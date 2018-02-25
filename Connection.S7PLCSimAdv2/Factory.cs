// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.S7PLCSimAdv2
{
    public class Factory: ICommunicationFactory
    {
        #region Connection

            public bool             isPossibleToCreateConnection(out string aError)
            {       
                try
                {
                    if (SimulationRuntimeManager.IsRuntimeManagerAvailable == false)
                    {
                        aError = "Simulation Runtime Manager is not available. ";
                        return false;
                    }

                    if (SimulationRuntimeManager.IsInitialized == false)
                    {
                        aError = "Simulation Runtime Manager is not initialized. ";
                        return false;
                    }
                    
                    aError = "";
                    return true;
                }
                catch (Exception lExc)
                {
                    aError = lExc.Message;
                    return false;
                }
            }

            public IConnection      createFromXML(XmlTextReader aXMLTextReader)
            {
                var lConnection     = new Connection();
                var lReader         = new XMLAttributeReader(aXMLTextReader);

                lConnection.mRemote = lReader.getAttribute<Boolean>("Remote", lConnection.mRemote);

                if (lConnection.mRemote)
                {
                    lConnection.IP      = lReader.getAttribute<String>("IP");
                    lConnection.IPPort  = lReader.getAttribute<Int32>("IPPort", lConnection.IPPort);
                }

                lConnection.mPLCName = lReader.getAttribute<String>("PLC");

                return lConnection;
            }

            public IConnection      createByForm(IWin32Window aOwner)
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

            public void             setupByForm(IConnection aConnection, IWin32Window aOwner)
            {
                Connection lConnection = (Connection)aConnection;
                using (var lSetupForm = new ConnectionSetupForm(lConnection, false))
                {
                    lSetupForm.ShowDialog(aOwner);
                }
            }

            public void             saveToXML(IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                Connection lConnection = (Connection)aConnection;

                aXMLTextWriter.WriteAttributeString("Remote", StringUtils.ObjectToString(lConnection.mRemote));

                if (lConnection.mRemote)
                {
                    aXMLTextWriter.WriteAttributeString("IP", lConnection.IP);
                    aXMLTextWriter.WriteAttributeString("IPPort", StringUtils.ObjectToString(lConnection.IPPort));
                }

                aXMLTextWriter.WriteAttributeString("PLC", lConnection.mPLCName);
            }

            public void             destroyConnection(IConnection aConnection)
            {
                ((Connection)aConnection).Dispose();
            }

        #endregion

        #region DataItem

            public bool             isPossibleToCreateDataItem(IConnection aConnection, out string aError)
            {
                aError = "";
                return true;
            }

            public IDataItem        createFromXML(IConnection aConnection, XmlTextReader aXMLTextReader)
            {
                Connection lConnection      = (Connection)aConnection;
                XMLAttributeReader lReader  = new XMLAttributeReader(aXMLTextReader);
                return lConnection.addItem(lReader.getAttribute<String>("TagName"));
            }

            public IDataItem        createByForm(IConnection aConnection, IWin32Window aOwner)
            {
                Connection lConnection  = (Connection)aConnection;
                DataItem lItem          = null;

                using (var lSetupForm = new ItemSetupForm(lConnection, ""))
                {
                    do
                    {
                        try
                        {
                            lSetupForm.ShowDialog(aOwner);
                            if (lSetupForm.DialogResult == DialogResult.OK)
                            {
                                lItem = lConnection.addItem(lSetupForm.TagName);
                            }
                        }
                        catch (Exception lExc)
                        {
                            Log.Error("Error while user was creating new data item for PLC '"
                                        + lConnection.mPLCName + "'. " + lExc.Message, lExc.ToString());
                            MessageForm.showMessage(lExc.Message, aOwner);
                        }
                    }
                    while (lSetupForm.DialogResult == DialogResult.OK && lItem == null);
                }

                return lItem;
            }

            public void             setupByForm(IDataItem aDataItem, IConnection aConnection, IWin32Window aOwner)
            {
                DataItem lItem          = (DataItem)aDataItem;
                Connection lConnection  = (Connection)aConnection;
                bool lModified          = false;

                using (var lSetupForm = new ItemSetupForm(lConnection, lItem.mTagName))
                {
                    do
                    {
                        lSetupForm.ShowDialog(aOwner);
                        if (lSetupForm.DialogResult == DialogResult.OK)
                        {
                            try
                            {
                                lConnection.modifyItem(lItem, lSetupForm.TagName);
                                lModified = true;
                            }
                            catch (Exception lExc)
                            {
                                Log.Error("Error while user was configuring data item for PLC '"
                                    + lConnection.mPLCName + "'. " + lExc.Message, lExc.ToString());
                                MessageForm.showMessage(lExc.Message, aOwner);
                            }
                        }
                    }
                    while (lSetupForm.DialogResult == DialogResult.OK && lModified == false);
                }
            }

            public void             saveToXML(IDataItem aDataItem, IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("TagName", ((DataItem)aDataItem).mTagName);
            }

            public void             destroyDataItem(IDataItem aDataItem, IConnection aConnection)
            {
                ((Connection)aConnection).removeItem((DataItem)aDataItem);
            }

        #endregion
    }
}
