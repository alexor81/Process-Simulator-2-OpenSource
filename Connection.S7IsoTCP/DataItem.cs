// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using Snap7;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Utils;
using Utils.Segmentation;

namespace Connection.S7IsoTCP
{
    public class DataItem : IDataItem, ISegmentItem
    {
        public Connection           mConnection;
        public EArea                mMemoryType     = EArea.M;
        private int                 mDB             = 1;
        public int                  DB
        {
            get { return mDB; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Invalid DB number. ");
                }

                mDB = value;
            }
        }
        private EWordlen            mDataType       = EWordlen.S7_Bit;
        public EWordlen             DataType
        {
            get { return mDataType; }
            set
            {
                mDataType   = value;
                mValue      = InitValue;
                setParams();
            }
        }
        private int                 mByte           = 0;
        public int                  Byte
        {
            get { return mByte; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid byte number. ");
                }

                mByte = value;
                setParams();
            }
        }
        private int                 mBit            = 0;
        public int                  Bit
        {
            get { return mBit; }
            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentException("Invalid bit number. ");
                }

                mBit = value;
                setParams();
            }
        }
        private bool                mSigned         = false;
        public bool                 Signed
        {
            get { return mSigned; }
            set
            {
                mSigned = value;
                mValue  = InitValue;
            }
        }
        private bool                mFloatingP      = false;
        public bool                 FloatingP
        {
            get { return mFloatingP; }
            set
            {
                mFloatingP  = value;
                mValue      = InitValue;
            }
        }
        private int                 mLength         = 1;
        public int                  Length
        {
            get { return mLength; }
            set
            {
                if (value < 1 || value > 16348)
                {
                    throw new ArgumentException("Invalid Length. ");
                }

                if (value > 1 && mDataType == EWordlen.S7_Bit)
                {
                    throw new ArgumentException("Arrays of bits are not supported. ");
                }

                mLength = value;
                mValue  = InitValue;
                setParams();
            }
        }
        private void                setParams()
        {
            switch (mDataType)
            {
                case EWordlen.S7_Bit:           mBufferLength = 1;              mStart = mByte * 8 + mBit;  break;
                case EWordlen.S7_Byte:          mBufferLength = 1 * mLength;    mStart = mByte;             break;
                case EWordlen.S7_Word:          mBufferLength = 2 * mLength;    mStart = mByte;             break;
                case EWordlen.S7_DoubleWord:    mBufferLength = 4 * mLength;    mStart = mByte;             break;
            }
        }
        private int                 mBufferLength   = 1;
        private int                 mStart          = 0;

        public object               mValue          = false;
        private readonly object     mValueLock      = new object();
        public volatile bool        mNeedWrite      = false;
        public void                 read(S7Client aClient)
        {
            if (mNeedWrite != true)
            {
                byte[] lBuff = new byte[mBufferLength];
                int lResult = aClient.ReadArea((int)mMemoryType, mDB, mStart, mLength, (int)mDataType, lBuff);
                if (lResult == 0)
                {
                    setValueFromPLC(lBuff);
                }
                else
                {
                    mConnection.reportError(Description + " " + aClient.ErrorText(lResult));
                }
            }
        }
        public void                 write(S7Client aClient)
        {
            mNeedWrite = false;

            int lResult = aClient.WriteArea((int)mMemoryType, mDB, mStart, mLength, (int)mDataType, getValueForPLC());
            if (lResult != 0)
            {
                mConnection.reportError(Description + " " + aClient.ErrorText(lResult));
            }
        }
        private static byte[]       getBytes(object aValue)
        {
            if (aValue is Boolean)
            {
                if ((bool)aValue)
                {
                    return new byte[1] { 1 };
                }
                else
                {
                    return new byte[1] { 0 };
                }
            }
            else if (aValue is Byte)
            {
                return new byte[1] { (byte)aValue };
            }
            else if (aValue is SByte)
            {
                return new byte[1] { unchecked((byte)(sbyte)aValue) };
            }
            else if (aValue is Int16)
            {
                byte[] lResult = BitConverter.GetBytes((short)aValue);
                Array.Reverse(lResult);
                return lResult;
            }
            else if (aValue is UInt16)
            {
                byte[] lResult = BitConverter.GetBytes((ushort)aValue);
                Array.Reverse(lResult);
                return lResult;
            }
            else if (aValue is Int32)
            {
                byte[] lResult = BitConverter.GetBytes((int)aValue);
                Array.Reverse(lResult);
                return lResult;
            }
            else if (aValue is UInt32)
            {
                byte[] lResult = BitConverter.GetBytes((uint)aValue);
                Array.Reverse(lResult);
                return lResult;
            }
            else if (aValue is Single)
            {
                byte[] lResult = BitConverter.GetBytes((float)aValue);
                Array.Reverse(lResult);
                return lResult;
            }

            throw new ArgumentException("Wrong type. ");
        }
        public byte[]               getValueForPLC()
        {
            Array lArray = mValue as Array;

            if (lArray == null)
            {
                return getBytes(mValue);
            }
            else
            {
                List<byte> lResult = new List<byte>(mBufferLength);
                for (int i = 0; i < mLength; i++)
                {
                    lResult.AddRange(getBytes(lArray.GetValue(i)));
                }

                return lResult.ToArray();
            }
        }
        public void                 setValueFromPLC(byte[] aBytes)
        {
            if (mNeedWrite) return;

            bool lValueChanged  = false;
            object lNewValue    = aBytes;

            if (mLength == 1)
            {
                if (mDataType == EWordlen.S7_Bit)
                {
                    lNewValue = (aBytes[0] > 0);
                }
                else if (mDataType == EWordlen.S7_Byte)
                {
                    if(mSigned)
                    {
                        lNewValue = unchecked((sbyte)aBytes[0]);
                    }
                    else
                    {
                        lNewValue = aBytes[0];
                    }
                }
                else if (mDataType == EWordlen.S7_Word)
                {
                    Array.Reverse(aBytes);

                    if (mSigned)
                    {
                        lNewValue = BitConverter.ToInt16(aBytes, 0);
                    }
                    else
                    {
                        lNewValue = BitConverter.ToUInt16(aBytes, 0);
                    }
                }
                else if (mDataType == EWordlen.S7_DoubleWord)
                {
                    Array.Reverse(aBytes);
                    if (mFloatingP)
                    {
                        lNewValue = BitConverter.ToSingle(aBytes, 0);
                    }
                    else
                    {
                        if (mSigned)
                        {
                            lNewValue = BitConverter.ToInt32(aBytes, 0);
                        }
                        else
                        {
                            lNewValue = BitConverter.ToUInt32(aBytes, 0);
                        }
                    }
                }
            }
            else
            {
                if (mDataType == EWordlen.S7_Byte)
                {
                    if (mSigned)
                    {
                        sbyte[] lArray = new sbyte[mLength];
                        for (int i = 0; i < mLength; i++)
                        {
                            lArray[i] = unchecked((sbyte)aBytes[i]);
                        }
                        lNewValue = lArray;
                    }
                    else
                    {
                        lNewValue = aBytes;
                    }
                }
                else if (mDataType == EWordlen.S7_Word)
                {
                    byte[] lValue   = new byte[2];
                    int lIndex      = 0;

                    if (mSigned)
                    {
                        short[] lArray = new short[mLength];
                        
                        for (int i = 0; i < mLength; i++)
                        {
                            Array.Copy(aBytes, lIndex, lValue, 0, 2);
                            Array.Reverse(lValue);
                            lArray[i] = BitConverter.ToInt16(lValue, 0);
                            lIndex = lIndex + 2;
                        }

                        lNewValue = lArray;
                    }
                    else
                    {
                        ushort[] lArray = new ushort[mLength];

                        for (int i = 0; i < mLength; i++)
                        {
                            Array.Copy(aBytes, lIndex, lValue, 0, 2);
                            Array.Reverse(lValue);
                            lArray[i] = BitConverter.ToUInt16(lValue, 0);
                            lIndex = lIndex + 2;
                        }

                        lNewValue = lArray;
                    }
                }
                else if (mDataType == EWordlen.S7_DoubleWord)
                {
                    byte[] lValue   = new byte[4];
                    int lIndex      = 0;

                    if (mFloatingP)
                    {
                        float[] lArray = new float[mLength];

                        for (int i = 0; i < mLength; i++)
                        {
                            Array.Copy(aBytes, lIndex, lValue, 0, 4);
                            Array.Reverse(lValue);
                            lArray[i] = BitConverter.ToSingle(lValue, 0);
                            lIndex = lIndex + 4;
                        }

                        lNewValue = lArray;
                    }
                    else
                    {
                        if (mSigned)
                        {
                            int[] lArray = new int[mLength];

                            for (int i = 0; i < mLength; i++)
                            {
                                Array.Copy(aBytes, lIndex, lValue, 0, 4);
                                Array.Reverse(lValue);
                                lArray[i] = BitConverter.ToInt32(lValue, 0);
                                lIndex = lIndex + 4;
                            }

                            lNewValue = lArray;
                        }
                        else
                        {
                            uint[] lArray = new uint[mLength];

                            for (int i = 0; i < mLength; i++)
                            {
                                Array.Copy(aBytes, lIndex, lValue, 0, 4);
                                Array.Reverse(lValue);
                                lArray[i] = BitConverter.ToUInt32(lValue, 0);
                                lIndex = lIndex + 4;
                            }

                            lNewValue = lArray;
                        }
                    }
                }
            }

            Monitor.Enter(mValueLock);
            //=========================================
            try
            {
                if (mNeedWrite) return;

                if (ValuesCompare.isNotEqual(mValue, lNewValue))
                {
                    mValue          = lNewValue;
                    lValueChanged   = true;
                }
            }
            finally
            {
                //=========================================
                Monitor.Exit(mValueLock);
            }

            if (lValueChanged)
            {
                raiseValueChanged();
            } 
        }
              
        public object               Value
        {
            get
            {
                if (mAccess.HasFlag(EAccess.READ) == false)
                {
                    throw new InvalidOperationException("No access. ");
                }

                return mValue;
            }
            set
            {
                if (mAccess.HasFlag(EAccess.WRITE) == false)
                {
                    throw new InvalidOperationException("No access. ");
                }

                object lNewValue;
                Array lArray = value as Array;
                if (mLength == 1)
                {
                    if (lArray != null)
                    {
                        throw new InvalidOperationException("Array is not expected. ");
                    }

                    lNewValue = Converters.convertValue(mValue.GetType(), value);
                }
                else
                {
                    if (lArray == null)
                    {
                        throw new InvalidOperationException("Array is expected. ");
                    }

                    if (lArray.Length != mLength)
                    {
                        throw new InvalidOperationException("Array with length " + 
                                                                StringUtils.ObjectToString(mLength) + " is expected. ");
                    }

                    lNewValue = Converters.convertValue(mValue.GetType().GetElementType(), value);
                }

                bool lUpdate = false;
                Monitor.Enter(mValueLock);
                //=========================================
                try
                {
                    if (ValuesCompare.isNotEqual(mValue, lNewValue))
                    {
                        mValue      = lNewValue;
                        mNeedWrite  = true;
                        lUpdate     = true;
                    }
                }
                finally
                {
                    //=========================================
                    Monitor.Exit(mValueLock);
                }

                if (lUpdate)
                {
                    raiseValueChanged();
                }
            }
        }
        public event EventHandler   ValueChanged;
        public void                 raiseValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public object               InitValue
        {
            get
            {
                Type lType = null;

                switch (mDataType)
                {
                    case EWordlen.S7_Bit:           return new Boolean();

                    case EWordlen.S7_Byte:          if (mSigned) { lType = typeof(SByte); }
                                                    else { lType = typeof(Byte); }
                                                    break;

                    case EWordlen.S7_Word:          if (mSigned) { lType = typeof(Int16); }
                                                    else { lType = typeof(UInt16); }
                                                    break;

                    case EWordlen.S7_DoubleWord:    if (mFloatingP) { lType = typeof(Single); }
                                                    else
                                                    { 
                                                        if (mSigned) { lType = typeof(Int32); }
                                                        else { lType = typeof(UInt32); }
                                                    }
                                                    break;
                }

                if (lType == null)
                {
                    throw new ArgumentException("DataType is wrong. ");
                }

                return StringUtils.getInitValue(lType, (mLength > 1), mLength);
            }
        }

        public volatile EAccess     mAccess         = EAccess.NO_ACCESS;
        public void                 initAccess()
        {
            EAccess lAccess = EAccess.NO_ACCESS;

            if (mConnection.Connected)
            {
                lAccess = EAccess.READ_WRITE;
            }

            if (lAccess != mAccess)
            {
                mAccess = lAccess;
                raisePropertiesChanged();
            }
        }
        public EAccess              Access
        {
            get
            {
                return mAccess;
            }
        }

        public void                 onConnectionStateChanged(object aSender, EventArgs aEventArgs)
        {
            initAccess();
        }

        public string               Description
        {
            get
            {
                StringBuilder lResult = new StringBuilder();

                if (mMemoryType == EArea.DB)
                {
                    lResult.Append("DB");
                    lResult.Append(StringUtils.ObjectToString(mDB));
                    lResult.Append(".DB");
                }
                else
                {
                    lResult.Append(mMemoryType.ToString());
                }

                switch (mDataType)
                {
                    case EWordlen.S7_Bit:           if (mMemoryType == EArea.DB)
                                                    {
                                                        lResult.Append("X");
                                                    }
                                                    break;
                    case EWordlen.S7_Byte:          lResult.Append("B"); break;
                    case EWordlen.S7_Word:          lResult.Append("W"); break;
                    case EWordlen.S7_DoubleWord:    lResult.Append("D"); break;
                }

                lResult.Append(mByte);

                if (mDataType == EWordlen.S7_Bit)
                {
                    lResult.Append("." + StringUtils.ObjectToString(mBit) + ", BOOL");
                }
                else if (mDataType == EWordlen.S7_DoubleWord && mFloatingP)
                {
                    lResult.Append(", REAL");
                }
                else
                {
                    if (mSigned)
                    {
                        switch (mDataType) //-V3002
                        {
                            case EWordlen.S7_Byte:          lResult.Append(", SBYTE"); break;
                            case EWordlen.S7_Word:          lResult.Append(", INT"); break;
                            case EWordlen.S7_DoubleWord:    lResult.Append(", DINT"); break;
                        }
                    }
                    else
                    {
                        switch (mDataType) //-V3002
                        {
                            case EWordlen.S7_Byte:          lResult.Append(", BYTE"); break;
                            case EWordlen.S7_Word:          lResult.Append(", WORD"); break;
                            case EWordlen.S7_DoubleWord:    lResult.Append(", DWORD"); break;
                        }
                    }
                }

                if (mLength > 1)
                {
                    lResult.Append(", length " + StringUtils.ObjectToString(mLength));
                }

                return lResult.ToString();
            }
        }

        public event EventHandler   PropertiesChanged;
        public void                 raisePropertiesChanged()
        {
            PropertiesChanged?.Invoke(this, EventArgs.Empty);
        }
    
        #region ISegmentItem

            public int              SegID { get; set; } = -1;

            public int              SegAddress
            {
                get
                {
                    return mByte;
                }
            }

            public int              SegLength
            {
                get
                {
                    return mBufferLength;
                }
            }

        #endregion
        
    }
}
