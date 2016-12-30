// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;

namespace SimulationObject.Item.TimeLine
{
    public partial class DelayForm : Form
    {
        public          DelayForm(long aDelay)
        {
            InitializeComponent();
            spinEdit_Delay.Value = aDelay;
        }

        public long     Delay
        {
            get { return (long)spinEdit_Delay.Value; }
        }

        private void    okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void    DelayForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void    DelayForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
