// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Timers;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.ModbusN
{
    public partial class ConnectionSetupForm : Form
    {
        private Connection          mConnection;
        private System.Timers.Timer mCyclicUpdateTimer;

        public                      ConnectionSetupForm(Connection aConnectionModbus, bool aNew)
        {
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }

            mConnection                   = aConnectionModbus;
            mConnection.ConnectionState   += new EventHandler(onConnectionState);
            mConnection.ConnectionError   += new EventHandler<MessageStringEventArgs>(onConnectionError);
            updateForm();
            cycUpdate();

            mCyclicUpdateTimer          = new System.Timers.Timer(MiscUtils.SlowFormUpdateTime);
            mCyclicUpdateTimer.Elapsed  += new ElapsedEventHandler(CyclicUpdate);
            mCyclicUpdateTimer.Start();
        }

        private void                updateForm()
        {
            switch (mConnection.mTransport)
            {
                case ETransportType.TCP:        radioButton_TCP.Checked = true;
                                                radioButton_TCP_CheckedChanged(null, null);
                                                textBox_IP.Text     = mConnection.IP;
                                                spinEdit_Port.Value = mConnection.IPPort;
                                                break;

                case ETransportType.SERIAL:     radioButton_Serial.Checked = true;
                                                radioButton_Serial_CheckedChanged(null, null);
                                                comboBox_COMPort.Text   = mConnection.COMPort;
                                                comboBox_Baud.Text      = mConnection.Baud.ToString();

                                                if (mConnection.DataBits == 8)
                                                {
                                                    radioButton_8.Checked = true;
                                                }
                                                else if (mConnection.DataBits == 7)
                                                {
                                                    radioButton_7.Checked = true;
                                                }
                                                else if (mConnection.DataBits == 6)
                                                {
                                                    radioButton_6.Checked = true;
                                                }
                                                else if (mConnection.DataBits == 5)
                                                {
                                                    radioButton_5.Checked = true;
                                                }

                                                if (mConnection.mParity == System.IO.Ports.Parity.None)
                                                {
                                                    radioButton_N.Checked = true;
                                                }
                                                else if (mConnection.mParity == System.IO.Ports.Parity.Even)
                                                {
                                                    radioButton_E.Checked = true;
                                                }
                                                else if (mConnection.mParity == System.IO.Ports.Parity.Odd)
                                                {
                                                    radioButton_O.Checked = true;
                                                } 
                                                else if (mConnection.mParity == System.IO.Ports.Parity.Mark)
                                                {
                                                    radioButton_M.Checked = true;
                                                }
                                                else if (mConnection.mParity == System.IO.Ports.Parity.Space)
                                                {
                                                    radioButton_S.Checked = true;
                                                }

                                                if (mConnection.mStopBits == System.IO.Ports.StopBits.One)
                                                {
                                                    radioButton_1.Checked = true;
                                                }
                                                else if (mConnection.mStopBits == System.IO.Ports.StopBits.OnePointFive)
                                                {
                                                    radioButton_1_5.Checked = true;
                                                }
                                                else if (mConnection.mStopBits == System.IO.Ports.StopBits.Two)
                                                {
                                                    radioButton_2.Checked = true;
                                                }

                                                if (mConnection.mProtocol == EProtocol.RTU)
                                                {
                                                    radioButton_RTU.Checked = true;
                                                }
                                                else if (mConnection.mProtocol == EProtocol.ASCII)
                                                {
                                                    radioButton_ASCII.Checked = true;
                                                }

                                                break; 
            }

            groupBox_Transport.Enabled = !mConnection.Connected;
            if (mConnection.Connected)
            {
                groupBox_Ethernet.Enabled   = false;
                groupBox_Protocol.Enabled   = false;
                groupBox_Serial.Enabled     = false;
            }
            spinEdit_Frame.Enabled      = !mConnection.Connected;
            button_Connect.Enabled      = !mConnection.Connected;
            button_Disconnect.Enabled   = mConnection.Connected;

            spinEdit_Timeout.Value  = mConnection.TimeoutMS;
            spinEdit_Errors.Value   = mConnection.mErrorsBeforeDisconnect;
            spinEdit_Pause.Value    = mConnection.PauseMS;
            spinEdit_Frame.Value    = mConnection.Frame;

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

        private void                updateTransport()
        {
            if (radioButton_TCP.Checked)
            {
                mConnection.mTransport  = ETransportType.TCP;
                mConnection.IP          = textBox_IP.Text;
                mConnection.IPPort      = (int)spinEdit_Port.Value;
            }
            else
            {
                mConnection.mTransport  = ETransportType.SERIAL;
                mConnection.COMPort     = comboBox_COMPort.Text;
                mConnection.Baud        = Int32.Parse(comboBox_Baud.Text);
                
                if (radioButton_8.Checked)
                {
                    mConnection.DataBits = 8;
                }
                else if (radioButton_7.Checked)
                {
                    mConnection.DataBits = 7;
                }
                else if (radioButton_6.Checked)
                {
                    mConnection.DataBits = 6;
                }
                else if (radioButton_5.Checked)
                {
                    mConnection.DataBits = 5;
                }

                if (radioButton_N.Checked)
                {
                    mConnection.mParity = System.IO.Ports.Parity.None;
                }
                else if (radioButton_E.Checked)
                {
                    mConnection.mParity = System.IO.Ports.Parity.Even;
                }
                else if (radioButton_O.Checked)
                {
                    mConnection.mParity = System.IO.Ports.Parity.Odd;
                }
                else if (radioButton_M.Checked)
                {
                    mConnection.mParity = System.IO.Ports.Parity.Mark;
                }
                else if (radioButton_S.Checked)
                {
                    mConnection.mParity = System.IO.Ports.Parity.Space;
                }

                if (radioButton_1.Checked)
                {
                    mConnection.mStopBits = System.IO.Ports.StopBits.One;
                }
                else if (radioButton_1_5.Checked)
                {
                    mConnection.mStopBits = System.IO.Ports.StopBits.OnePointFive;
                }
                else if (radioButton_2.Checked)
                {
                    mConnection.mStopBits = System.IO.Ports.StopBits.Two;
                }

                if (radioButton_RTU.Checked)
                {
                    mConnection.mProtocol = EProtocol.RTU;
                }
                else if (radioButton_ASCII.Checked)
                {
                    mConnection.mProtocol = EProtocol.ASCII;
                }
            }

            updateForm();
        }

        private void                button_Connect_Click(object aSender, EventArgs aEventArgs)
        {
            Cursor = Cursors.WaitCursor;
            //============================
            try
            {
                errorProvider.SetError(button_Disconnect, "");
                updateTransport();
                mConnection.connect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was connecting to Modbus slave. " + lExc.Message, lExc.ToString());
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
                mConnection.disconnect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was disconnecting from Modbus slave. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                radioButton_TCP_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            groupBox_Ethernet.Enabled   = true;
            groupBox_Protocol.Enabled   = false;
            groupBox_Serial.Enabled     = false;
        }

        private void                radioButton_Serial_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            groupBox_Ethernet.Enabled   = false;
            groupBox_Protocol.Enabled   = true;
            groupBox_Serial.Enabled     = true;
        }

        private void                spinEdit_Frame_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Frame.Value;
            if (lValue != mConnection.Frame)
            {
                mConnection.Frame = lValue;
            }
        }

        private void                spinEdit_Timeout_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Timeout.Value;
            if (lValue != mConnection.TimeoutMS)
            {
                mConnection.TimeoutMS = lValue;
            }
        }

        private void                spinEdit_Errors_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Errors.Value;
            if (lValue != mConnection.mErrorsBeforeDisconnect)
            {
                mConnection.mErrorsBeforeDisconnect = lValue;
            }
        }

        private void                spinEdit_Pause_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Pause.Value;
            if (lValue != mConnection.PauseMS)
            {
                mConnection.PauseMS = lValue;
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (mConnection.Connected == false)
            {
                updateTransport();
            }
            DialogResult = okCancelButton.DialogResult;
        }

        private void                ConnectionSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mCyclicUpdateTimer.Stop();
            mCyclicUpdateTimer.Elapsed  -= CyclicUpdate;

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
