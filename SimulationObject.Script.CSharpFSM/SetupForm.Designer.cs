// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Script.CSharpFSM
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButton_Add = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Setup = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Rename = new System.Windows.Forms.ToolStripButton();
            this.tsButton_First = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.panel_Graph = new System.Windows.Forms.Panel();
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.toolStrip.SuspendLayout();
            this.panel_OkCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Add,
            this.tsButton_Delete,
            this.tsButton_Setup,
            this.tsButton_Rename,
            this.tsButton_First,
            this.toolStripSeparator1,
            this.tsButton_Refresh});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(576, 25);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsButton_Add
            // 
            this.tsButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Add.Image = global::SimulationObject.Script.CSharpFSM.Properties.Resources.Add;
            this.tsButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Add.Name = "tsButton_Add";
            this.tsButton_Add.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Add.Text = "Add";
            this.tsButton_Add.Click += new System.EventHandler(this.tsButton_Add_Click);
            // 
            // tsButton_Delete
            // 
            this.tsButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Delete.Image = global::SimulationObject.Script.CSharpFSM.Properties.Resources.Delete;
            this.tsButton_Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Delete.Name = "tsButton_Delete";
            this.tsButton_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Delete.Text = "Delete";
            this.tsButton_Delete.Click += new System.EventHandler(this.tsButton_Delete_Click);
            // 
            // tsButton_Setup
            // 
            this.tsButton_Setup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Setup.Image = global::SimulationObject.Script.CSharpFSM.Properties.Resources.Setup;
            this.tsButton_Setup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Setup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Setup.Name = "tsButton_Setup";
            this.tsButton_Setup.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Setup.Text = "Setup";
            this.tsButton_Setup.Click += new System.EventHandler(this.tsButton_Setup_Click);
            // 
            // tsButton_Rename
            // 
            this.tsButton_Rename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Rename.Image = global::SimulationObject.Script.CSharpFSM.Properties.Resources.Rename;
            this.tsButton_Rename.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Rename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Rename.Name = "tsButton_Rename";
            this.tsButton_Rename.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Rename.Text = "Rename";
            this.tsButton_Rename.Click += new System.EventHandler(this.tsButton_Rename_Click);
            // 
            // tsButton_First
            // 
            this.tsButton_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_First.Image = global::SimulationObject.Script.CSharpFSM.Properties.Resources.flag_checker;
            this.tsButton_First.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_First.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_First.Name = "tsButton_First";
            this.tsButton_First.Size = new System.Drawing.Size(23, 22);
            this.tsButton_First.Text = "First State";
            this.tsButton_First.Click += new System.EventHandler(this.tsButton_First_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Refresh
            // 
            this.tsButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Refresh.Image = global::SimulationObject.Script.CSharpFSM.Properties.Resources.Refresh;
            this.tsButton_Refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Refresh.Name = "tsButton_Refresh";
            this.tsButton_Refresh.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Refresh.Text = "Refresh";
            this.tsButton_Refresh.Click += new System.EventHandler(this.tsButton_Refresh_Click);
            // 
            // panel_Graph
            // 
            this.panel_Graph.BackColor = System.Drawing.Color.White;
            this.panel_Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Graph.Location = new System.Drawing.Point(0, 25);
            this.panel_Graph.Name = "panel_Graph";
            this.panel_Graph.Size = new System.Drawing.Size(576, 421);
            this.panel_Graph.TabIndex = 7;
            // 
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 446);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(576, 39);
            this.panel_OkCancel.TabIndex = 6;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okCancelButton.Location = new System.Drawing.Point(194, 3);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 485);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Graph);
            this.Controls.Add(this.panel_OkCancel);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script.CSharpFSM";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.SizeChanged += new System.EventHandler(this.SetupForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel_OkCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButton_Add;
        private System.Windows.Forms.ToolStripButton tsButton_Delete;
        private System.Windows.Forms.Panel panel_Graph;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Panel panel_OkCancel;
        private System.Windows.Forms.ToolStripButton tsButton_Setup;
        private System.Windows.Forms.ToolStripButton tsButton_Rename;
        private System.Windows.Forms.ToolStripButton tsButton_First;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButton_Refresh;
    }
}