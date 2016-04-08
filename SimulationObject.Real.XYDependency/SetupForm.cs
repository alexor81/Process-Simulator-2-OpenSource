using API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Utils;
using Utils.DialogForms;
using Utils.Logger;
using Utils.SpecialControls;

namespace SimulationObject.Real.XYDependency
{
    public partial class SetupForm : Form
    {
        private XYDependency                        mXYDependency;
        private IItemBrowser                        mBrowser;
        private SortedDictionary<double, double>    mPoints;
        private List<double>                        mIndex      = new List<double>();

        private int                                 mSelected   = -1;
        private bool                                mMove       = false;
        private int                                 mMouseY;

        public                                      SetupForm(XYDependency aXYDependency, IItemBrowser aBrowser)
        {
            mXYDependency   = aXYDependency;
            mBrowser        = aBrowser;
            mPoints         = mXYDependency.Points;
            InitializeComponent();

            if (mXYDependency.mInputItemHandle != -1)
            {
                itemEditBox_X.ItemName      = mBrowser.getItemNameByHandle(mXYDependency.mInputItemHandle);
                itemEditBox_X.ItemToolTip   = mBrowser.getItemToolTipByHandle(mXYDependency.mInputItemHandle);
            }

            if (mXYDependency.mValueItemHandle != -1)
            {
                itemEditBox_Y.ItemName      = mBrowser.getItemNameByHandle(mXYDependency.mValueItemHandle);
                itemEditBox_Y.ItemToolTip   = mBrowser.getItemToolTipByHandle(mXYDependency.mValueItemHandle);
            }
            
            updateChart();
            updatePoints();
            updateButtons();
        }

        #region Size

