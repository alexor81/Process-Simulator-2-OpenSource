// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils.SpecialControls;

namespace Utils.CSharpScript
{
    public partial class OptionsForm : Form
    {
        private SetupForm       mSetupForm;
        private IItemBrowser    mBrowser;

        public                  OptionsForm(SetupForm aSetupForm, IItemBrowser aBrowser)
        {
            mSetupForm  = aSetupForm;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mSetupForm.OnItemHandle != -1)
            { 
                itemEditBox_OnItem.ItemName    = mBrowser.getItemNameByHandle(mSetupForm.OnItemHandle);
                itemEditBox_OnItem.ItemToolTip = mBrowser.getItemToolTipByHandle(mSetupForm.OnItemHandle);
            }

            spinEdit_Trigger.Value  = mSetupForm.TriggerTimeMS;
            spinEdit_Watchdog.Value = mSetupForm.WatchdogMS;
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);

            if (mSetupForm.OnItemHandle != lHandle)
            {
                mSetupForm.OnItemHandle = lHandle;
            }
        }

        private void            spinEdit_Trigger_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_Trigger.Value != mSetupForm.TriggerTimeMS)
            {
                mSetupForm.TriggerTimeMS = (uint)spinEdit_Trigger.Value;
            }
        }

        private void            spinEdit_Watchdog_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_Watchdog.Value != mSetupForm.WatchdogMS)
            {
                mSetupForm.WatchdogMS = (uint)spinEdit_Watchdog.Value;
            }
        }

        private void            OptionsForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void            OptionsForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
