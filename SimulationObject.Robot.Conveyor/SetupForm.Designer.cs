// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Robot.Conveyor
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
            this.checkBox_UseOneCommand = new System.Windows.Forms.CheckBox();
            this.itemEditBox_StopCMD = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_StartCMD = new Utils.SpecialControls.ItemEditBox();
            this.label_StopCMD = new System.Windows.Forms.Label();
            this.label_StartCMD = new System.Windows.Forms.Label();
            this.checkBox_IgnoreCommands = new System.Windows.Forms.CheckBox();
            this.groupBox_Time = new System.Windows.Forms.GroupBox();
            this.spinEdit_StopMS = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_StartMS = new DevExpress.XtraEditors.SpinEdit();
            this.label_StopMS = new System.Windows.Forms.Label();
            this.label_StartMS = new System.Windows.Forms.Label();
            this.groupBox_Signals = new System.Windows.Forms.GroupBox();
            this.itemEditBox_Backward = new Utils.SpecialControls.ItemEditBox();
            this.label_Backward = new System.Windows.Forms.Label();
            this.itemEditBox_Forward = new Utils.SpecialControls.ItemEditBox();
            this.label_Forward = new System.Windows.Forms.Label();
            this.textBox_SpeedMin = new System.Windows.Forms.TextBox();
            this.textBox_SpeedMax = new System.Windows.Forms.TextBox();
            this.label_SpeedMin = new System.Windows.Forms.Label();
            this.label_SpeedMax = new System.Windows.Forms.Label();
            this.label_Speed = new System.Windows.Forms.Label();
            this.itemEditBox_Speed = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Braking = new Utils.SpecialControls.ItemEditBox();
            this.label3 = new System.Windows.Forms.Label();
            this.itemEditBox_Acceleration = new Utils.SpecialControls.ItemEditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemEditBox_Reverse = new Utils.SpecialControls.ItemEditBox();
            this.label_Reverse = new System.Windows.Forms.Label();
            this.itemEditBox_Moving = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Alarm = new Utils.SpecialControls.ItemEditBox();
            this.label_Moving = new System.Windows.Forms.Label();
            this.label_Alarm = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.textBox_SpeedCMDMin = new System.Windows.Forms.TextBox();
            this.textBox_SpeedCMDMax = new System.Windows.Forms.TextBox();
            this.label_SpeedCMDMin = new System.Windows.Forms.Label();
            this.label_SpeedCMDMax = new System.Windows.Forms.Label();
            this.label_SpeedCMD = new System.Windows.Forms.Label();
            this.itemEditBox_SpeedCMD = new Utils.SpecialControls.ItemEditBox();
            this.groupBox_Control.SuspendLayout();
            this.groupBox_Time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_StopMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_StartMS.Properties)).BeginInit();
            this.groupBox_Signals.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.Controls.Add(this.textBox_SpeedCMDMin);
            this.groupBox_Control.Controls.Add(this.textBox_SpeedCMDMax);
            this.groupBox_Control.Controls.Add(this.label_SpeedCMDMin);
            this.groupBox_Control.Controls.Add(this.label_SpeedCMDMax);
            this.groupBox_Control.Controls.Add(this.label_SpeedCMD);
            this.groupBox_Control.Controls.Add(this.itemEditBox_SpeedCMD);
            this.groupBox_Control.Controls.Add(this.checkBox_UseOneCommand);
            this.groupBox_Control.Controls.Add(this.itemEditBox_StopCMD);
            this.groupBox_Control.Controls.Add(this.itemEditBox_StartCMD);
            this.groupBox_Control.Controls.Add(this.label_StopCMD);
            this.groupBox_Control.Controls.Add(this.label_StartCMD);
            this.groupBox_Control.Controls.Add(this.checkBox_IgnoreCommands);
            this.groupBox_Control.Location = new System.Drawing.Point(6, 3);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Size = new System.Drawing.Size(326, 223);
            this.groupBox_Control.TabIndex = 0;
            this.groupBox_Control.TabStop = false;
            this.groupBox_Control.Text = "Control";
            // 
            // checkBox_UseOneCommand
            // 
            this.checkBox_UseOneCommand.AutoSize = true;
            this.checkBox_UseOneCommand.Location = new System.Drawing.Point(71, 93);
            this.checkBox_UseOneCommand.Name = "checkBox_UseOneCommand";
            this.checkBox_UseOneCommand.Size = new System.Drawing.Size(153, 21);
            this.checkBox_UseOneCommand.TabIndex = 3;
            this.checkBox_UseOneCommand.Text = "Use One Command";
            this.checkBox_UseOneCommand.UseVisualStyleBackColor = true;
            // 
            // itemEditBox_StopCMD
            // 
            this.itemEditBox_StopCMD.ItemName = "";
            this.itemEditBox_StopCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_StopCMD.ItemToolTip = "";
            this.itemEditBox_StopCMD.Location = new System.Drawing.Point(71, 122);
            this.itemEditBox_StopCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_StopCMD.Name = "itemEditBox_StopCMD";
            this.itemEditBox_StopCMD.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_StopCMD.TabIndex = 4;
            this.itemEditBox_StopCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_StartCMD
            // 
            this.itemEditBox_StartCMD.ItemName = "";
            this.itemEditBox_StartCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_StartCMD.ItemToolTip = "";
            this.itemEditBox_StartCMD.Location = new System.Drawing.Point(71, 55);
            this.itemEditBox_StartCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_StartCMD.Name = "itemEditBox_StartCMD";
            this.itemEditBox_StartCMD.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_StartCMD.TabIndex = 2;
            this.itemEditBox_StartCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_StopCMD
            // 
            this.label_StopCMD.AutoSize = true;
            this.label_StopCMD.Location = new System.Drawing.Point(25, 129);
            this.label_StopCMD.Name = "label_StopCMD";
            this.label_StopCMD.Size = new System.Drawing.Size(41, 17);
            this.label_StopCMD.TabIndex = 28;
            this.label_StopCMD.Text = "Stop:";
            // 
            // label_StartCMD
            // 
            this.label_StartCMD.AutoSize = true;
            this.label_StartCMD.Location = new System.Drawing.Point(24, 62);
            this.label_StartCMD.Name = "label_StartCMD";
            this.label_StartCMD.Size = new System.Drawing.Size(42, 17);
            this.label_StartCMD.TabIndex = 25;
            this.label_StartCMD.Text = "Start:";
            // 
            // checkBox_IgnoreCommands
            // 
            this.checkBox_IgnoreCommands.AutoSize = true;
            this.checkBox_IgnoreCommands.Location = new System.Drawing.Point(10, 22);
            this.checkBox_IgnoreCommands.Name = "checkBox_IgnoreCommands";
            this.checkBox_IgnoreCommands.Size = new System.Drawing.Size(144, 21);
            this.checkBox_IgnoreCommands.TabIndex = 1;
            this.checkBox_IgnoreCommands.Text = "Ignore Commands";
            this.checkBox_IgnoreCommands.UseVisualStyleBackColor = true;
            // 
            // groupBox_Time
            // 
            this.groupBox_Time.Controls.Add(this.spinEdit_StopMS);
            this.groupBox_Time.Controls.Add(this.spinEdit_StartMS);
            this.groupBox_Time.Controls.Add(this.label_StopMS);
            this.groupBox_Time.Controls.Add(this.label_StartMS);
            this.groupBox_Time.Location = new System.Drawing.Point(6, 231);
            this.groupBox_Time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Time.Name = "groupBox_Time";
            this.groupBox_Time.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Time.Size = new System.Drawing.Size(326, 103);
            this.groupBox_Time.TabIndex = 1;
            this.groupBox_Time.TabStop = false;
            this.groupBox_Time.Text = "Time";
            // 
            // spinEdit_StopMS
            // 
            this.spinEdit_StopMS.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_StopMS.Location = new System.Drawing.Point(125, 61);
            this.spinEdit_StopMS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_StopMS.Name = "spinEdit_StopMS";
            this.spinEdit_StopMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_StopMS.Properties.IsFloatValue = false;
            this.spinEdit_StopMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_StopMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_StopMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_StopMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_StopMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_StopMS.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_StopMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_StopMS.TabIndex = 1;
            // 
            // spinEdit_StartMS
            // 
            this.spinEdit_StartMS.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_StartMS.Location = new System.Drawing.Point(125, 26);
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
            this.spinEdit_StartMS.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_StartMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_StartMS.TabIndex = 0;
            // 
            // label_StopMS
            // 
            this.label_StopMS.AutoSize = true;
            this.label_StopMS.Location = new System.Drawing.Point(43, 65);
            this.label_StopMS.Name = "label_StopMS";
            this.label_StopMS.Size = new System.Drawing.Size(71, 17);
            this.label_StopMS.TabIndex = 32;
            this.label_StopMS.Text = "Stop [ms]:";
            // 
            // label_StartMS
            // 
            this.label_StartMS.AutoSize = true;
            this.label_StartMS.Location = new System.Drawing.Point(42, 30);
            this.label_StartMS.Name = "label_StartMS";
            this.label_StartMS.Size = new System.Drawing.Size(72, 17);
            this.label_StartMS.TabIndex = 30;
            this.label_StartMS.Text = "Start [ms]:";
            // 
            // groupBox_Signals
            // 
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Backward);
            this.groupBox_Signals.Controls.Add(this.label_Backward);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Forward);
            this.groupBox_Signals.Controls.Add(this.label_Forward);
            this.groupBox_Signals.Controls.Add(this.textBox_SpeedMin);
            this.groupBox_Signals.Controls.Add(this.textBox_SpeedMax);
            this.groupBox_Signals.Controls.Add(this.label_SpeedMin);
            this.groupBox_Signals.Controls.Add(this.label_SpeedMax);
            this.groupBox_Signals.Controls.Add(this.label_Speed);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Speed);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Braking);
            this.groupBox_Signals.Controls.Add(this.label3);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Acceleration);
            this.groupBox_Signals.Controls.Add(this.label2);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Reverse);
            this.groupBox_Signals.Controls.Add(this.label_Reverse);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Moving);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Alarm);
            this.groupBox_Signals.Controls.Add(this.label_Moving);
            this.groupBox_Signals.Controls.Add(this.label_Alarm);
            this.groupBox_Signals.Location = new System.Drawing.Point(338, 3);
            this.groupBox_Signals.Name = "groupBox_Signals";
            this.groupBox_Signals.Size = new System.Drawing.Size(357, 331);
            this.groupBox_Signals.TabIndex = 2;
            this.groupBox_Signals.TabStop = false;
            this.groupBox_Signals.Text = "Signals";
            // 
            // itemEditBox_Backward
            // 
            this.itemEditBox_Backward.ItemName = "";
            this.itemEditBox_Backward.ItemRequirements = "Binary, Write";
            this.itemEditBox_Backward.ItemToolTip = "";
            this.itemEditBox_Backward.Location = new System.Drawing.Point(104, 224);
            this.itemEditBox_Backward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Backward.Name = "itemEditBox_Backward";
            this.itemEditBox_Backward.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Backward.TabIndex = 6;
            this.itemEditBox_Backward.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Backward
            // 
            this.label_Backward.AutoSize = true;
            this.label_Backward.Location = new System.Drawing.Point(25, 231);
            this.label_Backward.Name = "label_Backward";
            this.label_Backward.Size = new System.Drawing.Size(73, 17);
            this.label_Backward.TabIndex = 74;
            this.label_Backward.Text = "Backward:";
            // 
            // itemEditBox_Forward
            // 
            this.itemEditBox_Forward.ItemName = "";
            this.itemEditBox_Forward.ItemRequirements = "Binary, Write";
            this.itemEditBox_Forward.ItemToolTip = "";
            this.itemEditBox_Forward.Location = new System.Drawing.Point(104, 190);
            this.itemEditBox_Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Forward.Name = "itemEditBox_Forward";
            this.itemEditBox_Forward.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Forward.TabIndex = 5;
            this.itemEditBox_Forward.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Forward
            // 
            this.label_Forward.AutoSize = true;
            this.label_Forward.Location = new System.Drawing.Point(35, 197);
            this.label_Forward.Name = "label_Forward";
            this.label_Forward.Size = new System.Drawing.Size(63, 17);
            this.label_Forward.TabIndex = 72;
            this.label_Forward.Text = "Forward:";
            // 
            // textBox_SpeedMin
            // 
            this.textBox_SpeedMin.Location = new System.Drawing.Point(248, 293);
            this.textBox_SpeedMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_SpeedMin.Name = "textBox_SpeedMin";
            this.textBox_SpeedMin.Size = new System.Drawing.Size(89, 22);
            this.textBox_SpeedMin.TabIndex = 9;
            this.textBox_SpeedMin.Text = "0";
            // 
            // textBox_SpeedMax
            // 
            this.textBox_SpeedMax.Location = new System.Drawing.Point(105, 293);
            this.textBox_SpeedMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_SpeedMax.Name = "textBox_SpeedMax";
            this.textBox_SpeedMax.Size = new System.Drawing.Size(89, 22);
            this.textBox_SpeedMax.TabIndex = 8;
            this.textBox_SpeedMax.Text = "27648";
            // 
            // label_SpeedMin
            // 
            this.label_SpeedMin.AutoSize = true;
            this.label_SpeedMin.Location = new System.Drawing.Point(208, 296);
            this.label_SpeedMin.Name = "label_SpeedMin";
            this.label_SpeedMin.Size = new System.Drawing.Size(34, 17);
            this.label_SpeedMin.TabIndex = 70;
            this.label_SpeedMin.Text = "Min:";
            // 
            // label_SpeedMax
            // 
            this.label_SpeedMax.AutoSize = true;
            this.label_SpeedMax.Location = new System.Drawing.Point(61, 296);
            this.label_SpeedMax.Name = "label_SpeedMax";
            this.label_SpeedMax.Size = new System.Drawing.Size(37, 17);
            this.label_SpeedMax.TabIndex = 69;
            this.label_SpeedMax.Text = "Max:";
            // 
            // label_Speed
            // 
            this.label_Speed.AutoSize = true;
            this.label_Speed.Location = new System.Drawing.Point(45, 265);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(53, 17);
            this.label_Speed.TabIndex = 68;
            this.label_Speed.Text = "Speed:";
            // 
            // itemEditBox_Speed
            // 
            this.itemEditBox_Speed.ItemName = "";
            this.itemEditBox_Speed.ItemRequirements = "Real, Write";
            this.itemEditBox_Speed.ItemToolTip = "";
            this.itemEditBox_Speed.Location = new System.Drawing.Point(104, 258);
            this.itemEditBox_Speed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Speed.Name = "itemEditBox_Speed";
            this.itemEditBox_Speed.Size = new System.Drawing.Size(244, 30);
            this.itemEditBox_Speed.TabIndex = 7;
            this.itemEditBox_Speed.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Braking
            // 
            this.itemEditBox_Braking.ItemName = "";
            this.itemEditBox_Braking.ItemRequirements = "Binary, Write";
            this.itemEditBox_Braking.ItemToolTip = "";
            this.itemEditBox_Braking.Location = new System.Drawing.Point(104, 156);
            this.itemEditBox_Braking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Braking.Name = "itemEditBox_Braking";
            this.itemEditBox_Braking.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Braking.TabIndex = 4;
            this.itemEditBox_Braking.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 64;
            this.label3.Text = "Braking:";
            // 
            // itemEditBox_Acceleration
            // 
            this.itemEditBox_Acceleration.ItemName = "";
            this.itemEditBox_Acceleration.ItemRequirements = "Binary, Write";
            this.itemEditBox_Acceleration.ItemToolTip = "";
            this.itemEditBox_Acceleration.Location = new System.Drawing.Point(104, 122);
            this.itemEditBox_Acceleration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Acceleration.Name = "itemEditBox_Acceleration";
            this.itemEditBox_Acceleration.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Acceleration.TabIndex = 3;
            this.itemEditBox_Acceleration.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 62;
            this.label2.Text = "Acceleration:";
            // 
            // itemEditBox_Reverse
            // 
            this.itemEditBox_Reverse.ItemName = "";
            this.itemEditBox_Reverse.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Reverse.ItemToolTip = "";
            this.itemEditBox_Reverse.Location = new System.Drawing.Point(104, 88);
            this.itemEditBox_Reverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Reverse.Name = "itemEditBox_Reverse";
            this.itemEditBox_Reverse.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Reverse.TabIndex = 2;
            this.itemEditBox_Reverse.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Reverse
            // 
            this.label_Reverse.AutoSize = true;
            this.label_Reverse.Location = new System.Drawing.Point(33, 95);
            this.label_Reverse.Name = "label_Reverse";
            this.label_Reverse.Size = new System.Drawing.Size(65, 17);
            this.label_Reverse.TabIndex = 60;
            this.label_Reverse.Text = "Reverse:";
            // 
            // itemEditBox_Moving
            // 
            this.itemEditBox_Moving.ItemName = "";
            this.itemEditBox_Moving.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Moving.ItemToolTip = "";
            this.itemEditBox_Moving.Location = new System.Drawing.Point(104, 20);
            this.itemEditBox_Moving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Moving.Name = "itemEditBox_Moving";
            this.itemEditBox_Moving.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Moving.TabIndex = 0;
            this.itemEditBox_Moving.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Alarm
            // 
            this.itemEditBox_Alarm.ItemName = "";
            this.itemEditBox_Alarm.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Alarm.ItemToolTip = "";
            this.itemEditBox_Alarm.Location = new System.Drawing.Point(104, 54);
            this.itemEditBox_Alarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Alarm.Name = "itemEditBox_Alarm";
            this.itemEditBox_Alarm.Size = new System.Drawing.Size(245, 30);
            this.itemEditBox_Alarm.TabIndex = 1;
            this.itemEditBox_Alarm.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Moving
            // 
            this.label_Moving.AutoSize = true;
            this.label_Moving.Location = new System.Drawing.Point(41, 27);
            this.label_Moving.Name = "label_Moving";
            this.label_Moving.Size = new System.Drawing.Size(57, 17);
            this.label_Moving.TabIndex = 58;
            this.label_Moving.Text = "Moving:";
            // 
            // label_Alarm
            // 
            this.label_Alarm.AutoSize = true;
            this.label_Alarm.Location = new System.Drawing.Point(50, 61);
            this.label_Alarm.Name = "label_Alarm";
            this.label_Alarm.Size = new System.Drawing.Size(48, 17);
            this.label_Alarm.TabIndex = 57;
            this.label_Alarm.Text = "Alarm:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(256, 346);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 3;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // textBox_SpeedCMDMin
            // 
            this.textBox_SpeedCMDMin.Location = new System.Drawing.Point(215, 191);
            this.textBox_SpeedCMDMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_SpeedCMDMin.Name = "textBox_SpeedCMDMin";
            this.textBox_SpeedCMDMin.Size = new System.Drawing.Size(89, 22);
            this.textBox_SpeedCMDMin.TabIndex = 7;
            this.textBox_SpeedCMDMin.Text = "0";
            // 
            // textBox_SpeedCMDMax
            // 
            this.textBox_SpeedCMDMax.Location = new System.Drawing.Point(71, 191);
            this.textBox_SpeedCMDMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_SpeedCMDMax.Name = "textBox_SpeedCMDMax";
            this.textBox_SpeedCMDMax.Size = new System.Drawing.Size(89, 22);
            this.textBox_SpeedCMDMax.TabIndex = 6;
            this.textBox_SpeedCMDMax.Text = "27648";
            // 
            // label_SpeedCMDMin
            // 
            this.label_SpeedCMDMin.AutoSize = true;
            this.label_SpeedCMDMin.Location = new System.Drawing.Point(175, 194);
            this.label_SpeedCMDMin.Name = "label_SpeedCMDMin";
            this.label_SpeedCMDMin.Size = new System.Drawing.Size(34, 17);
            this.label_SpeedCMDMin.TabIndex = 76;
            this.label_SpeedCMDMin.Text = "Min:";
            // 
            // label_SpeedCMDMax
            // 
            this.label_SpeedCMDMax.AutoSize = true;
            this.label_SpeedCMDMax.Location = new System.Drawing.Point(29, 194);
            this.label_SpeedCMDMax.Name = "label_SpeedCMDMax";
            this.label_SpeedCMDMax.Size = new System.Drawing.Size(37, 17);
            this.label_SpeedCMDMax.TabIndex = 75;
            this.label_SpeedCMDMax.Text = "Max:";
            // 
            // label_SpeedCMD
            // 
            this.label_SpeedCMD.AutoSize = true;
            this.label_SpeedCMD.Location = new System.Drawing.Point(13, 163);
            this.label_SpeedCMD.Name = "label_SpeedCMD";
            this.label_SpeedCMD.Size = new System.Drawing.Size(53, 17);
            this.label_SpeedCMD.TabIndex = 74;
            this.label_SpeedCMD.Text = "Speed:";
            // 
            // itemEditBox_SpeedCMD
            // 
            this.itemEditBox_SpeedCMD.ItemName = "";
            this.itemEditBox_SpeedCMD.ItemRequirements = "Real, Read";
            this.itemEditBox_SpeedCMD.ItemToolTip = "";
            this.itemEditBox_SpeedCMD.Location = new System.Drawing.Point(71, 156);
            this.itemEditBox_SpeedCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_SpeedCMD.Name = "itemEditBox_SpeedCMD";
            this.itemEditBox_SpeedCMD.Size = new System.Drawing.Size(244, 30);
            this.itemEditBox_SpeedCMD.TabIndex = 5;
            this.itemEditBox_SpeedCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 383);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Signals);
            this.Controls.Add(this.groupBox_Time);
            this.Controls.Add(this.groupBox_Control);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Robot.Conveyor";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            this.groupBox_Time.ResumeLayout(false);
            this.groupBox_Time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_StopMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_StartMS.Properties)).EndInit();
            this.groupBox_Signals.ResumeLayout(false);
            this.groupBox_Signals.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.CheckBox checkBox_IgnoreCommands;
        private System.Windows.Forms.CheckBox checkBox_UseOneCommand;
        private Utils.SpecialControls.ItemEditBox itemEditBox_StopCMD;
        private Utils.SpecialControls.ItemEditBox itemEditBox_StartCMD;
        private System.Windows.Forms.Label label_StopCMD;
        private System.Windows.Forms.Label label_StartCMD;
        private System.Windows.Forms.GroupBox groupBox_Time;
        private DevExpress.XtraEditors.SpinEdit spinEdit_StopMS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_StartMS;
        private System.Windows.Forms.Label label_StopMS;
        private System.Windows.Forms.Label label_StartMS;
        private System.Windows.Forms.GroupBox groupBox_Signals;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Moving;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Alarm;
        private System.Windows.Forms.Label label_Moving;
        private System.Windows.Forms.Label label_Alarm;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Braking;
        private System.Windows.Forms.Label label3;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Acceleration;
        private System.Windows.Forms.Label label2;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Reverse;
        private System.Windows.Forms.Label label_Reverse;
        private System.Windows.Forms.TextBox textBox_SpeedMin;
        private System.Windows.Forms.TextBox textBox_SpeedMax;
        private System.Windows.Forms.Label label_SpeedMin;
        private System.Windows.Forms.Label label_SpeedMax;
        private System.Windows.Forms.Label label_Speed;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Speed;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Backward;
        private System.Windows.Forms.Label label_Backward;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Forward;
        private System.Windows.Forms.Label label_Forward;
        private System.Windows.Forms.TextBox textBox_SpeedCMDMin;
        private System.Windows.Forms.TextBox textBox_SpeedCMDMax;
        private System.Windows.Forms.Label label_SpeedCMDMin;
        private System.Windows.Forms.Label label_SpeedCMDMax;
        private System.Windows.Forms.Label label_SpeedCMD;
        private Utils.SpecialControls.ItemEditBox itemEditBox_SpeedCMD;
    }
}