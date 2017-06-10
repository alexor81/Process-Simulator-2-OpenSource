// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utils;
using Utils.Logger;

namespace Connection.OPCUA
{
    public class Connection : IConnection, IDisposable
    {
        public static ApplicationDescriptionCollection  getServersDescr(string aDiscoveryUrl)
        {
            Uri lDiscoveryUrl;

            if (String.IsNullOrWhiteSpace(aDiscoveryUrl))
            {
                lDiscoveryUrl = new Uri("opc.tcp://localhost:4840");
            }
            else
            {
                lDiscoveryUrl = new Uri(aDiscoveryUrl);
            }

            var lAllServers = DiscoveryClient.Create(lDiscoveryUrl).FindServers(null);
            var lResult     = new ApplicationDescriptionCollection();

            foreach (var lServer in lAllServers)
            {
                if(lServer.ApplicationType == ApplicationType.ClientAndServer || lServer.ApplicationType == ApplicationType.Server)
                {
                    lResult.Add(lServer);
                }
            }

            return lResult;
        }

        public static string[]                          getServers(string aDiscoveryUrl)
        {
            var lServers        = getServersDescr(aDiscoveryUrl);
            var lServersList    = new List<string>();
            foreach(var lServer in lServers)
            {
                lServersList.Add(lServer.ApplicationName.ToString());
            }

            return lServersList.ToArray();
        }

        public static ETransport                        getTransport(string aUrl)
        {
            string lPart = aUrl.Substring(0, aUrl.IndexOf(':'));
            if (lPart.Equals("opc.tcp", StringComparison.Ordinal))
            {
                return ETransport.TCP;
            }
            else if(lPart.Equals("http", StringComparison.Ordinal))
            {
                return ETransport.HTTP;
            }
            else
            {
                throw new ArgumentException("Wrong url. ");
            }
        }

        public string                                   mDiscovery      = "opc.tcp://localhost:4840";
        public string                                   mHost           = "";
        public string                                   mServerName     = "";
        public string                                   mLogin          = "";
        public string                                   mPassword       = "";

        private ETransport                              mTransport      = ETransport.TCP;
        public string                                   Transport
        {
            get { return mTransport.ToString(); }
            set
            {
                mTransport = (ETransport)Enum.Parse(typeof(ETransport), value);
            }
        }

        public int                                      mPublishingInterval = 100;

        public Session                                  mSession        = null;
        private Subscription                            mSubscription   = null;
        private void                                    clearSession()
        {
            if (mOPCNodeBrowserForm != null)
            {
                mOPCNodeBrowserForm.Dispose();
                mOPCNodeBrowserForm = null;
            }

            if (mSubscription != null)
            {
                if (mSession != null)
                {
                    mSession.RemoveSubscription(mSubscription);
                }
                mSubscription.Dispose();
                mSubscription = null;
            }

            if (mSession != null)
            {
                mSession.KeepAlive      -= MSession_KeepAlive;
                mSession.Notification   -= MSession_Notification;
                mSession.PublishError   -= MSession_PublishError;
                mSession.Dispose();
                mSession = null;
            }
        }

