// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using Siemens.Simatic.Simulation.Runtime;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.S7PLCSimAdv2
{
    public partial class TagBrowserForm : Form
    {
        private bool                mFirstTime = true;
        private IInstance           mPLC;
        private STagInfo[]          mTags;
        private int[]               mColumnsWidth;
        private DataTable           mDataTable;
        private DataView            mDataView;

        public                      TagBrowserForm(IInstance aPLC)
        {
            mPLC = aPLC;
            InitializeComponent();
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
                        Size        = mNormalSize;
                        Location    = mNormalLocation;
                        mMaximized  = false;
                    }
                    else
                    {
                        mNormalSize     = Size;
                        mNormalLocation = Location;
                        Screen lScreen  = Screen.FromControl(this);
                        Size            = lScreen.WorkingArea.Size;
                        Location        = lScreen.WorkingArea.Location;
                        mMaximized      = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

        #endregion

        #region Filter

            private string          mFilter = "";
            private void            filterChanged(object aSender, EventArgs aEventArgs)
            {
                mColumnsWidth           = GridUtils.saveColumnsWidth(dataGridView_Tags, mColumnsWidth);
                tsTextBox_Name.Text     = tsTextBox_Name.Text.Replace("'", "");

                string lSelect;
                if (dataGridView_Tags.SelectedRows.Count == 0)
                {
                    lSelect = "";
                }
                else
                {
                    lSelect = dataGridView_Tags.SelectedRows[0].Cells[0].Value.ToString();
                }

                if (tsButton_Filter.Checked)
                {
                    StringBuilder lFilterStr = new StringBuilder();
                    
                    if (tsButton_I.Checked || tsButton_Q.Checked || 
                        tsButton_M.Checked || tsButton_DB.Checked ||
                        tsButton_C.Checked || tsButton_T.Checked)
                    {
                        lFilterStr.Append("(");
                        if (tsButton_I.Checked)
                        {
                            lFilterStr.Append("Area = 'Input'");
                        }

                        if (tsButton_Q.Checked)
                        {
                            if (lFilterStr.Length > 1)
                            {
                                lFilterStr.Append(" OR ");
                            }
                            lFilterStr.Append("Area = 'Output'");
                        }

                        if (tsButton_M.Checked)
                        {
                            if (lFilterStr.Length > 1)
                            {
                                lFilterStr.Append(" OR ");
                            }
                            lFilterStr.Append("Area = 'Marker'");
                        }

                        if (tsButton_DB.Checked)
                        {
                            if (lFilterStr.Length > 1)
                            {
                                lFilterStr.Append(" OR ");
                            }
                            lFilterStr.Append("Area = 'DataBlock'");
                        }

                        if (tsButton_C.Checked)
                        {
                            if (lFilterStr.Length > 1)
                            {
                                lFilterStr.Append(" OR ");
                            }
                            lFilterStr.Append("Area = 'Counter'");
                        }

                        if (tsButton_T.Checked)
                        {
                            if (lFilterStr.Length > 1)
                            {
                                lFilterStr.Append(" OR ");
                            }
                            lFilterStr.Append("Area = 'Timer'");
                        }

                        lFilterStr.Append(")");
                    }


                    if (String.IsNullOrEmpty(tsTextBox_Name.Text) == false)
                    {
                        if (lFilterStr.Length != 0)
                        {
                            lFilterStr.Append(" AND ");
                        }

                        lFilterStr.Append("Name LIKE '*");
                        lFilterStr.Append(GridUtils.correctFilter(tsTextBox_Name.Text));
                        lFilterStr.Append("*'");
                    }

                    mFilter = lFilterStr.ToString();
                }
                else
                {
                    mFilter = "";
                }

                mDataView.RowFilter = mFilter;
                updateStatusBar();

                if (String.IsNullOrWhiteSpace(lSelect) == false)
                {
                    var lRow = GridUtils.findRow(dataGridView_Tags, 0, lSelect);
                    if (lRow != -1)
                    {
                        dataGridView_Tags.Rows[lRow].Selected = true;
                        try // Иначе в свёрнутом виде ругается: No room is available to display rows
                        {
                            dataGridView_Tags.FirstDisplayedScrollingRowIndex = lRow;
                        }
                        catch { }
                    }
                }
            }

            private void            textBox_KeyPress(object aSender, KeyPressEventArgs aEventArgs)
            {
                if (aEventArgs.KeyChar == 39)
                {
                    aEventArgs.Handled = true;
                }
            }

        #endregion

        private void                readTags()
        {
            Cursor = Cursors.WaitCursor;
            dataGridView_Tags.SuspendLayout();
            //================================
            try
            {
                try
                {
                    mPLC.UpdateTagList();
                    mTags = mPLC.TagInfos;
                }
                catch (SimulationRuntimeException lExc)
                {
                    throw new InvalidOperationException(Connection.ErrorCodeMessage(lExc.RuntimeErrorCode), lExc);
                }

                DataTable lTable = new DataTable();
                lTable.Columns.Add("Name");
                lTable.Columns.Add("Area");
                lTable.Columns.Add("Type");

                foreach(var lTag in mTags)
                {
                    if (lTag.PrimitiveDataType == EPrimitiveDataType.Struct) continue;
                    if (lTag.PrimitiveDataType == EPrimitiveDataType.Unspecific) continue;
                    if (lTag.Dimension.Length > 0) continue;

                    lTable.Rows.Add(lTag.Name, lTag.Area, lTag.PrimitiveDataType);
                }

                string lSelect = "";
                GridUtils.setGridDataSource(dataGridView_Tags, lTable, mFilter, ref mColumnsWidth, ref mDataView, ref lSelect);

                if (mDataTable != null)
                {
                    mDataTable.Dispose();
                                
                }
                mDataTable = lTable;
            }
            catch (Exception lExc)
            {
                Log.Error("Error getting Tags from PLC '" + mPLC.Name + "'. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
            finally
            {
                //================================
                Cursor = Cursors.Default;
                dataGridView_Tags.ResumeLayout();

                updateStatusBar();
            }
        }

        private void                updateStatusBar()
        {
            if (mDataTable != null)
            {
                tsStatusLabel_Total.Text    = "Total: " + mDataTable.Rows.Count.ToString();
                tsStatusLabel_Filtered.Text = "Filtered: " + dataGridView_Tags.Rows.Count;
            }
            else
            {
                tsStatusLabel_Total.Text    = "Total: 0";
                tsStatusLabel_Filtered.Text = "Filtered: 0";
            }
        }

        private void                TagBrowserForm_Load(object aSender, EventArgs aEventArgs)
        {
            if (mFirstTime)
            {
                mFirstTime = false;
                readTags();
            }
        }

        private void                toolStripButton_Refresh_Click(object aSender, EventArgs aEventArgs)
        {
            readTags();
        }

        private void                dataGridView_Tags_CellMouseDown(object aSender, DataGridViewCellMouseEventArgs aEventArgs)
        {
            if (aEventArgs.RowIndex == -1)
            {
                mColumnsWidth = GridUtils.saveColumnsWidth(dataGridView_Tags, mColumnsWidth);
            }
        }

        private void                dataGridView_Tags_DataBindingComplete(object aSender, DataGridViewBindingCompleteEventArgs aEventArgs)
        {
            try // Иначе иногда исключение: Object reference not set to an instance of an object.
            {
                GridUtils.restoreColumnsWidth(dataGridView_Tags, mColumnsWidth);
            }
            catch { }  
        }

        private void                dataGridView_Tags_CellMouseDoubleClick(object aSender, DataGridViewCellMouseEventArgs aEventArgs)
        {
            if (aEventArgs.RowIndex >= 0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void                dataGridView_Tags_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Enter)
            {
                aEventArgs.SuppressKeyPress = true;
                DialogResult                = DialogResult.OK;
            }
        }

        private void                TagBrowserForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        public string               TagName
        {
            get
            {
                if (dataGridView_Tags.SelectedRows.Count == 0)
                {
                    return "";
                }
                else
                {
                    return dataGridView_Tags.SelectedRows[0].Cells[0].Value.ToString();
                }
            }
        }

        #region Dispose

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    mPLC = null; 

                    if (mDataView != null)
                    {
                        dataGridView_Tags.DataSource = null;
                        mDataView.Dispose();
                        mDataView = null;
                    }

                    if (mDataTable != null)
                    {
                        mDataTable.Dispose();
                        mDataTable = null;
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
