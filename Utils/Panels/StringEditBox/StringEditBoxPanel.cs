// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils.DialogForms;

namespace Utils.Panels.StringEditBox
{
    public partial class StringEditBoxPanel : UserControl, IPanel
    {
        private IObjectValueReadWrite   mObjectValue;

        public                          StringEditBoxPanel(IObjectValueReadWrite aObjectValue)
        {
            mObjectValue = aObjectValue;
            InitializeComponent();

            BackColor                   = SystemColors.Control;
            MaximumSize                 = new Size(Int32.MaxValue, textBox_Value.Height + 2);
            MinimumSize                 = new Size(0, textBox_Value.Height + 2);
            textBox_Value.ContextMenu   = new ContextMenu(); // иначе появляется стандартное меню
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            string lNewToolTip = StringForm.getString(LabelText, this, "Panel ToolTip");
            if (lNewToolTip != null)
            {
                LabelText = lNewToolTip;
            }
        }

        public string                   LabelText
        {
            get { return toolTip.GetToolTip(textBox_Value); }
            set
            {
                toolTip.SetToolTip(textBox_Value, value);
            }
        }

        public void                     updateValues()
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
        private void                    updateV()
        {
            if (textBox_Value.ContainsFocus == false)
            {
                textBox_Value.Text = StringUtils.ObjectToString(mObjectValue.ValueObject);
            }
        }

        public void                     updateProperties()
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
        private void                    updateP()
        {
        }

        private void                    StringEditBoxPanel_Resize(object aSender, EventArgs aEventArgs)
        {
            textBox_Value.Width = Width - 2;
        }

        private void                    textBox_Value_KeyPress(object aSender, KeyPressEventArgs aEventArgs)
        {
            if (aEventArgs.KeyChar == (char)Keys.Enter)
            {
                mObjectValue.ValueObject = textBox_Value.Text;

                textBox_Value.Enabled = false;
                textBox_Value.Enabled = true;

                textBox_Value.Text = StringUtils.ObjectToString(mObjectValue.ValueObject);
            }
        }

        private void                    textBox_Value_Leave(object aSender, EventArgs aEventArgs)
        {
            textBox_Value.Text = StringUtils.ObjectToString(mObjectValue.ValueObject);
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
