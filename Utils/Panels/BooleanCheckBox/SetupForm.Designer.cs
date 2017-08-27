// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanCheckBox
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
            this.checkBox_RightLeft = new System.Windows.Forms.CheckBox();
            this.label_LabelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Text
            // 
            this.textBox_Text.Location = new System.Drawing.Point(54, 9);
            this.textBox_Text.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Text.Name = "textBox_Text";
            this.textBox_Text.Size = new System.Drawing.Size(236, 22);
            this.textBox_Text.TabIndex = 0;
            this.textBox_Text.TextChanged += new System.EventHandler(this.textBox_Text_TextChanged);
            // 
            // checkBox_RightLeft
            // 
            this.checkBox_RightLeft.AutoSize = true;
            this.checkBox_RightLeft.Location = new System.Drawing.Point(104, 42);
            this.checkBox_RightLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_RightLeft.Name = "checkBox_RightLeft";
            this.checkBox_RightLeft.Size = new System.Drawing.Size(91, 21);
            this.checkBox_RightLeft.TabIndex = 1;
            this.checkBox_RightLeft.Text = "Right/Left";
            this.checkBox_RightLeft.UseVisualStyleBackColor = true;
            this.checkBox_RightLeft.CheckedChanged += new System.EventHandler(this.checkBox_RightLeft_CheckedChanged);
            // 
            // label_LabelText
            // 
            this.label_LabelText.AutoSize = true;
            this.label_LabelText.Location = new System.Drawing.Point(9, 14);
            this.label_LabelText.Name = "label_LabelText";
            this.label_LabelText.Size = new System.Drawing.Size(39, 17);
            this.label_LabelText.TabIndex = 1;
            this.label_LabelText.Text = "Text:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 71);
            this.Controls.Add(this.checkBox_RightLeft);
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
            this.Text = "Check Box";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Text;
        private System.Windows.Forms.CheckBox checkBox_RightLeft;
        private System.Windows.Forms.Label label_LabelText;
    }
}