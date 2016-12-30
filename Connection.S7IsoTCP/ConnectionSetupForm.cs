// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Timers;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.S7IsoTCP
{
    public partial class ConnectionSetupForm : Form
    {
        private Connection          mConnectionS7IsoTCP;
        private System.Timers.Timer mCyclicUpdateTimer;

        public                      ConnectionSetupForm(Connection aConnectionS7IsoTCP, bool aNew)
        {
            mConnectionS7IsoTCP = aConnectionS7IsoTCP;
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }

            mConnectionS7IsoTCP.ConnectionState += new EventHandler(onConnectionState);
            mConnectionS7IsoTCP.ConnectionError += new EventHandler<MessageStringEventArgs>(onConnectionError);
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
            textBox_IP.Text             = mConnectionS7IsoTCP.mIP;
            spinEdit_Rack.Value         = mConnectionS7IsoTCP.Rack;
            spinEdit_Slot.Value         = mConnectionS7IsoTCP.Slot;
            comboBox_Type.SelectedIndex = (int)mConnectionS7IsoTCP.mConnectionType - 1;

            textBox_IP.Enabled          = !mConnectionS7IsoTCP.Connected;
            spinEdit_Rack.Enabled       = !mConnectionS7IsoTCP.Connected;
            spinEdit_Slot.Enabled       = !mConnectionS7IsoTCP.Connected;
            comboBox_Type.Enabled       = !mConnectionS7IsoTCP.Connected;
            button_Connect.Enabled      = !mConnectionS7IsoTCP.Connected;
            button_Disconnect.Enabled   = mConnectionS7IsoTCP.Connected;

            spinEdit_Slowing.Value      = (decimal)mConnectionS7IsoTCP.Slowdown;
            spinEdit_Errors.Value       = (decimal)mConnectionS7IsoTCP.mErrorsBeforeDisconnect;
            label_CountN.Text           = StringUtils.ObjectToString(mConnectionS7IsoTCP.NumberOfItems);
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
            label_CTime.Text            = StringUtils.ObjectToString(mConnectionS7IsoTCP.mMainCycleTimeMS);
            label_WriteRequests.Text    = StringUtils.ObjectToString(mConnectionS7IsoTCP.mWriteRequests);
        }

        private void                textBox_IP_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionS7IsoTCP.mIP = textBox_IP.Text;
        }

        private void                spinEdit_Rack_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionS7IsoTCP.Rack = (int)spinEdit_Rack.Value;
        }

        private void                spinEdit_Slot_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionS7IsoTCP.Slot = (int)spinEdit_Slot.Value;
        }

        private void                comboBox_Type_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionS7IsoTCP.mConnectionType = (EConnectionType)(comboBox_Type.SelectedIndex + 1);
        }

        private void                button_Connect_Click(object aSender, EventArgs aEventArgs)
        {
            Cursor = Cursors.WaitCursor;
            //============================
            try
            {
                errorProvider.SetError(button_Disconnect, "");

                mConnectionS7IsoTCP.connect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was connecting to Siemens S7 PLC. " + lExc.Message, lExc.ToString());
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
                mConnectionS7IsoTCP.disconnect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was disconnecting from Siemens S7 PLC. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                spinEdit_Slowing_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Slowing.Value;
            if (lValue != mConnectionS7IsoTCP.Slowdown)
            {
                mConnectionS7IsoTCP.Slowdown = lValue;
            }
        }

        private void                spinEdit_Errors_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Errors.Value;
            if (lValue != mConnectionS7IsoTCP.mErrorsBeforeDisconnect)
            {
                mConnectionS7IsoTCP.mErrorsBeforeDisconnect = lValue;
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                ConnectionSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mCyclicUpdateTimer.Stop();
            mCyclicUpdateTimer.Elapsed  -= CyclicUpdate;

            mConnectionS7IsoTCP.ConnectionState -= onConnectionState;
            mConnectionS7IsoTCP.ConnectionError -= onConnectionError;
        }

        private void                ConnectionSetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape && okCancelButton.isOkCancelStyle)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                ConnectionSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if(mCyclicUpdateTimer != null)
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
