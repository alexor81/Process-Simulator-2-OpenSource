// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.ObjectTextLabel
{
    public partial class SetupForm : Form
    {
        private ObjectTextLabelPanel    mObjectTextLabel;

        public                          SetupForm(ObjectTextLabelPanel aObjectTextLabel)
        {
            mObjectTextLabel = aObjectTextLabel;
            InitializeComponent();
            
            colorEdit_TextColor.Color   = mObjectTextLabel.TextColor;
            colorEdit_BackColor.Color   = mObjectTextLabel.BackgroundColor;
            buttonEdit_Font.Text        = StringUtils.ObjectToString(mObjectTextLabel.LabelFont);
            checkBox_AutoResize.Checked = mObjectTextLabel.AutoResize;
            textBox_Format.Text         = mObjectTextLabel.Format;
        }

        private void                    colorEdit_TextColor_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_TextColor.Color != mObjectTextLabel.TextColor)
            {
                mObjectTextLabel.TextColor = colorEdit_TextColor.Color;
            }
        }

        private void                    colorEdit_BackColor_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_BackColor.Color != mObjectTextLabel.BackgroundColor)
            {
                mObjectTextLabel.BackgroundColor = colorEdit_BackColor.Color;
            }
        }

        private void                    buttonEdit_Font_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            using (var lFontDlg = new FontDialog())
            {
                lFontDlg.Font = mObjectTextLabel.LabelFont;
                if (lFontDlg.ShowDialog(this) == DialogResult.OK)
                {
                    mObjectTextLabel.LabelFont = lFontDlg.Font;
                    buttonEdit_Font.Text = StringUtils.ObjectToString(mObjectTextLabel.LabelFont);
                }
            }
        }

        private void                    checkBox_AutoResize_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_AutoResize.Checked != mObjectTextLabel.AutoResize)
            {
                mObjectTextLabel.AutoResize = checkBox_AutoResize.Checked;
            }
        }

        private void                    textBox_Format_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_Format.Text.Equals(mObjectTextLabel.Format, StringComparison.Ordinal) == false)
            {
                mObjectTextLabel.Format = textBox_Format.Text;
            }
        }

        private void                    button_Size_Click(object aSender, EventArgs aEventArgs)
        {
            mObjectTextLabel.resizeToContent();
        }

        private void                    SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void                    SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
