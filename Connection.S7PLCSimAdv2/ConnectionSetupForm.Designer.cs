// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.S7PLCSimAdv2
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox_Server = new System.Windows.Forms.GroupBox();
            this.checkBox_Remote = new System.Windows.Forms.CheckBox();
            this.spinEdit_Port = new DevExpress.XtraEditors.SpinEdit();
            this.label_Port = new System.Windows.Forms.Label();
            this.label_IP = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.comboBox_PLC = new System.Windows.Forms.ComboBox();
            this.label_PLC = new System.Windows.Forms.Label();
            this.button_Browse = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.label_WriteRequests = new System.Windows.Forms.Label();
            this.label_WR = new System.Windows.Forms.Label();
            this.spinEdit_Pause = new DevExpress.XtraEditors.SpinEdit();
            this.label_Pause = new System.Windows.Forms.Label();
            this.label_CycleTime = new System.Windows.Forms.Label();
            this.label_CTime = new System.Windows.Forms.Label();
            this.groupBox_Items.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox_Server.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Port.Properties)).BeginInit();
            this.groupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Pause.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Items
            // 
            this.groupBox_Items.Controls.Add(this.label_CountN);
            this.groupBox_Items.Controls.Add(this.label_Count);
            this.groupBox_Items.Location = new System.Drawing.Point(11, 287);
            this.groupBox_Items.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Name = "groupBox_Items";
            this.groupBox_Items.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Size = new System.Drawing.Size(397, 41);
            this.groupBox_Items.TabIndex = 2;
            this.groupBox_Items.TabStop = false;
            this.groupBox_Items.Text = "Items";
            // 
            // label_CountN
            // 
            this.label_CountN.AutoSize = true;
            this.label_CountN.Location = new System.Drawing.Point(211, 16);
            this.label_CountN.Name = "label_CountN";
            this.label_CountN.Size = new System.Drawing.Size(16, 17);
            this.label_CountN.TabIndex = 1;
            this.label_CountN.Text = "0";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(156, 16);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(49, 17);
            this.label_Count.TabIndex = 0;
            this.label_Count.Text = "Count:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox_Server
            // 
            this.groupBox_Server.Controls.Add(this.checkBox_Remote);
            this.groupBox_Server.Controls.Add(this.spinEdit_Port);
            this.groupBox_Server.Controls.Add(this.label_Port);
            this.groupBox_Server.Controls.Add(this.label_IP);
            this.groupBox_Server.Controls.Add(this.textBox_IP);
            this.groupBox_Server.Controls.Add(this.comboBox_PLC);
            this.groupBox_Server.Controls.Add(this.label_PLC);
            this.groupBox_Server.Controls.Add(this.button_Browse);
            this.groupBox_Server.Controls.Add(this.button_Disconnect);
            this.groupBox_Server.Controls.Add(this.button_Connect);
            this.groupBox_Server.Location = new System.Drawing.Point(11, 12);
            this.groupBox_Server.Name = "groupBox_Server";
            this.groupBox_Server.Size = new System.Drawing.Size(397, 151);
            this.groupBox_Server.TabIndex = 0;
            this.groupBox_Server.TabStop = false;
            this.groupBox_Server.Text = "Instance";
            // 
            // checkBox_Remote
            // 
            this.checkBox_Remote.AutoSize = true;
            this.checkBox_Remote.Location = new System.Drawing.Point(15, 22);
            this.checkBox_Remote.Name = "checkBox_Remote";
            this.checkBox_Remote.Size = new System.Drawing.Size(79, 21);
            this.checkBox_Remote.TabIndex = 0;
            this.checkBox_Remote.Text = "Remote";
            this.checkBox_Remote.UseVisualStyleBackColor = true;
            this.checkBox_Remote.CheckedChanged += new System.EventHandler(this.checkBox_Remote_CheckedChanged);
            // 
            // spinEdit_Port
            // 
            this.spinEdit_Port.EditValue = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.spinEdit_Port.Location = new System.Drawing.Point(193, 50);
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
            this.spinEdit_Port.TabIndex = 2;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(147, 54);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(38, 17);
            this.label_Port.TabIndex = 16;
            this.label_Port.Text = "Port:";
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(105, 23);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(80, 17);
            this.label_IP.TabIndex = 15;
            this.label_IP.Text = "IP Address:";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(193, 20);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(146, 22);
            this.textBox_IP.TabIndex = 1;
            // 
            // comboBox_PLC
            // 
            this.comboBox_PLC.FormattingEnabled = true;
            this.comboBox_PLC.Location = new System.Drawing.Point(193, 83);
            this.comboBox_PLC.Name = "comboBox_PLC";
            this.comboBox_PLC.Size = new System.Drawing.Size(188, 24);
            this.comboBox_PLC.TabIndex = 3;
            this.comboBox_PLC.DropDown += new System.EventHandler(this.comboBox_PLC_DropDown);
            // 
            // label_PLC
            // 
            this.label_PLC.AutoSize = true;
            this.label_PLC.Location = new System.Drawing.Point(147, 86);
            this.label_PLC.Name = "label_PLC";
            this.label_PLC.Size = new System.Drawing.Size(38, 17);
            this.label_PLC.TabIndex = 12;
            this.label_PLC.Text = "PLC:";
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(264, 115);
            this.button_Browse.Margin = new System.Windows.Forms.Padding(4);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(116, 27);
            this.button_Browse.TabIndex = 6;
            this.button_Browse.Text = "Browse Tags";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(140, 115);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(116, 27);
            this.button_Disconnect.TabIndex = 5;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(16, 115);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(116, 27);
            this.button_Connect.TabIndex = 4;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(115, 339);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 3;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.Controls.Add(this.label_WriteRequests);
            this.groupBox_Options.Controls.Add(this.label_WR);
            this.groupBox_Options.Controls.Add(this.spinEdit_Pause);
            this.groupBox_Options.Controls.Add(this.label_Pause);
            this.groupBox_Options.Controls.Add(this.label_CycleTime);
            this.groupBox_Options.Controls.Add(this.label_CTime);
            this.groupBox_Options.Location = new System.Drawing.Point(12, 169);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Size = new System.Drawing.Size(397, 113);
            this.groupBox_Options.TabIndex = 1;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Options";
            // 
            // label_WriteRequests
            // 
            this.label_WriteRequests.AutoSize = true;
            this.label_WriteRequests.Location = new System.Drawing.Point(246, 86);
            this.label_WriteRequests.Name = "label_WriteRequests";
            this.label_WriteRequests.Size = new System.Drawing.Size(16, 17);
            this.label_WriteRequests.TabIndex = 22;
            this.label_WriteRequests.Text = "0";
            this.label_WriteRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_WR
            // 
            this.label_WR.AutoSize = true;
            this.label_WR.Location = new System.Drawing.Point(135, 86);
            this.label_WR.Name = "label_WR";
            this.label_WR.Size = new System.Drawing.Size(104, 17);
            this.label_WR.TabIndex = 21;
            this.label_WR.Text = "Write requests:";
            // 
            // spinEdit_Pause
            // 
            this.spinEdit_Pause.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Pause.Location = new System.Drawing.Point(195, 23);
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
            this.spinEdit_Pause.TabIndex = 0;
            this.spinEdit_Pause.EditValueChanged += new System.EventHandler(this.spinEdit_Pause_EditValueChanged);
            // 
            // label_Pause
            // 
            this.label_Pause.AutoSize = true;
            this.label_Pause.Location = new System.Drawing.Point(109, 27);
            this.label_Pause.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Pause.Name = "label_Pause";
            this.label_Pause.Size = new System.Drawing.Size(82, 17);
            this.label_Pause.TabIndex = 18;
            this.label_Pause.Text = "Pause [ms]:";
            // 
            // label_CycleTime
            // 
            this.label_CycleTime.AutoSize = true;
            this.label_CycleTime.Location = new System.Drawing.Point(131, 57);
            this.label_CycleTime.Name = "label_CycleTime";
            this.label_CycleTime.Size = new System.Drawing.Size(111, 17);
            this.label_CycleTime.TabIndex = 16;
            this.label_CycleTime.Text = "Cycle Time [ms]:";
            this.label_CycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CTime
            // 
            this.label_CTime.AutoSize = true;
            this.label_CTime.Location = new System.Drawing.Point(250, 57);
            this.label_CTime.Name = "label_CTime";
            this.label_CTime.Size = new System.Drawing.Size(16, 17);
            this.label_CTime.TabIndex = 15;
            this.label_CTime.Text = "0";
            this.label_CTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectionSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 379);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Options);
            this.Controls.Add(this.groupBox_Server);
            this.Controls.Add(this.groupBox_Items);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PLCSim Advanced v2 Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSetupForm_KeyDown);
            this.groupBox_Items.ResumeLayout(false);
            this.groupBox_Items.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox_Server.ResumeLayout(false);
            this.groupBox_Server.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Port.Properties)).EndInit();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Pause.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Items;
        private System.Windows.Forms.Label label_CountN;
        private System.Windows.Forms.Label label_Count;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox_Server;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.ComboBox comboBox_PLC;
        private System.Windows.Forms.Label label_PLC;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Port;
        private System.Windows.Forms.CheckBox checkBox_Remote;
        private System.Windows.Forms.GroupBox groupBox_Options;
        private System.Windows.Forms.Label label_WriteRequests;
        private System.Windows.Forms.Label label_WR;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Pause;
        private System.Windows.Forms.Label label_Pause;
        private System.Windows.Forms.Label label_CycleTime;
        private System.Windows.Forms.Label label_CTime;
    }
}