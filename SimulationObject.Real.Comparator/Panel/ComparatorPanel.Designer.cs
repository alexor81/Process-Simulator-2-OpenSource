namespace SimulationObject.Real.Comparator.Panel
{
    partial class ComparatorPanel
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
            this.label_Output = new System.Windows.Forms.Label();
            this.panel_div = new System.Windows.Forms.Panel();
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
            this.panel.Controls.Add(this.label_Output);
            this.panel.Controls.Add(this.panel_div);
            this.panel.Controls.Add(this.label_Input2);
            this.panel.Controls.Add(this.label_Input1);
            this.panel.Controls.Add(this.comboBox_Operation);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(138, 94);
            this.panel.TabIndex = 0;
            // 
            // label_Output
            // 
            this.label_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Output.Location = new System.Drawing.Point(23, 70);
            this.label_Output.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(91, 19);
            this.label_Output.TabIndex = 45;
            this.label_Output.Text = "Output";
            this.label_Output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_div
            // 
            this.panel_div.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_div.Location = new System.Drawing.Point(5, 64);
            this.panel_div.Margin = new System.Windows.Forms.Padding(2);
            this.panel_div.Name = "panel_div";
            this.panel_div.Size = new System.Drawing.Size(127, 4);
            this.panel_div.TabIndex = 44;
            // 
            // label_Input2
            // 
            this.label_Input2.BackColor = System.Drawing.SystemColors.Control;
            this.label_Input2.Location = new System.Drawing.Point(4, 46);
            this.label_Input2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Input2.Name = "label_Input2";
            this.label_Input2.Size = new System.Drawing.Size(128, 16);
            this.label_Input2.TabIndex = 41;
            this.label_Input2.Text = "0";
            this.label_Input2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Input1
            // 
            this.label_Input1.BackColor = System.Drawing.SystemColors.Control;
            this.label_Input1.Location = new System.Drawing.Point(4, 26);
            this.label_Input1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Input1.Name = "label_Input1";
            this.label_Input1.Size = new System.Drawing.Size(128, 16);
            this.label_Input1.TabIndex = 40;
            this.label_Input1.Text = "0";
            this.label_Input1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_Operation
            // 
            this.comboBox_Operation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operation.Location = new System.Drawing.Point(3, 3);
            this.comboBox_Operation.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Operation.Name = "comboBox_Operation";
            this.comboBox_Operation.Size = new System.Drawing.Size(131, 21);
            this.comboBox_Operation.TabIndex = 0;
            this.comboBox_Operation.SelectedIndexChanged += new System.EventHandler(this.comboBox_Operation_SelectedIndexChanged);
            // 
            // ComparatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "ComparatorPanel";
            this.Size = new System.Drawing.Size(138, 94);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label_Input2;
        private System.Windows.Forms.Label label_Input1;
        private System.Windows.Forms.ComboBox comboBox_Operation;
        private System.Windows.Forms.Panel panel_div;
        private System.Windows.Forms.Label label_Output;
    }
}
