using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Converter.ToBoolean
{
    public partial class SetupForm : Form
    {
        private Converter   mBoolean;
        private object      mTrueValue;
        private object      mFalseValue;
        
        public              SetupForm(Converter aBoolean)
        {
            mBoolean = aBoolean;
            InitializeComponent();

            checkBox_Reverse.Checked        = mBoolean.mReverse;
            checkBox_TrueIfWrong.Checked    = mBoolean.mTrueIfWrong;

            mTrueValue                      = mBoolean.mTrueValue;
            buttonEdit_TrueValue.Text       = StringUtils.ObjectToString(mTrueValue);

            mFalseValue                     = mBoolean.mFalseValue;
            buttonEdit_FalseValue.Text      = StringUtils.ObjectToString(mFalseValue);
        }

        private void        buttonEdit_TrueValue_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            try
            {
                object lValue = ValueForm.getValue(mTrueValue, this);
                if (lValue != null)
                {
                    mTrueValue                  = lValue;
                    buttonEdit_TrueValue.Text   = StringUtils.ObjectToString(mTrueValue);
                }
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was editing True Value for converter. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        buttonEdit_FalseValue_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            try
            {
                object lValue = ValueForm.getValue(mFalseValue, this);
                if (lValue != null)
                {
                    mFalseValue                 = lValue;
                    buttonEdit_FalseValue.Text  = StringUtils.ObjectToString(mFalseValue);
                }
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was editing False Value for converter. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                if (okCancelButton.DialogResult == DialogResult.OK)
                {
                    mBoolean.checkValues(mTrueValue, mFalseValue);

                    mBoolean.mReverse       = checkBox_Reverse.Checked;
                    mBoolean.mTrueIfWrong   = checkBox_TrueIfWrong.Checked;

                    mBoolean.mTrueValue     = mTrueValue;
                    mBoolean.mFalseValue    = mFalseValue;
                }

                Close();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
