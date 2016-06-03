using API;
using S7PROSIMLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Utils;

namespace Connection.S7PLCSim
{
    public class Connection: IConnection, IDisposable
    {
        private S7ProSim                                    mS7ProSim           = new S7ProSim();
        public uint                                         mInstanceNumber     = 1;
        public bool                                         mContinuousScan     = true;

        private double                                      mSlowingFactor      = 0.0D;
        public uint                                         Slowdown
        {
            get { return (uint)mSlowingFactor; }
            set
            {
                if (value <= 0)
                {
                    mSlowingFactor  = 0.0D;
                    mDeltaSlow      = 0.0D;
                }
                else if (value >= 100)
                {
                    mSlowingFactor  = 100.0D;
                    mDeltaSlow      = 1.0D;
                }
                else
                {
                    mSlowingFactor  = (double)value;
                    mDeltaSlow      = 1.0D - 0.5D * Math.Log10(100.0D - mSlowingFactor);
                }
                mSlowCounter = 0.0D;
            }
        }
        private double                                      mDeltaSlow          = 0.0D;
        private double                                      mSlowCounter        = 0.0D;

        private System.Timers.Timer                         mMainCycleTimer;
        public long                                         mMainCycleTimeMS;
        private volatile bool                               mDisconnect;  

        private volatile DataItem                           mCurrentItem;

        public                                              Connection()
        {
            mS7ProSim.ConnectionError += new IS7ProSimEvents_ConnectionErrorEventHandler(onConnectionError);
        }

        private void                                        onConnectionError(string aControlEngine, int aError)
        {
            StringBuilder lMessage = new StringBuilder();
            switch (aError)
            {
                //==================  PS_E_BADBITNDX            0x80040205 : Bit index is invalid
                case -2147220987: lMessage.Append(mCurrentItem.Description); lMessage.Append(". Bit index is invalid. "); break;

                //==================  PS_E_BADBYTECOUNT         0x80040202 : Size of data array is invalid for given starting byte index
                case -2147220990: lMessage.Append(mCurrentItem.Description); lMessage.Append(". Size of data array is invalid for given starting byte index. "); break;

                //==================  PS_E_BADBYTENDX           0x80040201 : Byte index is invalid
                case -2147220991: lMessage.Append(mCurrentItem.Description); lMessage.Append(". Byte index is invalid. "); break;

                //================== PS_E_BADTYPE               0x80040206 : Invalid data type
                case -2147220986: lMessage.Append(mCurrentItem.Description); lMessage.Append(". Invalid data type. "); break;

                //==================  PS_E_INVALIDCALLBACK      0x80040207 : Invalid callback
                case -2147220985: lMessage.Append("Invalid callback. "); break;

                //==================  PS_E_INVALIDDISPATCH      0x80040208 : Invalid dispatch
                case -2147220984: lMessage.Append("Invalid dispatch. "); break;

                //==================  PS_E_INVALIDINPUT         0x80040213 : Invalid input
                case -2147220973: lMessage.Append("Invalid input. "); break;

                //==================  PS_E_INVALIDSCANTYPE      0x8004020B : Invalid scan type, must be one of the ScanModeConstants
                case -2147220981: lMessage.Append("Invalid scan type, must be one of the ScanModeConstants. "); break;

                //==================  PS_E_MAXINSTANCE          0x80040214 : Maximum number of open S7-PLCSIM instances reached
                case -2147220972: lMessage.Append("Maximum number of open S7-PLCSIM instances reached. "); break;

                //==================  PS_E_MODENOTPOSSIBLE      0x8004020C : S7-PLCSIM could not set specified scan mode
                case -2147220980: lMessage.Append("S7-PLCSIM could not set specified scan mode. "); break;

                //==================  PS_E_NOTALLREADSWORKED    0x8004020F : All read operations did not succeed
                case -2147220977: lMessage.Append("All read operations did not succeed. "); break;

                //==================  PS_E_NOTALLWRITESWORKED   0x80040210 : All write operations did not succeed
                case -2147220976: lMessage.Append("All write operations did not succeed. "); break;

                //================== PS_E_NOTCONNECTED          0x80040211 : S7ProSim is not connected to S7-PLCSIM
                case -2147220975: lMessage.Append("S7ProSim is not connected to S7-PLCSIM. "); break;

                //==================  PS_E_NOTIFICATION_EXIST   0x8004020D : S7ProSim is already registered for notification
                case -2147220979: lMessage.Append("S7ProSim is already registered for notification. "); break;

                //==================  PS_E_NOTREGISTERED        0x80040209 : S7ProSim is not registered for callbacks from S7-PLCSIM
                case -2147220983: lMessage.Append("S7ProSim is not registered for callbacks from S7-PLCSIM. "); break;

                //==================  PS_E_NOTSINGLESCAN        0x8004020A : S7-PLCSIM is not in single scan mode
                case -2147220982: lMessage.Append("S7-PLCSIM is not in single scan mode. "); break;

                //==================  PS_E_PLCNOTRUNNING        0x8004020E : S7-PLCSIM is not running
                case -2147220978: lMessage.Append("S7-PLCSIM is not running. "); break;

                //==================  PS_E_POWEROFF             0x80040212 : S7-PLCSIM is powered off
                case -2147220974: lMessage.Append("S7-PLCSIM is powered off. "); break;

                //==================  PS_E_READFAILED           0x80040203 : Read operation failed
                case -2147220989: lMessage.Append("Read operation failed. "); break;

                //==================  PS_E_WRITEFAILED          0x80040204 : Write operation failed
                case -2147220988: lMessage.Append("Write operation failed. "); break;

                //================== E_FAIL                     0x80004005 : Unspecified error
                case -2147467259: lMessage.Append("Unspecified error. "); break;

                //================== STG_E_CANTSAVE             0x80030103 : Cannot save
                case -2147286781: lMessage.Append("Cannot save. "); break;

                //==================  E_INVALID_STATE           0x00008002 : Invalid state
                case 32770: lMessage.Append("Invalid state. "); break;

                //==================  S_OK                      0x00000000 : Success code
                case 0: break;

                default: lMessage.Append("Unknown error. "); break;
            }

            if (aError != 0)
            {
                mDisconnect = true;
                lMessage.Append("(" + aError.ToString("X") + ")");
                raiseConnectionError(lMessage.ToString());
            }
        }

