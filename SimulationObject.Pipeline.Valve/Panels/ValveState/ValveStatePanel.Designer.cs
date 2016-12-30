// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Pipeline.Valve.Panels.ValveState
{
    partial class ValveStatePanel
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
            this.pictureBox_State = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_State
            // 
            this.pictureBox_State.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_State.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_State.Name = "pictureBox_State";
            this.pictureBox_State.Size = new System.Drawing.Size(43, 34);
            this.pictureBox_State.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_State.TabIndex = 1;
            this.pictureBox_State.TabStop = false;
            this.pictureBox_State.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_State_MouseClick);
            // 
            // ValveStatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox_State);
            this.Name = "ValveStatePanel";
            this.Size = new System.Drawing.Size(43, 34);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_State;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
