namespace SimulationObject.Item.BitSplitter
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
            this.label_ArrayItem = new System.Windows.Forms.Label();
            this.spinEdit_Index = new DevExpress.XtraEditors.SpinEdit();
            this.label_Item = new System.Windows.Forms.Label();
            this.label_Index = new System.Windows.Forms.Label();
            this.label_DataFlow = new System.Windows.Forms.Label();
            this.dataGridView_Bit = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_Elements = new System.Windows.Forms.GroupBox();
            this.itemEditBox_Item = new Utils.SpecialControls.ItemEditBox();
            this.button_Modify = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.comboBox_DataFlow = new System.Windows.Forms.ComboBox();
            this.itemEditBox_Value = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Index.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bit)).BeginInit();
            this.groupBox_Elements.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ArrayItem
            // 
            this.label_ArrayItem.AutoSize = true;
            this.label_ArrayItem.Location = new System.Drawing.Point(37, 16);
            this.label_ArrayItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ArrayItem.Name = "label_ArrayItem";
            this.label_ArrayItem.Size = new System.Drawing.Size(48, 17);
            this.label_ArrayItem.TabIndex = 58;
            this.label_ArrayItem.Text = "Value:";
            // 
            // spinEdit_Index
            // 
            this.spinEdit_Index.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Index.Location = new System.Drawing.Point(84, 19);
            this.spinEdit_Index.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Index.Name = "spinEdit_Index";
            this.spinEdit_Index.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Index.Properties.IsFloatValue = false;
            this.spinEdit_Index.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Index.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Index.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Index.Properties.Mask.EditMask = "N00";
            this.spinEdit_Index.Properties.MaxValue = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.spinEdit_Index.Size = new System.Drawing.Size(135, 24);
            this.spinEdit_Index.TabIndex = 0;
            // 
            // label_Item
            // 
            this.label_Item.AutoSize = true;
            this.label_Item.Location = new System.Drawing.Point(31, 59);
            this.label_Item.Name = "label_Item";
            this.label_Item.Size = new System.Drawing.Size(38, 17);
            this.label_Item.TabIndex = 62;
            this.label_Item.Text = "Item:";
            // 
            // label_Index
            // 
            this.label_Index.AutoSize = true;
            this.label_Index.Location = new System.Drawing.Point(24, 23);
            this.label_Index.Name = "label_Index";
            this.label_Index.Size = new System.Drawing.Size(45, 17);
            this.label_Index.TabIndex = 61;
            this.label_Index.Text = "Index:";
            // 
            // label_DataFlow
            // 
            this.label_DataFlow.AutoSize = true;
            this.label_DataFlow.Location = new System.Drawing.Point(15, 48);
            this.label_DataFlow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DataFlow.Name = "label_DataFlow";
            this.label_DataFlow.Size = new System.Drawing.Size(70, 17);
            this.label_DataFlow.TabIndex = 64;
            this.label_DataFlow.Text = "Data flow:";
            // 
            // dataGridView_Bit
            // 
            this.dataGridView_Bit.AllowUserToAddRows = false;
            this.dataGridView_Bit.AllowUserToDeleteRows = false;
            this.dataGridView_Bit.AllowUserToResizeColumns = false;
            this.dataGridView_Bit.AllowUserToResizeRows = false;
            this.dataGridView_Bit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Bit.CausesValidation = false;
            this.dataGridView_Bit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Bit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.ItemID});
            this.dataGridView_Bit.Location = new System.Drawing.Point(6, 116);
            this.dataGridView_Bit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Bit.MultiSelect = false;
            this.dataGridView_Bit.Name = "dataGridView_Bit";
            this.dataGridView_Bit.ReadOnly = true;
            this.dataGridView_Bit.RowHeadersVisible = false;
            this.dataGridView_Bit.RowTemplate.Height = 24;
            this.dataGridView_Bit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Bit.ShowCellErrors = false;
            this.dataGridView_Bit.ShowCellToolTips = false;
            this.dataGridView_Bit.ShowEditingIcon = false;
            this.dataGridView_Bit.ShowRowErrors = false;
            this.dataGridView_Bit.Size = new System.Drawing.Size(424, 121);
            this.dataGridView_Bit.TabIndex = 5;
            this.dataGridView_Bit.TabStop = false;
            this.dataGridView_Bit.SelectionChanged += new System.EventHandler(this.dataGridView_Bit_SelectionChanged);
            // 
            // Index
            // 
            this.Index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 66;
            // 
            // ItemID
            // 
            this.ItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemID.HeaderText = "Item";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // groupBox_Elements
            // 
            this.groupBox_Elements.Controls.Add(this.spinEdit_Index);
            this.groupBox_Elements.Controls.Add(this.itemEditBox_Item);
            this.groupBox_Elements.Controls.Add(this.label_Item);
            this.groupBox_Elements.Controls.Add(this.label_Index);
            this.groupBox_Elements.Controls.Add(this.dataGridView_Bit);
            this.groupBox_Elements.Controls.Add(this.button_Modify);
            this.groupBox_Elements.Controls.Add(this.button_Add);
            this.groupBox_Elements.Controls.Add(this.button_Delete);
            this.groupBox_Elements.Location = new System.Drawing.Point(5, 73);
            this.groupBox_Elements.Name = "groupBox_Elements";
            this.groupBox_Elements.Size = new System.Drawing.Size(436, 242);
            this.groupBox_Elements.TabIndex = 2;
            this.groupBox_Elements.TabStop = false;
            this.groupBox_Elements.Text = "Bits";
            // 
            // itemEditBox_Item
            // 
            this.itemEditBox_Item.ItemName = "";
            this.itemEditBox_Item.ItemRequirements = "Binary, Read, Write, Obligatory";
            this.itemEditBox_Item.ItemToolTip = "";
            this.itemEditBox_Item.Location = new System.Drawing.Point(84, 52);
            this.itemEditBox_Item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Item.Name = "itemEditBox_Item";
            this.itemEditBox_Item.Size = new System.Drawing.Size(321, 30);
            this.itemEditBox_Item.TabIndex = 1;
            this.itemEditBox_Item.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(262, 86);
            this.button_Modify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(75, 26);
            this.button_Modify.TabIndex = 4;
            this.button_Modify.Text = "Modify";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(99, 86);
            this.button_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 26);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(181, 86);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 26);
            this.button_Delete.TabIndex = 3;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // comboBox_DataFlow
            // 
            this.comboBox_DataFlow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataFlow.FormattingEnabled = true;
            this.comboBox_DataFlow.Items.AddRange(new object[] {
            "<- Value",
            "-> Value",
            "<-> Value"});
            this.comboBox_DataFlow.Location = new System.Drawing.Point(90, 45);
            this.comboBox_DataFlow.Name = "comboBox_DataFlow";
            this.comboBox_DataFlow.Size = new System.Drawing.Size(179, 24);
            this.comboBox_DataFlow.TabIndex = 1;
            // 
            // itemEditBox_Value
            // 
            this.itemEditBox_Value.ItemName = "";
            this.itemEditBox_Value.ItemRequirements = "Real (8 to 64bit), Read, Write, Obligatory";
            this.itemEditBox_Value.ItemToolTip = "";
            this.itemEditBox_Value.Location = new System.Drawing.Point(90, 9);
            this.itemEditBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Value.Name = "itemEditBox_Value";
            this.itemEditBox_Value.Size = new System.Drawing.Size(321, 30);
            this.itemEditBox_Value.TabIndex = 0;
            this.itemEditBox_Value.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(129, 319);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 3;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 351);
            this.ControlBox = false;
            this.Controls.Add(this.label_DataFlow);
            this.Controls.Add(this.groupBox_Elements);
            this.Controls.Add(this.comboBox_DataFlow);
            this.Controls.Add(this.itemEditBox_Value);
            this.Controls.Add(this.label_ArrayItem);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item.BitSplitter";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Index.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Bit)).EndInit();
            this.groupBox_Elements.ResumeLayout(false);
            this.groupBox_Elements.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Value;
        private System.Windows.Forms.Label label_ArrayItem;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Index;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Item;
        private System.Windows.Forms.Label label_Item;
        private System.Windows.Forms.Label label_Index;
        private System.Windows.Forms.Label label_DataFlow;
        private System.Windows.Forms.DataGridView dataGridView_Bit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.GroupBox groupBox_Elements;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.ComboBox comboBox_DataFlow;

    }
}