        #region Read optimisation

            private int                                     mQStartIndex    = 0;

            private int                                     mQLength        = 0;

            private bool                                    mQOptimise      = false;
            private void                                    optimise()
            {
                mQStartIndex    = 65569;
                mQLength        = 0;

                DataItem lItem;
                int lLength = 0;
                int lDif;

                int lCount = mItemRWList.Count;
                for (int i = 0; i < lCount; i++)
                {
                    lItem = mItemRWList[i];
                    if (lItem.mMemoryType == EPLCMemoryType.Q)
                    {
                        if (lItem.Byte < mQStartIndex)
                        {
                            if (mQLength != 0)
                            {
                                mQLength = mQLength + (mQStartIndex - lItem.Byte);
                            }
                            mQStartIndex    = lItem.Byte;
                        }

                        switch(lItem.DataType)
                        {
                            case PointDataTypeConstants.S7_Bit:         lLength = 1; break;
                            case PointDataTypeConstants.S7_Byte:        lLength = lItem.Length; break;
                            case PointDataTypeConstants.S7_Word:        lLength = lItem.Length * 2; break;
                            case PointDataTypeConstants.S7_DoubleWord:  lLength = lItem.Length * 4; break;
                        }

                        lDif = lItem.Byte + lLength - mQStartIndex - mQLength;
                        if (lDif > 0)
                        {
                            mQLength = mQLength + lDif;
                        }
                    }
                }
            }

        #endregion

        public long                                         mWriteRequests;

