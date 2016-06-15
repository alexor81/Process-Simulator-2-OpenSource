namespace Connection.S7PLCSim
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
            this.label_S7PlcSimInstNum = new System.Windows.Forms.Label();
            this.groupBox_S7PLCSim = new System.Windows.Forms.GroupBox();
            this.spinEdit_InstNum = new DevExpress.XtraEditors.SpinEdit();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider();
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.label_WriteRequests = new System.Windows.Forms.Label();
            this.label_WR = new System.Windows.Forms.Label();
            this.label_CycleTime = new System.Windows.Forms.Label();
            this.label_CTime = new System.Windows.Forms.Label();
            this.spinEdit_Slowing = new DevExpress.XtraEditors.SpinEdit();
            this.label_Slowdown = new System.Windows.Forms.Label();
            this.checkBox_CScan = new System.Windows.Forms.CheckBox();
            this.groupBox_Items = new System.Windows.Forms.GroupBox();
            this.label_CountN = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_S7PLCSim.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_InstNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Slowing.Properties)).BeginInit();
            this.groupBox_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_S7PlcSimInstNum
            // 
            this.label_S7PlcSimInstNum.AutoSize = true;
            this.label_S7PlcSimInstNum.Location = new System.Drawing.Point(79, 24);
            this.label_S7PlcSimInstNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_S7PlcSimInstNum.Name = "label_S7PlcSimInstNum";
            this.label_S7PlcSimInstNum.Size = new System.Drawing.Size(119, 17);
            this.label_S7PlcSimInstNum.TabIndex = 0;
            this.label_S7PlcSimInstNum.Text = "Instance Number:";
            // 
            // groupBox_S7PLCSim
            // 
            this.groupBox_S7PLCSim.Controls.Add(this.spinEdit_InstNum);
            this.groupBox_S7PLCSim.Controls.Add(this.button_Disconnect);
            this.groupBox_S7PLCSim.Controls.Add(this.button_Connect);
            this.groupBox_S7PLCSim.Controls.Add(this.label_S7PlcSimInstNum);
            this.groupBox_S7PLCSim.Location = new System.Drawing.Point(9, 1);
            this.groupBox_S7PLCSim.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_S7PLCSim.Name = "groupBox_S7PLCSim";
            this.groupBox_S7PLCSim.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_S7PLCSim.Size = new System.Drawing.Size(345, 90);
            this.groupBox_S7PLCSim.TabIndex = 0;
            this.groupBox_S7PLCSim.TabStop = false;
            this.groupBox_S7PLCSim.Text = "Instance";
            // 
            // spinEdit_InstNum
            // 
            this.spinEdit_InstNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_InstNum.Location = new System.Drawing.Point(207, 19);
            this.spinEdit_InstNum.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_InstNum.Name = "spinEdit_InstNum";
            this.spinEdit_InstNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_InstNum.Properties.IsFloatValue = false;
            this.spinEdit_InstNum.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_InstNum.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_InstNum.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_InstNum.Properties.Mask.EditMask = "N00";
            this.spinEdit_InstNum.Properties.MaxValue = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.spinEdit_InstNum.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_InstNum.Size = new System.Drawing.Size(59, 24);
            this.spinEdit_InstNum.TabIndex = 0;
            this.spinEdit_InstNum.EditValueChanged += new System.EventHandler(this.spinEdit_InstNum_EditValueChanged);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(177, 54);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(105, 27);
            this.button_Disconnect.TabIndex = 2;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(63, 54);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(105, 27);
            this.button_Connect.TabIndex = 1;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.Controls.Add(this.label_WriteRequests);
            this.groupBox_Options.Controls.Add(this.label_WR);
            this.groupBox_Options.Controls.Add(this.label_CycleTime);
            this.groupBox_Options.Controls.Add(this.label_CTime);
            this.groupBox_Options.Controls.Add(this.spinEdit_Slowing);
            this.groupBox_Options.Controls.Add(this.label_Slowdown);
            this.groupBox_Options.Controls.Add(this.checkBox_CScan);
            this.groupBox_Options.Location = new System.Drawing.Point(9, 99);
            this.groupBox_Options.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Options.Size = new System.Drawing.Size(345, 131);
            this.groupBox_Options.TabIndex = 1;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Options";
            // 
            // label_WriteRequests
            // 
            this.label_WriteRequests.AutoSize = true;
            this.label_WriteRequests.Location = new System.Drawing.Point(223, 106);
            this.label_WriteRequests.Name = "label_WriteRequests";
            this.label_WriteRequests.Size = new System.Drawing.Size(16, 17);
            this.label_WriteRequests.TabIndex = 16;
            this.label_WriteRequests.Text = "0";
            this.label_WriteRequests.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_WR
            // 
            this.label_WR.AutoSize = true;
            this.label_WR.Location = new System.Drawing.Point(112, 106);
            this.label_WR.Name = "label_WR";
            this.label_WR.Size = new System.Drawing.Size(104, 17);
            this.label_WR.TabIndex = 15;
            this.label_WR.Text = "Write requests:";
            // 
            // label_CycleTime
            // 
            this.label_CycleTime.AutoSize = true;
            this.label_CycleTime.Location = new System.Drawing.Point(105, 79);
            this.label_CycleTime.Name = "label_CycleTime";
            this.label_CycleTime.Size = new System.Drawing.Size(111, 17);
            this.label_CycleTime.TabIndex = 14;
            this.label_CycleTime.Text = "Cycle Time [ms]:";
            this.label_CycleTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_CTime
            // 
            this.label_CTime.AutoSize = true;
            this.label_CTime.Location = new System.Drawing.Point(223, 79);
            this.label_CTime.Name = "label_CTime";
            this.label_CTime.Size = new System.Drawing.Size(16, 17);
            this.label_CTime.TabIndex = 13;
            this.label_CTime.Text = "0";
            this.label_CTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spinEdit_Slowing
            // 
            this.spinEdit_Slowing.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Slowing.Location = new System.Drawing.Point(166, 47);
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
            this.spinEdit_Slowing.TabIndex = 1;
            this.spinEdit_Slowing.EditValueChanged += new System.EventHandler(this.spinEdit_Slowing_EditValueChanged);
            // 
            // label_Slowdown
            // 
            this.label_Slowdown.AutoSize = true;
            this.label_Slowdown.Location = new System.Drawing.Point(86, 51);
            this.label_Slowdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Slowdown.Name = "label_Slowdown";
            this.label_Slowdown.Size = new System.Drawing.Size(74, 17);
            this.label_Slowdown.TabIndex = 6;
            this.label_Slowdown.Text = "Slowdown:";
            // 
            // checkBox_CScan
            // 
            this.checkBox_CScan.AutoSize = true;
            this.checkBox_CScan.Location = new System.Drawing.Point(25, 20);
            this.checkBox_CScan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_CScan.Name = "checkBox_CScan";
            this.checkBox_CScan.Size = new System.Drawing.Size(284, 21);
            this.checkBox_CScan.TabIndex = 0;
            this.checkBox_CScan.Text = "Switch on continuous scan after connect";
            this.checkBox_CScan.UseVisualStyleBackColor = true;
            this.checkBox_CScan.CheckedChanged += new System.EventHandler(this.checkBox_CScan_CheckedChanged);
            // 
            // groupBox_Items
            // 
            this.groupBox_Items.Controls.Add(this.label_CountN);
            this.groupBox_Items.Controls.Add(this.label_Count);
            this.groupBox_Items.Location = new System.Drawing.Point(9, 236);
            this.groupBox_Items.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Name = "groupBox_Items";
            this.groupBox_Items.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Size = new System.Drawing.Size(345, 43);
            this.groupBox_Items.TabIndex = 2;
            this.groupBox_Items.TabStop = false;
            this.groupBox_Items.Text = "Items";
            // 
            // label_CountN
            // 
            this.label_CountN.AutoSize = true;
            this.label_CountN.Location = new System.Drawing.Point(191, 16);
            this.label_CountN.Name = "label_CountN";
            this.label_CountN.Size = new System.Drawing.Size(16, 17);
            this.label_CountN.TabIndex = 1;
            this.label_CountN.Text = "0";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(136, 16);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(49, 17);
            this.label_Count.TabIndex = 0;
            this.label_Count.Text = "Count:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(87, 286);
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
            this.ClientSize = new System.Drawing.Size(362, 324);
            this.ControlBox = false;
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.groupBox_Items);
            this.Controls.Add(this.groupBox_Options);
            this.Controls.Add(this.groupBox_S7PLCSim);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "S7PLCSim Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConnectionSetupForm_KeyDown);
            this.groupBox_S7PLCSim.ResumeLayout(false);
            this.groupBox_S7PLCSim.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_InstNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Slowing.Properties)).EndInit();
            this.groupBox_Items.ResumeLayout(false);
            this.groupBox_Items.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_S7PlcSimInstNum;
        private System.Windows.Forms.GroupBox groupBox_S7PLCSim;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox_Options;
        private System.Windows.Forms.CheckBox checkBox_CScan;
        private System.Windows.Forms.Label label_Slowdown;
        private System.Windows.Forms.Label label_CTime;
        private System.Windows.Forms.Label label_CycleTime;
        private System.Windows.Forms.GroupBox groupBox_Items;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.Label label_CountN;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Slowing;
        private DevExpress.XtraEditors.SpinEdit spinEdit_InstNum;
        private System.Windows.Forms.Label label_WriteRequests;
        private System.Windows.Forms.Label label_WR;
    }
}