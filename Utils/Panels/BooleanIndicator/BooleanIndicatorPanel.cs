// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using LBSoft.IndustrialCtrls.Leds;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanIndicator
{
    public partial class BooleanIndicatorPanel : UserControl, IPanel, IPanelExt
    {
        private IBooleanValueRead   mBooleanValue;

        public                      BooleanIndicatorPanel(IBooleanValueRead aBooleanValue)
        {
            mBooleanValue = aBooleanValue;
            InitializeComponent();

            BackColor = SystemColors.Control;
        }

        public void                 fillForDemo()
        {
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            LabelText       = lReader.getAttribute<String>("Text", "");

            if(lReader.getAttribute<String>("Shape", Shape.ToString()).Equals("Ellipse"))
            {
                Shape = LBLed.LedStyle.Circular;
            }
            else
            {
                Shape = LBLed.LedStyle.Rectangular;
            }

            TrueColor       = lReader.getAttribute<Color>("TrueColor", TrueColor);
            FalseColor      = lReader.getAttribute<Color>("FalseColor", FalseColor);

            Blink           = lReader.getAttribute<Boolean>("Blink", Blink);
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Text", LabelText);

            if (Shape == LBLed.LedStyle.Circular)
            {
                aXMLTextWriter.WriteAttributeString("Shape", "Ellipse");
            }
            else
            {
                aXMLTextWriter.WriteAttributeString("Shape", "Rectangle");
            }

            aXMLTextWriter.WriteAttributeString("TrueColor", StringUtils.ObjectToString(TrueColor));
            aXMLTextWriter.WriteAttributeString("FalseColor", StringUtils.ObjectToString(FalseColor));

            aXMLTextWriter.WriteAttributeString("Blink", StringUtils.ObjectToString(Blink));
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
            get { return label.Text; }
            set
            {
                label.Text = value;
                updateSize();
            }
        }

        private void                updateSize()
        {
            int lSplitterDist               = splitContainer.SplitterDistance;
            Width                           = lSplitterDist + label.Width + 5;
            splitContainer.SplitterDistance = lSplitterDist;
        }

        private void                BooleanIndicatorPanel_Resize(object aSender, EventArgs aEventArgs)
        {
            label.Top = Height / 2 - label.Height / 2;
        }

        private void                lbLed_SizeChanged(object aSender, EventArgs aEventArgs)
        {
            lbLed.LedSize = new SizeF(lbLed.Size.Width - 2, lbLed.Size.Height - 2);
        }

        public void                 fitToContent()
        {
            splitContainer.SplitterDistance = Height;
            updateSize();
        }

        public LBLed.LedStyle       Shape
        {
            get { return lbLed.Style; }
            set { lbLed.Style = value; }
        }

        public Color                TrueColor
        {
            get { return lbLed.LedColor; }
            set { lbLed.LedColor = value; }
        }

        public Color                FalseColor
        {
            get { return lbLed.LedOffColor; }
            set { lbLed.LedOffColor = value; }
        }

        private bool                mBlink = false;
        public bool                 Blink
        {
            get { return mBlink; }
            set
            {
                mBlink = value;
                updateValues();
            }
        }

        public void                 updateValues()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateIndicator(); }));
            }
            else
            {
                updateIndicator();
            }
        }
        private void                updateIndicator()
        {
            if (mBooleanValue.ValueBoolean)
            {
                if (mBlink)
                {
                    lbLed.State = LBLed.LedState.Blink;
                }
                else
                {
                    lbLed.State = LBLed.LedState.On;
                }
            }
            else
            {
                lbLed.State = LBLed.LedState.Off;
            }
        }

        public void                 updateProperties()
        {
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                mBooleanValue = null;

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
