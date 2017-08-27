// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.VectorImage.ElementRectangle
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
            this.label_X = new System.Windows.Forms.Label();
            this.label_Y = new System.Windows.Forms.Label();
            this.label_Width = new System.Windows.Forms.Label();
            this.label_Height = new System.Windows.Forms.Label();
            this.label_BorderColor = new System.Windows.Forms.Label();
            this.label_BorderWidth = new System.Windows.Forms.Label();
            this.label_FillColor = new System.Windows.Forms.Label();
            this.colorEdit_BorderColor = new DevExpress.XtraEditors.ColorEdit();
            this.colorEdit_FillColor = new DevExpress.XtraEditors.ColorEdit();
            this.spinEdit_X = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Width = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Height = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_BorderWidth = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Y = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BorderColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_FillColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_X.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Width.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Height.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_BorderWidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Y.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label_X
            // 
            this.label_X.AutoSize = true;
            this.label_X.Location = new System.Drawing.Point(84, 13);
            this.label_X.Name = "label_X";
            this.label_X.Size = new System.Drawing.Size(21, 17);
            this.label_X.TabIndex = 0;
            this.label_X.Text = "X:";
            // 
            // label_Y
            // 
            this.label_Y.AutoSize = true;
            this.label_Y.Location = new System.Drawing.Point(84, 43);
            this.label_Y.Name = "label_Y";
            this.label_Y.Size = new System.Drawing.Size(21, 17);
            this.label_Y.TabIndex = 1;
            this.label_Y.Text = "Y:";
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(57, 73);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(48, 17);
            this.label_Width.TabIndex = 2;
            this.label_Width.Text = "Width:";
            // 
            // label_Height
            // 
            this.label_Height.AutoSize = true;
            this.label_Height.Location = new System.Drawing.Point(52, 103);
            this.label_Height.Name = "label_Height";
            this.label_Height.Size = new System.Drawing.Size(53, 17);
            this.label_Height.TabIndex = 3;
            this.label_Height.Text = "Height:";
            // 
            // label_BorderColor
            // 
            this.label_BorderColor.AutoSize = true;
            this.label_BorderColor.Location = new System.Drawing.Point(13, 133);
            this.label_BorderColor.Name = "label_BorderColor";
            this.label_BorderColor.Size = new System.Drawing.Size(92, 17);
            this.label_BorderColor.TabIndex = 4;
            this.label_BorderColor.Text = "Border Color:";
            // 
            // label_BorderWidth
            // 
            this.label_BorderWidth.AutoSize = true;
            this.label_BorderWidth.Location = new System.Drawing.Point(10, 163);
            this.label_BorderWidth.Name = "label_BorderWidth";
            this.label_BorderWidth.Size = new System.Drawing.Size(95, 17);
            this.label_BorderWidth.TabIndex = 5;
            this.label_BorderWidth.Text = "Border Width:";
            // 
            // label_FillColor
            // 
            this.label_FillColor.AutoSize = true;
            this.label_FillColor.Location = new System.Drawing.Point(39, 193);
            this.label_FillColor.Name = "label_FillColor";
            this.label_FillColor.Size = new System.Drawing.Size(66, 17);
            this.label_FillColor.TabIndex = 6;
            this.label_FillColor.Text = "Fill Color:";
            // 
            // colorEdit_BorderColor
            // 
            this.colorEdit_BorderColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_BorderColor.Location = new System.Drawing.Point(111, 129);
            this.colorEdit_BorderColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_BorderColor.Name = "colorEdit_BorderColor";
            this.colorEdit_BorderColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_BorderColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_BorderColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_BorderColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_BorderColor.Size = new System.Drawing.Size(162, 24);
            this.colorEdit_BorderColor.TabIndex = 4;
            this.colorEdit_BorderColor.EditValueChanged += new System.EventHandler(this.colorEdit_BorderColor_EditValueChanged);
            // 
            // colorEdit_FillColor
            // 
            this.colorEdit_FillColor.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_FillColor.Location = new System.Drawing.Point(111, 189);
            this.colorEdit_FillColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_FillColor.Name = "colorEdit_FillColor";
            this.colorEdit_FillColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_FillColor.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_FillColor.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_FillColor.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_FillColor.Size = new System.Drawing.Size(162, 24);
            this.colorEdit_FillColor.TabIndex = 6;
            this.colorEdit_FillColor.EditValueChanged += new System.EventHandler(this.colorEdit_FillColor_EditValueChanged);
            // 
            // spinEdit_X
            // 
            this.spinEdit_X.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_X.Location = new System.Drawing.Point(111, 9);
            this.spinEdit_X.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_X.Name = "spinEdit_X";
            this.spinEdit_X.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_X.Properties.IsFloatValue = false;
            this.spinEdit_X.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_X.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_X.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_X.Properties.Mask.EditMask = "N00";
            this.spinEdit_X.Size = new System.Drawing.Size(162, 24);
            this.spinEdit_X.TabIndex = 0;
            this.spinEdit_X.EditValueChanged += new System.EventHandler(this.spinEdit_X_EditValueChanged);
            // 
            // spinEdit_Width
            // 
            this.spinEdit_Width.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Width.Location = new System.Drawing.Point(111, 69);
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
            this.spinEdit_Width.Size = new System.Drawing.Size(162, 24);
            this.spinEdit_Width.TabIndex = 2;
            this.spinEdit_Width.EditValueChanged += new System.EventHandler(this.spinEdit_Width_EditValueChanged);
            // 
            // spinEdit_Height
            // 
            this.spinEdit_Height.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Height.Location = new System.Drawing.Point(110, 99);
            this.spinEdit_Height.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Height.Name = "spinEdit_Height";
            this.spinEdit_Height.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Height.Properties.IsFloatValue = false;
            this.spinEdit_Height.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Height.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Height.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Height.Properties.Mask.EditMask = "N00";
            this.spinEdit_Height.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_Height.Size = new System.Drawing.Size(162, 24);
            this.spinEdit_Height.TabIndex = 3;
            this.spinEdit_Height.EditValueChanged += new System.EventHandler(this.spinEdit_Height_EditValueChanged);
            // 
            // spinEdit_BorderWidth
            // 
            this.spinEdit_BorderWidth.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_BorderWidth.Location = new System.Drawing.Point(110, 159);
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
            this.spinEdit_BorderWidth.TabIndex = 5;
            this.spinEdit_BorderWidth.EditValueChanged += new System.EventHandler(this.spinEdit_BorderWidth_EditValueChanged);
            // 
            // spinEdit_Y
            // 
            this.spinEdit_Y.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Y.Location = new System.Drawing.Point(110, 39);
            this.spinEdit_Y.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Y.Name = "spinEdit_Y";
            this.spinEdit_Y.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Y.Properties.IsFloatValue = false;
            this.spinEdit_Y.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Y.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Y.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Y.Properties.Mask.EditMask = "N00";
            this.spinEdit_Y.Size = new System.Drawing.Size(162, 24);
            this.spinEdit_Y.TabIndex = 1;
            this.spinEdit_Y.EditValueChanged += new System.EventHandler(this.spinEdit_Y_EditValueChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 222);
            this.Controls.Add(this.spinEdit_Y);
            this.Controls.Add(this.spinEdit_BorderWidth);
            this.Controls.Add(this.spinEdit_Height);
            this.Controls.Add(this.spinEdit_Width);
            this.Controls.Add(this.spinEdit_X);
            this.Controls.Add(this.colorEdit_FillColor);
            this.Controls.Add(this.colorEdit_BorderColor);
            this.Controls.Add(this.label_FillColor);
            this.Controls.Add(this.label_BorderWidth);
            this.Controls.Add(this.label_BorderColor);
            this.Controls.Add(this.label_Height);
            this.Controls.Add(this.label_Width);
            this.Controls.Add(this.label_Y);
            this.Controls.Add(this.label_X);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rectangle";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_BorderColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_FillColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_X.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Width.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Height.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_BorderWidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Y.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_X;
        private System.Windows.Forms.Label label_Y;
        private System.Windows.Forms.Label label_Width;
        private System.Windows.Forms.Label label_Height;
        private System.Windows.Forms.Label label_BorderColor;
        private System.Windows.Forms.Label label_BorderWidth;
        private System.Windows.Forms.Label label_FillColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_BorderColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_FillColor;
        private DevExpress.XtraEditors.SpinEdit spinEdit_X;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Width;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Height;
        private DevExpress.XtraEditors.SpinEdit spinEdit_BorderWidth;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Y;
    }
}