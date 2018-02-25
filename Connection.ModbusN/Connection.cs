// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using NModbus;
using NModbus.Serial;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using Utils;
using Utils.Segmentation;

namespace Connection.ModbusN
{
    public class Connection : IConnection, IDisposable
    {
        private IModbusMaster               mMaster;
        private uint                        mTimeoutMS              = 250;
        public uint                         TimeoutMS
        {
            get { return mTimeoutMS; }
            set
            {
                mTimeoutMS = value;
                if (mMaster != null)
                {
                    mMaster.Transport.ReadTimeout   = (int)mTimeoutMS;
                    mMaster.Transport.WriteTimeout  = (int)mTimeoutMS;
                }
            }
        }
        public ETransportType               mTransport              = ETransportType.TCP;
        private string                      mIP                     = "127.0.0.1";
        public string                       IP
        {
            get { return mIP; }
            set
            {
                mIP = CommunicationUtils.checkTCP_IP(value);
            }
        }
        private int                         mIPPort                 = 502;
        public int                          IPPort
        {
            get { return mIPPort; }
            set
            {
                CommunicationUtils.checkTCP_Port(value);
                mIPPort = value;
            }
        }
        private string                      mCOMPort                = "COM1";
        public string                       COMPort
        {
            get { return mCOMPort; }
            set
            {
                CommunicationUtils.checkSerial_Port(value);
                mCOMPort = value;
            }
        }
        private int                         mBaud                   = 9600;
        public int                          Baud
        {
            get {return mBaud; }
            set
            {
                if (value < 1) throw new ArgumentException("Invalid baudrate parameter value. ");
                mBaud = value;
            }
        }
        private int                         mDataBits               = 8;
        public int                          DataBits
        {
            get { return mDataBits; }
            set
            {
                if (value < 5 || value > 8) throw new ArgumentException("Invalid databits parameter value. ");
                mDataBits = value;
            }
        }
        public Parity                       mParity                 = Parity.None;
        public StopBits                     mStopBits               = StopBits.One;
        public EProtocol                    mProtocol               = EProtocol.RTU;

        private System.Timers.Timer         mMainCycleTimer;
        public long                         mMainCycleTimeMS;
        private volatile bool               mDisconnect             = false;

        public uint                         mErrorsBeforeDisconnect = 3;
        private uint                        mErrorsCounter          = 0;

        private uint                        mPauseMS                = 0;
        private uint                        mSleepCounts            = 0;
        private uint                        mSleepAddMS             = 0;
        private uint                        mAddMS                  = 0;
        public uint                         PauseMS
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
        private void                        pause()
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

        #region Read/Write optimisation

            private uint                    mFrame                  = 1;
            public uint                     Frame
            {
                get { return mFrame; }
                set
                {
                    if (value < 1)      value = 1;
                    if (value > 125)    value = 125;

                    mFrame              = value;
                    mItemListChanged    = true;
                }
            }

            private bool                    mOptimize               = false;
            private void                    optimize()
            {
                var lRegSegments = new SegmentBuilder(mFrame, false);
                var lBitSegments = new SegmentBuilder((uint)mFrame * 16, true);

                string lSegName;

                int lCount = mItemList.Count;
                for (int i = 0; i < lCount; i++)
                {
                    lSegName = mItemList[i].SlaveID.ToString();
                    switch (mItemList[i].RegisterType)
                    {
                        case ERegisterType.HOLDING_REGISTER:    lSegName = lSegName + "HR"; break;
                        case ERegisterType.INPUT_REGISTER:      lSegName = lSegName + "IR"; break;
                        case ERegisterType.COIL_BIT:            lSegName = lSegName + "C"; break;
                        case ERegisterType.INPUT_BIT:           lSegName = lSegName + "I"; break;
                    }
                
                    if (mItemList[i].RegisterType == ERegisterType.HOLDING_REGISTER || mItemList[i].RegisterType == ERegisterType.INPUT_REGISTER)
                    {
                        lRegSegments.addItem(lSegName, mItemList[i]);
                    }
                    else
                    {
                        lBitSegments.addItem(lSegName, mItemList[i]);
                    }
                }

                var lSeg        = lRegSegments.getSegments();
                mSegRegActual   = new bool[lSeg.Item1.Length];
                mSegRegStart    = lSeg.Item1;
                mSegRegBuffer   = new ushort[lSeg.Item1.Length][];

                for (int i = 0; i < lSeg.Item1.Length; i++)
                {
                    mSegRegBuffer[i] = new ushort[lSeg.Item2[i]];
                }

                lSeg            = lBitSegments.getSegments();
                mSegBitActual   = new bool[lSeg.Item1.Length];
                mSegBitStart    = lSeg.Item1;
                mSegBitBuffer   = new bool[lSeg.Item1.Length][];

                for (int i = 0; i < lSeg.Item1.Length; i++)
                {
                    mSegBitBuffer[i] = new bool[lSeg.Item2[i]];
                }
            }

