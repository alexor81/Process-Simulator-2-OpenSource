using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Real.Scale
{
    public partial class SetupForm : Form
    {
        private ScaleReal       mScaleReal;
        private IItemBrowser    mBrowser;

        public                  SetupForm(ScaleReal aScaleReal, IItemBrowser aBrowser)
        {
            mScaleReal  = aScaleReal;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (aScaleReal.mInValueItemHandle != -1)
            {

                itemEditBox_Input.ItemName      = mBrowser.getItemNameByHandle(aScaleReal.mInValueItemHandle);
                itemEditBox_Input.ItemToolTip   = mBrowser.getItemToolTipByHandle(aScaleReal.mInValueItemHandle);
            }

            if (aScaleReal.mOutValueItemHandle != -1)
            {
                itemEditBox_Output.ItemName     = mBrowser.getItemNameByHandle(aScaleReal.mOutValueItemHandle);
                itemEditBox_Output.ItemToolTip  = mBrowser.getItemToolTipByHandle(aScaleReal.mOutValueItemHandle);
            }

            textBox_InMax.Text  = StringUtils.ObjectToString(aScaleReal.mValueScale.InMax);
            textBox_InMin.Text  = StringUtils.ObjectToString(aScaleReal.mValueScale.InMin);
            textBox_OutMax.Text = StringUtils.ObjectToString(aScaleReal.mValueScale.OutMax);
            textBox_OutMin.Text = StringUtils.ObjectToString(aScaleReal.mValueScale.OutMin);
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

                    if (String.IsNullOrWhiteSpace(itemEditBox_Output.ItemName))
                    {
                        throw new ArgumentException("Output Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Input.ItemName);
                    lChecker.addItemName(itemEditBox_Output.ItemName);

                    double lInMin;
                    double lInMax;
                    double lOutMin;
                    double lOutMax;

                    try
                    {
                        lInMin = StringUtils.toDouble(textBox_InMin.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong minimum value for input signal. ", lExc);
                    }

                    try
                    {
                        lInMax = StringUtils.toDouble(textBox_InMax.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong maximum value for input signal. ", lExc);
                    }

                    try
                    {
                        lOutMin = StringUtils.toDouble(textBox_OutMin.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong minimum value for output signal. ", lExc);
                    }

                    try
                    {
                        lOutMax = StringUtils.toDouble(textBox_OutMax.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong maximum value for output signal. ", lExc);
                    }

                    mScaleReal.mValueScale.setProperties(lInMax, lInMin, lOutMax, lOutMin);
                    mScaleReal.mInValueItemHandle   = mBrowser.getItemHandleByName(itemEditBox_Input.ItemName);
                    mScaleReal.mOutValueItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Output.ItemName);         
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
