// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Item.WriteToFile.Panel
{
    partial class WriteToFilePanel
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
            this.checkBox_Record = new System.Windows.Forms.CheckBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.checkBox_Record);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(37, 36);
            this.panel.TabIndex = 0;
            // 
            // checkBox_Record
            // 
            this.checkBox_Record.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Record.Image = global::SimulationObject.Item.WriteToFile.Properties.Resources.Record;
            this.checkBox_Record.Location = new System.Drawing.Point(4, 5);
            this.checkBox_Record.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Record.Name = "checkBox_Record";
            this.checkBox_Record.Size = new System.Drawing.Size(29, 27);
            this.checkBox_Record.TabIndex = 3;
            this.checkBox_Record.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_Record.UseVisualStyleBackColor = true;
            this.checkBox_Record.CheckedChanged += new System.EventHandler(this.checkBox_Record_CheckedChanged);
            // 
            // WriteToFilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "WriteToFilePanel";
            this.Size = new System.Drawing.Size(37, 36);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.CheckBox checkBox_Record;
    }
}
