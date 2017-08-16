// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Converter.ToBoolean
{
    public class Converter : IValueConverter
    {
        public bool                 mReverse        = false;

        public object               mTrueValue      = true;
        public object               mFalseValue     = false;

        public void                 checkValues(object aTrueValue, object aFalseValue)
        {
            Type lTrueType  = aTrueValue.GetType();
            Type lFalseType = aFalseValue.GetType();

            if (lTrueType.Equals(lFalseType) == false)
            {
                throw new ArgumentException("True and False Values should be the same type. ");
            }

            if(lTrueType.IsArray)
            {
                if(lTrueType.GetElementType().Equals(lFalseType.GetElementType()) == false)
                {
                    throw new ArgumentException("True and False Values should be the same type. ");
                }
            }

            if (ValuesCompare.isEqual(aTrueValue, aFalseValue))
            {
                throw new ArgumentException("True and False Values should not be equal. ");
            }
        }

        public bool                 mTrueIfWrong    = false;

        private bool                toBool(object aValue)
        {
            if (ValuesCompare.isEqual(mTrueValue, Converters.convertValue(mTrueValue.GetType(), aValue)))
            {
                return true;
            }
            else if (ValuesCompare.isEqual(mFalseValue, Converters.convertValue(mFalseValue.GetType(), aValue)))
            {
                return false;
            }
            else
            {
                if (mTrueIfWrong)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private object              fromBool(object aValue)
        {
            bool lBoolean = Convert.ToBoolean(aValue);
            if (lBoolean)
            {
                return mTrueValue;
            }
            else
            {
                return mFalseValue;
            }
        }

        public object               convertValue(object aValue)
        {
            object lValue;

            if (mReverse)
            {
                lValue = fromBool(aValue);
            }
            else
            {
                lValue = toBool(aValue);
            }
            
            return lValue;
        }

        public object               unconvertValue(object aValue)
        {
            object lValue;

            if (mReverse)
            {
                lValue = toBool(aValue);
            }
            else
            {
                lValue = fromBool(aValue);
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
            mReverse = lReader.getAttribute<Boolean>("Reverse", mReverse);
            mTrueIfWrong = lReader.getAttribute<Boolean>("TrueIfWrong", mTrueIfWrong);

            object lTrueValue = mTrueValue;
            object lFalseValue = mFalseValue;

            aXMLTextReader.Read();
            if (aXMLTextReader.Name.Equals("TrueValue", StringComparison.Ordinal))
            {
                lTrueValue = XMLUtils.loadValueFromXML(aXMLTextReader);
            }

            aXMLTextReader.Read();
            if (aXMLTextReader.Name.Equals("FalseValue", StringComparison.Ordinal))
            {
                lFalseValue = XMLUtils.loadValueFromXML(aXMLTextReader);
            }

            checkValues(lTrueValue, lFalseValue);
            mTrueValue  = lTrueValue;
            mFalseValue = lFalseValue;
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Reverse", StringUtils.ObjectToString(mReverse));
            aXMLTextWriter.WriteAttributeString("TrueIfWrong", StringUtils.ObjectToString(mTrueIfWrong));

            aXMLTextWriter.WriteStartElement("TrueValue");
            XMLUtils.saveValueToXML(aXMLTextWriter, mTrueValue);
            aXMLTextWriter.WriteEndElement();

            aXMLTextWriter.WriteStartElement("FalseValue");
            XMLUtils.saveValueToXML(aXMLTextWriter, mFalseValue);
            aXMLTextWriter.WriteEndElement();
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
