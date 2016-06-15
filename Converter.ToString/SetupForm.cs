using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;

namespace Converter.ToString
{
    public partial class SetupForm : Form
    {
        private Converter mString;

        public          SetupForm(Converter aString)
        {
            mString = aString;
            InitializeComponent();

            okCancelButton.setOkOnlyStyle();

            comboBox_Type.Items.AddRange(StringUtils.TypesNames);

            comboBox_Type.SelectedIndex = StringUtils.getIndexByType(mString.mType);
            checkBox_Array.Checked      = mString.mArray;
            checkBox_Reverse.Checked    = mString.mReverse;
        }

        private void    okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mString.mType       = StringUtils.getTypeByIndex(comboBox_Type.SelectedIndex);
                mString.mArray      = checkBox_Array.Checked;
                mString.mReverse    = checkBox_Reverse.Checked;

                Close();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void    SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
