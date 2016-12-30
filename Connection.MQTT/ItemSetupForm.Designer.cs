// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.MQTT
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
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.label_Topic = new System.Windows.Forms.Label();
            this.textBox_Topic = new System.Windows.Forms.TextBox();
            this.checkBox_Subscribe = new System.Windows.Forms.CheckBox();
            this.checkBox_Publish = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(95, 97);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 2;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // label_Topic
            // 
            this.label_Topic.AutoSize = true;
            this.label_Topic.Location = new System.Drawing.Point(10, 16);
            this.label_Topic.Name = "label_Topic";
            this.label_Topic.Size = new System.Drawing.Size(47, 17);
            this.label_Topic.TabIndex = 3;
            this.label_Topic.Text = "Topic:";
            // 
            // textBox_Topic
            // 
            this.textBox_Topic.Location = new System.Drawing.Point(63, 13);
            this.textBox_Topic.Name = "textBox_Topic";
            this.textBox_Topic.Size = new System.Drawing.Size(306, 22);
            this.textBox_Topic.TabIndex = 0;
            this.textBox_Topic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Topic_KeyPress);
            // 
            // checkBox_Subscribe
            // 
            this.checkBox_Subscribe.AutoSize = true;
            this.checkBox_Subscribe.Location = new System.Drawing.Point(102, 50);
            this.checkBox_Subscribe.Name = "checkBox_Subscribe";
            this.checkBox_Subscribe.Size = new System.Drawing.Size(93, 21);
            this.checkBox_Subscribe.TabIndex = 1;
            this.checkBox_Subscribe.Text = "Subscribe";
            this.checkBox_Subscribe.UseVisualStyleBackColor = true;
            // 
            // checkBox_Publish
            // 
            this.checkBox_Publish.AutoSize = true;
            this.checkBox_Publish.Location = new System.Drawing.Point(201, 50);
            this.checkBox_Publish.Name = "checkBox_Publish";
            this.checkBox_Publish.Size = new System.Drawing.Size(76, 21);
            this.checkBox_Publish.TabIndex = 4;
            this.checkBox_Publish.Text = "Publish";
            this.checkBox_Publish.UseVisualStyleBackColor = true;
            // 
            // ItemSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 136);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_Publish);
            this.Controls.Add(this.checkBox_Subscribe);
            this.Controls.Add(this.textBox_Topic);
            this.Controls.Add(this.label_Topic);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MQTT Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ItemSetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_Topic;
        private System.Windows.Forms.TextBox textBox_Topic;
        private System.Windows.Forms.CheckBox checkBox_Subscribe;
        private System.Windows.Forms.CheckBox checkBox_Publish;
    }
}