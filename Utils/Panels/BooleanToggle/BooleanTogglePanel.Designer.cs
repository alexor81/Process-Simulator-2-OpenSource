// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanToggle
{
    partial class BooleanTogglePanel
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
            this.toggleSwitch = new JCS.ToggleSwitch();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // toggleSwitch
            // 
            this.toggleSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toggleSwitch.Location = new System.Drawing.Point(0, 0);
            this.toggleSwitch.Name = "toggleSwitch";
            this.toggleSwitch.OffFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toggleSwitch.OnFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toggleSwitch.Size = new System.Drawing.Size(53, 23);
            this.toggleSwitch.TabIndex = 0;
            this.toggleSwitch.CheckedChanged += new JCS.ToggleSwitch.CheckedChangedDelegate(this.toggleSwitch_CheckedChanged);
            // 
            // BooleanTogglePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toggleSwitch);
            this.Name = "BooleanTogglePanel";
            this.Size = new System.Drawing.Size(53, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private JCS.ToggleSwitch toggleSwitch;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
