// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanIndicator
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
            this.colorEdit_True = new DevExpress.XtraEditors.ColorEdit();
            this.label_TrueColor = new System.Windows.Forms.Label();
            this.colorEdit_False = new DevExpress.XtraEditors.ColorEdit();
            this.label_FalseColor = new System.Windows.Forms.Label();
            this.label_Shape = new System.Windows.Forms.Label();
            this.comboBox_Shape = new System.Windows.Forms.ComboBox();
            this.button_Fit = new System.Windows.Forms.Button();
            this.checkBox_Blink = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_True.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_False.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(54, 6);
            this.textBox_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.Size = new System.Drawing.Size(242, 22);
            this.textBox_Text.TabIndex = 0;
            this.textBox_Text.TextChanged += new System.EventHandler(this.textBox_Text_TextChanged);
            // 
            // label_LabelText
            // 
            this.label_LabelText.AutoSize = true;
            this.label_LabelText.Location = new System.Drawing.Point(9, 11);
            this.label_LabelText.Name = "label_LabelText";
            this.label_LabelText.Size = new System.Drawing.Size(39, 17);
            this.label_LabelText.TabIndex = 4;
            this.label_LabelText.Text = "Text:";
            // 
            // colorEdit_True
            // 
            this.colorEdit_True.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_True.Location = new System.Drawing.Point(96, 68);
            this.colorEdit_True.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_True.Name = "colorEdit_True";
            this.colorEdit_True.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_True.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_True.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_True.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_True.Size = new System.Drawing.Size(200, 24);
            this.colorEdit_True.TabIndex = 2;
            this.colorEdit_True.ColorChanged += new System.EventHandler(this.colorEdit_True_ColorChanged);
            // 
            // label_TrueColor
            // 
            this.label_TrueColor.AutoSize = true;
            this.label_TrueColor.Location = new System.Drawing.Point(13, 74);
            this.label_TrueColor.Name = "label_TrueColor";
            this.label_TrueColor.Size = new System.Drawing.Size(79, 17);
            this.label_TrueColor.TabIndex = 6;
            this.label_TrueColor.Text = "True Color:";
            // 
            // colorEdit_False
            // 
            this.colorEdit_False.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_False.Location = new System.Drawing.Point(96, 98);
            this.colorEdit_False.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_False.Name = "colorEdit_False";
            this.colorEdit_False.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_False.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_False.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_False.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_False.Size = new System.Drawing.Size(200, 24);
            this.colorEdit_False.TabIndex = 3;
            this.colorEdit_False.ColorChanged += new System.EventHandler(this.colorEdit_False_ColorChanged);
            // 
            // label_FalseColor
            // 
            this.label_FalseColor.AutoSize = true;
            this.label_FalseColor.Location = new System.Drawing.Point(9, 105);
            this.label_FalseColor.Name = "label_FalseColor";
            this.label_FalseColor.Size = new System.Drawing.Size(83, 17);
            this.label_FalseColor.TabIndex = 8;
            this.label_FalseColor.Text = "False Color:";
            // 
            // label_Shape
            // 
            this.label_Shape.AutoSize = true;
            this.label_Shape.Location = new System.Drawing.Point(37, 43);
            this.label_Shape.Name = "label_Shape";
            this.label_Shape.Size = new System.Drawing.Size(53, 17);
            this.label_Shape.TabIndex = 10;
            this.label_Shape.Text = "Shape:";
            // 
            // comboBox_Shape
            // 
            this.comboBox_Shape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Shape.FormattingEnabled = true;
            this.comboBox_Shape.Items.AddRange(new object[] {
            "Ellipse",
            "Rectangle"});
            this.comboBox_Shape.Location = new System.Drawing.Point(96, 38);
            this.comboBox_Shape.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Shape.Name = "comboBox_Shape";
            this.comboBox_Shape.Size = new System.Drawing.Size(200, 24);
            this.comboBox_Shape.TabIndex = 1;
            this.comboBox_Shape.SelectedIndexChanged += new System.EventHandler(this.comboBox_Shape_SelectedIndexChanged);
            // 
            // button_Fit
            // 
            this.button_Fit.Location = new System.Drawing.Point(87, 155);
            this.button_Fit.Margin = new System.Windows.Forms.Padding(4);
            this.button_Fit.Name = "button_Fit";
            this.button_Fit.Size = new System.Drawing.Size(131, 28);
            this.button_Fit.TabIndex = 5;
            this.button_Fit.Text = "Fit to content";
            this.button_Fit.UseVisualStyleBackColor = true;
            this.button_Fit.Click += new System.EventHandler(this.button_Fit_Click);
            // 
            // checkBox_Blink
            // 
            this.checkBox_Blink.AutoSize = true;
            this.checkBox_Blink.Location = new System.Drawing.Point(96, 127);
            this.checkBox_Blink.Name = "checkBox_Blink";
            this.checkBox_Blink.Size = new System.Drawing.Size(60, 21);
            this.checkBox_Blink.TabIndex = 4;
            this.checkBox_Blink.Text = "Blink";
            this.checkBox_Blink.UseVisualStyleBackColor = true;
            this.checkBox_Blink.CheckedChanged += new System.EventHandler(this.checkBox_Blink_CheckedChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 193);
            this.Controls.Add(this.checkBox_Blink);
            this.Controls.Add(this.button_Fit);
            this.Controls.Add(this.comboBox_Shape);
            this.Controls.Add(this.label_Shape);
            this.Controls.Add(this.colorEdit_False);
            this.Controls.Add(this.label_FalseColor);
            this.Controls.Add(this.colorEdit_True);
            this.Controls.Add(this.label_TrueColor);
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
            this.Text = "Indicator";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_True.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_False.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Text;
        private System.Windows.Forms.Label label_LabelText;
        private DevExpress.XtraEditors.ColorEdit colorEdit_True;
        private System.Windows.Forms.Label label_TrueColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_False;
        private System.Windows.Forms.Label label_FalseColor;
        private System.Windows.Forms.Label label_Shape;
        private System.Windows.Forms.ComboBox comboBox_Shape;
        private System.Windows.Forms.Button button_Fit;
        private System.Windows.Forms.CheckBox checkBox_Blink;
    }
}