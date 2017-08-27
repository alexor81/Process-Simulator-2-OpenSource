// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Panels.ArrayDoubleTrend
{
    public partial class SetupForm : Form
    {
        private ArrayDoubleTrendPanel   mTrend;
        private DataTable               mDataTable;

        public                          SetupForm(ArrayDoubleTrendPanel aTrend)
        {
            mTrend = aTrend;
            InitializeComponent();
            
            textBox_ToolTip.Text        = mTrend.LabelText;
            trackBar_Update.Value       = mTrend.UpdateRate;
            label_Update.Text           = "Update Rate: " + StringUtils.ObjectToString(trackBar_Update.Value) + " ms";
            trackBar_TimeFrame.Value    = mTrend.TimeFrame;
            label_TimeFrame.Text        = "Time Frame: " + StringUtils.ObjectToString(trackBar_TimeFrame.Value) + " min";
            checkBox_Legend.Checked     = mTrend.Legend;
            checkBox_ShowCursor.Checked = mTrend.ShowCursor;
            spinEdit_Round.Value        = mTrend.CursorRound;
            buttonEdit_Font.Text        = StringUtils.ObjectToString(mTrend.CursorFont);
            checkBox_YAutoScale.Checked = mTrend.YAutoScale;
            checkBox_ShowLabels.Checked = mTrend.YLabels;

            updateYMaxMin();
            updateTable();
        }

        private void                    textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mTrend.LabelText.Equals(textBox_ToolTip.Text, StringComparison.Ordinal) == false)
            {
                mTrend.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                    trackBar_Update_ValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mTrend.UpdateRate != trackBar_Update.Value)
            {
                mTrend.UpdateRate = trackBar_Update.Value;
                label_Update.Text = "Update Rate: " + StringUtils.ObjectToString(trackBar_Update.Value) + " ms";
            }
        }

        private void                    trackBar_TimeFrame_ValueChanged(object aSender, EventArgs aEventArgse)
        {
            if (mTrend.TimeFrame != trackBar_TimeFrame.Value)
            {
                mTrend.TimeFrame = trackBar_TimeFrame.Value;
                label_TimeFrame.Text = "Time Frame: " + StringUtils.ObjectToString(trackBar_TimeFrame.Value) + " min";
            }
        }

        private void                    checkBox_Legend_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mTrend.Legend != checkBox_Legend.Checked)
            {
                mTrend.Legend = checkBox_Legend.Checked;
            }
        }

        private void                    button_Clear_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mTrend.clearSeries();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    checkBox_ShowCursor_CheckedChanged(object aSender, EventArgs aEventArgse)
        {
            if (mTrend.ShowCursor != checkBox_ShowCursor.Checked)
            {
                mTrend.ShowCursor = checkBox_ShowCursor.Checked;
            }
        }

        private void                    spinEdit_Round_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            int lNewValue = (int)spinEdit_Round.Value;
            if (lNewValue != mTrend.CursorRound)
            {
                mTrend.CursorRound = lNewValue;
            }
        }

        private void                    buttonEdit_Font_ButtonClick(object aSender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs aEventArgs)
        {
            using (var lFontDlg = new FontDialog())
            {
                lFontDlg.Font = mTrend.CursorFont;
                if (lFontDlg.ShowDialog(this) == DialogResult.OK)
                {
                    mTrend.CursorFont = lFontDlg.Font;
                    buttonEdit_Font.Text = StringUtils.ObjectToString(mTrend.CursorFont);
                }
            }
        }

        private void                    button_Add_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mTrend.addSeries((int)spinEdit_Index.Value, colorEdit.Color, textBox_Label.Text);
                updateTable();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    button_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mTrend.deleteSeries((int)spinEdit_Index.Value);
                updateTable();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    button_Modify_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mTrend.modifySeries((int)dataGridView_Elm.SelectedRows[0].Cells[0].Value, (int)spinEdit_Index.Value, colorEdit.Color, textBox_Label.Text);
                updateTable();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    dataGridView_Elm_SelectionChanged(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Elm.SelectedRows.Count != 0)
            {
                int RowIndex            = dataGridView_Elm.SelectedRows[0].Index;
                spinEdit_Index.Value    = Convert.ToDecimal(dataGridView_Elm.Rows[RowIndex].Cells[0].Value);
                colorEdit.Color         = (Color)dataGridView_Elm.Rows[RowIndex].Cells[1].Value;
                textBox_Label.Text      = (string)dataGridView_Elm.Rows[RowIndex].Cells[2].Value;
            }
        }

        private void                    updateTable()
        {
            var lDataTable                              = mTrend.SeriesData;
            dataGridView_Elm.DataSource                 = lDataTable;
            dataGridView_Elm.Columns[0].AutoSizeMode    = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_Elm.Columns[1].AutoSizeMode    = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_Elm.Sort(dataGridView_Elm.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            if (mDataTable != null)
            {
                mDataTable.Dispose();
            }
            mDataTable = lDataTable;

            bool lExist             = (dataGridView_Elm.RowCount > 0);
            button_Delete.Enabled   = lExist;
            button_Modify.Enabled   = lExist;
        }

        private void                    dataGridView_Elm_CellPainting(object aSender, DataGridViewCellPaintingEventArgs aEventArgs)
        {
            if (aEventArgs.RowIndex > -1 && aEventArgs.ColumnIndex == 1)
            {
                aEventArgs.CellStyle.BackColor = (Color)aEventArgs.Value;
            }
        }

        private void                    checkBox_YAutoScale_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_YAutoScale.Checked != mTrend.YAutoScale)
            {
                mTrend.YAutoScale = checkBox_YAutoScale.Checked;
            }

            updateYMaxMin();
        }

        private void                    updateYMaxMin()
        {
            bool lNAuto             = (mTrend.YAutoScale == false);
            textBox_YMax.Enabled    = lNAuto;
            textBox_YMin.Enabled    = lNAuto;
            button_Set.Enabled      = lNAuto;

            textBox_YMax.Text       = StringUtils.ObjectToString(mTrend.YMax);
            textBox_YMin.Text       = StringUtils.ObjectToString(mTrend.YMin);
        }

        private void                    checkBox_ShowLabels_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_ShowLabels.Checked != mTrend.YLabels)
            {
                mTrend.YLabels = checkBox_ShowLabels.Checked;
            }
        }

        private void                    button_Set_Click(object aSender, EventArgs aEventArgs)
        {
            try
            {
                mTrend.setYMaxMin(StringUtils.toDouble(textBox_YMax.Text), StringUtils.toDouble(textBox_YMin.Text));
                updateYMaxMin();
            }
            catch (Exception lExc)
            {
                Log.Error("Error while user was configuring max/min value for Trend Y axis. " + lExc.Message, lExc.ToString());
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void                    SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void                    SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mDataTable != null)
                {
                    dataGridView_Elm.DataSource = null;
                    mDataTable.Dispose();
                    mDataTable = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
