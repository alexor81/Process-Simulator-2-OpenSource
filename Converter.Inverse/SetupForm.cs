using System;
using System.Windows.Forms;
using Utils;

namespace Converter.Inverse
{
    public partial class SetupForm : Form
    {
        public          SetupForm()
        {
            InitializeComponent();
            okCancelButton.setOkOnlyStyle();
        }

        private void    okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            Close();
        }

        private void    SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
