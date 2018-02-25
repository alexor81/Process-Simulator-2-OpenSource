// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Connection.S7PLCSimAdv2
{
    partial class TagBrowserForm
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
            this.toolStripButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLabel_Name = new System.Windows.Forms.ToolStripLabel();
            this.tsTextBox_Name = new System.Windows.Forms.ToolStripTextBox();
            this.tsButton_I = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Q = new System.Windows.Forms.ToolStripButton();
            this.tsButton_M = new System.Windows.Forms.ToolStripButton();
            this.tsButton_DB = new System.Windows.Forms.ToolStripButton();
            this.tsButton_C = new System.Windows.Forms.ToolStripButton();
            this.tsButton_T = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Filter = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsStatusLabel_Total = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatusLabel_Filtered = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_Tags = new System.Windows.Forms.DataGridView();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Refresh,
            this.toolStripSeparator1,
            this.tsLabel_Name,
            this.tsTextBox_Name,
            this.tsButton_I,
            this.tsButton_Q,
            this.tsButton_M,
            this.tsButton_DB,
            this.tsButton_C,
            this.tsButton_T,
            this.tsButton_Filter});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(891, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButton_Refresh
            // 
            this.toolStripButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Refresh.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Refresh;
            this.toolStripButton_Refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Refresh.Name = "toolStripButton_Refresh";
            this.toolStripButton_Refresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Refresh.Text = "Refresh";
            this.toolStripButton_Refresh.Click += new System.EventHandler(this.toolStripButton_Refresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLabel_Name
            // 
            this.tsLabel_Name.Name = "tsLabel_Name";
            this.tsLabel_Name.Size = new System.Drawing.Size(52, 22);
            this.tsLabel_Name.Text = "Name:";
            // 
            // tsTextBox_Name
            // 
            this.tsTextBox_Name.AutoSize = false;
            this.tsTextBox_Name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tsTextBox_Name.Name = "tsTextBox_Name";
            this.tsTextBox_Name.Size = new System.Drawing.Size(200, 20);
            this.tsTextBox_Name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.tsTextBox_Name.TextChanged += new System.EventHandler(this.filterChanged);
            // 
            // tsButton_I
            // 
            this.tsButton_I.CheckOnClick = true;
            this.tsButton_I.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_I.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Memory_I;
            this.tsButton_I.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_I.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_I.Name = "tsButton_I";
            this.tsButton_I.Size = new System.Drawing.Size(23, 22);
            this.tsButton_I.Text = "Input";
            this.tsButton_I.Click += new System.EventHandler(this.filterChanged);
            // 
            // tsButton_Q
            // 
            this.tsButton_Q.CheckOnClick = true;
            this.tsButton_Q.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Q.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Memory_Q;
            this.tsButton_Q.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Q.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Q.Name = "tsButton_Q";
            this.tsButton_Q.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Q.Text = "Output";
            this.tsButton_Q.Click += new System.EventHandler(this.filterChanged);
            // 
            // tsButton_M
            // 
            this.tsButton_M.CheckOnClick = true;
            this.tsButton_M.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_M.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Memory_M;
            this.tsButton_M.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_M.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_M.Name = "tsButton_M";
            this.tsButton_M.Size = new System.Drawing.Size(23, 22);
            this.tsButton_M.Text = "Marker";
            this.tsButton_M.Click += new System.EventHandler(this.filterChanged);
            // 
            // tsButton_DB
            // 
            this.tsButton_DB.CheckOnClick = true;
            this.tsButton_DB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_DB.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Memory_DB;
            this.tsButton_DB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_DB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_DB.Name = "tsButton_DB";
            this.tsButton_DB.Size = new System.Drawing.Size(23, 22);
            this.tsButton_DB.Text = "DataBlock";
            this.tsButton_DB.Click += new System.EventHandler(this.filterChanged);
            // 
            // tsButton_C
            // 
            this.tsButton_C.CheckOnClick = true;
            this.tsButton_C.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_C.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Memory_C;
            this.tsButton_C.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_C.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_C.Name = "tsButton_C";
            this.tsButton_C.Size = new System.Drawing.Size(23, 22);
            this.tsButton_C.Text = "Counter";
            this.tsButton_C.Click += new System.EventHandler(this.filterChanged);
            // 
            // tsButton_T
            // 
            this.tsButton_T.CheckOnClick = true;
            this.tsButton_T.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_T.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Memory_T;
            this.tsButton_T.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_T.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_T.Name = "tsButton_T";
            this.tsButton_T.Size = new System.Drawing.Size(23, 22);
            this.tsButton_T.Text = "Timer";
            this.tsButton_T.Click += new System.EventHandler(this.filterChanged);
            // 
            // tsButton_Filter
            // 
            this.tsButton_Filter.CheckOnClick = true;
            this.tsButton_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Filter.Image = global::Connection.S7PLCSimAdv2.Properties.Resources.Filter;
            this.tsButton_Filter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Filter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Filter.Name = "tsButton_Filter";
            this.tsButton_Filter.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Filter.Text = "Filter";
            this.tsButton_Filter.CheckedChanged += new System.EventHandler(this.filterChanged);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatusLabel_Total,
            this.tsStatusLabel_Filtered});
            this.statusStrip.Location = new System.Drawing.Point(0, 556);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(891, 29);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tsStatusLabel_Total
            // 
            this.tsStatusLabel_Total.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsStatusLabel_Total.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsStatusLabel_Total.Name = "tsStatusLabel_Total";
            this.tsStatusLabel_Total.Size = new System.Drawing.Size(61, 24);
            this.tsStatusLabel_Total.Text = "Total: 0";
            // 
            // tsStatusLabel_Filtered
            // 
            this.tsStatusLabel_Filtered.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tsStatusLabel_Filtered.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tsStatusLabel_Filtered.Name = "tsStatusLabel_Filtered";
            this.tsStatusLabel_Filtered.Size = new System.Drawing.Size(78, 24);
            this.tsStatusLabel_Filtered.Text = "Filtered: 0";
            // 
            // dataGridView_Tags
            // 
            this.dataGridView_Tags.AllowUserToAddRows = false;
            this.dataGridView_Tags.AllowUserToDeleteRows = false;
            this.dataGridView_Tags.AllowUserToOrderColumns = true;
            this.dataGridView_Tags.AllowUserToResizeRows = false;
            this.dataGridView_Tags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Tags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Tags.CausesValidation = false;
            this.dataGridView_Tags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Tags.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Tags.Location = new System.Drawing.Point(0, 25);
            this.dataGridView_Tags.MultiSelect = false;
            this.dataGridView_Tags.Name = "dataGridView_Tags";
            this.dataGridView_Tags.ReadOnly = true;
            this.dataGridView_Tags.RowHeadersVisible = false;
            this.dataGridView_Tags.RowTemplate.Height = 24;
            this.dataGridView_Tags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Tags.ShowCellErrors = false;
            this.dataGridView_Tags.ShowEditingIcon = false;
            this.dataGridView_Tags.ShowRowErrors = false;
            this.dataGridView_Tags.Size = new System.Drawing.Size(891, 531);
            this.dataGridView_Tags.StandardTab = true;
            this.dataGridView_Tags.TabIndex = 3;
            this.dataGridView_Tags.TabStop = false;
            this.dataGridView_Tags.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Tags_CellMouseDoubleClick);
            this.dataGridView_Tags.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Tags_CellMouseDown);
            this.dataGridView_Tags.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_Tags_DataBindingComplete);
            this.dataGridView_Tags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_Tags_KeyDown);
            // 
            // TagBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 585);
            this.Controls.Add(this.dataGridView_Tags);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TagBrowserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tag Browser";
            this.Load += new System.EventHandler(this.TagBrowserForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TagBrowserForm_KeyDown);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Tags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton_Refresh;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.DataGridView dataGridView_Tags;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel_Total;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel tsStatusLabel_Filtered;
        private System.Windows.Forms.ToolStripLabel tsLabel_Name;
        private System.Windows.Forms.ToolStripTextBox tsTextBox_Name;
        private System.Windows.Forms.ToolStripButton tsButton_Filter;
        private System.Windows.Forms.ToolStripButton tsButton_I;
        private System.Windows.Forms.ToolStripButton tsButton_Q;
        private System.Windows.Forms.ToolStripButton tsButton_M;
        private System.Windows.Forms.ToolStripButton tsButton_DB;
        private System.Windows.Forms.ToolStripButton tsButton_C;
        private System.Windows.Forms.ToolStripButton tsButton_T;
    }
}