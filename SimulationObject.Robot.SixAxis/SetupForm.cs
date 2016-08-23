using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Robot.SixAxis
{
    public partial class SetupForm : Form
    {
        private Robot           mRobot;
        private IItemBrowser    mBrowser;
        private ItemEditBox[]   mSP;
        private ItemEditBox[]   mAngle;
        private TextBox[]       mMaxSpeed;
        private TextBox[]       mMaxAngle;
        private TextBox[]       mMinAngle;

        public                  SetupForm(Robot aRobot, IItemBrowser aBrowser)
        {
            mRobot      = aRobot;
            mBrowser    = aBrowser;
            InitializeComponent();

            mSP         = new ItemEditBox[6] { itemEditBox_SP1, itemEditBox_SP2, itemEditBox_SP3, itemEditBox_SP4, itemEditBox_SP5, itemEditBox_SP6 };
            mAngle      = new ItemEditBox[6] { itemEditBox_Angle1, itemEditBox_Angle2, itemEditBox_Angle3, itemEditBox_Angle4, itemEditBox_Angle5, itemEditBox_Angle6 };
            mMaxSpeed   = new TextBox[6] { textBox_MaxSpeed1, textBox_MaxSpeed2, textBox_MaxSpeed3, textBox_MaxSpeed4, textBox_MaxSpeed5, textBox_MaxSpeed6 };
            mMaxAngle   = new TextBox[6] { textBox_MaxAngle1, textBox_MaxAngle2, textBox_MaxAngle3, textBox_MaxAngle4, textBox_MaxAngle5, textBox_MaxAngle6 };
            mMinAngle   = new TextBox[6] { textBox_MinAngle1, textBox_MinAngle2, textBox_MinAngle3, textBox_MinAngle4, textBox_MinAngle5, textBox_MinAngle6 };

            for (int i = 0; i < 6; i++)
            {
                if (mRobot.mAxisSPItemHandle[i] != -1)
                {
                    mSP[i].ItemName     = mBrowser.getItemNameByHandle(mRobot.mAxisSPItemHandle[i]);
                    mSP[i].ItemToolTip  = mBrowser.getItemToolTipByHandle(mRobot.mAxisSPItemHandle[i]);
                }

                if (mRobot.mAxisAngleItemHandle[i] != -1)
                {
                    mAngle[i].ItemName      = mBrowser.getItemNameByHandle(mRobot.mAxisAngleItemHandle[i]);
                    mAngle[i].ItemToolTip   = mBrowser.getItemToolTipByHandle(mRobot.mAxisAngleItemHandle[i]);
                }

                mMaxSpeed[i].Text = StringUtils.ObjectToString(mRobot.mMaxSpeed[i]);
                mMaxAngle[i].Text = StringUtils.ObjectToString(mRobot.mMaxAngle[i]);
                mMinAngle[i].Text = StringUtils.ObjectToString(mRobot.mMinAngle[i]);
            }

            checkBox_Send.Checked = mRobot.SendData;
            spinEdit_Update.Value = mRobot.UpdateRoKiSimMS;
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

                        double[] lMaxSpeed  = new double[6];
                        double[] lMaxAngle  = new double[6];
                        double[] lMinAngle  = new double[6];
                        var lChecker        = new RepeatItemNameChecker();
                        int lJointIndex;

                        for(int i = 0; i < 6; i++)
                        {
                            lJointIndex = i + 1;

                            try
                            {
                                lMaxSpeed[i] = StringUtils.toDouble(mMaxSpeed[i].Text);
                            }
                            catch (Exception lExc)
                            {
                                throw new ArgumentException("Wrong maximum speed of joint №" + lJointIndex.ToString() + ". ", lExc);
                            }

                            if (lMaxSpeed[i] <= 0.0D)
                            {
                                throw new ArgumentException("Maximum speed of joint №" + lJointIndex.ToString() + " must be greater than zero. ");
                            }

                            try
                            {
                                lMaxAngle[i] = StringUtils.toDouble(mMaxAngle[i].Text);
                            }
                            catch (Exception lExc)
                            {
                                throw new ArgumentException("Wrong maximum angle of joint №" + lJointIndex.ToString() + ". ", lExc);
                            }

                            try
                            {
                                lMinAngle[i] = StringUtils.toDouble(mMinAngle[i].Text);
                            }
                            catch (Exception lExc)
                            {
                                throw new ArgumentException("Wrong minimum angle of joint №" + lJointIndex.ToString() + ". ", lExc);
                            }

                            if (lMaxAngle[i] <= lMinAngle[i])
                            {
                                throw new ArgumentException("The maximum angle of joint №" + lJointIndex.ToString() + " has to be greater than minimum. ");
                            }

                            lChecker.addItemName(mSP[i].ItemName);
                            lChecker.addItemName(mAngle[i].ItemName);
                        }

                    #endregion

                    for (int i = 0; i < 6; i++)
                    {
                        mRobot.mAxisSPItemHandle[i] = mBrowser.getItemHandleByName(mSP[i].ItemName);
                        if (mRobot.mAxisSPItemHandle[i] == -1)
                        {
                            mRobot.mAxisSP[i] = 0.0D;
                        }

                        mRobot.mAxisAngleItemHandle[i] = mBrowser.getItemHandleByName(mAngle[i].ItemName);
                        if (mRobot.mAxisAngleItemHandle[i] == -1)
                        {
                            mRobot.mAxisAngle[i] = 0.0D;
                        }
                    }

                    mRobot.mMaxSpeed    = lMaxSpeed;
                    mRobot.mMaxAngle    = lMaxAngle;
                    mRobot.mMinAngle    = lMinAngle;

                    mRobot.SendData         = checkBox_Send.Checked;
                    mRobot.UpdateRoKiSimMS  = (int)spinEdit_Update.Value;

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
