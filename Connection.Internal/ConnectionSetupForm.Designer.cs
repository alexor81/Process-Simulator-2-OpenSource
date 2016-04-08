namespace Connection.Internal
{
    partial class ConnectionSetupForm
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
            this.label_Status = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_Disconnect = new System.Windows.Forms.Button();
            this.groupBox_Connection = new System.Windows.Forms.GroupBox();
            this.groupBox_Items = new System.Windows.Forms.GroupBox();
            this.label_CountN = new System.Windows.Forms.Label();
            this.label_Count = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Connection.SuspendLayout();
            this.groupBox_Items.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Status
            // 
            this.label_Status.AutoSize = true;
            this.label_Status.Location = new System.Drawing.Point(12, 26);
            this.label_Status.Name = "label_Status";
            this.label_Status.Size = new System.Drawing.Size(124, 17);
            this.label_Status.TabIndex = 1;
            this.label_Status.Text = "Status: Connected";
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(32, 62);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(103, 27);
            this.button_Connect.TabIndex = 0;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // button_Disconnect
            // 
            this.button_Disconnect.Location = new System.Drawing.Point(140, 62);
            this.button_Disconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Disconnect.Name = "button_Disconnect";
            this.button_Disconnect.Size = new System.Drawing.Size(103, 27);
            this.button_Disconnect.TabIndex = 1;
            this.button_Disconnect.Text = "Disconnect";
            this.button_Disconnect.UseVisualStyleBackColor = true;
            this.button_Disconnect.Click += new System.EventHandler(this.button_Disconnect_Click);
            // 
            // groupBox_Connection
            // 
            this.groupBox_Connection.Controls.Add(this.label_Status);
            this.groupBox_Connection.Controls.Add(this.button_Disconnect);
            this.groupBox_Connection.Controls.Add(this.button_Connect);
            this.groupBox_Connection.Location = new System.Drawing.Point(4, 1);
            this.groupBox_Connection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Connection.Name = "groupBox_Connection";
            this.groupBox_Connection.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Connection.Size = new System.Drawing.Size(276, 98);
            this.groupBox_Connection.TabIndex = 0;
            this.groupBox_Connection.TabStop = false;
            this.groupBox_Connection.Text = "Connection";
            // 
            // groupBox_Items
            // 
            this.groupBox_Items.Controls.Add(this.label_CountN);
            this.groupBox_Items.Controls.Add(this.label_Count);
            this.groupBox_Items.Location = new System.Drawing.Point(4, 106);
            this.groupBox_Items.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Name = "groupBox_Items";
            this.groupBox_Items.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Items.Size = new System.Drawing.Size(276, 43);
            this.groupBox_Items.TabIndex = 1;
            this.groupBox_Items.TabStop = false;
            this.groupBox_Items.Text = "Items";
            // 
            // label_CountN
            // 
            this.label_CountN.AutoSize = true;
            this.label_CountN.Location = new System.Drawing.Point(156, 16);
            this.label_CountN.Name = "label_CountN";
            this.label_CountN.Size = new System.Drawing.Size(16, 17);
            this.label_CountN.TabIndex = 1;
            this.label_CountN.Text = "0";
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Location = new System.Drawing.Point(101, 16);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(49, 17);
            this.label_Count.TabIndex = 0;
            this.label_Count.Text = "Count:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(48, 155);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 2;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // ConnectionSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 190);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Connection);
            this.Controls.Add(this.okCancelButton);
            this.Controls.Add(this.groupBox_Items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Internal Connection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConnectionSetupForm_FormClosed);
            this.Load += new System.EventHandler(this.ConnectionSetupForm_Load);
            this.groupBox_Connection.ResumeLayout(false);
            this.groupBox_Connection.PerformLayout();
            this.groupBox_Items.ResumeLayout(false);
            this.groupBox_Items.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Status;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button button_Disconnect;
        private System.Windows.Forms.GroupBox groupBox_Connection;
        private System.Windows.Forms.GroupBox groupBox_Items;
        private System.Windows.Forms.Label label_CountN;
        private System.Windows.Forms.Label label_Count;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
    }
}