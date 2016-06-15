using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Real.Generator
{
    public partial class SetupForm : Form
    {
        private Generator       mGenerator;
        private IItemBrowser    mBrowser;

        public                  SetupForm(Generator aGenerator, IItemBrowser aBrowser)
        {
            mGenerator  = aGenerator;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mGenerator.mOnItemHandle != -1)
            {
                itemEditBox_On.ItemName     = mBrowser.getItemNameByHandle(mGenerator.mOnItemHandle);
                itemEditBox_On.ItemToolTip  = mBrowser.getItemToolTipByHandle(mGenerator.mOnItemHandle);
            }

            if (mGenerator.mValueItemHandle != -1)
            {
                itemEditBox_Value.ItemName      = mBrowser.getItemNameByHandle(mGenerator.mValueItemHandle);
                itemEditBox_Value.ItemToolTip   = mBrowser.getItemToolTipByHandle(mGenerator.mValueItemHandle);
            }

            comboBox_Signal.Items.AddRange(Generator.Signals);
            comboBox_Signal.SelectedIndex   = mGenerator.SignalIndex;
            spinEdit_Bias.Value             = (decimal)mGenerator.Bias;
            spinEdit_Amplitude.Value        = (decimal)mGenerator.Amplitude;
            spinEdit_PeriodMS.Value         = mGenerator.PeriodMS;
            spinEdit_TurnMS.Value           = mGenerator.TurnMS;
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
                    if (String.IsNullOrWhiteSpace(itemEditBox_Value.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }
                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_On.ItemName);
                    lChecker.addItemName(itemEditBox_Value.ItemName);

                    mGenerator.mOnItemHandle    = mBrowser.getItemHandleByName(itemEditBox_On.ItemName);
                    mGenerator.mValueItemHandle = mBrowser.getItemHandleByName(itemEditBox_Value.ItemName);

                    mGenerator.SignalIndex      = comboBox_Signal.SelectedIndex;
                    mGenerator.Bias             = (double)spinEdit_Bias.Value;
                    mGenerator.Amplitude        = (double)spinEdit_Amplitude.Value;
                    mGenerator.PeriodMS         = (uint)spinEdit_PeriodMS.Value;
                    mGenerator.TurnMS           = (uint)spinEdit_TurnMS.Value;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }

                DialogResult = DialogResult.OK;
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
