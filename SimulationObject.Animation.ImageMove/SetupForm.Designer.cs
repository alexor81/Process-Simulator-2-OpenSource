namespace SimulationObject.Animation.ImageMove
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
            this.label_XItem = new System.Windows.Forms.Label();
            this.label_YItem = new System.Windows.Forms.Label();
            this.itemEditBox_Y = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_X = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.open_file = new System.Windows.Forms.OpenFileDialog();
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.panel_Items = new System.Windows.Forms.Panel();
            this.panel_Image = new System.Windows.Forms.Panel();
            this.toolStrip_Image = new System.Windows.Forms.ToolStrip();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tsLabel_Image = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Import = new System.Windows.Forms.ToolStripButton();
            this.panel_OkCancel.SuspendLayout();
            this.panel_Items.SuspendLayout();
            this.panel_Image.SuspendLayout();
            this.toolStrip_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label_XItem
            // 
            this.label_XItem.AutoSize = true;
            this.label_XItem.Location = new System.Drawing.Point(11, 20);
            this.label_XItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_XItem.Name = "label_XItem";
            this.label_XItem.Size = new System.Drawing.Size(75, 17);
            this.label_XItem.TabIndex = 19;
            this.label_XItem.Text = "Position X:";
            // 
            // label_YItem
            // 
            this.label_YItem.AutoSize = true;
            this.label_YItem.Location = new System.Drawing.Point(307, 20);
            this.label_YItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_YItem.Name = "label_YItem";
            this.label_YItem.Size = new System.Drawing.Size(75, 17);
            this.label_YItem.TabIndex = 21;
            this.label_YItem.Text = "Position Y:";
            // 
            // itemEditBox_Y
            // 
            this.itemEditBox_Y.ItemName = "";
            this.itemEditBox_Y.ItemRequirements = "Real, Read, Obligatory";
            this.itemEditBox_Y.ItemToolTip = "";
            this.itemEditBox_Y.Location = new System.Drawing.Point(384, 13);
            this.itemEditBox_Y.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Y.Name = "itemEditBox_Y";
            this.itemEditBox_Y.Size = new System.Drawing.Size(209, 30);
            this.itemEditBox_Y.TabIndex = 1;
            this.itemEditBox_Y.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_X
            // 
            this.itemEditBox_X.ItemName = "";
            this.itemEditBox_X.ItemRequirements = "Real, Read, Obligatory";
            this.itemEditBox_X.ItemToolTip = "";
            this.itemEditBox_X.Location = new System.Drawing.Point(88, 13);
            this.itemEditBox_X.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_X.Name = "itemEditBox_X";
            this.itemEditBox_X.Size = new System.Drawing.Size(209, 30);
            this.itemEditBox_X.TabIndex = 0;
            this.itemEditBox_X.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okCancelButton.Location = new System.Drawing.Point(207, 7);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 0;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // open_file
            // 
            this.open_file.Filter = "Images|*.bmp;*.png;*.gif;*.exif;*.jpg;*.tif";
            this.open_file.InitialDirectory = "C:\\";
            this.open_file.RestoreDirectory = true;
            // 
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 418);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(603, 46);
            this.panel_OkCancel.TabIndex = 23;
            // 
            // panel_Items
            // 
            this.panel_Items.Controls.Add(this.itemEditBox_X);
            this.panel_Items.Controls.Add(this.label_XItem);
            this.panel_Items.Controls.Add(this.itemEditBox_Y);
            this.panel_Items.Controls.Add(this.label_YItem);
            this.panel_Items.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Items.Location = new System.Drawing.Point(0, 0);
            this.panel_Items.Name = "panel_Items";
            this.panel_Items.Size = new System.Drawing.Size(603, 54);
            this.panel_Items.TabIndex = 25;
            // 
            // panel_Image
            // 
            this.panel_Image.Controls.Add(this.pictureBox);
            this.panel_Image.Controls.Add(this.toolStrip_Image);
            this.panel_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Image.Location = new System.Drawing.Point(0, 54);
            this.panel_Image.Name = "panel_Image";
            this.panel_Image.Size = new System.Drawing.Size(603, 364);
            this.panel_Image.TabIndex = 26;
            // 
            // toolStrip_Image
            // 
            this.toolStrip_Image.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Image.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel_Image,
            this.toolStripSeparator1,
            this.tsButton_Import});
            this.toolStrip_Image.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Image.Name = "toolStrip_Image";
            this.toolStrip_Image.Size = new System.Drawing.Size(603, 25);
            this.toolStrip_Image.TabIndex = 0;
            this.toolStrip_Image.Text = "Image";
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(603, 339);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // tsLabel_Image
            // 
            this.tsLabel_Image.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsLabel_Image.Name = "tsLabel_Image";
            this.tsLabel_Image.Size = new System.Drawing.Size(51, 22);
            this.tsLabel_Image.Text = "Image";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 464);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Image);
            this.Controls.Add(this.panel_Items);
            this.Controls.Add(this.panel_OkCancel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Animation.ImgMove";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.panel_OkCancel.ResumeLayout(false);
            this.panel_Items.ResumeLayout(false);
            this.panel_Items.PerformLayout();
            this.panel_Image.ResumeLayout(false);
            this.panel_Image.PerformLayout();
            this.toolStrip_Image.ResumeLayout(false);
            this.toolStrip_Image.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_XItem;
        private System.Windows.Forms.Label label_YItem;
        private System.Windows.Forms.OpenFileDialog open_file;
        private Utils.SpecialControls.ItemEditBox itemEditBox_X;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Y;
        private System.Windows.Forms.Panel panel_OkCancel;
        private System.Windows.Forms.Panel panel_Items;
        private System.Windows.Forms.Panel panel_Image;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip_Image;
        private System.Windows.Forms.ToolStripLabel tsLabel_Image;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButton_Import;
    }
}
