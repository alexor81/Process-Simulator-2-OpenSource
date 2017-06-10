// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Binary.Trigger.Panels
{
    partial class TriggerPanel
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
            this.label_Set = new System.Windows.Forms.Label();
            this.label_Reset = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button_Value = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.comboBox_SR_RS = new System.Windows.Forms.ComboBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Set
            // 
            this.label_Set.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Set.Location = new System.Drawing.Point(2, 2);
            this.label_Set.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Set.Name = "label_Set";
            this.label_Set.Size = new System.Drawing.Size(40, 18);
            this.label_Set.TabIndex = 0;
            this.label_Set.Text = "Set";
            this.label_Set.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Reset
            // 
            this.label_Reset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Reset.Location = new System.Drawing.Point(46, 2);
            this.label_Reset.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Reset.Name = "label_Reset";
            this.label_Reset.Size = new System.Drawing.Size(40, 18);
            this.label_Reset.TabIndex = 1;
            this.label_Reset.Text = "Reset";
            this.label_Reset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Value
            // 
            this.button_Value.Location = new System.Drawing.Point(4, 46);
            this.button_Value.Margin = new System.Windows.Forms.Padding(2);
            this.button_Value.Name = "button_Value";
            this.button_Value.Size = new System.Drawing.Size(82, 20);
            this.button_Value.TabIndex = 1;
            this.button_Value.Text = "Output";
            this.button_Value.UseVisualStyleBackColor = true;
            this.button_Value.Click += new System.EventHandler(this.button_Value_Click);
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.comboBox_SR_RS);
            this.panel.Controls.Add(this.label_Set);
            this.panel.Controls.Add(this.label_Reset);
            this.panel.Controls.Add(this.button_Value);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(90, 70);
            this.panel.TabIndex = 5;
            // 
            // comboBox_SR_RS
            // 
            this.comboBox_SR_RS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SR_RS.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.comboBox_SR_RS.Items.AddRange(new object[] {
            "SR",
            "RS"});
            this.comboBox_SR_RS.Location = new System.Drawing.Point(2, 23);
            this.comboBox_SR_RS.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_SR_RS.Name = "comboBox_SR_RS";
            this.comboBox_SR_RS.Size = new System.Drawing.Size(84, 21);
            this.comboBox_SR_RS.TabIndex = 0;
            this.comboBox_SR_RS.SelectedIndexChanged += new System.EventHandler(this.comboBox_SR_RS_SelectedIndexChanged);
            // 
            // TriggerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TriggerPanel";
            this.Size = new System.Drawing.Size(90, 70);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Set;
        private System.Windows.Forms.Label label_Reset;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button button_Value;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox comboBox_SR_RS;
    }
}
