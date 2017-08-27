// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Xml;

namespace Utils.NameValueList
{
    public class NameValueHolder
    {
        private bool                        mAllowEmpty;
        private bool                        mAllowSameValue;
        private List<string>                mName           = new List<string>();
        private Dictionary<string, object>  mNameValue      = new Dictionary<string, object>(StringComparer.Ordinal);
        private HashSet<string>             mReservedWords  = new HashSet<string>();
        private Action<string>              mNameValidator;          

        public                              NameValueHolder(bool aAllowEmpty, bool aAllowSameValue)
        {
            mAllowEmpty     = aAllowEmpty;
            mAllowSameValue = aAllowSameValue;
        }

        public                              NameValueHolder(bool aAllowEmpty, bool aAllowSameValue, string[] aReservedWords)
                                            : this(aAllowEmpty, aAllowSameValue)
        {
            for (int i = 0; i < aReservedWords.Length; i++)
            {
                mReservedWords.Add(aReservedWords[i]);
            }
        }

        public                              NameValueHolder(bool aAllowEmpty, bool aAllowSameValue, string[] aReservedWords, Action<string> aNameValidator)
                                            : this(aAllowEmpty, aAllowSameValue, aReservedWords)
        {
            mNameValidator = aNameValidator;
        }

        public event EventHandler           ListChanged;
        private void                        raiseListChanged()
        {
            ListChanged?.Invoke(this, EventArgs.Empty);
        }

        public void                         add(string aName, object aValue, bool mReplaceDefault)
        {
            #region Name

                if (String.IsNullOrWhiteSpace(aName))
                {
                    throw new ArgumentException("Name is empty. ");
                }

                if (mReservedWords.Contains(aName))
                {
                    throw new ArgumentException("Name is reserved. ");
                }

                mNameValidator?.Invoke(aName);

                if (mNameValue.ContainsKey(aName) == true)
                {
                    if (mReplaceDefault && aName.Equals("Current value", StringComparison.Ordinal))
                    {
                        mName.Remove("Current value");
                        mNameValue.Remove("Current value");
                    }
                    else
                    {
                        throw new ArgumentException("Name '" + aName + "' already exists. ");
                    }
                }

            #endregion

            #region Value

                if (aValue == null)
                {
                    throw new ArgumentException("Null value is not allowed. ");
                }

                int lCount = mName.Count;
                for (int i = 0; i < lCount; i++)
                {
                    if (ValuesCompare.isEqual(mNameValue[mName[i]], aValue))
                    {
                        if (mReplaceDefault && mName[i].Equals("Current value", StringComparison.Ordinal))
                        {
                            mName.Remove("Current value");
                            mNameValue.Remove("Current value");
                            break;
                        }
                        else
                        {
                            if (mAllowSameValue == false)
                            {
                                throw new ArgumentException("Value '" + StringUtils.ObjectToString(aValue) + "' already exists. ");
                            }
                        }
                    }
                }

            #endregion

            mName.Add(aName);
            mNameValue.Add(aName, aValue);

            raiseListChanged();
        }

        public void                         modify(string aOldName, string aNewName, object aValue)
        {
            #region Name

                if (mNameValue.ContainsKey(aOldName) == false)
                {
                    throw new ArgumentException("Name '" + aOldName + "' does not exist. ");
                }

                if (String.IsNullOrWhiteSpace(aNewName))
                {
                    throw new ArgumentException("New name is empty. ");
                }

                if (mReservedWords.Contains(aNewName))
                {
                    throw new ArgumentException("Name is reserved. ");
                }

                mNameValidator?.Invoke(aNewName);

                if (aOldName.Equals(aNewName, StringComparison.Ordinal) == false)
                {
                    if (mNameValue.ContainsKey(aNewName))
                    {
                        throw new ArgumentException("Name '" + aNewName + "' already exists. ");
                    }
                }

            #endregion

            #region Value

                if (aValue == null)
                {
                    throw new ArgumentException("Null value is not allowed. ");
                }

                if (mAllowSameValue == false)
                {
                    int lCount = mName.Count;
                    for (int i = 0; i < lCount; i++)
                    {
                        if (aOldName.Equals(mName[i], StringComparison.Ordinal) == false)
                        {
                            if (ValuesCompare.isEqual(mNameValue[mName[i]], aValue))
                            {
                                throw new ArgumentException("Value '" + StringUtils.ObjectToString(aValue) + "' already exists. ");
                            }
                        }
                    }
                }

            #endregion

            mName[mName.IndexOf(aOldName)] = aNewName;
            mNameValue.Remove(aOldName);
            mNameValue.Add(aNewName, aValue);

            raiseListChanged();
        }

