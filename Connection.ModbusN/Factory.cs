// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Connection.ModbusN
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
                var lConnection = new Connection();
                var lReader     = new XMLAttributeReader(aXMLTextReader);

                lConnection.mTransport  = (ETransportType)Enum.Parse(typeof(ETransportType), lReader.getAttribute<String>("Transport"));

                if (lConnection.mTransport == ETransportType.TCP)
                {
                    lConnection.IP      = lReader.getAttribute<String>("IP");
                    lConnection.IPPort  = lReader.getAttribute<Int32>("IPPort");
                }
                else if (lConnection.mTransport == ETransportType.SERIAL)
                {
                    lConnection.COMPort     = lReader.getAttribute<String>("Port");
                    lConnection.Baud        = lReader.getAttribute<Int32>("Baud");
                    lConnection.DataBits    = lReader.getAttribute<Int32>("DataBits");
                    lConnection.mParity     = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), lReader.getAttribute<String>("Parity"));
                    lConnection.mStopBits   = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), lReader.getAttribute<String>("StopBits"));
                    lConnection.mProtocol   = (EProtocol)Enum.Parse(typeof(EProtocol), lReader.getAttribute<String>("Protocol"));
                }

                lConnection.TimeoutMS               = lReader.getAttribute<UInt32>("Timeout", lConnection.TimeoutMS);
                lConnection.mErrorsBeforeDisconnect = lReader.getAttribute<UInt32>("ErrorsBeforeDisconnect", lConnection.mErrorsBeforeDisconnect);
                lConnection.PauseMS                 = lReader.getAttribute<UInt32>("Pause", lConnection.PauseMS);
                lConnection.Frame                   = lReader.getAttribute<UInt32>("Frame", lConnection.Frame);

                return lConnection;
            }

            public IConnection  createByForm(IWin32Window aOwner)
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

            public void         setupByForm(IConnection aConnection, IWin32Window aOwner)
            {
                using (var lSetupForm = new ConnectionSetupForm((Connection)aConnection, false))
                {
                    lSetupForm.ShowDialog(aOwner);
                }
            }

            public void         saveToXML(IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                var lConnection = (Connection)aConnection;

                aXMLTextWriter.WriteAttributeString("Transport", lConnection.mTransport.ToString());

                if (lConnection.mTransport == ETransportType.TCP)
                {
                    aXMLTextWriter.WriteAttributeString("IP", lConnection.IP);
                    aXMLTextWriter.WriteAttributeString("IPPort", StringUtils.ObjectToString(lConnection.IPPort));
                }
                else if (lConnection.mTransport == ETransportType.SERIAL)
                {
                    aXMLTextWriter.WriteAttributeString("Port", lConnection.COMPort);
                    aXMLTextWriter.WriteAttributeString("Baud", StringUtils.ObjectToString(lConnection.Baud));
                    aXMLTextWriter.WriteAttributeString("DataBits", StringUtils.ObjectToString(lConnection.DataBits));
                    aXMLTextWriter.WriteAttributeString("Parity", lConnection.mParity.ToString());
                    aXMLTextWriter.WriteAttributeString("StopBits", lConnection.mStopBits.ToString());
                    aXMLTextWriter.WriteAttributeString("Protocol", lConnection.mProtocol.ToString());
                }

                aXMLTextWriter.WriteAttributeString("Timeout", StringUtils.ObjectToString(lConnection.TimeoutMS));
                aXMLTextWriter.WriteAttributeString("ErrorsBeforeDisconnect", StringUtils.ObjectToString(lConnection.mErrorsBeforeDisconnect));
                aXMLTextWriter.WriteAttributeString("Pause", StringUtils.ObjectToString(lConnection.PauseMS));
                aXMLTextWriter.WriteAttributeString("Frame", StringUtils.ObjectToString(lConnection.Frame));
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
                var lItem       = new DataItem();
                var lReader     = new XMLAttributeReader(aXMLTextReader);

                lItem.SlaveID   = lReader.getAttribute<Byte>("SlaveID");
                lItem.setRegister((ERegisterType)Enum.Parse(typeof(ERegisterType), lReader.getAttribute<String>("RegisterType")),
                                    lReader.getAttribute<UInt16>("Register"), 
                                        StringUtils.parseType(lReader.getAttribute<String>("DataType")), 
                                            lReader.getAttribute<UInt16>("Length", 1));
                if (lItem.DataType == typeof(Single) || lItem.DataType == typeof(Int32) || lItem.DataType == typeof(UInt32))
                {
                    lItem.mSwapWords = lReader.getAttribute<Boolean>("SwapWords");
                } 

                lConnection.addItem(lItem);

                return lItem;
            }

            public IDataItem    createByForm(IConnection aConnection, IWin32Window aOwner)
            {
                var lConnection = (Connection)aConnection;
                var lItem       = new DataItem();

                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.OK)
                    {
                        lItem.SlaveID = lSetupForm.SlaveID;
                        lItem.setRegister(lSetupForm.RegisterType,
                                            lSetupForm.Register, lSetupForm.DataType, lSetupForm.Length);
                        lItem.mSwapWords = lSetupForm.SwapWords;

                        lConnection.addItem(lItem);
                    }
                    else
                    {
                        lItem = null;
                    }
                }

                return lItem;
            }

            public void         setupByForm(IDataItem aDataItem, IConnection aConnection, IWin32Window aOwner)
            {
                var lConnection = (Connection)aConnection;
                var lItem       = (DataItem)aDataItem;
                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.OK)
                    {
                        lConnection.removeItem(lItem);
                        lConnection.waitCycleEnd();

                        lItem.SlaveID = lSetupForm.SlaveID;
                        lItem.mSwapWords = lSetupForm.SwapWords;
                        lItem.setRegister(lSetupForm.RegisterType,
                                                lSetupForm.Register, lSetupForm.DataType, lSetupForm.Length);
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

            public void         saveToXML(IDataItem aDataItem, IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                var lItem = (DataItem)aDataItem;

                aXMLTextWriter.WriteAttributeString("SlaveID", StringUtils.ObjectToString(lItem.SlaveID));
                aXMLTextWriter.WriteAttributeString("RegisterType", lItem.RegisterType.ToString());
                aXMLTextWriter.WriteAttributeString("Register", StringUtils.ObjectToString(lItem.Register));
                aXMLTextWriter.WriteAttributeString("DataType", lItem.DataType.FullName);
                if (lItem.DataType == typeof(Single) || lItem.DataType == typeof(Int32) || lItem.DataType == typeof(UInt32))
                {
                    aXMLTextWriter.WriteAttributeString("SwapWords", StringUtils.ObjectToString(lItem.mSwapWords));
                }

                if (lItem.Length > 1)
                {
                    aXMLTextWriter.WriteAttributeString("Length", StringUtils.ObjectToString(lItem.Length));
                }
            }

            public void         destroyDataItem(IDataItem aDataItem, IConnection aConnection)
            {
                ((Connection)aConnection).removeItem((DataItem)aDataItem);
            }

        #endregion
    }
}
