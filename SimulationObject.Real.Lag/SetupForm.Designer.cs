// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Real.Lag
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
            this.itemEditBox_Value = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Input = new Utils.SpecialControls.ItemEditBox();
            this.label_Input = new System.Windows.Forms.Label();
            this.label_Value = new System.Windows.Forms.Label();
            this.spinEdit_LagMS = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_Gain = new DevExpress.XtraEditors.SpinEdit();
            this.label_LagMS = new System.Windows.Forms.Label();
            this.label_Gain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LagMS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Gain.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(84, 156);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // itemEditBox_Value
            // 
            this.itemEditBox_Value.ItemName = "";
            this.itemEditBox_Value.ItemRequirements = "Real, Write, Required";
            this.itemEditBox_Value.ItemToolTip = "";
            this.itemEditBox_Value.Location = new System.Drawing.Point(65, 47);
            this.itemEditBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Value.Name = "itemEditBox_Value";
            this.itemEditBox_Value.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_Value.TabIndex = 1;
            this.itemEditBox_Value.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Input
            // 
            this.itemEditBox_Input.ItemName = "";
            this.itemEditBox_Input.ItemRequirements = "Real, Read, Required";
            this.itemEditBox_Input.ItemToolTip = "";
            this.itemEditBox_Input.Location = new System.Drawing.Point(65, 9);
            this.itemEditBox_Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Input.Name = "itemEditBox_Input";
            this.itemEditBox_Input.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_Input.TabIndex = 0;
            this.itemEditBox_Input.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Input
            // 
            this.label_Input.AutoSize = true;
            this.label_Input.Location = new System.Drawing.Point(16, 16);
            this.label_Input.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(43, 17);
            this.label_Input.TabIndex = 52;
            this.label_Input.Text = "Input:";
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(12, 54);
            this.label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 51;
            this.label_Value.Text = "Value:";
            // 
            // spinEdit_LagMS
            // 
            this.spinEdit_LagMS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_LagMS.Location = new System.Drawing.Point(137, 118);
            this.spinEdit_LagMS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_LagMS.Name = "spinEdit_LagMS";
            this.spinEdit_LagMS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_LagMS.Properties.IsFloatValue = false;
            this.spinEdit_LagMS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_LagMS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_LagMS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_LagMS.Properties.Mask.EditMask = "N00";
            this.spinEdit_LagMS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_LagMS.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_LagMS.TabIndex = 3;
            // 
            // spinEdit_Gain
            // 
            this.spinEdit_Gain.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Gain.Location = new System.Drawing.Point(137, 86);
            this.spinEdit_Gain.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Gain.Name = "spinEdit_Gain";
            this.spinEdit_Gain.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Gain.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Gain.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Gain.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Gain.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_Gain.TabIndex = 2;
            // 
            // label_LagMS
            // 
            this.label_LagMS.AutoSize = true;
            this.label_LagMS.Location = new System.Drawing.Point(65, 123);
            this.label_LagMS.Name = "label_LagMS";
            this.label_LagMS.Size = new System.Drawing.Size(66, 17);
            this.label_LagMS.TabIndex = 54;
            this.label_LagMS.Text = "Lag [ms]:";
            // 
            // label_Gain
            // 
            this.label_Gain.AutoSize = true;
            this.label_Gain.Location = new System.Drawing.Point(89, 91);
            this.label_Gain.Name = "label_Gain";
            this.label_Gain.Size = new System.Drawing.Size(42, 17);
            this.label_Gain.TabIndex = 53;
            this.label_Gain.Text = "Gain:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 190);
            this.ControlBox = false;
            this.Controls.Add(this.spinEdit_LagMS);
            this.Controls.Add(this.spinEdit_Gain);
            this.Controls.Add(this.label_LagMS);
            this.Controls.Add(this.label_Gain);
            this.Controls.Add(this.itemEditBox_Value);
            this.Controls.Add(this.itemEditBox_Input);
            this.Controls.Add(this.label_Input);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Real.Lag";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_LagMS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Gain.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Value;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Input;
        private System.Windows.Forms.Label label_Input;
        private System.Windows.Forms.Label label_Value;
        private DevExpress.XtraEditors.SpinEdit spinEdit_LagMS;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Gain;
        private System.Windows.Forms.Label label_LagMS;
        private System.Windows.Forms.Label label_Gain;
    }
}