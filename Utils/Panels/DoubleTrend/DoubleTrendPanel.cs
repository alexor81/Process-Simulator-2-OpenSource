// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Utils.Logger;

namespace Utils.Panels.DoubleTrend
{
    public partial class DoubleTrendPanel : UserControl, IPanel, IPanelExt
    {
        private IDoubleValueRead        mDoubleValue;

        public                          DoubleTrendPanel(IDoubleValueRead aDoubleValue)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();
            timer_Update.Start();

            chart.MouseWheel += chart_MouseWheel;
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            UpdateRate  = lReader.getAttribute<Int32>("UpdateRate", timer_Update.Interval);
            TimeFrame   = lReader.getAttribute<Int32>("TimeFrame", TimeFrame);
            TrendColor  = lReader.getAttribute<Color>("Color", chart.Series[0].Color);
            ShowCursor  = lReader.getAttribute<Boolean>("ShowCursor", ShowCursor);
            CursorRound = (int)lReader.getAttribute<Int32>("CursorRound", CursorRound);
            CursorFont  = lReader.getAttribute<Font>("CursorFont", CursorFont);
            mCursorX    = lReader.getAttribute<Int32>("CursorPosition", mCursorX);
            YAutoScale  = lReader.getAttribute<Boolean>("YAutoScale", YAutoScale);
            if(YAutoScale == false)
            {
                setYMaxMin(lReader.getAttribute<Double>("YMax"), lReader.getAttribute<Double>("YMin"));
            }
            YLabels     = lReader.getAttribute<Boolean>("YLabels", YLabels);
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("UpdateRate", StringUtils.ObjectToString(UpdateRate));
            aXMLTextWriter.WriteAttributeString("TimeFrame", StringUtils.ObjectToString(TimeFrame));
            aXMLTextWriter.WriteAttributeString("Color", StringUtils.ObjectToString(TrendColor));
            aXMLTextWriter.WriteAttributeString("ShowCursor", StringUtils.ObjectToString(ShowCursor));
            aXMLTextWriter.WriteAttributeString("CursorRound", StringUtils.ObjectToString(CursorRound));
            aXMLTextWriter.WriteAttributeString("CursorFont", StringUtils.ObjectToString(CursorFont));
            aXMLTextWriter.WriteAttributeString("CursorPosition", StringUtils.ObjectToString(mCursorX));
            aXMLTextWriter.WriteAttributeString("YAutoScale", StringUtils.ObjectToString(YAutoScale));
            if(YAutoScale == false)
            {
                aXMLTextWriter.WriteAttributeString("YMax", StringUtils.ObjectToString(YMax));
                aXMLTextWriter.WriteAttributeString("YMin", StringUtils.ObjectToString(YMin));
            }
            aXMLTextWriter.WriteAttributeString("YLabels", StringUtils.ObjectToString(YLabels));
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public bool                     IsSetupOnDblClick { get { return true; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        private string                  mLabelText;
        public string                   LabelText
        {
            get { return mLabelText; }
            set { mLabelText = value; }
        }
        private void                    chart_GetToolTipText(object aSender, ToolTipEventArgs aEventArgs)
        {
            aEventArgs.Text = mLabelText;
        }

        public Color                    TrendColor
        {
            get { return chart.Series[0].Color; }
            set
            {
                chart.Series[0].Color = value;
                mCursorBrush = null;
            }
        }

        private int                     mTopY;
        private int                     mBottomY;
        private int                     mLeftX;
        private int                     mRightX;

        private double[]                mThresholds;

        #region X axis

            public int                  UpdateRate
            {
                get { return timer_Update.Interval; }
                set
                {
                    if (value >= 50 && value <= 1000)
                    {
                        timer_Update.Interval = value;
                    }
                }
            }

            private int                 mTimeFrame  = 1;
            private double              mWindow     = 1.0D / 1440.0D;
            public int                  TimeFrame
            {
                get { return mTimeFrame; }
                set
                {
                    if (value >= 1 && value <= 5)
                    {
                        mTimeFrame  = value;
                        mWindow     = (double)mTimeFrame / 1440.0D;
                    }
                }
            }

        #endregion

        #region Y axis

            private bool                mYAutoScale = true;
            public bool                 YAutoScale
            {
                get { return mYAutoScale; }
                set
                {
                    if (mYAutoScale != value)
                    {
                        mYAutoScale = value;

                        if(mYAutoScale)
                        {
                            chart.ChartAreas[0].Axes[1].IsStartedFromZero   = true;
                            chart.ChartAreas[0].Axes[1].Maximum             = Double.NaN;
                            chart.ChartAreas[0].Axes[1].Minimum             = Double.NaN;
                            chart.ChartAreas[0].RecalculateAxesScale();
                        }
                        else
                        {
                            chart.ChartAreas[0].Axes[1].IsStartedFromZero   = false;
                            setYMaxMin(YMax, YMin);
                        }
                    }
                    mReInit = true;
                }
            }

            public double               YMax
            {
                get { return chart.ChartAreas[0].Axes[1].Maximum; }
            }

            public double               YMin
            {
                get { return chart.ChartAreas[0].Axes[1].Minimum; }
            }

            public void                 setYMaxMin(double aMax, double aMin)
            {
                double lMax;
                if (Double.IsNaN(aMax) == false)
                {
                    lMax = aMax;
                }
                else
                {
                    lMax = 100;
                }

                double lMin;
                if (Double.IsNaN(aMin) == false)
                {
                    lMin = aMin;
                }
                else
                {
                    lMin = -100;
                }

                if(lMax > ChartUtils.MaxValue || lMax < ChartUtils.MinValue 
                    || lMin > ChartUtils.MaxValue || lMin < ChartUtils.MinValue
                        || (lMax - lMin < 0.0001))
                {
                    return;
                }

                if(lMax <= lMin)
                {
                    throw new ArgumentException("Maximum value has to be greater than minimum. ");
                }

                chart.ChartAreas[0].Axes[1].Maximum = lMax;
                chart.ChartAreas[0].Axes[1].Minimum = lMin;
                chart.ChartAreas[0].RecalculateAxesScale();
            }

            public void                 setYMaxMinRound(double aMax, double aMin)
            {
                double lDelta = aMax - aMin;

                if (lDelta > 100.0)
                {
                    aMax = Math.Round(aMax, 0, MidpointRounding.AwayFromZero);
                    aMin = Math.Round(aMin, 0, MidpointRounding.AwayFromZero);
                }
                else if (lDelta > 10.0)
                {
                    aMax = Math.Round(aMax, 1, MidpointRounding.AwayFromZero);
                    aMin = Math.Round(aMin, 1, MidpointRounding.AwayFromZero);
                }
                else if (lDelta > 1.0)
                {
                    aMax = Math.Round(aMax, 2, MidpointRounding.AwayFromZero);
                    aMin = Math.Round(aMin, 2, MidpointRounding.AwayFromZero);
                }
                else if (lDelta > 0.1)
                {
                    aMax = Math.Round(aMax, 3, MidpointRounding.AwayFromZero);
                    aMin = Math.Round(aMin, 3, MidpointRounding.AwayFromZero);
                }

                setYMaxMin(aMax, aMin);
            }

            private void                chart_MouseWheel(object aSender, MouseEventArgs aEventArgs)
            {
                if (YAutoScale) return;

                chart.ChartAreas[0].RecalculateAxesScale();
                double lY   = chart.ChartAreas[0].Axes[1].PixelPositionToValue(aEventArgs.Y);
                double lMax = YMax;
                double lMin = YMin;

                if (lY > lMin && lY < lMax)
                {
                    double lDeltaMax    = (lMax - lY) / 10.0;
                    double lDeltaMin    = (lY - lMin) / 10.0;

                    if (aEventArgs.Delta > 0)
                    {
                        lMax = lMax - lDeltaMax;
                        lMin = lMin + lDeltaMin;
                    }
                    else
                    {
                        lMax = lMax + lDeltaMax;
                        lMin = lMin - lDeltaMin;
                    }

                    setYMaxMinRound(lMax, lMin);
                }
            }

            private int                 mLastY = -1;

            private void                chart_MouseMove(object aSender, MouseEventArgs aEventArgs)
            {
                if (YAutoScale) return;

                if (aEventArgs.Button == MouseButtons.Left
                    && aEventArgs.Y < mBottomY 
                    && aEventArgs.Y > mTopY)
                {
                    if(mLastY > 0)
                    {
                        chart.ChartAreas[0].RecalculateAxesScale();
                        double lDelta = chart.ChartAreas[0].Axes[1].PixelPositionToValue(mLastY) 
                                        - chart.ChartAreas[0].Axes[1].PixelPositionToValue(aEventArgs.Y);
                        setYMaxMinRound(YMax + lDelta, YMin + lDelta);
                    }

                    mLastY = aEventArgs.Y;
                }
            }

            private void                chart_MouseUp(object aSender, MouseEventArgs aEventArgs)
            {
                if(aEventArgs.Button == MouseButtons.Left)
                {
                    mLastY = -1;
                }
            }

            public bool                 YLabels
            {
                get { return chart.ChartAreas[0].AxisY.LabelStyle.Enabled; }
                set 
                { 
                    chart.ChartAreas[0].AxisY.LabelStyle.Enabled    = value;
                    chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = value;
                }
            }

        #endregion

        #region Cursor

            private bool                mShowCursor = false;
            public bool                 ShowCursor
            {
                get { return mShowCursor; }
                set
                {
                    mShowCursor = value;
                    mReInit     = true;
                }
            }

            private int                 mCursorRound = 3;
            public int                  CursorRound
            {
                get { return mCursorRound; }
                set
                {
                    if (mCursorRound != value)
                    {
                        if (value < -1)
                        {
                            mCursorRound = -1;
                        }
                        else if (value > 15)
                        {
                            mCursorRound = 15;
                        }
                        else
                        {
                            mCursorRound = value;
                        }
                    }
                }
            }

            private Font                mCursorFont = new Font("Microsoft Sans Serif", 7);
            public Font                 CursorFont
            {
                get { return mCursorFont; }
                set { mCursorFont = value; }
            }

            private int                 mCursorX;
            private string              mCursorValue;
            private Brush               mCursorBrush;
            private void                calcCursorValue()
            {
                if (mShowCursor)
                {
                    string lValue = "";
                    if (chart.Series[0].Points.Count > 2)
                    {
                        chart.ChartAreas[0].RecalculateAxesScale();
                        double lX   = chart.ChartAreas[0].AxisX.PixelPositionToValue(mCursorX);
                        lValue      = StringUtils.ObjectToString(StringUtils.DoubleToString(ChartUtils.getValue(chart.Series[0], lX), mCursorRound));
                    }
                    mCursorValue = lValue;
                }
            }

            private void                chart_MouseDown(object aSender, MouseEventArgs aEventArgs)
            {
                if (aEventArgs.Button == MouseButtons.Left)
                {
                    bool lUpdate = false;
                    var lHit = chart.HitTest(aEventArgs.X, aEventArgs.Y);

                    if (lHit.ChartElementType == ChartElementType.DataPoint || lHit.ChartElementType == ChartElementType.PlottingArea)
                    {
                        mCursorX = aEventArgs.X;
                        lUpdate = true;
                    }
                    else if (lHit.ChartElementType == ChartElementType.Axis)
                    {
                        if (lHit.Axis.AxisName == AxisName.Y)
                        {
                            mCursorX = mLeftX;
                            lUpdate = true;
                        }
                        else if (lHit.Axis.AxisName == AxisName.Y2)
                        {
                            mCursorX = mRightX;
                            lUpdate = true;
                        }
                    }

                    if (lUpdate)
                    {
                        calcCursorValue();
                        mReInit = true;
                        chart.Invalidate();
                    }
                }
            }

        #endregion

        private void                    addValue(double aDateTime, double aValue)
        {
            if (double.IsNaN(aValue) 
                || double.IsNegativeInfinity(aValue) 
                    || double.IsPositiveInfinity(aValue) 
                        || aValue > ChartUtils.MaxValue 
                            || aValue < ChartUtils.MinValue)
            {
                chart.Series[0].Points.AddXY(aDateTime, 0);
                chart.Series[0].Points[chart.Series[0].Points.Count - 1].IsEmpty = true;
            }
            else
            {
                chart.Series[0].Points.AddXY(aDateTime, aValue);
            }
        }

        public void                     clear()
        {
            chart.Series[0].Points.Clear();
        }

        private void                    timer_Update_Tick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                double lNow     = DateTime.Now.ToOADate();
                double lLast    = lNow - mWindow;
 
                addValue(lNow, mValue);

                if (chart.Series[0].Points.Count >= 2)
                {
                    while (chart.Series[0].Points[0].XValue < lLast)
                    {
                        if (chart.Series[0].Points[1].XValue > lLast) break;
                        chart.Series[0].Points.RemoveAt(0);
                        if (chart.Series[0].Points.Count <= 2) break;
                    }
                }

                if (mYAutoScale)
                {
                    chart.ResetAutoValues();
                }

                chart.ChartAreas[0].AxisX.Maximum = lNow;
                chart.ChartAreas[0].AxisX.Minimum = lLast;

                calcCursorValue();
            }
            catch (Exception lExc)
            {
                Log.Error("Error updating Panel 'Trend'. " + lExc.Message, lExc.ToString());
            }
        }

