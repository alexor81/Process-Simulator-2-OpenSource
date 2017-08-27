// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.ArrayDoubleTrend
{
    partial class ArrayDoubleTrendPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            this.timer_Update = new System.Windows.Forms.Timer(this.components);
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // timer_Update
            // 
            this.timer_Update.Interval = 50;
            this.timer_Update.Tick += new System.EventHandler(this.timer_Update_Tick);
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.Area3DStyle.PointDepth = 20;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.Interval = 30D;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Interval = 1D;
            chartArea1.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            stripLine1.Interval = 30D;
            stripLine1.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorTickMark.Enabled = false;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 7;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.LabelAutoFitMaxFontSize = 7;
            chartArea1.AxisY2.LabelAutoFitMinFontSize = 5;
            chartArea1.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea1.AxisY2.LabelStyle.Enabled = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea_Value";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(4);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart.Size = new System.Drawing.Size(253, 169);
            this.chart.SuppressExceptions = true;
            this.chart.TabIndex = 1;
            this.chart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_GetToolTipText);
            this.chart.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart_PostPaint);
            this.chart.PrePaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart_PrePaint);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.chart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_MouseUp);
            // 
            // ArrayDoubleTrendPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart);
            this.Name = "ArrayDoubleTrendPanel";
            this.Size = new System.Drawing.Size(253, 169);
            this.SizeChanged += new System.EventHandler(this.ArrayDoubleTrendPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_Update;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}
