// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanSymbol.SymbolEllipse
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
            this.spinEdit_BorderWidth = new DevExpress.XtraEditors.SpinEdit();
            this.colorEdit_FillColor = new DevExpress.XtraEditors.ColorEdit();
            this.colorEdit_BorderColor = new DevExpress.XtraEditors.ColorEdit();
            this.label_FillColor = new System.Windows.Forms.Label();
            this.label_BorderWidth = new System.Windows.Forms.Label();
            this.label_BorderColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_BorderWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_FillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BorderColor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // spinEdit_BorderWidth
            // 
            this.spinEdit_BorderWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_BorderWidth.Location = new System.Drawing.Point(107, 41);
            this.spinEdit_BorderWidth.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_BorderWidth.Name = "spinEdit_BorderWidth";
            this.spinEdit_BorderWidth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_BorderWidth.Properties.IsFloatValue = false;
            this.spinEdit_BorderWidth.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_BorderWidth.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_BorderWidth.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_BorderWidth.Properties.Mask.EditMask = "N00";
            this.spinEdit_BorderWidth.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_BorderWidth.Size = new System.Drawing.Size(162, 24);
            this.spinEdit_BorderWidth.TabIndex = 1;
            this.spinEdit_BorderWidth.EditValueChanged += new System.EventHandler(this.spinEdit_BorderWidth_EditValueChanged);
            // 
            // colorEdit_FillColor
            // 
            this.colorEdit_FillColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_FillColor.Location = new System.Drawing.Point(108, 71);
            this.colorEdit_FillColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_FillColor.Name = "colorEdit_FillColor";
            this.colorEdit_FillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_FillColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_FillColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_FillColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_FillColor.Size = new System.Drawing.Size(162, 24);
            this.colorEdit_FillColor.TabIndex = 2;
            this.colorEdit_FillColor.EditValueChanged += new System.EventHandler(this.colorEdit_FillColor_EditValueChanged);
            // 
            // colorEdit_BorderColor
            // 
            this.colorEdit_BorderColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_BorderColor.Location = new System.Drawing.Point(108, 11);
            this.colorEdit_BorderColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_BorderColor.Name = "colorEdit_BorderColor";
            this.colorEdit_BorderColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_BorderColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_BorderColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_BorderColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_BorderColor.Size = new System.Drawing.Size(162, 24);
            this.colorEdit_BorderColor.TabIndex = 0;
            this.colorEdit_BorderColor.EditValueChanged += new System.EventHandler(this.colorEdit_BorderColor_EditValueChanged);
            // 
            // label_FillColor
            // 
            this.label_FillColor.AutoSize = true;
            this.label_FillColor.Location = new System.Drawing.Point(36, 75);
            this.label_FillColor.Name = "label_FillColor";
            this.label_FillColor.Size = new System.Drawing.Size(66, 17);
            this.label_FillColor.TabIndex = 12;
            this.label_FillColor.Text = "Fill Color:";
            // 
            // label_BorderWidth
            // 
            this.label_BorderWidth.AutoSize = true;
            this.label_BorderWidth.Location = new System.Drawing.Point(7, 45);
            this.label_BorderWidth.Name = "label_BorderWidth";
            this.label_BorderWidth.Size = new System.Drawing.Size(95, 17);
            this.label_BorderWidth.TabIndex = 10;
            this.label_BorderWidth.Text = "Border Width:";
            // 
            // label_BorderColor
            // 
            this.label_BorderColor.AutoSize = true;
            this.label_BorderColor.Location = new System.Drawing.Point(10, 15);
            this.label_BorderColor.Name = "label_BorderColor";
            this.label_BorderColor.Size = new System.Drawing.Size(92, 17);
            this.label_BorderColor.TabIndex = 8;
            this.label_BorderColor.Text = "Border Color:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 103);
            this.Controls.Add(this.spinEdit_BorderWidth);
            this.Controls.Add(this.colorEdit_FillColor);
            this.Controls.Add(this.colorEdit_BorderColor);
            this.Controls.Add(this.label_FillColor);
            this.Controls.Add(this.label_BorderWidth);
            this.Controls.Add(this.label_BorderColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ellipse";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_BorderWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_FillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BorderColor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit spinEdit_BorderWidth;
        private DevExpress.XtraEditors.ColorEdit colorEdit_FillColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_BorderColor;
        private System.Windows.Forms.Label label_FillColor;
        private System.Windows.Forms.Label label_BorderWidth;
        private System.Windows.Forms.Label label_BorderColor;
    }
}