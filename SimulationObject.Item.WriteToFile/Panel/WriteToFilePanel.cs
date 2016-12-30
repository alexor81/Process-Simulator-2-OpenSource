// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Item.WriteToFile.Panel
{
    public partial class WriteToFilePanel : UserControl, IPanel
    {
        private WriteToFile     mWriteToFile;

        public                  WriteToFilePanel(WriteToFile aWriteToFile)
        {
            mWriteToFile = aWriteToFile;
            InitializeComponent();

            BackColor = SystemColors.Control;
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
            checkBox_Record.Checked = mWriteToFile.On;
        }

        public void             updateProperties()
        {
        }

        private void            checkBox_Record_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mWriteToFile.On != checkBox_Record.Checked)
            {
                mWriteToFile.On = checkBox_Record.Checked;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mWriteToFile = null;
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
