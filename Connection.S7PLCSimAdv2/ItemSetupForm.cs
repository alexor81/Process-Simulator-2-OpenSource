// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace Connection.S7PLCSimAdv2
{
    public partial class ItemSetupForm : Form
    {
        private Connection  mConnection;

        public              ItemSetupForm(Connection aConnection, string aName)
        {
            mConnection = aConnection;
            InitializeComponent();

            textBox_Tag.Text             = aName;
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
                Text                    = "S7PLCSimAdv2 Item";
            }
            else
            {
                button_Browser.Enabled  = false;
                Text                    = "S7PLCSimAdv2 Item (Disconnected)";
            }
        }

        private void        button_Browser_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                if (mConnection.TagBrowserForm.ShowDialog(this) == DialogResult.OK)
                {
                    textBox_Tag.Text = mConnection.TagBrowserForm.TagName;
                }
            }
            catch (Exception lExc)
            {
                Log.Error("Error getting Tag list from PLC '" + mConnection.mPLCName + "'. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        public string       TagName
        {
            get { return textBox_Tag.Text; }
            set { textBox_Tag.Text = value; }
        }

        private void        ItemSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnection.ConnectionState -= onChange;
        }

        private void        ItemSetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void        ItemSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
