using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Utils.Logger;

namespace Connection.MQTT
{
    public class Connection: IConnection, IDisposable
    {
        private MqttClient                                  mClient;
        public string                                       mHost       = "localhost";
        public int                                          mPort       = 1883;
        public string                                       mClientID   = "";
        public string                                       mLogin      = "";
        public string                                       mPassword   = "";

        private byte                                        mQOS        = MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE;
        public byte                                         QOS
        {
            get { return mQOS; }
            set
            {
                if(mQOS != value)
                {
                    if(value > 2)
                    {
                        mQOS = 2;
                    }
                    else
                    {
                        mQOS = value;
                    }
                }
            }
        }

        public ushort                                       mKeepAlive  = 60;

        private MqttProtocolVersion                         mProtocol   = MqttProtocolVersion.Version_3_1_1;
        public string                                       Protocol
        {
            get { return mProtocol.ToString(); }
            set
            {
                mProtocol = (MqttProtocolVersion)Enum.Parse(typeof(MqttProtocolVersion), value);
            }
        }

        private string                                      mRoot       = "";
        private bool                                        mRootExist  = false;
        public string                                       Root
        {
            get
            {
                return mRoot;
            }
            set
            {
               if(String.IsNullOrWhiteSpace(value))
                {                
                    mRoot       = "";
                    mRootExist = false;
                }
                else
                {
                    if (mRoot.Equals(value, StringComparison.Ordinal) == false)
                    {
                        if (value.Contains("+"))
                        {
                            throw new ArgumentException("There is wrong symbol [+] in Root '" + value + "'. ");
                        }

                        if (value.Contains("#"))
                        {
                            throw new ArgumentException("There is wrong symbol [#] in Root '" + value + "'. ");
                        }

                        mRoot       = value;
                        mRootExist  = true;
                    }
                }
            }
        }
        public string                                       getFullTopic(string aTopic)
        {
            if (mRootExist)
            {
                return mRoot + aTopic;
            }
            else
            {
                return aTopic;
            }
        }

        private volatile bool                               mUserDisconnect = false;
        public void                                         connect()
        {
            mClient                         = new MqttClient(mHost, mPort, false, MqttSslProtocols.None, null, null);
            mClient.ConnectionClosed        += new MqttClient.ConnectionClosedEventHandler(MClient_ConnectionClosed);
            mClient.MqttMsgPublishReceived  += new MqttClient.MqttMsgPublishEventHandler(MClient_MqttMsgPublishReceived);
            mClient.ProtocolVersion         = mProtocol;

            mClientID       = Guid.NewGuid().ToString();
            mUserDisconnect = false;

            try
            {
                if (String.IsNullOrWhiteSpace(mLogin) != true && String.IsNullOrWhiteSpace(mPassword) != true)
                {
                    mClient.Connect(mClientID, mLogin, mPassword, true, mKeepAlive);
                }
                else
                {
                    mClient.Connect(mClientID, null, null, true, mKeepAlive);
                }

                if(mClient.IsConnected == false)
                {
                    throw new InvalidOperationException("Unable to connect '" + mHost + ":" + mPort.ToString() + "'. ");
                }
            }
            catch
            {
                cleanClient();
                throw;
            }

            raiseConnectionState();

            if (mItemList.Count > 0)
            {
                string[] lItems = mItemList.Keys.ToArray();
                byte[] lQoS     = new byte[lItems.Length];

                for (int i = 0; i < lItems.Length; i++)
                {
                    lItems[i]   = getFullTopic(lItems[i]);
                    lQoS[i]     = mQOS;
                }

                mClient.Subscribe(lItems, lQoS);
            }
        }

        private void                                        cleanClient()
        {
            mClient.ConnectionClosed        -= MClient_ConnectionClosed;
            mClient.MqttMsgPublishReceived  -= MClient_MqttMsgPublishReceived;
        }

        public void                                         disconnect()
        {
            mUserDisconnect = true;
            mClient.Disconnect();
        }

        public bool                                         Connected
        {
            get
            {
                if (mClient != null)
                {
                    return mClient.IsConnected;
                }
                else
                {
                    return false;
                }
            }
        }

        public event EventHandler                           ConnectionState;
        private void                                        raiseConnectionState()
        {
            var lEvent = ConnectionState;
            if (lEvent != null) lEvent(this, EventArgs.Empty);
        }

        private string                                      mLastError  = "";
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

        private void                                        MClient_ConnectionClosed(object aSender, EventArgs aEventArgs)
        {
            if (mUserDisconnect == false)
            {
                raiseConnectionError("Broker disconnection. ");
            }

            cleanClient();
            raiseConnectionState();
        }

