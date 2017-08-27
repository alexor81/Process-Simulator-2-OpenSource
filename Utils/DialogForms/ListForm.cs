// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Windows.Forms;

namespace Utils.DialogForms
{
    public partial class ListForm : Form
    {
        private static ListForm mListForm;

        public static int       getItemIndex(string[] aList, int aIndex, IWin32Window aOwner, string aCaption)
        {
            if (mListForm == null)
            {
                mListForm = new ListForm();
            }

            mListForm.Text = aCaption;
            mListForm.listBox.Items.Clear();           
            mListForm.listBox.Items.AddRange(aList);
            if (aList.Length != 0 && aIndex >= 0 && aIndex < aList.Length)
            {
                mListForm.listBox.SelectedIndex = aIndex;
                mListForm.mIndex = aIndex;
            }
            else
            {
                mListForm.mIndex = -1;
            }

            mListForm.ShowDialog(aOwner);

            return mListForm.mIndex;
        }

        private int             mIndex;

        private                 ListForm()
        {
            InitializeComponent();
        }

        private void            listBox_MouseDoubleClick(object aSender, MouseEventArgs aEventArgs)
        {
            mIndex = listBox.SelectedIndex;
            Close();
        }

        private void            ListForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
