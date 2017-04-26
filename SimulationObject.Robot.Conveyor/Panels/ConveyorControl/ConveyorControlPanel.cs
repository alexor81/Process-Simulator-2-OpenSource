// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.DialogForms;

namespace SimulationObject.Robot.Conveyor.Panel.ConveyorControl
{
    public partial class ConveyorControlPanel : UserControl, IPanel
    {
        private Conveyor        mConveyor;

        public                  ConveyorControlPanel(Conveyor aConveyor)
        {
            mConveyor = aConveyor;
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
                //toolTip.SetToolTip(trackBar_Position, value);
                //toolTip.SetToolTip(label_Position, value);
                //toolTip.SetToolTip(label_Closed, value);
                //toolTip.SetToolTip(label_Open, value);
                //toolTip.SetToolTip(checkBox_Power, value);
                //toolTip.SetToolTip(checkBox_Remote, value);
                //toolTip.SetToolTip(checkBox_Alarm1, value);
                //toolTip.SetToolTip(checkBox_Alarm2, value);
                //toolTip.SetToolTip(label_Alarms, value);
                //toolTip.SetToolTip(label_PositionCMD, value);
                //toolTip.SetToolTip(label_EsdCMD, value);
                //toolTip.SetToolTip(label_StopCMD, value);
                //toolTip.SetToolTip(label_CloseCMD, value);
                //toolTip.SetToolTip(label_OpenCMD, value);
            }
        }

        private void            updateStartCMD()
        {
            if (mConveyor.UseOneCommand)
            {
                label_StartCMD.BackColor = Color.Yellow;
                if (mConveyor.mStartCMD == true)
                {
                    label_StartCMD.Text = "Start";
                }
                else
                {
                    label_StartCMD.Text = "Stop";
                }
            }
            else
            {
                label_StartCMD.Text = "Start";
                if (mConveyor.mStartCMD == true)
                {
                    label_StartCMD.BackColor = Color.Yellow;
                }
                else
                {
                    label_StartCMD.BackColor = BackColor;
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
            if (mConveyor.Moving == true)
            {
                button_Moving.Text      = "Moving";
                button_Moving.BackColor = Color.LimeGreen;
            }
            else
            {
                button_Moving.Text      = "Stop";
                button_Moving.BackColor = Color.LightGray;
            }

            label_Speed.Text        = StringUtils.DoubleToString(mConveyor.Speed, 2) + " %";
            trackBar_Position.Value = (int)Math.Truncate(mConveyor.Speed);

            updateStartCMD();

            if (mConveyor.mStopCMD == true)
            {
                label_StopCMD.BackColor = Color.Yellow;
            }
            else
            {
                label_StopCMD.BackColor = BackColor;
            }

            label_SpeedCMD.Text = StringUtils.DoubleToString(mConveyor.mSpeedCMD, 2) + " %";

            if (mConveyor.IgnoreCommands != label_Control.Font.Strikeout)
            {
                label_Control.Font = new Font(label_Control.Font, label_Control.Font.Style ^ FontStyle.Strikeout);

                if (mConveyor.IgnoreCommands)
                {
                    label_Control.ForeColor = Color.Red;

                }
                else
                {
                    label_Control.ForeColor = Color.Black;
                }
            }

            checkBox_Reverse.Checked = mConveyor.Reverse;

            checkBox_Alarm.Checked = mConveyor.Alarm;
            if (checkBox_Alarm.Checked)
            {
                checkBox_Alarm.BackColor = Color.Red;
            }
            else
            {
                checkBox_Alarm.BackColor = BackColor;
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
            label_SpeedCMD.Visible      = (mConveyor.mSpeedCMDItemHandle != -1);
            label_StartCMD.Visible      = (mConveyor.mStartCMDItemHandle != -1);
            updateStartCMD();
            label_StopCMD.Visible       = !mConveyor.UseOneCommand && (mConveyor.mStopCMDItemHandle != -1);

            checkBox_Alarm.Enabled      = (mConveyor.mAlarmItemHandle != -1);
        }
    
        private void            checkBox_Reverse_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mConveyor.Reverse != checkBox_Reverse.Checked)
            {
                mConveyor.Reverse = checkBox_Reverse.Checked;
            }
        }

        private void            checkBox_Alarm_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mConveyor.Alarm != checkBox_Alarm.Checked)
            {
                mConveyor.Alarm = checkBox_Alarm.Checked;
            }
        }

        private void            button_Moving_Click(object aSender, EventArgs aEventArgs)
        {
            mConveyor.Moving = !mConveyor.Moving;
        }

        private void            trackBar_Position_Scroll(object aSender, EventArgs aEventArgs)
        {
            int lPosition = (int)Math.Truncate(mConveyor.Speed);
            if (trackBar_Position.Value != lPosition)
            {
                mConveyor.Speed = trackBar_Position.Value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                mConveyor = null;
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
