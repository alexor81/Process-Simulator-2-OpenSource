// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Utils.SpecialControls;

namespace Utils.Panels.DoubleBar
{
    public partial class DoubleBarPanel : UserControl, IPanel, IPanelExt
    {
        private ProgressBar         mProgressBar;
        private IDoubleValueRead    mDoubleValue;
        private bool                mMaxMinCfg;
        private ValueScale          mValueScale = new ValueScale();

        public                      DoubleBarPanel(IDoubleValueRead aDoubleValue)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();

            BackColor   = SystemColors.Control;
            mMaxMinCfg  = false;
            createProgressBar();
        }

        public                      DoubleBarPanel(IDoubleValueRead aDoubleValue, double aMaximum, double aMinimum)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();

            BackColor   = SystemColors.Control;
            mMaxMinCfg  = true;
            setMaxMinValues(aMaximum, aMinimum);
            createProgressBar();
        }

        private bool                mVertical = false;
        public bool                 Vertical
        {
            get { return mVertical; }
            set
            {
                if (mVertical != value)
                {
                    mVertical = value;
                    createProgressBar();
                }
            }
        }
        private void                createProgressBar()
        {
            ProgressBar lPrevPB = null;
            if (mProgressBar != null)
            {
                lPrevPB = mProgressBar;
                Controls.Remove(mProgressBar);
            }

            ProgressBar lNewPB;
            if (mVertical)
            {
                lNewPB = new VerticalProgressBar();
            }
            else
            {
                lNewPB = new ProgressBar();
            }

            lNewPB.Dock     = DockStyle.Fill;
            lNewPB.Location = new Point(0, 0);
            lNewPB.Maximum  = 27648;
            lNewPB.Name     = "progressBar";
            lNewPB.Style    = ProgressBarStyle.Continuous;
            if (lPrevPB != null)
            {
                lNewPB.Value        = lPrevPB.Value;
                lNewPB.ForeColor    = lPrevPB.ForeColor;
                string lToolTip     = toolTip.GetToolTip(lPrevPB);
                toolTip.RemoveAll();
                toolTip.SetToolTip(lNewPB, lToolTip); 
            }
            Controls.Add(lNewPB);
            mProgressBar = lNewPB;

            mProgressBar.Click += ProgressBar_Click;

            if (lPrevPB != null)
            {
                lPrevPB.Click -= ProgressBar_Click;
                lPrevPB.Dispose();
            }
        }

        private long                mLastClick = 0;
        private void                ProgressBar_Click(object aSender, EventArgs aEventArgs)
        {
            if (mLastClick == 0 || MiscUtils.TimerMS - mLastClick > SystemInformation.DoubleClickTime)
            {
                mLastClick = MiscUtils.TimerMS;
            }
            else
            {
                var lMethodInfo = this.GetType().GetMethod("OnDoubleClick", BindingFlags.NonPublic | BindingFlags.Instance);
                lMethodInfo.Invoke(this, new object[] { EventArgs.Empty });
                mLastClick = 0;
            }
        }

        public void                 fillForDemo()
        {
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader         = new XMLAttributeReader(aXMLTextReader);           
            LabelText           = lReader.getAttribute<String>("ToolTip", "");
            Vertical            = lReader.getAttribute<Boolean>("Vertical", Vertical);
            Color               = lReader.getAttribute<Color>("Color", Color);
            if (mMaxMinCfg)
            {
                double lMaximum = lReader.getAttribute<Double>("MaxValue", MaxValue);
                double lMinimum = lReader.getAttribute<Double>("MinValue", MinValue);
                setMaxMinValues(lMaximum, lMinimum);
            }
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);      
            aXMLTextWriter.WriteAttributeString("Vertical", StringUtils.ObjectToString(Vertical));
            aXMLTextWriter.WriteAttributeString("Color", StringUtils.ObjectToString(Color));
            if (mMaxMinCfg)
            {
                aXMLTextWriter.WriteAttributeString("MaxValue", StringUtils.ObjectToString(MaxValue));
                aXMLTextWriter.WriteAttributeString("MinValue", StringUtils.ObjectToString(MinValue));
            }
        }

        public UserControl          UserControl { get { return this; } }

        public bool                 IsScalable { get { return true; } }

        public bool                 IsTransparent { get { return false; } }

        public bool                 IsConfigurable { get { return true; } }

        public bool                 IsContainer { get { return false; } }

        public bool                 IsSetupOnDblClick { get { return true; } }

        public void                 setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this, mMaxMinCfg))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string               LabelText
        {
            get { return toolTip.GetToolTip(mProgressBar); }
            set { toolTip.SetToolTip(mProgressBar, value); }
        }

        public Color                Color
        {
            get { return mProgressBar.ForeColor; }
            set { mProgressBar.ForeColor = value; }
        }

        public double               MaxValue
        {
            get { return mValueScale.OutMax; }
        }

        public double               MinValue
        {
            get { return mValueScale.OutMin; }
        }

        public void                 setMaxMinValues(double aMaxValue, double aMinValue)
        {
            mValueScale.setProperties(27648, 0, aMaxValue, aMinValue);
        }

        private double              mValue;
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
            if (ValuesCompare.NotEqualDelta1.compare(mValue, mDoubleValue.ValueDouble))
            {
                mValue = mDoubleValue.ValueDouble;

                if (Double.IsNaN(mValue) == false && Double.IsInfinity(mValue) == false)
                {
                    double lValue   = mValueScale.unscale(mDoubleValue.ValueDouble);
                    if (lValue > mValueScale.InMax)
                    {
                        lValue = mValueScale.InMax;
                    }
                    else if (lValue < mValueScale.InMin)
                    {
                        lValue = mValueScale.InMin;
                    }

                    mProgressBar.Value = Convert.ToInt32(lValue);
                }
            }
        }

        public void                 updateProperties()
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
        private void                updateP()
        {
            if (mMaxMinCfg == false)
            {
                IDoubleValueReadWrite lReadWrite = mDoubleValue as IDoubleValueReadWrite;
                if (lReadWrite != null)
                {
                    setMaxMinValues(lReadWrite.Maximum, lReadWrite.Minimum);
                }
            }
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                mDoubleValue = null;

                if (mProgressBar != null)
                {
                    Controls.Remove(mProgressBar);
                    mProgressBar.Dispose();
                    mProgressBar = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
