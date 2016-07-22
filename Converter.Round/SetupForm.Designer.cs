namespace Converter.Round
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
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.spinEdit_Round = new DevExpress.XtraEditors.SpinEdit();
            this.label_Round = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(25, 71);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 1;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // spinEdit_Round
            // 
            this.spinEdit_Round.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Round.Location = new System.Drawing.Point(82, 28);
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
            this.spinEdit_Round.Size = new System.Drawing.Size(137, 24);
            this.spinEdit_Round.TabIndex = 0;
            // 
            // label_Round
            // 
            this.label_Round.AutoSize = true;
            this.label_Round.Location = new System.Drawing.Point(20, 33);
            this.label_Round.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Round.Name = "label_Round";
            this.label_Round.Size = new System.Drawing.Size(54, 17);
            this.label_Round.TabIndex = 43;
            this.label_Round.Text = "Round:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 112);
            this.ControlBox = false;
            this.Controls.Add(this.spinEdit_Round);
            this.Controls.Add(this.label_Round);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Round";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Round.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Round;
        private System.Windows.Forms.Label label_Round;
    }
}