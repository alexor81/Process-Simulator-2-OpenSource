// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;

namespace Converter.ToString
{
    public partial class SetupForm : Form
    {
        private Converter   mString;

        public              SetupForm(Converter aString)
        {
            mString = aString;
            InitializeComponent();

            comboBox_Type.Items.AddRange(StringUtils.TypesNames);

            comboBox_Type.SelectedIndex = StringUtils.getIndexByType(mString.mType);
            checkBox_Array.Checked      = mString.mArray;
            checkBox_Reverse.Checked    = mString.mReverse;
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                if (okCancelButton.DialogResult == DialogResult.OK)
                {
                    mString.mType       = StringUtils.getTypeByIndex(comboBox_Type.SelectedIndex);
                    mString.mArray      = checkBox_Array.Checked;
                    mString.mReverse    = checkBox_Reverse.Checked;
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
