// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanButton
{
    partial class BooleanButtonPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton
            // 
            this.simpleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButton.Location = new System.Drawing.Point(0, 0);
            this.simpleButton.LookAndFeel.SkinName = "Office 2010 Black";
            this.simpleButton.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.simpleButton.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton.Name = "simpleButton";
            this.simpleButton.Size = new System.Drawing.Size(57, 36);
            this.simpleButton.TabIndex = 0;
            this.simpleButton.Click += new System.EventHandler(this.simpleButton_Click);
            // 
            // BooleanButtonPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BooleanButtonPanel";
            this.Size = new System.Drawing.Size(57, 36);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton;

    }
}
