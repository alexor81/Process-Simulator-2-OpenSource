using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using API;
using Microsoft.Win32;
using S7PROSIMLib;
using Utils;

namespace Connection.S7PLCSim
{
    public class Factory : ICommunicationFactory
    {
        #region Connection

            public bool         isPossibleToCreateConnection(out string aError)
            {
                try
                {
                    var lRegKey             = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\CLSID\{83CC0D83-FEDA-11D1-BE76-0060B06816CF}\InprocServer32");
                    Object lValue           = lRegKey.GetValue(null);
                    var lFileVersionInfo    = FileVersionInfo.GetVersionInfo(lValue.ToString());

                    if ((lFileVersionInfo.ProductMajorPart == 5 && lFileVersionInfo.ProductMinorPart >= 4)
                        || lFileVersionInfo.ProductMajorPart > 5)
                    {
                        aError = "";
                        return true;
                    }
                    else
                    {
                        aError = "Version of Siemens S7ProSim library is older than needed (5.4). ";
                        return false;
                    }
                }
                catch
                {
                    aError = "Siemens S7ProSim library is not found. ";
                    return false;
                }
            }

            public IConnection  createFromXML(XmlTextReader aXMLTextReader)
            {
                Connection lConnection          = new Connection();
                XMLAttributeReader lReader      = new XMLAttributeReader(aXMLTextReader);

                lConnection.mInstanceNumber     = lReader.getAttribute<UInt32>("InstanceNumber", lConnection.mInstanceNumber);
                lConnection.mContinuousScan     = lReader.getAttribute<Boolean>("ContinuousScan", lConnection.mContinuousScan);
                lConnection.Slowdown            = lReader.getAttribute<UInt32>("Slowdown", lConnection.Slowdown);

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
                using (var lSetupForm = new ConnectionSetupForm((Connection)aConnection, false))
                {
                    lSetupForm.ShowDialog(aOwner);
                }
            }

            public void         saveToXML(IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                Connection lConnection = (Connection)aConnection;
                aXMLTextWriter.WriteAttributeString("InstanceNumber", StringUtils.ObjectToString(lConnection.mInstanceNumber));
                aXMLTextWriter.WriteAttributeString("ContinuousScan", StringUtils.ObjectToString(lConnection.mContinuousScan));
                aXMLTextWriter.WriteAttributeString("Slowdown", StringUtils.ObjectToString(lConnection.Slowdown));
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
                Connection lConnection      = (Connection)aConnection;
                DataItem lItem              = new DataItem();
                XMLAttributeReader lReader  = new XMLAttributeReader(aXMLTextReader);

                lItem.mMemoryType = (EPLCMemoryType)Enum.Parse(typeof(EPLCMemoryType), lReader.getAttribute<String>("MemoryType"));
                if (lItem.mMemoryType == EPLCMemoryType.DB)
                {
                    lItem.DB = (int)lReader.getAttribute<UInt32>("DB");
                }

                lItem.DataType  = (PointDataTypeConstants)Enum.Parse(typeof(PointDataTypeConstants), lReader.getAttribute<String>("DataType"));
                lItem.Byte      = (int)lReader.getAttribute<UInt32>("Byte");

                if (lItem.DataType == PointDataTypeConstants.S7_Bit)
                {
                    lItem.Bit = (int)lReader.getAttribute<UInt32>("Bit");
                }
                else if (lItem.DataType == PointDataTypeConstants.S7_Byte || lItem.DataType == PointDataTypeConstants.S7_Word)
                {
                    lItem.Signed = lReader.getAttribute<Boolean>("Signed", lItem.Signed);
                }
                else if (lItem.DataType == PointDataTypeConstants.S7_DoubleWord)
                {
                    lItem.FloatingP = lReader.getAttribute<Boolean>("FloatingPoint", lItem.FloatingP);
                    if (lItem.FloatingP == false)
                    {
                        lItem.Signed = lReader.getAttribute<Boolean>("Signed", lItem.Signed);
                    }
                }

                if ((lItem.mMemoryType == EPLCMemoryType.I || lItem.mMemoryType == EPLCMemoryType.Q) && lItem.DataType != PointDataTypeConstants.S7_Bit)
                {
                    lItem.Length = (int)lReader.getAttribute<UInt32>("Length", 1);
                }

                lConnection.addItem(lItem);

                return lItem;
            }

            public IDataItem    createByForm(IConnection aConnection, IWin32Window aOwner)
            {
                Connection lConnection  = (Connection)aConnection;
                DataItem lItem          = new DataItem();
                using (var lSetupForm = new ItemSetupForm(lConnection, lItem))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.OK)
                    {
                        lItem.mMemoryType   = lSetupForm.MemoryType;
                        lItem.DB            = lSetupForm.DB;
                        lItem.Byte          = lSetupForm.Byte;
                        lItem.Bit           = lSetupForm.Bit;
                        lItem.DataType      = lSetupForm.DataType;
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

            public void         saveToXML(IDataItem aDataItem, IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                DataItem lItem = (DataItem)aDataItem;

                aXMLTextWriter.WriteAttributeString("MemoryType", lItem.mMemoryType.ToString());
                if (lItem.mMemoryType == EPLCMemoryType.DB)
                {
                    aXMLTextWriter.WriteAttributeString("DB", StringUtils.ObjectToString(lItem.DB));
                }

                aXMLTextWriter.WriteAttributeString("DataType", lItem.DataType.ToString());
                aXMLTextWriter.WriteAttributeString("Byte", StringUtils.ObjectToString(lItem.Byte));

                if (lItem.DataType == PointDataTypeConstants.S7_Bit)
                {
                    aXMLTextWriter.WriteAttributeString("Bit", StringUtils.ObjectToString(lItem.Bit));
                }
                else if (lItem.DataType == PointDataTypeConstants.S7_Byte || lItem.DataType == PointDataTypeConstants.S7_Word)
                {
                    aXMLTextWriter.WriteAttributeString("Signed", StringUtils.ObjectToString(lItem.Signed));
                }
                else if (lItem.DataType == PointDataTypeConstants.S7_DoubleWord)
                {
                    aXMLTextWriter.WriteAttributeString("FloatingPoint", StringUtils.ObjectToString(lItem.FloatingP));
                    if (lItem.FloatingP == false)
                    {
                        aXMLTextWriter.WriteAttributeString("Signed", StringUtils.ObjectToString(lItem.Signed));
                    }
                }

                if ((lItem.mMemoryType == EPLCMemoryType.I || lItem.mMemoryType == EPLCMemoryType.Q) && lItem.DataType != PointDataTypeConstants.S7_Bit)
                {
                    if (lItem.Length > 1)
                    {
                        aXMLTextWriter.WriteAttributeString("Length", StringUtils.ObjectToString(lItem.Length));
                    }
                }
            }

            public void         destroyDataItem(IDataItem aDataItem, IConnection aConnection)
            {
                ((Connection)aConnection).removeItem((DataItem)aDataItem);
            }

        #endregion
    }
}
