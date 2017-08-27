// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanSymbol.SymbolImage
{
    public class SymbolImage: ISymbol
    {
        public MemoryStream         mImgMemStrm;

        public string               Name { get { return "Image"; } }

        public void                 setupByForm(IWin32Window aOwner, IRedraw aRedraw)
        {
            using (var lSetupForm = new SetupForm(this, aRedraw))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            if (aXMLTextReader.IsEmptyElement == false)
            {
                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("Image", StringComparison.Ordinal))
                {
                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        aXMLTextReader.Read();
                        mImgMemStrm = new MemoryStream(Convert.FromBase64String(aXMLTextReader.ReadString()));
                    }
                }
            }
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteStartElement("Image");
                if (mImgMemStrm != null)
                {
                    aXMLTextWriter.WriteString(Convert.ToBase64String(mImgMemStrm.ToArray()));
                }
            aXMLTextWriter.WriteEndElement();
        }

        public Bitmap               draw(int aWidth, int aHeight)
        {
            var lResult = new Bitmap(aWidth, aHeight);

            using (var lGraphics = Graphics.FromImage(lResult))
            {
                lGraphics.Clear(Color.Transparent);
                if (mImgMemStrm != null)
                {
                    lGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                    lGraphics.DrawImage(new Bitmap(mImgMemStrm), 0, 0, aWidth - 1, aHeight - 1);
                }
            }

            return lResult;
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
                        if (mImgMemStrm != null)
                        {
                            mImgMemStrm.Close();
                            mImgMemStrm = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
