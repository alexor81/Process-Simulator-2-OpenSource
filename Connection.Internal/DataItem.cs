// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using Utils;

namespace Connection.Internal
{
    public class DataItem: IDataItem
    {
        public Connection               mConnection;

        public object                   mValue = 0;
        public void                     setValue(object aValue)
        {
            if (ValuesCompare.isNotEqual(mValue, aValue))
            {
                bool lTypeChanged = true;
                if (mValue != null)
                {
                    lTypeChanged = (mValue.GetType() != aValue.GetType());
                }
                else
                {
                    lTypeChanged = true;
                }

                mValue = aValue;
                if (Access.HasFlag(EAccess.READ))
                {
                    raiseValueChanged();
                }

                if (lTypeChanged)
                {
                    raisePropertiesChanged();
                }
            }
        }
        public object                   Value
        {
            get
            {
                if (Access.HasFlag(EAccess.READ) == false)
                {
                    throw new InvalidOperationException("No access. ");
                }

                return mValue;
            }
            set
            {
                if (Access.HasFlag(EAccess.WRITE) == false)
                {
                    throw new InvalidOperationException("No access. ");
                }

                if(value == null)
                {
                    throw new ArgumentException("Null value is prohibited. ");
                }

                if(mConnection.mTypeChangeProhibited && mValue != null)
                {
                    if(mValue.GetType() != value.GetType())
                    {
                        throw new ArgumentException("Type change is prohibited. ");
                    }
                }

                setValue(value);
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
                return mValue;
            }
        }

        public volatile EAccess         mAccess     = EAccess.READ_WRITE;
        public EAccess                  Access
        {
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
            set
            {
                if(mAccess != value)
                {
                    mAccess = value;
                    raisePropertiesChanged();

                    if (Access.HasFlag(EAccess.READ))
                    {
                        raiseValueChanged();
                    }
                }
            }
        }

        public void                     onConnectionStateChanged(object aSender, EventArgs aEventArgs)
        {
            raisePropertiesChanged();

            if (Access.HasFlag(EAccess.READ))
            {
                raiseValueChanged();
            }   
        }

        public string                   Description
        {
            get
            {
                return "";
            }
        }

        public event EventHandler       PropertiesChanged;
        public void                     raisePropertiesChanged()
        {
            PropertiesChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