        public void                                     connect()
        {
            clearSession();

            #region Server

                var lServers = getServersDescr(mDiscovery);

                ApplicationDescription lApplication = null;
                foreach(var lServer in lServers)
                {
                    if( mServerName.Equals(lServer.ApplicationName.ToString(), StringComparison.Ordinal))
                    {
                        lApplication = lServer;
                        break;
                    }
                }

                if(lApplication == null)
                {
                    throw new InvalidOperationException("Unable to find server. ");
                }

                var lEndpoints = DiscoveryClient.Create(new Uri(lApplication.DiscoveryUrls[0])).GetEndpoints(null);

                EndpointDescription lEndpoint = null;
                foreach (var lEP in lEndpoints)
                {
                    try
                    {
                        if (getTransport(lEP.EndpointUrl) == mTransport && lEP.SecurityMode == MessageSecurityMode.None)
                        {
                            lEndpoint = lEP;
                            break;
                        }
                    }
                    catch { }
                }

                if(lEndpoint == null)
                {
                    throw new InvalidOperationException("Unable to find suitable endpoint. ");
                }

                mHost                   = mDiscovery.Split(':')[1].Substring(2);
                lEndpoint.EndpointUrl   = lEndpoint.EndpointUrl.Replace("localhost", mHost);

            #endregion

            #region ApplicationConfiguration

                var lAppConfig              = new ApplicationConfiguration();
                lAppConfig.ApplicationName  = "Process Simulator 2";
                lAppConfig.ApplicationType  = ApplicationType.Client;
                lAppConfig.ApplicationUri   = "http://localhost/VendorId/ApplicationId/InstanceId";
                lAppConfig.ProductUri       = "http://VendorId/ProductId/VersionId";

                lAppConfig.SecurityConfiguration                                    = new SecurityConfiguration();
                lAppConfig.SecurityConfiguration.ApplicationCertificate             = new CertificateIdentifier();
                lAppConfig.SecurityConfiguration.ApplicationCertificate.StoreType   = CertificateStoreType.Windows;
                lAppConfig.SecurityConfiguration.ApplicationCertificate.StorePath   = "LocalMachine\\My";
                lAppConfig.SecurityConfiguration.ApplicationCertificate.SubjectName = lAppConfig.ApplicationName;
                lAppConfig.SecurityConfiguration.TrustedPeerCertificates.StoreType  = CertificateStoreType.Windows;
                lAppConfig.SecurityConfiguration.TrustedPeerCertificates.StorePath  = "LocalMachine\\My";

                var lClientCertificate = lAppConfig.SecurityConfiguration.ApplicationCertificate.Find(true);
                if (lClientCertificate == null)
                {
                    lClientCertificate = CertificateFactory.CreateCertificate(
                        lAppConfig.SecurityConfiguration.ApplicationCertificate.StoreType,
                        lAppConfig.SecurityConfiguration.ApplicationCertificate.StorePath,
                        lAppConfig.ApplicationUri,
                        lAppConfig.ApplicationName,
                        null,
                        null,
                        1024,
                        120);
                }

                lAppConfig.TransportConfigurations.Add(new TransportConfiguration(Opc.Ua.Utils.UriSchemeOpcTcp, typeof(Opc.Ua.Bindings.UaTcpBinding)));
                lAppConfig.TransportConfigurations.Add(new TransportConfiguration(Opc.Ua.Utils.UriSchemeHttp, typeof(Opc.Ua.Bindings.UaSoapXmlBinding)));

                lAppConfig.TransportQuotas                  = new TransportQuotas();
                lAppConfig.TransportQuotas.OperationTimeout = 360000;
                lAppConfig.TransportQuotas.MaxStringLength  = 67108864;
                lAppConfig.ServerConfiguration              = new ServerConfiguration();

                lAppConfig.ClientConfiguration                          = new ClientConfiguration();
                lAppConfig.ClientConfiguration.DefaultSessionTimeout    = 36000;

                lAppConfig.Validate(ApplicationType.Client);

            #endregion

            #region Session

                var lEndpointConfig                 = EndpointConfiguration.Create(lAppConfig);
                lEndpointConfig.OperationTimeout    = 300000;
                lEndpointConfig.UseBinaryEncoding   = true;

                var lConfiguredEndpoint             = new ConfiguredEndpoint(null, lEndpoint, lEndpointConfig);
                var lBindingFactory                 = BindingFactory.Create(lAppConfig, new ServiceMessageContext());

                lAppConfig.CertificateValidator.CertificateValidation += (s, e) => { e.Accept = true; };

                var lChannel                        = SessionChannel.Create(lAppConfig,
                                                                            lEndpoint,
                                                                            lEndpointConfig,
                                                                            lBindingFactory,
                                                                            lClientCertificate,
                                                                            null);

                mSession                    = new Session(lChannel, lAppConfig, lConfiguredEndpoint);
                mSession.ReturnDiagnostics  = DiagnosticsMasks.All;

                mSession.KeepAlive          += MSession_KeepAlive;
                mSession.Notification       += MSession_Notification;
                mSession.PublishError       += MSession_PublishError;

                if(String.IsNullOrWhiteSpace(mLogin) == false && String.IsNullOrWhiteSpace(mPassword) == false)
                {
                    mSession.Open("Process Simulator 2 session", new UserIdentity(mLogin, mPassword));
                }
                else
                {
                    mSession.Open("Process Simulator 2 session", null);
                }

            #endregion

            #region Namespace

                var lNewNamespaces = getNamespaces();
                if(mNamespaces != null && NumberOfItems > 0)
                {
                    int lIndex;
                    int[] lNsChanges    = new int[mNamespaces.Length];
                    bool lNeedChanges   = false;

                    for (int i = 0; i < mNamespaces.Length; i++)
                    {
                        lIndex = StringUtils.getIndex(lNewNamespaces, mNamespaces[i]);
                        if (lIndex == -1)
                        {
                            throw new InvalidOperationException("Namespace '" + mNamespaces[i] + "' is missing. ");
                        }

                        lNsChanges[i] = lIndex;

                        if (i != lIndex)
                        {
                            lNeedChanges = true;
                        }
                    }

                    if(lNeedChanges)
                    {
                        foreach(DataItem lItem in mItemList)
                        {
                            if (lItem.mNodeId.NamespaceIndex != lNsChanges[lItem.mNodeId.NamespaceIndex])
                            {
                                lItem.mNodeId = new NodeId(lItem.mNodeId.Identifier, (ushort)lNsChanges[lItem.mNodeId.NamespaceIndex]);
                            }
                        }

                        mNamespaces = lNewNamespaces;
                    }
                }
                else
                { 
                    mNamespaces     = lNewNamespaces;
                }

            #endregion

            #region Subscription

                mSubscription                               = new Subscription(mSession.DefaultSubscription);
                mSubscription.DisplayName                   = "Subscription";
                mSubscription.PublishingEnabled             = true;
                mSubscription.PublishingInterval            = mPublishingInterval;
                mSubscription.KeepAliveCount                = 10;
                mSubscription.LifetimeCount                 = 100;
                mSubscription.MaxNotificationsPerPublish    = 100;
                mSession.AddSubscription(mSubscription);
                mSubscription.Create();

                byte lAccess;
                object lValue;
                StatusCode lStatusCode;
                string lType;
                bool lArray;
                int lNotOKItemsCount = 0;
                foreach (DataItem lItem in mItemList)
                {
                    try
                    {
                        checkVariable(lItem.mNodeId, out lAccess, out lValue, out lStatusCode, out lType, out lArray);

                        lItem.setAccess(lAccess);
                        lItem.StatusCode = lStatusCode;

                        if ((lAccess == AccessLevels.CurrentRead || lAccess == AccessLevels.CurrentReadOrWrite) && StatusCode.IsGood(lStatusCode) && lValue != null)
                        {
                            lItem.mValue = lValue;
                        }
                        else
                        {
                            lItem.initValue(lType, lArray);
                        }

                        addItemToSubscription(lItem);
                    }
                    catch(Exception lExc)
                    {
                        lItem.setAccess(AccessLevels.None);
                        lNotOKItemsCount = lNotOKItemsCount + 1;
                        Log.Error("Data item '" + lItem.mNodeId.ToString() + "' activation error. " + lExc.Message, lExc.ToString());
                    }
                }

                mSubscription.ApplyChanges();

            #endregion

            mConnected = true;    
            raiseConnectionState();

            #region Update Item Values

                if(mItemList.Count > lNotOKItemsCount)
                {
                    foreach (DataItem lItem in mItemList)
                    {
                        if (lItem.Access.HasFlag(EAccess.READ))
                        {
                            lItem.raiseValueChanged();
                        }
                    }
                }

            #endregion

            if (lNotOKItemsCount > 0)
            {
                throw new InvalidOperationException("Unable to activate " + StringUtils.ObjectToString(lNotOKItemsCount) + " data item(s). ");
            }
        }

