// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Binary.Counter
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
            this.label_Value = new System.Windows.Forms.Label();
            this.itemEditBox_Input = new Utils.SpecialControls.ItemEditBox();
            this.label_Input = new System.Windows.Forms.Label();
            this.comboBox_Front = new System.Windows.Forms.ComboBox();
            this.label_Front = new System.Windows.Forms.Label();
            this.label_P = new System.Windows.Forms.Label();
            this.label_N = new System.Windows.Forms.Label();
            this.comboBox_P = new System.Windows.Forms.ComboBox();
            this.comboBox_N = new System.Windows.Forms.ComboBox();
            this.checkBox_ReadOutput = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(85, 226);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 6;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // itemEditBox_Value
            // 
            this.itemEditBox_Value.ItemName = "";
            this.itemEditBox_Value.ItemRequirements = "Real, Read, Write, Obligatory";
            this.itemEditBox_Value.ItemToolTip = "";
            this.itemEditBox_Value.Location = new System.Drawing.Point(67, 159);
            this.itemEditBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Value.Name = "itemEditBox_Value";
            this.itemEditBox_Value.Size = new System.Drawing.Size(273, 30);
            this.itemEditBox_Value.TabIndex = 4;
            this.itemEditBox_Value.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(19, 166);
            this.label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 29;
            this.label_Value.Text = "Value:";
            // 
            // itemEditBox_Input
            // 
            this.itemEditBox_Input.ItemName = "";
            this.itemEditBox_Input.ItemRequirements = "Boolean, Read, Obligatory";
            this.itemEditBox_Input.ItemToolTip = "";
            this.itemEditBox_Input.Location = new System.Drawing.Point(67, 11);
            this.itemEditBox_Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Input.Name = "itemEditBox_Input";
            this.itemEditBox_Input.Size = new System.Drawing.Size(273, 30);
            this.itemEditBox_Input.TabIndex = 0;
            this.itemEditBox_Input.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Input
            // 
            this.label_Input.AutoSize = true;
            this.label_Input.Location = new System.Drawing.Point(19, 18);
            this.label_Input.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(43, 17);
            this.label_Input.TabIndex = 31;
            this.label_Input.Text = "Input:";
            // 
            // comboBox_Front
            // 
            this.comboBox_Front.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Front.FormattingEnabled = true;
            this.comboBox_Front.Location = new System.Drawing.Point(148, 51);
            this.comboBox_Front.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Front.Name = "comboBox_Front";
            this.comboBox_Front.Size = new System.Drawing.Size(134, 24);
            this.comboBox_Front.TabIndex = 1;
            // 
            // label_Front
            // 
            this.label_Front.AutoSize = true;
            this.label_Front.Location = new System.Drawing.Point(100, 55);
            this.label_Front.Name = "label_Front";
            this.label_Front.Size = new System.Drawing.Size(45, 17);
            this.label_Front.TabIndex = 35;
            this.label_Front.Text = "Front:";
            // 
            // label_P
            // 
            this.label_P.AutoSize = true;
            this.label_P.Location = new System.Drawing.Point(84, 90);
            this.label_P.Name = "label_P";
            this.label_P.Size = new System.Drawing.Size(61, 17);
            this.label_P.TabIndex = 36;
            this.label_P.Text = "Positive:";
            // 
            // label_N
            // 
            this.label_N.AutoSize = true;
            this.label_N.Location = new System.Drawing.Point(77, 125);
            this.label_N.Name = "label_N";
            this.label_N.Size = new System.Drawing.Size(68, 17);
            this.label_N.TabIndex = 37;
            this.label_N.Text = "Negative:";
            // 
            // comboBox_P
            // 
            this.comboBox_P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_P.FormattingEnabled = true;
            this.comboBox_P.Items.AddRange(new object[] {
            "Increase",
            "Decrease"});
            this.comboBox_P.Location = new System.Drawing.Point(148, 86);
            this.comboBox_P.Name = "comboBox_P";
            this.comboBox_P.Size = new System.Drawing.Size(134, 24);
            this.comboBox_P.TabIndex = 2;
            // 
            // comboBox_N
            // 
            this.comboBox_N.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_N.FormattingEnabled = true;
            this.comboBox_N.Items.AddRange(new object[] {
            "Increase",
            "Decrease"});
            this.comboBox_N.Location = new System.Drawing.Point(148, 121);
            this.comboBox_N.Name = "comboBox_N";
            this.comboBox_N.Size = new System.Drawing.Size(134, 24);
            this.comboBox_N.TabIndex = 3;
            // 
            // checkBox_ReadOutput
            // 
            this.checkBox_ReadOutput.AutoSize = true;
            this.checkBox_ReadOutput.Location = new System.Drawing.Point(67, 194);
            this.checkBox_ReadOutput.Name = "checkBox_ReadOutput";
            this.checkBox_ReadOutput.Size = new System.Drawing.Size(64, 21);
            this.checkBox_ReadOutput.TabIndex = 5;
            this.checkBox_ReadOutput.Text = "Read";
            this.checkBox_ReadOutput.UseVisualStyleBackColor = true;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 263);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_ReadOutput);
            this.Controls.Add(this.comboBox_N);
            this.Controls.Add(this.comboBox_P);
            this.Controls.Add(this.label_N);
            this.Controls.Add(this.label_P);
            this.Controls.Add(this.comboBox_Front);
            this.Controls.Add(this.label_Front);
            this.Controls.Add(this.itemEditBox_Input);
            this.Controls.Add(this.label_Input);
            this.Controls.Add(this.itemEditBox_Value);
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Binary.Counter";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Value;
        private System.Windows.Forms.Label label_Value;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Input;
        private System.Windows.Forms.Label label_Input;
        private System.Windows.Forms.ComboBox comboBox_Front;
        private System.Windows.Forms.Label label_Front;
        private System.Windows.Forms.Label label_P;
        private System.Windows.Forms.Label label_N;
        private System.Windows.Forms.ComboBox comboBox_P;
        private System.Windows.Forms.ComboBox comboBox_N;
        private System.Windows.Forms.CheckBox checkBox_ReadOutput;
    }
}