            private bool[]                  mSegRegActual;
            private int[]                   mSegRegStart;
            private ushort[][]              mSegRegBuffer;

            private bool[]                  mSegBitActual;
            private int[]                   mSegBitStart;
            private bool[][]                mSegBitBuffer;

            private void                    resetSegActual()
            {
                if (mSegRegActual != null)
                {
                    for (int i = 0; i < mSegRegActual.Length; i++)
                    {
                        mSegRegActual[i] = false;
                    }
                }

                if (mSegBitActual != null)
                {
                    for (int i = 0; i < mSegBitActual.Length; i++)
                    {
                        mSegBitActual[i] = false;
                    }
                }
            }

            private bool                    readRegSegment(byte aSlaveID, ERegisterType aRegisterType, ushort aRegister, ref ushort[] aValue)
            {
                int lFrame  = (int)mFrame;
                int lDiv    = aValue.Length / lFrame;
                int lStart  = 0;
                ushort[] lArray;

                for (int i = 0; i < lDiv; i++)
                {
                    try
                    {
                        if (aRegisterType == ERegisterType.HOLDING_REGISTER)
                        {
                            lArray = mMaster.ReadHoldingRegisters(aSlaveID, (ushort)(aRegister + lStart), (ushort)mFrame);
                        }
                        else
                        {
                            lArray = mMaster.ReadInputRegisters(aSlaveID, (ushort)(aRegister + lStart), (ushort)mFrame);
                        }
                    }
                    catch (Exception lExc)
                    {
                        reportError("Error reading data for one or group of Items: " + lExc.Message);
                        return false;
                    }

                    Array.Copy(lArray, 0, aValue, lStart, mFrame);

                    lStart = lStart + lFrame;
                }

                int lLastPart = aValue.Length - lStart;
                if (lLastPart > 0)
                {
                    try
                    {
                        if (aRegisterType == ERegisterType.HOLDING_REGISTER)
                        {
                            lArray = mMaster.ReadHoldingRegisters(aSlaveID, (ushort)(aRegister + lStart), (ushort)lLastPart);
                        }
                        else
                        {
                            lArray = mMaster.ReadInputRegisters(aSlaveID, (ushort)(aRegister + lStart), (ushort)lLastPart);
                        }
                    }
                    catch (Exception lExc)
                    {
                        reportError("Error reading data for one or group of Items: " + lExc.Message);
                        return false;
                    }

                    Array.Copy(lArray, 0, aValue, lStart, lLastPart);
                }

                return true;
            }
            private bool                    readBitSegment(byte aSlaveID, ERegisterType aRegisterType, ushort aRegister, ref bool[] aValue)
            {
                int lFrame      = (int)mFrame * 16;
                int lDiv        = aValue.Length / lFrame;
                int lStart      = 0;
                bool[] lArray;

                for (int i = 0; i < lDiv; i++)
                {
                    try
                    {
                        if (aRegisterType == ERegisterType.COIL_BIT)
                        {
                            lArray = mMaster.ReadCoils(aSlaveID, (ushort)(aRegister + lStart), (ushort)lFrame);
                        }
                        else
                        {
                            lArray = mMaster.ReadInputs(aSlaveID, (ushort)(aRegister + lStart), (ushort)lFrame);
                        }
                    }
                    catch (Exception lExc)
                    {
                        reportError("Error reading data for one or group of Items: " + lExc.Message);
                        return false;
                    }

                    Array.Copy(lArray, 0, aValue, lStart, lFrame);

                    lStart = lStart + lFrame;
                }

                int lLastPart = aValue.Length - lStart;
                if (lLastPart > 0)
                {
                    try
                    {
                        if (aRegisterType == ERegisterType.COIL_BIT)
                        {
                            lArray = mMaster.ReadCoils(aSlaveID, (ushort)(aRegister + lStart), (ushort)lLastPart);
                        }
                        else
                        {
                            lArray = mMaster.ReadInputs(aSlaveID, (ushort)(aRegister + lStart), (ushort)lLastPart);
                        }
                    }
                    catch (Exception lExc)
                    {
                        reportError("Error reading data for one or group of Items: " + lExc.Message);
                        return false;
                    }

                    Array.Copy(lArray, 0, aValue, lStart, lLastPart);
                }

                return true;
            }

