// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Real.Comparator.Panel
{
    public partial class ComparatorPanel : UserControl, IPanel
    {
        private Comparator      mComparator;

        public                  ComparatorPanel(Comparator aComparator)
        {
            mComparator = aComparator;
            InitializeComponent();

            BackColor = SystemColors.Control;
            comboBox_Operation.Items.AddRange(ValuesCompare.Operations);
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
                toolTip.SetToolTip(comboBox_Operation, value);
                toolTip.SetToolTip(label_Input1, value);
                toolTip.SetToolTip(label_Input2, value);
                toolTip.SetToolTip(label_Output, value);
                toolTip.SetToolTip(panel_div, value);
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
            label_Input1.Text = StringUtils.ObjectToString(mComparator.Input1);
            label_Input2.Text = StringUtils.ObjectToString(mComparator.Input2);
            if (mComparator.ValueBoolean)
            {
                label_Output.BackColor = Color.LimeGreen;
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
            comboBox_Operation.SelectedIndex = mComparator.OperationIndex;
        }

        private void            comboBox_Operation_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if (comboBox_Operation.SelectedIndex != mComparator.OperationIndex)
            {
                mComparator.OperationIndex = comboBox_Operation.SelectedIndex;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mComparator = null;
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
