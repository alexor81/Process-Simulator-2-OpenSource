// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;

namespace Converter.Round
{
    public class Converter : IValueConverter
    {
        private int     mRound = 3;
        public int      Round
        {
            get { return mRound; }
            set
            {
                if (mRound != value)
                {
                    if (value < 0)
                    {
                        mRound = 0;
                    }
                    else if (value > 15)
                    {
                        mRound = 15;
                    }
                    else
                    {
                        mRound = value;
                    }
                }
            }
        }

        private object  roundDecimal(object aValue)
        {
            decimal lValue;
            try
            {
                lValue = Convert.ToDecimal(aValue);
            }
            catch (Exception lExc)
            {
                throw new InvalidOperationException("Value conversion error. " + lExc.Message, lExc);
            }

            return Math.Round(lValue, mRound);
        }

        private object  roundSingle(object aValue)
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

            return Convert.ToSingle(Math.Round(lValue, mRound));
        }

        private object  roundDouble(object aValue)
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

            return Math.Round(lValue, mRound);
        }

        private object  round(object aValue)
        {
            if (aValue is Decimal)
            {
                return roundDecimal(aValue);
            }
            else if (aValue is Single)
            {
                return roundSingle(aValue);
            }
            else if (aValue is Double)
            {
                return roundDouble(aValue);
            }
            else if (aValue is Array)
            {
                Array lArray        = aValue as Array;
                Type lElementType   = lArray.GetType().GetElementType();

                if (lElementType == typeof(Decimal))
                {
                    for (int i = 0; i < lArray.Length; i++)
                    {
                        lArray.SetValue(roundDecimal(lArray.GetValue(i)), i);
                    }

                    return lArray;
                }
                else if (lElementType == typeof(Single))
                {
                    for (int i = 0; i < lArray.Length; i++)
                    {
                        lArray.SetValue(roundSingle(lArray.GetValue(i)), i);
                    }

                    return lArray;
                }
                else if (lElementType == typeof(Double))
                {
                    for (int i = 0; i < lArray.Length; i++)
                    {
                        lArray.SetValue(roundDouble(lArray.GetValue(i)), i);
                    }

                    return lArray;
                }
                else
                {
                    throw new InvalidOperationException("Value conversion error. ");
                }
            }
            else
            {
                throw new InvalidOperationException("Value conversion error. ");
            }
        }

        public object   convertValue(object aValue) //-V3013
        {
           return round(aValue);
        }

        public object   unconvertValue(object aValue) //-V3013
        {
            return round(aValue);
        }

        public void     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public void     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            Round       = (int)lReader.getAttribute<UInt32>("Round", (uint)Round);
        }

        public void     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Round", StringUtils.ObjectToString(Round));
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
