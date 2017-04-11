// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Pipeline.Valve.Panels.ValveControl;
using SimulationObject.Pipeline.Valve.Panels.ValveState;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;

namespace SimulationObject.Pipeline.Valve
{
    public class Valve : ISimulationObject
    {
        public                                                  Valve()
        {
            mFSM = new FiniteStateMachine("Stoped", () => ValveStoped());
            mFSM.addState("Opens", () => ValveOpens());
            mFSM.addState("Closes", () => ValveCloses());
            mFSM.addState("Esd", () => ValveEsd());
        }

        #region Properties

            private double                                      mPosPerMS           = 0.025D;

            private double                                      mLimitSwitchOff     = 25.0D;
            private double                                      LimitSwitchOff
            {
                get { return mLimitSwitchOff; }
                set
                {
                    if (value > 100.0D)
                    {
                        mLimitSwitchOff = 100.0D;
                    }
                    else
                    {
                        mLimitSwitchOff = value;
                    }
                }
            }

            private uint                                        mLimitSwitchMS      = 1000;
            public uint                                         LimitSwitchMS
            {
                get { return mLimitSwitchMS; }
                set
                {
                    if (mLimitSwitchMS != value)
                    {
                        if (value == 0)
                        {
                            mLimitSwitchMS = 1;
                        }
                        else
                        {
                            mLimitSwitchMS = value;
                        }
                        
                        LimitSwitchOff = mPosPerMS * mLimitSwitchMS;
                    }
                }
            }

            private uint                                        mTravelMS           = 4000;
            public uint                                         TravelMS
            {
                get { return mTravelMS; }
                set
                {
                    if (mTravelMS != value)
                    {
                        if (value == 0)
                        {
                            mTravelMS = 1;
                        }
                        else
                        {
                            mTravelMS = value;
                        }

                        mPosPerMS       = 100.0D / mTravelMS;
                        LimitSwitchOff  = mPosPerMS * mLimitSwitchMS;
                    }
                }
            }

            public bool                                         mAnalogCtrl         = false;

            public bool                                         mImpulseCtrl        = false;

            public bool                                         mEsdOpen            = false;

            private bool                                        mIgnoreCommands     = false;
            public bool                                         IgnoreCommands
            {
                get { return mIgnoreCommands; }
                set
                {
                    if (mIgnoreCommands != value)
                    {
                        mIgnoreCommands = value;
                        raiseValuesChanged();
                    }
                }
            }

            private bool                                        mForseLimSwitches   = false;
            public bool                                         ForseLimSwitches
            {
                get { return mForseLimSwitches; }
                set
                {
                    if (mForseLimSwitches != value)
                    {
                        mForseLimSwitches    = value;
                        mValueChanged       = true;
                        raiseValuesChanged();
                    }
                }
            }

            private bool                                        mPositionFault      = false;
            public bool                                         PositionFault
            {
                get { return mPositionFault; }
                set
                {
                    if (mPositionFault != value)
                    {
                        mPositionFault = value;
                        mValueChanged = true;
                        raiseValuesChanged();
                    }
                }
            }
            public double                                       mFaultValue         = 32767;

            private bool                                        mUseOneCommand      = false;
            public bool                                         UseOneCommand
            {
                get { return mUseOneCommand; }
                set
                {
                    if (mUseOneCommand != value)
                    {
                        mUseOneCommand = value;
                        raisePropertiesChanged();
                    }
                }
        }

        #endregion

        #region IItemUser

            public int                                          mOpenCMDItemHandle      = -1;
            public bool                                         mOpenCMD                = false;

            public int                                          mCloseCMDItemHandle     = -1;
            public bool                                         mCloseCMD               = false;

            public int                                          mStopCMDItemHandle      = -1;
            public bool                                         mStopCMD                = false;

            public int                                          mEsdCMDItemHandle       = -1;
            public bool                                         mEsdCMD                 = false;

