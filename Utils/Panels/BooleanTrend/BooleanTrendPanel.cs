// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using API;
using Utils.Logger;

namespace Utils.Panels.BooleanTrend
{
    public partial class BooleanTrendPanel : UserControl, IPanel, IPanelExt
    {
        private IBooleanValueRead   mBooleanValue;

        public                      BooleanTrendPanel(IBooleanValueRead aBooleanValueRead)
        {
            mBooleanValue = aBooleanValueRead;
            InitializeComponent();

            timer_Update.Start();
        }

        public void                 fillForDemo()
        {
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText = lReader.getAttribute<String>("ToolTip", "");
            TimeFrame = lReader.getAttribute<Int32>("TimeFrame", mTimeFrame);
            TrendColor = lReader.getAttribute<Color>("Color", chart.Series[0].Color);
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("TimeFrame", StringUtils.ObjectToString(TimeFrame));
            aXMLTextWriter.WriteAttributeString("Color", StringUtils.ObjectToString(TrendColor));
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

        private string              mLabelText;
        public string               LabelText
        {
            get { return mLabelText; }
            set { mLabelText = value; }
        }
        private void                chart_GetToolTipText(object aSender, ToolTipEventArgs aEventArgs)
        {
            aEventArgs.Text = mLabelText;
        }

        private int                 mTimeFrame  = 1;
        private double              mWindow     = 1.0D / 1440.0D;
        public int                  TimeFrame
        {
            get { return mTimeFrame; }
            set
            {
                if (value >= 1 && value <= 5)
                {
                    mTimeFrame  = value;
                    mWindow     = (double)mTimeFrame / 1440.0D;
                }
            }
        }

        public Color                TrendColor
        {
            get { return chart.Series[0].Color; }
            set { chart.Series[0].Color = value; }
        }

        private void                addValue(double aDateTime, bool aValue)
        {
            if (aValue != mValue)
            {
                chart.Series[0].Points.AddXY(aDateTime, mValue);
                chart.Series[0].Points.AddXY(aDateTime, aValue);

                mValue = aValue;
            }
            else
            {
                chart.Series[0].Points.AddXY(aDateTime, mValue);
            }
        }

        public void                 clear()
        {
            chart.Series[0].Points.Clear();
        }

        private void                timer_Update_Tick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                double lNow     = DateTime.Now.ToOADate();
                double lLast    = lNow - mWindow;

                addValue(lNow, mValue);

                if (chart.Series[0].Points.Count > 2)
                {
                    while (chart.Series[0].Points[0].XValue < lLast)
                    {
                        if (chart.Series[0].Points[1].XValue > lLast) break;
                        chart.Series[0].Points.RemoveAt(0);
                        if (chart.Series[0].Points.Count <= 2) break;
                    }
                }

                chart.ResetAutoValues();
                chart.ChartAreas[0].AxisX.Maximum = lNow;
                chart.ChartAreas[0].AxisX.Minimum = lLast;
            }
            catch (Exception lExc)
            {
                Log.Error("Error updating Panel 'Trend'. " + lExc.Message, lExc.ToString());
            }
        }

        private bool                mValue;
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
            addValue(DateTime.Now.ToOADate(), mBooleanValue.ValueBoolean);
        }

        public void                 updateProperties()
        {
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                mBooleanValue = null;
                timer_Update.Stop();

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
