// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.MQTT
{
    partial class ConnectionSetupForm
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
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.groupBox_Connection = new System.Windows.Forms.GroupBox();
            this.comboBox_Protocol = new System.Windows.Forms.ComboBox();
            this.label_Protocol = new System.Windows.Forms.Label();
            this.spinEdit_QOS = new DevExpress.XtraEditors.SpinEdit();
            this.label_QOS = new System.Windows.Forms.Label();
            this.spinEdit_keepAlive = new DevExpress.XtraEditors.SpinEdit();
            this.label_keepAlive = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.label_Login = new System.Windows.Forms.Label();
            this.textBox_Root = new System.Windows.Forms.TextBox();
            this.label_Root = new System.Windows.Forms.Label();
            this.spinEdit_Port = new DevExpress.XtraEditors.SpinEdit();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_Host = new System.Windows.Forms.TextBox();
            this.label_Host = new System.Windows.Forms.Label();
            this.groupBox_Items = new System.Windows.Forms.GroupBox();
            this.label_CountN = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Connection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_QOS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_keepAlive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Port.Properties)).BeginInit();
            this.groupBox_Items.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(125, 210);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(103, 27);
            this.button_Connect.TabIndex = 8;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(233, 210);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(103, 27);
            this.button_Disconnect.TabIndex = 9;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // groupBox_Connection
            // 
            this.groupBox_Connection.Controls.Add(this.comboBox_Protocol);
            this.groupBox_Connection.Controls.Add(this.label_Protocol);
            this.groupBox_Connection.Controls.Add(this.spinEdit_QOS);
            this.groupBox_Connection.Controls.Add(this.label_QOS);
            this.groupBox_Connection.Controls.Add(this.spinEdit_keepAlive);
            this.groupBox_Connection.Controls.Add(this.label_keepAlive);
            this.groupBox_Connection.Controls.Add(this.textBox_Password);
            this.groupBox_Connection.Controls.Add(this.label_Password);
            this.groupBox_Connection.Controls.Add(this.textBox_Login);
            this.groupBox_Connection.Controls.Add(this.label_Login);
            this.groupBox_Connection.Controls.Add(this.textBox_Root);
            this.groupBox_Connection.Controls.Add(this.label_Root);
            this.groupBox_Connection.Controls.Add(this.spinEdit_Port);
            this.groupBox_Connection.Controls.Add(this.label_Port);
            this.groupBox_Connection.Controls.Add(this.textBox_Host);
            this.groupBox_Connection.Controls.Add(this.label_Host);
            this.groupBox_Connection.Controls.Add(this.button_Disconnect);
            this.groupBox_Connection.Controls.Add(this.button_Connect);
            this.groupBox_Connection.Location = new System.Drawing.Point(7, 1);
            this.groupBox_Connection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Connection.Name = "groupBox_Connection";
            this.groupBox_Connection.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Connection.Size = new System.Drawing.Size(460, 251);
            this.groupBox_Connection.TabIndex = 0;
            this.groupBox_Connection.TabStop = false;
            this.groupBox_Connection.Text = "Connection";
            // 
            // comboBox_Protocol
            // 
            this.comboBox_Protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Protocol.FormattingEnabled = true;
            this.comboBox_Protocol.Items.AddRange(new object[] {
            "Version_3_1_1",
            "Version_3_1"});
            this.comboBox_Protocol.Location = new System.Drawing.Point(84, 85);
            this.comboBox_Protocol.Name = "comboBox_Protocol";
            this.comboBox_Protocol.Size = new System.Drawing.Size(144, 24);
            this.comboBox_Protocol.TabIndex = 3;
            this.comboBox_Protocol.SelectedIndexChanged += new System.EventHandler(this.comboBox_Protocol_SelectedIndexChanged);
            // 
            // label_Protocol
            // 
            this.label_Protocol.AutoSize = true;
            this.label_Protocol.Location = new System.Drawing.Point(14, 89);
            this.label_Protocol.Name = "label_Protocol";
            this.label_Protocol.Size = new System.Drawing.Size(64, 17);
            this.label_Protocol.TabIndex = 13;
            this.label_Protocol.Text = "Protocol:";
            // 
            // spinEdit_QOS
            // 
            this.spinEdit_QOS.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_QOS.Location = new System.Drawing.Point(328, 85);
            this.spinEdit_QOS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_QOS.Name = "spinEdit_QOS";
            this.spinEdit_QOS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_QOS.Properties.IsFloatValue = false;
            this.spinEdit_QOS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_QOS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_QOS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_QOS.Properties.Mask.EditMask = "N00";
            this.spinEdit_QOS.Properties.MaxValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.spinEdit_QOS.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_QOS.TabIndex = 4;
            this.spinEdit_QOS.EditValueChanged += new System.EventHandler(this.spinEdit_QOS_EditValueChanged);
            // 
            // label_QOS
            // 
            this.label_QOS.AutoSize = true;
            this.label_QOS.Location = new System.Drawing.Point(281, 89);
            this.label_QOS.Name = "label_QOS";
            this.label_QOS.Size = new System.Drawing.Size(40, 17);
            this.label_QOS.TabIndex = 0;
            this.label_QOS.Text = "QoS:";
            // 
            // spinEdit_keepAlive
            // 
            this.spinEdit_keepAlive.EditValue = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.spinEdit_keepAlive.Location = new System.Drawing.Point(328, 54);
            this.spinEdit_keepAlive.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_keepAlive.Name = "spinEdit_keepAlive";
            this.spinEdit_keepAlive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_keepAlive.Properties.IsFloatValue = false;
            this.spinEdit_keepAlive.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_keepAlive.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_keepAlive.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_keepAlive.Properties.Mask.EditMask = "N00";
            this.spinEdit_keepAlive.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEdit_keepAlive.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_keepAlive.TabIndex = 2;
            this.spinEdit_keepAlive.EditValueChanged += new System.EventHandler(this.spinEdit_keepAlive_EditValueChanged);
            // 
            // label_keepAlive
            // 
            this.label_keepAlive.AutoSize = true;
            this.label_keepAlive.Location = new System.Drawing.Point(224, 58);
            this.label_keepAlive.Name = "label_keepAlive";
            this.label_keepAlive.Size = new System.Drawing.Size(97, 17);
            this.label_keepAlive.TabIndex = 12;
            this.label_keepAlive.Text = "Keep alive [s]:";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(84, 174);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(368, 22);
            this.textBox_Password.TabIndex = 7;
            this.textBox_Password.TextChanged += new System.EventHandler(this.textBox_Password_TextChanged);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(5, 177);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(73, 17);
            this.label_Password.TabIndex = 10;
            this.label_Password.Text = "Password:";
            // 
            // textBox_Login
            // 
            this.textBox_Login.Location = new System.Drawing.Point(84, 145);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(368, 22);
            this.textBox_Login.TabIndex = 6;
            this.textBox_Login.TextChanged += new System.EventHandler(this.textBox_Login_TextChanged);
            // 
            // label_Login
            // 
            this.label_Login.AutoSize = true;
            this.label_Login.Location = new System.Drawing.Point(31, 148);
            this.label_Login.Name = "label_Login";
            this.label_Login.Size = new System.Drawing.Size(47, 17);
            this.label_Login.TabIndex = 8;
            this.label_Login.Text = "Login:";
            // 
            // textBox_Root
            // 
            this.textBox_Root.Location = new System.Drawing.Point(84, 116);
            this.textBox_Root.Name = "textBox_Root";
            this.textBox_Root.Size = new System.Drawing.Size(368, 22);
            this.textBox_Root.TabIndex = 5;
            this.textBox_Root.TextChanged += new System.EventHandler(this.textBox_Root_TextChanged);
            this.textBox_Root.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Root_KeyPress);
            // 
            // label_Root
            // 
            this.label_Root.AutoSize = true;
            this.label_Root.Location = new System.Drawing.Point(36, 119);
            this.label_Root.Name = "label_Root";
            this.label_Root.Size = new System.Drawing.Size(42, 17);
            this.label_Root.TabIndex = 6;
            this.label_Root.Text = "Root:";
            // 
            // spinEdit_Port
            // 
            this.spinEdit_Port.EditValue = new decimal(new int[] {
            1883,
            0,
            0,
            0});
            this.spinEdit_Port.Location = new System.Drawing.Point(84, 54);
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
            this.spinEdit_Port.EditValueChanged += new System.EventHandler(this.spinEdit_Port_EditValueChanged);
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(40, 58);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(38, 17);
            this.label_Port.TabIndex = 4;
            this.label_Port.Text = "Port:";
            // 
            // textBox_Host
            // 
            this.textBox_Host.Location = new System.Drawing.Point(84, 25);
            this.textBox_Host.Name = "textBox_Host";
            this.textBox_Host.Size = new System.Drawing.Size(368, 22);
            this.textBox_Host.TabIndex = 0;
            this.textBox_Host.TextChanged += new System.EventHandler(this.textBox_Host_TextChanged);
            // 
            // label_Host
            // 
            this.label_Host.AutoSize = true;
            this.label_Host.Location = new System.Drawing.Point(37, 28);
            this.label_Host.Name = "label_Host";
            this.label_Host.Size = new System.Drawing.Size(41, 17);
            this.label_Host.TabIndex = 2;
            this.label_Host.Text = "Host:";
            // 
            // groupBox_Items
            // 
            this.groupBox_Items.Controls.Add(this.label_CountN);
            this.groupBox_Items.Controls.Add(this.label_Count);
            this.groupBox_Items.Location = new System.Drawing.Point(7, 256);
            this.groupBox_Items.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Name = "groupBox_Items";
            this.groupBox_Items.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Size = new System.Drawing.Size(460, 43);
            this.groupBox_Items.TabIndex = 1;
            this.groupBox_Items.TabStop = false;
            this.groupBox_Items.Text = "Items";
            // 
            // label_CountN
            // 
            this.label_CountN.AutoSize = true;
            this.label_CountN.Location = new System.Drawing.Point(250, 16);
            this.label_CountN.Name = "label_CountN";
            this.label_CountN.Size = new System.Drawing.Size(16, 17);
            this.label_CountN.TabIndex = 1;
            this.label_CountN.Text = "0";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(195, 16);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(49, 17);
            this.label_Count.TabIndex = 0;
            this.label_Count.Text = "Count:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(143, 306);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 2;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // ConnectionSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 346);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Connection);
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.groupBox_Items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MQTT Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectionSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSetupForm_KeyDown);
            this.groupBox_Connection.ResumeLayout(false);
            this.groupBox_Connection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_QOS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_keepAlive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Port.Properties)).EndInit();
            this.groupBox_Items.ResumeLayout(false);
            this.groupBox_Items.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.GroupBox groupBox_Connection;
        private System.Windows.Forms.GroupBox groupBox_Items;
        private System.Windows.Forms.Label label_CountN;
        private System.Windows.Forms.Label label_Count;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.TextBox textBox_Host;
        private System.Windows.Forms.Label label_Host;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label_Port;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Port;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.Label label_Login;
        private System.Windows.Forms.TextBox textBox_Root;
        private System.Windows.Forms.Label label_Root;
        private DevExpress.XtraEditors.SpinEdit spinEdit_QOS;
        private System.Windows.Forms.Label label_QOS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_keepAlive;
        private System.Windows.Forms.Label label_keepAlive;
        private System.Windows.Forms.ComboBox comboBox_Protocol;
        private System.Windows.Forms.Label label_Protocol;
    }
}