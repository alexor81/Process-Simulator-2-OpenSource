using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Real.Comparator
{
    public partial class SetupForm : Form
    {
        private Comparator      mComparator;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Comparator aComparator, IItemBrowser aBrowser)
        {
            mComparator = aComparator;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mComparator.mInput1ItemHandle != -1)
            {
                itemEditBox_In1.ItemName    = mBrowser.getItemNameByHandle(mComparator.mInput1ItemHandle);
                itemEditBox_In1.ItemToolTip = mBrowser.getItemToolTipByHandle(mComparator.mInput1ItemHandle);
            }

            if (mComparator.mInput2ItemHandle != -1)
            {
                itemEditBox_In2.ItemName    = mBrowser.getItemNameByHandle(mComparator.mInput2ItemHandle);
                itemEditBox_In2.ItemToolTip = mBrowser.getItemToolTipByHandle(mComparator.mInput2ItemHandle);
            }

            if (mComparator.mValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mComparator.mValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mComparator.mValueItemHandle);
            }

            comboBox_Operation.Items.AddRange(ValuesCompare.Operations);
            comboBox_Operation.SelectedIndex = mComparator.OperationIndex;
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

                    if (String.IsNullOrWhiteSpace(itemEditBox_In2.ItemName))
                    {
                        throw new ArgumentException("Input №2 Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Value.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_In1.ItemName);
                    lChecker.addItemName(itemEditBox_In2.ItemName);
                    lChecker.addItemName(itemEditBox_Value.ItemName);

                    mComparator.mInput1ItemHandle   = mBrowser.getItemHandleByName(itemEditBox_In1.ItemName);
                    mComparator.mInput2ItemHandle   = mBrowser.getItemHandleByName(itemEditBox_In2.ItemName);
                    mComparator.mValueItemHandle    = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);
                    mComparator.OperationIndex      = comboBox_Operation.SelectedIndex;

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
