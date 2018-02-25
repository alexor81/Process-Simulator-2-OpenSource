// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Threading;
using Utils;

namespace Connection.S7PLCSimAdv2
{
    public class DataItem: IDataItem
    {
        public Connection           mConnection;
        public string               mTagName;

        public object               mValue          = 0;
        private readonly object     mValueLock      = new object();
        public volatile bool        mNeedWrite      = false;
        private EPrimitiveDataType  mPDataType      = EPrimitiveDataType.Unspecific;
        public void                 setValue(SDataValue aValue)
        {
            if (mNeedWrite) return;

            mPDataType = aValue.Type;

            object lNewValue;
            switch(aValue.Type)
            {
                case EPrimitiveDataType.Bool:   lNewValue = aValue.Bool; break;
                case EPrimitiveDataType.Int8:   lNewValue = aValue.Int8; break;
                case EPrimitiveDataType.Int16:  lNewValue = aValue.Int16; break;
                case EPrimitiveDataType.Int32:  lNewValue = aValue.Int32; break;
                case EPrimitiveDataType.Int64:  lNewValue = aValue.Int64; break;
                case EPrimitiveDataType.UInt8:  lNewValue = aValue.UInt8; break;
                case EPrimitiveDataType.UInt16: lNewValue = aValue.UInt16; break;
                case EPrimitiveDataType.UInt32: lNewValue = aValue.UInt32; break;
                case EPrimitiveDataType.UInt64: lNewValue = aValue.UInt64; break;
                case EPrimitiveDataType.Float:  lNewValue = aValue.Float; break;
                case EPrimitiveDataType.Double: lNewValue = aValue.Double; break;
                case EPrimitiveDataType.Char:   lNewValue = aValue.Char; break;
                case EPrimitiveDataType.WChar:  lNewValue = aValue.WChar; break;

                default:                        throw new InvalidOperationException("Type is not supported. ");
            }

            bool lValueChanged = false;
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
        public SDataValue           getValue()
        {
            var lValue  = new SDataValue();
            lValue.Type = mPDataType;

            switch(mPDataType)
            {
                case EPrimitiveDataType.Bool:   lValue.Bool     = (bool)mValue; break;
                case EPrimitiveDataType.Int8:   lValue.Int8     = (sbyte)mValue; break;
                case EPrimitiveDataType.Int16:  lValue.Int16    = (short)mValue; break;
                case EPrimitiveDataType.Int32:  lValue.Int32    = (int)mValue; break;
                case EPrimitiveDataType.Int64:  lValue.Int64    = (long)mValue; break;
                case EPrimitiveDataType.UInt8:  lValue.UInt8    = (byte)mValue; break;
                case EPrimitiveDataType.UInt16: lValue.UInt16   = (ushort)mValue; break;
                case EPrimitiveDataType.UInt32: lValue.UInt32   = (uint)mValue; break;
                case EPrimitiveDataType.UInt64: lValue.UInt64   = (ulong)mValue; break;
                case EPrimitiveDataType.Float:  lValue.Float    = (float)mValue; break;
                case EPrimitiveDataType.Double: lValue.Double   = (double)mValue; break;
                case EPrimitiveDataType.Char:   lValue.Char     = (sbyte)mValue; break;
                case EPrimitiveDataType.WChar:  lValue.WChar    = (char)mValue; break;

                default:                        throw new InvalidOperationException("Type is not supported. ");
            }

            return lValue;
        }
        public void                 updateValue()
        {
            if (Access.HasFlag(EAccess.READ))
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

                object lNewValue = Converters.convertValue(mValue.GetType(), value);

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
                return mValue;
            }
        }

        public volatile EAccess     mAccess         = EAccess.NO_ACCESS;
        public EAccess              Access
        {
            set
            {
                if (mAccess != value)
                {
                    mAccess = value;
                    raisePropertiesChanged();
                }
            }
            get
            {
                if (mConnection.Connected)
                {
                    return mAccess;
                }
                else
                {
                    return EAccess.NO_ACCESS;
                }
            }
        }

        public void                 onConnectionStateChanged(object aSender, EventArgs aEventArgs)
        {
            raisePropertiesChanged();
        }

        public string               Description
        {
            get
            {
                return mTagName;
            }
        }

        public event EventHandler   PropertiesChanged;
        public void                 raisePropertiesChanged()
        {
            PropertiesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
