// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Real.OneOfTwo
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
            this.itemEditBox_In2 = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_In1 = new Utils.SpecialControls.ItemEditBox();
            this.label_In2 = new System.Windows.Forms.Label();
            this.label_In1 = new System.Windows.Forms.Label();
            this.label_Value = new System.Windows.Forms.Label();
            this.itemEditBox_Switch = new Utils.SpecialControls.ItemEditBox();
            this.label_Switch = new System.Windows.Forms.Label();
            this.groupBox_Speed = new System.Windows.Forms.GroupBox();
            this.label_ToIn2 = new System.Windows.Forms.Label();
            this.spinEdit_In1ToIn2MS = new DevExpress.XtraEditors.SpinEdit();
            this.label_ToIn1 = new System.Windows.Forms.Label();
            this.spinEdit_In2ToIn1MS = new DevExpress.XtraEditors.SpinEdit();
            this.groupBox_Speed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In1ToIn2MS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In2ToIn1MS.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(107, 270);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 5;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // itemEditBox_Value
            // 
            this.itemEditBox_Value.ItemName = "";
            this.itemEditBox_Value.ItemRequirements = "Real, Write, Required";
            this.itemEditBox_Value.ItemToolTip = "";
            this.itemEditBox_Value.Location = new System.Drawing.Point(113, 128);
            this.itemEditBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Value.Name = "itemEditBox_Value";
            this.itemEditBox_Value.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_Value.TabIndex = 3;
            this.itemEditBox_Value.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_In2
            // 
            this.itemEditBox_In2.ItemName = "";
            this.itemEditBox_In2.ItemRequirements = "Real, Read, Required";
            this.itemEditBox_In2.ItemToolTip = "";
            this.itemEditBox_In2.Location = new System.Drawing.Point(113, 89);
            this.itemEditBox_In2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_In2.Name = "itemEditBox_In2";
            this.itemEditBox_In2.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_In2.TabIndex = 2;
            this.itemEditBox_In2.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_In1
            // 
            this.itemEditBox_In1.ItemName = "";
            this.itemEditBox_In1.ItemRequirements = "Real, Read, Required";
            this.itemEditBox_In1.ItemToolTip = "";
            this.itemEditBox_In1.Location = new System.Drawing.Point(113, 50);
            this.itemEditBox_In1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_In1.Name = "itemEditBox_In1";
            this.itemEditBox_In1.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_In1.TabIndex = 1;
            this.itemEditBox_In1.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_In2
            // 
            this.label_In2.AutoSize = true;
            this.label_In2.Location = new System.Drawing.Point(6, 96);
            this.label_In2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_In2.Name = "label_In2";
            this.label_In2.Size = new System.Drawing.Size(103, 17);
            this.label_In2.TabIndex = 46;
            this.label_In2.Text = "Input 2 (False):";
            // 
            // label_In1
            // 
            this.label_In1.AutoSize = true;
            this.label_In1.Location = new System.Drawing.Point(10, 57);
            this.label_In1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_In1.Name = "label_In1";
            this.label_In1.Size = new System.Drawing.Size(99, 17);
            this.label_In1.TabIndex = 45;
            this.label_In1.Text = "Input 1 (True):";
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(61, 135);
            this.label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 44;
            this.label_Value.Text = "Value:";
            // 
            // itemEditBox_Switch
            // 
            this.itemEditBox_Switch.ItemName = "";
            this.itemEditBox_Switch.ItemRequirements = "Boolean, Read, Write, Required";
            this.itemEditBox_Switch.ItemToolTip = "";
            this.itemEditBox_Switch.Location = new System.Drawing.Point(113, 11);
            this.itemEditBox_Switch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Switch.Name = "itemEditBox_Switch";
            this.itemEditBox_Switch.Size = new System.Drawing.Size(283, 30);
            this.itemEditBox_Switch.TabIndex = 0;
            this.itemEditBox_Switch.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Switch
            // 
            this.label_Switch.AutoSize = true;
            this.label_Switch.Location = new System.Drawing.Point(57, 18);
            this.label_Switch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Switch.Name = "label_Switch";
            this.label_Switch.Size = new System.Drawing.Size(52, 17);
            this.label_Switch.TabIndex = 48;
            this.label_Switch.Text = "Switch:";
            // 
            // groupBox_Speed
            // 
            this.groupBox_Speed.Controls.Add(this.label_ToIn2);
            this.groupBox_Speed.Controls.Add(this.spinEdit_In1ToIn2MS);
            this.groupBox_Speed.Controls.Add(this.label_ToIn1);
            this.groupBox_Speed.Controls.Add(this.spinEdit_In2ToIn1MS);
            this.groupBox_Speed.Location = new System.Drawing.Point(8, 165);
            this.groupBox_Speed.Name = "groupBox_Speed";
            this.groupBox_Speed.Size = new System.Drawing.Size(387, 95);
            this.groupBox_Speed.TabIndex = 4;
            this.groupBox_Speed.TabStop = false;
            this.groupBox_Speed.Text = "Transition delay [ms] for distance 100";
            // 
            // label_ToIn2
            // 
            this.label_ToIn2.AutoSize = true;
            this.label_ToIn2.Location = new System.Drawing.Point(67, 63);
            this.label_ToIn2.Name = "label_ToIn2";
            this.label_ToIn2.Size = new System.Drawing.Size(154, 17);
            this.label_ToIn2.TabIndex = 53;
            this.label_ToIn2.Text = "From Input 1 to Input 2:";
            // 
            // spinEdit_In1ToIn2MS
            // 
            this.spinEdit_In1ToIn2MS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_In1ToIn2MS.Location = new System.Drawing.Point(229, 59);
            this.spinEdit_In1ToIn2MS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_In1ToIn2MS.Name = "spinEdit_In1ToIn2MS";
            this.spinEdit_In1ToIn2MS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_In1ToIn2MS.Properties.IsFloatValue = false;
            this.spinEdit_In1ToIn2MS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_In1ToIn2MS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_In1ToIn2MS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_In1ToIn2MS.Properties.Mask.EditMask = "N00";
            this.spinEdit_In1ToIn2MS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_In1ToIn2MS.Size = new System.Drawing.Size(91, 24);
            this.spinEdit_In1ToIn2MS.TabIndex = 1;
            // 
            // label_ToIn1
            // 
            this.label_ToIn1.AutoSize = true;
            this.label_ToIn1.Location = new System.Drawing.Point(67, 31);
            this.label_ToIn1.Name = "label_ToIn1";
            this.label_ToIn1.Size = new System.Drawing.Size(154, 17);
            this.label_ToIn1.TabIndex = 51;
            this.label_ToIn1.Text = "From Input 2 to Input 1:";
            // 
            // spinEdit_In2ToIn1MS
            // 
            this.spinEdit_In2ToIn1MS.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_In2ToIn1MS.Location = new System.Drawing.Point(229, 27);
            this.spinEdit_In2ToIn1MS.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_In2ToIn1MS.Name = "spinEdit_In2ToIn1MS";
            this.spinEdit_In2ToIn1MS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_In2ToIn1MS.Properties.IsFloatValue = false;
            this.spinEdit_In2ToIn1MS.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_In2ToIn1MS.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_In2ToIn1MS.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_In2ToIn1MS.Properties.Mask.EditMask = "N00";
            this.spinEdit_In2ToIn1MS.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_In2ToIn1MS.Size = new System.Drawing.Size(91, 24);
            this.spinEdit_In2ToIn1MS.TabIndex = 0;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 305);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Speed);
            this.Controls.Add(this.itemEditBox_Switch);
            this.Controls.Add(this.label_Switch);
            this.Controls.Add(this.itemEditBox_Value);
            this.Controls.Add(this.itemEditBox_In2);
            this.Controls.Add(this.itemEditBox_In1);
            this.Controls.Add(this.label_In2);
            this.Controls.Add(this.label_In1);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Real.OneOfTwo";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Speed.ResumeLayout(false);
            this.groupBox_Speed.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In1ToIn2MS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In2ToIn1MS.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Value;
        private Utils.SpecialControls.ItemEditBox itemEditBox_In2;
        private Utils.SpecialControls.ItemEditBox itemEditBox_In1;
        private System.Windows.Forms.Label label_In2;
        private System.Windows.Forms.Label label_In1;
        private System.Windows.Forms.Label label_Value;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Switch;
        private System.Windows.Forms.Label label_Switch;
        private System.Windows.Forms.GroupBox groupBox_Speed;
        private System.Windows.Forms.Label label_ToIn2;
        private DevExpress.XtraEditors.SpinEdit spinEdit_In1ToIn2MS;
        private System.Windows.Forms.Label label_ToIn1;
        private DevExpress.XtraEditors.SpinEdit spinEdit_In2ToIn1MS;
    }
}