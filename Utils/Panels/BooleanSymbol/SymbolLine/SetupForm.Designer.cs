// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanSymbol.SymbolLine
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
            this.spinEdit_Width = new DevExpress.XtraEditors.SpinEdit();
            this.colorEdit_Color = new DevExpress.XtraEditors.ColorEdit();
            this.label_Width = new System.Windows.Forms.Label();
            this.label_Color = new System.Windows.Forms.Label();
            this.spinEdit_Angle = new DevExpress.XtraEditors.SpinEdit();
            this.label_Angle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Width.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Angle.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEdit_Width
            // 
            this.spinEdit_Width.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Width.Location = new System.Drawing.Point(63, 42);
            this.spinEdit_Width.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Width.Name = "spinEdit_Width";
            this.spinEdit_Width.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Width.Properties.IsFloatValue = false;
            this.spinEdit_Width.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Width.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Width.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Width.Properties.Mask.EditMask = "N00";
            this.spinEdit_Width.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_Width.Size = new System.Drawing.Size(209, 24);
            this.spinEdit_Width.TabIndex = 1;
            this.spinEdit_Width.EditValueChanged += new System.EventHandler(this.spinEdit_Width_EditValueChanged);
            // 
            // colorEdit_Color
            // 
            this.colorEdit_Color.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Color.Location = new System.Drawing.Point(63, 12);
            this.colorEdit_Color.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Color.Name = "colorEdit_Color";
            this.colorEdit_Color.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Color.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Color.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Color.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Color.Size = new System.Drawing.Size(209, 24);
            this.colorEdit_Color.TabIndex = 0;
            this.colorEdit_Color.EditValueChanged += new System.EventHandler(this.colorEdit_Color_EditValueChanged);
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(9, 46);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(48, 17);
            this.label_Width.TabIndex = 14;
            this.label_Width.Text = "Width:";
            // 
            // label_Color
            // 
            this.label_Color.AutoSize = true;
            this.label_Color.Location = new System.Drawing.Point(12, 16);
            this.label_Color.Name = "label_Color";
            this.label_Color.Size = new System.Drawing.Size(45, 17);
            this.label_Color.TabIndex = 13;
            this.label_Color.Text = "Color:";
            // 
            // spinEdit_Angle
            // 
            this.spinEdit_Angle.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Angle.Location = new System.Drawing.Point(63, 72);
            this.spinEdit_Angle.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Angle.Name = "spinEdit_Angle";
            this.spinEdit_Angle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Angle.Properties.IsFloatValue = false;
            this.spinEdit_Angle.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Angle.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Angle.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Angle.Properties.Mask.EditMask = "N00";
            this.spinEdit_Angle.Properties.MaxValue = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.spinEdit_Angle.Size = new System.Drawing.Size(209, 24);
            this.spinEdit_Angle.TabIndex = 2;
            this.spinEdit_Angle.EditValueChanged += new System.EventHandler(this.spinEdit_Angle_EditValueChanged);
            // 
            // label_Angle
            // 
            this.label_Angle.AutoSize = true;
            this.label_Angle.Location = new System.Drawing.Point(9, 76);
            this.label_Angle.Name = "label_Angle";
            this.label_Angle.Size = new System.Drawing.Size(48, 17);
            this.label_Angle.TabIndex = 16;
            this.label_Angle.Text = "Angle:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 109);
            this.Controls.Add(this.spinEdit_Angle);
            this.Controls.Add(this.label_Angle);
            this.Controls.Add(this.spinEdit_Width);
            this.Controls.Add(this.colorEdit_Color);
            this.Controls.Add(this.label_Width);
            this.Controls.Add(this.label_Color);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Width.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Angle.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEdit_Width;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Color;
        private System.Windows.Forms.Label label_Width;
        private System.Windows.Forms.Label label_Color;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Angle;
        private System.Windows.Forms.Label label_Angle;
    }
}