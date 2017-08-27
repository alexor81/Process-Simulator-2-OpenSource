// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.ArrayDoubleTrend
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
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button_Clear = new System.Windows.Forms.Button();
            this.checkBox_Legend = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox_Label = new System.Windows.Forms.TextBox();
            this.label_Label = new System.Windows.Forms.Label();
            this.dataGridView_Elm = new System.Windows.Forms.DataGridView();
            this.button_Modify = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Delete = new System.Windows.Forms.Button();
            this.colorEdit = new DevExpress.XtraEditors.ColorEdit();
            this.label_Color = new System.Windows.Forms.Label();
            this.spinEdit_Index = new DevExpress.XtraEditors.SpinEdit();
            this.label_Index = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonEdit_Font = new DevExpress.XtraEditors.ButtonEdit();
            this.label_Font = new System.Windows.Forms.Label();
            this.spinEdit_Round = new DevExpress.XtraEditors.SpinEdit();
            this.checkBox_ShowCursor = new System.Windows.Forms.CheckBox();
            this.label_Round = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_TimeFrame = new System.Windows.Forms.Label();
            this.label_Update = new System.Windows.Forms.Label();
            this.trackBar_TimeFrame = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar_Update = new System.Windows.Forms.TrackBar();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox_MinMax = new System.Windows.Forms.GroupBox();
            this.button_Set = new System.Windows.Forms.Button();
            this.textBox_YMax = new System.Windows.Forms.TextBox();
            this.textBox_YMin = new System.Windows.Forms.TextBox();
            this.label_YMax = new System.Windows.Forms.Label();
            this.label_YMin = new System.Windows.Forms.Label();
            this.checkBox_YAutoScale = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowLabels = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Elm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Index.Properties)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TimeFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Update)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox_MinMax.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(80, 19);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(313, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(15, 24);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 25;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(418, 308);
            this.tabControl.TabIndex = 34;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button_Clear);
            this.tabPage1.Controls.Add(this.checkBox_Legend);
            this.tabPage1.Controls.Add(this.textBox_ToolTip);
            this.tabPage1.Controls.Add(this.label_ToolTip);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(410, 279);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button_Clear
            // 
            this.button_Clear.ForeColor = System.Drawing.Color.Black;
            this.button_Clear.Location = new System.Drawing.Point(254, 56);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(100, 28);
            this.button_Clear.TabIndex = 2;
            this.button_Clear.Text = "Clear Trend";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // checkBox_Legend
            // 
            this.checkBox_Legend.AutoSize = true;
            this.checkBox_Legend.Location = new System.Drawing.Point(80, 61);
            this.checkBox_Legend.Name = "checkBox_Legend";
            this.checkBox_Legend.Size = new System.Drawing.Size(78, 21);
            this.checkBox_Legend.TabIndex = 1;
            this.checkBox_Legend.Text = "Legend";
            this.checkBox_Legend.UseVisualStyleBackColor = true;
            this.checkBox_Legend.CheckedChanged += new System.EventHandler(this.checkBox_Legend_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox_Label);
            this.tabPage2.Controls.Add(this.label_Label);
            this.tabPage2.Controls.Add(this.dataGridView_Elm);
            this.tabPage2.Controls.Add(this.button_Modify);
            this.tabPage2.Controls.Add(this.button_Add);
            this.tabPage2.Controls.Add(this.button_Delete);
            this.tabPage2.Controls.Add(this.colorEdit);
            this.tabPage2.Controls.Add(this.label_Color);
            this.tabPage2.Controls.Add(this.spinEdit_Index);
            this.tabPage2.Controls.Add(this.label_Index);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(410, 279);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Series";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox_Label
            // 
            this.textBox_Label.Location = new System.Drawing.Point(135, 72);
            this.textBox_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Label.Name = "textBox_Label";
            this.textBox_Label.Size = new System.Drawing.Size(197, 22);
            this.textBox_Label.TabIndex = 2;
            // 
            // label_Label
            // 
            this.label_Label.AutoSize = true;
            this.label_Label.Location = new System.Drawing.Point(78, 75);
            this.label_Label.Name = "label_Label";
            this.label_Label.Size = new System.Drawing.Size(47, 17);
            this.label_Label.TabIndex = 73;
            this.label_Label.Text = "Label:";
            // 
            // dataGridView_Elm
            // 
            this.dataGridView_Elm.AllowUserToAddRows = false;
            this.dataGridView_Elm.AllowUserToDeleteRows = false;
            this.dataGridView_Elm.AllowUserToResizeColumns = false;
            this.dataGridView_Elm.AllowUserToResizeRows = false;
            this.dataGridView_Elm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Elm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Elm.CausesValidation = false;
            this.dataGridView_Elm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Elm.Location = new System.Drawing.Point(7, 140);
            this.dataGridView_Elm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_Elm.MultiSelect = false;
            this.dataGridView_Elm.Name = "dataGridView_Elm";
            this.dataGridView_Elm.ReadOnly = true;
            this.dataGridView_Elm.RowHeadersVisible = false;
            this.dataGridView_Elm.RowTemplate.Height = 24;
            this.dataGridView_Elm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Elm.ShowCellErrors = false;
            this.dataGridView_Elm.ShowCellToolTips = false;
            this.dataGridView_Elm.ShowEditingIcon = false;
            this.dataGridView_Elm.ShowRowErrors = false;
            this.dataGridView_Elm.Size = new System.Drawing.Size(396, 134);
            this.dataGridView_Elm.TabIndex = 72;
            this.dataGridView_Elm.TabStop = false;
            this.dataGridView_Elm.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView_Elm_CellPainting);
            this.dataGridView_Elm.SelectionChanged += new System.EventHandler(this.dataGridView_Elm_SelectionChanged);
            // 
            // button_Modify
            // 
            this.button_Modify.Location = new System.Drawing.Point(249, 107);
            this.button_Modify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Modify.Name = "button_Modify";
            this.button_Modify.Size = new System.Drawing.Size(75, 26);
            this.button_Modify.TabIndex = 5;
            this.button_Modify.Text = "Modify";
            this.button_Modify.UseVisualStyleBackColor = true;
            this.button_Modify.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(86, 107);
            this.button_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 26);
            this.button_Add.TabIndex = 3;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(168, 107);
            this.button_Delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(75, 26);
            this.button_Delete.TabIndex = 4;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // colorEdit
            // 
            this.colorEdit.EditValue = System.Drawing.Color.Blue;
            this.colorEdit.Location = new System.Drawing.Point(135, 39);
            this.colorEdit.Margin = new System.Windows.Forms.Padding(4);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit.Properties.LookAndFeel.SkinName = "Black";
            this.colorEdit.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit.Size = new System.Drawing.Size(197, 24);
            this.colorEdit.TabIndex = 1;
            // 
            // label_Color
            // 
            this.label_Color.AutoSize = true;
            this.label_Color.Location = new System.Drawing.Point(78, 43);
            this.label_Color.Name = "label_Color";
            this.label_Color.Size = new System.Drawing.Size(45, 17);
            this.label_Color.TabIndex = 67;
            this.label_Color.Text = "Color:";
            // 
            // spinEdit_Index
            // 
            this.spinEdit_Index.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Index.Location = new System.Drawing.Point(135, 7);
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
            2147483647,
            0,
            0,
            0});
            this.spinEdit_Index.Size = new System.Drawing.Size(135, 24);
            this.spinEdit_Index.TabIndex = 0;
            // 
            // label_Index
            // 
            this.label_Index.AutoSize = true;
            this.label_Index.Location = new System.Drawing.Point(78, 11);
            this.label_Index.Name = "label_Index";
            this.label_Index.Size = new System.Drawing.Size(45, 17);
            this.label_Index.TabIndex = 65;
            this.label_Index.Text = "Index:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonEdit_Font);
            this.tabPage3.Controls.Add(this.label_Font);
            this.tabPage3.Controls.Add(this.spinEdit_Round);
            this.tabPage3.Controls.Add(this.checkBox_ShowCursor);
            this.tabPage3.Controls.Add(this.label_Round);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(410, 279);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cursor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonEdit_Font
            // 
            this.buttonEdit_Font.Location = new System.Drawing.Point(84, 62);
            this.buttonEdit_Font.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_Font.Name = "buttonEdit_Font";
            this.buttonEdit_Font.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_Font.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_Font.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_Font.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Font.Properties.ReadOnly = true;
            this.buttonEdit_Font.Size = new System.Drawing.Size(289, 24);
            this.buttonEdit_Font.TabIndex = 2;
            this.buttonEdit_Font.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Font_ButtonClick);
            // 
            // label_Font
            // 
            this.label_Font.AutoSize = true;
            this.label_Font.Location = new System.Drawing.Point(37, 68);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(40, 17);
            this.label_Font.TabIndex = 52;
            this.label_Font.Text = "Font:";
            // 
            // spinEdit_Round
            // 
            this.spinEdit_Round.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Round.Location = new System.Drawing.Point(236, 20);
            this.spinEdit_Round.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Round.Name = "spinEdit_Round";
            this.spinEdit_Round.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Round.Properties.IsFloatValue = false;
            this.spinEdit_Round.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Round.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Round.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Round.Properties.Mask.EditMask = "N00";
            this.spinEdit_Round.Properties.MaxValue = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.spinEdit_Round.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.spinEdit_Round.Size = new System.Drawing.Size(137, 24);
            this.spinEdit_Round.TabIndex = 1;
            this.spinEdit_Round.EditValueChanged += new System.EventHandler(this.spinEdit_Round_EditValueChanged);
            // 
            // checkBox_ShowCursor
            // 
            this.checkBox_ShowCursor.AutoSize = true;
            this.checkBox_ShowCursor.Location = new System.Drawing.Point(38, 22);
            this.checkBox_ShowCursor.Name = "checkBox_ShowCursor";
            this.checkBox_ShowCursor.Size = new System.Drawing.Size(110, 21);
            this.checkBox_ShowCursor.TabIndex = 0;
            this.checkBox_ShowCursor.Text = "Show Cursor";
            this.checkBox_ShowCursor.UseVisualStyleBackColor = true;
            this.checkBox_ShowCursor.CheckedChanged += new System.EventHandler(this.checkBox_ShowCursor_CheckedChanged);
            // 
            // label_Round
            // 
            this.label_Round.AutoSize = true;
            this.label_Round.Location = new System.Drawing.Point(174, 24);
            this.label_Round.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Round.Name = "label_Round";
            this.label_Round.Size = new System.Drawing.Size(54, 17);
            this.label_Round.TabIndex = 50;
            this.label_Round.Text = "Round:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label_TimeFrame);
            this.tabPage4.Controls.Add(this.label_Update);
            this.tabPage4.Controls.Add(this.trackBar_TimeFrame);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.trackBar_Update);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(410, 279);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Axis X";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 41;
            this.label4.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "1";
            // 
            // label_TimeFrame
            // 
            this.label_TimeFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_TimeFrame.ForeColor = System.Drawing.Color.Black;
            this.label_TimeFrame.Location = new System.Drawing.Point(8, 84);
            this.label_TimeFrame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TimeFrame.Name = "label_TimeFrame";
            this.label_TimeFrame.Size = new System.Drawing.Size(392, 16);
            this.label_TimeFrame.TabIndex = 39;
            this.label_TimeFrame.Text = "Time Frame: 1 min";
            this.label_TimeFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Update
            // 
            this.label_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Update.ForeColor = System.Drawing.Color.Black;
            this.label_Update.Location = new System.Drawing.Point(8, 8);
            this.label_Update.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Update.Name = "label_Update";
            this.label_Update.Size = new System.Drawing.Size(392, 16);
            this.label_Update.TabIndex = 36;
            this.label_Update.Text = "Update Rate: 50 ms";
            this.label_Update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_TimeFrame
            // 
            this.trackBar_TimeFrame.Location = new System.Drawing.Point(7, 101);
            this.trackBar_TimeFrame.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_TimeFrame.Maximum = 5;
            this.trackBar_TimeFrame.Minimum = 1;
            this.trackBar_TimeFrame.Name = "trackBar_TimeFrame";
            this.trackBar_TimeFrame.Size = new System.Drawing.Size(395, 56);
            this.trackBar_TimeFrame.TabIndex = 1;
            this.trackBar_TimeFrame.Value = 1;
            this.trackBar_TimeFrame.ValueChanged += new System.EventHandler(this.trackBar_TimeFrame_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "1000";
            // 
            // trackBar_Update
            // 
            this.trackBar_Update.Location = new System.Drawing.Point(7, 25);
            this.trackBar_Update.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_Update.Maximum = 1000;
            this.trackBar_Update.Minimum = 50;
            this.trackBar_Update.Name = "trackBar_Update";
            this.trackBar_Update.Size = new System.Drawing.Size(395, 56);
            this.trackBar_Update.TabIndex = 0;
            this.trackBar_Update.TickFrequency = 100;
            this.trackBar_Update.Value = 50;
            this.trackBar_Update.ValueChanged += new System.EventHandler(this.trackBar_Update_ValueChanged);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.checkBox_ShowLabels);
            this.tabPage5.Controls.Add(this.groupBox_MinMax);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(410, 279);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Axis Y";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox_MinMax
            // 
            this.groupBox_MinMax.Controls.Add(this.button_Set);
            this.groupBox_MinMax.Controls.Add(this.checkBox_YAutoScale);
            this.groupBox_MinMax.Controls.Add(this.textBox_YMax);
            this.groupBox_MinMax.Controls.Add(this.textBox_YMin);
            this.groupBox_MinMax.Controls.Add(this.label_YMax);
            this.groupBox_MinMax.Controls.Add(this.label_YMin);
            this.groupBox_MinMax.Location = new System.Drawing.Point(100, 3);
            this.groupBox_MinMax.Name = "groupBox_MinMax";
            this.groupBox_MinMax.Size = new System.Drawing.Size(211, 147);
            this.groupBox_MinMax.TabIndex = 0;
            this.groupBox_MinMax.TabStop = false;
            // 
            // button_Set
            // 
            this.button_Set.Location = new System.Drawing.Point(80, 109);
            this.button_Set.Name = "button_Set";
            this.button_Set.Size = new System.Drawing.Size(55, 26);
            this.button_Set.TabIndex = 3;
            this.button_Set.Text = "Set";
            this.button_Set.UseVisualStyleBackColor = true;
            this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
            // 
            // textBox_YMax
            // 
            this.textBox_YMax.Location = new System.Drawing.Point(93, 49);
            this.textBox_YMax.Name = "textBox_YMax";
            this.textBox_YMax.Size = new System.Drawing.Size(100, 22);
            this.textBox_YMax.TabIndex = 1;
            // 
            // textBox_YMin
            // 
            this.textBox_YMin.Location = new System.Drawing.Point(93, 77);
            this.textBox_YMin.Name = "textBox_YMin";
            this.textBox_YMin.Size = new System.Drawing.Size(100, 22);
            this.textBox_YMin.TabIndex = 2;
            // 
            // label_YMax
            // 
            this.label_YMax.AutoSize = true;
            this.label_YMax.Location = new System.Drawing.Point(17, 52);
            this.label_YMax.Name = "label_YMax";
            this.label_YMax.Size = new System.Drawing.Size(70, 17);
            this.label_YMax.TabIndex = 1;
            this.label_YMax.Text = "Maximum:";
            // 
            // label_YMin
            // 
            this.label_YMin.AutoSize = true;
            this.label_YMin.Location = new System.Drawing.Point(20, 80);
            this.label_YMin.Name = "label_YMin";
            this.label_YMin.Size = new System.Drawing.Size(67, 17);
            this.label_YMin.TabIndex = 3;
            this.label_YMin.Text = "Minimum:";
            // 
            // checkBox_YAutoScale
            // 
            this.checkBox_YAutoScale.AutoSize = true;
            this.checkBox_YAutoScale.Location = new System.Drawing.Point(57, 18);
            this.checkBox_YAutoScale.Name = "checkBox_YAutoScale";
            this.checkBox_YAutoScale.Size = new System.Drawing.Size(96, 21);
            this.checkBox_YAutoScale.TabIndex = 0;
            this.checkBox_YAutoScale.Text = "Auto scale";
            this.checkBox_YAutoScale.UseVisualStyleBackColor = true;
            this.checkBox_YAutoScale.CheckedChanged += new System.EventHandler(this.checkBox_YAutoScale_CheckedChanged);
            // 
            // checkBox_ShowLabels
            // 
            this.checkBox_ShowLabels.AutoSize = true;
            this.checkBox_ShowLabels.Location = new System.Drawing.Point(157, 168);
            this.checkBox_ShowLabels.Name = "checkBox_ShowLabels";
            this.checkBox_ShowLabels.Size = new System.Drawing.Size(110, 21);
            this.checkBox_ShowLabels.TabIndex = 1;
            this.checkBox_ShowLabels.Text = "Show Labels";
            this.checkBox_ShowLabels.UseVisualStyleBackColor = true;
            this.checkBox_ShowLabels.CheckedChanged += new System.EventHandler(this.checkBox_ShowLabels_CheckedChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 308);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trend";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Elm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Index.Properties)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TimeFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Update)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox_MinMax.ResumeLayout(false);
            this.groupBox_MinMax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label_Color;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Index;
        private System.Windows.Forms.Label label_Index;
        private DevExpress.XtraEditors.ColorEdit colorEdit;
        private System.Windows.Forms.Button button_Modify;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.DataGridView dataGridView_Elm;
        private System.Windows.Forms.CheckBox checkBox_Legend;
        private System.Windows.Forms.Label label_Label;
        private System.Windows.Forms.TextBox textBox_Label;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.TabPage tabPage3;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Font;
        private System.Windows.Forms.Label label_Font;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Round;
        private System.Windows.Forms.CheckBox checkBox_ShowCursor;
        private System.Windows.Forms.Label label_Round;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_TimeFrame;
        private System.Windows.Forms.Label label_Update;
        private System.Windows.Forms.TrackBar trackBar_TimeFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar_Update;
        private System.Windows.Forms.GroupBox groupBox_MinMax;
        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.TextBox textBox_YMax;
        private System.Windows.Forms.TextBox textBox_YMin;
        private System.Windows.Forms.Label label_YMax;
        private System.Windows.Forms.Label label_YMin;
        private System.Windows.Forms.CheckBox checkBox_YAutoScale;
        private System.Windows.Forms.CheckBox checkBox_ShowLabels;
    }
}