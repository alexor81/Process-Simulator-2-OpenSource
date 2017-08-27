// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Panels.DoubleMeter
{
    public partial class SetupForm : Form
    {
        private DoubleMeterPanel    mDoubleMeter;

        public                      SetupForm(DoubleMeterPanel aDoubleMeter, bool aMaxMinCfg)
        {
            mDoubleMeter = aDoubleMeter;
            InitializeComponent();
            
            textBox_ToolTip.Text    = mDoubleMeter.LabelText;
            colorEdit_Body.Color    = mDoubleMeter.BodyColor;
            colorEdit_Needle.Color  = mDoubleMeter.NeedleColor;
            colorEdit_Scale.Color   = mDoubleMeter.ScaleColor;
            groupBox_Value.Enabled  = aMaxMinCfg;
            textBox_Min.Text        = StringUtils.ObjectToString(mDoubleMeter.MinValue);
            textBox_Max.Text        = StringUtils.ObjectToString(mDoubleMeter.MaxValue);
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mDoubleMeter.LabelText, StringComparison.Ordinal) == false)
            {
                mDoubleMeter.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                Set_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                double lMax = StringUtils.toDouble(textBox_Max.Text);
                double lMin = StringUtils.toDouble(textBox_Min.Text);
                mDoubleMeter.setMaxMinValues(lMax, lMin);
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was configuring max/min value for Meter panel. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                colorEdit_Body_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Body.Color != mDoubleMeter.BodyColor)
            {
                mDoubleMeter.BodyColor = colorEdit_Body.Color;
            }
        }

        private void                colorEdit_Needle_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Needle.Color != mDoubleMeter.NeedleColor)
            {
                mDoubleMeter.NeedleColor = colorEdit_Needle.Color;
            }
        }

        private void                colorEdit_Scale_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Scale.Color != mDoubleMeter.ScaleColor)
            {
                mDoubleMeter.ScaleColor = colorEdit_Scale.Color;
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
