// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace SimulationObject.Robot.Conveyor.Panel.ConveyorState
{
    public partial class ConveyorStatePanel : UserControl, IPanel
    {
        private Conveyor        mConveyor;
        private Bitmap          mBackground = new Bitmap(240, 36);
        private Bitmap          mControl    = new Bitmap(240, 36);
        private Bitmap          mBitmap     = new Bitmap(240, 36);
        private Graphics        mGraphics;
 
        private IConveyorLayout mLayout     =  new BeltSideLayout();
        public string           LayoutType
        {
            get
            {
                if (mLayout is BeltTopLayout)
                {
                    return "BeltTop";
                }
                else 
                {
                    return "BeltSide";
                }
            }
            set
            {
                if (LayoutType.Equals(value, StringComparison.Ordinal) == false)
                {
                    if (value.Equals("BeltTop", StringComparison.Ordinal))
                    {
                        mLayout = new BeltTopLayout();
                    }
                    else
                    {
                        mLayout = new BeltSideLayout();
                    }
                    mFullUpdate = true;
                }
            }
        }

        public                  ConveyorStatePanel(Conveyor aConveyor)
        {
            mConveyor                   = aConveyor;
            mGraphics                   = Graphics.FromImage(mBitmap);
            mGraphics.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            mGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            InitializeComponent();

            pictureBox_State.Image = mBitmap;
            mLayout.drawBackground(mBackground);
            mLayout.drawControl(mControl, mBackground, false, false, false);
            mLayout.draw(0, mGraphics, mControl, false, 0, false);

            mLastMS                     = MiscUtils.TimerMS;
            timer_Animation.Interval    = 30;
            timer_Animation.Enabled     = true;
        }

        public void             fillForDemo()
        {
        }

        public void             loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            LayoutType  = lReader.getAttribute<String>("Type", "");
        }

        public void             saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("Type", LayoutType);
        }

        public UserControl      UserControl { get { return this; } }

        public bool             IsScalable { get { return true; } }

        public bool             IsTransparent { get { return true; } }

        public bool             IsConfigurable { get { return true; } }

        public bool             IsContainer { get { return false; } }

        public void             setupByForm(IWin32Window aOwner)
        {
            using (var lSetup = new SetupForm(this))
            {
                lSetup.ShowDialog(this);
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

        private volatile bool   mFullUpdate;
        private volatile bool   mControlUpdate;
        private bool            mMoving;
        private bool            mReverse;
        private bool            mAlarm;
        private bool            mForward;
        private bool            mBackward;
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
            bool lBoolChanged = (mConveyor.Moving != mMoving) ||
                                (mConveyor.Reverse != mReverse) ||
                                (mConveyor.Alarm != mAlarm) ||
                                (mConveyor.Forward != mForward) ||
                                (mConveyor.Backward != mBackward) ||
                                (mConveyor.IgnoreCommands != mIgnoreCommands);

            if (lBoolChanged)
            {
                mMoving         = mConveyor.Moving;
                mAlarm          = mConveyor.Alarm;
                mReverse        = mConveyor.Reverse;
                mForward        = mConveyor.Forward;
                mBackward       = mConveyor.Backward;
                mIgnoreCommands = mConveyor.IgnoreCommands;

                mControlUpdate  = true;
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
            mFullUpdate = true;
        }

        private long            mLastMS;
        private void            timer_Animation_Tick(object aSender, EventArgs aEventArgs)
        {
            long lFromLast = MiscUtils.TimerMS - mLastMS;

            if (mFullUpdate)
            {
                mFullUpdate     = false;
                mControlUpdate  = false;
                bool lResize = (mBackground.Size != pictureBox_State.Size);

                if (lResize)
                {
                    mBackground.Dispose();
                    mBackground = new Bitmap(pictureBox_State.Width, pictureBox_State.Height);

                    mControl.Dispose();
                    mControl = new Bitmap(pictureBox_State.Width, pictureBox_State.Height);
                }

                mLayout.drawBackground(mBackground);
                mLayout.drawControl(mControl, mBackground, mConveyor.Moving, 
                                    mConveyor.Forward, mConveyor.Alarm || mConveyor.IgnoreCommands);

                Bitmap lBitmap;
                Graphics lGraphics;

                if (lResize)
                {
                    lBitmap                     = new Bitmap(pictureBox_State.Width, pictureBox_State.Height);
                    lGraphics                   = Graphics.FromImage(lBitmap);
                    lGraphics.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    lGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                }
                else
                {
                    lBitmap     = mBitmap;
                    lGraphics   = mGraphics;
                }
            
                mLayout.draw(lFromLast, mGraphics, mControl, mConveyor.Moving, 
                                mConveyor.Speed, mConveyor.Forward);

                if (ReferenceEquals(lGraphics, mGraphics) == false)
                {
                    pictureBox_State.Image = lBitmap;
                    mGraphics.Dispose();
                    mBitmap.Dispose();

                    mBitmap     = lBitmap;
                    mGraphics   = lGraphics;
                }
            }
            else if (mControlUpdate)
            {
                mControlUpdate  = false;
                mLayout.drawControl(mControl, mBackground, mConveyor.Moving, 
                                    mConveyor.Forward, mConveyor.Alarm || mConveyor.IgnoreCommands);
                mLayout.draw(lFromLast, mGraphics, mControl, mConveyor.Moving, 
                             mConveyor.Speed, mConveyor.Forward);
            }
            else
            {
                mLayout.draw(lFromLast, mGraphics, mControl, mConveyor.Moving, 
                            mConveyor.Speed, mConveyor.Forward);
            }

            pictureBox_State.Refresh();
            mLastMS = MiscUtils.TimerMS;
        }

        private void            ConveyorPanel_SizeChanged(object aSender, EventArgs aEventArgs)
        {
            mFullUpdate = true;
        }

        private void            pictureBox_State_MouseClick(object aSender, MouseEventArgs aEventArgs)
        {
            if (aEventArgs.Button == MouseButtons.Left)
            {
                using (var lPanelForm = new PanelForm(mConveyor, "Control", LabelText))
                {
                    lPanelForm.ShowDialog();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer_Animation.Enabled = false;    

                mConveyor = null;
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
                    pictureBox_State.Image = null;
                    mBitmap.Dispose();                   
                    mBitmap = null;
                }

                if (mBackground != null)
                {
                    mBackground.Dispose();
                    mBackground = null;
                }

                if (mControl != null)
                {
                    mControl.Dispose();
                    mControl = null;
                }

                if (mLayout != null)
                {
                    mLayout.Dispose();
                    mLayout = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}
