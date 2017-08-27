// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanSymbol
{
    partial class BooleanSymbolPanel
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
            this.pictureBox_State = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_State
            // 
            this.pictureBox_State.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_State.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_State.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_State.Name = "pictureBox_State";
            this.pictureBox_State.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_State.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_State.TabIndex = 1;
            this.pictureBox_State.TabStop = false;
            // 
            // BooleanSymbolPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox_State);
            this.Name = "BooleanSymbolPanel";
            this.Size = new System.Drawing.Size(50, 50);
            this.SizeChanged += new System.EventHandler(this.BooleanSymbolPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox pictureBox_State;
    }
}