            private bool                            mMaximized;
            private Size                            mNormalSize;
            private Point                           mNormalLocation;
            protected override void                 WndProc(ref Message aMessage)
            {
                if (aMessage.Msg == (int)WM.NCLBUTTONDBLCLK)
                {
                    if (mMaximized)
                    {
                        Size        = mNormalSize;
                        Location    = mNormalLocation;
                        mMaximized  = false;
                    }
                    else
                    {
                        mNormalSize     = Size;
                        mNormalLocation = Location;
                        Screen lScreen  = Screen.FromControl(this);
                        Size            = lScreen.WorkingArea.Size;
                        Location        = lScreen.WorkingArea.Location;
                        mMaximized      = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

        #endregion

        private void                                updateChart()
        {
            chart.Series[0].Points.Clear();

            foreach(double lX in mPoints.Keys)
            {
                chart.Series[0].Points.AddXY(lX, mPoints[lX]);
            }
        }

        private void                                updatePoints()
        {
            mIndex.Clear();
            mIndex.AddRange(mPoints.Keys);

            listBox_Points.BeginUpdate();
            try
            {
                int lSelected = listBox_Points.SelectedIndex;

                listBox_Points.Items.Clear();

                foreach (double lX in mPoints.Keys)
                {
                    listBox_Points.Items.Add(StringUtils.ObjectToString(lX) + ", " + StringUtils.ObjectToString(mPoints[lX]));
                }

                int lLastIndex = listBox_Points.Items.Count - 1;
                if (lSelected > lLastIndex)
                {
                    lSelected = lLastIndex;
                }

                if(lSelected != -1)
                {
                    listBox_Points.SelectedIndex = lSelected;
                }
            }
            finally
            {
                listBox_Points.EndUpdate();
            }
        }

        private void                                updateSelectedPoint()
        {
            if (mSelected != -1)
            {
                listBox_Points.BeginUpdate();
                try
                {
                    double lX                       = mIndex[mSelected];
                    listBox_Points.Items[mSelected] = StringUtils.ObjectToString(lX) + ", " + StringUtils.ObjectToString(mPoints[lX]);
                }
                finally
                {
                    listBox_Points.EndUpdate();
                }
            }
        }

        private void                                updateButtons()
        {
            bool lSelection         = (listBox_Points.SelectedIndex != -1);

            tsButton_Delete.Enabled = (mPoints.Count > 2 && lSelection);
            tsButton_Setup.Enabled  = lSelection;
        }

        private void                                ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void                                tsButton_Add_Click(object aSender, EventArgs aEventArgs)
        {
            bool lCreated = false;
            using (var lAddForm = new AddSetupForm(0.0D, 0.0D))
            {
                do
                {
                    try
                    {
                        lAddForm.ShowDialog(this);
                        if (lAddForm.DialogResult == DialogResult.OK)
                        {
                            double lX = lAddForm.X;
                            double lY = lAddForm.Y;

                            if(mPoints.ContainsKey(lX))
                            {
                                throw new ArgumentException("Point already exists. ");
                            }

                            mPoints.Add(lX, lY);

                            lCreated = true;
                            updateChart();
                            updatePoints();
                        }
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Error while user was creating new Point. " + lExc.Message, lExc.ToString());
                        MessageForm.showMessage(lExc.Message, this);
                    }
                }
                while (lAddForm.DialogResult == DialogResult.OK && lCreated == false) ;
            }
        }

        private void                                tsButton_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            if(mPoints.Count > 2 && listBox_Points.SelectedIndex != -1)
            {
                try
                {
                    mPoints.Remove(mIndex[listBox_Points.SelectedIndex]);
                    updateChart();
                    updatePoints();
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was deleting Point. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                                tsButton_Setup_Click(object aSender, EventArgs aEventArgs)
        {
            if (listBox_Points.SelectedIndex == -1)
            {
                return;
            }

            double lX   = mIndex[listBox_Points.SelectedIndex];
            double lY   = mPoints[lX];  
            bool lExit  = false;
            double lNewX;

            do
            {
                try
                {
                    using (var lSetupForm = new AddSetupForm(lX, lY))
                    {
                        lSetupForm.ShowDialog(this);
                        if (lSetupForm.DialogResult == DialogResult.OK)
                        {
                            mPoints.Remove(lX);

                            lNewX = lSetupForm.X;
                            if (mPoints.ContainsKey(lNewX))
                            {
                                mPoints.Add(lX, lY);
                                throw new ArgumentException("Point already exists. ");
                            }

                            mPoints.Add(lNewX, lSetupForm.Y);

                            updateChart();
                            updatePoints();
                        }

                        lExit = true;
                    }
                }
                catch (Exception lExc)
                {
                    Log.Error("Error while user was configuring Point. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
            while (lExit == false);
        }

        private void                                listBox_Points_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            updateButtons();

            if(mSelected != -1 && mSelected < chart.Series[0].Points.Count)
            {
                chart.Series[0].Points[mSelected].MarkerColor   = Color.Blue;
                chart.Series[0].Points[mSelected].MarkerSize    = 5;
                mSelected                                       = -1;
            }

            if(listBox_Points.SelectedIndex != -1)
            {

                mSelected                                       = listBox_Points.SelectedIndex;
                chart.Series[0].Points[mSelected].MarkerColor   = Color.Red;
                chart.Series[0].Points[mSelected].MarkerSize    = 6;
            }
        }

        private void                                chart_MouseDown(object aSender, MouseEventArgs aEventArgs)
        {
            if (aEventArgs.Button == MouseButtons.Left)
            {
                var lResult = chart.HitTest(aEventArgs.X, aEventArgs.Y);

                if (lResult.ChartElementType == ChartElementType.DataPoint)
                {
                    listBox_Points.SelectedIndex    = lResult.PointIndex;
                    mMove                           = true;
                }
            }
        }

        private void                                chart_MouseMove(object aSender, MouseEventArgs aEventArgs)
        {
            if(mMove)
            {
                mMouseY = aEventArgs.Y;
                chart.ResetAutoValues();
            }
            else
            {
                var lResult = chart.HitTest(aEventArgs.X, aEventArgs.Y);
                if (lResult.ChartElementType == ChartElementType.DataPoint)
                {
                    chart.Cursor = Cursors.Hand;
                }
                else
                {
                    chart.Cursor = Cursors.Default;
                }
            }
        }

        private void                                chart_MouseUp(object aSender, MouseEventArgs aEventArgs)
        {
            if (aEventArgs.Button == MouseButtons.Left)
            {
                mMove   = false;
                mMouseY = 0;
                chart.ResetAutoValues();
            }
        }

        private void                                chart_PrePaint(object aSender, ChartPaintEventArgs aEventArgs)
        {
            if(mMove)
            {
                if (mMouseY > 0 && mMouseY < chart.Height)
                {
                    double lY                                       = chart.ChartAreas[0].AxisY.PixelPositionToValue(mMouseY);
                    chart.Series[0].Points[mSelected].YValues[0]    = lY;
                    mPoints[mIndex[mSelected]]                      = lY;
                    updateSelectedPoint();
                }
            }
        }

        private void                                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(itemEditBox_X.ItemName))
                    {
                        throw new ArgumentException("X Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Y.ItemName))
                    {
                        throw new ArgumentException("Y Item is missing. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_X.ItemName);
                    lChecker.addItemName(itemEditBox_Y.ItemName);

                    mXYDependency.mInputItemHandle  = mBrowser.getItemHandleByName(itemEditBox_X.ItemName);
                    mXYDependency.mValueItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Y.ItemName);

                    mXYDependency.Points            = mPoints;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void                                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
