// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.DoubleEditBox
{
    public partial class DoubleEditBoxPanel : UserControl, IPanel
    {
        private IDoubleValueReadWrite   mDoubleValue;

        public                          DoubleEditBoxPanel(IDoubleValueReadWrite aDoubleValue)
        {
            mDoubleValue = aDoubleValue;
            InitializeComponent();

            BackColor                   = SystemColors.Control;
            MaximumSize                 = new Size(Int32.MaxValue, textBox_Value.Height + 2);
            MinimumSize                 = new Size(0, textBox_Value.Height + 2);
            textBox_Value.ContextMenu   = new ContextMenu(); // иначе появляется стандартное меню
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            ShowUnits   = lReader.getAttribute<Boolean>("ShowUnits", ShowUnits);
            Units       = lReader.getAttribute<String>("Units", "");
            Round       = lReader.getAttribute<Int32>("Round", Round);
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("ShowUnits", StringUtils.ObjectToString(ShowUnits));
            aXMLTextWriter.WriteAttributeString("Units", mUnits);
            aXMLTextWriter.WriteAttributeString("Round", StringUtils.ObjectToString(Round));
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                   LabelText
        {
            get { return toolTip.GetToolTip(textBox_Value); }
            set
            {
                toolTip.SetToolTip(textBox_Value, value);
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

        private void                    DoubleEditBoxPanel_Resize(object aSender, EventArgs aEventArgs)
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
                textBox_Value.Width = Width - label_Units.Width - 2;
                label_Units.Left    = Width - label_Units.Width - 1;
            }
            else
            {
                label_Units.Text    = "";
                textBox_Value.Width = Width - 2;
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
            if (textBox_Value.ContainsFocus == false)
            {
                textBox_Value.Text = StringUtils.DoubleToString(mDoubleValue.ValueDouble, mRound);
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
            checkSize();
            checkFault();
        }

        private void                    textBox_Value_KeyPress(object aSender, KeyPressEventArgs aEventArgs)
        {
            if (aEventArgs.KeyChar == (char)Keys.Enter)
            {
                double lValue;
                try
                {
                    lValue = StringUtils.toDouble(textBox_Value.Text);

                    if (mRound != -1)
                    {
                        lValue = Math.Round(lValue, mRound, MidpointRounding.AwayFromZero);
                    }

                    mDoubleValue.ValueDouble = lValue;
                }
                catch { }

                textBox_Value.Enabled = false;
                textBox_Value.Enabled = true;

                textBox_Value.Text = StringUtils.DoubleToString(mDoubleValue.ValueDouble, mRound);
            }
            checkFault();
        }

        private void                    textBox_Value_Leave(object aSender, EventArgs aEventArgs)
        {
            textBox_Value.Text = StringUtils.DoubleToString(mDoubleValue.ValueDouble, mRound);
            checkFault();
        }

        private void                    checkFault()
        {
            var lValue = mDoubleValue.ValueDouble;

            if (Double.IsNaN(lValue) || Double.IsInfinity(lValue) || lValue > mDoubleValue.Maximum || lValue < mDoubleValue.Minimum)
            {
                textBox_Value.BackColor = Color.Red;
            }
            else
            {
                textBox_Value.BackColor = SystemColors.Window;
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
