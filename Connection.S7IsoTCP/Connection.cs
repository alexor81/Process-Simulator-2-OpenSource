using API;
using Snap7;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Utils;
using Utils.Logger;

namespace Connection.S7IsoTCP
{
    public class Connection : IConnection, IDisposable
    {
        public S7Client                 mClient                 = new S7Client();
        public string                   mIP                     = "127.0.0.1";
        private int                     mRack                   = 0;
        public int                      Rack
        {
            get { return mRack;  }
            set
            {
                mRack = value;
            }
        }
        private int                     mSlot                   = 0;
        public int                      Slot
        {
            get { return mSlot; }
            set
            {
                mSlot = value;
            }
        }
        public EConnectionType          mConnectionType         = EConnectionType.PG;

        private System.Timers.Timer     mMainCycleTimer;
        public long                     mMainCycleTimeMS;
        private volatile bool           mDisconnect             = false;

        public uint                     mErrorsBeforeDisconnect = 3;
        private uint                    mErrorsCounter          = 0;

        private double                  mSlowingFactor          = 0.0D;
        public uint                     Slowdown
        {
            get { return (uint)mSlowingFactor; }
            set
            {
                if (value <= 0)
                {
                    mSlowingFactor = 0.0D;
                    mDeltaSlow = 0.0D;
                }
                else if (value >= 100)
                {
                    mSlowingFactor = 100.0D;
                    mDeltaSlow = 1.0D;
                }
                else
                {
                    mSlowingFactor = (double)value;
                    mDeltaSlow = 1.0D - 0.5D * Math.Log10(100.0D - mSlowingFactor);
                }
                mSlowCounter = 0.0D;
            }
        }
        private double                  mDeltaSlow              = 0.0D;
        private double                  mSlowCounter            = 0.0D;

        #region Read/Write optimisation

            private class GroupDescriptor
            {
                public static GroupDescriptor   getNewGroupDescriptor(DataItem aItem, int aPDULength, int aMaxAddress)
                {
                    var lGroupDsc       = new GroupDescriptor();
                    lGroupDsc.mStart    = aItem.Byte;
                    lGroupDsc.setBufferSize(aItem, aPDULength, aMaxAddress);
                    return lGroupDsc;
                }

                public bool                     mActual;
                public int                      mStart;             
                public byte[]                   mBuffer;
                public void                     setBufferSize(DataItem aItem, int aPDULength, int aMaxAddress)
                {
                    int lBuffer = mStart + aItem.Byte + aItem.BufferLength;
                    int lDiv    = lBuffer / aPDULength;
                    if ((lBuffer % aPDULength) > 0)
                    {
                        lDiv = lDiv + 1;
                    }
                    lBuffer = aPDULength * lDiv;

                    if (mStart + lBuffer - 1 > aMaxAddress)
                    {
                        lBuffer = aMaxAddress - mStart + 1;
                    }

                    mBuffer = new byte[lBuffer];
                }
            }

            private List<GroupDescriptor>   mGroups             = new List<GroupDescriptor>();

            private int                     mPDULength          = 0;

