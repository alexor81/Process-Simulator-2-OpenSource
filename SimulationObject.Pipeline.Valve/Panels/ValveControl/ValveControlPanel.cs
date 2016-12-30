// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Pipeline.Valve.Panels.ValveControl
{
    public partial class ValveControlPanel : UserControl, IPanel
    {
        private Valve           mValve;

        public                  ValveControlPanel(Valve aValve)
        {
            mValve = aValve;
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
                toolTip.SetToolTip(trackBar_Position, value);
                toolTip.SetToolTip(label_Position, value);
                toolTip.SetToolTip(label_Closed, value);
                toolTip.SetToolTip(label_Open, value);
                toolTip.SetToolTip(checkBox_Power, value);
                toolTip.SetToolTip(checkBox_Remote, value);
                toolTip.SetToolTip(checkBox_Alarm1, value);
                toolTip.SetToolTip(checkBox_Alarm2, value);
                toolTip.SetToolTip(label_Alarms, value);
                toolTip.SetToolTip(label_PositionCMD, value);
                toolTip.SetToolTip(label_EsdCMD, value);
                toolTip.SetToolTip(label_StopCMD, value);
                toolTip.SetToolTip(label_CloseCMD, value);
                toolTip.SetToolTip(label_OpenCMD, value);
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
            if (mValve.PositionFault)
            {
                trackBar_Position.BackColor = Color.Red;
            }
            else
            {
                trackBar_Position.BackColor = BackColor;
            }
            trackBar_Position.Value = (int)Math.Truncate(mValve.Position);

            label_Position.Text     = StringUtils.DoubleToString(mValve.Position, 2) + " %";

            if (mValve.ForseLimSwitches)
            {
                label_Closed.BackColor  = Color.Red;
                label_Open.BackColor    = Color.Green;
            }
            else
            {
                if (mValve.ClosedLimit)
                {
                    label_Closed.BackColor = Color.Red;
                }
                else
                {
                    label_Closed.BackColor = BackColor;
                }

                if (mValve.OpenLimit)
                {
                    label_Open.BackColor = Color.Green;
                }
                else
                {
                    label_Open.BackColor = BackColor;
                }
            }

            checkBox_Power.Checked  = mValve.Power;
            checkBox_Remote.Checked = mValve.Remote;

            checkBox_Alarm1.Checked = mValve.Alarm1;
            if (checkBox_Alarm1.Checked)
            {
                checkBox_Alarm1.BackColor = Color.Red;
            }
            else
            {
                checkBox_Alarm1.BackColor = BackColor;
            }
            checkBox_Alarm2.Checked = mValve.Alarm2;
            if (checkBox_Alarm2.Checked)
            {
                checkBox_Alarm2.BackColor = Color.Red;
            }
            else
            {
                checkBox_Alarm2.BackColor = BackColor;
            }

            if (mValve.mAnalogCtrl)
            {
                label_PositionCMD.Text = StringUtils.DoubleToString(mValve.mPositionCMD, 2) + " %";
            }
            else
            {
                if (mValve.mOpenCMD == true)
                {
                    label_OpenCMD.BackColor = Color.Yellow;
                }
                else
                {
                    label_OpenCMD.BackColor = BackColor;
                }

                if (mValve.mCloseCMD == true)
                {
                    label_CloseCMD.BackColor = Color.Yellow;
                }
                else
                {
                    label_CloseCMD.BackColor = BackColor;
                }

                if (mValve.mStopCMD == true)
                {
                    label_StopCMD.BackColor = Color.Yellow;
                }
                else
                {
                    label_StopCMD.BackColor = BackColor;
                }
            }

            if (mValve.mEsdCMD == true)
            {
                label_EsdCMD.BackColor = Color.Yellow;
            }
            else
            {
                label_EsdCMD.BackColor = BackColor;
            }

            if (mValve.IgnoreCommands != (label_Control.Font.Strikeout))
            {
                label_Control.Font = new Font(label_Control.Font, label_Control.Font.Style ^ FontStyle.Strikeout);

                if (mValve.IgnoreCommands)
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
            label_PositionCMD.Visible   = mValve.mAnalogCtrl && (mValve.mPositionCMDItemHandle != -1);
            label_OpenCMD.Visible       = !mValve.mAnalogCtrl && (mValve.mOpenCMDItemHandle != -1);
            label_CloseCMD.Visible      = !mValve.mAnalogCtrl && !mValve.UseOneCommand && (mValve.mCloseCMDItemHandle != -1);
            label_StopCMD.Visible       = !mValve.mAnalogCtrl && (mValve.mStopCMDItemHandle != -1);
            label_EsdCMD.Visible        = (mValve.mEsdCMDItemHandle != -1);
            
            checkBox_Power.Enabled      = (mValve.mPowerItemHandle != -1);
            checkBox_Remote.Enabled     = (mValve.mRemoteItemHandle != -1);

            checkBox_Alarm1.Enabled     = (mValve.mAlarm1ItemHandle != -1);
            checkBox_Alarm2.Enabled     = (mValve.mAlarm2ItemHandle != -1);
            label_Alarms.Enabled        = checkBox_Alarm1.Enabled || checkBox_Alarm2.Enabled;
        }

        private void            trackBar_Position_ValueChanged(object aSender, EventArgs aEventArgs)
        {
            int lPosition = (int)Math.Truncate(mValve.Position);
            if (trackBar_Position.Value != lPosition)
            {
                mValve.Position     = trackBar_Position.Value;
            }
        }

        private void            label_Open_Click(object aSender, EventArgs aEventArgs)
        {
            if (ValuesCompare.NotEqualDelta1.compare(mValve.Position, 100.0D))
            {
                mValve.Position = 100.0D;
            }
        }

        private void            label_Closed_Click(object aSender, EventArgs aEventArgs)
        {
            if (ValuesCompare.NotEqualDelta1.compare(mValve.Position, 0.0D))         
            {
                mValve.Position = 0.0D;
            }
        }

        private void            checkBox_Power_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mValve.Power != checkBox_Power.Checked)
            {
                mValve.Power = checkBox_Power.Checked;
            }
        }

        private void            checkBox_Remote_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mValve.Remote != checkBox_Remote.Checked)
            {
                mValve.Remote = checkBox_Remote.Checked;
            }
        }

        private void            checkBox_Alarm1_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mValve.Alarm1 != checkBox_Alarm1.Checked)
            {
                mValve.Alarm1 = checkBox_Alarm1.Checked;
            }
        }

        private void            checkBox_Alarm2_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mValve.Alarm2 != checkBox_Alarm2.Checked)
            {
                mValve.Alarm2 = checkBox_Alarm2.Checked;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mValve = null;
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
