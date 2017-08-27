// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.VectorImage.ElementRectangle
{
    public class ElementRectangle: IVectorElement
    {
        public string               Name { get { return "Rectangle"; } }

        public IVectorElement       Clone
        {
            get
            {
                var lClone          = new ElementRectangle();
                lClone.mX           = mX;
                lClone.mY           = mY;
                lClone.mWidth       = mWidth;
                lClone.mHeight      = mHeight;
                lClone.BorderColor  = mBorderColor;
                lClone.BorderWidth  = mBorderWidth;
                lClone.FillColor    = mFillColor;
                return lClone;
            }
        }

        public int                  mX              = 0;
        public int                  mY              = 0;
        public int                  mWidth          = 0;
        public int                  mHeight         = 0;

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

        private Color               mFillColor      = Color.Transparent;
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

        private Brush               mFillBrush;

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);

            mX          = lReader.getAttribute<Int32>("X");
            mY          = lReader.getAttribute<Int32>("Y");
            mWidth      = lReader.getAttribute<Int32>("Width");
            mHeight     = lReader.getAttribute<Int32>("Height");

            mBorderColor = lReader.getAttribute<Color>("BorderColor", mBorderColor);
            mBorderWidth = lReader.getAttribute<UInt32>("BorderWidth", mBorderWidth);
            initBorderPen();

            FillColor   = lReader.getAttribute<Color>("FillColor", mFillColor);

            if (mWidth < 0 || mHeight < 0)
            {
                var lRect   = normalize();
                mX          = lRect.X;
                mY          = lRect.Y;
                mWidth      = lRect.Width;
                mHeight     = lRect.Height;
            }
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("X", StringUtils.ObjectToString(mX));
            aXMLTextWriter.WriteAttributeString("Y", StringUtils.ObjectToString(mY));
            aXMLTextWriter.WriteAttributeString("Width", StringUtils.ObjectToString(mWidth));
            aXMLTextWriter.WriteAttributeString("Height", StringUtils.ObjectToString(mHeight));
            aXMLTextWriter.WriteAttributeString("BorderColor", StringUtils.ObjectToString(mBorderColor));
            aXMLTextWriter.WriteAttributeString("BorderWidth", StringUtils.ObjectToString(mBorderWidth));
            aXMLTextWriter.WriteAttributeString("FillColor", StringUtils.ObjectToString(mFillColor));
        }

        public void                 draw(Graphics aGraphics)
        {
            if (mWidth < 0 || mHeight < 0)
            {
                var lRect   = normalize();
                mX          = lRect.X;
                mY          = lRect.Y;
                mWidth      = lRect.Width;
                mHeight     = lRect.Height;
            }

            if (mFillColor.A > 0)
            {
                aGraphics.FillRectangle(mFillBrush, mX, mY, mWidth, mHeight);
            }

            if (mBorderWidth != 0)
            {
                aGraphics.DrawRectangle(mBorderPen, mX, mY, mWidth, mHeight);
            }
        }

        public void                 drawSelected(Graphics aGraphics)
        {
            var lRect = normalize();
            if (mBorderWidth <= 1)
            {
                aGraphics.DrawRectangle(VectorImagePanel.mSelectionPen, lRect);
            }
            else
            {
                int lDelta = (int)mBorderWidth / 2;
                aGraphics.DrawRectangle(VectorImagePanel.mSelectionPen, lRect.X + lDelta, lRect.Y + lDelta, lRect.Width - mBorderWidth, lRect.Height - mBorderWidth);
                aGraphics.DrawRectangle(VectorImagePanel.mSelectionPen, lRect.X - lDelta, lRect.Y - lDelta, lRect.Width + mBorderWidth, lRect.Height + mBorderWidth);
            }
        }

        public void                 move(int aDx, int aDy)
        {
            mX = mX + aDx;
            mY = mY + aDy;
        }

        public bool                 testHit(Point aPoint)
        {
            uint lHitDelta      = VectorImagePanel.mHitDelta + mBorderWidth;
            uint lDoubleDelta   = lHitDelta + lHitDelta;

            if (mFillColor.ToArgb() == Color.Transparent.ToArgb() && mWidth > lDoubleDelta && mHeight > lDoubleDelta)
            {
                if (Math.Abs(mX - aPoint.X) <= lHitDelta)
                {
                    return (aPoint.Y >= mY - lHitDelta && aPoint.Y <= mY + mHeight + lHitDelta);
                }
                else if (Math.Abs(mX + mWidth - aPoint.X) <= lHitDelta)
                {
                    return (aPoint.Y >= mY - lHitDelta && aPoint.Y <= mY + mHeight + lHitDelta);
                }
                else if (Math.Abs(mY - aPoint.Y) <= lHitDelta)
                {
                    return (aPoint.X >= mX - lHitDelta && aPoint.X <= mX + mWidth + lHitDelta);
                }
                else if (Math.Abs(mY + mHeight - aPoint.Y) <= lHitDelta)
                {
                    return (aPoint.X >= mX - lHitDelta && aPoint.X <= mX + mWidth + lHitDelta);
                }
            }
            else
            {
                return (aPoint.X >= mX && aPoint.X <= mX + mWidth && aPoint.Y >= mY && aPoint.Y <= mY + mHeight);
            }

            return false;
        }

        public void                 resize(int aWidth, int aHeight, bool aShift)
        {
            if (aShift)
            {
                if (Math.Abs(aWidth) < Math.Abs(aHeight))
                {
                    mWidth = aWidth;
                    if (aHeight > 0)
                    {
                        mHeight = Math.Abs(aWidth);
                    }
                    else
                    {
                        mHeight = -Math.Abs(aWidth);
                    }
                }
                else
                {
                    mHeight = aHeight;
                    if (aWidth > 0)
                    {
                        mWidth = Math.Abs(aHeight);
                    }
                    else
                    {
                        mWidth = -Math.Abs(aHeight);
                    }
                }
            }
            else
            {
                mWidth  = aWidth;
                mHeight = aHeight;
            }
        }

        public void                 centerVertically(int aX)
        {
            mX = aX - mWidth / 2;
        }

        public void                 centerHorizantally(int aY)
        {
            mY = aY - mHeight / 2;
        }

        public void                 alignLeft(int aX)
        {
            mX = aX + (int)mBorderWidth / 2;
        }

        public void                 alignRight(int aX)
        {
            mX = aX - mWidth - 1 - (int)mBorderWidth / 2;
        }

        public void                 alignTop(int aY)
        {
            mY = aY + (int)mBorderWidth / 2;
        }

        public void                 alignBottom(int aY)
        {
            mY = aY - mHeight - 1 - (int)mBorderWidth / 2;
        }

        public Rectangle            coverRect
        {
            get 
            {
                int lDelta  = (int)mBorderWidth / 2;
                int l2Delta = 2 * lDelta;
                return new Rectangle(mX - lDelta, mY - lDelta, mWidth + l2Delta, mHeight + l2Delta); 
            }
        }

        private Rectangle           normalize()
        {
            int lX, lY, lH, lW;

            if (mWidth < 0)
            {
                lX = mX + mWidth;
                lW = Math.Abs(mWidth);
            }
            else
            {
                lX = mX;
                lW = mWidth;
            }

            if (mHeight < 0)
            {
                lY = mY + mHeight;
                lH = Math.Abs(mHeight);
            }
            else
            {
                lY = mY;
                lH = mHeight;
            }
            
            return new Rectangle( lX, lY, lW, lH );
        }

        public Form                 getSetupForm(IRedraw aRedraw)
        {
            return new SetupForm(this, aRedraw);
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
