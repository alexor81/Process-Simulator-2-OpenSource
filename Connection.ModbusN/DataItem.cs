// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using NModbus;
using System;
using System.Text;
using System.Threading;
using Utils;
using Utils.Segmentation;

namespace Connection.ModbusN
{
    public class DataItem : IDataItem, ISegmentItem
    {
        public Connection           mConnection;
        private byte                mSlaveID        = 1;
        public byte                 SlaveID
        {
            get { return mSlaveID; }
            set
            {
                if (value == 0) throw new ArgumentException("Wrong slave ID. ");

                mSlaveID = value;
            }
        }     
        public void                 setRegister(ERegisterType aRegisterType, ushort aRegister, Type aDataType, ushort aLength)
        {
            if (aLength == 0 || (aRegister + aLength) > 65535) throw new ArgumentException("Length is wrong. ");

            if (aRegisterType == ERegisterType.INPUT_BIT || aRegisterType == ERegisterType.COIL_BIT)
            {
                if (aDataType != typeof(Boolean)) throw new ArgumentException("DataType is wrong. "); 
            }
            else
            {
                if (aDataType != typeof(Int16) && aDataType != typeof(UInt16) 
                    && aDataType != typeof(Int32) && aDataType != typeof(UInt32) && aDataType != typeof(Single))
                {
                    throw new ArgumentException("DataType is wrong. ");
                }
            }

            mRegisterType   = aRegisterType;
            mRegister       = aRegister;
            mDataType       = aDataType;
            mLength         = aLength;
            mValue          = InitValue;

            if (mRegisterType == ERegisterType.INPUT_REGISTER || mRegisterType == ERegisterType.HOLDING_REGISTER)
            {
                
                if (mDataType == typeof(Int16) || mDataType == typeof(UInt16))
                {
                    mSegLength = (ushort)mLength;
                }
                else
                {
                    mSegLength =  (ushort)(2 * mLength);
                }
            }
            else
            {
                mSegLength = (ushort)mLength;
            }
        }
        private ERegisterType       mRegisterType   = ERegisterType.HOLDING_REGISTER;
        public ERegisterType        RegisterType
        {
            get { return mRegisterType; }
        }
        private ushort              mRegister       = 0;
        public ushort               Register
        {
            get { return mRegister; }
        }
        private ushort              mLength         = 1;
        public ushort               Length
        {
            get { return mLength; }
        }       
        private ushort              mSegLength      = 1;
        private Type                mDataType       = typeof(UInt16);
        public Type                 DataType
        {
            get { return mDataType; }
        }
        public bool                 mSwapWords      = false;
        
