// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Binary.Trigger
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
            this.label_Value = new System.Windows.Forms.Label();
            this.radioButton_SR = new System.Windows.Forms.RadioButton();
            this.radioButton_RS = new System.Windows.Forms.RadioButton();
            this.label_Set = new System.Windows.Forms.Label();
            this.label_Reset = new System.Windows.Forms.Label();
            this.itemEditBox_Value = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Reset = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Set = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.SuspendLayout();
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(9, 113);
            this.label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 19;
            this.label_Value.Text = "Value:";
            // 
            // radioButton_SR
            // 
            this.radioButton_SR.AutoSize = true;
            this.radioButton_SR.Location = new System.Drawing.Point(113, 80);
            this.radioButton_SR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_SR.Name = "radioButton_SR";
            this.radioButton_SR.Size = new System.Drawing.Size(48, 21);
            this.radioButton_SR.TabIndex = 2;
            this.radioButton_SR.TabStop = true;
            this.radioButton_SR.Text = "SR";
            this.radioButton_SR.UseVisualStyleBackColor = true;
            // 
            // radioButton_RS
            // 
            this.radioButton_RS.AutoSize = true;
            this.radioButton_RS.Location = new System.Drawing.Point(185, 80);
            this.radioButton_RS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_RS.Name = "radioButton_RS";
            this.radioButton_RS.Size = new System.Drawing.Size(48, 21);
            this.radioButton_RS.TabIndex = 3;
            this.radioButton_RS.TabStop = true;
            this.radioButton_RS.Text = "RS";
            this.radioButton_RS.UseVisualStyleBackColor = true;
            // 
            // label_Set
            // 
            this.label_Set.AutoSize = true;
            this.label_Set.Location = new System.Drawing.Point(24, 15);
            this.label_Set.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Set.Name = "label_Set";
            this.label_Set.Size = new System.Drawing.Size(33, 17);
            this.label_Set.TabIndex = 23;
            this.label_Set.Text = "Set:";
            // 
            // label_Reset
            // 
            this.label_Reset.AutoSize = true;
            this.label_Reset.Location = new System.Drawing.Point(8, 52);
            this.label_Reset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Reset.Name = "label_Reset";
            this.label_Reset.Size = new System.Drawing.Size(49, 17);
            this.label_Reset.TabIndex = 25;
            this.label_Reset.Text = "Reset:";
            // 
            // itemEditBox_Value
            // 
            this.itemEditBox_Value.ItemName = "";
            this.itemEditBox_Value.ItemRequirements = "Binary, Read, Write, Obligatory";
            this.itemEditBox_Value.ItemToolTip = "";
            this.itemEditBox_Value.Location = new System.Drawing.Point(63, 106);
            this.itemEditBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Value.Name = "itemEditBox_Value";
            this.itemEditBox_Value.Size = new System.Drawing.Size(281, 30);
            this.itemEditBox_Value.TabIndex = 4;
            this.itemEditBox_Value.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Reset
            // 
            this.itemEditBox_Reset.ItemName = "";
            this.itemEditBox_Reset.ItemRequirements = "Binary, Read, Obligatory";
            this.itemEditBox_Reset.ItemToolTip = "";
            this.itemEditBox_Reset.Location = new System.Drawing.Point(63, 44);
            this.itemEditBox_Reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Reset.Name = "itemEditBox_Reset";
            this.itemEditBox_Reset.Size = new System.Drawing.Size(281, 30);
            this.itemEditBox_Reset.TabIndex = 1;
            this.itemEditBox_Reset.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Set
            // 
            this.itemEditBox_Set.ItemName = "";
            this.itemEditBox_Set.ItemRequirements = "Binary, Read, Obligatory";
            this.itemEditBox_Set.ItemToolTip = "";
            this.itemEditBox_Set.Location = new System.Drawing.Point(63, 7);
            this.itemEditBox_Set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Set.Name = "itemEditBox_Set";
            this.itemEditBox_Set.Size = new System.Drawing.Size(281, 30);
            this.itemEditBox_Set.TabIndex = 0;
            this.itemEditBox_Set.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(82, 145);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 5;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 184);
            this.ControlBox = false;
            this.Controls.Add(this.itemEditBox_Value);
            this.Controls.Add(this.itemEditBox_Reset);
            this.Controls.Add(this.itemEditBox_Set);
            this.Controls.Add(this.label_Reset);
            this.Controls.Add(this.label_Set);
            this.Controls.Add(this.radioButton_RS);
            this.Controls.Add(this.radioButton_SR);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Binary.Trigger";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.RadioButton radioButton_SR;
        private System.Windows.Forms.RadioButton radioButton_RS;
        private System.Windows.Forms.Label label_Set;
        private System.Windows.Forms.Label label_Reset;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Set;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Reset;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Value;
    }
}