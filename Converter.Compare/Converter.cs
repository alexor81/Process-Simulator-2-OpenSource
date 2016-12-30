// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;

namespace Converter.Compare
{
    public class Converter : IValueConverter
    {
        public double               mValue          = 0.0D;
        public ValuesCompare        mValuesCompare  = new ValuesCompare();

        public object               convertValue(object aValue)
        {
            double lValue;
            try
            {
                lValue = Convert.ToDouble(aValue);
            }
            catch (Exception lExc)
            {
                throw new InvalidOperationException("Value conversion error. " + lExc.Message, lExc);
            }

            return mValuesCompare.compare(lValue, mValue);
        }

        public object               unconvertValue(object aValue)
        {
            return aValue;
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
            XMLAttributeReader lReader      = new XMLAttributeReader(aXMLTextReader);
            mValuesCompare.OperationName    = lReader.getAttribute<String>("Operation");
            mValue                          = lReader.getAttribute<Double>("Value");
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Operation", mValuesCompare.OperationName);
            aXMLTextWriter.WriteAttributeString("Value", StringUtils.ObjectToString(mValue));
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
