// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Real.XYDependency
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.panel_Items = new System.Windows.Forms.Panel();
            this.itemEditBox_X = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Y = new Utils.SpecialControls.ItemEditBox();
            this.panel_Points = new System.Windows.Forms.Panel();
            this.splitContainerControl_Points = new DevExpress.XtraEditors.SplitContainerControl();
            this.listBox_Points = new System.Windows.Forms.ListBox();
            this.toolStrip_Points = new System.Windows.Forms.ToolStrip();
            this.tsLabel_Points = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Add = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Setup = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel_OkCancel.SuspendLayout();
            this.panel_Items.SuspendLayout();
            this.panel_Points.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Points)).BeginInit();
            this.splitContainerControl_Points.SuspendLayout();
            this.toolStrip_Points.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(16, 15);
            this.label_X.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(21, 17);
            this.label_X.TabIndex = 56;
            this.label_X.Text = "X:";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(343, 15);
            this.label_Y.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(21, 17);
            this.label_Y.TabIndex = 55;
            this.label_Y.Text = "Y:";
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY2.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont)));
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Blue;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(520, 388);
            this.chart.TabIndex = 57;
            this.chart.Text = "chart";
            this.chart.PrePaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart_PrePaint);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            this.chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart_MouseMove);
            this.chart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chart_MouseUp);
            // 
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 433);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(668, 46);
            this.panel_OkCancel.TabIndex = 2;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okCancelButton.Location = new System.Drawing.Point(240, 7);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 0;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // panel_Items
            // 
            this.panel_Items.Controls.Add(this.itemEditBox_X);
            this.panel_Items.Controls.Add(this.label_X);
            this.panel_Items.Controls.Add(this.itemEditBox_Y);
            this.panel_Items.Controls.Add(this.label_Y);
            this.panel_Items.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Items.Location = new System.Drawing.Point(0, 0);
            this.panel_Items.Name = "panel_Items";
            this.panel_Items.Size = new System.Drawing.Size(668, 45);
            this.panel_Items.TabIndex = 0;
            // 
            // itemEditBox_X
            // 
            this.itemEditBox_X.ItemName = "";
            this.itemEditBox_X.ItemRequirements = "Real, Read, Required";
            this.itemEditBox_X.ItemToolTip = "";
            this.itemEditBox_X.Location = new System.Drawing.Point(42, 8);
            this.itemEditBox_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_X.Name = "itemEditBox_X";
            this.itemEditBox_X.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_X.TabIndex = 0;
            this.itemEditBox_X.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Y
            // 
            this.itemEditBox_Y.ItemName = "";
            this.itemEditBox_Y.ItemRequirements = "Real, Write, Required";
            this.itemEditBox_Y.ItemToolTip = "";
            this.itemEditBox_Y.Location = new System.Drawing.Point(369, 8);
            this.itemEditBox_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Y.Name = "itemEditBox_Y";
            this.itemEditBox_Y.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_Y.TabIndex = 1;
            this.itemEditBox_Y.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // panel_Points
            // 
            this.panel_Points.Controls.Add(this.splitContainerControl_Points);
            this.panel_Points.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Points.Location = new System.Drawing.Point(0, 45);
            this.panel_Points.Name = "panel_Points";
            this.panel_Points.Size = new System.Drawing.Size(668, 388);
            this.panel_Points.TabIndex = 62;
            // 
            // splitContainerControl_Points
            // 
            this.splitContainerControl_Points.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl_Points.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl_Points.LookAndFeel.SkinName = "Office 2010 Black";
            this.splitContainerControl_Points.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl_Points.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerControl_Points.Name = "splitContainerControl_Points";
            this.splitContainerControl_Points.Panel1.Controls.Add(this.listBox_Points);
            this.splitContainerControl_Points.Panel1.Controls.Add(this.toolStrip_Points);
            this.splitContainerControl_Points.Panel1.Text = "Panel1";
            this.splitContainerControl_Points.Panel2.Controls.Add(this.chart);
            this.splitContainerControl_Points.Panel2.Text = "Panel2";
            this.splitContainerControl_Points.Size = new System.Drawing.Size(668, 388);
            this.splitContainerControl_Points.SplitterPosition = 142;
            this.splitContainerControl_Points.TabIndex = 1;
            // 
            // listBox_Points
            // 
            this.listBox_Points.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Points.FormattingEnabled = true;
            this.listBox_Points.IntegralHeight = false;
            this.listBox_Points.ItemHeight = 16;
            this.listBox_Points.Location = new System.Drawing.Point(0, 25);
            this.listBox_Points.Name = "listBox_Points";
            this.listBox_Points.Size = new System.Drawing.Size(142, 363);
            this.listBox_Points.TabIndex = 2;
            this.listBox_Points.TabStop = false;
            this.listBox_Points.SelectedIndexChanged += new System.EventHandler(this.listBox_Points_SelectedIndexChanged);
            this.listBox_Points.DoubleClick += new System.EventHandler(this.tsButton_Setup_Click);
            // 
            // toolStrip_Points
            // 
            this.toolStrip_Points.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Points.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel_Points,
            this.toolStripSeparator1,
            this.tsButton_Add,
            this.tsButton_Delete,
            this.tsButton_Setup});
            this.toolStrip_Points.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Points.Name = "toolStrip_Points";
            this.toolStrip_Points.Size = new System.Drawing.Size(142, 25);
            this.toolStrip_Points.TabIndex = 0;
            this.toolStrip_Points.Text = "Points";
            // 
            // tsLabel_Points
            // 
            this.tsLabel_Points.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsLabel_Points.Name = "tsLabel_Points";
            this.tsLabel_Points.Size = new System.Drawing.Size(50, 22);
            this.tsLabel_Points.Text = "Points";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Add
            // 
            this.tsButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Add.Image = global::SimulationObject.Real.XYDependency.Properties.Resources.Add;
            this.tsButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Add.Name = "tsButton_Add";
            this.tsButton_Add.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Add.Text = "Add";
            this.tsButton_Add.Click += new System.EventHandler(this.tsButton_Add_Click);
            // 
            // tsButton_Delete
            // 
            this.tsButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Delete.Image = global::SimulationObject.Real.XYDependency.Properties.Resources.Delete;
            this.tsButton_Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Delete.Name = "tsButton_Delete";
            this.tsButton_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Delete.Text = "Delete";
            this.tsButton_Delete.Click += new System.EventHandler(this.tsButton_Delete_Click);
            // 
            // tsButton_Setup
            // 
            this.tsButton_Setup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Setup.Image = global::SimulationObject.Real.XYDependency.Properties.Resources.Setup;
            this.tsButton_Setup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Setup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Setup.Name = "tsButton_Setup";
            this.tsButton_Setup.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Setup.Text = "Setup";
            this.tsButton_Setup.Click += new System.EventHandler(this.tsButton_Setup_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 479);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Points);
            this.Controls.Add(this.panel_Items);
            this.Controls.Add(this.panel_OkCancel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Real.XYDependency";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel_OkCancel.ResumeLayout(false);
            this.panel_Items.ResumeLayout(false);
            this.panel_Items.PerformLayout();
            this.panel_Points.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Points)).EndInit();
            this.splitContainerControl_Points.ResumeLayout(false);
            this.toolStrip_Points.ResumeLayout(false);
            this.toolStrip_Points.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Y;
        private Utils.SpecialControls.ItemEditBox itemEditBox_X;
        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panel_OkCancel;
        private System.Windows.Forms.Panel panel_Items;
        private System.Windows.Forms.Panel panel_Points;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_Points;
        private System.Windows.Forms.ToolStrip toolStrip_Points;
        private System.Windows.Forms.ToolStripButton tsButton_Add;
        private System.Windows.Forms.ToolStripButton tsButton_Delete;
        private System.Windows.Forms.ListBox listBox_Points;
        private System.Windows.Forms.ToolStripButton tsButton_Setup;
        private System.Windows.Forms.ToolStripLabel tsLabel_Points;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}