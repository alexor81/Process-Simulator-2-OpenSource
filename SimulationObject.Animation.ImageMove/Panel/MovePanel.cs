using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;
using Utils.Logger;

namespace SimulationObject.Animation.ImageMove.Panel
{
    public partial class MovePanel : UserControl, IPanel
    {
        private Move            mMove;
        private bool            mDemo;

        public                  MovePanel(Move aMove)
        {
            mDemo = false;
            mMove = aMove;
            InitializeComponent();
        }

        public void             fillForDemo()
        {
            mDemo = true;
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

        public bool             IsTransparent { get { return true; } }

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
            get { return toolTip.GetToolTip(this); }
            set
            {
                toolTip.SetToolTip(this, value);
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
            if (mDemo == false)
            {
                Location = new Point(mMove.mXValue, mMove.mYValue);
                if (pictureBox.Enabled)
                {
                    Visible = mMove.mVisible;
                }
                else
                {
                    Visible = true;
                }
            }
            else
            {
                Visible = true;
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
            if (mMove.mBmp != null)
            {
                pictureBox.Image    = mMove.mBmp;
                Size                = mMove.mBmp.Size;
            }
            else
            {
                Log.Error("Error in panel for Animation.ImageMove. Image is empty. ");
            }
        }

        private void            pictureBox_EnabledChanged(object aSender, EventArgs aEventArgs)
        {
            updateV();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mMove = null;
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
