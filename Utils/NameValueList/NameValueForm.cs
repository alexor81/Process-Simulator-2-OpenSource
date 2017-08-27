// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils.DialogForms;

namespace Utils.NameValueList
{
    public partial class NameValueForm : Form
    {
        private NameValueHolder         mHolder;

        public                          NameValueForm(NameValueHolder aHolder, string aText)
        {
            mHolder = aHolder;
            Text    = aText;
            InitializeComponent();
            
            updateForm();
        }

        private void                    updateForm()
        {
            int lSelectedIndex = -1;
            if(dataGridView_RB.SelectedRows.Count > 0)
            {
                lSelectedIndex = dataGridView_RB.SelectedRows[0].Index;
            }

            dataGridView_RB.Rows.Clear();

            if (mHolder.Count > 0)
            {
                object lValue;
                string[] lNames = mHolder.Names;
                for (int i = 0; i < lNames.Length; i++)
                {
                    lValue = mHolder.getValue(lNames[i]);
                    dataGridView_RB.Rows.Add(lNames[i], StringUtils.ObjectToString(lValue), lValue.GetType().Name);
                }

                if(lSelectedIndex > -1 && lSelectedIndex < dataGridView_RB.RowCount)
                {
                    dataGridView_RB.Rows[lSelectedIndex].Selected = true;
                }
            }

            dataGridView_RB.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_RB.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_RB.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            updateButtons();
        }

        private void                    updateButtons()
        {
            bool lExist                 = (dataGridView_RB.RowCount > 0);
            bool lMore1                 = (dataGridView_RB.RowCount > 1);
            tsButton_Delete.Enabled     = lExist;
            tsButton_Modify.Enabled     = lExist;
            tsButton_CopyAll.Enabled    = lExist;
            tsButton_Paste.Enabled      = (Clipboard.isEmpty == false);
            tsButton_Up.Enabled         = lMore1 && (dataGridView_RB.SelectedRows.Count == 1) && (dataGridView_RB.SelectedRows[0].Index > 0);
            tsButton_Down.Enabled       = lMore1 && (dataGridView_RB.SelectedRows.Count == 1) && (dataGridView_RB.SelectedRows[0].Index < dataGridView_RB.RowCount - 1);
        }

        private void                    dataGridView_RB_SelectionChanged(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_RB.SelectedRows.Count != 0)
            {
                string lName            = dataGridView_RB.SelectedRows[0].Cells[0].Value.ToString();
                textBox_Name.Text       = lName;
                mValue                  = mHolder.getValue(lName);
                buttonEdit_Value.Text   = StringUtils.ObjectToString(mValue);
            }

            updateButtons();
        }

        private object                  mValue = 0;
        private void                    buttonEdit_Value_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            try
            {
                object lValue = ValueForm.getValue(mValue, this);
                if (lValue != null)
                {
                    mValue                  = lValue;
                    buttonEdit_Value.Text   = StringUtils.ObjectToString(lValue);
                }
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    tsButton_Add_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mHolder.add(textBox_Name.Text, mValue, false);
                updateForm();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    tsButton_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mHolder.delete(textBox_Name.Text);
                updateForm();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    tsButton_Modify_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mHolder.modify(dataGridView_RB.SelectedRows[0].Cells[0].Value.ToString(), textBox_Name.Text, mValue);
                updateForm();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    tsButton_CopyAll_Click(object aSender, EventArgs aEventArgs)
        {
            Clipboard.clear();
            if (mHolder.Count > 0)
            {
                string[] lNames = mHolder.Names;
                for (int i = 0; i < lNames.Length; i++)
                {
                    Clipboard.add(lNames[i], mHolder.getValue(lNames[i]));
                }
            }
            updateForm();
        }

        private void                    tsButton_Paste_Click(object aSender, EventArgs aEventArgs)
        {
            string[] lNames;
            object[] lValues;

            Clipboard.get(out lNames, out lValues);

            for (int i = 0; i < lNames.Length; i++)
            {
                try
                {
                    mHolder.add(lNames[i], lValues[i], true);
                }
                catch(Exception lExc)
                {
                    var lResult = QuestionForm.askQuestion(lExc.Message + " Continue?", this);
                    if(lResult == DialogResult.No)
                    {
                        break;
                    }
                }
            }

            updateForm();
        }

        private void                    tsButton_Up_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                int lIndex = mHolder.moveUp(textBox_Name.Text);
                updateForm();
                dataGridView_RB.Rows[lIndex].Selected = true;
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    tsButton_Down_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                int lIndex = mHolder.moveDown(textBox_Name.Text);
                updateForm();
                dataGridView_RB.Rows[lIndex].Selected = true;
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void                    SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}