// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Pipeline.Pump.Panels.PumpControl
{
    partial class PumpControlPanel
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
            this.panel = new System.Windows.Forms.Panel();
            this.button_On = new System.Windows.Forms.Button();
            this.groupBox_Buttons = new System.Windows.Forms.GroupBox();
            this.checkBox_OffBtn = new System.Windows.Forms.CheckBox();
            this.checkBox_OnBtn = new System.Windows.Forms.CheckBox();
            this.checkBox_Alarm = new System.Windows.Forms.CheckBox();
            this.checkBox_Remote = new System.Windows.Forms.CheckBox();
            this.checkBox_Power = new System.Windows.Forms.CheckBox();
            this.label_OffCMD = new System.Windows.Forms.Label();
            this.label_OnCMD = new System.Windows.Forms.Label();
            this.label_EsdCMD = new System.Windows.Forms.Label();
            this.label_Control = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip();
            this.panel.SuspendLayout();
            this.groupBox_Buttons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.button_On);
            this.panel.Controls.Add(this.groupBox_Buttons);
            this.panel.Controls.Add(this.checkBox_Alarm);
            this.panel.Controls.Add(this.checkBox_Remote);
            this.panel.Controls.Add(this.checkBox_Power);
            this.panel.Controls.Add(this.label_OffCMD);
            this.panel.Controls.Add(this.label_OnCMD);
            this.panel.Controls.Add(this.label_EsdCMD);
            this.panel.Controls.Add(this.label_Control);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(169, 113);
            this.panel.TabIndex = 0;
            // 
            // button_On
            // 
            this.button_On.Location = new System.Drawing.Point(73, 26);
            this.button_On.Margin = new System.Windows.Forms.Padding(2);
            this.button_On.Name = "button_On";
            this.button_On.Size = new System.Drawing.Size(90, 60);
            this.button_On.TabIndex = 1;
            this.button_On.Text = "OFF";
            this.button_On.UseVisualStyleBackColor = true;
            this.button_On.Click += new System.EventHandler(this.button_On_Click);
            // 
            // groupBox_Buttons
            // 
            this.groupBox_Buttons.Controls.Add(this.checkBox_OffBtn);
            this.groupBox_Buttons.Controls.Add(this.checkBox_OnBtn);
            this.groupBox_Buttons.Location = new System.Drawing.Point(6, 20);
            this.groupBox_Buttons.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Buttons.Name = "groupBox_Buttons";
            this.groupBox_Buttons.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Buttons.Size = new System.Drawing.Size(61, 67);
            this.groupBox_Buttons.TabIndex = 0;
            this.groupBox_Buttons.TabStop = false;
            this.groupBox_Buttons.Text = "Buttons";
            // 
            // checkBox_OffBtn
            // 
            this.checkBox_OffBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_OffBtn.Location = new System.Drawing.Point(11, 40);
            this.checkBox_OffBtn.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_OffBtn.Name = "checkBox_OffBtn";
            this.checkBox_OffBtn.Size = new System.Drawing.Size(39, 22);
            this.checkBox_OffBtn.TabIndex = 1;
            this.checkBox_OffBtn.Text = "Off";
            this.checkBox_OffBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_OffBtn.UseVisualStyleBackColor = true;
            this.checkBox_OffBtn.CheckedChanged += new System.EventHandler(this.checkBox_OffBtn_CheckedChanged);
            // 
            // checkBox_OnBtn
            // 
            this.checkBox_OnBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_OnBtn.Location = new System.Drawing.Point(11, 16);
            this.checkBox_OnBtn.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_OnBtn.Name = "checkBox_OnBtn";
            this.checkBox_OnBtn.Size = new System.Drawing.Size(39, 22);
            this.checkBox_OnBtn.TabIndex = 0;
            this.checkBox_OnBtn.Text = "On";
            this.checkBox_OnBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_OnBtn.UseVisualStyleBackColor = true;
            this.checkBox_OnBtn.CheckedChanged += new System.EventHandler(this.checkBox_OnBtn_CheckedChanged);
            // 
            // checkBox_Alarm
            // 
            this.checkBox_Alarm.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_Alarm.Location = new System.Drawing.Point(120, 88);
            this.checkBox_Alarm.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_Alarm.Name = "checkBox_Alarm";
            this.checkBox_Alarm.Size = new System.Drawing.Size(44, 22);
            this.checkBox_Alarm.TabIndex = 4;
            this.checkBox_Alarm.Text = "Alarm";
            this.checkBox_Alarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_Alarm.UseVisualStyleBackColor = true;
            this.checkBox_Alarm.CheckedChanged += new System.EventHandler(this.checkBox_Alarm_CheckedChanged);
            // 
            // checkBox_Remote
            // 
            this.checkBox_Remote.AutoSize = true;
            this.checkBox_Remote.Location = new System.Drawing.Point(5, 91);
            this.checkBox_Remote.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_Remote.Name = "checkBox_Remote";
            this.checkBox_Remote.Size = new System.Drawing.Size(63, 17);
            this.checkBox_Remote.TabIndex = 2;
            this.checkBox_Remote.Text = "Remote";
            this.checkBox_Remote.UseVisualStyleBackColor = true;
            this.checkBox_Remote.CheckedChanged += new System.EventHandler(this.checkBox_Remote_CheckedChanged);
            // 
            // checkBox_Power
            // 
            this.checkBox_Power.AutoSize = true;
            this.checkBox_Power.Location = new System.Drawing.Point(73, 91);
            this.checkBox_Power.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_Power.Name = "checkBox_Power";
            this.checkBox_Power.Size = new System.Drawing.Size(44, 17);
            this.checkBox_Power.TabIndex = 3;
            this.checkBox_Power.Text = "PW";
            this.checkBox_Power.UseVisualStyleBackColor = true;
            this.checkBox_Power.CheckedChanged += new System.EventHandler(this.checkBox_Power_CheckedChanged);
            // 
            // label_OffCMD
            // 
            this.label_OffCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_OffCMD.Location = new System.Drawing.Point(93, 3);
            this.label_OffCMD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_OffCMD.Name = "label_OffCMD";
            this.label_OffCMD.Size = new System.Drawing.Size(34, 16);
            this.label_OffCMD.TabIndex = 18;
            this.label_OffCMD.Text = "Off";
            this.label_OffCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_OnCMD
            // 
            this.label_OnCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_OnCMD.Location = new System.Drawing.Point(57, 3);
            this.label_OnCMD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_OnCMD.Name = "label_OnCMD";
            this.label_OnCMD.Size = new System.Drawing.Size(34, 16);
            this.label_OnCMD.TabIndex = 17;
            this.label_OnCMD.Text = "On";
            this.label_OnCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_EsdCMD
            // 
            this.label_EsdCMD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_EsdCMD.Location = new System.Drawing.Point(129, 3);
            this.label_EsdCMD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_EsdCMD.Name = "label_EsdCMD";
            this.label_EsdCMD.Size = new System.Drawing.Size(34, 16);
            this.label_EsdCMD.TabIndex = 15;
            this.label_EsdCMD.Text = "ESD";
            this.label_EsdCMD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Control
            // 
            this.label_Control.AutoSize = true;
            this.label_Control.Location = new System.Drawing.Point(9, 5);
            this.label_Control.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Control.Name = "label_Control";
            this.label_Control.Size = new System.Drawing.Size(43, 13);
            this.label_Control.TabIndex = 16;
            this.label_Control.Text = "Control:";
            // 
            // PumpControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PumpControlPanel";
            this.Size = new System.Drawing.Size(169, 113);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.groupBox_Buttons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label_EsdCMD;
        private System.Windows.Forms.Label label_Control;
        private System.Windows.Forms.Label label_OffCMD;
        private System.Windows.Forms.Label label_OnCMD;
        private System.Windows.Forms.CheckBox checkBox_Remote;
        private System.Windows.Forms.CheckBox checkBox_Power;
        private System.Windows.Forms.CheckBox checkBox_Alarm;
        private System.Windows.Forms.GroupBox groupBox_Buttons;
        private System.Windows.Forms.CheckBox checkBox_OffBtn;
        private System.Windows.Forms.CheckBox checkBox_OnBtn;
        private System.Windows.Forms.Button button_On;
    }
}
