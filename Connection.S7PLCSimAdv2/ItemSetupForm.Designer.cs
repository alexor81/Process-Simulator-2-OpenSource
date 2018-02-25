// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.S7PLCSimAdv2
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
            this.button_Browser = new System.Windows.Forms.Button();
            this.textBox_Tag = new System.Windows.Forms.TextBox();
            this.label_Tag = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.SuspendLayout();
            // 
            // button_Browser
            // 
            this.button_Browser.Location = new System.Drawing.Point(327, 17);
            this.button_Browser.Name = "button_Browser";
            this.button_Browser.Size = new System.Drawing.Size(33, 23);
            this.button_Browser.TabIndex = 11;
            this.button_Browser.Text = "...";
            this.button_Browser.UseVisualStyleBackColor = true;
            this.button_Browser.Click += new System.EventHandler(this.button_Browser_Click);
            // 
            // textBox_Tag
            // 
            this.textBox_Tag.Location = new System.Drawing.Point(52, 17);
            this.textBox_Tag.Name = "textBox_Tag";
            this.textBox_Tag.Size = new System.Drawing.Size(273, 22);
            this.textBox_Tag.TabIndex = 10;
            // 
            // label_Tag
            // 
            this.label_Tag.AutoSize = true;
            this.label_Tag.Location = new System.Drawing.Point(9, 20);
            this.label_Tag.Name = "label_Tag";
            this.label_Tag.Size = new System.Drawing.Size(37, 17);
            this.label_Tag.TabIndex = 13;
            this.label_Tag.Text = "Tag:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(90, 51);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 12;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // ItemSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 88);
            this.ControlBox = false;
            this.Controls.Add(this.button_Browser);
            this.Controls.Add(this.textBox_Tag);
            this.Controls.Add(this.label_Tag);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "S7PLCSimAdv2 Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ItemSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Browser;
        private System.Windows.Forms.TextBox textBox_Tag;
        private System.Windows.Forms.Label label_Tag;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
    }
}