namespace SimulationObject.Script.CSharp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButton_Check = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Items = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Cut = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Copy = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Paste = new System.Windows.Forms.ToolStripButton();
            this.tsButton_SelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Undo = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_CollapseAll = new System.Windows.Forms.ToolStripButton();
            this.tsButton_ExpandAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Find = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Replace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLabel_Font = new System.Windows.Forms.ToolStripLabel();
            this.tsComboBox_Font = new System.Windows.Forms.ToolStripComboBox();
            this.tsButton_Options = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItem_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItem_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItem_CollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_ExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItem_Find = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_Replace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItem_Comment = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_Uncomment = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItem_Indent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_Clone = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItem_CloneAndComment = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.panel_Code = new System.Windows.Forms.Panel();
            this.splitContainerControl_Code = new DevExpress.XtraEditors.SplitContainerControl();
            this.fastColoredTextBox_Code = new FastColoredTextBoxNS.FastColoredTextBox();
            this.richTextBox_Result = new System.Windows.Forms.RichTextBox();
            this.toolStrip.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.panel_OkCancel.SuspendLayout();
            this.panel_Code.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Code)).BeginInit();
            this.splitContainerControl_Code.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_Code)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Check,
            this.tsButton_Items,
            this.toolStripSeparator4,
            this.tsButton_Cut,
            this.tsButton_Copy,
            this.tsButton_Paste,
            this.tsButton_SelectAll,
            this.toolStripSeparator1,
            this.tsButton_Undo,
            this.tsButton_Redo,
            this.toolStripSeparator9,
            this.tsButton_CollapseAll,
            this.tsButton_ExpandAll,
            this.toolStripSeparator2,
            this.tsButton_Find,
            this.tsButton_Replace,
            this.toolStripSeparator3,
            this.tsLabel_Font,
            this.tsComboBox_Font,
            this.tsButton_Options});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(658, 28);
            this.toolStrip.TabIndex = 0;
            // 
            // tsButton_Check
            // 
            this.tsButton_Check.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Check.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Check;
            this.tsButton_Check.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Check.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Check.Name = "tsButton_Check";
            this.tsButton_Check.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Check.Text = "Check";
            this.tsButton_Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // tsButton_Items
            // 
            this.tsButton_Items.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Items.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Book;
            this.tsButton_Items.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Items.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Items.Name = "tsButton_Items";
            this.tsButton_Items.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Items.Text = "Items";
            this.tsButton_Items.Click += new System.EventHandler(this.Items_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // tsButton_Cut
            // 
            this.tsButton_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Cut.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Cut;
            this.tsButton_Cut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Cut.Name = "tsButton_Cut";
            this.tsButton_Cut.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Cut.Text = "Cut";
            this.tsButton_Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // tsButton_Copy
            // 
            this.tsButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Copy.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Copy;
            this.tsButton_Copy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Copy.Name = "tsButton_Copy";
            this.tsButton_Copy.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Copy.Text = "Copy";
            this.tsButton_Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // tsButton_Paste
            // 
            this.tsButton_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Paste.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Paste;
            this.tsButton_Paste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Paste.Name = "tsButton_Paste";
            this.tsButton_Paste.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Paste.Text = "Paste";
            this.tsButton_Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // tsButton_SelectAll
            // 
            this.tsButton_SelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_SelectAll.Image = global::SimulationObject.Script.CSharp.Properties.Resources.SelectAll;
            this.tsButton_SelectAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_SelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_SelectAll.Name = "tsButton_SelectAll";
            this.tsButton_SelectAll.Size = new System.Drawing.Size(23, 25);
            this.tsButton_SelectAll.Text = "Select All";
            this.tsButton_SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // tsButton_Undo
            // 
            this.tsButton_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Undo.Enabled = false;
            this.tsButton_Undo.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Undo;
            this.tsButton_Undo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Undo.Name = "tsButton_Undo";
            this.tsButton_Undo.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Undo.Text = "Undo";
            this.tsButton_Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // tsButton_Redo
            // 
            this.tsButton_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Redo.Enabled = false;
            this.tsButton_Redo.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Redo;
            this.tsButton_Redo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Redo.Name = "tsButton_Redo";
            this.tsButton_Redo.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Redo.Text = "Redo";
            this.tsButton_Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 28);
            // 
            // tsButton_CollapseAll
            // 
            this.tsButton_CollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_CollapseAll.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Collapse;
            this.tsButton_CollapseAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_CollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_CollapseAll.Name = "tsButton_CollapseAll";
            this.tsButton_CollapseAll.Size = new System.Drawing.Size(23, 25);
            this.tsButton_CollapseAll.Text = "Collapse All";
            this.tsButton_CollapseAll.Click += new System.EventHandler(this.CollapseAll_Click);
            // 
            // tsButton_ExpandAll
            // 
            this.tsButton_ExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_ExpandAll.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Expand;
            this.tsButton_ExpandAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_ExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_ExpandAll.Name = "tsButton_ExpandAll";
            this.tsButton_ExpandAll.Size = new System.Drawing.Size(23, 25);
            this.tsButton_ExpandAll.Text = "Expand All";
            this.tsButton_ExpandAll.Click += new System.EventHandler(this.ExpandAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // tsButton_Find
            // 
            this.tsButton_Find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Find.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Find;
            this.tsButton_Find.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Find.Name = "tsButton_Find";
            this.tsButton_Find.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Find.Text = "Find";
            this.tsButton_Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // tsButton_Replace
            // 
            this.tsButton_Replace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Replace.Image = global::SimulationObject.Script.CSharp.Properties.Resources.FindReplace;
            this.tsButton_Replace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Replace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Replace.Name = "tsButton_Replace";
            this.tsButton_Replace.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Replace.Text = "Replace";
            this.tsButton_Replace.Click += new System.EventHandler(this.Replace_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // tsLabel_Font
            // 
            this.tsLabel_Font.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tsLabel_Font.Name = "tsLabel_Font";
            this.tsLabel_Font.Size = new System.Drawing.Size(41, 25);
            this.tsLabel_Font.Text = "Font:";
            // 
            // tsComboBox_Font
            // 
            this.tsComboBox_Font.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tsComboBox_Font.Items.AddRange(new object[] {
            "Small",
            "Medium",
            "Large"});
            this.tsComboBox_Font.Name = "tsComboBox_Font";
            this.tsComboBox_Font.Size = new System.Drawing.Size(121, 28);
            this.tsComboBox_Font.SelectedIndexChanged += new System.EventHandler(this.tsComboBox_Font_SelectedIndexChanged);
            // 
            // tsButton_Options
            // 
            this.tsButton_Options.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsButton_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Options.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Options;
            this.tsButton_Options.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Options.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Options.Name = "tsButton_Options";
            this.tsButton_Options.Size = new System.Drawing.Size(23, 25);
            this.tsButton_Options.Text = "Options";
            this.tsButton_Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem_Cut,
            this.tsMenuItem_Copy,
            this.tsMenuItem_Paste,
            this.tsMenuItem_SelectAll,
            this.toolStripSeparator5,
            this.tsMenuItem_Undo,
            this.tsMenuItem_Redo,
            this.toolStripSeparator10,
            this.tsMenuItem_CollapseAll,
            this.tsMenuItem_ExpandAll,
            this.toolStripSeparator6,
            this.tsMenuItem_Find,
            this.tsMenuItem_Replace,
            this.toolStripSeparator7,
            this.tsMenuItem_Comment,
            this.tsMenuItem_Uncomment,
            this.toolStripSeparator8,
            this.tsMenuItem_Indent,
            this.tsMenuItem_Clone,
            this.tsMenuItem_CloneAndComment});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(217, 394);
            // 
            // tsMenuItem_Cut
            // 
            this.tsMenuItem_Cut.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Cut;
            this.tsMenuItem_Cut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Cut.Name = "tsMenuItem_Cut";
            this.tsMenuItem_Cut.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Cut.Text = "Cut";
            this.tsMenuItem_Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // tsMenuItem_Copy
            // 
            this.tsMenuItem_Copy.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Copy;
            this.tsMenuItem_Copy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Copy.Name = "tsMenuItem_Copy";
            this.tsMenuItem_Copy.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Copy.Text = "Copy";
            this.tsMenuItem_Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // tsMenuItem_Paste
            // 
            this.tsMenuItem_Paste.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Paste;
            this.tsMenuItem_Paste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Paste.Name = "tsMenuItem_Paste";
            this.tsMenuItem_Paste.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Paste.Text = "Paste";
            this.tsMenuItem_Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // tsMenuItem_SelectAll
            // 
            this.tsMenuItem_SelectAll.Image = global::SimulationObject.Script.CSharp.Properties.Resources.SelectAll;
            this.tsMenuItem_SelectAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_SelectAll.Name = "tsMenuItem_SelectAll";
            this.tsMenuItem_SelectAll.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_SelectAll.Text = "Select All";
            this.tsMenuItem_SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(213, 6);
            // 
            // tsMenuItem_Undo
            // 
            this.tsMenuItem_Undo.Enabled = false;
            this.tsMenuItem_Undo.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Undo;
            this.tsMenuItem_Undo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Undo.Name = "tsMenuItem_Undo";
            this.tsMenuItem_Undo.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Undo.Text = "Undo";
            this.tsMenuItem_Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // tsMenuItem_Redo
            // 
            this.tsMenuItem_Redo.Enabled = false;
            this.tsMenuItem_Redo.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Redo;
            this.tsMenuItem_Redo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Redo.Name = "tsMenuItem_Redo";
            this.tsMenuItem_Redo.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Redo.Text = "Redo";
            this.tsMenuItem_Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(213, 6);
            // 
            // tsMenuItem_CollapseAll
            // 
            this.tsMenuItem_CollapseAll.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Collapse;
            this.tsMenuItem_CollapseAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_CollapseAll.Name = "tsMenuItem_CollapseAll";
            this.tsMenuItem_CollapseAll.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_CollapseAll.Text = "Collapse All";
            this.tsMenuItem_CollapseAll.Click += new System.EventHandler(this.CollapseAll_Click);
            // 
            // tsMenuItem_ExpandAll
            // 
            this.tsMenuItem_ExpandAll.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Expand;
            this.tsMenuItem_ExpandAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_ExpandAll.Name = "tsMenuItem_ExpandAll";
            this.tsMenuItem_ExpandAll.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_ExpandAll.Text = "Expand All";
            this.tsMenuItem_ExpandAll.Click += new System.EventHandler(this.ExpandAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(213, 6);
            // 
            // tsMenuItem_Find
            // 
            this.tsMenuItem_Find.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Find;
            this.tsMenuItem_Find.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Find.Name = "tsMenuItem_Find";
            this.tsMenuItem_Find.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Find.Text = "Find";
            this.tsMenuItem_Find.Click += new System.EventHandler(this.Find_Click);
            // 
            // tsMenuItem_Replace
            // 
            this.tsMenuItem_Replace.Image = global::SimulationObject.Script.CSharp.Properties.Resources.FindReplace;
            this.tsMenuItem_Replace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Replace.Name = "tsMenuItem_Replace";
            this.tsMenuItem_Replace.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Replace.Text = "Replace";
            this.tsMenuItem_Replace.Click += new System.EventHandler(this.Replace_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(213, 6);
            // 
            // tsMenuItem_Comment
            // 
            this.tsMenuItem_Comment.Name = "tsMenuItem_Comment";
            this.tsMenuItem_Comment.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Comment.Text = "Comment";
            this.tsMenuItem_Comment.Click += new System.EventHandler(this.Comment_Click);
            // 
            // tsMenuItem_Uncomment
            // 
            this.tsMenuItem_Uncomment.Name = "tsMenuItem_Uncomment";
            this.tsMenuItem_Uncomment.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Uncomment.Text = "Uncomment";
            this.tsMenuItem_Uncomment.Click += new System.EventHandler(this.Uncomment_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(213, 6);
            // 
            // tsMenuItem_Indent
            // 
            this.tsMenuItem_Indent.Image = global::SimulationObject.Script.CSharp.Properties.Resources.text_indent;
            this.tsMenuItem_Indent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Indent.Name = "tsMenuItem_Indent";
            this.tsMenuItem_Indent.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Indent.Text = "Indent";
            this.tsMenuItem_Indent.Click += new System.EventHandler(this.Indent_Click);
            // 
            // tsMenuItem_Clone
            // 
            this.tsMenuItem_Clone.Image = global::SimulationObject.Script.CSharp.Properties.Resources.Clone;
            this.tsMenuItem_Clone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMenuItem_Clone.Name = "tsMenuItem_Clone";
            this.tsMenuItem_Clone.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_Clone.Text = "Clone";
            this.tsMenuItem_Clone.Click += new System.EventHandler(this.Clone_Click);
            // 
            // tsMenuItem_CloneAndComment
            // 
            this.tsMenuItem_CloneAndComment.Name = "tsMenuItem_CloneAndComment";
            this.tsMenuItem_CloneAndComment.Size = new System.Drawing.Size(216, 24);
            this.tsMenuItem_CloneAndComment.Text = "Clone and Comment";
            this.tsMenuItem_CloneAndComment.Click += new System.EventHandler(this.CloneAndComment_Click);
            // 
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 515);
            this.panel_OkCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(658, 39);
            this.panel_OkCancel.TabIndex = 4;
            this.panel_OkCancel.TabStop = true;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okCancelButton.Location = new System.Drawing.Point(235, 4);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 5;
            this.okCancelButton.TabStop = false;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // panel_Code
            // 
            this.panel_Code.Controls.Add(this.splitContainerControl_Code);
            this.panel_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Code.Location = new System.Drawing.Point(0, 28);
            this.panel_Code.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Code.Name = "panel_Code";
            this.panel_Code.Size = new System.Drawing.Size(658, 487);
            this.panel_Code.TabIndex = 2;
            this.panel_Code.TabStop = true;
            // 
            // splitContainerControl_Code
            // 
            this.splitContainerControl_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl_Code.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl_Code.Horizontal = false;
            this.splitContainerControl_Code.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl_Code.LookAndFeel.SkinName = "Office 2010 Black";
            this.splitContainerControl_Code.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl_Code.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerControl_Code.Name = "splitContainerControl_Code";
            this.splitContainerControl_Code.Panel1.Controls.Add(this.fastColoredTextBox_Code);
            this.splitContainerControl_Code.Panel1.Text = "Panel1";
            this.splitContainerControl_Code.Panel2.Controls.Add(this.richTextBox_Result);
            this.splitContainerControl_Code.Panel2.Text = "Panel2";
            this.splitContainerControl_Code.Size = new System.Drawing.Size(658, 487);
            this.splitContainerControl_Code.SplitterPosition = 53;
            this.splitContainerControl_Code.TabIndex = 1;
            this.splitContainerControl_Code.TabStop = true;
            // 
            // fastColoredTextBox_Code
            // 
            this.fastColoredTextBox_Code.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox_Code.AutoScrollMinSize = new System.Drawing.Size(31, 18);
            this.fastColoredTextBox_Code.BackBrush = null;
            this.fastColoredTextBox_Code.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox_Code.CharHeight = 18;
            this.fastColoredTextBox_Code.CharWidth = 10;
            this.fastColoredTextBox_Code.ContextMenuStrip = this.contextMenuStrip;
            this.fastColoredTextBox_Code.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_Code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox_Code.IsReplaceMode = false;
            this.fastColoredTextBox_Code.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fastColoredTextBox_Code.LeftBracket = '(';
            this.fastColoredTextBox_Code.LeftBracket2 = '{';
            this.fastColoredTextBox_Code.Location = new System.Drawing.Point(0, 0);
            this.fastColoredTextBox_Code.Name = "fastColoredTextBox_Code";
            this.fastColoredTextBox_Code.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_Code.RightBracket = ')';
            this.fastColoredTextBox_Code.RightBracket2 = '}';
            this.fastColoredTextBox_Code.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_Code.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_Code.ServiceColors")));
            this.fastColoredTextBox_Code.Size = new System.Drawing.Size(658, 428);
            this.fastColoredTextBox_Code.TabIndex = 0;
            this.fastColoredTextBox_Code.TabStop = false;
            this.fastColoredTextBox_Code.Zoom = 100;
            this.fastColoredTextBox_Code.ToolTipNeeded += new System.EventHandler<FastColoredTextBoxNS.ToolTipNeededEventArgs>(this.fastColoredTextBox_Code_ToolTipNeeded);
            this.fastColoredTextBox_Code.LineRemoved += new System.EventHandler<FastColoredTextBoxNS.LineRemovedEventArgs>(this.fastColoredTextBox_Code_LineRemoved);
            this.fastColoredTextBox_Code.UndoRedoStateChanged += new System.EventHandler<System.EventArgs>(this.fastColoredTextBox_Code_UndoRedoStateChanged);
            // 
            // richTextBox_Result
            // 
            this.richTextBox_Result.DetectUrls = false;
            this.richTextBox_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Result.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Result.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox_Result.Name = "richTextBox_Result";
            this.richTextBox_Result.ReadOnly = true;
            this.richTextBox_Result.Size = new System.Drawing.Size(658, 53);
            this.richTextBox_Result.TabIndex = 0;
            this.richTextBox_Result.TabStop = false;
            this.richTextBox_Result.WordWrap = false;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 554);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Code);
            this.Controls.Add(this.panel_OkCancel);
            this.Controls.Add(this.toolStrip);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script.CSharp";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.SizeChanged += new System.EventHandler(this.SetupForm_SizeChanged);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.panel_OkCancel.ResumeLayout(false);
            this.panel_Code.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl_Code)).EndInit();
            this.splitContainerControl_Code.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_Code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsButton_Check;
        private System.Windows.Forms.ToolStripButton tsButton_Cut;
        private System.Windows.Forms.ToolStripButton tsButton_Copy;
        private System.Windows.Forms.ToolStripButton tsButton_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButton_SelectAll;
        private System.Windows.Forms.ToolStripButton tsButton_Undo;
        private System.Windows.Forms.ToolStripButton tsButton_Redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButton_Find;
        private System.Windows.Forms.ToolStripButton tsButton_Replace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel tsLabel_Font;
        private System.Windows.Forms.ToolStripComboBox tsComboBox_Font;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsButton_Options;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Cut;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Paste;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_SelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Undo;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Find;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Replace;
        private System.Windows.Forms.Panel panel_OkCancel;
        private System.Windows.Forms.Panel panel_Code;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl_Code;
        private System.Windows.Forms.RichTextBox richTextBox_Result;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Comment;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Uncomment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Indent;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_Clone;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_CloneAndComment;
        private System.Windows.Forms.ToolStripButton tsButton_Items;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsButton_CollapseAll;
        private System.Windows.Forms.ToolStripButton tsButton_ExpandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_CollapseAll;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItem_ExpandAll;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_Code;
    }
}