// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Panels.DoubleSlider
{
    public partial class SetupForm : Form
    {
        private DoubleSliderPanel   mDoubleSliderPanel;

        public                      SetupForm(DoubleSliderPanel aDoubleSliderPanel, bool aMaxMinCfg)
        {
            mDoubleSliderPanel          = aDoubleSliderPanel;
            InitializeComponent();
            
            textBox_ToolTip.Text        = mDoubleSliderPanel.LabelText;
            colorEdit_Color.Color       = mDoubleSliderPanel.NeedleColor;
            checkBox_ReadOnly.Checked   = mDoubleSliderPanel.ReadOnly;
            groupBox_Value.Enabled      = aMaxMinCfg;
            textBox_Min.Text            = StringUtils.ObjectToString(mDoubleSliderPanel.MinValue);
            textBox_Max.Text            = StringUtils.ObjectToString(mDoubleSliderPanel.MaxValue);
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mDoubleSliderPanel.LabelText, StringComparison.Ordinal) == false)
            {
                mDoubleSliderPanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                colorEdit_Color_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Color.Color != mDoubleSliderPanel.NeedleColor)
            {
                mDoubleSliderPanel.NeedleColor = colorEdit_Color.Color;
            }
        }

        private void                checkBox_ReadOnly_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_ReadOnly.Checked != mDoubleSliderPanel.ReadOnly)
            {
                mDoubleSliderPanel.ReadOnly = checkBox_ReadOnly.Checked;
            }
        }

        private void                Set_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mDoubleSliderPanel.setMaxMinValues(StringUtils.toDouble(textBox_Max.Text), StringUtils.toDouble(textBox_Min.Text));
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was configuring max/min value for Slider panel. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
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
