namespace SimulationObject.Real.Calculator.Panel
{
    partial class CalculatorPanel
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
            this.panel = new System.Windows.Forms.Panel();
            this.panel_div = new System.Windows.Forms.Panel();
            this.label_Value = new System.Windows.Forms.Label();
            this.label_Input2 = new System.Windows.Forms.Label();
            this.label_Input1 = new System.Windows.Forms.Label();
            this.comboBox_Operation = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.panel_div);
            this.panel.Controls.Add(this.label_Value);
            this.panel.Controls.Add(this.label_Input2);
            this.panel.Controls.Add(this.label_Input1);
            this.panel.Controls.Add(this.comboBox_Operation);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(138, 90);
            this.panel.TabIndex = 0;
            // 
            // panel_div
            // 
            this.panel_div.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_div.Location = new System.Drawing.Point(5, 64);
            this.panel_div.Margin = new System.Windows.Forms.Padding(2);
            this.panel_div.Name = "panel_div";
            this.panel_div.Size = new System.Drawing.Size(127, 4);
            this.panel_div.TabIndex = 43;
            // 
            // label_Value
            // 
            this.label_Value.BackColor = System.Drawing.SystemColors.Control;
            this.label_Value.Location = new System.Drawing.Point(4, 69);
            this.label_Value.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(128, 16);
            this.label_Value.TabIndex = 39;
            this.label_Value.Text = "0";
            this.label_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Input2
            // 
            this.label_Input2.BackColor = System.Drawing.SystemColors.Control;
            this.label_Input2.Location = new System.Drawing.Point(4, 45);
            this.label_Input2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Input2.Name = "label_Input2";
            this.label_Input2.Size = new System.Drawing.Size(128, 16);
            this.label_Input2.TabIndex = 38;
            this.label_Input2.Text = "0";
            this.label_Input2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Input1
            // 
            this.label_Input1.BackColor = System.Drawing.SystemColors.Control;
            this.label_Input1.Location = new System.Drawing.Point(4, 25);
            this.label_Input1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Input1.Name = "label_Input1";
            this.label_Input1.Size = new System.Drawing.Size(128, 16);
            this.label_Input1.TabIndex = 37;
            this.label_Input1.Text = "0";
            this.label_Input1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_Operation
            // 
            this.comboBox_Operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operation.Location = new System.Drawing.Point(3, 2);
            this.comboBox_Operation.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Operation.Name = "comboBox_Operation";
            this.comboBox_Operation.Size = new System.Drawing.Size(131, 21);
            this.comboBox_Operation.TabIndex = 0;
            this.comboBox_Operation.SelectedIndexChanged += new System.EventHandler(this.comboBox_Operation_SelectedIndexChanged);
            // 
            // CalculatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CalculatorPanel";
            this.Size = new System.Drawing.Size(138, 90);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox comboBox_Operation;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Input2;
        private System.Windows.Forms.Label label_Input1;
        private System.Windows.Forms.Panel panel_div;
    }
}
