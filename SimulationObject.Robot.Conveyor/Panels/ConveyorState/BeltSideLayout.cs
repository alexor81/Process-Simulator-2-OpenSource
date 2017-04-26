// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using Utils;

namespace SimulationObject.Robot.Conveyor.Panel
{
    public class BeltSideLayout: IConveyorLayout
    {
        private bool                mDrawDynamics;
        private float               mR;
        private float               mRMult2;

        private float               mXp1;
        private float               mYp1;
        private float               mX11;
        private float               mY11;
        private float               mX12;
        private float               mY12;

        private float               mXp2;
        private float               mYp2;
        private float               mX21;
        private float               mY21;
        private float               mX22;
        private float               mY22;

        private const double        mSpeedCoef = 0.5 / (30.0 * 100.0); // Максимальная скорость 0.5 радиана за 30 мс, делить на 100%

        private bool                mDrawSpeedArrow;
        private float               mSHeightDiv2;
        private Point               mArrowPoint;
        private SizeF               mSpeedSize;
        private Rectangle           mSpeedFRect;
        private Rectangle           mSpeedBRect;
        private StringFormat        mSpeedFormat         = new StringFormat();
        private Font                mSpeedFont           = new Font("Microsoft Sans Serif", 7);
        private Bitmap              mForwardArrow;
        private Bitmap              mBackwardArrow;

        public                      BeltSideLayout()
        {
            mSpeedFormat.Alignment      = StringAlignment.Center;
            mSpeedFormat.LineAlignment  = StringAlignment.Center;
        }

        public void                 drawBackground(Bitmap aBackground)
        {
            float lHeightSub1 = aBackground.Height - 1.0f;
            float lHeightDiv2 = aBackground.Height / 2.0f;

            mR      = lHeightDiv2 /  7.0f;
            mRMult2 = mR * 2.0f;

            mXp1 = lHeightSub1 / 2.0f;
            mYp1 = mXp1;

            float lR = mXp1 / 2.0f;

            mX11 = mXp1 + lR;
            mY11 = mYp1;

            mX12 = mXp1 - lR;
            mY12 = mY11;

            mXp2 = aBackground.Width - mXp1;
            mYp2 = mXp1;

            mX21 = mXp2 + lR;
            mY21 = mYp2;

            mX22 = mXp2 - lR;
            mY22 = mY21;

            float lHeightMult2  = aBackground.Height * 2;
            mDrawDynamics       = aBackground.Width >= lHeightMult2;

            using (var lGraphics = Graphics.FromImage(aBackground))
            {
                mSpeedSize      = lGraphics.MeasureString(" 100 % ", mSpeedFont);

                lGraphics.Clear(Color.Transparent);
                lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                lGraphics.DrawEllipse(Pens.Black, 0, 0, lHeightSub1, lHeightSub1);
                lGraphics.DrawEllipse(Pens.Black, aBackground.Width - aBackground.Height, 0, lHeightSub1, lHeightSub1);
                lGraphics.DrawLine(Pens.Black, lHeightDiv2, 0, aBackground.Width - lHeightDiv2, 0);
                lGraphics.DrawLine(Pens.Black, lHeightDiv2, lHeightSub1, aBackground.Width - lHeightDiv2, lHeightSub1);
            }

            if (mForwardArrow != null)
            {
                mForwardArrow.Dispose();
                mForwardArrow = null;
            }

            if (mBackwardArrow != null)
            {
                mBackwardArrow.Dispose();
                mBackwardArrow = null;
            }

            mSHeightDiv2    = mSpeedSize.Height / 2.0f;
            mDrawSpeedArrow = (mSpeedSize.Width  + lHeightMult2 + mSHeightDiv2) <= aBackground.Width;
            if (mDrawSpeedArrow)
            {  
                float lArrowH   = mSpeedSize.Height * 2.0f;
                float lArrorW   = mSpeedSize.Width + mSHeightDiv2;

                mArrowPoint     = new Point(aBackground.Width / 2 - (int)lArrorW / 2, aBackground.Height / 2 - (int)lArrowH / 2);
                mSpeedFRect     = new Rectangle(mArrowPoint.X, mArrowPoint.Y + (int)mSHeightDiv2, (int)mSpeedSize.Width, (int)mSpeedSize.Height);            
                mSpeedBRect     = new Rectangle(mArrowPoint.X + (int)mSHeightDiv2, mArrowPoint.Y + (int)mSHeightDiv2, (int)mSpeedSize.Width, (int)mSpeedSize.Height);

                mForwardArrow = new Bitmap((int)lArrorW, (int)lArrowH);
                using (var lGraphics = Graphics.FromImage(mForwardArrow))
                {
                    lGraphics.Clear(Color.Transparent);
                    lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    lGraphics.FillRectangle(Brushes.Silver, 0, mSHeightDiv2, mSpeedSize.Width, mSpeedSize.Height);

                    float lTemp = mSpeedSize.Width - mSHeightDiv2;
                    lGraphics.FillPolygon(Brushes.Silver, new PointF[] { new PointF(lTemp, 0),
                                                                       new PointF(lTemp, mForwardArrow.Height),
                                                                       new PointF(mForwardArrow.Width, mSpeedSize.Height) });
                }

                mBackwardArrow = new Bitmap((int)lArrorW, (int)lArrowH);;
                using (var lGraphics = Graphics.FromImage(mBackwardArrow))
                {
                    lGraphics.Clear(Color.Transparent);
                    lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                    lGraphics.FillRectangle(Brushes.Silver, mSHeightDiv2, mSHeightDiv2, mSpeedSize.Width, mSpeedSize.Height);

                    float lTemp = mSHeightDiv2;
                    lGraphics.FillPolygon(Brushes.Silver, new PointF[] { new PointF(mSpeedSize.Height, 0),
                                                                       new PointF(mSpeedSize.Height, mForwardArrow.Height),
                                                                       new PointF(0, mSpeedSize.Height) });
                }
            }
        }
    
