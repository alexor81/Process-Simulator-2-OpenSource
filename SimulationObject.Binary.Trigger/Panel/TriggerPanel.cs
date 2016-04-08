using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Binary.Trigger.Panel
{
    public partial class TriggerPanel : UserControl, IPanel
    {
        private Trigger         mTrigger;

        public                  TriggerPanel(Trigger aTrigger)
        {
            mTrigger = aTrigger;
            InitializeComponent();
            
            updateButton();
        }

        public void             fillForDemo()
        {
        }

        public void             loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
        }

        public void             saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
        }

        public UserControl      UserControl { get { return this; } }

        public bool             IsScalable { get { return false; } }

        public bool             IsTransparent { get { return false; } }

        public bool             IsConfigurable { get { return true; } }

        public bool             IsContainer { get { return false; } }

        public void             setupByForm(IWin32Window aOwner)
        {
            string lNewToolTip = StringForm.getString(LabelText, this, "Panel ToolTip");
            if (lNewToolTip != null)
            {
                LabelText = lNewToolTip;
            }
        }

        public string           LabelText
        {
            get { return toolTip.GetToolTip(panel); }
            set
            {
                toolTip.SetToolTip(panel, value);
                toolTip.SetToolTip(label_Set, value);
                toolTip.SetToolTip(label_Reset, value);
                toolTip.SetToolTip(comboBox_SR_RS, value);
                toolTip.SetToolTip(button_Value, value);
            }
        }

        public void             updateValues()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateV(); }));
            }
            else
            {
                updateV();
            }
        }
        private void            updateV()
        {
            if (mTrigger.mSetValue)
            {
                label_Set.BackColor = Color.Yellow;
            }
            else
            {
                label_Set.BackColor = BackColor;
            }

            if (mTrigger.mResetValue)
            {
                label_Reset.BackColor = Color.Yellow;
            }
            else
            {
                label_Reset.BackColor = BackColor;
            }

            if (mValue != mTrigger.ValueBoolean)
            {
                mValue = mTrigger.ValueBoolean;
                updateButton();
            }
        }

        private void            updateButton()
        {
            if (mValue)
            {
                button_Value.BackColor  = Color.Green;
            }
            else
            {
                button_Value.BackColor  = BackColor;
            }
        }

        public void             updateProperties()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateP(); }));
            }
            else
            {
                updateP();
            }
        }
        private void            updateP()
        {
            if (mTrigger.SR_RS)
            {
                comboBox_SR_RS.SelectedIndex = 0;
            }
            else
            {
                comboBox_SR_RS.SelectedIndex = 1;
            }
        }

        private void            comboBox_SR_RS_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if (mTrigger.SR_RS == false && comboBox_SR_RS.SelectedIndex == 0)
            {
                mTrigger.SR_RS = true;
            }
            else if (mTrigger.SR_RS == true && comboBox_SR_RS.SelectedIndex == 1)
            {
                mTrigger.SR_RS = false;
            }
        }

        private bool            mValue;
        private void            button_Value_Click(object aSender, EventArgs aEventArgs)
        {
            mValue                  = !mValue;
            mTrigger.ValueBoolean   = mValue;
            updateButton();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mTrigger = null;
                toolTip.RemoveAll();

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
