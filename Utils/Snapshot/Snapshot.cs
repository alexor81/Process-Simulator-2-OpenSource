// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Utils.Logger;

namespace Utils.Snapshot
{
    public class Snapshot
    {
        private string                  mName;
        public string                   Name
        {
            get { return mName; }
            set { mName = value; }
        }

        private IItemBrowser            mItemBrowser;
        public IItemBrowser             ItemBrowser { get { return mItemBrowser; } }

        private Dictionary<int, object> mRecords = new Dictionary<int, object>();

        public                          Snapshot(string aName, IItemBrowser aItemBrowser)
        {
            mName           = aName;
            mItemBrowser    = aItemBrowser;
        }

        #region Load/Save

            public void                 loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader = new XMLAttributeReader(aXMLTextReader);
                string lItemName;
                object lValue;

                while (aXMLTextReader.Name.Equals("Record", StringComparison.Ordinal) && aXMLTextReader.IsStartElement())
                {
                    lItemName   = lReader.getAttribute<String>("Item");
                    lValue      = XMLUtils.loadValueFromXML(aXMLTextReader);

                    addRecord(lItemName, lValue);

                    aXMLTextReader.Read();
                }
            }

            public void                 saveToXML(XmlTextWriter aXMLTextWriter)
            {
                foreach (KeyValuePair<int, object> lRecord in mRecords)
                {
                    aXMLTextWriter.WriteStartElement("Record");
                    aXMLTextWriter.WriteAttributeString("Item", mItemBrowser.getItemNameByHandle(lRecord.Key));
                    XMLUtils.saveValueToXML(aXMLTextWriter, lRecord.Value);
                    aXMLTextWriter.WriteEndElement();
                }
            }

        #endregion

        public void                     checkRecordArguments(string aItemName, object aValue)
        {
            if (String.IsNullOrWhiteSpace(aItemName))
            {
                throw new ArgumentException("Item name is missing. ");
            }

            if (mItemBrowser.isItemExists(aItemName) == false)
            {
                throw new ArgumentException("Item '" + aItemName + "' does not exist. ");
            }

            if (aValue == null)
            {
                throw new ArgumentException("Value is null. ");
            }
        }

        public void                     checkRecordArguments(int aItemHandle, object aValue)
        {
            if (mItemBrowser.isItemExists(aItemHandle) == false)
            {
                throw new ArgumentException("Item does not exist. ");
            }

            if (aValue == null)
            {
                throw new ArgumentException("Value is null. ");
            }
        }

        public bool                     isRecordExists(int aItemHandle)
        {
            return mRecords.ContainsKey(aItemHandle);
        }

        public void                     addRecord(string aItemName, object aValue)
        {
            checkRecordArguments(aItemName, aValue);

            int lItemHandle = mItemBrowser.getItemHandleByName(aItemName);
            if (mRecords.ContainsKey(lItemHandle))
            {
                throw new ArgumentException("Item '" + aItemName + "' already exists. ");
            }

            mRecords.Add(lItemHandle, aValue);
        }

        public void                     addRecord(int aItemHandle, object aValue)
        {
            checkRecordArguments(aItemHandle, aValue);

            if (mRecords.ContainsKey(aItemHandle))
            {
                throw new ArgumentException("Item '" +  mItemBrowser.getItemNameByHandle(aItemHandle) + "' already exists. ");
            }

            mRecords.Add(aItemHandle, aValue);
        }

        public void                     deleteRecord(string aItemName)
        {
            int lItemHandle = mItemBrowser.getItemHandleByName(aItemName);
            if (lItemHandle == -1)
            {
                throw new ArgumentException("Item '" + aItemName + "' does not exist. ");
            }

            if (mRecords.Remove(lItemHandle) == false)
            {
                throw new ArgumentException("Item '" + aItemName + "' does not exist. ");
            }
        }

        public void                     deleteRecord(int aItemHandle)
        {
            if (mItemBrowser.isItemExists(aItemHandle) == false)
            {
                throw new ArgumentException("Item does not exist. ");
            }

            if (mRecords.Remove(aItemHandle) == false)
            {
                throw new ArgumentException("Item '" + mItemBrowser.getItemNameByHandle(aItemHandle) + "' does not exist. ");
            }
        }

