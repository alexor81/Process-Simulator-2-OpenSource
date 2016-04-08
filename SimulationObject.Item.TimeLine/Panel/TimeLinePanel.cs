using System;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Item.TimeLine.Panel
{
    public partial class TimeLinePanel : UserControl, IPanel
    {
        private TimeLine        mTimeLine;

        public                  TimeLinePanel(TimeLine aTimeLine)
        {
            mTimeLine = aTimeLine;
            InitializeComponent();
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
                toolTip.SetToolTip(playPause, value);
                toolTip.SetToolTip(checkBox_Loop, value);
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
            playPause.Checked = mTimeLine.On;
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
            checkBox_Loop.Checked = mTimeLine.Loop;
        }

        private void            playPause_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mTimeLine.On != playPause.Checked)
            {
                mTimeLine.On = playPause.Checked;
            }
        }

        private void            checkBox_Loop_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mTimeLine.Loop != checkBox_Loop.Checked)
            {
                mTimeLine.Loop = checkBox_Loop.Checked;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mTimeLine = null;
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
