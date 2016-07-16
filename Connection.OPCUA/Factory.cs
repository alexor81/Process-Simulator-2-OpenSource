using API;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.OPCUA
{
    public class Factory : ICommunicationFactory
    {
        #region Connection

            public bool         isPossibleToCreateConnection(out string aError)
            {
                aError = "";
                return true;
            }

            public IConnection  createFromXML(XmlTextReader aXMLTextReader)
            {
                Connection lConnection      = new Connection();
                XMLAttributeReader lReader  = new XMLAttributeReader(aXMLTextReader);

                lConnection.mDiscovery          = lReader.getAttribute<String>("Discovery", lConnection.mDiscovery);
                lConnection.mServerName         = lReader.getAttribute<String>("ServerName", lConnection.mServerName);
                lConnection.Transport           = lReader.getAttribute<String>("Transport", lConnection.Transport);
                lConnection.mPublishingInterval = (int)lReader.getAttribute<UInt32>("PublishingInterval", (uint)lConnection.mPublishingInterval);

                List<string> lNamespaces = new List<string>();
                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("Namespaces", StringComparison.Ordinal))
                {
                    aXMLTextReader.Read();

                    while (aXMLTextReader.Name.Equals("Namespace", StringComparison.Ordinal) && aXMLTextReader.IsStartElement())
                    {
                        lNamespaces.Add(aXMLTextReader.ReadElementContentAsString());
                    }
                }
                lConnection.mNamespaces = lNamespaces.ToArray();

                return lConnection;
            }

            public IConnection  createByForm(IWin32Window aOwner)
            {
                Connection lConnection = new Connection();
                using (var lSetupForm = new ConnectionSetupForm(lConnection, true))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.Cancel)
                    {
                        if (lConnection.Connected)
                        {
                            lConnection.disconnect();
                        }
                        lConnection.Dispose();
                        lConnection = null;
                    }
                }
                return lConnection;
            }

            public void         setupByForm(IConnection aConnection, IWin32Window aOwner)
            {
                Connection lConnection = (Connection)aConnection;
                using (var lSetupForm = new ConnectionSetupForm(lConnection, false))
                {
                    lSetupForm.ShowDialog(aOwner);
                }
            }

            public void         saveToXML(IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                Connection lConnection = (Connection)aConnection;
                
                aXMLTextWriter.WriteAttributeString("Discovery", lConnection.mDiscovery);
                aXMLTextWriter.WriteAttributeString("ServerName", lConnection.mServerName);
                aXMLTextWriter.WriteAttributeString("Transport", lConnection.Transport);
                aXMLTextWriter.WriteAttributeString("PublishingInterval", StringUtils.ObjectToString(lConnection.mPublishingInterval));

                aXMLTextWriter.WriteStartElement("Namespaces");

                    for (int i = 0; i < lConnection.mNamespaces.Length; i++)
                    {
                        aXMLTextWriter.WriteStartElement("Namespace");
                        aXMLTextWriter.WriteString(lConnection.mNamespaces[i]);
                        aXMLTextWriter.WriteEndElement();
                    }

                aXMLTextWriter.WriteEndElement();
            }

            public void         destroyConnection(IConnection aConnection)
            {
                ((Connection)aConnection).Dispose();
            }

        #endregion

        #region DataItem

            public bool         isPossibleToCreateDataItem(IConnection aConnection, out string aError)
            {
                aError = "";
                return true;
            }

            public IDataItem    createFromXML(IConnection aConnection, XmlTextReader aXMLTextReader)
            {
                var lConnection = (Connection)aConnection;
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                return lConnection.addItem(lReader.getAttribute<String>("NodeId"), lReader.getAttribute<Int32>("Sampling", 100));
            }

            public IDataItem    createByForm(IConnection aConnection, IWin32Window aOwner)
            {
                var lConnection     = (Connection)aConnection;
                DataItem lItem      = null;

                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    do
                    {
                        try
                        {
                            lSetupForm.ShowDialog(aOwner);
                            if (lSetupForm.DialogResult == DialogResult.OK)
                            {
                                lItem = lConnection.addItem(lSetupForm.NodeId, lSetupForm.Sampling);
                            }
                        }
                        catch (Exception lExc)
                        {
                            Log.Error("Error while user was creating new data item from OPC UA server '"
                                        + lConnection.mServerName + "' at host '" + lConnection.mHost + "'. " + lExc.Message, lExc.ToString());
                            MessageForm.showMessage(lExc.Message, aOwner);
                        }
                    }
                    while (lSetupForm.DialogResult == DialogResult.OK && lItem == null);
                }

                return lItem;
            }

            public void         setupByForm(IDataItem aDataItem, IConnection aConnection, IWin32Window aOwner)
            {
                var lItem       = (DataItem)aDataItem;
                var lConnection = (Connection)aConnection;
                bool lModified  = false;

                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    do
                    {
                        lSetupForm.ShowDialog(aOwner);
                        if (lSetupForm.DialogResult == DialogResult.OK)
                        {
                            try
                            {
                                lConnection.modifyItem(lItem, lSetupForm.NodeId, lSetupForm.Sampling);
                                lModified = true;
                            }
                            catch (Exception lExc)
                            {
                                Log.Error("Error while user was configuring data item from OPC UA server '"
                                        + lConnection.mServerName + "' at host '" + lConnection.mHost + "'. " + lExc.Message, lExc.ToString());
                                MessageForm.showMessage(lExc.Message, aOwner);
                            }
                        }
                    }
                    while (lSetupForm.DialogResult == DialogResult.OK && lModified == false);
                }
            }

            public void         saveToXML(IDataItem aDataItem, IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                DataItem lItem = (DataItem)aDataItem;

                aXMLTextWriter.WriteAttributeString("NodeId", lItem.mNodeId.ToString());
                aXMLTextWriter.WriteAttributeString("Sampling", StringUtils.ObjectToString(lItem.mSampling));
            }

            public void         destroyDataItem(IDataItem aDataItem, IConnection aConnection)
            {
                ((Connection)aConnection).removeItem((DataItem)aDataItem);
            }

        #endregion
    }
}
