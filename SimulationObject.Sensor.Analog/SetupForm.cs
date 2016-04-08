using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;
using Utils.SpecialControls;

namespace SimulationObject.Sensor.Analog
{
    public partial class SetupForm : Form
    {
        private AnalogSensor    mAnalogSensor;
        private IItemBrowser    mBrowser;

        public                  SetupForm(AnalogSensor aAnalogSensor, IItemBrowser aBrowser)
        {
            mAnalogSensor   = aAnalogSensor;
            mBrowser        = aBrowser;
            InitializeComponent();

            comboBox_Operation.Items.AddRange(ValuesCompare.Operations);

            if (mAnalogSensor.mValueItemHandle != -1)
            {
                itemEditBox_Item.ItemName    = mBrowser.getItemNameByHandle(mAnalogSensor.mValueItemHandle);
                itemEditBox_Item.ItemToolTip = mBrowser.getItemToolTipByHandle(mAnalogSensor.mValueItemHandle);
            }

            textBox_Units.Text      = mAnalogSensor.Units;
            textBox_RawMin.Text     = StringUtils.ObjectToString(mAnalogSensor.mValueScale.InMin);
            textBox_RawMax.Text     = StringUtils.ObjectToString(mAnalogSensor.mValueScale.InMax);
            checkBox_Fault.Checked  = mAnalogSensor.mFault;
            textBox_FValue.Text     = StringUtils.ObjectToString(mAnalogSensor.mFaultValue);
            textBox_PMin.Text       = StringUtils.ObjectToString(mAnalogSensor.mValueScale.OutMin);
            textBox_PMax.Text       = StringUtils.ObjectToString(mAnalogSensor.mValueScale.OutMax);
            
            for (int i = 0; i < mAnalogSensor.mThdItemHandles.Length; i++)
            {
                dataGridView_Thd.Rows.Add(mAnalogSensor.mThdOperations[i].OperationName, StringUtils.ObjectToString(mAnalogSensor.Thresholds[i]), mBrowser.getItemNameByHandle(mAnalogSensor.mThdItemHandles[i]));
            }

            if (dataGridView_Thd.RowCount == 0)
            {
                button_Delete.Enabled = false;
                button_Modify.Enabled = false;
            }
        }

        private void            ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

        private void            dataGridView_Thd_SelectionChanged(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Thd.SelectedRows.Count != 0)
            {
                int RowIndex                        = dataGridView_Thd.SelectedRows[0].Index;
                comboBox_Operation.SelectedIndex    = ValuesCompare.OperationNameToNumber(dataGridView_Thd.Rows[RowIndex].Cells[0].Value.ToString());
                textBox_ThdValue.Text               = StringUtils.ObjectToString(dataGridView_Thd.Rows[RowIndex].Cells[1].Value);
                itemEditBox_Thd.ItemName            = StringUtils.ObjectToString(dataGridView_Thd.Rows[RowIndex].Cells[2].Value);
                itemEditBox_Thd.ItemToolTip         = mBrowser.getItemToolTipByHandle(mBrowser.getItemHandleByName(itemEditBox_Thd.ItemName));
            }
        }

        private bool            checkThdParams(bool aCheckSelected)
        {
            try
            {
                double lValue;
                double lPMin;
                double lPMax;

                try
                {
                    lValue = StringUtils.toDouble(textBox_ThdValue.Text);
                }
                catch(Exception lExc)
                {
                    throw new ArgumentException("Wrong threshold value. ", lExc);
                }

                try
                {
                    lPMin = StringUtils.toDouble(textBox_PMin.Text);
                }
                catch(Exception lExc)
                {
                    throw new ArgumentException("Wrong minimum value for physical signal. ", lExc);
                }

                try
                {
                    lPMax = StringUtils.toDouble(textBox_PMax.Text);
                }
                catch (Exception lExc)
                {
                    throw new ArgumentException("Wrong maximum value for physical signal. ", lExc);
                }

                if (lValue > lPMax)
                {
                    throw new ArgumentException("Threshold value is more than maximum of physical value. ");
                }

                if (lValue < lPMin)
                {
                    throw new ArgumentException("Threshold value is less than minimum of physical value. ");
                }

                if (String.IsNullOrWhiteSpace(itemEditBox_Thd.ItemName))
                {
                    throw new ArgumentException("Threshold Item is missing. ");
                }

                var lChecker = new RepeatItemNameChecker();
                lChecker.addItemName(itemEditBox_Item.ItemName);
                lChecker.addItemName(itemEditBox_Thd.ItemName);
                int lCount = dataGridView_Thd.Rows.Count;
                for (int i = 0; i < lCount; i++)
                {
                    if (aCheckSelected == false && i == dataGridView_Thd.SelectedRows[0].Index)
                    {
                        continue;
                    }

                    lChecker.addItemName(dataGridView_Thd.Rows[i].Cells[2].Value.ToString());
                }
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
                return false;
            }

            return true;
        }

