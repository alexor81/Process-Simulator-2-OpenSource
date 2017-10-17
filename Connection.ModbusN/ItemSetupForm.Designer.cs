// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.ModbusN
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
            this.label_SlaveID = new System.Windows.Forms.Label();
            this.comboBox_DataType = new System.Windows.Forms.ComboBox();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_Register = new System.Windows.Forms.Label();
            this.comboBox_RegisterType = new System.Windows.Forms.ComboBox();
            this.label_RegisterType = new System.Windows.Forms.Label();
            this.checkBox_SwapWords = new System.Windows.Forms.CheckBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.spinEdit_SlaveID = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Register = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Length = new DevExpress.XtraEditors.SpinEdit();
            this.label_Length = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_SlaveID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Register.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Length.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label_SlaveID
            // 
            this.label_SlaveID.AutoSize = true;
            this.label_SlaveID.Location = new System.Drawing.Point(50, 17);
            this.label_SlaveID.Name = "label_SlaveID";
            this.label_SlaveID.Size = new System.Drawing.Size(64, 17);
            this.label_SlaveID.TabIndex = 50;
            this.label_SlaveID.Text = "Slave ID:";
            // 
            // comboBox_DataType
            // 
            this.comboBox_DataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataType.FormattingEnabled = true;
            this.comboBox_DataType.Location = new System.Drawing.Point(123, 104);
            this.comboBox_DataType.Name = "comboBox_DataType";
            this.comboBox_DataType.Size = new System.Drawing.Size(162, 24);
            this.comboBox_DataType.TabIndex = 3;
            this.comboBox_DataType.SelectedIndexChanged += new System.EventHandler(this.comboBox_DataType_SelectedIndexChanged);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(36, 108);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(78, 17);
            this.label_Type.TabIndex = 63;
            this.label_Type.Text = "Data Type:";
            // 
            // label_Register
            // 
            this.label_Register.AutoSize = true;
            this.label_Register.Location = new System.Drawing.Point(49, 78);
            this.label_Register.Name = "label_Register";
            this.label_Register.Size = new System.Drawing.Size(65, 17);
            this.label_Register.TabIndex = 61;
            this.label_Register.Text = "Register:";
            // 
            // comboBox_RegisterType
            // 
            this.comboBox_RegisterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RegisterType.FormattingEnabled = true;
            this.comboBox_RegisterType.Items.AddRange(new object[] {
            "Coil Bit",
            "Input Bit",
            "Input Register",
            "Holding Register"});
            this.comboBox_RegisterType.Location = new System.Drawing.Point(123, 44);
            this.comboBox_RegisterType.Name = "comboBox_RegisterType";
            this.comboBox_RegisterType.Size = new System.Drawing.Size(162, 24);
            this.comboBox_RegisterType.TabIndex = 1;
            this.comboBox_RegisterType.SelectedIndexChanged += new System.EventHandler(this.comboBox_RegisterType_SelectedIndexChanged);
            // 
            // label_RegisterType
            // 
            this.label_RegisterType.AutoSize = true;
            this.label_RegisterType.Location = new System.Drawing.Point(13, 48);
            this.label_RegisterType.Name = "label_RegisterType";
            this.label_RegisterType.Size = new System.Drawing.Size(101, 17);
            this.label_RegisterType.TabIndex = 59;
            this.label_RegisterType.Text = "Register Type:";
            // 
            // checkBox_SwapWords
            // 
            this.checkBox_SwapWords.AutoSize = true;
            this.checkBox_SwapWords.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_SwapWords.Location = new System.Drawing.Point(31, 134);
            this.checkBox_SwapWords.Name = "checkBox_SwapWords";
            this.checkBox_SwapWords.Size = new System.Drawing.Size(109, 21);
            this.checkBox_SwapWords.TabIndex = 4;
            this.checkBox_SwapWords.Text = "Swap Words";
            this.checkBox_SwapWords.UseVisualStyleBackColor = true;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(55, 193);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 6;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // spinEdit_SlaveID
            // 
            this.spinEdit_SlaveID.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_SlaveID.Location = new System.Drawing.Point(123, 13);
            this.spinEdit_SlaveID.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_SlaveID.Name = "spinEdit_SlaveID";
            this.spinEdit_SlaveID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_SlaveID.Properties.IsFloatValue = false;
            this.spinEdit_SlaveID.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_SlaveID.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_SlaveID.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_SlaveID.Properties.Mask.EditMask = "N00";
            this.spinEdit_SlaveID.Properties.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spinEdit_SlaveID.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_SlaveID.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_SlaveID.TabIndex = 0;
            // 
            // spinEdit_Register
            // 
            this.spinEdit_Register.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Register.Location = new System.Drawing.Point(123, 74);
            this.spinEdit_Register.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Register.Name = "spinEdit_Register";
            this.spinEdit_Register.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Register.Properties.IsFloatValue = false;
            this.spinEdit_Register.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Register.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Register.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Register.Properties.Mask.EditMask = "N00";
            this.spinEdit_Register.Properties.MaxValue = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.spinEdit_Register.Size = new System.Drawing.Size(161, 24);
            this.spinEdit_Register.TabIndex = 2;
            // 
            // spinEdit_Length
            // 
            this.spinEdit_Length.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Length.Location = new System.Drawing.Point(124, 161);
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
            65535,
            0,
            0,
            0});
            this.spinEdit_Length.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_Length.Size = new System.Drawing.Size(92, 24);
            this.spinEdit_Length.TabIndex = 5;
            // 
            // label_Length
            // 
            this.label_Length.AutoSize = true;
            this.label_Length.Location = new System.Drawing.Point(58, 165);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(56, 17);
            this.label_Length.TabIndex = 65;
            this.label_Length.Text = "Length:";
            // 
            // ItemSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 230);
            this.ControlBox = false;
            this.Controls.Add(this.spinEdit_Length);
            this.Controls.Add(this.label_Length);
            this.Controls.Add(this.spinEdit_Register);
            this.Controls.Add(this.spinEdit_SlaveID);
            this.Controls.Add(this.comboBox_DataType);
            this.Controls.Add(this.label_Type);
            this.Controls.Add(this.label_Register);
            this.Controls.Add(this.comboBox_RegisterType);
            this.Controls.Add(this.label_RegisterType);
            this.Controls.Add(this.checkBox_SwapWords);
            this.Controls.Add(this.label_SlaveID);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modbus Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ItemSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_SlaveID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Register.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Length.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_SlaveID;
        private System.Windows.Forms.ComboBox comboBox_DataType;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.Label label_Register;
        private System.Windows.Forms.ComboBox comboBox_RegisterType;
        private System.Windows.Forms.Label label_RegisterType;
        private System.Windows.Forms.CheckBox checkBox_SwapWords;
        private DevExpress.XtraEditors.SpinEdit spinEdit_SlaveID;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Register;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Length;
        private System.Windows.Forms.Label label_Length;
    }
}