// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;

namespace Connection.Internal
{
    public partial class ConnectionSetupForm : Form
    {
        private Connection          mConnection;

        public                      ConnectionSetupForm(Connection aConnection, bool aNew)
        {
            mConnection = aConnection;
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }
            
            mConnection.ConnectionState += new EventHandler(onConnectionStateChanged);
            updateForm();
        }

        private void                onConnectionStateChanged(object aSender, EventArgs aEventArgs)
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

        private void                updateForm()
        {
            if (mConnection.Connected)
            {
                label_Status.Text = "Status: Connected";
            }
            else
            {
                label_Status.Text = "Status: Disconnected";
            }

            button_Connect.Enabled      = !mConnection.Connected;
            button_Disconnect.Enabled   = mConnection.Connected;

            checkBox_TypeChangeProhibited.Checked = mConnection.mTypeChangeProhibited;

            label_CountN.Text           = StringUtils.ObjectToString(mConnection.NumberOfItems);
        }

        private void                button_Connect_Click(object aSender, EventArgs aEventArgs)
        {
            mConnection.connect();
        }

        private void                button_Disconnect_Click(object aSender, EventArgs aEventArgs)
        {
            mConnection.disconnect();
        }

        private void                checkBox_TypeChangeProhibited_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            mConnection.mTypeChangeProhibited = checkBox_TypeChangeProhibited.Checked;
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                ConnectionSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnection.ConnectionState -= onConnectionStateChanged;
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
