// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Robot.Conveyor
{
    public partial class SetupForm : Form
    {
        private Conveyor        mConveyor;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Conveyor aConveyor, IItemBrowser aBrowser)
        {
            mConveyor   = aConveyor;
            mBrowser    = aBrowser;
            InitializeComponent();

            checkBox_IgnoreCommands.Checked = mConveyor.IgnoreCommands;

            if (mConveyor.mStartCMDItemHandle != -1)
            {
                itemEditBox_StartCMD.ItemName       = mBrowser.getItemNameByHandle(mConveyor.mStartCMDItemHandle);
                itemEditBox_StartCMD.ItemToolTip    = mBrowser.getItemToolTipByHandle(mConveyor.mStartCMDItemHandle);
            }

            checkBox_UseOneCommand.Checked  = mConveyor.UseOneCommand;

            if (mConveyor.mStopCMDItemHandle != -1)
            {
                itemEditBox_StopCMD.ItemName     = mBrowser.getItemNameByHandle(mConveyor.mStopCMDItemHandle);
                itemEditBox_StopCMD.ItemToolTip  = mBrowser.getItemToolTipByHandle(mConveyor.mStopCMDItemHandle);
            }

            spinEdit_StartMS.Value  = mConveyor.StartMS;
            spinEdit_StopMS.Value   = mConveyor.StopMS;

            if (mConveyor.mSpeedCMDItemHandle != -1)
            {
                itemEditBox_SpeedCMD.ItemName       = mBrowser.getItemNameByHandle(mConveyor.mSpeedCMDItemHandle);
                itemEditBox_SpeedCMD.ItemToolTip    = mBrowser.getItemToolTipByHandle(mConveyor.mSpeedCMDItemHandle);
            }

            textBox_SpeedCMDMax.Text = StringUtils.ObjectToString(mConveyor.mSpeedCMDScale.InMax);
            textBox_SpeedCMDMin.Text = StringUtils.ObjectToString(mConveyor.mSpeedCMDScale.InMin);

            if (mConveyor.mMovingItemHandle != -1)
            {
                itemEditBox_Moving.ItemName     = mBrowser.getItemNameByHandle(mConveyor.mMovingItemHandle);
                itemEditBox_Moving.ItemToolTip  = mBrowser.getItemToolTipByHandle(mConveyor.mMovingItemHandle);
            }

            if (mConveyor.mAlarmItemHandle != -1)
            {
                itemEditBox_Alarm.ItemName      = mBrowser.getItemNameByHandle(mConveyor.mAlarmItemHandle);
                itemEditBox_Alarm.ItemToolTip   = mBrowser.getItemToolTipByHandle(mConveyor.mAlarmItemHandle);
            }

            if (mConveyor.mReverseItemHandle != -1)
            {
                itemEditBox_Reverse.ItemName      = mBrowser.getItemNameByHandle(mConveyor.mReverseItemHandle);
                itemEditBox_Reverse.ItemToolTip   = mBrowser.getItemToolTipByHandle(mConveyor.mReverseItemHandle);
            }

            if (mConveyor.mAccelerationItemHandle != -1)
            {
                itemEditBox_Acceleration.ItemName      = mBrowser.getItemNameByHandle(mConveyor.mAccelerationItemHandle);
                itemEditBox_Acceleration.ItemToolTip   = mBrowser.getItemToolTipByHandle(mConveyor.mAccelerationItemHandle);
            }

            if (mConveyor.mBrakingItemHandle != -1)
            {
                itemEditBox_Braking.ItemName      = mBrowser.getItemNameByHandle(mConveyor.mBrakingItemHandle);
                itemEditBox_Braking.ItemToolTip   = mBrowser.getItemToolTipByHandle(mConveyor.mBrakingItemHandle);
            }

            if (mConveyor.mSpeedItemHandle != -1)
            {
                itemEditBox_Speed.ItemName       = mBrowser.getItemNameByHandle(mConveyor.mSpeedItemHandle);
                itemEditBox_Speed.ItemToolTip    = mBrowser.getItemToolTipByHandle(mConveyor.mSpeedItemHandle);
            }

            textBox_SpeedMax.Text = StringUtils.ObjectToString(mConveyor.mSpeedScale.InMax);
            textBox_SpeedMin.Text = StringUtils.ObjectToString(mConveyor.mSpeedScale.InMin);

            if (mConveyor.mForwardItemHandle != -1)
            {
                itemEditBox_Forward.ItemName       = mBrowser.getItemNameByHandle(mConveyor.mForwardItemHandle);
                itemEditBox_Forward.ItemToolTip    = mBrowser.getItemToolTipByHandle(mConveyor.mForwardItemHandle);
            }

            if (mConveyor.mBackwardItemHandle != -1)
            {
                itemEditBox_Backward.ItemName       = mBrowser.getItemNameByHandle(mConveyor.mBackwardItemHandle);
                itemEditBox_Backward.ItemToolTip    = mBrowser.getItemToolTipByHandle(mConveyor.mBackwardItemHandle);
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
                    #region Check

                        double lMin;
                        double lMax;

                        try
                        {
                            lMin = StringUtils.toDouble(textBox_SpeedMin.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong minimum value for 'Speed' signal. ", lExc);
                        }

                        try
                        {
                            lMax = StringUtils.toDouble(textBox_SpeedMax.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong maximum value for 'Speed' signal. ", lExc);
                        }
                        mConveyor.mSpeedScale.checkProperties(lMax, lMin, 100.0D, 0.0D);

                        try
                        {
                            lMin = StringUtils.toDouble(textBox_SpeedCMDMin.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong minimum value for 'Speed' command. ", lExc);
                        }

                        try
                        {
                            lMax = StringUtils.toDouble(textBox_SpeedCMDMax.Text);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong maximum value for 'Speed' command. ", lExc);
                        }
                        mConveyor.mSpeedCMDScale.checkProperties(lMax, lMin, 100.0D, 0.0D);

                        var lChecker = new RepeatItemNameChecker();
                        lChecker.addItemName(itemEditBox_StartCMD.ItemName);
                        lChecker.addItemName(itemEditBox_StopCMD.ItemName);
                        lChecker.addItemName(itemEditBox_SpeedCMD.ItemName);
                        lChecker.addItemName(itemEditBox_Moving.ItemName);
                        lChecker.addItemName(itemEditBox_Alarm.ItemName);
                        lChecker.addItemName(itemEditBox_Reverse.ItemName);
                        lChecker.addItemName(itemEditBox_Acceleration.ItemName);
                        lChecker.addItemName(itemEditBox_Braking.ItemName);
                        lChecker.addItemName(itemEditBox_Speed.ItemName);
                        lChecker.addItemName(itemEditBox_Forward.ItemName);
                        lChecker.addItemName(itemEditBox_Backward.ItemName);

                    #endregion

                    mConveyor.IgnoreCommands    = checkBox_IgnoreCommands.Checked;
                    mConveyor.UseOneCommand     = checkBox_UseOneCommand.Checked;

                    mConveyor.StartMS           = (uint)spinEdit_StartMS.Value;
                    mConveyor.StopMS            = (uint)spinEdit_StopMS.Value;

                    mConveyor.mSpeedScale.setProperties(StringUtils.toDouble(textBox_SpeedMax.Text), StringUtils.toDouble(textBox_SpeedMin.Text), 100.0D, 0.0D);
                    mConveyor.mSpeedCMDScale.setProperties(StringUtils.toDouble(textBox_SpeedCMDMax.Text), StringUtils.toDouble(textBox_SpeedCMDMin.Text), 100.0D, 0.0D);

                    mConveyor.mStartCMDItemHandle = mBrowser.getItemHandleByName(itemEditBox_StartCMD.ItemName);
                    if (mConveyor.mStartCMDItemHandle == -1)
                    {
                        mConveyor.mStartCMD = false;
                    }
                    mConveyor.mStopCMDItemHandle = mBrowser.getItemHandleByName(itemEditBox_StopCMD.ItemName);
                    if (mConveyor.mStopCMDItemHandle == -1)
                    {
                        mConveyor.mStopCMD = false;
                    }
                    mConveyor.mSpeedCMDItemHandle = mBrowser.getItemHandleByName(itemEditBox_SpeedCMD.ItemName);
                    if (mConveyor.mSpeedCMDItemHandle == -1)
                    {
                        mConveyor.mSpeedCMD = 100.0;
                    }
                    mConveyor.mMovingItemHandle = mBrowser.getItemHandleByName(itemEditBox_Moving.ItemName);
                    mConveyor.mAlarmItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Alarm.ItemName);
                    if (mConveyor.mAlarmItemHandle == -1)
                    {
                        mConveyor.Alarm = false;
                    }
                    mConveyor.mReverseItemHandle        = mBrowser.getItemHandleByName(itemEditBox_Reverse.ItemName);
                    mConveyor.mAccelerationItemHandle   = mBrowser.getItemHandleByName(itemEditBox_Acceleration.ItemName);
                    mConveyor.mBrakingItemHandle        = mBrowser.getItemHandleByName(itemEditBox_Braking.ItemName);
                    mConveyor.mSpeedItemHandle          = mBrowser.getItemHandleByName(itemEditBox_Speed.ItemName);
                    mConveyor.mForwardItemHandle        = mBrowser.getItemHandleByName(itemEditBox_Forward.ItemName);
                    mConveyor.mBackwardItemHandle       = mBrowser.getItemHandleByName(itemEditBox_Backward.ItemName);

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
