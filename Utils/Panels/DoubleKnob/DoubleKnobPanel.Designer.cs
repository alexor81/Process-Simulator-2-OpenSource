// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleKnob
{
    partial class DoubleKnobPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoubleKnobPanel));
            this.lbKnob = new LBSoft.IndustrialCtrls.Knobs.LBKnob();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lbKnob
            // 
            this.lbKnob.BackColor = System.Drawing.Color.Transparent;
            this.lbKnob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbKnob.DrawRatio = 0.495F;
            this.lbKnob.IndicatorColor = System.Drawing.Color.Red;
            this.lbKnob.IndicatorOffset = 15F;
            this.lbKnob.KnobCenter = ((System.Drawing.PointF)(resources.GetObject("lbKnob.KnobCenter")));
            this.lbKnob.KnobColor = System.Drawing.Color.Silver;
            this.lbKnob.KnobRect = ((System.Drawing.RectangleF)(resources.GetObject("lbKnob.KnobRect")));
            this.lbKnob.Location = new System.Drawing.Point(0, 0);
            this.lbKnob.MaxValue = 1F;
            this.lbKnob.MinValue = 0F;
            this.lbKnob.Name = "lbKnob";
            this.lbKnob.ReadOnly = false;
            this.lbKnob.Renderer = null;
            this.lbKnob.ScaleColor = System.Drawing.Color.WhiteSmoke;
            this.lbKnob.Size = new System.Drawing.Size(102, 99);
            this.lbKnob.StepValue = 0.1F;
            this.lbKnob.Style = LBSoft.IndustrialCtrls.Knobs.LBKnob.KnobStyle.Circular;
            this.lbKnob.TabIndex = 0;
            this.lbKnob.Thresholds = new float[0];
            this.lbKnob.Value = 0F;
            this.lbKnob.KnobChangeValue += new LBSoft.IndustrialCtrls.Knobs.KnobChangeValue(this.lbKnob_KnobChangeValue);
            // 
            // DoubleKnobPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lbKnob);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DoubleKnobPanel";
            this.Size = new System.Drawing.Size(102, 99);
            this.ResumeLayout(false);

        }

        #endregion

        private LBSoft.IndustrialCtrls.Knobs.LBKnob lbKnob;
        private System.Windows.Forms.ToolTip toolTip;

    }
}
