// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
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

namespace SimulationObject.Sensor.Analog
{
    public class AnalogSensor : ISimulationObject, IDoubleValueReadWrite, IObjectValueReadWrite
    {
        public                                                  AnalogSensor()
        {
            mFilter = new BackValueFilter(this, 500);
        }

        #region Properties

            public ValueScale                                   mValueScale = new ValueScale();

            public bool                                         mFault      = false;
            public double                                       mFaultValue = 32767;

        #endregion

        #region IItemUser, IDoubleValueReadWrite, IObjectValueReadWrite

            public int                                          mValueItemHandle = -1;
            private double                                      mValue;
            public double                                       ValueDouble
            {
                get
                {
                    if (mFault)
                    {
                        return mValueScale.scale(mFaultValue);
                    }
                    else
                    {
                        return mValue;
                    }
                }
                set
                {
                    mFault = false;

                    if (ValuesCompare.NotEqualDelta1.compare(mValue, value))
                    {
                        if (value <= mValueScale.OutMax && value >= mValueScale.OutMin)
                        {
                            mValue              = value;
                            mValueChangedByUI   = true;
                            mFilter.addOutValue(mValue);
                            checkThresholds();
                            mValueChanged       = true;
                            raiseValuesChanged();
                        }
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
            private volatile bool                               mValueChangedByUI;
            private BackValueFilter                             mFilter;

            public int[]                                        mThdItemHandles = new int[0];
            public bool[]                                       mThdItemValues  = new bool[0];
            public ValuesCompare[]                              mThdOperations  = new ValuesCompare[0];
            private double[]                                    mThdValues      = new double[0];
            public double[]                                     Thresholds
            { 
                get { return mThdValues;}
                set { mThdValues = value; }
            }
            private void                                        checkThresholds()
            {
                bool lNewValue;
                for (int i = 0; i < mThdItemHandles.Length; i++)
                {
                    lNewValue = mThdOperations[i].compare(mValue, mThdValues[i]);
                    if (lNewValue != mThdItemValues[i])
                    {
                        mThdItemValues[i]   = lNewValue;
                        mValueChanged       = true;
                    }
                }
            }

            private string                                      mUnits          = "%";
            public string                                       Units
            {
                get { return mUnits; }
                set { mUnits = value; }
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
                    return new int[] {mValueItemHandle};
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    lResult.Add(mValueItemHandle);
                    lResult.AddRange(mThdItemHandles);

                    return lResult.ToArray();
                }
            }

            private volatile bool                               mValueChanged   = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                bool lValueChanged      = mValueChanged;
                mValueChanged           = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                if (mFault)
                {
                    lHandles.Add(mValueItemHandle);
                    lValues.Add(mFaultValue);
                }
                else
                {
                    if (mValueChangedByUI || lValueChanged == false)
                    {
                        mValueChangedByUI = false;
                        lHandles.Add(mValueItemHandle);
                        lValues.Add(mValueScale.unscale(mValue));
                    }
                }

                for (int i = 0; i < mThdItemHandles.Length; i++)
                {
                    lHandles.Add(mThdItemHandles[i]);
                    lValues.Add(mThdItemValues[i]);
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                                         setValueOutside(double aValue)
            {
                mValue = aValue;
                checkThresholds();
                raiseValuesChanged();
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mValueItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = mValueScale.scale(Convert.ToDouble(aItemValue));
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value conversion error. ", lExc);
                    }

                    if (mFault)
                    {
                        if (ValuesCompare.NotEqualDelta1.compare(lValue, mFaultValue))
                        {
                            mValueChanged = true;
                        }
                    }
                    else
                    {
                        mFilter.addInValue(lValue);
                        if (mFilter.Ignore == false)
                        {
                            if (ValuesCompare.NotEqualDelta1.compare(lValue, mValue))
                            {
                                if (lValue <= mValueScale.OutMax && lValue >= mValueScale.OutMin)
                                {
                                    setValueOutside(lValue);
                                }
                            }
                        }
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

                string lItem = lReader.getAttribute<String>("Item");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                double lPMax    = lReader.getAttribute<Double>("MaxPhysicalValue");
                double lPMin    = lReader.getAttribute<Double>("MinPhysicalValue");
                double lRawMax  = lReader.getAttribute<Double>("MaxRawValue");
                double lRawMin  = lReader.getAttribute<Double>("MinRawValue");
                mValueScale.setProperties(lRawMax, lRawMin, lPMax, lPMin);

                mFaultValue = lReader.getAttribute<Double>("FaultValue", mFaultValue);
                if (mFaultValue > lRawMin && mFaultValue < lRawMax)
                {
                    throw new ArgumentException("Fault value is inside normal range. ");
                }

                mUnits = lReader.getAttribute<String>("Units", mUnits);

                #region Thresholds

                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        aXMLTextReader.Read();
                        if (aXMLTextReader.Name.Equals("Thresholds", StringComparison.Ordinal))
                        {
                            if (aXMLTextReader.IsEmptyElement == false)
                            {
                                List<int> lItems                = new List<int>();
                                List<double> lValues            = new List<double>();
                                List<ValuesCompare> lOperations = new List<ValuesCompare>();
                                double lValue;

                                aXMLTextReader.Read();
                                while (aXMLTextReader.Name.Equals("Threshold", StringComparison.Ordinal))
                                {
                                    lOperations.Add(new ValuesCompare(lReader.getAttribute<String>("Operation")));

                                    lValue = lReader.getAttribute<Double>("Value");
                                    if (lValue > mValueScale.OutMax)
                                    {
                                        throw new ArgumentException("Threshold value is more than maximum of physical value. ");
                                    }
                                    if (lValue < mValueScale.OutMin)
                                    {
                                        throw new ArgumentException("Threshold value is less than minimum of physical value. ");
                                    }
                                    lValues.Add(lValue);

                                    lItem = lReader.getAttribute<String>("Item");
                                    lChecker.addItemName(lItem);
                                    lItems.Add(mItemBrowser.getItemHandleByName(lItem));

                                    aXMLTextReader.Read();
                                }

                                if (lOperations.Count != 0)
                                {
                                    mThdItemHandles = lItems.ToArray();
                                    mThdItemValues  = new bool[lOperations.Count];
                                    mThdValues      = lValues.ToArray();
                                    mThdOperations  = lOperations.ToArray();
                                }
                            }

                            aXMLTextReader.Read();
                        }
                    }

                #endregion
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Item", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteAttributeString("MaxRawValue", StringUtils.ObjectToString(mValueScale.InMax));
                aXMLTextWriter.WriteAttributeString("MinRawValue", StringUtils.ObjectToString(mValueScale.InMin));
                aXMLTextWriter.WriteAttributeString("FaultValue", StringUtils.ObjectToString(mFaultValue));
                aXMLTextWriter.WriteAttributeString("MaxPhysicalValue", StringUtils.ObjectToString(mValueScale.OutMax));
                aXMLTextWriter.WriteAttributeString("MinPhysicalValue", StringUtils.ObjectToString(mValueScale.OutMin));
                aXMLTextWriter.WriteAttributeString("Units", mUnits);
                if (mThdItemHandles.Length > 0)
                {
                    aXMLTextWriter.WriteStartElement("Thresholds");
                    for (int i = 0; i < mThdItemHandles.Length; i++)
                    {
                        aXMLTextWriter.WriteStartElement("Threshold");
                        aXMLTextWriter.WriteAttributeString("Operation", mThdOperations[i].OperationName);
                        aXMLTextWriter.WriteAttributeString("Value", StringUtils.ObjectToString(mThdValues[i]));
                        aXMLTextWriter.WriteAttributeString("Item", mItemBrowser.getItemNameByHandle(mThdItemHandles[i]));
                        aXMLTextWriter.WriteEndElement();
                    }
                    aXMLTextWriter.WriteEndElement();
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
                get
                {
                    if (mFault)
                    {
                        return new string[] { "Reset fault" };
                    }
                    else
                    {
                        return new string[] { "Set fault" };
                    }
                }
            }

            public void                                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
                mFault = !mFault;

                if (mFault == false)
                {
                    mValueChangedByUI = true;
                }

                mValueChanged   = true;
                raiseValuesChanged();
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
                    if (aDisposing)
                    {
                        if (mFilter != null)
                        {
                            mFilter.Dispose();
                            mFilter = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
