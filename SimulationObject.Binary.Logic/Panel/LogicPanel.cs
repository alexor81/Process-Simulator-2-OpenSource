// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Binary.Logic.Panel
{
    public partial class LogicPanel : UserControl, IPanel
    {
        private Logic           mLogic;

        public                  LogicPanel(Logic aLogic)
        {
            mLogic = aLogic;
            InitializeComponent();

            BackColor = SystemColors.Control;
            comboBox_Operator.Items.AddRange(Logic.Operators);
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
                toolTip.SetToolTip(comboBox_Operator, value);
                toolTip.SetToolTip(label_In1, value);
                toolTip.SetToolTip(label_In2, value);
                toolTip.SetToolTip(label_Output, value);
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
            if (mLogic.Input1Value)
            {
                label_In1.BackColor = Color.Yellow;
            }
            else
            {
                label_In1.BackColor = BackColor;
            }

            if (mLogic.Input2Value)
            {
                label_In2.BackColor = Color.Yellow;
            }
            else
            {
                label_In2.BackColor = BackColor;
            }

            if (mLogic.ValueBoolean)
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
            comboBox_Operator.SelectedIndex = mLogic.OperatorIndex;
            label_In2.Visible               = (comboBox_Operator.SelectedIndex != 3);
            checkBox_In2Inverse.Visible     = label_In2.Visible;
            checkBox_In1Inverse.Checked     = mLogic.Input1Inverse;
            checkBox_In2Inverse.Checked     = mLogic.Input2Inverse;
        }

        private void            comboBox_Operator_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if (comboBox_Operator.SelectedIndex != mLogic.OperatorIndex)
            {
                mLogic.OperatorIndex = comboBox_Operator.SelectedIndex;
            }
        }

        private void            checkBox_In1Inverse_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLogic.Input1Inverse != checkBox_In1Inverse.Checked)
            {
                mLogic.Input1Inverse = checkBox_In1Inverse.Checked;
            }
        }

        private void            checkBox_In2Inverse_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLogic.Input2Inverse != checkBox_In2Inverse.Checked)
            {
                mLogic.Input2Inverse = checkBox_In2Inverse.Checked;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mLogic = null;
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
