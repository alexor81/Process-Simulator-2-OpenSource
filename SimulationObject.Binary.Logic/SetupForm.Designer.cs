namespace SimulationObject.Binary.Logic
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
            this.label_In2 = new System.Windows.Forms.Label();
            this.label_In1 = new System.Windows.Forms.Label();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Operator = new System.Windows.Forms.Label();
            this.comboBox_Operator = new System.Windows.Forms.ComboBox();
            this.itemEditBox_Value = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_In2 = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_In1 = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.checkBox_In1Inverse = new System.Windows.Forms.CheckBox();
            this.checkBox_In2Inverse = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_In2
            // 
            this.label_In2.AutoSize = true;
            this.label_In2.Location = new System.Drawing.Point(19, 78);
            this.label_In2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_In2.Name = "label_In2";
            this.label_In2.Size = new System.Drawing.Size(55, 17);
            this.label_In2.TabIndex = 31;
            this.label_In2.Text = "Input 2:";
            // 
            // label_In1
            // 
            this.label_In1.AutoSize = true;
            this.label_In1.Location = new System.Drawing.Point(19, 12);
            this.label_In1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_In1.Name = "label_In1";
            this.label_In1.Size = new System.Drawing.Size(55, 17);
            this.label_In1.TabIndex = 29;
            this.label_In1.Text = "Input 1:";
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(26, 171);
            this.label_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 27;
            this.label_Value.Text = "Value:";
            // 
            // label_Operator
            // 
            this.label_Operator.AutoSize = true;
            this.label_Operator.Location = new System.Drawing.Point(5, 136);
            this.label_Operator.Name = "label_Operator";
            this.label_Operator.Size = new System.Drawing.Size(69, 17);
            this.label_Operator.TabIndex = 33;
            this.label_Operator.Text = "Operator:";
            // 
            // comboBox_Operator
            // 
            this.comboBox_Operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operator.FormattingEnabled = true;
            this.comboBox_Operator.Location = new System.Drawing.Point(74, 132);
            this.comboBox_Operator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Operator.Name = "comboBox_Operator";
            this.comboBox_Operator.Size = new System.Drawing.Size(89, 24);
            this.comboBox_Operator.TabIndex = 4;
            // 
            // itemEditBox_Value
            // 
            this.itemEditBox_Value.ItemName = "";
            this.itemEditBox_Value.ItemRequirements = "Binay, Write, Obligatory";
            this.itemEditBox_Value.ItemToolTip = "";
            this.itemEditBox_Value.Location = new System.Drawing.Point(74, 164);
            this.itemEditBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Value.Name = "itemEditBox_Value";
            this.itemEditBox_Value.Size = new System.Drawing.Size(273, 30);
            this.itemEditBox_Value.TabIndex = 5;
            this.itemEditBox_Value.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_In2
            // 
            this.itemEditBox_In2.ItemName = "";
            this.itemEditBox_In2.ItemRequirements = "Binary, Read";
            this.itemEditBox_In2.ItemToolTip = "";
            this.itemEditBox_In2.Location = new System.Drawing.Point(74, 70);
            this.itemEditBox_In2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_In2.Name = "itemEditBox_In2";
            this.itemEditBox_In2.Size = new System.Drawing.Size(273, 30);
            this.itemEditBox_In2.TabIndex = 2;
            this.itemEditBox_In2.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_In1
            // 
            this.itemEditBox_In1.ItemName = "";
            this.itemEditBox_In1.ItemRequirements = "Binary, Read, Obligatory";
            this.itemEditBox_In1.ItemToolTip = "";
            this.itemEditBox_In1.Location = new System.Drawing.Point(74, 5);
            this.itemEditBox_In1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_In1.Name = "itemEditBox_In1";
            this.itemEditBox_In1.Size = new System.Drawing.Size(273, 30);
            this.itemEditBox_In1.TabIndex = 0;
            this.itemEditBox_In1.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(82, 200);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 6;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // checkBox_In1Inverse
            // 
            this.checkBox_In1Inverse.AutoSize = true;
            this.checkBox_In1Inverse.Location = new System.Drawing.Point(74, 39);
            this.checkBox_In1Inverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_In1Inverse.Name = "checkBox_In1Inverse";
            this.checkBox_In1Inverse.Size = new System.Drawing.Size(76, 21);
            this.checkBox_In1Inverse.TabIndex = 1;
            this.checkBox_In1Inverse.Text = "Inverse";
            this.checkBox_In1Inverse.UseVisualStyleBackColor = true;
            // 
            // checkBox_In2Inverse
            // 
            this.checkBox_In2Inverse.AutoSize = true;
            this.checkBox_In2Inverse.Location = new System.Drawing.Point(74, 104);
            this.checkBox_In2Inverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_In2Inverse.Name = "checkBox_In2Inverse";
            this.checkBox_In2Inverse.Size = new System.Drawing.Size(76, 21);
            this.checkBox_In2Inverse.TabIndex = 3;
            this.checkBox_In2Inverse.Text = "Inverse";
            this.checkBox_In2Inverse.UseVisualStyleBackColor = true;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 239);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_In2Inverse);
            this.Controls.Add(this.checkBox_In1Inverse);
            this.Controls.Add(this.itemEditBox_Value);
            this.Controls.Add(this.itemEditBox_In2);
            this.Controls.Add(this.itemEditBox_In1);
            this.Controls.Add(this.comboBox_Operator);
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.label_Operator);
            this.Controls.Add(this.label_In2);
            this.Controls.Add(this.label_In1);
            this.Controls.Add(this.label_Value);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Binary.Logic";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_In2;
        private System.Windows.Forms.Label label_In1;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Operator;
        private System.Windows.Forms.ComboBox comboBox_Operator;
        private Utils.SpecialControls.ItemEditBox itemEditBox_In1;
        private Utils.SpecialControls.ItemEditBox itemEditBox_In2;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Value;
        private System.Windows.Forms.CheckBox checkBox_In1Inverse;
        private System.Windows.Forms.CheckBox checkBox_In2Inverse;
    }
}