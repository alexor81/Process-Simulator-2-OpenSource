// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Text;
using System.Threading;
using API;
using S7PROSIMLib;
using Utils;

namespace Connection.S7PLCSim
{
    public class DataItem: IDataItem
    {
        public Connection               mConnection;
        public EPLCMemoryType           mMemoryType     = EPLCMemoryType.M;
        private int                     mDB             = 1;
        public int                      DB
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
        private int                     mByte           = 0;
        public int                      Byte
        {
            get { return mByte; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid byte number. ");
                }

                mByte = value;
            }
        }
        private int                     mBit            = 0;
        public int                      Bit
        {
            get { return mBit; }
            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentException("Invalid bit number. ");
                }

                mBit = value;
            }
        }
        private PointDataTypeConstants  mDataType       = PointDataTypeConstants.S7_Bit;
        public PointDataTypeConstants   DataType
        {
            get { return mDataType; }
            set
            {
                mDataType   = value;
                mValue      = InitValue;
            }
        }
        private ImageDataTypeConstants  ImageDataType
        {
            get
            {
                switch(mDataType)
                {     
                    case PointDataTypeConstants.S7_Word:        return ImageDataTypeConstants.S7Word;
                    case PointDataTypeConstants.S7_DoubleWord:  return ImageDataTypeConstants.S7DoubleWord;
                    default:                                    return ImageDataTypeConstants.S7Byte;
                }
            }
        }
        private bool                    mSigned         = false;
        public bool                     Signed
        {
            get { return mSigned; }
            set
            {
                mSigned = value;
                mValue  = InitValue;
            }
        }
        private bool                    mFloatingP      = false;
        public bool                     FloatingP
        {
            get { return mFloatingP; }
            set
            {
                mFloatingP  = value;
                mValue      = InitValue;
            }
        }
        private int                     mLength         = 1;
        public int                      Length
        {
            get { return mLength; }
            set
            {
                if (value < 1 || value > 16348)
                {
                    throw new ArgumentException("Invalid Length. ");
                }

                if (value > 1 && (mDataType == PointDataTypeConstants.S7_Bit || (mMemoryType != EPLCMemoryType.I && mMemoryType != EPLCMemoryType.Q)))
                {
                    throw new ArgumentException("Invalid Length. ");
                }

                mLength = value;
                mValue  = InitValue;
            }
        }

        public volatile bool            mNeedWrite      = false;
        public void                     read(S7ProSim aS7ProSim)
        {
            if (mMemoryType != EPLCMemoryType.I)
            {
                if (mNeedWrite != true)
                {
                    object lValue = null;
                    switch (mMemoryType) //-V3002
                    {
                        case EPLCMemoryType.DB: aS7ProSim.ReadDataBlockValue(mDB, mByte, mBit, DataType, ref lValue); break;
                        case EPLCMemoryType.M:  aS7ProSim.ReadFlagValue(mByte, mBit, DataType, ref lValue); break;
                        case EPLCMemoryType.Q:  if (mLength == 1)
                                                {
                                                    aS7ProSim.ReadOutputPoint(mByte, mBit, DataType, ref lValue); break;
                                                }
                                                else
                                                {
                                                    aS7ProSim.ReadOutputImage(mByte, mLength, ImageDataType, ref lValue); break;
                                                }
                    }

                    if (lValue != null)
                    {
                        setValueFromPLC(lValue);
                    }
                }
            }
        }
        public void                     write(S7ProSim aS7ProSim)
        {
            mNeedWrite = false;

            if (mMemoryType != EPLCMemoryType.Q)
            {
                object lValue = getValueForPLC();
                switch (mMemoryType) //-V3002
                {
                    case EPLCMemoryType.DB: aS7ProSim.WriteDataBlockValue(mDB, mByte, mBit, ref lValue); break;
                    case EPLCMemoryType.M:  aS7ProSim.WriteFlagValue(mByte, mBit, ref lValue); break;
                    case EPLCMemoryType.I:  if (mLength == 1)
                                            {
                                                aS7ProSim.WriteInputPoint(mByte, mBit, ref lValue); break;
                                            }
                                            else
                                            {
                                                aS7ProSim.WriteInputImage(mByte, ref lValue); break;
                                            }
                }
            }
        }
        private object                  getValueForPLC()
        {
            Array lArray = mValue as Array;

            if (lArray == null)
            {
                if (mValue is SByte)
                {
                    return unchecked((byte)(sbyte)mValue);
                }
                else if (mValue is UInt16)
                {
                    return BitConverter.ToInt16(BitConverter.GetBytes((ushort)mValue), 0);
                }
                else if (mValue is UInt32)
                {
                    return BitConverter.ToInt32(BitConverter.GetBytes((uint)mValue), 0);
                }
                else if (mValue is Single)
                {
                    return BitConverter.ToInt32(BitConverter.GetBytes((float)mValue), 0);
                }
                else
                {
                    return mValue;
                }
            }
            else
            {
                Type lElementType = lArray.GetType().GetElementType();

                if (lElementType == typeof(SByte))
                {
                    byte[] lValue = new byte[mLength];
                    for (int i = 0; i < mLength; i++)
                    {
                        lValue[i] = unchecked((byte)(sbyte)lArray.GetValue(i));
                    }
                    return lValue;
                }
                else if (lElementType == typeof(UInt16))
                {
                    short[] lValue = new short[mLength];
                    for (int i = 0; i < mLength; i++)
                    {
                        lValue[i] = BitConverter.ToInt16(BitConverter.GetBytes((ushort)lArray.GetValue(i)), 0);
                    }
                    return lValue;
                }
                else if (lElementType == typeof(UInt32))
                {
                    int[] lValue = new int[mLength];
                    for (int i = 0; i < mLength; i++)
                    {
                        lValue[i] = BitConverter.ToInt32(BitConverter.GetBytes((uint)lArray.GetValue(i)), 0);
                    }
                    return lValue;
                }
                else if (lElementType == typeof(Single))
                {
                    int[] lValue = new int[mLength];
                    for (int i = 0; i < mLength; i++)
                    {
                        lValue[i] = BitConverter.ToInt32(BitConverter.GetBytes((float)lArray.GetValue(i)), 0);
                    }
                    return lValue;
                }
                else
                {
                    return mValue;
                }
            }
        }
        private void                    setValueFromPLC(object aValue)
        {
            object lNewValue = aValue;

            if (mNeedWrite) return;

            if (mLength == 1)
            {
                if (mDataType == PointDataTypeConstants.S7_Byte && mSigned == true)
                {
                    lNewValue = unchecked((sbyte)(byte)aValue);
                }
                else if (mDataType == PointDataTypeConstants.S7_Word && mSigned == false)
                {
                    lNewValue = BitConverter.ToUInt16(BitConverter.GetBytes((short)aValue), 0);
                }
                else if (mDataType == PointDataTypeConstants.S7_DoubleWord)
                {
                    if (mFloatingP)
                    {
                        lNewValue = BitConverter.ToSingle(BitConverter.GetBytes((int)aValue), 0);
                    }
                    else if (mSigned == false)
                    {
                        lNewValue = BitConverter.ToUInt32(BitConverter.GetBytes((int)aValue), 0);
                    }
                }
            }
            else
            {
                Array lArray = aValue as Array;

                if (mDataType == PointDataTypeConstants.S7_Byte && mSigned == true)
                {
                    sbyte[] lValue = new sbyte[mLength];
                    for (int i = 0; i < mLength; i++)
                    {
                        lValue[i] = unchecked((sbyte)(byte)lArray.GetValue(i));
                    }
                    lNewValue = lValue;
                }
                else if (mDataType == PointDataTypeConstants.S7_Word && mSigned == false)
                {
                    ushort[] lValue = new ushort[mLength];
                    for (int i = 0; i < mLength; i++)
                    {
                        lValue[i] = BitConverter.ToUInt16(BitConverter.GetBytes((short)lArray.GetValue(i)), 0);
                    }
                    lNewValue = lValue;
                }
                else if (mDataType == PointDataTypeConstants.S7_DoubleWord)
                {
                    if (mFloatingP)
                    {
                        float[] lValue = new float[mLength];
                        for (int i = 0; i < mLength; i++)
                        {
                            lValue[i] = BitConverter.ToSingle(BitConverter.GetBytes((int)lArray.GetValue(i)), 0);
                        }
                        lNewValue = lValue;
                    }
                    else if (mSigned == false)
                    {
                        uint[] lValue = new uint[mLength];
                        for (int i = 0; i < mLength; i++)
                        {
                            lValue[i] = BitConverter.ToUInt32(BitConverter.GetBytes((int)lArray.GetValue(i)), 0);
                        }
                        lNewValue = lValue;
                    }
                }
            }

            setValue(lNewValue);
        }
        public void                     setValueFromBuffer(byte[] aBuffer, int aStartIndex)
        {
            if (mNeedWrite) return;

            byte[] lBytes = null;
            switch (DataType)
            {
                case PointDataTypeConstants.S7_Bit: lBytes = new byte[1]; break;
                case PointDataTypeConstants.S7_Byte: lBytes = new byte[mLength]; break;
                case PointDataTypeConstants.S7_Word: lBytes = new byte[mLength * 2]; break;
                case PointDataTypeConstants.S7_DoubleWord: lBytes = new byte[mLength * 4]; break;
            }
            Array.Copy(aBuffer, Byte - aStartIndex, lBytes, 0, lBytes.Length);

            object lNewValue = lBytes;

            if (mLength == 1)
            {
                if (mDataType == PointDataTypeConstants.S7_Bit)
                {
                    lNewValue = (lBytes[0] & (1 << mBit)) != 0;
                }
                else if (mDataType == PointDataTypeConstants.S7_Byte)
                {
                    if (mSigned)
                    {
                        lNewValue = unchecked((sbyte)lBytes[0]);
                    }
                    else
                    {
                        lNewValue = lBytes[0];
                    }
                }
                else if (mDataType == PointDataTypeConstants.S7_Word)
                {
                    Array.Reverse(lBytes);

                    if (mSigned)
                    {
                        lNewValue = BitConverter.ToInt16(lBytes, 0);
                    }
                    else
                    {
                        lNewValue = BitConverter.ToUInt16(lBytes, 0);
                    }
                }
                else if (mDataType == PointDataTypeConstants.S7_DoubleWord)
                {
                    Array.Reverse(lBytes);
                    if (mFloatingP)
                    {
                        lNewValue = BitConverter.ToSingle(lBytes, 0);
                    }
                    else
                    {
                        if (mSigned)
                        {
                            lNewValue = BitConverter.ToInt32(lBytes, 0);
                        }
                        else
                        {
                            lNewValue = BitConverter.ToUInt32(lBytes, 0);
                        }
                    }
                }
            }
            else
            {
                if (mDataType == PointDataTypeConstants.S7_Byte)
                {
                    if (mSigned)
                    {
                        sbyte[] lArray = new sbyte[mLength];
                        for (int i = 0; i < mLength; i++)
                        {
                            lArray[i] = unchecked((sbyte)lBytes[i]);
                        }
                        lNewValue = lArray;
                    }
                    else
                    {
                        lNewValue = lBytes;
                    }
                }
                else if (mDataType == PointDataTypeConstants.S7_Word)
                {
                    byte[] lValue = new byte[2];
                    int lIndex = 0;

                    if (mSigned)
                    {
                        short[] lArray = new short[mLength];

                        for (int i = 0; i < mLength; i++)
                        {
                            Array.Copy(lBytes, lIndex, lValue, 0, 2);
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
                            Array.Copy(lBytes, lIndex, lValue, 0, 2);
                            Array.Reverse(lValue);
                            lArray[i] = BitConverter.ToUInt16(lValue, 0);
                            lIndex = lIndex + 2;
                        }

                        lNewValue = lArray;
                    }
                }
                else if (mDataType == PointDataTypeConstants.S7_DoubleWord)
                {
                    byte[] lValue = new byte[4];
                    int lIndex = 0;

                    if (mFloatingP)
                    {
                        float[] lArray = new float[mLength];

                        for (int i = 0; i < mLength; i++)
                        {
                            Array.Copy(lBytes, lIndex, lValue, 0, 4);
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
                                Array.Copy(lBytes, lIndex, lValue, 0, 4);
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
                                Array.Copy(lBytes, lIndex, lValue, 0, 4);
                                Array.Reverse(lValue);
                                lArray[i] = BitConverter.ToUInt32(lValue, 0);
                                lIndex = lIndex + 4;
                            }

                            lNewValue = lArray;
                        }
                    }
                }
            }

            setValue(lNewValue);
        }
        private void                    setValue(object aNewValue)
        {
            bool lValueChanged = false;
            Monitor.Enter(mValueLock);
            //=========================================
            try
            {
                if (mNeedWrite) return;

                if (mLength == 1)
                {
                    if (setIfNewValue(aNewValue))
                    {
                        lValueChanged = true;
                    }
                }
                else
                {
                    mValue          = aNewValue;
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
        private bool                    setIfNewValue(object aNewValue)
        {
            if (mDataType == PointDataTypeConstants.S7_Bit)
            {
                bool lNewValue = Convert.ToBoolean(aNewValue);
                if ((bool)mValue != lNewValue)
                {
                    mValue = lNewValue;
                    return true;
                }
            }
            else if (mDataType == PointDataTypeConstants.S7_Byte)
            {
                if (mSigned)
                {
                    sbyte lNewValue = Convert.ToSByte(aNewValue);
                    if ((sbyte)mValue != lNewValue)
                    {
                        mValue = lNewValue;
                        return true;
                    }
                }
                else
                {
                    byte lNewValue = Convert.ToByte(aNewValue);
                    if ((byte)mValue != lNewValue)
                    {
                        mValue = lNewValue;
                        return true;
                    }
                }
            }
            else if (mDataType == PointDataTypeConstants.S7_Word)
            {
                if (mSigned)
                {
                    short lNewValue = Convert.ToInt16(aNewValue);
                    if ((short)mValue != lNewValue)
                    {
                        mValue = lNewValue;
                        return true;
                    }
                }
                else
                {
                    ushort lNewValue = Convert.ToUInt16(aNewValue);
                    if ((ushort)mValue != lNewValue)
                    {
                        mValue = lNewValue;
                        return true;
                    }
                }
            }
            else if (mDataType == PointDataTypeConstants.S7_DoubleWord)
            {
                if (mFloatingP)
                {
                    float lNewValue = Convert.ToSingle(aNewValue);
                    if (ValuesCompare.NotEqualDelta1.compare((float)mValue, lNewValue))
                    {
                        mValue = lNewValue;
                        return true;
                    }
                }
                else
                {
                    if (mSigned)
                    {
                        int lNewValue = Convert.ToInt32(aNewValue);
                        if ((int)mValue != lNewValue)
                        {
                            mValue = lNewValue;
                            return true;
                        }
                    }
                    else
                    {
                        uint lNewValue = Convert.ToUInt32(aNewValue);
                        if ((uint)mValue != lNewValue)
                        {
                            mValue = lNewValue;
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        private bool                    isCorrectArrayElementType(Type aType)
        {
            switch (mDataType)
            {
                case PointDataTypeConstants.S7_Bit:         return false;
                case PointDataTypeConstants.S7_Byte:        if (mSigned)
                                                            {
                                                                return (aType == typeof(SByte));
                                                            }
                                                            else
                                                            {
                                                                return (aType == typeof(Byte));
                                                            } 

                case PointDataTypeConstants.S7_Word:        if (mSigned)
                                                            {
                                                                return (aType == typeof(Int16));
                                                            }
                                                            else
                                                            {
                                                                return (aType == typeof(UInt16));
                                                            }

                case PointDataTypeConstants.S7_DoubleWord:  if (mFloatingP)
                                                            {
                                                                return (aType == typeof(Single));
                                                            }
                                                            else
                                                            {
                                                                if (mSigned)
                                                                {
                                                                    return (aType == typeof(Int32));
                                                                }
                                                                else
                                                                {
                                                                    return (aType == typeof(UInt32));
                                                                }
                                                            }
            }

            return false;
        }

        public object                   mValue          = false;
        private readonly object         mValueLock      = new object();
        public object                   Value
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

                bool lUpdate = false;

                Monitor.Enter(mValueLock);
                //=========================================
                try
                {
                    Array lArray = value as Array;

                    if (mLength == 1)
                    {
                        if (lArray != null)
                        {
                            throw new InvalidOperationException("Array is not expected. ");
                        }

                        if (mMemoryType == EPLCMemoryType.I)
                        {
                            mNeedWrite  = true;
                            lUpdate     = setIfNewValue(value);
                        }
                        else
                        {
                            if (setIfNewValue(value))
                            {
                                mNeedWrite  = true;
                                lUpdate     = true;
                            }
                        }
                    }
                    else
                    {
                        if (lArray == null)
                        {
                            throw new InvalidOperationException("Array is expected. ");
                        }

                        if (lArray.Length != mLength)
                        {
                            throw new InvalidOperationException("Array with length " + StringUtils.ObjectToString(mLength) + " is expected. ");
                        }

                        if(isCorrectArrayElementType(lArray.GetType().GetElementType()) == false)
                        {
                            throw new InvalidOperationException("Array element type is wrong. ");
                        }

                        mValue      = lArray;
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
        public event EventHandler       ValueChanged;
        public void                     raiseValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public object                   InitValue
        {
            get
            {
                switch (mDataType)
                {
                    case PointDataTypeConstants.S7_Bit:         return new Boolean();

                    case PointDataTypeConstants.S7_Byte:        if (mSigned)
                                                                {
                                                                    if (mLength == 1)
                                                                    {
                                                                        return new SByte();
                                                                    }
                                                                    else
                                                                    {
                                                                        return Array.CreateInstance(typeof(SByte), mLength);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (mLength == 1)
                                                                    {
                                                                        return new Byte();
                                                                    }
                                                                    else
                                                                    {
                                                                        return Array.CreateInstance(typeof(Byte), mLength);
                                                                    }
                                                                }

                    case PointDataTypeConstants.S7_Word:        if (mSigned)
                                                                {
                                                                    if (mLength == 1)
                                                                    {
                                                                        return new Int16();
                                                                    }
                                                                    else
                                                                    {
                                                                        return Array.CreateInstance(typeof(Int16), mLength);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (mLength == 1)
                                                                    {
                                                                        return new UInt16();
                                                                    }
                                                                    else
                                                                    {
                                                                        return Array.CreateInstance(typeof(UInt16), mLength);
                                                                    } 
                                                                }

                    case PointDataTypeConstants.S7_DoubleWord:  if (mFloatingP)
                                                                {
                                                                    if (mLength == 1)
                                                                    {
                                                                        return new Single();
                                                                    }
                                                                    else
                                                                    {
                                                                        return Array.CreateInstance(typeof(Single), mLength);
                                                                    } 
                                                                }
                                                                else
                                                                {
                                                                    if (mSigned)
                                                                    {
                                                                        if (mLength == 1)
                                                                        {
                                                                            return new Int32();
                                                                        }
                                                                        else
                                                                        {
                                                                            return Array.CreateInstance(typeof(Int32), mLength);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (mLength == 1)
                                                                        {
                                                                            return new UInt32();
                                                                        }
                                                                        else
                                                                        {
                                                                            return Array.CreateInstance(typeof(UInt32), mLength);
                                                                        }
                                                                    }
                                                                }
                }

                return null;
            }
        }

        public volatile EAccess         mAccess         = EAccess.NO_ACCESS;
        public void                     initAccess()
        {
            EAccess lAccess = EAccess.NO_ACCESS;

            if (mConnection.Connected)
            {
                switch (mMemoryType)
                {
                    case EPLCMemoryType.M:  lAccess = EAccess.READ_WRITE;
                                            break;

                    case EPLCMemoryType.DB: lAccess = EAccess.READ_WRITE;
                                            break;

                    case EPLCMemoryType.I:  lAccess = EAccess.READ_WRITE;
                                            break;

                    case EPLCMemoryType.Q:  lAccess = EAccess.READ;
                                            break;
                }
            }

            if (lAccess != mAccess)
            {
                mAccess = lAccess;
                raisePropertiesChanged();
            }
        }
        public EAccess                  Access
        {
            get
            {
                return mAccess;
            }
        }

        public void                     onConnectionStateChanged(object aSender, EventArgs aEventArgs)
        {
            initAccess();
        }

        public string                   Description
        {
            get
            {
                StringBuilder lResult = new StringBuilder();

                if (mMemoryType == EPLCMemoryType.DB)
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
                    case PointDataTypeConstants.S7_Bit:         if (mMemoryType == EPLCMemoryType.DB)
                                                                {
                                                                    lResult.Append("X");
                                                                }
                                                                break;

                    case PointDataTypeConstants.S7_Byte:        lResult.Append("B"); break;
                    case PointDataTypeConstants.S7_Word:        lResult.Append("W"); break;
                    case PointDataTypeConstants.S7_DoubleWord:  lResult.Append("D"); break;
                }

                lResult.Append(mByte);

                if (mDataType == PointDataTypeConstants.S7_Bit)
                {
                    lResult.Append("." + StringUtils.ObjectToString(mBit) + ", BOOL");
                }
                else if (mDataType == PointDataTypeConstants.S7_DoubleWord && mFloatingP)
                {
                    lResult.Append(", REAL");
                }
                else
                {
                    if (mSigned)
                    {
                        switch (mDataType) //-V3002
                        {
                            case PointDataTypeConstants.S7_Byte:        lResult.Append(", SBYTE"); break;
                            case PointDataTypeConstants.S7_Word:        lResult.Append(", INT"); break;
                            case PointDataTypeConstants.S7_DoubleWord:  lResult.Append(", DINT"); break;
                        }
                    }
                    else
                    {
                        switch (mDataType) //-V3002
                        {
                            case PointDataTypeConstants.S7_Byte:        lResult.Append(", BYTE"); break;
                            case PointDataTypeConstants.S7_Word:        lResult.Append(", WORD"); break;
                            case PointDataTypeConstants.S7_DoubleWord:  lResult.Append(", DWORD"); break;
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

        public event EventHandler       PropertiesChanged;
        public void                     raisePropertiesChanged()
        {
            PropertiesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
