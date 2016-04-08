using API;
using System;
using System.Timers;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.S7PLCSim
{
    public partial class ConnectionSetupForm : Form
    {
        private Connection          mConnectionS7PLCSim;
        private System.Timers.Timer mCyclicUpdateTimer;

        public                      ConnectionSetupForm(Connection aConnectionS7PLCSim, bool aNew)
        {
            mConnectionS7PLCSim = aConnectionS7PLCSim;
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }

            mConnectionS7PLCSim.ConnectionState += new EventHandler(onConnectionState);
            mConnectionS7PLCSim.ConnectionError += new EventHandler<MessageStringEventArgs>(onConnectionError);
            updateForm();
            cycUpdate();

            mCyclicUpdateTimer          = new System.Timers.Timer(MiscUtils.SlowFormUpdateTime);
            mCyclicUpdateTimer.Elapsed  += new ElapsedEventHandler(CyclicUpdate);
            mCyclicUpdateTimer.Start();
        }

        private void                onConnectionState(object aSender, EventArgs aEventArgs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateForm(); }));
            }
            else
            {
                updateForm();
            }
        }

        private void                onConnectionError(object aSender, MessageStringEventArgs aEventArgs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { errorProvider.SetError(button_Disconnect, aEventArgs.Message); }));
            }
            else
            {
                errorProvider.SetError(button_Disconnect, aEventArgs.Message);
            }
        }

        private void                updateForm()
        {
            spinEdit_InstNum.Enabled        = !mConnectionS7PLCSim.Connected;
            spinEdit_InstNum.Value          = (decimal)mConnectionS7PLCSim.mInstanceNumber;
            button_Connect.Enabled          = !mConnectionS7PLCSim.Connected;
            button_Disconnect.Enabled       = mConnectionS7PLCSim.Connected;
            checkBox_CScan.Checked          = mConnectionS7PLCSim.mContinuousScan;
            spinEdit_Slowing.Value          = (decimal)mConnectionS7PLCSim.Slowdown;
            label_CountN.Text               = StringUtils.ObjectToString(mConnectionS7PLCSim.NumberOfItems);
        }

        private void                CyclicUpdate(object aSender, ElapsedEventArgs aEventArgs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { cycUpdate(); }));
            }
            else
            {
                cycUpdate();
            }
        }

        private void                cycUpdate()
        {
            label_CTime.Text            = StringUtils.ObjectToString(mConnectionS7PLCSim.mMainCycleTimeMS);
            label_WriteRequests.Text    = StringUtils.ObjectToString(mConnectionS7PLCSim.mWriteRequests);
        }

        private void                spinEdit_InstNum_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionS7PLCSim.mInstanceNumber = (uint)spinEdit_InstNum.Value;
        }

        private void                button_Connect_Click(object aSender, EventArgs aEventArgs)
        {
            Cursor = Cursors.WaitCursor;
            //============================
            try
            {
                errorProvider.SetError(button_Disconnect, "");

                mConnectionS7PLCSim.connect();   
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was connecting to Siemens S7-PLCSIM. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
            finally
            {
                //============================
                Cursor = Cursors.Arrow;
            }
        }

        private void                button_Disconnect_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mConnectionS7PLCSim.disconnect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was disconnecting from Siemens S7-PLCSIM. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                checkBox_CScan_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionS7PLCSim.mContinuousScan = checkBox_CScan.Checked;
        }

        private void                spinEdit_Slowing_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Slowing.Value;
            if (lValue != mConnectionS7PLCSim.Slowdown)
            {
                mConnectionS7PLCSim.Slowdown = lValue;
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                SetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mCyclicUpdateTimer.Stop();
            mCyclicUpdateTimer.Elapsed  -= CyclicUpdate;

            mConnectionS7PLCSim.ConnectionState -= onConnectionState;
            mConnectionS7PLCSim.ConnectionError -= onConnectionError;
        }

        private void                ConnectionSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mCyclicUpdateTimer != null)
                {
                    mCyclicUpdateTimer.Dispose();
                    mCyclicUpdateTimer = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
