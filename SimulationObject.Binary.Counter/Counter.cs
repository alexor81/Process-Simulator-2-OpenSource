// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Binary.Counter.Panels;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
using Utils.Panels.DoubleBar;
using Utils.Panels.DoubleEditBox;
using Utils.Panels.DoubleIndicator;
using Utils.Panels.DoubleMeter;
using Utils.Panels.DoubleSlidingScale;
using Utils.Panels.DoubleTrend;
using Utils.Panels.ObjectDropDownList;
using Utils.Panels.ObjectRadioButtonGroup;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Binary.Counter
{
    public class Counter: ISimulationObject, IDoubleValueReadWrite, IObjectValueReadWrite
    {
        #region Properties

            public enum             EFront
            {
                Positive = 0,
                Negative = 1,
                Both     = 2
            }

            private EFront          mFront          = EFront.Positive;
            public EFront           Front
            {
                get { return mFront; }
                set
                {
                    mFront = value;
                    raisePropertiesChanged();
                }
            }

            private bool            mPositiveInc    = true;
            public bool             PositiveInc
            {
                get { return mPositiveInc; }
                set
                {
                    mPositiveInc = value;
                    raisePropertiesChanged();
                }
            }


            private bool            mNegativeInc    = false;
            public bool             NegativeInc
            {
                get { return mNegativeInc; }
                set
                {
                    mNegativeInc = value;
                    raisePropertiesChanged();
                }
            }

            public bool             mReadOutput     = true;

        #endregion

        #region IItemUser, IDoubleValueRead, IObjectValueRead

            public int              mOutValueItemHandle = -1;
            public int              mOutValue;
            public double           ValueDouble
            {
                get{ return mOutValue; }
                set
                {
                    ValueObject = value;
                }
            }
            public object           ValueObject
            {
                get { return mOutValue; }
                set
                {
                    int lNewValue;
                    try
                    {
                        lNewValue = Convert.ToInt32(value);
                    }
                    catch (Exception lExc)
                    {
                        raiseSimulationObjectError(lExc.Message);
                        return;
                    }

                    if(lNewValue != mOutValue)
                    {
                        mOutValue       = lNewValue;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }
            public void             Reset()
            {
                if (mOutValue != 0)
                {
                    mOutValue       = 0;
                    mValueChanged   = true;
                    raiseValuesChanged();
                }
            }


            public double[]         Thresholds { get { return new double[0]; } }
            public string           Units { get { return ""; } }
            public double           Maximum { get { return Int32.MaxValue; } }
            public double           Minimum { get { return Int32.MinValue; } }

            public int              mInValueItemHandle = -1;
            public bool             mInValue;

            private IItemBrowser    mItemBrowser;
            public IItemBrowser     ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]            ItemReadHandles
            {
                get
                {
                    if (mReadOutput)
                    {
                        return new int[] { mInValueItemHandle, mOutValueItemHandle };
                    }
                    else
                    {
                        return new int[] { mInValueItemHandle };
                    }
                }
            }

            public int[]            ItemWriteHandles
            {
                get
                {
                    return new int[] { mOutValueItemHandle };
                }
            }

            private volatile bool   mValueChanged = false;
            public bool             IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void             getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged   = false;

                aItemHandles    = new int[] { mOutValueItemHandle };
                aItemValues     = new object[] { mOutValue };
            }

            public void             onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mInValueItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value conversion error. ", lExc);
                    }

                    if (mInValue != lValue)
                    {
                        mInValue = lValue;
                        count();
                    }

                    return;
                }

                if (mReadOutput && aItemHandle == mOutValueItemHandle)
                {
                    int lValue;
                    try
                    {
                        lValue = Convert.ToInt32(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Output value conversion error. " + lExc.Message, lExc.ToString());
                        mValueChanged = true;
                        return;
                    }

                    if (mOutValue != lValue)
                    {
                        mOutValue = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[] mPanelList = new string[] { "Counter", "Trend", "Indicator", "TextLabel", "Meter", "Bar", "SlidingScale", "EditBox", "RadioButton", "DropDownList" };
            public string[]         PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel           getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Counter":         return new CounterPanel(this);
                    case "Trend":           return new DoubleTrendPanel(this);
                    case "Indicator":       return new DoubleIndicatorPanel(this);
                    case "TextLabel":       return new ObjectTextLabelPanel(this);
                    case "EditBox":         return new DoubleEditBoxPanel(this);
                    case "RadioButton":     return new RadioButtonGroupPanel(this);
                    case "DropDownList":    return new DropDownListPanel(this);
                    case "Meter":           return new DoubleMeterPanel(this, 100, 0);
                    case "Bar":             return new DoubleBarPanel(this, 100, 0);
                    case "SlidingScale":    return new DoubleSlidingScalePanel(this);
                    default:                throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler ChangedValues;
            public void             raiseValuesChanged()
            {
                ChangedValues?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler ChangedProperties;
            public void             raisePropertiesChanged()
            {
                ChangedProperties?.Invoke(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult     setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

            public void             loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                mFront          = (EFront)Enum.Parse(typeof(EFront), lReader.getAttribute<String>("Front"));
                mPositiveInc    = lReader.getAttribute<Boolean>("PositiveIncrease");
                mNegativeInc    = lReader.getAttribute<Boolean>("NegativeIncrease");

                string lItem = lReader.getAttribute<String>("Input");
                lChecker.addItemName(lItem);
                mInValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Output");
                lChecker.addItemName(lItem);
                mOutValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mReadOutput = lReader.getAttribute<Boolean>("ReadOutput", mReadOutput);
            }

            public void             saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Front", mFront.ToString());
                aXMLTextWriter.WriteAttributeString("PositiveIncrease", StringUtils.ObjectToString(mPositiveInc));
                aXMLTextWriter.WriteAttributeString("NegativeIncrease", StringUtils.ObjectToString(mNegativeInc));
                aXMLTextWriter.WriteAttributeString("Input", mItemBrowser.getItemNameByHandle(mInValueItemHandle));
                aXMLTextWriter.WriteAttributeString("Output", mItemBrowser.getItemNameByHandle(mOutValueItemHandle));
                aXMLTextWriter.WriteAttributeString("ReadOutput", StringUtils.ObjectToString(mReadOutput));
            }

            private bool            mPrevInValue;

            private void            count()
            {
                if (mPrevInValue != mInValue)
                {
                    bool lValueChanged = false;

                    if(mPrevInValue == false)
                    {
                        if(mFront == EFront.Positive || mFront == EFront.Both)
                        {
                            if(mPositiveInc)
                            {
                                mOutValue = mOutValue + 1;
                            }
                            else
                            {
                                mOutValue = mOutValue - 1;
                            }
                            lValueChanged = true;
                        }
                    }
                    else
                    {
                        if(mFront == EFront.Negative || mFront == EFront.Both)
                        {
                            if (mNegativeInc)
                            {
                                mOutValue = mOutValue + 1;
                            }
                            else
                            {
                                mOutValue = mOutValue - 1;
                            }
                            lValueChanged = true;
                        }
                    }

                    mPrevInValue = mInValue;

                    if (lValueChanged)
                    {
                        mValueChanged = true;                  
                    }

                    raiseValuesChanged();
                }
            }

            public void             execute()
            {
            }

            public void             beforeActivate()
            {
            }

            public void             afterDeactivate()
            {
            }

            public event EventHandler<MessageStringEventArgs> SimulationObjectError;
            private void            raiseSimulationObjectError(string aMessage)
            {
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            public string           LastError
            {
                get { return ""; }
            }

            public string[]         ContextMenuItemList
            {
                get { return new string[0]; }
            }

            public void             onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
            }

        #endregion

        #region IDisposable

            private bool            mDisposed = false;

            public void             Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void  Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    mDisposed = true;
                }
            }

        #endregion
    }
}
