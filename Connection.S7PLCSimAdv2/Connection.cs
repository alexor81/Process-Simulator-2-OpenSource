// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Timers;
using Utils;

namespace Connection.S7PLCSimAdv2
{
    public class Connection: IConnection, IDisposable
    {
        public static string                                ErrorCodeMessage(ERuntimeErrorCode aCode)
        {
            switch(aCode)
            {
                case ERuntimeErrorCode.DoesNotExist:                return "Does not exist (-4). ";
                case ERuntimeErrorCode.WrongArgument:               return "Argument is wrong (-8). ";
                case ERuntimeErrorCode.ConnectionError:             return "Connection error (-10). ";
                case ERuntimeErrorCode.Timeout:                     return "Timeout (-11). ";
                case ERuntimeErrorCode.WrongVersion:                return "Wrong version (-13). ";
                case ERuntimeErrorCode.InstanceNotRunning:          return "Instance not running (-14). ";
                case ERuntimeErrorCode.InterfaceRemoved:            return "Interface removed (-15). ";
                case ERuntimeErrorCode.NotSupported:                return "Not supported (-19). ";
                case ERuntimeErrorCode.SignalConfigurationError:    return "Signal configuration error (-24). ";
                case ERuntimeErrorCode.TypeMismatch:                return "Type mismatch (-29). ";
                case ERuntimeErrorCode.NotEnoughMemory:             return "Not enough memory (-43). ";
                case ERuntimeErrorCode.NotUpToDate:                 return "The stored tag list must be updated (-47). ";

                default:                                            return "Unknown error code " + ((int)aCode).ToString() + ". ";
            }
        }