            private bool                    mOptimize           = false;
            private void                    optimize()
            {
                #region Sorting

                    var lMemoryAreas    = new SortedList<string, SortedDictionary<int, List<DataItem>>>(StringComparer.Ordinal);
                    var lItemCount      = new SortedList<string, int>(StringComparer.Ordinal);
                    var lMaxAddress     = new SortedList<string, int>(StringComparer.Ordinal);

                    DataItem lItem;
                    string lAreaName;
                    int lMax;

                    int lCount = mItemRWList.Count;
                    for (int i = 0; i < lCount; i++)
                    {
                        lItem       = mItemRWList[i];
                        lAreaName   = lItem.mMemoryType.ToString();
                        if (lItem.mMemoryType == EArea.DB)
                        {
                            lAreaName = lAreaName + lItem.DB.ToString();
                        }

                        lMax = lItem.Byte + lItem.BufferLength - 1;

                        if (lMemoryAreas.ContainsKey(lAreaName) == false)
                        {
                            lMemoryAreas.Add(lAreaName, new SortedDictionary<int, List<DataItem>>());
                            lItemCount.Add(lAreaName, 0);
                            lMaxAddress.Add(lAreaName, lMax);                            
                        }

                        if (lMemoryAreas[lAreaName].ContainsKey(lItem.Byte) == false)
                        {
                            lMemoryAreas[lAreaName].Add(lItem.Byte, new List<DataItem>());
                        }

                        lMemoryAreas[lAreaName][lItem.Byte].Add(lItem);
                        lItemCount[lAreaName] = lItemCount[lAreaName] + 1;
                        if (lMaxAddress[lAreaName] < lMax)
                        {
                            lMaxAddress[lAreaName] = lMax;
                        }

                        lItem.mGroup = 0;
                    }

                #endregion

                #region Grouping

                    SortedDictionary<int, List<DataItem>> lArea;
                    mGroups.Clear();
                    mItemRWList.Clear();
                    
                    int lGroupLastByte;
                    int lItemLastByte;
                    GroupDescriptor lGroupDsc   = null;
                    int lGroup                  = 0;

                    foreach (string lAreaName1 in lMemoryAreas.Keys)
                    {
                        lArea = lMemoryAreas[lAreaName1];
                        foreach (int lByte in lArea.Keys)
                        {
                            mItemRWList.AddRange(lArea[lByte]); 
                        }

                        if (lItemCount[lAreaName1] > 1)
                        {
                            foreach (int lByte in lArea.Keys)
                            {
                                foreach (DataItem lItem1 in lArea[lByte])
                                {
                                    if (lGroupDsc == null)
                                    {
                                        lGroupDsc = GroupDescriptor.getNewGroupDescriptor(lItem1, mPDULength, lMaxAddress[lAreaName1]);
                                        mGroups.Add(lGroupDsc);
                                        lGroup = lGroup + 1;
                                    }

                                    lGroupLastByte  = lGroupDsc.mStart + lGroupDsc.mBuffer.Length - 1;
                                    lItemLastByte   = lItem1.Byte + lItem1.BufferLength - 1;

                                    if (lGroupLastByte < lItemLastByte)
                                    {
                                        if (lItem1.Byte <= lGroupLastByte)
                                        {
                                            lGroupDsc.setBufferSize(lItem1, mPDULength, lMaxAddress[lAreaName1]);
                                        }
                                        else
                                        {
                                            lGroupDsc = GroupDescriptor.getNewGroupDescriptor(lItem1, mPDULength, lMaxAddress[lAreaName1]);
                                            mGroups.Add(lGroupDsc);
                                            lGroup = lGroup + 1;
                                        }                
                                    }

                                    lItem1.mGroup = lGroup;
                                }   
                            }
                            lGroupDsc = null;
                        }
                    }

                #endregion
            }

            private void                    read(DataItem aItem)
            {
                if (aItem.mGroup == 0)
                {
                    aItem.read(mClient);
                }
                else
                {
                    GroupDescriptor lGroupDsc = mGroups[aItem.mGroup - 1];
                    if (lGroupDsc.mActual == false)
                    {
                        int lResult = mClient.ReadArea((int)aItem.mMemoryType, aItem.DB, lGroupDsc.mStart, lGroupDsc.mBuffer.Length, (int)EWordlen.S7_Byte, lGroupDsc.mBuffer);
                        if (lResult != 0)
                        {
                            reportError("Error reading data for group of Items: " + mClient.ErrorText(lResult));
                            return;
                        }

                        lGroupDsc.mActual = true;
                    }

                    byte[] lValue   = new byte[aItem.BufferLength];
                    int lIndex      = aItem.Byte - lGroupDsc.mStart;
                    if (aItem.DataType == EWordlen.S7_Bit)
                    {
                        if ((lGroupDsc.mBuffer[lIndex] & (1 << aItem.Bit)) != 0)
                        {
                            lValue[0] = 1;
                        }
                        else
                        {
                            lValue[0] = 0;
                        }
                    }
                    else
                    {
                        Array.Copy(lGroupDsc.mBuffer, lIndex, lValue, 0, lValue.Length);
                    }
                    aItem.setValueFromPLC(lValue);
                }
            }

            private void                    write(DataItem aItem)
            {
                mWriteRequests = mWriteRequests + 1;
                byte[] lValue = aItem.write(mClient);
                if (lValue != null && aItem.mGroup != 0)
                {
                    var lGroupDsc   = mGroups[aItem.mGroup - 1];
                    int lIndex      = aItem.Byte - lGroupDsc.mStart;
                    if (aItem.DataType == EWordlen.S7_Bit)
                    {
                        if (lValue[0] == 1)
                        {
                            lGroupDsc.mBuffer[lIndex] = (byte)(lGroupDsc.mBuffer[lIndex] | (1 << aItem.Bit));
                        }
                        else
                        {
                            lGroupDsc.mBuffer[lIndex] = (byte)(lGroupDsc.mBuffer[lIndex] & ~(1 << aItem.Bit));
                        }
                    }
                    else
                    {
                        for (int i = lIndex; i < lValue.Length; i++)
                        {
                            lGroupDsc.mBuffer[i] = lValue[i];
                        }
                    }
                }
            }

            private void                    resetGroupCache()
            {
                int lCount = mGroups.Count;
                for (int i = 0; i < lCount; i++)
                {
                    mGroups[i].mActual = false;
                }
            }

