// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.StringTextEditor
{
    public partial class SetupForm : Form
    {
        private StringTextEditorPanel   mStringTextEditorPanel;

        public                          SetupForm(StringTextEditorPanel aStringTextEditorPanel)
        {
            mStringTextEditorPanel  = aStringTextEditorPanel;
            InitializeComponent();

            textBox_ToolTip.Text    = mStringTextEditorPanel.LabelText;
            comboBox_Type.Items.AddRange(Enum.GetNames(typeof(FastColoredTextBoxNS.Language)));
            comboBox_Type.Text      = mStringTextEditorPanel.TextType;
        }

        private void                    textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mStringTextEditorPanel.LabelText, StringComparison.Ordinal) == false)
            {
                mStringTextEditorPanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                    comboBox_Type_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if (mStringTextEditorPanel.TextType.Equals(comboBox_Type.Text, StringComparison.Ordinal) == false)
            {
                mStringTextEditorPanel.TextType = comboBox_Type.Text;
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
