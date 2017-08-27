// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanSymbol
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.groupBox_True = new System.Windows.Forms.GroupBox();
            this.comboBox_True = new System.Windows.Forms.ComboBox();
            this.button_TrueSetup = new System.Windows.Forms.Button();
            this.pictureBox_True = new System.Windows.Forms.PictureBox();
            this.groupBox_False = new System.Windows.Forms.GroupBox();
            this.comboBox_False = new System.Windows.Forms.ComboBox();
            this.button_FalseSetup = new System.Windows.Forms.Button();
            this.pictureBox_False = new System.Windows.Forms.PictureBox();
            this.groupBox_True.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_True)).BeginInit();
            this.groupBox_False.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_False)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(73, 10);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(361, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(8, 13);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 34;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // groupBox_True
            // 
            this.groupBox_True.Controls.Add(this.comboBox_True);
            this.groupBox_True.Controls.Add(this.button_TrueSetup);
            this.groupBox_True.Controls.Add(this.pictureBox_True);
            this.groupBox_True.Location = new System.Drawing.Point(6, 40);
            this.groupBox_True.Name = "groupBox_True";
            this.groupBox_True.Size = new System.Drawing.Size(210, 246);
            this.groupBox_True.TabIndex = 1;
            this.groupBox_True.TabStop = false;
            this.groupBox_True.Text = "True";
            // 
            // comboBox_True
            // 
            this.comboBox_True.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_True.FormattingEnabled = true;
            this.comboBox_True.Location = new System.Drawing.Point(14, 32);
            this.comboBox_True.Name = "comboBox_True";
            this.comboBox_True.Size = new System.Drawing.Size(182, 24);
            this.comboBox_True.TabIndex = 0;
            this.comboBox_True.SelectedIndexChanged += new System.EventHandler(this.comboBox_True_SelectedIndexChanged);
            // 
            // button_TrueSetup
            // 
            this.button_TrueSetup.Location = new System.Drawing.Point(68, 67);
            this.button_TrueSetup.Name = "button_TrueSetup";
            this.button_TrueSetup.Size = new System.Drawing.Size(75, 30);
            this.button_TrueSetup.TabIndex = 1;
            this.button_TrueSetup.Text = "Setup";
            this.button_TrueSetup.UseVisualStyleBackColor = true;
            this.button_TrueSetup.Click += new System.EventHandler(this.button_TrueSetup_Click);
            // 
            // pictureBox_True
            // 
            this.pictureBox_True.Location = new System.Drawing.Point(6, 107);
            this.pictureBox_True.Name = "pictureBox_True";
            this.pictureBox_True.Size = new System.Drawing.Size(198, 133);
            this.pictureBox_True.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_True.TabIndex = 0;
            this.pictureBox_True.TabStop = false;
            // 
            // groupBox_False
            // 
            this.groupBox_False.Controls.Add(this.comboBox_False);
            this.groupBox_False.Controls.Add(this.button_FalseSetup);
            this.groupBox_False.Controls.Add(this.pictureBox_False);
            this.groupBox_False.Location = new System.Drawing.Point(227, 40);
            this.groupBox_False.Name = "groupBox_False";
            this.groupBox_False.Size = new System.Drawing.Size(210, 246);
            this.groupBox_False.TabIndex = 2;
            this.groupBox_False.TabStop = false;
            this.groupBox_False.Text = "False";
            // 
            // comboBox_False
            // 
            this.comboBox_False.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_False.FormattingEnabled = true;
            this.comboBox_False.Location = new System.Drawing.Point(14, 32);
            this.comboBox_False.Name = "comboBox_False";
            this.comboBox_False.Size = new System.Drawing.Size(182, 24);
            this.comboBox_False.TabIndex = 0;
            this.comboBox_False.SelectedIndexChanged += new System.EventHandler(this.comboBox_False_SelectedIndexChanged);
            // 
            // button_FalseSetup
            // 
            this.button_FalseSetup.Location = new System.Drawing.Point(68, 67);
            this.button_FalseSetup.Name = "button_FalseSetup";
            this.button_FalseSetup.Size = new System.Drawing.Size(75, 30);
            this.button_FalseSetup.TabIndex = 1;
            this.button_FalseSetup.Text = "Setup";
            this.button_FalseSetup.UseVisualStyleBackColor = true;
            this.button_FalseSetup.Click += new System.EventHandler(this.button_FalseSetup_Click);
            // 
            // pictureBox_False
            // 
            this.pictureBox_False.Location = new System.Drawing.Point(6, 107);
            this.pictureBox_False.Name = "pictureBox_False";
            this.pictureBox_False.Size = new System.Drawing.Size(198, 133);
            this.pictureBox_False.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_False.TabIndex = 1;
            this.pictureBox_False.TabStop = false;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 292);
            this.Controls.Add(this.groupBox_False);
            this.Controls.Add(this.groupBox_True);
            this.Controls.Add(this.textBox_ToolTip);
            this.Controls.Add(this.label_ToolTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Symbol";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_True.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_True)).EndInit();
            this.groupBox_False.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_False)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.GroupBox groupBox_True;
        private System.Windows.Forms.GroupBox groupBox_False;
        private System.Windows.Forms.PictureBox pictureBox_True;
        private System.Windows.Forms.PictureBox pictureBox_False;
        private System.Windows.Forms.Button button_TrueSetup;
        private System.Windows.Forms.Button button_FalseSetup;
        private System.Windows.Forms.ComboBox comboBox_True;
        private System.Windows.Forms.ComboBox comboBox_False;
    }
}