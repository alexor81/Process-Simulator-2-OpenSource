// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
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

        private void    SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void    SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
