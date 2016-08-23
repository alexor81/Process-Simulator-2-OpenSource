using API;
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Binary.Logic
{
    public partial class SetupForm : Form
    {
        private Logic           mLogic;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Logic aLogic, IItemBrowser aBrowser)
        {
            mLogic      = aLogic;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mLogic.mInput1ItemHandle != -1)
            {
                itemEditBox_In1.ItemName    = mBrowser.getItemNameByHandle(mLogic.mInput1ItemHandle);
                itemEditBox_In1.ItemToolTip = mBrowser.getItemToolTipByHandle(mLogic.mInput1ItemHandle);
            }

            checkBox_In1Inverse.Checked = mLogic.Input1Inverse;

            if (mLogic.mInput2ItemHandle != -1)
            {
                itemEditBox_In2.ItemName    = mBrowser.getItemNameByHandle(mLogic.mInput2ItemHandle);
                itemEditBox_In2.ItemToolTip = mBrowser.getItemToolTipByHandle(mLogic.mInput2ItemHandle);
            }

            checkBox_In2Inverse.Checked = mLogic.Input2Inverse;

            if (mLogic.mValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mLogic.mValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mLogic.mValueItemHandle);
            }

            comboBox_Operator.Items.AddRange(Logic.Operators);
            comboBox_Operator.SelectedIndex = mLogic.OperatorIndex;
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
                    if (String.IsNullOrWhiteSpace(itemEditBox_In1.ItemName))
                    {
                        throw new ArgumentException("Input №1 Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Value.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_In1.ItemName);
                    lChecker.addItemName(itemEditBox_In2.ItemName);
                    lChecker.addItemName(itemEditBox_Value.ItemName);

                    mLogic.mInput1ItemHandle    = mBrowser.getItemHandleByName(itemEditBox_In1.ItemName);
                    mLogic.Input1Inverse       = checkBox_In1Inverse.Checked;

                    mLogic.mInput2ItemHandle    = mBrowser.getItemHandleByName(itemEditBox_In2.ItemName);
                    mLogic.Input2Inverse       = checkBox_In2Inverse.Checked;

                    mLogic.mValueItemHandle     = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);
                    mLogic.OperatorIndex        = comboBox_Operator.SelectedIndex;

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
