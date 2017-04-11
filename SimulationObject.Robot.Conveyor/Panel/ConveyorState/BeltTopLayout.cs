// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using Utils;

namespace SimulationObject.Robot.Conveyor.Panel.ConveyorState
{
    public class BeltTopLayout: IConveyorLayout
    {
        private float               mL1;
        private float               mL2;
        private float               mL3;
        private const float         mSpeedCoef = 1.0f / 1500.0f;

        private bool                mDrawSpeedArrow;
        private bool                mHorizontal;
        private float               mSHeightDiv2;
        private Point               mArrowPoint;
        private SizeF               mSpeedSize;
        private Rectangle           mSpeedFRect;
        private Rectangle           mSpeedBRect;
        private StringFormat        mSpeedFormat         = new StringFormat();
        private Font                mSpeedFont           = new Font("Microsoft Sans Serif", 7);
        private Bitmap              mForwardArrow;
        private Bitmap              mBackwardArrow;

        public                      BeltTopLayout()
        {
            mSpeedFormat.Alignment      = StringAlignment.Center;
            mSpeedFormat.LineAlignment  = StringAlignment.Center;
        }

        public void                 drawBackground(Bitmap aBackground)
        {
            float lHeightSub1   = aBackground.Height - 1.0f;
            float lWidthSub1    = aBackground.Width - 1.0f;
            mHorizontal         = aBackground.Width > aBackground.Height;

            float lD;
            if (mHorizontal)
            {
               lD = lWidthSub1 / 3.0f;
            }
            else
            {
                lD = lHeightSub1 / 3.0f;
            }
            mL1 = lD;
            mL2 = lD + lD;
            mL3 = mL2 + lD;

            using (var lGraphics = Graphics.FromImage(aBackground))
            {
                mSpeedSize = lGraphics.MeasureString(" 100 % ", mSpeedFont);

                lGraphics.Clear(Color.Transparent);
                lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                lGraphics.DrawRectangle(Pens.Black, 0.0f, 0.0f, lWidthSub1, lHeightSub1);
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
            
            if (mHorizontal)
            {          
                mDrawSpeedArrow = (mSpeedSize.Width + mSHeightDiv2) <= aBackground.Width;
                if (mDrawSpeedArrow)
                {  
                    float lArrowH   = mSpeedSize.Height * 2.0f;
                    float lArrorW   = mSpeedSize.Width + mSHeightDiv2;

                    mArrowPoint     = new Point(aBackground.Width / 2 - (int)lArrorW / 2, aBackground.Height / 2 - (int)lArrowH / 2);
                    mSpeedFRect     = new Rectangle(mArrowPoint.X, mArrowPoint.Y + (int)mSHeightDiv2, (int)mSpeedSize.Width, (int)mSpeedSize.Height);
                    mSpeedBRect     = new Rectangle(mArrowPoint.X + (int)mSHeightDiv2, mArrowPoint.Y + (int)mSHeightDiv2, (int)mSpeedSize.Width, (int)mSpeedSize.Height);

                    mForwardArrow   = new Bitmap((int)lArrorW, (int)lArrowH);
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

                    mBackwardArrow  = new Bitmap((int)lArrorW, (int)lArrowH);;
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
            else
            {
                mDrawSpeedArrow = (mSpeedSize.Width + mSHeightDiv2) <= aBackground.Height;
                if (mDrawSpeedArrow)
                {
                    float lArrowH   = mSpeedSize.Width + mSHeightDiv2;
                    float lArrorW   = mSpeedSize.Height * 2.0f;

                    mArrowPoint     = new Point(aBackground.Width / 2 - (int)lArrorW / 2, aBackground.Height / 2 - (int)lArrowH / 2);
                    mSpeedFRect     = new Rectangle(mArrowPoint.X + (int)mSHeightDiv2, mArrowPoint.Y + (int)mSHeightDiv2, (int)mSpeedSize.Height, (int)mSpeedSize.Width);
                    mSpeedBRect     = new Rectangle(mArrowPoint.X + (int)mSHeightDiv2, mArrowPoint.Y, (int)mSpeedSize.Height, (int)mSpeedSize.Width);

                    mForwardArrow   = new Bitmap((int)lArrorW, (int)lArrowH);
                    using (var lGraphics = Graphics.FromImage(mForwardArrow))
                    {
                        lGraphics.Clear(Color.Transparent);
                        lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        lGraphics.FillRectangle(Brushes.Gray, mSHeightDiv2, mSHeightDiv2, mSpeedSize.Height, mSpeedSize.Width);

                        lGraphics.FillPolygon(Brushes.Gray, new PointF[] { new PointF(0, mSpeedSize.Height),
                                                                           new PointF(mSpeedSize.Height, 0),
                                                                           new PointF(mForwardArrow.Width, mSpeedSize.Height) });
                    }

                    mBackwardArrow  = new Bitmap((int)lArrorW, (int)lArrowH);;
                    using (var lGraphics = Graphics.FromImage(mBackwardArrow))
                    {
                        lGraphics.Clear(Color.Transparent);
                        lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        lGraphics.FillRectangle(Brushes.Gray, mSHeightDiv2, 0, mSpeedSize.Height, mSpeedSize.Width);

                        float lTemp = mSpeedSize.Width - mSHeightDiv2;
                        lGraphics.FillPolygon(Brushes.Gray, new PointF[] { new PointF(0, lTemp),
                                                                           new PointF(mSpeedSize.Height, mBackwardArrow.Height),
                                                                           new PointF(mBackwardArrow.Width, lTemp) });
                    }
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

        private void                drawLines(Graphics aGraphics, float aWidth, float aHeight)
        {
            if (mHorizontal)
            {
                float lH = aHeight - 2.0f;
                aGraphics.DrawLine(Pens.Silver, mL1, 1, mL1, lH);
                aGraphics.DrawLine(Pens.Silver, mL2, 1, mL2, lH);
                aGraphics.DrawLine(Pens.Silver, mL3, 1, mL3, lH);
            }
            else
            {
                float lW = aWidth - 2.0f;
                aGraphics.DrawLine(Pens.Silver, 1, mL1, lW, mL1);
                aGraphics.DrawLine(Pens.Silver, 1, mL2, lW, mL2);
                aGraphics.DrawLine(Pens.Silver, 1, mL3, lW, mL3);
            }
        }

        public void                 draw(long aMSFromLast, Graphics aGraphics, Bitmap aControl, 
                                            bool aMoving, double aSpeed, bool aForward)
        {
            aGraphics.Clear(Color.Transparent);
            aGraphics.DrawImage(aControl, 0, 0);

            if (aMoving && aSpeed > 0.0)
            {
                #region Lines

                    float lDelta = aMSFromLast * mSpeedCoef * (float)aSpeed;

                    if (aForward)
                    {
                        if (mHorizontal)
                        {
                            mL1 = mL1 + lDelta;
                            mL2 = mL2 + lDelta;
                            mL3 = mL3 + lDelta;

                            if (mL1 > aControl.Width) mL1 = 0.0f;
                            if (mL2 > aControl.Width) mL2 = 0.0f;
                            if (mL3 > aControl.Width) mL3 = 0.0f;
                        }
                        else
                        {
                            mL1 = mL1 - lDelta;
                            mL2 = mL2 - lDelta;
                            mL3 = mL3 - lDelta;

                            if (mL1 < 0) mL1 = aControl.Height;
                            if (mL2 < 0) mL2 = aControl.Height;
                            if (mL3 < 0) mL3 = aControl.Height;
                        }
                    }
                    else
                    {
                        if (mHorizontal)
                        {
                            mL1 = mL1 - lDelta;
                            mL2 = mL2 - lDelta;
                            mL3 = mL3 - lDelta;

                            if (mL1 < 0) mL1 = aControl.Width;
                            if (mL2 < 0) mL2 = aControl.Width;
                            if (mL3 < 0) mL3 = aControl.Width;
                        }
                        else
                        {
                            mL1 = mL1 + lDelta;
                            mL2 = mL2 + lDelta;
                            mL3 = mL3 + lDelta;

                            if (mL1 > aControl.Height) mL1 = 0.0f;
                            if (mL2 > aControl.Height) mL2 = 0.0f;
                            if (mL3 > aControl.Height) mL3 = 0.0f;
                        }
                    }

                    drawLines(aGraphics, aControl.Width, aControl.Height);

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

                        if (mHorizontal)
                        {                       
                            aGraphics.DrawString(StringUtils.ObjectToString(Math.Round(aSpeed, 0, MidpointRounding.AwayFromZero)) + " %",
                                                     mSpeedFont, Brushes.Black, lRect, mSpeedFormat);
                        }
                        else
                        {
                            aGraphics.TranslateTransform(lRect.X + mSpeedSize.Height, lRect.Y);
                            aGraphics.RotateTransform(90);
                            aGraphics.DrawString(StringUtils.ObjectToString(Math.Round(aSpeed, 0, MidpointRounding.AwayFromZero)) + " %",
                                                     mSpeedFont, Brushes.Black, 0, 0);
                            aGraphics.ResetTransform();
                        }
                    }

                #endregion
            }
            else
            {
                #region Lines

                    drawLines(aGraphics, aControl.Width, aControl.Height);

                #endregion

                #region Speed

                if (mDrawSpeedArrow)
                    {
                        if (mHorizontal)
                        {
                            aGraphics.DrawString(StringUtils.ObjectToString(Math.Round(aSpeed, 0, MidpointRounding.AwayFromZero)) + " %",
                                                    mSpeedFont, Brushes.Black, new Rectangle(0, 0, aControl.Width, aControl.Height), mSpeedFormat);
                        }
                        else
                        {
                            aGraphics.TranslateTransform(mSpeedSize.Height + aControl.Width / 2.0f - mSpeedSize.Height / 2.0f, aControl.Height / 2.0f - mSpeedSize.Width / 2.0f);
                            aGraphics.RotateTransform(90);
                            aGraphics.DrawString(StringUtils.ObjectToString(Math.Round(aSpeed, 0, MidpointRounding.AwayFromZero)) + " %",
                                                     mSpeedFont, Brushes.Black, 0, 0);
                            aGraphics.ResetTransform();
                        }
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
