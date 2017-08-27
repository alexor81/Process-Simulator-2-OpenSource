// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.DialogForms
{
    partial class QuestionForm
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
            this.button_Yes = new System.Windows.Forms.Button();
            this.button_No = new System.Windows.Forms.Button();
            this.richTextBox_Question = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_Yes
            // 
            this.button_Yes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button_Yes.Location = new System.Drawing.Point(99, 116);
            this.button_Yes.Margin = new System.Windows.Forms.Padding(4);
            this.button_Yes.Name = "button_Yes";
            this.button_Yes.Size = new System.Drawing.Size(87, 30);
            this.button_Yes.TabIndex = 1;
            this.button_Yes.Text = "Yes";
            this.button_Yes.UseVisualStyleBackColor = true;
            // 
            // button_No
            // 
            this.button_No.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button_No.Location = new System.Drawing.Point(209, 116);
            this.button_No.Margin = new System.Windows.Forms.Padding(4);
            this.button_No.Name = "button_No";
            this.button_No.Size = new System.Drawing.Size(87, 30);
            this.button_No.TabIndex = 0;
            this.button_No.Text = "No";
            this.button_No.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Question
            // 
            this.richTextBox_Question.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox_Question.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Question.DetectUrls = false;
            this.richTextBox_Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_Question.Location = new System.Drawing.Point(79, 28);
            this.richTextBox_Question.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Question.Name = "richTextBox_Question";
            this.richTextBox_Question.ReadOnly = true;
            this.richTextBox_Question.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_Question.Size = new System.Drawing.Size(299, 80);
            this.richTextBox_Question.TabIndex = 2;
            this.richTextBox_Question.TabStop = false;
            this.richTextBox_Question.Text = "Question";
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 158);
            this.ControlBox = false;
            this.Controls.Add(this.richTextBox_Question);
            this.Controls.Add(this.button_No);
            this.Controls.Add(this.button_Yes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuestionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QuestionBoxForm_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Yes;
        private System.Windows.Forms.Button button_No;
        private System.Windows.Forms.RichTextBox richTextBox_Question;
    }
}