            private void                    read(DataItem aItem)
            {
                if (aItem.SegID < 0)
                {
                    pause();
                    if (aItem.mNeedWrite) return;

                    if (aItem.RegisterType == ERegisterType.HOLDING_REGISTER || aItem.RegisterType == ERegisterType.INPUT_REGISTER)
                    {
                        var lValue = new ushort[aItem.SegLength];
                        if (readRegSegment(aItem.SlaveID, aItem.RegisterType, aItem.Register, ref lValue))
                        {
                            aItem.setRawValue(lValue);
                        }
                    }
                    else
                    {
                        var lValue = new bool[aItem.SegLength];
                        if (readBitSegment(aItem.SlaveID, aItem.RegisterType, aItem.Register, ref lValue))
                        {
                            if (aItem.Length > 1)
                            {
                                aItem.setValue(lValue);
                            }
                            else
                            {
                                aItem.setValue(lValue[0]);
                            }
                        }
                    }                
                }
                else
                {
                    if (aItem.RegisterType == ERegisterType.HOLDING_REGISTER || aItem.RegisterType == ERegisterType.INPUT_REGISTER)
                    {
                        if (mSegRegActual[aItem.SegID] == false)
                        {
                            pause();
                            if (aItem.mNeedWrite) return;

                            mSegRegActual[aItem.SegID] = readRegSegment(aItem.SlaveID, aItem.RegisterType, (ushort)mSegRegStart[aItem.SegID], ref mSegRegBuffer[aItem.SegID]);
                        }

                        if (mSegRegActual[aItem.SegID])
                        {
                            var lValue = new ushort[aItem.SegLength];
                            Array.Copy(mSegRegBuffer[aItem.SegID], aItem.SegAddress - mSegRegStart[aItem.SegID], lValue, 0, lValue.Length);
                            aItem.setRawValue(lValue);
                        }
                    }
                    else
                    {
                        if (mSegBitActual[aItem.SegID] == false)
                        {
                            pause();
                            if (aItem.mNeedWrite) return;

                            mSegBitActual[aItem.SegID] = readBitSegment(aItem.SlaveID, aItem.RegisterType, (ushort)mSegBitStart[aItem.SegID], ref mSegBitBuffer[aItem.SegID]);
                        }

                        if (mSegBitActual[aItem.SegID])
                        {
                            if (aItem.Length > 1)
                            {
                                var lValue = new bool[aItem.Length];
                                Array.Copy(mSegBitBuffer[aItem.SegID], aItem.SegAddress - mSegRegStart[aItem.SegID], lValue, 0, lValue.Length);
                                aItem.setValue(lValue);
                            }
                            else
                            {
                                aItem.setValue(mSegBitBuffer[aItem.SegID][aItem.SegAddress - mSegBitStart[aItem.SegID]]);
                            }
                        }
                    }
                }
            }
            private void                    write(DataItem aItem)
            {
                pause();
                aItem.mNeedWrite  = false;
                mWriteRequests = mWriteRequests + 1;         
                
                if (aItem.RegisterType == ERegisterType.HOLDING_REGISTER)
                {
                    ushort[] lArray = new ushort[0];

                    if (aItem.Length == 1)
                    {
                        lArray = new ushort[aItem.SegLength];

                        if (aItem.DataType == typeof(Int16))
                        {
                            lArray[0] = unchecked((ushort)((short)aItem.mValue));
                        }
                        else if (aItem.DataType == typeof(UInt16))
                        {
                            lArray[0] = (ushort)aItem.mValue;
                        }
                        else if (aItem.DataType == typeof(Int32))
                        {
                            unsafe
                            {
                                int lValue = (int)aItem.mValue;
                                ushort* pValue = (ushort*)&lValue;
                                if (aItem.mSwapWords)
                                {
                                    lArray[0] = pValue[1];
                                    lArray[1] = pValue[0];
                                }
                                else
                                {
                                    lArray[0] = pValue[0];
                                    lArray[1] = pValue[1];
                                }
                            }
                        }
                        else if (aItem.DataType == typeof(UInt32))
                        {
                            unsafe
                            {
                                uint lValue = (uint)aItem.mValue;
                                ushort* pValue = (ushort*)&lValue;
                                if (aItem.mSwapWords)
                                {
                                    lArray[0] = pValue[1];
                                    lArray[1] = pValue[0];
                                }
                                else
                                {
                                    lArray[0] = pValue[0];
                                    lArray[1] = pValue[1];
                                }
                            }
                        }
                        else if (aItem.DataType == typeof(Single))
                        {
                            unsafe
                            {
                                float lValue = (float)aItem.mValue;
                                ushort* pValue = (ushort*)&lValue;
                                if (aItem.mSwapWords)
                                {
                                    lArray[0] = pValue[1];
                                    lArray[1] = pValue[0];
                                }
                                else
                                {
                                    lArray[0] = pValue[0];
                                    lArray[1] = pValue[1];
                                }
                            }
                        }
                    }
                    else
                    {
                        if (aItem.DataType == typeof(Int16))
                        {      
                            lArray      = new ushort[aItem.SegLength];
                            var lValue  = (short[])aItem.mValue;
                            for (int i = 0; i < aItem.Length; i++)
                            {
                                lArray[i] = unchecked((ushort)lValue[i]);
                            }
                        }
                        else if (aItem.DataType == typeof(UInt16))
                        {
                            lArray = (ushort[])aItem.mValue;
                        }
                        else
                        {
                            lArray      = new ushort[aItem.SegLength];                       
                            var lTemp   = new ushort[2];
                            int lIndex  = 0;

                            if (aItem.DataType == typeof(Int32))
                            {
                                var lmValue  = (int[])aItem.mValue;
                                for (int i = 0; i < aItem.Length; i++)
                                {
                                    unsafe
                                    {
                                        int lValue = lmValue[i];
                                        ushort* pValue = (ushort*)&lValue;
                                        if (aItem.mSwapWords)
                                        {
                                            lArray[lIndex]      = pValue[1];
                                            lArray[lIndex + 1]  = pValue[0];
                                        }
                                        else
                                        {
                                            lArray[lIndex]      = pValue[0];
                                            lArray[lIndex + 1]  = pValue[1];
                                        }
                                    }
                                    lIndex = lIndex + 2;
                                }
                            }
                            else if (aItem.DataType == typeof(UInt32))
                            {
                                var lmValue  = (uint[])aItem.mValue;
                                for (int i = 0; i < aItem.Length; i++)
                                {
                                    unsafe
                                    {
                                        uint lValue = lmValue[i];
                                        ushort* pValue = (ushort*)&lValue;
                                        if (aItem.mSwapWords)
                                        {
                                            lArray[lIndex]      = pValue[1];
                                            lArray[lIndex + 1]  = pValue[0];
                                        }
                                        else
                                        {
                                            lArray[lIndex]      = pValue[0];
                                            lArray[lIndex + 1]  = pValue[1];
                                        }
                                    }
                                    lIndex = lIndex + 2;
                                }
                            }
                            else if (aItem.DataType == typeof(Single))
                            {
                                var lmValue  = (float[])aItem.mValue;
                                for (int i = 0; i < aItem.Length; i++)
                                {
                                    unsafe
                                    {
                                        float lValue = lmValue[i];
                                        ushort* pValue = (ushort*)&lValue;
                                        if (aItem.mSwapWords)
                                        {
                                            lArray[lIndex]      = pValue[1];
                                            lArray[lIndex + 1]  = pValue[0];
                                        }
                                        else
                                        {
                                            lArray[lIndex]      = pValue[0];
                                            lArray[lIndex + 1]  = pValue[1];
                                        }
                                    }
                                    lIndex = lIndex + 2;
                                }
                            }
                        }
                    }

                    try
                    {
                        if (lArray.Length == 1)
                        {
                            mMaster.WriteSingleRegister(aItem.SlaveID, aItem.Register, lArray[0]);
                        }
                        else
                        {
                            if (lArray.Length <= mFrame)
                            {
                                mMaster.WriteMultipleRegisters(aItem.SlaveID, aItem.Register, lArray);
                            }
                            else
                            {
                                int lDiv    = lArray.Length / (int)mFrame;
                                int lStart  = 0;
                                var lFrame  = new ushort[mFrame];
                                for(int i = 0; i < lDiv; i++)
                                {
                                    Array.Copy(lArray, lStart, lFrame, 0, lFrame.Length);
                                    mMaster.WriteMultipleRegisters(aItem.SlaveID, (ushort)(aItem.Register + lStart), lFrame);
                                    lStart = lStart + lFrame.Length;
                                }

                                int lLastPart = lArray.Length - lStart;
                                if (lLastPart > 0)
                                {
                                    lFrame  = new ushort[lLastPart];
                                    Array.Copy(lArray, lStart, lFrame, 0, lLastPart);
                                    mMaster.WriteMultipleRegisters(aItem.SlaveID, (ushort)(aItem.Register + lStart), lFrame);
                                }
                            }
                        }
                    }
                    catch(Exception lExc)
                    {
                        reportError(aItem.Description + " " + lExc.Message);
                        return;
                    }
                }
                else if (aItem.RegisterType == ERegisterType.COIL_BIT)
                {
                    try
                    {
                        if (aItem.Length > 1)
                        {
                            var lFrameSize = mFrame * 16;
                            if (aItem.Length <= lFrameSize)
                            {
                                mMaster.WriteMultipleCoils(aItem.SlaveID, aItem.Register, (bool[])aItem.mValue);
                            }
                            else
                            {
                                var lmValue = (bool[])aItem.mValue;
                                int lDiv    = (int)(aItem.Length / lFrameSize);
                                int lStart  = 0;
                                var lFrame  = new bool[lFrameSize];
                                for(int i = 0; i < lDiv; i++)
                                {
                                    Array.Copy(lmValue, lStart, lFrame, 0, lFrame.Length);
                                    mMaster.WriteMultipleCoils(aItem.SlaveID, (ushort)(aItem.Register + lStart), lFrame);
                                    lStart = lStart + lFrame.Length;
                                }

                                int lLastPart = lmValue.Length - lStart;
                                if (lLastPart > 0)
                                {
                                    lFrame  = new bool[lLastPart];
                                    Array.Copy(lmValue, lStart, lFrame, 0, lLastPart);
                                    mMaster.WriteMultipleCoils(aItem.SlaveID, (ushort)(aItem.Register + lStart), lFrame);
                                }
                            }
                        }
                        else
                        {
                            mMaster.WriteSingleCoil(aItem.SlaveID, aItem.Register, (bool)aItem.mValue);
                        }
                    }
                    catch(Exception lExc)
                    {
                        reportError(aItem.Description + " " + lExc.Message);
                        return;
                    }
                }        
            }

