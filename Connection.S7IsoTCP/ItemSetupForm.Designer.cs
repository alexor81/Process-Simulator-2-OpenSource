namespace Connection.S7IsoTCP
{
    partial class ItemSetupForm
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
            this.comboBox_MemoryType = new System.Windows.Forms.ComboBox();
            this.label_MemType = new System.Windows.Forms.Label();
            this.spinEdit_Bit = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Byte = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_DBNum = new DevExpress.XtraEditors.SpinEdit();
            this.label_DB = new System.Windows.Forms.Label();
            this.label_Bit = new System.Windows.Forms.Label();
            this.label_Byte = new System.Windows.Forms.Label();
            this.spinEdit_Length = new DevExpress.XtraEditors.SpinEdit();
            this.label_Length = new System.Windows.Forms.Label();
            this.checkBox_Signed = new System.Windows.Forms.CheckBox();
            this.comboBox_DataType = new System.Windows.Forms.ComboBox();
            this.label_DataType = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.checkBox_FloatingP = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Bit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Byte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_DBNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Length.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_MemoryType
            // 
            this.comboBox_MemoryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MemoryType.FormattingEnabled = true;
            this.comboBox_MemoryType.Items.AddRange(new object[] {
            "I",
            "Q",
            "M",
            "DB"});
            this.comboBox_MemoryType.Location = new System.Drawing.Point(140, 7);
            this.comboBox_MemoryType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_MemoryType.Name = "comboBox_MemoryType";
            this.comboBox_MemoryType.Size = new System.Drawing.Size(89, 24);
            this.comboBox_MemoryType.TabIndex = 0;
            this.comboBox_MemoryType.SelectedIndexChanged += new System.EventHandler(this.comboBox_MemoryType_SelectedIndexChanged);
            // 
            // label_MemType
            // 
            this.label_MemType.AutoSize = true;
            this.label_MemType.Location = new System.Drawing.Point(33, 11);
            this.label_MemType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_MemType.Name = "label_MemType";
            this.label_MemType.Size = new System.Drawing.Size(98, 17);
            this.label_MemType.TabIndex = 34;
            this.label_MemType.Text = "Memory Type:";
            // 
            // spinEdit_Bit
            // 
            this.spinEdit_Bit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Bit.Location = new System.Drawing.Point(140, 97);
            this.spinEdit_Bit.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Bit.Name = "spinEdit_Bit";
            this.spinEdit_Bit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Bit.Properties.IsFloatValue = false;
            this.spinEdit_Bit.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Bit.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Bit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Bit.Properties.Mask.EditMask = "N00";
            this.spinEdit_Bit.Properties.MaxValue = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.spinEdit_Bit.Size = new System.Drawing.Size(91, 24);
            this.spinEdit_Bit.TabIndex = 3;
            // 
            // spinEdit_Byte
            // 
            this.spinEdit_Byte.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Byte.Location = new System.Drawing.Point(140, 67);
            this.spinEdit_Byte.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Byte.Name = "spinEdit_Byte";
            this.spinEdit_Byte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Byte.Properties.IsFloatValue = false;
            this.spinEdit_Byte.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Byte.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Byte.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Byte.Properties.Mask.EditMask = "N00";
            this.spinEdit_Byte.Properties.MaxValue = new decimal(new int[] {
            65569,
            0,
            0,
            0});
            this.spinEdit_Byte.Size = new System.Drawing.Size(91, 24);
            this.spinEdit_Byte.TabIndex = 2;
            // 
            // spinEdit_DBNum
            // 
            this.spinEdit_DBNum.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_DBNum.Location = new System.Drawing.Point(140, 37);
            this.spinEdit_DBNum.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_DBNum.Name = "spinEdit_DBNum";
            this.spinEdit_DBNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_DBNum.Properties.IsFloatValue = false;
            this.spinEdit_DBNum.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_DBNum.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_DBNum.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_DBNum.Properties.Mask.EditMask = "N00";
            this.spinEdit_DBNum.Properties.MaxValue = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinEdit_DBNum.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_DBNum.Size = new System.Drawing.Size(91, 24);
            this.spinEdit_DBNum.TabIndex = 1;
            // 
            // label_DB
            // 
            this.label_DB.AutoSize = true;
            this.label_DB.Location = new System.Drawing.Point(46, 41);
            this.label_DB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DB.Name = "label_DB";
            this.label_DB.Size = new System.Drawing.Size(85, 17);
            this.label_DB.TabIndex = 46;
            this.label_DB.Text = "DB Number:";
            // 
            // label_Bit
            // 
            this.label_Bit.AutoSize = true;
            this.label_Bit.Location = new System.Drawing.Point(103, 101);
            this.label_Bit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Bit.Name = "label_Bit";
            this.label_Bit.Size = new System.Drawing.Size(28, 17);
            this.label_Bit.TabIndex = 45;
            this.label_Bit.Text = "Bit:";
            // 
            // label_Byte
            // 
            this.label_Byte.AutoSize = true;
            this.label_Byte.Location = new System.Drawing.Point(91, 71);
            this.label_Byte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Byte.Name = "label_Byte";
            this.label_Byte.Size = new System.Drawing.Size(40, 17);
            this.label_Byte.TabIndex = 44;
            this.label_Byte.Text = "Byte:";
            // 
            // spinEdit_Length
            // 
            this.spinEdit_Length.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Length.Location = new System.Drawing.Point(140, 218);
            this.spinEdit_Length.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Length.Name = "spinEdit_Length";
            this.spinEdit_Length.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Length.Properties.IsFloatValue = false;
            this.spinEdit_Length.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Length.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Length.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Length.Properties.Mask.EditMask = "N00";
            this.spinEdit_Length.Properties.MaxValue = new decimal(new int[] {
            16348,
            0,
            0,
            0});
            this.spinEdit_Length.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Length.Size = new System.Drawing.Size(92, 24);
            this.spinEdit_Length.TabIndex = 7;
            // 
            // label_Length
            // 
            this.label_Length.AutoSize = true;
            this.label_Length.Location = new System.Drawing.Point(75, 222);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(56, 17);
            this.label_Length.TabIndex = 72;
            this.label_Length.Text = "Length:";
            // 
            // checkBox_Signed
            // 
            this.checkBox_Signed.AutoSize = true;
            this.checkBox_Signed.Enabled = false;
            this.checkBox_Signed.Location = new System.Drawing.Point(85, 161);
            this.checkBox_Signed.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Signed.Name = "checkBox_Signed";
            this.checkBox_Signed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Signed.Size = new System.Drawing.Size(74, 21);
            this.checkBox_Signed.TabIndex = 5;
            this.checkBox_Signed.Text = "Signed";
            this.checkBox_Signed.UseVisualStyleBackColor = true;
            // 
            // comboBox_DataType
            // 
            this.comboBox_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataType.FormattingEnabled = true;
            this.comboBox_DataType.Items.AddRange(new object[] {
            "S7_Bit",
            "S7_Byte",
            "S7_Word",
            "S7_DoubleWord"});
            this.comboBox_DataType.Location = new System.Drawing.Point(140, 127);
            this.comboBox_DataType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_DataType.Name = "comboBox_DataType";
            this.comboBox_DataType.Size = new System.Drawing.Size(144, 24);
            this.comboBox_DataType.TabIndex = 4;
            this.comboBox_DataType.SelectedIndexChanged += new System.EventHandler(this.comboBox_DataType_SelectedIndexChanged);
            // 
            // label_DataType
            // 
            this.label_DataType.AutoSize = true;
            this.label_DataType.Location = new System.Drawing.Point(53, 131);
            this.label_DataType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DataType.Name = "label_DataType";
            this.label_DataType.Size = new System.Drawing.Size(78, 17);
            this.label_DataType.TabIndex = 70;
            this.label_DataType.Text = "Data Type:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(66, 248);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 8;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // checkBox_FloatingP
            // 
            this.checkBox_FloatingP.AutoSize = true;
            this.checkBox_FloatingP.Enabled = false;
            this.checkBox_FloatingP.Location = new System.Drawing.Point(43, 189);
            this.checkBox_FloatingP.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_FloatingP.Name = "checkBox_FloatingP";
            this.checkBox_FloatingP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_FloatingP.Size = new System.Drawing.Size(116, 21);
            this.checkBox_FloatingP.TabIndex = 6;
            this.checkBox_FloatingP.Text = "Floating Point";
            this.checkBox_FloatingP.UseVisualStyleBackColor = true;
            this.checkBox_FloatingP.CheckedChanged += new System.EventHandler(this.checkBox_FloatingP_CheckedChanged);
            // 
            // ItemSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 286);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_FloatingP);
            this.Controls.Add(this.spinEdit_Length);
            this.Controls.Add(this.label_Length);
            this.Controls.Add(this.checkBox_Signed);
            this.Controls.Add(this.comboBox_DataType);
            this.Controls.Add(this.label_DataType);
            this.Controls.Add(this.spinEdit_Bit);
            this.Controls.Add(this.spinEdit_Byte);
            this.Controls.Add(this.spinEdit_DBNum);
            this.Controls.Add(this.label_DB);
            this.Controls.Add(this.label_Bit);
            this.Controls.Add(this.label_Byte);
            this.Controls.Add(this.comboBox_MemoryType);
            this.Controls.Add(this.label_MemType);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "S7IsoTCP Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ItemSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Bit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Byte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_DBNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Length.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.ComboBox comboBox_MemoryType;
        private System.Windows.Forms.Label label_MemType;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Bit;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Byte;
        private DevExpress.XtraEditors.SpinEdit spinEdit_DBNum;
        private System.Windows.Forms.Label label_DB;
        private System.Windows.Forms.Label label_Bit;
        private System.Windows.Forms.Label label_Byte;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Length;
        private System.Windows.Forms.Label label_Length;
        private System.Windows.Forms.CheckBox checkBox_Signed;
        private System.Windows.Forms.ComboBox comboBox_DataType;
        private System.Windows.Forms.Label label_DataType;
        private System.Windows.Forms.CheckBox checkBox_FloatingP;
    }
}