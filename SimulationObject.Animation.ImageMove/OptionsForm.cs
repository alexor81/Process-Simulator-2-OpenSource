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

            if (mSetupForm.mWidthItemHandle != -1)
            {
                itemEditBox_Width.ItemName      = mBrowser.getItemNameByHandle(mSetupForm.mWidthItemHandle);
                itemEditBox_Width.ItemToolTip   = mBrowser.getItemToolTipByHandle(mSetupForm.mWidthItemHandle);
            }

            if (mSetupForm.mHeightItemHandle != -1)
            {
                itemEditBox_Height.ItemName     = mBrowser.getItemNameByHandle(mSetupForm.mHeightItemHandle);
                itemEditBox_Height.ItemToolTip  = mBrowser.getItemToolTipByHandle(mSetupForm.mHeightItemHandle);
            }

            if (mSetupForm.mLabelItemHandle != -1)
            {
                itemEditBox_Label.ItemName     = mBrowser.getItemNameByHandle(mSetupForm.mLabelItemHandle);
                itemEditBox_Label.ItemToolTip  = mBrowser.getItemToolTipByHandle(mSetupForm.mLabelItemHandle);
            }

            buttonEdit_Font.Text    = StringUtils.ObjectToString(mSetupForm.mLabelFont);
            colorEdit_Color.Color   = mSetupForm.mLabelColor;

            if (mSetupForm.mRotateItemHandle != -1)
            {
                itemEditBox_Rotate.ItemName     = mBrowser.getItemNameByHandle(mSetupForm.mRotateItemHandle);
                itemEditBox_Rotate.ItemToolTip  = mBrowser.getItemToolTipByHandle(mSetupForm.mRotateItemHandle);
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

        private void            buttonEdit_Font_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            using (var lFontDlg = new FontDialog())
            {
                lFontDlg.Font = mSetupForm.mLabelFont;
                if (lFontDlg.ShowDialog(this) == DialogResult.OK)
                {
                    mSetupForm.mLabelFont   = lFontDlg.Font;
                    buttonEdit_Font.Text    = StringUtils.ObjectToString(mSetupForm.mLabelFont);
                }
            }
        }

        private void            OptionsForm_FormClosing(object aSender, FormClosingEventArgs aEventArgs)
        {
            mSetupForm.mVisibleItemHandle   = mBrowser.getItemHandleByName(itemEditBox_Visible.ItemName);
            mSetupForm.mWidthItemHandle     = mBrowser.getItemHandleByName(itemEditBox_Width.ItemName);
            mSetupForm.mHeightItemHandle    = mBrowser.getItemHandleByName(itemEditBox_Height.ItemName);
            mSetupForm.mLabelItemHandle     = mBrowser.getItemHandleByName(itemEditBox_Label.ItemName);
            mSetupForm.mRotateItemHandle    = mBrowser.getItemHandleByName(itemEditBox_Rotate.ItemName);
            
            mSetupForm.mLabelColor          = colorEdit_Color.Color;

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
