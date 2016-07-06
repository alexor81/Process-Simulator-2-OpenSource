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
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.panel_Items = new System.Windows.Forms.Panel();
            this.itemEditBox_Visible = new Utils.SpecialControls.ItemEditBox();
            this.label_Visible = new System.Windows.Forms.Label();
            this.panel_Image = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButton_Import = new System.Windows.Forms.ToolStripButton();
            this.panel_OkCancel.SuspendLayout();
            this.panel_Items.SuspendLayout();
            this.panel_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_XItem
            // 
            this.label_XItem.AutoSize = true;
            this.label_XItem.Location = new System.Drawing.Point(18, 13);
            this.label_XItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_XItem.Name = "label_XItem";
            this.label_XItem.Size = new System.Drawing.Size(75, 17);
            this.label_XItem.TabIndex = 19;
            this.label_XItem.Text = "Position X:";
            // 
            // label_YItem
            // 
            this.label_YItem.AutoSize = true;
            this.label_YItem.Location = new System.Drawing.Point(18, 48);
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
            this.itemEditBox_Y.Location = new System.Drawing.Point(95, 41);
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
            this.itemEditBox_X.Location = new System.Drawing.Point(95, 6);
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
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 418);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(603, 46);
            this.panel_OkCancel.TabIndex = 2;
            // 
            // panel_Items
            // 
            this.panel_Items.Controls.Add(this.itemEditBox_Visible);
            this.panel_Items.Controls.Add(this.label_Visible);
            this.panel_Items.Controls.Add(this.itemEditBox_X);
            this.panel_Items.Controls.Add(this.label_XItem);
            this.panel_Items.Controls.Add(this.itemEditBox_Y);
            this.panel_Items.Controls.Add(this.label_YItem);
            this.panel_Items.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Items.Location = new System.Drawing.Point(0, 0);
            this.panel_Items.Name = "panel_Items";
            this.panel_Items.Size = new System.Drawing.Size(603, 76);
            this.panel_Items.TabIndex = 0;
            // 
            // itemEditBox_Visible
            // 
            this.itemEditBox_Visible.ItemName = "";
            this.itemEditBox_Visible.ItemRequirements = "Binary, Read";
            this.itemEditBox_Visible.ItemToolTip = "";
            this.itemEditBox_Visible.Location = new System.Drawing.Point(376, 6);
            this.itemEditBox_Visible.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Visible.Name = "itemEditBox_Visible";
            this.itemEditBox_Visible.Size = new System.Drawing.Size(209, 30);
            this.itemEditBox_Visible.TabIndex = 22;
            this.itemEditBox_Visible.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Visible
            // 
            this.label_Visible.AutoSize = true;
            this.label_Visible.Location = new System.Drawing.Point(316, 13);
            this.label_Visible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Visible.Name = "label_Visible";
            this.label_Visible.Size = new System.Drawing.Size(53, 17);
            this.label_Visible.TabIndex = 23;
            this.label_Visible.Text = "Visible:";
            // 
            // panel_Image
            // 
            this.panel_Image.Controls.Add(this.pictureBox);
            this.panel_Image.Controls.Add(this.toolStrip);
            this.panel_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Image.Location = new System.Drawing.Point(0, 76);
            this.panel_Image.Name = "panel_Image";
            this.panel_Image.Size = new System.Drawing.Size(603, 342);
            this.panel_Image.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 25);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(603, 317);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Import});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(603, 25);
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
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 464);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Image);
            this.Controls.Add(this.panel_Items);
            this.Controls.Add(this.panel_OkCancel);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Animation.ImageMove";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.panel_OkCancel.ResumeLayout(false);
            this.panel_Items.ResumeLayout(false);
            this.panel_Items.PerformLayout();
            this.panel_Image.ResumeLayout(false);
            this.panel_Image.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_XItem;
        private System.Windows.Forms.Label label_YItem;
        private Utils.SpecialControls.ItemEditBox itemEditBox_X;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Y;
        private System.Windows.Forms.Panel panel_OkCancel;
        private System.Windows.Forms.Panel panel_Items;
        private System.Windows.Forms.Panel panel_Image;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButton_Import;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Visible;
        private System.Windows.Forms.Label label_Visible;
    }
}
