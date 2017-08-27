// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils.DialogForms;

namespace Utils.Panels.BooleanTrend
{
    public partial class SetupForm : Form
    {
        private BooleanTrendPanel   mTrend;

        public                      SetupForm(BooleanTrendPanel aTrend)
        {
            mTrend = aTrend;
            InitializeComponent();
            
            textBox_ToolTip.Text        = mTrend.LabelText;
            trackBar_TimeFrame.Value    = mTrend.TimeFrame;
            label_TimeFrame.Text        = "Time Frame: " + StringUtils.ObjectToString(trackBar_TimeFrame.Value) + " min";
            colorEdit.Color             = mTrend.TrendColor;
        }

        private void                trackBar_TimeFrame_ValueChanged(object aSender, EventArgs aEventArgse)
        {
            if (mTrend.TimeFrame != trackBar_TimeFrame.Value)
            {
                mTrend.TimeFrame = trackBar_TimeFrame.Value;
                label_TimeFrame.Text = "Time Frame: " + StringUtils.ObjectToString(trackBar_TimeFrame.Value) + " min";
            }
        }

        private void                colorEdit_ColorChanged(object aSender, EventArgs aEventArgse)
        {
            if (mTrend.TrendColor != colorEdit.Color)
            {
                mTrend.TrendColor = colorEdit.Color;
            }
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mTrend.LabelText.Equals(textBox_ToolTip.Text, StringComparison.Ordinal) == false)
            {
                mTrend.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                button_Clear_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mTrend.clear();
            }
            catch (Exception lExc)
            {
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
