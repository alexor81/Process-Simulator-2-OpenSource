// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Utils.Logger;

namespace Utils.Panels.ArrayDoubleTrend
{
    public partial class ArrayDoubleTrendPanel : UserControl, IPanel, IPanelExt
    {
        private IArrayValueRead     mArrayValue;

        public                      ArrayDoubleTrendPanel(IArrayValueRead aArrayValue)
        {
            mArrayValue = aArrayValue;
            mValue      = mArrayValue.ValueArray;
            InitializeComponent();  
            timer_Update.Start();

            chart.MouseWheel += chart_MouseWheel;
        }

        public void                 fillForDemo()
        {
            addSeries(0, Color.Blue, "Example");
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            UpdateRate  = (int)lReader.getAttribute<UInt32>("UpdateRate", (uint)timer_Update.Interval);
            TimeFrame   = (int)lReader.getAttribute<UInt32>("TimeFrame", (uint)mTimeFrame);
            Legend      = lReader.getAttribute<Boolean>("Legend", Legend);
            ShowCursor  = lReader.getAttribute<Boolean>("ShowCursor", ShowCursor);
            CursorRound = (int)lReader.getAttribute<Int32>("CursorRound", CursorRound);
            CursorFont  = lReader.getAttribute<Font>("CursorFont", CursorFont);
            mCursorX    = lReader.getAttribute<Int32>("CursorPosition", mCursorX);
            YAutoScale  = lReader.getAttribute<Boolean>("YAutoScale", YAutoScale);
            if (YAutoScale == false)
            {
                setYMaxMin(lReader.getAttribute<Double>("YMax"), lReader.getAttribute<Double>("YMin"));
            }
            YLabels     = lReader.getAttribute<Boolean>("YLabels", YLabels);

            #region Series

            if (aXMLTextReader.IsEmptyElement == false)
                {
                    aXMLTextReader.Read();

                    if (aXMLTextReader.Name.Equals("Series", StringComparison.Ordinal))
                    {
                        if (aXMLTextReader.IsEmptyElement == false)
                        {
                            int lIndex;
                            Color lColor;
                            string lLabel;

                            aXMLTextReader.Read();
                            while (aXMLTextReader.Name.Equals("Serie", StringComparison.Ordinal))
                            {
                                lIndex = (int)lReader.getAttribute<UInt32>("Index");
                                lColor = lReader.getAttribute<Color>("Color");
                                lLabel = lReader.getAttribute<string>("Label", "");

                                addSeries(lIndex, lColor, lLabel);

                                aXMLTextReader.Read();
                            }
                        }

                        aXMLTextReader.Read();
                    }
                }

            #endregion
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("UpdateRate", StringUtils.ObjectToString(UpdateRate));
            aXMLTextWriter.WriteAttributeString("TimeFrame", StringUtils.ObjectToString(TimeFrame));
            aXMLTextWriter.WriteAttributeString("Legend", StringUtils.ObjectToString(Legend));
            aXMLTextWriter.WriteAttributeString("ShowCursor", StringUtils.ObjectToString(ShowCursor));
            aXMLTextWriter.WriteAttributeString("CursorRound", StringUtils.ObjectToString(CursorRound));
            aXMLTextWriter.WriteAttributeString("CursorFont", StringUtils.ObjectToString(CursorFont));
            aXMLTextWriter.WriteAttributeString("CursorPosition", StringUtils.ObjectToString(mCursorX));
            aXMLTextWriter.WriteAttributeString("YAutoScale", StringUtils.ObjectToString(YAutoScale));
            aXMLTextWriter.WriteAttributeString("YLabels", StringUtils.ObjectToString(YLabels));
            if (YAutoScale == false)
            {
                aXMLTextWriter.WriteAttributeString("YMax", StringUtils.ObjectToString(YMax));
                aXMLTextWriter.WriteAttributeString("YMin", StringUtils.ObjectToString(YMin));
            }

            if (chart.Series.Count > 0)
            {
                int[] lArrayIndex = mArrayIndex.ToArray();
                Array.Sort(lArrayIndex);
                int lSerieIndex;

                aXMLTextWriter.WriteStartElement("Series");
                for (int i = 0; i < lArrayIndex.Length; i++)
                {
                    lSerieIndex = mArrayIndex.IndexOf(lArrayIndex[i]);
                    aXMLTextWriter.WriteStartElement("Serie");
                        aXMLTextWriter.WriteAttributeString("Index", StringUtils.ObjectToString(lArrayIndex[i]));
                        aXMLTextWriter.WriteAttributeString("Color", StringUtils.ObjectToString(chart.Series[lSerieIndex].Color));
                        aXMLTextWriter.WriteAttributeString("Label", chart.Series[lSerieIndex].LegendText);
                    aXMLTextWriter.WriteEndElement();
                }
                aXMLTextWriter.WriteEndElement();
            }
        }

