// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleIndicator
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
            this.checkBox_ShowUnits = new System.Windows.Forms.CheckBox();
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.colorEdit_TextColor = new DevExpress.XtraEditors.ColorEdit();
            this.label_TextColor = new System.Windows.Forms.Label();
            this.colorEdit_BackColor = new DevExpress.XtraEditors.ColorEdit();
            this.label_BackColor = new System.Windows.Forms.Label();
            this.textBox_Units = new System.Windows.Forms.TextBox();
            this.label_Round = new System.Windows.Forms.Label();
            this.spinEdit_Round = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_TextColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BackColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_ShowUnits
            // 
            this.checkBox_ShowUnits.AutoSize = true;
            this.checkBox_ShowUnits.Location = new System.Drawing.Point(9, 69);
            this.checkBox_ShowUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_ShowUnits.Name = "checkBox_ShowUnits";
            this.checkBox_ShowUnits.Size = new System.Drawing.Size(100, 21);
            this.checkBox_ShowUnits.TabIndex = 3;
            this.checkBox_ShowUnits.Text = "Show Units";
            this.checkBox_ShowUnits.UseVisualStyleBackColor = true;
            this.checkBox_ShowUnits.CheckedChanged += new System.EventHandler(this.checkBox_ShowUnits_CheckedChanged);
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(71, 4);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(217, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(4, 9);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 25;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // colorEdit_TextColor
            // 
            this.colorEdit_TextColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_TextColor.Location = new System.Drawing.Point(96, 96);
            this.colorEdit_TextColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_TextColor.Name = "colorEdit_TextColor";
            this.colorEdit_TextColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_TextColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_TextColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_TextColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_TextColor.Size = new System.Drawing.Size(193, 24);
            this.colorEdit_TextColor.TabIndex = 5;
            this.colorEdit_TextColor.ColorChanged += new System.EventHandler(this.colorEdit_TextColor_ColorChanged);
            // 
            // label_TextColor
            // 
            this.label_TextColor.AutoSize = true;
            this.label_TextColor.Location = new System.Drawing.Point(12, 102);
            this.label_TextColor.Name = "label_TextColor";
            this.label_TextColor.Size = new System.Drawing.Size(76, 17);
            this.label_TextColor.TabIndex = 34;
            this.label_TextColor.Text = "Text Color:";
            // 
            // colorEdit_BackColor
            // 
            this.colorEdit_BackColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_BackColor.Location = new System.Drawing.Point(95, 128);
            this.colorEdit_BackColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_BackColor.Name = "colorEdit_BackColor";
            this.colorEdit_BackColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_BackColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_BackColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_BackColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_BackColor.Size = new System.Drawing.Size(195, 24);
            this.colorEdit_BackColor.TabIndex = 6;
            this.colorEdit_BackColor.ColorChanged += new System.EventHandler(this.colorEdit_BackColor_ColorChanged);
            // 
            // label_BackColor
            // 
            this.label_BackColor.AutoSize = true;
            this.label_BackColor.Location = new System.Drawing.Point(7, 134);
            this.label_BackColor.Name = "label_BackColor";
            this.label_BackColor.Size = new System.Drawing.Size(80, 17);
            this.label_BackColor.TabIndex = 36;
            this.label_BackColor.Text = "Back Color:";
            // 
            // textBox_Units
            // 
            this.textBox_Units.Location = new System.Drawing.Point(123, 66);
            this.textBox_Units.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Units.Name = "textBox_Units";
            this.textBox_Units.Size = new System.Drawing.Size(165, 22);
            this.textBox_Units.TabIndex = 4;
            this.textBox_Units.TextChanged += new System.EventHandler(this.textBox_Units_TextChanged);
            // 
            // label_Round
            // 
            this.label_Round.AutoSize = true;
            this.label_Round.Location = new System.Drawing.Point(9, 38);
            this.label_Round.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Round.Name = "label_Round";
            this.label_Round.Size = new System.Drawing.Size(54, 17);
            this.label_Round.TabIndex = 38;
            this.label_Round.Text = "Round:";
            // 
            // spinEdit_Round
            // 
            this.spinEdit_Round.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Round.Location = new System.Drawing.Point(71, 33);
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
            this.spinEdit_Round.TabIndex = 2;
            this.spinEdit_Round.EditValueChanged += new System.EventHandler(this.spinEdit_Round_EditValueChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 159);
            this.Controls.Add(this.spinEdit_Round);
            this.Controls.Add(this.label_Round);
            this.Controls.Add(this.textBox_Units);
            this.Controls.Add(this.colorEdit_BackColor);
            this.Controls.Add(this.label_BackColor);
            this.Controls.Add(this.colorEdit_TextColor);
            this.Controls.Add(this.label_TextColor);
            this.Controls.Add(this.textBox_ToolTip);
            this.Controls.Add(this.label_ToolTip);
            this.Controls.Add(this.checkBox_ShowUnits);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Indicator";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_TextColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BackColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_ShowUnits;
        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private DevExpress.XtraEditors.ColorEdit colorEdit_TextColor;
        private System.Windows.Forms.Label label_TextColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_BackColor;
        private System.Windows.Forms.Label label_BackColor;
        private System.Windows.Forms.TextBox textBox_Units;
        private System.Windows.Forms.Label label_Round;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Round;
    }
}