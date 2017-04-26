// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Real.OneOfTwo.Panels
{
    public partial class OneOfTwoPanel : UserControl, IPanel
    {
        private OneOfTwo        mOneOfTwo;

        public                  OneOfTwoPanel(OneOfTwo aOneOfTwo)
        {
            mOneOfTwo = aOneOfTwo;
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
                toolTip.SetToolTip(label_Input1, value);
                toolTip.SetToolTip(label_Input2, value);
                toolTip.SetToolTip(label_Value, value);
                toolTip.SetToolTip(button_Switch, value);
                toolTip.SetToolTip(spinEdit_In1ToIn2, value);
                toolTip.SetToolTip(spinEdit_In2ToIn1, value);
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
            label_Value.Text    = StringUtils.ObjectToString(mOneOfTwo.ValueDouble);
            label_Input1.Text   = StringUtils.ObjectToString(mOneOfTwo.Input1);
            label_Input2.Text   = StringUtils.ObjectToString(mOneOfTwo.Input2);

            if (mOneOfTwo.Switch)
            {
                button_Switch.BackColor     = Color.LimeGreen;
                button_Switch.Text          = "Input 1";
                label_Input1.BorderStyle    = BorderStyle.FixedSingle;
                label_Input2.BorderStyle    = BorderStyle.None;
            }
            else
            {
                button_Switch.BackColor     = BackColor;
                button_Switch.Text          = "Input 2";
                label_Input2.BorderStyle    = BorderStyle.FixedSingle;
                label_Input1.BorderStyle    = BorderStyle.None;
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
           spinEdit_In1ToIn2.Value = mOneOfTwo.In1ToIn2MS;
           spinEdit_In2ToIn1.Value = mOneOfTwo.In2ToIn1MS;
        }

        private void            button_Switch_Click(object aSender, EventArgs aEventArgs)
        {
            mOneOfTwo.Switch = !mOneOfTwo.Switch;
        }

        private void            spinEdit_In1ToIn2_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_In1ToIn2.Value;
            if (lValue != mOneOfTwo.In1ToIn2MS)
            {
                mOneOfTwo.In1ToIn2MS = lValue;
            }
        }

        private void            spinEdit_In2ToIn1_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            uint lValue = (uint)spinEdit_In2ToIn1.Value;
            if (lValue != mOneOfTwo.In2ToIn1MS)
            {
                mOneOfTwo.In2ToIn1MS = lValue;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mOneOfTwo = null;
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