        public void                         delete(string aName)
        {
            if (mNameValue.ContainsKey(aName) == false)
            {
                throw new ArgumentException("Name '" + aName + "' does not exist. ");
            }

            if (mName.Count == 1 && mAllowEmpty == false)
            {
                throw new ArgumentException("Can not delete last value. ");
            }

            mName.Remove(aName);
            mNameValue.Remove(aName);

            raiseListChanged();
        }

        private void                        swap(int aIndex1, int aIndex2)
        {
            string lName    = mName[aIndex1];
            mName[aIndex1]  = mName[aIndex2];
            mName[aIndex2]  = lName;

            raiseListChanged();
        }

        public int                          moveUp(string aName)
        {
            if (mNameValue.ContainsKey(aName) == false)
            {
                throw new ArgumentException("Name '" + aName + "' does not exist. ");
            }

            int lIndex1 = mName.IndexOf(aName);
            int lIndex2 = lIndex1 - 1;
            swap(lIndex1, lIndex2);

            return lIndex2;
        }

        public int                          moveDown(string aName)
        {
            if (mNameValue.ContainsKey(aName) == false)
            {
                throw new ArgumentException("Name '" + aName + "' does not exist. ");
            }

            int lIndex1 = mName.IndexOf(aName);
            int lIndex2 = lIndex1 + 1;
            swap(lIndex1, lIndex2);

            return lIndex2;
        }

        public void                         clear()
        {
            mName.Clear();
            mNameValue.Clear();

            raiseListChanged();
        }

        public string[]                     Names
        {
            get { return mName.ToArray(); }
        }

        public object[]                     Values
        {
            get
            {
                var lNames  = mName.ToArray();
                var lValues = new object[lNames.Length];

                for (int i = 0; i < lNames.Length; i++)
                {
                    lValues[i] = mNameValue[lNames[i]];
                }

                return lValues;
            }
        }

        public object                       getValue(string aName)
        {
            if (mNameValue.ContainsKey(aName) == false)
            {
                throw new ArgumentException("Name '" + aName + "' does not exist. ");
            }

            return mNameValue[aName];
        }

        public void                         setValue(string aName, object aValue)
        {
            if (mNameValue.ContainsKey(aName) == false)
            {
                throw new ArgumentException("Name '" + aName + "' does not exist. ");
            }

            if (aValue == null)
            {
                throw new ArgumentException("Null value is not allowed. ");
            }

            mNameValue[aName] = aValue;
        }

        public int                          Count
        {
            get { return mName.Count; }
        }

        public void                         loadFromXML(XmlTextReader aXMLTextReader, string aName)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            string lName;
            object lValue;

            aXMLTextReader.Read();
            while (aXMLTextReader.Name.Equals(aName, StringComparison.Ordinal))
            {
                lName   = lReader.getAttribute<String>("Name");
                lValue  = XMLUtils.loadValueFromXML(aXMLTextReader);
                add(lName, lValue, false);

                aXMLTextReader.Read();
            }
        }

        public void                         saveToXML(XmlTextWriter aXMLTextWriter, string aName)
        {
            int lCount = mName.Count;
            for (int i = 0; i < lCount; i++)
            {
                aXMLTextWriter.WriteStartElement(aName);
                aXMLTextWriter.WriteAttributeString("Name", StringUtils.ObjectToString(mName[i]));
                XMLUtils.saveValueToXML(aXMLTextWriter, mNameValue[mName[i]]);
                aXMLTextWriter.WriteEndElement();
            }
        }

        public NameValueHolder              clone()
        {
            var lNew            = new NameValueHolder(mAllowEmpty, mAllowSameValue);
            lNew.mName          = new List<string>(mName);
            lNew.mNameValue     = new Dictionary<string, object>(mNameValue);
            lNew.mReservedWords = new HashSet<string>(mReservedWords);
            lNew.mNameValidator = mNameValidator;
            return lNew;
        }
    }
}
