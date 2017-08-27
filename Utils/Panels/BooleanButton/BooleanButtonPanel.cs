// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanButton
{
    public partial class BooleanButtonPanel : UserControl, IPanel
    {
        private IBooleanValueReadWrite  mBooleanValue;

        public                          BooleanButtonPanel(IBooleanValueReadWrite aBooleanValue)
        {
            mBooleanValue = aBooleanValue;
            InitializeComponent();
            
            updateButton();
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            TrueText    = lReader.getAttribute<String>("TrueText", "");
            TrueColor   = lReader.getAttribute<Color>("TrueColor", TrueColor);
            FalseText   = lReader.getAttribute<String>("FalseText", "");
            FalseColor  = lReader.getAttribute<Color>("FalseColor", FalseColor);
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("TrueText", TrueText);
            aXMLTextWriter.WriteAttributeString("TrueColor", StringUtils.ObjectToString(TrueColor));
            aXMLTextWriter.WriteAttributeString("FalseText", FalseText);
            aXMLTextWriter.WriteAttributeString("FalseColor", StringUtils.ObjectToString(FalseColor)); 
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                   LabelText
        {
            set { simpleButton.ToolTip = value; }
            get { return simpleButton.ToolTip; }
        }

        private Color                   mTrueColor = Color.LimeGreen;
        public Color                    TrueColor
        {
            get { return mTrueColor; }
            set 
            { 
                mTrueColor = value;
                updateButton();
            }
        }

        private Color                   mFalseColor = Color.LightGray;
        public Color                    FalseColor
        {
            get { return mFalseColor; }
            set 
            { 
                mFalseColor = value;
                updateButton();
            }
        }

        private string                  mTrueText = "True";
        public string                   TrueText
        {
            get { return mTrueText; }
            set
            {
                mTrueText = value;
                updateButton();
            }
        }

        private string                  mFalseText = "False";
        public string                   FalseText
        {
            get { return mFalseText; }
            set
            {
                mFalseText = value;
                updateButton();
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
            if (mValue != mBooleanValue.ValueBoolean)
            {
                mValue = mBooleanValue.ValueBoolean;
                updateButton();
            }
        }

        private void                    updateButton()
        {
            if (mValue)
            {
                simpleButton.Text = mTrueText;
                simpleButton.Appearance.BackColor = mTrueColor;
            }
            else
            {
                simpleButton.Text = mFalseText;
                simpleButton.Appearance.BackColor = mFalseColor;
            }
        }

        public void                     updateProperties()
        {
        }

        private bool                    mValue;
        private void                    simpleButton_Click(object aSender, EventArgs aEventArgs)
        {
            mValue                      = !mValue;
            mBooleanValue.ValueBoolean  = mValue;
            updateButton();
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing)
            {
                mBooleanValue = null;

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
