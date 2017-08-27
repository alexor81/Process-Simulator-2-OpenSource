// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.VectorImage.ElementText
{
    public enum ERotation
    {
        Rotate0     = 0,
        Rotate90    = 1,
        Rotate180   = 2,
        Rotate270   = 3
    }

    public class ElementText : IVectorElement
    {
        public string               Name { get { return "Text"; } }

        public IVectorElement       Clone
        {
            get
            {
                var lClone          = new ElementText();
                lClone.mX           = mX;
                lClone.mY           = mY;
                lClone.mText        = mText;
                lClone.TextFont     = (Font)mTextFont.Clone();
                lClone.TextColor    = mTextColor;
                lClone.mRotation    = mRotation;
                return lClone;
            }
        }

        public int                  mX          = 0;
        public int                  mY          = 0;
        public string               mText       = "Text";

        private Font                mTextFont   = new Font(SystemFonts.DefaultFont.Name, SystemFonts.DefaultFont.Size);
        public Font                 TextFont
        {
            get { return mTextFont; }
            set { mTextFont = value; }
        }

        private Color               mTextColor  = Color.Black;
        public Color                TextColor
        {
            get { return mTextColor; }
            set
            {
                if (mBrish != null)
                {
                    mBrish.Dispose();
                }

                mTextColor  = value;
                mBrish      = new SolidBrush(mTextColor);
            }
        }

        private Brush               mBrish      = new SolidBrush(Color.Black);

        public ERotation            mRotation   = ERotation.Rotate0;

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);

            mX          = lReader.getAttribute<Int32>("X");
            mY          = lReader.getAttribute<Int32>("Y");
            mText       = lReader.getAttribute<string>("Text");
            TextFont    = lReader.getAttribute<Font>("Font", mTextFont);
            TextColor   = lReader.getAttribute<Color>("Color", mTextColor);
            mRotation   = (ERotation)Enum.Parse(typeof(ERotation), lReader.getAttribute<String>("Rotation", ERotation.Rotate0.ToString()));
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("X", StringUtils.ObjectToString(mX));
            aXMLTextWriter.WriteAttributeString("Y", StringUtils.ObjectToString(mY));
            aXMLTextWriter.WriteAttributeString("Text", mText);
            aXMLTextWriter.WriteAttributeString("Font", StringUtils.ObjectToString(mTextFont));
            aXMLTextWriter.WriteAttributeString("Color", StringUtils.ObjectToString(mTextColor));
            aXMLTextWriter.WriteAttributeString("Rotation", StringUtils.ObjectToString(mRotation));
        }

        private void                drawText(Graphics aGraphics)
        {
            if (String.IsNullOrWhiteSpace(mText) == false)
            {
                Size lSize = aGraphics.MeasureString(mText, mTextFont).ToSize();

                using (var lBmp = new Bitmap(lSize.Width + 2, lSize.Height))
                {
                    using (var lGraphics = Graphics.FromImage(lBmp))
                    {
                        lGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                        lGraphics.Clear(Color.Transparent);
                        lGraphics.DrawString(mText, mTextFont, mBrish, 0, 0);
                    }

                    switch (mRotation)
                    {
                        case ERotation.Rotate90:    lBmp.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                        case ERotation.Rotate180:   lBmp.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                        case ERotation.Rotate270:   lBmp.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                        default:                    break;
                    }

                    aGraphics.DrawImage(lBmp, mX, mY);
                    mSize = lBmp.Size;
                }
            }
            else
            {
                mSize = new Size();
            }
        }

        public void                 draw(Graphics aGraphics)
        {
            drawText(aGraphics);
        }

        public void                 drawSelected(Graphics aGraphics)
        {
            drawText(aGraphics);
            aGraphics.DrawRectangle(VectorImagePanel.mSelectionPen, mX, mY, mSize.Width, mSize.Height);
        }

        private Size                mSize;
        public bool                 testHit(Point aPoint)
        {
            if (mSize != null)
            {
                return (aPoint.X >= mX && aPoint.X <= mX + mSize.Width && aPoint.Y >= mY && aPoint.Y <= mY + mSize.Height);
            }
            return false;
        }

        public void                 move(int aDx, int aDy)
        {
            mX = mX + aDx;
            mY = mY + aDy;
        }

        public void                 resize(int aWidth, int aHeight, bool aShift)
        {
        }

        public void                 centerVertically(int aX)
        {
            mX = aX - mSize.Width / 2;
        }

        public void                 centerHorizantally(int aY)
        {
            mY = aY - mSize.Height / 2;
        }

        public void                 alignLeft(int aX)
        {
            mX = aX;
        }

        public void                 alignRight(int aX)
        {
            mX = aX - mSize.Width - 1;
        }

        public void                 alignTop(int aY)
        {
            mY = aY;
        }

        public void                 alignBottom(int aY)
        {
            mY = aY - mSize.Height - 1;
        }

        public Rectangle            coverRect
        {
            get { return new Rectangle(mX, mY, mSize.Width, mSize.Height); }
        }

        public Form                 getSetupForm(IRedraw aRedraw)
        {
            return new SetupForm(this, aRedraw);
        }

        #region IDisposable

            private bool            mDisposed   = false;

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
                        if (mBrish != null)
                        {
                            mBrish.Dispose();
                            mBrish = null;
                        }

                        if(mTextFont != null)
                        {
                            mTextFont.Dispose();
                            mTextFont = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
