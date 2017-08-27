// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using API;
using LBSoft.IndustrialCtrls.Knobs;

namespace Utils.Panels.DoubleKnob
{
    public partial class DoubleKnobPanel : UserControl, IPanel
    {
        private IDoubleValueReadWrite   mDoubleValue;
        private bool                    mMaxMinCfg;

        public                          DoubleKnobPanel(IDoubleValueReadWrite aDoubleValue)
        {
            mDoubleValue = aDoubleValue;  
            InitializeComponent();

            mMaxMinCfg = false;
        }

        public                          DoubleKnobPanel(IDoubleValueReadWrite aDoubleValue, double aMaximum, double aMinimum)
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
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            LabelText       = lReader.getAttribute<String>("ToolTip", "");           
            ReadOnly        = lReader.getAttribute<System.Boolean>("ReadOnly", ReadOnly);
            KnobColor       = lReader.getAttribute<Color>("KnobColor", KnobColor);
            IndicatorColor  = lReader.getAttribute<Color>("IndicatorColor", IndicatorColor);
            ScaleColor      = lReader.getAttribute<Color>("ScaleColor", ScaleColor);
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
            aXMLTextWriter.WriteAttributeString("ReadOnly", StringUtils.ObjectToString(ReadOnly));
            aXMLTextWriter.WriteAttributeString("KnobColor", StringUtils.ObjectToString(KnobColor));
            aXMLTextWriter.WriteAttributeString("IndicatorColor", StringUtils.ObjectToString(IndicatorColor));
            aXMLTextWriter.WriteAttributeString("ScaleColor", StringUtils.ObjectToString(ScaleColor));
            if (mMaxMinCfg)
            {
                aXMLTextWriter.WriteAttributeString("MaxValue", StringUtils.ObjectToString(MaxValue));
                aXMLTextWriter.WriteAttributeString("MinValue", StringUtils.ObjectToString(MinValue));
            }
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return true; } }

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
            get { return toolTip.GetToolTip(lbKnob); }
            set { toolTip.SetToolTip(lbKnob, value); }
        }

        public Color                    KnobColor
        {
            get { return lbKnob.KnobColor; }
            set { lbKnob.KnobColor = value; }
        }

        public Color                    IndicatorColor
        {
            get { return lbKnob.IndicatorColor; }
            set { lbKnob.IndicatorColor = value; }
        }

        public Color                    ScaleColor
        {
            get { return lbKnob.ScaleColor; }
            set { lbKnob.ScaleColor = value; }
        }

        public bool                     ReadOnly
        {
            get { return lbKnob.ReadOnly; }
            set { lbKnob.ReadOnly = value; }
        }

        private double                  mValue;
        private volatile bool           mNoUpdate;

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
                mValue = mDoubleValue.ValueDouble;

                if (Double.IsNaN(mValue) == false && Double.IsInfinity(mValue) == false)
                {
                    float lValue;

                    if (mValue > MaxValue)
                    {
                        lValue = convertDoubleToSingle(lbKnob.MaxValue);
                    }
                    else if (mValue < MinValue)
                    {
                        lValue = convertDoubleToSingle(lbKnob.MinValue);
                    }
                    else
                    {
                        lValue = convertDoubleToSingle(mValue);
                    }

                    mNoUpdate = true;
                    try
                    {
                        lbKnob.Value = lValue;
                    }
                    finally
                    {
                        mNoUpdate = false;
                    }
                }
            }

            checkFault();
        }

        private void                    lbKnob_KnobChangeValue(object aSender, LBKnobEventArgs aEventArgs)
        {
            if (mNoUpdate) return;

            double lValue = (double)aEventArgs.Value;
            if (ValuesCompare.NotEqualDelta1.compare(mValue, lValue))
            {
                mValue                      = lValue;
                mDoubleValue.ValueDouble    = lValue;
            }

            checkFault();
        }

        private float                   convertDoubleToSingle(double aValue)
        {
            if (aValue > Single.MaxValue)
            {
                return Single.MaxValue;
            }
            else if (aValue < Single.MinValue)
            {
                return Single.MinValue;
            }
            else
            {
                return Convert.ToSingle(aValue);
            }
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

            float[] lThresholds = new float[mDoubleValue.Thresholds.Length];
            for (int i = 0; i < mDoubleValue.Thresholds.Length; i++)
            {
                lThresholds[i] = convertDoubleToSingle(mDoubleValue.Thresholds[i]);
            }
            lbKnob.Thresholds = lThresholds;  
        }

        public double                   MinValue
        {
            get { return lbKnob.MinValue; }
        }

        public double                   MaxValue
        {
            get { return lbKnob.MaxValue; }
        }

        public void                     setMaxMinValues(double aMaxValue, double aMinValue)
        {
            if (aMaxValue <= aMinValue)
            {
                throw new ArgumentException("Maximum value has to be greater than minimum. ");
            }
            lbKnob.MaxValue = convertDoubleToSingle(aMaxValue);
            lbKnob.MinValue = convertDoubleToSingle(aMinValue);
        }

        private void                    checkFault()
        {
            var lValue = mDoubleValue.ValueDouble;

            if (Double.IsNaN(lValue) || Double.IsInfinity(lValue) || lValue > MaxValue || lValue < MinValue)
            {
                lbKnob.BackColor = Color.Red;
            }
            else
            {
                lbKnob.BackColor = Color.Transparent;
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