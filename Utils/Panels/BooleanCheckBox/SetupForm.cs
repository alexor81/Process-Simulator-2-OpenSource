// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.BooleanCheckBox
{
    public partial class SetupForm : Form
    {
        private BooleanCheckBoxPanel    mBooleanCheckBoxPanel;

        public                          SetupForm(BooleanCheckBoxPanel aBooleanCheckBoxPanel)
        {
            mBooleanCheckBoxPanel = aBooleanCheckBoxPanel;
            InitializeComponent();
            
            textBox_Text.Text           = mBooleanCheckBoxPanel.LabelText;
            checkBox_RightLeft.Checked  = mBooleanCheckBoxPanel.RightLeft;
        }

        private void                    textBox_Text_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_Text.Text.Equals(mBooleanCheckBoxPanel.LabelText, StringComparison.Ordinal) == false)
            {
                mBooleanCheckBoxPanel.LabelText = textBox_Text.Text;
            }
        }

        private void                    checkBox_RightLeft_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_RightLeft.Checked != mBooleanCheckBoxPanel.RightLeft)
            {
                mBooleanCheckBoxPanel.RightLeft = checkBox_RightLeft.Checked;
            }
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
