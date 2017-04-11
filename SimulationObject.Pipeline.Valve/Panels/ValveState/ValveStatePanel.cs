// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Pipeline.Valve.Panels.ValveState
{
    public partial class ValveStatePanel : UserControl, IPanel
    {
        private Valve           mValve;
        private Bitmap          mBitmap         = new Bitmap(43, 34);
        private Graphics        mGraphics;
        private Bitmap          mStateBuf       = new Bitmap(43, 34);
        private Rectangle       mImageRect      = new Rectangle(0, 0, 43, 34);
        private Font            mFont           = new Font("Microsoft Sans Serif", 5);
        private StringFormat    mStringFormat   = new StringFormat();

        public                  ValveStatePanel(Valve aValve)
        {
            mValve                      = aValve;
            mGraphics                   = Graphics.FromImage(mBitmap);
            mGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            mStringFormat.Alignment     = StringAlignment.Center;
            mStringFormat.LineAlignment = StringAlignment.Far;
            InitializeComponent();

            pictureBox_State.Image = mBitmap;

            redrawStateBuf();
            redraw(0);
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
        private bool            mOpenLimit;
        private bool            mClosedLimit;
        private bool            mAlarm1;
        private bool            mAlarm2;
        private bool            mPower;
        private int             mPosition;
        private bool            mIgnoreCommands;
        private bool            mForseLimSwitches;
        private bool            mPositionFault;

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
            bool lBoolChanged =     mValve.Remote           != mRemote              ||
                                    mValve.OpenLimit        != mOpenLimit           ||
                                    mValve.ClosedLimit      != mClosedLimit         ||
                                    mValve.Alarm1           != mAlarm1              ||
                                    mValve.Alarm2           != mAlarm2              ||
                                    mValve.Power            != mPower               ||
                                    mValve.IgnoreCommands   != mIgnoreCommands      ||
                                    mValve.ForseLimSwitches != mForseLimSwitches    ||
                                    mValve.PositionFault    != mPositionFault;

            int lPosition = (int)Math.Truncate(mValve.Position);

            if ( lBoolChanged || lPosition != mPosition )
            {
                mRemote             = mValve.Remote;
                mOpenLimit          = mValve.OpenLimit;
                mClosedLimit        = mValve.ClosedLimit;
                mAlarm1             = mValve.Alarm1;
                mAlarm2             = mValve.Alarm2;
                mPower              = mValve.Power;
                mIgnoreCommands     = mValve.IgnoreCommands;
                mForseLimSwitches   = mValve.ForseLimSwitches;
                mPositionFault      = mValve.PositionFault;
                mPosition           = lPosition;

                if( lBoolChanged )
                {
                    redrawStateBuf();
                }

                redraw(lPosition);
            }
        }

        private void            redrawStateBuf()
        {
            var lGraphics = Graphics.FromImage(mStateBuf);
            lGraphics.Clear(Color.Transparent);

            if (mValve.Remote)
            {
                lGraphics.DrawImage((Image)SimulationObject.Pipeline.Valve.Properties.Resources.Vlv_DC, mImageRect);
            }
            else
            {
                lGraphics.DrawImage((Image)SimulationObject.Pipeline.Valve.Properties.Resources.Vlv_NDC, mImageRect);
            }

            if (mValve.OpenLimit)
            {
                lGraphics.DrawImage((Image)SimulationObject.Pipeline.Valve.Properties.Resources.Vlv_OP, mImageRect);
            }
            else if (mValve.ClosedLimit)
            {
                lGraphics.DrawImage((Image)SimulationObject.Pipeline.Valve.Properties.Resources.Vlv_CL, mImageRect);
            }
            else
            {
                lGraphics.DrawImage((Image)SimulationObject.Pipeline.Valve.Properties.Resources.Vlv_OP_CL, mImageRect);
            }

            if (mValve.Alarm1 || mValve.Alarm2 || !mValve.Power || mValve.IgnoreCommands || mValve.ForseLimSwitches || mValve.PositionFault)
            {
                lGraphics.DrawImage((Image)SimulationObject.Pipeline.Valve.Properties.Resources.Alarm, mImageRect);
            }

            lGraphics.Dispose();
        }

        private void            redraw(int aPosition)
        {
            mGraphics.Clear(Color.Transparent);
            mGraphics.DrawImage(mStateBuf, mImageRect);
            mGraphics.DrawString(StringUtils.ObjectToString(aPosition), mFont, Brushes.Black, mImageRect, mStringFormat);
            pictureBox_State.Refresh();
        }

        public void             updateProperties()
        {
        }

        private void            pictureBox_State_MouseClick(object aSender, MouseEventArgs aEventArgs)
        {
            if (aEventArgs.Button == MouseButtons.Left)
            {
                using (var lPanelForm = new PanelForm(mValve, "Control", LabelText))
                {
                    lPanelForm.ShowDialog();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mValve = null;
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

                if(mFont != null)
                {
                    mFont.Dispose();
                    mFont = null;
                }

                if (mBitmap != null)
                {
                    pictureBox_State.Image = null;
                    mBitmap.Dispose();
                    mBitmap = null;
                }

                if (mStateBuf != null)
                {
                    mStateBuf.Dispose();
                    mStateBuf = null;
                }

                if (mStringFormat != null)
                {
                    mStringFormat.Dispose();
                    mStringFormat = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