        public UserControl          UserControl { get { return this; } }

        public bool                 IsScalable { get { return true; } }

        public bool                 IsTransparent { get { return false; } }

        public bool                 IsConfigurable { get { return true; } }

        public bool                 IsContainer { get { return false; } }

        public bool                 IsSetupOnDblClick { get { return true; } }

        public void                 setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        private string              mLabelText;
        public string               LabelText
        {
            get { return mLabelText; }
            set { mLabelText = value; }
        }
        private void                chart_GetToolTipText(object aSender, ToolTipEventArgs aEventArgs)
        {
            aEventArgs.Text = mLabelText;
        }

        public bool                 Legend
        {
            get
            {
                return (chart.Legends.Count == 1);
            }
            set
            {
                if (value)
                {
                    if (chart.Legends.Count == 0)
                    {
                        Legend lLegend  = new Legend();
                        lLegend.Docking = Docking.Left;
                        chart.Legends.Add(lLegend);
                        
                    }
                }
                else
                {
                    if (chart.Legends.Count == 1)
                    {
                        Legend lLegend = chart.Legends[0];
                        chart.Legends.RemoveAt(0);
                        lLegend.Dispose();
                    }
                }
                mReInit = true;
            }
        }

        private int                 mTopY;
        private int                 mBottomY;
        private int                 mLeftX;
        private int                 mRightX;

        #region X axis

            public int              UpdateRate
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

            private int             mTimeFrame = 1;
            private double          mWindow = 1.0D / 1440.0D;
            public int              TimeFrame
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

            private bool            mYAutoScale = true;
            public bool             YAutoScale
            {
                get { return mYAutoScale; }
                set
                {
                    if (mYAutoScale != value)
                    {
                        mYAutoScale = value;

                        if (mYAutoScale)
                        {
                            chart.ChartAreas[0].Axes[1].IsStartedFromZero = true;
                            chart.ChartAreas[0].Axes[1].Maximum = Double.NaN;
                            chart.ChartAreas[0].Axes[1].Minimum = Double.NaN;
                            chart.ChartAreas[0].RecalculateAxesScale();
                        }
                        else
                        {
                            chart.ChartAreas[0].Axes[1].IsStartedFromZero = false;
                            setYMaxMin(YMax, YMin);
                        }
                    }
                    mReInit = true;
                }
            }

            public double           YMax
            {
                get { return chart.ChartAreas[0].Axes[1].Maximum; }
            }

            public double           YMin
            {
                get { return chart.ChartAreas[0].Axes[1].Minimum; }
            }

            public void             setYMaxMin(double aMax, double aMin)
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

                if (lMax > ChartUtils.MaxValue || lMax < ChartUtils.MinValue
                    || lMin > ChartUtils.MaxValue || lMin < ChartUtils.MinValue
                        || (lMax - lMin < 0.0001))
                {
                    return;
                }

                if (lMax <= lMin)
                {
                    throw new ArgumentException("Maximum value has to be greater than minimum. ");
                }

                chart.ChartAreas[0].Axes[1].Maximum = lMax;
                chart.ChartAreas[0].Axes[1].Minimum = lMin;
                chart.ChartAreas[0].RecalculateAxesScale();
            }

            public void             setYMaxMinRound(double aMax, double aMin)
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

