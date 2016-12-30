// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.OPCUA
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
            this.components = new System.ComponentModel.Container();
            this.groupBox_Server = new System.Windows.Forms.GroupBox();
            this.spinEdit_PubInterval = new DevExpress.XtraEditors.SpinEdit();
            this.label_PubInterval = new System.Windows.Forms.Label();
            this.button_Browse = new System.Windows.Forms.Button();
            this.comboBox_Transport = new System.Windows.Forms.ComboBox();
            this.label_Transport = new System.Windows.Forms.Label();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.comboBox_Server = new System.Windows.Forms.ComboBox();
            this.textBox_Discovery = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.label_Discovery = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox_Items = new System.Windows.Forms.GroupBox();
            this.label_CountN = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Login = new System.Windows.Forms.TextBox();
            this.label_Login = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Server.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PubInterval.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_Server
            // 
            this.groupBox_Server.Controls.Add(this.textBox_Password);
            this.groupBox_Server.Controls.Add(this.label_Password);
            this.groupBox_Server.Controls.Add(this.textBox_Login);
            this.groupBox_Server.Controls.Add(this.label_Login);
            this.groupBox_Server.Controls.Add(this.spinEdit_PubInterval);
            this.groupBox_Server.Controls.Add(this.label_PubInterval);
            this.groupBox_Server.Controls.Add(this.button_Browse);
            this.groupBox_Server.Controls.Add(this.comboBox_Transport);
            this.groupBox_Server.Controls.Add(this.label_Transport);
            this.groupBox_Server.Controls.Add(this.button_Disconnect);
            this.groupBox_Server.Controls.Add(this.button_Connect);
            this.groupBox_Server.Controls.Add(this.comboBox_Server);
            this.groupBox_Server.Controls.Add(this.textBox_Discovery);
            this.groupBox_Server.Controls.Add(this.label_Server);
            this.groupBox_Server.Controls.Add(this.label_Discovery);
            this.groupBox_Server.Location = new System.Drawing.Point(6, 1);
            this.groupBox_Server.Name = "groupBox_Server";
            this.groupBox_Server.Size = new System.Drawing.Size(397, 235);
            this.groupBox_Server.TabIndex = 0;
            this.groupBox_Server.TabStop = false;
            this.groupBox_Server.Text = "Server";
            // 
            // spinEdit_PubInterval
            // 
            this.spinEdit_PubInterval.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEdit_PubInterval.Location = new System.Drawing.Point(219, 108);
            this.spinEdit_PubInterval.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_PubInterval.Name = "spinEdit_PubInterval";
            this.spinEdit_PubInterval.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_PubInterval.Properties.IsFloatValue = false;
            this.spinEdit_PubInterval.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_PubInterval.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_PubInterval.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_PubInterval.Properties.Mask.EditMask = "N00";
            this.spinEdit_PubInterval.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_PubInterval.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_PubInterval.TabIndex = 3;
            this.spinEdit_PubInterval.EditValueChanged += new System.EventHandler(this.spinEdit_PubInterval_EditValueChanged);
            // 
            // label_PubInterval
            // 
            this.label_PubInterval.AutoSize = true;
            this.label_PubInterval.Location = new System.Drawing.Point(85, 112);
            this.label_PubInterval.Name = "label_PubInterval";
            this.label_PubInterval.Size = new System.Drawing.Size(127, 17);
            this.label_PubInterval.TabIndex = 0;
            this.label_PubInterval.Text = "Publishing interval:";
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(264, 199);
            this.button_Browse.Margin = new System.Windows.Forms.Padding(4);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(116, 27);
            this.button_Browse.TabIndex = 8;
            this.button_Browse.Text = "Browse Nodes";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // comboBox_Transport
            // 
            this.comboBox_Transport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Transport.FormattingEnabled = true;
            this.comboBox_Transport.Location = new System.Drawing.Point(99, 80);
            this.comboBox_Transport.Name = "comboBox_Transport";
            this.comboBox_Transport.Size = new System.Drawing.Size(281, 24);
            this.comboBox_Transport.TabIndex = 2;
            this.comboBox_Transport.TextChanged += new System.EventHandler(this.comboBox_Transport_TextChanged);
            // 
            // label_Transport
            // 
            this.label_Transport.AutoSize = true;
            this.label_Transport.Location = new System.Drawing.Point(17, 84);
            this.label_Transport.Name = "label_Transport";
            this.label_Transport.Size = new System.Drawing.Size(74, 17);
            this.label_Transport.TabIndex = 6;
            this.label_Transport.Text = "Transport:";
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(140, 199);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(116, 27);
            this.button_Disconnect.TabIndex = 7;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(16, 199);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(116, 27);
            this.button_Connect.TabIndex = 6;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // comboBox_Server
            // 
            this.comboBox_Server.FormattingEnabled = true;
            this.comboBox_Server.Location = new System.Drawing.Point(99, 50);
            this.comboBox_Server.Name = "comboBox_Server";
            this.comboBox_Server.Size = new System.Drawing.Size(281, 24);
            this.comboBox_Server.TabIndex = 1;
            this.comboBox_Server.DropDown += new System.EventHandler(this.comboBox_Server_DropDown);
            this.comboBox_Server.TextChanged += new System.EventHandler(this.comboBox_Server_TextChanged);
            // 
            // textBox_Discovery
            // 
            this.textBox_Discovery.Location = new System.Drawing.Point(99, 22);
            this.textBox_Discovery.Name = "textBox_Discovery";
            this.textBox_Discovery.Size = new System.Drawing.Size(281, 22);
            this.textBox_Discovery.TabIndex = 0;
            this.textBox_Discovery.Text = "opc.tcp://localhost:4840";
            this.textBox_Discovery.TextChanged += new System.EventHandler(this.textBox_Discovery_TextChanged);
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(37, 54);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(54, 17);
            this.label_Server.TabIndex = 1;
            this.label_Server.Text = "Server:";
            // 
            // label_Discovery
            // 
            this.label_Discovery.AutoSize = true;
            this.label_Discovery.Location = new System.Drawing.Point(17, 25);
            this.label_Discovery.Name = "label_Discovery";
            this.label_Discovery.Size = new System.Drawing.Size(74, 17);
            this.label_Discovery.TabIndex = 0;
            this.label_Discovery.Text = "Discovery:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox_Items
            // 
            this.groupBox_Items.Controls.Add(this.label_CountN);
            this.groupBox_Items.Controls.Add(this.label_Count);
            this.groupBox_Items.Location = new System.Drawing.Point(6, 241);
            this.groupBox_Items.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Name = "groupBox_Items";
            this.groupBox_Items.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Size = new System.Drawing.Size(397, 43);
            this.groupBox_Items.TabIndex = 1;
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
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(99, 165);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.Size = new System.Drawing.Size(281, 22);
            this.textBox_Password.TabIndex = 5;
            this.textBox_Password.TextChanged += new System.EventHandler(this.textBox_Password_TextChanged);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(18, 168);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(73, 17);
            this.label_Password.TabIndex = 14;
            this.label_Password.Text = "Password:";
            // 
            // textBox_Login
            // 
            this.textBox_Login.Location = new System.Drawing.Point(99, 137);
            this.textBox_Login.Name = "textBox_Login";
            this.textBox_Login.Size = new System.Drawing.Size(281, 22);
            this.textBox_Login.TabIndex = 4;
            this.textBox_Login.TextChanged += new System.EventHandler(this.textBox_Login_TextChanged);
            // 
            // label_Login
            // 
            this.label_Login.AutoSize = true;
            this.label_Login.Location = new System.Drawing.Point(44, 140);
            this.label_Login.Name = "label_Login";
            this.label_Login.Size = new System.Drawing.Size(47, 17);
            this.label_Login.TabIndex = 13;
            this.label_Login.Text = "Login:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(110, 293);
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
            this.ClientSize = new System.Drawing.Size(409, 332);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Items);
            this.Controls.Add(this.groupBox_Server);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OPC UA Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSetupForm_KeyDown);
            this.groupBox_Server.ResumeLayout(false);
            this.groupBox_Server.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_PubInterval.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox_Items.ResumeLayout(false);
            this.groupBox_Items.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.GroupBox groupBox_Server;
        private System.Windows.Forms.ComboBox comboBox_Server;
        private System.Windows.Forms.TextBox textBox_Discovery;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.Label label_Discovery;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label_Transport;
        private System.Windows.Forms.ComboBox comboBox_Transport;
        private System.Windows.Forms.GroupBox groupBox_Items;
        private System.Windows.Forms.Label label_CountN;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.Label label_PubInterval;
        private DevExpress.XtraEditors.SpinEdit spinEdit_PubInterval;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Login;
        private System.Windows.Forms.Label label_Login;
    }
}