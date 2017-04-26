// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Robot.Conveyor.Panel.ConveyorState
{
    partial class ConveyorStatePanel
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
            this.timer_Animation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_State
            // 
            this.pictureBox_State.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_State.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_State.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_State.Name = "pictureBox_State";
            this.pictureBox_State.Size = new System.Drawing.Size(240, 36);
            this.pictureBox_State.TabIndex = 2;
            this.pictureBox_State.TabStop = false;
            this.pictureBox_State.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_State_MouseClick);
            // 
            // timer_Animation
            // 
            this.timer_Animation.Tick += new System.EventHandler(this.timer_Animation_Tick);
            // 
            // ConveyorStatePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox_State);
            this.Name = "ConveyorStatePanel";
            this.Size = new System.Drawing.Size(240, 36);
            this.SizeChanged += new System.EventHandler(this.ConveyorPanel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_State)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_State;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timer_Animation;
    }
}
