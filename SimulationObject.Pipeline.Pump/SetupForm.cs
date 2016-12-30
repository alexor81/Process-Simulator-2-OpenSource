// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Pipeline.Pump
{
    public partial class SetupForm : Form
    {
        private Pump            mPump;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Pump aPump, IItemBrowser aBrowser)
        {
            mPump       = aPump;
            mBrowser    = aBrowser;
            InitializeComponent();

            checkBox_IgnoreCommands.Checked = mPump.IgnoreCommands;

            if (mPump.mOnCMDItemHandle != -1)
            {
                itemEditBox_OnCMD.ItemName      = mBrowser.getItemNameByHandle(mPump.mOnCMDItemHandle);
                itemEditBox_OnCMD.ItemToolTip   = mBrowser.getItemToolTipByHandle(mPump.mOnCMDItemHandle);
            }

            checkBox_UseOneCommand.Checked      = mPump.UseOneCommand;

            if (mPump.mOffCMDItemHandle != -1)
            {
                itemEditBox_OffCMD.ItemName     = mBrowser.getItemNameByHandle(mPump.mOffCMDItemHandle);
                itemEditBox_OffCMD.ItemToolTip  = mBrowser.getItemToolTipByHandle(mPump.mOffCMDItemHandle);
            }

            if (mPump.mEsdCMDItemHandle != -1)
            {
                itemEditBox_EsdCMD.ItemName     = mBrowser.getItemNameByHandle(mPump.mEsdCMDItemHandle);
                itemEditBox_EsdCMD.ItemToolTip  = mBrowser.getItemToolTipByHandle(mPump.mEsdCMDItemHandle);
            }

            spinEdit_On.Value    = mPump.OnMS;
            spinEdit_Off.Value   = mPump.OffMS;

            if (mPump.mOnItemHandle != -1)
            {
                itemEditBox_On.ItemName     = mBrowser.getItemNameByHandle(mPump.mOnItemHandle);
                itemEditBox_On.ItemToolTip  = mBrowser.getItemToolTipByHandle(mPump.mOnItemHandle);
            }

            if (mPump.mAlarmItemHandle != -1)
            {
                itemEditBox_Alarm.ItemName      = mBrowser.getItemNameByHandle(mPump.mAlarmItemHandle);
                itemEditBox_Alarm.ItemToolTip   = mBrowser.getItemToolTipByHandle(mPump.mAlarmItemHandle);
            }

            if (mPump.mPowerItemHandle != -1)
            {
                itemEditBox_Power.ItemName      = mBrowser.getItemNameByHandle(mPump.mPowerItemHandle);
                itemEditBox_Power.ItemToolTip   = mBrowser.getItemToolTipByHandle(mPump.mPowerItemHandle);
            }

            if (mPump.mRemoteItemHandle != -1)
            {
                itemEditBox_Remote.ItemName     = mBrowser.getItemNameByHandle(mPump.mRemoteItemHandle);
                itemEditBox_Remote.ItemToolTip  = mBrowser.getItemToolTipByHandle(mPump.mRemoteItemHandle);
            }

            if (mPump.mOnBtnItemHandle != -1)
            {
                itemEditBox_OnBtn.ItemName      = mBrowser.getItemNameByHandle(mPump.mOnBtnItemHandle);
                itemEditBox_OnBtn.ItemToolTip   = mBrowser.getItemToolTipByHandle(mPump.mOnBtnItemHandle);
            }

            if (mPump.mOffBtnItemHandle != -1)
            {
                itemEditBox_OffBtn.ItemName     = mBrowser.getItemNameByHandle(mPump.mOffBtnItemHandle);
                itemEditBox_OffBtn.ItemToolTip  = mBrowser.getItemToolTipByHandle(mPump.mOffBtnItemHandle);
            }
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
                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Power.ItemName);
                    lChecker.addItemName(itemEditBox_OnCMD.ItemName);
                    lChecker.addItemName(itemEditBox_OffCMD.ItemName);
                    lChecker.addItemName(itemEditBox_EsdCMD.ItemName);
                    lChecker.addItemName(itemEditBox_On.ItemName);
                    lChecker.addItemName(itemEditBox_Alarm.ItemName);
                    lChecker.addItemName(itemEditBox_Remote.ItemName);
                    lChecker.addItemName(itemEditBox_OnBtn.ItemName);
                    lChecker.addItemName(itemEditBox_OffBtn.ItemName);

                    mPump.IgnoreCommands    = checkBox_IgnoreCommands.Checked;
                    mPump.UseOneCommand     = checkBox_UseOneCommand.Checked;

                    mPump.OnMS  = (uint)spinEdit_On.Value;
                    mPump.OffMS = (uint)spinEdit_Off.Value;

                    mPump.mRemoteItemHandle = mBrowser.getItemHandleByName(itemEditBox_Remote.ItemName);
                    if (mPump.mRemoteItemHandle == -1)
                    {
                        mPump.Remote = true;
                    }
                    mPump.mOnCMDItemHandle  = mBrowser.getItemHandleByName(itemEditBox_OnCMD.ItemName);
                    if (mPump.mOnCMDItemHandle == -1)
                    {
                        mPump.mOnCMD = false;
                    }
                    mPump.mOffCMDItemHandle = mBrowser.getItemHandleByName(itemEditBox_OffCMD.ItemName);
                    if (mPump.mOffCMDItemHandle == -1)
                    {
                        mPump.mOffCMD = false;
                    }
                    mPump.mEsdCMDItemHandle = mBrowser.getItemHandleByName(itemEditBox_EsdCMD.ItemName);
                    if (mPump.mEsdCMDItemHandle == -1)
                    {
                        mPump.mEsdCMD = false;
                    }
                    mPump.mOnItemHandle     = mBrowser.getItemHandleByName(itemEditBox_On.ItemName);
                    mPump.mAlarmItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Alarm.ItemName);
                    if (mPump.mAlarmItemHandle == -1)
                    {
                        mPump.Alarm = false;
                    }
                    mPump.mPowerItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Power.ItemName);
                    if (mPump.mPowerItemHandle == -1)
                    {
                        mPump.Power = true;
                    }
                    mPump.mOnBtnItemHandle  = mBrowser.getItemHandleByName(itemEditBox_OnBtn.ItemName);
                    if (mPump.mOnBtnItemHandle == -1)
                    {
                        mPump.OnBtn = false;
                    }
                    mPump.mOffBtnItemHandle = mBrowser.getItemHandleByName(itemEditBox_OffBtn.ItemName);
                    if (mPump.mOffBtnItemHandle == -1)
                    {
                        mPump.OffBtn = false;
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