            private void            chart_MouseWheel(object aSender, MouseEventArgs aEventArgs)
            {
                if (YAutoScale) return;

                chart.ChartAreas[0].RecalculateAxesScale();
                double lY = chart.ChartAreas[0].Axes[1].PixelPositionToValue(aEventArgs.Y);
                double lMax = YMax;
                double lMin = YMin;

                if (lY > lMin && lY < lMax)
                {
                    double lDeltaMax = (lMax - lY) / 10.0;
                    double lDeltaMin = (lY - lMin) / 10.0;

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

            private int             mLastY = -1;

            private void            chart_MouseMove(object aSender, MouseEventArgs aEventArgs)
            {
                if (YAutoScale) return;

                if (aEventArgs.Button == MouseButtons.Left
                    && aEventArgs.Y < mBottomY
                    && aEventArgs.Y > mTopY)
                {
                    if (mLastY > 0)
                    {
                        chart.ChartAreas[0].RecalculateAxesScale();
                        double lDelta = chart.ChartAreas[0].Axes[1].PixelPositionToValue(mLastY)
                                        - chart.ChartAreas[0].Axes[1].PixelPositionToValue(aEventArgs.Y);
                        setYMaxMinRound(YMax + lDelta, YMin + lDelta);
                    }

                    mLastY = aEventArgs.Y;
                }
            }

            private void            chart_MouseUp(object aSender, MouseEventArgs aEventArgs)
            {
                if (aEventArgs.Button == MouseButtons.Left)
                {
                    mLastY = -1;
                }
            }

            public bool             YLabels
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

        private bool            mShowCursor = false;
            public bool             ShowCursor
            {
                get { return mShowCursor; }
                set
                { 
                    mShowCursor = value;
                    mReInit     = true; 
                }
            }

            private int             mCursorRound = 3;
            public int              CursorRound
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

            private Font            mCursorFont = new Font("Microsoft Sans Serif", 7);
            public Font             CursorFont
            {
                get { return mCursorFont; }
                set { mCursorFont = value; }
            }

            private int             mCursorX;
            private List<string>    mCursorValue = new List<string>();
            private List<Brush>     mCursorBrush = new List<Brush>();
            private void            calcCursorValues()
            {
                if (mShowCursor)
                {
                    chart.ChartAreas[0].RecalculateAxesScale();
                    int lSeriesCount = chart.Series.Count;
                    for (int i = 0; i < lSeriesCount; i++)
                    {
                        string lValue = "";
                        if (chart.Series[i].Points.Count >= 2)
                        {
                            double lX   = chart.ChartAreas[0].AxisX.PixelPositionToValue(mCursorX);
                            lValue      = StringUtils.ObjectToString(StringUtils.DoubleToString(ChartUtils.getValue(chart.Series[i], lX), mCursorRound));
                        }
                        mCursorValue[i] = lValue;
                    }
                }
            }

            private void            chart_MouseDown(object aSender, MouseEventArgs aEventArgs)
            {
                if (aEventArgs.Button == MouseButtons.Left)
                {
                    bool lUpdate = false;
                    var lHit = chart.HitTest(aEventArgs.X, aEventArgs.Y);

                    if (lHit.ChartElementType == ChartElementType.DataPoint || lHit.ChartElementType == ChartElementType.PlottingArea)
                    {
                        mCursorX    = aEventArgs.X;
                        lUpdate     = true;
                    }
                    else if (lHit.ChartElementType == ChartElementType.Axis)
                    {
                        if (lHit.Axis.AxisName == AxisName.Y)
                        {
                            mCursorX    = mLeftX;
                            lUpdate     = true;
                        }
                        else if (lHit.Axis.AxisName == AxisName.Y2)
                        {
                            mCursorX    = mRightX;
                            lUpdate     = true;
                        }
                    }

                    if (lUpdate)
                    {
                        lock(mArrayIndex)
                        {
                            calcCursorValues();
                        }

                        mReInit = true;
                        chart.Invalidate();
                    }
                }
            }

        #endregion

        private List<int>           mArrayIndex = new List<int>();

        public void                 addSeries(int aIndex, Color aColor, string aLabel)
        {
            if (mArrayIndex.IndexOf(aIndex) >= 0)
            {
                throw new ArgumentException("Index '" + aIndex.ToString() + "' already exists. ");
            }

            Series lSeries = new Series();
            lSeries.LegendText = aLabel;
            lSeries.Color = aColor;
            lSeries.YAxisType = AxisType.Primary;
            lSeries.ChartType = SeriesChartType.Line;
            lSeries.XValueType = ChartValueType.DateTime;

            lock (mArrayIndex)
            {
                chart.Series.Add(lSeries);
                mArrayIndex.Add(aIndex);
                mCursorBrush.Add(new SolidBrush(aColor));
                mCursorValue.Add("");
            }
        }

        public void                 deleteSeries(int aIndex)
        {
            int lIndex = mArrayIndex.IndexOf(aIndex);
            if (lIndex < 0)
            {
                throw new ArgumentException("Index '" + aIndex.ToString() + "' does not exist. ");
            }

            Series lSeries = chart.Series[lIndex];
            lock (mArrayIndex)
            {
                chart.Series.RemoveAt(lIndex);
                mArrayIndex.RemoveAt(lIndex);
                mCursorBrush.RemoveAt(lIndex);
                mCursorValue.RemoveAt(lIndex);
            }
            lSeries.Dispose();
        }

        public void                 modifySeries(int aIndex, int aNewIndex, Color aNewColor, string aNewLabel)
        {
            int lIndex = mArrayIndex.IndexOf(aIndex);
            if (lIndex < 0)
            {
                throw new ArgumentException("Index '" + aIndex.ToString() + "' does not exist. ");
            }

            if (aIndex != aNewIndex)
            {
                if (mArrayIndex.IndexOf(aNewIndex) > 0)
                {
                    throw new ArgumentException("Index '" + aNewIndex.ToString() + "' already exists. ");
                }
            }

            Series lSeries = chart.Series[lIndex];
            lSeries.Color = aNewColor;
            lSeries.LegendText = aNewLabel;

            lock (mArrayIndex)
            {
                mArrayIndex[lIndex] = aNewIndex;
                mCursorBrush[lIndex] = new SolidBrush(aNewColor);
            }
        }

        public DataTable            SeriesData
        {
            get
            {
                DataTable lTable = new DataTable();
                lTable.Columns.Add("Index").DataType = typeof(int);
                lTable.Columns.Add("Color").DataType = typeof(Color);
                lTable.Columns.Add("Label").DataType = typeof(string);

                lock (mArrayIndex)
                {
                    int lCount = mArrayIndex.Count;
                    for (int i = 0; i < lCount; i++)
                    {
                        lTable.Rows.Add(mArrayIndex[i], chart.Series[i].Color, chart.Series[i].LegendText);
                    }
                }

                return lTable;
            }
        }

        private void                addValues(double aDateTime)
        {
            double lValue;
            for (int i = 0; i < chart.Series.Count; i++)
            {
                if (i == mValue.Length) { break; }
                if (mArrayIndex[i] >= mValue.Length) { continue; }

                lValue = Convert.ToDouble(mValue.GetValue(mArrayIndex[i]));
                if (double.IsNaN(lValue)
                    || double.IsNegativeInfinity(lValue)
                        || double.IsPositiveInfinity(lValue)
                            || lValue > ChartUtils.MaxValue
                                || lValue < ChartUtils.MinValue)
                {
                    chart.Series[i].Points.AddXY(aDateTime, 0);
                    chart.Series[i].Points[chart.Series[i].Points.Count - 1].IsEmpty = true;
                }
                else
                {
                    chart.Series[i].Points.AddXY(aDateTime, lValue);
                }
            }
        }

        public void                 clearSeries()
        {
            lock (mArrayIndex)
            {
                for (int i = 0; i < chart.Series.Count; i++)
                {
                    chart.Series[i].Points.Clear();
                }
            }
        }

        private void                timer_Update_Tick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                if (chart.Series.Count > 0)
                {
                    double lNow     = DateTime.Now.ToOADate();
                    double lLast    = lNow - mWindow;

                    lock (mArrayIndex)
                    {
                        if (mValueChanged)
                        {
                            mValueChanged = false;
                            addValues(mValueTime);
                        }
                        else
                        {
                            addValues(lNow);
                        }

                        for (int i = 0; i < chart.Series.Count; i++)
                        {
                            if (chart.Series[i].Points.Count > 2)
                            {
                                while (chart.Series[i].Points[0].XValue < lLast)
                                {
                                    if (chart.Series[i].Points[1].XValue > lLast) break;
                                    chart.Series[i].Points.RemoveAt(0);
                                    if (chart.Series[i].Points.Count <= 2) break;
                                }
                            }
                        }

                        chart.ResetAutoValues();
                        chart.ChartAreas[0].AxisX.Maximum = lNow;
                        chart.ChartAreas[0].AxisX.Minimum = lLast;

                        calcCursorValues();
                    }
                }
            }
            catch (Exception lExc)
            {
                Log.Error("Error updating Panel 'Trend'. " + lExc.Message, lExc.ToString());
            }
        }

