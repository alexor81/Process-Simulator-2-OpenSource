// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.NameValueList
{
    partial class NameValueForm
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
            this.dataGridView_RB = new System.Windows.Forms.DataGridView();
            this.RB_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RB_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Value = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.buttonEdit_Value = new DevExpress.XtraEditors.ButtonEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsButton_Add = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Modify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_CopyAll = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Up = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Down = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Value.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_RB
            // 
            this.dataGridView_RB.AllowUserToAddRows = false;
            this.dataGridView_RB.AllowUserToDeleteRows = false;
            this.dataGridView_RB.AllowUserToResizeColumns = false;
            this.dataGridView_RB.AllowUserToResizeRows = false;
            this.dataGridView_RB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_RB.CausesValidation = false;
            this.dataGridView_RB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_RB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RB_Name,
            this.RB_Value,
            this.Type});
            this.dataGridView_RB.Location = new System.Drawing.Point(4, 93);
            this.dataGridView_RB.MultiSelect = false;
            this.dataGridView_RB.Name = "dataGridView_RB";
            this.dataGridView_RB.ReadOnly = true;
            this.dataGridView_RB.RowHeadersVisible = false;
            this.dataGridView_RB.RowTemplate.Height = 24;
            this.dataGridView_RB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_RB.ShowCellErrors = false;
            this.dataGridView_RB.ShowCellToolTips = false;
            this.dataGridView_RB.ShowEditingIcon = false;
            this.dataGridView_RB.ShowRowErrors = false;
            this.dataGridView_RB.Size = new System.Drawing.Size(393, 178);
            this.dataGridView_RB.TabIndex = 0;
            this.dataGridView_RB.TabStop = false;
            this.dataGridView_RB.SelectionChanged += new System.EventHandler(this.dataGridView_RB_SelectionChanged);
            // 
            // RB_Name
            // 
            this.RB_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RB_Name.HeaderText = "Name";
            this.RB_Name.Name = "RB_Name";
            this.RB_Name.ReadOnly = true;
            this.RB_Name.Width = 74;
            // 
            // RB_Value
            // 
            this.RB_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RB_Value.HeaderText = "Value";
            this.RB_Value.Name = "RB_Value";
            this.RB_Value.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(13, 31);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(49, 17);
            this.label_Name.TabIndex = 9;
            this.label_Name.Text = "Name:";
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(14, 63);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 10;
            this.label_Value.Text = "Value:";
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(68, 28);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(321, 22);
            this.textBox_Name.TabIndex = 0;
            // 
            // buttonEdit_Value
            // 
            this.buttonEdit_Value.Location = new System.Drawing.Point(68, 59);
            this.buttonEdit_Value.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_Value.Name = "buttonEdit_Value";
            this.buttonEdit_Value.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_Value.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_Value.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_Value.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Value.Properties.ReadOnly = true;
            this.buttonEdit_Value.Size = new System.Drawing.Size(320, 24);
            this.buttonEdit_Value.TabIndex = 1;
            this.buttonEdit_Value.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Value_ButtonClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Add,
            this.tsButton_Delete,
            this.tsButton_Modify,
            this.toolStripSeparator1,
            this.tsButton_CopyAll,
            this.tsButton_Paste,
            this.toolStripSeparator2,
            this.tsButton_Up,
            this.tsButton_Down});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(402, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsButton_Add
            // 
            this.tsButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Add.Image = global::Utils.Properties.Resources.Add;
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
            this.tsButton_Delete.Image = global::Utils.Properties.Resources.Delete;
            this.tsButton_Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Delete.Name = "tsButton_Delete";
            this.tsButton_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Delete.Text = "Delete";
            this.tsButton_Delete.Click += new System.EventHandler(this.tsButton_Delete_Click);
            // 
            // tsButton_Modify
            // 
            this.tsButton_Modify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Modify.Image = global::Utils.Properties.Resources.Setup;
            this.tsButton_Modify.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Modify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Modify.Name = "tsButton_Modify";
            this.tsButton_Modify.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Modify.Text = "Modify";
            this.tsButton_Modify.Click += new System.EventHandler(this.tsButton_Modify_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_CopyAll
            // 
            this.tsButton_CopyAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_CopyAll.Image = global::Utils.Properties.Resources.Copy;
            this.tsButton_CopyAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_CopyAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_CopyAll.Name = "tsButton_CopyAll";
            this.tsButton_CopyAll.Size = new System.Drawing.Size(23, 22);
            this.tsButton_CopyAll.Text = "Copy All";
            this.tsButton_CopyAll.Click += new System.EventHandler(this.tsButton_CopyAll_Click);
            // 
            // tsButton_Paste
            // 
            this.tsButton_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Paste.Image = global::Utils.Properties.Resources.Paste;
            this.tsButton_Paste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Paste.Name = "tsButton_Paste";
            this.tsButton_Paste.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Paste.Text = "Paste";
            this.tsButton_Paste.Click += new System.EventHandler(this.tsButton_Paste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Up
            // 
            this.tsButton_Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Up.Image = global::Utils.Properties.Resources.Up;
            this.tsButton_Up.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Up.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Up.Name = "tsButton_Up";
            this.tsButton_Up.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Up.Text = "Up";
            this.tsButton_Up.Click += new System.EventHandler(this.tsButton_Up_Click);
            // 
            // tsButton_Down
            // 
            this.tsButton_Down.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Down.Image = global::Utils.Properties.Resources.Down;
            this.tsButton_Down.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Down.Name = "tsButton_Down";
            this.tsButton_Down.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Down.Text = "Down";
            this.tsButton_Down.Click += new System.EventHandler(this.tsButton_Down_Click);
            // 
            // NameValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 275);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.buttonEdit_Value);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.dataGridView_RB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NameValueForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_RB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Value.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_RB;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.TextBox textBox_Name;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn RB_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn RB_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsButton_Add;
        private System.Windows.Forms.ToolStripButton tsButton_Delete;
        private System.Windows.Forms.ToolStripButton tsButton_Modify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButton_CopyAll;
        private System.Windows.Forms.ToolStripButton tsButton_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButton_Up;
        private System.Windows.Forms.ToolStripButton tsButton_Down;
    }
}