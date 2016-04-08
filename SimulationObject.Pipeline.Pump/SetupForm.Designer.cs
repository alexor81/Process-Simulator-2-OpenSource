namespace SimulationObject.Pipeline.Pump
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
            this.groupBox_Control = new System.Windows.Forms.GroupBox();
            this.checkBox_IgnoreCommands = new System.Windows.Forms.CheckBox();
            this.itemEditBox_EsdCMD = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_OffCMD = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_OnCMD = new Utils.SpecialControls.ItemEditBox();
            this.label_EsdCMD = new System.Windows.Forms.Label();
            this.label_OffCMD = new System.Windows.Forms.Label();
            this.label_OnCMD = new System.Windows.Forms.Label();
            this.groupBox_Signals = new System.Windows.Forms.GroupBox();
            this.itemEditBox_On = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Remote = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Power = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Alarm = new Utils.SpecialControls.ItemEditBox();
            this.label_On = new System.Windows.Forms.Label();
            this.label_Power = new System.Windows.Forms.Label();
            this.label_Remote = new System.Windows.Forms.Label();
            this.label_Alarm = new System.Windows.Forms.Label();
            this.groupBox_Delay = new System.Windows.Forms.GroupBox();
            this.spinEdit_Off = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_On = new DevExpress.XtraEditors.SpinEdit();
            this.label_OffMS = new System.Windows.Forms.Label();
            this.label_OnMS = new System.Windows.Forms.Label();
            this.label_OffBtn = new System.Windows.Forms.Label();
            this.groupBox_Buttons = new System.Windows.Forms.GroupBox();
            this.itemEditBox_OnBtn = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_OffBtn = new Utils.SpecialControls.ItemEditBox();
            this.label_OnBtn = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Control.SuspendLayout();
            this.groupBox_Signals.SuspendLayout();
            this.groupBox_Delay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Off.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_On.Properties)).BeginInit();
            this.groupBox_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.Controls.Add(this.checkBox_IgnoreCommands);
            this.groupBox_Control.Controls.Add(this.itemEditBox_EsdCMD);
            this.groupBox_Control.Controls.Add(this.itemEditBox_OffCMD);
            this.groupBox_Control.Controls.Add(this.itemEditBox_OnCMD);
            this.groupBox_Control.Controls.Add(this.label_EsdCMD);
            this.groupBox_Control.Controls.Add(this.label_OffCMD);
            this.groupBox_Control.Controls.Add(this.label_OnCMD);
            this.groupBox_Control.Location = new System.Drawing.Point(6, 2);
            this.groupBox_Control.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Control.Size = new System.Drawing.Size(304, 154);
            this.groupBox_Control.TabIndex = 0;
            this.groupBox_Control.TabStop = false;
            this.groupBox_Control.Text = "Control";
            // 
            // checkBox_IgnoreCommands
            // 
            this.checkBox_IgnoreCommands.AutoSize = true;
            this.checkBox_IgnoreCommands.Location = new System.Drawing.Point(10, 21);
            this.checkBox_IgnoreCommands.Name = "checkBox_IgnoreCommands";
            this.checkBox_IgnoreCommands.Size = new System.Drawing.Size(144, 21);
            this.checkBox_IgnoreCommands.TabIndex = 25;
            this.checkBox_IgnoreCommands.Text = "Ignore Commands";
            this.checkBox_IgnoreCommands.UseVisualStyleBackColor = true;
            // 
            // itemEditBox_EsdCMD
            // 
            this.itemEditBox_EsdCMD.ItemName = "";
            this.itemEditBox_EsdCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_EsdCMD.ItemToolTip = "";
            this.itemEditBox_EsdCMD.Location = new System.Drawing.Point(53, 120);
            this.itemEditBox_EsdCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_EsdCMD.Name = "itemEditBox_EsdCMD";
            this.itemEditBox_EsdCMD.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_EsdCMD.TabIndex = 2;
            this.itemEditBox_EsdCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_OffCMD
            // 
            this.itemEditBox_OffCMD.ItemName = "";
            this.itemEditBox_OffCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_OffCMD.ItemToolTip = "";
            this.itemEditBox_OffCMD.Location = new System.Drawing.Point(53, 83);
            this.itemEditBox_OffCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_OffCMD.Name = "itemEditBox_OffCMD";
            this.itemEditBox_OffCMD.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_OffCMD.TabIndex = 1;
            this.itemEditBox_OffCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_OnCMD
            // 
            this.itemEditBox_OnCMD.ItemName = "";
            this.itemEditBox_OnCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_OnCMD.ItemToolTip = "";
            this.itemEditBox_OnCMD.Location = new System.Drawing.Point(53, 46);
            this.itemEditBox_OnCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_OnCMD.Name = "itemEditBox_OnCMD";
            this.itemEditBox_OnCMD.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_OnCMD.TabIndex = 0;
            this.itemEditBox_OnCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_EsdCMD
            // 
            this.label_EsdCMD.AutoSize = true;
            this.label_EsdCMD.Location = new System.Drawing.Point(7, 127);
            this.label_EsdCMD.Name = "label_EsdCMD";
            this.label_EsdCMD.Size = new System.Drawing.Size(40, 17);
            this.label_EsdCMD.TabIndex = 24;
            this.label_EsdCMD.Text = "ESD:";
            // 
            // label_OffCMD
            // 
            this.label_OffCMD.AutoSize = true;
            this.label_OffCMD.Location = new System.Drawing.Point(17, 90);
            this.label_OffCMD.Name = "label_OffCMD";
            this.label_OffCMD.Size = new System.Drawing.Size(31, 17);
            this.label_OffCMD.TabIndex = 23;
            this.label_OffCMD.Text = "Off:";
            // 
            // label_OnCMD
            // 
            this.label_OnCMD.AutoSize = true;
            this.label_OnCMD.Location = new System.Drawing.Point(17, 54);
            this.label_OnCMD.Name = "label_OnCMD";
            this.label_OnCMD.Size = new System.Drawing.Size(31, 17);
            this.label_OnCMD.TabIndex = 1;
            this.label_OnCMD.Text = "On:";
            // 
            // groupBox_Signals
            // 
            this.groupBox_Signals.Controls.Add(this.itemEditBox_On);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Remote);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Power);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Alarm);
            this.groupBox_Signals.Controls.Add(this.label_On);
            this.groupBox_Signals.Controls.Add(this.label_Power);
            this.groupBox_Signals.Controls.Add(this.label_Remote);
            this.groupBox_Signals.Controls.Add(this.label_Alarm);
            this.groupBox_Signals.Location = new System.Drawing.Point(316, 1);
            this.groupBox_Signals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Signals.Name = "groupBox_Signals";
            this.groupBox_Signals.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Signals.Size = new System.Drawing.Size(324, 155);
            this.groupBox_Signals.TabIndex = 2;
            this.groupBox_Signals.TabStop = false;
            this.groupBox_Signals.Text = "Signals";
            // 
            // itemEditBox_On
            // 
            this.itemEditBox_On.ItemName = "";
            this.itemEditBox_On.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_On.ItemToolTip = "";
            this.itemEditBox_On.Location = new System.Drawing.Point(73, 16);
            this.itemEditBox_On.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_On.Name = "itemEditBox_On";
            this.itemEditBox_On.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_On.TabIndex = 0;
            this.itemEditBox_On.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Remote
            // 
            this.itemEditBox_Remote.ItemName = "";
            this.itemEditBox_Remote.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Remote.ItemToolTip = "";
            this.itemEditBox_Remote.Location = new System.Drawing.Point(73, 119);
            this.itemEditBox_Remote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Remote.Name = "itemEditBox_Remote";
            this.itemEditBox_Remote.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Remote.TabIndex = 3;
            this.itemEditBox_Remote.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Power
            // 
            this.itemEditBox_Power.ItemName = "";
            this.itemEditBox_Power.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Power.ItemToolTip = "";
            this.itemEditBox_Power.Location = new System.Drawing.Point(73, 85);
            this.itemEditBox_Power.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Power.Name = "itemEditBox_Power";
            this.itemEditBox_Power.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Power.TabIndex = 2;
            this.itemEditBox_Power.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Alarm
            // 
            this.itemEditBox_Alarm.ItemName = "";
            this.itemEditBox_Alarm.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Alarm.ItemToolTip = "";
            this.itemEditBox_Alarm.Location = new System.Drawing.Point(73, 50);
            this.itemEditBox_Alarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Alarm.Name = "itemEditBox_Alarm";
            this.itemEditBox_Alarm.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Alarm.TabIndex = 1;
            this.itemEditBox_Alarm.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_On
            // 
            this.label_On.AutoSize = true;
            this.label_On.Location = new System.Drawing.Point(37, 23);
            this.label_On.Name = "label_On";
            this.label_On.Size = new System.Drawing.Size(31, 17);
            this.label_On.TabIndex = 54;
            this.label_On.Text = "On:";
            // 
            // label_Power
            // 
            this.label_Power.AutoSize = true;
            this.label_Power.Location = new System.Drawing.Point(16, 92);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(51, 17);
            this.label_Power.TabIndex = 49;
            this.label_Power.Text = "Power:";
            // 
            // label_Remote
            // 
            this.label_Remote.AutoSize = true;
            this.label_Remote.Location = new System.Drawing.Point(7, 127);
            this.label_Remote.Name = "label_Remote";
            this.label_Remote.Size = new System.Drawing.Size(61, 17);
            this.label_Remote.TabIndex = 47;
            this.label_Remote.Text = "Remote:";
            // 
            // label_Alarm
            // 
            this.label_Alarm.AutoSize = true;
            this.label_Alarm.Location = new System.Drawing.Point(21, 58);
            this.label_Alarm.Name = "label_Alarm";
            this.label_Alarm.Size = new System.Drawing.Size(48, 17);
            this.label_Alarm.TabIndex = 44;
            this.label_Alarm.Text = "Alarm:";
            // 
            // groupBox_Delay
            // 
            this.groupBox_Delay.Controls.Add(this.spinEdit_Off);
            this.groupBox_Delay.Controls.Add(this.spinEdit_On);
            this.groupBox_Delay.Controls.Add(this.label_OffMS);
            this.groupBox_Delay.Controls.Add(this.label_OnMS);
            this.groupBox_Delay.Location = new System.Drawing.Point(6, 158);
            this.groupBox_Delay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Delay.Name = "groupBox_Delay";
            this.groupBox_Delay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Delay.Size = new System.Drawing.Size(304, 89);
            this.groupBox_Delay.TabIndex = 1;
            this.groupBox_Delay.TabStop = false;
            this.groupBox_Delay.Text = "Delay";
            // 
            // spinEdit_Off
            // 
            this.spinEdit_Off.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Off.Location = new System.Drawing.Point(107, 54);
            this.spinEdit_Off.Margin = new System.Windows.Forms.Padding(4);
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
            this.spinEdit_Off.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_Off.TabIndex = 34;
            // 
            // spinEdit_On
            // 
            this.spinEdit_On.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_On.Location = new System.Drawing.Point(107, 19);
            this.spinEdit_On.Margin = new System.Windows.Forms.Padding(4);
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
            this.spinEdit_On.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_On.TabIndex = 33;
            // 
            // label_OffMS
            // 
            this.label_OffMS.AutoSize = true;
            this.label_OffMS.Location = new System.Drawing.Point(40, 59);
            this.label_OffMS.Name = "label_OffMS";
            this.label_OffMS.Size = new System.Drawing.Size(61, 17);
            this.label_OffMS.TabIndex = 32;
            this.label_OffMS.Text = "Off [ms]:";
            // 
            // label_OnMS
            // 
            this.label_OnMS.AutoSize = true;
            this.label_OnMS.Location = new System.Drawing.Point(40, 24);
            this.label_OnMS.Name = "label_OnMS";
            this.label_OnMS.Size = new System.Drawing.Size(61, 17);
            this.label_OnMS.TabIndex = 30;
            this.label_OnMS.Text = "On [ms]:";
            // 
            // label_OffBtn
            // 
            this.label_OffBtn.AutoSize = true;
            this.label_OffBtn.Location = new System.Drawing.Point(37, 60);
            this.label_OffBtn.Name = "label_OffBtn";
            this.label_OffBtn.Size = new System.Drawing.Size(31, 17);
            this.label_OffBtn.TabIndex = 53;
            this.label_OffBtn.Text = "Off:";
            // 
            // groupBox_Buttons
            // 
            this.groupBox_Buttons.Controls.Add(this.itemEditBox_OnBtn);
            this.groupBox_Buttons.Controls.Add(this.itemEditBox_OffBtn);
            this.groupBox_Buttons.Controls.Add(this.label_OnBtn);
            this.groupBox_Buttons.Controls.Add(this.label_OffBtn);
            this.groupBox_Buttons.Location = new System.Drawing.Point(316, 158);
            this.groupBox_Buttons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Buttons.Name = "groupBox_Buttons";
            this.groupBox_Buttons.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Buttons.Size = new System.Drawing.Size(324, 89);
            this.groupBox_Buttons.TabIndex = 3;
            this.groupBox_Buttons.TabStop = false;
            this.groupBox_Buttons.Text = "Buttons";
            // 
            // itemEditBox_OnBtn
            // 
            this.itemEditBox_OnBtn.ItemName = "";
            this.itemEditBox_OnBtn.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_OnBtn.ItemToolTip = "";
            this.itemEditBox_OnBtn.Location = new System.Drawing.Point(73, 17);
            this.itemEditBox_OnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_OnBtn.Name = "itemEditBox_OnBtn";
            this.itemEditBox_OnBtn.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_OnBtn.TabIndex = 0;
            this.itemEditBox_OnBtn.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_OffBtn
            // 
            this.itemEditBox_OffBtn.ItemName = "";
            this.itemEditBox_OffBtn.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_OffBtn.ItemToolTip = "";
            this.itemEditBox_OffBtn.Location = new System.Drawing.Point(73, 53);
            this.itemEditBox_OffBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_OffBtn.Name = "itemEditBox_OffBtn";
            this.itemEditBox_OffBtn.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_OffBtn.TabIndex = 1;
            this.itemEditBox_OffBtn.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_OnBtn
            // 
            this.label_OnBtn.AutoSize = true;
            this.label_OnBtn.Location = new System.Drawing.Point(37, 25);
            this.label_OnBtn.Name = "label_OnBtn";
            this.label_OnBtn.Size = new System.Drawing.Size(31, 17);
            this.label_OnBtn.TabIndex = 54;
            this.label_OnBtn.Text = "On:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(229, 253);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 294);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Buttons);
            this.Controls.Add(this.groupBox_Delay);
            this.Controls.Add(this.groupBox_Signals);
            this.Controls.Add(this.groupBox_Control);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pipeline.Pump";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            this.groupBox_Signals.ResumeLayout(false);
            this.groupBox_Signals.PerformLayout();
            this.groupBox_Delay.ResumeLayout(false);
            this.groupBox_Delay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Off.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_On.Properties)).EndInit();
            this.groupBox_Buttons.ResumeLayout(false);
            this.groupBox_Buttons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_OnCMD;
        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.Label label_OnCMD;
        private System.Windows.Forms.Label label_EsdCMD;
        private System.Windows.Forms.Label label_OffCMD;
        private Utils.SpecialControls.ItemEditBox itemEditBox_EsdCMD;
        private Utils.SpecialControls.ItemEditBox itemEditBox_OffCMD;
        private System.Windows.Forms.GroupBox groupBox_Signals;
        private System.Windows.Forms.GroupBox groupBox_Delay;
        private System.Windows.Forms.Label label_OffMS;
        private System.Windows.Forms.Label label_OnMS;
        private System.Windows.Forms.Label label_Power;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Remote;
        private System.Windows.Forms.Label label_Remote;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Power;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Alarm;
        private System.Windows.Forms.Label label_Alarm;
        private Utils.SpecialControls.ItemEditBox itemEditBox_On;
        private Utils.SpecialControls.ItemEditBox itemEditBox_OnBtn;
        private Utils.SpecialControls.ItemEditBox itemEditBox_OffBtn;
        private System.Windows.Forms.Label label_On;
        private System.Windows.Forms.Label label_OffBtn;
        private System.Windows.Forms.GroupBox groupBox_Buttons;
        private System.Windows.Forms.Label label_OnBtn;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Off;
        private DevExpress.XtraEditors.SpinEdit spinEdit_On;
        private System.Windows.Forms.CheckBox checkBox_IgnoreCommands;
    }
}