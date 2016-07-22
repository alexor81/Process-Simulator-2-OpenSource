namespace Converter.FilterExp
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
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.textBox_Alfa = new System.Windows.Forms.TextBox();
            this.label_Alfa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(26, 71);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 1;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // textBox_Alfa
            // 
            this.textBox_Alfa.Location = new System.Drawing.Point(60, 28);
            this.textBox_Alfa.Name = "textBox_Alfa";
            this.textBox_Alfa.Size = new System.Drawing.Size(161, 22);
            this.textBox_Alfa.TabIndex = 0;
            // 
            // label_Alfa
            // 
            this.label_Alfa.AutoSize = true;
            this.label_Alfa.Location = new System.Drawing.Point(20, 31);
            this.label_Alfa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Alfa.Name = "label_Alfa";
            this.label_Alfa.Size = new System.Drawing.Size(36, 17);
            this.label_Alfa.TabIndex = 44;
            this.label_Alfa.Text = "Alfa:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 108);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_Alfa);
            this.Controls.Add(this.label_Alfa);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exponential Filter";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.TextBox textBox_Alfa;
        private System.Windows.Forms.Label label_Alfa;
    }
}