// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Panels.BooleanIndicator
{
    partial class BooleanIndicatorPanel
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lbLed = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lbLed);
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.label);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(75, 27);
            this.splitContainer.SplitterDistance = 30;
            this.splitContainer.SplitterWidth = 1;
            this.splitContainer.TabIndex = 0;
            // 
            // lbLed
            // 
            this.lbLed.BackColor = System.Drawing.Color.Transparent;
            this.lbLed.BlinkInterval = 500;
            this.lbLed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLed.Label = "";
            this.lbLed.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Bottom;
            this.lbLed.LedColor = System.Drawing.Color.Red;
            this.lbLed.LedOffColor = System.Drawing.Color.LightGray;
            this.lbLed.LedSize = new System.Drawing.SizeF(25F, 25F);
            this.lbLed.Location = new System.Drawing.Point(0, 0);
            this.lbLed.Name = "lbLed";
            this.lbLed.Renderer = null;
            this.lbLed.Size = new System.Drawing.Size(30, 27);
            this.lbLed.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed.TabIndex = 0;
            this.lbLed.SizeChanged += new System.EventHandler(this.lbLed_SizeChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(3, 6);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 17);
            this.label.TabIndex = 0;
            this.label.Text = "Text";
            // 
            // BooleanIndicatorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BooleanIndicatorPanel";
            this.Size = new System.Drawing.Size(75, 27);
            this.Resize += new System.EventHandler(this.BooleanIndicatorPanel_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label label;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed;

    }
}
