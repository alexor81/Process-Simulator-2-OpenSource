using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Binary.Trigger
{
    public partial class SetupForm : Form
    {
        private Trigger         mTrigger;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Trigger aTrigger, IItemBrowser aBrowser)
        {
            mTrigger = aTrigger;
            mBrowser = aBrowser;
            InitializeComponent();

            if (mTrigger.mValueItemHandle != -1)
            {

                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mTrigger.mValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mTrigger.mValueItemHandle);
            }

            if (mTrigger.mSetItemHandle != -1)
            {
                itemEditBox_Set.ItemName    = mBrowser.getItemNameByHandle(mTrigger.mSetItemHandle);
                itemEditBox_Set.ItemToolTip = mBrowser.getItemToolTipByHandle(mTrigger.mSetItemHandle);
            }

            if (mTrigger.mResetItemHandle != -1)
            {
                itemEditBox_Reset.ItemName      = mBrowser.getItemNameByHandle(mTrigger.mResetItemHandle);
                itemEditBox_Reset.ItemToolTip   = mBrowser.getItemToolTipByHandle(mTrigger.mResetItemHandle);
            }

            radioButton_SR.Checked = mTrigger.SR_RS;
            radioButton_RS.Checked = mTrigger.SR_RS == false;
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
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
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Set.ItemName))
                    {
                        throw new ArgumentException("Item for trigger set is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Reset.ItemName))
                    {
                        throw new ArgumentException("Item for trigger reset is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Value.ItemName);
                    lChecker.addItemName(itemEditBox_Set.ItemName);
                    lChecker.addItemName(itemEditBox_Reset.ItemName);

                    mTrigger.SR_RS              = radioButton_SR.Checked;
                    mTrigger.mValueItemHandle   = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);
                    mTrigger.mSetItemHandle     = mBrowser.getItemHandleByName(itemEditBox_Set.ItemName);
                    mTrigger.mResetItemHandle   = mBrowser.getItemHandleByName(itemEditBox_Reset.ItemName);
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
    }
}
