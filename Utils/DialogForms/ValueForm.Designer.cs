// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.DialogForms
{
    partial class ValueForm
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
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.label_Type = new System.Windows.Forms.Label();
            this.checkBox_Array = new System.Windows.Forms.CheckBox();
            this.label_Length = new System.Windows.Forms.Label();
            this.tabControl_Value = new System.Windows.Forms.TabControl();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.spinEdit_Length = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Length.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(60, 47);
            this.comboBox_Type.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(236, 24);
            this.comboBox_Type.TabIndex = 2;
            this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(11, 52);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(44, 17);
            this.label_Type.TabIndex = 9;
            this.label_Type.Text = "Type:";
            // 
            // checkBox_Array
            // 
            this.checkBox_Array.AutoSize = true;
            this.checkBox_Array.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_Array.Location = new System.Drawing.Point(11, 14);
            this.checkBox_Array.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Array.Name = "checkBox_Array";
            this.checkBox_Array.Size = new System.Drawing.Size(64, 21);
            this.checkBox_Array.TabIndex = 0;
            this.checkBox_Array.Text = "Array";
            this.checkBox_Array.UseVisualStyleBackColor = true;
            this.checkBox_Array.CheckedChanged += new System.EventHandler(this.checkBox_Array_CheckedChanged);
            // 
            // label_Length
            // 
            this.label_Length.AutoSize = true;
            this.label_Length.Location = new System.Drawing.Point(113, 16);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(56, 17);
            this.label_Length.TabIndex = 12;
            this.label_Length.Text = "Length:";
            // 
            // tabControl_Value
            // 
            this.tabControl_Value.Location = new System.Drawing.Point(3, 79);
            this.tabControl_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl_Value.Name = "tabControl_Value";
            this.tabControl_Value.SelectedIndex = 0;
            this.tabControl_Value.Size = new System.Drawing.Size(300, 85);
            this.tabControl_Value.TabIndex = 3;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(59, 169);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // spinEdit_Length
            // 
            this.spinEdit_Length.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Length.Location = new System.Drawing.Point(177, 12);
            this.spinEdit_Length.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spinEdit_Length.Name = "spinEdit_Length";
            this.spinEdit_Length.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Length.Properties.IsFloatValue = false;
            this.spinEdit_Length.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Length.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Length.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Length.Properties.Mask.EditMask = "N00";
            this.spinEdit_Length.Properties.MaxValue = new decimal(new int[] {
            217483647,
            0,
            0,
            0});
            this.spinEdit_Length.Size = new System.Drawing.Size(119, 24);
            this.spinEdit_Length.TabIndex = 1;
            this.spinEdit_Length.EditValueChanged += new System.EventHandler(this.spinEdit_Length_EditValueChanged);
            // 
            // ValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 203);
            this.ControlBox = false;
            this.Controls.Add(this.spinEdit_Length);
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.tabControl_Value);
            this.Controls.Add(this.label_Length);
            this.Controls.Add(this.checkBox_Array);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.label_Type);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValueForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ValueForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ValueForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Length.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Type;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.CheckBox checkBox_Array;
        private System.Windows.Forms.Label label_Length;
        private System.Windows.Forms.TabControl tabControl_Value;
        private SpecialControls.OKCancelButton okCancelButton;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Length;
    }
}