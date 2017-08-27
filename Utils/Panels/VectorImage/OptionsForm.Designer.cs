// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.VectorImage
{
    partial class OptionsForm
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
            this.checkBox_IsConteiner = new System.Windows.Forms.CheckBox();
            this.label_BackgroundColor = new System.Windows.Forms.Label();
            this.colorEdit_Background = new DevExpress.XtraEditors.ColorEdit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Background.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_IsConteiner
            // 
            this.checkBox_IsConteiner.AutoSize = true;
            this.checkBox_IsConteiner.Location = new System.Drawing.Point(139, 52);
            this.checkBox_IsConteiner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_IsConteiner.Name = "checkBox_IsConteiner";
            this.checkBox_IsConteiner.Size = new System.Drawing.Size(91, 21);
            this.checkBox_IsConteiner.TabIndex = 1;
            this.checkBox_IsConteiner.Text = "Conteiner";
            this.checkBox_IsConteiner.UseVisualStyleBackColor = true;
            this.checkBox_IsConteiner.CheckedChanged += new System.EventHandler(this.checkBox_IsConteiner_CheckedChanged);
            // 
            // label_BackgroundColor
            // 
            this.label_BackgroundColor.AutoSize = true;
            this.label_BackgroundColor.ForeColor = System.Drawing.Color.Black;
            this.label_BackgroundColor.Location = new System.Drawing.Point(8, 17);
            this.label_BackgroundColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_BackgroundColor.Name = "label_BackgroundColor";
            this.label_BackgroundColor.Size = new System.Drawing.Size(123, 17);
            this.label_BackgroundColor.TabIndex = 33;
            this.label_BackgroundColor.Text = "Background color:";
            // 
            // colorEdit_Background
            // 
            this.colorEdit_Background.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Background.Location = new System.Drawing.Point(139, 13);
            this.colorEdit_Background.Margin = new System.Windows.Forms.Padding(4);
            this.colorEdit_Background.Name = "colorEdit_Background";
            this.colorEdit_Background.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Background.Properties.LookAndFeel.SkinName = "Black";
            this.colorEdit_Background.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Background.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Background.Size = new System.Drawing.Size(197, 24);
            this.colorEdit_Background.TabIndex = 0;
            this.colorEdit_Background.ColorChanged += new System.EventHandler(this.colorEdit_BackGround_ColorChanged);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 83);
            this.Controls.Add(this.label_BackgroundColor);
            this.Controls.Add(this.colorEdit_Background);
            this.Controls.Add(this.checkBox_IsConteiner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Background.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_IsConteiner;
        private System.Windows.Forms.Label label_BackgroundColor;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Background;
    }
}