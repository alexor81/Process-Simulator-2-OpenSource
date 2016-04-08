namespace SimulationObject.Real.Generator.Panel
{
    partial class GeneratorPanel
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
            this.playPause = new Utils.SpecialControls.PlayPause();
            this.spinEdit_TurnMS = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_PeriodMS = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Amplitude = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Bias = new DevExpress.XtraEditors.SpinEdit();
            this.comboBox_Signal = new System.Windows.Forms.ComboBox();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_TurnMS = new System.Windows.Forms.Label();
            this.label_PeriodMS = new System.Windows.Forms.Label();
            this.label_Amplitude = new System.Windows.Forms.Label();
            this.label_Bias = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TurnMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PeriodMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Amplitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Bias.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.playPause);
            this.panel.Controls.Add(this.spinEdit_TurnMS);
            this.panel.Controls.Add(this.spinEdit_PeriodMS);
            this.panel.Controls.Add(this.spinEdit_Amplitude);
            this.panel.Controls.Add(this.spinEdit_Bias);
            this.panel.Controls.Add(this.comboBox_Signal);
            this.panel.Controls.Add(this.label_Value);
            this.panel.Controls.Add(this.label_TurnMS);
            this.panel.Controls.Add(this.label_PeriodMS);
            this.panel.Controls.Add(this.label_Amplitude);
            this.panel.Controls.Add(this.label_Bias);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(4);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(233, 199);
            this.panel.TabIndex = 0;
            // 
            // playPause
            // 
            this.playPause.Checked = false;
            this.playPause.Location = new System.Drawing.Point(6, 3);
            this.playPause.Name = "playPause";
            this.playPause.Size = new System.Drawing.Size(31, 29);
            this.playPause.TabIndex = 56;
            this.playPause.CheckedChanged += new System.EventHandler(this.playPause_CheckedChanged);
            // 
            // spinEdit_TurnMS
            // 
            this.spinEdit_TurnMS.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_TurnMS.Location = new System.Drawing.Point(92, 164);
            this.spinEdit_TurnMS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_TurnMS.Name = "spinEdit_TurnMS";
            this.spinEdit_TurnMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_TurnMS.Properties.IsFloatValue = false;
            this.spinEdit_TurnMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_TurnMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_TurnMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_TurnMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_TurnMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_TurnMS.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_TurnMS.Size = new System.Drawing.Size(132, 24);
            this.spinEdit_TurnMS.TabIndex = 5;
            this.spinEdit_TurnMS.EditValueChanged += new System.EventHandler(this.spinEdit_TurnMS_EditValueChanged);
            // 
            // spinEdit_PeriodMS
            // 
            this.spinEdit_PeriodMS.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_PeriodMS.Location = new System.Drawing.Point(92, 132);
            this.spinEdit_PeriodMS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_PeriodMS.Name = "spinEdit_PeriodMS";
            this.spinEdit_PeriodMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_PeriodMS.Properties.IsFloatValue = false;
            this.spinEdit_PeriodMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_PeriodMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_PeriodMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_PeriodMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_PeriodMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_PeriodMS.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_PeriodMS.Size = new System.Drawing.Size(132, 24);
            this.spinEdit_PeriodMS.TabIndex = 4;
            this.spinEdit_PeriodMS.EditValueChanged += new System.EventHandler(this.spinEdit_PeriodMS_EditValueChanged);
            // 
            // spinEdit_Amplitude
            // 
            this.spinEdit_Amplitude.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Amplitude.Location = new System.Drawing.Point(92, 100);
            this.spinEdit_Amplitude.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Amplitude.Name = "spinEdit_Amplitude";
            this.spinEdit_Amplitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Amplitude.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Amplitude.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Amplitude.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Amplitude.Size = new System.Drawing.Size(132, 24);
            this.spinEdit_Amplitude.TabIndex = 3;
            this.spinEdit_Amplitude.EditValueChanged += new System.EventHandler(this.spinEdit_Amplitude_EditValueChanged);
            // 
            // spinEdit_Bias
            // 
            this.spinEdit_Bias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Bias.Location = new System.Drawing.Point(92, 68);
            this.spinEdit_Bias.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Bias.Name = "spinEdit_Bias";
            this.spinEdit_Bias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Bias.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Bias.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Bias.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Bias.Size = new System.Drawing.Size(132, 24);
            this.spinEdit_Bias.TabIndex = 2;
            this.spinEdit_Bias.EditValueChanged += new System.EventHandler(this.spinEdit_Bias_EditValueChanged);
            // 
            // comboBox_Signal
            // 
            this.comboBox_Signal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Signal.Location = new System.Drawing.Point(8, 37);
            this.comboBox_Signal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Signal.Name = "comboBox_Signal";
            this.comboBox_Signal.Size = new System.Drawing.Size(215, 24);
            this.comboBox_Signal.TabIndex = 1;
            this.comboBox_Signal.SelectedIndexChanged += new System.EventHandler(this.comboBox_Signal_SelectedIndexChanged);
            // 
            // label_Value
            // 
            this.label_Value.BackColor = System.Drawing.SystemColors.Control;
            this.label_Value.Location = new System.Drawing.Point(47, 7);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(171, 20);
            this.label_Value.TabIndex = 40;
            this.label_Value.Text = "0";
            this.label_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_TurnMS
            // 
            this.label_TurnMS.AutoSize = true;
            this.label_TurnMS.Location = new System.Drawing.Point(16, 169);
            this.label_TurnMS.Name = "label_TurnMS";
            this.label_TurnMS.Size = new System.Drawing.Size(72, 17);
            this.label_TurnMS.TabIndex = 55;
            this.label_TurnMS.Text = "Turn [ms]:";
            // 
            // label_PeriodMS
            // 
            this.label_PeriodMS.AutoSize = true;
            this.label_PeriodMS.Location = new System.Drawing.Point(5, 137);
            this.label_PeriodMS.Name = "label_PeriodMS";
            this.label_PeriodMS.Size = new System.Drawing.Size(83, 17);
            this.label_PeriodMS.TabIndex = 54;
            this.label_PeriodMS.Text = "Period [ms]:";
            // 
            // label_Amplitude
            // 
            this.label_Amplitude.AutoSize = true;
            this.label_Amplitude.Location = new System.Drawing.Point(13, 105);
            this.label_Amplitude.Name = "label_Amplitude";
            this.label_Amplitude.Size = new System.Drawing.Size(74, 17);
            this.label_Amplitude.TabIndex = 53;
            this.label_Amplitude.Text = "Amplitude:";
            // 
            // label_Bias
            // 
            this.label_Bias.AutoSize = true;
            this.label_Bias.Location = new System.Drawing.Point(48, 73);
            this.label_Bias.Name = "label_Bias";
            this.label_Bias.Size = new System.Drawing.Size(39, 17);
            this.label_Bias.TabIndex = 52;
            this.label_Bias.Text = "Bias:";
            // 
            // GeneratorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GeneratorPanel";
            this.Size = new System.Drawing.Size(233, 199);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TurnMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PeriodMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Amplitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Bias.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.ComboBox comboBox_Signal;
        private System.Windows.Forms.Label label_TurnMS;
        private System.Windows.Forms.Label label_PeriodMS;
        private System.Windows.Forms.Label label_Amplitude;
        private System.Windows.Forms.Label label_Bias;
        private DevExpress.XtraEditors.SpinEdit spinEdit_TurnMS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_PeriodMS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Amplitude;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Bias;
        private Utils.SpecialControls.PlayPause playPause;
    }
}
