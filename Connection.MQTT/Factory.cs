using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.MQTT
{
    public class Factory: ICommunicationFactory
    {
        #region Connection

            public bool                 isPossibleToCreateConnection(out string aError)
            {
                aError = "";
                return true;
            }

            public IConnection          createFromXML(XmlTextReader aXMLTextReader)
            {
                var lConnection         = new Connection();
                var lReader             = new XMLAttributeReader(aXMLTextReader);

                lConnection.mHost       = lReader.getAttribute<String>("BrokerHost", lConnection.mHost);
                lConnection.mPort       = (int)lReader.getAttribute<UInt32>("BrokerPort", (uint)lConnection.mPort);
                lConnection.mKeepAlive  = lReader.getAttribute<UInt16>("KeepAlive", lConnection.mKeepAlive);
                lConnection.QOS         = lReader.getAttribute<Byte>("QoS", lConnection.QOS);
                lConnection.Protocol    = lReader.getAttribute<String>("Protocol", "Version_3_1_1");
                lConnection.Root        = lReader.getAttribute<String>("Root", lConnection.Root);
                lConnection.mLogin      = lReader.getAttribute<String>("Login", lConnection.mLogin);
                lConnection.mPassword   = lReader.getAttribute<String>("Password", lConnection.mPassword);

                return lConnection;
            }

            public IConnection          createByForm(IWin32Window aOwner)
            {
                Connection lConnection = new Connection();
                using (var lSetupForm = new ConnectionSetupForm(lConnection, true))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.Cancel)
                    {
                        lConnection = null;
                    }
                }
                return lConnection;      
            }

            public void                 setupByForm(IConnection aConnection, IWin32Window aOwner)
            {
                using (var lSetupForm = new ConnectionSetupForm((Connection)aConnection, false))
                {
                    lSetupForm.ShowDialog(aOwner);
                }
            }

            public void                 saveToXML(IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                Connection lConnection = (Connection)aConnection;

                aXMLTextWriter.WriteAttributeString("BrokerHost", lConnection.mHost);
                aXMLTextWriter.WriteAttributeString("BrokerPort", StringUtils.ObjectToString(lConnection.mPort));
                aXMLTextWriter.WriteAttributeString("KeepAlive", StringUtils.ObjectToString(lConnection.mKeepAlive));
                aXMLTextWriter.WriteAttributeString("QoS", StringUtils.ObjectToString(lConnection.QOS));
                aXMLTextWriter.WriteAttributeString("Protocol", lConnection.Protocol);
                aXMLTextWriter.WriteAttributeString("Root", lConnection.Root);
                aXMLTextWriter.WriteAttributeString("Login", lConnection.mLogin);
                aXMLTextWriter.WriteAttributeString("Password", lConnection.mPassword);
            }

            public void                 destroyConnection(IConnection aConnection)
            {
                ((Connection)aConnection).Dispose();
            }

        #endregion

        #region DataItem

            public bool                 isPossibleToCreateDataItem(IConnection aConnection, out string aError)
            {
                aError = "";
                return true;
            }

            public IDataItem            createFromXML(IConnection aConnection, XmlTextReader aXMLTextReader)
            {
                var lConnection = (Connection)aConnection;
                var lReader     = new XMLAttributeReader(aXMLTextReader);

                string lTopic   = lReader.getAttribute<String>("Topic");
                bool lSubscribe = lReader.getAttribute<Boolean>("Subscribe", true);
                bool lPublish   = lReader.getAttribute<Boolean>("Publish", true);
                string lValue   = lReader.getAttribute<String>("Value", "");

                return lConnection.addItem(lTopic, lSubscribe, lPublish, lValue);
            }

            public IDataItem            createByForm(IConnection aConnection, IWin32Window aOwner)
            {
                Connection lConnection  = (Connection)aConnection;
                DataItem lItem          = new DataItem();
                bool lCreated           = false;

                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    do
                    {
                        try
                        {
                            lSetupForm.ShowDialog(aOwner);
                            if (lSetupForm.DialogResult == DialogResult.OK)
                            {
                                lItem       = lConnection.addItem(lSetupForm.Topic, lSetupForm.Subscribe, lSetupForm.Publish, "");
                                lCreated    = true;
                            }
                            else
                            {
                                lItem = null;
                            }
                        }
                        catch (Exception lExc)
                        {
                            Log.Error("Error while user was creating new data item for MQQT broker '"
                                        + lConnection.mHost + ":" + lConnection.mPort + "'. " + lExc.Message, lExc.ToString());
                            MessageForm.showMessage(lExc.Message, aOwner);
                        }
                    }
                    while (lSetupForm.DialogResult == DialogResult.OK && lCreated == false);
                }

                return lItem;
            }

            public void                 setupByForm(IDataItem aDataItem, IConnection aConnection, IWin32Window aOwner)
            {
                DataItem lItem          = (DataItem)aDataItem;
                Connection lConnection  = (Connection)aConnection;
                bool lModified          = false;

                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    do
                    {
                        lSetupForm.ShowDialog(aOwner);
                        if (lSetupForm.DialogResult == DialogResult.OK)
                        {
                            try
                            {
                                lConnection.modifyItem(lItem, lSetupForm.Topic, lSetupForm.Subscribe, lSetupForm.Publish);
                                lModified = true;
                            }
                            catch (Exception lExc)
                            {
                                Log.Error("Error while user was configuring data item for MQQT broker '"
                                        + lConnection.mHost + ":" + lConnection.mPort + "'. " + lExc.Message, lExc.ToString());
                                MessageForm.showMessage(lExc.Message, aOwner);
                            }
                        }
                    }
                    while (lSetupForm.DialogResult == DialogResult.OK && lModified == false);
                }
        }

            public void                 saveToXML(IDataItem aDataItem, IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                Connection lConnection  = (Connection)aConnection;
                DataItem lItem          = (DataItem)aDataItem;

                aXMLTextWriter.WriteAttributeString("Topic", lItem.mTopic);
                aXMLTextWriter.WriteAttributeString("Subscribe", StringUtils.ObjectToString(lItem.Subscribe));
                aXMLTextWriter.WriteAttributeString("Publish", StringUtils.ObjectToString(lItem.Publish));
                aXMLTextWriter.WriteAttributeString("Value", lItem.mValue);
            }

            public void                 destroyDataItem(IDataItem aDataItem, IConnection aConnection)
            {
                ((Connection)aConnection).removeItem((DataItem)aDataItem);
            }

        #endregion
    }
}