        public object               mValue          = (ushort)0;
        private readonly object     mValueLock      = new object();
        public volatile bool        mNeedWrite      = false;
        public void                 setRawValue(ushort[] aRegisters)
        {
            if (mNeedWrite) return;

            object lNewValue = aRegisters;

            if (mLength == 1)
            {
                if (mDataType == typeof(Int16))
                {
                    lNewValue = unchecked((short)aRegisters[0]);
                }
                else if (mDataType == typeof(UInt16))
                {
                    lNewValue = aRegisters[0];
                }
                else
                {
                    if (mSwapWords) Array.Reverse(aRegisters);

                    if (mDataType == typeof(Int32))
                    {
                        unsafe
                        {
                            fixed (ushort* pBuffer = aRegisters)
                            {
                                int* pValue = (int*)pBuffer;
                                lNewValue = pValue[0];
                            }
                        }
                    }
                    else if (mDataType == typeof(UInt32))
                    {
                        unsafe
                        {
                            fixed (ushort* pBuffer = aRegisters)
                            {
                                uint* pValue = (uint*)pBuffer;
                                lNewValue = pValue[0];
                            }
                        }
                    }
                    else if (mDataType == typeof(Single))
                    {
                        unsafe
                        {
                            fixed (ushort* pBuffer = aRegisters)
                            {
                                float* pValue = (float*)pBuffer;
                                lNewValue = pValue[0];
                            }
                        }
                    }
                }
            }
            else
            {
                if (mDataType == typeof(Int16))
                {
                    var lArray = new short[mLength];

                    for (int i = 0; i < lArray.Length; i++)
                    {
                        lArray[i] = unchecked((short)aRegisters[i]);
                    }

                    lNewValue = lArray;
                }
                else if (mDataType == typeof(UInt16))
                {
                    var lArray = new ushort[mLength];

                    for (int i = 0; i < lArray.Length; i++)
                    {
                        lArray[i] = aRegisters[i];
                    }

                    lNewValue = lArray;
                }
                else
                {
                    var lValue  = new ushort[2];
                    int lIndex  = 0;

                    if (mDataType == typeof(Int32))
                    {
                        var lArray = new int[mLength];

                        for (int i = 0; i < lArray.Length; i++)
                        {
                            Array.Copy(aRegisters, lIndex, lValue, 0, 2);
                            if (mSwapWords) Array.Reverse(lValue);
                            unsafe
                            {
                                fixed (ushort* pBuffer = lValue)
                                {
                                    int* pValue = (int*)pBuffer;
                                    lArray[i] = pValue[0];
                                }
                            }
                            lIndex = lIndex + 2;
                        }

                        lNewValue = lArray;
                    }
                    else if (mDataType == typeof(UInt32))
                    {
                        var lArray = new uint[mLength];

                        for (int i = 0; i < lArray.Length; i++)
                        {
                            Array.Copy(aRegisters, lIndex, lValue, 0, 2);
                            if (mSwapWords) Array.Reverse(lValue);
                            unsafe
                            {
                                fixed (ushort* pBuffer = lValue)
                                {
                                    uint* pValue = (uint*)pBuffer;
                                    lArray[i] = pValue[0];
                                }
                            }
                            lIndex = lIndex + 2;
                        }

                        lNewValue = lArray;
                    }
                    else if (mDataType == typeof(Single))
                    {
                        var lArray = new float[mLength];

                        for (int i = 0; i < lArray.Length; i++)
                        {
                            Array.Copy(aRegisters, lIndex, lValue, 0, 2);
                            if (mSwapWords) Array.Reverse(lValue);
                            unsafe
                            {
                                fixed (ushort* pBuffer = lValue)
                                {
                                    float* pValue = (float*)pBuffer;
                                    lArray[i] = pValue[0];
                                }
                            }
                            lIndex = lIndex + 2;
                        }

                        lNewValue = lArray;
                    }
                }
            }

            setValue(lNewValue);
        }
        public void                 setValue(object aNewValue)
        {
            bool lValueChanged = false;
            Monitor.Enter(mValueLock);
            //=========================================
            try
            {
                if (mNeedWrite) return;

                if (ValuesCompare.isNotEqual(mValue, aNewValue))
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
                return StringUtils.getInitValue(mDataType, (mLength > 1), (int)mLength);
            }
        }

        public volatile EAccess     mAccess         = EAccess.NO_ACCESS;
        public void                 initAccess()
        {
            EAccess lAccess = EAccess.NO_ACCESS;

            if (mConnection.Connected)
            {
                if (mRegisterType == ERegisterType.COIL_BIT || mRegisterType == ERegisterType.HOLDING_REGISTER)
                {
                    lAccess = EAccess.READ_WRITE;
                }
                else
                {
                    lAccess = EAccess.READ;
                }
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
                StringBuilder lResult = new StringBuilder("Slave №");
                lResult.Append(StringUtils.ObjectToString(mSlaveID));

                switch(mRegisterType)
                {
                    case ERegisterType.COIL_BIT:            lResult.Append(" Coil Bit "); break;
                    case ERegisterType.INPUT_BIT:           lResult.Append(" Input Bit "); break;
                    case ERegisterType.INPUT_REGISTER:      lResult.Append(" Input Register "); break;
                    case ERegisterType.HOLDING_REGISTER:    lResult.Append(" Holding Register "); break;
                }
                lResult.Append(StringUtils.ObjectToString(mRegister));

                if (mSwapWords)
                {
                    lResult.Append(", swaped words");
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
                    return (int)mRegister;
                }
            }

            public int              SegLength
            {
                get
                {
                    return mSegLength;
                }
            }

        #endregion
    }
}
