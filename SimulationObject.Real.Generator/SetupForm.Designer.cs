// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Real.Generator
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
            this.itemEditBox_Value = new Utils.SpecialControls.ItemEditBox();
            this.label_Value = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.comboBox_Signal = new System.Windows.Forms.ComboBox();
            this.label_Signal = new System.Windows.Forms.Label();
            this.label_Bias = new System.Windows.Forms.Label();
            this.label_Amplitude = new System.Windows.Forms.Label();
            this.label_Period = new System.Windows.Forms.Label();
            this.label_Turn = new System.Windows.Forms.Label();
            this.spinEdit_Bias = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Amplitude = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_PeriodMS = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_TurnMS = new DevExpress.XtraEditors.SpinEdit();
            this.itemEditBox_On = new Utils.SpecialControls.ItemEditBox();
            this.label_On = new System.Windows.Forms.Label();
            this.spinEdit_StartMS = new DevExpress.XtraEditors.SpinEdit();
            this.label_Start = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Bias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Amplitude.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PeriodMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TurnMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_StartMS.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // itemEditBox_Value
            // 
            this.itemEditBox_Value.ItemName = "";
            this.itemEditBox_Value.ItemRequirements = "Real, Write, Required";
            this.itemEditBox_Value.ItemToolTip = "";
            this.itemEditBox_Value.Location = new System.Drawing.Point(64, 43);
            this.itemEditBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Value.Name = "itemEditBox_Value";
            this.itemEditBox_Value.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_Value.TabIndex = 1;
            this.itemEditBox_Value.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(11, 50);
            this.label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 41;
            this.label_Value.Text = "Value:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(85, 277);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 8;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // comboBox_Signal
            // 
            this.comboBox_Signal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Signal.FormattingEnabled = true;
            this.comboBox_Signal.Location = new System.Drawing.Point(131, 84);
            this.comboBox_Signal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Signal.Name = "comboBox_Signal";
            this.comboBox_Signal.Size = new System.Drawing.Size(157, 24);
            this.comboBox_Signal.TabIndex = 2;
            // 
            // label_Signal
            // 
            this.label_Signal.AutoSize = true;
            this.label_Signal.Location = new System.Drawing.Point(73, 88);
            this.label_Signal.Name = "label_Signal";
            this.label_Signal.Size = new System.Drawing.Size(51, 17);
            this.label_Signal.TabIndex = 43;
            this.label_Signal.Text = "Signal:";
            // 
            // label_Bias
            // 
            this.label_Bias.AutoSize = true;
            this.label_Bias.Location = new System.Drawing.Point(85, 119);
            this.label_Bias.Name = "label_Bias";
            this.label_Bias.Size = new System.Drawing.Size(39, 17);
            this.label_Bias.TabIndex = 44;
            this.label_Bias.Text = "Bias:";
            // 
            // label_Amplitude
            // 
            this.label_Amplitude.AutoSize = true;
            this.label_Amplitude.Location = new System.Drawing.Point(51, 150);
            this.label_Amplitude.Name = "label_Amplitude";
            this.label_Amplitude.Size = new System.Drawing.Size(74, 17);
            this.label_Amplitude.TabIndex = 45;
            this.label_Amplitude.Text = "Amplitude:";
            // 
            // label_Period
            // 
            this.label_Period.AutoSize = true;
            this.label_Period.Location = new System.Drawing.Point(43, 181);
            this.label_Period.Name = "label_Period";
            this.label_Period.Size = new System.Drawing.Size(83, 17);
            this.label_Period.TabIndex = 46;
            this.label_Period.Text = "Period [ms]:";
            // 
            // label_Turn
            // 
            this.label_Turn.AutoSize = true;
            this.label_Turn.Location = new System.Drawing.Point(53, 212);
            this.label_Turn.Name = "label_Turn";
            this.label_Turn.Size = new System.Drawing.Size(72, 17);
            this.label_Turn.TabIndex = 47;
            this.label_Turn.Text = "Turn [ms]:";
            // 
            // spinEdit_Bias
            // 
            this.spinEdit_Bias.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Bias.Location = new System.Drawing.Point(131, 115);
            this.spinEdit_Bias.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Bias.Name = "spinEdit_Bias";
            this.spinEdit_Bias.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Bias.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Bias.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Bias.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Bias.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_Bias.TabIndex = 3;
            // 
            // spinEdit_Amplitude
            // 
            this.spinEdit_Amplitude.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Amplitude.Location = new System.Drawing.Point(131, 146);
            this.spinEdit_Amplitude.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Amplitude.Name = "spinEdit_Amplitude";
            this.spinEdit_Amplitude.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Amplitude.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Amplitude.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Amplitude.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Amplitude.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_Amplitude.TabIndex = 4;
            // 
            // spinEdit_PeriodMS
            // 
            this.spinEdit_PeriodMS.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_PeriodMS.Location = new System.Drawing.Point(131, 177);
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
            this.spinEdit_PeriodMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_PeriodMS.TabIndex = 5;
            // 
            // spinEdit_TurnMS
            // 
            this.spinEdit_TurnMS.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_TurnMS.Location = new System.Drawing.Point(131, 208);
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
            this.spinEdit_TurnMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_TurnMS.TabIndex = 6;
            // 
            // itemEditBox_On
            // 
            this.itemEditBox_On.ItemName = "";
            this.itemEditBox_On.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_On.ItemToolTip = "";
            this.itemEditBox_On.Location = new System.Drawing.Point(64, 5);
            this.itemEditBox_On.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_On.Name = "itemEditBox_On";
            this.itemEditBox_On.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_On.TabIndex = 0;
            this.itemEditBox_On.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_On
            // 
            this.label_On.AutoSize = true;
            this.label_On.Location = new System.Drawing.Point(28, 12);
            this.label_On.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_On.Name = "label_On";
            this.label_On.Size = new System.Drawing.Size(31, 17);
            this.label_On.TabIndex = 49;
            this.label_On.Text = "On:";
            // 
            // spinEdit_StartMS
            // 
            this.spinEdit_StartMS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_StartMS.Location = new System.Drawing.Point(131, 239);
            this.spinEdit_StartMS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_StartMS.Name = "spinEdit_StartMS";
            this.spinEdit_StartMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_StartMS.Properties.IsFloatValue = false;
            this.spinEdit_StartMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_StartMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_StartMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_StartMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_StartMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_StartMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_StartMS.TabIndex = 7;
            // 
            // label_Start
            // 
            this.label_Start.AutoSize = true;
            this.label_Start.Location = new System.Drawing.Point(53, 243);
            this.label_Start.Name = "label_Start";
            this.label_Start.Size = new System.Drawing.Size(72, 17);
            this.label_Start.TabIndex = 51;
            this.label_Start.Text = "Start [ms]:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 313);
            this.ControlBox = false;
            this.Controls.Add(this.spinEdit_StartMS);
            this.Controls.Add(this.label_Start);
            this.Controls.Add(this.itemEditBox_On);
            this.Controls.Add(this.label_On);
            this.Controls.Add(this.spinEdit_TurnMS);
            this.Controls.Add(this.spinEdit_PeriodMS);
            this.Controls.Add(this.spinEdit_Amplitude);
            this.Controls.Add(this.spinEdit_Bias);
            this.Controls.Add(this.label_Turn);
            this.Controls.Add(this.label_Period);
            this.Controls.Add(this.label_Amplitude);
            this.Controls.Add(this.label_Bias);
            this.Controls.Add(this.comboBox_Signal);
            this.Controls.Add(this.label_Signal);
            this.Controls.Add(this.itemEditBox_Value);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Real.Generator";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Bias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Amplitude.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PeriodMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TurnMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_StartMS.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.ItemEditBox itemEditBox_Value;
        private System.Windows.Forms.Label label_Value;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.ComboBox comboBox_Signal;
        private System.Windows.Forms.Label label_Signal;
        private System.Windows.Forms.Label label_Bias;
        private System.Windows.Forms.Label label_Amplitude;
        private System.Windows.Forms.Label label_Period;
        private System.Windows.Forms.Label label_Turn;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Bias;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Amplitude;
        private DevExpress.XtraEditors.SpinEdit spinEdit_PeriodMS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_TurnMS;
        private Utils.SpecialControls.ItemEditBox itemEditBox_On;
        private System.Windows.Forms.Label label_On;
        private DevExpress.XtraEditors.SpinEdit spinEdit_StartMS;
        private System.Windows.Forms.Label label_Start;
    }
}