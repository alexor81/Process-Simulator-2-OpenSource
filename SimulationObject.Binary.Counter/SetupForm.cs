// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Binary.Counter
{
    public partial class SetupForm : Form
    {
        private Counter         mCounter;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Counter aCounter, IItemBrowser aBrowser)
        {
            mCounter = aCounter;
            mBrowser = aBrowser;
            InitializeComponent();

            if (mCounter.mInValueItemHandle != -1)
            {
                itemEditBox_Input.ItemName = mBrowser.getItemNameByHandle(mCounter.mInValueItemHandle);
                itemEditBox_Input.ItemToolTip = mBrowser.getItemToolTipByHandle(mCounter.mInValueItemHandle);
            }

            if (mCounter.mOutValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName = mBrowser.getItemNameByHandle(mCounter.mOutValueItemHandle);
                itemEditBox_Value.ItemToolTip = mBrowser.getItemToolTipByHandle(mCounter.mOutValueItemHandle);
            }

            comboBox_Front.Items.AddRange(Enum.GetNames(typeof(EFront)));
            comboBox_Front.SelectedIndex = (int)mCounter.Front;

            if(mCounter.PositiveInc)
            {
                comboBox_P.SelectedIndex = 0;
            }
            else
            {
                comboBox_P.SelectedIndex = 1;
            }

            if (mCounter.NegativeInc)
            {
                comboBox_N.SelectedIndex = 0;
            }
            else
            {
                comboBox_N.SelectedIndex = 1;
            }

            checkBox_ReadOutput.Checked = mCounter.mReadOutput;
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void            okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(itemEditBox_Input.ItemName))
                    {
                        throw new ArgumentException("Input Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Value.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Input.ItemName);
                    lChecker.addItemName(itemEditBox_Value.ItemName);

                    mCounter.mInValueItemHandle     = mBrowser.getItemHandleByName(itemEditBox_Input.ItemName);
                    mCounter.mOutValueItemHandle    = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);

                    mCounter.Front = (EFront)comboBox_Front.SelectedIndex;

                    mCounter.PositiveInc = (comboBox_P.SelectedIndex == 0);
                    mCounter.NegativeInc = (comboBox_N.SelectedIndex == 0);

                    mCounter.mReadOutput = checkBox_ReadOutput.Checked;

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void            SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
