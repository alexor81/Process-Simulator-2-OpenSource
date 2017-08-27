// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.DoubleSlider
{
    public partial class DoubleSliderPanel : UserControl, IPanel
    {
        private IDoubleValueReadWrite   mDoubleValue;
        private bool                    mMaxMinCfg;
        private ValueScale              mValueScale = new ValueScale();

        public                          DoubleSliderPanel(IDoubleValueReadWrite aDoubleValue)
        { 
            mDoubleValue = aDoubleValue;           
            InitializeComponent();

            mMaxMinCfg = false;
        }

        public                          DoubleSliderPanel(IDoubleValueReadWrite aDoubleValue, double aMaximum, double aMinimum)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();

            mMaxMinCfg = true;
            setMaxMinValues(aMaximum, aMinimum);
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            NeedleColor = lReader.getAttribute<Color>("NeedleColor", NeedleColor);
            ReadOnly    = lReader.getAttribute<System.Boolean>("ReadOnly", ReadOnly);
            if (mMaxMinCfg)
            {
                double lMaximum = lReader.getAttribute<Double>("MaxValue", MaxValue);
                double lMinimum = lReader.getAttribute<Double>("MinValue", MinValue);
                setMaxMinValues(lMaximum, lMinimum);
            }
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("NeedleColor", StringUtils.ObjectToString(NeedleColor));
            aXMLTextWriter.WriteAttributeString("ReadOnly", StringUtils.ObjectToString(ReadOnly));
            if(mMaxMinCfg)
            {
                aXMLTextWriter.WriteAttributeString("MaxValue", StringUtils.ObjectToString(MaxValue));
                aXMLTextWriter.WriteAttributeString("MinValue", StringUtils.ObjectToString(MinValue));
            }
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this, mMaxMinCfg))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                   LabelText
        {
            get { return  toolTip.GetToolTip(sliderControl); }
            set { toolTip.SetToolTip(sliderControl, value); }
        }

        public Color                    NeedleColor
        {
            get { return sliderControl.NeedleColor; }
            set { sliderControl.NeedleColor = value; }
        }

        private double                  mValue;
        private volatile bool           mNoUpdate;

        public bool                     ReadOnly
        {
            get { return sliderControl.mReadOnly; }
            set { sliderControl.mReadOnly = value; }
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
            if (ValuesCompare.NotEqualDelta1.compare(mValue, mDoubleValue.ValueDouble))
            {
                mValue          = mDoubleValue.ValueDouble;

                if (Double.IsNaN(mValue) == false && Double.IsInfinity(mValue) == false)
                {
                    double lValue   = mValueScale.unscale(mDoubleValue.ValueDouble);

                    if (lValue > sliderControl.Maximum)
                    {
                        lValue = sliderControl.Maximum;
                    }
                    else if (lValue < sliderControl.Minimum)
                    {
                        lValue = sliderControl.Minimum;
                    }

                    mNoUpdate = true;
                    try
                    {
                        sliderControl.Value = Convert.ToInt32(lValue);
                    }
                    finally
                    {
                        mNoUpdate = false;
                    }
                }
            }

            checkFault();
        }

        private void                    sliderControl_ValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mNoUpdate) return;

            double lValue = mValueScale.scale(sliderControl.Value);
            if (ValuesCompare.NotEqualDelta1.compare(mValue, lValue))
            {
                mValue                      = lValue;
                mDoubleValue.ValueDouble    = lValue;
            }

            checkFault();
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
            if (mMaxMinCfg == false)
            {
                setMaxMinValues(mDoubleValue.Maximum, mDoubleValue.Minimum);
            }

            checkFault();

            int[] lThesholds = new int[mDoubleValue.Thresholds.Length];
            for (int i = 0; i < mDoubleValue.Thresholds.Length; i++)
            {
                lThesholds[i] = Convert.ToInt32(mValueScale.unscale(mDoubleValue.Thresholds[i]));
            }
            sliderControl.Thresholds = lThesholds;             
        }

        public double                   MinValue
        {
            get { return mValueScale.OutMin; }
        }

        public double                   MaxValue
        {
            get { return mValueScale.OutMax; }
        }

        public void                     setMaxMinValues(double aMaxValue, double aMinValue)
        {
            if (aMaxValue <= aMinValue)
            {
                throw new ArgumentException("Maximum value has to be greater than minimum. ");
            }
            mValueScale.setProperties(27648, 0, aMaxValue, aMinValue);
        }

        private void                    checkFault()
        {
            var lValue = mDoubleValue.ValueDouble;

            if (Double.IsNaN(lValue) || Double.IsInfinity(lValue) || lValue > MaxValue || lValue < MinValue)
            {
                sliderControl.BackColor = Color.Red;
            }
            else
            {
                sliderControl.BackColor = SystemColors.Control;
            }
        }

        private void                    DoubleSliderPanel_Resize(object aSender, EventArgs aEventArgs)
        {
            if (Height > Width)
            {
                sliderControl.Orientation = Orientation.Vertical;
            }
            else if (Height < Width)
            {
                sliderControl.Orientation = Orientation.Horizontal;
            }
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing)
            {
                mDoubleValue = null;
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
