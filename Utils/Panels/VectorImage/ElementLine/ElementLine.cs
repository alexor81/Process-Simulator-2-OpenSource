// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.VectorImage.ElementLine
{
    public class ElementLine : IVectorElement
    {
        public string               Name { get { return "Line"; } }

        public IVectorElement       Clone
        {
            get
            {
                var lClone          = new ElementLine();
                lClone.mX1          = mX1;
                lClone.mY1          = mY1;
                lClone.mX2          = mX2;
                lClone.mY2          = mY2;
                lClone.LineColor    = mLineColor;
                lClone.LineWidth    = mLineWidth;
                return lClone;
            }
        }

        public int                  mX1         = 0;
        public int                  mY1         = 0;
        public int                  mX2         = 0;
        public int                  mY2         = 0;

        private Color               mLineColor  = Color.Black;
        public Color                LineColor
        {
            get { return mLineColor; }
            set
            {
                mLineColor = value;
                initLinePen();
            }
        }

        private uint                mLineWidth  = 1;
        public uint                 LineWidth
        {
            get { return mLineWidth; }
            set
            {
                mLineWidth = value;
                initLinePen();
            }
        }

        private Pen                 mLinePen    = new Pen(Color.Black, 1);
        private void                initLinePen()
        {
            if (mLinePen != null)
            {
                mLinePen.Dispose();
            }
            mLinePen = new Pen(mLineColor, mLineWidth);
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);

            mX1         = lReader.getAttribute<Int32>("X1");
            mY1         = lReader.getAttribute<Int32>("Y1");
            mX2         = lReader.getAttribute<Int32>("X2");
            mY2         = lReader.getAttribute<Int32>("Y2");

            mLineColor   = lReader.getAttribute<Color>("LineColor", mLineColor);
            mLineWidth   = lReader.getAttribute<UInt32>("LineWidth", mLineWidth);
            initLinePen();
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("X1", StringUtils.ObjectToString(mX1));
            aXMLTextWriter.WriteAttributeString("Y1", StringUtils.ObjectToString(mY1));
            aXMLTextWriter.WriteAttributeString("X2", StringUtils.ObjectToString(mX2));
            aXMLTextWriter.WriteAttributeString("Y2", StringUtils.ObjectToString(mY2));
            aXMLTextWriter.WriteAttributeString("LineColor", StringUtils.ObjectToString(mLineColor));
            aXMLTextWriter.WriteAttributeString("LineWidth", StringUtils.ObjectToString(mLineWidth));
        }

        public void                 draw(Graphics aGraphics)
        {
            if (mLineWidth > 0)
            {
                aGraphics.DrawLine(mLinePen, mX1, mY1, mX2, mY2);
            }
        }

        private PointF[]            rectPoints
        {
            get
            {
                if (mLineWidth <= 1 || ((mX1 == mX2) && (mY1 == mY2)))
                {
                    return new PointF[2] { new PointF(mX1, mY1), new PointF(mX2, mY2) };
                }
                else
                {
                    float lDelta = mLineWidth / 2.0f;
                    if (mX1 == mX2)
                    {
                        float lX1 = mX1 + lDelta;
                        float lX2 = mX1 - lDelta;
                        return new PointF[4] { new PointF(lX2, mY1), new PointF(lX1, mY1), new PointF(lX1, mY2), new PointF(lX2, mY2) };
                    }
                    else if (mY1 == mY2)
                    {
                        float lY1 = mY1 + lDelta;
                        float lY2 = mY1 - lDelta;
                        return new PointF[4] { new PointF(mX1, lY1), new PointF(mX1, lY2), new PointF(mX2, lY2), new PointF(mX2, lY1) };
                    }
                    else
                    {
                        float lAdB  = (float)(mY1 - mY2) / (float)(mX2 - mX1);
                        float lPart = lDelta / (float)Math.Sqrt(1.0f + lAdB * lAdB);

                        float lY1 = mY1 + lPart;
                        float lX1 = lAdB * (lY1 - mY1) + mX1;

                        float lY2 = mY1 - lPart;
                        float lX2 = lAdB * (lY2 - mY1) + mX1;


                        float lY3 = mY2 + lPart;
                        float lX3 = lAdB * (lY3 - mY2) + mX2;

                        float lY4 = mY2 - lPart;
                        float lX4 = lAdB * (lY4 - mY2) + mX2;

                        return new PointF[4] { new PointF(lX1, lY1), new PointF(lX2, lY2), new PointF(lX4, lY4), new PointF(lX3, lY3) };
                    }
                }
            }
        }
            
        private float               MinX
        {
            get
            {
                var lPoints = rectPoints;
                float lX    = lPoints[0].X;
                for(int i = 1; i < lPoints.Length; i++)
                {
                    if(lPoints[i].X < lX)
                    {
                        lX = lPoints[i].X;
                    }
                }

                return lX;
            }
        }

        private float               MinY
        {
            get
            {
                var lPoints = rectPoints;
                float lY    = lPoints[0].Y;
                for (int i = 1; i < lPoints.Length; i++)
                {
                    if (lPoints[i].Y < lY)
                    {
                        lY = lPoints[i].Y;
                    }
                }

                return lY;
            }
        }

        private float               MaxX
        {
            get
            {
                var lPoints = rectPoints;
                float lX    = lPoints[0].X;
                for (int i = 1; i < lPoints.Length; i++)
                {
                    if (lPoints[i].X > lX)
                    {
                        lX = lPoints[i].X;
                    }
                }

                return lX;
            }
        }

        private float               MaxY
        {
            get
            {
                var lPoints = rectPoints;
                float lY    = lPoints[0].Y;
                for (int i = 1; i < lPoints.Length; i++)
                {
                    if (lPoints[i].Y > lY)
                    {
                        lY = lPoints[i].Y;
                    }
                }

                return lY;
            }
        }

        public void                 drawSelected(Graphics aGraphics)
        {
            var lPoints = rectPoints;
            if (lPoints.Length == 2)
            {
                aGraphics.DrawLine(VectorImagePanel.mSelectionPen, lPoints[0], lPoints[1]);
            }
            else
            {
                aGraphics.DrawLine(VectorImagePanel.mSelectionPen, lPoints[0], lPoints[1]);
                aGraphics.DrawLine(VectorImagePanel.mSelectionPen, lPoints[1], lPoints[2]);
                aGraphics.DrawLine(VectorImagePanel.mSelectionPen, lPoints[2], lPoints[3]);
                aGraphics.DrawLine(VectorImagePanel.mSelectionPen, lPoints[3], lPoints[0]);
            }
        }

        public void                 move(int aDx, int aDy)
        {
            mX1 = mX1 + aDx;
            mY1 = mY1 + aDy;

            mX2 = mX2 + aDx;
            mY2 = mY2 + aDy;
        }

        public bool                 testHit(Point aPoint)
        {
            uint lHitDelta = VectorImagePanel.mHitDelta + mLineWidth;

            if (mX1 < mX2)
            {
                if (mX1 - lHitDelta > aPoint.X || mX2 + lHitDelta < aPoint.X)
                {
                    return false;
                }
            }
            else
            {
                if (mX2 - lHitDelta > aPoint.X || mX1 + lHitDelta < aPoint.X)
                {
                    return false;
                }
            }

            if (mY1 < mY2)
            {
                if (mY1 - lHitDelta > aPoint.Y || mY2 + lHitDelta < aPoint.Y)
                {
                    return false;
                }
            }
            else
            {
                if (mY2 - lHitDelta > aPoint.Y || mY1 + lHitDelta < aPoint.Y)
                {
                    return false;
                }
            }

            if (Math.Abs(mX1 - mX2) <= lHitDelta)
            {
                return true;
            }

            if (Math.Abs(mY1 - mY2) <= lHitDelta)
            {
                return true;
            }

            double lA = (double)(mY2 - mY1);
            double lB = (double)(mX1 - mX2);
            double lC = (double)(mX2*mY1) - (double)(mX1*mY2);
            double ld = Math.Abs(lA * (double)aPoint.X + lB * (double)aPoint.Y + lC) / Math.Sqrt(lA*lA + lB*lB);

            if (ld <= lHitDelta)
            {
                return true;
            }

            return false;
        }

        public void                 resize(int aWidth, int aHeight, bool aShift)
        {
            if (aShift)
            {
                if (Math.Abs(aWidth) > Math.Abs(aHeight))
                {
                    mX2 = mX1 + aWidth;
                    mY2 = mY1;
                }
                else
                {
                    mX2 = mX1;
                    mY2 = mY1 + aHeight;
                }
            }
            else
            {
                mX2 = mX1 + aWidth;
                mY2 = mY1 + aHeight;
            }
        }

        public void                 centerVertically(int aX)
        {
            int lHalf = Math.Abs(mX1 - mX2) / 2;

            if(mX1 < mX2)
            {
                mX1 = aX - lHalf;
                mX2 = aX + lHalf;
            }
            else
            {
                mX1 = aX + lHalf;
                mX2 = aX - lHalf;
            }
        }

        public void                 centerHorizantally(int aY)
        {
            int lHalf = Math.Abs(mY1 - mY2) / 2;

            if (mY1 < mY2)
            {
                mY1 = aY - lHalf;
                mY2 = aY + lHalf;
            }
            else
            {
                mY1 = aY + lHalf;
                mY2 = aY - lHalf;
            }
        }

        public void                 alignLeft(int aX)
        {
            int lShift = aX - (int)MinX;
            move(lShift, 0);
        }

        public void                 alignRight(int aX)
        {
            int lShift = aX - (int)MaxX;
            move(lShift, 0);
        }

        public void                 alignTop(int aY)
        {
            int lShift = aY - (int)MinY;
            move(0, lShift);
        }

        public void                 alignBottom(int aY)
        {
            int lShift = aY - (int)MaxY;
            move(0, lShift);
        }

        public Rectangle            coverRect
        {
            get 
            {
                var lPoints = rectPoints;
                int lMinX   = (int)lPoints[0].X;
                int lMinY   = (int)lPoints[0].Y;
                int lMaxX   = (int)lPoints[0].X;
                int lMaxY   = (int)lPoints[0].Y;

                for (int i = 1; i < lPoints.Length; i++)
                {
                    if (lPoints[i].X < lMinX) { lMinX = (int)lPoints[i].X; }
                    if (lPoints[i].Y < lMinY) { lMinY = (int)lPoints[i].Y; }
                    if (lPoints[i].X > lMaxX) { lMaxX = (int)lPoints[i].X; }
                    if (lPoints[i].Y > lMaxY) { lMaxY = (int)lPoints[i].Y; }
                }

                if (lMinX == lMaxX && lMinY == lMaxY)
                {
                    return new Rectangle((int)lMinX, (int)lMinY, -1, -1);
                }
                else if (lMinX == lMaxX)
                {
                    return new Rectangle((int)lMinX, (int)lMinY, -1, (int)(lMaxY - lMinY) - 1);
                }
                else if (lMinY == lMaxY)
                {
                    return new Rectangle((int)lMinX, (int)lMinY, (int)(lMaxX - lMinX) - 1, -1);
                }
                else
                {
                    return new Rectangle((int)lMinX, (int)lMinY, (int)(lMaxX - lMinX) - 1, (int)(lMaxY - lMinY) - 1);
                }
            }
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
