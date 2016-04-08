using System;
using System.Windows.Forms;
using Utils;

namespace Connection.S7IsoTCP
{
    public partial class ItemSetupForm : Form
    {
        private Connection  mConnectionS7IsoTCP;

        public              ItemSetupForm(Connection aConnectionS7IsoTCP, DataItem aItemS7IsoTCP)
        {
            mConnectionS7IsoTCP = aConnectionS7IsoTCP;
            InitializeComponent();

            MemoryType  = aItemS7IsoTCP.mMemoryType;
            DataType    = aItemS7IsoTCP.DataType;
            DB          = aItemS7IsoTCP.DB;
            Bit         = aItemS7IsoTCP.Bit;
            Byte        = aItemS7IsoTCP.Byte;
            Signed      = aItemS7IsoTCP.Signed;
            FloatingP   = aItemS7IsoTCP.FloatingP;
            Length      = aItemS7IsoTCP.Length;

            mConnectionS7IsoTCP.ConnectionState += new EventHandler(onChange);
            updateForm();
        }

        private void        onChange(object aSender, EventArgs aEventArgs)
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

        private void        updateForm()
        {
            if (mConnectionS7IsoTCP.Connected)
            {
                Text = "S7IsoTCP Item";
            }
            else
            {
                Text = "S7IsoTCP Item (Disconnected)";
            }
        }

        public EArea        MemoryType
        {
            get
            {
                switch (comboBox_MemoryType.SelectedIndex)
                {
                    case 0: return EArea.I;
                    case 1: return EArea.Q;
                    case 2: return EArea.M;
                    case 3: return EArea.DB;
                }
                return EArea.M;
            }
            set
            {
                switch (value)
                {
                    case EArea.I:   comboBox_MemoryType.SelectedIndex = 0; break;
                    case EArea.Q:   comboBox_MemoryType.SelectedIndex = 1; break;
                    case EArea.M:   comboBox_MemoryType.SelectedIndex = 2; break;
                    case EArea.DB:  comboBox_MemoryType.SelectedIndex = 3; break;
                }
            }
        }

        public EWordlen     DataType
        {
            get
            {
                switch (comboBox_DataType.SelectedIndex)
                {
                    case 0: return EWordlen.S7_Bit;
                    case 1: return EWordlen.S7_Byte;
                    case 2: return EWordlen.S7_Word;
                    case 3: return EWordlen.S7_DoubleWord;
                }
                return EWordlen.S7_Bit;
            }
            set
            {
                switch (value)
                {
                    case EWordlen.S7_Bit:           comboBox_DataType.SelectedIndex = 0; break;
                    case EWordlen.S7_Byte:          comboBox_DataType.SelectedIndex = 1; break;
                    case EWordlen.S7_Word:          comboBox_DataType.SelectedIndex = 2; break;
                    case EWordlen.S7_DoubleWord:    comboBox_DataType.SelectedIndex = 3; break;
                }
            }
        }

        public int          DB
        {
            get { return (int)spinEdit_DBNum.Value; }
            set { spinEdit_DBNum.Value = (decimal)value; }
        }

        public int          Bit
        {
            get { return (int)spinEdit_Bit.Value; }
            set { spinEdit_Bit.Value = (decimal)value; }
        }

        public int          Byte
        {
            get { return (int)spinEdit_Byte.Value; }
            set { spinEdit_Byte.Value = (decimal)value; }
        }

        public bool         Signed
        {
            get { return checkBox_Signed.Checked; }
            set { checkBox_Signed.Checked = value; }
        }

        public bool         FloatingP
        {
            get { return checkBox_FloatingP.Checked; }
            set { checkBox_FloatingP.Checked = value; }
        }

        public int          Length
        {
            get { return (int)spinEdit_Length.Value; }
            set { spinEdit_Length.Value = value; }
        }
        private void        LengthEnabler()
        {
            if (DataType == EWordlen.S7_Bit)
            {
                label_Length.Enabled    = false;
                spinEdit_Length.Enabled = false;
                spinEdit_Length.Value   = 1;
            }
            else
            {
                label_Length.Enabled    = true;
                spinEdit_Length.Enabled = true;
            }
        }

        private void        comboBox_MemoryType_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            spinEdit_DBNum.Enabled  = (MemoryType == EArea.DB);
            label_DB.Enabled        = spinEdit_DBNum.Enabled;
        }

        private void        comboBox_DataType_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            switch(DataType)
            {
                case EWordlen.S7_Bit:           checkBox_FloatingP.Enabled  = false;
                                                checkBox_Signed.Enabled     = false;
                                                checkBox_FloatingP.Checked  = false;
                                                checkBox_Signed.Checked     = false;
                                                label_Bit.Enabled           = true;
                                                spinEdit_Bit.Enabled        = true;
                                                break;

                case EWordlen.S7_Byte:          checkBox_FloatingP.Enabled  = false;
                                                checkBox_Signed.Enabled     = true;
                                                checkBox_FloatingP.Checked  = false;
                                                label_Bit.Enabled           = false;
                                                spinEdit_Bit.Enabled        = false;
                                                spinEdit_Bit.Value          = 0;
                                                break;

                case EWordlen.S7_Word:          checkBox_FloatingP.Enabled  = false;
                                                checkBox_Signed.Enabled     = true;
                                                checkBox_FloatingP.Checked  = false;
                                                label_Bit.Enabled           = false;
                                                spinEdit_Bit.Enabled        = false;
                                                spinEdit_Bit.Value          = 0;
                                                break;

                case EWordlen.S7_DoubleWord:    checkBox_FloatingP.Enabled  = true;
                                                checkBox_Signed.Enabled     = true;
                                                label_Bit.Enabled           = false;
                                                spinEdit_Bit.Enabled        = false;
                                                spinEdit_Bit.Value          = 0;
                                                break;
            }

            LengthEnabler();
        }

        private void        checkBox_FloatingP_CheckedChanged(object aSender, EventArgs aEventArgs)
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

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void        ItemSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnectionS7IsoTCP.ConnectionState -= onChange;
        }

        private void        ItemSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
