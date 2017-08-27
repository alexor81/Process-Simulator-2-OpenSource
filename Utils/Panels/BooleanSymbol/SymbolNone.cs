// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanSymbol
{
    public class SymbolNone: ISymbol
    {
        public string               Name { get { return "None"; } }

        public void                 setupByForm(IWin32Window aOwner, IRedraw aRedraw)
        {
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
        }

        public Bitmap               draw(int aWidth, int aHeight)
        {
            return null;
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
                    if (aDisposing)
                    {

                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
