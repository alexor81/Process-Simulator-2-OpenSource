// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.ObjectTextLabel
{
    partial class ObjectTextLabelPanel
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
            this.label_Value = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label_Value
            // 
            this.label_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Value.Location = new System.Drawing.Point(0, 0);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(123, 25);
            this.label_Value.TabIndex = 0;
            // 
            // ObjectTextLabelPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Value);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ObjectTextLabelPanel";
            this.Size = new System.Drawing.Size(123, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
