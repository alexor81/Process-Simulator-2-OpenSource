// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.SpecialControls
{
    public partial class ValueControl : UserControl
    {
        public          ValueControl()
        {
            InitializeComponent();
            dateTimePicker_Value.CustomFormat = StringUtils.DTFormat;
        }

        public void     setValue(object aValue)
        {
            if(aValue == null)
            {
                throw new ArgumentException("Value is null. ");
            }

            setType(aValue.GetType());

            if (aValue is Boolean)
            {
                radioButton_True.Checked    = ((Boolean)aValue);
                radioButton_False.Checked   = !((Boolean)aValue);
            }
            else if(aValue is DateTime)
            {
                DateTime lValue = (DateTime)aValue;
                dateTimePicker_Value.Value = lValue;
                numericUpDown_Ms.Value = lValue.Millisecond;
            }
            else
            {
                textBox_Value.Text = StringUtils.ObjectToString(aValue);
            }
        }
        public string   getValueString()
        {
            if (mType == typeof(Boolean))
            {
                return StringUtils.ObjectToString(radioButton_True.Checked);
            }
            else if (mType == typeof(DateTime))
            {
                TimeSpan lTimeSpan = new TimeSpan(0, 0, 0, 0, dateTimePicker_Value.Value.Millisecond);
                return StringUtils.ObjectToString(dateTimePicker_Value.Value.Subtract(lTimeSpan).AddMilliseconds((double)numericUpDown_Ms.Value));
            }
            else
            {
                return textBox_Value.Text;
            }
        }

        private Type    mType;
        public void     setType(Type aType)
        {
            if(aType == typeof(Boolean))
            {
                textBox_Value.Visible           = false;
                dateTimePicker_Value.Visible    = false;
                numericUpDown_Ms.Visible        = false;
                radioButton_True.Visible        = true;
                radioButton_False.Visible       = true;        
            }
            else if (aType == typeof(DateTime))
            {
                textBox_Value.Visible           = false;
                dateTimePicker_Value.Visible    = true;
                numericUpDown_Ms.Visible        = true;
                radioButton_True.Visible        = false;
                radioButton_False.Visible       = false; 
            }
            else
            {
                textBox_Value.Visible           = true;
                dateTimePicker_Value.Visible    = false;
                numericUpDown_Ms.Visible        = false;
                radioButton_True.Visible        = false;
                radioButton_False.Visible       = false; 
            }

            mType = aType;
        }
    }
}
