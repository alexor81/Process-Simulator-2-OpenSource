// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Xml;

namespace Utils
{
    public class XMLAttributeReader
    {
        private XmlTextReader   mReader;

        public                  XMLAttributeReader(XmlTextReader aReader)
        {
            mReader = aReader;
        }

        private T               parse<T>(string aName, string aValue)
        {
            if (String.IsNullOrEmpty(aValue))
            {
                throw new NullReferenceException("Attribute '" + aName + "' of type '" + typeof(T).FullName + "' is not found. ");
            }

            T lValue;

            try
            {
                lValue = (T)StringUtils.StringToObject(typeof(T), aValue);
            }
            catch (Exception lExc)
            {
                throw new FormatException("Type conversion error for attribute '" + aName + "'. " + lExc.Message, lExc);
            }

            return lValue;
        }

        public T                getAttribute<T>(string aName)
        {
            return parse<T>(aName, mReader.GetAttribute(aName));
        }

        public T                getAttribute<T>(string aName, T aDefault)
        {
            string lValue = mReader.GetAttribute(aName);
            if(String.IsNullOrEmpty(lValue))
            {
                return aDefault;
            }

            return parse<T>(aName, lValue);
        }
    }
}
