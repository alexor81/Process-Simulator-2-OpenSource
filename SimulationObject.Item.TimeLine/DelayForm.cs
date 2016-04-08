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

        private void    DelayForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
