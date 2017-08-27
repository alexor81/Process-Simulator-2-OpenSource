// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using LBSoft.IndustrialCtrls.Leds;

namespace Utils.Panels.BooleanIndicator
{
    public partial class SetupForm : Form
    {
        private BooleanIndicatorPanel   mBooleanIndicatorPanel;

        public                          SetupForm(BooleanIndicatorPanel aBooleanIndicatorPanel)
        {
            mBooleanIndicatorPanel = aBooleanIndicatorPanel;
            InitializeComponent();
            
            textBox_Text.Text = mBooleanIndicatorPanel.LabelText;
            switch(mBooleanIndicatorPanel.Shape)
            {
                case LBLed.LedStyle.Circular:       comboBox_Shape.SelectedIndex = 0; break;
                case LBLed.LedStyle.Rectangular:    comboBox_Shape.SelectedIndex = 1; break;
            }
            colorEdit_True.Color            = mBooleanIndicatorPanel.TrueColor;
            colorEdit_False.Color           = mBooleanIndicatorPanel.FalseColor;
            checkBox_Blink.Checked          = mBooleanIndicatorPanel.Blink;
        }

        private void                    textBox_Text_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_Text.Text.Equals(mBooleanIndicatorPanel.LabelText, StringComparison.Ordinal) == false)
            {
                mBooleanIndicatorPanel.LabelText = textBox_Text.Text;
            }
        }

        private void                    colorEdit_True_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_True.Color != mBooleanIndicatorPanel.TrueColor)
            {
                mBooleanIndicatorPanel.TrueColor = colorEdit_True.Color;
            }
        }

        private void                    colorEdit_False_ColorChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_False.Color != mBooleanIndicatorPanel.FalseColor)
            {
                mBooleanIndicatorPanel.FalseColor = colorEdit_False.Color;
            }
        }

        private void                    comboBox_Shape_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            LBLed.LedStyle lShape;
            if (comboBox_Shape.SelectedIndex == 0)
            {
                lShape = LBLed.LedStyle.Circular;
            }
            else
            {
                lShape = LBLed.LedStyle.Rectangular;
            }

            if (lShape != mBooleanIndicatorPanel.Shape)
            {
                mBooleanIndicatorPanel.Shape = lShape;
            }
        }

        private void                    checkBox_Blink_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mBooleanIndicatorPanel.Blink != checkBox_Blink.Checked)
            {
                mBooleanIndicatorPanel.Blink = checkBox_Blink.Checked;
            }
        }

        private void                    button_Fit_Click(object aSender, EventArgs aEventArgs)
        {
            mBooleanIndicatorPanel.fitToContent();
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
