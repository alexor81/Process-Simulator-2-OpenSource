// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;
using Utils.Snapshot;
using Utils.SpecialControls;

namespace SimulationObject.Item.TimeLine
{
    public partial class SetupForm : Form
    {
        private TimeLine                    mTimeLine;
        private IItemBrowser                mBrowser;
        private List<Tuple<long, Snapshot>> mCloneSections = new List<Tuple<long, Snapshot>>();      
        private DataTable                   mDataTable;

        public                              SetupForm(TimeLine aTimeLine, IItemBrowser aBrowser)
        {
            mTimeLine   = aTimeLine;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mTimeLine.mOnItemHandle != -1)
            {
                itemEditBox_On.ItemName     = mBrowser.getItemNameByHandle(mTimeLine.mOnItemHandle);
                itemEditBox_On.ItemToolTip  = mBrowser.getItemToolTipByHandle(mTimeLine.mOnItemHandle);
            }

            checkBox_Loop.Checked = mTimeLine.Loop;

            foreach (Tuple<long, Snapshot> lSection in mTimeLine.mSections)
            {
                mCloneSections.Add(new Tuple<long, Snapshot>(lSection.Item1, lSection.Item2.Clone));
            }

            updateTable();
            updateButtons();
        }

        private void                        updateTable()
        {
            var lDataTable = new DataTable();

            lDataTable.Columns.Add("Index").DataType        = typeof(int);
            lDataTable.Columns.Add("Delay [ms]").DataType   = typeof(long);
            lDataTable.Columns.Add("Records").DataType      = typeof(int);

            int lCount = mCloneSections.Count;
            for (int i = 0; i < lCount; i++)
            {
                lDataTable.Rows.Add(i, mCloneSections[i].Item1, mCloneSections[i].Item2.RecordsCount);
            }

            dataGridView_Sections.DataSource            = lDataTable;
            dataGridView_Sections.Columns[0].SortMode   = DataGridViewColumnSortMode.NotSortable;
            dataGridView_Sections.Columns[1].SortMode   = DataGridViewColumnSortMode.NotSortable;
            dataGridView_Sections.Columns[2].SortMode   = DataGridViewColumnSortMode.NotSortable;

            if (mDataTable != null)
            {
                mDataTable.Dispose();
            }
            mDataTable = lDataTable;
        }

        private void                        updateButtons()
        {
            bool lExistSelected         = (mDataTable.Rows.Count > 0) && (dataGridView_Sections.SelectedRows.Count > 0);
            bool lOneSelected           = (dataGridView_Sections.SelectedRows.Count == 1);

            tsButton_Up.Enabled         = lExistSelected && lOneSelected && (dataGridView_Sections.SelectedRows[0].Index != 0);
            tsButton_Down.Enabled       = lExistSelected && lOneSelected && (dataGridView_Sections.SelectedRows[0].Index != (mDataTable.Rows.Count - 1));
            tsButton_Delete.Enabled     = lExistSelected;
            tsButton_Clone.Enabled      = lExistSelected && lOneSelected;
            tsButton_Delay.Enabled      = tsButton_Clone.Enabled;
            tsButton_Setup.Enabled      = tsButton_Clone.Enabled;
            tsButton_Replace.Enabled    = (mDataTable.Rows.Count > 0);
        }

        private void                        dataGridView_Sections_SelectionChanged(object aSender, EventArgs aEventArgs)
        {
            updateButtons();
        }

