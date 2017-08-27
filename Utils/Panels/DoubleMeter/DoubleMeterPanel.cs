// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.DoubleMeter
{
    public partial class DoubleMeterPanel : UserControl, IPanel, IPanelExt
    {
        private IDoubleValueRead        mDoubleValue;
        private bool                    mMaxMinCfg;

        public                          DoubleMeterPanel(IDoubleValueRead aDoubleValue)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();

            mMaxMinCfg = false;
        }

        public                          DoubleMeterPanel(IDoubleValueRead aDoubleValue, double aMaximum, double aMinimum)
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
            BodyColor       = lReader.getAttribute<Color>("BodyColor", BodyColor);
            NeedleColor     = lReader.getAttribute<Color>("NeedleColor", NeedleColor);
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
            aXMLTextWriter.WriteAttributeString("BodyColor", StringUtils.ObjectToString(BodyColor));
            aXMLTextWriter.WriteAttributeString("NeedleColor", StringUtils.ObjectToString(NeedleColor));
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

        public bool                     IsSetupOnDblClick { get { return true; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this, mMaxMinCfg))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                   LabelText
        {
            get { return toolTip.GetToolTip(lbAnalogMeter); }
            set { toolTip.SetToolTip(lbAnalogMeter, value); }
        }

        public double                   MinValue
        {
            get { return lbAnalogMeter.MinValue; }
        }

        public double                   MaxValue
        {
            get { return lbAnalogMeter.MaxValue; }
        }

        public void                     setMaxMinValues(double aMaxValue, double aMinValue)
        {
            if (aMaxValue <= aMinValue)
            {
                throw new ArgumentException("Maximum value has to be greater than minimum. ");
            }
            lbAnalogMeter.MaxValue = aMaxValue;
            lbAnalogMeter.MinValue = aMinValue;
        }

        public Color                    BodyColor
        {
            get { return lbAnalogMeter.BodyColor; }
            set { lbAnalogMeter.BodyColor = value; }
        }

        public Color                    NeedleColor
        {
            get { return lbAnalogMeter.NeedleColor; }
            set { lbAnalogMeter.NeedleColor = value; }
        }

        public Color                    ScaleColor
        {
            get { return lbAnalogMeter.ScaleColor; }
            set { lbAnalogMeter.ScaleColor = value; }
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
            lbAnalogMeter.Value = mDoubleValue.ValueDouble;
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
                IDoubleValueReadWrite lReadWrite = mDoubleValue as IDoubleValueReadWrite;
                if (lReadWrite != null)
                {
                    setMaxMinValues(lReadWrite.Maximum, lReadWrite.Minimum);
                }
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
