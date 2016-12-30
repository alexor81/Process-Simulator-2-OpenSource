// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Item.BitSplitter
{
    public partial class SetupForm : Form
    {
        private Splitter        mSplitter;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Splitter aSplitter, IItemBrowser aBrowser)
        {
            mSplitter   = aSplitter;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mSplitter.mBitsValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mSplitter.mBitsValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mSplitter.mBitsValueItemHandle);
            }

            switch (mSplitter.mDataFlow)
            {
                case EDataFlow.FROM:    comboBox_DataFlow.SelectedIndex = 0; break;
                case EDataFlow.TO:      comboBox_DataFlow.SelectedIndex = 1; break;
                case EDataFlow.BOTH:    comboBox_DataFlow.SelectedIndex = 2; break;
            }

            for (int i = 0; i < mSplitter.mBitItemHandles.Length; i++)
            {
                if (mSplitter.mBitItemHandles[i] != -1)
                {
                    dataGridView_Bit.Rows.Add((decimal)i, mBrowser.getItemNameByHandle(mSplitter.mBitItemHandles[i]));
                }
            }

            if (dataGridView_Bit.RowCount == 0)
            {
                button_Delete.Enabled = false;
                button_Modify.Enabled = false;
            }
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void            dataGridView_Bit_SelectionChanged(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Bit.SelectedRows.Count != 0)
            {
                int RowIndex                    = dataGridView_Bit.SelectedRows[0].Index;
                spinEdit_Index.Value            = (decimal)dataGridView_Bit.Rows[RowIndex].Cells[0].Value;
                itemEditBox_Item.ItemName       = StringUtils.ObjectToString(dataGridView_Bit.Rows[RowIndex].Cells[1].Value);
                itemEditBox_Item.ItemToolTip    = mBrowser.getItemToolTipByHandle(mBrowser.getItemHandleByName(itemEditBox_Item.ItemName));
            }
        }

        private bool            checkElmParams(bool aCheckSelected)
        {
            try
            {
                var lIndexSet = new HashSet<int>();
                var lChecker = new RepeatItemNameChecker();

                lIndexSet.Add((int)spinEdit_Index.Value);
                lChecker.addItemName(itemEditBox_Item.ItemName);
                lChecker.addItemName(itemEditBox_Value.ItemName);
                int lCount = dataGridView_Bit.Rows.Count;
                for (int i = 0; i < lCount; i++)
                {
                    if (aCheckSelected == false && i == dataGridView_Bit.SelectedRows[0].Index)
                    {
                        continue;
                    }

                    if (lIndexSet.Add((int)StringUtils.StringToObject(typeof(Int32), dataGridView_Bit.Rows[i].Cells[0].Value.ToString())) == false)
                    {
                        throw new ArgumentException("Bit '" + spinEdit_Index.Value.ToString() + "' already exists. ");
                    }

                    lChecker.addItemName(dataGridView_Bit.Rows[i].Cells[1].Value.ToString());
                }

                return true;
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
                return false;
            }
        }

        private void            button_Add_Click(object aSender, EventArgs aEventArgs)
        {
            if (checkElmParams(true) == true)
            {
                dataGridView_Bit.Rows.Add(spinEdit_Index.Value, itemEditBox_Item.ItemName);
                button_Delete.Enabled = true;
                button_Modify.Enabled = true;
            }
        }

        private void            button_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Bit.SelectedRows.Count != 0)
            {
                dataGridView_Bit.Rows.Remove(dataGridView_Bit.SelectedRows[0]);
            }

            if (dataGridView_Bit.RowCount == 0)
            {
                button_Delete.Enabled = false;
                button_Modify.Enabled = false;
            }
        }

        private void            button_Modify_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Bit.SelectedRows.Count != 0)
            {
                if (checkElmParams(false) == true)
                {
                    int lRowIndex                                   = dataGridView_Bit.SelectedRows[0].Index;
                    dataGridView_Bit.Rows[lRowIndex].Cells[0].Value = spinEdit_Index.Value;
                    dataGridView_Bit.Rows[lRowIndex].Cells[1].Value = itemEditBox_Item.ItemName;
                }
            }
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
                    if (String.IsNullOrWhiteSpace(itemEditBox_Value.ItemName))
                    {
                        throw new ArgumentException("Value Item is missing. ");
                    }

                    var lIndexSet   = new HashSet<int>();
                    var lChecker    = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Value.ItemName);

                    int lMaxIndex = -1;
                    int lIndex;
                    int lCount = dataGridView_Bit.Rows.Count;
                    for (int i = 0; i < lCount; i++)
                    {
                        lIndex = (int)StringUtils.StringToObject(typeof(Int32), dataGridView_Bit.Rows[i].Cells[0].Value.ToString());
                        if (lIndexSet.Add(lIndex) == false)
                        {
                            throw new ArgumentException("Bit '" + lIndex.ToString() + "' already exists. ");
                        }
                        if (lIndex > lMaxIndex)
                        {
                            lMaxIndex = lIndex;
                        }

                        lChecker.addItemName(dataGridView_Bit.Rows[i].Cells[1].Value.ToString());
                    }

                    mSplitter.mBitsValueItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);
                    mSplitter.mBitItemHandles       = new int[lMaxIndex + 1];
                    for (int i = 0; i < mSplitter.mBitItemHandles.Length; i++)
                    {
                        mSplitter.mBitItemHandles[i] = -1;
                    }
                    mSplitter.mBitValueChanged  = new bool[mSplitter.mBitItemHandles.Length];
                    mSplitter.mBitsValue        = new bool[mSplitter.mBitItemHandles.Length];
                    for (int i = 0; i < lCount; i++)
                    {
                        lIndex                              = (int)StringUtils.StringToObject(typeof(Int32), dataGridView_Bit.Rows[i].Cells[0].Value.ToString());
                        mSplitter.mBitItemHandles[lIndex]   = mBrowser.getItemHandleByName(dataGridView_Bit.Rows[i].Cells[1].Value.ToString());
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

        private void            SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
