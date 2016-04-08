using API;
using SimulationObject.Real.Comparator.Panel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
using Utils.Panels.BooleanIndicator;
using Utils.Panels.BooleanTrend;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Real.Comparator
{
    public class Comparator : ISimulationObject, IBooleanValueRead, IObjectValueRead
    {
        public                                                  Comparator()
        {
            compare();
        }

        #region Properties

            private ValuesCompare                               mValuesCompare = new ValuesCompare();

            public int                                          OperationIndex
            {
                get { return mValuesCompare.OperationNumber; }
                set
                {
                    if (mValuesCompare.OperationNumber != value)
                    {
                        mValuesCompare.OperationNumber = value;
                        raisePropertiesChanged();
                        compare();
                    }
                }
            }
            public string                                       OperationString
            {
                get { return mValuesCompare.OperationName; }
                set
                {
                    if (mValuesCompare.OperationName.Equals(value, StringComparison.Ordinal) == false)
                    {
                        mValuesCompare.OperationName = value;
                        raisePropertiesChanged();
                        compare();
                    }
                }
            }

        #endregion

        #region IItemUser, IBooleanValueRead, IObjectValueRead

            public int                                          mValueItemHandle = -1;
            private bool                                        mValue;
            public bool                                         ValueBoolean
            {
                get
                {
                    return mValue;
                }
            }
            public object                                       ValueObject
            {
                get { return ValueBoolean; }
            }

            public int                                          mInput1ItemHandle = -1;
            private double                                      mInput1;
            public double                                       Input1
            {
                get { return mInput1; }
            }

            public int                                          mInput2ItemHandle = -1;
            private double                                      mInput2;
            public double                                       Input2
            {
                get { return mInput2; }
            }

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    lResult.Add(mValueItemHandle);
                    lResult.Add(mInput1ItemHandle);
                    lResult.Add(mInput2ItemHandle);

                    return lResult.ToArray();
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    lResult.Add(mValueItemHandle);

                    return lResult.ToArray();
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged = false;

                aItemHandles = new int[] { mValueItemHandle };
                aItemValues = new object[] { mValue };
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mInput1ItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = Convert.ToDouble(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value №1 conversion error. ", lExc);
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mInput1, lValue))
                    {
                        mInput1 = lValue;
                        compare();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mInput2ItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = Convert.ToDouble(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value №2 conversion error. ", lExc);
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mInput2, lValue))
                    {
                        mInput2 = lValue;
                        compare();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mValueItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Output value conversion error. " + lExc.Message, lExc.ToString());
                        mValueChanged = true;
                        return;
                    }

                    if (mValue != lValue)
                    {
                        mValueChanged = true;
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Comparator", "Indicator", "Trend", "TextLabel" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Comparator":  return new ComparatorPanel(this);
                    case "Indicator":   return new BooleanIndicatorPanel(this);
                    case "Trend":       return new BooleanTrendPanel(this);
                    case "TextLabel":   return new ObjectTextLabelPanel(this);
                    default:            throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler                           ChangedValues;
            public void                                         raiseValuesChanged()
            {
                EventHandler lEvent = ChangedValues;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

            public event EventHandler                           ChangedProperties;
            public void                                         raisePropertiesChanged()
            {
                EventHandler lEvent = ChangedProperties;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult                                 setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

            public void                                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                OperationString = lReader.getAttribute<String>("Operation");

                string lItem = lReader.getAttribute<String>("Input1");
                lChecker.addItemName(lItem);
                mInput1ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Input2");
                lChecker.addItemName(lItem);
                mInput2ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Operation", OperationString);
                aXMLTextWriter.WriteAttributeString("Input1", mItemBrowser.getItemNameByHandle(mInput1ItemHandle));
                aXMLTextWriter.WriteAttributeString("Input2", mItemBrowser.getItemNameByHandle(mInput2ItemHandle));
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mValueItemHandle));
            }

            private void                                        compare()
            {
                bool lLastOutValue = mValue;

                mValue = mValuesCompare.compare(mInput1, mInput2);

                if (lLastOutValue != mValue)
                {
                    mValueChanged = true;
                    raiseValuesChanged();
                }
            }

            public void                                         execute()
            {
            }

            public void                                         beforeActivate()
            {
            }

            public void                                         afterDeactivate()
            {
            }

            public event EventHandler<MessageStringEventArgs>   SimulationObjectError;
            private void                                        raiseSimulationObjectError(string aMessage)
            {
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
            }

            public string                                       LastError
            {
                get { return ""; }
            }

            public string[]                                     ContextMenuItemList
            {
                get { return new string[0]; }
            }

            public void                                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
            }

        #endregion

        #region IDisposable

            private bool                                        mDisposed = false;

            public void                                         Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void                              Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    mDisposed = true;
                }
            }

        #endregion
    }
}
