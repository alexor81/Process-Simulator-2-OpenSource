using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Pipeline.Valve
{
    public partial class SetupForm : Form
    {
        private Valve           mValve;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Valve aValve, IItemBrowser aBrowser)
        {
            mValve      = aValve;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mValve.mRemoteItemHandle != -1)
            {
                itemEditBox_Remote.ItemName     = mBrowser.getItemNameByHandle(mValve.mRemoteItemHandle);
                itemEditBox_Remote.ItemToolTip  = mBrowser.getItemToolTipByHandle(mValve.mRemoteItemHandle);
            }

            spinEdit_LimitMS.Value          = mValve.LimitSwitchMS;
            spinEdit_TravelMS.Value         = mValve.TravelMS;

            if (mValve.mAnalogCtrl)
            {
                tabControl_Control.SelectedIndex = 1;
            }
            else
            {
                tabControl_Control.SelectedIndex = 0;
            }

            if (mValve.mPositionCMDItemHandle != -1)
            {
                itemEditBox_PositionCMD.ItemName    = mBrowser.getItemNameByHandle(mValve.mPositionCMDItemHandle);
                itemEditBox_PositionCMD.ItemToolTip = mBrowser.getItemToolTipByHandle(mValve.mPositionCMDItemHandle);
            }

            textBox_PositionCMDMax.Text = StringUtils.ObjectToString(mValve.mPositionCMDScale.InMax);
            textBox_PositionCMDMin.Text = StringUtils.ObjectToString(mValve.mPositionCMDScale.InMin);

            if (mValve.mOpenCMDItemHandle != -1)
            {
                itemEditBox_OpenCMD.ItemName    = mBrowser.getItemNameByHandle(mValve.mOpenCMDItemHandle);
                itemEditBox_OpenCMD.ItemToolTip = mBrowser.getItemToolTipByHandle(mValve.mOpenCMDItemHandle);
            }

            checkBox_UseOneCommand.Checked = mValve.UseOneCommand;

            if (mValve.mCloseCMDItemHandle != -1)
            {
                itemEditBox_CloseCMD.ItemName       = mBrowser.getItemNameByHandle(mValve.mCloseCMDItemHandle);
                itemEditBox_CloseCMD.ItemToolTip    = mBrowser.getItemToolTipByHandle(mValve.mCloseCMDItemHandle);
            }

            if (mValve.mStopCMDItemHandle != -1)
            {
                itemEditBox_StopCMD.ItemName    = mBrowser.getItemNameByHandle(mValve.mStopCMDItemHandle);
                itemEditBox_StopCMD.ItemToolTip = mBrowser.getItemToolTipByHandle(mValve.mStopCMDItemHandle);
            }

            checkBox_ImpCtrl.Checked = mValve.mImpulseCtrl;

            if (mValve.mEsdCMDItemHandle != -1)
            {
                itemEditBox_EsdCMD.ItemName     = mBrowser.getItemNameByHandle(mValve.mEsdCMDItemHandle);
                itemEditBox_EsdCMD.ItemToolTip  = mBrowser.getItemToolTipByHandle(mValve.mEsdCMDItemHandle); 
            }

            checkBox_EsdOpen.Checked = mValve.mEsdOpen;

            if (mValve.mOpenLimitItemHandle != -1)
            {
                itemEditBox_OpenLimit.ItemName       = mBrowser.getItemNameByHandle(mValve.mOpenLimitItemHandle);
                itemEditBox_OpenLimit.ItemToolTip    = mBrowser.getItemToolTipByHandle(mValve.mOpenLimitItemHandle);
            }

            if (mValve.mOpensItemHandle != -1)
            {
                itemEditBox_Opens.ItemName      = mBrowser.getItemNameByHandle(mValve.mOpensItemHandle);
                itemEditBox_Opens.ItemToolTip   = mBrowser.getItemToolTipByHandle(mValve.mOpensItemHandle);
            }

            if (mValve.mClosedLimitItemHandle != -1)
            {
                itemEditBox_ClosedLimit.ItemName     = mBrowser.getItemNameByHandle(mValve.mClosedLimitItemHandle);
                itemEditBox_ClosedLimit.ItemToolTip  = mBrowser.getItemToolTipByHandle(mValve.mClosedLimitItemHandle);
            }

            if (mValve.mClosesItemHandle != -1)
            {
                itemEditBox_Closes.ItemName     = mBrowser.getItemNameByHandle(mValve.mClosesItemHandle);
                itemEditBox_Closes.ItemToolTip  = mBrowser.getItemToolTipByHandle(mValve.mClosesItemHandle);
            }

            if (mValve.mRotationItemHandle != -1)
            {
                itemEditBox_Rotation.ItemName       = mBrowser.getItemNameByHandle(mValve.mRotationItemHandle);
                itemEditBox_Rotation.ItemToolTip    = mBrowser.getItemToolTipByHandle(mValve.mRotationItemHandle);
            }

            if (mValve.mPositionItemHandle != -1)
            {
                itemEditBox_Position.ItemName       = mBrowser.getItemNameByHandle(mValve.mPositionItemHandle);
                itemEditBox_Position.ItemToolTip    = mBrowser.getItemToolTipByHandle(mValve.mPositionItemHandle);
            }

            textBox_PositionMax.Text = StringUtils.ObjectToString(mValve.mPositionScale.InMax);
            textBox_PositionMin.Text = StringUtils.ObjectToString(mValve.mPositionScale.InMin);

            if (mValve.mAlarm1ItemHandle != -1)
            {
                itemEditBox_Alarm1.ItemName     = mBrowser.getItemNameByHandle(mValve.mAlarm1ItemHandle);
                itemEditBox_Alarm1.ItemToolTip  = mBrowser.getItemToolTipByHandle(mValve.mAlarm1ItemHandle);
            }

            if (mValve.mAlarm2ItemHandle != -1)
            {
                itemEditBox_Alarm2.ItemName     = mBrowser.getItemNameByHandle(mValve.mAlarm2ItemHandle);
                itemEditBox_Alarm2.ItemToolTip  = mBrowser.getItemToolTipByHandle(mValve.mAlarm2ItemHandle);
            }

            if (mValve.mPowerItemHandle != -1)
            {
                itemEditBox_Power.ItemName      = mBrowser.getItemNameByHandle(mValve.mPowerItemHandle);
                itemEditBox_Power.ItemToolTip   = mBrowser.getItemToolTipByHandle(mValve.mPowerItemHandle);
            }

            checkBox_IgnoreCommands.Checked     = mValve.IgnoreCommands;
            checkBox_ForceLimSwitches.Checked   = mValve.ForseLimSwitches;
            checkBox_PositionF.Checked          = mValve.PositionFault;
            textBox_FValue.Text                 = StringUtils.ObjectToString(mValve.mFaultValue);
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
                    #region Check

                        double lMin;
                        double lMax;
                        double lFValue;

                        try
                        {
                            lMin = StringUtils.toDouble(textBox_PositionCMDMin.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong minimum value for 'Position' command. ", lExc);
                        }

                        try
                        {
                            lMax = StringUtils.toDouble(textBox_PositionCMDMax.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong maximum value for 'Position' command. ", lExc);
                        }
                        mValve.mPositionCMDScale.checkProperties(lMax, lMin, 100.0D, 0.0D);

                        try
                        {
                            lMin = StringUtils.toDouble(textBox_PositionMin.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong minimum value for 'Position' signal. ", lExc);
                        }

                        try
                        {
                            lMax = StringUtils.toDouble(textBox_PositionMax.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong maximum value for 'Position' signal. ", lExc);
                        }
                        mValve.mPositionScale.checkProperties(lMax, lMin, 100.0D, 0.0D);

                        try
                        {
                            lFValue = StringUtils.toDouble(textBox_FValue.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong fault value. ", lExc);
                        }

                        if (checkBox_ImpCtrl.Checked && checkBox_UseOneCommand.Checked)
                        {
                            throw new ArgumentException("Impulse control is not supported when using only one command. ");
                        }

                        var lChecker = new RepeatItemNameChecker();
                        lChecker.addItemName(itemEditBox_Remote.ItemName);
                        lChecker.addItemName(itemEditBox_PositionCMD.ItemName);
                        lChecker.addItemName(itemEditBox_OpenCMD.ItemName);
                        lChecker.addItemName(itemEditBox_CloseCMD.ItemName);
                        lChecker.addItemName(itemEditBox_StopCMD.ItemName);
                        lChecker.addItemName(itemEditBox_EsdCMD.ItemName);
                        lChecker.addItemName(itemEditBox_OpenLimit.ItemName);
                        lChecker.addItemName(itemEditBox_Opens.ItemName);
                        lChecker.addItemName(itemEditBox_ClosedLimit.ItemName);
                        lChecker.addItemName(itemEditBox_Closes.ItemName);
                        lChecker.addItemName(itemEditBox_Rotation.ItemName);
                        lChecker.addItemName(itemEditBox_Position.ItemName);
                        lChecker.addItemName(itemEditBox_Alarm1.ItemName);
                        lChecker.addItemName(itemEditBox_Alarm2.ItemName);
                        lChecker.addItemName(itemEditBox_Power.ItemName);

                    #endregion

                    mValve.mAnalogCtrl      = (tabControl_Control.SelectedIndex == 1);
                    mValve.mEsdOpen         = checkBox_EsdOpen.Checked;
                    mValve.mImpulseCtrl     = checkBox_ImpCtrl.Checked;

                    mValve.mPositionCMDScale.setProperties(StringUtils.toDouble(textBox_PositionCMDMax.Text), StringUtils.toDouble(textBox_PositionCMDMin.Text), 100.0D, 0.0D);
                    mValve.mPositionScale.setProperties(StringUtils.toDouble(textBox_PositionMax.Text), StringUtils.toDouble(textBox_PositionMin.Text), 100.0D, 0.0D);
                    mValve.mFaultValue = lFValue;

                    mValve.LimitSwitchMS    = (uint)spinEdit_LimitMS.Value;
                    mValve.TravelMS         = (uint)spinEdit_TravelMS.Value;

                    mValve.mRemoteItemHandle        = mBrowser.getItemHandleByName(itemEditBox_Remote.ItemName);
                    if (mValve.mRemoteItemHandle == -1)
                    {
                        mValve.Remote = true;
                    }
                    mValve.mPositionCMDItemHandle   = mBrowser.getItemHandleByName(itemEditBox_PositionCMD.ItemName);

                    mValve.mOpenCMDItemHandle       = mBrowser.getItemHandleByName(itemEditBox_OpenCMD.ItemName);
                    if (mValve.mOpenCMDItemHandle == -1)
                    {
                        mValve.mOpenCMD = false;
                    }
                    mValve.UseOneCommand            = checkBox_UseOneCommand.Checked;
                    mValve.mCloseCMDItemHandle      = mBrowser.getItemHandleByName(itemEditBox_CloseCMD.ItemName);
                    if (mValve.mCloseCMDItemHandle == -1)
                    {
                        mValve.mCloseCMD = false;
                    }
                    mValve.mStopCMDItemHandle       = mBrowser.getItemHandleByName(itemEditBox_StopCMD.ItemName);
                    if (mValve.mStopCMDItemHandle == -1)
                    {
                        mValve.mStopCMD = false;
                    }
                    mValve.mEsdCMDItemHandle        = mBrowser.getItemHandleByName(itemEditBox_EsdCMD.ItemName);
                    if (mValve.mEsdCMDItemHandle == -1)
                    {
                        mValve.mEsdCMD = false;
                    }
                    mValve.mOpenLimitItemHandle     = mBrowser.getItemHandleByName(itemEditBox_OpenLimit.ItemName);
                    mValve.mOpensItemHandle         = mBrowser.getItemHandleByName(itemEditBox_Opens.ItemName);
                    mValve.mClosedLimitItemHandle   = mBrowser.getItemHandleByName(itemEditBox_ClosedLimit.ItemName);
                    mValve.mClosesItemHandle        = mBrowser.getItemHandleByName(itemEditBox_Closes.ItemName);
                    mValve.mRotationItemHandle      = mBrowser.getItemHandleByName(itemEditBox_Rotation.ItemName);
                    mValve.mPositionItemHandle      = mBrowser.getItemHandleByName(itemEditBox_Position.ItemName);
                    mValve.mAlarm1ItemHandle        = mBrowser.getItemHandleByName(itemEditBox_Alarm1.ItemName);
                    if (mValve.mAlarm1ItemHandle == -1)
                    {
                        mValve.Alarm1 = false;
                    }
                    mValve.mAlarm2ItemHandle        = mBrowser.getItemHandleByName(itemEditBox_Alarm2.ItemName);
                    if (mValve.mAlarm2ItemHandle == -1)
                    {
                        mValve.Alarm2 = false;
                    }
                    mValve.mPowerItemHandle         = mBrowser.getItemHandleByName(itemEditBox_Power.ItemName);
                    if (mValve.mPowerItemHandle == -1)
                    {
                        mValve.Power = true;
                    }

                    mValve.IgnoreCommands   = checkBox_IgnoreCommands.Checked;
                    mValve.ForseLimSwitches = checkBox_ForceLimSwitches.Checked;
                    mValve.PositionFault    = checkBox_PositionF.Checked;

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
