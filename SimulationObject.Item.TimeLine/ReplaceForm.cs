// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Data;
using System.Windows.Forms;
using Utils.DialogForms;

namespace SimulationObject.Item.TimeLine
{
    public partial class ReplaceForm : Form
    {
        private IItemBrowser    mBrowser;
        private DataTable       mDataTable;
        private int[]           mUniqueItemHandles;
        private int[,]          mReplace;

        public                  ReplaceForm(int[] aUniqueItemHandles, IItemBrowser aBrowser)
        {
            mUniqueItemHandles  = aUniqueItemHandles;
            mBrowser            = aBrowser;
            InitializeComponent();

            mDataTable = new DataTable();
            mDataTable.Columns.Add("Current");
            mDataTable.Columns.Add("New");

            foreach(int lHandle in mUniqueItemHandles)
            {
                mDataTable.Rows.Add(mBrowser.getItemNameByHandle(lHandle), "");
            }

            dataGridViewItems.DataSource = mDataTable;
        }

        private void            dataGridViewItems_CellMouseDoubleClick(object aSender, DataGridViewCellMouseEventArgs aEventArgs)
        {
            if (aEventArgs.RowIndex == -1) return;

            string lItem    = mDataTable.Rows[aEventArgs.RowIndex][1].ToString();
            int lHandle     = -1;
            if (String.IsNullOrWhiteSpace(lItem) == false)
            {
                lHandle = mBrowser.getItemHandleByName(lItem);
            }

            lHandle = mBrowser.getItemHandleByForm(lHandle, this);

            if (lHandle != -1)
            {
                mDataTable.Rows[aEventArgs.RowIndex][1] = mBrowser.getItemNameByHandle(lHandle);
            }
            else
            {
                mDataTable.Rows[aEventArgs.RowIndex][1] = "";
            }
        }

        private void            dataGridViewItems_CellToolTipTextNeeded(object aSender, DataGridViewCellToolTipTextNeededEventArgs aEventArgs)
        {
            if (aEventArgs.RowIndex == -1) return;

            string lItem = mDataTable.Rows[aEventArgs.RowIndex][aEventArgs.ColumnIndex].ToString();
            if (String.IsNullOrWhiteSpace(lItem) == false)
            {
                aEventArgs.ToolTipText = mBrowser.getItemToolTipByHandle(mBrowser.getItemHandleByName(lItem));
            }
        }

        public int[,]           Replace
        {
            get { return mReplace; }
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
                    var lRows = mDataTable.Select("LEN(New) > 0 AND Current <> New");

                    if (lRows.Length > 0)
                    {
                        int lCount = lRows.Length;

                        mReplace = new int[lCount, 2];
                        for (int i = 0; i < lCount; i++)
                        {
                            mReplace[i, 0] = mBrowser.getItemHandleByName(((DataRow)lRows.GetValue(i)).ItemArray.GetValue(0).ToString());
                            mReplace[i, 1] = mBrowser.getItemHandleByName(((DataRow)lRows.GetValue(i)).ItemArray.GetValue(1).ToString());
                        }

                        for(int i = 0; i < lCount; i++)
                        {
                            for(int j = 0; j < mUniqueItemHandles.Length; j++)
                            {
                                if(mUniqueItemHandles[j] == mReplace[i,1])
                                {
                                    for(int k = 0; k < lCount; k++)
                                    {
                                        if(mUniqueItemHandles[j] == mReplace[k,0])
                                        {
                                            goto Next;
                                        }
                                    }
                                    throw new Exception("Items duplication is possible. ");
                                }
                            }

                            Next:;
                        }
                    }

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
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
