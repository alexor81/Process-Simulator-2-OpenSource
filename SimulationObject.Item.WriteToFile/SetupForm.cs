using API;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;
using Utils.SpecialControls;

namespace SimulationObject.Item.WriteToFile
{
    public partial class SetupForm : Form
    {
        private WriteToFile     mWriteToFile;
        private IItemBrowser    mBrowser;
        private HashSet<int>    mCloneItems = new HashSet<int>();
        private DataTable       mDataTable;

        public                  SetupForm(WriteToFile aWriteToFile, IItemBrowser aBrowser)
        {
            mWriteToFile    = aWriteToFile;
            mBrowser        = aBrowser;
            InitializeComponent();

            if (mWriteToFile.mOnItemHandle != -1)
            {
                itemEditBox_On.ItemName     = mBrowser.getItemNameByHandle(mWriteToFile.mOnItemHandle);
                itemEditBox_On.ItemToolTip  = mBrowser.getItemToolTipByHandle(mWriteToFile.mOnItemHandle);
            }

            buttonEdit_Path.Text            = mWriteToFile.mPath;
            textBox_FileName.Text           = mWriteToFile.mFileName;
            checkBox_WriteChanges.Checked   = mWriteToFile.mWriteChangesOnly;
            textBox_Delimiter.Text          = mWriteToFile.mDelimiter;

            spinEdit_Timeout.Properties.MinValue = MiscUtils.TimeSlice;
            spinEdit_Timeout.Value = mWriteToFile.RateMS;

            for (int i = 0; i < mWriteToFile.mItems.Length; i++)
            {
                mCloneItems.Add(mWriteToFile.mItems[i]);
            }

            updateTable();
            updateButtons();
        }

        private void            updateTable()
        {
            var lDataTable = new DataTable();
            lDataTable.Columns.Add("Item");

            foreach(int lHandle in mCloneItems)
            { 
                lDataTable.Rows.Add(mBrowser.getItemNameByHandle(lHandle));
            }

            var lSort = dataGridView_Items.SortOrder;
            dataGridView_Items.DataSource = lDataTable;
            if (lSort != SortOrder.None)
            {
                if (lSort == SortOrder.Ascending)
                {
                    dataGridView_Items.Sort(dataGridView_Items.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
                }
                else
                {
                    dataGridView_Items.Sort(dataGridView_Items.Columns[0], System.ComponentModel.ListSortDirection.Descending);
                }
            }

            if (mDataTable != null)
            {
                mDataTable.Dispose();
            }
            mDataTable = lDataTable;
        }

        private void            updateButtons()
        {
            tsButton_Delete.Enabled = (mDataTable.Rows.Count > 0) && (dataGridView_Items.SelectedRows.Count > 0);
        }

        private void            dataGridView_Items_SelectionChanged(object aSender, EventArgs aEventArgs)
        {
            updateButtons();
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void            buttonEdit_Path_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            using (FolderBrowserDialog lDialog = new FolderBrowserDialog())
            {
                if(String.IsNullOrWhiteSpace(buttonEdit_Path.Text) == false)
                {
                    if(Directory.Exists(buttonEdit_Path.Text))
                    {
                        lDialog.SelectedPath = buttonEdit_Path.Text;
                    }
                    else
                    {
                        lDialog.SelectedPath = MiscUtils.ProjectPath;
                    }
                }
                else
                {
                    lDialog.SelectedPath = MiscUtils.ProjectPath;
                }

                if(lDialog.ShowDialog(this) == DialogResult.OK)
                {
                    buttonEdit_Path.Text = lDialog.SelectedPath;   
                }    
            }
        }

        private void            tsButton_Add_Click(object aSender, EventArgs aEventArgs)
        {
            int lHandle = mBrowser.getItemHandleByForm(-1, this);

            if(lHandle != -1)
            {
                try
                { 
                    if(mCloneItems.Contains(lHandle))
                    {
                        throw new ArgumentException("Item already exists. ");
                    }

                    mCloneItems.Add(lHandle);

                    updateTable();
                    updateButtons();
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was adding Item. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void            tsButton_AddWizard_Click(object aSender, EventArgs aEventArgs)
        {
            int[] lHandles = mBrowser.getItemHandlesByForm(this);

            if (lHandles.Length > 0)
            {
                int lDoubling = 0;

                try
                {
                    for (int i = 0; i < lHandles.Length; i++)
                    {
                        if (mCloneItems.Contains(lHandles[i]))
                        {
                            lDoubling = lDoubling + 1;
                        }
                        else
                        {
                            mCloneItems.Add(lHandles[i]);
                        }

                        updateTable();
                        updateButtons();
                    }

                    if (lDoubling > 0)
                    {
                        throw new ArgumentException(lDoubling.ToString() + " from " + lHandles.Length + " Items already exist. ");
                    }
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was adding Items. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void            tsButton_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            int lCount = dataGridView_Items.SelectedRows.Count;
            if (lCount > 0)
            {
                try
                {
                    if (QuestionForm.askQuestion("Delete " + lCount.ToString() + " Item(s)?", this) == DialogResult.Yes)
                    {
                        HashSet<int> lDeleteHandles = new HashSet<int>();

                        for (int i = 0; i < lCount; i++)
                        {
                            lDeleteHandles.Add(mBrowser.getItemHandleByName(dataGridView_Items.SelectedRows[i].Cells[0].Value.ToString()));
                        }

                        HashSet<int> lNewHandles = new HashSet<int>();
                        foreach(int lHandle in mCloneItems)
                        {
                            if(lDeleteHandles.Contains(lHandle) == false)
                            {
                                lNewHandles.Add(lHandle);
                            }
                        }

                        mCloneItems = lNewHandles;

                        updateTable();
                        updateButtons();
                    }
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was deleting Item(s). " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void            SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if(tabControl.SelectedIndex == 1 && aEventArgs.KeyCode == Keys.Delete)
            {
                tsButton_Delete_Click(this, EventArgs.Empty);
            }
        }

        private void            dataGridView_Items_CellErrorTextNeeded(object aSender, DataGridViewCellErrorTextNeededEventArgs aEventArgs)
        {
            var lCell           = dataGridView_Items.Rows[aEventArgs.RowIndex].Cells[aEventArgs.ColumnIndex];
            lCell.ToolTipText   = mBrowser.getItemToolTipByHandle(mBrowser.getItemHandleByName(lCell.Value.ToString()));
        }

        private void            okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(buttonEdit_Path.Text) == false)
                    {
                        if (Directory.Exists(buttonEdit_Path.Text) == false)
                        {
                            throw new ArgumentException("Path does not exist. ");
                        }
                    }

                    if(String.IsNullOrWhiteSpace(textBox_FileName.Text))
                    {
                        throw new ArgumentException("File name is empty. ");
                    }

                    mWriteToFile.mOnItemHandle      = mBrowser.getItemHandleByName(itemEditBox_On.ItemName);
                    mWriteToFile.mPath              = buttonEdit_Path.Text;
                    mWriteToFile.mFileName          = textBox_FileName.Text;
                    mWriteToFile.mWriteChangesOnly  = checkBox_WriteChanges.Checked;
                    mWriteToFile.RateMS             = (int)spinEdit_Timeout.Value;
                    mWriteToFile.mDelimiter         = textBox_Delimiter.Text;
                    mWriteToFile.initItems(mCloneItems.ToArray());
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (mDataTable != null)
                {
                    mDataTable.Dispose();
                    mDataTable = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
