namespace SimulationObject.Binary.Logic.Panel
{
    partial class LogicPanel
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
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.checkBox_In2Inverse = new System.Windows.Forms.CheckBox();
            this.checkBox_In1Inverse = new System.Windows.Forms.CheckBox();
            this.label_Output = new System.Windows.Forms.Label();
            this.label_In2 = new System.Windows.Forms.Label();
            this.label_In1 = new System.Windows.Forms.Label();
            this.comboBox_Operator = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.checkBox_In2Inverse);
            this.panel.Controls.Add(this.checkBox_In1Inverse);
            this.panel.Controls.Add(this.label_Output);
            this.panel.Controls.Add(this.label_In2);
            this.panel.Controls.Add(this.label_In1);
            this.panel.Controls.Add(this.comboBox_Operator);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(176, 114);
            this.panel.TabIndex = 6;
            // 
            // checkBox_In2Inverse
            // 
            this.checkBox_In2Inverse.AutoSize = true;
            this.checkBox_In2Inverse.Location = new System.Drawing.Point(92, 29);
            this.checkBox_In2Inverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_In2Inverse.Name = "checkBox_In2Inverse";
            this.checkBox_In2Inverse.Size = new System.Drawing.Size(76, 21);
            this.checkBox_In2Inverse.TabIndex = 1;
            this.checkBox_In2Inverse.Text = "Inverse";
            this.checkBox_In2Inverse.UseVisualStyleBackColor = true;
            this.checkBox_In2Inverse.CheckedChanged += new System.EventHandler(this.checkBox_In2Inverse_CheckedChanged);
            // 
            // checkBox_In1Inverse
            // 
            this.checkBox_In1Inverse.AutoSize = true;
            this.checkBox_In1Inverse.Location = new System.Drawing.Point(7, 29);
            this.checkBox_In1Inverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_In1Inverse.Name = "checkBox_In1Inverse";
            this.checkBox_In1Inverse.Size = new System.Drawing.Size(76, 21);
            this.checkBox_In1Inverse.TabIndex = 0;
            this.checkBox_In1Inverse.Text = "Inverse";
            this.checkBox_In1Inverse.UseVisualStyleBackColor = true;
            this.checkBox_In1Inverse.CheckedChanged += new System.EventHandler(this.checkBox_In1Inverse_CheckedChanged);
            // 
            // label_Output
            // 
            this.label_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Output.Location = new System.Drawing.Point(7, 84);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(161, 23);
            this.label_Output.TabIndex = 38;
            this.label_Output.Text = "Output";
            this.label_Output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_In2
            // 
            this.label_In2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_In2.Location = new System.Drawing.Point(92, 2);
            this.label_In2.Name = "label_In2";
            this.label_In2.Size = new System.Drawing.Size(76, 22);
            this.label_In2.TabIndex = 37;
            this.label_In2.Text = "Input 2";
            this.label_In2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_In1
            // 
            this.label_In1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_In1.Location = new System.Drawing.Point(7, 2);
            this.label_In1.Name = "label_In1";
            this.label_In1.Size = new System.Drawing.Size(76, 22);
            this.label_In1.TabIndex = 36;
            this.label_In1.Text = "Input 1";
            this.label_In1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_Operator
            // 
            this.comboBox_Operator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Operator.Location = new System.Drawing.Point(7, 55);
            this.comboBox_Operator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Operator.Name = "comboBox_Operator";
            this.comboBox_Operator.Size = new System.Drawing.Size(161, 24);
            this.comboBox_Operator.TabIndex = 2;
            this.comboBox_Operator.SelectedIndexChanged += new System.EventHandler(this.comboBox_Operator_SelectedIndexChanged);
            // 
            // LogicPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogicPanel";
            this.Size = new System.Drawing.Size(176, 114);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboBox_Operator;
        private System.Windows.Forms.Label label_In2;
        private System.Windows.Forms.Label label_In1;
        private System.Windows.Forms.Label label_Output;
        private System.Windows.Forms.CheckBox checkBox_In2Inverse;
        private System.Windows.Forms.CheckBox checkBox_In1Inverse;
    }
}