        private void                                        MClient_MqttMsgPublishReceived(object aSender, MqttMsgPublishEventArgs aEventArgs)
        {
            string lTopic = aEventArgs.Topic;
            if (mRootExist)
            {
                if (lTopic.StartsWith(mRoot))
                {
                    lTopic = lTopic.Remove(0, mRoot.Length);
                }
                else
                {
                    Log.Error("Root is wrong in Topic '" + lTopic + "'. ");
                    return;
                }
            }

            mItemListLock.EnterReadLock();
            //========================================
            try
            {
                if (mItemList.ContainsKey(lTopic) == false)
                {
                    Log.Error("Topic '" + aEventArgs.Topic + "' does not exist. ");
                    return;
                }

                if (mItemList[lTopic].Subscribe)
                {
                    mItemList[lTopic].setValue(Encoding.UTF8.GetString(aEventArgs.Message));
                }
            }
            finally
            {
                //========================================
                mItemListLock.ExitReadLock();
            }

        }

        public void                                         publish(string aTopic, string aValue)
        {
            mClient.Publish(getFullTopic(aTopic), Encoding.UTF8.GetBytes(aValue), mQOS, true);
        }

        #region Items

            private Dictionary<string, DataItem>            mItemList       = new Dictionary<string, DataItem>();
            private ReaderWriterLockSlim                    mItemListLock   = new ReaderWriterLockSlim();

            private void                                    checkItemArguments(string aTopic)
            {
                if(String.IsNullOrWhiteSpace(aTopic))
                {
                    throw new ArgumentException("Topic name is empty. ");
                }

                if (aTopic.Contains("+"))
                {
                    throw new ArgumentException("There is wrong symbol [+] in Topic name '" + aTopic + "'. ");
                }

                if (aTopic.Contains("#"))
                {
                    throw new ArgumentException("There is wrong symbol [#] in Topic name '" + aTopic + "'. ");
                }
            }

            public DataItem                                 addItem(string aTopic, bool aSubscribe, bool aPublish, string aValue)
            {
                checkItemArguments(aTopic);

                DataItem lItem      = new DataItem();
                lItem.mTopic        = aTopic;
                lItem.mConnection   = this;
                lItem.Subscribe     = aSubscribe;
                lItem.Publish       = aPublish;
                lItem.mValue        = aValue;
                lItem.initAccess();

                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    if (mItemList.ContainsKey(aTopic))
                    {
                        throw new ArgumentException("Topic '" + aTopic + "' already exists. ");
                    }

                    ConnectionState += new EventHandler(lItem.onConnectionStateChanged);

                    mItemList.Add(aTopic, lItem);
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }

                if (Connected)
                {
                    mClient.Subscribe(new string[] { getFullTopic(aTopic) }, new byte[] { mQOS });
                }

                return lItem;
            }

            public void                                     modifyItem(DataItem aItem, string aNewTopic, bool aSubscribe, bool aPublish)
            {
                checkItemArguments(aNewTopic);

                if (aItem.mTopic.Equals(aNewTopic, StringComparison.Ordinal) == false)
                {
                    mItemListLock.EnterWriteLock();
                    //========================================
                    try
                    {
                        if (mItemList.ContainsKey(aItem.mTopic) == false)
                        {
                            throw new ArgumentException("Data item with Topic: '" + aItem.mTopic + "' is not found. ");
                        }

                        if (mItemList.ContainsKey(aNewTopic))
                        {
                            throw new ArgumentException("Topic '" + aNewTopic + "' already exists. ");
                        }

                        if (Connected)
                        {
                            mClient.Unsubscribe(new string[] { getFullTopic(aItem.mTopic) });
                        }

                        mItemList.Remove(aItem.mTopic);
                        aItem.mTopic = aNewTopic;
                        mItemList.Add(aNewTopic, aItem);
                    }
                    finally
                    {
                        //========================================
                        mItemListLock.ExitWriteLock();
                    }

                    if (Connected)
                    {
                        mClient.Subscribe(new string[] { getFullTopic(aNewTopic) }, new byte[] { mQOS });
                    }
                }

                if (aItem.Subscribe != aSubscribe)
                {
                    aItem.Subscribe = aSubscribe;
                }

                if (aItem.Publish != aPublish)
                {
                    aItem.Publish = aPublish;
                }
            }

            public void                                     removeItem(DataItem aItem)
            {
                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    if (mItemList.ContainsKey(aItem.mTopic) == false)
                    {
                        throw new ArgumentException("Data item with Topic: '" + aItem.mTopic + "' is not found. ");
                    }

                    ConnectionState -= aItem.onConnectionStateChanged;

                    if (Connected)
                    {
                        mClient.Unsubscribe(new string[] { getFullTopic(aItem.mTopic) });
                    }

                    mItemList.Remove(aItem.mTopic);
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }
            }

            public int                                      NumberOfItems
            {
                get
                {
                    return mItemList.Count;
                }
            }

        #endregion

        #region IDisposable

        private bool                                    mDisposed = false;

            public void                                     Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void                          Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        mItemList.Clear();

                        if (mItemListLock != null)
                        {
                            mItemListLock.Dispose();
                            mItemListLock = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
