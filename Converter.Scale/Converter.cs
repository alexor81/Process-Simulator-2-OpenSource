using System;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;

namespace Converter.Scale
{
    public class Converter : IValueConverter
    {
        private ValueScale  mValueScale;

        public              Converter()
        {
            mValueScale = new ValueScale();
        }

        public object       convertValue(object aValue)
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

            return mValueScale.scale(lValue);
        }

        public object       unconvertValue(object aValue)
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

            return mValueScale.unscale(lValue);
        }

        public void         setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(mValueScale))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public void         loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            double lInMax   = lReader.getAttribute<Double>("InMax");
            double lInMin   = lReader.getAttribute<Double>("InMin");
            double lOutMax  = lReader.getAttribute<Double>("OutMax");
            double lOutMin  = lReader.getAttribute<Double>("OutMin");

            mValueScale.setProperties(lInMax, lInMin, lOutMax, lOutMin);
        }

        public void         saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("InMax", StringUtils.ObjectToString(mValueScale.InMax));
            aXMLTextWriter.WriteAttributeString("InMin", StringUtils.ObjectToString(mValueScale.InMin));
            aXMLTextWriter.WriteAttributeString("OutMax", StringUtils.ObjectToString(mValueScale.OutMax));
            aXMLTextWriter.WriteAttributeString("OutMin", StringUtils.ObjectToString(mValueScale.OutMin));
        }

        #region IDisposable

            private bool mDisposed = false;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    mDisposed = true;
                }
            }

        #endregion
    }
}
