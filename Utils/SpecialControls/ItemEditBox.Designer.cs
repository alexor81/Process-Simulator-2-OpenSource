// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
namespace Utils.SpecialControls
{
    partial class ItemEditBox
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.buttonEdit_Item = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Item.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEdit_Item
            // 
            this.buttonEdit_Item.CausesValidation = false;
            this.buttonEdit_Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEdit_Item.Location = new System.Drawing.Point(0, 0);
            this.buttonEdit_Item.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEdit_Item.Name = "buttonEdit_Item";
            this.buttonEdit_Item.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Utils.Properties.Resources.Book, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.buttonEdit_Item.Properties.LookAndFeel.SkinName = "Black";
            this.buttonEdit_Item.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.buttonEdit_Item.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.buttonEdit_Item.Properties.NullValuePrompt = "Type, Read, Write, Required";
            this.buttonEdit_Item.Properties.NullValuePromptShowForEmptyValue = true;
            this.buttonEdit_Item.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.buttonEdit_Item.Size = new System.Drawing.Size(211, 26);
            this.buttonEdit_Item.TabIndex = 0;
            this.buttonEdit_Item.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit_Item_ButtonClick);
            // 
            // ItemEditBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEdit_Item);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ItemEditBox";
            this.Size = new System.Drawing.Size(211, 33);
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit_Item.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ButtonEdit buttonEdit_Item;

    }
}
