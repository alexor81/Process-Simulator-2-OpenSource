// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using API;

namespace Utils.Panels.ObjectTextLabel
{
    public partial class ObjectTextLabelPanel : UserControl, IPanel, IPanelExt
    {
        private IObjectValueRead    mObjectValue;

        public                      ObjectTextLabelPanel(IObjectValueRead aObjectValue)
        {
            mObjectValue = aObjectValue;
            InitializeComponent();

            BackColor = SystemColors.Control;
            updateV();
            resizeToContent();
        }

        public void                 fillForDemo()
        {
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            TextColor       = lReader.getAttribute<Color>("TextColor", TextColor);
            BackgroundColor = lReader.getAttribute<Color>("BackgroundColor", BackgroundColor);
            LabelFont       = lReader.getAttribute<Font>("Font", LabelFont);
            AutoResize      = lReader.getAttribute<Boolean>("AutoResize", false);
            Format          = lReader.getAttribute<String>("Format", Format);
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("TextColor", StringUtils.ObjectToString(TextColor));
            aXMLTextWriter.WriteAttributeString("BackgroundColor", StringUtils.ObjectToString(BackgroundColor));
            aXMLTextWriter.WriteAttributeString("Font", StringUtils.ObjectToString(LabelFont));
            aXMLTextWriter.WriteAttributeString("AutoResize", StringUtils.ObjectToString(AutoResize));
            aXMLTextWriter.WriteAttributeString("Format", StringUtils.ObjectToString(mFormat));
        }

        public UserControl          UserControl { get { return this; } }

        public bool                 IsScalable { get { return true; } }

        public bool                 IsTransparent { get { return false; } }

        public bool                 IsConfigurable { get { return true; } }

        public bool                 IsContainer { get { return false; } }

        public bool                 IsSetupOnDblClick { get { return true; } }

        public void                 setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string               LabelText
        {
            get { return toolTip.GetToolTip(label_Value); }
            set
            {
                toolTip.SetToolTip(label_Value, value);
            }
        }

        public Color                TextColor
        {
            get { return label_Value.ForeColor; }
            set { label_Value.ForeColor = value; }
        }

        public Color                BackgroundColor
        {
            get { return label_Value.BackColor; }
            set { label_Value.BackColor = value; }
        }

        public Font                 LabelFont
        {
            get { return label_Value.Font; }
            set { label_Value.Font = value; }
        }

        private bool                mAutoResize = true;
        public bool                 AutoResize
        {
            get { return mAutoResize; }
            set
            {
                mAutoResize = value;
                if (mAutoResize)
                {
                    resizeToContent();
                }
            }
        }

        private string              mFormat     = "";
        public string               Format
        {
            get { return mFormat; }
            set
            {
                try
                {
                    StringUtils.ObjectToString(mObjectValue.ValueObject, value);
                    mFormat = value;
                    updateV();
                }
                catch {}
            }
        }

        public void                 updateValues()
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
        private void                updateV()
        {
            label_Value.Text = StringUtils.ObjectToString(mObjectValue.ValueObject, mFormat);
            if (mAutoResize)
            {
                resizeToContent();
            }
        }

        public void                 updateProperties()
        {
        }

        public void                 resizeToContent()
        {
            label_Value.AutoSize    = true;
            Width                   = label_Value.Width + 1;
            Height                  = label_Value.Height + 1;
            label_Value.AutoSize    = false;
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                mObjectValue = null;
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
