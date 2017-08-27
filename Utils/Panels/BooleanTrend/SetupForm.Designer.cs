// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanTrend
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
            this.textBox_ToolTip = new System.Windows.Forms.TextBox();
            this.label_ToolTip = new System.Windows.Forms.Label();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label_Color = new System.Windows.Forms.Label();
            this.colorEdit = new DevExpress.XtraEditors.ColorEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_TimeFrame = new System.Windows.Forms.Label();
            this.trackBar_TimeFrame = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TimeFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_ToolTip
            // 
            this.textBox_ToolTip.Location = new System.Drawing.Point(79, 6);
            this.textBox_ToolTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_ToolTip.Name = "textBox_ToolTip";
            this.textBox_ToolTip.Size = new System.Drawing.Size(313, 22);
            this.textBox_ToolTip.TabIndex = 24;
            this.textBox_ToolTip.TextChanged += new System.EventHandler(this.textBox_ToolTip_TextChanged);
            // 
            // label_ToolTip
            // 
            this.label_ToolTip.AutoSize = true;
            this.label_ToolTip.Location = new System.Drawing.Point(14, 9);
            this.label_ToolTip.Name = "label_ToolTip";
            this.label_ToolTip.Size = new System.Drawing.Size(60, 17);
            this.label_ToolTip.TabIndex = 32;
            this.label_ToolTip.Text = "ToolTip:";
            // 
            // button_Clear
            // 
            this.button_Clear.ForeColor = System.Drawing.Color.Black;
            this.button_Clear.Location = new System.Drawing.Point(287, 110);
            this.button_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(100, 28);
            this.button_Clear.TabIndex = 27;
            this.button_Clear.Text = "Clear Trend";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label_Color
            // 
            this.label_Color.AutoSize = true;
            this.label_Color.ForeColor = System.Drawing.Color.Black;
            this.label_Color.Location = new System.Drawing.Point(19, 116);
            this.label_Color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Color.Name = "label_Color";
            this.label_Color.Size = new System.Drawing.Size(45, 17);
            this.label_Color.TabIndex = 31;
            this.label_Color.Text = "Color:";
            // 
            // colorEdit
            // 
            this.colorEdit.EditValue = System.Drawing.Color.Empty;
            this.colorEdit.Location = new System.Drawing.Point(68, 112);
            this.colorEdit.Margin = new System.Windows.Forms.Padding(4);
            this.colorEdit.Name = "colorEdit";
            this.colorEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit.Properties.LookAndFeel.SkinName = "Black";
            this.colorEdit.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit.Size = new System.Drawing.Size(197, 24);
            this.colorEdit.TabIndex = 26;
            this.colorEdit.ColorChanged += new System.EventHandler(this.colorEdit_ColorChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 87);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "1";
            // 
            // label_TimeFrame
            // 
            this.label_TimeFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_TimeFrame.ForeColor = System.Drawing.Color.Black;
            this.label_TimeFrame.Location = new System.Drawing.Point(7, 34);
            this.label_TimeFrame.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_TimeFrame.Name = "label_TimeFrame";
            this.label_TimeFrame.Size = new System.Drawing.Size(392, 16);
            this.label_TimeFrame.TabIndex = 28;
            this.label_TimeFrame.Text = "Time Frame: 1 min";
            this.label_TimeFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_TimeFrame
            // 
            this.trackBar_TimeFrame.Location = new System.Drawing.Point(6, 51);
            this.trackBar_TimeFrame.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_TimeFrame.Maximum = 5;
            this.trackBar_TimeFrame.Minimum = 1;
            this.trackBar_TimeFrame.Name = "trackBar_TimeFrame";
            this.trackBar_TimeFrame.Size = new System.Drawing.Size(395, 56);
            this.trackBar_TimeFrame.TabIndex = 25;
            this.trackBar_TimeFrame.Value = 1;
            this.trackBar_TimeFrame.ValueChanged += new System.EventHandler(this.trackBar_TimeFrame_ValueChanged);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 145);
            this.Controls.Add(this.textBox_ToolTip);
            this.Controls.Add(this.label_ToolTip);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.label_Color);
            this.Controls.Add(this.colorEdit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_TimeFrame);
            this.Controls.Add(this.trackBar_TimeFrame);
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
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_TimeFrame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ToolTip;
        private System.Windows.Forms.Label label_ToolTip;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label_Color;
        private DevExpress.XtraEditors.ColorEdit colorEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_TimeFrame;
        private System.Windows.Forms.TrackBar trackBar_TimeFrame;

    }
}