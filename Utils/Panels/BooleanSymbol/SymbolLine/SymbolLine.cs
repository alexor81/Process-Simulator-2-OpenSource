// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanSymbol.SymbolLine
{
    public class SymbolLine: ISymbol
    {
        public string               Name { get { return "Line"; } }

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

            mLineColor = lReader.getAttribute<Color>("Color", mLineColor);
            mLineWidth = lReader.getAttribute<UInt32>("Width", mLineWidth);
            initLinePen();

            Angle = lReader.getAttribute<Int32>("Angle", mAngle);
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Color", StringUtils.ObjectToString(mLineColor));
            aXMLTextWriter.WriteAttributeString("Width", StringUtils.ObjectToString(mLineWidth));
            aXMLTextWriter.WriteAttributeString("Angle", StringUtils.ObjectToString(mAngle));
        }

        private int                 mAngle          = 0;
        public int                  Angle
        {
            get { return mAngle; }
            set
            {
                if (value < 0)      value = 0;
                if (value > 180)    value = 180;
                mAngle = value;
            }
        }

        private Color               mLineColor      = Color.Black;
        public Color                LineColor
        {
            get { return mLineColor; }
            set
            {
                mLineColor = value;
                initLinePen();
            }
        }
        private uint                mLineWidth      = 1;
        public uint                 LineWidth
        {
            get { return mLineWidth; }
            set
            {
                mLineWidth = value;
                initLinePen();
            }
        }
        private Pen                 mLinePen        = new Pen(Color.Black, 1);
        private void                initLinePen()
        {
            if (mLinePen != null)
            {
                mLinePen.Dispose();
            }
            mLinePen = new Pen(mLineColor, mLineWidth);
        }

        public Bitmap               draw(int aWidth, int aHeight)
        {
            var lResult = new Bitmap(aWidth, aHeight);

            using (var lGraphics = Graphics.FromImage(lResult))
            {
                lGraphics.Clear(Color.Transparent);
                lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (mLineWidth > 0)
                {
                    double lXCenter = aWidth / 2.0;
                    double lYCenter = aHeight / 2.0;

                    if (mAngle == 0 || mAngle == 180)
                    {
                        lGraphics.DrawLine(mLinePen, 0.0f, (float)lYCenter, aWidth, (float)lYCenter);
                    }
                    else if (mAngle == 90)
                    {
                        lGraphics.DrawLine(mLinePen, (float)lXCenter, 0.0f, (float)lXCenter, aHeight);
                    }
                    else
                    {
                        double lK       = Math.Tan(Math.PI * (180.0 - mAngle) / 180.0);
                        double lYifX0   = lYCenter - lK * lXCenter;

                        if (lYifX0 >= 0 && lYifX0 <= aHeight)
                        {
                            lGraphics.DrawLine(mLinePen, 0.0f, (float)lYifX0, aWidth, (float)(aHeight - lYifX0));
                        }
                        else
                        {
                            double lXifY0 = lXCenter - lYCenter / lK;
                            lGraphics.DrawLine(mLinePen, (float)lXifY0, 0.0f, (float)(aWidth - lXifY0), aHeight);
                        }
                    }
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
                        if (mLinePen != null)
                        {
                            mLinePen.Dispose();
                            mLinePen = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
