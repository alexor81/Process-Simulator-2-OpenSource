// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;

namespace Converter.Scale
{
    public partial class SetupForm : Form
    {
        private ValueScale      mValueScale;

        public                  SetupForm(ValueScale aValueScale)
        {
            mValueScale = aValueScale;
            InitializeComponent();

            textBox_InMax.Text  = StringUtils.ObjectToString(mValueScale.InMax);
            textBox_InMin.Text  = StringUtils.ObjectToString(mValueScale.InMin);
            textBox_OutMax.Text = StringUtils.ObjectToString(mValueScale.OutMax);
            textBox_OutMin.Text = StringUtils.ObjectToString(mValueScale.OutMin);
        }

        private void            okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                if (okCancelButton.DialogResult == DialogResult.OK)
                {
                    double lInMax   = StringUtils.toDouble(textBox_InMax.Text);
                    double lInMin   = StringUtils.toDouble(textBox_InMin.Text);
                    double lOutMax  = StringUtils.toDouble(textBox_OutMax.Text);
                    double lOutMin  = StringUtils.toDouble(textBox_OutMin.Text);

                    mValueScale.setProperties(lInMax, lInMin, lOutMax, lOutMin);
                }

                Close();
            }
            catch (Exception lExc)
            {
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
