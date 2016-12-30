// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.S7IsoTCP
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
            this.groupBox_PLC = new System.Windows.Forms.GroupBox();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.spinEdit_Slot = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Rack = new DevExpress.XtraEditors.SpinEdit();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_Slot = new System.Windows.Forms.Label();
            this.label_Rack = new System.Windows.Forms.Label();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.label_IP = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.groupBox_Items = new System.Windows.Forms.GroupBox();
            this.label_CountN = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.label_WriteRequests = new System.Windows.Forms.Label();
            this.label_WR = new System.Windows.Forms.Label();
            this.spinEdit_Errors = new DevExpress.XtraEditors.SpinEdit();
            this.label_Errors = new System.Windows.Forms.Label();
            this.spinEdit_Slowing = new DevExpress.XtraEditors.SpinEdit();
            this.label_Slowdown = new System.Windows.Forms.Label();
            this.label_CycleTime = new System.Windows.Forms.Label();
            this.label_CTime = new System.Windows.Forms.Label();
            this.groupBox_PLC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Slot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Rack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox_Items.SuspendLayout();
            this.groupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Errors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Slowing.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_PLC
            // 
            this.groupBox_PLC.Controls.Add(this.comboBox_Type);
            this.groupBox_PLC.Controls.Add(this.spinEdit_Slot);
            this.groupBox_PLC.Controls.Add(this.spinEdit_Rack);
            this.groupBox_PLC.Controls.Add(this.label_Type);
            this.groupBox_PLC.Controls.Add(this.label_Slot);
            this.groupBox_PLC.Controls.Add(this.label_Rack);
            this.groupBox_PLC.Controls.Add(this.button_Disconnect);
            this.groupBox_PLC.Controls.Add(this.button_Connect);
            this.groupBox_PLC.Controls.Add(this.label_IP);
            this.groupBox_PLC.Controls.Add(this.textBox_IP);
            this.groupBox_PLC.Location = new System.Drawing.Point(7, 3);
            this.groupBox_PLC.Name = "groupBox_PLC";
            this.groupBox_PLC.Size = new System.Drawing.Size(362, 147);
            this.groupBox_PLC.TabIndex = 0;
            this.groupBox_PLC.TabStop = false;
            this.groupBox_PLC.Text = "PLC";
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Items.AddRange(new object[] {
            "PG",
            "OP",
            "S7Basic"});
            this.comboBox_Type.Location = new System.Drawing.Point(146, 81);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(93, 24);
            this.comboBox_Type.TabIndex = 3;
            this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
            // 
            // spinEdit_Slot
            // 
            this.spinEdit_Slot.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Slot.Location = new System.Drawing.Point(248, 50);
            this.spinEdit_Slot.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Slot.Name = "spinEdit_Slot";
            this.spinEdit_Slot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Slot.Properties.IsFloatValue = false;
            this.spinEdit_Slot.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Slot.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Slot.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Slot.Properties.Mask.EditMask = "N00";
            this.spinEdit_Slot.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEdit_Slot.Size = new System.Drawing.Size(52, 24);
            this.spinEdit_Slot.TabIndex = 2;
            this.spinEdit_Slot.EditValueChanged += new System.EventHandler(this.spinEdit_Slot_EditValueChanged);
            // 
            // spinEdit_Rack
            // 
            this.spinEdit_Rack.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Rack.Location = new System.Drawing.Point(146, 50);
            this.spinEdit_Rack.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Rack.Name = "spinEdit_Rack";
            this.spinEdit_Rack.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Rack.Properties.IsFloatValue = false;
            this.spinEdit_Rack.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Rack.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Rack.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Rack.Properties.Mask.EditMask = "N00";
            this.spinEdit_Rack.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEdit_Rack.Size = new System.Drawing.Size(53, 24);
            this.spinEdit_Rack.TabIndex = 1;
            this.spinEdit_Rack.EditValueChanged += new System.EventHandler(this.spinEdit_Rack_EditValueChanged);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(98, 85);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(44, 17);
            this.label_Type.TabIndex = 14;
            this.label_Type.Text = "Type:";
            // 
            // label_Slot
            // 
            this.label_Slot.AutoSize = true;
            this.label_Slot.Location = new System.Drawing.Point(208, 54);
            this.label_Slot.Name = "label_Slot";
            this.label_Slot.Size = new System.Drawing.Size(36, 17);
            this.label_Slot.TabIndex = 13;
            this.label_Slot.Text = "Slot:";
            // 
            // label_Rack
            // 
            this.label_Rack.AutoSize = true;
            this.label_Rack.Location = new System.Drawing.Point(97, 54);
            this.label_Rack.Name = "label_Rack";
            this.label_Rack.Size = new System.Drawing.Size(44, 17);
            this.label_Rack.TabIndex = 12;
            this.label_Rack.Text = "Rack:";
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(185, 114);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(100, 28);
            this.button_Disconnect.TabIndex = 5;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(77, 114);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(100, 28);
            this.button_Connect.TabIndex = 4;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(62, 24);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(80, 17);
            this.label_IP.TabIndex = 4;
            this.label_IP.Text = "IP Address:";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(146, 21);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(154, 22);
            this.textBox_IP.TabIndex = 0;
            this.textBox_IP.TextChanged += new System.EventHandler(this.textBox_IP_TextChanged);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(94, 337);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox_Items
            // 
            this.groupBox_Items.Controls.Add(this.label_CountN);
            this.groupBox_Items.Controls.Add(this.label_Count);
            this.groupBox_Items.Location = new System.Drawing.Point(7, 289);
            this.groupBox_Items.Name = "groupBox_Items";
            this.groupBox_Items.Size = new System.Drawing.Size(362, 43);
            this.groupBox_Items.TabIndex = 5;
            this.groupBox_Items.TabStop = false;
            this.groupBox_Items.Text = "Items";
            // 
            // label_CountN
            // 
            this.label_CountN.AutoSize = true;
            this.label_CountN.Location = new System.Drawing.Point(201, 18);
            this.label_CountN.Name = "label_CountN";
            this.label_CountN.Size = new System.Drawing.Size(16, 17);
            this.label_CountN.TabIndex = 1;
            this.label_CountN.Text = "0";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(146, 18);
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
            this.groupBox_Options.Controls.Add(this.spinEdit_Slowing);
            this.groupBox_Options.Controls.Add(this.label_Slowdown);
            this.groupBox_Options.Controls.Add(this.label_CycleTime);
            this.groupBox_Options.Controls.Add(this.label_CTime);
            this.groupBox_Options.Location = new System.Drawing.Point(7, 154);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Size = new System.Drawing.Size(362, 129);
            this.groupBox_Options.TabIndex = 6;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Options";
            // 
            // label_WriteRequests
            // 
            this.label_WriteRequests.AutoSize = true;
            this.label_WriteRequests.Location = new System.Drawing.Point(220, 101);
            this.label_WriteRequests.Name = "label_WriteRequests";
            this.label_WriteRequests.Size = new System.Drawing.Size(16, 17);
            this.label_WriteRequests.TabIndex = 24;
            this.label_WriteRequests.Text = "0";
            this.label_WriteRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_WR
            // 
            this.label_WR.AutoSize = true;
            this.label_WR.Location = new System.Drawing.Point(111, 101);
            this.label_WR.Name = "label_WR";
            this.label_WR.Size = new System.Drawing.Size(104, 17);
            this.label_WR.TabIndex = 23;
            this.label_WR.Text = "Write requests:";
            // 
            // spinEdit_Errors
            // 
            this.spinEdit_Errors.EditValue = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.spinEdit_Errors.Location = new System.Drawing.Point(223, 16);
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
            this.spinEdit_Errors.TabIndex = 22;
            this.spinEdit_Errors.EditValueChanged += new System.EventHandler(this.spinEdit_Errors_EditValueChanged);
            // 
            // label_Errors
            // 
            this.label_Errors.AutoSize = true;
            this.label_Errors.Location = new System.Drawing.Point(47, 20);
            this.label_Errors.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Errors.Name = "label_Errors";
            this.label_Errors.Size = new System.Drawing.Size(168, 17);
            this.label_Errors.TabIndex = 21;
            this.label_Errors.Text = "Errors before disconnect:";
            // 
            // spinEdit_Slowing
            // 
            this.spinEdit_Slowing.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Slowing.Location = new System.Drawing.Point(223, 43);
            this.spinEdit_Slowing.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Slowing.Name = "spinEdit_Slowing";
            this.spinEdit_Slowing.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Slowing.Properties.IsFloatValue = false;
            this.spinEdit_Slowing.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Slowing.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Slowing.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Slowing.Properties.Mask.EditMask = "N00";
            this.spinEdit_Slowing.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEdit_Slowing.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_Slowing.TabIndex = 19;
            this.spinEdit_Slowing.EditValueChanged += new System.EventHandler(this.spinEdit_Slowing_EditValueChanged);
            // 
            // label_Slowdown
            // 
            this.label_Slowdown.AutoSize = true;
            this.label_Slowdown.Location = new System.Drawing.Point(141, 47);
            this.label_Slowdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Slowdown.Name = "label_Slowdown";
            this.label_Slowdown.Size = new System.Drawing.Size(74, 17);
            this.label_Slowdown.TabIndex = 20;
            this.label_Slowdown.Text = "Slowdown:";
            // 
            // label_CycleTime
            // 
            this.label_CycleTime.AutoSize = true;
            this.label_CycleTime.Location = new System.Drawing.Point(104, 74);
            this.label_CycleTime.Name = "label_CycleTime";
            this.label_CycleTime.Size = new System.Drawing.Size(111, 17);
            this.label_CycleTime.TabIndex = 18;
            this.label_CycleTime.Text = "Cycle Time [ms]:";
            this.label_CycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CTime
            // 
            this.label_CTime.AutoSize = true;
            this.label_CTime.Location = new System.Drawing.Point(220, 74);
            this.label_CTime.Name = "label_CTime";
            this.label_CTime.Size = new System.Drawing.Size(16, 17);
            this.label_CTime.TabIndex = 17;
            this.label_CTime.Text = "0";
            this.label_CTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectionSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 377);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Options);
            this.Controls.Add(this.groupBox_Items);
            this.Controls.Add(this.groupBox_PLC);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "S7IsoTCP Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectionSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSetupForm_KeyDown);
            this.groupBox_PLC.ResumeLayout(false);
            this.groupBox_PLC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Slot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Rack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox_Items.ResumeLayout(false);
            this.groupBox_Items.PerformLayout();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Errors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Slowing.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.GroupBox groupBox_PLC;
        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Label label_Rack;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.Label label_Slot;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Slot;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Rack;
        private System.Windows.Forms.ComboBox comboBox_Type;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox_Options;
        private System.Windows.Forms.GroupBox groupBox_Items;
        private System.Windows.Forms.Label label_CountN;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.Label label_CycleTime;
        private System.Windows.Forms.Label label_CTime;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Slowing;
        private System.Windows.Forms.Label label_Slowdown;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Errors;
        private System.Windows.Forms.Label label_Errors;
        private System.Windows.Forms.Label label_WriteRequests;
        private System.Windows.Forms.Label label_WR;
    }
}