        private Array               mValue;
        private double              mValueTime      = DateTime.Now.ToOADate();
        private volatile bool       mValueChanged   = false;
        public void                 updateValues()
        {
            Type lElementType = mArrayValue.ValueArray.GetType().GetElementType();
            if (lElementType != typeof(Double) &&
                lElementType != typeof(Single) &&
                lElementType != typeof(Int64) &&
                lElementType != typeof(Int32) &&
                lElementType != typeof(Int16) &&
                lElementType != typeof(UInt64) &&
                lElementType != typeof(UInt32) &&
                lElementType != typeof(UInt16) &&
                lElementType != typeof(Byte) &&
                lElementType != typeof(SByte) &&
                lElementType != typeof(Decimal))
            {
                throw new ArgumentException("Array of numeric values is expected. ");
            }

            mValue          = mArrayValue.ValueArray;
            mValueTime      = DateTime.Now.ToOADate();
            mValueChanged   = true;
        }

        public void                 updateProperties()
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
        private void                updateP()
        {
            lock (mArrayIndex)
            {
                addValues(DateTime.Now.ToOADate());
            }
        }

        private volatile bool       mReInit = true;
        private void                ArrayDoubleTrendPanel_SizeChanged(object aSender, EventArgs aEventArgse)
        {
            mReInit = true;
        }

