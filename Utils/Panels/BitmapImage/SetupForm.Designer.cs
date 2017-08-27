// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BitmapImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.panel_Image = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButton_Import = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Fit = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Options = new System.Windows.Forms.ToolStripButton();
            this.panel_OkCancel.SuspendLayout();
            this.panel_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 462);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(642, 40);
            this.panel_OkCancel.TabIndex = 0;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okCancelButton.Location = new System.Drawing.Point(227, 4);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 1;
            this.okCancelButton.TabStop = false;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // panel_Image
            // 
            this.panel_Image.Controls.Add(this.pictureBox);
            this.panel_Image.Controls.Add(this.toolStrip);
            this.panel_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Image.Location = new System.Drawing.Point(0, 0);
            this.panel_Image.Name = "panel_Image";
            this.panel_Image.Size = new System.Drawing.Size(642, 462);
            this.panel_Image.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(642, 437);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Import,
            this.tsButton_Fit,
            this.tsButton_Options});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(642, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "Image";
            // 
            // tsButton_Import
            // 
            this.tsButton_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Import.Image = ((System.Drawing.Image)(resources.GetObject("tsButton_Import.Image")));
            this.tsButton_Import.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Import.Name = "tsButton_Import";
            this.tsButton_Import.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Import.Text = "&Import";
            this.tsButton_Import.Click += new System.EventHandler(this.tsButton_Import_Click);
            // 
            // tsButton_Fit
            // 
            this.tsButton_Fit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Fit.Image = global::Utils.Properties.Resources.FitSize;
            this.tsButton_Fit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Fit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Fit.Name = "tsButton_Fit";
            this.tsButton_Fit.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Fit.Text = "Fit Panel Size";
            this.tsButton_Fit.Click += new System.EventHandler(this.tsButton_Fit_Click);
            // 
            // tsButton_Options
            // 
            this.tsButton_Options.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsButton_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Options.Image = global::Utils.Properties.Resources.Options;
            this.tsButton_Options.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Options.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Options.Name = "tsButton_Options";
            this.tsButton_Options.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Options.Text = "toolStripButton1";
            this.tsButton_Options.Click += new System.EventHandler(this.tsButton_Options_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 502);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Image);
            this.Controls.Add(this.panel_OkCancel);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bitmap Image";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.panel_OkCancel.ResumeLayout(false);
            this.panel_Image.ResumeLayout(false);
            this.panel_Image.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_OkCancel;
        private SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Panel panel_Image;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButton_Import;
        private System.Windows.Forms.ToolStripButton tsButton_Fit;
        private System.Windows.Forms.ToolStripButton tsButton_Options;
    }
}