        #endregion

        public long                         mWriteRequests;

        private void                        MainCycle(object aSender, ElapsedEventArgs aEventArgs)
        {
            long lStartMS = MiscUtils.TimerMS;

            if (mDisconnect == false)
            {  
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
                                    mItemListChanged = false;
                                }
                                finally
                                {
                                    //========================================
                                    mItemListLock.ExitReadLock();
                                }

                                foreach (DataItem lDataItem in mItemRWList)
                                {
                                    lDataItem.SegID = -1;
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

                        resetSegActual();

                        for (int i = 0; i < lCount; i++)
                        {
                            lItem = mItemRWList[i];

                            if (mDisconnect) { break; }

                            #region Write/Read

                                if (lItem.mNeedWrite)
                                {
                                    write(lItem);
                                }
                                else
                                {
                                    read(lItem);
                                }

                            #endregion

                            if (mDisconnect) { break; }
                        }
                    }
                    catch (Exception lExc)
                    {
                        mDisconnect = true;
                        raiseConnectionError(lExc.Message);
                    }
                }
            }

            mMainCycleTimeMS = MiscUtils.TimerMS - lStartMS;

            if (mDisconnect)
            {
                mMaster.Dispose();
                mMaster = null;

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

        private ManualResetEvent            mCycleEndEvent          = new ManualResetEvent(true);

        public void                         waitCycleEnd()
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

        public void                         reportError(string aError)
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

        public void                         connect()
        {
            if (mMaster != null)
            {
                mMaster.Dispose();
                mMaster = null;
            }
            
            if (mTransport == ETransportType.TCP)
            {
                mMaster = new ModbusFactory().CreateMaster(new TcpClient(mIP, mIPPort));
            }
            else
            {
                var lPort       = new SerialPort(mCOMPort);
                lPort.BaudRate  = mBaud;
                lPort.DataBits  = mDataBits;
                lPort.Parity    = mParity;
                lPort.StopBits  = mStopBits;
                lPort.Open();

                if (mProtocol == EProtocol.RTU)
                {
                    mMaster =  new ModbusFactory().CreateRtuMaster(new SerialPortAdapter(lPort));
                }
                else
                {
                    mMaster =  new ModbusFactory().CreateAsciiMaster(new SerialPortAdapter(lPort));
                }
            }

            mMaster.Transport.ReadTimeout   = (int)mTimeoutMS;
            mMaster.Transport.WriteTimeout  = (int)mTimeoutMS;
            mMaster.Transport.Retries       = 0;

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

            raiseConnectionState();
        }

        public void                         disconnect()
        {
            mDisconnectEvent.Reset();
            mDisconnect = true;
            if (mConnected)
            {
                mDisconnectEvent.WaitOne();
            }
        }
        private ManualResetEvent            mDisconnectEvent        = new ManualResetEvent(true);

        private volatile bool               mConnected              = false;
        public bool                         Connected
        {
            get
            {
                return mConnected;
            }
        }

        public event EventHandler           ConnectionState;
        private void                        raiseConnectionState()
        {
            ConnectionState?.Invoke(this, EventArgs.Empty);
        }

        private string                      mLastError              = "";
        public string                       LastError
        {
            get
            {
                return mLastError;
            }
        }
        public event EventHandler<MessageStringEventArgs> ConnectionError;
        private void                        raiseConnectionError(string aMessage)
        {
            mLastError = aMessage;
            ConnectionError?.Invoke(this, new MessageStringEventArgs(aMessage));
        }

        #region Items

            private List<DataItem>          mItemList               = new List<DataItem>();
            private List<DataItem>          mItemRWList             = new List<DataItem>();
            private ReaderWriterLockSlim    mItemListLock           = new ReaderWriterLockSlim();
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

            private bool                    mDisposed = false;

            public void                     Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void          Dispose(bool aDisposing)
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

                        if (mMaster != null)
                        {
                            mMaster.Dispose();
                            mMaster = null;
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
