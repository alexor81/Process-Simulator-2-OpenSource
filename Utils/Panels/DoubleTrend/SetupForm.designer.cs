// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleTrend
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
            this.button_Clear = new System.Windows.Forms.Button();
            this.label_Color = new System.Windows.Forms.Label();
            this.colorEdit = new DevExpress.XtraEditors.ColorEdit();
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.checkBox_ShowCursor = new System.Windows.Forms.CheckBox();
            this.spinEdit_Round = new DevExpress.XtraEditors.SpinEdit();
            this.label_Round = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonEdit_Font = new DevExpress.XtraEditors.ButtonEdit();
            this.label_Font = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBar_Update = new System.Windows.Forms.TrackBar();
            this.label_Update = new System.Windows.Forms.Label();
            this.trackBar_TimeFrame = new System.Windows.Forms.TrackBar();
            this.label_TimeFrame = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox_MinMax = new System.Windows.Forms.GroupBox();
            this.button_Set = new System.Windows.Forms.Button();
            this.textBox_YMax = new System.Windows.Forms.TextBox();
            this.textBox_YMin = new System.Windows.Forms.TextBox();
            this.label_YMax = new System.Windows.Forms.Label();
            this.label_YMin = new System.Windows.Forms.Label();
            this.checkBox_YAutoScale = new System.Windows.Forms.CheckBox();
            this.checkBox_ShowLabels = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Update)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TimeFrame)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox_MinMax.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Clear
            // 
            this.button_Clear.ForeColor = System.Drawing.Color.Black;
            this.button_Clear.Location = new System.Drawing.Point(296, 56);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(100, 28);
            this.button_Clear.TabIndex = 2;
            this.button_Clear.Text = "Clear Trend";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label_Color
            // 
            this.label_Color.AutoSize = true;
            this.label_Color.ForeColor = System.Drawing.Color.Black;
            this.label_Color.Location = new System.Drawing.Point(33, 62);
            this.label_Color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Color.Name = "label_Color";
            this.label_Color.Size = new System.Drawing.Size(45, 17);
            this.label_Color.TabIndex = 22;
            this.label_Color.Text = "Color:";
            // 
            // colorEdit
            // 
            this.colorEdit.EditValue = System.Drawing.Color.Empty;
            this.colorEdit.Location = new System.Drawing.Point(82, 58);
            this.colorEdit.Margin = new System.Windows.Forms.Padding(4);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit.Properties.LookAndFeel.SkinName = "Black";
            this.colorEdit.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit.Size = new System.Drawing.Size(197, 24);
            this.colorEdit.TabIndex = 1;
            this.colorEdit.ColorChanged += new System.EventHandler(this.colorEdit_ColorChanged);
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(83, 18);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(313, 22);
            this.textBox_ToolTip.TabIndex = 0;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(18, 21);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 23;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // checkBox_ShowCursor
            // 
            this.checkBox_ShowCursor.AutoSize = true;
            this.checkBox_ShowCursor.Location = new System.Drawing.Point(40, 24);
            this.checkBox_ShowCursor.Name = "checkBox_ShowCursor";
            this.checkBox_ShowCursor.Size = new System.Drawing.Size(110, 21);
            this.checkBox_ShowCursor.TabIndex = 0;
            this.checkBox_ShowCursor.Text = "Show Cursor";
            this.checkBox_ShowCursor.UseVisualStyleBackColor = true;
            this.checkBox_ShowCursor.CheckedChanged += new System.EventHandler(this.checkBox_ShowCursor_CheckedChanged);
            // 
            // spinEdit_Round
            // 
            this.spinEdit_Round.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Round.Location = new System.Drawing.Point(238, 22);
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
            // label_Round
            // 
            this.label_Round.AutoSize = true;
            this.label_Round.Location = new System.Drawing.Point(176, 26);
            this.label_Round.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Round.Name = "label_Round";
            this.label_Round.Size = new System.Drawing.Size(54, 17);
            this.label_Round.TabIndex = 45;
            this.label_Round.Text = "Round:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 271);
            this.tabControl1.TabIndex = 46;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox_ToolTip);
            this.tabPage1.Controls.Add(this.label_ToolTip);
            this.tabPage1.Controls.Add(this.button_Clear);
            this.tabPage1.Controls.Add(this.label_Color);
            this.tabPage1.Controls.Add(this.colorEdit);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(415, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonEdit_Font);
            this.tabPage2.Controls.Add(this.label_Font);
            this.tabPage2.Controls.Add(this.spinEdit_Round);
            this.tabPage2.Controls.Add(this.checkBox_ShowCursor);
            this.tabPage2.Controls.Add(this.label_Round);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(415, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cursor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonEdit_Font
            // 
            this.buttonEdit_Font.Location = new System.Drawing.Point(86, 66);
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
            this.label_Font.Location = new System.Drawing.Point(39, 70);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(40, 17);
            this.label_Font.TabIndex = 47;
            this.label_Font.Text = "Font:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.trackBar_Update);
            this.tabPage3.Controls.Add(this.label_Update);
            this.tabPage3.Controls.Add(this.trackBar_TimeFrame);
            this.tabPage3.Controls.Add(this.label_TimeFrame);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(415, 242);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Axis X";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 64);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 58;
            this.label6.Text = "1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 64);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "50";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(380, 149);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 56;
            this.label7.Text = "5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 149);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 55;
            this.label8.Text = "1";
            // 
            // trackBar_Update
            // 
            this.trackBar_Update.Location = new System.Drawing.Point(10, 28);
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
            // label_Update
            // 
            this.label_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Update.ForeColor = System.Drawing.Color.Black;
            this.label_Update.Location = new System.Drawing.Point(11, 11);
            this.label_Update.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Update.Name = "label_Update";
            this.label_Update.Size = new System.Drawing.Size(392, 16);
            this.label_Update.TabIndex = 53;
            this.label_Update.Text = "Update Rate: 50 ms";
            this.label_Update.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_TimeFrame
            // 
            this.trackBar_TimeFrame.Location = new System.Drawing.Point(10, 113);
            this.trackBar_TimeFrame.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_TimeFrame.Maximum = 5;
            this.trackBar_TimeFrame.Minimum = 1;
            this.trackBar_TimeFrame.Name = "trackBar_TimeFrame";
            this.trackBar_TimeFrame.Size = new System.Drawing.Size(395, 56);
            this.trackBar_TimeFrame.TabIndex = 1;
            this.trackBar_TimeFrame.Value = 1;
            this.trackBar_TimeFrame.ValueChanged += new System.EventHandler(this.trackBar_TimeFrame_ValueChanged);
            // 
            // label_TimeFrame
            // 
            this.label_TimeFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_TimeFrame.ForeColor = System.Drawing.Color.Black;
            this.label_TimeFrame.Location = new System.Drawing.Point(11, 96);
            this.label_TimeFrame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TimeFrame.Name = "label_TimeFrame";
            this.label_TimeFrame.Size = new System.Drawing.Size(392, 16);
            this.label_TimeFrame.TabIndex = 54;
            this.label_TimeFrame.Text = "Time Frame: 1 min";
            this.label_TimeFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkBox_ShowLabels);
            this.tabPage4.Controls.Add(this.groupBox_MinMax);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(415, 242);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Axis Y";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox_MinMax
            // 
            this.groupBox_MinMax.Controls.Add(this.button_Set);
            this.groupBox_MinMax.Controls.Add(this.textBox_YMax);
            this.groupBox_MinMax.Controls.Add(this.checkBox_YAutoScale);
            this.groupBox_MinMax.Controls.Add(this.textBox_YMin);
            this.groupBox_MinMax.Controls.Add(this.label_YMax);
            this.groupBox_MinMax.Controls.Add(this.label_YMin);
            this.groupBox_MinMax.Location = new System.Drawing.Point(102, 3);
            this.groupBox_MinMax.Name = "groupBox_MinMax";
            this.groupBox_MinMax.Size = new System.Drawing.Size(211, 149);
            this.groupBox_MinMax.TabIndex = 0;
            this.groupBox_MinMax.TabStop = false;
            // 
            // button_Set
            // 
            this.button_Set.Location = new System.Drawing.Point(80, 111);
            this.button_Set.Name = "button_Set";
            this.button_Set.Size = new System.Drawing.Size(55, 26);
            this.button_Set.TabIndex = 3;
            this.button_Set.Text = "Set";
            this.button_Set.UseVisualStyleBackColor = true;
            this.button_Set.Click += new System.EventHandler(this.button_Set_Click);
            // 
            // textBox_YMax
            // 
            this.textBox_YMax.Location = new System.Drawing.Point(93, 51);
            this.textBox_YMax.Name = "textBox_YMax";
            this.textBox_YMax.Size = new System.Drawing.Size(100, 22);
            this.textBox_YMax.TabIndex = 1;
            // 
            // textBox_YMin
            // 
            this.textBox_YMin.Location = new System.Drawing.Point(93, 79);
            this.textBox_YMin.Name = "textBox_YMin";
            this.textBox_YMin.Size = new System.Drawing.Size(100, 22);
            this.textBox_YMin.TabIndex = 2;
            // 
            // label_YMax
            // 
            this.label_YMax.AutoSize = true;
            this.label_YMax.Location = new System.Drawing.Point(17, 54);
            this.label_YMax.Name = "label_YMax";
            this.label_YMax.Size = new System.Drawing.Size(70, 17);
            this.label_YMax.TabIndex = 1;
            this.label_YMax.Text = "Maximum:";
            // 
            // label_YMin
            // 
            this.label_YMin.AutoSize = true;
            this.label_YMin.Location = new System.Drawing.Point(20, 82);
            this.label_YMin.Name = "label_YMin";
            this.label_YMin.Size = new System.Drawing.Size(67, 17);
            this.label_YMin.TabIndex = 3;
            this.label_YMin.Text = "Minimum:";
            // 
            // checkBox_YAutoScale
            // 
            this.checkBox_YAutoScale.AutoSize = true;
            this.checkBox_YAutoScale.Location = new System.Drawing.Point(57, 20);
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
            this.checkBox_ShowLabels.Location = new System.Drawing.Point(152, 175);
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
            this.ClientSize = new System.Drawing.Size(423, 271);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trend";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Update)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TimeFrame)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox_MinMax.ResumeLayout(false);
            this.groupBox_MinMax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label_Color;
        private DevExpress.XtraEditors.ColorEdit colorEdit;
        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.CheckBox checkBox_ShowCursor;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Round;
        private System.Windows.Forms.Label label_Round;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Font;
        private System.Windows.Forms.Label label_Font;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar trackBar_Update;
        private System.Windows.Forms.Label label_Update;
        private System.Windows.Forms.TrackBar trackBar_TimeFrame;
        private System.Windows.Forms.Label label_TimeFrame;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox checkBox_YAutoScale;
        private System.Windows.Forms.TextBox textBox_YMin;
        private System.Windows.Forms.Label label_YMin;
        private System.Windows.Forms.TextBox textBox_YMax;
        private System.Windows.Forms.Label label_YMax;
        private System.Windows.Forms.GroupBox groupBox_MinMax;
        private System.Windows.Forms.Button button_Set;
        private System.Windows.Forms.CheckBox checkBox_ShowLabels;
    }
}