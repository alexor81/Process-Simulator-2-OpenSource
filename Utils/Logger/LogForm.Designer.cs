// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Logger
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.toolStrip_Log = new System.Windows.Forms.ToolStrip();
            this.tsButton_Track = new System.Windows.Forms.ToolStripButton();
            this.tsButton_StayOnTop = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Clear = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel_Total = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusLabel_Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusLabel_Error = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox_Log = new System.Windows.Forms.ListBox();
            this.toolStrip_Log.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Log
            // 
            this.toolStrip_Log.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Log.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Track,
            this.tsButton_StayOnTop,
            this.tsButton_Clear});
            this.toolStrip_Log.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Log.Name = "toolStrip_Log";
            this.toolStrip_Log.Size = new System.Drawing.Size(862, 25);
            this.toolStrip_Log.TabIndex = 0;
            this.toolStrip_Log.Text = "toolStrip";
            // 
            // tsButton_Track
            // 
            this.tsButton_Track.Checked = true;
            this.tsButton_Track.CheckOnClick = true;
            this.tsButton_Track.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsButton_Track.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Track.Image = global::Utils.Properties.Resources.Track;
            this.tsButton_Track.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Track.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Track.Name = "tsButton_Track";
            this.tsButton_Track.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Track.Text = "Track";
            this.tsButton_Track.Click += new System.EventHandler(this.tsButton_Track_Click);
            // 
            // tsButton_StayOnTop
            // 
            this.tsButton_StayOnTop.CheckOnClick = true;
            this.tsButton_StayOnTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_StayOnTop.Image = global::Utils.Properties.Resources.StayOnTop;
            this.tsButton_StayOnTop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_StayOnTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_StayOnTop.Name = "tsButton_StayOnTop";
            this.tsButton_StayOnTop.Size = new System.Drawing.Size(23, 22);
            this.tsButton_StayOnTop.Text = "Stay on Top";
            this.tsButton_StayOnTop.Click += new System.EventHandler(this.tsButton_StayOnTop_Click);
            // 
            // tsButton_Clear
            // 
            this.tsButton_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Clear.Image = global::Utils.Properties.Resources.Eracer;
            this.tsButton_Clear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Clear.Name = "tsButton_Clear";
            this.tsButton_Clear.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Clear.Text = "Clear";
            this.tsButton_Clear.Click += new System.EventHandler(this.tsButton_Clear_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel_Total,
            this.tsStatusLabel_Info,
            this.tsStatusLabel_Error});
            this.statusStrip1.Location = new System.Drawing.Point(0, 241);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(862, 29);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsStatusLabel_Total
            // 
            this.tsStatusLabel_Total.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsStatusLabel_Total.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsStatusLabel_Total.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsStatusLabel_Total.Name = "tsStatusLabel_Total";
            this.tsStatusLabel_Total.Size = new System.Drawing.Size(62, 24);
            this.tsStatusLabel_Total.Text = "Total: 0";
            // 
            // tsStatusLabel_Info
            // 
            this.tsStatusLabel_Info.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsStatusLabel_Info.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsStatusLabel_Info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsStatusLabel_Info.Name = "tsStatusLabel_Info";
            this.tsStatusLabel_Info.Size = new System.Drawing.Size(54, 24);
            this.tsStatusLabel_Info.Text = "Info: 0";
            // 
            // tsStatusLabel_Error
            // 
            this.tsStatusLabel_Error.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsStatusLabel_Error.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsStatusLabel_Error.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsStatusLabel_Error.Name = "tsStatusLabel_Error";
            this.tsStatusLabel_Error.Size = new System.Drawing.Size(60, 24);
            this.tsStatusLabel_Error.Text = "Error: 0";
            // 
            // listBox_Log
            // 
            this.listBox_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBox_Log.CausesValidation = false;
            this.listBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Log.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox_Log.FormattingEnabled = true;
            this.listBox_Log.ItemHeight = 16;
            this.listBox_Log.Location = new System.Drawing.Point(0, 25);
            this.listBox_Log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_Log.Name = "listBox_Log";
            this.listBox_Log.Size = new System.Drawing.Size(862, 216);
            this.listBox_Log.TabIndex = 3;
            this.listBox_Log.TabStop = false;
            this.listBox_Log.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_Log_DrawItem);
            this.listBox_Log.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBox_Log_MeasureItem);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 270);
            this.Controls.Add(this.listBox_Log);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip_Log);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoggerForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.LogForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogForm_KeyDown);
            this.toolStrip_Log.ResumeLayout(false);
            this.toolStrip_Log.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Log;
        private System.Windows.Forms.ToolStripButton tsButton_Track;
        private System.Windows.Forms.ToolStripButton tsButton_StayOnTop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListBox listBox_Log;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel_Total;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel_Info;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel_Error;
        private System.Windows.Forms.ToolStripButton tsButton_Clear;
    }
}