using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using API;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Pipeline.Pump.Panels.PumpState
{
    public partial class PumpStatePanel : UserControl, IPanel
    {
        private Pump            mPump;
        private Bitmap          mBitmap         = new Bitmap(43, 34);
        private Graphics        mGraphics;
        private RectangleF      mImageRect      = new RectangleF(0, 0, 43, 34);

        public                  PumpStatePanel(Pump aPump)
        {
            mPump                       = aPump;
            mGraphics                   = Graphics.FromImage(mBitmap);
            mGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            InitializeComponent();

            pictureBox_State.Image      = mBitmap;
			
            redraw();
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
            get { return toolTip.GetToolTip(pictureBox_State); }
            set
            {
                toolTip.SetToolTip(pictureBox_State, value);
            }
        }

        private bool            mRemote;
        private bool            mOn;
        private bool            mPower;
        private bool            mAlarm;
        private bool            mEsd;
        private bool            mIgnoreCommands;

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
            if (
                    mPump.Remote            != mRemote  ||
                    mPump.On                != mOn      ||
                    mPump.Power             != mPower   ||
                    mPump.Alarm             != mAlarm   ||
                    mPump.mEsdCMD           != mEsd     ||
                    mPump.IgnoreCommands    != mIgnoreCommands
                )
            {
                mRemote         = mPump.Remote;
                mOn             = mPump.On;
                mPower          = mPump.Power;
                mAlarm          = mPump.Alarm;
                mEsd            = mPump.mEsdCMD;
                mIgnoreCommands = mPump.IgnoreCommands;

                redraw();
            }
        }

        private void            redraw()
        {
            mGraphics.Clear(Color.Transparent);

            if (mPump.Remote)
            {
                mGraphics.DrawImage((Image)SimulationObject.Pipeline.Pump.Properties.Resources.Pmp_DC, mImageRect);
            }
            else
            {
                mGraphics.DrawImage((Image)SimulationObject.Pipeline.Pump.Properties.Resources.Pmp_NDC, mImageRect);
            }

            if (mPump.On)
            {
                mGraphics.DrawImage((Image)SimulationObject.Pipeline.Pump.Properties.Resources.Pmp_On, mImageRect);
            }
            else
            {
                mGraphics.DrawImage((Image)SimulationObject.Pipeline.Pump.Properties.Resources.Pmp_Off, mImageRect);
            }

            if (mPump.Power == false || mPump.Alarm || mPump.mEsdCMD || mPump.IgnoreCommands)
            {
                mGraphics.DrawImage((Image)SimulationObject.Pipeline.Pump.Properties.Resources.Alarm, mImageRect);
            }

            pictureBox_State.Refresh();
        }

        public void             updateProperties()
        {
        }

        private void            pictureBox_State_MouseClick(object aSender, MouseEventArgs aEventArgs)
        {
            if (aEventArgs.Button == System.Windows.Forms.MouseButtons.Left)
            {
                using (var lPanelForm = new PanelForm(mPump, "Control", LabelText))
                {
                    lPanelForm.ShowDialog();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mPump = null;
                toolTip.RemoveAll();

                if (components != null)
                {
                    components.Dispose();
                }

                if (mGraphics != null)
                {
                    mGraphics.Dispose();
                    mGraphics = null;
                }

                if (mBitmap != null)
                {
                    mBitmap.Dispose();
                    mBitmap = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
