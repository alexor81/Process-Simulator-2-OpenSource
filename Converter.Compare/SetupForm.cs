﻿// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;

namespace Converter.Compare
{
    public partial class SetupForm : Form
    {
        private Converter   mCompare;

        public              SetupForm(Converter aCompare)
        {
            mCompare = aCompare;
            InitializeComponent();

            comboBox_Operation.Items.AddRange(ValuesCompare.Operations);

            comboBox_Operation.SelectedIndex    = mCompare.mValuesCompare.OperationNumber;
            textBox_Value.Text                  = StringUtils.ObjectToString(mCompare.mValue);
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            try
            {
                if (okCancelButton.DialogResult == DialogResult.OK)
                {
                    double lValue                           = StringUtils.toDouble(textBox_Value.Text);
                    mCompare.mValuesCompare.OperationNumber = comboBox_Operation.SelectedIndex;
                    mCompare.mValue                         = lValue;
                }

                Close();
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }
        }

        private void        SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
