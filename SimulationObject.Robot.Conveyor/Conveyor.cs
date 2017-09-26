// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Robot.Conveyor.Panel.ConveyorControl;
using SimulationObject.Robot.Conveyor.Panel.ConveyorState;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace SimulationObject.Robot.Conveyor
{
    public class Conveyor : ISimulationObject
    {
        public                                                  Conveyor()
        {
            mFSM = new FiniteStateMachine("Stop", () => ConveyorStop());
            mFSM.addState("Moving", () => ConveyorMoving());
            mFSM.addState("Acceleration", () => ConveyorAcceleration());
            mFSM.addState("Braking", () => ConveyorBraking());
            mFSM.addState("Reverse", () => ConveyorReverse());
            mFSM.addState("Change", () => ConveyorChange());
        }

        #region Properties

            private double                                      mSpeedUpPerMS       = 100;
            private double                                      mSpeedDownPerMS     = 100;

            private uint                                        mStartMS            = 1;
            public uint                                         StartMS
            {
                get { return mStartMS; }
                set
                {
                    if (mStartMS != value)
                    {
                        if (value == 0)
                        {
                            mStartMS = 1;
                        }
                        else
                        {
                            mStartMS = value;
                        }

                        mSpeedUpPerMS = 100.0D / mStartMS;
                    }
                }
            }

            private uint                                        mStopMS             = 1;
            public uint                                         StopMS
            {
                get { return mStopMS; }
                set
                {
                    if (mStopMS != value)
                    {
                        if (value == 0)
                        {
                            mStopMS = 1;
                        }
                        else
                        {
                            mStopMS = value;
                        }

                        mSpeedDownPerMS = 100.0D / mStopMS;
                    }
                }
            }

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

            private bool                                        mUseOneCommand      = false;
            public bool                                         UseOneCommand
            {
                get { return mUseOneCommand; }
                set
                {
                    if(mUseOneCommand != value)
                    {
                        mUseOneCommand = value;
                        raisePropertiesChanged();
                    }
                }
            }

        #endregion

        #region IItemUser

            public int                                          mStartCMDItemHandle = -1;
            public bool                                         mStartCMD           = false;

            public int                                          mStopCMDItemHandle  = -1;
            public bool                                         mStopCMD            = false;

            public int                                          mSpeedCMDItemHandle  = -1;
            public ValueScale                                   mSpeedCMDScale       = new ValueScale();
            public double                                       mSpeedCMD            = 100.0D;

            public int                                          mMovingItemHandle   = -1;
            private bool                                        mMoving;
            public bool                                         Moving
            {
                get { return mMoving; }
                set
                {
                    if (mMoving != value)
                    {
                        evaluate(value);
                        mValueChanged = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mAlarmItemHandle    = -1;
            private bool                                        mAlarm              = false;
            private bool                                        mAlarmChanged;
            public bool                                         Alarm
            {
                get { return mAlarm; }
                set
                {
                    if (mAlarm != value)
                    {
                        mAlarm = value;
                        mFSM.executeStateAction();                    
                        mAlarmChanged   = true;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mReverseItemHandle  = -1;
            private bool                                        mReverse            = false;
            private bool                                        mReverseChanged;
            public bool                                         Reverse
            {
                get { return mReverse; }
                set
                {
                    if (mReverse != value)
                    {
                        mReverse = value;
                        mFSM.executeStateAction();                     
                        mReverseChanged = true;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mAccelerationItemHandle = -1;
            private bool                                        mAcceleration           = false;
            public bool                                         Acceleration
            {
                get { return mAcceleration; }
            }

            public int                                          mBrakingItemHandle  = -1;
            private bool                                        mBraking            = false;
            public bool                                         Braking
            {
                get { return mBraking; }
            }

            public int                                          mSpeedItemHandle    = -1;
            public ValueScale                                   mSpeedScale         = new ValueScale();
            private double                                      mSpeed              = 0.0;
            public double                                       Speed
            {
                get { return mSpeed; }
                set
                {
                    if (ValuesCompare.NotEqualDelta1.compare(mSpeed, value))
                    {
                        mSpeed = value;

                        if (mSpeedCMDItemHandle == -1)
                        {
                            mSpeedCMD = mSpeed;
                        }

                        mValueChanged = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mForwardItemHandle  = -1;
            private bool                                        mForward            = false;
            public bool                                         Forward
            {
                get { return mForward; }
            }

            public int                                          mBackwardItemHandle = -1;
            private bool                                        mBackward           = false;
            public bool                                         Backward
            {
                get { return mBackward; }
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

                    if (mStartCMDItemHandle != -1)
                    {
                        lResult.Add(mStartCMDItemHandle);
                    }

                    if (mStopCMDItemHandle != -1)
                    {
                        lResult.Add(mStopCMDItemHandle);
                    }

                    if (mSpeedCMDItemHandle != -1)
                    {
                        lResult.Add(mSpeedCMDItemHandle);
                    }

                    if (mMovingItemHandle != -1)
                    {
                        lResult.Add(mMovingItemHandle);
                    }

                    if (mAlarmItemHandle != -1)
                    {
                        lResult.Add(mAlarmItemHandle);
                    }

                    if (mReverseItemHandle != -1)
                    {
                        lResult.Add(mReverseItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    if (mMovingItemHandle != -1)
                    {
                        lResult.Add(mMovingItemHandle);
                    }

                    if (mAlarmItemHandle != -1)
                    {
                        lResult.Add(mAlarmItemHandle);
                    }

                    if (mReverseItemHandle != -1)
                    {
                        lResult.Add(mReverseItemHandle);
                    }

                    if (mAccelerationItemHandle != -1)
                    {
                        lResult.Add(mAccelerationItemHandle);
                    }

                    if (mBrakingItemHandle != -1)
                    {
                        lResult.Add(mBrakingItemHandle);
                    }

                    if (mSpeedItemHandle != -1)
                    {
                        lResult.Add(mSpeedItemHandle);
                    }

                    if (mForwardItemHandle != -1)
                    {
                        lResult.Add(mForwardItemHandle);
                    }

                    if (mBackwardItemHandle != -1)
                    {
                        lResult.Add(mBackwardItemHandle);
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
                bool lValueChanged  = mValueChanged;
                mValueChanged       = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                if (mMovingItemHandle != -1)
                {
                    lHandles.Add(mMovingItemHandle);
                    lValues.Add(mMoving);
                }

                if (mAlarmItemHandle != -1)
                {
                    if (!lValueChanged || mAlarmChanged)
                    {
                        mAlarmChanged = false;
                        lHandles.Add(mAlarmItemHandle);
                        lValues.Add(mAlarm);
                    }
                }

                if (mReverseItemHandle != -1)
                {
                    if (!lValueChanged || mReverseChanged)
                    {
                        mReverseChanged = false;
                        lHandles.Add(mReverseItemHandle);
                        lValues.Add(mReverse);
                    }
                }

                if (mAccelerationItemHandle != -1)
                {
                    lHandles.Add(mAccelerationItemHandle);
                    lValues.Add(mAcceleration);
                }

                if (mBrakingItemHandle != -1)
                {
                    lHandles.Add(mBrakingItemHandle);
                    lValues.Add(mBraking);
                }

                if (mSpeedItemHandle != -1)
                {
                    lHandles.Add(mSpeedItemHandle);
                    lValues.Add(mSpeedScale.unscale(mSpeed));
                }

                if (mForwardItemHandle != -1)
                {
                    lHandles.Add(mForwardItemHandle);
                    lValues.Add(mForward);
                }

                if (mBackwardItemHandle != -1)
                {
                    lHandles.Add(mBackwardItemHandle);
                    lValues.Add(mBackward);
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mStartCMDItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for conveyor 'Start' command. ", lExc);
                    }

                    if (mStartCMD != lValue)
                    {
                        mStartCMD = lValue;
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
                        throw new ArgumentException("Value conversion error for conveyor 'Stop' command. ", lExc);
                    }

                    if (mStopCMD != lValue)
                    {
                        mStopCMD = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mSpeedCMDItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = mSpeedCMDScale.scale(Convert.ToDouble(aItemValue));
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for conveyor 'Speed' command. ", lExc);
                    }

                    if (lValue < 0.0D || lValue > 100.0D)
                    {
                        throw new ArgumentException("Value of the 'Speed' command is out of range (0..100%). ");
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mSpeedCMD, lValue))
                    {
                        mSpeedCMD = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mMovingItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for conveyor 'Moving' state. ", lExc);
                    }

                    if (mMoving != lValue)
                    {
                        evaluate(lValue);
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mAlarmItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for conveyor 'Alarm' state. ", lExc);
                    }

                    if (mAlarm != lValue)
                    {
                        mAlarm = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mReverseItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for conveyor 'Reverse' state. ", lExc);
                    }

                    if (mReverse != lValue)
                    {
                        mReverse = lValue;
                        raiseValuesChanged();
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
                    case "Control": return new ConveyorControlPanel(this);
                    case "State":   return new ConveyorStatePanel(this);
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
                double lMax, lMin;

                string lItem = lReader.getAttribute<String>("StartCMD", "");
                lChecker.addItemName(lItem);
                mStartCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mUseOneCommand = lReader.getAttribute<Boolean>("UseOneCMD", mUseOneCommand);

                lItem = lReader.getAttribute<String>("StopCMD", "");
                lChecker.addItemName(lItem);
                mStopCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                StartMS = lReader.getAttribute<UInt32>("StartMS", mStartMS);
                StopMS  = lReader.getAttribute<UInt32>("StopMS", mStopMS);

                lItem = lReader.getAttribute<String>("SpeedCMD", "");
                lChecker.addItemName(lItem);
                mSpeedCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lMax = lReader.getAttribute<Double>("SpeedCMDMax", mSpeedCMDScale.InMax);
                lMin = lReader.getAttribute<Double>("SpeedCMDMin", mSpeedCMDScale.InMin);
                mSpeedCMDScale.setProperties(lMax, lMin, 100.0D, 0.0D);

                lItem = lReader.getAttribute<String>("Moving", "");
                lChecker.addItemName(lItem);
                mMovingItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Alarm", "");
                lChecker.addItemName(lItem);
                mAlarmItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Reverse", "");
                lChecker.addItemName(lItem);
                mReverseItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Acceleration", "");
                lChecker.addItemName(lItem);
                mAccelerationItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Braking", "");
                lChecker.addItemName(lItem);
                mBrakingItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Speed", "");
                lChecker.addItemName(lItem);
                mSpeedItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lMax = lReader.getAttribute<Double>("SpeedMax", mSpeedScale.InMax);
                lMin = lReader.getAttribute<Double>("SpeedMin", mSpeedScale.InMin);
                mSpeedScale.setProperties(lMax, lMin, 100.0D, 0.0D);

                lItem = lReader.getAttribute<String>("Forward", "");
                lChecker.addItemName(lItem);
                mForwardItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Backward", "");
                lChecker.addItemName(lItem);
                mBackwardItemHandle = mItemBrowser.getItemHandleByName(lItem);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("StartCMD", mItemBrowser.getItemNameByHandle(mStartCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("UseOneCMD", StringUtils.ObjectToString(mUseOneCommand));
                aXMLTextWriter.WriteAttributeString("StopCMD", mItemBrowser.getItemNameByHandle(mStopCMDItemHandle));

                aXMLTextWriter.WriteAttributeString("SpeedCMD", mItemBrowser.getItemNameByHandle(mSpeedCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("SpeedCMDMax", StringUtils.ObjectToString(mSpeedCMDScale.InMax));
                aXMLTextWriter.WriteAttributeString("SpeedCMDMin", StringUtils.ObjectToString(mSpeedCMDScale.InMin));

                aXMLTextWriter.WriteAttributeString("StartMS", StringUtils.ObjectToString(mStartMS));
                aXMLTextWriter.WriteAttributeString("StopMS", StringUtils.ObjectToString(mStopMS));

                aXMLTextWriter.WriteAttributeString("Moving", mItemBrowser.getItemNameByHandle(mMovingItemHandle));
                aXMLTextWriter.WriteAttributeString("Alarm", mItemBrowser.getItemNameByHandle(mAlarmItemHandle));
                aXMLTextWriter.WriteAttributeString("Reverse", mItemBrowser.getItemNameByHandle(mReverseItemHandle));

                aXMLTextWriter.WriteAttributeString("Acceleration", mItemBrowser.getItemNameByHandle(mAccelerationItemHandle));
                aXMLTextWriter.WriteAttributeString("Braking", mItemBrowser.getItemNameByHandle(mBrakingItemHandle));

                aXMLTextWriter.WriteAttributeString("Speed", mItemBrowser.getItemNameByHandle(mSpeedItemHandle));
                aXMLTextWriter.WriteAttributeString("SpeedMax", StringUtils.ObjectToString(mSpeedScale.InMax));
                aXMLTextWriter.WriteAttributeString("SpeedMin", StringUtils.ObjectToString(mSpeedScale.InMin));

                aXMLTextWriter.WriteAttributeString("Forward", mItemBrowser.getItemNameByHandle(mForwardItemHandle));
                aXMLTextWriter.WriteAttributeString("Backward", mItemBrowser.getItemNameByHandle(mBackwardItemHandle));
            }        

            private FiniteStateMachine                          mFSM;
            private long                                        mLastMS;
            private bool                                        mReversePrev;

            private void                                        evaluate(bool aMoving)
            {
                if (aMoving)
                {
                    mReversePrev    = mReverse;
                    mSpeed          = 100.0;

                    if (mSpeedCMDItemHandle == -1)
                    {
                        mSpeedCMD = 100.0;
                    }

                    mFSM.State      = "Moving";
                    mFSM.executeStateAction();
                }
                else
                {
                    mFSM.State  = "Stop";
                    mSpeed      = 0.0;
                    mFSM.executeStateAction();
                }
            }

            private void                                        ConveyorStop()
            {
                mMoving         = false;
                mAcceleration   = false;
                mBraking        = false;
                mForward        = false;
                mSpeed          = 0.0;

                if (mSpeedCMDItemHandle == -1 && ValuesCompare.EqualDelta1.compare(mSpeedCMD, 0.0))
                {
                    mSpeedCMD = 100.0;
                }

                if (mIgnoreCommands == false && !mAlarm && mStartCMD && mSpeedCMD > 0.0)
                {
                    mReversePrev    = mReverse;
                    mLastMS         = MiscUtils.TimerMS;
                    mFSM.State      = "Acceleration";
                    return;
                }
            }

            private void                                        ConveyorAcceleration()
            {
                mMoving         = true;
                mAcceleration   = true;
                mBraking        = false;
                mForward        = !mReverse;
                mBackward       = mReverse;
                
                mSpeed          = mSpeed + mSpeedUpPerMS * (MiscUtils.TimerMS - mLastMS);
                mLastMS         = MiscUtils.TimerMS;

                if (mIgnoreCommands)
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Moving";
                    return;
                }
          
                if (mSpeedCMD <= mSpeed)
                {
                    mSpeed      = mSpeedCMD;
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Moving";
                    return;
                }

                if (mAlarm)
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Braking";
                    return;
                }

                if ((mStopCMD && !mUseOneCommand) || (!mStartCMD && mUseOneCommand))
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Braking";
                    return;
                }

                if (mReverse != mReversePrev)
                {
                    mReversePrev    = mReverse;
                    mForward        = mReverse;
                    mBackward       = !mReverse;
                    mLastMS         = MiscUtils.TimerMS;
                    mFSM.State      = "Reverse";
                    return;
                }
            }

            private void                                        ConveyorBraking()
            {
                mMoving         = true;
                mAcceleration   = false;
                mBraking        = true;
                mForward        = !mReverse;
                mBackward       = mReverse;

                mSpeed          = mSpeed - mSpeedDownPerMS * (MiscUtils.TimerMS - mLastMS);
                mLastMS         = MiscUtils.TimerMS;

                if (mSpeed <= 0.0)
                {
                    mSpeed      = 0.0;
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Stop";
                    return;
                }
            }

            private void                                        ConveyorMoving()
            {
                mMoving         = true;
                mAcceleration   = false;
                mBraking        = false;
                mForward        = !mReverse;
                mBackward       = mReverse;

                if (mSpeed > 100.0)
                {
                    mSpeed = 100.0;
                }

                if (mSpeed <= 0.0)
                {
                    mSpeed          = 0.0;
                    mLastMS         = MiscUtils.TimerMS;
                    mFSM.State      = "Stop";
                    return;
                }

                if (mIgnoreCommands == false && ((mStopCMD && !mUseOneCommand) || (!mStartCMD && mUseOneCommand)))
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Braking";
                    return;
                }

                if (mAlarm)
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Braking";
                    return;
                }

                if (mIgnoreCommands == false && mReverse != mReversePrev)
                {
                    mReversePrev    = mReverse;
                    mForward        = mReverse;
                    mBackward       = !mReverse;
                    mLastMS         = MiscUtils.TimerMS;
                    mFSM.State      = "Reverse";
                    return;
                }

                if (mIgnoreCommands == false && ValuesCompare.NotEqualDelta1.compare(mSpeed, mSpeedCMD))
                {
                    mLastMS         = MiscUtils.TimerMS;
                    mFSM.State      = "Change";
                    return;
                }
            }

            private void                                        ConveyorReverse()
            {
                mMoving         = true;
                mAcceleration   = false;
                mBraking        = true;
                mForward        = mReverse;
                mBackward       = !mReverse;

                mSpeed          = mSpeed - mSpeedDownPerMS * (MiscUtils.TimerMS - mLastMS);
                mLastMS         = MiscUtils.TimerMS;

                if (mSpeed <= 0.0)
                {
                    mSpeed      = 0.0;
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Acceleration";
                    return;
                }
            }

            private void                                        ConveyorChange()
            {
                mMoving     = true;
                mForward    = !mReverse;
                mBackward   = mReverse;

                if (mIgnoreCommands)
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Moving";
                    return;
                }

                if (mSpeed < mSpeedCMD)
                {
                    mAcceleration   = true;
                    mBraking        = false;

                    mSpeed          = mSpeed + mSpeedDownPerMS * (MiscUtils.TimerMS - mLastMS);
                    mLastMS         = MiscUtils.TimerMS;

                    if (mSpeed >= mSpeedCMD)
                    {
                        mSpeed          = mSpeedCMD;
                        mLastMS         = MiscUtils.TimerMS;
                        mFSM.State      = "Moving";
                        return;
                    }
                }
                else
                {
                    mAcceleration   = false;
                    mBraking        = true;

                    mSpeed          = mSpeed - mSpeedDownPerMS * (MiscUtils.TimerMS - mLastMS);
                    mLastMS         = MiscUtils.TimerMS;

                    if (mSpeed <= mSpeedCMD)
                    {
                        mSpeed          = mSpeedCMD;
                        mLastMS         = MiscUtils.TimerMS;
                        mFSM.State      = "Moving";
                        return;
                    }
                }

                if ((mStopCMD && !mUseOneCommand) || (!mStartCMD && mUseOneCommand))
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Braking";
                    return;
                }

                if (mAlarm)
                {
                    mLastMS     = MiscUtils.TimerMS;
                    mFSM.State  = "Braking";
                    return;
                }

                if (mReverse != mReversePrev)
                {
                    mReversePrev    = mReverse;
                    mForward        = mReverse;
                    mBackward       = !mReverse;
                    mLastMS         = MiscUtils.TimerMS;
                    mFSM.State      = "Reverse";
                    return;
                }
            }

            private bool                                        mLastMovingValue;
            private bool                                        mLastAccelerationValue;
            private bool                                        mLastBrakingValue;
            private bool                                        mLastReverseValue;
            private double                                      mLastSpeed;
            private bool                                        mLastForwardValue;
            private bool                                        mLastBackwardValue;
            public void                                         execute()
            {
                mFSM.executeStateAction();

                bool lUpdatePanels  = false;
                bool lUpdateItems   = mValueChanged;

                if (mLastMovingValue != mMoving)
                {
                    mLastMovingValue    = mMoving;
                    lUpdatePanels       = true;
                    lUpdateItems        = true;
                }

                if (mLastAccelerationValue != mAcceleration)
                {
                    mLastAccelerationValue  = mAcceleration;
                    lUpdatePanels           = true;
                    lUpdateItems            = true;
                }

                if (mLastBrakingValue != mBraking)
                {
                    mLastBrakingValue   = mBraking;
                    lUpdatePanels       = true;
                    lUpdateItems        = true;
                }

                if (mLastReverseValue != mReverse)
                {
                    mLastReverseValue   = mReverse;
                    lUpdatePanels       = true;
                    lUpdateItems        = true;
                }

                if (ValuesCompare.NotEqualDelta1.compare(mSpeed, mLastSpeed))
                {
                    mLastSpeed      = mSpeed;
                    lUpdatePanels   = true;

                    if (mSpeedItemHandle != -1)
                    {
                        lUpdateItems = true;
                    }
                }

                if (mLastForwardValue != mForward)
                {
                    mLastForwardValue   = mForward;
                    lUpdatePanels       = true;
                    lUpdateItems        = true;
                }

                if (mLastBackwardValue != mBackward)
                {
                    mLastBackwardValue  = mBackward;
                    lUpdatePanels       = true;
                    lUpdateItems        = true;
                }

                if (lUpdatePanels)
                {
                    raiseValuesChanged();
                }

                mValueChanged = lUpdateItems;
            }

            public void                                         beforeActivate()
            {
                evaluate(mMoving);
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
                    if (mIgnoreCommands)
                    {
                        return new string[] { "Not ignore commands" };
                    }
                    else
                    {
                        return new string[] { "Ignore commands" };
                    }
                }
            }

            public void                                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
                IgnoreCommands = !IgnoreCommands;
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
