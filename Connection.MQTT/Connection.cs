// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

            if (mItemList.Count != 0)
            {
                string[] lKeys  = mItemList.Keys.ToArray();
                string[] lItems = new string[lKeys.Length];
                byte[] lQoS     = new byte[lKeys.Length];
                DataItem lDataItem;

                for (int i = 0; i < lKeys.Length; i++)
                {
                    lItems[i]   = getFullTopic(lKeys[i]);
                    lQoS[i]     = mQOS;
                    lDataItem   = mItemList[lKeys[i]];
                    if (lDataItem.Publish && lDataItem.Subscribe == false)
                    {
                        publish(lItems[i], lDataItem.mValue);
                    }
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
            ConnectionState?.Invoke(this, EventArgs.Empty);
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
            mLastError = aMessage;
            ConnectionError?.Invoke(this, new MessageStringEventArgs(aMessage));
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

        private void                                        MsgReceived(string aTopic, byte[] aMessage)
        {
            string lTopic = aTopic;

            if (mRootExist)
            {
                if (lTopic.StartsWith(mRoot))
                {
                    lTopic = aTopic.Remove(0, mRoot.Length);
                }
                else
                {
                    Log.Error("Root is wrong in Topic '" + aTopic + "'. ");
                    return;
                }
            }

            mItemListLock.EnterReadLock();
            //========================================
            try
            {
                if (mItemList.ContainsKey(lTopic) == false)
                {
                    Log.Error("Topic '" + aTopic + "' does not exist. ");
                    return;
                }

                if (mItemList[lTopic].Subscribe)
                {
                    mItemList[lTopic].setValue(Encoding.UTF8.GetString(aMessage));
                }
            }
            catch (Exception lExc)
            {
                raiseConnectionError("Error updating value. " + lExc.ToString());
            }
            finally
            {
                //========================================
                mItemListLock.ExitReadLock();
            }
        }

        private void                                        MClient_MqttMsgPublishReceived(object aSender, MqttMsgPublishEventArgs aEventArgs)
        {
            Task.Factory.StartNew(() => MsgReceived(aEventArgs.Topic, aEventArgs.Message));
        }

        public void                                         publish(string aTopic, string aValue)
        {
            mClient.Publish(getFullTopic(aTopic), Encoding.UTF8.GetBytes(aValue), mQOS, true);
        }

        #region Items

            private Dictionary<string, DataItem>            mItemList       = new Dictionary<string, DataItem>(StringComparer.Ordinal);
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

                    mItemList.Add(aTopic, lItem);
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }

                lItem.raisePropertiesChanged();
                if (Connected)
                {
                    string lFullTopic = getFullTopic(aTopic);
                    if (aPublish && aSubscribe == false)
                    {
                        publish(lFullTopic, aValue);
                    }
                    mClient.Subscribe(new string[] { lFullTopic }, new byte[] { mQOS });
                }

                ConnectionState += new EventHandler(lItem.onConnectionStateChanged);

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

                    aItem.raisePropertiesChanged();
                    if (Connected)
                    {
                        mClient.Subscribe(new string[] { getFullTopic(aNewTopic) }, new byte[] { mQOS });
                    }
                }

                if (aItem.Subscribe != aSubscribe)
                {
                    aItem.Subscribe = aSubscribe;
                    if (Connected)
                    {
                        mClient.Unsubscribe(new string[] { getFullTopic(aItem.mTopic) });
                        mClient.Subscribe(new string[] { getFullTopic(aItem.mTopic) }, new byte[] { mQOS });
                    }
                }

                if (aItem.Publish != aPublish)
                {
                    aItem.Publish = aPublish;
                }
            }

            public void                                     removeItem(DataItem aItem)
            {
                ConnectionState -= aItem.onConnectionStateChanged;

                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    if (mItemList.ContainsKey(aItem.mTopic) == false)
                    {
                        throw new ArgumentException("Data item with Topic: '" + aItem.mTopic + "' is not found. ");
                    }

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