        public void                     changeRecord(string aItemName, string aNewItemName, object aNewValue)
        {
            checkRecordArguments(aNewItemName, aNewValue);
            int lItemHandle = mItemBrowser.getItemHandleByName(aNewItemName);

            if (aItemName.Equals(aNewItemName, StringComparison.Ordinal) == false)
            {
                if (mRecords.ContainsKey(lItemHandle))
                {
                    throw new ArgumentException("Item '" + aNewItemName + "' already exists. ");
                }

                deleteRecord(aItemName);
                addRecord(lItemHandle, aNewValue);
            }
            else
            {
                mRecords[lItemHandle] = aNewValue;
            }
        }

        public void                     replaceItems(int[,] aItemHandles)
        {
            var lNewRecords = new Dictionary<int, object>();

            foreach (int lHandle in mRecords.Keys)
            {
                for(int i = 0; i < aItemHandles.GetLength(0); i++)
                {
                    if(lHandle == aItemHandles[i,0])
                    {
                        lNewRecords.Add(aItemHandles[i, 1], mRecords[lHandle]);
                        goto Next;
                    }
                }

                lNewRecords.Add(lHandle, mRecords[lHandle]);

                Next:;
            }

            mRecords = lNewRecords;
        }

        public object                   getRecordValue(string aItemName)
        {
            int lItemHandle = mItemBrowser.getItemHandleByName(aItemName);
            if (lItemHandle == -1)
            {
                throw new ArgumentException("Item '" + aItemName + "' does not exist. ");
            }

            if (mRecords.ContainsKey(lItemHandle) == false)
            {
                throw new ArgumentException("Item '" + aItemName + "' does not exist. ");
            }

            return mRecords[lItemHandle];
        }

        public object                   getRecordValue(int aItemHandle)
        {
            if (mItemBrowser.isItemExists(aItemHandle) == false)
            {
                throw new ArgumentException("Item does not exist. ");
            }

            if (mRecords.ContainsKey(aItemHandle) == false)
            {
                throw new ArgumentException("Item '" + mItemBrowser.getItemNameByHandle(aItemHandle) + "' does not exist. ");
            }

            return mRecords[aItemHandle];
        }

        public int                      RecordsCount
        {
            get { return mRecords.Count; }
        }

        public DataTable                RecordsData
        {
            get
            {
                var lTable = new DataTable();
                lTable.Columns.Add("Item");
                lTable.Columns.Add("Value");
                lTable.Columns.Add("Type");

                foreach (int lItemHandle in mRecords.Keys)
                {
                    lTable.Rows.Add(mItemBrowser.getItemNameByHandle(lItemHandle), StringUtils.ObjectToString(mRecords[lItemHandle]), mRecords[lItemHandle].GetType().Name);
                }

                return lTable;
            }
        }

        public int[]                    ItemsHandles
        {
            get { return mRecords.Keys.ToArray(); }
        }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SnapshotRecordsManagerForm(this) )
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public void                     writeSnapshot(bool aCancelOnError)
        {
            foreach (KeyValuePair<int, object> lKeyValue in mRecords)
            {
                if (mItemBrowser.getItemAccess(lKeyValue.Key).HasFlag(EAccess.WRITE))
                {
                    try
                    {
                        mItemBrowser.writeItemValue(lKeyValue.Key, lKeyValue.Value);
                    }
                    catch (Exception lExc)
                    {
                        string lMessage = "Error writing Item '" + mItemBrowser.getItemNameByHandle(lKeyValue.Key) + "'. " + lExc.Message;
                        if (aCancelOnError)
                        {
                            throw new InvalidOperationException(lMessage, lExc);
                        }
                        else
                        {
                            Log.Error(lMessage, lExc.ToString());
                        }
                    }
                }
                else
                {
                    string lMessage = "No access for writing Item '" + mItemBrowser.getItemNameByHandle(lKeyValue.Key) + "'. ";
                    if (aCancelOnError)
                    {
                        throw new InvalidOperationException(lMessage);
                    }
                    else
                    {
                        Log.Error(lMessage);
                    }
                }
            }
        }

        public Snapshot                 Clone
        {
            get
            {
                var lClone = new Snapshot(mName, mItemBrowser);

                foreach (int lItemHandle in mRecords.Keys)
                {
                    lClone.addRecord(lItemHandle, mRecords[lItemHandle]);
                }

                return lClone;
            }
        }
    }
}
