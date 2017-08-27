// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Drawing;
using System.Windows.Forms;

namespace Utils.DialogForms
{
    public partial class MessageForm : Form
    {
        private static MessageForm  mMessageBoxForm;

        public static void          showMessage(string aMessage, IWin32Window aOwner)
        {
            if (mMessageBoxForm == null)
            {
                mMessageBoxForm = new MessageForm(aMessage);
            }
            else
            {
                mMessageBoxForm.richTextBox_Message.Text = aMessage;
            }

            mMessageBoxForm.ShowDialog(aOwner);
        }

        private                     MessageForm(string aMessage)
        {
            InitializeComponent();
            richTextBox_Message.Text = aMessage;
        }

        private void                MessageBoxForm_Paint(object aSender, PaintEventArgs aEventArgs)
        {
            Graphics lGr = this.CreateGraphics();
            lGr.DrawIcon(SystemIcons.Exclamation, 10, 10);
        }

        private void                MessageForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape || aEventArgs.KeyCode == Keys.Enter)
            {
                Close();
            }
        }

        private void                MessageForm_Load(object aSender, System.EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
