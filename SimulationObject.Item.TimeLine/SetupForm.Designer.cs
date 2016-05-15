namespace SimulationObject.Item.TimeLine
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
            this.label_On = new System.Windows.Forms.Label();
            this.checkBox_Loop = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Options = new System.Windows.Forms.TabPage();
            this.itemEditBox_On = new Utils.SpecialControls.ItemEditBox();
            this.tabPage_Sections = new System.Windows.Forms.TabPage();
            this.dataGridView_Sections = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButton_Up = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Down = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Add = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Clone = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Setup = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delay = new System.Windows.Forms.ToolStripButton();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.tabControl.SuspendLayout();
            this.tabPage_Options.SuspendLayout();
            this.tabPage_Sections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sections)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_On
            // 
            this.label_On.AutoSize = true;
            this.label_On.Location = new System.Drawing.Point(63, 30);
            this.label_On.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_On.Name = "label_On";
            this.label_On.Size = new System.Drawing.Size(31, 17);
            this.label_On.TabIndex = 51;
            this.label_On.Text = "On:";
            // 
            // checkBox_Loop
            // 
            this.checkBox_Loop.AutoSize = true;
            this.checkBox_Loop.Location = new System.Drawing.Point(100, 59);
            this.checkBox_Loop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Loop.Name = "checkBox_Loop";
            this.checkBox_Loop.Size = new System.Drawing.Size(62, 21);
            this.checkBox_Loop.TabIndex = 1;
            this.checkBox_Loop.Text = "Loop";
            this.checkBox_Loop.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage_Options);
            this.tabControl.Controls.Add(this.tabPage_Sections);
            this.tabControl.Location = new System.Drawing.Point(9, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(453, 297);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage_Options
            // 
            this.tabPage_Options.Controls.Add(this.itemEditBox_On);
            this.tabPage_Options.Controls.Add(this.checkBox_Loop);
            this.tabPage_Options.Controls.Add(this.label_On);
            this.tabPage_Options.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Options.Name = "tabPage_Options";
            this.tabPage_Options.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Options.Size = new System.Drawing.Size(445, 268);
            this.tabPage_Options.TabIndex = 0;
            this.tabPage_Options.Text = "Options";
            this.tabPage_Options.UseVisualStyleBackColor = true;
            // 
            // itemEditBox_On
            // 
            this.itemEditBox_On.ItemName = "";
            this.itemEditBox_On.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_On.ItemToolTip = "";
            this.itemEditBox_On.Location = new System.Drawing.Point(100, 23);
            this.itemEditBox_On.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_On.Name = "itemEditBox_On";
            this.itemEditBox_On.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_On.TabIndex = 0;
            this.itemEditBox_On.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // tabPage_Sections
            // 
            this.tabPage_Sections.Controls.Add(this.dataGridView_Sections);
            this.tabPage_Sections.Controls.Add(this.toolStrip);
            this.tabPage_Sections.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Sections.Name = "tabPage_Sections";
            this.tabPage_Sections.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Sections.Size = new System.Drawing.Size(446, 263);
            this.tabPage_Sections.TabIndex = 1;
            this.tabPage_Sections.Text = "Sections";
            this.tabPage_Sections.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Sections
            // 
            this.dataGridView_Sections.AllowUserToAddRows = false;
            this.dataGridView_Sections.AllowUserToDeleteRows = false;
            this.dataGridView_Sections.AllowUserToResizeColumns = false;
            this.dataGridView_Sections.AllowUserToResizeRows = false;
            this.dataGridView_Sections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Sections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Sections.CausesValidation = false;
            this.dataGridView_Sections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Sections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Sections.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Sections.Location = new System.Drawing.Point(3, 28);
            this.dataGridView_Sections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Sections.Name = "dataGridView_Sections";
            this.dataGridView_Sections.ReadOnly = true;
            this.dataGridView_Sections.RowHeadersVisible = false;
            this.dataGridView_Sections.RowTemplate.Height = 24;
            this.dataGridView_Sections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Sections.ShowCellErrors = false;
            this.dataGridView_Sections.ShowCellToolTips = false;
            this.dataGridView_Sections.ShowEditingIcon = false;
            this.dataGridView_Sections.ShowRowErrors = false;
            this.dataGridView_Sections.Size = new System.Drawing.Size(440, 232);
            this.dataGridView_Sections.TabIndex = 1;
            this.dataGridView_Sections.TabStop = false;
            this.dataGridView_Sections.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Sections_CellDoubleClick);
            this.dataGridView_Sections.SelectionChanged += new System.EventHandler(this.dataGridView_Sections_SelectionChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Up,
            this.tsButton_Down,
            this.toolStripSeparator1,
            this.tsButton_Add,
            this.tsButton_Clone,
            this.tsButton_Delete,
            this.toolStripSeparator2,
            this.tsButton_Setup,
            this.tsButton_Delay});
            this.toolStrip.Location = new System.Drawing.Point(3, 3);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(440, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // tsButton_Up
            // 
            this.tsButton_Up.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Up.Image = global::SimulationObject.Item.TimeLine.Properties.Resources.Up;
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
            this.tsButton_Down.Image = global::SimulationObject.Item.TimeLine.Properties.Resources.Down;
            this.tsButton_Down.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Down.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Down.Name = "tsButton_Down";
            this.tsButton_Down.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Down.Text = "Down";
            this.tsButton_Down.Click += new System.EventHandler(this.tsButton_Down_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Add
            // 
            this.tsButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Add.Image = global::SimulationObject.Item.TimeLine.Properties.Resources.Add;
            this.tsButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Add.Name = "tsButton_Add";
            this.tsButton_Add.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Add.Text = "Add";
            this.tsButton_Add.Click += new System.EventHandler(this.tsButton_Add_Click);
            // 
            // tsButton_Clone
            // 
            this.tsButton_Clone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Clone.Image = global::SimulationObject.Item.TimeLine.Properties.Resources.Clone;
            this.tsButton_Clone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Clone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Clone.Name = "tsButton_Clone";
            this.tsButton_Clone.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Clone.Text = "Clone";
            this.tsButton_Clone.Click += new System.EventHandler(this.tsButton_Clone_Click);
            // 
            // tsButton_Delete
            // 
            this.tsButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Delete.Image = global::SimulationObject.Item.TimeLine.Properties.Resources.Delete;
            this.tsButton_Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Delete.Name = "tsButton_Delete";
            this.tsButton_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Delete.Text = "Delete";
            this.tsButton_Delete.Click += new System.EventHandler(this.tsButton_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Setup
            // 
            this.tsButton_Setup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Setup.Image = global::SimulationObject.Item.TimeLine.Properties.Resources.Setup;
            this.tsButton_Setup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Setup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Setup.Name = "tsButton_Setup";
            this.tsButton_Setup.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Setup.Text = "Setup";
            this.tsButton_Setup.Click += new System.EventHandler(this.tsButton_Setup_Click);
            // 
            // tsButton_Delay
            // 
            this.tsButton_Delay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Delay.Image = global::SimulationObject.Item.TimeLine.Properties.Resources.Clock;
            this.tsButton_Delay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Delay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Delay.Name = "tsButton_Delay";
            this.tsButton_Delay.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Delay.Text = "Delay";
            this.tsButton_Delay.Click += new System.EventHandler(this.tsButton_Delay_Click);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(141, 312);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 1;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 349);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item.TimeLine";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabPage_Options.ResumeLayout(false);
            this.tabPage_Options.PerformLayout();
            this.tabPage_Sections.ResumeLayout(false);
            this.tabPage_Sections.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Sections)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_On;
        private System.Windows.Forms.Label label_On;
        private System.Windows.Forms.CheckBox checkBox_Loop;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_Options;
        private System.Windows.Forms.TabPage tabPage_Sections;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButton_Up;
        private System.Windows.Forms.ToolStripButton tsButton_Down;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dataGridView_Sections;
        private System.Windows.Forms.ToolStripButton tsButton_Add;
        private System.Windows.Forms.ToolStripButton tsButton_Delete;
        private System.Windows.Forms.ToolStripButton tsButton_Clone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButton_Delay;
        private System.Windows.Forms.ToolStripButton tsButton_Setup;
    }
}