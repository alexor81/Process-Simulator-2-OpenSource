using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Converter.ToString
{
    public class Converter : IValueConverter
    {
        public Type                 mType       = typeof(Double);
        public bool                 mArray      = false;
        public bool                 mReverse    = false;

        public object               convertValue(object aValue)
        {
            object lValue;

            if(mReverse)
            {
                if (mArray)
                {
                    lValue = StringUtils.StringToArray(mType, (string)aValue);
                }
                else
                {
                    lValue = StringUtils.StringToObject(mType, (string)aValue);
                }
            }
            else
            {
                if (mArray)
                {
                    lValue = StringUtils.ObjectToString(MiscUtils.convertValue(mType.MakeArrayType(1), aValue));
                }
                else
                {
                    lValue = StringUtils.ObjectToString(MiscUtils.convertValue(mType, aValue));
                }
            }

            return lValue;
        }

        public object               unconvertValue(object aValue)
        {
            object lValue;

            if (mReverse)
            {
                if (mArray)
                {
                    lValue = StringUtils.ObjectToString(MiscUtils.convertValue(mType.MakeArrayType(1), aValue));
                }
                else
                {
                    lValue = StringUtils.ObjectToString(MiscUtils.convertValue(mType, aValue));
                }
            }
            else
            {
                if (mArray)
                {
                    lValue = StringUtils.StringToArray(mType, (string)aValue);
                }
                else
                {
                    lValue = StringUtils.StringToObject(mType, (string)aValue);
                }
            }

            return lValue;
        }

        public void                 setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            mType       = StringUtils.parseType(lReader.getAttribute<String>("DataType"));
            mArray      = lReader.getAttribute<Boolean>("Array", mArray);
            mReverse    = lReader.getAttribute<Boolean>("Reverse", mReverse);       
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("DataType", mType.FullName);
            aXMLTextWriter.WriteAttributeString("Array", StringUtils.ObjectToString(mArray));
            aXMLTextWriter.WriteAttributeString("Reverse", StringUtils.ObjectToString(mReverse));
        }

        #region IDisposable

            private bool            mDisposed = false;

            public void             Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void  Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    mDisposed = true;
                }
            }

        #endregion
    }
}
