// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleIndicator
{
    partial class DoubleIndicatorPanel
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
            this.label_Units = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label_Value
            // 
            this.label_Value.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label_Value.Location = new System.Drawing.Point(1, 1);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(171, 20);
            this.label_Value.TabIndex = 0;
            this.label_Value.Text = "0";
            this.label_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Units
            // 
            this.label_Units.AutoSize = true;
            this.label_Units.Location = new System.Drawing.Point(176, 2);
            this.label_Units.Name = "label_Units";
            this.label_Units.Size = new System.Drawing.Size(0, 17);
            this.label_Units.TabIndex = 1;
            this.label_Units.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoubleIndicatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Units);
            this.Controls.Add(this.label_Value);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DoubleIndicatorPanel";
            this.Size = new System.Drawing.Size(172, 22);
            this.Resize += new System.EventHandler(this.DoubleIndicatorPanel_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.Label label_Units;
        private System.Windows.Forms.ToolTip toolTip;

    }
}
