// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Binary.Delay
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
            this.label_InItem = new System.Windows.Forms.Label();
            this.label_OutItem = new System.Windows.Forms.Label();
            this.checkBox_Inverse = new System.Windows.Forms.CheckBox();
            this.groupBox_Delay = new System.Windows.Forms.GroupBox();
            this.spinEdit_Off = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_On = new DevExpress.XtraEditors.SpinEdit();
            this.label_Off = new System.Windows.Forms.Label();
            this.label_On = new System.Windows.Forms.Label();
            this.itemEditBox_Out = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_In = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Delay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Off.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_On.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label_InItem
            // 
            this.label_InItem.AutoSize = true;
            this.label_InItem.Location = new System.Drawing.Point(19, 14);
            this.label_InItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_InItem.Name = "label_InItem";
            this.label_InItem.Size = new System.Drawing.Size(43, 17);
            this.label_InItem.TabIndex = 19;
            this.label_InItem.Text = "Input:";
            // 
            // label_OutItem
            // 
            this.label_OutItem.AutoSize = true;
            this.label_OutItem.Location = new System.Drawing.Point(8, 50);
            this.label_OutItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_OutItem.Name = "label_OutItem";
            this.label_OutItem.Size = new System.Drawing.Size(55, 17);
            this.label_OutItem.TabIndex = 21;
            this.label_OutItem.Text = "Output:";
            // 
            // checkBox_Inverse
            // 
            this.checkBox_Inverse.AutoSize = true;
            this.checkBox_Inverse.Location = new System.Drawing.Point(11, 164);
            this.checkBox_Inverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Inverse.Name = "checkBox_Inverse";
            this.checkBox_Inverse.Size = new System.Drawing.Size(76, 21);
            this.checkBox_Inverse.TabIndex = 3;
            this.checkBox_Inverse.Text = "Inverse";
            this.checkBox_Inverse.UseVisualStyleBackColor = true;
            // 
            // groupBox_Delay
            // 
            this.groupBox_Delay.Controls.Add(this.spinEdit_Off);
            this.groupBox_Delay.Controls.Add(this.spinEdit_On);
            this.groupBox_Delay.Controls.Add(this.label_Off);
            this.groupBox_Delay.Controls.Add(this.label_On);
            this.groupBox_Delay.Location = new System.Drawing.Point(11, 78);
            this.groupBox_Delay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Delay.Name = "groupBox_Delay";
            this.groupBox_Delay.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Delay.Size = new System.Drawing.Size(376, 81);
            this.groupBox_Delay.TabIndex = 2;
            this.groupBox_Delay.TabStop = false;
            this.groupBox_Delay.Text = "Delay";
            // 
            // spinEdit_Off
            // 
            this.spinEdit_Off.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Off.Location = new System.Drawing.Point(143, 48);
            this.spinEdit_Off.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Off.Name = "spinEdit_Off";
            this.spinEdit_Off.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Off.Properties.IsFloatValue = false;
            this.spinEdit_Off.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Off.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Off.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Off.Properties.Mask.EditMask = "N00";
            this.spinEdit_Off.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_Off.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_Off.TabIndex = 5;
            // 
            // spinEdit_On
            // 
            this.spinEdit_On.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_On.Location = new System.Drawing.Point(143, 15);
            this.spinEdit_On.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_On.Name = "spinEdit_On";
            this.spinEdit_On.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_On.Properties.IsFloatValue = false;
            this.spinEdit_On.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_On.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_On.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_On.Properties.Mask.EditMask = "N00";
            this.spinEdit_On.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_On.Size = new System.Drawing.Size(159, 24);
            this.spinEdit_On.TabIndex = 4;
            // 
            // label_Off
            // 
            this.label_Off.AutoSize = true;
            this.label_Off.Location = new System.Drawing.Point(75, 54);
            this.label_Off.Name = "label_Off";
            this.label_Off.Size = new System.Drawing.Size(61, 17);
            this.label_Off.TabIndex = 3;
            this.label_Off.Text = "Off [ms]:";
            // 
            // label_On
            // 
            this.label_On.AutoSize = true;
            this.label_On.Location = new System.Drawing.Point(75, 21);
            this.label_On.Name = "label_On";
            this.label_On.Size = new System.Drawing.Size(61, 17);
            this.label_On.TabIndex = 2;
            this.label_On.Text = "On [ms]:";
            // 
            // itemEditBox_Out
            // 
            this.itemEditBox_Out.ItemName = "";
            this.itemEditBox_Out.ItemRequirements = "Binary, Write, Obligatory";
            this.itemEditBox_Out.ItemToolTip = "";
            this.itemEditBox_Out.Location = new System.Drawing.Point(68, 43);
            this.itemEditBox_Out.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Out.Name = "itemEditBox_Out";
            this.itemEditBox_Out.Size = new System.Drawing.Size(321, 30);
            this.itemEditBox_Out.TabIndex = 1;
            this.itemEditBox_Out.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_In
            // 
            this.itemEditBox_In.ItemName = "";
            this.itemEditBox_In.ItemRequirements = "Binary, Read, Obligatory";
            this.itemEditBox_In.ItemToolTip = "";
            this.itemEditBox_In.Location = new System.Drawing.Point(68, 6);
            this.itemEditBox_In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_In.Name = "itemEditBox_In";
            this.itemEditBox_In.Size = new System.Drawing.Size(321, 30);
            this.itemEditBox_In.TabIndex = 0;
            this.itemEditBox_In.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(104, 191);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 229);
            this.ControlBox = false;
            this.Controls.Add(this.itemEditBox_Out);
            this.Controls.Add(this.itemEditBox_In);
            this.Controls.Add(this.groupBox_Delay);
            this.Controls.Add(this.checkBox_Inverse);
            this.Controls.Add(this.label_OutItem);
            this.Controls.Add(this.label_InItem);
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
            this.Text = "Binary.Delay";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Delay.ResumeLayout(false);
            this.groupBox_Delay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Off.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_On.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_InItem;
        private System.Windows.Forms.Label label_OutItem;
        private System.Windows.Forms.CheckBox checkBox_Inverse;
        private System.Windows.Forms.GroupBox groupBox_Delay;
        private System.Windows.Forms.Label label_On;
        private System.Windows.Forms.Label label_Off;
        private Utils.SpecialControls.ItemEditBox itemEditBox_In;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Out;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Off;
        private DevExpress.XtraEditors.SpinEdit spinEdit_On;
    }
}