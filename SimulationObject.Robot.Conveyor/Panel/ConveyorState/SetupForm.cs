// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;

namespace SimulationObject.Robot.Conveyor.Panel.ConveyorState
{
    public partial class SetupForm : Form
    {
        private ConveyorStatePanel  mConveyorStatePanel;

        public                      SetupForm(ConveyorStatePanel aConveyorStatePanel)
        {
            mConveyorStatePanel = aConveyorStatePanel;
            InitializeComponent();

            textBox_ToolTip.Text        = mConveyorStatePanel.LabelText;
            comboBox_Type.SelectedItem  = mConveyorStatePanel.LayoutType;
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mConveyorStatePanel.LabelText, StringComparison.Ordinal) == false)
            {
                mConveyorStatePanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                comboBox_Type_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            string lNew = comboBox_Type.SelectedItem.ToString();
            if (lNew.Equals(mConveyorStatePanel.LayoutType, StringComparison.Ordinal) == false)
            {
                mConveyorStatePanel.LayoutType = lNew;
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