        public static string[]                              getPLCList(bool aRomote, string aIP, int aIPPort)
        {
            SInstanceInfo[] lPLC;   

            if (aRomote)
            {    
                var lConnectionStr = aIP + ":" + aIPPort.ToString();
                try
                {
                    var lRRManager  = SimulationRuntimeManager.RemoteConnect(lConnectionStr);
                    lPLC            = lRRManager.RegisteredInstanceInfo;
                    lRRManager.Disconnect();
                    lRRManager.Dispose();
                }
                catch(SimulationRuntimeException lExc)
                {
                    throw new InvalidOperationException("Connection '" + lConnectionStr + "'. " + ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                }
            }
            else
            {
                try
                {
                    lPLC = SimulationRuntimeManager.RegisteredInstanceInfo;
                }
                catch(SimulationRuntimeException lExc)
                {
                    throw new InvalidOperationException(ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                }
            }

            return lPLC.Select(x => x.Name).ToArray();
        }

        public string                                       mPLCName;
        private IInstance                                   mPLC;

        public bool                                         mRemote         = false;
        private string                                      mIP             = "";
        public string                                       IP
        {
            get { return mIP; }
            set
            {
                mIP = CommunicationUtils.checkTCP_IP(value);
            }
        }
        private int                                         mIPPort         = 50000;
        public int                                          IPPort
        {
            get { return mIPPort; }
            set
            {
                CommunicationUtils.checkTCP_Port(value);
                mIPPort = value;
            }
        }
        private IRemoteRuntimeManager                       mRRManager      = null;

        private System.Timers.Timer                         mMainCycleTimer;
        public long                                         mMainCycleTimeMS;
        private volatile bool                               mDisconnect;

        private uint                                        mPauseMS        = 0;
        private uint                                        mSleepCounts    = 0;
        private uint                                        mSleepAddMS     = 0;
        private uint                                        mAddMS          = 0;
        public uint                                         PauseMS
        {
            get { return mPauseMS; }
            set
            {
                uint lValue = value;

                if (lValue > 10000)
                {
                    lValue = 10000;
                }

                mPauseMS        = lValue;
                mSleepCounts    = lValue / MiscUtils.TimeSlice;
                mSleepAddMS     = lValue % MiscUtils.TimeSlice;
            }
        }
        private void                                        pause()
        {
            if (mDisconnect == false && mSleepCounts != 0)
            {
                for (int i = 0; i < mSleepCounts; i++)
                {
                    if (mDisconnect)
                    {
                        return;
                    }
                    else
                    {
                        Thread.Sleep(MiscUtils.TimeSlice);
                    }
                }
            }

            if (mDisconnect == false && mSleepAddMS > 0)
            {
                mAddMS = mAddMS + mSleepAddMS;

                if (mAddMS >= MiscUtils.TimeSlice)
                {
                    mAddMS = mAddMS - MiscUtils.TimeSlice;
                    Thread.Sleep(MiscUtils.TimeSlice);
                }
            }
        }   

        public                                              Connection()
        {
            SimulationRuntimeManager.OnRunTimemanagerLost += onConnectionLost;
        }

        private void                                        onConnectionLost()
        {
            mDisconnect = true;
            raiseConnectionError("Connection lost. ");
        }

        private void                                        onRemoteConnectionLost(IRemoteRuntimeManager aSender)
        {
            onConnectionLost();
        }

        private TagBrowserForm                              mTagBrowserForm;
        public TagBrowserForm                               TagBrowserForm
        {
            get
            {
                if (mTagBrowserForm == null)
                {
                    mTagBrowserForm = new TagBrowserForm(mPLC);
                }

                return mTagBrowserForm;
            }
        }

        public long                                         mWriteRequests;

        private void                                        MainCycle(object aSender, ElapsedEventArgs aEventArgs)
        {
            long lStartMS = MiscUtils.TimerMS;

            if (mDisconnect) goto End;

            if (mItemList.Count != 0)
            {
                try
                {
                    #region Item List Changed

                        if (mItemListChanged)
                        {
                            mItemRWList.Clear();
                            mItemListLock.EnterReadLock();
                            //========================================
                            try
                            {
                                mItemRWList.AddRange(mItemList);
                                var lCount  = mItemList.Count;
                                mSDataValue = new SDataValueByNameWithCheck[lCount];
                                for (int i = 0; i < lCount; i++)
                                {
                                    var lDataValue  = new SDataValueByNameWithCheck();
                                    lDataValue.Name = mItemList[i].mTagName;

                                    mSDataValue[i] = lDataValue;
                                }

                                mItemListChanged = false;
                            }
                            finally
                            {
                                //========================================
                                mItemListLock.ExitReadLock();
                            }
                        }

                    #endregion

                    if (mDisconnect) goto End;

                    bool lNewValues;
                    try
                    {
                        mPLC.ReadSignals(ref mSDataValue, out lNewValues);
                    }
                    catch(SimulationRuntimeException lExc)
                    {
                        if (lExc.RuntimeErrorCode != ERuntimeErrorCode.SignalConfigurationError)
                        {
                            throw new InvalidOperationException(ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                        }
                    }

                    if (mDisconnect) goto End;

                    for (int i = 0; i < mSDataValue.Length; i++)
                    {
                        if (mItemRWList[i].mNeedWrite)
                        {
                            mItemRWList[i].mNeedWrite   = false;
                            mWriteRequests              = mWriteRequests + 1;

                            mPLC.Write(mItemRWList[i].mTagName, mItemRWList[i].getValue());
                        }
                        else
                        {
                            if (mSDataValue[i].ErrorCode == ERuntimeErrorCode.OK)
                            {
                                mItemRWList[i].Access = EAccess.READ_WRITE;
                            }
                            else
                            {
                                mItemRWList[i].Access = EAccess.NO_ACCESS;
                            }

                            if (mSDataValue[i].ValueHasChanged)
                            {
                                mItemRWList[i].setValue(mSDataValue[i].DataValue);
                            }
                        }
                        if (mDisconnect) goto End;
                    }

                    pause();
                }
                catch (Exception lExc)
                {
                    mDisconnect = true;
                    raiseConnectionError(lExc.Message);
                }
            }

            mMainCycleTimeMS = MiscUtils.TimerMS - lStartMS;

End:
            if (mDisconnect)
            {
                if (mPLC != null)
                {
                    mPLC.Dispose();
                    mPLC = null;
                }

                if (mRRManager != null)
                {
                    mRRManager.OnConnectionLost -= onRemoteConnectionLost;
                    mRRManager.Disconnect();
                    mRRManager.Dispose();
                    mRRManager = null;
                }

                mConnected = false;
                raiseConnectionState();
                mDisconnectEvent.Set();
            }
            else
            {
                mMainCycleTimer.Start();
            }
        }

        public void                                         connect()
        {
            if (mTagBrowserForm != null)
            {
                mTagBrowserForm.Dispose();
                mTagBrowserForm = null;
            }

            if (String.IsNullOrWhiteSpace(mPLCName))
            {
                throw new InvalidOperationException("PLC name is empty. ");
            }

            if (mRemote)
            {
                var lConnectionStr = mIP + ":" + mIPPort.ToString();
                if (String.IsNullOrWhiteSpace(lConnectionStr))
                {
                    throw new InvalidOperationException("Connection string is empty. ");
                }

                try
                {
                    mRRManager  = SimulationRuntimeManager.RemoteConnect(lConnectionStr);
                }
                catch(SimulationRuntimeException lExc)
                {
                    throw new InvalidOperationException("Connection '" + lConnectionStr + "'. " + ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                }

                try
                {
                    mPLC = mRRManager.CreateInterface(mPLCName);
                }
                catch(SimulationRuntimeException lExc)
                {
                    mRRManager.Dispose();
                    mRRManager = null;

                    throw new InvalidOperationException("PLC instance '" + mPLCName + "'. " + ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                }

                mRRManager.OnConnectionLost += onRemoteConnectionLost;
            }
            else
            {
                try
                {
                    mPLC = SimulationRuntimeManager.CreateInterface(mPLCName);
                }
                catch(SimulationRuntimeException lExc)
                {
                    throw new InvalidOperationException("PLC instance '" + mPLCName + "'. " + ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                }
            }

            if (mMainCycleTimer == null)
            {
                mMainCycleTimer             = new System.Timers.Timer(MiscUtils.TimeSlice);
                mMainCycleTimer.Elapsed     += new ElapsedEventHandler(MainCycle);
                mMainCycleTimer.AutoReset   = false;
            }

            mPLC.UpdateTagList();

            mConnected      = true;
            mDisconnect     = false;
            mWriteRequests  = 0;
            mMainCycleTimer.Start();
            raiseConnectionState();
        }

        public void                                         disconnect()
        {
            mDisconnectEvent.Reset();
            mDisconnect = true;
            if (mConnected)
            {
                mDisconnectEvent.WaitOne();
            }
        }
        private ManualResetEvent                            mDisconnectEvent    = new ManualResetEvent(true);

        private volatile bool                               mConnected  = false;
        public bool                                         Connected
        {
            get
            {
                return mConnected;
            }
        }

        public event EventHandler                           ConnectionState;
        private void                                        raiseConnectionState()
        {
            ConnectionState?.Invoke(this, EventArgs.Empty);
        }

        private string                                      mLastError  = "";
        public string                                       LastError
        {
            get
            {
                return mLastError;
            }
        }
        public event                                        EventHandler<MessageStringEventArgs> ConnectionError;
        private void                                        raiseConnectionError(string aMessage)
        {
            mLastError  = aMessage;
            ConnectionError?.Invoke(this, new MessageStringEventArgs(aMessage));
        }

        #region Items

            private List<DataItem>                          mItemList       = new List<DataItem>();
            private List<DataItem>                          mItemRWList     = new List<DataItem>();
            private SDataValueByNameWithCheck[]             mSDataValue;
            private ReaderWriterLockSlim                    mItemListLock   = new ReaderWriterLockSlim();
            private volatile bool                           mItemListChanged;

            public DataItem                                 addItem(string aTagName)
            {
                if(String.IsNullOrWhiteSpace(aTagName))
                {
                    throw new ArgumentException("Item TagName is empty. ");
                }

                DataItem lItem      = new DataItem();
                lItem.mTagName      = aTagName;
                lItem.mConnection   = this;  

                if (Connected)
                {
                    try
                    {
                        lItem.setValue(mPLC.Read(aTagName));
                        lItem.mAccess = EAccess.READ_WRITE;
                    }
                    catch(SimulationRuntimeException lExc)
                    {
                        throw new InvalidOperationException(ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                    }
                } 

                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    mItemList.Add(lItem);
                    mItemListChanged = true;
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }

                ConnectionState += new EventHandler(lItem.onConnectionStateChanged);

                lItem.raisePropertiesChanged();
                lItem.updateValue();

                return lItem;
            }

            public void                                     modifyItem(DataItem aItem, string aNewTagName)
            {
                if (aItem.mTagName.Equals(aNewTagName, StringComparison.Ordinal) == false)
                {
                    SDataValue lSDValue = new SDataValue();
                    lSDValue.Type = EPrimitiveDataType.Unspecific;

                    if (mConnected)
                    {
                        try
                        {
                            lSDValue = mPLC.Read(aNewTagName);
                        }
                        catch(SimulationRuntimeException lExc)
                        {
                            throw new InvalidOperationException(ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                        }

                        if (lSDValue.Type == EPrimitiveDataType.Struct 
                            || lSDValue.Type == EPrimitiveDataType.Unspecific)
                        {
                            throw new InvalidOperationException("Type is not supported. ");
                        }
                    }

                    mItemListLock.EnterWriteLock();
                    //========================================
                    try
                    {
                        aItem.mTagName      = aNewTagName;
                        mItemListChanged    = true;
                    }
                    finally
                    {
                        //========================================
                        mItemListLock.ExitWriteLock();
                    }

                    aItem.raisePropertiesChanged();
                    if (lSDValue.Type != EPrimitiveDataType.Unspecific)
                    {
                        aItem.setValue(lSDValue);
                    }
                }
            }

            public void                                     removeItem(DataItem aItem)
            {
                ConnectionState -= aItem.onConnectionStateChanged;

                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    mItemList.Remove(aItem);
                    mItemListChanged = true;
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }
            }

            public int                                      NumberOfItems
            {
                get
                {
                    return mItemList.Count;
                }
            }

        #endregion

        #region IDisposable

            private bool                                    mDisposed   = false;

            public void                                     Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void                          Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        SimulationRuntimeManager.OnRunTimemanagerLost -= onConnectionLost;

                        mItemList.Clear();
                        mItemRWList.Clear();
                        mSDataValue = null;

                        if (mTagBrowserForm != null)
                        {
                            mTagBrowserForm.Dispose();
                            mTagBrowserForm = null;
                        }

                        if (mItemListLock != null)
                        {
                            mItemListLock.Dispose();
                            mItemListLock = null;
                        }

                        if (mMainCycleTimer != null)
                        {
                            mMainCycleTimer.Dispose();
                            mMainCycleTimer = null;
                        }

                        if (mDisconnectEvent != null)
                        {
                            mDisconnectEvent.Dispose();
                            mDisconnectEvent = null;
                        }

                        if (mPLC != null)
                        {
                            mPLC.Dispose();
                            mPLC = null;
                        }

                        if (mRRManager != null)
                        {
                            mRRManager.OnConnectionLost -= onRemoteConnectionLost;
                            mRRManager.Disconnect();
                            mRRManager.Dispose();
                            mRRManager = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
