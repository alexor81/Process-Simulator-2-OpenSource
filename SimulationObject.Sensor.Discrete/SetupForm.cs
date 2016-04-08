using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Sensor.Discrete
{
    public partial class SetupForm : Form
    {
        private DiscreteSensor  mDiscreteSensor;
        private IItemBrowser    mBrowser;

        public                  SetupForm(DiscreteSensor aDiscreteSensor, IItemBrowser aBrowser)
        {
            mDiscreteSensor = aDiscreteSensor;
            mBrowser        = aBrowser;
            InitializeComponent();

            if (mDiscreteSensor.mValueItemHandle != -1)
            {
                itemEditBox.ItemName    = mBrowser.getItemNameByHandle(mDiscreteSensor.mValueItemHandle);
                itemEditBox.ItemToolTip = mBrowser.getItemToolTipByHandle(mDiscreteSensor.mValueItemHandle);
            }

            textBox_True.Text           = mDiscreteSensor.TrueSpeech;
            textBox_False.Text          = mDiscreteSensor.FalseSpeech;

            checkBox_TellTrue.Checked   = mDiscreteSensor.TellTrue;
            checkBox_TellFalse.Checked  = mDiscreteSensor.TellFalse;

            checkBox_LogTrue.Checked    = mDiscreteSensor.LogTrue;
            checkBox_LogFalse.Checked   = mDiscreteSensor.LogFalse;
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
                    if (String.IsNullOrWhiteSpace(itemEditBox.ItemName))
                    {
                        throw new ArgumentException("Item is missing. ");
                    }

                    mDiscreteSensor.mValueItemHandle    = mBrowser.getItemHandleByName(itemEditBox.ItemName);
                    mDiscreteSensor.TrueSpeech          = textBox_True.Text;
                    mDiscreteSensor.FalseSpeech         = textBox_False.Text;

                    mDiscreteSensor.TellTrue            = checkBox_TellTrue.Checked;
                    mDiscreteSensor.TellFalse           = checkBox_TellFalse.Checked;

                    mDiscreteSensor.LogTrue             = checkBox_LogTrue.Checked;
                    mDiscreteSensor.LogFalse            = checkBox_LogFalse.Checked;
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