        private void                                        MainCycle(object aSender, ElapsedEventArgs aEventArgs)
        {
            long lStartMS = MiscUtils.TimerMS;

            if (mDisconnect == false)
            {
                try
                {
                    mS7ProSim.GetState();

                    if (mItemList.Count != 0)
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
                                    mItemListChanged = false;
                                }
                                finally
                                {
                                    //========================================
                                    mItemListLock.ExitReadLock();
                                }

                                mQLength    = 0;
                                mQOptimise  = true;
                            }
                            else if (mQOptimise)
                            {
                                mQOptimise = false;
                                optimise();
                            }

                        #endregion

                        if (mQLength > 0)
                        {
                            Task lQ = new Task(MC_Q_Read);
                            lQ.Start();

                            Task lIMDB = new Task(MC_IMDB_WriteRead);
                            lIMDB.Start();

                            Task.WaitAll(lQ, lIMDB);
                        }
                        else
                        {
                            int lCount = mItemRWList.Count;

                            for (int i = 0; i < lCount; i++)
                            {
                                mCurrentItem = mItemRWList[i];

                                if (mDisconnect) { break; }

                                #region Write

                                    if (mCurrentItem.mNeedWrite)
                                    {
                                        mWriteRequests = mWriteRequests + 1;
                                        mCurrentItem.write(mS7ProSim);
                                    }

                                #endregion

                                if (mDisconnect) { break; }

                                #region Read

                                    if (mCurrentItem.mNeedWrite != true)
                                    {
                                        mCurrentItem.read(mS7ProSim);
                                    }

                                #endregion

                                if (mDisconnect) { break; }

                                mSlowCounter = mSlowCounter + mDeltaSlow;
                                if (mSlowCounter >= 1.0D)
                                {
                                    mSlowCounter = mSlowCounter - 1.0D;
                                    Thread.Sleep(MiscUtils.TimeSlice);
                                }
                            }

                            mCurrentItem = null;
                        }
                    }
                }
                catch (Exception lExc)
                {
                    mDisconnect = true;
                    raiseConnectionError(lExc.Message);
                }
            }

            mMainCycleTimeMS = MiscUtils.TimerMS - lStartMS;

            if (mDisconnect)
            {
                mS7ProSim.EndScanNotify();
                mS7ProSim.Disconnect();

                mConnected = false;
                raiseConnectionState();
                mCycleEndEvent.Set();
                mDisconnectEvent.Set();
            }
            else
            {
                mMainCycleTimer.Start();
                mCycleEndEvent.Set();
            }
        }

        private void                                        MC_Q_Read()
        {
            object lObject = null;
            try
            {
                mS7ProSim.ReadOutputImage(mQStartIndex, mQLength, ImageDataTypeConstants.S7Byte, ref lObject);
            }
            catch (Exception lExc)
            {
                mDisconnect = true;
                raiseConnectionError(lExc.Message);
                return;
            }

            byte[] lQBuffer = (byte[])lObject;
            Parallel.ForEach<DataItem>
            (
                mItemRWList, (lItem, lLoopState) =>
                            {
                                try
                                {
                                    if (mDisconnect)
                                    {
                                        lLoopState.Stop();
                                        return;
                                    }

                                    if (lItem.mMemoryType == EPLCMemoryType.Q && lItem.mNeedWrite != true)
                                    {
                                        lItem.setValueFromBuffer(lQBuffer, mQStartIndex);
                                    }
                                }
                                catch (Exception lExc)
                                {
                                    mDisconnect = true;
                                    raiseConnectionError(lExc.Message);
                                }
                            }
            );
        }

        private void                                        MC_IMDB_WriteRead()
        {
            int lCount = mItemRWList.Count;

            for (int i = 0; i < lCount; i++)
            {
                mCurrentItem = mItemRWList[i];

                if (mDisconnect) { break; }

                if (mCurrentItem.mMemoryType != EPLCMemoryType.Q)
                {
                    try
                    {
                        #region Write

                            if (mCurrentItem.mNeedWrite)
                            {
                                mWriteRequests = mWriteRequests + 1;
                                mCurrentItem.write(mS7ProSim);
                            }

                        #endregion

                        if (mDisconnect) { break; }

                        #region Read

                            if (mCurrentItem.mNeedWrite != true)
                            {
                                mCurrentItem.read(mS7ProSim);
                            }

                        #endregion

                        if (mDisconnect) { break; }

                        mSlowCounter = mSlowCounter + mDeltaSlow;
                        if (mSlowCounter >= 1.0D)
                        {
                            mSlowCounter = mSlowCounter - 1.0D;

                            Thread.Sleep(MiscUtils.TimeSlice);
                        }
                    }
                    catch (Exception lExc)
                    {
                        mDisconnect = true;
                        raiseConnectionError(lExc.Message);
                    }
                }

                mCurrentItem = null;
            }
        }

        private ManualResetEvent                            mCycleEndEvent = new ManualResetEvent(true);

        public void                                         waitCycleEnd()
        {
            if (mConnected)
            {
                mCycleEndEvent.Reset();
                if (mConnected)
                {
                    mCycleEndEvent.WaitOne();
                }
            }
        }

        public void                                         connect()
        {
            mS7ProSim.ConnectExt((int)mInstanceNumber);
            if (mS7ProSim.GetState().Equals("ERROR", StringComparison.Ordinal))
            {
                throw new InvalidOperationException("Unable to connect application instance №" + StringUtils.ObjectToString(mInstanceNumber) + ". ");
            }

            if (mMainCycleTimer == null)
            {
                mMainCycleTimer             = new System.Timers.Timer(MiscUtils.TimeSlice);
                mMainCycleTimer.Elapsed     += new ElapsedEventHandler(MainCycle);
                mMainCycleTimer.AutoReset   = false;
            }

            mConnected      = true;
            mDisconnect     = false;
            mWriteRequests  = 0;
            mMainCycleTimer.Start();

            if (mContinuousScan)
            {
                mS7ProSim.SetScanMode(ScanModeConstants.ContinuousScan);
            }

            mS7ProSim.BeginScanNotify();

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

        private volatile bool                               mConnected          = false;
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
            EventHandler lEvent = ConnectionState;
            if (lEvent != null) lEvent(this, EventArgs.Empty);
        }

        private string                                      mLastError          = "";
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
            var lEvent  = ConnectionError;
            if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
        }

        #region Items

            private List<DataItem>          mItemList       = new List<DataItem>();
            private List<DataItem>          mItemRWList     = new List<DataItem>();
            private ReaderWriterLockSlim    mItemListLock   = new ReaderWriterLockSlim();
            private volatile bool           mItemListChanged;

            public void                     addItem(DataItem aItem)
            {
                aItem.mConnection   = this;
                ConnectionState     += new EventHandler(aItem.onConnectionStateChanged);
                aItem.initAccess();

                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    mItemList.Add(aItem);
                    mItemListChanged = true;
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }
            }

            public void                     removeItem(DataItem aItem)
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

            public int                      NumberOfItems
            {
                get
                {
                    return mItemList.Count;
                }
            }

        #endregion

        #region IDisposable

        private bool                                    mDisposed = false;

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
                        mS7ProSim.ConnectionError -= onConnectionError;

                        mItemList.Clear();
                        mItemRWList.Clear();
                        mCurrentItem = null;

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

                        if (mCycleEndEvent != null)
                        {
                            mCycleEndEvent.Dispose();
                            mCycleEndEvent = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
