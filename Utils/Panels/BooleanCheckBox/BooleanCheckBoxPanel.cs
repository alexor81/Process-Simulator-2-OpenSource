// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanCheckBox
{
    public partial class BooleanCheckBoxPanel : UserControl, IPanel
    {
        private IBooleanValueReadWrite  mBooleanValue;

        public                          BooleanCheckBoxPanel(IBooleanValueReadWrite aBooleanValue)
        {
            mBooleanValue = aBooleanValue;
            InitializeComponent();

            BackColor = SystemColors.Control;
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            LabelText       = lReader.getAttribute<String>("Text", "");
            RightLeft       = lReader.getAttribute<Boolean>("RightLeft", mRightLeft);
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Text", LabelText);
            aXMLTextWriter.WriteAttributeString("RightLeft", StringUtils.ObjectToString(RightLeft));
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return false; } }

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
            get { return checkBox.Text; }
            set
            {
                checkBox.Text = value;
                Width = checkBox.Width + 5;
            }
        }

        private bool                    mRightLeft = false;
        public bool                     RightLeft
        {
            get { return mRightLeft; }
            set
            {
                if (mRightLeft != value)
                {
                    mRightLeft = value;
                    if (mRightLeft)
                    {
                        checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
                    }
                    else
                    {
                        checkBox.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    }   
                }
            }
        }

        public void                     updateValues()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateCheckBox(); }));
            }
            else
            {
                updateCheckBox();
            }
        }

        public void                     updateProperties()
        {
        }

        private void                    updateCheckBox()
        {
            if (mBooleanValue.ValueBoolean != checkBox.Checked)
            {
                checkBox.Checked = mBooleanValue.ValueBoolean;
            }
        }

        private void                    checkBox_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mBooleanValue.ValueBoolean != checkBox.Checked)
            {
                mBooleanValue.ValueBoolean = checkBox.Checked;
            }
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
