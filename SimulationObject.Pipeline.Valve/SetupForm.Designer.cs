namespace SimulationObject.Pipeline.Valve
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
            this.checkBox_EsdOpen = new System.Windows.Forms.CheckBox();
            this.itemEditBox_EsdCMD = new Utils.SpecialControls.ItemEditBox();
            this.tabControl_Control = new System.Windows.Forms.TabControl();
            this.tabPage_Digital = new System.Windows.Forms.TabPage();
            this.checkBox_ImpCtrl = new System.Windows.Forms.CheckBox();
            this.itemEditBox_StopCMD = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_CloseCMD = new Utils.SpecialControls.ItemEditBox();
            this.label_StopCMD = new System.Windows.Forms.Label();
            this.itemEditBox_OpenCMD = new Utils.SpecialControls.ItemEditBox();
            this.label_CloseCMD = new System.Windows.Forms.Label();
            this.label_OpenCMD = new System.Windows.Forms.Label();
            this.tabPage_Analog = new System.Windows.Forms.TabPage();
            this.textBox_PositionCMDMin = new System.Windows.Forms.TextBox();
            this.textBox_PositionCMDMax = new System.Windows.Forms.TextBox();
            this.label_PosCMDMin = new System.Windows.Forms.Label();
            this.label_PosCMDMax = new System.Windows.Forms.Label();
            this.label_PositionCMD = new System.Windows.Forms.Label();
            this.itemEditBox_PositionCMD = new Utils.SpecialControls.ItemEditBox();
            this.label_EsdCMD = new System.Windows.Forms.Label();
            this.groupBox_Settings = new System.Windows.Forms.GroupBox();
            this.spinEdit_TravelMS = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_LimitMS = new DevExpress.XtraEditors.SpinEdit();
            this.label_TravelMS = new System.Windows.Forms.Label();
            this.label_LimitSwitchMS = new System.Windows.Forms.Label();
            this.groupBox_Signals = new System.Windows.Forms.GroupBox();
            this.itemEditBox_Rotation = new Utils.SpecialControls.ItemEditBox();
            this.label_Power = new System.Windows.Forms.Label();
            this.itemEditBox_Power = new Utils.SpecialControls.ItemEditBox();
            this.label_Remote = new System.Windows.Forms.Label();
            this.itemEditBox_Remote = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Alarm2 = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Alarm1 = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Closes = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Opens = new Utils.SpecialControls.ItemEditBox();
            this.label_Alarm2 = new System.Windows.Forms.Label();
            this.label_Alarm1 = new System.Windows.Forms.Label();
            this.label_Closes = new System.Windows.Forms.Label();
            this.label_Opens = new System.Windows.Forms.Label();
            this.textBox_PositionMin = new System.Windows.Forms.TextBox();
            this.textBox_PositionMax = new System.Windows.Forms.TextBox();
            this.label_PositionMin = new System.Windows.Forms.Label();
            this.label_PositionMax = new System.Windows.Forms.Label();
            this.itemEditBox_ClosedLimit = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_OpenLimit = new Utils.SpecialControls.ItemEditBox();
            this.label_Position = new System.Windows.Forms.Label();
            this.itemEditBox_Position = new Utils.SpecialControls.ItemEditBox();
            this.label_Closed = new System.Windows.Forms.Label();
            this.label_Open = new System.Windows.Forms.Label();
            this.label_Rotation = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_SpecModes = new System.Windows.Forms.GroupBox();
            this.textBox_FValue = new System.Windows.Forms.TextBox();
            this.checkBox_PositionF = new System.Windows.Forms.CheckBox();
            this.checkBox_ForceLimSwitches = new System.Windows.Forms.CheckBox();
            this.checkBox_IgnoreCommands = new System.Windows.Forms.CheckBox();
            this.groupBox_Control.SuspendLayout();
            this.tabControl_Control.SuspendLayout();
            this.tabPage_Digital.SuspendLayout();
            this.tabPage_Analog.SuspendLayout();
            this.groupBox_Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TravelMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LimitMS.Properties)).BeginInit();
            this.groupBox_Signals.SuspendLayout();
            this.groupBox_SpecModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Control
            // 
            this.groupBox_Control.Controls.Add(this.checkBox_EsdOpen);
            this.groupBox_Control.Controls.Add(this.itemEditBox_EsdCMD);
            this.groupBox_Control.Controls.Add(this.tabControl_Control);
            this.groupBox_Control.Controls.Add(this.label_EsdCMD);
            this.groupBox_Control.Location = new System.Drawing.Point(3, 2);
            this.groupBox_Control.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Control.Name = "groupBox_Control";
            this.groupBox_Control.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Control.Size = new System.Drawing.Size(365, 258);
            this.groupBox_Control.TabIndex = 0;
            this.groupBox_Control.TabStop = false;
            this.groupBox_Control.Text = "Control";
            // 
            // checkBox_EsdOpen
            // 
            this.checkBox_EsdOpen.AutoSize = true;
            this.checkBox_EsdOpen.Location = new System.Drawing.Point(85, 230);
            this.checkBox_EsdOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_EsdOpen.Name = "checkBox_EsdOpen";
            this.checkBox_EsdOpen.Size = new System.Drawing.Size(230, 21);
            this.checkBox_EsdOpen.TabIndex = 2;
            this.checkBox_EsdOpen.Text = "Open on ESD (otherwise Close)";
            this.checkBox_EsdOpen.UseVisualStyleBackColor = true;
            // 
            // itemEditBox_EsdCMD
            // 
            this.itemEditBox_EsdCMD.ItemName = "";
            this.itemEditBox_EsdCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_EsdCMD.ItemToolTip = "";
            this.itemEditBox_EsdCMD.Location = new System.Drawing.Point(85, 195);
            this.itemEditBox_EsdCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_EsdCMD.Name = "itemEditBox_EsdCMD";
            this.itemEditBox_EsdCMD.Size = new System.Drawing.Size(267, 30);
            this.itemEditBox_EsdCMD.TabIndex = 1;
            this.itemEditBox_EsdCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // tabControl_Control
            // 
            this.tabControl_Control.Controls.Add(this.tabPage_Digital);
            this.tabControl_Control.Controls.Add(this.tabPage_Analog);
            this.tabControl_Control.Location = new System.Drawing.Point(9, 20);
            this.tabControl_Control.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl_Control.Name = "tabControl_Control";
            this.tabControl_Control.SelectedIndex = 0;
            this.tabControl_Control.Size = new System.Drawing.Size(351, 167);
            this.tabControl_Control.TabIndex = 0;
            // 
            // tabPage_Digital
            // 
            this.tabPage_Digital.Controls.Add(this.checkBox_ImpCtrl);
            this.tabPage_Digital.Controls.Add(this.itemEditBox_StopCMD);
            this.tabPage_Digital.Controls.Add(this.itemEditBox_CloseCMD);
            this.tabPage_Digital.Controls.Add(this.label_StopCMD);
            this.tabPage_Digital.Controls.Add(this.itemEditBox_OpenCMD);
            this.tabPage_Digital.Controls.Add(this.label_CloseCMD);
            this.tabPage_Digital.Controls.Add(this.label_OpenCMD);
            this.tabPage_Digital.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Digital.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Digital.Name = "tabPage_Digital";
            this.tabPage_Digital.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Digital.Size = new System.Drawing.Size(343, 138);
            this.tabPage_Digital.TabIndex = 0;
            this.tabPage_Digital.Text = "Digital";
            this.tabPage_Digital.UseVisualStyleBackColor = true;
            // 
            // checkBox_ImpCtrl
            // 
            this.checkBox_ImpCtrl.AutoSize = true;
            this.checkBox_ImpCtrl.Location = new System.Drawing.Point(71, 110);
            this.checkBox_ImpCtrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_ImpCtrl.Name = "checkBox_ImpCtrl";
            this.checkBox_ImpCtrl.Size = new System.Drawing.Size(254, 21);
            this.checkBox_ImpCtrl.TabIndex = 3;
            this.checkBox_ImpCtrl.Text = "Impulse control (Open, Close, Stop)";
            this.checkBox_ImpCtrl.UseVisualStyleBackColor = true;
            // 
            // itemEditBox_StopCMD
            // 
            this.itemEditBox_StopCMD.ItemName = "";
            this.itemEditBox_StopCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_StopCMD.ItemToolTip = "";
            this.itemEditBox_StopCMD.Location = new System.Drawing.Point(71, 74);
            this.itemEditBox_StopCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_StopCMD.Name = "itemEditBox_StopCMD";
            this.itemEditBox_StopCMD.Size = new System.Drawing.Size(267, 30);
            this.itemEditBox_StopCMD.TabIndex = 2;
            this.itemEditBox_StopCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_CloseCMD
            // 
            this.itemEditBox_CloseCMD.ItemName = "";
            this.itemEditBox_CloseCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_CloseCMD.ItemToolTip = "";
            this.itemEditBox_CloseCMD.Location = new System.Drawing.Point(71, 39);
            this.itemEditBox_CloseCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_CloseCMD.Name = "itemEditBox_CloseCMD";
            this.itemEditBox_CloseCMD.Size = new System.Drawing.Size(267, 30);
            this.itemEditBox_CloseCMD.TabIndex = 1;
            this.itemEditBox_CloseCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_StopCMD
            // 
            this.label_StopCMD.AutoSize = true;
            this.label_StopCMD.Location = new System.Drawing.Point(24, 81);
            this.label_StopCMD.Name = "label_StopCMD";
            this.label_StopCMD.Size = new System.Drawing.Size(41, 17);
            this.label_StopCMD.TabIndex = 2;
            this.label_StopCMD.Text = "Stop:";
            // 
            // itemEditBox_OpenCMD
            // 
            this.itemEditBox_OpenCMD.ItemName = "";
            this.itemEditBox_OpenCMD.ItemRequirements = "Binary, Read";
            this.itemEditBox_OpenCMD.ItemToolTip = "";
            this.itemEditBox_OpenCMD.Location = new System.Drawing.Point(71, 5);
            this.itemEditBox_OpenCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_OpenCMD.Name = "itemEditBox_OpenCMD";
            this.itemEditBox_OpenCMD.Size = new System.Drawing.Size(267, 30);
            this.itemEditBox_OpenCMD.TabIndex = 0;
            this.itemEditBox_OpenCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_CloseCMD
            // 
            this.label_CloseCMD.AutoSize = true;
            this.label_CloseCMD.Location = new System.Drawing.Point(19, 47);
            this.label_CloseCMD.Name = "label_CloseCMD";
            this.label_CloseCMD.Size = new System.Drawing.Size(47, 17);
            this.label_CloseCMD.TabIndex = 1;
            this.label_CloseCMD.Text = "Close:";
            // 
            // label_OpenCMD
            // 
            this.label_OpenCMD.AutoSize = true;
            this.label_OpenCMD.Location = new System.Drawing.Point(19, 12);
            this.label_OpenCMD.Name = "label_OpenCMD";
            this.label_OpenCMD.Size = new System.Drawing.Size(47, 17);
            this.label_OpenCMD.TabIndex = 0;
            this.label_OpenCMD.Text = "Open:";
            // 
            // tabPage_Analog
            // 
            this.tabPage_Analog.Controls.Add(this.textBox_PositionCMDMin);
            this.tabPage_Analog.Controls.Add(this.textBox_PositionCMDMax);
            this.tabPage_Analog.Controls.Add(this.label_PosCMDMin);
            this.tabPage_Analog.Controls.Add(this.label_PosCMDMax);
            this.tabPage_Analog.Controls.Add(this.label_PositionCMD);
            this.tabPage_Analog.Controls.Add(this.itemEditBox_PositionCMD);
            this.tabPage_Analog.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Analog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Analog.Name = "tabPage_Analog";
            this.tabPage_Analog.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Analog.Size = new System.Drawing.Size(343, 138);
            this.tabPage_Analog.TabIndex = 1;
            this.tabPage_Analog.Text = "Analog";
            this.tabPage_Analog.UseVisualStyleBackColor = true;
            // 
            // textBox_PositionCMDMin
            // 
            this.textBox_PositionCMDMin.Location = new System.Drawing.Point(145, 96);
            this.textBox_PositionCMDMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PositionCMDMin.Name = "textBox_PositionCMDMin";
            this.textBox_PositionCMDMin.Size = new System.Drawing.Size(89, 22);
            this.textBox_PositionCMDMin.TabIndex = 2;
            this.textBox_PositionCMDMin.Text = "0";
            // 
            // textBox_PositionCMDMax
            // 
            this.textBox_PositionCMDMax.Location = new System.Drawing.Point(145, 63);
            this.textBox_PositionCMDMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PositionCMDMax.Name = "textBox_PositionCMDMax";
            this.textBox_PositionCMDMax.Size = new System.Drawing.Size(89, 22);
            this.textBox_PositionCMDMax.TabIndex = 1;
            this.textBox_PositionCMDMax.Text = "27648";
            // 
            // label_PosCMDMin
            // 
            this.label_PosCMDMin.AutoSize = true;
            this.label_PosCMDMin.Location = new System.Drawing.Point(109, 101);
            this.label_PosCMDMin.Name = "label_PosCMDMin";
            this.label_PosCMDMin.Size = new System.Drawing.Size(34, 17);
            this.label_PosCMDMin.TabIndex = 25;
            this.label_PosCMDMin.Text = "Min:";
            // 
            // label_PosCMDMax
            // 
            this.label_PosCMDMax.AutoSize = true;
            this.label_PosCMDMax.Location = new System.Drawing.Point(107, 68);
            this.label_PosCMDMax.Name = "label_PosCMDMax";
            this.label_PosCMDMax.Size = new System.Drawing.Size(37, 17);
            this.label_PosCMDMax.TabIndex = 24;
            this.label_PosCMDMax.Text = "Max:";
            // 
            // label_PositionCMD
            // 
            this.label_PositionCMD.AutoSize = true;
            this.label_PositionCMD.Location = new System.Drawing.Point(5, 28);
            this.label_PositionCMD.Name = "label_PositionCMD";
            this.label_PositionCMD.Size = new System.Drawing.Size(62, 17);
            this.label_PositionCMD.TabIndex = 23;
            this.label_PositionCMD.Text = "Position:";
            // 
            // itemEditBox_PositionCMD
            // 
            this.itemEditBox_PositionCMD.ItemName = "";
            this.itemEditBox_PositionCMD.ItemRequirements = "Real, Read";
            this.itemEditBox_PositionCMD.ItemToolTip = "";
            this.itemEditBox_PositionCMD.Location = new System.Drawing.Point(71, 21);
            this.itemEditBox_PositionCMD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_PositionCMD.Name = "itemEditBox_PositionCMD";
            this.itemEditBox_PositionCMD.Size = new System.Drawing.Size(267, 30);
            this.itemEditBox_PositionCMD.TabIndex = 0;
            this.itemEditBox_PositionCMD.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_EsdCMD
            // 
            this.label_EsdCMD.AutoSize = true;
            this.label_EsdCMD.Location = new System.Drawing.Point(39, 203);
            this.label_EsdCMD.Name = "label_EsdCMD";
            this.label_EsdCMD.Size = new System.Drawing.Size(40, 17);
            this.label_EsdCMD.TabIndex = 23;
            this.label_EsdCMD.Text = "ESD:";
            // 
            // groupBox_Settings
            // 
            this.groupBox_Settings.Controls.Add(this.spinEdit_TravelMS);
            this.groupBox_Settings.Controls.Add(this.spinEdit_LimitMS);
            this.groupBox_Settings.Controls.Add(this.label_TravelMS);
            this.groupBox_Settings.Controls.Add(this.label_LimitSwitchMS);
            this.groupBox_Settings.Location = new System.Drawing.Point(4, 264);
            this.groupBox_Settings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Settings.Name = "groupBox_Settings";
            this.groupBox_Settings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Settings.Size = new System.Drawing.Size(365, 79);
            this.groupBox_Settings.TabIndex = 1;
            this.groupBox_Settings.TabStop = false;
            this.groupBox_Settings.Text = "Settings";
            // 
            // spinEdit_TravelMS
            // 
            this.spinEdit_TravelMS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_TravelMS.Location = new System.Drawing.Point(179, 48);
            this.spinEdit_TravelMS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_TravelMS.Name = "spinEdit_TravelMS";
            this.spinEdit_TravelMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_TravelMS.Properties.IsFloatValue = false;
            this.spinEdit_TravelMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_TravelMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_TravelMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_TravelMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_TravelMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_TravelMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_TravelMS.TabIndex = 5;
            // 
            // spinEdit_LimitMS
            // 
            this.spinEdit_LimitMS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_LimitMS.Location = new System.Drawing.Point(179, 17);
            this.spinEdit_LimitMS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_LimitMS.Name = "spinEdit_LimitMS";
            this.spinEdit_LimitMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_LimitMS.Properties.IsFloatValue = false;
            this.spinEdit_LimitMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_LimitMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_LimitMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_LimitMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_LimitMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_LimitMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_LimitMS.TabIndex = 4;
            // 
            // label_TravelMS
            // 
            this.label_TravelMS.AutoSize = true;
            this.label_TravelMS.Location = new System.Drawing.Point(60, 53);
            this.label_TravelMS.Name = "label_TravelMS";
            this.label_TravelMS.Size = new System.Drawing.Size(112, 17);
            this.label_TravelMS.TabIndex = 1;
            this.label_TravelMS.Text = "Travel time [ms]:";
            // 
            // label_LimitSwitchMS
            // 
            this.label_LimitSwitchMS.AutoSize = true;
            this.label_LimitSwitchMS.Location = new System.Drawing.Point(28, 22);
            this.label_LimitSwitchMS.Name = "label_LimitSwitchMS";
            this.label_LimitSwitchMS.Size = new System.Drawing.Size(143, 17);
            this.label_LimitSwitchMS.TabIndex = 0;
            this.label_LimitSwitchMS.Text = "Limit switch time [ms]:";
            // 
            // groupBox_Signals
            // 
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Rotation);
            this.groupBox_Signals.Controls.Add(this.label_Power);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Power);
            this.groupBox_Signals.Controls.Add(this.label_Remote);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Remote);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Alarm2);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Alarm1);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Closes);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Opens);
            this.groupBox_Signals.Controls.Add(this.label_Alarm2);
            this.groupBox_Signals.Controls.Add(this.label_Alarm1);
            this.groupBox_Signals.Controls.Add(this.label_Closes);
            this.groupBox_Signals.Controls.Add(this.label_Opens);
            this.groupBox_Signals.Controls.Add(this.textBox_PositionMin);
            this.groupBox_Signals.Controls.Add(this.textBox_PositionMax);
            this.groupBox_Signals.Controls.Add(this.label_PositionMin);
            this.groupBox_Signals.Controls.Add(this.label_PositionMax);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_ClosedLimit);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_OpenLimit);
            this.groupBox_Signals.Controls.Add(this.label_Position);
            this.groupBox_Signals.Controls.Add(this.itemEditBox_Position);
            this.groupBox_Signals.Controls.Add(this.label_Closed);
            this.groupBox_Signals.Controls.Add(this.label_Open);
            this.groupBox_Signals.Controls.Add(this.label_Rotation);
            this.groupBox_Signals.Location = new System.Drawing.Point(375, 2);
            this.groupBox_Signals.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Signals.Name = "groupBox_Signals";
            this.groupBox_Signals.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Signals.Size = new System.Drawing.Size(365, 429);
            this.groupBox_Signals.TabIndex = 2;
            this.groupBox_Signals.TabStop = false;
            this.groupBox_Signals.Text = "Signals";
            // 
            // itemEditBox_Rotation
            // 
            this.itemEditBox_Rotation.ItemName = "";
            this.itemEditBox_Rotation.ItemRequirements = "Binary, Write";
            this.itemEditBox_Rotation.ItemToolTip = "";
            this.itemEditBox_Rotation.Location = new System.Drawing.Point(73, 161);
            this.itemEditBox_Rotation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Rotation.Name = "itemEditBox_Rotation";
            this.itemEditBox_Rotation.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Rotation.TabIndex = 5;
            this.itemEditBox_Rotation.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Power
            // 
            this.label_Power.AutoSize = true;
            this.label_Power.Location = new System.Drawing.Point(17, 358);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(51, 17);
            this.label_Power.TabIndex = 43;
            this.label_Power.Text = "Power:";
            // 
            // itemEditBox_Power
            // 
            this.itemEditBox_Power.ItemName = "";
            this.itemEditBox_Power.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Power.ItemToolTip = "";
            this.itemEditBox_Power.Location = new System.Drawing.Point(73, 351);
            this.itemEditBox_Power.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Power.Name = "itemEditBox_Power";
            this.itemEditBox_Power.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Power.TabIndex = 10;
            this.itemEditBox_Power.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Remote
            // 
            this.label_Remote.AutoSize = true;
            this.label_Remote.Location = new System.Drawing.Point(8, 396);
            this.label_Remote.Name = "label_Remote";
            this.label_Remote.Size = new System.Drawing.Size(61, 17);
            this.label_Remote.TabIndex = 41;
            this.label_Remote.Text = "Remote:";
            // 
            // itemEditBox_Remote
            // 
            this.itemEditBox_Remote.ItemName = "";
            this.itemEditBox_Remote.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Remote.ItemToolTip = "";
            this.itemEditBox_Remote.Location = new System.Drawing.Point(73, 389);
            this.itemEditBox_Remote.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Remote.Name = "itemEditBox_Remote";
            this.itemEditBox_Remote.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Remote.TabIndex = 11;
            this.itemEditBox_Remote.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Alarm2
            // 
            this.itemEditBox_Alarm2.ItemName = "";
            this.itemEditBox_Alarm2.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Alarm2.ItemToolTip = "";
            this.itemEditBox_Alarm2.Location = new System.Drawing.Point(73, 313);
            this.itemEditBox_Alarm2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Alarm2.Name = "itemEditBox_Alarm2";
            this.itemEditBox_Alarm2.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Alarm2.TabIndex = 9;
            this.itemEditBox_Alarm2.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Alarm1
            // 
            this.itemEditBox_Alarm1.ItemName = "";
            this.itemEditBox_Alarm1.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_Alarm1.ItemToolTip = "";
            this.itemEditBox_Alarm1.Location = new System.Drawing.Point(73, 275);
            this.itemEditBox_Alarm1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Alarm1.Name = "itemEditBox_Alarm1";
            this.itemEditBox_Alarm1.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Alarm1.TabIndex = 8;
            this.itemEditBox_Alarm1.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Closes
            // 
            this.itemEditBox_Closes.ItemName = "";
            this.itemEditBox_Closes.ItemRequirements = "Binary, Write";
            this.itemEditBox_Closes.ItemToolTip = "";
            this.itemEditBox_Closes.Location = new System.Drawing.Point(73, 237);
            this.itemEditBox_Closes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Closes.Name = "itemEditBox_Closes";
            this.itemEditBox_Closes.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Closes.TabIndex = 7;
            this.itemEditBox_Closes.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Opens
            // 
            this.itemEditBox_Opens.ItemName = "";
            this.itemEditBox_Opens.ItemRequirements = "Binary, Write";
            this.itemEditBox_Opens.ItemToolTip = "";
            this.itemEditBox_Opens.Location = new System.Drawing.Point(73, 199);
            this.itemEditBox_Opens.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Opens.Name = "itemEditBox_Opens";
            this.itemEditBox_Opens.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Opens.TabIndex = 6;
            this.itemEditBox_Opens.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Alarm2
            // 
            this.label_Alarm2.AutoSize = true;
            this.label_Alarm2.Location = new System.Drawing.Point(15, 320);
            this.label_Alarm2.Name = "label_Alarm2";
            this.label_Alarm2.Size = new System.Drawing.Size(56, 17);
            this.label_Alarm2.TabIndex = 35;
            this.label_Alarm2.Text = "Alarm2:";
            // 
            // label_Alarm1
            // 
            this.label_Alarm1.AutoSize = true;
            this.label_Alarm1.Location = new System.Drawing.Point(15, 282);
            this.label_Alarm1.Name = "label_Alarm1";
            this.label_Alarm1.Size = new System.Drawing.Size(56, 17);
            this.label_Alarm1.TabIndex = 34;
            this.label_Alarm1.Text = "Alarm1:";
            // 
            // label_Closes
            // 
            this.label_Closes.AutoSize = true;
            this.label_Closes.Location = new System.Drawing.Point(16, 244);
            this.label_Closes.Name = "label_Closes";
            this.label_Closes.Size = new System.Drawing.Size(54, 17);
            this.label_Closes.TabIndex = 33;
            this.label_Closes.Text = "Closes:";
            // 
            // label_Opens
            // 
            this.label_Opens.AutoSize = true;
            this.label_Opens.Location = new System.Drawing.Point(16, 206);
            this.label_Opens.Name = "label_Opens";
            this.label_Opens.Size = new System.Drawing.Size(54, 17);
            this.label_Opens.TabIndex = 32;
            this.label_Opens.Text = "Opens:";
            // 
            // textBox_PositionMin
            // 
            this.textBox_PositionMin.Location = new System.Drawing.Point(231, 131);
            this.textBox_PositionMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PositionMin.Name = "textBox_PositionMin";
            this.textBox_PositionMin.Size = new System.Drawing.Size(89, 22);
            this.textBox_PositionMin.TabIndex = 4;
            this.textBox_PositionMin.Text = "0";
            // 
            // textBox_PositionMax
            // 
            this.textBox_PositionMax.Location = new System.Drawing.Point(88, 131);
            this.textBox_PositionMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PositionMax.Name = "textBox_PositionMax";
            this.textBox_PositionMax.Size = new System.Drawing.Size(89, 22);
            this.textBox_PositionMax.TabIndex = 3;
            this.textBox_PositionMax.Text = "27648";
            // 
            // label_PositionMin
            // 
            this.label_PositionMin.AutoSize = true;
            this.label_PositionMin.Location = new System.Drawing.Point(191, 134);
            this.label_PositionMin.Name = "label_PositionMin";
            this.label_PositionMin.Size = new System.Drawing.Size(34, 17);
            this.label_PositionMin.TabIndex = 29;
            this.label_PositionMin.Text = "Min:";
            // 
            // label_PositionMax
            // 
            this.label_PositionMax.AutoSize = true;
            this.label_PositionMax.Location = new System.Drawing.Point(44, 134);
            this.label_PositionMax.Name = "label_PositionMax";
            this.label_PositionMax.Size = new System.Drawing.Size(37, 17);
            this.label_PositionMax.TabIndex = 28;
            this.label_PositionMax.Text = "Max:";
            // 
            // itemEditBox_ClosedLimit
            // 
            this.itemEditBox_ClosedLimit.ItemName = "";
            this.itemEditBox_ClosedLimit.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_ClosedLimit.ItemToolTip = "";
            this.itemEditBox_ClosedLimit.Location = new System.Drawing.Point(73, 55);
            this.itemEditBox_ClosedLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_ClosedLimit.Name = "itemEditBox_ClosedLimit";
            this.itemEditBox_ClosedLimit.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_ClosedLimit.TabIndex = 1;
            this.itemEditBox_ClosedLimit.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_OpenLimit
            // 
            this.itemEditBox_OpenLimit.ItemName = "";
            this.itemEditBox_OpenLimit.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_OpenLimit.ItemToolTip = "";
            this.itemEditBox_OpenLimit.Location = new System.Drawing.Point(73, 17);
            this.itemEditBox_OpenLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_OpenLimit.Name = "itemEditBox_OpenLimit";
            this.itemEditBox_OpenLimit.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_OpenLimit.TabIndex = 0;
            this.itemEditBox_OpenLimit.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Position
            // 
            this.label_Position.AutoSize = true;
            this.label_Position.Location = new System.Drawing.Point(8, 100);
            this.label_Position.Name = "label_Position";
            this.label_Position.Size = new System.Drawing.Size(62, 17);
            this.label_Position.TabIndex = 4;
            this.label_Position.Text = "Position:";
            // 
            // itemEditBox_Position
            // 
            this.itemEditBox_Position.ItemName = "";
            this.itemEditBox_Position.ItemRequirements = "Real, Write";
            this.itemEditBox_Position.ItemToolTip = "";
            this.itemEditBox_Position.Location = new System.Drawing.Point(73, 93);
            this.itemEditBox_Position.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Position.Name = "itemEditBox_Position";
            this.itemEditBox_Position.Size = new System.Drawing.Size(287, 30);
            this.itemEditBox_Position.TabIndex = 2;
            this.itemEditBox_Position.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Closed
            // 
            this.label_Closed.AutoSize = true;
            this.label_Closed.Location = new System.Drawing.Point(15, 62);
            this.label_Closed.Name = "label_Closed";
            this.label_Closed.Size = new System.Drawing.Size(55, 17);
            this.label_Closed.TabIndex = 2;
            this.label_Closed.Text = "Closed:";
            // 
            // label_Open
            // 
            this.label_Open.AutoSize = true;
            this.label_Open.Location = new System.Drawing.Point(23, 24);
            this.label_Open.Name = "label_Open";
            this.label_Open.Size = new System.Drawing.Size(47, 17);
            this.label_Open.TabIndex = 1;
            this.label_Open.Text = "Open:";
            // 
            // label_Rotation
            // 
            this.label_Rotation.AutoSize = true;
            this.label_Rotation.Location = new System.Drawing.Point(4, 168);
            this.label_Rotation.Name = "label_Rotation";
            this.label_Rotation.Size = new System.Drawing.Size(65, 17);
            this.label_Rotation.TabIndex = 44;
            this.label_Rotation.Text = "Rotation:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(279, 436);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 3;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // groupBox_SpecModes
            // 
            this.groupBox_SpecModes.Controls.Add(this.textBox_FValue);
            this.groupBox_SpecModes.Controls.Add(this.checkBox_PositionF);
            this.groupBox_SpecModes.Controls.Add(this.checkBox_ForceLimSwitches);
            this.groupBox_SpecModes.Controls.Add(this.checkBox_IgnoreCommands);
            this.groupBox_SpecModes.Location = new System.Drawing.Point(3, 348);
            this.groupBox_SpecModes.Name = "groupBox_SpecModes";
            this.groupBox_SpecModes.Size = new System.Drawing.Size(365, 83);
            this.groupBox_SpecModes.TabIndex = 4;
            this.groupBox_SpecModes.TabStop = false;
            this.groupBox_SpecModes.Text = "Special modes";
            // 
            // textBox_FValue
            // 
            this.textBox_FValue.Location = new System.Drawing.Point(139, 48);
            this.textBox_FValue.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_FValue.Name = "textBox_FValue";
            this.textBox_FValue.Size = new System.Drawing.Size(152, 22);
            this.textBox_FValue.TabIndex = 47;
            this.textBox_FValue.Text = "32767";
            // 
            // checkBox_PositionF
            // 
            this.checkBox_PositionF.AutoSize = true;
            this.checkBox_PositionF.Location = new System.Drawing.Point(13, 49);
            this.checkBox_PositionF.Name = "checkBox_PositionF";
            this.checkBox_PositionF.Size = new System.Drawing.Size(115, 21);
            this.checkBox_PositionF.TabIndex = 45;
            this.checkBox_PositionF.Text = "Position fault:";
            this.checkBox_PositionF.UseVisualStyleBackColor = true;
            // 
            // checkBox_ForceLimSwitches
            // 
            this.checkBox_ForceLimSwitches.AutoSize = true;
            this.checkBox_ForceLimSwitches.Location = new System.Drawing.Point(200, 22);
            this.checkBox_ForceLimSwitches.Name = "checkBox_ForceLimSwitches";
            this.checkBox_ForceLimSwitches.Size = new System.Drawing.Size(151, 21);
            this.checkBox_ForceLimSwitches.TabIndex = 1;
            this.checkBox_ForceLimSwitches.Text = "Force limit switches";
            this.checkBox_ForceLimSwitches.UseVisualStyleBackColor = true;
            // 
            // checkBox_IgnoreCommands
            // 
            this.checkBox_IgnoreCommands.AutoSize = true;
            this.checkBox_IgnoreCommands.Location = new System.Drawing.Point(13, 22);
            this.checkBox_IgnoreCommands.Name = "checkBox_IgnoreCommands";
            this.checkBox_IgnoreCommands.Size = new System.Drawing.Size(142, 21);
            this.checkBox_IgnoreCommands.TabIndex = 0;
            this.checkBox_IgnoreCommands.Text = "Ignore commands";
            this.checkBox_IgnoreCommands.UseVisualStyleBackColor = true;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 474);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_SpecModes);
            this.Controls.Add(this.groupBox_Signals);
            this.Controls.Add(this.groupBox_Settings);
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
            this.Text = "Pipeline.Valve";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox_Control.ResumeLayout(false);
            this.groupBox_Control.PerformLayout();
            this.tabControl_Control.ResumeLayout(false);
            this.tabPage_Digital.ResumeLayout(false);
            this.tabPage_Digital.PerformLayout();
            this.tabPage_Analog.ResumeLayout(false);
            this.tabPage_Analog.PerformLayout();
            this.groupBox_Settings.ResumeLayout(false);
            this.groupBox_Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_TravelMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LimitMS.Properties)).EndInit();
            this.groupBox_Signals.ResumeLayout(false);
            this.groupBox_Signals.PerformLayout();
            this.groupBox_SpecModes.ResumeLayout(false);
            this.groupBox_SpecModes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_OpenCMD;
        private System.Windows.Forms.GroupBox groupBox_Control;
        private System.Windows.Forms.CheckBox checkBox_EsdOpen;
        private System.Windows.Forms.Label label_EsdCMD;
        private Utils.SpecialControls.ItemEditBox itemEditBox_EsdCMD;
        private System.Windows.Forms.TabControl tabControl_Control;
        private System.Windows.Forms.TabPage tabPage_Digital;
        private System.Windows.Forms.CheckBox checkBox_ImpCtrl;
        private Utils.SpecialControls.ItemEditBox itemEditBox_StopCMD;
        private Utils.SpecialControls.ItemEditBox itemEditBox_CloseCMD;
        private System.Windows.Forms.Label label_StopCMD;
        private System.Windows.Forms.Label label_CloseCMD;
        private System.Windows.Forms.Label label_OpenCMD;
        private System.Windows.Forms.TabPage tabPage_Analog;
        private Utils.SpecialControls.ItemEditBox itemEditBox_PositionCMD;
        private System.Windows.Forms.Label label_PositionCMD;
        private System.Windows.Forms.Label label_PosCMDMin;
        private System.Windows.Forms.Label label_PosCMDMax;
        private System.Windows.Forms.GroupBox groupBox_Settings;
        private System.Windows.Forms.GroupBox groupBox_Signals;
        private System.Windows.Forms.TextBox textBox_PositionCMDMax;
        private System.Windows.Forms.TextBox textBox_PositionCMDMin;
        private System.Windows.Forms.Label label_LimitSwitchMS;
        private System.Windows.Forms.Label label_TravelMS;
        private System.Windows.Forms.Label label_Closed;
        private System.Windows.Forms.Label label_Open;
        private Utils.SpecialControls.ItemEditBox itemEditBox_ClosedLimit;
        private Utils.SpecialControls.ItemEditBox itemEditBox_OpenLimit;
        private System.Windows.Forms.Label label_Position;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Position;
        private System.Windows.Forms.TextBox textBox_PositionMin;
        private System.Windows.Forms.TextBox textBox_PositionMax;
        private System.Windows.Forms.Label label_PositionMin;
        private System.Windows.Forms.Label label_PositionMax;
        private System.Windows.Forms.Label label_Remote;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Remote;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Alarm2;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Alarm1;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Closes;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Opens;
        private System.Windows.Forms.Label label_Alarm2;
        private System.Windows.Forms.Label label_Alarm1;
        private System.Windows.Forms.Label label_Closes;
        private System.Windows.Forms.Label label_Opens;
        private System.Windows.Forms.Label label_Power;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Power;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Rotation;
        private System.Windows.Forms.Label label_Rotation;
        private DevExpress.XtraEditors.SpinEdit spinEdit_TravelMS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_LimitMS;
        private System.Windows.Forms.GroupBox groupBox_SpecModes;
        private System.Windows.Forms.CheckBox checkBox_ForceLimSwitches;
        private System.Windows.Forms.CheckBox checkBox_IgnoreCommands;
        private System.Windows.Forms.CheckBox checkBox_PositionF;
        private System.Windows.Forms.TextBox textBox_FValue;
    }
}