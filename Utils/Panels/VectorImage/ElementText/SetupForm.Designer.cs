// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.VectorImage.ElementText
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
            this.spinEdit_Y = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_X = new DevExpress.XtraEditors.SpinEdit();
            this.label_Y = new System.Windows.Forms.Label();
            this.label_X = new System.Windows.Forms.Label();
            this.buttonEdit_Font = new DevExpress.XtraEditors.ButtonEdit();
            this.label_Font = new System.Windows.Forms.Label();
            this.textBox_Text = new System.Windows.Forms.TextBox();
            this.label_Text = new System.Windows.Forms.Label();
            this.colorEdit_Color = new DevExpress.XtraEditors.ColorEdit();
            this.label_Color = new System.Windows.Forms.Label();
            this.comboBox_Rotate = new System.Windows.Forms.ComboBox();
            this.label_Rotate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Y.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_X.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Color.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEdit_Y
            // 
            this.spinEdit_Y.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Y.Location = new System.Drawing.Point(69, 42);
            this.spinEdit_Y.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Y.Name = "spinEdit_Y";
            this.spinEdit_Y.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Y.Properties.IsFloatValue = false;
            this.spinEdit_Y.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Y.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Y.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Y.Properties.Mask.EditMask = "N00";
            this.spinEdit_Y.Size = new System.Drawing.Size(202, 24);
            this.spinEdit_Y.TabIndex = 1;
            this.spinEdit_Y.EditValueChanged += new System.EventHandler(this.spinEdit_Y_EditValueChanged);
            // 
            // spinEdit_X
            // 
            this.spinEdit_X.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_X.Location = new System.Drawing.Point(69, 12);
            this.spinEdit_X.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_X.Name = "spinEdit_X";
            this.spinEdit_X.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_X.Properties.IsFloatValue = false;
            this.spinEdit_X.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_X.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_X.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_X.Properties.Mask.EditMask = "N00";
            this.spinEdit_X.Size = new System.Drawing.Size(202, 24);
            this.spinEdit_X.TabIndex = 0;
            this.spinEdit_X.EditValueChanged += new System.EventHandler(this.spinEdit_X_EditValueChanged);
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(42, 46);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(21, 17);
            this.label_Y.TabIndex = 13;
            this.label_Y.Text = "Y:";
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(42, 16);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(21, 17);
            this.label_X.TabIndex = 12;
            this.label_X.Text = "X:";
            // 
            // buttonEdit_Font
            // 
            this.buttonEdit_Font.Location = new System.Drawing.Point(69, 102);
            this.buttonEdit_Font.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_Font.Name = "buttonEdit_Font";
            this.buttonEdit_Font.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_Font.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_Font.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_Font.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Font.Properties.ReadOnly = true;
            this.buttonEdit_Font.Size = new System.Drawing.Size(202, 24);
            this.buttonEdit_Font.TabIndex = 3;
            this.buttonEdit_Font.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Font_ButtonClick);
            // 
            // label_Font
            // 
            this.label_Font.AutoSize = true;
            this.label_Font.Location = new System.Drawing.Point(23, 106);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(40, 17);
            this.label_Font.TabIndex = 44;
            this.label_Font.Text = "Font:";
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(69, 73);
            this.textBox_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.Size = new System.Drawing.Size(202, 22);
            this.textBox_Text.TabIndex = 2;
            this.textBox_Text.TextChanged += new System.EventHandler(this.textBox_Text_TextChanged);
            // 
            // label_Text
            // 
            this.label_Text.AutoSize = true;
            this.label_Text.Location = new System.Drawing.Point(24, 76);
            this.label_Text.Name = "label_Text";
            this.label_Text.Size = new System.Drawing.Size(39, 17);
            this.label_Text.TabIndex = 46;
            this.label_Text.Text = "Text:";
            // 
            // colorEdit_Color
            // 
            this.colorEdit_Color.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Color.Location = new System.Drawing.Point(69, 132);
            this.colorEdit_Color.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Color.Name = "colorEdit_Color";
            this.colorEdit_Color.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Color.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Color.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Color.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Color.Size = new System.Drawing.Size(202, 24);
            this.colorEdit_Color.TabIndex = 4;
            this.colorEdit_Color.EditValueChanged += new System.EventHandler(this.colorEdit_Color_EditValueChanged);
            // 
            // label_Color
            // 
            this.label_Color.AutoSize = true;
            this.label_Color.Location = new System.Drawing.Point(18, 136);
            this.label_Color.Name = "label_Color";
            this.label_Color.Size = new System.Drawing.Size(45, 17);
            this.label_Color.TabIndex = 48;
            this.label_Color.Text = "Color:";
            // 
            // comboBox_Rotate
            // 
            this.comboBox_Rotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Rotate.FormattingEnabled = true;
            this.comboBox_Rotate.Items.AddRange(new object[] {
            "0",
            "90",
            "180",
            "270"});
            this.comboBox_Rotate.Location = new System.Drawing.Point(69, 162);
            this.comboBox_Rotate.Name = "comboBox_Rotate";
            this.comboBox_Rotate.Size = new System.Drawing.Size(202, 24);
            this.comboBox_Rotate.TabIndex = 5;
            this.comboBox_Rotate.SelectedIndexChanged += new System.EventHandler(this.comboBox_Rotate_SelectedIndexChanged);
            // 
            // label_Rotate
            // 
            this.label_Rotate.AutoSize = true;
            this.label_Rotate.Location = new System.Drawing.Point(9, 166);
            this.label_Rotate.Name = "label_Rotate";
            this.label_Rotate.Size = new System.Drawing.Size(54, 17);
            this.label_Rotate.TabIndex = 50;
            this.label_Rotate.Text = "Rotate:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 199);
            this.Controls.Add(this.comboBox_Rotate);
            this.Controls.Add(this.label_Rotate);
            this.Controls.Add(this.colorEdit_Color);
            this.Controls.Add(this.label_Color);
            this.Controls.Add(this.textBox_Text);
            this.Controls.Add(this.label_Text);
            this.Controls.Add(this.buttonEdit_Font);
            this.Controls.Add(this.label_Font);
            this.Controls.Add(this.spinEdit_Y);
            this.Controls.Add(this.spinEdit_X);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_X);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Y.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_X.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Color.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEdit_Y;
        private DevExpress.XtraEditors.SpinEdit spinEdit_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Label label_X;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Font;
        private System.Windows.Forms.Label label_Font;
        private System.Windows.Forms.TextBox textBox_Text;
        private System.Windows.Forms.Label label_Text;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Color;
        private System.Windows.Forms.Label label_Color;
        private System.Windows.Forms.ComboBox comboBox_Rotate;
        private System.Windows.Forms.Label label_Rotate;
    }
}