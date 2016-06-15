using System;
using System.Windows.Forms;
using Utils;

namespace SimulationObject.Script.CSharp
{
    public partial class OptionsForm : Form
    {
        private SetupForm   mSetupForm;

        public              OptionsForm(SetupForm aSetupForm)
        {
            mSetupForm = aSetupForm;
            InitializeComponent();

            spinEdit_Trigger.Value  = mSetupForm.TriggerTimeMS;
            spinEdit_Watchdog.Value = mSetupForm.WatchdogMS;
        }

        private void        spinEdit_Trigger_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_Trigger.Value != mSetupForm.TriggerTimeMS)
            {
                mSetupForm.TriggerTimeMS = (uint)spinEdit_Trigger.Value;
            }
        }

        private void        spinEdit_Watchdog_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_Watchdog.Value != mSetupForm.WatchdogMS)
            {
                mSetupForm.WatchdogMS = (uint)spinEdit_Watchdog.Value;
            }
        }

        private void        OptionsForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void        OptionsForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
