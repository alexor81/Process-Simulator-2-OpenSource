namespace SimulationObject.Item.WriteToFile
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.label_On = new System.Windows.Forms.Label();
            this.buttonEdit_Path = new DevExpress.XtraEditors.ButtonEdit();
            this.label_Path = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox_Delimiter = new System.Windows.Forms.TextBox();
            this.label_Delimiter = new System.Windows.Forms.Label();
            this.spinEdit_Timeout = new DevExpress.XtraEditors.SpinEdit();
            this.label_Rate = new System.Windows.Forms.Label();
            this.checkBox_WriteChanges = new System.Windows.Forms.CheckBox();
            this.textBox_FileName = new System.Windows.Forms.TextBox();
            this.label_FileName = new System.Windows.Forms.Label();
            this.itemEditBox_On = new Utils.SpecialControls.ItemEditBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_Items = new System.Windows.Forms.DataGridView();
            this.toolStrip_Items = new System.Windows.Forms.ToolStrip();
            this.tsButton_Add = new System.Windows.Forms.ToolStripButton();
            this.tsButton_AddWizard = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Path.Properties)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Timeout.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).BeginInit();
            this.toolStrip_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_On
            // 
            this.label_On.AutoSize = true;
            this.label_On.Location = new System.Drawing.Point(83, 24);
            this.label_On.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_On.Name = "label_On";
            this.label_On.Size = new System.Drawing.Size(31, 17);
            this.label_On.TabIndex = 53;
            this.label_On.Text = "On:";
            // 
            // buttonEdit_Path
            // 
            this.buttonEdit_Path.Location = new System.Drawing.Point(120, 56);
            this.buttonEdit_Path.Name = "buttonEdit_Path";
            this.buttonEdit_Path.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", 17, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.buttonEdit_Path.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.buttonEdit_Path.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.buttonEdit_Path.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Path.Size = new System.Drawing.Size(283, 24);
            this.buttonEdit_Path.TabIndex = 1;
            this.buttonEdit_Path.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Path_ButtonClick);
            // 
            // label_Path
            // 
            this.label_Path.AutoSize = true;
            this.label_Path.Location = new System.Drawing.Point(73, 60);
            this.label_Path.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Path.Name = "label_Path";
            this.label_Path.Size = new System.Drawing.Size(41, 17);
            this.label_Path.TabIndex = 56;
            this.label_Path.Text = "Path:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(13, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(453, 297);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox_Delimiter);
            this.tabPage1.Controls.Add(this.label_Delimiter);
            this.tabPage1.Controls.Add(this.spinEdit_Timeout);
            this.tabPage1.Controls.Add(this.label_Rate);
            this.tabPage1.Controls.Add(this.checkBox_WriteChanges);
            this.tabPage1.Controls.Add(this.textBox_FileName);
            this.tabPage1.Controls.Add(this.label_FileName);
            this.tabPage1.Controls.Add(this.itemEditBox_On);
            this.tabPage1.Controls.Add(this.label_Path);
            this.tabPage1.Controls.Add(this.label_On);
            this.tabPage1.Controls.Add(this.buttonEdit_Path);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(445, 268);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox_Delimiter
            // 
            this.textBox_Delimiter.Location = new System.Drawing.Point(120, 153);
            this.textBox_Delimiter.Name = "textBox_Delimiter";
            this.textBox_Delimiter.Size = new System.Drawing.Size(51, 22);
            this.textBox_Delimiter.TabIndex = 5;
            // 
            // label_Delimiter
            // 
            this.label_Delimiter.AutoSize = true;
            this.label_Delimiter.Location = new System.Drawing.Point(47, 156);
            this.label_Delimiter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Delimiter.Name = "label_Delimiter";
            this.label_Delimiter.Size = new System.Drawing.Size(67, 17);
            this.label_Delimiter.TabIndex = 62;
            this.label_Delimiter.Text = "Delimiter:";
            // 
            // spinEdit_Timeout
            // 
            this.spinEdit_Timeout.EditValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.spinEdit_Timeout.Location = new System.Drawing.Point(120, 120);
            this.spinEdit_Timeout.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Timeout.Name = "spinEdit_Timeout";
            this.spinEdit_Timeout.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Timeout.Properties.IsFloatValue = false;
            this.spinEdit_Timeout.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Timeout.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Timeout.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Timeout.Properties.Mask.EditMask = "N00";
            this.spinEdit_Timeout.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spinEdit_Timeout.Size = new System.Drawing.Size(111, 24);
            this.spinEdit_Timeout.TabIndex = 3;
            // 
            // label_Rate
            // 
            this.label_Rate.AutoSize = true;
            this.label_Rate.Location = new System.Drawing.Point(42, 124);
            this.label_Rate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Rate.Name = "label_Rate";
            this.label_Rate.Size = new System.Drawing.Size(72, 17);
            this.label_Rate.TabIndex = 60;
            this.label_Rate.Text = "Rate [ms]:";
            // 
            // checkBox_WriteChanges
            // 
            this.checkBox_WriteChanges.AutoSize = true;
            this.checkBox_WriteChanges.Location = new System.Drawing.Point(252, 122);
            this.checkBox_WriteChanges.Name = "checkBox_WriteChanges";
            this.checkBox_WriteChanges.Size = new System.Drawing.Size(151, 21);
            this.checkBox_WriteChanges.TabIndex = 4;
            this.checkBox_WriteChanges.Text = "Write changes only";
            this.checkBox_WriteChanges.UseVisualStyleBackColor = true;
            // 
            // textBox_FileName
            // 
            this.textBox_FileName.Location = new System.Drawing.Point(120, 89);
            this.textBox_FileName.Name = "textBox_FileName";
            this.textBox_FileName.Size = new System.Drawing.Size(283, 22);
            this.textBox_FileName.TabIndex = 2;
            // 
            // label_FileName
            // 
            this.label_FileName.AutoSize = true;
            this.label_FileName.Location = new System.Drawing.Point(41, 92);
            this.label_FileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_FileName.Name = "label_FileName";
            this.label_FileName.Size = new System.Drawing.Size(73, 17);
            this.label_FileName.TabIndex = 57;
            this.label_FileName.Text = "File name:";
            // 
            // itemEditBox_On
            // 
            this.itemEditBox_On.ItemName = "";
            this.itemEditBox_On.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_On.ItemToolTip = "";
            this.itemEditBox_On.Location = new System.Drawing.Point(120, 17);
            this.itemEditBox_On.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_On.Name = "itemEditBox_On";
            this.itemEditBox_On.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_On.TabIndex = 0;
            this.itemEditBox_On.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_Items);
            this.tabPage2.Controls.Add(this.toolStrip_Items);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(445, 268);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_Items
            // 
            this.dataGridView_Items.AllowUserToAddRows = false;
            this.dataGridView_Items.AllowUserToDeleteRows = false;
            this.dataGridView_Items.AllowUserToResizeColumns = false;
            this.dataGridView_Items.AllowUserToResizeRows = false;
            this.dataGridView_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Items.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Items.CausesValidation = false;
            this.dataGridView_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Items.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Items.Location = new System.Drawing.Point(3, 28);
            this.dataGridView_Items.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Items.Name = "dataGridView_Items";
            this.dataGridView_Items.ReadOnly = true;
            this.dataGridView_Items.RowHeadersVisible = false;
            this.dataGridView_Items.RowTemplate.Height = 24;
            this.dataGridView_Items.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Items.ShowCellErrors = false;
            this.dataGridView_Items.ShowEditingIcon = false;
            this.dataGridView_Items.ShowRowErrors = false;
            this.dataGridView_Items.Size = new System.Drawing.Size(439, 237);
            this.dataGridView_Items.TabIndex = 0;
            this.dataGridView_Items.TabStop = false;
            this.dataGridView_Items.CellErrorTextNeeded += new System.Windows.Forms.DataGridViewCellErrorTextNeededEventHandler(this.dataGridView_Items_CellErrorTextNeeded);
            this.dataGridView_Items.SelectionChanged += new System.EventHandler(this.dataGridView_Items_SelectionChanged);
            // 
            // toolStrip_Items
            // 
            this.toolStrip_Items.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Items.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Add,
            this.tsButton_AddWizard,
            this.tsButton_Delete});
            this.toolStrip_Items.Location = new System.Drawing.Point(3, 3);
            this.toolStrip_Items.Name = "toolStrip_Items";
            this.toolStrip_Items.Size = new System.Drawing.Size(439, 25);
            this.toolStrip_Items.TabIndex = 0;
            this.toolStrip_Items.Text = "toolStrip1";
            // 
            // tsButton_Add
            // 
            this.tsButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Add.Image = global::SimulationObject.Item.WriteToFile.Properties.Resources.Add;
            this.tsButton_Add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Add.Name = "tsButton_Add";
            this.tsButton_Add.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Add.Text = "Add";
            this.tsButton_Add.Click += new System.EventHandler(this.tsButton_Add_Click);
            // 
            // tsButton_AddWizard
            // 
            this.tsButton_AddWizard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_AddWizard.Image = global::SimulationObject.Item.WriteToFile.Properties.Resources.AddWizard;
            this.tsButton_AddWizard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_AddWizard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_AddWizard.Name = "tsButton_AddWizard";
            this.tsButton_AddWizard.Size = new System.Drawing.Size(23, 22);
            this.tsButton_AddWizard.Text = "Add Items Wizard";
            this.tsButton_AddWizard.Click += new System.EventHandler(this.tsButton_AddWizard_Click);
            // 
            // tsButton_Delete
            // 
            this.tsButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Delete.Image = global::SimulationObject.Item.WriteToFile.Properties.Resources.Delete;
            this.tsButton_Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Delete.Name = "tsButton_Delete";
            this.tsButton_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Delete.Text = "Delete";
            this.tsButton_Delete.Click += new System.EventHandler(this.tsButton_Delete_Click);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(145, 310);
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
            this.ClientSize = new System.Drawing.Size(479, 350);
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
            this.Text = "Item.WriteToFile";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Path.Properties)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Timeout.Properties)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Items)).EndInit();
            this.toolStrip_Items.ResumeLayout(false);
            this.toolStrip_Items.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Utils.SpecialControls.ItemEditBox itemEditBox_On;
        private System.Windows.Forms.Label label_On;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Path;
        private System.Windows.Forms.Label label_Path;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip_Items;
        private System.Windows.Forms.DataGridView dataGridView_Items;
        private System.Windows.Forms.ToolStripButton tsButton_Add;
        private System.Windows.Forms.ToolStripButton tsButton_Delete;
        private System.Windows.Forms.TextBox textBox_FileName;
        private System.Windows.Forms.Label label_FileName;
        private System.Windows.Forms.CheckBox checkBox_WriteChanges;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Timeout;
        private System.Windows.Forms.Label label_Rate;
        private System.Windows.Forms.TextBox textBox_Delimiter;
        private System.Windows.Forms.Label label_Delimiter;
        private System.Windows.Forms.ToolStripButton tsButton_AddWizard;
    }
}