// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Real.Calculator.Panels
{
    public partial class CalculatorPanel : UserControl, IPanel
    {
        private Calculator      mCalculator;

        public                  CalculatorPanel(Calculator aCalculator)
        {
            mCalculator = aCalculator;
            InitializeComponent();

            BackColor = SystemColors.Control;
            comboBox_Operation.Items.AddRange(Calculator.Operations);
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
                toolTip.SetToolTip(panel_div, value);
                toolTip.SetToolTip(comboBox_Operation, value);
                toolTip.SetToolTip(label_Input1, value);
                toolTip.SetToolTip(label_Input2, value);
                toolTip.SetToolTip(label_Value, value);
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
            label_Input1.Text           = StringUtils.ObjectToString(mCalculator.Input1);
            label_Input2.Text           = StringUtils.ObjectToString(mCalculator.Input2);
            label_Value.Text            = StringUtils.ObjectToString(mCalculator.ValueDouble);
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
            comboBox_Operation.SelectedIndex    = mCalculator.OperationIndex;
            label_Input2.Enabled                = comboBox_Operation.SelectedIndex < Calculator.OneArgument;
        }

        private void            comboBox_Operation_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if (comboBox_Operation.SelectedIndex != mCalculator.OperationIndex)
            {
                mCalculator.OperationIndex = comboBox_Operation.SelectedIndex;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mCalculator = null;
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
