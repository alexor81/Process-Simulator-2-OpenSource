// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Real.OneOfTwo.Panels
{
    partial class OneOfTwoPanel
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
            this.spinEdit_In2ToIn1 = new DevExpress.XtraEditors.SpinEdit();
            this.spinEdit_In1ToIn2 = new DevExpress.XtraEditors.SpinEdit();
            this.label_Value = new System.Windows.Forms.Label();
            this.button_Switch = new System.Windows.Forms.Button();
            this.label_Input2 = new System.Windows.Forms.Label();
            this.label_Input1 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In2ToIn1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In1ToIn2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.spinEdit_In2ToIn1);
            this.panel.Controls.Add(this.spinEdit_In1ToIn2);
            this.panel.Controls.Add(this.label_Value);
            this.panel.Controls.Add(this.button_Switch);
            this.panel.Controls.Add(this.label_Input2);
            this.panel.Controls.Add(this.label_Input1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(263, 95);
            this.panel.TabIndex = 0;
            // 
            // spinEdit_In2ToIn1
            // 
            this.spinEdit_In2ToIn1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_In2ToIn1.Location = new System.Drawing.Point(5, 36);
            this.spinEdit_In2ToIn1.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_In2ToIn1.Name = "spinEdit_In2ToIn1";
            this.spinEdit_In2ToIn1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_In2ToIn1.Properties.IsFloatValue = false;
            this.spinEdit_In2ToIn1.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_In2ToIn1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_In2ToIn1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_In2ToIn1.Properties.Mask.EditMask = "N00";
            this.spinEdit_In2ToIn1.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_In2ToIn1.Size = new System.Drawing.Size(75, 24);
            this.spinEdit_In2ToIn1.TabIndex = 46;
            this.spinEdit_In2ToIn1.EditValueChanged += new System.EventHandler(this.spinEdit_In2ToIn1_EditValueChanged);
            // 
            // spinEdit_In1ToIn2
            // 
            this.spinEdit_In1ToIn2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit_In1ToIn2.Location = new System.Drawing.Point(5, 66);
            this.spinEdit_In1ToIn2.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_In1ToIn2.Name = "spinEdit_In1ToIn2";
            this.spinEdit_In1ToIn2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_In1ToIn2.Properties.IsFloatValue = false;
            this.spinEdit_In1ToIn2.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_In1ToIn2.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_In1ToIn2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_In1ToIn2.Properties.Mask.EditMask = "N00";
            this.spinEdit_In1ToIn2.Properties.MaxValue = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.spinEdit_In1ToIn2.Size = new System.Drawing.Size(75, 24);
            this.spinEdit_In1ToIn2.TabIndex = 45;
            this.spinEdit_In1ToIn2.EditValueChanged += new System.EventHandler(this.spinEdit_In1ToIn2_EditValueChanged);
            // 
            // label_Value
            // 
            this.label_Value.BackColor = System.Drawing.SystemColors.Control;
            this.label_Value.Location = new System.Drawing.Point(85, 8);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(171, 20);
            this.label_Value.TabIndex = 44;
            this.label_Value.Text = "0";
            this.label_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Switch
            // 
            this.button_Switch.Location = new System.Drawing.Point(5, 3);
            this.button_Switch.Name = "button_Switch";
            this.button_Switch.Size = new System.Drawing.Size(74, 30);
            this.button_Switch.TabIndex = 43;
            this.button_Switch.Text = "Input 1";
            this.button_Switch.UseVisualStyleBackColor = true;
            this.button_Switch.Click += new System.EventHandler(this.button_Switch_Click);
            // 
            // label_Input2
            // 
            this.label_Input2.BackColor = System.Drawing.SystemColors.Control;
            this.label_Input2.Location = new System.Drawing.Point(85, 68);
            this.label_Input2.Name = "label_Input2";
            this.label_Input2.Size = new System.Drawing.Size(171, 20);
            this.label_Input2.TabIndex = 42;
            this.label_Input2.Text = "0";
            this.label_Input2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Input1
            // 
            this.label_Input1.BackColor = System.Drawing.SystemColors.Control;
            this.label_Input1.Location = new System.Drawing.Point(85, 38);
            this.label_Input1.Name = "label_Input1";
            this.label_Input1.Size = new System.Drawing.Size(171, 20);
            this.label_Input1.TabIndex = 41;
            this.label_Input1.Text = "0";
            this.label_Input1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OneOfTwoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "OneOfTwoPanel";
            this.Size = new System.Drawing.Size(263, 95);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In2ToIn1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_In1ToIn2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label_Input1;
        private System.Windows.Forms.Label label_Input2;
        private System.Windows.Forms.Button button_Switch;
        private System.Windows.Forms.Label label_Value;
        private DevExpress.XtraEditors.SpinEdit spinEdit_In1ToIn2;
        private DevExpress.XtraEditors.SpinEdit spinEdit_In2ToIn1;
    }
}
