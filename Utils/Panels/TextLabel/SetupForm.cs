// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.TextLabel
{
    public partial class SetupForm : Form
    {
        private TextLabelPanel  mTextLabel;

        public                  SetupForm(TextLabelPanel aTextLabel)
        {
            mTextLabel = aTextLabel;
            InitializeComponent();
           
            textBox_Text.Text               = mTextLabel.LabelText;
            colorEdit_TextColor.Color       = mTextLabel.TextColor;
            colorEdit_BackColor.Color       = mTextLabel.BackgroundColor;
            buttonEdit_Font.Text            = StringUtils.ObjectToString(mTextLabel.LabelFont);
            comboBox_Rotate.SelectedIndex   = (int)mTextLabel.Rotation;
        }

        private void            textBox_Text_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_Text.Text.Equals(mTextLabel.LabelText, StringComparison.Ordinal) == false)
            {
                mTextLabel.LabelText = textBox_Text.Text;
            }
        }

        private void            colorEdit_TextColor_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_TextColor.Color != mTextLabel.TextColor)
            {
                mTextLabel.TextColor = colorEdit_TextColor.Color;
            }
        }

        private void            colorEdit_BackColor_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_BackColor.Color != mTextLabel.BackgroundColor)
            {
                mTextLabel.BackgroundColor = colorEdit_BackColor.Color;
            }
        }

        private void            buttonEdit_Font_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            using (var lFontDlg = new FontDialog())
            {
                lFontDlg.Font = mTextLabel.LabelFont;
                if (lFontDlg.ShowDialog(this) == DialogResult.OK)
                {
                    mTextLabel.LabelFont = lFontDlg.Font;
                    buttonEdit_Font.Text = StringUtils.ObjectToString(mTextLabel.LabelFont);
                }
            }
        }

        private void            comboBox_Rotate_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            ERotation lNewAngle = (ERotation)comboBox_Rotate.SelectedIndex;
            if(lNewAngle != mTextLabel.Rotation)
            {
                mTextLabel.Rotation = lNewAngle;
            }
        }

        private void            button_Fit_Click(object aSender, EventArgs aEventArgs)
        {
            mTextLabel.fitToContent();
        }

        private void            SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