        public void                 drawControl(Bitmap aControl, Bitmap aBackground, bool aMoving, bool aForward, bool aAlarm)
        {
            using (var lGraphics = Graphics.FromImage(aControl))
            {
                lGraphics.Clear(Color.Transparent);
                lGraphics.DrawImage(aBackground, 0, 0);

                lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                if (aAlarm)
                {
                    lGraphics.DrawRectangle(Pens.Red, 0, 0, aBackground.Width - 1, aBackground.Height - 1); 
                }

                if (mDrawSpeedArrow && aMoving)
                {
                    if (aForward)
                    {
                        lGraphics.DrawImage(mForwardArrow, mArrowPoint);
                    }
                    else
                    {
                        lGraphics.DrawImage(mBackwardArrow, mArrowPoint);                                        
                    }                   
                }
            }
        }

        public void                 draw(long aMSFromLast, Graphics aGraphics, Bitmap aControl, 
                                            bool aMoving, double aSpeed, bool aForward)
        {
            aGraphics.Clear(Color.Transparent);
            aGraphics.DrawImage(aControl, 0, 0);

            if (mDrawDynamics == false) return;

            if (aMoving && aSpeed > 0.0)
            {
                #region Rotation

                    double lAngle = aMSFromLast * mSpeedCoef * aSpeed;

                    float lSinA = (float)Math.Sin(lAngle);
                    float lCosA = (float)Math.Cos(lAngle);
                
                    float lReverse;
                    if (aForward)
                    {
                        lReverse = 1;
                    }
                    else
                    {
                        lReverse = -1;
                    }

                    float lX = mXp1 + (mX11 - mXp1) * lCosA - lReverse * (mY11 - mYp1) * lSinA;
                    float lY = mYp1 + (mY11 - mYp1) * lCosA + lReverse * (mX11 - mXp1) * lSinA;
                    mX11 = lX;
                    mY11 = lY;
                    aGraphics.FillEllipse(Brushes.Black, mX11 - mR, mY11 - mR, mRMult2, mRMult2);

                    lX = mXp1 + (mX12 - mXp1) * lCosA - lReverse * (mY12 - mYp1) * lSinA;
                    lY = mYp1 + (mY12 - mYp1) * lCosA + lReverse * (mX12 - mXp1) * lSinA;
                    mX12 = lX;
                    mY12 = lY;
                    aGraphics.FillEllipse(Brushes.Black, mX12 - mR, mY12 - mR, mRMult2, mRMult2);

                    lX = mXp2 + (mX21 - mXp2) * lCosA - lReverse * (mY21 - mYp2) * lSinA;
                    lY = mYp2 + (mY21 - mYp2) * lCosA + lReverse * (mX21 - mXp2) * lSinA;
                    mX21 = lX;
                    mY21 = lY;
                    aGraphics.FillEllipse(Brushes.Black, mX21 - mR, mY21 - mR, mRMult2, mRMult2);

                    lX = mXp2 + (mX22 - mXp2) * lCosA - lReverse * (mY22 - mYp2) * lSinA;
                    lY = mYp2 + (mY22 - mYp2) * lCosA + lReverse * (mX22 - mXp2) * lSinA;
                    mX22 = lX;
                    mY22 = lY;
                    aGraphics.FillEllipse(Brushes.Black, mX22 - mR, mY22 - mR, mRMult2, mRMult2);

                #endregion

                #region Speed

                    if (mDrawSpeedArrow)
                    {
                        Rectangle lRect;
                        if (aForward)
                        {
                            lRect = mSpeedFRect;
                        }
                        else
                        {
                            lRect = mSpeedBRect;
                        }

                        aGraphics.DrawString(StringUtils.ObjectToString(Math.Round(aSpeed, 0, MidpointRounding.AwayFromZero)) + " %",
                                             mSpeedFont, Brushes.Black, lRect, mSpeedFormat);
                    }

                #endregion
            }
            else
            {
                #region Rotation    

                    aGraphics.FillEllipse(Brushes.Black, mX11 - mR, mY11 - mR, mRMult2, mRMult2);
                    aGraphics.FillEllipse(Brushes.Black, mX12 - mR, mY12 - mR, mRMult2, mRMult2);
                    aGraphics.FillEllipse(Brushes.Black, mX21 - mR, mY21 - mR, mRMult2, mRMult2);
                    aGraphics.FillEllipse(Brushes.Black, mX22 - mR, mY22 - mR, mRMult2, mRMult2);

                #endregion

                #region Speed

                    if (mDrawSpeedArrow)
                    {
                        aGraphics.DrawString(StringUtils.ObjectToString(Math.Round(aSpeed, 0, MidpointRounding.AwayFromZero)) + " %",
                                             mSpeedFont, Brushes.Black, new Rectangle(0, 0, aControl.Width, aControl.Height), mSpeedFormat);
                    }

                #endregion
            }
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
                        if (mSpeedFont != null)
                        {
                            mSpeedFont.Dispose();
                            mSpeedFont = null;
                        }

                        if (mSpeedFormat != null)
                        {
                            mSpeedFormat.Dispose();
                            mSpeedFormat = null;
                        }

                        if (mForwardArrow != null)
                        {
                            mForwardArrow.Dispose();
                            mForwardArrow = null;
                        }

                        if (mBackwardArrow != null)
                        {
                            mBackwardArrow.Dispose();
                            mBackwardArrow = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion    
    }
}
