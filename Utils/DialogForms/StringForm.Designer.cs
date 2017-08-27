// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.DialogForms
{
    partial class StringForm
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
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.SuspendLayout();
            // 
            // textBox_Value
            // 
            this.textBox_Value.Location = new System.Drawing.Point(8, 27);
            this.textBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(273, 22);
            this.textBox_Value.TabIndex = 0;
            this.textBox_Value.TextChanged += new System.EventHandler(this.textBox_Value_TextChanged);
            this.textBox_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Value_KeyPress);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(50, 63);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 1;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // StringForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 97);
            this.ControlBox = false;
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.textBox_Value);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StringForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.StringForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StringForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Value;
        private SpecialControls.OKCancelButton okCancelButton;
    }
}