// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.SpecialControls
{
    partial class ValueControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButton_False = new System.Windows.Forms.RadioButton();
            this.radioButton_True = new System.Windows.Forms.RadioButton();
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.dateTimePicker_Value = new System.Windows.Forms.DateTimePicker();
            this.numericUpDown_Ms = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ms)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton_False
            // 
            this.radioButton_False.AutoSize = true;
            this.radioButton_False.Checked = true;
            this.radioButton_False.Location = new System.Drawing.Point(103, 13);
            this.radioButton_False.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_False.Name = "radioButton_False";
            this.radioButton_False.Size = new System.Drawing.Size(50, 17);
            this.radioButton_False.TabIndex = 1;
            this.radioButton_False.TabStop = true;
            this.radioButton_False.Text = "False";
            this.radioButton_False.UseVisualStyleBackColor = true;
            // 
            // radioButton_True
            // 
            this.radioButton_True.AutoSize = true;
            this.radioButton_True.Location = new System.Drawing.Point(39, 13);
            this.radioButton_True.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_True.Name = "radioButton_True";
            this.radioButton_True.Size = new System.Drawing.Size(47, 17);
            this.radioButton_True.TabIndex = 0;
            this.radioButton_True.Text = "True";
            this.radioButton_True.UseVisualStyleBackColor = true;
            // 
            // textBox_Value
            // 
            this.textBox_Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Value.Location = new System.Drawing.Point(7, 12);
            this.textBox_Value.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(180, 20);
            this.textBox_Value.TabIndex = 0;
            this.textBox_Value.Text = "0";
            // 
            // dateTimePicker_Value
            // 
            this.dateTimePicker_Value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_Value.CustomFormat = "yyyy.MM.dd HH:mm:ss";
            this.dateTimePicker_Value.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Value.Location = new System.Drawing.Point(7, 11);
            this.dateTimePicker_Value.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker_Value.Name = "dateTimePicker_Value";
            this.dateTimePicker_Value.ShowUpDown = true;
            this.dateTimePicker_Value.Size = new System.Drawing.Size(126, 20);
            this.dateTimePicker_Value.TabIndex = 0;
            // 
            // numericUpDown_Ms
            // 
            this.numericUpDown_Ms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Ms.Location = new System.Drawing.Point(142, 11);
            this.numericUpDown_Ms.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_Ms.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDown_Ms.Name = "numericUpDown_Ms";
            this.numericUpDown_Ms.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown_Ms.TabIndex = 1;
            this.numericUpDown_Ms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_Ms.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // ValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown_Ms);
            this.Controls.Add(this.dateTimePicker_Value);
            this.Controls.Add(this.radioButton_False);
            this.Controls.Add(this.radioButton_True);
            this.Controls.Add(this.textBox_Value);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ValueControl";
            this.Size = new System.Drawing.Size(193, 42);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Ms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton_False;
        private System.Windows.Forms.RadioButton radioButton_True;
        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Value;
        private System.Windows.Forms.NumericUpDown numericUpDown_Ms;

    }
}
