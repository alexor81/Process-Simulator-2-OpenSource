// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanSymbol.SymbolRectangle
{
    public class SymbolRectangle: ISymbol
    {
        public string               Name { get { return "Rectangle"; } }

        public void                 setupByForm(IWin32Window aOwner, IRedraw aRedraw)
        {
            using (var lSetupForm = new SetupForm(this, aRedraw))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);

            mBorderColor = lReader.getAttribute<Color>("BorderColor", mBorderColor);
            mBorderWidth = lReader.getAttribute<UInt32>("BorderWidth", mBorderWidth);
            initBorderPen();

            FillColor   = lReader.getAttribute<Color>("FillColor", mFillColor);
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("BorderColor", StringUtils.ObjectToString(mBorderColor));
            aXMLTextWriter.WriteAttributeString("BorderWidth", StringUtils.ObjectToString(mBorderWidth));
            aXMLTextWriter.WriteAttributeString("FillColor", StringUtils.ObjectToString(mFillColor));
        }

        private Brush               mFillBrush      = new SolidBrush(Color.LimeGreen);
        private Color               mFillColor      = Color.LimeGreen;
        public Color                FillColor
        {
            get { return mFillColor; }
            set
            {
                if (mFillBrush != null)
                {
                    mFillBrush.Dispose();
                }

                mFillColor = value;
                mFillBrush = new SolidBrush(mFillColor);
            }
        }

        private Color               mBorderColor    = Color.Black;
        public Color                BorderColor
        {
            get { return mBorderColor; }
            set
            {
                mBorderColor = value;
                initBorderPen();
            }
        }
        private uint                mBorderWidth    = 1;
        public uint                 BorderWidth
        {
            get { return mBorderWidth; }
            set
            {
                mBorderWidth = value;
                initBorderPen();
            }
        }
        private Pen                 mBorderPen      = new Pen(Color.Black, 1);
        private void                initBorderPen()
        {
            if (mBorderPen != null)
            {
                mBorderPen.Dispose();
            }
            mBorderPen = new Pen(mBorderColor, mBorderWidth);
        }

        public Bitmap               draw(int aWidth, int aHeight)
        {
            var lResult = new Bitmap(aWidth, aHeight);

            using (var lGraphics = Graphics.FromImage(lResult))
            {
                int lBorderDiv2 = (int)mBorderWidth / 2;
                int lW    = aWidth - 1 - (int)mBorderWidth;
                int lH    = aHeight - 1 - (int)mBorderWidth;

                if (mFillColor.A > 0)
                {
                    lGraphics.FillRectangle(mFillBrush, lBorderDiv2, lBorderDiv2, lW, lH);
                }

                if (mBorderWidth != 0)
                {
                    lGraphics.DrawRectangle(mBorderPen, lBorderDiv2, lBorderDiv2, lW, lH);
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
                        if (mBorderPen != null)
                        {
                            mBorderPen.Dispose();
                            mBorderPen = null;
                        }

                        if (mFillBrush != null)
                        {
                            mFillBrush.Dispose();
                            mFillBrush = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
