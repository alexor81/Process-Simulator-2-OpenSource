using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Real.Calculator
{
    public partial class SetupForm : Form
    {
        private Calculator      mCalculator;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Calculator aCalculator, IItemBrowser aBrowser)
        {
            mCalculator = aCalculator;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mCalculator.mInput1ItemHandle != -1)
            {
                itemEditBox_In1.ItemName    = mBrowser.getItemNameByHandle(mCalculator.mInput1ItemHandle);
                itemEditBox_In1.ItemToolTip = mBrowser.getItemToolTipByHandle(mCalculator.mInput1ItemHandle);
            }

            if (mCalculator.mInput2ItemHandle != -1)
            {
                itemEditBox_In2.ItemName    = mBrowser.getItemNameByHandle(mCalculator.mInput2ItemHandle);
                itemEditBox_In2.ItemToolTip = mBrowser.getItemToolTipByHandle(mCalculator.mInput2ItemHandle);
            }

            if (mCalculator.mValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mCalculator.mValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mCalculator.mValueItemHandle);
            }

            comboBox_Operation.Items.AddRange(Calculator.Operations);
            comboBox_Operation.SelectedIndex = mCalculator.OperationIndex;
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

                    mCalculator.mInput1ItemHandle   = mBrowser.getItemHandleByName(itemEditBox_In1.ItemName);
                    mCalculator.mInput2ItemHandle   = mBrowser.getItemHandleByName(itemEditBox_In2.ItemName);
                    mCalculator.mValueItemHandle    = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);
                    mCalculator.OperationIndex      = comboBox_Operation.SelectedIndex;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
