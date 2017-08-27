// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.TextLabel
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
            this.textBox_Text = new System.Windows.Forms.TextBox();
            this.label_LabelText = new System.Windows.Forms.Label();
            this.colorEdit_BackColor = new DevExpress.XtraEditors.ColorEdit();
            this.label_BackColor = new System.Windows.Forms.Label();
            this.colorEdit_TextColor = new DevExpress.XtraEditors.ColorEdit();
            this.label_TextColor = new System.Windows.Forms.Label();
            this.label_Font = new System.Windows.Forms.Label();
            this.buttonEdit_Font = new DevExpress.XtraEditors.ButtonEdit();
            this.button_Fit = new System.Windows.Forms.Button();
            this.label_Rotate = new System.Windows.Forms.Label();
            this.comboBox_Rotate = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BackColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_TextColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(99, 12);
            this.textBox_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.Size = new System.Drawing.Size(260, 22);
            this.textBox_Text.TabIndex = 0;
            this.textBox_Text.TextChanged += new System.EventHandler(this.textBox_Text_TextChanged);
            // 
            // label_LabelText
            // 
            this.label_LabelText.AutoSize = true;
            this.label_LabelText.Location = new System.Drawing.Point(52, 15);
            this.label_LabelText.Name = "label_LabelText";
            this.label_LabelText.Size = new System.Drawing.Size(39, 17);
            this.label_LabelText.TabIndex = 6;
            this.label_LabelText.Text = "Text:";
            // 
            // colorEdit_BackColor
            // 
            this.colorEdit_BackColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_BackColor.Location = new System.Drawing.Point(99, 113);
            this.colorEdit_BackColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_BackColor.Name = "colorEdit_BackColor";
            this.colorEdit_BackColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_BackColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_BackColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_BackColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_BackColor.Size = new System.Drawing.Size(261, 24);
            this.colorEdit_BackColor.TabIndex = 3;
            this.colorEdit_BackColor.ColorChanged += new System.EventHandler(this.colorEdit_BackColor_ColorChanged);
            // 
            // label_BackColor
            // 
            this.label_BackColor.AutoSize = true;
            this.label_BackColor.Location = new System.Drawing.Point(11, 117);
            this.label_BackColor.Name = "label_BackColor";
            this.label_BackColor.Size = new System.Drawing.Size(80, 17);
            this.label_BackColor.TabIndex = 40;
            this.label_BackColor.Text = "Back Color:";
            // 
            // colorEdit_TextColor
            // 
            this.colorEdit_TextColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_TextColor.Location = new System.Drawing.Point(99, 79);
            this.colorEdit_TextColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_TextColor.Name = "colorEdit_TextColor";
            this.colorEdit_TextColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_TextColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_TextColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_TextColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_TextColor.Size = new System.Drawing.Size(261, 24);
            this.colorEdit_TextColor.TabIndex = 2;
            this.colorEdit_TextColor.ColorChanged += new System.EventHandler(this.colorEdit_TextColor_ColorChanged);
            // 
            // label_TextColor
            // 
            this.label_TextColor.AutoSize = true;
            this.label_TextColor.Location = new System.Drawing.Point(15, 83);
            this.label_TextColor.Name = "label_TextColor";
            this.label_TextColor.Size = new System.Drawing.Size(76, 17);
            this.label_TextColor.TabIndex = 38;
            this.label_TextColor.Text = "Text Color:";
            // 
            // label_Font
            // 
            this.label_Font.AutoSize = true;
            this.label_Font.Location = new System.Drawing.Point(51, 49);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(40, 17);
            this.label_Font.TabIndex = 42;
            this.label_Font.Text = "Font:";
            // 
            // buttonEdit_Font
            // 
            this.buttonEdit_Font.Location = new System.Drawing.Point(99, 45);
            this.buttonEdit_Font.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_Font.Name = "buttonEdit_Font";
            this.buttonEdit_Font.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_Font.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_Font.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_Font.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Font.Properties.ReadOnly = true;
            this.buttonEdit_Font.Size = new System.Drawing.Size(261, 24);
            this.buttonEdit_Font.TabIndex = 1;
            this.buttonEdit_Font.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Font_ButtonClick);
            // 
            // button_Fit
            // 
            this.button_Fit.Location = new System.Drawing.Point(120, 188);
            this.button_Fit.Margin = new System.Windows.Forms.Padding(4);
            this.button_Fit.Name = "button_Fit";
            this.button_Fit.Size = new System.Drawing.Size(131, 28);
            this.button_Fit.TabIndex = 5;
            this.button_Fit.Text = "Fit to content";
            this.button_Fit.UseVisualStyleBackColor = true;
            this.button_Fit.Click += new System.EventHandler(this.button_Fit_Click);
            // 
            // label_Rotate
            // 
            this.label_Rotate.AutoSize = true;
            this.label_Rotate.Location = new System.Drawing.Point(37, 151);
            this.label_Rotate.Name = "label_Rotate";
            this.label_Rotate.Size = new System.Drawing.Size(54, 17);
            this.label_Rotate.TabIndex = 43;
            this.label_Rotate.Text = "Rotate:";
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
            this.comboBox_Rotate.Location = new System.Drawing.Point(99, 147);
            this.comboBox_Rotate.Name = "comboBox_Rotate";
            this.comboBox_Rotate.Size = new System.Drawing.Size(263, 24);
            this.comboBox_Rotate.TabIndex = 4;
            this.comboBox_Rotate.SelectedIndexChanged += new System.EventHandler(this.comboBox_Rotate_SelectedIndexChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 228);
            this.Controls.Add(this.comboBox_Rotate);
            this.Controls.Add(this.label_Rotate);
            this.Controls.Add(this.button_Fit);
            this.Controls.Add(this.buttonEdit_Font);
            this.Controls.Add(this.label_Font);
            this.Controls.Add(this.colorEdit_BackColor);
            this.Controls.Add(this.label_BackColor);
            this.Controls.Add(this.colorEdit_TextColor);
            this.Controls.Add(this.label_TextColor);
            this.Controls.Add(this.textBox_Text);
            this.Controls.Add(this.label_LabelText);
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

        private System.Windows.Forms.TextBox textBox_Text;
        private System.Windows.Forms.Label label_LabelText;
        private DevExpress.XtraEditors.ColorEdit colorEdit_BackColor;
        private System.Windows.Forms.Label label_BackColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_TextColor;
        private System.Windows.Forms.Label label_TextColor;
        private System.Windows.Forms.Label label_Font;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Font;
        private System.Windows.Forms.Button button_Fit;
        private System.Windows.Forms.Label label_Rotate;
        private System.Windows.Forms.ComboBox comboBox_Rotate;
    }
}