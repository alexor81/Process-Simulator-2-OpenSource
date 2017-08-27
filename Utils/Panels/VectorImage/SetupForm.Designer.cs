// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.VectorImage
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
            this.toolStrip_Main = new System.Windows.Forms.ToolStrip();
            this.tsButton_SelectAll = new System.Windows.Forms.ToolStripButton();
            this.tsButton_SelectNone = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Copy = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Paste = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_CenterV = new System.Windows.Forms.ToolStripButton();
            this.tsButton_CenterH = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Options = new System.Windows.Forms.ToolStripButton();
            this.tsButton_AlignL = new System.Windows.Forms.ToolStripButton();
            this.tsButton_AlignR = new System.Windows.Forms.ToolStripButton();
            this.tsButton_AlignT = new System.Windows.Forms.ToolStripButton();
            this.tsButton_AlignB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_Fit = new System.Windows.Forms.ToolStripButton();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.panel_Editor = new System.Windows.Forms.Panel();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.listBox_Elements = new System.Windows.Forms.ListBox();
            this.toolStrip_Setup = new System.Windows.Forms.ToolStrip();
            this.tsButton_Setup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsButton_SendToBack = new System.Windows.Forms.ToolStripButton();
            this.tsButton_BringToFront = new System.Windows.Forms.ToolStripButton();
            this.panel_Draw = new System.Windows.Forms.Panel();
            this.labelControl_HW = new DevExpress.XtraEditors.LabelControl();
            this.labelControl_XY = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip_Draw = new System.Windows.Forms.ToolStrip();
            this.tsButton_Pointer = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Line = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Rectangle = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Ellipse = new System.Windows.Forms.ToolStripButton();
            this.tsButton_Text = new System.Windows.Forms.ToolStripButton();
            this.panel_OkCancel = new System.Windows.Forms.Panel();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.toolStrip_Main.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.panel_Editor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.toolStrip_Setup.SuspendLayout();
            this.panel_Draw.SuspendLayout();
            this.toolStrip_Draw.SuspendLayout();
            this.panel_OkCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Main
            // 
            this.toolStrip_Main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_SelectAll,
            this.tsButton_SelectNone,
            this.toolStripSeparator3,
            this.tsButton_Copy,
            this.tsButton_Paste,
            this.tsButton_Delete,
            this.toolStripSeparator6,
            this.tsButton_CenterV,
            this.tsButton_CenterH,
            this.tsButton_Options,
            this.tsButton_AlignL,
            this.tsButton_AlignR,
            this.tsButton_AlignT,
            this.tsButton_AlignB,
            this.toolStripSeparator1,
            this.tsButton_Fit});
            this.toolStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Main.Name = "toolStrip_Main";
            this.toolStrip_Main.Size = new System.Drawing.Size(812, 25);
            this.toolStrip_Main.TabIndex = 0;
            // 
            // tsButton_SelectAll
            // 
            this.tsButton_SelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_SelectAll.Image = global::Utils.Properties.Resources.SelectAll_Items;
            this.tsButton_SelectAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_SelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_SelectAll.Name = "tsButton_SelectAll";
            this.tsButton_SelectAll.Size = new System.Drawing.Size(23, 22);
            this.tsButton_SelectAll.ToolTipText = "Select All";
            this.tsButton_SelectAll.Click += new System.EventHandler(this.tsButton_SelectAll_Click);
            // 
            // tsButton_SelectNone
            // 
            this.tsButton_SelectNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_SelectNone.Image = global::Utils.Properties.Resources.SelectNone_Items;
            this.tsButton_SelectNone.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_SelectNone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_SelectNone.Name = "tsButton_SelectNone";
            this.tsButton_SelectNone.Size = new System.Drawing.Size(23, 22);
            this.tsButton_SelectNone.ToolTipText = "Select None";
            this.tsButton_SelectNone.Click += new System.EventHandler(this.tsButton_SelectNone_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Copy
            // 
            this.tsButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Copy.Image = global::Utils.Properties.Resources.Copy;
            this.tsButton_Copy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Copy.Name = "tsButton_Copy";
            this.tsButton_Copy.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Copy.ToolTipText = "Copy";
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
            this.tsButton_Paste.ToolTipText = "Paste";
            this.tsButton_Paste.Click += new System.EventHandler(this.tsButton_Paste_Click);
            // 
            // tsButton_Delete
            // 
            this.tsButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Delete.Image = global::Utils.Properties.Resources.Eracer;
            this.tsButton_Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Delete.Name = "tsButton_Delete";
            this.tsButton_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Delete.ToolTipText = "Delete";
            this.tsButton_Delete.Click += new System.EventHandler(this.tsButton_Delete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_CenterV
            // 
            this.tsButton_CenterV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_CenterV.Image = global::Utils.Properties.Resources.CenterH;
            this.tsButton_CenterV.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_CenterV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_CenterV.Name = "tsButton_CenterV";
            this.tsButton_CenterV.Size = new System.Drawing.Size(23, 22);
            this.tsButton_CenterV.Text = "Center Vertically";
            this.tsButton_CenterV.Click += new System.EventHandler(this.tsButton_CenterV_Click);
            // 
            // tsButton_CenterH
            // 
            this.tsButton_CenterH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_CenterH.Image = global::Utils.Properties.Resources.CenterV;
            this.tsButton_CenterH.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_CenterH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_CenterH.Name = "tsButton_CenterH";
            this.tsButton_CenterH.Size = new System.Drawing.Size(23, 22);
            this.tsButton_CenterH.Text = "Center Horizontally";
            this.tsButton_CenterH.ToolTipText = "Center Horizantally";
            this.tsButton_CenterH.Click += new System.EventHandler(this.tsButton_CenterH_Click);
            // 
            // tsButton_Options
            // 
            this.tsButton_Options.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsButton_Options.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Options.Image = global::Utils.Properties.Resources.Options;
            this.tsButton_Options.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Options.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Options.Name = "tsButton_Options";
            this.tsButton_Options.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Options.Text = "Options";
            this.tsButton_Options.Click += new System.EventHandler(this.tsButton_Options_Click);
            // 
            // tsButton_AlignL
            // 
            this.tsButton_AlignL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_AlignL.Image = global::Utils.Properties.Resources.AlignLeft;
            this.tsButton_AlignL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_AlignL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_AlignL.Name = "tsButton_AlignL";
            this.tsButton_AlignL.Size = new System.Drawing.Size(23, 22);
            this.tsButton_AlignL.Text = "Align Left";
            this.tsButton_AlignL.Click += new System.EventHandler(this.tsButton_AlignL_Click);
            // 
            // tsButton_AlignR
            // 
            this.tsButton_AlignR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_AlignR.Image = global::Utils.Properties.Resources.AlignRight;
            this.tsButton_AlignR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_AlignR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_AlignR.Name = "tsButton_AlignR";
            this.tsButton_AlignR.Size = new System.Drawing.Size(23, 22);
            this.tsButton_AlignR.Text = "Align Right";
            this.tsButton_AlignR.Click += new System.EventHandler(this.tsButton_AlignR_Click);
            // 
            // tsButton_AlignT
            // 
            this.tsButton_AlignT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_AlignT.Image = global::Utils.Properties.Resources.AlignTop;
            this.tsButton_AlignT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_AlignT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_AlignT.Name = "tsButton_AlignT";
            this.tsButton_AlignT.Size = new System.Drawing.Size(23, 22);
            this.tsButton_AlignT.Text = "Align Top";
            this.tsButton_AlignT.Click += new System.EventHandler(this.tsButton_AlignT_Click);
            // 
            // tsButton_AlignB
            // 
            this.tsButton_AlignB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_AlignB.Image = global::Utils.Properties.Resources.AlignBottom;
            this.tsButton_AlignB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_AlignB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_AlignB.Name = "tsButton_AlignB";
            this.tsButton_AlignB.Size = new System.Drawing.Size(23, 22);
            this.tsButton_AlignB.Text = "Align Bottom";
            this.tsButton_AlignB.Click += new System.EventHandler(this.tsButton_AlignB_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_Fit
            // 
            this.tsButton_Fit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Fit.Image = global::Utils.Properties.Resources.FitSize;
            this.tsButton_Fit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Fit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Fit.Name = "tsButton_Fit";
            this.tsButton_Fit.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Fit.Text = "Fit Panel Size";
            this.tsButton_Fit.Click += new System.EventHandler(this.tsButton_Fit_Click);
            // 
            // panel_Main
            // 
            this.panel_Main.Controls.Add(this.panel_Editor);
            this.panel_Main.Controls.Add(this.panel_OkCancel);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 25);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(812, 558);
            this.panel_Main.TabIndex = 3;
            // 
            // panel_Editor
            // 
            this.panel_Editor.Controls.Add(this.splitContainerControl);
            this.panel_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Editor.Location = new System.Drawing.Point(0, 0);
            this.panel_Editor.Name = "panel_Editor";
            this.panel_Editor.Size = new System.Drawing.Size(812, 518);
            this.panel_Editor.TabIndex = 3;
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl.LookAndFeel.SkinName = "Office 2010 Black";
            this.splitContainerControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Panel1.Controls.Add(this.listBox_Elements);
            this.splitContainerControl.Panel1.Controls.Add(this.toolStrip_Setup);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.Controls.Add(this.panel_Draw);
            this.splitContainerControl.Panel2.Controls.Add(this.toolStrip_Draw);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(812, 518);
            this.splitContainerControl.SplitterPosition = 85;
            this.splitContainerControl.TabIndex = 1;
            // 
            // listBox_Elements
            // 
            this.listBox_Elements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Elements.FormattingEnabled = true;
            this.listBox_Elements.IntegralHeight = false;
            this.listBox_Elements.ItemHeight = 16;
            this.listBox_Elements.Location = new System.Drawing.Point(0, 25);
            this.listBox_Elements.Name = "listBox_Elements";
            this.listBox_Elements.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Elements.Size = new System.Drawing.Size(85, 493);
            this.listBox_Elements.TabIndex = 2;
            this.listBox_Elements.TabStop = false;
            this.listBox_Elements.SelectedIndexChanged += new System.EventHandler(this.listBox_Elements_SelectedIndexChanged);
            this.listBox_Elements.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_Elements_MouseDown);
            // 
            // toolStrip_Setup
            // 
            this.toolStrip_Setup.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Setup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Setup,
            this.toolStripSeparator2,
            this.tsButton_SendToBack,
            this.tsButton_BringToFront});
            this.toolStrip_Setup.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Setup.Name = "toolStrip_Setup";
            this.toolStrip_Setup.Size = new System.Drawing.Size(85, 25);
            this.toolStrip_Setup.TabIndex = 1;
            this.toolStrip_Setup.Text = "toolStrip2";
            // 
            // tsButton_Setup
            // 
            this.tsButton_Setup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Setup.Image = global::Utils.Properties.Resources.Setup;
            this.tsButton_Setup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Setup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Setup.Name = "tsButton_Setup";
            this.tsButton_Setup.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Setup.ToolTipText = "Setup";
            this.tsButton_Setup.Click += new System.EventHandler(this.tsButton_Setup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsButton_SendToBack
            // 
            this.tsButton_SendToBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_SendToBack.Image = global::Utils.Properties.Resources.SendToBack;
            this.tsButton_SendToBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_SendToBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_SendToBack.Name = "tsButton_SendToBack";
            this.tsButton_SendToBack.Size = new System.Drawing.Size(23, 22);
            this.tsButton_SendToBack.ToolTipText = "Send To Back";
            this.tsButton_SendToBack.Click += new System.EventHandler(this.tsButton_SendToBack_Click);
            // 
            // tsButton_BringToFront
            // 
            this.tsButton_BringToFront.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_BringToFront.Image = global::Utils.Properties.Resources.BringToFront;
            this.tsButton_BringToFront.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_BringToFront.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_BringToFront.Name = "tsButton_BringToFront";
            this.tsButton_BringToFront.Size = new System.Drawing.Size(23, 22);
            this.tsButton_BringToFront.ToolTipText = "Bring To Front";
            this.tsButton_BringToFront.Click += new System.EventHandler(this.tsButton_BringToFront_Click);
            // 
            // panel_Draw
            // 
            this.panel_Draw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Draw.Controls.Add(this.labelControl_HW);
            this.panel_Draw.Controls.Add(this.labelControl_XY);
            this.panel_Draw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Draw.Location = new System.Drawing.Point(0, 25);
            this.panel_Draw.Name = "panel_Draw";
            this.panel_Draw.Size = new System.Drawing.Size(721, 493);
            this.panel_Draw.TabIndex = 2;
            this.panel_Draw.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Draw_Paint);
            this.panel_Draw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_Draw_MouseDown);
            this.panel_Draw.MouseEnter += new System.EventHandler(this.panel_Draw_MouseEnter);
            this.panel_Draw.MouseLeave += new System.EventHandler(this.panel_Draw_MouseLeave);
            this.panel_Draw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Draw_MouseMove);
            this.panel_Draw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_Draw_MouseUp);
            this.panel_Draw.Resize += new System.EventHandler(this.panel_Draw_Resize);
            // 
            // labelControl_HW
            // 
            this.labelControl_HW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl_HW.Appearance.Image = global::Utils.Properties.Resources.Size;
            this.labelControl_HW.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl_HW.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl_HW.Location = new System.Drawing.Point(56, 467);
            this.labelControl_HW.Name = "labelControl_HW";
            this.labelControl_HW.Size = new System.Drawing.Size(42, 19);
            this.labelControl_HW.TabIndex = 3;
            this.labelControl_HW.Text = "0, 0";
            // 
            // labelControl_XY
            // 
            this.labelControl_XY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl_XY.Appearance.Image = global::Utils.Properties.Resources.Crosshair;
            this.labelControl_XY.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl_XY.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl_XY.Location = new System.Drawing.Point(5, 465);
            this.labelControl_XY.Name = "labelControl_XY";
            this.labelControl_XY.Size = new System.Drawing.Size(45, 22);
            this.labelControl_XY.TabIndex = 2;
            this.labelControl_XY.Text = "0, 0";
            // 
            // toolStrip_Draw
            // 
            this.toolStrip_Draw.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Draw.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButton_Pointer,
            this.tsButton_Line,
            this.tsButton_Rectangle,
            this.tsButton_Ellipse,
            this.tsButton_Text});
            this.toolStrip_Draw.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Draw.Name = "toolStrip_Draw";
            this.toolStrip_Draw.Size = new System.Drawing.Size(721, 25);
            this.toolStrip_Draw.TabIndex = 1;
            this.toolStrip_Draw.Text = "toolStrip1";
            // 
            // tsButton_Pointer
            // 
            this.tsButton_Pointer.Checked = true;
            this.tsButton_Pointer.CheckOnClick = true;
            this.tsButton_Pointer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsButton_Pointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Pointer.Image = global::Utils.Properties.Resources.Arrow;
            this.tsButton_Pointer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Pointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Pointer.Name = "tsButton_Pointer";
            this.tsButton_Pointer.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Pointer.ToolTipText = "Pointer";
            this.tsButton_Pointer.Click += new System.EventHandler(this.tsButton_UserTool_Click);
            // 
            // tsButton_Line
            // 
            this.tsButton_Line.CheckOnClick = true;
            this.tsButton_Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Line.Image = global::Utils.Properties.Resources.Line;
            this.tsButton_Line.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Line.Name = "tsButton_Line";
            this.tsButton_Line.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Line.ToolTipText = "Line";
            this.tsButton_Line.Click += new System.EventHandler(this.tsButton_UserTool_Click);
            // 
            // tsButton_Rectangle
            // 
            this.tsButton_Rectangle.CheckOnClick = true;
            this.tsButton_Rectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Rectangle.Image = global::Utils.Properties.Resources.Rectangle;
            this.tsButton_Rectangle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Rectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Rectangle.Name = "tsButton_Rectangle";
            this.tsButton_Rectangle.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Rectangle.ToolTipText = "Rectangle";
            this.tsButton_Rectangle.Click += new System.EventHandler(this.tsButton_UserTool_Click);
            // 
            // tsButton_Ellipse
            // 
            this.tsButton_Ellipse.CheckOnClick = true;
            this.tsButton_Ellipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Ellipse.Image = global::Utils.Properties.Resources.Ellipse;
            this.tsButton_Ellipse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Ellipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Ellipse.Name = "tsButton_Ellipse";
            this.tsButton_Ellipse.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Ellipse.ToolTipText = "Ellipse";
            this.tsButton_Ellipse.Click += new System.EventHandler(this.tsButton_UserTool_Click);
            // 
            // tsButton_Text
            // 
            this.tsButton_Text.CheckOnClick = true;
            this.tsButton_Text.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButton_Text.Image = global::Utils.Properties.Resources.Text;
            this.tsButton_Text.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsButton_Text.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButton_Text.Name = "tsButton_Text";
            this.tsButton_Text.Size = new System.Drawing.Size(23, 22);
            this.tsButton_Text.ToolTipText = "Text";
            this.tsButton_Text.Click += new System.EventHandler(this.tsButton_UserTool_Click);
            // 
            // panel_OkCancel
            // 
            this.panel_OkCancel.Controls.Add(this.okCancelButton);
            this.panel_OkCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_OkCancel.Location = new System.Drawing.Point(0, 518);
            this.panel_OkCancel.Name = "panel_OkCancel";
            this.panel_OkCancel.Size = new System.Drawing.Size(812, 40);
            this.panel_OkCancel.TabIndex = 2;
            // 
            // okCancelButton
            // 
            this.okCancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.okCancelButton.Location = new System.Drawing.Point(312, 4);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 0;
            this.okCancelButton.TabStop = false;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 583);
            this.ControlBox = false;
            this.Controls.Add(this.panel_Main);
            this.Controls.Add(this.toolStrip_Main);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vector Image";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.SizeChanged += new System.EventHandler(this.SetupForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.toolStrip_Main.ResumeLayout(false);
            this.toolStrip_Main.PerformLayout();
            this.panel_Main.ResumeLayout(false);
            this.panel_Editor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.toolStrip_Setup.ResumeLayout(false);
            this.toolStrip_Setup.PerformLayout();
            this.panel_Draw.ResumeLayout(false);
            this.panel_Draw.PerformLayout();
            this.toolStrip_Draw.ResumeLayout(false);
            this.toolStrip_Draw.PerformLayout();
            this.panel_OkCancel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Main;
        private System.Windows.Forms.Panel panel_Main;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private System.Windows.Forms.Panel panel_OkCancel;
        private SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Panel panel_Editor;
        private System.Windows.Forms.ToolStripButton tsButton_SelectAll;
        private System.Windows.Forms.ToolStripButton tsButton_SelectNone;
        private System.Windows.Forms.ToolStripButton tsButton_Delete;
        private System.Windows.Forms.ToolStripButton tsButton_Copy;
        private System.Windows.Forms.ToolStripButton tsButton_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsButton_Options;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsButton_CenterV;
        private System.Windows.Forms.ToolStripButton tsButton_CenterH;
        private System.Windows.Forms.Panel panel_Draw;
        private System.Windows.Forms.ToolStrip toolStrip_Draw;
        private System.Windows.Forms.ToolStripButton tsButton_Pointer;
        private System.Windows.Forms.ToolStripButton tsButton_Line;
        private System.Windows.Forms.ToolStripButton tsButton_Rectangle;
        private System.Windows.Forms.ToolStripButton tsButton_Ellipse;
        private System.Windows.Forms.ToolStripButton tsButton_Text;
        private System.Windows.Forms.ListBox listBox_Elements;
        private System.Windows.Forms.ToolStrip toolStrip_Setup;
        private System.Windows.Forms.ToolStripButton tsButton_Setup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsButton_SendToBack;
        private System.Windows.Forms.ToolStripButton tsButton_BringToFront;
        private DevExpress.XtraEditors.LabelControl labelControl_XY;
        private System.Windows.Forms.ToolStripButton tsButton_AlignL;
        private System.Windows.Forms.ToolStripButton tsButton_AlignR;
        private System.Windows.Forms.ToolStripButton tsButton_AlignT;
        private System.Windows.Forms.ToolStripButton tsButton_AlignB;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsButton_Fit;
        private DevExpress.XtraEditors.LabelControl labelControl_HW;
    }
}