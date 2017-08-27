// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.StringTextEditor
{
    partial class StringTextEditorPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringTextEditorPanel));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Write = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Cut = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Copy = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Paste = new System.Windows.Forms.ToolStripButton();
            this.tsButton_SelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Undo = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Redo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_CollapseAll = new System.Windows.Forms.ToolStripButton();
            this.tsButton_ExpandAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Find = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Replace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_XMLPretty = new System.Windows.Forms.ToolStripButton();
            this.fastColoredTextBox_Text = new FastColoredTextBoxNS.FastColoredTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_Text)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Refresh,
            this.tsButton_Write,
            this.toolStripSeparator1,
            this.tsButton_Cut,
            this.tsButton_Copy,
            this.tsButton_Paste,
            this.tsButton_SelectAll,
            this.toolStripSeparator2,
            this.tsButton_Undo,
            this.tsButton_Redo,
            this.toolStripSeparator3,
            this.tsButton_CollapseAll,
            this.tsButton_ExpandAll,
            this.toolStripSeparator4,
            this.tsButton_Find,
            this.tsButton_Replace,
            this.toolStripSeparator5,
            this.tsButton_XMLPretty});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(230, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsButton_Refresh
            // 
            this.tsButton_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Refresh.Image = global::Utils.Properties.Resources.Refresh;
            this.tsButton_Refresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Refresh.Name = "tsButton_Refresh";
            this.tsButton_Refresh.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Refresh.Text = "Refresh";
            this.tsButton_Refresh.Click += new System.EventHandler(this.tsButton_Refresh_Click);
            // 
            // tsButton_Write
            // 
            this.tsButton_Write.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Write.Image = global::Utils.Properties.Resources.Pencil;
            this.tsButton_Write.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Write.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Write.Name = "tsButton_Write";
            this.tsButton_Write.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Write.Text = "Write";
            this.tsButton_Write.Click += new System.EventHandler(this.tsButton_Write_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Cut
            // 
            this.tsButton_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Cut.Image = global::Utils.Properties.Resources.Cut;
            this.tsButton_Cut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Cut.Name = "tsButton_Cut";
            this.tsButton_Cut.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Cut.Text = "Cut";
            this.tsButton_Cut.Click += new System.EventHandler(this.tsButton_Cut_Click);
            // 
            // tsButton_Copy
            // 
            this.tsButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Copy.Image = global::Utils.Properties.Resources.Copy;
            this.tsButton_Copy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Copy.Name = "tsButton_Copy";
            this.tsButton_Copy.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Copy.Text = "Copy";
            this.tsButton_Copy.Click += new System.EventHandler(this.tsButton_Copy_Click);
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
            // tsButton_SelectAll
            // 
            this.tsButton_SelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_SelectAll.Image = global::Utils.Properties.Resources.SelectAll;
            this.tsButton_SelectAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_SelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_SelectAll.Name = "tsButton_SelectAll";
            this.tsButton_SelectAll.Size = new System.Drawing.Size(23, 22);
            this.tsButton_SelectAll.Text = "Select All";
            this.tsButton_SelectAll.Click += new System.EventHandler(this.tsButton_SelectAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Undo
            // 
            this.tsButton_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Undo.Image = global::Utils.Properties.Resources.Undo;
            this.tsButton_Undo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Undo.Name = "tsButton_Undo";
            this.tsButton_Undo.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Undo.Text = "Undo";
            this.tsButton_Undo.Click += new System.EventHandler(this.tsButton_Undo_Click);
            // 
            // tsButton_Redo
            // 
            this.tsButton_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Redo.Image = global::Utils.Properties.Resources.Redo;
            this.tsButton_Redo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Redo.Name = "tsButton_Redo";
            this.tsButton_Redo.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Redo.Text = "Redo";
            this.tsButton_Redo.Click += new System.EventHandler(this.tsButton_Redo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_CollapseAll
            // 
            this.tsButton_CollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_CollapseAll.Image = global::Utils.Properties.Resources.Collapse;
            this.tsButton_CollapseAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_CollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_CollapseAll.Name = "tsButton_CollapseAll";
            this.tsButton_CollapseAll.Size = new System.Drawing.Size(23, 22);
            this.tsButton_CollapseAll.Text = "Collapse All";
            this.tsButton_CollapseAll.Click += new System.EventHandler(this.tsButton_CollapseAll_Click);
            // 
            // tsButton_ExpandAll
            // 
            this.tsButton_ExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_ExpandAll.Image = global::Utils.Properties.Resources.Expand;
            this.tsButton_ExpandAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_ExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_ExpandAll.Name = "tsButton_ExpandAll";
            this.tsButton_ExpandAll.Size = new System.Drawing.Size(23, 22);
            this.tsButton_ExpandAll.Text = "Expand All";
            this.tsButton_ExpandAll.Click += new System.EventHandler(this.tsButton_ExpandAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Find
            // 
            this.tsButton_Find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Find.Image = global::Utils.Properties.Resources.Find;
            this.tsButton_Find.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Find.Name = "tsButton_Find";
            this.tsButton_Find.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Find.Text = "Find";
            this.tsButton_Find.Click += new System.EventHandler(this.tsButton_Find_Click);
            // 
            // tsButton_Replace
            // 
            this.tsButton_Replace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Replace.Image = global::Utils.Properties.Resources.FindReplace;
            this.tsButton_Replace.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Replace.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Replace.Name = "tsButton_Replace";
            this.tsButton_Replace.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Replace.Text = "Replace";
            this.tsButton_Replace.Click += new System.EventHandler(this.tsButton_Replace_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 6);
            // 
            // tsButton_XMLPretty
            // 
            this.tsButton_XMLPretty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_XMLPretty.Image = global::Utils.Properties.Resources.document_smiley;
            this.tsButton_XMLPretty.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_XMLPretty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_XMLPretty.Name = "tsButton_XMLPretty";
            this.tsButton_XMLPretty.Size = new System.Drawing.Size(23, 20);
            this.tsButton_XMLPretty.Text = "Pretty XML";
            this.tsButton_XMLPretty.Click += new System.EventHandler(this.tsButton_PrettyXML_Click);
            // 
            // fastColoredTextBox_Text
            // 
            this.fastColoredTextBox_Text.AutoCompleteBracketsList = new char[] {
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
            this.fastColoredTextBox_Text.AutoIndentCharsPatterns = "\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\n^\\s*(case|default)\\s*[^:]*(" +
    "?<range>:)\\s*(?<range>[^;]+);\n";
            this.fastColoredTextBox_Text.AutoScrollMinSize = new System.Drawing.Size(29, 19);
            this.fastColoredTextBox_Text.BackBrush = null;
            this.fastColoredTextBox_Text.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox_Text.CharHeight = 19;
            this.fastColoredTextBox_Text.CharWidth = 9;
            this.fastColoredTextBox_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox_Text.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox_Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox_Text.Font = new System.Drawing.Font("Consolas", 10.2F);
            this.fastColoredTextBox_Text.IsReplaceMode = false;
            this.fastColoredTextBox_Text.LeftBracket = '(';
            this.fastColoredTextBox_Text.LeftBracket2 = '{';
            this.fastColoredTextBox_Text.Location = new System.Drawing.Point(0, 25);
            this.fastColoredTextBox_Text.Name = "fastColoredTextBox_Text";
            this.fastColoredTextBox_Text.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox_Text.RightBracket = ')';
            this.fastColoredTextBox_Text.RightBracket2 = '}';
            this.fastColoredTextBox_Text.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox_Text.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox_Text.ServiceColors")));
            this.fastColoredTextBox_Text.ShowFoldingLines = true;
            this.fastColoredTextBox_Text.Size = new System.Drawing.Size(230, 139);
            this.fastColoredTextBox_Text.TabIndex = 1;
            this.fastColoredTextBox_Text.TabStop = false;
            this.fastColoredTextBox_Text.WordWrapAutoIndent = false;
            this.fastColoredTextBox_Text.Zoom = 100;
            this.fastColoredTextBox_Text.UndoRedoStateChanged += new System.EventHandler<System.EventArgs>(this.fastColoredTextBox_Text_UndoRedoStateChanged);
            // 
            // StringTextEditorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fastColoredTextBox_Text);
            this.Controls.Add(this.toolStrip);
            this.Name = "StringTextEditorPanel";
            this.Size = new System.Drawing.Size(230, 164);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox_Text)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox_Text;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripButton tsButton_Refresh;
        private System.Windows.Forms.ToolStripButton tsButton_Write;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButton_Undo;
        private System.Windows.Forms.ToolStripButton tsButton_Redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButton_Cut;
        private System.Windows.Forms.ToolStripButton tsButton_Copy;
        private System.Windows.Forms.ToolStripButton tsButton_Paste;
        private System.Windows.Forms.ToolStripButton tsButton_SelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsButton_Find;
        private System.Windows.Forms.ToolStripButton tsButton_Replace;
        private System.Windows.Forms.ToolStripButton tsButton_CollapseAll;
        private System.Windows.Forms.ToolStripButton tsButton_ExpandAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsButton_XMLPretty;
    }
}
