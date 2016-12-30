// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Item.Delay
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
            this.itemEditBox_On = new Utils.SpecialControls.ItemEditBox();
            this.label_On = new System.Windows.Forms.Label();
            this.itemEditBox_Out = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_In = new Utils.SpecialControls.ItemEditBox();
            this.label_OutItem = new System.Windows.Forms.Label();
            this.label_InItem = new System.Windows.Forms.Label();
            this.label_Delay = new System.Windows.Forms.Label();
            this.spinEdit_Delay = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Delay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(102, 153);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 4;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // itemEditBox_On
            // 
            this.itemEditBox_On.ItemName = "";
            this.itemEditBox_On.ItemRequirements = "Binary, Read, Write";
            this.itemEditBox_On.ItemToolTip = "";
            this.itemEditBox_On.Location = new System.Drawing.Point(66, 8);
            this.itemEditBox_On.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_On.Name = "itemEditBox_On";
            this.itemEditBox_On.Size = new System.Drawing.Size(321, 30);
            this.itemEditBox_On.TabIndex = 0;
            this.itemEditBox_On.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_On
            // 
            this.label_On.AutoSize = true;
            this.label_On.Location = new System.Drawing.Point(30, 15);
            this.label_On.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_On.Name = "label_On";
            this.label_On.Size = new System.Drawing.Size(31, 17);
            this.label_On.TabIndex = 51;
            this.label_On.Text = "On:";
            // 
            // itemEditBox_Out
            // 
            this.itemEditBox_Out.ItemName = "";
            this.itemEditBox_Out.ItemRequirements = "Any type, Write, Obligatory";
            this.itemEditBox_Out.ItemToolTip = "";
            this.itemEditBox_Out.Location = new System.Drawing.Point(66, 79);
            this.itemEditBox_Out.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Out.Name = "itemEditBox_Out";
            this.itemEditBox_Out.Size = new System.Drawing.Size(321, 30);
            this.itemEditBox_Out.TabIndex = 2;
            this.itemEditBox_Out.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_In
            // 
            this.itemEditBox_In.ItemName = "";
            this.itemEditBox_In.ItemRequirements = "Any type, Read, Obligatory";
            this.itemEditBox_In.ItemToolTip = "";
            this.itemEditBox_In.Location = new System.Drawing.Point(66, 43);
            this.itemEditBox_In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_In.Name = "itemEditBox_In";
            this.itemEditBox_In.Size = new System.Drawing.Size(321, 30);
            this.itemEditBox_In.TabIndex = 1;
            this.itemEditBox_In.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_OutItem
            // 
            this.label_OutItem.AutoSize = true;
            this.label_OutItem.Location = new System.Drawing.Point(6, 86);
            this.label_OutItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_OutItem.Name = "label_OutItem";
            this.label_OutItem.Size = new System.Drawing.Size(55, 17);
            this.label_OutItem.TabIndex = 55;
            this.label_OutItem.Text = "Output:";
            // 
            // label_InItem
            // 
            this.label_InItem.AutoSize = true;
            this.label_InItem.Location = new System.Drawing.Point(17, 50);
            this.label_InItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_InItem.Name = "label_InItem";
            this.label_InItem.Size = new System.Drawing.Size(43, 17);
            this.label_InItem.TabIndex = 54;
            this.label_InItem.Text = "Input:";
            // 
            // label_Delay
            // 
            this.label_Delay.AutoSize = true;
            this.label_Delay.Location = new System.Drawing.Point(75, 121);
            this.label_Delay.Name = "label_Delay";
            this.label_Delay.Size = new System.Drawing.Size(78, 17);
            this.label_Delay.TabIndex = 57;
            this.label_Delay.Text = "Delay [ms]:";
            // 
            // spinEdit_Delay
            // 
            this.spinEdit_Delay.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_Delay.Location = new System.Drawing.Point(161, 117);
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
            this.spinEdit_Delay.TabIndex = 3;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 190);
            this.ControlBox = false;
            this.Controls.Add(this.spinEdit_Delay);
            this.Controls.Add(this.label_Delay);
            this.Controls.Add(this.itemEditBox_Out);
            this.Controls.Add(this.itemEditBox_In);
            this.Controls.Add(this.label_OutItem);
            this.Controls.Add(this.label_InItem);
            this.Controls.Add(this.itemEditBox_On);
            this.Controls.Add(this.label_On);
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
            this.Text = "Item.Delay";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Delay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_On;
        private System.Windows.Forms.Label label_On;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Out;
        private Utils.SpecialControls.ItemEditBox itemEditBox_In;
        private System.Windows.Forms.Label label_OutItem;
        private System.Windows.Forms.Label label_InItem;
        private System.Windows.Forms.Label label_Delay;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Delay;
    }
}