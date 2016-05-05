using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Real.Lag.Panel
{
    public partial class LagPanel : UserControl, IPanel
    {
        private Lag             mLag;

        public                  LagPanel(Lag aLag)
        {
            mLag = aLag;
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
                toolTip.SetToolTip(label_Input, value);
                toolTip.SetToolTip(label_Value, value);
                toolTip.SetToolTip(spinEdit_Gain, value);
                toolTip.SetToolTip(spinEdit_LagMS, value);
                toolTip.SetToolTip(label_Gain, value);
                toolTip.SetToolTip(label_LagMS, value);
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
            label_Value.Text = StringUtils.ObjectToString(mLag.ValueDouble);
            label_Input.Text = StringUtils.ObjectToString(mLag.Input);
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
            spinEdit_Gain.Value     = (decimal)mLag.Gain;
            spinEdit_LagMS.Value    = mLag.LagMS;
        }

        private void            spinEdit_Gain_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            double lValue = (double)spinEdit_Gain.Value;
            if (ValuesCompare.NotEqualDelta1.compare(lValue, mLag.Gain))
            {
                mLag.Gain = lValue;
            }
        }

        private void            spinEdit_LagMS_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_LagMS.Value;
            if (lValue != mLag.LagMS)
            {
                mLag.LagMS = lValue;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mLag = null;
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
