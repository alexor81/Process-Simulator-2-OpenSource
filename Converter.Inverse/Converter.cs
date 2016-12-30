// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using System.Xml;
using API;

namespace Converter.Inverse
{
    public class Converter : IValueConverter
    {
        private object  inverse(object aValue)
        {
            if (aValue is Boolean)
            {
                return !((Boolean)aValue);
            }
            else if (aValue is Array)
            {
                Array lArray = aValue as Array;
                if (lArray.GetType().GetElementType() == typeof(Boolean))
                {
                    for (int i = 0; i < lArray.Length; i++)
                    {
                        lArray.SetValue(!((Boolean)lArray.GetValue(i)), i);
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
            return inverse(aValue);
        }

        public object   unconvertValue(object aValue) //-V3013
        {
            return inverse(aValue);
        }

        public void     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm())
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public void     loadFromXML(XmlTextReader aXMLTextReader)
        {
        }

        public void     saveToXML(XmlTextWriter aXMLTextWriter)
        {
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
