namespace Converter.Compare
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
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Operation = new System.Windows.Forms.Label();
            this.comboBox_Operation = new System.Windows.Forms.ComboBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.SuspendLayout();
            // 
            // textBox_Value
            // 
            this.textBox_Value.Location = new System.Drawing.Point(99, 58);
            this.textBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(175, 22);
            this.textBox_Value.TabIndex = 1;
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(41, 63);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 5;
            this.label_Value.Text = "Value:";
            // 
            // label_Operation
            // 
            this.label_Operation.AutoSize = true;
            this.label_Operation.Location = new System.Drawing.Point(16, 23);
            this.label_Operation.Name = "label_Operation";
            this.label_Operation.Size = new System.Drawing.Size(75, 17);
            this.label_Operation.TabIndex = 4;
            this.label_Operation.Text = "Operation:";
            // 
            // comboBox_Operation
            // 
            this.comboBox_Operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operation.FormattingEnabled = true;
            this.comboBox_Operation.Location = new System.Drawing.Point(99, 18);
            this.comboBox_Operation.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_Operation.Name = "comboBox_Operation";
            this.comboBox_Operation.Size = new System.Drawing.Size(175, 24);
            this.comboBox_Operation.TabIndex = 0;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(52, 101);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 2;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 135);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox_Operation);
            this.Controls.Add(this.textBox_Value);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.label_Operation);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compare";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Operation;
        private System.Windows.Forms.ComboBox comboBox_Operation;
    }
}