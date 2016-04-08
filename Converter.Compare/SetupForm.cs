using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;

namespace Converter.Compare
{
    public partial class SetupForm : Form
    {
        private Converter   mCompare;

        public              SetupForm(Converter aCompare)
        {
            mCompare = aCompare;
            InitializeComponent();

            okCancelButton.setOkOnlyStyle();
            comboBox_Operation.Items.AddRange(ValuesCompare.Operations);
            comboBox_Operation.SelectedIndex    = mCompare.mValuesCompare.OperationNumber;
            textBox_Value.Text                  = StringUtils.ObjectToString(mCompare.mValue);
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            double lValue;

            try
            {
                lValue = StringUtils.toDouble(textBox_Value.Text);
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
                return;
            }

            mCompare.mValuesCompare.OperationNumber = comboBox_Operation.SelectedIndex;
            mCompare.mValue                         = lValue;

            Close();
        }

        private void        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
