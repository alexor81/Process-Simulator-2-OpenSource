// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Robot.Conveyor.Panel.ConveyorControl
{
    partial class ConveyorControlPanel
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
            this.label_StopCMD = new System.Windows.Forms.Label();
            this.label_StartCMD = new System.Windows.Forms.Label();
            this.label_Control = new System.Windows.Forms.Label();
            this.label_SpeedCMD = new System.Windows.Forms.Label();
            this.checkBox_Reverse = new System.Windows.Forms.CheckBox();
            this.checkBox_Alarm = new System.Windows.Forms.CheckBox();
            this.button_Moving = new System.Windows.Forms.Button();
            this.trackBar_Position = new System.Windows.Forms.TrackBar();
            this.label_Speed = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Position)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.label_Speed);
            this.panel.Controls.Add(this.trackBar_Position);
            this.panel.Controls.Add(this.button_Moving);
            this.panel.Controls.Add(this.checkBox_Alarm);
            this.panel.Controls.Add(this.checkBox_Reverse);
            this.panel.Controls.Add(this.label_SpeedCMD);
            this.panel.Controls.Add(this.label_StopCMD);
            this.panel.Controls.Add(this.label_StartCMD);
            this.panel.Controls.Add(this.label_Control);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(250, 127);
            this.panel.TabIndex = 0;
            // 
            // label_StopCMD
            // 
            this.label_StopCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_StopCMD.Location = new System.Drawing.Point(117, 2);
            this.label_StopCMD.Name = "label_StopCMD";
            this.label_StopCMD.Size = new System.Drawing.Size(50, 19);
            this.label_StopCMD.TabIndex = 16;
            this.label_StopCMD.Text = "Stop";
            this.label_StopCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_StartCMD
            // 
            this.label_StartCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_StartCMD.Location = new System.Drawing.Point(64, 2);
            this.label_StartCMD.Name = "label_StartCMD";
            this.label_StartCMD.Size = new System.Drawing.Size(50, 19);
            this.label_StartCMD.TabIndex = 15;
            this.label_StartCMD.Text = "Start";
            this.label_StartCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Control
            // 
            this.label_Control.AutoSize = true;
            this.label_Control.Location = new System.Drawing.Point(3, 3);
            this.label_Control.Name = "label_Control";
            this.label_Control.Size = new System.Drawing.Size(57, 17);
            this.label_Control.TabIndex = 17;
            this.label_Control.Text = "Control:";
            // 
            // label_SpeedCMD
            // 
            this.label_SpeedCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_SpeedCMD.Location = new System.Drawing.Point(170, 2);
            this.label_SpeedCMD.Name = "label_SpeedCMD";
            this.label_SpeedCMD.Size = new System.Drawing.Size(75, 19);
            this.label_SpeedCMD.TabIndex = 18;
            this.label_SpeedCMD.Text = "0 %";
            this.label_SpeedCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_Reverse
            // 
            this.checkBox_Reverse.AutoSize = true;
            this.checkBox_Reverse.Location = new System.Drawing.Point(6, 102);
            this.checkBox_Reverse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Reverse.Name = "checkBox_Reverse";
            this.checkBox_Reverse.Size = new System.Drawing.Size(83, 21);
            this.checkBox_Reverse.TabIndex = 3;
            this.checkBox_Reverse.Text = "Reverse";
            this.checkBox_Reverse.UseVisualStyleBackColor = true;
            this.checkBox_Reverse.CheckedChanged += new System.EventHandler(this.checkBox_Reverse_CheckedChanged);
            // 
            // checkBox_Alarm
            // 
            this.checkBox_Alarm.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Alarm.AutoSize = true;
            this.checkBox_Alarm.Location = new System.Drawing.Point(191, 96);
            this.checkBox_Alarm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Alarm.Name = "checkBox_Alarm";
            this.checkBox_Alarm.Size = new System.Drawing.Size(54, 27);
            this.checkBox_Alarm.TabIndex = 4;
            this.checkBox_Alarm.Text = "Alarm";
            this.checkBox_Alarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_Alarm.UseVisualStyleBackColor = true;
            this.checkBox_Alarm.CheckedChanged += new System.EventHandler(this.checkBox_Alarm_CheckedChanged);
            // 
            // button_Moving
            // 
            this.button_Moving.Location = new System.Drawing.Point(6, 27);
            this.button_Moving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Moving.Name = "button_Moving";
            this.button_Moving.Size = new System.Drawing.Size(83, 70);
            this.button_Moving.TabIndex = 0;
            this.button_Moving.Text = "Moving";
            this.button_Moving.UseVisualStyleBackColor = true;
            this.button_Moving.Click += new System.EventHandler(this.button_Moving_Click);
            // 
            // trackBar_Position
            // 
            this.trackBar_Position.AutoSize = false;
            this.trackBar_Position.Location = new System.Drawing.Point(92, 52);
            this.trackBar_Position.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar_Position.Maximum = 100;
            this.trackBar_Position.Name = "trackBar_Position";
            this.trackBar_Position.Size = new System.Drawing.Size(153, 40);
            this.trackBar_Position.TabIndex = 2;
            this.trackBar_Position.TickFrequency = 10;
            this.trackBar_Position.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar_Position.Scroll += new System.EventHandler(this.trackBar_Position_Scroll);
            // 
            // label_Speed
            // 
            this.label_Speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Speed.ForeColor = System.Drawing.Color.Blue;
            this.label_Speed.Location = new System.Drawing.Point(115, 29);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(107, 16);
            this.label_Speed.TabIndex = 19;
            this.label_Speed.Text = "0 %";
            this.label_Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConveyorControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "ConveyorControlPanel";
            this.Size = new System.Drawing.Size(250, 127);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Position)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label_StopCMD;
        private System.Windows.Forms.Label label_StartCMD;
        private System.Windows.Forms.Label label_Control;
        private System.Windows.Forms.Label label_SpeedCMD;
        private System.Windows.Forms.CheckBox checkBox_Reverse;
        private System.Windows.Forms.CheckBox checkBox_Alarm;
        private System.Windows.Forms.Button button_Moving;
        private System.Windows.Forms.TrackBar trackBar_Position;
        private System.Windows.Forms.Label label_Speed;
    }
}
