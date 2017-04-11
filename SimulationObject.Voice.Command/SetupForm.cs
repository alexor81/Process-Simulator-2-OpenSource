// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.NameValueList;
using Utils.SpecialControls;

namespace SimulationObject.Voice.Command
{
    public partial class SetupForm : Form
    {
        private Command                     mCommand;
        private IItemBrowser                mBrowser;
        public NameValueHolder              mHolder;

        public                              SetupForm(Command aCommand, IItemBrowser aBrowser)
        {
            mCommand    = aCommand;
            mBrowser    = aBrowser;
            InitializeComponent();

            comboBox_Lang.Items.AddRange(mCommand.Languages);
            if(String.IsNullOrWhiteSpace(mCommand.Language) == false)
            {
                comboBox_Lang.SelectedItem = mCommand.Language;
            }

            if (mCommand.mValueItemHandle != -1)
            {
                itemEditBox.ItemName    = mBrowser.getItemNameByHandle(mCommand.mValueItemHandle);
                itemEditBox.ItemToolTip = mBrowser.getItemToolTipByHandle(mCommand.mValueItemHandle);
            }

            mHolder = mCommand.mHolder.clone();
        }

        private void                        ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void                        button_Commands_Click(object aSender, EventArgs aEventArgs)
        {
            using (var lSetupForm = new NameValueForm(mHolder, "Commands"))
            {
                lSetupForm.ShowDialog(this);
            }
        }

        private void                        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    if(comboBox_Lang.SelectedItem == null)
                    {
                        throw new ArgumentException("Language is not selected. ");
                    }
                   
                    if (String.IsNullOrWhiteSpace(itemEditBox.ItemName))
                    {
                        throw new ArgumentException("Item is missing. ");
                    }

                    mCommand.Language           = comboBox_Lang.SelectedItem.ToString();
                    mCommand.mValueItemHandle   = mBrowser.getItemHandleByName(itemEditBox.ItemName);
                    mCommand.mHolder            = mHolder;

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                        SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
