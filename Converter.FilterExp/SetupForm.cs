using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;

namespace Converter.FilterExp
{
    public partial class SetupForm : Form
    {
        private Converter   mFilterExp;

        public              SetupForm(Converter aFilterExp)
        {
            mFilterExp = aFilterExp;
            InitializeComponent();

            okCancelButton.setOkOnlyStyle();
            textBox_Alfa.Text = StringUtils.ObjectToString(mFilterExp.Alfa);
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                double lAlfa = StringUtils.toDouble(textBox_Alfa.Text);

                if(lAlfa > 1.0D || lAlfa < 0.0D)
                {
                    throw new ArgumentException("Alfa range is  0..1.");
                }

                mFilterExp.Alfa = lAlfa;

                Close();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
