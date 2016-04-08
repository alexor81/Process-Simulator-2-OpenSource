using System;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Real.Generator.Panel
{
    public partial class GeneratorPanel : UserControl, IPanel
    {
        private Generator       mGenerator;

        public                  GeneratorPanel(Generator aGenerator)
        {
            mGenerator = aGenerator;
            InitializeComponent();

            comboBox_Signal.Items.AddRange(Generator.Signals);
        }

        public void             fillForDemo()
        {
        }

        public void             loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText = lReader.getAttribute<String>("ToolTip", "");
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
                toolTip.SetToolTip(label_Value, value);
                toolTip.SetToolTip(playPause, value);
                toolTip.SetToolTip(comboBox_Signal, value);
                toolTip.SetToolTip(label_Bias, value);
                toolTip.SetToolTip(label_Amplitude, value);
                toolTip.SetToolTip(label_PeriodMS, value);
                toolTip.SetToolTip(label_TurnMS, value);
                toolTip.SetToolTip(spinEdit_Bias, value);
                toolTip.SetToolTip(spinEdit_Amplitude, value);
                toolTip.SetToolTip(spinEdit_PeriodMS, value);
                toolTip.SetToolTip(spinEdit_TurnMS, value);
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
            label_Value.Text    = StringUtils.ObjectToString(mGenerator.ValueDouble);
            playPause.Checked   = mGenerator.On;
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
            comboBox_Signal.SelectedIndex   = mGenerator.SignalIndex;
            spinEdit_Bias.Value             = (decimal)mGenerator.Bias;
            spinEdit_Amplitude.Value        = (decimal)mGenerator.Amplitude;
            spinEdit_PeriodMS.Value         = mGenerator.PeriodMS;
            spinEdit_TurnMS.Value           = mGenerator.TurnMS;
        }

        private void            playPause_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mGenerator.On != playPause.Checked)
            {
                mGenerator.On = playPause.Checked;
            }
        }

        private void            comboBox_Signal_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if (comboBox_Signal.SelectedIndex != mGenerator.SignalIndex)
            {
                mGenerator.SignalIndex = comboBox_Signal.SelectedIndex;
            }
        }

        private void            spinEdit_Bias_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            double lValue = (double)spinEdit_Bias.Value;
            if (ValuesCompare.NotEqualDelta1.compare(lValue, mGenerator.Bias))
            {
                mGenerator.Bias = lValue;
            }
        }

        private void            spinEdit_Amplitude_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            double lValue = (double)spinEdit_Amplitude.Value;
            if (ValuesCompare.NotEqualDelta1.compare(lValue, mGenerator.Amplitude))
            {
                mGenerator.Amplitude = lValue;
            }
        }

        private void            spinEdit_PeriodMS_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_PeriodMS.Value;
            if (lValue != mGenerator.PeriodMS)
            {
                mGenerator.PeriodMS = lValue;
            }
        }

        private void            spinEdit_TurnMS_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_TurnMS.Value;
            if (lValue != mGenerator.TurnMS)
            {
                mGenerator.TurnMS = lValue;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mGenerator = null;
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
