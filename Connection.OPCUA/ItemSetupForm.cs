// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.OPCUA
{
    public partial class ItemSetupForm : Form
    {
        private Connection  mConnection;

        public              ItemSetupForm(Connection aConnection, DataItem aItem)
        {
            mConnection = aConnection;
            InitializeComponent();

            if (aItem != null)
            {
                textBox_NodeId.Text     = aItem.mNodeId.ToString();
                spinEdit_Sampling.Value = aItem.mSampling;
            }

            mConnection.ConnectionState += new EventHandler(onChange);
            updateForm();
        }

        private void        onChange(object aSender, EventArgs aEventArgs)
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

        private void        updateForm()
        {
            if (mConnection.Connected)
            {
                button_Browser.Enabled  = true;
                Text                    = "OPC UA Item";
            }
            else
            {
                button_Browser.Enabled  = false;
                Text                    = "OPC UA Item (Disconnected)";
            }
        }

        private void        button_Browser_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                if (mConnection.OPCNodeBrowserForm.ShowDialog(this) == DialogResult.OK)
                {
                    textBox_NodeId.Text = mConnection.OPCNodeBrowserForm.NodeId;
                }
            }
            catch (Exception lExc)
            {
                Log.Error("Error getting OPC UA NodeId list from server '"
                                        + mConnection.mServerName + "' at host '" + mConnection.mHost + "'. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        public string       NodeId
        {
            get { return textBox_NodeId.Text; }
        }

        public int          Sampling
        {
            get { return (int)spinEdit_Sampling.Value; }
        }

        private void        ItemSetupFormcs_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnection.ConnectionState -= onChange;
        }

        private void        ItemSetupFormcs_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void        ItemSetupFormcs_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
