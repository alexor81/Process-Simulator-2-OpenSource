namespace Converter.ToBoolean
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
            this.checkBox_Reverse = new System.Windows.Forms.CheckBox();
            this.checkBox_TrueIfWrong = new System.Windows.Forms.CheckBox();
            this.buttonEdit_TrueValue = new DevExpress.XtraEditors.ButtonEdit();
            this.label_TrueValue = new System.Windows.Forms.Label();
            this.label_FalseValue = new System.Windows.Forms.Label();
            this.buttonEdit_FalseValue = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_TrueValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_FalseValue.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(97, 154);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // checkBox_Reverse
            // 
            this.checkBox_Reverse.AutoSize = true;
            this.checkBox_Reverse.Location = new System.Drawing.Point(102, 118);
            this.checkBox_Reverse.Name = "checkBox_Reverse";
            this.checkBox_Reverse.Size = new System.Drawing.Size(83, 21);
            this.checkBox_Reverse.TabIndex = 3;
            this.checkBox_Reverse.Text = "Reverse";
            this.checkBox_Reverse.UseVisualStyleBackColor = true;
            // 
            // checkBox_TrueIfWrong
            // 
            this.checkBox_TrueIfWrong.AutoSize = true;
            this.checkBox_TrueIfWrong.Location = new System.Drawing.Point(102, 86);
            this.checkBox_TrueIfWrong.Name = "checkBox_TrueIfWrong";
            this.checkBox_TrueIfWrong.Size = new System.Drawing.Size(151, 21);
            this.checkBox_TrueIfWrong.TabIndex = 2;
            this.checkBox_TrueIfWrong.Text = "True if wrong value";
            this.checkBox_TrueIfWrong.UseVisualStyleBackColor = true;
            // 
            // buttonEdit_TrueValue
            // 
            this.buttonEdit_TrueValue.Location = new System.Drawing.Point(102, 16);
            this.buttonEdit_TrueValue.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_TrueValue.Name = "buttonEdit_TrueValue";
            this.buttonEdit_TrueValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_TrueValue.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_TrueValue.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_TrueValue.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_TrueValue.Properties.ReadOnly = true;
            this.buttonEdit_TrueValue.Size = new System.Drawing.Size(270, 24);
            this.buttonEdit_TrueValue.TabIndex = 0;
            this.buttonEdit_TrueValue.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_TrueValue_ButtonClick);
            // 
            // label_TrueValue
            // 
            this.label_TrueValue.AutoSize = true;
            this.label_TrueValue.Location = new System.Drawing.Point(13, 20);
            this.label_TrueValue.Name = "label_TrueValue";
            this.label_TrueValue.Size = new System.Drawing.Size(82, 17);
            this.label_TrueValue.TabIndex = 12;
            this.label_TrueValue.Text = "True Value:";
            // 
            // label_FalseValue
            // 
            this.label_FalseValue.AutoSize = true;
            this.label_FalseValue.Location = new System.Drawing.Point(13, 55);
            this.label_FalseValue.Name = "label_FalseValue";
            this.label_FalseValue.Size = new System.Drawing.Size(86, 17);
            this.label_FalseValue.TabIndex = 14;
            this.label_FalseValue.Text = "False Value:";
            // 
            // buttonEdit_FalseValue
            // 
            this.buttonEdit_FalseValue.Location = new System.Drawing.Point(102, 51);
            this.buttonEdit_FalseValue.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_FalseValue.Name = "buttonEdit_FalseValue";
            this.buttonEdit_FalseValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_FalseValue.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_FalseValue.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_FalseValue.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_FalseValue.Properties.ReadOnly = true;
            this.buttonEdit_FalseValue.Size = new System.Drawing.Size(270, 24);
            this.buttonEdit_FalseValue.TabIndex = 1;
            this.buttonEdit_FalseValue.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_FalseValue_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 191);
            this.ControlBox = false;
            this.Controls.Add(this.label_FalseValue);
            this.Controls.Add(this.buttonEdit_FalseValue);
            this.Controls.Add(this.label_TrueValue);
            this.Controls.Add(this.buttonEdit_TrueValue);
            this.Controls.Add(this.checkBox_TrueIfWrong);
            this.Controls.Add(this.checkBox_Reverse);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ToBoolean";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_TrueValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_FalseValue.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.CheckBox checkBox_Reverse;
        private System.Windows.Forms.CheckBox checkBox_TrueIfWrong;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_TrueValue;
        private System.Windows.Forms.Label label_TrueValue;
        private System.Windows.Forms.Label label_FalseValue;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_FalseValue;
    }
}