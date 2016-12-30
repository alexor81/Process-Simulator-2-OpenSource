// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils;

namespace SimulationObject.Real.XYDependency
{
    public partial class AddSetupForm : Form
    {
        public          AddSetupForm(double aX, double aY)
        {
            InitializeComponent();

            textBox_X.Text = Utils.StringUtils.ObjectToString(aX);
            textBox_Y.Text = Utils.StringUtils.ObjectToString(aY);
        }

        public double   X
        {
            get { return (double)StringUtils.StringToObject(typeof(Double), textBox_X.Text); }
        }

        public double   Y
        {
            get { return (double)StringUtils.StringToObject(typeof(Double), textBox_Y.Text); }
        }

        private void    okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void    AddForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void    AddForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
