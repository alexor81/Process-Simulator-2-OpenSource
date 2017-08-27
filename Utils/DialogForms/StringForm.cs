// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.DialogForms
{
    public partial class StringForm : Form
    {
        private static StringForm   mStringForm;

        private static bool         mNoQuote = false;

        public static string        getString(string aString, IWin32Window aOwner, string aCaption)
        {
            if (mStringForm == null)
            {
                mStringForm = new StringForm();
            }

            mStringForm.Text                = aCaption;
            mStringForm.textBox_Value.Text  = aString;
            mStringForm.textBox_Value.Select();

            if (mStringForm.ShowDialog(aOwner) == DialogResult.OK)
            {
                return mStringForm.textBox_Value.Text;
            }
            else
            {
                return null;
            }
        }

        public static string        getString(string aString, IWin32Window aOwner, string aCaption, bool aNoQuote)
        {
            mNoQuote    = aNoQuote;
            var lResult = getString(aString, aOwner, aCaption);
            mNoQuote    = false;

            return lResult;
        }

        private                     StringForm()
        {
            InitializeComponent();
        }

        private void                textBox_Value_KeyPress(object aSender, KeyPressEventArgs aEventArgs)
        {
            if (mNoQuote)
            {
                if (aEventArgs.KeyChar == 39)
                {
                    aEventArgs.Handled = true;
                }
            }
        }

        private void                textBox_Value_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mNoQuote)
            {
                textBox_Value.Text = textBox_Value.Text.Replace("'", "");
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                StringForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                StringForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