        public void                                     disconnect()
        {
            mConnected = false;
            mSession.Close(5000);
            raiseConnectionState();
        }

        private volatile bool                           mConnected = false;
        public bool                                     Connected
        {
            get
            {
                return mConnected;
            }
        }

        private void                                    MSession_KeepAlive(Session aSession, KeepAliveEventArgs aKeepAliveEventArgs)
        {
            if (mConnected)
            {
                if (aKeepAliveEventArgs.CurrentState != ServerState.Running)
                {
                    raiseConnectionError("Server status " + aKeepAliveEventArgs.CurrentState.ToString() + ". ");
                    disconnect();
                }
            }
        }

        private void                                    NotificationReceived(IList<MonitoredItemNotification> aDataChanges)
        {
            MonitoredItem lMItem;
            DataItem lItem;
            int lCount = aDataChanges.Count;

            for(int i = 0; i < lCount; i++)
            {
                mItemListLock.EnterReadLock();
                //========================================
                try
                {
                    lMItem = mSubscription.FindItemByClientHandle(aDataChanges[i].ClientHandle);
                    if (lMItem != null)
                    {
                        lItem = lMItem.Handle as DataItem;

                        if (aDataChanges[i].Value.StatusCode != lItem.StatusCode)
                        {
                            lItem.StatusCode = aDataChanges[i].Value.StatusCode;
                            lItem.raisePropertiesChanged();
                        }

                        if (aDataChanges[i].Value.Value != null)
                        {
                            if (ValuesCompare.isNotEqual(lItem.mValue, aDataChanges[i].Value.Value))
                            {
                                lItem.mValue = aDataChanges[i].Value.Value;
                                if (lItem.Access.HasFlag(EAccess.READ))
                                {
                                    lItem.raiseValueChanged();
                                }
                            }
                        }
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
        }

        private void                                    MSession_Notification(Session aSession, NotificationEventArgs aNotificationEventArgs)
        {
            if (mConnected == false || mItemList.Count == 0) return;

            var lMessage = aNotificationEventArgs.NotificationMessage;
            if (lMessage.NotificationData.Count == 0) return;

            var lDataChanges = lMessage.GetDataChanges(false);
            if (lDataChanges.Count == 0) return;

            Task.Factory.StartNew(() => NotificationReceived(lDataChanges));
        }

        private void                                    MSession_PublishError(Session aSession, PublishErrorEventArgs aPublishErrorEventArgs)
        {
            if (mConnected == false || mItemList.Count == 0) return;

            raiseConnectionError("Server publish error '" + aPublishErrorEventArgs.Status.ToString() + "'. ");
            disconnect();
        }

        private OPCNodesBrowserForm                     mOPCNodeBrowserForm;
        public OPCNodesBrowserForm                      OPCNodeBrowserForm
        {
            get
            {
                if (mOPCNodeBrowserForm == null)
                {
                    mOPCNodeBrowserForm = new OPCNodesBrowserForm(this);
                }

                return mOPCNodeBrowserForm;
            }
        }

        public DataValueCollection                      readAttribute(NodeId aNodeId, uint aAttribute)
        {
            var lAttributeToRead            = new ReadValueId();
            lAttributeToRead.NodeId         = aNodeId;
            lAttributeToRead.AttributeId    = aAttribute;

            var lValueIdsToRead = new ReadValueIdCollection();
            lValueIdsToRead.Add(lAttributeToRead);

            DataValueCollection lResults                = null;
            DiagnosticInfoCollection lDiagnosticInfos   = null;

            var lResponse = mSession.Read(null, 0, TimestampsToReturn.Neither, lValueIdsToRead, out lResults, out lDiagnosticInfos);

            if((lResults.Count != 1) || (lResults[0].Value == null))
            {
                return null;
            }

            return lResults;
        }

        public void                                     writeAttribute(NodeId aNodeId, uint aAttribute, object aValue)
        {
            StatusCodeCollection lResult                = null;
            DiagnosticInfoCollection lDiagnosticInfos   = null;

            var lValuesToWrite              = new WriteValueCollection();
            var lAttributeToWrite           = new WriteValue();
            lAttributeToWrite.NodeId        = aNodeId;
            lAttributeToWrite.AttributeId   = Attributes.Value;
            lAttributeToWrite.Value         = new DataValue(new Variant(aValue));
            lValuesToWrite.Add(lAttributeToWrite);
        
            mSession.Write(null, lValuesToWrite, out lResult, out lDiagnosticInfos);

            if (StatusCode.IsBad(lResult[0]))
            {
                throw new InvalidOperationException(StatusCode.LookupSymbolicId(lResult[0].Code));
            }
        }

        private string[]                                getNamespaces()
        {
            var lResults = readAttribute(new NodeId(Variables.Server_NamespaceArray), Attributes.Value);

            if ((lResults == null) || (lResults[0].Value.GetType() != typeof(string[])))
            {
                throw new InvalidOperationException("Reading namespace table returned unexptected result. ");
            }

            return (string[])lResults[0].Value;
        }

        public event EventHandler                       ConnectionState;
        private void                                    raiseConnectionState()
        {
            ConnectionState?.Invoke(this, EventArgs.Empty);
        }

        private string                                  mLastError = "";
        public string                                   LastError
        {
            get
            {
                return mLastError;
            }
        }
        public event EventHandler<MessageStringEventArgs> ConnectionError;
        private void                                    raiseConnectionError(string aMessage)
        {
            mLastError = aMessage;
            ConnectionError?.Invoke(this, new MessageStringEventArgs(aMessage));
        }

        #region Items

            public string[]                             mNamespaces;
            private List<DataItem>                      mItemList       = new List<DataItem>();
            private ReaderWriterLockSlim                mItemListLock   = new ReaderWriterLockSlim();  

            private void                                addItemToSubscription(DataItem aItem)
            {
                var lMonitoredItem              = new MonitoredItem(mSubscription.DefaultItem);
                lMonitoredItem.StartNodeId      = aItem.mNodeId;
                lMonitoredItem.AttributeId      = Attributes.Value;
                lMonitoredItem.MonitoringMode   = MonitoringMode.Reporting;
                lMonitoredItem.SamplingInterval = aItem.mSampling;
                lMonitoredItem.QueueSize        = 1;
                lMonitoredItem.DiscardOldest    = true;
                lMonitoredItem.Handle           = aItem;
                aItem.mClientHandle             = lMonitoredItem.ClientHandle;

                mSubscription.AddItem(lMonitoredItem);
                mSubscription.ApplyChanges();
                if (lMonitoredItem.Status.Error != null && StatusCode.IsBad(lMonitoredItem.Status.Error.StatusCode))
                {
                    lMonitoredItem.Handle = null;
                    mSubscription.RemoveItem(lMonitoredItem);
                    mSubscription.ApplyChanges();
                    throw new InvalidOperationException("Creation of data monitored item failed. ");
                }
            }

            private void                                removeItemFromSubscription(DataItem aItem)
            {
                var lMonitoredItem = mSubscription.FindItemByClientHandle(aItem.mClientHandle);
                if (lMonitoredItem != null)
                { 
                    mSubscription.RemoveItem(lMonitoredItem);
                    mSubscription.ApplyChanges();
                    lMonitoredItem.Handle = null;
                }
            }

            private ReadValueIdCollection               mReadValueIdCollection;
            private void                                checkVariable(NodeId aNodeId, out byte aAccess, out object aValue, out StatusCode aStatusCode, out string aType, out bool aArray)
            {
                DataValueCollection lResults                = null;
                DiagnosticInfoCollection lDiagnosticInfos   = null;

                if(mReadValueIdCollection == null)
                { 
                    mReadValueIdCollection = new ReadValueIdCollection();

                    var lAttributeToRead            = new ReadValueId();
                    lAttributeToRead.AttributeId    = Attributes.NodeId;
                    mReadValueIdCollection.Add(lAttributeToRead);

                    lAttributeToRead                = new ReadValueId();
                    lAttributeToRead.AttributeId    = Attributes.NodeClass;
                    mReadValueIdCollection.Add(lAttributeToRead);

                    lAttributeToRead                = new ReadValueId();
                    lAttributeToRead.AttributeId    = Attributes.UserAccessLevel;
                    mReadValueIdCollection.Add(lAttributeToRead);

                    lAttributeToRead                = new ReadValueId();
                    lAttributeToRead.AttributeId    = Attributes.Value;

                    mReadValueIdCollection.Add(lAttributeToRead);

                    lAttributeToRead                = new ReadValueId();
                    lAttributeToRead.AttributeId    = Attributes.DataType;

                    mReadValueIdCollection.Add(lAttributeToRead);

                    lAttributeToRead                = new ReadValueId();
                    lAttributeToRead.AttributeId    = Attributes.ValueRank;
                    mReadValueIdCollection.Add(lAttributeToRead);
                } 

                foreach(var lReadValueId in mReadValueIdCollection)
                {
                    lReadValueId.NodeId = aNodeId;
                }

                var lResponse = mSession.Read(null, 0, TimestampsToReturn.Neither, mReadValueIdCollection, out lResults, out lDiagnosticInfos);

                if(lResults.Count != 6)
                {
                    throw new InvalidOperationException("Reading node attributes returned unexptected result. ");
                }

                if (lResults[0].Value.GetType() != typeof(NodeId))
                {
                    throw new InvalidOperationException("NodeId is wrong. ");
                }

                if (lResults[1].Value.GetType() != typeof(int))
                {
                    throw new InvalidOperationException("Reading node class returned unexptected result. ");
                }
                if ((NodeClass)lResults[1].Value != NodeClass.Variable)
                {
                    throw new InvalidOperationException("Node is not a variable. ");
                }

                if (lResults[2].Value.GetType() != typeof(byte))
                {
                    throw new InvalidOperationException("Reading item access level returned unexptected result. ");
                }
                aAccess = (byte)lResults[2].Value;

                aValue      = null;
                aStatusCode = lResults[3].StatusCode;
                aType       = null;
                aArray      = false;

                if ((aAccess == AccessLevels.CurrentRead || aAccess == AccessLevels.CurrentReadOrWrite) && StatusCode.IsGood(aStatusCode) && lResults[3].Value != null)
                {
                    object lValue   = lResults[3].Value;
                    Type lType      = lValue.GetType();
                    if (StringUtils.isTypeSupported(lType) == false)
                    {
                        throw new ArgumentException("Type '" + lType.Name + "' is not supported. ");
                    }

                    aValue = lValue;
                }
                else
                {
                    if (lResults[4].Value.GetType() != typeof(NodeId))
                    {
                        throw new InvalidOperationException("Reading item datatype returned unexptected result. ");
                    }
                    aType = mSession.NodeCache.Find((NodeId)lResults[4].Value).ToString();
                    if (aType.Equals("Float", StringComparison.Ordinal))
                    {
                        aType = "Single";
                    }
                    if (StringUtils.isTypeSupported(aType) == false)
                    {
                        throw new ArgumentException("Type '" + aType + "' is not supported. ");
                    }

                    if (lResults[5].Value.GetType() != typeof(int))
                    {
                        throw new InvalidOperationException("Reading item value rank returned unexptected result. ");
                    }
                    int lValueRank  = (int)lResults[5].Value;
                    aArray          = false;
                    if (lValueRank == ValueRanks.OneDimension)
                    {
                        aArray = true;
                    }
                    else if (lValueRank != ValueRanks.Scalar)
                    {
                        throw new ArgumentException("Only scalar or one dimension array is supported. ");
                    }
                }
            }

            public DataItem                             addItem(string aNodeId, int aSampling)
            {
                if(String.IsNullOrWhiteSpace(aNodeId))
                {
                    throw new ArgumentException("Item NodeId is empty. ");
                }

                DataItem lItem      = new DataItem();

                lItem.mConnection   = this;
                lItem.mSampling     = aSampling;
                lItem.mNodeId       = new NodeId(aNodeId);

                if (mConnected)
                {
                    byte lAccess;
                    object lValue;
                    StatusCode lStatusCode;
                    string lType;
                    bool lArray;

                    checkVariable(lItem.mNodeId, out lAccess, out lValue, out lStatusCode, out lType, out lArray);

                    lItem.setAccess(lAccess);
                    lItem.StatusCode = lStatusCode; 

                    if ((lAccess == AccessLevels.CurrentRead || lAccess == AccessLevels.CurrentReadOrWrite) && StatusCode.IsGood(lStatusCode) && lValue != null)
                    {
                        lItem.mValue = lValue;
                    }
                    else
                    {
                        lItem.initValue(lType, lArray);
                    }
                }

                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    if (mConnected)
                    {
                        addItemToSubscription(lItem);
                    }

                    mItemList.Add(lItem);
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }

                lItem.raisePropertiesChanged();
                if (lItem.Access.HasFlag(EAccess.READ))
                {
                    lItem.raiseValueChanged();
                }

                ConnectionState += new EventHandler(lItem.onConnectionStateChanged);

                return lItem;
            }

            public void                                 modifyItem(DataItem aItem, string aNewNodeId, int aNewSampling)
            {
                bool lChange = false;

                if(aItem.mNodeId.ToString().Equals(aNewNodeId, StringComparison.Ordinal) == false)
                {
                    NodeId lNewNodeId = new NodeId(aNewNodeId);

                    if (Connected)
                    {
                        byte lAccess;
                        object lValue;
                        StatusCode lStatusCode;
                        string lType;
                        bool lArray;

                        checkVariable(lNewNodeId, out lAccess, out lValue, out lStatusCode, out lType, out lArray);

                        mItemListLock.EnterWriteLock();
                        //========================================
                        try
                        {
                            removeItemFromSubscription(aItem);
                            aItem.mNodeId = lNewNodeId;
                            addItemToSubscription(aItem);

                            aItem.setAccess(lAccess);
                            aItem.StatusCode = lStatusCode;                        

                            if((lAccess == AccessLevels.CurrentRead || lAccess == AccessLevels.CurrentReadOrWrite) && StatusCode.IsGood(lStatusCode) && lValue != null)
                            {
                                aItem.mValue = lValue;
                            }
                            else
                            {
                                aItem.initValue(lType, lArray);
                            }
                        }
                        finally
                        {
                            //========================================
                            mItemListLock.ExitWriteLock();
                        }

                    }
                    else
                    {
                        aItem.mNodeId = lNewNodeId;
                    }

                    lChange = true;
                }

                if(aItem.mSampling != aNewSampling)
                {
                    aItem.mSampling                                                             = aNewSampling;
                    mSubscription.FindItemByClientHandle(aItem.mClientHandle).SamplingInterval  = aNewSampling;
                    mSubscription.ApplyChanges();
                    lChange = true;
                }

                if(lChange)
                {
                    aItem.raisePropertiesChanged();
                    if (aItem.Access.HasFlag(EAccess.READ))
                    {
                        aItem.raiseValueChanged();
                    }
                }
            }

            public void                                 removeItem(DataItem aItem)
            {
                ConnectionState -= aItem.onConnectionStateChanged;

                mItemListLock.EnterWriteLock();
                //========================================
                try
                {
                    if (mConnected)
                    {
                        removeItemFromSubscription(aItem);
                    }

                    mItemList.Remove(aItem);
                }
                finally
                {
                    //========================================
                    mItemListLock.ExitWriteLock();
                }

                aItem.mConnection   = null;
            }

            public int                                  NumberOfItems
            {
                get
                {
                    return mItemList.Count;
                }
            }

        #endregion

        #region IDisposable

            private bool                                mDisposed = false;

            public void                                 Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void                      Dispose(bool aDisposing)
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

                        clearSession();
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}