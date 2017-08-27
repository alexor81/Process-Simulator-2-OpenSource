// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanSymbol.SymbolImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsButton_Import = new System.Windows.Forms.ToolStripButton();
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.labelControl_HW = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Import});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(272, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsButton_Import
            // 
            this.tsButton_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Import.Image = ((System.Drawing.Image)(resources.GetObject("tsButton_Import.Image")));
            this.tsButton_Import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Import.Name = "tsButton_Import";
            this.tsButton_Import.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Import.Text = "Import";
            this.tsButton_Import.Click += new System.EventHandler(this.tsButton_Import_Click);
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Image.Location = new System.Drawing.Point(0, 25);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(272, 168);
            this.pictureBox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_Image.TabIndex = 1;
            this.pictureBox_Image.TabStop = false;
            // 
            // labelControl_HW
            // 
            this.labelControl_HW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl_HW.Appearance.Image = global::Utils.Properties.Resources.Size;
            this.labelControl_HW.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl_HW.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl_HW.Location = new System.Drawing.Point(12, 165);
            this.labelControl_HW.Name = "labelControl_HW";
            this.labelControl_HW.Size = new System.Drawing.Size(42, 19);
            this.labelControl_HW.TabIndex = 5;
            this.labelControl_HW.Text = "0, 0";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 193);
            this.Controls.Add(this.labelControl_HW);
            this.Controls.Add(this.pictureBox_Image);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(290, 240);
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Image";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.ToolStripButton tsButton_Import;
        private DevExpress.XtraEditors.LabelControl labelControl_HW;
    }
}