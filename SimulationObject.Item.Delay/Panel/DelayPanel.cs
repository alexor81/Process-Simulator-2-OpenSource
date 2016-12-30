// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Item.Delay.Panel
{
    public partial class DelayPanel : UserControl, IPanel
    {
        private Delay           mDelay;

        public                  DelayPanel(Delay aDelay)
        {
            mDelay = aDelay;
            InitializeComponent();

            BackColor = SystemColors.Control;
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
                toolTip.SetToolTip(label_Delay, value);
                toolTip.SetToolTip(spinEdit_Delay, value);
                toolTip.SetToolTip(playPause, value);
                toolTip.SetToolTip(label_In, value);
                toolTip.SetToolTip(label_InValue, value);
                toolTip.SetToolTip(label_Out, value);
                toolTip.SetToolTip(label_OutValue, value);
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
            playPause.Checked   = mDelay.On;
            label_InValue.Text  = StringUtils.ObjectToString(mDelay.InValue);
            label_OutValue.Text = StringUtils.ObjectToString(mDelay.ValueObject);
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
            spinEdit_Delay.Value    = mDelay.DelayMS;
        }

        private void            spinEdit_Delay_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_Delay.Value != mDelay.DelayMS)
            {
                mDelay.DelayMS = (uint)spinEdit_Delay.Value;
            }
        }

        private void            playPause_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (playPause.Checked != mDelay.On)
            {
                mDelay.On = playPause.Checked;
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
