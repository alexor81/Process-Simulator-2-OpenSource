// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.StringTextEditor
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
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(72, 14);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(211, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(7, 17);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 4;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(23, 55);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(44, 17);
            this.labelType.TabIndex = 5;
            this.labelType.Text = "Type:";
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(72, 51);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(211, 24);
            this.comboBox_Type.TabIndex = 1;
            this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 88);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.textBox_ToolTip);
            this.Controls.Add(this.label_ToolTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Text Editor";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBox_Type;
    }
}