using System;
using API;

namespace Connection.Internal
{
    public class Connection: IConnection
    {
        public void                                         connect()
        {
            mConnected = true;
            raiseConnectionState();
        }

        public void                                         disconnect()
        {
            mConnected = false;
            raiseConnectionState();
        }

        private bool                                        mConnected = true;
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
            var lEvent = ConnectionState;
            if (lEvent != null) lEvent(this, EventArgs.Empty);
        }

        private string                                      mLastError = "";
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

            public DataItem                                 addItem(EAccess aItemAccess, object aValue)
            {
                DataItem lItem  = new DataItem();
                ConnectionState += new EventHandler(lItem.onConnectionStateChanged);

                lItem.mPrevAccess = aItemAccess;
                if (Connected)
                {
                    lItem.mAccess = aItemAccess;
                }
                else
                {
                    lItem.mAccess = EAccess.NO_ACCESS;
                }

                lItem.mValue    = aValue;
                mNumberOfItems  = mNumberOfItems + 1;

                return lItem;
            }

            public void                                     removeItem(DataItem aItem)
            {
                ConnectionState -= aItem.onConnectionStateChanged;
                mNumberOfItems  = mNumberOfItems - 1;
            }

            private int                                     mNumberOfItems = 0;
            public int                                      NumberOfItems
            {
                get
                {
                    return mNumberOfItems;
                }
            }

        #endregion
    }
}
