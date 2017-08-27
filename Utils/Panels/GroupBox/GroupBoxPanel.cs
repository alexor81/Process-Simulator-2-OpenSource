// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils.DialogForms;

namespace Utils.Panels.GroupBox
{
    public partial class GroupBoxPanel : UserControl, IPanel
    {
        public                  GroupBoxPanel()
        {
            InitializeComponent();

            BackColor = SystemColors.Control;
        }

        public void             fillForDemo()
        {
        }

        public void             loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("Text", "");
        }

        public void             saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Text", LabelText);
        }

        public UserControl      UserControl { get { return this; } }

        public bool             IsScalable { get { return true; } }

        public bool             IsTransparent { get { return false; } }

        public bool             IsConfigurable { get { return true; } }

        public bool             IsContainer { get { return true; } }

        public void             setupByForm(IWin32Window aOwner)
        {
            string lNewText = StringForm.getString(LabelText, this, "GroupBox Text");
            if (lNewText != null)
            {
                LabelText = lNewText;
            }
        }

        public string           LabelText
        {
            set { groupBox.Text = value; }
            get { return groupBox.Text; }
        }

        public void             updateValues()
        {
        }

        public void             updateProperties()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
