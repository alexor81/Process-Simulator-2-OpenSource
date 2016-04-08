using API;
using SimulationObject.Pipeline.Pump.Panels.PumpControl;
using SimulationObject.Pipeline.Pump.Panels.PumpState;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace SimulationObject.Pipeline.Pump
{
    public class Pump : ISimulationObject
    {
        public                                                  Pump()
        {
            mFSM = new FiniteStateMachine("Switch", () => PumpSwitch());
            mFSM.addState("On", () => PumpOn());
            mFSM.addState("Off", () => PumpOff());
        }

        #region Properties

            private uint                                        mOnMS = 0;
            public uint                                         OnMS
            {
                get { return mOnMS; }
                set
                {
                    if (mOnMS != value)
                    {
                        mOnMS = value;
                    }
                }
            }

            private uint                                        mOffMS = 0;
            public uint                                         OffMS
            {
                get { return mOffMS; }
                set
                {
                    if (mOffMS != value)
                    {
                        mOffMS = value;
                    }
                }
            }

            private bool                                        mIgnoreCommands = false;
            public bool                                         IgnoreCommands
            {
                get { return mIgnoreCommands; }
                set
                {
                    if (mIgnoreCommands != value)
                    {
                        mIgnoreCommands = value;
                        evaluate();
                        raiseValuesChanged();
                    }
                }
            }

        #endregion

        #region IItemUser

            public int                                          mOnCMDItemHandle    = -1;
            public bool                                         mOnCMD = false;

            public int                                          mOffCMDItemHandle   = -1;
            public bool                                         mOffCMD = false;

            public int                                          mEsdCMDItemHandle   = -1;
            public bool                                         mEsdCMD = false;

            public int                                          mOnItemHandle       = -1;
            private bool                                        mOn;
            private bool                                        mOnInternal;
            public bool                                         On
            {
                get { return mOn; }
                set
                {
                    if (mOn != value)
                    {
                        mOnInternal     = value;
                        evaluate();
                        mOn             = mOnInternal;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mPowerItemHandle    = -1;
            private bool                                        mPower              = true;
            private bool                                        mPowerChanged;
            public bool                                         Power
            {
                get { return mPower; }
                set
                {
                    if (mPower != value)
                    {
                        mPower          = value;
                        mPowerChanged   = true;
                        mValueChanged   = true;
                        evaluate();
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
                        mAlarm          = value;                      
                        mAlarmChanged   = true;
                        mValueChanged   = true;
                        evaluate();
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mRemoteItemHandle   = -1;
            private bool                                        mRemote             = true;
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
                                evaluate();
                            }
                        }
                        else
                        {
                            mRemote = value;
                            evaluate(); 
                        }

                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mOnBtnItemHandle    = -1;
            private bool                                        mOnBtn              = false;
            private bool                                        mOnBtnChanged;
            public bool                                         OnBtn
            {
                get { return mOnBtn; }
                set
                {
                    if (mOnBtn != value)
                    {
                        mOnBtn          = value;
                        mOnBtnChanged   = true;
                        mValueChanged   = true;
                        evaluate();
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mOffBtnItemHandle   = -1;
            private bool                                        mOffBtn             = false;
            private bool                                        mOffBtnChanged;
            public bool                                         OffBtn
            {
                get { return mOffBtn; }
                set
                {
                    if (mOffBtn != value)
                    {
                        mOffBtn         = value;
                        mOffBtnChanged  = true;
                        mValueChanged   = true;
                        evaluate();
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

                    if (mOnCMDItemHandle != -1)
                    {
                        lResult.Add(mOnCMDItemHandle);
                    }

                    if (mOffCMDItemHandle != -1)
                    {
                        lResult.Add(mOffCMDItemHandle);
                    }

                    if (mEsdCMDItemHandle != -1)
                    {
                        lResult.Add(mEsdCMDItemHandle);
                    }

                    if (mOnItemHandle != -1)
                    {
                        lResult.Add(mOnItemHandle);
                    }

                    if (mPowerItemHandle != -1)
                    {
                        lResult.Add(mPowerItemHandle);
                    }

                    if (mAlarmItemHandle != -1)
                    {
                        lResult.Add(mAlarmItemHandle);
                    }

                    if (mRemoteItemHandle != -1)
                    {
                        lResult.Add(mRemoteItemHandle);
                    }

                    if (mOnBtnItemHandle != -1)
                    {
                        lResult.Add(mOnBtnItemHandle);
                    }

                    if (mOffBtnItemHandle != -1)
                    {
                        lResult.Add(mOffBtnItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    if (mOnItemHandle != -1)
                    {
                        lResult.Add(mOnItemHandle);
                    }

                    if (mPowerItemHandle != -1)
                    {
                        lResult.Add(mPowerItemHandle);
                    }

                    if (mAlarmItemHandle != -1)
                    {
                        lResult.Add(mAlarmItemHandle);
                    }

                    if (mRemoteItemHandle != -1)
                    {
                        lResult.Add(mRemoteItemHandle);
                    }

                    if (mOnBtnItemHandle != -1)
                    {
                        lResult.Add(mOnBtnItemHandle);
                    }

                    if (mOffBtnItemHandle != -1)
                    {
                        lResult.Add(mOffBtnItemHandle);
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

                if (mOnItemHandle != -1)
                {
                    lHandles.Add(mOnItemHandle);
                    lValues.Add(mOn);
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

                if (mAlarmItemHandle != -1)
                {
                    if (!lValueChanged || mAlarmChanged)
                    {
                        mAlarmChanged = false;
                        lHandles.Add(mAlarmItemHandle);
                        lValues.Add(mAlarm);
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

                if (mOnBtnItemHandle != -1)
                {
                    if (!lValueChanged || mOnBtnChanged)
                    {
                        mOnBtnChanged = false;
                        lHandles.Add(mOnBtnItemHandle);
                        lValues.Add(mOnBtn);
                    }
                }

                if (mOffBtnItemHandle != -1)
                {
                    if (!lValueChanged || mOffBtnChanged)
                    {
                        mOffBtnChanged = false;
                        lHandles.Add(mOffBtnItemHandle);
                        lValues.Add(mOffBtn);
                    }
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mOnCMDItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for pump 'On' command. ", lExc);
                    }

                    if (mOnCMD != lValue)
                    {
                        mOnCMD = lValue;
                        evaluate();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mOffCMDItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for pump 'Off' command. ", lExc);
                    }

                    if (mOffCMD != lValue)
                    {
                        mOffCMD = lValue;
                        evaluate();
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
                        throw new ArgumentException("Value conversion error for pump 'ESD' command. ", lExc);
                    }

                    if (mEsdCMD != lValue)
                    {
                        mEsdCMD = lValue;
                        evaluate();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mOnItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for pump 'On' state. ", lExc);
                    }

                    if (mOn != lValue)
                    {
                        On = lValue;
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
                        throw new ArgumentException("Value conversion error for pump 'Power' state. ", lExc);
                    }

                    if (mPower != lValue)
                    {
                        mPower = lValue;
                        evaluate();
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
                        throw new ArgumentException("Value conversion error for pump 'Alarm' state. ", lExc);
                    }

                    if (mAlarm != lValue)
                    {
                        mAlarm = lValue;
                        evaluate();
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
                        throw new ArgumentException("Value conversion error for pump 'Remote' state. ", lExc);
                    }

                    if (mRemote != lValue)
                    {
                        mRemote = lValue;
                        evaluate();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mOnBtnItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for pump 'On Button' state. ", lExc);
                    }

                    if (mOnBtn != lValue)
                    {
                        mOnBtn = lValue;
                        evaluate();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mOffBtnItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for pump 'Off Button' state. ", lExc);
                    }

                    if (mOffBtn != lValue)
                    {
                        mOffBtn = lValue;
                        evaluate();
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
                    case "Control": return new PumpControlPanel(this);
                    case "State":   return new PumpStatePanel(this);
                    default:        throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
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
                    raisePropertiesChanged();
                }

                return lResult;
            }

            public void                                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader = new XMLAttributeReader(aXMLTextReader);
                var lChecker = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("Remote", "");
                lChecker.addItemName(lItem);
                mRemoteItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("OnCMD", "");
                lChecker.addItemName(lItem);
                mOnCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("OffCMD", "");
                lChecker.addItemName(lItem);
                mOffCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("EsdCMD", "");
                lChecker.addItemName(lItem);
                mEsdCMDItemHandle = mItemBrowser.getItemHandleByName(lItem);

                OnMS    = lReader.getAttribute<UInt32>("OnMS", mOnMS);
                OffMS   = lReader.getAttribute<UInt32>("OffMS", mOffMS);

                lItem = lReader.getAttribute<String>("On", "");
                lChecker.addItemName(lItem);
                mOnItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Power", "");
                lChecker.addItemName(lItem);
                mPowerItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Alarm", "");
                lChecker.addItemName(lItem);
                mAlarmItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("OnBtn", "");
                lChecker.addItemName(lItem);
                mOnBtnItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("OffBtn", "");
                lChecker.addItemName(lItem);
                mOffBtnItemHandle = mItemBrowser.getItemHandleByName(lItem);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Remote", mItemBrowser.getItemNameByHandle(mRemoteItemHandle));

                aXMLTextWriter.WriteAttributeString("OnCMD", mItemBrowser.getItemNameByHandle(mOnCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("OffCMD", mItemBrowser.getItemNameByHandle(mOffCMDItemHandle));
                aXMLTextWriter.WriteAttributeString("EsdCMD", mItemBrowser.getItemNameByHandle(mEsdCMDItemHandle));

                aXMLTextWriter.WriteAttributeString("OnMS", StringUtils.ObjectToString(mOnMS));
                aXMLTextWriter.WriteAttributeString("OffMS", StringUtils.ObjectToString(mOffMS));

                aXMLTextWriter.WriteAttributeString("On", mItemBrowser.getItemNameByHandle(mOnItemHandle));
                aXMLTextWriter.WriteAttributeString("Power", mItemBrowser.getItemNameByHandle(mPowerItemHandle));
                aXMLTextWriter.WriteAttributeString("Alarm", mItemBrowser.getItemNameByHandle(mAlarmItemHandle));
                aXMLTextWriter.WriteAttributeString("OnBtn", mItemBrowser.getItemNameByHandle(mOnBtnItemHandle));
                aXMLTextWriter.WriteAttributeString("OffBtn", mItemBrowser.getItemNameByHandle(mOffBtnItemHandle));
            }

            private void                                        evaluate()
            {
                if (mIgnoreCommands == false)
                {
                    bool lNewOnInternal = mOnInternal;

                    if (mPower && !mAlarm)
                    {
                        if ((mRemote && mOnCMD) || mOnBtn)
                        {
                            lNewOnInternal = true;
                        }
                    }

                    if ((mRemote && mOffCMD) || mOffBtn || !mPower || mEsdCMD || mAlarm)
                    {
                        lNewOnInternal = false;
                    }

                    mOnInternal = lNewOnInternal;
                }
            }

            private bool                                        mLastOutValue;

            private FiniteStateMachine                          mFSM;

            private long                                        mLastMS;
            private void                                        PumpSwitch()
            {
                if (mIgnoreCommands == false)
                {
                    if (mOnInternal == false && mOn == true)
                    {
                        mLastMS = MiscUtils.TimerMS;
                        mFSM.State = "Off";
                        return;
                    }

                    if (mOnInternal == true && mOn == false)
                    {
                        mLastMS = MiscUtils.TimerMS;
                        mFSM.State = "On";
                        return;
                    }
                }
            }

            private void                                        PumpOn()
            {
                if (MiscUtils.TimerMS - mLastMS > mOnMS)
                {
                    mOn = true;
                }

                if (mOn == true || mOnInternal == false || mIgnoreCommands)
                {
                    mFSM.State = "Switch";
                    return;
                }
            }

            private void                                        PumpOff()
            {
                if (MiscUtils.TimerMS - mLastMS > mOffMS)
                {
                    mOn = false;
                }
                if (mOn == false || mOnInternal == true || mIgnoreCommands)
                {
                    mFSM.State = "Switch";
                    return;
                }
            }

            public void                                         execute()
            {
                mFSM.executeStateAction();

                if (mLastOutValue != mOn)
                {
                    mLastOutValue = mOn;
                    raiseValuesChanged();
                    mValueChanged = true;
                }
            }

            public void                                         beforeActivate()
            {
                mFSM.State  = "Switch";
                mOnInternal = mOn;
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
