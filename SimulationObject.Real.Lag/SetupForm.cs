using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Real.Lag
{
    public partial class SetupForm : Form
    {
        private Lag             mLag;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Lag aLag, IItemBrowser aBrowser)
        {
            mLag        = aLag;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mLag.mInputItemHandle != -1)
            {
                itemEditBox_Input.ItemName      = mBrowser.getItemNameByHandle(mLag.mInputItemHandle);
                itemEditBox_Input.ItemToolTip   = mBrowser.getItemToolTipByHandle(mLag.mInputItemHandle);
            }

            if (mLag.mValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mLag.mValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mLag.mValueItemHandle);
            }

            spinEdit_Gain.Value     = (decimal)mLag.Gain;
            spinEdit_LagMS.Value    = mLag.LagMS;
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
                    if (String.IsNullOrWhiteSpace(itemEditBox_Input.ItemName))
                    {
                        throw new ArgumentException("Input Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Value.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Input.ItemName);
                    lChecker.addItemName(itemEditBox_Value.ItemName);

                    mLag.mInputItemHandle = mBrowser.getItemHandleByName(itemEditBox_Input.ItemName);
                    mLag.mValueItemHandle = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);

                    mLag.Gain   = (double)spinEdit_Gain.Value;
                    mLag.LagMS  = (uint)spinEdit_LagMS.Value;
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
