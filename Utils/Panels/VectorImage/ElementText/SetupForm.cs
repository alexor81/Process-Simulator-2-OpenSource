// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.VectorImage.ElementText
{
    public partial class SetupForm : Form
    {
        private IRedraw     mRedraw;
        private ElementText mText;

        public              SetupForm(ElementText aText, IRedraw aRedraw)
        {
            mText   = aText;
            mRedraw = aRedraw;
            InitializeComponent();

            spinEdit_X.Value                = mText.mX;
            spinEdit_Y.Value                = mText.mY;
            textBox_Text.Text               = mText.mText;
            buttonEdit_Font.Text            = StringUtils.ObjectToString(mText.TextFont);
            colorEdit_Color.Color           = mText.TextColor;
            comboBox_Rotate.SelectedIndex   = (int)mText.mRotation;
        }

        private void        spinEdit_X_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mText.mX != spinEdit_X.Value)
            {
                mText.mX = (int)spinEdit_X.Value;
                mRedraw.Redraw();
            }
        }

        private void        spinEdit_Y_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mText.mY != spinEdit_Y.Value)
            {
                mText.mY = (int)spinEdit_Y.Value;
                mRedraw.Redraw();
            }
        }

        private void        textBox_Text_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_Text.Text.Equals(mText.mText, StringComparison.Ordinal) == false)
            {
                mText.mText = textBox_Text.Text;
                mRedraw.Redraw();
            }
        }

        private void        buttonEdit_Font_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            using (var lFontDlg = new FontDialog())
            {
                lFontDlg.Font = mText.TextFont;
                if (lFontDlg.ShowDialog(this) == DialogResult.OK)
                {
                    mText.TextFont          = lFontDlg.Font;
                    buttonEdit_Font.Text    = StringUtils.ObjectToString(mText.TextFont);
                    mRedraw.Redraw();
                }
            }
        }

        private void        colorEdit_Color_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Color.Color != mText.TextColor)
            {
                mText.TextColor = colorEdit_Color.Color;
                mRedraw.Redraw();
            }
        }

        private void        comboBox_Rotate_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            ERotation lNewAngle = (ERotation)comboBox_Rotate.SelectedIndex;
            if (lNewAngle != mText.mRotation)
            {
                mText.mRotation = lNewAngle;
                mRedraw.Redraw();
            }
        }

        private void        SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
