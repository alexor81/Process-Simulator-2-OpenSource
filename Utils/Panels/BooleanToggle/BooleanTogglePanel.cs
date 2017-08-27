// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanToggle
{
    public partial class BooleanTogglePanel : UserControl, IPanel
    {
        private IBooleanValueReadWrite  mBooleanValue;

        public                          BooleanTogglePanel(IBooleanValueReadWrite aBooleanValue)
        {
            mBooleanValue = aBooleanValue;
            InitializeComponent();

            BackColor = SystemColors.Control;
            toggleSwitch.RightMouseDown += ToggleSwitch_RightMouseDown;
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            Style       = lReader.getAttribute<String>("Style", Style);
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("Style", Style);
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
            get { return toolTip.GetToolTip(toggleSwitch); }
            set { toolTip.SetToolTip(toggleSwitch, value); }
        }

        public string                   Style
        {
            get { return toggleSwitch.Style.ToString(); }
            set
            {
                var lStyle = (JCS.ToggleSwitch.ToggleSwitchStyle)Enum.Parse(typeof(JCS.ToggleSwitch.ToggleSwitchStyle), value);
                if (toggleSwitch.Style != lStyle)
                {
                    toggleSwitch.Style = lStyle;
                }
            }
        }

        public void                     updateValues()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateToggle(); }));
            }
            else
            {
                updateToggle();
            }
        }

        public void                     updateProperties()
        {
        }

        private void                    updateToggle()
        {
            if (mBooleanValue.ValueBoolean != toggleSwitch.Checked)
            {
                toggleSwitch.Checked = mBooleanValue.ValueBoolean;
            }
        }

        private void                    toggleSwitch_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mBooleanValue.ValueBoolean != toggleSwitch.Checked)
            {
                mBooleanValue.ValueBoolean = toggleSwitch.Checked;
            }
        }

        private void                    ToggleSwitch_RightMouseDown(object aSender, MouseEventArgs aEventArgs)
        {
            OnMouseDown(aEventArgs);
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing)
            {
                toggleSwitch.RightMouseDown -= ToggleSwitch_RightMouseDown;

                mBooleanValue               = null;

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
