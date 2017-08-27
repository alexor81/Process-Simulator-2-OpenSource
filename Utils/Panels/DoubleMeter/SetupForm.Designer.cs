// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleMeter
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
            this.Min = new System.Windows.Forms.Label();
            this.Max = new System.Windows.Forms.Label();
            this.textBox_Min = new System.Windows.Forms.TextBox();
            this.textBox_Max = new System.Windows.Forms.TextBox();
            this.groupBox_Value = new System.Windows.Forms.GroupBox();
            this.Set = new System.Windows.Forms.Button();
            this.colorEdit_Body = new DevExpress.XtraEditors.ColorEdit();
            this.label_BodyColor = new System.Windows.Forms.Label();
            this.colorEdit_Needle = new DevExpress.XtraEditors.ColorEdit();
            this.label_NeedleColor = new System.Windows.Forms.Label();
            this.colorEdit_Scale = new DevExpress.XtraEditors.ColorEdit();
            this.label_ScaleColor = new System.Windows.Forms.Label();
            this.groupBox_Color = new System.Windows.Forms.GroupBox();
            this.groupBox_Value.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Body.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Needle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Scale.Properties)).BeginInit();
            this.groupBox_Color.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(72, 11);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(217, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(7, 14);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 31;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // Min
            // 
            this.Min.AutoSize = true;
            this.Min.Location = new System.Drawing.Point(45, 57);
            this.Min.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(34, 17);
            this.Min.TabIndex = 35;
            this.Min.Text = "Min:";
            // 
            // Max
            // 
            this.Max.AutoSize = true;
            this.Max.Location = new System.Drawing.Point(42, 27);
            this.Max.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(37, 17);
            this.Max.TabIndex = 34;
            this.Max.Text = "Max:";
            // 
            // textBox_Min
            // 
            this.textBox_Min.Location = new System.Drawing.Point(84, 54);
            this.textBox_Min.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Min.Name = "textBox_Min";
            this.textBox_Min.Size = new System.Drawing.Size(161, 22);
            this.textBox_Min.TabIndex = 1;
            this.textBox_Min.Text = "0";
            // 
            // textBox_Max
            // 
            this.textBox_Max.Location = new System.Drawing.Point(84, 24);
            this.textBox_Max.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Max.Name = "textBox_Max";
            this.textBox_Max.Size = new System.Drawing.Size(161, 22);
            this.textBox_Max.TabIndex = 0;
            this.textBox_Max.Text = "100";
            // 
            // groupBox_Value
            // 
            this.groupBox_Value.Controls.Add(this.Set);
            this.groupBox_Value.Controls.Add(this.textBox_Max);
            this.groupBox_Value.Controls.Add(this.Min);
            this.groupBox_Value.Controls.Add(this.Max);
            this.groupBox_Value.Controls.Add(this.textBox_Min);
            this.groupBox_Value.Location = new System.Drawing.Point(5, 156);
            this.groupBox_Value.Name = "groupBox_Value";
            this.groupBox_Value.Size = new System.Drawing.Size(286, 119);
            this.groupBox_Value.TabIndex = 2;
            this.groupBox_Value.TabStop = false;
            this.groupBox_Value.Text = "Value";
            // 
            // Set
            // 
            this.Set.Location = new System.Drawing.Point(106, 86);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(75, 25);
            this.Set.TabIndex = 2;
            this.Set.Text = "Set";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // colorEdit_Body
            // 
            this.colorEdit_Body.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Body.Location = new System.Drawing.Point(77, 20);
            this.colorEdit_Body.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Body.Name = "colorEdit_Body";
            this.colorEdit_Body.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Body.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Body.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Body.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Body.Size = new System.Drawing.Size(198, 24);
            this.colorEdit_Body.TabIndex = 0;
            this.colorEdit_Body.EditValueChanged += new System.EventHandler(this.colorEdit_Body_EditValueChanged);
            // 
            // label_BodyColor
            // 
            this.label_BodyColor.AutoSize = true;
            this.label_BodyColor.Location = new System.Drawing.Point(25, 24);
            this.label_BodyColor.Name = "label_BodyColor";
            this.label_BodyColor.Size = new System.Drawing.Size(44, 17);
            this.label_BodyColor.TabIndex = 38;
            this.label_BodyColor.Text = "Body:";
            // 
            // colorEdit_Needle
            // 
            this.colorEdit_Needle.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Needle.Location = new System.Drawing.Point(77, 48);
            this.colorEdit_Needle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Needle.Name = "colorEdit_Needle";
            this.colorEdit_Needle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Needle.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Needle.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Needle.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Needle.Size = new System.Drawing.Size(198, 24);
            this.colorEdit_Needle.TabIndex = 1;
            this.colorEdit_Needle.EditValueChanged += new System.EventHandler(this.colorEdit_Needle_EditValueChanged);
            // 
            // label_NeedleColor
            // 
            this.label_NeedleColor.AutoSize = true;
            this.label_NeedleColor.Location = new System.Drawing.Point(12, 52);
            this.label_NeedleColor.Name = "label_NeedleColor";
            this.label_NeedleColor.Size = new System.Drawing.Size(57, 17);
            this.label_NeedleColor.TabIndex = 40;
            this.label_NeedleColor.Text = "Needle:";
            // 
            // colorEdit_Scale
            // 
            this.colorEdit_Scale.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Scale.Location = new System.Drawing.Point(77, 76);
            this.colorEdit_Scale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Scale.Name = "colorEdit_Scale";
            this.colorEdit_Scale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Scale.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Scale.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Scale.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Scale.Size = new System.Drawing.Size(198, 24);
            this.colorEdit_Scale.TabIndex = 2;
            this.colorEdit_Scale.EditValueChanged += new System.EventHandler(this.colorEdit_Scale_EditValueChanged);
            // 
            // label_ScaleColor
            // 
            this.label_ScaleColor.AutoSize = true;
            this.label_ScaleColor.Location = new System.Drawing.Point(22, 80);
            this.label_ScaleColor.Name = "label_ScaleColor";
            this.label_ScaleColor.Size = new System.Drawing.Size(47, 17);
            this.label_ScaleColor.TabIndex = 42;
            this.label_ScaleColor.Text = "Scale:";
            // 
            // groupBox_Color
            // 
            this.groupBox_Color.Controls.Add(this.colorEdit_Body);
            this.groupBox_Color.Controls.Add(this.colorEdit_Scale);
            this.groupBox_Color.Controls.Add(this.label_BodyColor);
            this.groupBox_Color.Controls.Add(this.label_ScaleColor);
            this.groupBox_Color.Controls.Add(this.label_NeedleColor);
            this.groupBox_Color.Controls.Add(this.colorEdit_Needle);
            this.groupBox_Color.Location = new System.Drawing.Point(5, 38);
            this.groupBox_Color.Name = "groupBox_Color";
            this.groupBox_Color.Size = new System.Drawing.Size(286, 112);
            this.groupBox_Color.TabIndex = 1;
            this.groupBox_Color.TabStop = false;
            this.groupBox_Color.Text = "Color";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 279);
            this.Controls.Add(this.groupBox_Color);
            this.Controls.Add(this.groupBox_Value);
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
            this.Text = "Meter";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Value.ResumeLayout(false);
            this.groupBox_Value.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Body.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Needle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Scale.Properties)).EndInit();
            this.groupBox_Color.ResumeLayout(false);
            this.groupBox_Color.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.Label Min;
        private System.Windows.Forms.Label Max;
        private System.Windows.Forms.TextBox textBox_Min;
        private System.Windows.Forms.TextBox textBox_Max;
        private System.Windows.Forms.GroupBox groupBox_Value;
        private System.Windows.Forms.Button Set;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Body;
        private System.Windows.Forms.Label label_BodyColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Needle;
        private System.Windows.Forms.Label label_NeedleColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Scale;
        private System.Windows.Forms.Label label_ScaleColor;
        private System.Windows.Forms.GroupBox groupBox_Color;
    }
}