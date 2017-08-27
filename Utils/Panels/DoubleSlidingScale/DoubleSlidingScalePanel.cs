// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.DoubleSlidingScale
{
    public partial class DoubleSlidingScalePanel : UserControl, IPanel, IPanelExt
    {
        private IDoubleValueRead    mDoubleValue;

        public                      DoubleSlidingScalePanel(IDoubleValueRead aDoubleValue)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();
        }

        public void                 fillForDemo()
        {
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            LabelText       = lReader.getAttribute<String>("ToolTip", "");
            NeedleColor     = lReader.getAttribute<Color>("NeedleColor", NeedleColor);
            ScaleColor      = lReader.getAttribute<Color>("ScaleColor", ScaleColor);
            BodyColor       = lReader.getAttribute<Color>("BodyColor", BodyColor);
            Shadow          = lReader.getAttribute<Boolean>("Shadow", Shadow);
            ShadowColor     = lReader.getAttribute<Color>("ShadowColor", ShadowColor);
            LargeTickLength = lReader.getAttribute<Int32>("LargeTickLength", LargeTickLength);
            SmallTickLength = lReader.getAttribute<Int32>("SmallTickLength", SmallTickLength);
            LargeTickCount  = lReader.getAttribute<Int32>("LargeTickCount", LargeTickCount);
            SmallTickCount  = lReader.getAttribute<Int32>("SmallTickCount", SmallTickCount);
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("NeedleColor", StringUtils.ObjectToString(NeedleColor));
            aXMLTextWriter.WriteAttributeString("ScaleColor", StringUtils.ObjectToString(ScaleColor));
            aXMLTextWriter.WriteAttributeString("BodyColor", StringUtils.ObjectToString(BodyColor));
            aXMLTextWriter.WriteAttributeString("Shadow", StringUtils.ObjectToString(Shadow));
            aXMLTextWriter.WriteAttributeString("ShadowColor", StringUtils.ObjectToString(ShadowColor));
            aXMLTextWriter.WriteAttributeString("LargeTickLength", StringUtils.ObjectToString(LargeTickLength));
            aXMLTextWriter.WriteAttributeString("SmallTickLength", StringUtils.ObjectToString(SmallTickLength));
            aXMLTextWriter.WriteAttributeString("LargeTickCount", StringUtils.ObjectToString(LargeTickCount));
            aXMLTextWriter.WriteAttributeString("SmallTickCount", StringUtils.ObjectToString(SmallTickCount));
        }

        public UserControl          UserControl { get { return this; } }

        public bool                 IsScalable { get { return true; } }

        public bool                 IsTransparent { get { return false; } }

        public bool                 IsConfigurable { get { return true; } }

        public bool                 IsContainer { get { return false; } }

        public bool                 IsSetupOnDblClick { get { return true; } }

        public void                 setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string               LabelText
        {
            get { return toolTip.GetToolTip(slidingScale); }
            set { toolTip.SetToolTip(slidingScale, value); }
        }

        public Color                NeedleColor
        {
            get { return slidingScale.NeedleColor; }
            set { slidingScale.NeedleColor = value; }
        }

        public Color                ScaleColor
        {
            get { return slidingScale.ForeColor; }
            set { slidingScale.ForeColor = value; }
        }

        public Color                BodyColor
        {
            get { return slidingScale.BackColor; }
            set { slidingScale.BackColor = value; }
        }

        public Color                ShadowColor
        {
            get { return slidingScale.ShadowColor; }
            set { slidingScale.ShadowColor = value; }
        }

        public bool                 Shadow
        {
            get { return slidingScale.ShadowEnabled; }
            set { slidingScale.ShadowEnabled = value; }
        }

        public int                  LargeTickLength // >=0
        {
            get { return slidingScale.LargeTicksLength; }
            set { slidingScale.LargeTicksLength = value; }
        }

        public int                  SmallTickLength // >=0
        {
            get { return slidingScale.SmallTickLength; }
            set { slidingScale.SmallTickLength = value; }
        }

        public int                  LargeTickCount // >0
        {
            get { return slidingScale.LargeTicksCount; }
            set { slidingScale.LargeTicksCount = value; }
        }

        public int                  SmallTickCount // 0-9
        {
            get { return slidingScale.SmallTickCount; }
            set { slidingScale.SmallTickCount = value; }
        }

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
            if (Double.IsNaN(mDoubleValue.ValueDouble) == false && Double.IsInfinity(mDoubleValue.ValueDouble) == false)
            {
                slidingScale.Value = mDoubleValue.ValueDouble;
            }
        }

        public void                 updateProperties()
        {
        }

        private void                DoubleSlidingScalePanel_Resize(object aSender, EventArgs aEventArgs)
        {
            if (Height > Width)
            {
                slidingScale.Orientation = Orientation.Vertical;
            }
            else if (Height < Width)
            {
                slidingScale.Orientation = Orientation.Horizontal;
            }
        }

        protected override void     Dispose(bool disposing)
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
