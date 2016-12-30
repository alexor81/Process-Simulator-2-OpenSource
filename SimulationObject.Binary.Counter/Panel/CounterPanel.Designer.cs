// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Binary.Counter.Panel
{
    partial class CounterPanel
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.comboBox_N = new System.Windows.Forms.ComboBox();
            this.comboBox_P = new System.Windows.Forms.ComboBox();
            this.label_N = new System.Windows.Forms.Label();
            this.label_P = new System.Windows.Forms.Label();
            this.comboBox_Front = new System.Windows.Forms.ComboBox();
            this.label_Input = new System.Windows.Forms.Label();
            this.button_Reset = new System.Windows.Forms.Button();
            this.label_Output = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.label_Output);
            this.panel.Controls.Add(this.button_Reset);
            this.panel.Controls.Add(this.label_Input);
            this.panel.Controls.Add(this.comboBox_N);
            this.panel.Controls.Add(this.comboBox_P);
            this.panel.Controls.Add(this.label_N);
            this.panel.Controls.Add(this.label_P);
            this.panel.Controls.Add(this.comboBox_Front);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(193, 140);
            this.panel.TabIndex = 0;
            // 
            // comboBox_N
            // 
            this.comboBox_N.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_N.FormattingEnabled = true;
            this.comboBox_N.Items.AddRange(new object[] {
            "+1",
            "-1"});
            this.comboBox_N.Location = new System.Drawing.Point(134, 70);
            this.comboBox_N.Name = "comboBox_N";
            this.comboBox_N.Size = new System.Drawing.Size(49, 24);
            this.comboBox_N.TabIndex = 2;
            this.comboBox_N.SelectedIndexChanged += new System.EventHandler(this.comboBox_N_SelectedIndexChanged);
            // 
            // comboBox_P
            // 
            this.comboBox_P.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_P.FormattingEnabled = true;
            this.comboBox_P.Items.AddRange(new object[] {
            "+1",
            "-1"});
            this.comboBox_P.Location = new System.Drawing.Point(42, 69);
            this.comboBox_P.Name = "comboBox_P";
            this.comboBox_P.Size = new System.Drawing.Size(49, 24);
            this.comboBox_P.TabIndex = 1;
            this.comboBox_P.SelectedIndexChanged += new System.EventHandler(this.comboBox_P_SelectedIndexChanged);
            // 
            // label_N
            // 
            this.label_N.Image = global::SimulationObject.Binary.Counter.Properties.Resources.FN;
            this.label_N.Location = new System.Drawing.Point(100, 74);
            this.label_N.Name = "label_N";
            this.label_N.Size = new System.Drawing.Size(28, 17);
            this.label_N.TabIndex = 43;
            // 
            // label_P
            // 
            this.label_P.Image = global::SimulationObject.Binary.Counter.Properties.Resources.FP;
            this.label_P.Location = new System.Drawing.Point(7, 73);
            this.label_P.Name = "label_P";
            this.label_P.Size = new System.Drawing.Size(28, 17);
            this.label_P.TabIndex = 42;
            // 
            // comboBox_Front
            // 
            this.comboBox_Front.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Front.FormattingEnabled = true;
            this.comboBox_Front.Location = new System.Drawing.Point(10, 40);
            this.comboBox_Front.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_Front.Name = "comboBox_Front";
            this.comboBox_Front.Size = new System.Drawing.Size(173, 24);
            this.comboBox_Front.TabIndex = 0;
            this.comboBox_Front.SelectedIndexChanged += new System.EventHandler(this.comboBox_Front_SelectedIndexChanged);
            // 
            // label_Input
            // 
            this.label_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Input.Location = new System.Drawing.Point(10, 10);
            this.label_Input.Name = "label_Input";
            this.label_Input.Size = new System.Drawing.Size(173, 23);
            this.label_Input.TabIndex = 44;
            this.label_Input.Text = "Input";
            this.label_Input.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(10, 99);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(58, 31);
            this.button_Reset.TabIndex = 3;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // label_Output
            // 
            this.label_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Output.Location = new System.Drawing.Point(74, 103);
            this.label_Output.Name = "label_Output";
            this.label_Output.Size = new System.Drawing.Size(109, 23);
            this.label_Output.TabIndex = 46;
            this.label_Output.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CounterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "CounterPanel";
            this.Size = new System.Drawing.Size(193, 140);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox comboBox_N;
        private System.Windows.Forms.ComboBox comboBox_P;
        private System.Windows.Forms.Label label_N;
        private System.Windows.Forms.Label label_P;
        private System.Windows.Forms.ComboBox comboBox_Front;
        private System.Windows.Forms.Label label_Input;
        private System.Windows.Forms.Label label_Output;
        private System.Windows.Forms.Button button_Reset;
    }
}
