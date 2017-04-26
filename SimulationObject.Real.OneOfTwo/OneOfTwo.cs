// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Real.OneOfTwo.Panels;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Panels.DoubleBar;
using Utils.Panels.DoubleIndicator;
using Utils.Panels.DoubleMeter;
using Utils.Panels.DoubleSlidingScale;
using Utils.Panels.DoubleTrend;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Real.OneOfTwo
{
    public class OneOfTwo : ISimulationObject, IDoubleValueRead, IObjectValueRead
    {
        public                                                  OneOfTwo()
        {
            mFSM = new FiniteStateMachine("Stable", () => StableState());
            mFSM.addState("ToIn1", () => ToIn1State());
            mFSM.addState("ToIn2", () => ToIn2State());
        }

        #region Properties

            private double                                      mIn1ToIn2PerMS  = 0;
            private uint                                        mIn1ToIn2MS     = 0;
            public uint                                         In1ToIn2MS
            {
                get { return mIn1ToIn2MS; }
                set
                {
                    if (mIn1ToIn2MS != value)
                    {
                        mIn1ToIn2MS = value;

                        if (mIn1ToIn2MS > 0)
                        {
                            mIn1ToIn2PerMS = 100.0D / mIn1ToIn2MS;
                        }

                        raisePropertiesChanged();
                    }
                }
            }

            private double                                      mIn2ToIn1PerMS  = 0;
            private uint                                        mIn2ToIn1MS     = 0;
            public uint                                         In2ToIn1MS
            {
                get { return mIn2ToIn1MS; }
                set
                {
                    if (mIn2ToIn1MS != value)
                    {
                        mIn2ToIn1MS = value;

                        if (mIn2ToIn1MS > 0)
                        {
                            mIn2ToIn1PerMS = 100.0D / mIn2ToIn1MS;
                        }

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
                get{ return mValue; }
            }
            public object                                       ValueObject
            {
                get { return ValueDouble; }
            }

            public double[]                                     Thresholds { get { return new double[0]; } }
            public string                                       Units { get { return ""; } }

            public int                                          mSwitchItemHandle = -1;
            private bool                                        mSwitch;
            private bool                                        mSwitchChanged;
            public bool                                         Switch
            {
                get { return mSwitch; }
                set
                {
                    if (mSwitch != value)
                    {
                        mSwitch         = value;
                        simpleSwitch(Changes.Switch);
                        mSwitchChanged  = true;
                        mValueChanged   = true;

                        raiseValuesChanged();
                    }
                }
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
                    return new int[] {mSwitchItemHandle, mInput1ItemHandle, mInput2ItemHandle};
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return new int[] {mSwitchItemHandle, mValueItemHandle};
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                bool lValueChanged  = mValueChanged;
                mValueChanged       = false;
    
                if (!lValueChanged || mSwitchChanged)
                {
                    mSwitchChanged = false;
                    aItemHandles    = new int[] { mValueItemHandle, mSwitchItemHandle };
                    aItemValues     = new object[] { mValue, mSwitch };
                }
                else
                {
                    aItemHandles    = new int[] { mValueItemHandle };
                    aItemValues     = new object[] { mValue };
                }
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
                        simpleSwitch(Changes.In1);
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
                        simpleSwitch(Changes.In2);
                        raiseValuesChanged();
                    }

                    return;
                }
            
                if (aItemHandle == mSwitchItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for 'Switch' state. ", lExc);
                    }

                    if (mSwitch != lValue)
                    {
                        mSwitch = lValue;
                        simpleSwitch(Changes.Switch);
                        raiseValuesChanged();
                    }

                    return;
                }    
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "OneOfTwo", "Trend", "Indicator", "TextLabel", "Meter", "Bar", "SlidingScale" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "OneOfTwo":        return new OneOfTwoPanel(this);
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

                string lItem = lReader.getAttribute<String>("Switch");
                lChecker.addItemName(lItem);
                mSwitchItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Input1");
                lChecker.addItemName(lItem);
                mInput1ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Input2");
                lChecker.addItemName(lItem);
                mInput2ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                In2ToIn1MS = lReader.getAttribute<UInt32>("In2ToIn1MS", mIn2ToIn1MS);
                In1ToIn2MS = lReader.getAttribute<UInt32>("In1ToIn2MS", mIn1ToIn2MS);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Switch", mItemBrowser.getItemNameByHandle(mSwitchItemHandle));
                aXMLTextWriter.WriteAttributeString("Input1", mItemBrowser.getItemNameByHandle(mInput1ItemHandle));
                aXMLTextWriter.WriteAttributeString("Input2", mItemBrowser.getItemNameByHandle(mInput2ItemHandle));
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteAttributeString("In2ToIn1MS", StringUtils.ObjectToString(mIn2ToIn1MS));
                aXMLTextWriter.WriteAttributeString("In1ToIn2MS", StringUtils.ObjectToString(mIn1ToIn2MS));
            }

            private enum Changes
            {
                In1,
                In2,
                Switch
            }

            private void                                        simpleSwitch(Changes aChanges)
            {
                switch(aChanges)
                {
                    case Changes.In1:       if (mSwitch) 
                                            {
                                                mValue          = mInput1;
                                                mValueChanged   = true;
                                            }
                                            break;

                    case Changes.In2:       if (!mSwitch) 
                                            {
                                                mValue          = mInput2;
                                                mValueChanged   = true;
                                            }
                                            break;

                    case Changes.Switch:    if (mSwitch)
                                            {
                                                if (mIn2ToIn1MS == 0)
                                                {
                                                    mValue          = mInput1;
                                                    mValueChanged   = true;
                                                }
                                                else
                                                {
                                                    mLastMS     = MiscUtils.TimerMS;
                                                    mFSM.State  = "ToIn1";
                                                }
                                            }
                                            else
                                            {
                                                if (mIn1ToIn2MS == 0)
                                                {
                                                    mValue          = mInput2;
                                                    mValueChanged   = true;
                                                }
                                                else
                                                {
                                                    mLastMS     = MiscUtils.TimerMS;
                                                    mFSM.State  = "ToIn2";
                                                }
                                            }
                                            break;
                }
            }

            private FiniteStateMachine                          mFSM;
            private long                                        mLastMS;
            private void                                        StableState()
            {
                if (mSwitch)
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mInput1, mValue))
                    {
                        mValue          = mInput1;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
                else
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mInput2, mValue))
                    {
                        mValue          = mInput2;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            private void                                        ToIn1State()
            {
                var lMS = (double)(MiscUtils.TimerMS - mLastMS);
                mLastMS = MiscUtils.TimerMS;

                if (mInput1 > mInput2)
                {
                    mValue = mValue + mIn2ToIn1PerMS * lMS;

                    if (mValue >= mInput1)
                    {
                        mValue      = mInput1;                     
                        mFSM.State  = "Stable"; 
                    }
                }
                else
                {
                    mValue = mValue - mIn2ToIn1PerMS * lMS;

                    if (mValue <= mInput1)
                    {
                        mValue      = mInput1;         
                        mFSM.State  = "Stable";
                    }
                }

                mValueChanged = true;
                raiseValuesChanged();
            }

            private void                                        ToIn2State()
            {
                var lMS = (double)(MiscUtils.TimerMS - mLastMS);
                mLastMS = MiscUtils.TimerMS;

                if (mInput2 > mInput1)
                {
                    mValue = mValue + mIn1ToIn2PerMS * lMS;

                    if (mValue >= mInput2)
                    {
                        mValue      = mInput2;         
                        mFSM.State  = "Stable"; 
                    }
                }
                else
                {
                    mValue = mValue - mIn1ToIn2PerMS * lMS;

                    if (mValue <= mInput2)
                    {
                        mValue      = mInput2;         
                        mFSM.State  = "Stable";
                    }
                }

                mValueChanged = true;
                raiseValuesChanged();
            }

            public void                                         execute()
            {
                mFSM.executeStateAction();
            }

            public void                                         beforeActivate()
            {
                mFSM.State = "Stable";
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
                    if (aDisposing)
                    {
                        if (mFSM != null)
                        {
                            mFSM.Dispose();
                            mFSM = null;
                        }
                    }
                    mDisposed = true;
                }
            }

        #endregion
    }
}
