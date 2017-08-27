// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanButton
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
            this.groupBox_True = new System.Windows.Forms.GroupBox();
            this.colorEdit_True = new DevExpress.XtraEditors.ColorEdit();
            this.textBox_TrueText = new System.Windows.Forms.TextBox();
            this.label_TrueColor = new System.Windows.Forms.Label();
            this.label_TrueText = new System.Windows.Forms.Label();
            this.groupBox_False = new System.Windows.Forms.GroupBox();
            this.colorEdit_False = new DevExpress.XtraEditors.ColorEdit();
            this.textBox_FalseText = new System.Windows.Forms.TextBox();
            this.label_FalseColor = new System.Windows.Forms.Label();
            this.label_FalseText = new System.Windows.Forms.Label();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.groupBox_True.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_True.Properties)).BeginInit();
            this.groupBox_False.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_False.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_True
            // 
            this.groupBox_True.Controls.Add(this.colorEdit_True);
            this.groupBox_True.Controls.Add(this.textBox_TrueText);
            this.groupBox_True.Controls.Add(this.label_TrueColor);
            this.groupBox_True.Controls.Add(this.label_TrueText);
            this.groupBox_True.Location = new System.Drawing.Point(0, 37);
            this.groupBox_True.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_True.Name = "groupBox_True";
            this.groupBox_True.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_True.Size = new System.Drawing.Size(292, 86);
            this.groupBox_True.TabIndex = 1;
            this.groupBox_True.TabStop = false;
            this.groupBox_True.Text = "True";
            // 
            // colorEdit_True
            // 
            this.colorEdit_True.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_True.Location = new System.Drawing.Point(61, 50);
            this.colorEdit_True.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_True.Name = "colorEdit_True";
            this.colorEdit_True.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_True.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_True.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_True.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_True.Size = new System.Drawing.Size(219, 24);
            this.colorEdit_True.TabIndex = 1;
            this.colorEdit_True.ColorChanged += new System.EventHandler(this.colorEdit_True_ColorChanged);
            // 
            // textBox_TrueText
            // 
            this.textBox_TrueText.Location = new System.Drawing.Point(61, 18);
            this.textBox_TrueText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_TrueText.Name = "textBox_TrueText";
            this.textBox_TrueText.Size = new System.Drawing.Size(219, 22);
            this.textBox_TrueText.TabIndex = 0;
            this.textBox_TrueText.TextChanged += new System.EventHandler(this.textBox_TrueText_TextChanged);
            // 
            // label_TrueColor
            // 
            this.label_TrueColor.AutoSize = true;
            this.label_TrueColor.Location = new System.Drawing.Point(12, 57);
            this.label_TrueColor.Name = "label_TrueColor";
            this.label_TrueColor.Size = new System.Drawing.Size(45, 17);
            this.label_TrueColor.TabIndex = 2;
            this.label_TrueColor.Text = "Color:";
            // 
            // label_TrueText
            // 
            this.label_TrueText.AutoSize = true;
            this.label_TrueText.Location = new System.Drawing.Point(16, 23);
            this.label_TrueText.Name = "label_TrueText";
            this.label_TrueText.Size = new System.Drawing.Size(39, 17);
            this.label_TrueText.TabIndex = 0;
            this.label_TrueText.Text = "Text:";
            // 
            // groupBox_False
            // 
            this.groupBox_False.Controls.Add(this.colorEdit_False);
            this.groupBox_False.Controls.Add(this.textBox_FalseText);
            this.groupBox_False.Controls.Add(this.label_FalseColor);
            this.groupBox_False.Controls.Add(this.label_FalseText);
            this.groupBox_False.Location = new System.Drawing.Point(0, 127);
            this.groupBox_False.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_False.Name = "groupBox_False";
            this.groupBox_False.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_False.Size = new System.Drawing.Size(292, 86);
            this.groupBox_False.TabIndex = 2;
            this.groupBox_False.TabStop = false;
            this.groupBox_False.Text = "False";
            // 
            // colorEdit_False
            // 
            this.colorEdit_False.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_False.Location = new System.Drawing.Point(61, 50);
            this.colorEdit_False.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_False.Name = "colorEdit_False";
            this.colorEdit_False.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_False.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_False.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_False.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_False.Size = new System.Drawing.Size(219, 24);
            this.colorEdit_False.TabIndex = 1;
            this.colorEdit_False.ColorChanged += new System.EventHandler(this.colorEdit_False_ColorChanged);
            // 
            // textBox_FalseText
            // 
            this.textBox_FalseText.Location = new System.Drawing.Point(61, 18);
            this.textBox_FalseText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_FalseText.Name = "textBox_FalseText";
            this.textBox_FalseText.Size = new System.Drawing.Size(219, 22);
            this.textBox_FalseText.TabIndex = 0;
            this.textBox_FalseText.TextChanged += new System.EventHandler(this.textBox_FalseText_TextChanged);
            // 
            // label_FalseColor
            // 
            this.label_FalseColor.AutoSize = true;
            this.label_FalseColor.Location = new System.Drawing.Point(12, 57);
            this.label_FalseColor.Name = "label_FalseColor";
            this.label_FalseColor.Size = new System.Drawing.Size(45, 17);
            this.label_FalseColor.TabIndex = 2;
            this.label_FalseColor.Text = "Color:";
            // 
            // label_FalseText
            // 
            this.label_FalseText.AutoSize = true;
            this.label_FalseText.Location = new System.Drawing.Point(16, 23);
            this.label_FalseText.Name = "label_FalseText";
            this.label_FalseText.Size = new System.Drawing.Size(39, 17);
            this.label_FalseText.TabIndex = 0;
            this.label_FalseText.Text = "Text:";
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(7, 12);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 2;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(72, 9);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(211, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 214);
            this.Controls.Add(this.textBox_ToolTip);
            this.Controls.Add(this.groupBox_False);
            this.Controls.Add(this.groupBox_True);
            this.Controls.Add(this.label_ToolTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Button";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_True.ResumeLayout(false);
            this.groupBox_True.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_True.Properties)).EndInit();
            this.groupBox_False.ResumeLayout(false);
            this.groupBox_False.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_False.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_True;
        private DevExpress.XtraEditors.ColorEdit colorEdit_True;
        private System.Windows.Forms.Label label_TrueColor;
        private System.Windows.Forms.TextBox textBox_TrueText;
        private System.Windows.Forms.Label label_TrueText;
        private System.Windows.Forms.GroupBox groupBox_False;
        private DevExpress.XtraEditors.ColorEdit colorEdit_False;
        private System.Windows.Forms.Label label_FalseColor;
        private System.Windows.Forms.TextBox textBox_FalseText;
        private System.Windows.Forms.Label label_FalseText;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.TextBox textBox_ToolTip;
    }
}