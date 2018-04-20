// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Snapshot
{
    public partial class SnapshotRecordsManagerForm : Form
    {
        private Snapshot            mSnapshot;

        public                      SnapshotRecordsManagerForm(Snapshot aSnapshot)
        {
            mSnapshot = aSnapshot;
            InitializeComponent();
            
            if (String.IsNullOrWhiteSpace(mSnapshot.Name) == false)
            {
                Text = "Snapshot '" + mSnapshot.Name + "'";
            }

            updateForm();
        }

        #region Size

            private bool            mMaximized;
            private Size            mNormalSize;
            private Point           mNormalLocation;
            protected override void WndProc(ref Message aMessage)
            {
                if (aMessage.Msg == (int)WM.NCLBUTTONDBLCLK)
                {
                    if (mMaximized)
                    {
                        Size = mNormalSize;
                        Location = mNormalLocation;
                        mMaximized = false;
                    }
                    else
                    {
                        mNormalSize = Size;
                        mNormalLocation = Location;
                        Screen lScreen = Screen.FromControl(this);
                        Size = lScreen.WorkingArea.Size;
                        Location = lScreen.WorkingArea.Location;
                        mMaximized = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

        #endregion

        #region Update

            private DataView        mRecordsDataView;
            private DataTable       mRecordsDataTable;
            private string          mSelectedItem;
            private int[]           mColumnsWidth;

            private void            updateForm()
            {
                try
                {
                    int lRecordsCount       = mSnapshot.RecordsCount;
                    ssLabel_Records.Text    = "Records: " + StringUtils.ObjectToString(lRecordsCount);

                    if (lRecordsCount == 0)
                    {
                        GridUtils.setGridDataSource(dataGridView_Records, null, mFilter, ref mColumnsWidth, ref mRecordsDataView, ref mSelectedItem);

                        if (mRecordsDataTable != null)
                        {
                            mRecordsDataTable.Dispose();
                            mRecordsDataTable = null;
                        }

                        tsButton_Filter.ToolTipText = "Filter";
                    }
                    else
                    {
                        dataGridView_Records.SuspendLayout();
                        //======================================
                        try
                        {
                            var lDataTable = mSnapshot.RecordsData;
                            GridUtils.setGridDataSource(dataGridView_Records, lDataTable, mFilter, ref mColumnsWidth, ref mRecordsDataView, ref mSelectedItem);

                            if (mRecordsDataTable != null)
                            {
                                mRecordsDataTable.Dispose();
                            }
                            mRecordsDataTable = lDataTable;
                        }
                        finally
                        {
                            //======================================
                            dataGridView_Records.ResumeLayout();
                        }

                        if (tsButton_Filter.Checked)
                        {
                            tsButton_Filter.ToolTipText = "Filter (" + dataGridView_Records.RowCount + ")";
                        }
                        else
                        {
                            tsButton_Filter.ToolTipText = "Filter";
                        }
                    }

                    FormUtils.CursorJerk();
                }
                catch (Exception lExc)
                {
                    Log.Error("Error updating list of records in Snapshot '" + mSnapshot.Name + "' records manager. " + lExc.Message, lExc.ToString());
                }
            }

            private void            updateButtons()
            {
                bool lSelected              = (dataGridView_Records.SelectedRows.Count >= 1);
                tsButton_Delete.Enabled     = lSelected;
                tsButton_Setup.Enabled      = lSelected;
                tsButton_UpdateV.Enabled    = lSelected;
            }

            private void            dataGridView_Records_DataBindingComplete(object aSender, DataGridViewBindingCompleteEventArgs aEventArgs)
            {
                try // Иначе иногда исключение: Object reference not set to an instance of an object.
                {
                    GridUtils.restoreColumnsWidth(dataGridView_Records, mColumnsWidth);
                }
                catch { }    
            }

            private void            dataGridView_Records_CellMouseDown(object aSender, DataGridViewCellMouseEventArgs aEventArgs)
            {
                if (aEventArgs.RowIndex == -1)
                {
                    mColumnsWidth = GridUtils.saveColumnsWidth(dataGridView_Records, mColumnsWidth);
                }
            }

            private void            dataGridView_Records_SelectionChanged(object aSender, EventArgs aEventArgs)
            {
                updateButtons();
            }

        #endregion

        #region Filter

            private string          mFilter = "";
            private void            filterChanged(object aSender, EventArgs aEventArgs)
            {
                mColumnsWidth = GridUtils.saveColumnsWidth(dataGridView_Records, mColumnsWidth);
                tsTextBox_Name.Text = tsTextBox_Name.Text.Replace("'", "");

                if (tsButton_Filter.Checked)
                {
                    StringBuilder lFilterStr = new StringBuilder();

                    if (String.IsNullOrEmpty(tsTextBox_Name.Text) == false)
                    {
                        lFilterStr.Append("Item LIKE '*");
                        lFilterStr.Append(GridUtils.correctFilter(tsTextBox_Name.Text));
                        lFilterStr.Append("*'");
                    }

                    mFilter = lFilterStr.ToString();
                }
                else
                {
                    mFilter = "";
                }

                updateForm();
            }

            private void            textBox_KeyPress(object aSender, KeyPressEventArgs aEventArgs)
            {
                if (aEventArgs.KeyChar == 39)
                {
                    aEventArgs.Handled = true;
                }
            }

        #endregion

        #region Buttons

            private void            tsButton_Add_Click(object aSender, EventArgs aEventArgs)
            {
                try
                {
                    int lItemHandle = mSnapshot.ItemBrowser.getItemHandleByForm(-1, this);
                    if (lItemHandle != -1)
                    {
                        object lValue = mSnapshot.ItemBrowser.readItemOrInitValue(lItemHandle);

                        using (var lSetupFrom = new AddEditRecordForm(mSnapshot.ItemBrowser, lItemHandle, lValue))
                        {
                            lSetupFrom.ShowDialog(this);
                            if (lSetupFrom.DialogResult == DialogResult.OK)
                            {
                                lItemHandle = lSetupFrom.ItemHandle;
                                lValue      = lSetupFrom.Value;
                                mSnapshot.addRecord(lItemHandle, lValue);

                                mSelectedItem = mSnapshot.ItemBrowser.getItemNameByHandle(lItemHandle);
                                updateForm();
                            }
                        }
                    }
                }
                catch(Exception lExc)
                {
                    Log.Error("Error while user was adding new record to snapshot '"
                                + mSnapshot.Name + "'. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }

            private void            tsButton_AddWizard_Click(object aSender, EventArgs aEventArgs)
            {
                try
                { 
                    int[] lHandles = mSnapshot.ItemBrowser.getItemHandlesByForm(this);
                    if(lHandles.Length > 0)
                    {
                        Cursor          = Cursors.WaitCursor;
                        bool? lReplace  = null;

                        try
                        {
                            for(int i = 0; i < lHandles.Length; i++)
                            {
                                if(mSnapshot.isRecordExists(lHandles[i]))
                                {
                                    if (lReplace == null)
                                    {
                                        lReplace = (QuestionForm.askQuestion("Replace existing records? ", this) == DialogResult.Yes);
                                    }

                                    if (lReplace == true)
                                    {
                                        mSnapshot.deleteRecord(lHandles[i]);
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                mSnapshot.addRecord(lHandles[i], mSnapshot.ItemBrowser.readItemOrInitValue(lHandles[i]));
                            }

                            updateForm();
                        }
                        finally
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                }
                catch (Exception lExc)
                {
                    Cursor = Cursors.Arrow;
                    Log.Error("Error while user was adding new records to snapshot '"
                                + mSnapshot.Name + "'. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }

            private void            tsButton_Delete_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = dataGridView_Records.SelectedRows.Count;
                if (lCount > 0)
                {
                    try
                    {
                        if (QuestionForm.askQuestion("Delete " + lCount.ToString() + " record(s)?", this) == DialogResult.Yes)
                        {
                            for (int i = 0; i < lCount; i++)
                            {
                                mSnapshot.deleteRecord(dataGridView_Records.SelectedRows[i].Cells[0].Value.ToString());
                            }
                            updateForm();
                        }
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Error while user was deleting record(s) from snapshot '"
                                    + mSnapshot.Name + "'. " + lExc.Message, lExc.ToString());
                        MessageForm.showMessage(lExc.Message, this);
                    }
                }
            }

            private void            SnapshotRecordsManagerForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
            {
                if (aEventArgs.KeyCode == Keys.Escape)
                {
                    Close();
                }

                if (aEventArgs.KeyCode == Keys.Delete)
                {
                    tsButton_Delete_Click(this, EventArgs.Empty);
                }
            }

            private void            tsButton_Setup_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = dataGridView_Records.SelectedRows.Count;
                if (lCount > 0)
                {
                    try
                    {
                        var lItemName = dataGridView_Records.SelectedRows[0].Cells[0].Value.ToString();
                        using (var lSetupFrom = new AddEditRecordForm(mSnapshot.ItemBrowser, 
                            mSnapshot.ItemBrowser.getItemHandleByName(lItemName), mSnapshot.getRecordValue(lItemName)))
                        {
                            lSetupFrom.ShowDialog(this);
                            if (lSetupFrom.DialogResult == DialogResult.OK)
                            {
                                mSnapshot.changeRecord(lItemName, lSetupFrom.ItemName, lSetupFrom.Value);

                                mSelectedItem = lSetupFrom.ItemName;
                                updateForm();
                            }
                        }
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Error while user was configuring record of snapshot '"
                                    + mSnapshot.Name + "'. " + lExc.Message, lExc.ToString());
                        MessageForm.showMessage(lExc.Message, this);
                    }
                }
            }

            private void            dataGridView_Records_CellDoubleClick(object aSender, DataGridViewCellEventArgs aEventArgs)
            {
                tsButton_Setup_Click(aSender, EventArgs.Empty);
            }

            private void            tsButton_UpdateV_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = dataGridView_Records.SelectedRows.Count;
                if (lCount > 0)
                {
                    string lItem;
                    object lValue;

                    try
                    {
                        if (QuestionForm.askQuestion("Update values for " + lCount.ToString() + " record(s)?", this) == DialogResult.Yes)
                        {
                            for (int i = 0; i < lCount; i++)
                            {
                                lItem   = dataGridView_Records.SelectedRows[i].Cells[0].Value.ToString();
                                lValue  = mSnapshot.ItemBrowser.readItemOrInitValue(mSnapshot.ItemBrowser.getItemHandleByName(lItem));
                                mSnapshot.changeRecord(lItem, lItem, lValue);
                            }
                            updateForm();
                        }
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Error while user was updating values for record(s) of snapshot '"
                                    + mSnapshot.Name + "'. " + lExc.Message, lExc.ToString());
                        MessageForm.showMessage(lExc.Message, this);
                    }
                }
            }

            private void            tsButton_SelectAll_Click(object aSender, EventArgs aEventArgs)
            {
                dataGridView_Records.SelectAll();
            }

            private void            tsButton_SelectNone_Click(object aSender, EventArgs aEventArgs)
            {
                dataGridView_Records.ClearSelection();
            }

        #endregion

        #region Dispose

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (mRecordsDataView != null)
                    {
                        dataGridView_Records.DataSource = null;
                        mRecordsDataView.Dispose();
                        mRecordsDataView = null;
                    }

                    if (mRecordsDataTable != null)
                    {
                        mRecordsDataTable.Dispose();
                        mRecordsDataTable = null;
                    }

                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }

        #endregion
    }
}
