namespace SimulationObject.Item.Delay.Panel
{
    partial class DelayPanel
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
            this.panel = new System.Windows.Forms.Panel();
            this.playPause = new Utils.SpecialControls.PlayPause();
            this.label_OutValue = new System.Windows.Forms.Label();
            this.label_InValue = new System.Windows.Forms.Label();
            this.spinEdit_Delay = new DevExpress.XtraEditors.SpinEdit();
            this.label_Delay = new System.Windows.Forms.Label();
            this.label_Out = new System.Windows.Forms.Label();
            this.label_In = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Delay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.playPause);
            this.panel.Controls.Add(this.label_OutValue);
            this.panel.Controls.Add(this.label_InValue);
            this.panel.Controls.Add(this.spinEdit_Delay);
            this.panel.Controls.Add(this.label_Delay);
            this.panel.Controls.Add(this.label_Out);
            this.panel.Controls.Add(this.label_In);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(232, 118);
            this.panel.TabIndex = 0;
            // 
            // playPause
            // 
            this.playPause.Checked = false;
            this.playPause.Location = new System.Drawing.Point(3, 3);
            this.playPause.Name = "playPause";
            this.playPause.Size = new System.Drawing.Size(31, 29);
            this.playPause.TabIndex = 15;
            this.playPause.CheckedChanged += new System.EventHandler(this.playPause_CheckedChanged);
            // 
            // label_OutValue
            // 
            this.label_OutValue.Location = new System.Drawing.Point(41, 81);
            this.label_OutValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_OutValue.Name = "label_OutValue";
            this.label_OutValue.Size = new System.Drawing.Size(175, 28);
            this.label_OutValue.TabIndex = 14;
            this.label_OutValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_InValue
            // 
            this.label_InValue.Location = new System.Drawing.Point(41, 41);
            this.label_InValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_InValue.Name = "label_InValue";
            this.label_InValue.Size = new System.Drawing.Size(175, 28);
            this.label_InValue.TabIndex = 13;
            this.label_InValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEdit_Delay
            // 
            this.spinEdit_Delay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Delay.Location = new System.Drawing.Point(115, 4);
            this.spinEdit_Delay.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Delay.Name = "spinEdit_Delay";
            this.spinEdit_Delay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Delay.Properties.IsFloatValue = false;
            this.spinEdit_Delay.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Delay.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Delay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Delay.Properties.Mask.EditMask = "N00";
            this.spinEdit_Delay.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_Delay.Size = new System.Drawing.Size(111, 24);
            this.spinEdit_Delay.TabIndex = 1;
            this.spinEdit_Delay.EditValueChanged += new System.EventHandler(this.spinEdit_Delay_EditValueChanged);
            // 
            // label_Delay
            // 
            this.label_Delay.AutoSize = true;
            this.label_Delay.Location = new System.Drawing.Point(39, 9);
            this.label_Delay.Name = "label_Delay";
            this.label_Delay.Size = new System.Drawing.Size(78, 17);
            this.label_Delay.TabIndex = 8;
            this.label_Delay.Text = "Delay [ms]:";
            // 
            // label_Out
            // 
            this.label_Out.AutoSize = true;
            this.label_Out.Location = new System.Drawing.Point(4, 87);
            this.label_Out.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Out.Name = "label_Out";
            this.label_Out.Size = new System.Drawing.Size(35, 17);
            this.label_Out.TabIndex = 12;
            this.label_Out.Text = "Out:";
            // 
            // label_In
            // 
            this.label_In.AutoSize = true;
            this.label_In.Location = new System.Drawing.Point(15, 47);
            this.label_In.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_In.Name = "label_In";
            this.label_In.Size = new System.Drawing.Size(23, 17);
            this.label_In.TabIndex = 11;
            this.label_In.Text = "In:";
            // 
            // DelayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DelayPanel";
            this.Size = new System.Drawing.Size(232, 118);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Delay.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip toolTip;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Delay;
        private System.Windows.Forms.Label label_Delay;
        private System.Windows.Forms.Label label_In;
        private System.Windows.Forms.Label label_OutValue;
        private System.Windows.Forms.Label label_InValue;
        private System.Windows.Forms.Label label_Out;
        private Utils.SpecialControls.PlayPause playPause;
    }
}