        private void                chart_PrePaint(object aSender, ChartPaintEventArgs aEventArgs)
        {
            if (mReInit)
            {
                try
                {
                    mRightX         = (int)chart.ChartAreas[0].AxisX2.ValueToPixelPosition(chart.ChartAreas[0].AxisX2.Maximum);
                    mLeftX          = (int)chart.ChartAreas[0].AxisX2.ValueToPixelPosition(chart.ChartAreas[0].AxisX2.Minimum);

                    mTopY           = (int)chart.ChartAreas[0].AxisY.ValueToPixelPosition(chart.ChartAreas[0].AxisY.Maximum);
                    mBottomY        = (int)chart.ChartAreas[0].AxisY.ValueToPixelPosition(chart.ChartAreas[0].AxisY.Minimum);

                    mReInit     = false;
                }
                catch (Exception lExc)
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
        }

        private void                chart_PostPaint(object aSender, ChartPaintEventArgs aEventArgs)
        {
            if (mReInit) { return; }

            var lGraphics = aEventArgs.ChartGraphics.Graphics;

            if (mShowCursor)
            {
                lGraphics.DrawLine(Pens.Black, mCursorX, mTopY, mCursorX, mBottomY);

                int lHeight = 0;
                int lWidth  = 0;
                SizeF lSize = SizeF.Empty;
                int lCount  = mCursorValue.Count;
                int[] lW    = new int[lCount];

                for (int i = 0; i < lCount; i++)
                {
                    if (String.IsNullOrWhiteSpace(mCursorValue[i]) == false)
                    {
                        lSize = lGraphics.MeasureString(mCursorValue[i], mCursorFont);
                        lW[i] = (int)lSize.Width;
                        if (lWidth < lW[i])
                        {
                            lWidth = lW[i];
                        }
                    }
                }

                if(lWidth > 0)
                {
                    lHeight = (int)lSize.Height * mCursorValue.Count;
                    int lX;
                    if (mCursorX + lWidth + 2 > mRightX)
                    {
                        lX = mCursorX - lWidth;
                        lGraphics.FillRectangle(Brushes.White, lX - 1, mTopY, lWidth, lHeight);
                    }
                    else
                    {
                        lX = mCursorX + 1;
                        lGraphics.FillRectangle(Brushes.White, lX, mTopY, lWidth, lHeight);
                    }

                    int lY = mTopY;
                    for(int i = 0; i < lCount; i++)
                    {
                        lGraphics.DrawString(mCursorValue[i], mCursorFont, mCursorBrush[i], lX + (lWidth - lW[i]), lY);
                        lY = lY + (int)lSize.Height;
                    }
                }
            }
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                chart.MouseWheel -= chart_MouseWheel;

                mArrayValue = null;
                timer_Update.Stop();

                if (mCursorBrush != null)
                {
                    foreach(Brush lBrush in mCursorBrush)
                    {
                        lBrush.Dispose();
                    }
                    mCursorBrush.Clear();
                    mCursorBrush = null;
                }

                if (mCursorFont != null)
                {
                    mCursorFont.Dispose();
                    mCursorFont = null;
                }

                if (mCursorValue != null)
                {
                    mCursorValue.Clear();
                    mCursorValue = null;
                }

                if(mArrayIndex != null)
                {
                    mArrayIndex.Clear();
                    mArrayValue = null;
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
