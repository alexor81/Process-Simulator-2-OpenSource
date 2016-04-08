using System;
using API;
using Utils;

namespace Connection.Internal
{
    public class DataItem: IDataItem
    {
        public object                   mValue = 0;
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

                if (ValuesCompare.isNotEqual(mValue, value))
                {
                    bool lTypeChanged = true;
                    if (mValue != null && value != null)
                    {
                        lTypeChanged = (mValue.GetType() != value.GetType());
                    }

                    mValue      = value;
                    var lEvent  = ValueChanged;
                    if (mAccess.HasFlag(EAccess.READ) && lEvent != null)
                    {
                        lEvent(this, EventArgs.Empty);
                    }

                    if (lTypeChanged)
                    {
                        raisePropertiesChanged();
                    }
                }
            }
        }
        public event EventHandler       ValueChanged;
        public object                   InitValue
        {
            get
            {
                return mValue;
            }
        }

        public volatile EAccess         mPrevAccess = EAccess.READ_WRITE;
        public volatile EAccess         mAccess     = EAccess.READ_WRITE;
        public EAccess                  Access
        {
            get
            {
                return mAccess;
            }
            set
            {
                if (mAccess != value)
                {
                    mAccess = value;
                    raisePropertiesChanged();
                }
            }
        }

        public void                     onConnectionStateChanged(object aSender, EventArgs aEventArgs)
        {
            if (((Connection)aSender).Connected)
            {
                Access = mPrevAccess;
            }
            else
            {
                mPrevAccess = mAccess;
                Access      = EAccess.NO_ACCESS;
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
        private void                    raisePropertiesChanged()
        {
            EventHandler lEvent = PropertiesChanged;
            if (lEvent != null) lEvent(this, EventArgs.Empty);
        }
    }
}
