// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleSlidingScale
{
    partial class DoubleSlidingScalePanel
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
            this.slidingScale = new TB.Instruments.SlidingScale();
            this.SuspendLayout();
            // 
            // slidingScale
            // 
            this.slidingScale.BackColor = System.Drawing.Color.White;
            this.slidingScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slidingScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slidingScale.ForeColor = System.Drawing.Color.Black;
            this.slidingScale.Location = new System.Drawing.Point(0, 0);
            this.slidingScale.Name = "slidingScale";
            this.slidingScale.NeedleColor = System.Drawing.Color.Red;
            this.slidingScale.ShadowColor = System.Drawing.Color.DimGray;
            this.slidingScale.Size = new System.Drawing.Size(259, 51);
            this.slidingScale.TabIndex = 0;
            // 
            // DoubleSlidingScalePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.slidingScale);
            this.Name = "DoubleSlidingScalePanel";
            this.Size = new System.Drawing.Size(259, 51);
            this.Resize += new System.EventHandler(this.DoubleSlidingScalePanel_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private TB.Instruments.SlidingScale slidingScale;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
