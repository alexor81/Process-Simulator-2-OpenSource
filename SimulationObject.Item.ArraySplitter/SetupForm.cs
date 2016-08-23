using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Item.ArraySplitter
{
    public partial class SetupForm : Form
    {
        private Splitter            mSplitter;
        private IItemBrowser        mBrowser;

        public                      SetupForm(Splitter aSplitter, IItemBrowser aBrowser)
        {
            mSplitter   = aSplitter;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mSplitter.mArrayValueItemHandle != -1)
            {
                itemEditBox_Array.ItemName      = mBrowser.getItemNameByHandle(mSplitter.mArrayValueItemHandle);
                itemEditBox_Array.ItemToolTip   = mBrowser.getItemToolTipByHandle(mSplitter.mArrayValueItemHandle);
            }

            switch(mSplitter.mDataFlow)
            {
                case EDataFlow.FROM:    comboBox_DataFlow.SelectedIndex = 0; break;
                case EDataFlow.TO:      comboBox_DataFlow.SelectedIndex = 1; break;
                case EDataFlow.BOTH:    comboBox_DataFlow.SelectedIndex = 2; break;
            }

            for (int i = 0; i < mSplitter.mElementItemHandles.Length; i++)
            {
                if (mSplitter.mElementItemHandles[i] != -1)
                {
                    dataGridView_Elm.Rows.Add((decimal)i, mBrowser.getItemNameByHandle(mSplitter.mElementItemHandles[i]));
                }
            }

            if (dataGridView_Elm.RowCount == 0)
            {
                button_Delete.Enabled = false;
                button_Modify.Enabled = false;
            }
        }

        private void                ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void                dataGridView_Elements_SelectionChanged(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Elm.SelectedRows.Count != 0)
            {
                int RowIndex                    = dataGridView_Elm.SelectedRows[0].Index;
                spinEdit_Index.Value            = (decimal)dataGridView_Elm.Rows[RowIndex].Cells[0].Value;
                itemEditBox_Item.ItemName       = StringUtils.ObjectToString(dataGridView_Elm.Rows[RowIndex].Cells[1].Value);
                itemEditBox_Item.ItemToolTip    = mBrowser.getItemToolTipByHandle(mBrowser.getItemHandleByName(itemEditBox_Item.ItemName));
            }
        }

        private bool                checkElmParams(bool aCheckSelected)
        {
            try
            {
                var lIndexSet   = new HashSet<int>();
                var lChecker    = new RepeatItemNameChecker();

                lIndexSet.Add((int)spinEdit_Index.Value);
                lChecker.addItemName(itemEditBox_Item.ItemName);
                lChecker.addItemName(itemEditBox_Array.ItemName);
                int lCount = dataGridView_Elm.Rows.Count;
                for (int i = 0; i < lCount; i++)
                {
                    if (aCheckSelected == false && i == dataGridView_Elm.SelectedRows[0].Index)
                    {
                        continue;
                    }

                    if(lIndexSet.Add((int)StringUtils.StringToObject(typeof(Int32),dataGridView_Elm.Rows[i].Cells[0].Value.ToString())) == false)
                    {
                        throw new ArgumentException("Index '" + spinEdit_Index.Value.ToString() + "' already exists. ");
                    }

                    lChecker.addItemName(dataGridView_Elm.Rows[i].Cells[1].Value.ToString());
                }

                return true;
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
                return false;
            } 
        }

        private void                button_Add_Click(object aSender, EventArgs aEventArgs)
        {
            if (checkElmParams(true) == true)
            {
                dataGridView_Elm.Rows.Add(spinEdit_Index.Value, itemEditBox_Item.ItemName);
                button_Delete.Enabled = true;
                button_Modify.Enabled = true;
            }
        }

        private void                button_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Elm.SelectedRows.Count != 0)
            {
                dataGridView_Elm.Rows.Remove(dataGridView_Elm.SelectedRows[0]);
            }

            if (dataGridView_Elm.RowCount == 0)
            {
                button_Delete.Enabled = false;
                button_Modify.Enabled = false;
            }
        }

        private void                button_Modify_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Elm.SelectedRows.Count != 0)
            {
                if (checkElmParams(false) == true)
                {
                    int lRowIndex                                   = dataGridView_Elm.SelectedRows[0].Index;
                    dataGridView_Elm.Rows[lRowIndex].Cells[0].Value = spinEdit_Index.Value;
                    dataGridView_Elm.Rows[lRowIndex].Cells[1].Value = itemEditBox_Item.ItemName;
                }
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(itemEditBox_Array.ItemName))
                    {
                        throw new ArgumentException("Array Item is missing. ");
                    }

                    var lIndexSet   = new HashSet<int>();
                    var lChecker    = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Array.ItemName);

                    int lMaxIndex = -1;
                    int lIndex;
                    int lCount = dataGridView_Elm.Rows.Count;
                    for (int i = 0; i < lCount; i++)
                    {
                        lIndex = (int)StringUtils.StringToObject(typeof(Int32), dataGridView_Elm.Rows[i].Cells[0].Value.ToString());
                        if (lIndexSet.Add(lIndex) == false)
                        {
                            throw new ArgumentException("Index '" + lIndex.ToString() + "' already exists. ");
                        }
                        if(lIndex > lMaxIndex)
                        {
                            lMaxIndex = lIndex;
                        }

                        lChecker.addItemName(dataGridView_Elm.Rows[i].Cells[1].Value.ToString());
                    }

                    mSplitter.mArrayValueItemHandle = mBrowser.getItemHandleByName(itemEditBox_Array.ItemName);
                    mSplitter.mElementItemHandles   = new int[lMaxIndex + 1];
                    for (int i = 0; i < mSplitter.mElementItemHandles.Length; i++)
                    {
                        mSplitter.mElementItemHandles[i] = -1;
                    }
                    mSplitter.mElementValueChanged  = new bool[mSplitter.mElementItemHandles.Length];
                    mSplitter.mArrayValue           = new object[mSplitter.mElementItemHandles.Length];
                    for (int i = 0; i < lCount; i++)
                    {
                        lIndex                                  = (int)StringUtils.StringToObject(typeof(Int32), dataGridView_Elm.Rows[i].Cells[0].Value.ToString());
                        mSplitter.mElementItemHandles[lIndex]   = mBrowser.getItemHandleByName(dataGridView_Elm.Rows[i].Cells[1].Value.ToString());
                    }

                    switch (comboBox_DataFlow.SelectedIndex)
                    {
                        case 0: mSplitter.mDataFlow = EDataFlow.FROM; break;
                        case 1: mSplitter.mDataFlow = EDataFlow.TO; break;
                        case 2: mSplitter.mDataFlow = EDataFlow.BOTH; break;
                    }

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }  
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
