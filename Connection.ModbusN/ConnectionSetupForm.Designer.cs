// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.ModbusN
{
    partial class ConnectionSetupForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox_Items = new System.Windows.Forms.GroupBox();
            this.label_CountN = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.label_WriteRequests = new System.Windows.Forms.Label();
            this.label_WR = new System.Windows.Forms.Label();
            this.spinEdit_Errors = new DevExpress.XtraEditors.SpinEdit();
            this.label_Errors = new System.Windows.Forms.Label();
            this.spinEdit_Timeout = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Pause = new DevExpress.XtraEditors.SpinEdit();
            this.label_Pause = new System.Windows.Forms.Label();
            this.label_CycleTime = new System.Windows.Forms.Label();
            this.label_CTime = new System.Windows.Forms.Label();
            this.label_Timeout = new System.Windows.Forms.Label();
            this.groupBox_Ethernet = new System.Windows.Forms.GroupBox();
            this.spinEdit_Port = new DevExpress.XtraEditors.SpinEdit();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_IP = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.groupBox_Serial = new System.Windows.Forms.GroupBox();
            this.groupBox_StopBits = new System.Windows.Forms.GroupBox();
            this.radioButton_2 = new System.Windows.Forms.RadioButton();
            this.radioButton_1 = new System.Windows.Forms.RadioButton();
            this.radioButton_1_5 = new System.Windows.Forms.RadioButton();
            this.groupBox_Parity = new System.Windows.Forms.GroupBox();
            this.radioButton_S = new System.Windows.Forms.RadioButton();
            this.radioButton_M = new System.Windows.Forms.RadioButton();
            this.radioButton_E = new System.Windows.Forms.RadioButton();
            this.radioButton_N = new System.Windows.Forms.RadioButton();
            this.radioButton_O = new System.Windows.Forms.RadioButton();
            this.label_Parity = new System.Windows.Forms.Label();
            this.label_StopBits = new System.Windows.Forms.Label();
            this.groupBox_DataBits = new System.Windows.Forms.GroupBox();
            this.radioButton_6 = new System.Windows.Forms.RadioButton();
            this.radioButton_5 = new System.Windows.Forms.RadioButton();
            this.radioButton_8 = new System.Windows.Forms.RadioButton();
            this.radioButton_7 = new System.Windows.Forms.RadioButton();
            this.comboBox_Baud = new System.Windows.Forms.ComboBox();
            this.comboBox_COMPort = new System.Windows.Forms.ComboBox();
            this.label_DataBits = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_COMPort = new System.Windows.Forms.Label();
            this.groupBox_Protocol = new System.Windows.Forms.GroupBox();
            this.radioButton_ASCII = new System.Windows.Forms.RadioButton();
            this.radioButton_RTU = new System.Windows.Forms.RadioButton();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.groupBox_Transport = new System.Windows.Forms.GroupBox();
            this.spinEdit_Frame = new DevExpress.XtraEditors.SpinEdit();
            this.label_Frame = new System.Windows.Forms.Label();
            this.radioButton_Serial = new System.Windows.Forms.RadioButton();
            this.radioButton_TCP = new System.Windows.Forms.RadioButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Items.SuspendLayout();
            this.groupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Errors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Timeout.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Pause.Properties)).BeginInit();
            this.groupBox_Ethernet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Port.Properties)).BeginInit();
            this.groupBox_Serial.SuspendLayout();
            this.groupBox_StopBits.SuspendLayout();
            this.groupBox_Parity.SuspendLayout();
            this.groupBox_DataBits.SuspendLayout();
            this.groupBox_Protocol.SuspendLayout();
            this.groupBox_Transport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Frame.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Items
            // 
            this.groupBox_Items.Controls.Add(this.label_CountN);
            this.groupBox_Items.Controls.Add(this.label_Count);
            this.groupBox_Items.Location = new System.Drawing.Point(7, 494);
            this.groupBox_Items.Name = "groupBox_Items";
            this.groupBox_Items.Size = new System.Drawing.Size(597, 43);
            this.groupBox_Items.TabIndex = 2;
            this.groupBox_Items.TabStop = false;
            this.groupBox_Items.Text = "Items";
            // 
            // label_CountN
            // 
            this.label_CountN.AutoSize = true;
            this.label_CountN.Location = new System.Drawing.Point(318, 16);
            this.label_CountN.Name = "label_CountN";
            this.label_CountN.Size = new System.Drawing.Size(16, 17);
            this.label_CountN.TabIndex = 1;
            this.label_CountN.Text = "0";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(263, 16);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(49, 17);
            this.label_Count.TabIndex = 0;
            this.label_Count.Text = "Count:";
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.Controls.Add(this.label_WriteRequests);
            this.groupBox_Options.Controls.Add(this.label_WR);
            this.groupBox_Options.Controls.Add(this.spinEdit_Errors);
            this.groupBox_Options.Controls.Add(this.label_Errors);
            this.groupBox_Options.Controls.Add(this.spinEdit_Timeout);
            this.groupBox_Options.Controls.Add(this.spinEdit_Pause);
            this.groupBox_Options.Controls.Add(this.label_Pause);
            this.groupBox_Options.Controls.Add(this.label_CycleTime);
            this.groupBox_Options.Controls.Add(this.label_CTime);
            this.groupBox_Options.Controls.Add(this.label_Timeout);
            this.groupBox_Options.Location = new System.Drawing.Point(7, 342);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Size = new System.Drawing.Size(597, 146);
            this.groupBox_Options.TabIndex = 1;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Options";
            // 
            // label_WriteRequests
            // 
            this.label_WriteRequests.AutoSize = true;
            this.label_WriteRequests.Location = new System.Drawing.Point(346, 117);
            this.label_WriteRequests.Name = "label_WriteRequests";
            this.label_WriteRequests.Size = new System.Drawing.Size(16, 17);
            this.label_WriteRequests.TabIndex = 22;
            this.label_WriteRequests.Text = "0";
            this.label_WriteRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_WR
            // 
            this.label_WR.AutoSize = true;
            this.label_WR.Location = new System.Drawing.Point(235, 117);
            this.label_WR.Name = "label_WR";
            this.label_WR.Size = new System.Drawing.Size(104, 17);
            this.label_WR.TabIndex = 21;
            this.label_WR.Text = "Write requests:";
            // 
            // spinEdit_Errors
            // 
            this.spinEdit_Errors.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinEdit_Errors.Location = new System.Drawing.Point(446, 22);
            this.spinEdit_Errors.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Errors.Name = "spinEdit_Errors";
            this.spinEdit_Errors.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Errors.Properties.IsFloatValue = false;
            this.spinEdit_Errors.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Errors.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Errors.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Errors.Properties.Mask.EditMask = "N00";
            this.spinEdit_Errors.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_Errors.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_Errors.TabIndex = 20;
            this.spinEdit_Errors.EditValueChanged += new System.EventHandler(this.spinEdit_Errors_EditValueChanged);
            // 
            // label_Errors
            // 
            this.label_Errors.AutoSize = true;
            this.label_Errors.Location = new System.Drawing.Point(273, 26);
            this.label_Errors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Errors.Name = "label_Errors";
            this.label_Errors.Size = new System.Drawing.Size(168, 17);
            this.label_Errors.TabIndex = 19;
            this.label_Errors.Text = "Errors before disconnect:";
            // 
            // spinEdit_Timeout
            // 
            this.spinEdit_Timeout.EditValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spinEdit_Timeout.Location = new System.Drawing.Point(155, 22);
            this.spinEdit_Timeout.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Timeout.Name = "spinEdit_Timeout";
            this.spinEdit_Timeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Timeout.Properties.IsFloatValue = false;
            this.spinEdit_Timeout.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Timeout.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Timeout.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Timeout.Properties.Mask.EditMask = "N00";
            this.spinEdit_Timeout.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinEdit_Timeout.Properties.MinValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spinEdit_Timeout.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_Timeout.TabIndex = 0;
            this.spinEdit_Timeout.EditValueChanged += new System.EventHandler(this.spinEdit_Timeout_EditValueChanged);
            // 
            // spinEdit_Pause
            // 
            this.spinEdit_Pause.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Pause.Location = new System.Drawing.Point(295, 54);
            this.spinEdit_Pause.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Pause.Name = "spinEdit_Pause";
            this.spinEdit_Pause.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Pause.Properties.IsFloatValue = false;
            this.spinEdit_Pause.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Pause.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Pause.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Pause.Properties.Mask.EditMask = "N00";
            this.spinEdit_Pause.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.spinEdit_Pause.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_Pause.TabIndex = 1;
            this.spinEdit_Pause.EditValueChanged += new System.EventHandler(this.spinEdit_Pause_EditValueChanged);
            // 
            // label_Pause
            // 
            this.label_Pause.AutoSize = true;
            this.label_Pause.Location = new System.Drawing.Point(209, 58);
            this.label_Pause.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Pause.Name = "label_Pause";
            this.label_Pause.Size = new System.Drawing.Size(82, 17);
            this.label_Pause.TabIndex = 18;
            this.label_Pause.Text = "Pause [ms]:";
            // 
            // label_CycleTime
            // 
            this.label_CycleTime.AutoSize = true;
            this.label_CycleTime.Location = new System.Drawing.Point(231, 88);
            this.label_CycleTime.Name = "label_CycleTime";
            this.label_CycleTime.Size = new System.Drawing.Size(111, 17);
            this.label_CycleTime.TabIndex = 16;
            this.label_CycleTime.Text = "Cycle Time [ms]:";
            this.label_CycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CTime
            // 
            this.label_CTime.AutoSize = true;
            this.label_CTime.Location = new System.Drawing.Point(350, 88);
            this.label_CTime.Name = "label_CTime";
            this.label_CTime.Size = new System.Drawing.Size(16, 17);
            this.label_CTime.TabIndex = 15;
            this.label_CTime.Text = "0";
            this.label_CTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Timeout
            // 
            this.label_Timeout.AutoSize = true;
            this.label_Timeout.Location = new System.Drawing.Point(58, 26);
            this.label_Timeout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Timeout.Name = "label_Timeout";
            this.label_Timeout.Size = new System.Drawing.Size(93, 17);
            this.label_Timeout.TabIndex = 10;
            this.label_Timeout.Text = "Timeout [ms]:";
            // 
            // groupBox_Ethernet
            // 
            this.groupBox_Ethernet.Controls.Add(this.spinEdit_Port);
            this.groupBox_Ethernet.Controls.Add(this.label_Port);
            this.groupBox_Ethernet.Controls.Add(this.label_IP);
            this.groupBox_Ethernet.Controls.Add(this.textBox_IP);
            this.groupBox_Ethernet.Location = new System.Drawing.Point(9, 54);
            this.groupBox_Ethernet.Name = "groupBox_Ethernet";
            this.groupBox_Ethernet.Size = new System.Drawing.Size(248, 101);
            this.groupBox_Ethernet.TabIndex = 3;
            this.groupBox_Ethernet.TabStop = false;
            this.groupBox_Ethernet.Text = "Ethernet Parameters";
            // 
            // spinEdit_Port
            // 
            this.spinEdit_Port.EditValue = new decimal(new int[] {
            502,
            0,
            0,
            0});
            this.spinEdit_Port.Location = new System.Drawing.Point(93, 63);
            this.spinEdit_Port.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Port.Name = "spinEdit_Port";
            this.spinEdit_Port.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Port.Properties.IsFloatValue = false;
            this.spinEdit_Port.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Port.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Port.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Port.Properties.Mask.EditMask = "N00";
            this.spinEdit_Port.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEdit_Port.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_Port.TabIndex = 1;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(51, 67);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(38, 17);
            this.label_Port.TabIndex = 3;
            this.label_Port.Text = "Port:";
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(9, 33);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(80, 17);
            this.label_IP.TabIndex = 2;
            this.label_IP.Text = "IP Address:";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(93, 30);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(146, 22);
            this.textBox_IP.TabIndex = 0;
            // 
            // groupBox_Serial
            // 
            this.groupBox_Serial.Controls.Add(this.groupBox_StopBits);
            this.groupBox_Serial.Controls.Add(this.groupBox_Parity);
            this.groupBox_Serial.Controls.Add(this.label_Parity);
            this.groupBox_Serial.Controls.Add(this.label_StopBits);
            this.groupBox_Serial.Controls.Add(this.groupBox_DataBits);
            this.groupBox_Serial.Controls.Add(this.comboBox_Baud);
            this.groupBox_Serial.Controls.Add(this.comboBox_COMPort);
            this.groupBox_Serial.Controls.Add(this.label_DataBits);
            this.groupBox_Serial.Controls.Add(this.label1);
            this.groupBox_Serial.Controls.Add(this.label_COMPort);
            this.groupBox_Serial.Location = new System.Drawing.Point(266, 54);
            this.groupBox_Serial.Name = "groupBox_Serial";
            this.groupBox_Serial.Size = new System.Drawing.Size(321, 193);
            this.groupBox_Serial.TabIndex = 4;
            this.groupBox_Serial.TabStop = false;
            this.groupBox_Serial.Text = "Serial Parameters";
            // 
            // groupBox_StopBits
            // 
            this.groupBox_StopBits.Controls.Add(this.radioButton_2);
            this.groupBox_StopBits.Controls.Add(this.radioButton_1);
            this.groupBox_StopBits.Controls.Add(this.radioButton_1_5);
            this.groupBox_StopBits.Location = new System.Drawing.Point(83, 149);
            this.groupBox_StopBits.Name = "groupBox_StopBits";
            this.groupBox_StopBits.Size = new System.Drawing.Size(152, 36);
            this.groupBox_StopBits.TabIndex = 4;
            this.groupBox_StopBits.TabStop = false;
            // 
            // radioButton_2
            // 
            this.radioButton_2.AutoSize = true;
            this.radioButton_2.Location = new System.Drawing.Point(106, 10);
            this.radioButton_2.Name = "radioButton_2";
            this.radioButton_2.Size = new System.Drawing.Size(37, 21);
            this.radioButton_2.TabIndex = 2;
            this.radioButton_2.Text = "2";
            this.radioButton_2.UseVisualStyleBackColor = true;
            // 
            // radioButton_1
            // 
            this.radioButton_1.AutoSize = true;
            this.radioButton_1.Checked = true;
            this.radioButton_1.Location = new System.Drawing.Point(8, 10);
            this.radioButton_1.Name = "radioButton_1";
            this.radioButton_1.Size = new System.Drawing.Size(37, 21);
            this.radioButton_1.TabIndex = 0;
            this.radioButton_1.TabStop = true;
            this.radioButton_1.Text = "1";
            this.radioButton_1.UseVisualStyleBackColor = true;
            // 
            // radioButton_1_5
            // 
            this.radioButton_1_5.AutoSize = true;
            this.radioButton_1_5.Location = new System.Drawing.Point(51, 10);
            this.radioButton_1_5.Name = "radioButton_1_5";
            this.radioButton_1_5.Size = new System.Drawing.Size(49, 21);
            this.radioButton_1_5.TabIndex = 1;
            this.radioButton_1_5.Text = "1.5";
            this.radioButton_1_5.UseVisualStyleBackColor = true;
            // 
            // groupBox_Parity
            // 
            this.groupBox_Parity.Controls.Add(this.radioButton_S);
            this.groupBox_Parity.Controls.Add(this.radioButton_M);
            this.groupBox_Parity.Controls.Add(this.radioButton_E);
            this.groupBox_Parity.Controls.Add(this.radioButton_N);
            this.groupBox_Parity.Controls.Add(this.radioButton_O);
            this.groupBox_Parity.Location = new System.Drawing.Point(83, 113);
            this.groupBox_Parity.Name = "groupBox_Parity";
            this.groupBox_Parity.Size = new System.Drawing.Size(232, 36);
            this.groupBox_Parity.TabIndex = 3;
            this.groupBox_Parity.TabStop = false;
            // 
            // radioButton_S
            // 
            this.radioButton_S.AutoSize = true;
            this.radioButton_S.Location = new System.Drawing.Point(188, 10);
            this.radioButton_S.Name = "radioButton_S";
            this.radioButton_S.Size = new System.Drawing.Size(38, 21);
            this.radioButton_S.TabIndex = 4;
            this.radioButton_S.Text = "S";
            this.radioButton_S.UseVisualStyleBackColor = true;
            // 
            // radioButton_M
            // 
            this.radioButton_M.AutoSize = true;
            this.radioButton_M.Location = new System.Drawing.Point(142, 10);
            this.radioButton_M.Name = "radioButton_M";
            this.radioButton_M.Size = new System.Drawing.Size(40, 21);
            this.radioButton_M.TabIndex = 3;
            this.radioButton_M.Text = "M";
            this.radioButton_M.UseVisualStyleBackColor = true;
            // 
            // radioButton_E
            // 
            this.radioButton_E.AutoSize = true;
            this.radioButton_E.Location = new System.Drawing.Point(98, 10);
            this.radioButton_E.Name = "radioButton_E";
            this.radioButton_E.Size = new System.Drawing.Size(38, 21);
            this.radioButton_E.TabIndex = 2;
            this.radioButton_E.Text = "E";
            this.radioButton_E.UseVisualStyleBackColor = true;
            // 
            // radioButton_N
            // 
            this.radioButton_N.AutoSize = true;
            this.radioButton_N.Checked = true;
            this.radioButton_N.Location = new System.Drawing.Point(7, 10);
            this.radioButton_N.Name = "radioButton_N";
            this.radioButton_N.Size = new System.Drawing.Size(39, 21);
            this.radioButton_N.TabIndex = 0;
            this.radioButton_N.TabStop = true;
            this.radioButton_N.Text = "N";
            this.radioButton_N.UseVisualStyleBackColor = true;
            // 
            // radioButton_O
            // 
            this.radioButton_O.AutoSize = true;
            this.radioButton_O.Location = new System.Drawing.Point(52, 10);
            this.radioButton_O.Name = "radioButton_O";
            this.radioButton_O.Size = new System.Drawing.Size(40, 21);
            this.radioButton_O.TabIndex = 1;
            this.radioButton_O.Text = "O";
            this.radioButton_O.UseVisualStyleBackColor = true;
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(31, 123);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(48, 17);
            this.label_Parity.TabIndex = 7;
            this.label_Parity.Text = "Parity:";
            // 
            // label_StopBits
            // 
            this.label_StopBits.AutoSize = true;
            this.label_StopBits.Location = new System.Drawing.Point(11, 159);
            this.label_StopBits.Name = "label_StopBits";
            this.label_StopBits.Size = new System.Drawing.Size(68, 17);
            this.label_StopBits.TabIndex = 6;
            this.label_StopBits.Text = "Stop Bits:";
            // 
            // groupBox_DataBits
            // 
            this.groupBox_DataBits.Controls.Add(this.radioButton_6);
            this.groupBox_DataBits.Controls.Add(this.radioButton_5);
            this.groupBox_DataBits.Controls.Add(this.radioButton_8);
            this.groupBox_DataBits.Controls.Add(this.radioButton_7);
            this.groupBox_DataBits.Location = new System.Drawing.Point(83, 77);
            this.groupBox_DataBits.Name = "groupBox_DataBits";
            this.groupBox_DataBits.Size = new System.Drawing.Size(182, 36);
            this.groupBox_DataBits.TabIndex = 2;
            this.groupBox_DataBits.TabStop = false;
            // 
            // radioButton_6
            // 
            this.radioButton_6.AutoSize = true;
            this.radioButton_6.Location = new System.Drawing.Point(50, 10);
            this.radioButton_6.Name = "radioButton_6";
            this.radioButton_6.Size = new System.Drawing.Size(37, 21);
            this.radioButton_6.TabIndex = 1;
            this.radioButton_6.Text = "6";
            this.radioButton_6.UseVisualStyleBackColor = true;
            // 
            // radioButton_5
            // 
            this.radioButton_5.AutoSize = true;
            this.radioButton_5.Location = new System.Drawing.Point(5, 10);
            this.radioButton_5.Name = "radioButton_5";
            this.radioButton_5.Size = new System.Drawing.Size(37, 21);
            this.radioButton_5.TabIndex = 0;
            this.radioButton_5.Text = "5";
            this.radioButton_5.UseVisualStyleBackColor = true;
            // 
            // radioButton_8
            // 
            this.radioButton_8.AutoSize = true;
            this.radioButton_8.Checked = true;
            this.radioButton_8.Location = new System.Drawing.Point(140, 10);
            this.radioButton_8.Name = "radioButton_8";
            this.radioButton_8.Size = new System.Drawing.Size(37, 21);
            this.radioButton_8.TabIndex = 3;
            this.radioButton_8.TabStop = true;
            this.radioButton_8.Text = "8";
            this.radioButton_8.UseVisualStyleBackColor = true;
            // 
            // radioButton_7
            // 
            this.radioButton_7.AutoSize = true;
            this.radioButton_7.Location = new System.Drawing.Point(95, 10);
            this.radioButton_7.Name = "radioButton_7";
            this.radioButton_7.Size = new System.Drawing.Size(37, 21);
            this.radioButton_7.TabIndex = 2;
            this.radioButton_7.Text = "7";
            this.radioButton_7.UseVisualStyleBackColor = true;
            // 
            // comboBox_Baud
            // 
            this.comboBox_Baud.FormattingEnabled = true;
            this.comboBox_Baud.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.comboBox_Baud.Location = new System.Drawing.Point(83, 51);
            this.comboBox_Baud.Name = "comboBox_Baud";
            this.comboBox_Baud.Size = new System.Drawing.Size(119, 24);
            this.comboBox_Baud.TabIndex = 1;
            // 
            // comboBox_COMPort
            // 
            this.comboBox_COMPort.FormattingEnabled = true;
            this.comboBox_COMPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30",
            "COM31",
            "COM32"});
            this.comboBox_COMPort.Location = new System.Drawing.Point(83, 21);
            this.comboBox_COMPort.Name = "comboBox_COMPort";
            this.comboBox_COMPort.Size = new System.Drawing.Size(119, 24);
            this.comboBox_COMPort.TabIndex = 0;
            // 
            // label_DataBits
            // 
            this.label_DataBits.AutoSize = true;
            this.label_DataBits.Location = new System.Drawing.Point(10, 87);
            this.label_DataBits.Name = "label_DataBits";
            this.label_DataBits.Size = new System.Drawing.Size(69, 17);
            this.label_DataBits.TabIndex = 8;
            this.label_DataBits.Text = "Data Bits:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Baud:";
            // 
            // label_COMPort
            // 
            this.label_COMPort.AutoSize = true;
            this.label_COMPort.Location = new System.Drawing.Point(6, 25);
            this.label_COMPort.Name = "label_COMPort";
            this.label_COMPort.Size = new System.Drawing.Size(73, 17);
            this.label_COMPort.TabIndex = 4;
            this.label_COMPort.Text = "COM Port:";
            // 
            // groupBox_Protocol
            // 
            this.groupBox_Protocol.Controls.Add(this.radioButton_ASCII);
            this.groupBox_Protocol.Controls.Add(this.radioButton_RTU);
            this.groupBox_Protocol.Location = new System.Drawing.Point(9, 161);
            this.groupBox_Protocol.Name = "groupBox_Protocol";
            this.groupBox_Protocol.Size = new System.Drawing.Size(248, 86);
            this.groupBox_Protocol.TabIndex = 5;
            this.groupBox_Protocol.TabStop = false;
            this.groupBox_Protocol.Text = "Protocol";
            // 
            // radioButton_ASCII
            // 
            this.radioButton_ASCII.AutoSize = true;
            this.radioButton_ASCII.Location = new System.Drawing.Point(136, 37);
            this.radioButton_ASCII.Name = "radioButton_ASCII";
            this.radioButton_ASCII.Size = new System.Drawing.Size(62, 21);
            this.radioButton_ASCII.TabIndex = 1;
            this.radioButton_ASCII.Text = "ASCII";
            this.radioButton_ASCII.UseVisualStyleBackColor = true;
            // 
            // radioButton_RTU
            // 
            this.radioButton_RTU.AutoSize = true;
            this.radioButton_RTU.Checked = true;
            this.radioButton_RTU.Location = new System.Drawing.Point(51, 37);
            this.radioButton_RTU.Name = "radioButton_RTU";
            this.radioButton_RTU.Size = new System.Drawing.Size(58, 21);
            this.radioButton_RTU.TabIndex = 0;
            this.radioButton_RTU.TabStop = true;
            this.radioButton_RTU.Text = "RTU";
            this.radioButton_RTU.UseVisualStyleBackColor = true;
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(305, 294);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(100, 28);
            this.button_Disconnect.TabIndex = 8;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(197, 294);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(100, 28);
            this.button_Connect.TabIndex = 7;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // groupBox_Transport
            // 
            this.groupBox_Transport.Controls.Add(this.spinEdit_Frame);
            this.groupBox_Transport.Controls.Add(this.label_Frame);
            this.groupBox_Transport.Controls.Add(this.groupBox_Serial);
            this.groupBox_Transport.Controls.Add(this.groupBox_Ethernet);
            this.groupBox_Transport.Controls.Add(this.radioButton_Serial);
            this.groupBox_Transport.Controls.Add(this.radioButton_TCP);
            this.groupBox_Transport.Controls.Add(this.groupBox_Protocol);
            this.groupBox_Transport.Location = new System.Drawing.Point(7, 4);
            this.groupBox_Transport.Name = "groupBox_Transport";
            this.groupBox_Transport.Size = new System.Drawing.Size(597, 331);
            this.groupBox_Transport.TabIndex = 0;
            this.groupBox_Transport.TabStop = false;
            this.groupBox_Transport.Text = "Transport";
            // 
            // spinEdit_Frame
            // 
            this.spinEdit_Frame.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Frame.Location = new System.Drawing.Point(128, 254);
            this.spinEdit_Frame.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Frame.Name = "spinEdit_Frame";
            this.spinEdit_Frame.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Frame.Properties.IsFloatValue = false;
            this.spinEdit_Frame.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Frame.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Frame.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Frame.Properties.Mask.EditMask = "N00";
            this.spinEdit_Frame.Properties.MaxValue = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.spinEdit_Frame.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Frame.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_Frame.TabIndex = 6;
            this.spinEdit_Frame.EditValueChanged += new System.EventHandler(this.spinEdit_Frame_EditValueChanged);
            // 
            // label_Frame
            // 
            this.label_Frame.AutoSize = true;
            this.label_Frame.Location = new System.Drawing.Point(9, 258);
            this.label_Frame.Name = "label_Frame";
            this.label_Frame.Size = new System.Drawing.Size(112, 17);
            this.label_Frame.TabIndex = 6;
            this.label_Frame.Text = "Frame [register]:";
            // 
            // radioButton_Serial
            // 
            this.radioButton_Serial.AutoSize = true;
            this.radioButton_Serial.Location = new System.Drawing.Point(318, 21);
            this.radioButton_Serial.Name = "radioButton_Serial";
            this.radioButton_Serial.Size = new System.Drawing.Size(65, 21);
            this.radioButton_Serial.TabIndex = 2;
            this.radioButton_Serial.Text = "Serial";
            this.radioButton_Serial.UseVisualStyleBackColor = true;
            this.radioButton_Serial.CheckedChanged += new System.EventHandler(this.radioButton_Serial_CheckedChanged);
            // 
            // radioButton_TCP
            // 
            this.radioButton_TCP.AutoSize = true;
            this.radioButton_TCP.Checked = true;
            this.radioButton_TCP.Location = new System.Drawing.Point(213, 21);
            this.radioButton_TCP.Name = "radioButton_TCP";
            this.radioButton_TCP.Size = new System.Drawing.Size(56, 21);
            this.radioButton_TCP.TabIndex = 0;
            this.radioButton_TCP.TabStop = true;
            this.radioButton_TCP.Text = "TCP";
            this.radioButton_TCP.UseVisualStyleBackColor = true;
            this.radioButton_TCP.CheckedChanged += new System.EventHandler(this.radioButton_TCP_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(211, 550);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 3;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // ConnectionSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 587);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Items);
            this.Controls.Add(this.groupBox_Options);
            this.Controls.Add(this.button_Disconnect);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.groupBox_Transport);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModbusN Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectionSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSetupForm_KeyDown);
            this.groupBox_Items.ResumeLayout(false);
            this.groupBox_Items.PerformLayout();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Errors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Timeout.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Pause.Properties)).EndInit();
            this.groupBox_Ethernet.ResumeLayout(false);
            this.groupBox_Ethernet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Port.Properties)).EndInit();
            this.groupBox_Serial.ResumeLayout(false);
            this.groupBox_Serial.PerformLayout();
            this.groupBox_StopBits.ResumeLayout(false);
            this.groupBox_StopBits.PerformLayout();
            this.groupBox_Parity.ResumeLayout(false);
            this.groupBox_Parity.PerformLayout();
            this.groupBox_DataBits.ResumeLayout(false);
            this.groupBox_DataBits.PerformLayout();
            this.groupBox_Protocol.ResumeLayout(false);
            this.groupBox_Protocol.PerformLayout();
            this.groupBox_Transport.ResumeLayout(false);
            this.groupBox_Transport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Frame.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.GroupBox groupBox_Items;
        private System.Windows.Forms.Label label_CountN;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.GroupBox groupBox_Options;
        private System.Windows.Forms.Label label_CycleTime;
        private System.Windows.Forms.Label label_CTime;
        private System.Windows.Forms.Label label_Timeout;
        private System.Windows.Forms.GroupBox groupBox_Ethernet;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.GroupBox groupBox_Serial;
        private System.Windows.Forms.GroupBox groupBox_StopBits;
        private System.Windows.Forms.RadioButton radioButton_2;
        private System.Windows.Forms.RadioButton radioButton_1;
        private System.Windows.Forms.RadioButton radioButton_1_5;
        private System.Windows.Forms.GroupBox groupBox_Parity;
        private System.Windows.Forms.RadioButton radioButton_E;
        private System.Windows.Forms.RadioButton radioButton_N;
        private System.Windows.Forms.RadioButton radioButton_O;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.Label label_StopBits;
        private System.Windows.Forms.GroupBox groupBox_DataBits;
        private System.Windows.Forms.RadioButton radioButton_8;
        private System.Windows.Forms.RadioButton radioButton_7;
        private System.Windows.Forms.ComboBox comboBox_Baud;
        private System.Windows.Forms.ComboBox comboBox_COMPort;
        private System.Windows.Forms.Label label_DataBits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_COMPort;
        private System.Windows.Forms.GroupBox groupBox_Protocol;
        private System.Windows.Forms.RadioButton radioButton_ASCII;
        private System.Windows.Forms.RadioButton radioButton_RTU;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.GroupBox groupBox_Transport;
        private System.Windows.Forms.RadioButton radioButton_Serial;
        private System.Windows.Forms.RadioButton radioButton_TCP;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Pause;
        private System.Windows.Forms.Label label_Pause;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Timeout;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Port;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Errors;
        private System.Windows.Forms.Label label_Errors;
        private System.Windows.Forms.Label label_WriteRequests;
        private System.Windows.Forms.Label label_WR;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Frame;
        private System.Windows.Forms.Label label_Frame;
        private System.Windows.Forms.RadioButton radioButton_S;
        private System.Windows.Forms.RadioButton radioButton_M;
        private System.Windows.Forms.RadioButton radioButton_6;
        private System.Windows.Forms.RadioButton radioButton_5;
    }
}