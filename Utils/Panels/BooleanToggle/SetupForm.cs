// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.BooleanToggle
{
    public partial class SetupForm : Form
    {
        private BooleanTogglePanel  mBooleanTogglePanel;

        public                      SetupForm(BooleanTogglePanel aBooleanTogglePanel)
        {
            mBooleanTogglePanel = aBooleanTogglePanel;
            InitializeComponent();

            textBox_ToolTip.Text    = mBooleanTogglePanel.LabelText;
            comboBox_Style.Text     = mBooleanTogglePanel.Style;
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mBooleanTogglePanel.LabelText, StringComparison.Ordinal) == false)
            {
                mBooleanTogglePanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                comboBox_Style_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if(comboBox_Style.Text.Equals(mBooleanTogglePanel.Style, StringComparison.Ordinal) == false)
            {
                mBooleanTogglePanel.Style = comboBox_Style.Text;
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
