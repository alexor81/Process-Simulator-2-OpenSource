namespace Converter.ToString
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
            this.label_Type = new System.Windows.Forms.Label();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.checkBox_Array = new System.Windows.Forms.CheckBox();
            this.checkBox_Reverse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(49, 122);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(11, 10);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(44, 17);
            this.label_Type.TabIndex = 5;
            this.label_Type.Text = "Type:";
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(61, 6);
            this.comboBox_Type.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(214, 24);
            this.comboBox_Type.TabIndex = 6;
            // 
            // checkBox_Array
            // 
            this.checkBox_Array.AutoSize = true;
            this.checkBox_Array.Location = new System.Drawing.Point(61, 48);
            this.checkBox_Array.Name = "checkBox_Array";
            this.checkBox_Array.Size = new System.Drawing.Size(64, 21);
            this.checkBox_Array.TabIndex = 7;
            this.checkBox_Array.Text = "Array";
            this.checkBox_Array.UseVisualStyleBackColor = true;
            // 
            // checkBox_Reverse
            // 
            this.checkBox_Reverse.AutoSize = true;
            this.checkBox_Reverse.Location = new System.Drawing.Point(61, 87);
            this.checkBox_Reverse.Name = "checkBox_Reverse";
            this.checkBox_Reverse.Size = new System.Drawing.Size(83, 21);
            this.checkBox_Reverse.TabIndex = 8;
            this.checkBox_Reverse.Text = "Reverse";
            this.checkBox_Reverse.UseVisualStyleBackColor = true;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 160);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_Reverse);
            this.Controls.Add(this.checkBox_Array);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.label_Type);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ToString";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.ComboBox comboBox_Type;
        private System.Windows.Forms.CheckBox checkBox_Array;
        private System.Windows.Forms.CheckBox checkBox_Reverse;
    }
}