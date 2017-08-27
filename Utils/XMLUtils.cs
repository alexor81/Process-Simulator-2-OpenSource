// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Xml;

namespace Utils
{
    public static class XMLUtils
    {
        public static object    loadValueFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            Type lType      = StringUtils.parseType(lReader.getAttribute<String>("DataType"));
            bool lIsArray   = lReader.getAttribute<Boolean>("Array", false);

            if (lIsArray)
            {
                if (aXMLTextReader.IsEmptyElement)
                {
                    return Array.CreateInstance(lType, 0);
                }
                else
                {
                    List<object> lValues = new List<object>();
                    aXMLTextReader.Read();
                    while (aXMLTextReader.Name.Equals("Value", StringComparison.Ordinal))
                    {
                        lValues.Add(StringUtils.StringToObject(lType, aXMLTextReader.ReadElementContentAsString()));
                    }

                    int lCount      = lValues.Count;
                    Array lArray    = Array.CreateInstance(lType, lCount);

                    for (int i = 0; i < lCount; i++)
                    {
                        lArray.SetValue(lValues[i], i);
                    }

                    return lArray;
                }
            }
            else
            {
                return StringUtils.StringToObject(lType, lReader.getAttribute<String>("Value", ""));
            }
        }

        public static void      saveValueToXML(XmlTextWriter aXMLTextWriter, object aValue)
        {
            Array lArray = aValue as Array;
            if (lArray != null)
            {
                aXMLTextWriter.WriteAttributeString("DataType", lArray.GetType().GetElementType().FullName);
                aXMLTextWriter.WriteAttributeString("Array", "True");
                for (int i = 0; i < lArray.Length; i++)
                {
                    aXMLTextWriter.WriteStartElement("Value");
                    aXMLTextWriter.WriteString(StringUtils.ObjectToString(lArray.GetValue(i)));
                    aXMLTextWriter.WriteEndElement();
                }
            }
            else
            {
                aXMLTextWriter.WriteAttributeString("DataType", aValue.GetType().FullName);
                aXMLTextWriter.WriteAttributeString("Value", StringUtils.ObjectToString(aValue));
            }
        }
    }
}
