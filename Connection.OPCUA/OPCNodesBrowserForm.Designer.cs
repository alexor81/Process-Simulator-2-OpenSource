namespace Connection.OPCUA
{
    partial class OPCNodesBrowserForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPCNodesBrowserForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel_Node = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel_NodeId = new System.Windows.Forms.ToolStripLabel();
            this.treeView_Browser = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Refresh,
            this.toolStripSeparator1,
            this.toolStripLabel_Node,
            this.toolStripLabel_NodeId});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(589, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsButton_Refresh
            // 
            this.tsButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Refresh.Image = global::Connection.OPCUA.Properties.Resources.Refresh;
            this.tsButton_Refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Refresh.Name = "tsButton_Refresh";
            this.tsButton_Refresh.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Refresh.Text = "Refresh";
            this.tsButton_Refresh.Click += new System.EventHandler(this.tsButton_Refresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel_Node
            // 
            this.toolStripLabel_Node.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel_Node.Name = "toolStripLabel_Node";
            this.toolStripLabel_Node.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel_Node.Text = "Node:";
            // 
            // toolStripLabel_NodeId
            // 
            this.toolStripLabel_NodeId.Name = "toolStripLabel_NodeId";
            this.toolStripLabel_NodeId.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel_NodeId.Text = "NodeId";
            // 
            // treeView_Browser
            // 
            this.treeView_Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Browser.ImageKey = "Treefolder.png";
            this.treeView_Browser.ImageList = this.imageList;
            this.treeView_Browser.Location = new System.Drawing.Point(0, 25);
            this.treeView_Browser.Margin = new System.Windows.Forms.Padding(4);
            this.treeView_Browser.Name = "treeView_Browser";
            this.treeView_Browser.SelectedImageIndex = 0;
            this.treeView_Browser.ShowNodeToolTips = true;
            this.treeView_Browser.Size = new System.Drawing.Size(589, 390);
            this.treeView_Browser.TabIndex = 6;
            this.treeView_Browser.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_Browser_BeforeExpand);
            this.treeView_Browser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Browser_AfterSelect);
            this.treeView_Browser.DoubleClick += new System.EventHandler(this.treeView_Browser_DoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Treefolder.png");
            this.imageList.Images.SetKeyName(1, "Variable.png");
            this.imageList.Images.SetKeyName(2, "Error.png");
            // 
            // OPCNodesBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 415);
            this.Controls.Add(this.treeView_Browser);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OPCNodesBrowserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OPC Node Browser";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OPCNodesBrowserForm_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButton_Refresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_Node;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_NodeId;
        private System.Windows.Forms.TreeView treeView_Browser;
        private System.Windows.Forms.ImageList imageList;
    }
}