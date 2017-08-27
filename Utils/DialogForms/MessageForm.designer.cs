// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.DialogForms
{
    partial class MessageForm
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
            this.richTextBox_Message = new System.Windows.Forms.RichTextBox();
            this.button_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_Message
            // 
            this.richTextBox_Message.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Message.DetectUrls = false;
            this.richTextBox_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_Message.Location = new System.Drawing.Point(79, 28);
            this.richTextBox_Message.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Message.Name = "richTextBox_Message";
            this.richTextBox_Message.ReadOnly = true;
            this.richTextBox_Message.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Message.Size = new System.Drawing.Size(299, 80);
            this.richTextBox_Message.TabIndex = 1;
            this.richTextBox_Message.TabStop = false;
            this.richTextBox_Message.Text = "Message";
            // 
            // button_Ok
            // 
            this.button_Ok.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Ok.Location = new System.Drawing.Point(152, 116);
            this.button_Ok.Margin = new System.Windows.Forms.Padding(4);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(87, 30);
            this.button_Ok.TabIndex = 0;
            this.button_Ok.Text = "Ok";
            this.button_Ok.UseVisualStyleBackColor = true;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Ok;
            this.ClientSize = new System.Drawing.Size(386, 158);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox_Message);
            this.Controls.Add(this.button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.MessageForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MessageBoxForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Message;
        private System.Windows.Forms.Button button_Ok;
    }
}