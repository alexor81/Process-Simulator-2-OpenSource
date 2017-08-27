// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleSlidingScale
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
            this.groupBox_Color = new System.Windows.Forms.GroupBox();
            this.checkBox_Shadow = new System.Windows.Forms.CheckBox();
            this.colorEdit_Shadow = new DevExpress.XtraEditors.ColorEdit();
            this.label_ShadowColor = new System.Windows.Forms.Label();
            this.colorEdit_Body = new DevExpress.XtraEditors.ColorEdit();
            this.colorEdit_Scale = new DevExpress.XtraEditors.ColorEdit();
            this.label_BodyColor = new System.Windows.Forms.Label();
            this.label_ScaleColor = new System.Windows.Forms.Label();
            this.label_NeedleColor = new System.Windows.Forms.Label();
            this.colorEdit_Needle = new DevExpress.XtraEditors.ColorEdit();
            this.spinEdit_LT_Count = new DevExpress.XtraEditors.SpinEdit();
            this.label_LT_Count = new System.Windows.Forms.Label();
            this.groupBox_LargeTicks = new System.Windows.Forms.GroupBox();
            this.spinEdit_LT_Length = new DevExpress.XtraEditors.SpinEdit();
            this.label_LT_Length = new System.Windows.Forms.Label();
            this.groupBox_SmallTicks = new System.Windows.Forms.GroupBox();
            this.spinEdit_ST_Length = new DevExpress.XtraEditors.SpinEdit();
            this.label_ST_Count = new System.Windows.Forms.Label();
            this.label_ST_Length = new System.Windows.Forms.Label();
            this.spinEdit_ST_Count = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox_Color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Shadow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Body.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Scale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Needle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LT_Count.Properties)).BeginInit();
            this.groupBox_LargeTicks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LT_Length.Properties)).BeginInit();
            this.groupBox_SmallTicks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_ST_Length.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_ST_Count.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(77, 14);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(207, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(12, 17);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 33;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // groupBox_Color
            // 
            this.groupBox_Color.Controls.Add(this.checkBox_Shadow);
            this.groupBox_Color.Controls.Add(this.colorEdit_Shadow);
            this.groupBox_Color.Controls.Add(this.label_ShadowColor);
            this.groupBox_Color.Controls.Add(this.colorEdit_Body);
            this.groupBox_Color.Controls.Add(this.colorEdit_Scale);
            this.groupBox_Color.Controls.Add(this.label_BodyColor);
            this.groupBox_Color.Controls.Add(this.label_ScaleColor);
            this.groupBox_Color.Controls.Add(this.label_NeedleColor);
            this.groupBox_Color.Controls.Add(this.colorEdit_Needle);
            this.groupBox_Color.Location = new System.Drawing.Point(10, 42);
            this.groupBox_Color.Name = "groupBox_Color";
            this.groupBox_Color.Size = new System.Drawing.Size(280, 170);
            this.groupBox_Color.TabIndex = 1;
            this.groupBox_Color.TabStop = false;
            this.groupBox_Color.Text = "Color";
            // 
            // checkBox_Shadow
            // 
            this.checkBox_Shadow.AutoSize = true;
            this.checkBox_Shadow.Location = new System.Drawing.Point(76, 105);
            this.checkBox_Shadow.Name = "checkBox_Shadow";
            this.checkBox_Shadow.Size = new System.Drawing.Size(80, 21);
            this.checkBox_Shadow.TabIndex = 3;
            this.checkBox_Shadow.Text = "Shadow";
            this.checkBox_Shadow.UseVisualStyleBackColor = true;
            this.checkBox_Shadow.CheckedChanged += new System.EventHandler(this.checkBox_Shadow_CheckedChanged);
            // 
            // colorEdit_Shadow
            // 
            this.colorEdit_Shadow.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Shadow.Location = new System.Drawing.Point(76, 135);
            this.colorEdit_Shadow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Shadow.Name = "colorEdit_Shadow";
            this.colorEdit_Shadow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Shadow.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Shadow.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Shadow.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Shadow.Size = new System.Drawing.Size(198, 24);
            this.colorEdit_Shadow.TabIndex = 4;
            this.colorEdit_Shadow.EditValueChanged += new System.EventHandler(this.colorEdit_Shadow_EditValueChanged);
            // 
            // label_ShadowColor
            // 
            this.label_ShadowColor.AutoSize = true;
            this.label_ShadowColor.Location = new System.Drawing.Point(6, 139);
            this.label_ShadowColor.Name = "label_ShadowColor";
            this.label_ShadowColor.Size = new System.Drawing.Size(62, 17);
            this.label_ShadowColor.TabIndex = 44;
            this.label_ShadowColor.Text = "Shadow:";
            // 
            // colorEdit_Body
            // 
            this.colorEdit_Body.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Body.Location = new System.Drawing.Point(76, 76);
            this.colorEdit_Body.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Body.Name = "colorEdit_Body";
            this.colorEdit_Body.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Body.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Body.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Body.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Body.Size = new System.Drawing.Size(198, 24);
            this.colorEdit_Body.TabIndex = 2;
            this.colorEdit_Body.EditValueChanged += new System.EventHandler(this.colorEdit_Body_EditValueChanged);
            // 
            // colorEdit_Scale
            // 
            this.colorEdit_Scale.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Scale.Location = new System.Drawing.Point(76, 48);
            this.colorEdit_Scale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Scale.Name = "colorEdit_Scale";
            this.colorEdit_Scale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Scale.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Scale.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Scale.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Scale.Size = new System.Drawing.Size(198, 24);
            this.colorEdit_Scale.TabIndex = 1;
            this.colorEdit_Scale.EditValueChanged += new System.EventHandler(this.colorEdit_Scale_EditValueChanged);
            // 
            // label_BodyColor
            // 
            this.label_BodyColor.AutoSize = true;
            this.label_BodyColor.Location = new System.Drawing.Point(24, 80);
            this.label_BodyColor.Name = "label_BodyColor";
            this.label_BodyColor.Size = new System.Drawing.Size(44, 17);
            this.label_BodyColor.TabIndex = 38;
            this.label_BodyColor.Text = "Body:";
            // 
            // label_ScaleColor
            // 
            this.label_ScaleColor.AutoSize = true;
            this.label_ScaleColor.Location = new System.Drawing.Point(21, 52);
            this.label_ScaleColor.Name = "label_ScaleColor";
            this.label_ScaleColor.Size = new System.Drawing.Size(47, 17);
            this.label_ScaleColor.TabIndex = 42;
            this.label_ScaleColor.Text = "Scale:";
            // 
            // label_NeedleColor
            // 
            this.label_NeedleColor.AutoSize = true;
            this.label_NeedleColor.Location = new System.Drawing.Point(11, 24);
            this.label_NeedleColor.Name = "label_NeedleColor";
            this.label_NeedleColor.Size = new System.Drawing.Size(57, 17);
            this.label_NeedleColor.TabIndex = 40;
            this.label_NeedleColor.Text = "Needle:";
            // 
            // colorEdit_Needle
            // 
            this.colorEdit_Needle.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Needle.Location = new System.Drawing.Point(76, 20);
            this.colorEdit_Needle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Needle.Name = "colorEdit_Needle";
            this.colorEdit_Needle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Needle.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Needle.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Needle.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Needle.Size = new System.Drawing.Size(198, 24);
            this.colorEdit_Needle.TabIndex = 0;
            this.colorEdit_Needle.EditValueChanged += new System.EventHandler(this.colorEdit_Needle_EditValueChanged);
            // 
            // spinEdit_LT_Count
            // 
            this.spinEdit_LT_Count.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_LT_Count.Location = new System.Drawing.Point(79, 26);
            this.spinEdit_LT_Count.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_LT_Count.Name = "spinEdit_LT_Count";
            this.spinEdit_LT_Count.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_LT_Count.Properties.IsFloatValue = false;
            this.spinEdit_LT_Count.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_LT_Count.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_LT_Count.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_LT_Count.Properties.Mask.EditMask = "N00";
            this.spinEdit_LT_Count.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spinEdit_LT_Count.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_LT_Count.Size = new System.Drawing.Size(186, 24);
            this.spinEdit_LT_Count.TabIndex = 0;
            this.spinEdit_LT_Count.EditValueChanged += new System.EventHandler(this.spinEdit_LT_Count_EditValueChanged);
            // 
            // label_LT_Count
            // 
            this.label_LT_Count.AutoSize = true;
            this.label_LT_Count.Location = new System.Drawing.Point(22, 30);
            this.label_LT_Count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LT_Count.Name = "label_LT_Count";
            this.label_LT_Count.Size = new System.Drawing.Size(49, 17);
            this.label_LT_Count.TabIndex = 47;
            this.label_LT_Count.Text = "Count:";
            // 
            // groupBox_LargeTicks
            // 
            this.groupBox_LargeTicks.Controls.Add(this.spinEdit_LT_Length);
            this.groupBox_LargeTicks.Controls.Add(this.label_LT_Count);
            this.groupBox_LargeTicks.Controls.Add(this.label_LT_Length);
            this.groupBox_LargeTicks.Controls.Add(this.spinEdit_LT_Count);
            this.groupBox_LargeTicks.Location = new System.Drawing.Point(296, 1);
            this.groupBox_LargeTicks.Name = "groupBox_LargeTicks";
            this.groupBox_LargeTicks.Size = new System.Drawing.Size(280, 100);
            this.groupBox_LargeTicks.TabIndex = 2;
            this.groupBox_LargeTicks.TabStop = false;
            this.groupBox_LargeTicks.Text = "Large Ticks";
            // 
            // spinEdit_LT_Length
            // 
            this.spinEdit_LT_Length.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_LT_Length.Location = new System.Drawing.Point(79, 61);
            this.spinEdit_LT_Length.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_LT_Length.Name = "spinEdit_LT_Length";
            this.spinEdit_LT_Length.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_LT_Length.Properties.IsFloatValue = false;
            this.spinEdit_LT_Length.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_LT_Length.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_LT_Length.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_LT_Length.Properties.Mask.EditMask = "N00";
            this.spinEdit_LT_Length.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spinEdit_LT_Length.Size = new System.Drawing.Size(186, 24);
            this.spinEdit_LT_Length.TabIndex = 1;
            this.spinEdit_LT_Length.EditValueChanged += new System.EventHandler(this.spinEdit_LT_Length_EditValueChanged);
            // 
            // label_LT_Length
            // 
            this.label_LT_Length.AutoSize = true;
            this.label_LT_Length.Location = new System.Drawing.Point(15, 65);
            this.label_LT_Length.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LT_Length.Name = "label_LT_Length";
            this.label_LT_Length.Size = new System.Drawing.Size(56, 17);
            this.label_LT_Length.TabIndex = 49;
            this.label_LT_Length.Text = "Length:";
            // 
            // groupBox_SmallTicks
            // 
            this.groupBox_SmallTicks.Controls.Add(this.spinEdit_ST_Length);
            this.groupBox_SmallTicks.Controls.Add(this.label_ST_Count);
            this.groupBox_SmallTicks.Controls.Add(this.label_ST_Length);
            this.groupBox_SmallTicks.Controls.Add(this.spinEdit_ST_Count);
            this.groupBox_SmallTicks.Location = new System.Drawing.Point(296, 112);
            this.groupBox_SmallTicks.Name = "groupBox_SmallTicks";
            this.groupBox_SmallTicks.Size = new System.Drawing.Size(280, 100);
            this.groupBox_SmallTicks.TabIndex = 3;
            this.groupBox_SmallTicks.TabStop = false;
            this.groupBox_SmallTicks.Text = "Small Ticks";
            // 
            // spinEdit_ST_Length
            // 
            this.spinEdit_ST_Length.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_ST_Length.Location = new System.Drawing.Point(79, 61);
            this.spinEdit_ST_Length.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_ST_Length.Name = "spinEdit_ST_Length";
            this.spinEdit_ST_Length.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_ST_Length.Properties.IsFloatValue = false;
            this.spinEdit_ST_Length.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_ST_Length.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_ST_Length.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_ST_Length.Properties.Mask.EditMask = "N00";
            this.spinEdit_ST_Length.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spinEdit_ST_Length.Size = new System.Drawing.Size(186, 24);
            this.spinEdit_ST_Length.TabIndex = 1;
            this.spinEdit_ST_Length.EditValueChanged += new System.EventHandler(this.spinEdit_ST_Length_EditValueChanged);
            // 
            // label_ST_Count
            // 
            this.label_ST_Count.AutoSize = true;
            this.label_ST_Count.Location = new System.Drawing.Point(22, 30);
            this.label_ST_Count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ST_Count.Name = "label_ST_Count";
            this.label_ST_Count.Size = new System.Drawing.Size(49, 17);
            this.label_ST_Count.TabIndex = 47;
            this.label_ST_Count.Text = "Count:";
            // 
            // label_ST_Length
            // 
            this.label_ST_Length.AutoSize = true;
            this.label_ST_Length.Location = new System.Drawing.Point(15, 65);
            this.label_ST_Length.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ST_Length.Name = "label_ST_Length";
            this.label_ST_Length.Size = new System.Drawing.Size(56, 17);
            this.label_ST_Length.TabIndex = 49;
            this.label_ST_Length.Text = "Length:";
            // 
            // spinEdit_ST_Count
            // 
            this.spinEdit_ST_Count.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_ST_Count.Location = new System.Drawing.Point(79, 26);
            this.spinEdit_ST_Count.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_ST_Count.Name = "spinEdit_ST_Count";
            this.spinEdit_ST_Count.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_ST_Count.Properties.IsFloatValue = false;
            this.spinEdit_ST_Count.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_ST_Count.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_ST_Count.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_ST_Count.Properties.Mask.EditMask = "N00";
            this.spinEdit_ST_Count.Properties.MaxValue = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.spinEdit_ST_Count.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinEdit_ST_Count.Size = new System.Drawing.Size(186, 24);
            this.spinEdit_ST_Count.TabIndex = 0;
            this.spinEdit_ST_Count.EditValueChanged += new System.EventHandler(this.spinEdit_ST_Count_EditValueChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 218);
            this.Controls.Add(this.groupBox_SmallTicks);
            this.Controls.Add(this.groupBox_LargeTicks);
            this.Controls.Add(this.groupBox_Color);
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
            this.Text = "Sliding Scale";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Color.ResumeLayout(false);
            this.groupBox_Color.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Shadow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Body.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Scale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Needle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LT_Count.Properties)).EndInit();
            this.groupBox_LargeTicks.ResumeLayout(false);
            this.groupBox_LargeTicks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LT_Length.Properties)).EndInit();
            this.groupBox_SmallTicks.ResumeLayout(false);
            this.groupBox_SmallTicks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_ST_Length.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_ST_Count.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.GroupBox groupBox_Color;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Body;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Scale;
        private System.Windows.Forms.Label label_BodyColor;
        private System.Windows.Forms.Label label_ScaleColor;
        private System.Windows.Forms.Label label_NeedleColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Needle;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Shadow;
        private System.Windows.Forms.Label label_ShadowColor;
        private System.Windows.Forms.CheckBox checkBox_Shadow;
        private DevExpress.XtraEditors.SpinEdit spinEdit_LT_Count;
        private System.Windows.Forms.Label label_LT_Count;
        private System.Windows.Forms.GroupBox groupBox_LargeTicks;
        private DevExpress.XtraEditors.SpinEdit spinEdit_LT_Length;
        private System.Windows.Forms.Label label_LT_Length;
        private System.Windows.Forms.GroupBox groupBox_SmallTicks;
        private DevExpress.XtraEditors.SpinEdit spinEdit_ST_Length;
        private System.Windows.Forms.Label label_ST_Count;
        private System.Windows.Forms.Label label_ST_Length;
        private DevExpress.XtraEditors.SpinEdit spinEdit_ST_Count;
    }
}