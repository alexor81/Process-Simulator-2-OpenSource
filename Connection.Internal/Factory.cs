// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Connection.Internal
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
                var lConnection     = new Connection();
                var lReader         = new XMLAttributeReader(aXMLTextReader);

                lConnection.mTypeChangeProhibited = lReader.getAttribute<Boolean>("TypeChangeProhibited", lConnection.mTypeChangeProhibited);    

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
                aXMLTextWriter.WriteAttributeString("TypeChangeProhibited", StringUtils.ObjectToString(lConnection.mTypeChangeProhibited));
            }

            public void                 destroyConnection(IConnection aConnection)
            {
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
                Connection lConnection  = (Connection)aConnection;
                var lReader             = new XMLAttributeReader(aXMLTextReader);

                string lAccessString    = lReader.getAttribute<String>("Access", "READ_WRITE");
                EAccess lAccess         = (EAccess)Enum.Parse(typeof(EAccess), lAccessString);
                object lValue           = XMLUtils.loadValueFromXML(aXMLTextReader);

                return lConnection.addItem(lAccess, lValue);
            }

            public IDataItem            createByForm(IConnection aConnection, IWin32Window aOwner)
            {
                Connection lConnection  = (Connection)aConnection;
                DataItem lItem          = lConnection.addItem(EAccess.READ_WRITE, 0);
                using (var lSetupForm = new ItemSetupForm(lConnection, lItem, true))
                {
                    if (lSetupForm.ShowDialog(aOwner) == DialogResult.Cancel)
                    {
                        lConnection.removeItem(lItem);
                        lItem = null;
                    }
                }
                return lItem;
            }

            public void                 setupByForm(IDataItem aDataItem, IConnection aConnection, IWin32Window aOwner)
            {
                using (var lSetupForm = new ItemSetupForm((Connection)aConnection, (DataItem)aDataItem, false))
                {
                    lSetupForm.ShowDialog(aOwner);
                }
            }

            public void                 saveToXML(IDataItem aDataItem, IConnection aConnection, XmlTextWriter aXMLTextWriter)
            {
                Connection lConnection  = (Connection)aConnection;
                DataItem lItem          = (DataItem)aDataItem;

                aXMLTextWriter.WriteAttributeString("Access", lItem.mAccess.ToString());

                if (lItem.mValue != null)
                {
                    XMLUtils.saveValueToXML(aXMLTextWriter, lItem.mValue);
                }
            }

            public void                 destroyDataItem(IDataItem aDataItem, IConnection aConnection)
            {
                ((Connection)aConnection).removeItem((DataItem)aDataItem);
            }

        #endregion
    }
}
