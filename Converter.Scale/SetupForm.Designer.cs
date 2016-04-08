namespace Converter.Scale
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
            this.groupBox_In = new System.Windows.Forms.GroupBox();
            this.textBox_InMin = new System.Windows.Forms.TextBox();
            this.textBox_InMax = new System.Windows.Forms.TextBox();
            this.label_InMin = new System.Windows.Forms.Label();
            this.label_InMax = new System.Windows.Forms.Label();
            this.groupBox_Out = new System.Windows.Forms.GroupBox();
            this.textBox_OutMin = new System.Windows.Forms.TextBox();
            this.textBox_OutMax = new System.Windows.Forms.TextBox();
            this.label_OutMin = new System.Windows.Forms.Label();
            this.label_OutMax = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_In.SuspendLayout();
            this.groupBox_Out.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_In
            // 
            this.groupBox_In.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_In.Controls.Add(this.textBox_InMin);
            this.groupBox_In.Controls.Add(this.textBox_InMax);
            this.groupBox_In.Controls.Add(this.label_InMin);
            this.groupBox_In.Controls.Add(this.label_InMax);
            this.groupBox_In.Location = new System.Drawing.Point(5, 2);
            this.groupBox_In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_In.Name = "groupBox_In";
            this.groupBox_In.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_In.Size = new System.Drawing.Size(288, 86);
            this.groupBox_In.TabIndex = 0;
            this.groupBox_In.TabStop = false;
            this.groupBox_In.Text = "Input Value";
            // 
            // textBox_InMin
            // 
            this.textBox_InMin.Location = new System.Drawing.Point(79, 52);
            this.textBox_InMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_InMin.Name = "textBox_InMin";
            this.textBox_InMin.Size = new System.Drawing.Size(175, 22);
            this.textBox_InMin.TabIndex = 1;
            // 
            // textBox_InMax
            // 
            this.textBox_InMax.Location = new System.Drawing.Point(79, 22);
            this.textBox_InMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_InMax.Name = "textBox_InMax";
            this.textBox_InMax.Size = new System.Drawing.Size(175, 22);
            this.textBox_InMax.TabIndex = 0;
            // 
            // label_InMin
            // 
            this.label_InMin.AutoSize = true;
            this.label_InMin.Location = new System.Drawing.Point(37, 57);
            this.label_InMin.Name = "label_InMin";
            this.label_InMin.Size = new System.Drawing.Size(34, 17);
            this.label_InMin.TabIndex = 1;
            this.label_InMin.Text = "Min:";
            // 
            // label_InMax
            // 
            this.label_InMax.AutoSize = true;
            this.label_InMax.Location = new System.Drawing.Point(33, 27);
            this.label_InMax.Name = "label_InMax";
            this.label_InMax.Size = new System.Drawing.Size(37, 17);
            this.label_InMax.TabIndex = 0;
            this.label_InMax.Text = "Max:";
            // 
            // groupBox_Out
            // 
            this.groupBox_Out.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_Out.Controls.Add(this.textBox_OutMin);
            this.groupBox_Out.Controls.Add(this.textBox_OutMax);
            this.groupBox_Out.Controls.Add(this.label_OutMin);
            this.groupBox_Out.Controls.Add(this.label_OutMax);
            this.groupBox_Out.Location = new System.Drawing.Point(5, 94);
            this.groupBox_Out.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Out.Name = "groupBox_Out";
            this.groupBox_Out.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Out.Size = new System.Drawing.Size(288, 86);
            this.groupBox_Out.TabIndex = 1;
            this.groupBox_Out.TabStop = false;
            this.groupBox_Out.Text = "Output Value";
            // 
            // textBox_OutMin
            // 
            this.textBox_OutMin.Location = new System.Drawing.Point(79, 49);
            this.textBox_OutMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_OutMin.Name = "textBox_OutMin";
            this.textBox_OutMin.Size = new System.Drawing.Size(175, 22);
            this.textBox_OutMin.TabIndex = 1;
            // 
            // textBox_OutMax
            // 
            this.textBox_OutMax.Location = new System.Drawing.Point(79, 20);
            this.textBox_OutMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_OutMax.Name = "textBox_OutMax";
            this.textBox_OutMax.Size = new System.Drawing.Size(175, 22);
            this.textBox_OutMax.TabIndex = 0;
            // 
            // label_OutMin
            // 
            this.label_OutMin.AutoSize = true;
            this.label_OutMin.Location = new System.Drawing.Point(37, 54);
            this.label_OutMin.Name = "label_OutMin";
            this.label_OutMin.Size = new System.Drawing.Size(34, 17);
            this.label_OutMin.TabIndex = 5;
            this.label_OutMin.Text = "Min:";
            // 
            // label_OutMax
            // 
            this.label_OutMax.AutoSize = true;
            this.label_OutMax.Location = new System.Drawing.Point(33, 25);
            this.label_OutMax.Name = "label_OutMax";
            this.label_OutMax.Size = new System.Drawing.Size(37, 17);
            this.label_OutMax.TabIndex = 4;
            this.label_OutMax.Text = "Max:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(55, 186);
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
            this.ClientSize = new System.Drawing.Size(299, 223);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Out);
            this.Controls.Add(this.groupBox_In);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scale";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox_In.ResumeLayout(false);
            this.groupBox_In.PerformLayout();
            this.groupBox_Out.ResumeLayout(false);
            this.groupBox_Out.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.GroupBox groupBox_In;
        private System.Windows.Forms.GroupBox groupBox_Out;
        private System.Windows.Forms.TextBox textBox_InMin;
        private System.Windows.Forms.TextBox textBox_InMax;
        private System.Windows.Forms.Label label_InMin;
        private System.Windows.Forms.Label label_InMax;
        private System.Windows.Forms.TextBox textBox_OutMin;
        private System.Windows.Forms.TextBox textBox_OutMax;
        private System.Windows.Forms.Label label_OutMin;
        private System.Windows.Forms.Label label_OutMax;
    }
}