// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;

namespace Connection.ModbusN
{
    public partial class ItemSetupForm : Form
    {
        private Connection      mConnectionModbus;

        public                  ItemSetupForm(Connection aConnectionModbus, DataItem aItemModbus)
        {
            mConnectionModbus = aConnectionModbus;
            InitializeComponent();

            SlaveID         = aItemModbus.SlaveID;
            RegisterType    = aItemModbus.RegisterType;
            Register        = aItemModbus.Register;
            DataType        = aItemModbus.DataType;
            SwapWords       = aItemModbus.mSwapWords;
            Length          = aItemModbus.Length;
           
            mConnectionModbus.ConnectionState += new EventHandler(onChange);

            updateForm();
        }

        private void            onChange(object aSender, EventArgs aEventArgs)
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

        private void            updateForm()
        {
            if (mConnectionModbus.Connected)
            {
                Text = "Modbus Item";
            }
            else
            {
                Text = "Modbus Item (Disconnected)";
            }
        }

        public byte             SlaveID
        {
            get { return (byte)spinEdit_SlaveID.Value; }
            set
            {
                spinEdit_SlaveID.Value = value;
            }
        }

        public ERegisterType    RegisterType
        {
            get
            {
                switch (comboBox_RegisterType.SelectedIndex)
                {
                    case 0:     return ERegisterType.COIL_BIT;
                    case 1:     return ERegisterType.INPUT_BIT;
                    case 2:     return ERegisterType.INPUT_REGISTER;
                    default:    return ERegisterType.HOLDING_REGISTER;
                }
            }
            set
            {
                switch (value)
                {
                    case ERegisterType.COIL_BIT:            comboBox_RegisterType.SelectedIndex = 0; break;
                    case ERegisterType.INPUT_BIT:           comboBox_RegisterType.SelectedIndex = 1; break;
                    case ERegisterType.INPUT_REGISTER:      comboBox_RegisterType.SelectedIndex = 2; break;
                    case ERegisterType.HOLDING_REGISTER:    comboBox_RegisterType.SelectedIndex = 3; break;
                }
            }
        }

        public ushort           Register
        {
            get { return (ushort)spinEdit_Register.Value; }
            set
            {
                spinEdit_Register.Value = (decimal)value;
            }
        }

        public Type             DataType
        {
            get
            {
                if (comboBox_RegisterType.SelectedIndex != 0 && comboBox_RegisterType.SelectedIndex != 1)
                {
                    switch (comboBox_DataType.SelectedIndex)
                    {
                        case 0: return typeof(Int16);
                        case 1: return typeof(UInt16);
                        case 2: return typeof(Int32);
                        case 3: return typeof(UInt32);
                        case 4: return typeof(Single);
                    }

                    return typeof(Int16);
                }
                else
                {
                    return typeof(Boolean);
                }
            }
            set
            {
                if (comboBox_RegisterType.SelectedIndex != 0 && comboBox_RegisterType.SelectedIndex != 1)
                {
                    if (value == typeof(Int16))
                    {
                        comboBox_DataType.SelectedIndex = 0;
                    }
                    else if (value == typeof(UInt16))
                    {
                        comboBox_DataType.SelectedIndex = 1;
                    }
                    else if (value == typeof(Int32))
                    {
                        comboBox_DataType.SelectedIndex = 2;
                    }
                    else if (value == typeof(UInt32))
                    {
                        comboBox_DataType.SelectedIndex = 3;
                    }
                    else if (value == typeof(Single))
                    {
                        comboBox_DataType.SelectedIndex = 4;
                    }
                }
            }
        }

        public bool             SwapWords
        {
            get { return checkBox_SwapWords.Checked; }
            set { checkBox_SwapWords.Checked = value; }
        }

        public ushort           Length
        {
            get { return (ushort)spinEdit_Length.Value; }
            set { spinEdit_Length.Value = value; }
        }

        private void            comboBox_RegisterType_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            comboBox_DataType.Items.Clear();
            if (comboBox_RegisterType.SelectedIndex == 0 || comboBox_RegisterType.SelectedIndex == 1)
            {
                label_Type.Enabled          = false;
                comboBox_DataType.Enabled   = false;
                comboBox_DataType.Items.Add("Boolean");
                comboBox_DataType.SelectedIndex = 0;    
            }
            else
            {
                label_Type.Enabled          = true;
                comboBox_DataType.Enabled   = true;
                comboBox_DataType.Items.Add("Int16");
                comboBox_DataType.Items.Add("UInt16");
                comboBox_DataType.Items.Add("Int32");
                comboBox_DataType.Items.Add("UInt32");
                comboBox_DataType.Items.Add("Single");
                comboBox_DataType.SelectedIndex = 0;
            }
        }

        private void            comboBox_DataType_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            checkBox_SwapWords.Enabled = (comboBox_DataType.SelectedIndex == 4 || comboBox_DataType.SelectedIndex == 3 || comboBox_DataType.SelectedIndex == 2);
            if (checkBox_SwapWords.Enabled == false)
            {
                checkBox_SwapWords.Checked = false;
            }
        }

        private void            okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void            ItemSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mConnectionModbus.ConnectionState -= onChange;
        }

        private void            ItemSetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void            ItemSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
