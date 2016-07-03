using API;
using System;
using System.Text;
using Utils;

namespace Connection.MQTT
{
    public class DataItem: IDataItem
    {
        public string                   mTopic      = "";
        public Connection               mConnection;

        private bool                    mSubscribe  = true;
        public bool                     Subscribe
        {
            get { return mSubscribe; }
            set { mSubscribe = value; }
        }

        private bool                    mPublish    = true;
        public bool                     Publish
        {
            get { return mPublish; }
            set
            {
                if (mPublish != value)
                {
                    mPublish = value;
                    initAccess();
                }
            }
        }

        public string                   mValue      = "";
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

                string lValue = StringUtils.ObjectToString(value);
                if (mValue.Equals(lValue, StringComparison.Ordinal) == false)
                {
                    mValue = lValue;
                    mConnection.publish(mTopic, mValue);
                    raiseValueChanged();
                }
            }
        }
        public void                     setValue(string aValue)
        {
            if (mValue.Equals(aValue, StringComparison.Ordinal) == false)
            {
                mValue = aValue;
                raiseValueChanged();
            }
        }
        public event EventHandler       ValueChanged;
        public void                     raiseValueChanged()
        {
            EventHandler lEvent = ValueChanged;
            if (lEvent != null) lEvent(this, EventArgs.Empty);
        }
        public object                   InitValue
        {
            get { return mValue; }
        }

        public volatile EAccess         mAccess     = EAccess.NO_ACCESS;
        public void                     initAccess()
        {
            EAccess lAccess;

            if (mConnection.Connected)
            {
                if(mPublish)
                {
                    lAccess = EAccess.READ_WRITE;
                }
                else
                {
                    lAccess = EAccess.READ;
                }
            }
            else
            {
                lAccess = EAccess.NO_ACCESS;
            }

            if (mAccess != lAccess)
            {
                mAccess = lAccess;
                raisePropertiesChanged();
            }
        }
        public EAccess                  Access
        {
            get{ return mAccess; }
        }

        public void                     onConnectionStateChanged(object aSender, EventArgs aEventArgs)
        {
            initAccess();
        }

        public string                   Description
        {
            get
            {
                StringBuilder lResult = new StringBuilder("'");

                lResult.Append(mConnection.getFullTopic(mTopic));

                lResult.Append("'");

                if(mSubscribe)
                {
                    lResult.Append(", Subscribe");
                }

                if (mPublish)
                {
                    lResult.Append(", Publish");
                }

                return lResult.ToString();
            }
        }

        public event EventHandler       PropertiesChanged;
        public void                     raisePropertiesChanged()
        {
            EventHandler lEvent = PropertiesChanged;
            if (lEvent != null) lEvent(this, EventArgs.Empty);
        }
    }
}
