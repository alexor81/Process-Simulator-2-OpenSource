// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Panels.DoubleBar
{
    public partial class SetupForm : Form
    {
        private DoubleBarPanel  mDoubleBarPanel;

        public                  SetupForm(DoubleBarPanel aDoubleBarPanel, bool aMaxMinCfg)
        {
            mDoubleBarPanel = aDoubleBarPanel;
            InitializeComponent();

            textBox_ToolTip.Text        = mDoubleBarPanel.LabelText;
            checkBox_Vertical.Checked   = mDoubleBarPanel.Vertical;
            colorEdit_Color.Color       = mDoubleBarPanel.Color;
            groupBox_Value.Enabled      = aMaxMinCfg;
            textBox_Max.Text            = StringUtils.ObjectToString(mDoubleBarPanel.MaxValue);
            textBox_Min.Text            = StringUtils.ObjectToString(mDoubleBarPanel.MinValue);  
        }

        private void            textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mDoubleBarPanel.LabelText, StringComparison.Ordinal) == false)
            {
                mDoubleBarPanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void            checkBox_Vertical_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_Vertical.Checked != mDoubleBarPanel.Vertical)
            {
                mDoubleBarPanel.Vertical = checkBox_Vertical.Checked;
            }
        }

        private void            colorEdit_Color_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Color.Color != mDoubleBarPanel.Color)
            {
                mDoubleBarPanel.Color = colorEdit_Color.Color;
            }
        }

        private void            Set_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                double lMax = StringUtils.toDouble(textBox_Max.Text);
                double lMin = StringUtils.toDouble(textBox_Min.Text);

                mDoubleBarPanel.setMaxMinValues(lMax, lMin);
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was configuring max/min value for Bar panel. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
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
