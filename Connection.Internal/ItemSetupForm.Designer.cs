namespace Connection.Internal
{
    partial class ItemSetupForm
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
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_ValueValue = new System.Windows.Forms.Label();
            this.label_TypeValue = new System.Windows.Forms.Label();
            this.groupBox_Access = new System.Windows.Forms.GroupBox();
            this.radioButton_NA = new System.Windows.Forms.RadioButton();
            this.radioButton_RW = new System.Windows.Forms.RadioButton();
            this.radioButton_W = new System.Windows.Forms.RadioButton();
            this.radioButton_R = new System.Windows.Forms.RadioButton();
            this.button_Write = new System.Windows.Forms.Button();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Access.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(20, 34);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 2;
            this.label_Value.Text = "Value:";
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(24, 7);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(44, 17);
            this.label_Type.TabIndex = 3;
            this.label_Type.Text = "Type:";
            // 
            // label_ValueValue
            // 
            this.label_ValueValue.Location = new System.Drawing.Point(77, 33);
            this.label_ValueValue.Name = "label_ValueValue";
            this.label_ValueValue.Size = new System.Drawing.Size(196, 17);
            this.label_ValueValue.TabIndex = 4;
            this.label_ValueValue.Text = "0";
            // 
            // label_TypeValue
            // 
            this.label_TypeValue.AutoSize = true;
            this.label_TypeValue.Location = new System.Drawing.Point(77, 7);
            this.label_TypeValue.Name = "label_TypeValue";
            this.label_TypeValue.Size = new System.Drawing.Size(89, 17);
            this.label_TypeValue.TabIndex = 5;
            this.label_TypeValue.Text = "System.Int32";
            // 
            // groupBox_Access
            // 
            this.groupBox_Access.Controls.Add(this.radioButton_NA);
            this.groupBox_Access.Controls.Add(this.radioButton_RW);
            this.groupBox_Access.Controls.Add(this.radioButton_W);
            this.groupBox_Access.Controls.Add(this.radioButton_R);
            this.groupBox_Access.Location = new System.Drawing.Point(5, 90);
            this.groupBox_Access.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Access.Name = "groupBox_Access";
            this.groupBox_Access.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Access.Size = new System.Drawing.Size(283, 81);
            this.groupBox_Access.TabIndex = 1;
            this.groupBox_Access.TabStop = false;
            this.groupBox_Access.Text = "Access";
            // 
            // radioButton_NA
            // 
            this.radioButton_NA.AutoSize = true;
            this.radioButton_NA.Location = new System.Drawing.Point(31, 52);
            this.radioButton_NA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_NA.Name = "radioButton_NA";
            this.radioButton_NA.Size = new System.Drawing.Size(96, 21);
            this.radioButton_NA.TabIndex = 3;
            this.radioButton_NA.Text = "No Access";
            this.radioButton_NA.UseVisualStyleBackColor = true;
            this.radioButton_NA.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_RW
            // 
            this.radioButton_RW.AutoSize = true;
            this.radioButton_RW.Checked = true;
            this.radioButton_RW.Location = new System.Drawing.Point(31, 23);
            this.radioButton_RW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_RW.Name = "radioButton_RW";
            this.radioButton_RW.Size = new System.Drawing.Size(128, 21);
            this.radioButton_RW.TabIndex = 0;
            this.radioButton_RW.TabStop = true;
            this.radioButton_RW.Text = "Read and Write";
            this.radioButton_RW.UseVisualStyleBackColor = true;
            this.radioButton_RW.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_W
            // 
            this.radioButton_W.AutoSize = true;
            this.radioButton_W.Location = new System.Drawing.Point(185, 52);
            this.radioButton_W.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_W.Name = "radioButton_W";
            this.radioButton_W.Size = new System.Drawing.Size(62, 21);
            this.radioButton_W.TabIndex = 2;
            this.radioButton_W.Text = "Write";
            this.radioButton_W.UseVisualStyleBackColor = true;
            this.radioButton_W.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_R
            // 
            this.radioButton_R.AutoSize = true;
            this.radioButton_R.Location = new System.Drawing.Point(185, 23);
            this.radioButton_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_R.Name = "radioButton_R";
            this.radioButton_R.Size = new System.Drawing.Size(63, 21);
            this.radioButton_R.TabIndex = 1;
            this.radioButton_R.Text = "Read";
            this.radioButton_R.UseVisualStyleBackColor = true;
            this.radioButton_R.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // button_Write
            // 
            this.button_Write.Location = new System.Drawing.Point(114, 59);
            this.button_Write.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Write.Name = "button_Write";
            this.button_Write.Size = new System.Drawing.Size(65, 27);
            this.button_Write.TabIndex = 0;
            this.button_Write.Text = "Write";
            this.button_Write.UseVisualStyleBackColor = true;
            this.button_Write.Click += new System.EventHandler(this.button_Write_Click);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(52, 177);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 2;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // ItemSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 216);
            this.ControlBox = false;
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.button_Write);
            this.Controls.Add(this.groupBox_Access);
            this.Controls.Add(this.label_TypeValue);
            this.Controls.Add(this.label_ValueValue);
            this.Controls.Add(this.label_Type);
            this.Controls.Add(this.label_Value);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Internal Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ItemSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSetupForm_KeyDown);
            this.groupBox_Access.ResumeLayout(false);
            this.groupBox_Access.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.Label label_ValueValue;
        private System.Windows.Forms.Label label_TypeValue;
        private System.Windows.Forms.GroupBox groupBox_Access;
        private System.Windows.Forms.RadioButton radioButton_NA;
        private System.Windows.Forms.RadioButton radioButton_RW;
        private System.Windows.Forms.RadioButton radioButton_W;
        private System.Windows.Forms.RadioButton radioButton_R;
        private System.Windows.Forms.Button button_Write;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
    }
}