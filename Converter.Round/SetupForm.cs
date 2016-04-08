using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;

namespace Converter.Round
{
    public partial class SetupForm : Form
    {
        private Converter   mRound;

        public              SetupForm(Converter aRound)
        {
            mRound = aRound;
            InitializeComponent();

            okCancelButton.setOkOnlyStyle();
            spinEdit_Round.Value = mRound.Round;
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mRound.Round = (int)spinEdit_Round.Value;

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
