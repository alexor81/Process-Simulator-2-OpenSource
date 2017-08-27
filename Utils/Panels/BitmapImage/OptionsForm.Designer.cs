// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BitmapImage
{
    partial class OptionsForm
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
            this.checkBox_IsConteiner = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_IsConteiner
            // 
            this.checkBox_IsConteiner.AutoSize = true;
            this.checkBox_IsConteiner.Location = new System.Drawing.Point(74, 50);
            this.checkBox_IsConteiner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_IsConteiner.Name = "checkBox_IsConteiner";
            this.checkBox_IsConteiner.Size = new System.Drawing.Size(91, 21);
            this.checkBox_IsConteiner.TabIndex = 2;
            this.checkBox_IsConteiner.Text = "Conteiner";
            this.checkBox_IsConteiner.UseVisualStyleBackColor = true;
            this.checkBox_IsConteiner.CheckedChanged += new System.EventHandler(this.checkBox_IsConteiner_CheckedChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 121);
            this.Controls.Add(this.checkBox_IsConteiner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_IsConteiner;
    }
}