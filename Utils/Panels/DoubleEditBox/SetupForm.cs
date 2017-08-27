// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.DoubleEditBox
{
    public partial class SetupForm : Form
    {
        private DoubleEditBoxPanel  mEditBox;

        public                      SetupForm(DoubleEditBoxPanel aEditBox)
        {
            mEditBox = aEditBox;
            InitializeComponent();
            
            textBox_ToolTip.Text        = mEditBox.LabelText;
            spinEdit_Round.Value        = mEditBox.Round;
            checkBox_ShowUnits.Checked  = mEditBox.ShowUnits;
            textBox_Units.Text          = mEditBox.Units;
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEditBox.LabelText.Equals(textBox_ToolTip.Text, StringComparison.Ordinal) == false)
            {
                mEditBox.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                checkBox_ShowUnits_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_ShowUnits.Checked != mEditBox.ShowUnits)
            {
                mEditBox.ShowUnits = checkBox_ShowUnits.Checked;
            }
            textBox_Units.Enabled = checkBox_ShowUnits.Checked;
        }

        private void                textBox_Units_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEditBox.Units.Equals(textBox_Units.Text, StringComparison.Ordinal) == false)
            {
                mEditBox.Units = textBox_Units.Text;
                if (String.IsNullOrWhiteSpace(textBox_Units.Text))
                {
                    textBox_Units.Text = mEditBox.Units;
                }
            }
        }

        private void                spinEdit_Round_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            int lValue = (int)spinEdit_Round.Value;
            if (mEditBox.Round != lValue)
            {
                mEditBox.Round = lValue;
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
