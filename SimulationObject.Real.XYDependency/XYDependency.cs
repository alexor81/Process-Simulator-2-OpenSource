using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
using Utils.Panels.DoubleBar;
using Utils.Panels.DoubleIndicator;
using Utils.Panels.DoubleMeter;
using Utils.Panels.DoubleSlidingScale;
using Utils.Panels.DoubleTrend;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Real.XYDependency
{
    public class XYDependency : ISimulationObject, IDoubleValueRead, IObjectValueRead
    {
        #region Properties

            private double[]                        mXValues    = new double[] { 0.0D, 100.0D };
            private double[]                        mYValues    = new double[] { 0.0D, 100.0D };
            private readonly object                 mPointsLock = new object();
            public SortedDictionary<double, double> Points
            {
                get
                {
                    var lPoints = new SortedDictionary<double, double>();

                    lock(mPointsLock)
                    {
                        for (int i = 0; i < mXValues.Length; i++)
                        {
                            lPoints.Add(mXValues[i], mYValues[i]);
                        }
                    }

                    return lPoints;
                }
                set
                {
                    lock(mPointsLock)
                    {
                        mXValues = value.Keys.ToArray();
                        mYValues = value.Values.ToArray();
                    }
                    calc();
                }
            }

        #endregion

        #region IItemUser, IDoubleValueRead, IObjectValueRead

            public int                              mValueItemHandle = -1;
            private double                          mValue;
            public double                           ValueDouble
            {
                get { return mValue; }
            }
            public object                           ValueObject
            {
                get { return ValueDouble; }
            }

            public double[]                         Thresholds { get { return new double[0]; } }
            public string                           Units { get { return ""; } }

            public int                              mInputItemHandle = -1;
            private double                          mInput;
            public double                           Input
            {
                get { return mInput; }
            }

            private IItemBrowser                    mItemBrowser;
            public IItemBrowser                     ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                            ItemReadHandles
            {
                get
                {
                    return new int[] { mValueItemHandle, mInputItemHandle };
                }
            }

            public int[]                            ItemWriteHandles
            {
                get
                {
                    return new int[] { mValueItemHandle };
                }
            }

            private volatile bool                   mValueChanged = false;
            public bool                             IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                             getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged   = false;

                aItemHandles    = new int[] { mValueItemHandle };
                aItemValues     = new object[] { mValue };
            }

            public void                             onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mInputItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = Convert.ToDouble(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("X value conversion error. ", lExc);
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mInput, lValue))
                    {
                        mInput = lValue;
                        calc();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mValueItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = Convert.ToDouble(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Y value conversion error. " + lExc.Message, lExc.ToString());
                        mValueChanged = true;
                        return;
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mValue, lValue))
                    {
                        mValueChanged = true;
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]        mPanelList = new string[] { "Trend", "Indicator", "TextLabel", "Meter", "Bar", "SlidingScale" };
            public string[]                         PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                           getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Trend":           return new DoubleTrendPanel(this);
                    case "Indicator":       return new DoubleIndicatorPanel(this);
                    case "TextLabel":       return new ObjectTextLabelPanel(this);
                    case "Meter":           return new DoubleMeterPanel(this, 100, 0);
                    case "Bar":             return new DoubleBarPanel(this, 100, 0);
                    case "SlidingScale":    return new DoubleSlidingScalePanel(this);
                    default:                throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler               ChangedValues;
            public void                             raiseValuesChanged()
            {
                EventHandler lEvent = ChangedValues;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

            public event EventHandler               ChangedProperties;
            public void                             raisePropertiesChanged()
            {
                EventHandler lEvent = ChangedProperties;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult                     setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

            public void                             loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("Y");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("X");
                lChecker.addItemName(lItem);
                mInputItemHandle = mItemBrowser.getItemHandleByName(lItem);

                var lPoints = new SortedDictionary<double, double>();

                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("Points", StringComparison.Ordinal))
                {
                    aXMLTextReader.Read();

                    double lX, lY;

                    while (aXMLTextReader.Name.Equals("Point", StringComparison.Ordinal) && aXMLTextReader.IsStartElement())
                    {
                        lX = lReader.getAttribute<Double>("X");
                        lY = lReader.getAttribute<Double>("Y");

                        if(lPoints.ContainsKey(lX))
                        {
                            throw new ArgumentException("Point where X equals '" + lX.ToString() + "' already exists. ");
                        }

                        lPoints.Add(lX, lY);
                        aXMLTextReader.Read();
                    }
                }

                if (lPoints.Count >= 2)
                {
                    Points = lPoints;
                }
                else
                {
                    throw new ArgumentException("Points number must be equal or grater than two. ");
                }
            }

            public void                             saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Y", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteAttributeString("X", mItemBrowser.getItemNameByHandle(mInputItemHandle));

                aXMLTextWriter.WriteStartElement("Points");

                for(int i = 0; i < mXValues.Length; i++)
                {
                    aXMLTextWriter.WriteStartElement("Point");
                    aXMLTextWriter.WriteAttributeString("X", StringUtils.ObjectToString(mXValues[i]));
                    aXMLTextWriter.WriteAttributeString("Y", StringUtils.ObjectToString(mYValues[i]));
                    aXMLTextWriter.WriteEndElement();
                }

                aXMLTextWriter.WriteEndElement();
            }

            private void                            calc()
            {
                double lLastOutValue = mValue;

                lock(mPointsLock)
                {
                    int lLast = mXValues.Length - 1;

                    if (mInput <= mXValues[0])
                    {
                        mValue = mYValues[0];
                    }
                    else if (mInput >= mXValues[lLast])
                    {
                        mValue = mYValues[lLast];
                    }
                    else
                    {
                        int lFirst = 0;
                        int lMiddle = 0;
                        double lValue;

                        while (lFirst <= lLast)
                        {
                            lMiddle = lFirst + (lLast - lFirst) / 2;
                            lValue = mXValues[lMiddle];

                            if (lValue > mInput)
                            {
                                lLast = lMiddle - 1;
                            }
                            else if (lValue < mInput)
                            {
                                lFirst = lMiddle + 1;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (lMiddle > 0)
                        {
                            double lY1 = mYValues[lMiddle - 1];
                            double lY2 = mYValues[lMiddle];

                            if (ValuesCompare.EqualDelta1.compare(lY1, lY2))
                            {
                                mValue = lY1;
                            }
                            else
                            {
                                double lX1 = mXValues[lMiddle - 1];
                                double lX2 = mXValues[lMiddle];

                                mValue = lY1 + (lY2 - lY1) / (lX2 - lX1) * (mInput - lX1);
                            }
                        }
                        else
                        {
                            double lY1 = mYValues[lMiddle];
                            double lY2 = mYValues[lMiddle + 1];

                            if (ValuesCompare.EqualDelta1.compare(lY1, lY2))
                            {
                                mValue = lY1;
                            }
                            else
                            {
                                double lX1 = mXValues[lMiddle];
                                double lX2 = mXValues[lMiddle + 1];

                                mValue = lY1 + (lY2 - lY1) / (lX2 - lX1) * (mInput - lX1);
                            }
                        }
                    }
                }
                
                if (ValuesCompare.NotEqualDelta1.compare(lLastOutValue, mValue))
                {
                    mValueChanged = true;
                    raiseValuesChanged();
                }
            }

            public void                             execute()
            {
            }

            public void                             beforeActivate()
            {
            }

            public void                             afterDeactivate()
            {
            }

            public event EventHandler<MessageStringEventArgs> SimulationObjectError;
            private void                            raiseSimulationObjectError(string aMessage)
            {
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
            }

            public string                           LastError
            {
                get { return ""; }
            }

            public string[]                         ContextMenuItemList
            {
                get { return new string[0]; }
            }

            public void                             onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
            }

        #endregion

        #region IDisposable

            private bool                            mDisposed = false;

            public void                             Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void                  Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    mDisposed = true;
                }
            }

        #endregion
    }
}
