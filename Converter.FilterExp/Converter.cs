using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace Converter.FilterExp
{
    public class Converter : IValueConverter
    {
        private double              mAlfa = 0.5;
        public double               Alfa
        {
            get { return mAlfa; }
            set
            {
                if (ValuesCompare.NotEqualDelta1.compare(mAlfa, value))
                {
                    if (value < 0.0D)
                    {
                        mAlfa = 0;
                    }
                    else if (value > 1.0D)
                    {
                        mAlfa = 1;
                    }
                    else
                    {
                        mAlfa = value;
                    }
                }
            }
        }

        private bool                mFirst = true;

        private double              mValue;

        private object              filter(object aValue)
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

            if (mFirst)
            {
                mFirst = false;
                mValue = lValue;
                return mValue;
            }
            
            mValue = mValue + mAlfa * (lValue - mValue);

            return mValue;
        }

        public object               convertValue(object aValue) //-V3013
        {
            return filter(aValue);
        }

        public object               unconvertValue(object aValue) //-V3013
        {
            return filter(aValue);
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
            Alfa        = lReader.getAttribute<Double>("Alfa", Alfa);
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Alfa", StringUtils.ObjectToString(Alfa));
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
