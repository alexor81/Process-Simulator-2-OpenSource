using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Binary.Counter.Panel
{
    public partial class CounterPanel : UserControl, IPanel
    {
        private Counter         mCounter;

        public                  CounterPanel(Counter aCounter)
        {
            mCounter = aCounter;
            InitializeComponent();

            BackColor = SystemColors.Control;
            comboBox_Front.Items.AddRange(Enum.GetNames(typeof(Counter.EFront)));
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
                toolTip.SetToolTip(label_P, value);
                toolTip.SetToolTip(label_N, value);
                toolTip.SetToolTip(label_Input, value);
                toolTip.SetToolTip(label_Output, value);
                toolTip.SetToolTip(comboBox_Front, value);
                toolTip.SetToolTip(comboBox_P, value);
                toolTip.SetToolTip(comboBox_N, value);
                toolTip.SetToolTip(button_Reset, value);
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
            if (mCounter.mInValue)
            {
                label_Input.BackColor = Color.Yellow;
            }
            else
            {
                label_Input.BackColor = BackColor;
            }

            label_Output.Text = StringUtils.ObjectToString(mCounter.mOutValue);
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
            comboBox_Front.SelectedIndex = (int)mCounter.Front;
            if (mCounter.PositiveInc)
            {
                comboBox_P.SelectedIndex = 0;
            }
            else
            {
                comboBox_P.SelectedIndex = 1;
            }

            if (mCounter.NegativeInc)
            {
                comboBox_N.SelectedIndex = 0;
            }
            else
            {
                comboBox_N.SelectedIndex = 1;
            }
        }

        private void            comboBox_Front_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if(comboBox_Front.SelectedIndex != (int)mCounter.Front)
            {
                mCounter.Front = (Counter.EFront)comboBox_Front.SelectedIndex;
            }
        }

        private void            comboBox_P_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            bool lPI = (comboBox_P.SelectedIndex == 0);
            if(mCounter.PositiveInc != lPI)
            {
                mCounter.PositiveInc = lPI;
            }
        }

        private void            comboBox_N_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            bool lNI = (comboBox_N.SelectedIndex == 0);
            if (mCounter.NegativeInc != lNI)
            {
                mCounter.NegativeInc = lNI;
            }
        }

        private void            button_Reset_Click(object aSender, EventArgs aEventArgs)
        {
            mCounter.Reset();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mCounter = null;
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
