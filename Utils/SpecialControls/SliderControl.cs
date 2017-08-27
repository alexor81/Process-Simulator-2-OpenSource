// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Utils.SpecialControls
{
    public class SliderControl: TrackBar
    {
        public                      SliderControl() : base()
        {
            mNeedleBrush        = new SolidBrush(mNeedleColor);

            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            
            Resize += new EventHandler(SliderControl_Resize);
        }

        [DllImport("user32.dll")]
        static extern IntPtr        SendMessage(IntPtr hwnd, uint msg, IntPtr wp, ref RECT lp);
        [DllImport("user32.dll")]
        internal static extern int  BeginPaint(IntPtr hwnd, ref PAINTSTRUCT lpPaint);
        [DllImport("user32.dll")]
        internal static extern int  EndPaint(IntPtr hwnd, ref PAINTSTRUCT lpPaint);

        private const uint          TBM_GETTHUMBRECT    = 0x419;
        private const uint          TBM_GETCHANNELRECT  = 0x41A;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct PAINTSTRUCT 
        { 
            internal int hdc; 
            internal bool fErase; 
            internal RECT rcPaint; 
            internal bool fRestore; 
            internal bool fIncUpdate; 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] internal byte[] rgbReserved;
        }

        private float               mDXY;
        private float               mIndent;
        private Bitmap              mNeedleBmp;
        private PointF[][]          mTPoints;
        private volatile bool       mReCalc             = true;

        private int[]               mThresholds         = new int[0];
        public int[]                Thresholds
        {
            get { return mThresholds; }
            set
            {
                mThresholds = value;
                mReCalc     = true;
                Invalidate();
            }
        }

        private Brush               mNeedleBrush;
        private Color               mNeedleColor        = Color.Blue;
        public Color                NeedleColor
        {
            get { return mNeedleColor; }
            set
            {
                if (mNeedleBrush != null)
                {
                    mNeedleBrush.Dispose();
                }

                mNeedleColor    = value;
                mNeedleBrush    = new SolidBrush(mNeedleColor);
                mReCalc         = true;
                Invalidate(); 
            }
        }

        public bool                 mReadOnly           = false;
        
        protected override void     WndProc(ref Message aMessage)
        {
            if (aMessage.Msg == (int)WM.PAINT)
            {
                PAINTSTRUCT lPStruct = new PAINTSTRUCT();
                BeginPaint(aMessage.HWnd, ref lPStruct);
                using (Graphics lGraphics = Graphics.FromHwndInternal(aMessage.HWnd))
                {
                    SliderPaint(new PaintEventArgs(lGraphics, this.ClientRectangle));
                }
                EndPaint(aMessage.HWnd, ref lPStruct);

                return;
            }

            if (aMessage.Msg == (int)WM.LBUTTONDOWN && mReadOnly)
            {
                return;
            }

            base.WndProc(ref aMessage);
        }

        void                        SliderControl_Resize(object aSender, EventArgs aEventArgs)
        {
            mReCalc = true;
        }

        protected void              SliderPaint(PaintEventArgs aEventArgs)
        {
            var lBmp = new Bitmap(aEventArgs.ClipRectangle.Width, aEventArgs.ClipRectangle.Height);
            base.DrawToBitmap(lBmp, new Rectangle(0 , 0, aEventArgs.ClipRectangle.Width, aEventArgs.ClipRectangle.Height));
            var lGraphics = Graphics.FromImage(lBmp);

            RECT lNeedleRect = new RECT();
            SendMessage(this.Handle, TBM_GETTHUMBRECT, IntPtr.Zero, ref lNeedleRect);
            int lNeedleW = lNeedleRect.Right - lNeedleRect.Left;
            int lNeedleH = lNeedleRect.Bottom - lNeedleRect.Top;

            #region Recalculation

                if (mReCalc)
                {
                    mReCalc = false;

                    if (mNeedleBmp != null)
                    {
                        mNeedleBmp.Dispose();
                    }
                    mNeedleBmp = new Bitmap(lNeedleW, lNeedleH);
                    var lNeedlGr = Graphics.FromImage(mNeedleBmp);
                    lNeedlGr.FillRectangle(mNeedleBrush, 0, 0, lNeedleW, lNeedleH);
                    lNeedlGr.DrawRectangle(Pens.Black, 0, 0, lNeedleW - 1, lNeedleH - 1);

                    RECT lChannelRect = new RECT();
                    SendMessage(this.Handle, TBM_GETCHANNELRECT, IntPtr.Zero, ref lChannelRect);

                    if (Orientation == Orientation.Horizontal)
                    {
                        mIndent = Convert.ToSingle((double)(lNeedleW) / 2.0D + (double)lChannelRect.Left);
                        mDXY = ((float)Width - mIndent * 2.0F) / 27648.0F;

                        int lNeedleHalf = lNeedleW / 2;
                        lNeedlGr.DrawLine(Pens.Black, lNeedleHalf, 0, lNeedleHalf, lNeedleH);
                    }
                    else
                    {
                        mIndent = Convert.ToSingle((double)(lNeedleH) / 2.0D + (double)lChannelRect.Left);
                        mDXY = ((float)Height - mIndent * 2.0F) / 27648.0F;

                        int lNeedleHalf = lNeedleH / 2;
                        lNeedlGr.DrawLine(Pens.Black, 0, lNeedleHalf, lNeedleW, lNeedleHalf);
                    }

                    lNeedlGr.Dispose();

                    mTPoints = new PointF[mThresholds.Length][];
                    if (mThresholds.Length > 0)
                    {
                        float lStart;
                        float lEnd;
                        if (Orientation == Orientation.Horizontal)
                        {
                            lStart = (float)lNeedleRect.Bottom;
                            lEnd = lStart + 10.0F;
                        }
                        else
                        {
                            lStart = (float)lNeedleRect.Right;
                            lEnd = lStart + 10.0F;
                        }

                        float lXY;
                        for (int i = 0; i < mThresholds.Length; i++)
                        {
                            mTPoints[i] = new PointF[3];
                            if (Orientation == Orientation.Horizontal)
                            {
                                lXY = mDXY * (float)mThresholds[i] + mIndent;
                                mTPoints[i][0] = new PointF(lXY, lStart);
                                mTPoints[i][1] = new PointF(lXY + 5.0F, lEnd);
                                mTPoints[i][2] = new PointF(lXY - 5.0F, lEnd);
                            }
                            else
                            {
                                lXY = mDXY * (float)mThresholds[i] + mIndent;

                                mTPoints[i][0] = new PointF(lStart, lXY);
                                mTPoints[i][1] = new PointF(lEnd, lXY - 5.0F);
                                mTPoints[i][2] = new PointF(lEnd, lXY + 5.0F);
                            }
                        }
                    }
                }

            #endregion

            #region Needle

                if (mNeedleBmp != null)
                {
                    lGraphics.DrawImage(mNeedleBmp, lNeedleRect.Left, lNeedleRect.Top);
                }

            #endregion

            #region Thresholds

                lGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                for (int i = 0; i < mThresholds.Length; i++)
                {
                    lGraphics.FillClosedCurve(Brushes.Red, mTPoints[i], System.Drawing.Drawing2D.FillMode.Alternate, 0.0F);
                }

            #endregion

            aEventArgs.Graphics.DrawImage(lBmp, 0, 0);
            lGraphics.Dispose();
            lBmp.Dispose();
        }

        protected override bool     ProcessCmdKey(ref Message aMessage, Keys aKeys)
        {
            switch (aKeys)
            {
                case Keys.Up:       this.Value = Math.Min(this.Value + this.SmallChange, this.Maximum); return true;
                case Keys.Down:     this.Value = Math.Max(this.Value - this.SmallChange, this.Minimum); return true;
                case Keys.PageUp:   this.Value = Math.Min(this.Value + this.LargeChange, this.Maximum); return true;
                case Keys.PageDown: this.Value = Math.Max(this.Value - this.LargeChange, this.Minimum); return true;
            }
            return base.ProcessCmdKey(ref aMessage, aKeys);
        }

        private bool                mDisposed;
        protected override void     Dispose(bool disposing)
        {
            if (!mDisposed)
            {
                if (disposing)
                {
                    if (mNeedleBrush != null)
                    {
                        mNeedleBrush.Dispose();
                        mNeedleBrush = null;
                    }

                    if (mNeedleBmp != null)
                    {
                        mNeedleBmp.Dispose();
                        mNeedleBmp = null;
                    }
                }

                mDisposed = true;
            }

            base.Dispose(disposing);
        }
    }
}
