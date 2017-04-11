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
            this.itemEditBox_Visible = new Utils.SpecialControls.ItemEditBox();
            this.label_Visible = new System.Windows.Forms.Label();
            this.itemEditBox_Moving = new Utils.SpecialControls.ItemEditBox();
            this.label_Moving = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox_UserMove
            // 
            this.checkBox_UserMove.AutoSize = true;
            this.checkBox_UserMove.Location = new System.Drawing.Point(69, 49);
            this.checkBox_UserMove.Name = "checkBox_UserMove";
            this.checkBox_UserMove.Size = new System.Drawing.Size(125, 21);
            this.checkBox_UserMove.TabIndex = 1;
            this.checkBox_UserMove.Text = "User can move";
            this.checkBox_UserMove.UseVisualStyleBackColor = true;
            this.checkBox_UserMove.CheckedChanged += new System.EventHandler(this.checkBox_UserMove_CheckedChanged);
            // 
            // itemEditBox_Visible
            // 
            this.itemEditBox_Visible.ItemName = "";
            this.itemEditBox_Visible.ItemRequirements = "Binary, Read";
            this.itemEditBox_Visible.ItemToolTip = "";
            this.itemEditBox_Visible.Location = new System.Drawing.Point(69, 11);
            this.itemEditBox_Visible.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Visible.Name = "itemEditBox_Visible";
            this.itemEditBox_Visible.Size = new System.Drawing.Size(209, 30);
            this.itemEditBox_Visible.TabIndex = 0;
            this.itemEditBox_Visible.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Visible
            // 
            this.label_Visible.AutoSize = true;
            this.label_Visible.Location = new System.Drawing.Point(9, 18);
            this.label_Visible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Visible.Name = "label_Visible";
            this.label_Visible.Size = new System.Drawing.Size(53, 17);
            this.label_Visible.TabIndex = 26;
            this.label_Visible.Text = "Visible:";
            // 
            // itemEditBox_Moving
            // 
            this.itemEditBox_Moving.ItemName = "";
            this.itemEditBox_Moving.ItemRequirements = "Binary, Write";
            this.itemEditBox_Moving.ItemToolTip = "";
            this.itemEditBox_Moving.Location = new System.Drawing.Point(69, 81);
            this.itemEditBox_Moving.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.itemEditBox_Moving.Name = "itemEditBox_Moving";
            this.itemEditBox_Moving.Size = new System.Drawing.Size(209, 30);
            this.itemEditBox_Moving.TabIndex = 2;
            this.itemEditBox_Moving.ButtonClick += new System.EventHandler(this.ItemButtonClick);
            // 
            // label_Moving
            // 
            this.label_Moving.AutoSize = true;
            this.label_Moving.Location = new System.Drawing.Point(9, 88);
            this.label_Moving.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Moving.Name = "label_Moving";
            this.label_Moving.Size = new System.Drawing.Size(57, 17);
            this.label_Moving.TabIndex = 28;
            this.label_Moving.Text = "Moving:";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 120);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_UserMove;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Visible;
        private System.Windows.Forms.Label label_Visible;
        private Utils.SpecialControls.ItemEditBox itemEditBox_Moving;
        private System.Windows.Forms.Label label_Moving;
    }
}