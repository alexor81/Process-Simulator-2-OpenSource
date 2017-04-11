// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Panels.DoubleBar;
using Utils.Panels.DoubleEditBox;
using Utils.Panels.DoubleIndicator;
using Utils.Panels.DoubleKnob;
using Utils.Panels.DoubleMeter;
using Utils.Panels.DoubleSlider;
using Utils.Panels.DoubleSlidingScale;
using Utils.Panels.DoubleTrend;
using Utils.Panels.ObjectDropDownList;
using Utils.Panels.ObjectRadioButtonGroup;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Real.Scale
{
    public class ScaleReal : ISimulationObject, IDoubleValueReadWrite, IObjectValueReadWrite
    {
        #region Properties

            public ValueScale                                   mValueScale = new ValueScale();

        #endregion

        #region IItemUser, IDoubleValueReadWrite, IObjectValueReadWrite

            public int                                          mInValueItemHandle  = -1;
            private double                                      mInValue;
            private bool                                        mInValueChanged;

            public int                                          mOutValueItemHandle = -1;
            private double                                      mOutValue;
            private bool                                        mOutValueChanged;
            public double                                       ValueDouble
            {
                get { return mOutValue; }
                set
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mOutValue, value))
                    {
                        double lNewInValue;

                        try
                        {
                            if (value > mValueScale.OutMax || value < mValueScale.OutMin)
                            {
                                return;
                            }

                            lNewInValue = mValueScale.unscale(value);
                            if (lNewInValue > mValueScale.InMax || lNewInValue < mValueScale.InMin)
                            {
                                return;
                            }
                        }
                        catch
                        {
                            return;
                        }

                        mOutValue           = value;
                        mOutValueChanged    = true;

                        if (ValuesCompare.NotEqualDelta1.compare(lNewInValue, mInValue))
                        {
                            mInValue        = lNewInValue;
                            mInValueChanged = true;
                        }

                        mValueChanged = true;
                        raiseValuesChanged();
                    }
                }
            }
            public object                                       ValueObject
            {
                get { return ValueDouble; }
                set
                {
                    try
                    {
                        ValueDouble = Convert.ToDouble(value);
                    }
                    catch (Exception lExc)
                    {
                        raiseSimulationObjectError(lExc.Message);
                    }
                }
            }

            public double[]                                     Thresholds{ get { return new double[0]; } }
            public string                                       Units { get { return ""; } }

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    return new int[] { mInValueItemHandle, mOutValueItemHandle };
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return new int[] { mInValueItemHandle, mOutValueItemHandle };
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
                if (mInValueChanged && mOutValueChanged)
                {
                    mInValueChanged     = false;
                    mOutValueChanged    = false;
                    aItemHandles        = new int[] { mInValueItemHandle, mOutValueItemHandle };
                    aItemValues         = new object[] { mInValue, mOutValue };
                }
                else if (mInValueChanged)
                {
                    mInValueChanged = false;
                    aItemHandles    = new int[] { mInValueItemHandle };
                    aItemValues     = new object[] { mInValue };
                }
                else
                {
                    mOutValueChanged    = false;
                    aItemHandles        = new int[] { mOutValueItemHandle };
                    aItemValues         = new object[] { mOutValue };
                }
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mInValueItemHandle)
                {
                    double lNewInValue;
                    double lNewOutValue;
                    try
                    {
                        lNewInValue = Convert.ToDouble(aItemValue);
                        if (lNewInValue > mValueScale.InMax || lNewInValue < mValueScale.InMin)
                        {
                            throw new ArgumentException("Value is out of range. ");
                        }
                        lNewOutValue = mValueScale.scale(lNewInValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value conversion error. ", lExc);
                    }

                    mInValue = lNewInValue;

                    if (ValuesCompare.NotEqualDelta1.compare(lNewOutValue, mOutValue))
                    {
                        mOutValue           = lNewOutValue;
                        mOutValueChanged    = true;
                        mValueChanged       = true;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mOutValueItemHandle)
                {
                    double lNewInValue;
                    double lNewOutValue;
                    try
                    {
                        lNewOutValue = Convert.ToDouble(aItemValue);
                        if (lNewOutValue > mValueScale.OutMax || lNewOutValue < mValueScale.OutMin)
                        {
                            throw new ArgumentException("Value is out of range. ");
                        }
                        lNewInValue = mValueScale.unscale(lNewOutValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Output value conversion error. ", lExc);
                    }

                    mOutValue = lNewOutValue;

                    if (ValuesCompare.NotEqualDelta1.compare(lNewInValue, mInValue))
                    {
                        mInValue        = lNewInValue;
                        mInValueChanged = true;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }

                    return;
                }
            }

            public double                                       Maximum { get { return mValueScale.OutMax; } }

            public double                                       Minimum { get { return mValueScale.OutMin; } }


        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Trend", "Indicator", "Slider", "Knob", "EditBox", "RadioButton", "DropDownList", "TextLabel", "Meter", "Bar", "SlidingScale" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Trend":           return new DoubleTrendPanel(this);
                    case "Indicator":       return new DoubleIndicatorPanel(this);
                    case "Slider":          return new DoubleSliderPanel(this);
                    case "Knob":            return new DoubleKnobPanel(this);
                    case "EditBox":         return new DoubleEditBoxPanel(this);
                    case "RadioButton":     return new RadioButtonGroupPanel(this);
                    case "DropDownList":    return new DropDownListPanel(this);
                    case "TextLabel":       return new ObjectTextLabelPanel(this);
                    case "Meter":           return new DoubleMeterPanel(this);
                    case "Bar":             return new DoubleBarPanel(this);
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
                    raisePropertiesChanged();
                }

                return lResult;
            }

            public void                                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("InputItem");
                lChecker.addItemName(lItem);
                mInValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("OutputItem");
                lChecker.addItemName(lItem);
                mOutValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                double lInMax   = lReader.getAttribute<Double>("MaxInputValue");
                double lInMin   = lReader.getAttribute<Double>("MinInputValue");
                double lOutMax  = lReader.getAttribute<Double>("MaxOutputValue");
                double lOutMin  = lReader.getAttribute<Double>("MinOutputValue");

                mValueScale.setProperties(lInMax, lInMin, lOutMax, lOutMin);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("InputItem", mItemBrowser.getItemNameByHandle(mInValueItemHandle));
                aXMLTextWriter.WriteAttributeString("MaxInputValue", StringUtils.ObjectToString(mValueScale.InMax));
                aXMLTextWriter.WriteAttributeString("MinInputValue", StringUtils.ObjectToString(mValueScale.InMin));
                aXMLTextWriter.WriteAttributeString("OutputItem", mItemBrowser.getItemNameByHandle(mOutValueItemHandle));
                aXMLTextWriter.WriteAttributeString("MaxOutputValue", StringUtils.ObjectToString(mValueScale.OutMax));
                aXMLTextWriter.WriteAttributeString("MinOutputValue", StringUtils.ObjectToString(mValueScale.OutMin));
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
                mLastError = aMessage;
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            private string                                      mLastError;
            public string                                       LastError
            {
                get { return mLastError; }
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
