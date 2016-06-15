using System;
using System.Windows.Forms;
using S7PROSIMLib;
using Utils;

namespace Connection.S7PLCSim
{
    public partial class ItemSetupForm : Form
    {
        private Connection              mConnectionS7PLCSim;

        public                          ItemSetupForm(Connection aConnectionS7PLCSim, DataItem aItemS7PLCSim)
        {
            mConnectionS7PLCSim = aConnectionS7PLCSim;
            InitializeComponent();

            MemoryType  = aItemS7PLCSim.mMemoryType;
            DataType    = aItemS7PLCSim.DataType;
            DB          = aItemS7PLCSim.DB;
            Bit         = aItemS7PLCSim.Bit;
            Byte        = aItemS7PLCSim.Byte;
            Signed      = aItemS7PLCSim.Signed;
            FloatingP   = aItemS7PLCSim.FloatingP;
            Length      = aItemS7PLCSim.Length;

            mConnectionS7PLCSim.ConnectionState += new EventHandler(onChange);
            updateForm();
        }

        private void                    onChange(object aSender, EventArgs aEventArgs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateForm(); }));
            }
            else
            {
                updateForm();
            }
        }

        private void                    updateForm()
        {
            if (mConnectionS7PLCSim.Connected)
            {
                Text = "S7PLCSim Item";
            }
            else
            {
                Text = "S7PLCSim Item (Disconnected)";
            }
        }

        public EPLCMemoryType           MemoryType
        {
            get
            {
                switch (comboBox_MemoryType.SelectedIndex)
                {
                    case 0: return EPLCMemoryType.I;
                    case 1: return EPLCMemoryType.Q;
                    case 2: return EPLCMemoryType.M;
                    case 3: return EPLCMemoryType.DB;
                }
                return EPLCMemoryType.M;
            }
            set
            {
                switch (value)
                {
                    case EPLCMemoryType.I:  comboBox_MemoryType.SelectedIndex = 0; break;
                    case EPLCMemoryType.Q:  comboBox_MemoryType.SelectedIndex = 1; break;
                    case EPLCMemoryType.M:  comboBox_MemoryType.SelectedIndex = 2; break;
                    case EPLCMemoryType.DB: comboBox_MemoryType.SelectedIndex = 3; break;
                }
            }
        }

        public PointDataTypeConstants   DataType
        {
            get
            {
                switch (comboBox_DataType.SelectedIndex)
                {
                    case 0: return PointDataTypeConstants.S7_Bit;
                    case 1: return PointDataTypeConstants.S7_Byte;
                    case 2: return PointDataTypeConstants.S7_Word;
                    case 3: return PointDataTypeConstants.S7_DoubleWord;
                }
                return PointDataTypeConstants.S7_Bit;
            }
            set
            {
                switch (value)
                {
                    case PointDataTypeConstants.S7_Bit:         comboBox_DataType.SelectedIndex = 0; break;
                    case PointDataTypeConstants.S7_Byte:        comboBox_DataType.SelectedIndex = 1; break;
                    case PointDataTypeConstants.S7_Word:        comboBox_DataType.SelectedIndex = 2; break;
                    case PointDataTypeConstants.S7_DoubleWord:  comboBox_DataType.SelectedIndex = 3; break;
                }
            }
        }

        public int                      DB
        {
            get { return (int)spinEdit_DBNum.Value; }
            set { spinEdit_DBNum.Value = (decimal)value; }
        }

        public int                      Bit
        {
            get { return (int)spinEdit_Bit.Value; }
            set { spinEdit_Bit.Value = (decimal)value; }
        }

        public int                      Byte
        {
            get { return (int)spinEdit_Byte.Value; }
            set { spinEdit_Byte.Value = (decimal)value; }
        }

        public bool                     Signed
        {
            get { return checkBox_Signed.Checked; }
            set { checkBox_Signed.Checked = value; }
        }

        public bool                     FloatingP
        {
            get { return checkBox_FloatingP.Checked; }
            set { checkBox_FloatingP.Checked = value; }
        }

        public int                      Length
        {
            get { return (int)spinEdit_Length.Value; }
            set { spinEdit_Length.Value = value; }
        }
        private void                    LengthEnabler()
        {
            if ((MemoryType == EPLCMemoryType.I || MemoryType == EPLCMemoryType.Q) && DataType != PointDataTypeConstants.S7_Bit)
            {
                label_Length.Enabled    = true;
                spinEdit_Length.Enabled = true;
            }
            else
            {
                label_Length.Enabled    = false;
                spinEdit_Length.Enabled = false;
                spinEdit_Length.Value   = 1;
            }
        }

        private void                    comboBox_MemoryType_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            spinEdit_DBNum.Enabled  = (MemoryType == EPLCMemoryType.DB);
            label_DB.Enabled        = spinEdit_DBNum.Enabled;

            LengthEnabler();
        }

        private void                    comboBox_DataType_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            switch (DataType)
            {
                case PointDataTypeConstants.S7_Bit:         checkBox_FloatingP.Enabled  = false;
                                                            checkBox_Signed.Enabled     = false;
                                                            checkBox_FloatingP.Checked  = false;
                                                            checkBox_Signed.Checked     = false;
                                                            label_Bit.Enabled           = true;
                                                            spinEdit_Bit.Enabled        = true;
                                                            break;

                case PointDataTypeConstants.S7_Byte:        checkBox_FloatingP.Enabled  = false;
                                                            checkBox_Signed.Enabled     = true;
                                                            checkBox_FloatingP.Checked  = false;
                                                            label_Bit.Enabled           = false;
                                                            spinEdit_Bit.Enabled        = false;      
                                                            spinEdit_Bit.Value          = 0;
                                                            break;

                case PointDataTypeConstants.S7_Word:        checkBox_FloatingP.Enabled  = false;
                                                            checkBox_Signed.Enabled     = true;
                                                            checkBox_FloatingP.Checked  = false;
                                                            label_Bit.Enabled           = false;
                                                            spinEdit_Bit.Enabled        = false;
                                                            spinEdit_Bit.Value          = 0;
                                                            break;

                case PointDataTypeConstants.S7_DoubleWord:  checkBox_FloatingP.Enabled  = true;
                                                            checkBox_Signed.Enabled     = true;
                                                            label_Bit.Enabled           = false;
                                                            spinEdit_Bit.Enabled        = false;
                                                            spinEdit_Bit.Value          = 0;
                                                            break;
            }

            LengthEnabler();
        }

        private void                    checkBox_FloatingP_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_FloatingP.Checked)
            {
                checkBox_Signed.Enabled = false;
                checkBox_Signed.Checked = false;
            }
            else
            {
                checkBox_Signed.Enabled = true;
            }
        }

        private void                    okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                    ItemSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnectionS7PLCSim.ConnectionState -= onChange;
        }

        private void                    ItemSetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                    ItemSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}