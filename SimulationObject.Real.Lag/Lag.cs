// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Real.Lag.Panel;
using System;
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

namespace SimulationObject.Real.Lag
{
    public class Lag : ISimulationObject, IDoubleValueRead, IObjectValueRead
    {
        #region Properties

            private uint                                        mLagMS = 0;
            public uint                                         LagMS
            {
                get { return mLagMS; }
                set
                {
                    if (mLagMS != value)
                    {
                        mLagMS = value;
                        raisePropertiesChanged();
                    }
                }
            }

            private double                                      mGain = 0.0D;
            public double                                       Gain
            {
                get { return mGain; }
                set
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mGain, value))
                    {
                        mGain = value;
                        raisePropertiesChanged();
                    }
                }
            }

        #endregion

        #region IItemUser, IDoubleValueRead, IObjectValueRead

            public int                                          mValueItemHandle = -1;
            private double                                      mValue;
            public double                                       ValueDouble
            {
                get { return mValue; }
            }
            public object                                       ValueObject
            {
                get { return ValueDouble; }
            }

            public double[]                                     Thresholds { get { return new double[0]; } }
            public string                                       Units { get { return ""; } }

            public int                                          mInputItemHandle = -1;
            private double                                      mInput;
            public double                                       Input
            {
                get { return mInput; }
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
                    return new int[] { mInputItemHandle };
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return new int[] { mValueItemHandle };
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged   = false;

                aItemHandles    = new int[] { mValueItemHandle };
                aItemValues     = new object[] { mValue };
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
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
                        throw new ArgumentException("Input value conversion error. ", lExc);
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mInput, lValue))
                    {
                        mInput = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Lag", "Trend", "Indicator", "TextLabel", "Meter", "Bar", "SlidingScale" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Lag":             return new LagPanel(this);
                    case "Trend":           return new DoubleTrendPanel(this);
                    case "Indicator":       return new DoubleIndicatorPanel(this);
                    case "TextLabel":       return new ObjectTextLabelPanel(this);
                    case "Meter":           return new DoubleMeterPanel(this, 100, 0);
                    case "Bar":             return new DoubleBarPanel(this, 100, 0);
                    case "SlidingScale":    return new DoubleSlidingScalePanel(this);
                    default:                throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler                           ChangedValues;
            public void                                         raiseValuesChanged()
            {
                ChangedValues?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler                           ChangedProperties;
            public void                                         raisePropertiesChanged()
            {
                ChangedProperties?.Invoke(this, EventArgs.Empty);
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

                string lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Input");
                lChecker.addItemName(lItem);
                mInputItemHandle = mItemBrowser.getItemHandleByName(lItem);

                LagMS   = lReader.getAttribute<UInt32>("LagMS", LagMS);
                Gain    = lReader.getAttribute<Double>("Gain", Gain);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteAttributeString("Input", mItemBrowser.getItemNameByHandle(mInputItemHandle));
                aXMLTextWriter.WriteAttributeString("LagMS", StringUtils.ObjectToString(LagMS));
                aXMLTextWriter.WriteAttributeString("Gain", StringUtils.ObjectToString(Gain));
            }

            private double                                      mLastInput  = 0.0D;

            private long                                        mLastMS;
            public void                                         execute()
            {
                double lLastOutValue    = mValue;
                double lDTimeMS         = MiscUtils.TimerMS - mLastMS;

                mValue = mValue + lDTimeMS / ((double)mLagMS + lDTimeMS) * (mGain * (mLastInput + mInput) / 2.0D - mValue);

                if (ValuesCompare.NotEqualDelta1.compare(lLastOutValue, mValue))
                {
                    mValueChanged = true;
                    raiseValuesChanged();
                }

                mLastMS     = MiscUtils.TimerMS;
                mLastInput  = mInput;
            }

            public void                                         beforeActivate()
            {
                mLastMS     = MiscUtils.TimerMS;
                mLastInput  = mInput;
            }

            public void                                         afterDeactivate()
            {
            }

            public event EventHandler<MessageStringEventArgs>   SimulationObjectError;
            private void                                        raiseSimulationObjectError(string aMessage)
            {
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
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
