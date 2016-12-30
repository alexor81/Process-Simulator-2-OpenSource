// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Connection.S7IsoTCP
{
    public class Factory : ICommunicationFactory
    {
        #region Connection

            public bool             isPossibleToCreateConnection(out string aError)
            {
                aError = "";
                return true;
            }

            public IConnection      createFromXML(XmlTextReader aXMLTextReader)
            {
                var lConnection                     = new Connection();
                var lReader                         = new XMLAttributeReader(aXMLTextReader);

                lConnection.mIP                     = CommunicationUtils.checkTCP_IP(lReader.getAttribute<String>("IP"));
                lConnection.Rack                    = (int)lReader.getAttribute<UInt32>("Rack", (uint)lConnection.Rack);
                lConnection.Slot                    = (int)lReader.getAttribute<UInt32>("Slot", (uint)lConnection.Slot);
                lConnection.mConnectionType         = (EConnectionType)Enum.Parse(typeof(EConnectionType), lReader.getAttribute<String>("Type", lConnection.mConnectionType.ToString()));

                lConnection.Slowdown                = lReader.getAttribute<UInt32>("Slowdown", lConnection.Slowdown);
                lConnection.mErrorsBeforeDisconnect = lReader.getAttribute<UInt32>("ErrorsBeforeDisconnect", lConnection.mErrorsBeforeDisconnect);

                return lConnection;
            }

            public IConnection      createByForm(IWin32Window aOwner)
            {
                var lConnection = new Connection();
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
                using (var lSetupForm = new ConnectionSetupForm((Connection)aConnection, false))
                {
                    lSetupForm.ShowDialog(aOwner);
                }
            }

            public void             saveToXML(IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                var lConnection = (Connection)aConnection;

                aXMLTextWriter.WriteAttributeString("IP", lConnection.mIP);
                aXMLTextWriter.WriteAttributeString("Rack", StringUtils.ObjectToString(lConnection.Rack));
                aXMLTextWriter.WriteAttributeString("Slot", StringUtils.ObjectToString(lConnection.Slot));
                aXMLTextWriter.WriteAttributeString("Type", lConnection.mConnectionType.ToString());

                aXMLTextWriter.WriteAttributeString("Slowdown", StringUtils.ObjectToString(lConnection.Slowdown));
                aXMLTextWriter.WriteAttributeString("ErrorsBeforeDisconnect", StringUtils.ObjectToString(lConnection.mErrorsBeforeDisconnect));
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
                var lConnection = (Connection)aConnection;
                var lItem       = new DataItem();
                var lReader     = new XMLAttributeReader(aXMLTextReader);

                lItem.mMemoryType = (EArea)Enum.Parse(typeof(EArea), lReader.getAttribute<String>("MemoryType"));
                if (lItem.mMemoryType == EArea.DB)
                {
                    lItem.DB = (int)lReader.getAttribute<UInt32>("DB");
                }

                lItem.DataType = (EWordlen)Enum.Parse(typeof(EWordlen), lReader.getAttribute<String>("DataType"));
                lItem.Byte = (int)lReader.getAttribute<UInt32>("Byte");

                if (lItem.DataType == EWordlen.S7_Bit)
                {
                    lItem.Bit = (int)lReader.getAttribute<UInt32>("Bit");
                }
                else if (lItem.DataType == EWordlen.S7_Byte || lItem.DataType == EWordlen.S7_Word)
                {
                    lItem.Signed = lReader.getAttribute<Boolean>("Signed", lItem.Signed);
                }
                else if (lItem.DataType == EWordlen.S7_DoubleWord)
                {
                    lItem.FloatingP = lReader.getAttribute<Boolean>("FloatingPoint", lItem.FloatingP);
                    if (lItem.FloatingP == false)
                    {
                        lItem.Signed = lReader.getAttribute<Boolean>("Signed", lItem.Signed);
                    }
                }

                if (lItem.DataType != EWordlen.S7_Bit)
                {
                    lItem.Length = (int)lReader.getAttribute<UInt32>("Length", 1);
                }

                lConnection.addItem(lItem);

                return lItem;
            }

            public IDataItem        createByForm(IConnection aConnection, IWin32Window aOwner)
            {
                var lConnection = (Connection)aConnection;
                var lItem       = new DataItem();

                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.OK)
                    {
                        lItem.mMemoryType   = lSetupForm.MemoryType;
                        lItem.DataType      = lSetupForm.DataType;
                        lItem.DB            = lSetupForm.DB;
                        lItem.Byte          = lSetupForm.Byte;
                        lItem.Bit           = lSetupForm.Bit;
                        lItem.FloatingP     = lSetupForm.FloatingP;
                        lItem.Signed        = lSetupForm.Signed;
                        lItem.Length        = lSetupForm.Length;

                        lConnection.addItem(lItem);
                    }
                    else
                    {
                        lItem = null;
                    }
                }

                return lItem;
            }

            public void             setupByForm(IDataItem aDataItem, IConnection aConnection, IWin32Window aOwner)
            {
                var lConnection = (Connection)aConnection;
                var lItem       = (DataItem)aDataItem;
                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.OK)
                    {
                        lConnection.removeItem(lItem);
                        lConnection.waitCycleEnd();

                        lItem.mMemoryType   = lSetupForm.MemoryType;
                        lItem.DataType      = lSetupForm.DataType;
                        lItem.DB            = lSetupForm.DB;
                        lItem.Byte          = lSetupForm.Byte;
                        lItem.Bit           = lSetupForm.Bit;
                        lItem.FloatingP     = lSetupForm.FloatingP;
                        lItem.Signed        = lSetupForm.Signed;
                        lItem.Length        = lSetupForm.Length;
                        lConnection.addItem(lItem);


                        lConnection.waitCycleEnd();
                        lItem.raisePropertiesChanged();
                        if (lConnection.Connected && lItem.Access.HasFlag(EAccess.READ))
                        {
                            lItem.raiseValueChanged();
                        }
                    }
                }
            }

            public void             saveToXML(IDataItem aDataItem, IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                DataItem lItem = (DataItem)aDataItem;

                aXMLTextWriter.WriteAttributeString("MemoryType", lItem.mMemoryType.ToString());
                if (lItem.mMemoryType == EArea.DB)
                {
                    aXMLTextWriter.WriteAttributeString("DB", StringUtils.ObjectToString(lItem.DB));
                }

                aXMLTextWriter.WriteAttributeString("DataType", lItem.DataType.ToString());
                aXMLTextWriter.WriteAttributeString("Byte", StringUtils.ObjectToString(lItem.Byte));

                if (lItem.DataType == EWordlen.S7_Bit)
                {
                    aXMLTextWriter.WriteAttributeString("Bit", StringUtils.ObjectToString(lItem.Bit));
                }
                else if (lItem.DataType == EWordlen.S7_Byte || lItem.DataType == EWordlen.S7_Word)
                {
                    aXMLTextWriter.WriteAttributeString("Signed", StringUtils.ObjectToString(lItem.Signed));
                }
                else if (lItem.DataType == EWordlen.S7_DoubleWord)
                {
                    aXMLTextWriter.WriteAttributeString("FloatingPoint", StringUtils.ObjectToString(lItem.FloatingP));
                    if (lItem.FloatingP == false)
                    {
                        aXMLTextWriter.WriteAttributeString("Signed", StringUtils.ObjectToString(lItem.Signed));
                    }
                }

                if (lItem.DataType != EWordlen.S7_Bit)
                {
                    if (lItem.Length > 1)
                    {
                        aXMLTextWriter.WriteAttributeString("Length", StringUtils.ObjectToString(lItem.Length));
                    }
                }
            }

            public void             destroyDataItem(IDataItem aDataItem, IConnection aConnection)
            {
                ((Connection)aConnection).removeItem((DataItem)aDataItem);
            }

        #endregion
    }
}
