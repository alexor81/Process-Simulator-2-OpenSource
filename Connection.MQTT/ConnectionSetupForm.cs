// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.MQTT
{
    public partial class ConnectionSetupForm : Form
    {
        private Connection          mConnectionMQTT;

        public                      ConnectionSetupForm(Connection aConnectionMQTT, bool aNew)
        {
            mConnectionMQTT = aConnectionMQTT;
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }
            
            mConnectionMQTT.ConnectionState += new EventHandler(onConnectionState);
            mConnectionMQTT.ConnectionError += new EventHandler<MessageStringEventArgs>(onConnectionError);
            updateForm();
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
            if(mConnectionMQTT.Connected)
            {
                Text = "MQTT Connection" + " {" + mConnectionMQTT.mClientID + "}";
            }
            else
            {
                Text = "MQTT Connection";
            }

            textBox_Host.Text           = mConnectionMQTT.mHost;
            textBox_Host.Enabled        = !mConnectionMQTT.Connected;

            spinEdit_Port.Value         = mConnectionMQTT.mPort;
            spinEdit_Port.Enabled       = !mConnectionMQTT.Connected;

            spinEdit_keepAlive.Value    = mConnectionMQTT.mKeepAlive;
            spinEdit_keepAlive.Enabled  = !mConnectionMQTT.Connected;

            textBox_Login.Text          = mConnectionMQTT.mLogin;
            textBox_Login.Enabled       = !mConnectionMQTT.Connected;

            textBox_Password.Text       = mConnectionMQTT.mPassword;
            textBox_Password.Enabled    = !mConnectionMQTT.Connected;

            button_Connect.Enabled      = !mConnectionMQTT.Connected;
            button_Disconnect.Enabled   = mConnectionMQTT.Connected;

            textBox_Root.Text           = mConnectionMQTT.Root;
            textBox_Root.Enabled        = !mConnectionMQTT.Connected;

            spinEdit_QOS.Value          = mConnectionMQTT.QOS;
            spinEdit_QOS.Enabled        = !mConnectionMQTT.Connected;

            comboBox_Protocol.Text      = mConnectionMQTT.Protocol;
            comboBox_Protocol.Enabled   = !mConnectionMQTT.Connected;

            label_CountN.Text           = StringUtils.ObjectToString(mConnectionMQTT.NumberOfItems);
        }

        private void                textBox_Host_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionMQTT.mHost = textBox_Host.Text;
        }

        private void                spinEdit_Port_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionMQTT.mPort = (int)spinEdit_Port.Value;
        }

        private void                spinEdit_keepAlive_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionMQTT.mKeepAlive = (ushort)spinEdit_keepAlive.Value;
        }

        private void                textBox_Root_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionMQTT.Root = textBox_Root.Text;
        }

        private void                textBox_Root_KeyPress(object aSender, KeyPressEventArgs aEventArgs)
        {
            if (aEventArgs.KeyChar == 35 || aEventArgs.KeyChar == 43) // '+' '#'
            {
                aEventArgs.Handled = true;
            }
        }

        private void                textBox_Login_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionMQTT.mLogin = textBox_Login.Text;
        }

        private void                textBox_Password_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionMQTT.mPassword = textBox_Password.Text;
        }

        private void                spinEdit_QOS_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            byte lQoS = (byte)spinEdit_QOS.Value;
            if (mConnectionMQTT.QOS != lQoS)
            {
                mConnectionMQTT.QOS = lQoS;
            }
        }

        private void                comboBox_Protocol_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            mConnectionMQTT.Protocol = comboBox_Protocol.Text;
        }

        private void                button_Connect_Click(object aSender, EventArgs aEventArgs)
        {
            Cursor = Cursors.WaitCursor;
            //======================
            try
            {
                errorProvider.SetError(button_Disconnect, "");

                mConnectionMQTT.connect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was connecting to MQTT broker '" + mConnectionMQTT.mHost + "'. " + lExc.Message, lExc.ToString());
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
                mConnectionMQTT.disconnect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was disconnecting from MQTT broker. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                ConnectionSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnectionMQTT.ConnectionState -= onConnectionState;
            mConnectionMQTT.ConnectionError -= onConnectionError;
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
    }
}