        private double                  mValue;
        public void                     updateValues()
        {
            mValue = mDoubleValue.ValueDouble;
        }

        public void                     updateProperties()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateP(); }));
            }
            else
            {
                updateP();
            }
        }
        private void                    updateP()
        {
            addValue(DateTime.Now.ToOADate(), mDoubleValue.ValueDouble);
            mThresholds = mDoubleValue.Thresholds; 
            mReInit     = true;
        }

        private volatile bool           mReInit = true;
        private void                    DoubleTrendPanel_SizeChanged(object aSender, EventArgs aEventArgs)
        {
            mReInit = true;
        }

        private void                    chart_PrePaint(object aSender, ChartPaintEventArgs aEventArgs)
        {
            if(mReInit)
            {
                try
                {
                    mRightX         = (int)chart.ChartAreas[0].AxisX2.ValueToPixelPosition(chart.ChartAreas[0].AxisX2.Maximum);
                    mLeftX          = (int)chart.ChartAreas[0].AxisX2.ValueToPixelPosition(chart.ChartAreas[0].AxisX2.Minimum);

                    mTopY           = (int)chart.ChartAreas[0].AxisY.ValueToPixelPosition(chart.ChartAreas[0].AxisY.Maximum);
                    mBottomY        = (int)chart.ChartAreas[0].AxisY.ValueToPixelPosition(chart.ChartAreas[0].AxisY.Minimum);

                    mReInit         = false;
                }
                catch(Exception lExc)
                {
                    Log.Error("Error updating Panel 'Trend'. " + lExc.Message, lExc.ToString());
                }
            }

            if (mTopY == mBottomY)
            {
                float lScale    = chart.Height / 100.0f;
                mTopY           = (int)(chart.ChartAreas[0].Position.Y * lScale);
                mBottomY        = mTopY + (int)(chart.ChartAreas[0].Position.Height * lScale);
            }

            if (mCursorX < mLeftX)
            {
                mCursorX = mLeftX;
            }
            else if (mCursorX > mRightX)
            {
                mCursorX = mRightX;
            }

            if (mReInit) { return; }

            var lGraphics = aEventArgs.ChartGraphics.Graphics;

            #region Thresholds

                if (mThresholds != null)
                {
                    if (mThresholds.Length != 0)
                    {
                        float lY;
                        PointF[] lTriAngle;
                        float lX = mRightX + 1;
                        foreach (double lValue in mThresholds)
                        {
                            lY              = (float)chart.ChartAreas[0].AxisY2.ValueToPixelPosition(lValue);
                            lTriAngle       = new PointF[3];
                            lTriAngle[0]    = new PointF(lX, lY);
                            lTriAngle[1]    = new PointF(lX + 10, lY - 5);
                            lTriAngle[2]    = new PointF(lX + 10, lY + 5);
                            lGraphics.FillClosedCurve(Brushes.Red, lTriAngle, System.Drawing.Drawing2D.FillMode.Alternate, 0.0f);
                        }
                    }
                }

            #endregion
        }

        private void                    chart_PostPaint(object aSender, ChartPaintEventArgs aEventArgs)
        {
            if (mReInit) { return; }

            var lGraphics = aEventArgs.ChartGraphics.Graphics;

            #region Cursor

                if (mShowCursor)
                {
                    lGraphics.DrawLine(Pens.Black, mCursorX, mTopY, mCursorX, mBottomY);

                if (String.IsNullOrWhiteSpace(mCursorValue) == false)
                    {
                        if (mCursorBrush == null)
                        {
                            mCursorBrush = new SolidBrush(chart.Series[0].Color);
                        }

                        var lSize = lGraphics.MeasureString(mCursorValue, mCursorFont);

                        if (mCursorX + lSize.Width + 2 > mRightX)
                        {
                            int lX = mCursorX - (int)lSize.Width;
                            lGraphics.FillRectangle(Brushes.White, lX - 1, mTopY, lSize.Width, lSize.Height);
                            lGraphics.DrawString(mCursorValue, mCursorFont, mCursorBrush, lX, mTopY);
                        }
                        else
                        {
                            lGraphics.FillRectangle(Brushes.White, mCursorX + 1, mTopY, lSize.Width, lSize.Height);
                            lGraphics.DrawString(mCursorValue, mCursorFont, mCursorBrush, mCursorX, mTopY);
                        }
                    }
                }

            #endregion
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing)
            {
                chart.MouseWheel -= chart_MouseWheel;

                timer_Update.Stop();
                mDoubleValue = null;

                if (mCursorBrush != null)
                {
                    mCursorBrush.Dispose();
                    mCursorBrush = null;
                }

                if(mCursorFont != null)
                {
                    mCursorFont.Dispose();
                    mCursorFont = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
