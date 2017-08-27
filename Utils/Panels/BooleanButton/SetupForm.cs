// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.BooleanButton
{
    public partial class SetupForm : Form
    {
        private BooleanButtonPanel  mBooleanButtonPanel;

        public                      SetupForm(BooleanButtonPanel aBooleanButtonPanel)
        {
            mBooleanButtonPanel = aBooleanButtonPanel;
            InitializeComponent();
            
            textBox_TrueText.Text   = mBooleanButtonPanel.TrueText;
            textBox_FalseText.Text  = mBooleanButtonPanel.FalseText;
            colorEdit_True.Color    = mBooleanButtonPanel.TrueColor;
            colorEdit_False.Color   = mBooleanButtonPanel.FalseColor;
            textBox_ToolTip.Text    = mBooleanButtonPanel.LabelText;
        }

        private void                textBox_TrueText_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_TrueText.Text.Equals(mBooleanButtonPanel.TrueText, StringComparison.Ordinal) == false)
            {
                mBooleanButtonPanel.TrueText = textBox_TrueText.Text;
            }
        }

        private void                textBox_FalseText_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_FalseText.Text.Equals(mBooleanButtonPanel.FalseText, StringComparison.Ordinal) == false)
            {
                mBooleanButtonPanel.FalseText = textBox_FalseText.Text;
            }
        }

        private void                colorEdit_True_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_True.Color != mBooleanButtonPanel.TrueColor)
            {
                mBooleanButtonPanel.TrueColor = colorEdit_True.Color;
            }
        }

        private void                colorEdit_False_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_False.Color != mBooleanButtonPanel.FalseColor)
            {
                mBooleanButtonPanel.FalseColor = colorEdit_False.Color;
            }
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mBooleanButtonPanel.LabelText, StringComparison.Ordinal) == false)
            {
                mBooleanButtonPanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