        private void                        ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void                        tsButton_Up_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Sections.SelectedRows.Count == 1 && dataGridView_Sections.SelectedRows[0].Index != 0)
            {
                try
                {
                    int lIndex      = dataGridView_Sections.SelectedRows[0].Index;
                    int lNewIndex   = lIndex - 1;

                    var lTuple                 = mCloneSections[lIndex];
                    mCloneSections[lIndex]     = mCloneSections[lNewIndex];
                    mCloneSections[lNewIndex]  = lTuple;

                    updateTable();
                    if (lIndex != 1)
                    {
                        dataGridView_Sections.Rows[0].Selected          = false;
                        dataGridView_Sections.Rows[lNewIndex].Selected  = true;
                    }

                    try // Иначе в свёрнутом виде ругается: No room is available to display rows
                    {
                        dataGridView_Sections.FirstDisplayedScrollingRowIndex = dataGridView_Sections.SelectedRows[0].Index;
                    }
                    catch { }

                    updateButtons();
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was moving section up. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                        tsButton_Down_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Sections.SelectedRows.Count == 1 && dataGridView_Sections.SelectedRows[0].Index != mDataTable.Rows.Count - 1)
            {
                try
                {
                    int lIndex      = dataGridView_Sections.SelectedRows[0].Index;
                    int lNewIndex   = lIndex + 1;

                    var lTuple                 = mCloneSections[lIndex];
                    mCloneSections[lIndex]     = mCloneSections[lNewIndex];
                    mCloneSections[lNewIndex]  = lTuple;

                    updateTable();
                    dataGridView_Sections.Rows[0].Selected          = false;
                    dataGridView_Sections.Rows[lNewIndex].Selected  = true;

                    try // Иначе в свёрнутом виде ругается: No room is available to display rows
                    {
                        dataGridView_Sections.FirstDisplayedScrollingRowIndex = dataGridView_Sections.SelectedRows[0].Index;
                    }
                    catch { }

                    updateButtons();
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was moving section down. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                        tsButton_Add_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                using (var lDelayForm = new DelayForm(1000))
                {
                    if (lDelayForm.ShowDialog(this) == DialogResult.OK)
                    {
                        var lTuple = new Tuple<long, Snapshot>(lDelayForm.Delay, new Snapshot("", mBrowser));
                        lTuple.Item2.setupByForm(this);
                        mCloneSections.Add(lTuple);

                        updateTable();
                        if (mDataTable.Rows.Count != 1)
                        {
                            dataGridView_Sections.Rows[0].Selected = false;
                            dataGridView_Sections.Rows[mDataTable.Rows.Count - 1].Selected = true;
                        }

                        try // Иначе в свёрнутом виде ругается: No room is available to display rows
                        {
                            dataGridView_Sections.FirstDisplayedScrollingRowIndex = dataGridView_Sections.SelectedRows[0].Index;
                        }
                        catch { }

                        updateButtons();
                    }
                }
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was adding section. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                        tsButton_Clone_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Sections.SelectedRows.Count == 1)
            {
                try
                {
                    int lIndex = dataGridView_Sections.SelectedRows[0].Index;

                    long lTime = mCloneSections[lIndex].Item1;
                    if(lTime == 0)
                    {
                        lTime = MiscUtils.TimeSlice;
                    }

                    mCloneSections.Add(new Tuple<long, Snapshot>(lTime, mCloneSections[lIndex].Item2.Clone));

                    updateTable();
                    dataGridView_Sections.Rows[0].Selected                          = false;
                    dataGridView_Sections.Rows[mDataTable.Rows.Count - 1].Selected  = true;

                    try // Иначе в свёрнутом виде ругается: No room is available to display rows
                    {
                        dataGridView_Sections.FirstDisplayedScrollingRowIndex = dataGridView_Sections.SelectedRows[0].Index;
                    }
                    catch { }

                    updateButtons();
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was cloning section(s). " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                        tsButton_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            int lCount = dataGridView_Sections.SelectedRows.Count;
            if (lCount > 0)
            {
                try
                {
                    if (QuestionForm.askQuestion("Delete " + lCount.ToString() + " section(s)?", this) == DialogResult.Yes)
                    {
                        for (int i = 0; i < lCount; i++)
                        {
                            mCloneSections[dataGridView_Sections.SelectedRows[i].Index] = null;
                        }

                        var lTemp = new List<Tuple<long, Snapshot>>();
                        foreach (var lTuple in mCloneSections)
                        {
                            if (lTuple != null)
                            {
                                lTemp.Add(lTuple);
                            }
                        }
                        mCloneSections = lTemp;

                        updateTable();
                        updateButtons();
                    }
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was deleting section(s). " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                        SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }

            if (tabControl.SelectedIndex == 1 && aEventArgs.KeyCode == Keys.Delete)
            {
                tsButton_Delete_Click(this, EventArgs.Empty);
            }
        }

        private void                        tsButton_Delay_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Sections.SelectedRows.Count == 1)
            {
                try
                {
                    int lIndex = dataGridView_Sections.SelectedRows[0].Index;
                    using (var lDelayForm = new DelayForm(mCloneSections[lIndex].Item1))
                    {

                        if (lDelayForm.ShowDialog(this) == DialogResult.OK)
                        {
                            mCloneSections[lIndex] = new Tuple<long, Snapshot>(lDelayForm.Delay, mCloneSections[lIndex].Item2);

                            updateTable();
                            if (lIndex != 0)
                            {
                                dataGridView_Sections.Rows[0].Selected      = false;
                                dataGridView_Sections.Rows[lIndex].Selected = true;
                            }

                            try // Иначе в свёрнутом виде ругается: No room is available to display rows
                            {
                                dataGridView_Sections.FirstDisplayedScrollingRowIndex = dataGridView_Sections.SelectedRows[0].Index;
                            }
                            catch { }

                            updateButtons();
                        }
                    }
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was configuring delay for section. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                        tsButton_Setup_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Sections.SelectedRows.Count == 1)
            {
                try
                {
                    int lIndex = dataGridView_Sections.SelectedRows[0].Index;
                    mCloneSections[lIndex].Item2.setupByForm(this);

                    updateTable();
                    if (lIndex != 0)
                    {
                        dataGridView_Sections.Rows[0].Selected      = false;
                        dataGridView_Sections.Rows[lIndex].Selected = true;
                    }

                    try // Иначе в свёрнутом виде ругается: No room is available to display rows
                    {
                        dataGridView_Sections.FirstDisplayedScrollingRowIndex = dataGridView_Sections.SelectedRows[0].Index;
                    }
                    catch { }

                    updateButtons();
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was configuring section. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                        tsButton_Replace_Click(object aSender, EventArgs aEventArgs)
        {
            if(mDataTable.Rows.Count > 0)
            {
                using (var lReplaceForm = new ReplaceForm(mTimeLine.UniqueItemHandles, mBrowser))
                {
                    if(lReplaceForm.ShowDialog(this) == DialogResult.OK)
                    {
                        foreach (Tuple<long, Snapshot> lRecord in mCloneSections)
                        {
                            lRecord.Item2.replaceItems(lReplaceForm.Replace);
                        }
                    }
                }
            }
        }

        private void                        dataGridView_Sections_CellDoubleClick(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Sections.SelectedRows.Count == 1)
            {
                tsButton_Setup_Click(this, EventArgs.Empty);
            }
        }

        private void                        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    mTimeLine.mOnItemHandle = mBrowser.getItemHandleByName(itemEditBox_On.ItemName);
                    mTimeLine.Loop          = checkBox_Loop.Checked;
                    mTimeLine.mSections     = mCloneSections;

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }    
            }
        }

        private void                        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void             Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (mDataTable != null)
                {
                    dataGridView_Sections.DataSource = null;
                    mDataTable.Dispose();
                    mDataTable = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
