using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Binary.Delay
{
    public partial class SetupForm : Form
    {
        private Delay           mDelay;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Delay aDelay, IItemBrowser aBrowser)
        {
            mDelay      = aDelay;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mDelay.mInValueItemHandle != -1)
            {
                itemEditBox_In.ItemName     = mBrowser.getItemNameByHandle(mDelay.mInValueItemHandle);
                itemEditBox_In.ItemToolTip  = mBrowser.getItemToolTipByHandle(mDelay.mInValueItemHandle);
            }

            if (mDelay.mOutValueItemHandle != -1)
            {
                itemEditBox_Out.ItemName    = mBrowser.getItemNameByHandle(mDelay.mOutValueItemHandle);
                itemEditBox_Out.ItemToolTip = mBrowser.getItemToolTipByHandle(mDelay.mOutValueItemHandle);
            }

            checkBox_Inverse.Checked    = mDelay.Inverse;
            spinEdit_On.Value           = mDelay.OnDelayMS;
            spinEdit_Off.Value          = mDelay.OffDelayMS;
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
                    if (String.IsNullOrWhiteSpace(itemEditBox_In.ItemName))
                    {
                        throw new ArgumentException("Input Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Out.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_In.ItemName);
                    lChecker.addItemName(itemEditBox_Out.ItemName);

                    mDelay.mInValueItemHandle   = mBrowser.getItemHandleByName(itemEditBox_In.ItemName);
                    mDelay.mOutValueItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Out.ItemName);
                    mDelay.Inverse              = checkBox_Inverse.Checked;
                    mDelay.OnDelayMS            = (uint)spinEdit_On.Value;
                    mDelay.OffDelayMS           = (uint)spinEdit_Off.Value;
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