            public int                                          mPositionCMDItemHandle  = -1;
            public ValueScale                                   mPositionCMDScale       = new ValueScale();
            public double                                       mPositionCMD            = 0.0D;
            
            public int                                          mOpenLimitItemHandle    = -1;
            private bool                                        mOpenLimit;
            public bool                                         OpenLimit
            {
                get { return mOpenLimit; }
            }

            public int                                          mOpensItemHandle        = -1;
            private bool                                        mOpens;
            public bool                                         Opens
            {
                get { return mOpens; }
            }

            public int                                          mClosedLimitItemHandle  = -1;
            private bool                                        mClosedLimit;
            public bool                                         ClosedLimit
            {
                get { return mClosedLimit; }
            }

            public int                                          mClosesItemHandle       = -1;
            private bool                                        mCloses;
            private bool                                        Closes
            {
                get { return mCloses; }
            }

            public int                                          mRotationItemHandle     = -1;
            private bool                                        mRotation;
            private bool                                        Rotation
            {
                get { return mRotation; }
            }

            public int                                          mPositionItemHandle     = -1;
            public ValueScale                                   mPositionScale          = new ValueScale();
            private double                                      mPosition;
            public double                                       Position
            {
                get { return mPosition; }
                set
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mPosition, value))
                    {
                        mPosition       = value;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mRemoteItemHandle       = -1;
            private bool                                        mRemote                 = true;
            private bool                                        mRemoteChanged;
            public bool                                         Remote
            {
                get { return mRemote; }
                set
                {
                    if (mRemote != value)
                    {
                        if (mRemoteItemHandle != -1)
                        {
                            if (mItemBrowser.getItemAccess(mRemoteItemHandle).HasFlag(EAccess.WRITE))
                            {
                                mRemote         = value;
                                mRemoteChanged  = true;
                                mValueChanged   = true;
                            }
                        }
                        else
                        {
                            mRemote = value;
                        }

                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mAlarm1ItemHandle       = -1;
            private bool                                        mAlarm1                 = false;
            private bool                                        mAlarm1Changed;
            public bool                                         Alarm1
            {
                get { return mAlarm1; }
                set
                {
                    if (mAlarm1 != value)
                    {
                        mAlarm1         = value;
                        mValueChanged   = true;
                        mAlarm1Changed  = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mAlarm2ItemHandle       = -1;
            private bool                                        mAlarm2                 = false;
            private bool                                        mAlarm2Changed;
            public bool                                         Alarm2
            {
                get { return mAlarm2; }
                set
                {
                    if (mAlarm2 != value)
                    {
                        mAlarm2         = value;
                        mValueChanged   = true;
                        mAlarm2Changed  = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mPowerItemHandle        = -1;
            private bool                                        mPower                  = true;
            private bool                                        mPowerChanged;
            public bool                                         Power
            {
                get { return mPower; }
                set
                {
                    if (mPower != value)
                    {
                        mPower          = value;                    
                        mValueChanged   = true;
                        mPowerChanged   = true;
                        raiseValuesChanged();
                    }
                }
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

                    if (mOpenCMDItemHandle != -1)
                    {
                        lResult.Add(mOpenCMDItemHandle);
                    }

                    if (mCloseCMDItemHandle != -1)
                    {
                        lResult.Add(mCloseCMDItemHandle);
                    }

                    if (mStopCMDItemHandle != -1)
                    {
                        lResult.Add(mStopCMDItemHandle);
                    }

                    if (mPositionCMDItemHandle != -1)
                    {
                        lResult.Add(mPositionCMDItemHandle);
                    }

                    if (mEsdCMDItemHandle != -1)
                    {
                        lResult.Add(mEsdCMDItemHandle);
                    }

                    if (mOpenLimitItemHandle != -1)
                    {
                        lResult.Add(mOpenLimitItemHandle);
                    }

                    if (mClosedLimitItemHandle != -1)
                    {
                        lResult.Add(mClosedLimitItemHandle);
                    }

                    if (mRemoteItemHandle != -1)
                    {
                        lResult.Add(mRemoteItemHandle);
                    }

                    if (mAlarm1ItemHandle != -1)
                    {
                        lResult.Add(mAlarm1ItemHandle);
                    }

                    if (mAlarm2ItemHandle != -1)
                    {
                        lResult.Add(mAlarm2ItemHandle);
                    }

                    if (mPowerItemHandle != -1)
                    {
                        lResult.Add(mPowerItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    if (mOpenLimitItemHandle != -1)
                    {
                        lResult.Add(mOpenLimitItemHandle);
                    }

                    if (mOpensItemHandle != -1)
                    {
                        lResult.Add(mOpensItemHandle);
                    }

                    if (mClosedLimitItemHandle != -1)
                    {
                        lResult.Add(mClosedLimitItemHandle);
                    }

                    if (mClosesItemHandle != -1)
                    {
                        lResult.Add(mClosesItemHandle);
                    }

                    if (mRotationItemHandle != -1)
                    {
                        lResult.Add(mRotationItemHandle);
                    }

                    if (mPositionItemHandle != -1)
                    {
                        lResult.Add(mPositionItemHandle);
                    }

                    if (mRemoteItemHandle != -1)
                    {
                        lResult.Add(mRemoteItemHandle);
                    }

                    if (mAlarm1ItemHandle != -1)
                    {
                        lResult.Add(mAlarm1ItemHandle);
                    }

                    if (mAlarm2ItemHandle != -1)
                    {
                        lResult.Add(mAlarm2ItemHandle);
                    }

                    if (mPowerItemHandle != -1)
                    {
                        lResult.Add(mPowerItemHandle);
                    }

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
                bool lValueChanged      = mValueChanged;
                mValueChanged           = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                if (mOpenLimitItemHandle != -1)
                {
                    lHandles.Add(mOpenLimitItemHandle);
                    if (mForseLimSwitches)
                    {
                        lValues.Add(true);
                    }
                    else
                    {
                        lValues.Add(mOpenLimit);
                    }
                }

                if (mOpensItemHandle != -1)
                {
                    lHandles.Add(mOpensItemHandle);
                    lValues.Add(mOpens);
                }

                if (mClosedLimitItemHandle != -1)
                {
                    lHandles.Add(mClosedLimitItemHandle);
                    if (mForseLimSwitches)
                    {
                        lValues.Add(true);
                    }
                    else
                    {
                        lValues.Add(mClosedLimit);
                    }
                }

                if (mClosesItemHandle != -1)
                {
                    lHandles.Add(mClosesItemHandle);
                    lValues.Add(mCloses);
                }

                if (mRotationItemHandle != -1)
                {
                    lHandles.Add(mRotationItemHandle);
                    lValues.Add(mRotation);
                }

                if (mPositionItemHandle != -1)
                {
                    lHandles.Add(mPositionItemHandle);

                    if (mPositionFault)
                    {
                        lValues.Add(mFaultValue);
                    }
                    else
                    {
                        lValues.Add(mPositionScale.unscale(mPosition));
                    }
                }

                if (mRemoteItemHandle != -1)
                {
                    if (!lValueChanged || mRemoteChanged)
                    {
                        if (mItemBrowser.getItemAccess(mRemoteItemHandle).HasFlag(EAccess.WRITE))
                        {
                            mRemoteChanged = false;
                            lHandles.Add(mRemoteItemHandle);
                            lValues.Add(mRemote);
                        }
                    }
                }

                if (mAlarm1ItemHandle != -1)
                {
                    if (!lValueChanged || mAlarm1Changed)
                    {
                        mAlarm1Changed = false;
                        lHandles.Add(mAlarm1ItemHandle);
                        lValues.Add(mAlarm1);
                    }
                }

                if (mAlarm2ItemHandle != -1)
                {
                    if (!lValueChanged || mAlarm2Changed)
                    {
                        mAlarm2Changed = false;
                        lHandles.Add(mAlarm2ItemHandle);
                        lValues.Add(mAlarm2);
                    }
                }

                if (mPowerItemHandle != -1)
                {
                    if (!lValueChanged || mPowerChanged)
                    {
                        mPowerChanged = false;
                        lHandles.Add(mPowerItemHandle);
                        lValues.Add(mPower);
                    }
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mOpenCMDItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Open' command. ", lExc);
                    }

                    if (mOpenCMD != lValue)
                    {
                        if (mImpulseCtrl)
                        {
                            if (lValue == true)
                            {
                                mOpenCMD    = true;
                                mCloseCMD   = false;
                                mStopCMD    = false;
                            }
                        }
                        else
                        {
                            mOpenCMD = lValue;
                        }

                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mCloseCMDItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Close' command. ", lExc);
                    }

                    if (mCloseCMD != lValue)
                    {
                        if (mImpulseCtrl)
                        {
                            if (lValue == true)
                            {
                                mOpenCMD    = false;
                                mCloseCMD   = true;
                                mStopCMD    = false;
                            }
                        }
                        else
                        {
                            mCloseCMD = lValue;
                        }

                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mStopCMDItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Stop' command. ", lExc);
                    }

                    if (mStopCMD != lValue)
                    {
                        if (mImpulseCtrl)
                        {
                            if (lValue == true)
                            {
                                mOpenCMD    = false;
                                mCloseCMD   = false;
                                mStopCMD    = true;
                            }
                        }
                        else
                        {
                            mStopCMD = lValue;
                        }
                        
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mEsdCMDItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'ESD' command. ", lExc);
                    }

                    if (mEsdCMD != lValue)
                    {
                        mEsdCMD = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mPositionCMDItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = mPositionCMDScale.scale(Convert.ToDouble(aItemValue));
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Position' command. ", lExc);
                    }

                    if (lValue < 0.0D || lValue > 100.0D)
                    {
                        throw new ArgumentException("Value of the 'Position' command is out of range (0..100%). ");
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mPositionCMD, lValue))
                    {
                        mPositionCMD = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mRemoteItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Remote' state. ", lExc);
                    }

                    if (mRemote != lValue)
                    {
                        mRemote = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mAlarm1ItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Alarm №1' state. ", lExc);
                    }

                    if (mAlarm1 != lValue)
                    {
                        mAlarm1 = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mPowerItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Power' state. ", lExc);
                    }

                    if (mPower != lValue)
                    {
                        mPower = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mAlarm2ItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Alarm №2' state. ", lExc);
                    }

                    if (mAlarm2 != lValue)
                    {
                        mAlarm2 = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mOpenLimitItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Open' state. ", lExc);
                    }

                    if (mOpenLimit != lValue)
                    {
                        if (lValue == true)
                        {
                            Position = 100;
                        }
                        else
                        {
                            mValueChanged = true;
                        }
                    }

                    return;
                }

                if (aItemHandle == mClosedLimitItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for valve 'Closed' state. ", lExc);
                    }

                    if (mClosedLimit != lValue)
                    {
                        if (lValue == true)
                        {
                            Position = 0;
                        }
                        else
                        {
                            mValueChanged = true;
                        }
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Control", "State" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Control": return new ValveControlPanel(this);
                    case "State":   return new ValveStatePanel(this);
                    default:        throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
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

                string lItem = lReader.getAttribute<String>("Remote", "");
                lChecker.addItemName(lItem);
                mRemoteItemHandle = mItemBrowser.getItemHandleByName(lItem);

                TravelMS = lReader.getAttribute<UInt32>("TravelMS", mTravelMS);

                uint lUInt = lReader.getAttribute<UInt32>("LimitSwitchMS", mLimitSwitchMS);
                if (lUInt == 0)
                {
                    throw new ArgumentException("Limit switch time of valve has to be more than 0. ");
                }
                LimitSwitchMS = lUInt;

                mAnalogCtrl = lReader.getAttribute<Boolean>("AnalogControl", mAnalogCtrl);

                double lMax, lMin;
                lItem = lReader.getAttribute<String>("PositionCMD", "");
                lChecker.addItemName(lItem);
                mPositionCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lMax = lReader.getAttribute<Double>("PositionCMDMax", mPositionCMDScale.InMax);
                lMin = lReader.getAttribute<Double>("PositionCMDMin", mPositionCMDScale.InMin);
                mPositionCMDScale.setProperties(lMax, lMin, 100.0D, 0.0D);

                lItem = lReader.getAttribute<String>("OpenCMD", "");
                lChecker.addItemName(lItem);
                mOpenCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mUseOneCommand = lReader.getAttribute<Boolean>("UseOneCMD", mUseOneCommand);

                lItem = lReader.getAttribute<String>("CloseCMD", "");
                lChecker.addItemName(lItem);
                mCloseCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("StopCMD", "");
                lChecker.addItemName(lItem);
                mStopCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mImpulseCtrl = lReader.getAttribute<Boolean>("ImpulseControl", mImpulseCtrl);
                if (mImpulseCtrl && mUseOneCommand)
                {
                    throw new ArgumentException("Impulse control is not supported when using only one command. ");
                }

                lItem = lReader.getAttribute<String>("EsdCMD", "");
                lChecker.addItemName(lItem);
                mEsdCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mEsdOpen = lReader.getAttribute<Boolean>("EsdOpen", mEsdOpen);

                lItem = lReader.getAttribute<String>("OpenLimit", "");
                lChecker.addItemName(lItem);
                mOpenLimitItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Opens", "");
                lChecker.addItemName(lItem);
                mOpensItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("ClosedLimit", "");
                lChecker.addItemName(lItem);
                mClosedLimitItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Closes", "");
                lChecker.addItemName(lItem);
                mClosesItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Rotation", "");
                lChecker.addItemName(lItem);
                mRotationItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Position", "");
                lChecker.addItemName(lItem);
                mPositionItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lMax = lReader.getAttribute<Double>("PositionMax", mPositionScale.InMax);
                lMin = lReader.getAttribute<Double>("PositionMin", mPositionScale.InMin);
                mPositionScale.setProperties(lMax, lMin, 100.0D, 0.0D);
                mFaultValue = lReader.getAttribute<Double>("FaultValue", mFaultValue);

                lItem = lReader.getAttribute<String>("Alarm1", "");
                lChecker.addItemName(lItem);
                mAlarm1ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Alarm2", "");
                lChecker.addItemName(lItem);
                mAlarm2ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Power", "");
                lChecker.addItemName(lItem);
                mPowerItemHandle = mItemBrowser.getItemHandleByName(lItem);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Remote", mItemBrowser.getItemNameByHandle(mRemoteItemHandle));

                aXMLTextWriter.WriteAttributeString("TravelMS", StringUtils.ObjectToString(mTravelMS));
                aXMLTextWriter.WriteAttributeString("LimitSwitchMS", StringUtils.ObjectToString(mLimitSwitchMS));

                aXMLTextWriter.WriteAttributeString("AnalogControl", StringUtils.ObjectToString(mAnalogCtrl));

                aXMLTextWriter.WriteAttributeString("PositionCMD", mItemBrowser.getItemNameByHandle(mPositionCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("PositionCMDMax", StringUtils.ObjectToString(mPositionCMDScale.InMax));
                aXMLTextWriter.WriteAttributeString("PositionCMDMin", StringUtils.ObjectToString(mPositionCMDScale.InMin));

                aXMLTextWriter.WriteAttributeString("OpenCMD", mItemBrowser.getItemNameByHandle(mOpenCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("UseOneCMD", StringUtils.ObjectToString(mUseOneCommand));
                aXMLTextWriter.WriteAttributeString("CloseCMD", mItemBrowser.getItemNameByHandle(mCloseCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("StopCMD", mItemBrowser.getItemNameByHandle(mStopCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("ImpulseControl", StringUtils.ObjectToString(mImpulseCtrl));

                aXMLTextWriter.WriteAttributeString("EsdCMD", mItemBrowser.getItemNameByHandle(mEsdCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("EsdOpen", StringUtils.ObjectToString(mEsdOpen));

                aXMLTextWriter.WriteAttributeString("OpenLimit", mItemBrowser.getItemNameByHandle(mOpenLimitItemHandle));
                aXMLTextWriter.WriteAttributeString("Opens", mItemBrowser.getItemNameByHandle(mOpensItemHandle));
                aXMLTextWriter.WriteAttributeString("ClosedLimit", mItemBrowser.getItemNameByHandle(mClosedLimitItemHandle));
                aXMLTextWriter.WriteAttributeString("Closes", mItemBrowser.getItemNameByHandle(mClosesItemHandle));
                aXMLTextWriter.WriteAttributeString("Rotation", mItemBrowser.getItemNameByHandle(mRotationItemHandle));

                aXMLTextWriter.WriteAttributeString("Position", mItemBrowser.getItemNameByHandle(mPositionItemHandle));
                aXMLTextWriter.WriteAttributeString("PositionMax", StringUtils.ObjectToString(mPositionScale.InMax));
                aXMLTextWriter.WriteAttributeString("PositionMin", StringUtils.ObjectToString(mPositionScale.InMin));
                aXMLTextWriter.WriteAttributeString("FaultValue", StringUtils.ObjectToString(mFaultValue));

                aXMLTextWriter.WriteAttributeString("Alarm1", mItemBrowser.getItemNameByHandle(mAlarm1ItemHandle));
                aXMLTextWriter.WriteAttributeString("Alarm2", mItemBrowser.getItemNameByHandle(mAlarm2ItemHandle));

                aXMLTextWriter.WriteAttributeString("Power", mItemBrowser.getItemNameByHandle(mPowerItemHandle));
            }

            private double                                      mLastPosition   = 0.0D;

            private FiniteStateMachine                          mFSM;
            private long                                        mLastMS;
            private double                                      mLastPosCMD;
            private void                                        ValveStoped()
            {
                if(mAlarm1 == false && mAlarm2 == false && mPower && mIgnoreCommands == false)
                {
                    if (mEsdCMD && ( (mEsdOpen && mOpenLimit == false) || (mEsdOpen == false && mClosedLimit == false) ))
                    {
                        mLastMS = MiscUtils.TimerMS;
                        mFSM.State = "Esd";
                        return;
                    }

                    if (mRemote)
                    {
                        if (mAnalogCtrl)
                        {
                            if (mPositionCMD < mPosition)
                            {
                                mLastMS     = MiscUtils.TimerMS;
                                mLastPosCMD = mPositionCMD;
                                mFSM.State  = "Closes";
                                return;
                            }
                            else if (mPositionCMD > mPosition)
                            {
                                mLastMS     = MiscUtils.TimerMS;
                                mLastPosCMD = mPositionCMD;
                                mFSM.State  = "Opens";
                                return;
                            }
                        }
                        else
                        {
                            if (!mStopCMD)
                            {
                                    if (
                                        (
                                         (!mUseOneCommand && mOpenCMD && !mCloseCMD)
                                         ||
                                         (mUseOneCommand && mOpenCMD)
                                        )
                                         && (mPosition < 100.0D)
                                       )
                                    {
                                        mLastMS = MiscUtils.TimerMS;
                                        mFSM.State  = "Opens";
                                        return;
                                    }

                                    if (
                                        (
                                         (!mUseOneCommand && mCloseCMD && !mOpenCMD)
                                         ||
                                         (mUseOneCommand && !mOpenCMD)
                                        )
                                         && (mPosition > 0.0D)
                                       )
                                    {
                                        mLastMS = MiscUtils.TimerMS;
                                        mFSM.State  = "Closes";
                                        return;
                                    }
                                }
                            }
                    }
                }
            }
            private void                                        ValveOpens()
            {
                if (mAlarm1 || mAlarm2 || mEsdCMD || !mPower || !mRemote || mIgnoreCommands)
                {
                    mFSM.State = "Stoped";
                    return;
                }

                if (mAnalogCtrl && (mPositionCMD < mLastPosCMD))
                {
                    mFSM.State  = "Closes";
                    mLastPosCMD = mPositionCMD;
                    return;
                }

                mPosition = mPosition + mPosPerMS * (double)(MiscUtils.TimerMS - mLastMS);
                if (mPosition > 100.0D) { mPosition = 100.0D; }
                if (mAnalogCtrl && (mPosition > mPositionCMD)) { mPosition = mPositionCMD; }

                mLastMS = MiscUtils.TimerMS;

                if(
                        ValuesCompare.EqualDelta1.compare(mPosition, 100.0D) ||
                        (mAnalogCtrl && ValuesCompare.EqualDelta1.compare(mPosition, mPositionCMD)) ||
                        (!mAnalogCtrl && (!mOpenCMD || (!mUseOneCommand && mCloseCMD) || mStopCMD))
                  )
                {
                    mFSM.State = "Stoped";
                    return;
                }
            }
            private void                                        ValveCloses()
            {
                if (mAlarm1 || mAlarm2 || mEsdCMD || !mPower || !mRemote || mIgnoreCommands)
                {
                    mFSM.State = "Stoped";
                    return;
                }

                if (mAnalogCtrl && (mPositionCMD > mLastPosCMD))
                {
                    mFSM.State  = "Opens";
                    mLastPosCMD = mPositionCMD;
                    return;
                }

                mPosition = mPosition - mPosPerMS * (double)(MiscUtils.TimerMS - mLastMS);
                if (mPosition < 0.0D) { mPosition = 0.0D; }
                if (mAnalogCtrl && (mPosition < mPositionCMD)) { mPosition = mPositionCMD; }

                mLastMS = MiscUtils.TimerMS;

                if (
                        ValuesCompare.EqualDelta1.compare(mPosition, 0.0D) ||
                        (mAnalogCtrl && ValuesCompare.EqualDelta1.compare(mPosition, mPositionCMD)) ||
                        (!mAnalogCtrl && ((!mUseOneCommand && !mCloseCMD) || mOpenCMD || mStopCMD))
                   )
                {
                    mFSM.State = "Stoped";
                    return;
                }
            }
            private void                                        ValveEsd()
            {
                if (mAlarm1 || mAlarm2 || !mPower || mIgnoreCommands)
                {
                    mFSM.State = "Stoped";
                    return;
                }

                if (mEsdOpen)
                {
                    mPosition = mPosition + mPosPerMS * (double)(MiscUtils.TimerMS - mLastMS);
                    if (mPosition > 100.0D) { mPosition = 100.0D; }
                }
                else
                {
                    mPosition = mPosition - mPosPerMS * (double)(MiscUtils.TimerMS - mLastMS);
                    if (mPosition < 0.0D) { mPosition = 0.0D; }
                }

                mLastMS = MiscUtils.TimerMS;

                if (
                        !mEsdCMD ||
                        (mEsdOpen && ValuesCompare.EqualDelta1.compare(mPosition, 100.0D)) ||
                        (!mEsdOpen && ValuesCompare.EqualDelta1.compare(mPosition, 0.0D))
                  )
                {
                    mFSM.State = "Stoped";
                    return;
                }
            }

            public void                                         execute()
            {
                if (mAnalogCtrl && mPositionCMDItemHandle == -1)
                {
                    mPositionCMD = mPosition;
                }

                mFSM.executeStateAction();

                bool lUpdate = false;

                if (ValuesCompare.NotEqualDelta1.compare(mPosition, mLastPosition))
                {
                    if (mLastPosition < mPosition && (mOpens != true || mCloses != false || mRotation != true))
                    {
                        mRotation   = true;
                        mOpens      = true;
                        mCloses     = false;
                        lUpdate     = true;
                    }

                    if (mLastPosition > mPosition && (mOpens != false || mCloses != true || mRotation != true))
                    {
                        mRotation   = true;
                        mCloses     = true;
                        mOpens      = false;
                        lUpdate     = true;
                    }

                    mLastPosition = mPosition;                
                    if (mPositionItemHandle != -1)
                    {
                        lUpdate = true;
                    }
                    else
                    {
                        raiseValuesChanged();
                    }
                }
                else
                {
                    if (mRotation || mOpens || mCloses)
                    {
                        mRotation   = false;
                        mOpens      = false;
                        mCloses     = false;
                        lUpdate     = true;
                    }
                }

                if ((mPosition > mLimitSwitchOff) && mClosedLimit)
                {
                    mClosedLimit    = false;
                    lUpdate         = true;
                }

                if ((mPosition < 100.0D - mLimitSwitchOff) && mOpenLimit)
                {
                    mOpenLimit  = false;
                    lUpdate     = true;
                }

                if (ValuesCompare.EqualDelta1.compare(mPosition, 0.0D) && (!mClosedLimit || mOpenLimit))
                {
                    mClosedLimit    = true;
                    mOpenLimit      = false;
                    if (mImpulseCtrl)
                    {
                        mCloseCMD = false;
                    }
                    lUpdate = true;
                }

                if (ValuesCompare.EqualDelta1.compare(mPosition, 100.0D) && (!mOpenLimit || mClosedLimit))
                {
                    mOpenLimit      = true;
                    mClosedLimit    = false;
                    if (mImpulseCtrl)
                    {
                        mOpenCMD = false;
                    }
                    lUpdate = true;
                }

                if (
                    (
                        mLimitSwitchOff >   50.0D                         &&
                        mPosition       >   (100.0D - mLimitSwitchOff)    &&
                        mPosition       <   mLimitSwitchOff
                    )
                    &&
                    (!mOpenLimit || !mClosedLimit)
                   )
                {
                    mOpenLimit      = true;
                    mClosedLimit    = true;
                    lUpdate         = true;
                }

                if (lUpdate)
                {
                    mValueChanged = true;
                    raiseValuesChanged(); 
                }
            }

            public void                                         beforeActivate()
            {
                mFSM.State = "Stoped";
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
                get
                {
                    string[] lMenu = new string[3];

                    if (mIgnoreCommands)
                    {
                        lMenu[0] = "Not ignore commands";
                    }
                    else
                    {
                        lMenu[0] = "Ignore commands";
                    }

                    if (mForseLimSwitches)
                    {
                        lMenu[1] = "Not forse limit switches";
                    }
                    else
                    {
                        lMenu[1] = "Forse limit switches";
                    }

                    if (mPositionFault)
                    {
                        lMenu[2] = "Reset position signal fault";
                    }
                    else
                    {
                        lMenu[2] = "Set position signal fault";
                    }

                    return lMenu;
                }
            }

            public void                                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
                switch(aMenuItemName)
                {
                    case "Not ignore commands":         IgnoreCommands = false; break;
                    case "Ignore commands":             IgnoreCommands = true; break;
                    case "Not forse limit switches":    ForseLimSwitches = false; break;
                    case "Forse limit switches":        ForseLimSwitches = true; break;
                    case "Reset position signal fault": PositionFault = false; break;
                    case "Set position signal fault":   PositionFault = true; break;
                }
            }

        #endregion

        #region IDisposable

            private bool                        mDisposed = false;

            public void                         Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void              Dispose(bool aDisposing)
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
