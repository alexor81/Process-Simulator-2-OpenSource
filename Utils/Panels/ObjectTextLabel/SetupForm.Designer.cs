// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.ObjectTextLabel
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
            this.colorEdit_BackColor = new DevExpress.XtraEditors.ColorEdit();
            this.label_BackColor = new System.Windows.Forms.Label();
            this.colorEdit_TextColor = new DevExpress.XtraEditors.ColorEdit();
            this.label_TextColor = new System.Windows.Forms.Label();
            this.label_Font = new System.Windows.Forms.Label();
            this.buttonEdit_Font = new DevExpress.XtraEditors.ButtonEdit();
            this.button_Size = new System.Windows.Forms.Button();
            this.checkBox_AutoResize = new System.Windows.Forms.CheckBox();
            this.label_Format = new System.Windows.Forms.Label();
            this.textBox_Format = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BackColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_TextColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colorEdit_BackColor
            // 
            this.colorEdit_BackColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_BackColor.Location = new System.Drawing.Point(96, 76);
            this.colorEdit_BackColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_BackColor.Name = "colorEdit_BackColor";
            this.colorEdit_BackColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_BackColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_BackColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_BackColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_BackColor.Size = new System.Drawing.Size(261, 24);
            this.colorEdit_BackColor.TabIndex = 2;
            this.colorEdit_BackColor.ColorChanged += new System.EventHandler(this.colorEdit_BackColor_ColorChanged);
            // 
            // label_BackColor
            // 
            this.label_BackColor.AutoSize = true;
            this.label_BackColor.Location = new System.Drawing.Point(9, 76);
            this.label_BackColor.Name = "label_BackColor";
            this.label_BackColor.Size = new System.Drawing.Size(80, 17);
            this.label_BackColor.TabIndex = 40;
            this.label_BackColor.Text = "Back Color:";
            // 
            // colorEdit_TextColor
            // 
            this.colorEdit_TextColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_TextColor.Location = new System.Drawing.Point(96, 42);
            this.colorEdit_TextColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_TextColor.Name = "colorEdit_TextColor";
            this.colorEdit_TextColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_TextColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_TextColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_TextColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_TextColor.Size = new System.Drawing.Size(261, 24);
            this.colorEdit_TextColor.TabIndex = 1;
            this.colorEdit_TextColor.ColorChanged += new System.EventHandler(this.colorEdit_TextColor_ColorChanged);
            // 
            // label_TextColor
            // 
            this.label_TextColor.AutoSize = true;
            this.label_TextColor.Location = new System.Drawing.Point(13, 45);
            this.label_TextColor.Name = "label_TextColor";
            this.label_TextColor.Size = new System.Drawing.Size(76, 17);
            this.label_TextColor.TabIndex = 38;
            this.label_TextColor.Text = "Text Color:";
            // 
            // label_Font
            // 
            this.label_Font.AutoSize = true;
            this.label_Font.Location = new System.Drawing.Point(49, 14);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(40, 17);
            this.label_Font.TabIndex = 42;
            this.label_Font.Text = "Font:";
            // 
            // buttonEdit_Font
            // 
            this.buttonEdit_Font.Location = new System.Drawing.Point(96, 7);
            this.buttonEdit_Font.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_Font.Name = "buttonEdit_Font";
            this.buttonEdit_Font.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_Font.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_Font.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_Font.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Font.Properties.ReadOnly = true;
            this.buttonEdit_Font.Size = new System.Drawing.Size(261, 24);
            this.buttonEdit_Font.TabIndex = 0;
            this.buttonEdit_Font.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Font_ButtonClick);
            // 
            // button_Size
            // 
            this.button_Size.Location = new System.Drawing.Point(164, 106);
            this.button_Size.Margin = new System.Windows.Forms.Padding(4);
            this.button_Size.Name = "button_Size";
            this.button_Size.Size = new System.Drawing.Size(131, 28);
            this.button_Size.TabIndex = 4;
            this.button_Size.Text = "Resize to content";
            this.button_Size.UseVisualStyleBackColor = true;
            this.button_Size.Click += new System.EventHandler(this.button_Size_Click);
            // 
            // checkBox_AutoResize
            // 
            this.checkBox_AutoResize.AutoSize = true;
            this.checkBox_AutoResize.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_AutoResize.Location = new System.Drawing.Point(12, 107);
            this.checkBox_AutoResize.Name = "checkBox_AutoResize";
            this.checkBox_AutoResize.Size = new System.Drawing.Size(101, 21);
            this.checkBox_AutoResize.TabIndex = 3;
            this.checkBox_AutoResize.Text = "Auto resize";
            this.checkBox_AutoResize.UseVisualStyleBackColor = true;
            this.checkBox_AutoResize.CheckedChanged += new System.EventHandler(this.checkBox_AutoResize_CheckedChanged);
            // 
            // label_Format
            // 
            this.label_Format.AutoSize = true;
            this.label_Format.Location = new System.Drawing.Point(33, 145);
            this.label_Format.Name = "label_Format";
            this.label_Format.Size = new System.Drawing.Size(56, 17);
            this.label_Format.TabIndex = 43;
            this.label_Format.Text = "Format:";
            // 
            // textBox_Format
            // 
            this.textBox_Format.Location = new System.Drawing.Point(96, 142);
            this.textBox_Format.Name = "textBox_Format";
            this.textBox_Format.Size = new System.Drawing.Size(261, 22);
            this.textBox_Format.TabIndex = 5;
            this.textBox_Format.TextChanged += new System.EventHandler(this.textBox_Format_TextChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 180);
            this.Controls.Add(this.textBox_Format);
            this.Controls.Add(this.label_Format);
            this.Controls.Add(this.checkBox_AutoResize);
            this.Controls.Add(this.button_Size);
            this.Controls.Add(this.buttonEdit_Font);
            this.Controls.Add(this.label_Font);
            this.Controls.Add(this.colorEdit_BackColor);
            this.Controls.Add(this.label_BackColor);
            this.Controls.Add(this.colorEdit_TextColor);
            this.Controls.Add(this.label_TextColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text Label";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BackColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_TextColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ColorEdit colorEdit_BackColor;
        private System.Windows.Forms.Label label_BackColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_TextColor;
        private System.Windows.Forms.Label label_TextColor;
        private System.Windows.Forms.Label label_Font;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Font;
        private System.Windows.Forms.Button button_Size;
        private System.Windows.Forms.CheckBox checkBox_AutoResize;
        private System.Windows.Forms.Label label_Format;
        private System.Windows.Forms.TextBox textBox_Format;
    }
}