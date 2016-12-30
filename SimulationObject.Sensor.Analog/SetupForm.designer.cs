// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Sensor.Analog
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
            this.groupBox_Raw = new System.Windows.Forms.GroupBox();
            this.checkBox_Fault = new System.Windows.Forms.CheckBox();
            this.textBox_FValue = new System.Windows.Forms.TextBox();
            this.label_FValue = new System.Windows.Forms.Label();
            this.itemEditBox_Item = new Utils.SpecialControls.ItemEditBox();
            this.label_Item = new System.Windows.Forms.Label();
            this.label_RMin = new System.Windows.Forms.Label();
            this.label_RMax = new System.Windows.Forms.Label();
            this.textBox_RawMin = new System.Windows.Forms.TextBox();
            this.textBox_RawMax = new System.Windows.Forms.TextBox();
            this.groupBox_Physical = new System.Windows.Forms.GroupBox();
            this.label_Units = new System.Windows.Forms.Label();
            this.label_PMin = new System.Windows.Forms.Label();
            this.label_PMax = new System.Windows.Forms.Label();
            this.textBox_Units = new System.Windows.Forms.TextBox();
            this.textBox_PMin = new System.Windows.Forms.TextBox();
            this.textBox_PMax = new System.Windows.Forms.TextBox();
            this.tabControl_Thrs = new System.Windows.Forms.TabControl();
            this.tabPage_Value = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.itemEditBox_Thd = new Utils.SpecialControls.ItemEditBox();
            this.button_Modify = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.label_Value = new System.Windows.Forms.Label();
            this.textBox_ThdValue = new System.Windows.Forms.TextBox();
            this.label_OP = new System.Windows.Forms.Label();
            this.comboBox_Operation = new System.Windows.Forms.ComboBox();
            this.label_Item2 = new System.Windows.Forms.Label();
            this.dataGridView_Thd = new System.Windows.Forms.DataGridView();
            this.Operation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Raw.SuspendLayout();
            this.groupBox_Physical.SuspendLayout();
            this.tabControl_Thrs.SuspendLayout();
            this.tabPage_Value.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Thd)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_Raw
            // 
            this.groupBox_Raw.Controls.Add(this.checkBox_Fault);
            this.groupBox_Raw.Controls.Add(this.textBox_FValue);
            this.groupBox_Raw.Controls.Add(this.label_FValue);
            this.groupBox_Raw.Controls.Add(this.itemEditBox_Item);
            this.groupBox_Raw.Controls.Add(this.label_Item);
            this.groupBox_Raw.Controls.Add(this.label_RMin);
            this.groupBox_Raw.Controls.Add(this.label_RMax);
            this.groupBox_Raw.Controls.Add(this.textBox_RawMin);
            this.groupBox_Raw.Controls.Add(this.textBox_RawMax);
            this.groupBox_Raw.Location = new System.Drawing.Point(5, 7);
            this.groupBox_Raw.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Raw.Name = "groupBox_Raw";
            this.groupBox_Raw.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Raw.Size = new System.Drawing.Size(421, 128);
            this.groupBox_Raw.TabIndex = 0;
            this.groupBox_Raw.TabStop = false;
            this.groupBox_Raw.Text = "Raw value";
            // 
            // checkBox_Fault
            // 
            this.checkBox_Fault.AutoSize = true;
            this.checkBox_Fault.Location = new System.Drawing.Point(53, 96);
            this.checkBox_Fault.Name = "checkBox_Fault";
            this.checkBox_Fault.Size = new System.Drawing.Size(61, 21);
            this.checkBox_Fault.TabIndex = 14;
            this.checkBox_Fault.Text = "Fault";
            this.checkBox_Fault.UseVisualStyleBackColor = true;
            // 
            // textBox_FValue
            // 
            this.textBox_FValue.Location = new System.Drawing.Point(215, 95);
            this.textBox_FValue.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_FValue.Name = "textBox_FValue";
            this.textBox_FValue.Size = new System.Drawing.Size(152, 22);
            this.textBox_FValue.TabIndex = 13;
            this.textBox_FValue.Text = "32767";
            // 
            // label_FValue
            // 
            this.label_FValue.AutoSize = true;
            this.label_FValue.Location = new System.Drawing.Point(126, 98);
            this.label_FValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_FValue.Name = "label_FValue";
            this.label_FValue.Size = new System.Drawing.Size(81, 17);
            this.label_FValue.TabIndex = 12;
            this.label_FValue.Text = "Fault value:";
            // 
            // itemEditBox_Item
            // 
            this.itemEditBox_Item.ItemName = "";
            this.itemEditBox_Item.ItemRequirements = "Real, Read, Write, Obligatory";
            this.itemEditBox_Item.ItemToolTip = "";
            this.itemEditBox_Item.Location = new System.Drawing.Point(59, 21);
            this.itemEditBox_Item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Item.Name = "itemEditBox_Item";
            this.itemEditBox_Item.Size = new System.Drawing.Size(356, 30);
            this.itemEditBox_Item.TabIndex = 0;
            this.itemEditBox_Item.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Item
            // 
            this.label_Item.AutoSize = true;
            this.label_Item.Location = new System.Drawing.Point(12, 28);
            this.label_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Item.Name = "label_Item";
            this.label_Item.Size = new System.Drawing.Size(38, 17);
            this.label_Item.TabIndex = 11;
            this.label_Item.Text = "Item:";
            // 
            // label_RMin
            // 
            this.label_RMin.AutoSize = true;
            this.label_RMin.Location = new System.Drawing.Point(220, 66);
            this.label_RMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_RMin.Name = "label_RMin";
            this.label_RMin.Size = new System.Drawing.Size(34, 17);
            this.label_RMin.TabIndex = 3;
            this.label_RMin.Text = "Min:";
            // 
            // label_RMax
            // 
            this.label_RMax.AutoSize = true;
            this.label_RMax.Location = new System.Drawing.Point(12, 66);
            this.label_RMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_RMax.Name = "label_RMax";
            this.label_RMax.Size = new System.Drawing.Size(37, 17);
            this.label_RMax.TabIndex = 2;
            this.label_RMax.Text = "Max:";
            // 
            // textBox_RawMin
            // 
            this.textBox_RawMin.Location = new System.Drawing.Point(260, 63);
            this.textBox_RawMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_RawMin.Name = "textBox_RawMin";
            this.textBox_RawMin.Size = new System.Drawing.Size(153, 22);
            this.textBox_RawMin.TabIndex = 2;
            this.textBox_RawMin.Text = "0";
            // 
            // textBox_RawMax
            // 
            this.textBox_RawMax.Location = new System.Drawing.Point(59, 63);
            this.textBox_RawMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_RawMax.Name = "textBox_RawMax";
            this.textBox_RawMax.Size = new System.Drawing.Size(152, 22);
            this.textBox_RawMax.TabIndex = 1;
            this.textBox_RawMax.Text = "27648";
            // 
            // groupBox_Physical
            // 
            this.groupBox_Physical.Controls.Add(this.label_Units);
            this.groupBox_Physical.Controls.Add(this.label_PMin);
            this.groupBox_Physical.Controls.Add(this.label_PMax);
            this.groupBox_Physical.Controls.Add(this.textBox_Units);
            this.groupBox_Physical.Controls.Add(this.textBox_PMin);
            this.groupBox_Physical.Controls.Add(this.textBox_PMax);
            this.groupBox_Physical.Location = new System.Drawing.Point(5, 143);
            this.groupBox_Physical.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Physical.Name = "groupBox_Physical";
            this.groupBox_Physical.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Physical.Size = new System.Drawing.Size(421, 94);
            this.groupBox_Physical.TabIndex = 1;
            this.groupBox_Physical.TabStop = false;
            this.groupBox_Physical.Text = "Physical value";
            // 
            // label_Units
            // 
            this.label_Units.AutoSize = true;
            this.label_Units.Location = new System.Drawing.Point(7, 63);
            this.label_Units.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Units.Name = "label_Units";
            this.label_Units.Size = new System.Drawing.Size(44, 17);
            this.label_Units.TabIndex = 6;
            this.label_Units.Text = "Units:";
            // 
            // label_PMin
            // 
            this.label_PMin.AutoSize = true;
            this.label_PMin.Location = new System.Drawing.Point(220, 26);
            this.label_PMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PMin.Name = "label_PMin";
            this.label_PMin.Size = new System.Drawing.Size(34, 17);
            this.label_PMin.TabIndex = 5;
            this.label_PMin.Text = "Min:";
            // 
            // label_PMax
            // 
            this.label_PMax.AutoSize = true;
            this.label_PMax.Location = new System.Drawing.Point(12, 26);
            this.label_PMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_PMax.Name = "label_PMax";
            this.label_PMax.Size = new System.Drawing.Size(37, 17);
            this.label_PMax.TabIndex = 4;
            this.label_PMax.Text = "Max:";
            // 
            // textBox_Units
            // 
            this.textBox_Units.Location = new System.Drawing.Point(59, 60);
            this.textBox_Units.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Units.Name = "textBox_Units";
            this.textBox_Units.Size = new System.Drawing.Size(68, 22);
            this.textBox_Units.TabIndex = 2;
            // 
            // textBox_PMin
            // 
            this.textBox_PMin.Location = new System.Drawing.Point(260, 23);
            this.textBox_PMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PMin.Name = "textBox_PMin";
            this.textBox_PMin.Size = new System.Drawing.Size(153, 22);
            this.textBox_PMin.TabIndex = 1;
            this.textBox_PMin.Text = "0";
            // 
            // textBox_PMax
            // 
            this.textBox_PMax.Location = new System.Drawing.Point(59, 23);
            this.textBox_PMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_PMax.Name = "textBox_PMax";
            this.textBox_PMax.Size = new System.Drawing.Size(152, 22);
            this.textBox_PMax.TabIndex = 0;
            this.textBox_PMax.Text = "100";
            // 
            // tabControl_Thrs
            // 
            this.tabControl_Thrs.Controls.Add(this.tabPage_Value);
            this.tabControl_Thrs.Controls.Add(this.tabPage2);
            this.tabControl_Thrs.Location = new System.Drawing.Point(3, 2);
            this.tabControl_Thrs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl_Thrs.Name = "tabControl_Thrs";
            this.tabControl_Thrs.SelectedIndex = 0;
            this.tabControl_Thrs.Size = new System.Drawing.Size(444, 272);
            this.tabControl_Thrs.TabIndex = 0;
            // 
            // tabPage_Value
            // 
            this.tabPage_Value.Controls.Add(this.groupBox_Raw);
            this.tabPage_Value.Controls.Add(this.groupBox_Physical);
            this.tabPage_Value.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Value.Name = "tabPage_Value";
            this.tabPage_Value.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Value.Size = new System.Drawing.Size(436, 243);
            this.tabPage_Value.TabIndex = 0;
            this.tabPage_Value.Text = "Value";
            this.tabPage_Value.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.itemEditBox_Thd);
            this.tabPage2.Controls.Add(this.button_Modify);
            this.tabPage2.Controls.Add(this.button_Delete);
            this.tabPage2.Controls.Add(this.button_Add);
            this.tabPage2.Controls.Add(this.label_Value);
            this.tabPage2.Controls.Add(this.textBox_ThdValue);
            this.tabPage2.Controls.Add(this.label_OP);
            this.tabPage2.Controls.Add(this.comboBox_Operation);
            this.tabPage2.Controls.Add(this.label_Item2);
            this.tabPage2.Controls.Add(this.dataGridView_Thd);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(436, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thresholds";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // itemEditBox_Thd
            // 
            this.itemEditBox_Thd.ItemName = "";
            this.itemEditBox_Thd.ItemRequirements = "Binary, Write, Obligatory";
            this.itemEditBox_Thd.ItemToolTip = "";
            this.itemEditBox_Thd.Location = new System.Drawing.Point(107, 63);
            this.itemEditBox_Thd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Thd.Name = "itemEditBox_Thd";
            this.itemEditBox_Thd.Size = new System.Drawing.Size(299, 30);
            this.itemEditBox_Thd.TabIndex = 2;
            this.itemEditBox_Thd.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(260, 98);
            this.button_Modify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(75, 26);
            this.button_Modify.TabIndex = 5;
            this.button_Modify.Text = "Modify";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(179, 98);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 26);
            this.button_Delete.TabIndex = 4;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(97, 98);
            this.button_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 26);
            this.button_Add.TabIndex = 3;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(52, 39);
            this.label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 27;
            this.label_Value.Text = "Value:";
            // 
            // textBox_ThdValue
            // 
            this.textBox_ThdValue.Location = new System.Drawing.Point(107, 36);
            this.textBox_ThdValue.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ThdValue.Name = "textBox_ThdValue";
            this.textBox_ThdValue.Size = new System.Drawing.Size(157, 22);
            this.textBox_ThdValue.TabIndex = 1;
            this.textBox_ThdValue.Text = "0";
            // 
            // label_OP
            // 
            this.label_OP.AutoSize = true;
            this.label_OP.Location = new System.Drawing.Point(27, 11);
            this.label_OP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_OP.Name = "label_OP";
            this.label_OP.Size = new System.Drawing.Size(75, 17);
            this.label_OP.TabIndex = 26;
            this.label_OP.Text = "Operation:";
            // 
            // comboBox_Operation
            // 
            this.comboBox_Operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operation.FormattingEnabled = true;
            this.comboBox_Operation.Location = new System.Drawing.Point(107, 6);
            this.comboBox_Operation.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Operation.Name = "comboBox_Operation";
            this.comboBox_Operation.Size = new System.Drawing.Size(297, 24);
            this.comboBox_Operation.TabIndex = 0;
            // 
            // label_Item2
            // 
            this.label_Item2.AutoSize = true;
            this.label_Item2.Location = new System.Drawing.Point(61, 70);
            this.label_Item2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Item2.Name = "label_Item2";
            this.label_Item2.Size = new System.Drawing.Size(38, 17);
            this.label_Item2.TabIndex = 13;
            this.label_Item2.Text = "Item:";
            // 
            // dataGridView_Thd
            // 
            this.dataGridView_Thd.AllowUserToAddRows = false;
            this.dataGridView_Thd.AllowUserToDeleteRows = false;
            this.dataGridView_Thd.AllowUserToResizeColumns = false;
            this.dataGridView_Thd.AllowUserToResizeRows = false;
            this.dataGridView_Thd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Thd.CausesValidation = false;
            this.dataGridView_Thd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Thd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Operation,
            this.Value,
            this.ItemID});
            this.dataGridView_Thd.Location = new System.Drawing.Point(7, 130);
            this.dataGridView_Thd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Thd.MultiSelect = false;
            this.dataGridView_Thd.Name = "dataGridView_Thd";
            this.dataGridView_Thd.ReadOnly = true;
            this.dataGridView_Thd.RowHeadersVisible = false;
            this.dataGridView_Thd.RowTemplate.Height = 24;
            this.dataGridView_Thd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Thd.ShowCellErrors = false;
            this.dataGridView_Thd.ShowCellToolTips = false;
            this.dataGridView_Thd.ShowEditingIcon = false;
            this.dataGridView_Thd.ShowRowErrors = false;
            this.dataGridView_Thd.Size = new System.Drawing.Size(420, 109);
            this.dataGridView_Thd.TabIndex = 6;
            this.dataGridView_Thd.SelectionChanged += new System.EventHandler(this.dataGridView_Thd_SelectionChanged);
            // 
            // Operation
            // 
            this.Operation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Operation.HeaderText = "Operation";
            this.Operation.Name = "Operation";
            this.Operation.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 73;
            // 
            // ItemID
            // 
            this.ItemID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemID.HeaderText = "Item";
            this.ItemID.Name = "ItemID";
            this.ItemID.ReadOnly = true;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(131, 279);
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
            this.ClientSize = new System.Drawing.Size(449, 319);
            this.ControlBox = false;
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.tabControl_Thrs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sensor.Analog";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Raw.ResumeLayout(false);
            this.groupBox_Raw.PerformLayout();
            this.groupBox_Physical.ResumeLayout(false);
            this.groupBox_Physical.PerformLayout();
            this.tabControl_Thrs.ResumeLayout(false);
            this.tabPage_Value.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Thd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_Raw;
        private System.Windows.Forms.TextBox textBox_RawMin;
        private System.Windows.Forms.TextBox textBox_RawMax;
        private System.Windows.Forms.GroupBox groupBox_Physical;
        private System.Windows.Forms.TextBox textBox_Units;
        private System.Windows.Forms.TextBox textBox_PMin;
        private System.Windows.Forms.TextBox textBox_PMax;
        private System.Windows.Forms.Label label_RMin;
        private System.Windows.Forms.Label label_RMax;
        private System.Windows.Forms.Label label_Units;
        private System.Windows.Forms.Label label_PMin;
        private System.Windows.Forms.Label label_PMax;
        private System.Windows.Forms.Label label_Item;
        private System.Windows.Forms.TabControl tabControl_Thrs;
        private System.Windows.Forms.TabPage tabPage_Value;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_Thd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.Label label_Item2;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.TextBox textBox_ThdValue;
        private System.Windows.Forms.Label label_OP;
        private System.Windows.Forms.ComboBox comboBox_Operation;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Add;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Item;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Thd;
        private System.Windows.Forms.TextBox textBox_FValue;
        private System.Windows.Forms.Label label_FValue;
        private System.Windows.Forms.CheckBox checkBox_Fault;
    }
}