namespace SimulationObject.Binary.Delay.Panel
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
            this.spinEdit_Off = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_On = new DevExpress.XtraEditors.SpinEdit();
            this.label_Off = new System.Windows.Forms.Label();
            this.label_On = new System.Windows.Forms.Label();
            this.label_Output = new System.Windows.Forms.Label();
            this.checkBox_Inverse = new System.Windows.Forms.CheckBox();
            this.label_Input = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Off.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_On.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.spinEdit_Off);
            this.panel.Controls.Add(this.spinEdit_On);
            this.panel.Controls.Add(this.label_Off);
            this.panel.Controls.Add(this.label_On);
            this.panel.Controls.Add(this.label_Output);
            this.panel.Controls.Add(this.checkBox_Inverse);
            this.panel.Controls.Add(this.label_Input);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(176, 114);
            this.panel.TabIndex = 6;
            // 
            // spinEdit_Off
            // 
            this.spinEdit_Off.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Off.Location = new System.Drawing.Point(71, 82);
            this.spinEdit_Off.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spinEdit_Off.Name = "spinEdit_Off";
            this.spinEdit_Off.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Off.Properties.IsFloatValue = false;
            this.spinEdit_Off.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Off.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Off.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Off.Properties.Mask.EditMask = "N00";
            this.spinEdit_Off.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_Off.Size = new System.Drawing.Size(97, 24);
            this.spinEdit_Off.TabIndex = 2;
            this.spinEdit_Off.EditValueChanged += new System.EventHandler(this.spinEdit_Off_EditValueChanged);
            // 
            // spinEdit_On
            // 
            this.spinEdit_On.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_On.Location = new System.Drawing.Point(71, 53);
            this.spinEdit_On.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spinEdit_On.Name = "spinEdit_On";
            this.spinEdit_On.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_On.Properties.IsFloatValue = false;
            this.spinEdit_On.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_On.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_On.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_On.Properties.Mask.EditMask = "N00";
            this.spinEdit_On.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_On.Size = new System.Drawing.Size(97, 24);
            this.spinEdit_On.TabIndex = 1;
            this.spinEdit_On.EditValueChanged += new System.EventHandler(this.spinEdit_On_EditValueChanged);
            // 
            // label_Off
            // 
            this.label_Off.AutoSize = true;
            this.label_Off.Location = new System.Drawing.Point(5, 89);
            this.label_Off.Name = "label_Off";
            this.label_Off.Size = new System.Drawing.Size(61, 17);
            this.label_Off.TabIndex = 6;
            this.label_Off.Text = "Off [ms]:";
            // 
            // label_On
            // 
            this.label_On.AutoSize = true;
            this.label_On.Location = new System.Drawing.Point(5, 59);
            this.label_On.Name = "label_On";
            this.label_On.Size = new System.Drawing.Size(61, 17);
            this.label_On.TabIndex = 5;
            this.label_On.Text = "On [ms]:";
            // 
            // label_Output
            // 
            this.label_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Output.Location = new System.Drawing.Point(91, 2);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(74, 23);
            this.label_Output.TabIndex = 2;
            this.label_Output.Text = "Output";
            this.label_Output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_Inverse
            // 
            this.checkBox_Inverse.AutoSize = true;
            this.checkBox_Inverse.Location = new System.Drawing.Point(47, 30);
            this.checkBox_Inverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Inverse.Name = "checkBox_Inverse";
            this.checkBox_Inverse.Size = new System.Drawing.Size(76, 21);
            this.checkBox_Inverse.TabIndex = 0;
            this.checkBox_Inverse.Text = "Inverse";
            this.checkBox_Inverse.UseVisualStyleBackColor = true;
            this.checkBox_Inverse.CheckedChanged += new System.EventHandler(this.checkBox_Inverse_CheckedChanged);
            // 
            // label_Input
            // 
            this.label_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Input.Location = new System.Drawing.Point(8, 2);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(74, 23);
            this.label_Input.TabIndex = 0;
            this.label_Input.Text = "Input";
            this.label_Input.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DelayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DelayPanel";
            this.Size = new System.Drawing.Size(176, 114);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Off.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_On.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label_Output;
        private System.Windows.Forms.CheckBox checkBox_Inverse;
        private System.Windows.Forms.Label label_Input;
        private System.Windows.Forms.Label label_Off;
        private System.Windows.Forms.Label label_On;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Off;
        private DevExpress.XtraEditors.SpinEdit spinEdit_On;
    }
}