        #endregion

        public long                     mWriteRequests;

        private void                    MainCycle(object aSender, ElapsedEventArgs aEventArgs)
        {
            long lStartMS = MiscUtils.TimerMS;

            if (mDisconnect == false)
            {
                    try
                    {
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

                                foreach (DataItem lDataItem in mItemRWList)
                                {
                                    lDataItem.mGroup = 0;
                                }

                                mOptimize = true;
                            }
                            else if (mOptimize)
                            {
                                mOptimize = false;
                                optimize();
                            }

                            #endregion

                            int lCount = mItemRWList.Count;
                            DataItem lItem;

                            for (int i = 0; i < lCount; i++)
                            {
                                lItem = mItemRWList[i];

                                if (mDisconnect) { break; }

                                #region Write

                                    if (lItem.mNeedWrite)
                                    {
                                        write(lItem);
                                    }

                                #endregion

                                if (mDisconnect) { break; }

                                #region Read

                                    if (lItem.mNeedWrite != true)
                                    {
                                        read(lItem);
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
                        }
                    }
                    catch (Exception lExc)
                    {
                        mDisconnect = true;
                        raiseConnectionError(lExc.Message);
                    }
            }

            resetGroupCache();

            mMainCycleTimeMS = MiscUtils.TimerMS - lStartMS;

            if (mDisconnect)
            {
                int lResult = mClient.Disconnect();

                if (lResult != 0)
                {
                    Log.Error("S7IsoTCP disconnection error. " + mClient.ErrorText(lResult));
                }

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

        private ManualResetEvent        mCycleEndEvent          = new ManualResetEvent(true);

        public void                     waitCycleEnd()
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

        public void                     reportError(string aError)
        {
            if (mConnected && mErrorsBeforeDisconnect != 0)
            {
                mErrorsCounter = mErrorsCounter + 1;

                if (mErrorsCounter >= mErrorsBeforeDisconnect)
                {
                    mErrorsCounter = 0;
                    mDisconnect = true;
                }
            }
            else
            {
                mErrorsCounter = 0;
            }

            raiseConnectionError(aError);
        }

        public void                     connect()
        {
            mClient.SetConnectionType((ushort)mConnectionType);
            int lResult = mClient.ConnectTo(mIP, mRack, mSlot);
            if (lResult != 0)
            {
                throw new InvalidOperationException("Unable to connect. " + mClient.ErrorText(lResult));
            }

            mPDULength  = mClient.NegotiatedPduLength() - 18; // 18 byte payload of S7 telegramm

            mOptimize       = true;
            mConnected      = true;
            mDisconnect     = false;
            mWriteRequests  = 0;

            if (mMainCycleTimer == null)
            {
                mMainCycleTimer             = new System.Timers.Timer(MiscUtils.TimeSlice);
                mMainCycleTimer.Elapsed     += new ElapsedEventHandler(MainCycle);
                mMainCycleTimer.AutoReset   = false;
            }
            mMainCycleTimer.Start();

            raiseConnectionState();
        }

        public void                     disconnect()
        {
            mDisconnectEvent.Reset();
            mDisconnect = true;
            if (mConnected)
            {
                mDisconnectEvent.WaitOne();
            }
        }
        private ManualResetEvent        mDisconnectEvent        = new ManualResetEvent(true);

        private volatile bool           mConnected              = false;
        public bool                     Connected
        {
            get
            {
                return mConnected;
            }
        }

        public event EventHandler       ConnectionState;
        private void                    raiseConnectionState()
        {
            EventHandler lEvent = ConnectionState;
            if (lEvent != null) lEvent(this, EventArgs.Empty);
        }

        private string                  mLastError              = "";
        public string                   LastError
        {
            get
            {
                return mLastError;
            }
        }
        public event EventHandler<MessageStringEventArgs> ConnectionError;
        private void                    raiseConnectionError(string aMessage)
        {
            mLastError = aMessage;
            var lEvent = ConnectionError;
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
                    int lResult;

                    mItemListLock.EnterReadLock();
                    //========================================
                    try
                    {
                        lResult = mItemList.Count;
                    }
                    finally
                    {
                        //========================================
                        mItemListLock.ExitReadLock();
                    }

                    return lResult;
                }
            }

        #endregion

        #region IDisposable

        private bool                mDisposed           = false;

            public void                 Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void      Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        mItemList.Clear();
                        mItemRWList.Clear();

                        if (mMainCycleTimer != null)
                        {
                            mMainCycleTimer.Dispose();
                            mMainCycleTimer = null;
                        }

                        if (mItemListLock != null)
                        {
                            mItemListLock.Dispose();
                            mItemListLock = null;
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
