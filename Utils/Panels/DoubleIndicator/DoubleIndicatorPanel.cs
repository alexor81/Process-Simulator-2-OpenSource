// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.DoubleIndicator
{
    public partial class DoubleIndicatorPanel : UserControl, IPanel, IPanelExt
    {
        private IDoubleValueRead        mDoubleValue;

        public                          DoubleIndicatorPanel(IDoubleValueRead aDoubleValue)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();

            BackColor   = SystemColors.Control;
            MaximumSize = new Size(Int32.MaxValue, label_Value.Height + 2);
            MinimumSize = new Size(0, label_Value.Height + 2);
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);
            LabelText       = lReader.getAttribute<String>("ToolTip", "");
            ShowUnits       = lReader.getAttribute<Boolean>("ShowUnits", ShowUnits);
            Units           = lReader.getAttribute<String>("Units", "");
            Round           = lReader.getAttribute<Int32>("Round", Round);
            TextColor       = lReader.getAttribute<Color>("TextColor", TextColor);
            BackgroundColor = lReader.getAttribute<Color>("BackgroundColor", BackgroundColor);
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("ShowUnits", StringUtils.ObjectToString(ShowUnits));
            aXMLTextWriter.WriteAttributeString("Units", mUnits);
            aXMLTextWriter.WriteAttributeString("Round", StringUtils.ObjectToString(Round));
            aXMLTextWriter.WriteAttributeString("TextColor", StringUtils.ObjectToString(TextColor));
            aXMLTextWriter.WriteAttributeString("BackgroundColor", StringUtils.ObjectToString(BackgroundColor));
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public bool                     IsSetupOnDblClick { get { return true; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                   LabelText
        {
            get { return toolTip.GetToolTip(label_Value); }
            set
            {
                toolTip.SetToolTip(label_Value, value);
                toolTip.SetToolTip(label_Units, value);
            }
        }

        private bool                    mShowUnits = true;
        public bool                     ShowUnits
        {
            get { return mShowUnits; }
            set
            {
                mShowUnits = value;
                checkSize();
            }
        }
        
        private string                  mUnits = "";
        public string                   Units
        {
            get
            {
                if (String.IsNullOrWhiteSpace(mUnits))
                {
                    return mDoubleValue.Units;
                }
                else
                {
                    return mUnits;
                }
            }
            set
            {
                mUnits = value;
                checkSize();
            }
        }

        private void                    DoubleIndicatorPanel_Resize(object aSender, EventArgs aEventArgs)
        {
            checkSize();
        }

        private void                    checkSize()
        {
            bool lUserUnits = String.IsNullOrWhiteSpace(mUnits) == false;
            if (mShowUnits && (String.IsNullOrWhiteSpace(mDoubleValue.Units) == false || lUserUnits))
            {
                if (lUserUnits)
                {
                    label_Units.Text = mUnits;               
                }
                else
                {
                    label_Units.Text = mDoubleValue.Units;
                }
                label_Value.Width   = Width - label_Units.Width - 2;
                label_Units.Left    = Width - label_Units.Width - 1;
            }
            else
            {
                label_Units.Text  = "";
                label_Value.Width = Width - 2;
            }
        }

        private int                     mRound = -1;
        public int                      Round
        {
            get { return mRound; }
            set
            {
                if (mRound != value)
                {
                    if (value < -1)
                    {
                        mRound = -1;
                    }
                    else if (value > 15)
                    {
                        mRound = 15;
                    }
                    else
                    {
                        mRound = value;
                    }
                    updateValues();
                }
            }
        }

        public Color                    TextColor
        {
            get { return label_Value.ForeColor; }
            set { label_Value.ForeColor = value; }
        }

        public Color                    BackgroundColor
        {
            get { return label_Value.BackColor; }
            set { label_Value.BackColor = value; }
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
            label_Value.Text = StringUtils.DoubleToString(mDoubleValue.ValueDouble, mRound);
        }

        public void                     updateProperties()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { checkSize(); }));
            }
            else
            {
                checkSize();
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
