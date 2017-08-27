// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanToggle
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
            this.label_Style = new System.Windows.Forms.Label();
            this.comboBox_Style = new System.Windows.Forms.ComboBox();
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Style
            // 
            this.label_Style.AutoSize = true;
            this.label_Style.Location = new System.Drawing.Point(28, 42);
            this.label_Style.Name = "label_Style";
            this.label_Style.Size = new System.Drawing.Size(43, 17);
            this.label_Style.TabIndex = 0;
            this.label_Style.Text = "Style:";
            // 
            // comboBox_Style
            // 
            this.comboBox_Style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Style.FormattingEnabled = true;
            this.comboBox_Style.Items.AddRange(new object[] {
            "Metro",
            "Android",
            "IOS5",
            "BrushedMetal",
            "OSX",
            "Carbon",
            "Iphone",
            "Fancy",
            "Modern"});
            this.comboBox_Style.Location = new System.Drawing.Point(78, 39);
            this.comboBox_Style.Name = "comboBox_Style";
            this.comboBox_Style.Size = new System.Drawing.Size(217, 24);
            this.comboBox_Style.TabIndex = 1;
            this.comboBox_Style.SelectedIndexChanged += new System.EventHandler(this.comboBox_Style_SelectedIndexChanged);
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(78, 12);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(217, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(11, 15);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 35;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 74);
            this.Controls.Add(this.textBox_ToolTip);
            this.Controls.Add(this.label_ToolTip);
            this.Controls.Add(this.comboBox_Style);
            this.Controls.Add(this.label_Style);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Toggle";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Style;
        private System.Windows.Forms.ComboBox comboBox_Style;
        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
    }
}