        private void            button_Add_Click(object aSender, EventArgs aEventArgs)
        {
            if (comboBox_Operation.SelectedIndex == -1)
            {
                MessageForm.showMessage("Operation is missing. ", this);
                return;
            }

            if (checkThdParams(true) == true)
            {
                dataGridView_Thd.Rows.Add(comboBox_Operation.Text, textBox_ThdValue.Text, itemEditBox_Thd.ItemName);
                button_Delete.Enabled = true;
                button_Modify.Enabled = true;
            }
        }

        private void            button_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Thd.SelectedRows.Count != 0)
            {
                dataGridView_Thd.Rows.Remove(dataGridView_Thd.SelectedRows[0]);
            }

            if (dataGridView_Thd.RowCount == 0)
            {
                button_Delete.Enabled = false;
                button_Modify.Enabled = false;
            }
        }

        private void            button_Modify_Click(object aSender, EventArgs aEventArgs)
        {
            if (dataGridView_Thd.SelectedRows.Count != 0)
            {
                if (checkThdParams(false) == true)
                {
                    int lRowIndex                                   = dataGridView_Thd.SelectedRows[0].Index;
                    dataGridView_Thd.Rows[lRowIndex].Cells[0].Value = comboBox_Operation.Text;
                    dataGridView_Thd.Rows[lRowIndex].Cells[1].Value = textBox_ThdValue.Text;
                    dataGridView_Thd.Rows[lRowIndex].Cells[2].Value = itemEditBox_Thd.ItemName;
                }
            }
        }

        private void            okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(itemEditBox_Item.ItemName))
                    {
                        throw new ArgumentException("Item is missing. ");
                    }

                    double lRawMin;
                    double lRawMax;
                    double lFValue;
                    double lPMin;
                    double lPMax;

                    try
                    {
                        lRawMin = StringUtils.toDouble(textBox_RawMin.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong minimum value for raw signal. ", lExc);
                    }

                    try
                    {
                        lRawMax = StringUtils.toDouble(textBox_RawMax.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong maximum value for raw signal. ", lExc);
                    }

                    try
                    {
                        lFValue = StringUtils.toDouble(textBox_FValue.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong fault value for raw signal. ", lExc);
                    }

                    try
                    {
                        lPMin = StringUtils.toDouble(textBox_PMin.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong minimum value for physical signal. ", lExc);
                    }

                    try
                    {
                        lPMax = StringUtils.toDouble(textBox_PMax.Text);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Wrong maximum value for physical signal. ", lExc);
                    }

                    mAnalogSensor.mValueScale.checkProperties(lRawMax, lRawMin, lPMax, lPMin);

                    if (lFValue > lRawMin && lFValue < lRawMax)
                    {
                        throw new ArgumentException("Fault value is inside normal range. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_Item.ItemName);

                    double lValue;
                    int lCount = dataGridView_Thd.Rows.Count;
                    for (int i = 0; i < lCount; i++)
                    {
                        lChecker.addItemName(dataGridView_Thd.Rows[i].Cells[2].Value.ToString());
                        try
                        {
                            lValue = StringUtils.toDouble(dataGridView_Thd.Rows[i].Cells[1].Value.ToString());
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Wrong threshold value '" + dataGridView_Thd.Rows[i].Cells[1].Value.ToString() + "'. ", lExc);
                        }
                        if (lValue > lPMax)
                        {
                            throw new ArgumentException("Threshold value is more than maximum of physical value. ");
                        }

                        if (lValue < lPMin)
                        {
                            throw new ArgumentException("Threshold value is less than minimum of physical value. ");
                        }
                    }

                    mAnalogSensor.mValueItemHandle  = mBrowser.getItemHandleByName(itemEditBox_Item.ItemName);
                    mAnalogSensor.Units             = textBox_Units.Text;
                    mAnalogSensor.mValueScale.setProperties(lRawMax, lRawMin, lPMax, lPMin);
                    mAnalogSensor.mFault            = checkBox_Fault.Checked;
                    mAnalogSensor.mFaultValue       = lFValue;

                    int lThdCount                   = dataGridView_Thd.Rows.Count;
                    mAnalogSensor.mThdItemHandles   = new int[lThdCount];
                    mAnalogSensor.mThdItemValues    = new bool[lThdCount];
                    mAnalogSensor.Thresholds        = new double[lThdCount];
                    mAnalogSensor.mThdOperations    = new ValuesCompare[lThdCount];

                    for (int i = 0; i < lThdCount; i++)
                    {
                        mAnalogSensor.mThdOperations[i]     = new ValuesCompare(dataGridView_Thd.Rows[i].Cells[0].Value.ToString());
                        mAnalogSensor.Thresholds[i]         = StringUtils.toDouble(dataGridView_Thd.Rows[i].Cells[1].Value.ToString());
                        mAnalogSensor.mThdItemHandles[i]    = mBrowser.getItemHandleByName(dataGridView_Thd.Rows[i].Cells[2].Value.ToString());
                    }
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
