// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;
using Utils.SpecialControls;

namespace Utils.Snapshot
{
    public partial class AddEditRecordForm : Form
    {
        private IItemBrowser    mBrowser;

        private int             mItemHandle;
        public int              ItemHandle { get { return mItemHandle; } }
        public string           ItemName { get { return itemEditBox_Item.ItemName; } }

        private object          mValue;
        public object           Value { get { return mValue; } }

        public                  AddEditRecordForm(IItemBrowser aBrowser, int aItemHandle, object aValue)
        {
            mBrowser    = aBrowser;
            mItemHandle = aItemHandle;
            mValue      = aValue;
            InitializeComponent();

            if (mItemHandle != -1)
            {
                itemEditBox_Item.ItemName       = mBrowser.getItemNameByHandle(mItemHandle);
                itemEditBox_Item.ItemToolTip    = mBrowser.getItemToolTipByHandle(mItemHandle);
            }

            buttonEdit_Value.Text = StringUtils.ObjectToString(mValue);
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            mItemHandle                 = mBrowser.getItemHandleByForm(mItemHandle, this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(mItemHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(mItemHandle);
        }

        private void            buttonEdit_Value_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            try
            {
                object lValue = ValueForm.getValue(mValue, this);
                if (lValue != null)
                {
                    mValue = lValue;
                    buttonEdit_Value.Text = StringUtils.ObjectToString(mValue);
                }
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was editing new value for record. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void            okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void            AddEditRecordForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void            AddEditRecordForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
