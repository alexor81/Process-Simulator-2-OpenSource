// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.BitmapImage
{
    public partial class OptionsForm : Form
    {
        private SetupForm   mSetupForm;

        public              OptionsForm(SetupForm aSetupForm)
        {
            mSetupForm = aSetupForm;
            InitializeComponent();

            checkBox_IsConteiner.Checked = mSetupForm.IsContainer;
        }

        private void        checkBox_IsConteiner_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mSetupForm.IsContainer != checkBox_IsConteiner.Checked)
            {
                mSetupForm.IsContainer = checkBox_IsConteiner.Checked;
            }
        }

        private void        OptionsForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void        OptionsForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
