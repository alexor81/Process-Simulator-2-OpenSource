// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Voice.Command
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
            this.label_Language = new System.Windows.Forms.Label();
            this.comboBox_Lang = new System.Windows.Forms.ComboBox();
            this.button_Commands = new System.Windows.Forms.Button();
            this.label_Item = new System.Windows.Forms.Label();
            this.itemEditBox = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.SuspendLayout();
            // 
            // label_Language
            // 
            this.label_Language.AutoSize = true;
            this.label_Language.Location = new System.Drawing.Point(11, 21);
            this.label_Language.Name = "label_Language";
            this.label_Language.Size = new System.Drawing.Size(76, 17);
            this.label_Language.TabIndex = 4;
            this.label_Language.Text = "Language:";
            // 
            // comboBox_Lang
            // 
            this.comboBox_Lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Lang.FormattingEnabled = true;
            this.comboBox_Lang.Location = new System.Drawing.Point(93, 17);
            this.comboBox_Lang.Name = "comboBox_Lang";
            this.comboBox_Lang.Size = new System.Drawing.Size(203, 24);
            this.comboBox_Lang.TabIndex = 0;
            // 
            // button_Commands
            // 
            this.button_Commands.Location = new System.Drawing.Point(102, 88);
            this.button_Commands.Name = "button_Commands";
            this.button_Commands.Size = new System.Drawing.Size(105, 29);
            this.button_Commands.TabIndex = 2;
            this.button_Commands.Text = "Commands...";
            this.button_Commands.UseVisualStyleBackColor = true;
            this.button_Commands.Click += new System.EventHandler(this.button_Commands_Click);
            // 
            // label_Item
            // 
            this.label_Item.AutoSize = true;
            this.label_Item.Location = new System.Drawing.Point(49, 56);
            this.label_Item.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Item.Name = "label_Item";
            this.label_Item.Size = new System.Drawing.Size(38, 17);
            this.label_Item.TabIndex = 19;
            this.label_Item.Text = "Item:";
            // 
            // itemEditBox
            // 
            this.itemEditBox.ItemName = "";
            this.itemEditBox.ItemRequirements = "Any type, Write, Obligatory";
            this.itemEditBox.ItemToolTip = "";
            this.itemEditBox.Location = new System.Drawing.Point(94, 49);
            this.itemEditBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox.Name = "itemEditBox";
            this.itemEditBox.Size = new System.Drawing.Size(202, 30);
            this.itemEditBox.TabIndex = 1;
            this.itemEditBox.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(60, 129);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 3;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 169);
            this.ControlBox = false;
            this.Controls.Add(this.itemEditBox);
            this.Controls.Add(this.label_Item);
            this.Controls.Add(this.button_Commands);
            this.Controls.Add(this.comboBox_Lang);
            this.Controls.Add(this.label_Language);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Voice.Command";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetupForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private System.Windows.Forms.Label label_Language;
        private System.Windows.Forms.ComboBox comboBox_Lang;
        private System.Windows.Forms.Button button_Commands;
        private Utils.SpecialControls.ItemEditBox itemEditBox;
        private System.Windows.Forms.Label label_Item;
    }
}