// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.StringEditBox
{
    partial class StringEditBoxPanel
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
            this.textBox_Value = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox_Value
            // 
            this.textBox_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Value.Location = new System.Drawing.Point(1, 1);
            this.textBox_Value.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Value.Name = "textBox_Value";
            this.textBox_Value.Size = new System.Drawing.Size(170, 22);
            this.textBox_Value.TabIndex = 0;
            this.textBox_Value.WordWrap = false;
            this.textBox_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Value_KeyPress);
            this.textBox_Value.Leave += new System.EventHandler(this.textBox_Value_Leave);
            // 
            // StringEditBoxPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_Value);
            this.Name = "StringEditBoxPanel";
            this.Size = new System.Drawing.Size(173, 24);
            this.Resize += new System.EventHandler(this.StringEditBoxPanel_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Value;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
