// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Real.Scale
{
    partial class SetupForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_InItem = new System.Windows.Forms.Label();
            this.groupBox_Physical = new System.Windows.Forms.GroupBox();
            this.itemEditBox_Output = new Utils.SpecialControls.ItemEditBox();
            this.textBox_OutMin = new System.Windows.Forms.TextBox();
            this.textBox_OutMax = new System.Windows.Forms.TextBox();
            this.label_OutItem = new System.Windows.Forms.Label();
            this.textBox_InMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_InMax = new System.Windows.Forms.TextBox();
            this.groupBox_Raw = new System.Windows.Forms.GroupBox();
            this.itemEditBox_Input = new Utils.SpecialControls.ItemEditBox();
            this.label2 = new System.Windows.Forms.Label();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Physical.SuspendLayout();
            this.groupBox_Raw.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Min:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max:";
            // 
            // label_InItem
            // 
            this.label_InItem.AutoSize = true;
            this.label_InItem.Location = new System.Drawing.Point(17, 27);
            this.label_InItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_InItem.Name = "label_InItem";
            this.label_InItem.Size = new System.Drawing.Size(38, 17);
            this.label_InItem.TabIndex = 16;
            this.label_InItem.Text = "Item:";
            // 
            // groupBox_Physical
            // 
            this.groupBox_Physical.Controls.Add(this.itemEditBox_Output);
            this.groupBox_Physical.Controls.Add(this.textBox_OutMin);
            this.groupBox_Physical.Controls.Add(this.textBox_OutMax);
            this.groupBox_Physical.Controls.Add(this.label_OutItem);
            this.groupBox_Physical.Controls.Add(this.label4);
            this.groupBox_Physical.Controls.Add(this.label3);
            this.groupBox_Physical.Location = new System.Drawing.Point(4, 98);
            this.groupBox_Physical.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Physical.Name = "groupBox_Physical";
            this.groupBox_Physical.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Physical.Size = new System.Drawing.Size(421, 94);
            this.groupBox_Physical.TabIndex = 1;
            this.groupBox_Physical.TabStop = false;
            this.groupBox_Physical.Text = "Output";
            // 
            // itemEditBox_Output
            // 
            this.itemEditBox_Output.ItemName = "";
            this.itemEditBox_Output.ItemRequirements = "Real, Read, Write, Required";
            this.itemEditBox_Output.ItemToolTip = "";
            this.itemEditBox_Output.Location = new System.Drawing.Point(61, 20);
            this.itemEditBox_Output.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Output.Name = "itemEditBox_Output";
            this.itemEditBox_Output.Size = new System.Drawing.Size(349, 30);
            this.itemEditBox_Output.TabIndex = 0;
            this.itemEditBox_Output.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // textBox_OutMin
            // 
            this.textBox_OutMin.Location = new System.Drawing.Point(259, 60);
            this.textBox_OutMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_OutMin.Name = "textBox_OutMin";
            this.textBox_OutMin.Size = new System.Drawing.Size(151, 22);
            this.textBox_OutMin.TabIndex = 2;
            this.textBox_OutMin.Text = "0";
            // 
            // textBox_OutMax
            // 
            this.textBox_OutMax.Location = new System.Drawing.Point(61, 60);
            this.textBox_OutMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_OutMax.Name = "textBox_OutMax";
            this.textBox_OutMax.Size = new System.Drawing.Size(147, 22);
            this.textBox_OutMax.TabIndex = 1;
            this.textBox_OutMax.Text = "100";
            // 
            // label_OutItem
            // 
            this.label_OutItem.AutoSize = true;
            this.label_OutItem.Location = new System.Drawing.Point(17, 27);
            this.label_OutItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_OutItem.Name = "label_OutItem";
            this.label_OutItem.Size = new System.Drawing.Size(38, 17);
            this.label_OutItem.TabIndex = 18;
            this.label_OutItem.Text = "Item:";
            // 
            // textBox_InMin
            // 
            this.textBox_InMin.Location = new System.Drawing.Point(259, 59);
            this.textBox_InMin.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_InMin.Name = "textBox_InMin";
            this.textBox_InMin.Size = new System.Drawing.Size(151, 22);
            this.textBox_InMin.TabIndex = 2;
            this.textBox_InMin.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max:";
            // 
            // textBox_InMax
            // 
            this.textBox_InMax.Location = new System.Drawing.Point(61, 59);
            this.textBox_InMax.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_InMax.Name = "textBox_InMax";
            this.textBox_InMax.Size = new System.Drawing.Size(147, 22);
            this.textBox_InMax.TabIndex = 1;
            this.textBox_InMax.Text = "27648";
            // 
            // groupBox_Raw
            // 
            this.groupBox_Raw.Controls.Add(this.itemEditBox_Input);
            this.groupBox_Raw.Controls.Add(this.textBox_InMin);
            this.groupBox_Raw.Controls.Add(this.textBox_InMax);
            this.groupBox_Raw.Controls.Add(this.label_InItem);
            this.groupBox_Raw.Controls.Add(this.label2);
            this.groupBox_Raw.Controls.Add(this.label1);
            this.groupBox_Raw.Location = new System.Drawing.Point(4, 0);
            this.groupBox_Raw.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Raw.Name = "groupBox_Raw";
            this.groupBox_Raw.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Raw.Size = new System.Drawing.Size(421, 91);
            this.groupBox_Raw.TabIndex = 0;
            this.groupBox_Raw.TabStop = false;
            this.groupBox_Raw.Text = "Input";
            // 
            // itemEditBox_Input
            // 
            this.itemEditBox_Input.ItemName = "";
            this.itemEditBox_Input.ItemRequirements = "Real, Read, Write, Required";
            this.itemEditBox_Input.ItemToolTip = "";
            this.itemEditBox_Input.Location = new System.Drawing.Point(61, 20);
            this.itemEditBox_Input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Input.Name = "itemEditBox_Input";
            this.itemEditBox_Input.Size = new System.Drawing.Size(349, 30);
            this.itemEditBox_Input.TabIndex = 0;
            this.itemEditBox_Input.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Min:";
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(120, 202);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 2;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 235);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox_Physical);
            this.Controls.Add(this.groupBox_Raw);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Real.Scale";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Physical.ResumeLayout(false);
            this.groupBox_Physical.PerformLayout();
            this.groupBox_Raw.ResumeLayout(false);
            this.groupBox_Raw.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_InItem;
        private System.Windows.Forms.GroupBox groupBox_Physical;
        private System.Windows.Forms.TextBox textBox_OutMin;
        private System.Windows.Forms.TextBox textBox_OutMax;
        private System.Windows.Forms.TextBox textBox_InMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_InMax;
        private System.Windows.Forms.GroupBox groupBox_Raw;
        private System.Windows.Forms.Label label2;
        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_OutItem;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Output;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Input;

    }
}