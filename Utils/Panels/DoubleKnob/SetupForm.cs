// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Panels.DoubleKnob
{
    public partial class SetupForm : Form
    {
        private DoubleKnobPanel mDoubleKnobPanel;

        public                  SetupForm(DoubleKnobPanel aDoubleKnobPanel, bool aMaxMinCfg)
        {
            mDoubleKnobPanel = aDoubleKnobPanel;
            InitializeComponent();
            
            textBox_ToolTip.Text        = mDoubleKnobPanel.LabelText;
            checkBox_ReadOnly.Checked   = mDoubleKnobPanel.ReadOnly;
            colorEdit_Knob.Color        = mDoubleKnobPanel.KnobColor;
            colorEdit_Indicator.Color   = mDoubleKnobPanel.IndicatorColor;
            colorEdit_Scale.Color       = mDoubleKnobPanel.ScaleColor;
            groupBox_Value.Enabled      = aMaxMinCfg;
            textBox_Min.Text            = StringUtils.ObjectToString(mDoubleKnobPanel.MinValue);
            textBox_Max.Text            = StringUtils.ObjectToString(mDoubleKnobPanel.MaxValue);
        }

        private void            textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mDoubleKnobPanel.LabelText, StringComparison.Ordinal) == false)
            {
                mDoubleKnobPanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void            colorEdit_Knob_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Knob.Color != mDoubleKnobPanel.KnobColor)
            {
                mDoubleKnobPanel.KnobColor = colorEdit_Knob.Color;
            }
        }

        private void            colorEdit_Indicator_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Indicator.Color != mDoubleKnobPanel.IndicatorColor)
            {
                mDoubleKnobPanel.IndicatorColor = colorEdit_Indicator.Color;
            }
        }

        private void            colorEdit_Scale_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Scale.Color != mDoubleKnobPanel.ScaleColor)
            {
                mDoubleKnobPanel.ScaleColor = colorEdit_Scale.Color;
            }
        }

        private void            checkBox_ReadOnly_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_ReadOnly.Checked != mDoubleKnobPanel.ReadOnly)
            {
                mDoubleKnobPanel.ReadOnly = checkBox_ReadOnly.Checked;
            }
        }

        private void            Set_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                double lMax = StringUtils.toDouble(textBox_Max.Text);
                double lMin = StringUtils.toDouble(textBox_Min.Text);
                mDoubleKnobPanel.setMaxMinValues(lMax, lMin);
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was configuring max/min value for Knob panel. " + lExc.Message, lExc.ToString());
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
