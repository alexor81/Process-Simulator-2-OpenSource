namespace Connection.OPCUA
{
    partial class ItemSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.button_Browser = new System.Windows.Forms.Button();
            this.textBox_NodeId = new System.Windows.Forms.TextBox();
            this.label_NodeId = new System.Windows.Forms.Label();
            this.label_Sampling = new System.Windows.Forms.Label();
            this.spinEdit_Sampling = new DevExpress.XtraEditors.SpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Sampling.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(97, 82);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 3;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // button_Browser
            // 
            this.button_Browser.Location = new System.Drawing.Point(343, 11);
            this.button_Browser.Name = "button_Browser";
            this.button_Browser.Size = new System.Drawing.Size(33, 23);
            this.button_Browser.TabIndex = 1;
            this.button_Browser.Text = "...";
            this.button_Browser.UseVisualStyleBackColor = true;
            this.button_Browser.Click += new System.EventHandler(this.button_Browser_Click);
            // 
            // textBox_NodeId
            // 
            this.textBox_NodeId.Location = new System.Drawing.Point(114, 11);
            this.textBox_NodeId.Name = "textBox_NodeId";
            this.textBox_NodeId.Size = new System.Drawing.Size(223, 22);
            this.textBox_NodeId.TabIndex = 0;
            // 
            // label_NodeId
            // 
            this.label_NodeId.AutoSize = true;
            this.label_NodeId.Location = new System.Drawing.Point(44, 14);
            this.label_NodeId.Name = "label_NodeId";
            this.label_NodeId.Size = new System.Drawing.Size(63, 17);
            this.label_NodeId.TabIndex = 12;
            this.label_NodeId.Text = "Node ID:";
            // 
            // label_Sampling
            // 
            this.label_Sampling.AutoSize = true;
            this.label_Sampling.Location = new System.Drawing.Point(7, 48);
            this.label_Sampling.Name = "label_Sampling";
            this.label_Sampling.Size = new System.Drawing.Size(100, 17);
            this.label_Sampling.TabIndex = 13;
            this.label_Sampling.Text = "Sampling [ms]:";
            // 
            // spinEdit_Sampling
            // 
            this.spinEdit_Sampling.EditValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.spinEdit_Sampling.Location = new System.Drawing.Point(114, 44);
            this.spinEdit_Sampling.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit_Sampling.Name = "spinEdit_Sampling";
            this.spinEdit_Sampling.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinEdit_Sampling.Properties.IsFloatValue = false;
            this.spinEdit_Sampling.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.spinEdit_Sampling.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.spinEdit_Sampling.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.spinEdit_Sampling.Properties.Mask.EditMask = "N00";
            this.spinEdit_Sampling.Properties.MaxValue = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.spinEdit_Sampling.Size = new System.Drawing.Size(93, 24);
            this.spinEdit_Sampling.TabIndex = 2;
            // 
            // ItemSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 120);
            this.Controls.Add(this.spinEdit_Sampling);
            this.Controls.Add(this.label_Sampling);
            this.Controls.Add(this.button_Browser);
            this.Controls.Add(this.textBox_NodeId);
            this.Controls.Add(this.label_NodeId);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OPC UA Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemSetupFormcs_FormClosed);
            this.Load += new System.EventHandler(this.ItemSetupFormcs_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemSetupFormcs_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit_Sampling.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Button button_Browser;
        private System.Windows.Forms.TextBox textBox_NodeId;
        private System.Windows.Forms.Label label_NodeId;
        private System.Windows.Forms.Label label_Sampling;
        private DevExpress.XtraEditors.SpinEdit spinEdit_Sampling;
    }
}