namespace SimulationObject.Real.Lag.Panel
{
    partial class LagPanel
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
            this.panel = new System.Windows.Forms.Panel();
            this.label_Value = new System.Windows.Forms.Label();
            this.spinEdit_LagMS = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Gain = new DevExpress.XtraEditors.SpinEdit();
            this.label_LagMS = new System.Windows.Forms.Label();
            this.label_Gain = new System.Windows.Forms.Label();
            this.label_Input = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LagMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Gain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.label_Value);
            this.panel.Controls.Add(this.spinEdit_LagMS);
            this.panel.Controls.Add(this.spinEdit_Gain);
            this.panel.Controls.Add(this.label_LagMS);
            this.panel.Controls.Add(this.label_Gain);
            this.panel.Controls.Add(this.label_Input);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(159, 104);
            this.panel.TabIndex = 0;
            // 
            // label_Value
            // 
            this.label_Value.BackColor = System.Drawing.SystemColors.Control;
            this.label_Value.Location = new System.Drawing.Point(15, 81);
            this.label_Value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(128, 16);
            this.label_Value.TabIndex = 61;
            this.label_Value.Text = "0";
            this.label_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEdit_LagMS
            // 
            this.spinEdit_LagMS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_LagMS.Location = new System.Drawing.Point(56, 54);
            this.spinEdit_LagMS.Name = "spinEdit_LagMS";
            this.spinEdit_LagMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_LagMS.Properties.IsFloatValue = false;
            this.spinEdit_LagMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_LagMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_LagMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_LagMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_LagMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_LagMS.Size = new System.Drawing.Size(99, 22);
            this.spinEdit_LagMS.TabIndex = 1;
            this.spinEdit_LagMS.EditValueChanged += new System.EventHandler(this.spinEdit_LagMS_EditValueChanged);
            // 
            // spinEdit_Gain
            // 
            this.spinEdit_Gain.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Gain.Location = new System.Drawing.Point(56, 28);
            this.spinEdit_Gain.Name = "spinEdit_Gain";
            this.spinEdit_Gain.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Gain.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Gain.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Gain.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Gain.Size = new System.Drawing.Size(99, 22);
            this.spinEdit_Gain.TabIndex = 0;
            this.spinEdit_Gain.EditValueChanged += new System.EventHandler(this.spinEdit_Gain_EditValueChanged);
            // 
            // label_LagMS
            // 
            this.label_LagMS.AutoSize = true;
            this.label_LagMS.Location = new System.Drawing.Point(3, 58);
            this.label_LagMS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_LagMS.Name = "label_LagMS";
            this.label_LagMS.Size = new System.Drawing.Size(50, 13);
            this.label_LagMS.TabIndex = 58;
            this.label_LagMS.Text = "Lag [ms]:";
            // 
            // label_Gain
            // 
            this.label_Gain.AutoSize = true;
            this.label_Gain.Location = new System.Drawing.Point(21, 32);
            this.label_Gain.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Gain.Name = "label_Gain";
            this.label_Gain.Size = new System.Drawing.Size(32, 13);
            this.label_Gain.TabIndex = 57;
            this.label_Gain.Text = "Gain:";
            // 
            // label_Input
            // 
            this.label_Input.BackColor = System.Drawing.SystemColors.Control;
            this.label_Input.Location = new System.Drawing.Point(15, 7);
            this.label_Input.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(128, 16);
            this.label_Input.TabIndex = 41;
            this.label_Input.Text = "0";
            this.label_Input.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LagPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "LagPanel";
            this.Size = new System.Drawing.Size(159, 104);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LagMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Gain.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label_Input;
        private System.Windows.Forms.Label label_Value;
        private DevExpress.XtraEditors.SpinEdit spinEdit_LagMS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Gain;
        private System.Windows.Forms.Label label_LagMS;
        private System.Windows.Forms.Label label_Gain;
    }
}
