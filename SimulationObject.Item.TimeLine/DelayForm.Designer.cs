// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Item.TimeLine
{
    partial class DelayForm
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
            this.spinEdit_Delay = new DevExpress.XtraEditors.SpinEdit();
            this.label_Delay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Delay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(46, 71);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 1;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // spinEdit_Delay
            // 
            this.spinEdit_Delay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Delay.Location = new System.Drawing.Point(102, 26);
            this.spinEdit_Delay.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Delay.Name = "spinEdit_Delay";
            this.spinEdit_Delay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Delay.Properties.IsFloatValue = false;
            this.spinEdit_Delay.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Delay.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Delay.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Delay.Properties.Mask.EditMask = "N00";
            this.spinEdit_Delay.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_Delay.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_Delay.TabIndex = 0;
            // 
            // label_Delay
            // 
            this.label_Delay.AutoSize = true;
            this.label_Delay.Location = new System.Drawing.Point(20, 30);
            this.label_Delay.Name = "label_Delay";
            this.label_Delay.Size = new System.Drawing.Size(78, 17);
            this.label_Delay.TabIndex = 5;
            this.label_Delay.Text = "Delay [ms]:";
            // 
            // DelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 114);
            this.ControlBox = false;
            this.Controls.Add(this.spinEdit_Delay);
            this.Controls.Add(this.label_Delay);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "DelayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Section Delay";
            this.Load += new System.EventHandler(this.DelayForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DelayForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Delay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Delay;
        private System.Windows.Forms.Label label_Delay;
    }
}