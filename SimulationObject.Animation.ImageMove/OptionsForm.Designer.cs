// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace SimulationObject.Animation.ImageMove
{
    partial class OptionsForm
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
            this.checkBox_UserMove = new System.Windows.Forms.CheckBox();
            this.label_Visible = new System.Windows.Forms.Label();
            this.label_Moving = new System.Windows.Forms.Label();
            this.label_Width = new System.Windows.Forms.Label();
            this.label_Height = new System.Windows.Forms.Label();
            this.label_Label = new System.Windows.Forms.Label();
            this.itemEditBox_Label = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Height = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Width = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Moving = new Utils.SpecialControls.ItemEditBox();
            this.itemEditBox_Visible = new Utils.SpecialControls.ItemEditBox();
            this.buttonEdit_Font = new DevExpress.XtraEditors.ButtonEdit();
            this.label_LabelFont = new System.Windows.Forms.Label();
            this.colorEdit_Color = new DevExpress.XtraEditors.ColorEdit();
            this.label_TextColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Color.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_UserMove
            // 
            this.checkBox_UserMove.AutoSize = true;
            this.checkBox_UserMove.Location = new System.Drawing.Point(72, 227);
            this.checkBox_UserMove.Name = "checkBox_UserMove";
            this.checkBox_UserMove.Size = new System.Drawing.Size(125, 21);
            this.checkBox_UserMove.TabIndex = 6;
            this.checkBox_UserMove.Text = "User can move";
            this.checkBox_UserMove.UseVisualStyleBackColor = true;
            this.checkBox_UserMove.CheckedChanged += new System.EventHandler(this.checkBox_UserMove_CheckedChanged);
            // 
            // label_Visible
            // 
            this.label_Visible.AutoSize = true;
            this.label_Visible.Location = new System.Drawing.Point(12, 18);
            this.label_Visible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Visible.Name = "label_Visible";
            this.label_Visible.Size = new System.Drawing.Size(53, 17);
            this.label_Visible.TabIndex = 26;
            this.label_Visible.Text = "Visible:";
            // 
            // label_Moving
            // 
            this.label_Moving.AutoSize = true;
            this.label_Moving.Location = new System.Drawing.Point(8, 263);
            this.label_Moving.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Moving.Name = "label_Moving";
            this.label_Moving.Size = new System.Drawing.Size(57, 17);
            this.label_Moving.TabIndex = 28;
            this.label_Moving.Text = "Moving:";
            // 
            // label_Width
            // 
            this.label_Width.AutoSize = true;
            this.label_Width.Location = new System.Drawing.Point(17, 56);
            this.label_Width.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Width.Name = "label_Width";
            this.label_Width.Size = new System.Drawing.Size(48, 17);
            this.label_Width.TabIndex = 30;
            this.label_Width.Text = "Width:";
            // 
            // label_Height
            // 
            this.label_Height.AutoSize = true;
            this.label_Height.Location = new System.Drawing.Point(12, 94);
            this.label_Height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Height.Name = "label_Height";
            this.label_Height.Size = new System.Drawing.Size(53, 17);
            this.label_Height.TabIndex = 32;
            this.label_Height.Text = "Height:";
            // 
            // label_Label
            // 
            this.label_Label.AutoSize = true;
            this.label_Label.Location = new System.Drawing.Point(18, 132);
            this.label_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Label.Name = "label_Label";
            this.label_Label.Size = new System.Drawing.Size(47, 17);
            this.label_Label.TabIndex = 34;
            this.label_Label.Text = "Label:";
            // 
            // itemEditBox_Label
            // 
            this.itemEditBox_Label.ItemName = "";
            this.itemEditBox_Label.ItemRequirements = "Any type, Read";
            this.itemEditBox_Label.ItemToolTip = "";
            this.itemEditBox_Label.Location = new System.Drawing.Point(72, 125);
            this.itemEditBox_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Label.Name = "itemEditBox_Label";
            this.itemEditBox_Label.Size = new System.Drawing.Size(258, 30);
            this.itemEditBox_Label.TabIndex = 3;
            this.itemEditBox_Label.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Height
            // 
            this.itemEditBox_Height.ItemName = "";
            this.itemEditBox_Height.ItemRequirements = "Real, Read";
            this.itemEditBox_Height.ItemToolTip = "";
            this.itemEditBox_Height.Location = new System.Drawing.Point(72, 87);
            this.itemEditBox_Height.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Height.Name = "itemEditBox_Height";
            this.itemEditBox_Height.Size = new System.Drawing.Size(258, 30);
            this.itemEditBox_Height.TabIndex = 2;
            this.itemEditBox_Height.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Width
            // 
            this.itemEditBox_Width.ItemName = "";
            this.itemEditBox_Width.ItemRequirements = "Real, Read";
            this.itemEditBox_Width.ItemToolTip = "";
            this.itemEditBox_Width.Location = new System.Drawing.Point(72, 49);
            this.itemEditBox_Width.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Width.Name = "itemEditBox_Width";
            this.itemEditBox_Width.Size = new System.Drawing.Size(258, 30);
            this.itemEditBox_Width.TabIndex = 1;
            this.itemEditBox_Width.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Moving
            // 
            this.itemEditBox_Moving.ItemName = "";
            this.itemEditBox_Moving.ItemRequirements = "Binary, Write";
            this.itemEditBox_Moving.ItemToolTip = "";
            this.itemEditBox_Moving.Location = new System.Drawing.Point(72, 256);
            this.itemEditBox_Moving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Moving.Name = "itemEditBox_Moving";
            this.itemEditBox_Moving.Size = new System.Drawing.Size(258, 30);
            this.itemEditBox_Moving.TabIndex = 7;
            this.itemEditBox_Moving.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // itemEditBox_Visible
            // 
            this.itemEditBox_Visible.ItemName = "";
            this.itemEditBox_Visible.ItemRequirements = "Binary, Read";
            this.itemEditBox_Visible.ItemToolTip = "";
            this.itemEditBox_Visible.Location = new System.Drawing.Point(72, 11);
            this.itemEditBox_Visible.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Visible.Name = "itemEditBox_Visible";
            this.itemEditBox_Visible.Size = new System.Drawing.Size(258, 30);
            this.itemEditBox_Visible.TabIndex = 0;
            this.itemEditBox_Visible.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // buttonEdit_Font
            // 
            this.buttonEdit_Font.Location = new System.Drawing.Point(72, 163);
            this.buttonEdit_Font.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit_Font.Name = "buttonEdit_Font";
            this.buttonEdit_Font.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit_Font.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.buttonEdit_Font.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.buttonEdit_Font.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Font.Properties.ReadOnly = true;
            this.buttonEdit_Font.Size = new System.Drawing.Size(258, 24);
            this.buttonEdit_Font.TabIndex = 4;
            this.buttonEdit_Font.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Font_ButtonClick);
            // 
            // label_LabelFont
            // 
            this.label_LabelFont.AutoSize = true;
            this.label_LabelFont.Location = new System.Drawing.Point(25, 167);
            this.label_LabelFont.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LabelFont.Name = "label_LabelFont";
            this.label_LabelFont.Size = new System.Drawing.Size(40, 17);
            this.label_LabelFont.TabIndex = 36;
            this.label_LabelFont.Text = "Font:";
            // 
            // colorEdit_Color
            // 
            this.colorEdit_Color.EditValue = System.Drawing.Color.Empty;
            this.colorEdit_Color.Location = new System.Drawing.Point(72, 195);
            this.colorEdit_Color.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorEdit_Color.Name = "colorEdit_Color";
            this.colorEdit_Color.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEdit_Color.Properties.LookAndFeel.SkinName = "Office 2010 Black";
            this.colorEdit_Color.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.colorEdit_Color.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.colorEdit_Color.Size = new System.Drawing.Size(258, 24);
            this.colorEdit_Color.TabIndex = 5;
            // 
            // label_TextColor
            // 
            this.label_TextColor.AutoSize = true;
            this.label_TextColor.Location = new System.Drawing.Point(20, 199);
            this.label_TextColor.Name = "label_TextColor";
            this.label_TextColor.Size = new System.Drawing.Size(45, 17);
            this.label_TextColor.TabIndex = 40;
            this.label_TextColor.Text = "Color:";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 296);
            this.Controls.Add(this.colorEdit_Color);
            this.Controls.Add(this.label_TextColor);
            this.Controls.Add(this.label_LabelFont);
            this.Controls.Add(this.buttonEdit_Font);
            this.Controls.Add(this.itemEditBox_Label);
            this.Controls.Add(this.label_Label);
            this.Controls.Add(this.itemEditBox_Height);
            this.Controls.Add(this.label_Height);
            this.Controls.Add(this.itemEditBox_Width);
            this.Controls.Add(this.label_Width);
            this.Controls.Add(this.itemEditBox_Moving);
            this.Controls.Add(this.label_Moving);
            this.Controls.Add(this.checkBox_UserMove);
            this.Controls.Add(this.itemEditBox_Visible);
            this.Controls.Add(this.label_Visible);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OptionsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Font.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorEdit_Color.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_UserMove;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Visible;
        private System.Windows.Forms.Label label_Visible;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Moving;
        private System.Windows.Forms.Label label_Moving;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Width;
        private System.Windows.Forms.Label label_Width;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Height;
        private System.Windows.Forms.Label label_Height;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Label;
        private System.Windows.Forms.Label label_Label;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Font;
        private System.Windows.Forms.Label label_LabelFont;
        private DevExpress.XtraEditors.ColorEdit colorEdit_Color;
        private System.Windows.Forms.Label label_TextColor;
    }
}