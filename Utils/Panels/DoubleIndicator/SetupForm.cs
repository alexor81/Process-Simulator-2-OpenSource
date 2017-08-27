// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;

namespace Utils.Panels.DoubleIndicator
{
    public partial class SetupForm : Form
    {
        private DoubleIndicatorPanel    mIndicator;

        public                          SetupForm(DoubleIndicatorPanel aIndicator)
        {
            mIndicator = aIndicator;
            InitializeComponent();
            
            spinEdit_Round.Value        = mIndicator.Round;
            textBox_ToolTip.Text        = mIndicator.LabelText;
            checkBox_ShowUnits.Checked  = mIndicator.ShowUnits;
            textBox_Units.Text          = mIndicator.Units;
            colorEdit_TextColor.Color   = mIndicator.TextColor;
            colorEdit_BackColor.Color   = mIndicator.BackgroundColor;
            
        }

        private void                    textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mIndicator.LabelText.Equals(textBox_ToolTip.Text, StringComparison.Ordinal) == false)
            {
                mIndicator.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                    colorEdit_TextColor_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_TextColor.Color != mIndicator.TextColor)
            {
                mIndicator.TextColor = colorEdit_TextColor.Color;
            }
        }

        private void                    colorEdit_BackColor_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_BackColor.Color != mIndicator.BackgroundColor)
            {
                mIndicator.BackgroundColor = colorEdit_BackColor.Color;
            }
        }

        private void                    checkBox_ShowUnits_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_ShowUnits.Checked != mIndicator.ShowUnits)
            {
                mIndicator.ShowUnits = checkBox_ShowUnits.Checked;
            }
            textBox_Units.Enabled = checkBox_ShowUnits.Checked;
        }

        private void                    textBox_Units_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mIndicator.Units.Equals(textBox_Units.Text, StringComparison.Ordinal) == false)
            {
                mIndicator.Units = textBox_Units.Text;
                if (String.IsNullOrWhiteSpace(textBox_Units.Text))
                {
                    textBox_Units.Text = mIndicator.Units;
                }
            }
        }

        private void                    spinEdit_Round_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            int lValue = (int)spinEdit_Round.Value;
            if (mIndicator.Round != lValue)
            {
                mIndicator.Round = lValue;
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
