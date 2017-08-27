// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Snapshot
{
    partial class SnapshotRecordsManagerForm
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
            this.ts_Records = new System.Windows.Forms.ToolStrip();
            this.tsLabel_Records = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Add = new System.Windows.Forms.ToolStripButton();
            this.tsButton_AddWizard = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Setup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLabel_Name = new System.Windows.Forms.ToolStripLabel();
            this.tsTextBox_Name = new System.Windows.Forms.ToolStripTextBox();
            this.tsButton_Filter = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.ssLabel_Records = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_Records = new System.Windows.Forms.DataGridView();
            this.ts_Records.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Records)).BeginInit();
            this.SuspendLayout();
            // 
            // ts_Records
            // 
            this.ts_Records.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ts_Records.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel_Records,
            this.toolStripSeparator1,
            this.tsButton_Add,
            this.tsButton_AddWizard,
            this.tsButton_Delete,
            this.tsButton_Setup,
            this.toolStripSeparator2,
            this.tsLabel_Name,
            this.tsTextBox_Name,
            this.tsButton_Filter});
            this.ts_Records.Location = new System.Drawing.Point(0, 0);
            this.ts_Records.Name = "ts_Records";
            this.ts_Records.Size = new System.Drawing.Size(684, 25);
            this.ts_Records.TabIndex = 0;
            // 
            // tsLabel_Records
            // 
            this.tsLabel_Records.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.tsLabel_Records.Name = "tsLabel_Records";
            this.tsLabel_Records.Size = new System.Drawing.Size(64, 22);
            this.tsLabel_Records.Text = "Records";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Add
            // 
            this.tsButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Add.Image = global::Utils.Properties.Resources.Add;
            this.tsButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Add.Name = "tsButton_Add";
            this.tsButton_Add.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Add.Text = "Add Record";
            this.tsButton_Add.Click += new System.EventHandler(this.tsButton_Add_Click);
            // 
            // tsButton_AddWizard
            // 
            this.tsButton_AddWizard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_AddWizard.Image = global::Utils.Properties.Resources.AddWizard;
            this.tsButton_AddWizard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_AddWizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_AddWizard.Name = "tsButton_AddWizard";
            this.tsButton_AddWizard.Size = new System.Drawing.Size(23, 22);
            this.tsButton_AddWizard.Text = "Add Records Wizard";
            this.tsButton_AddWizard.Click += new System.EventHandler(this.tsButton_AddWizard_Click);
            // 
            // tsButton_Delete
            // 
            this.tsButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Delete.Image = global::Utils.Properties.Resources.Delete;
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
            this.tsButton_Setup.Image = global::Utils.Properties.Resources.Setup;
            this.tsButton_Setup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Setup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Setup.Name = "tsButton_Setup";
            this.tsButton_Setup.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Setup.Text = "Setup";
            this.tsButton_Setup.Click += new System.EventHandler(this.tsButton_Setup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // tsButton_Filter
            // 
            this.tsButton_Filter.CheckOnClick = true;
            this.tsButton_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Filter.Image = global::Utils.Properties.Resources.Filter;
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
            this.ssLabel_Records});
            this.statusStrip.Location = new System.Drawing.Point(0, 505);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(684, 29);
            this.statusStrip.TabIndex = 1;
            // 
            // ssLabel_Records
            // 
            this.ssLabel_Records.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ssLabel_Records.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.ssLabel_Records.Name = "ssLabel_Records";
            this.ssLabel_Records.Size = new System.Drawing.Size(81, 24);
            this.ssLabel_Records.Text = "Records: 0";
            // 
            // dataGridView_Records
            // 
            this.dataGridView_Records.AllowUserToAddRows = false;
            this.dataGridView_Records.AllowUserToDeleteRows = false;
            this.dataGridView_Records.AllowUserToResizeRows = false;
            this.dataGridView_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Records.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Records.CausesValidation = false;
            this.dataGridView_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Records.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Records.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Records.Location = new System.Drawing.Point(0, 25);
            this.dataGridView_Records.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Records.Name = "dataGridView_Records";
            this.dataGridView_Records.ReadOnly = true;
            this.dataGridView_Records.RowHeadersVisible = false;
            this.dataGridView_Records.RowTemplate.Height = 24;
            this.dataGridView_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Records.ShowCellErrors = false;
            this.dataGridView_Records.ShowEditingIcon = false;
            this.dataGridView_Records.ShowRowErrors = false;
            this.dataGridView_Records.Size = new System.Drawing.Size(684, 480);
            this.dataGridView_Records.StandardTab = true;
            this.dataGridView_Records.TabIndex = 2;
            this.dataGridView_Records.TabStop = false;
            this.dataGridView_Records.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Records_CellDoubleClick);
            this.dataGridView_Records.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Records_CellMouseDown);
            this.dataGridView_Records.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_Records_DataBindingComplete);
            this.dataGridView_Records.SelectionChanged += new System.EventHandler(this.dataGridView_Records_SelectionChanged);
            // 
            // SnapshotRecordsManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 534);
            this.Controls.Add(this.dataGridView_Records);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.ts_Records);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SnapshotRecordsManagerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnapshotRecordsManagerForm_KeyDown);
            this.ts_Records.ResumeLayout(false);
            this.ts_Records.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Records)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ts_Records;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripLabel tsLabel_Records;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButton_Add;
        private System.Windows.Forms.DataGridView dataGridView_Records;
        private System.Windows.Forms.ToolStripStatusLabel ssLabel_Records;
        private System.Windows.Forms.ToolStripButton tsButton_Delete;
        private System.Windows.Forms.ToolStripButton tsButton_Setup;
        private System.Windows.Forms.ToolStripButton tsButton_AddWizard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tsLabel_Name;
        private System.Windows.Forms.ToolStripTextBox tsTextBox_Name;
        private System.Windows.Forms.ToolStripButton tsButton_Filter;
    }
}