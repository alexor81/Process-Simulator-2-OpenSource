// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Timers;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.S7PLCSimAdv2
{
    public partial class ConnectionSetupForm : Form
    {
        private Connection          mConnection;
        private System.Timers.Timer mCyclicUpdateTimer;

        public                      ConnectionSetupForm(Connection aConnection, bool aNew)
        {
            mConnection = aConnection;
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }

            mConnection.ConnectionState += new EventHandler(onConnectionState);
            mConnection.ConnectionError += new EventHandler<MessageStringEventArgs>(onConnectionError);
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
                BeginInvoke((Action)(() => { errorProvider.SetError(button_Browse, aEventArgs.Message); }));
            }
            else
            {
                errorProvider.SetError(button_Browse, aEventArgs.Message);
            }
        }

        private void                updateForm()
        {
            checkBox_Remote.Checked     = mConnection.mRemote;
            checkBox_Remote.Enabled     = !mConnection.Connected;
            textBox_IP.Text             = mConnection.IP;
            textBox_IP.Enabled          = !mConnection.Connected && checkBox_Remote.Checked;
            spinEdit_Port.Value         = mConnection.IPPort;
            spinEdit_Port.Enabled       = !mConnection.Connected && checkBox_Remote.Checked;
            comboBox_PLC.Text           = mConnection.mPLCName;            
            comboBox_PLC.Enabled        = !mConnection.Connected;

            button_Connect.Enabled      = !mConnection.Connected;
            button_Disconnect.Enabled   = mConnection.Connected;
            button_Browse.Enabled       = mConnection.Connected;

            label_CountN.Text = StringUtils.ObjectToString(mConnection.NumberOfItems);
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
            label_CTime.Text            = StringUtils.ObjectToString(mConnection.mMainCycleTimeMS);
            label_WriteRequests.Text    = StringUtils.ObjectToString(mConnection.mWriteRequests);
        }

        private void                spinEdit_Pause_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Pause.Value;
            if (lValue != mConnection.PauseMS)
            {
                mConnection.PauseMS = lValue;
            }
        }

        private void                comboBox_PLC_DropDown(object aSender, EventArgs aEventArgs)
        {
            comboBox_PLC.Items.Clear();

            Cursor = Cursors.WaitCursor;
            //======================
            try
            {
                comboBox_PLC.Items.AddRange(Connection.getPLCList(checkBox_Remote.Checked, textBox_IP.Text, (int)spinEdit_Port.Value));
            }
            catch (Exception lExc)
            {
                if (String.IsNullOrWhiteSpace(textBox_IP.Text))
                {
                    Log.Error("Error while discovering PLC. " + lExc.Message, lExc.ToString());
                }
                else
                {
                    Log.Error("Error while discovering PLC at host '" 
                                    + textBox_IP.Text + ":" + spinEdit_Port.Value.ToString() + "'. " + lExc.Message, lExc.ToString());
                }

                MessageForm.showMessage(lExc.Message, this);
            }
            finally
            {
                //======================
                Cursor = Cursors.Arrow;
            }
        }

        private void                button_Connect_Click(object aSender, EventArgs aEventArgs)
        {
            Cursor = Cursors.WaitCursor;
            //======================
            try
            {
                errorProvider.SetError(button_Browse, "");

                mConnection.mRemote     = checkBox_Remote.Checked;
                mConnection.IP          = textBox_IP.Text;
                mConnection.IPPort      = (int)spinEdit_Port.Value;
                mConnection.mPLCName    = comboBox_PLC.Text;

                mConnection.connect();
            }
            catch (Exception lExc)
            {
                if (mConnection.mRemote)
                {
                    Log.Error("Error while user was connecting to Siemens S7-PLCSIM Advanced v2 PLC '"
                            + mConnection.mPLCName + "' at host '" + textBox_IP.Text + ":" + spinEdit_Port.Value.ToString()
                             + "'. " + lExc.Message, lExc.ToString());
                }
                else
                {
                    Log.Error("Error while user was connecting to Siemens S7-PLCSIM Advanced v2 PLC '"
                            + mConnection.mPLCName + "'. " + lExc.Message, lExc.ToString());
                }
                MessageForm.showMessage(lExc.Message, this);
            }
            finally
            {
                //======================
                Cursor = Cursors.Arrow;
            }
        }

        private void                button_Disconnect_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mConnection.disconnect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was disconnecting from Siemens S7-PLCSIM Advanced v2. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                button_Browse_Click(object aSender, EventArgs aEventArgs)
        {
            mConnection.TagBrowserForm.ShowDialog(this);
        }

        private void                checkBox_Remote_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            textBox_IP.Enabled      = !mConnection.Connected && checkBox_Remote.Checked;
            spinEdit_Port.Enabled   = !mConnection.Connected && checkBox_Remote.Checked;
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                SetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnection.ConnectionState -= onConnectionState;
            mConnection.ConnectionError -= onConnectionError;
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
