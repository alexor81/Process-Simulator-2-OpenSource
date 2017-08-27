// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.Snapshot
{
    partial class AddEditRecordForm
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
            this.itemEditBox_Item = new Utils.SpecialControls.ItemEditBox();
            this.okCancelButton = new Utils.SpecialControls.OKCancelButton();
            this.buttonEdit_Value = new DevExpress.XtraEditors.ButtonEdit();
            this.label_Item = new System.Windows.Forms.Label();
            this.label_Value = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Value.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // itemEditBox_Item
            // 
            this.itemEditBox_Item.ItemName = "";
            this.itemEditBox_Item.ItemRequirements = "Any type, Write, Obligatory";
            this.itemEditBox_Item.ItemToolTip = "";
            this.itemEditBox_Item.Location = new System.Drawing.Point(62, 8);
            this.itemEditBox_Item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Item.Name = "itemEditBox_Item";
            this.itemEditBox_Item.Size = new System.Drawing.Size(270, 30);
            this.itemEditBox_Item.TabIndex = 0;
            this.itemEditBox_Item.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // okCancelButton
            // 
            this.okCancelButton.Location = new System.Drawing.Point(76, 81);
            this.okCancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okCancelButton.MaximumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.MinimumSize = new System.Drawing.Size(188, 33);
            this.okCancelButton.Name = "okCancelButton";
            this.okCancelButton.Size = new System.Drawing.Size(188, 33);
            this.okCancelButton.TabIndex = 2;
            this.okCancelButton.ButtonClick += new System.EventHandler(this.okCancelButton_ButtonClick);
            // 
            // buttonEdit_Value
            // 
            this.buttonEdit_Value.Location = new System.Drawing.Point(62, 41);
            this.buttonEdit_Value.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_Value.Name = "buttonEdit_Value";
            this.buttonEdit_Value.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_Value.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_Value.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_Value.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Value.Properties.ReadOnly = true;
            this.buttonEdit_Value.Size = new System.Drawing.Size(270, 24);
            this.buttonEdit_Value.TabIndex = 1;
            this.buttonEdit_Value.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Value_ButtonClick);
            // 
            // label_Item
            // 
            this.label_Item.AutoSize = true;
            this.label_Item.Location = new System.Drawing.Point(18, 15);
            this.label_Item.Name = "label_Item";
            this.label_Item.Size = new System.Drawing.Size(38, 17);
            this.label_Item.TabIndex = 8;
            this.label_Item.Text = "Item:";
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Location = new System.Drawing.Point(8, 45);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(48, 17);
            this.label_Value.TabIndex = 9;
            this.label_Value.Text = "Value:";
            // 
            // AddEditRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 117);
            this.ControlBox = false;
            this.Controls.Add(this.label_Value);
            this.Controls.Add(this.label_Item);
            this.Controls.Add(this.buttonEdit_Value);
            this.Controls.Add(this.itemEditBox_Item);
            this.Controls.Add(this.okCancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRecordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Record";
            this.Load += new System.EventHandler(this.AddEditRecordForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddEditRecordForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Value.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utils.SpecialControls.OKCancelButton okCancelButton;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Item;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Value;
        private System.Windows.Forms.Label label_Item;
        private System.Windows.Forms.Label label_Value;
    }
}