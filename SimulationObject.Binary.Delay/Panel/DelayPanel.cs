using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Binary.Delay.Panel
{
    public partial class DelayPanel : UserControl, IPanel
    {
        private Delay           mDelay;

        public                  DelayPanel(Delay aDelay)
        {
            mDelay = aDelay;
            InitializeComponent();
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
                toolTip.SetToolTip(label_Input, value);
                toolTip.SetToolTip(label_Output, value);
                toolTip.SetToolTip(checkBox_Inverse, value);
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
            if (mDelay.mInValue)
            {
                label_Input.BackColor = Color.Yellow;
            }
            else
            {
                label_Input.BackColor = BackColor;
            }

            if (mDelay.ValueBoolean)
            {
                label_Output.BackColor = Color.Green;
            }
            else
            {
                label_Output.BackColor = BackColor;
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
            checkBox_Inverse.Checked    = mDelay.Inverse;
            spinEdit_On.Value           = mDelay.OnDelayMS;
            spinEdit_Off.Value          = mDelay.OffDelayMS;
        }

        private void            checkBox_Inverse_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mDelay.Inverse != checkBox_Inverse.Checked)
            {
                mDelay.Inverse = checkBox_Inverse.Checked;
            }
        }

        private void            spinEdit_On_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_On.Value;
            if (lValue != mDelay.OnDelayMS)
            {
                mDelay.OnDelayMS = lValue;
            }
        }

        private void            spinEdit_Off_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_Off.Value;
            if (lValue != mDelay.OffDelayMS)
            {
                mDelay.OffDelayMS = lValue;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mDelay = null;
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
