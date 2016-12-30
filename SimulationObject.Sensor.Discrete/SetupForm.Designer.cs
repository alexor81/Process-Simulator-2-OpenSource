// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Sensor.Discrete
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
            this.label_Item = new System.Windows.Forms.Label();
            this.textBox_True = new System.Windows.Forms.TextBox();
            this.label_True = new System.Windows.Forms.Label();
            this.groupBox_Signalisation = new System.Windows.Forms.GroupBox();
            this.checkBox_TellFalse = new System.Windows.Forms.CheckBox();
            this.checkBox_TellTrue = new System.Windows.Forms.CheckBox();
            this.checkBox_LogFalse = new System.Windows.Forms.CheckBox();
            this.checkBox_LogTrue = new System.Windows.Forms.CheckBox();
            this.label_Tell = new System.Windows.Forms.Label();
            this.label_Log = new System.Windows.Forms.Label();
            this.label_False = new System.Windows.Forms.Label();
            this.textBox_False = new System.Windows.Forms.TextBox();
            this.itemEditBox = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.groupBox_Signalisation.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Item
            // 
            this.label_Item.AutoSize = true;
            this.label_Item.Location = new System.Drawing.Point(11, 12);
            this.label_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Item.Name = "label_Item";
            this.label_Item.Size = new System.Drawing.Size(38, 17);
            this.label_Item.TabIndex = 17;
            this.label_Item.Text = "Item:";
            // 
            // textBox_True
            // 
            this.textBox_True.Location = new System.Drawing.Point(64, 39);
            this.textBox_True.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_True.Name = "textBox_True";
            this.textBox_True.Size = new System.Drawing.Size(206, 22);
            this.textBox_True.TabIndex = 0;
            // 
            // label_True
            // 
            this.label_True.AutoSize = true;
            this.label_True.Location = new System.Drawing.Point(16, 42);
            this.label_True.Name = "label_True";
            this.label_True.Size = new System.Drawing.Size(42, 17);
            this.label_True.TabIndex = 20;
            this.label_True.Text = "True:";
            // 
            // groupBox_Signalisation
            // 
            this.groupBox_Signalisation.Controls.Add(this.checkBox_TellFalse);
            this.groupBox_Signalisation.Controls.Add(this.checkBox_TellTrue);
            this.groupBox_Signalisation.Controls.Add(this.checkBox_LogFalse);
            this.groupBox_Signalisation.Controls.Add(this.checkBox_LogTrue);
            this.groupBox_Signalisation.Controls.Add(this.label_Tell);
            this.groupBox_Signalisation.Controls.Add(this.label_Log);
            this.groupBox_Signalisation.Controls.Add(this.label_False);
            this.groupBox_Signalisation.Controls.Add(this.textBox_False);
            this.groupBox_Signalisation.Controls.Add(this.label_True);
            this.groupBox_Signalisation.Controls.Add(this.textBox_True);
            this.groupBox_Signalisation.Location = new System.Drawing.Point(6, 41);
            this.groupBox_Signalisation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Signalisation.Name = "groupBox_Signalisation";
            this.groupBox_Signalisation.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_Signalisation.Size = new System.Drawing.Size(372, 108);
            this.groupBox_Signalisation.TabIndex = 1;
            this.groupBox_Signalisation.TabStop = false;
            this.groupBox_Signalisation.Text = "Signalisation";
            // 
            // checkBox_TellFalse
            // 
            this.checkBox_TellFalse.AutoSize = true;
            this.checkBox_TellFalse.Location = new System.Drawing.Point(335, 79);
            this.checkBox_TellFalse.Name = "checkBox_TellFalse";
            this.checkBox_TellFalse.Size = new System.Drawing.Size(18, 17);
            this.checkBox_TellFalse.TabIndex = 28;
            this.checkBox_TellFalse.UseVisualStyleBackColor = true;
            // 
            // checkBox_TellTrue
            // 
            this.checkBox_TellTrue.AutoSize = true;
            this.checkBox_TellTrue.Location = new System.Drawing.Point(335, 42);
            this.checkBox_TellTrue.Name = "checkBox_TellTrue";
            this.checkBox_TellTrue.Size = new System.Drawing.Size(18, 17);
            this.checkBox_TellTrue.TabIndex = 27;
            this.checkBox_TellTrue.UseVisualStyleBackColor = true;
            // 
            // checkBox_LogFalse
            // 
            this.checkBox_LogFalse.AutoSize = true;
            this.checkBox_LogFalse.Location = new System.Drawing.Point(287, 79);
            this.checkBox_LogFalse.Name = "checkBox_LogFalse";
            this.checkBox_LogFalse.Size = new System.Drawing.Size(18, 17);
            this.checkBox_LogFalse.TabIndex = 26;
            this.checkBox_LogFalse.UseVisualStyleBackColor = true;
            // 
            // checkBox_LogTrue
            // 
            this.checkBox_LogTrue.AutoSize = true;
            this.checkBox_LogTrue.Location = new System.Drawing.Point(287, 42);
            this.checkBox_LogTrue.Name = "checkBox_LogTrue";
            this.checkBox_LogTrue.Size = new System.Drawing.Size(18, 17);
            this.checkBox_LogTrue.TabIndex = 25;
            this.checkBox_LogTrue.UseVisualStyleBackColor = true;
            // 
            // label_Tell
            // 
            this.label_Tell.AutoSize = true;
            this.label_Tell.Location = new System.Drawing.Point(329, 14);
            this.label_Tell.Name = "label_Tell";
            this.label_Tell.Size = new System.Drawing.Size(31, 17);
            this.label_Tell.TabIndex = 24;
            this.label_Tell.Text = "Tell";
            // 
            // label_Log
            // 
            this.label_Log.AutoSize = true;
            this.label_Log.Location = new System.Drawing.Point(280, 14);
            this.label_Log.Name = "label_Log";
            this.label_Log.Size = new System.Drawing.Size(32, 17);
            this.label_Log.TabIndex = 23;
            this.label_Log.Text = "Log";
            // 
            // label_False
            // 
            this.label_False.AutoSize = true;
            this.label_False.Location = new System.Drawing.Point(12, 78);
            this.label_False.Name = "label_False";
            this.label_False.Size = new System.Drawing.Size(46, 17);
            this.label_False.TabIndex = 22;
            this.label_False.Text = "False:";
            // 
            // textBox_False
            // 
            this.textBox_False.Location = new System.Drawing.Point(64, 75);
            this.textBox_False.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_False.Name = "textBox_False";
            this.textBox_False.Size = new System.Drawing.Size(206, 22);
            this.textBox_False.TabIndex = 1;
            // 
            // itemEditBox
            // 
            this.itemEditBox.ItemName = "";
            this.itemEditBox.ItemRequirements = "Binary, Read, Write, Obligatory";
            this.itemEditBox.ItemToolTip = "";
            this.itemEditBox.Location = new System.Drawing.Point(55, 5);
            this.itemEditBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox.Name = "itemEditBox";
            this.itemEditBox.Size = new System.Drawing.Size(320, 30);
            this.itemEditBox.TabIndex = 0;
            this.itemEditBox.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(98, 159);
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
            this.ClientSize = new System.Drawing.Size(384, 196);
            this.ControlBox = false;
            this.Controls.Add(this.itemEditBox);
            this.Controls.Add(this.groupBox_Signalisation);
            this.Controls.Add(this.label_Item);
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
            this.Text = "Sensor.Discrete";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.groupBox_Signalisation.ResumeLayout(false);
            this.groupBox_Signalisation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_Item;
        private System.Windows.Forms.TextBox textBox_True;
        private System.Windows.Forms.Label label_True;
        private System.Windows.Forms.GroupBox groupBox_Signalisation;
        private System.Windows.Forms.Label label_False;
        private System.Windows.Forms.TextBox textBox_False;
        private Utils.SpecialControls.ItemEditBox itemEditBox;
        private System.Windows.Forms.Label label_Tell;
        private System.Windows.Forms.Label label_Log;
        private System.Windows.Forms.CheckBox checkBox_TellFalse;
        private System.Windows.Forms.CheckBox checkBox_TellTrue;
        private System.Windows.Forms.CheckBox checkBox_LogFalse;
        private System.Windows.Forms.CheckBox checkBox_LogTrue;
    }
}