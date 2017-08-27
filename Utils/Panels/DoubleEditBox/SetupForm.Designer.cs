// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleEditBox
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
            this.textBox_Units = new System.Windows.Forms.TextBox();
            this.checkBox_ShowUnits = new System.Windows.Forms.CheckBox();
            this.label_Round = new System.Windows.Forms.Label();
            this.spinEdit_Round = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(73, 4);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(217, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(6, 9);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 28;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // textBox_Units
            // 
            this.textBox_Units.Location = new System.Drawing.Point(125, 64);
            this.textBox_Units.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Units.Name = "textBox_Units";
            this.textBox_Units.Size = new System.Drawing.Size(165, 22);
            this.textBox_Units.TabIndex = 3;
            this.textBox_Units.TextChanged += new System.EventHandler(this.textBox_Units_TextChanged);
            // 
            // checkBox_ShowUnits
            // 
            this.checkBox_ShowUnits.AutoSize = true;
            this.checkBox_ShowUnits.Location = new System.Drawing.Point(11, 66);
            this.checkBox_ShowUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_ShowUnits.Name = "checkBox_ShowUnits";
            this.checkBox_ShowUnits.Size = new System.Drawing.Size(100, 21);
            this.checkBox_ShowUnits.TabIndex = 2;
            this.checkBox_ShowUnits.Text = "Show Units";
            this.checkBox_ShowUnits.UseVisualStyleBackColor = true;
            this.checkBox_ShowUnits.CheckedChanged += new System.EventHandler(this.checkBox_ShowUnits_CheckedChanged);
            // 
            // label_Round
            // 
            this.label_Round.AutoSize = true;
            this.label_Round.Location = new System.Drawing.Point(11, 38);
            this.label_Round.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Round.Name = "label_Round";
            this.label_Round.Size = new System.Drawing.Size(54, 17);
            this.label_Round.TabIndex = 40;
            this.label_Round.Text = "Round:";
            // 
            // spinEdit_Round
            // 
            this.spinEdit_Round.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Round.Location = new System.Drawing.Point(73, 33);
            this.spinEdit_Round.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Round.Name = "spinEdit_Round";
            this.spinEdit_Round.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Round.Properties.IsFloatValue = false;
            this.spinEdit_Round.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Round.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Round.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Round.Properties.Mask.EditMask = "N00";
            this.spinEdit_Round.Properties.MaxValue = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.spinEdit_Round.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEdit_Round.Size = new System.Drawing.Size(219, 24);
            this.spinEdit_Round.TabIndex = 1;
            this.spinEdit_Round.EditValueChanged += new System.EventHandler(this.spinEdit_Round_EditValueChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 101);
            this.Controls.Add(this.spinEdit_Round);
            this.Controls.Add(this.label_Round);
            this.Controls.Add(this.textBox_Units);
            this.Controls.Add(this.checkBox_ShowUnits);
            this.Controls.Add(this.textBox_ToolTip);
            this.Controls.Add(this.label_ToolTip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditBox";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.TextBox textBox_Units;
        private System.Windows.Forms.CheckBox checkBox_ShowUnits;
        private System.Windows.Forms.Label label_Round;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Round;
    }
}