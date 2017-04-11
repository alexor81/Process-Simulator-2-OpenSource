// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Pipeline.Pump.Panels.PumpControl
{
    public partial class PumpControlPanel : UserControl, IPanel
    {
        private Pump            mPump;

        public                  PumpControlPanel(Pump aPump)
        {
            mPump = aPump;
            InitializeComponent();

            BackColor = SystemColors.Control;
        }

        public void             fillForDemo()
        {
        }

        public void             loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
        }

        public void             saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
        }

        public UserControl      UserControl { get { return this; } }

        public bool             IsScalable { get { return false; } }

        public bool             IsTransparent { get { return false; } }

        public bool             IsConfigurable { get { return true; } }

        public bool             IsContainer { get { return false; } }

        public void             setupByForm(IWin32Window aOwner)
        {
            string lNewToolTip = StringForm.getString(LabelText, this, "Panel ToolTip");
            if (lNewToolTip != null)
            {
                LabelText = lNewToolTip;
            }
        }

        public string           LabelText
        {
            get { return toolTip.GetToolTip(panel); }
            set
            {
                toolTip.SetToolTip(panel, value);
                toolTip.SetToolTip(button_On, value);
                toolTip.SetToolTip(checkBox_OnBtn, value);
                toolTip.SetToolTip(checkBox_OffBtn, value);
                toolTip.SetToolTip(groupBox_Buttons, value);
                toolTip.SetToolTip(checkBox_Alarm, value);
                toolTip.SetToolTip(checkBox_Remote, value);
                toolTip.SetToolTip(checkBox_Power, value);                
                toolTip.SetToolTip(label_Control, value);
                toolTip.SetToolTip(label_OnCMD, value);
                toolTip.SetToolTip(label_OffCMD, value);
                toolTip.SetToolTip(label_EsdCMD, value);
            }
        }

        private void            updateOnCMD()
        {
            if (mPump.UseOneCommand)
            {
                label_OnCMD.BackColor = Color.Yellow;
                if (mPump.mOnCMD == true)
                {
                    label_OnCMD.Text = "On";
                }
                else
                {
                    label_OnCMD.Text = "Off";
                }
            }
            else
            {
                label_OnCMD.Text = "On";
                if (mPump.mOnCMD == true)
                {
                    label_OnCMD.BackColor = Color.Yellow;
                }
                else
                {
                    label_OnCMD.BackColor = BackColor;
                }
            }
        }

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
            if (mPump.On == true)
            {
                button_On.Text      = "ON";
                button_On.BackColor = Color.LimeGreen;
            }
            else
            {
                button_On.Text      = "OFF";
                button_On.BackColor = Color.LightGray;
            }

            checkBox_Power.Checked  = mPump.Power;
            checkBox_Remote.Checked = mPump.Remote;

            updateOnCMD();

            if (mPump.mOffCMD == true)
            {
                label_OffCMD.BackColor = Color.Yellow;
            }
            else
            {
                label_OffCMD.BackColor = BackColor;
            }

            if (mPump.mEsdCMD == true)
            {
                label_EsdCMD.BackColor = Color.Yellow;
            }
            else
            {
                label_EsdCMD.BackColor = BackColor;
            }

            checkBox_Alarm.Checked = mPump.Alarm;
            if (checkBox_Alarm.Checked)
            {
                checkBox_Alarm.BackColor = Color.Red;
            }
            else
            {
                checkBox_Alarm.BackColor = BackColor;
            }

            checkBox_OnBtn.Checked = mPump.OnBtn;
            if (checkBox_OnBtn.Checked)
            {
                checkBox_OnBtn.BackColor = Color.LimeGreen;
            }
            else
            {
                checkBox_OnBtn.BackColor = BackColor;
            }

            checkBox_OffBtn.Checked = mPump.OffBtn;
            if (checkBox_OffBtn.Checked)
            {
                checkBox_OffBtn.BackColor = Color.LimeGreen;
            }
            else
            {
                checkBox_OffBtn.BackColor = BackColor;
            }

            if (mPump.IgnoreCommands != label_Control.Font.Strikeout)
            {
                label_Control.Font = new Font(label_Control.Font, label_Control.Font.Style ^ FontStyle.Strikeout);

                if (mPump.IgnoreCommands)
                {
                    label_Control.ForeColor = Color.Red;
                }
                else
                {
                    label_Control.ForeColor = Color.Black;
                }
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
            label_OnCMD.Visible         = (mPump.mOnCMDItemHandle != -1);
            updateOnCMD();

            label_OffCMD.Visible        = (mPump.mOffCMDItemHandle != -1) && !mPump.UseOneCommand;
            label_EsdCMD.Visible        = (mPump.mEsdCMDItemHandle != -1);

            checkBox_Remote.Enabled     = (mPump.mRemoteItemHandle != -1);
            checkBox_Power.Enabled      = (mPump.mPowerItemHandle != -1);
            checkBox_Alarm.Enabled      = (mPump.mAlarmItemHandle != -1);

            checkBox_OnBtn.Enabled      = (mPump.mOnBtnItemHandle != -1);
            checkBox_OffBtn.Enabled     = (mPump.mOffBtnItemHandle != -1);
        }

        private void            checkBox_Remote_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mPump.Remote != checkBox_Remote.Checked)
            {
                mPump.Remote = checkBox_Remote.Checked;
            }
        }

        private void            checkBox_Power_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mPump.Power != checkBox_Power.Checked)
            {
                mPump.Power = checkBox_Power.Checked;
            }
        }

        private void            checkBox_Alarm_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mPump.Alarm != checkBox_Alarm.Checked)
            {
                mPump.Alarm = checkBox_Alarm.Checked;
            }
        }

        private void            checkBox_OnBtn_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mPump.OnBtn != checkBox_OnBtn.Checked)
            {
                mPump.OnBtn = checkBox_OnBtn.Checked;
            }
        }

        private void            checkBox_OffBtn_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mPump.OffBtn != checkBox_OffBtn.Checked)
            {
                mPump.OffBtn = checkBox_OffBtn.Checked;
            }
        }

        private void            button_On_Click(object aSender, EventArgs aEventArgs)
        {
            mPump.On = !mPump.On;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mPump = null;
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