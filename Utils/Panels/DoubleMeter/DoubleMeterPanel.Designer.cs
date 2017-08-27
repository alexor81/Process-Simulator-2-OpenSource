// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleMeter
{
    partial class DoubleMeterPanel
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
            this.lbAnalogMeter = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lbAnalogMeter
            // 
            this.lbAnalogMeter.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter.BodyColor = System.Drawing.Color.DodgerBlue;
            this.lbAnalogMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAnalogMeter.Location = new System.Drawing.Point(0, 0);
            this.lbAnalogMeter.MaxValue = 100D;
            this.lbAnalogMeter.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter.MinValue = -100D;
            this.lbAnalogMeter.Name = "lbAnalogMeter";
            this.lbAnalogMeter.NeedleColor = System.Drawing.Color.Yellow;
            this.lbAnalogMeter.Renderer = null;
            this.lbAnalogMeter.ScaleColor = System.Drawing.Color.White;
            this.lbAnalogMeter.ScaleDivisions = 10;
            this.lbAnalogMeter.ScaleSubDivisions = 10;
            this.lbAnalogMeter.Size = new System.Drawing.Size(173, 176);
            this.lbAnalogMeter.TabIndex = 0;
            this.lbAnalogMeter.Value = 0D;
            this.lbAnalogMeter.ViewGlass = false;
            // 
            // DoubleMeterPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lbAnalogMeter);
            this.Name = "DoubleMeterPanel";
            this.Size = new System.Drawing.Size(173, 176);
            this.ResumeLayout(false);

        }

        #endregion

        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
