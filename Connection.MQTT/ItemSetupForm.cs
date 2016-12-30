// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;

namespace Connection.MQTT
{
    public partial class ItemSetupForm : Form
    {
        private Connection  mConnectionMQTT;

        public              ItemSetupForm(Connection aConnectionMQTT, DataItem aItemMQTT)
        {
            mConnectionMQTT = aConnectionMQTT;
            InitializeComponent();

            mConnectionMQTT.ConnectionState += new EventHandler(onChange);

            textBox_Topic.Text          = aItemMQTT.mTopic;
            checkBox_Subscribe.Checked  = aItemMQTT.Subscribe;
            checkBox_Publish.Checked    = aItemMQTT.Publish;

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
            if (mConnectionMQTT.Connected)
            {
                Text = "MQTT Item";
            }
            else
            {
                Text = "MQTT Item (Disconnected)";
            }
        }

        public string       Topic
        {
            get { return textBox_Topic.Text; }
            set { textBox_Topic.Text = value; }
        }

        private void        textBox_Topic_KeyPress(object aSender, KeyPressEventArgs aEventArgs)
        {
            if (aEventArgs.KeyChar == 35 || aEventArgs.KeyChar == 43) // + #
            {
                aEventArgs.Handled = true;
            }
        }

        public bool         Subscribe
        {
            get { return checkBox_Subscribe.Checked; }
            set { checkBox_Subscribe.Checked = value; }
        }

        public bool         Publish
        {
            get { return checkBox_Publish.Checked; }
            set { checkBox_Publish.Checked = value; }
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void        ItemSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnectionMQTT.ConnectionState -= onChange;
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
