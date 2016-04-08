namespace SimulationObject.Item.TimeLine.Panel
{
    partial class TimeLinePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeLinePanel));
            this.panel = new System.Windows.Forms.Panel();
            this.playPause = new Utils.SpecialControls.PlayPause();
            this.checkBox_Loop = new System.Windows.Forms.CheckBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.playPause);
            this.panel.Controls.Add(this.checkBox_Loop);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(70, 36);
            this.panel.TabIndex = 0;
            // 
            // playPause
            // 
            this.playPause.Checked = false;
            this.playPause.Location = new System.Drawing.Point(4, 4);
            this.playPause.Name = "playPause";
            this.playPause.Size = new System.Drawing.Size(31, 29);
            this.playPause.TabIndex = 3;
            this.playPause.CheckedChanged += new System.EventHandler(this.playPause_CheckedChanged);
            // 
            // checkBox_Loop
            // 
            this.checkBox_Loop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Loop.ImageIndex = 0;
            this.checkBox_Loop.ImageList = this.imageList;
            this.checkBox_Loop.Location = new System.Drawing.Point(38, 5);
            this.checkBox_Loop.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Loop.Name = "checkBox_Loop";
            this.checkBox_Loop.Size = new System.Drawing.Size(29, 27);
            this.checkBox_Loop.TabIndex = 2;
            this.checkBox_Loop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_Loop.UseVisualStyleBackColor = true;
            this.checkBox_Loop.CheckedChanged += new System.EventHandler(this.checkBox_Loop_CheckedChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Loop.gif");
            // 
            // TimeLinePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "TimeLinePanel";
            this.Size = new System.Drawing.Size(70, 36);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.CheckBox checkBox_Loop;
        private System.Windows.Forms.ToolTip toolTip;
        private Utils.SpecialControls.PlayPause playPause;
    }
}
