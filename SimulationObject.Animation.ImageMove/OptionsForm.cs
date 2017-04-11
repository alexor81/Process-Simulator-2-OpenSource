// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.SpecialControls;

namespace SimulationObject.Animation.ImageMove
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

            if (mSetupForm.mVisibleItemHandle != -1)
            {
                itemEditBox_Visible.ItemName    = mBrowser.getItemNameByHandle(mSetupForm.mVisibleItemHandle);
                itemEditBox_Visible.ItemToolTip = mBrowser.getItemToolTipByHandle(mSetupForm.mVisibleItemHandle);
            }

            checkBox_UserMove.Checked = mSetupForm.mUserMove;

            if (mSetupForm.mUserMove && mSetupForm.mMovingByUserItemHandle != -1)
            {
                itemEditBox_Moving.ItemName    = mBrowser.getItemNameByHandle(mSetupForm.mMovingByUserItemHandle);
                itemEditBox_Moving.ItemToolTip = mBrowser.getItemToolTipByHandle(mSetupForm.mMovingByUserItemHandle);
            }     
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void            checkBox_UserMove_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            itemEditBox_Moving.Enabled = checkBox_UserMove.Checked;
        }

        private void            OptionsForm_FormClosing(object aSender, FormClosingEventArgs aEventArgs)
        {
            mSetupForm.mVisibleItemHandle = mBrowser.getItemHandleByName(itemEditBox_Visible.ItemName);

            mSetupForm.mUserMove = checkBox_UserMove.Checked;
            if (mSetupForm.mUserMove)
            {
                mSetupForm.mMovingByUserItemHandle = mBrowser.getItemHandleByName(itemEditBox_Moving.ItemName);
            }
            else
            {
                mSetupForm.mMovingByUserItemHandle = -1;
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
