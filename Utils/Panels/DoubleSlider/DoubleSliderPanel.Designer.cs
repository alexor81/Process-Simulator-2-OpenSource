// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.DoubleSlider
{
    partial class DoubleSliderPanel
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
            this.sliderControl = new Utils.SpecialControls.SliderControl();
            ((System.ComponentModel.ISupportInitialize)(this.sliderControl)).BeginInit();
            this.SuspendLayout();
            // 
            // sliderControl
            // 
            this.sliderControl.AutoSize = false;
            this.sliderControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliderControl.Location = new System.Drawing.Point(0, 0);
            this.sliderControl.Maximum = 27648;
            this.sliderControl.Name = "sliderControl";
            this.sliderControl.NeedleColor = System.Drawing.Color.CornflowerBlue;
            this.sliderControl.Size = new System.Drawing.Size(225, 33);
            this.sliderControl.TabIndex = 0;
            this.sliderControl.Thresholds = new int[0];
            this.sliderControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderControl.ValueChanged += new System.EventHandler(this.sliderControl_ValueChanged);
            // 
            // DoubleSliderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.Controls.Add(this.sliderControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DoubleSliderPanel";
            this.Size = new System.Drawing.Size(225, 33);
            this.Resize += new System.EventHandler(this.DoubleSliderPanel_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.sliderControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private SpecialControls.SliderControl sliderControl;

    }
}
