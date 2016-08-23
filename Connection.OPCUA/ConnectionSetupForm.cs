using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.OPCUA
{
    public partial class ConnectionSetupForm : Form
    {
        private Connection  mConnection;

        public              ConnectionSetupForm(Connection aConnection, bool aNew)
        {
            mConnection = aConnection;
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }

            comboBox_Transport.Items.AddRange(Enum.GetNames(typeof(ETransport)));

            spinEdit_PubInterval.Value = mConnection.mPublishingInterval;

            mConnection.ConnectionState += new EventHandler(onConnectionState);
            mConnection.ConnectionError += new EventHandler<MessageStringEventArgs>(onConnectionError);
            updateForm();
        }

        private void        onConnectionState(object aSender, EventArgs aEventArgs)
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

        private void        onConnectionError(object aSender, MessageStringEventArgs aEventArgs)
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

        private void        updateForm()
        {
            textBox_Discovery.Text          = mConnection.mDiscovery;
            textBox_Discovery.Enabled       = !mConnection.Connected;
            comboBox_Server.Text            = mConnection.mServerName;
            comboBox_Server.Enabled         = !mConnection.Connected;
            comboBox_Transport.Text         = mConnection.Transport;
            comboBox_Transport.Enabled      = !mConnection.Connected;
            spinEdit_PubInterval.Enabled    = !mConnection.Connected;

            button_Connect.Enabled          = !mConnection.Connected;
            button_Disconnect.Enabled       = mConnection.Connected;
            button_Browse.Enabled           = mConnection.Connected;

            label_CountN.Text = StringUtils.ObjectToString(mConnection.NumberOfItems);
        }

        private void        textBox_Discovery_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnection.mDiscovery = textBox_Discovery.Text;
        }

        private void        comboBox_Server_DropDown(object aSender, EventArgs aEventArgs)
        {
            comboBox_Server.Items.Clear();

            Cursor = Cursors.WaitCursor;
            //======================
            try
            {
                comboBox_Server.Items.AddRange(Connection.getServers(textBox_Discovery.Text));
            }
            catch (Exception lExc)
            {
                Log.Error("Error while recieving OPC UA servers from '" + textBox_Discovery.Text + "'. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
            finally
            {
                //======================
                Cursor = Cursors.Arrow;
            }
        }

        private void        comboBox_Server_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnection.mServerName = comboBox_Server.Text;
        }

        private void        comboBox_Transport_TextChanged(object aSender, EventArgs aEventArgs)
        {
            mConnection.Transport = comboBox_Transport.Text;
        }

        private void        button_Connect_Click(object aSender, EventArgs aEventArgs)
        {
            Cursor = Cursors.WaitCursor;
            //======================
            try
            {
                errorProvider.SetError(button_Browse, "");

                mConnection.connect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was connecting to OPC UA server '"
                            + mConnection.mServerName + "' at host '" + mConnection.mHost + "'. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
            finally
            {
                //======================
                Cursor = Cursors.Arrow;
            }
        }

        private void        button_Disconnect_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mConnection.disconnect();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was disconnecting from OPC UA server. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        button_Browse_Click(object aSender, EventArgs aEventArgs)
        {
            mConnection.OPCNodeBrowserForm.ShowDialog(this);
        }

        private void        spinEdit_PubInterval_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            int lNewPubInterval = (int)spinEdit_PubInterval.Value;
            if (mConnection.mPublishingInterval != lNewPubInterval)
            {
                mConnection.mPublishingInterval = lNewPubInterval;
            }
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void        SetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnection.ConnectionState -= onConnectionState;
            mConnection.ConnectionError -= onConnectionError;
        }

        private void        ConnectionSetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape && okCancelButton.isOkCancelStyle)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void        ConnectionSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
