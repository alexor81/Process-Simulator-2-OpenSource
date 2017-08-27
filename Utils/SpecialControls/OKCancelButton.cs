// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Utils.SpecialControls
{
    [DefaultEvent("ButtonClick")]
    public partial class OKCancelButton : UserControl
    {
        [Browsable(true)]
        public event EventHandler   ButtonClick;
        private void                raiseButton_Click(object aSender, EventArgs aEventArgs)
        {
            ButtonClick?.Invoke(this, aEventArgs);
        }

        private DialogResult        mDialogResult;
        public DialogResult         DialogResult
        {
            get { return mDialogResult; }
        }

        public                      OKCancelButton()
        {
            InitializeComponent();
        }

        private int                 mOKLeft;
        private void                changeView(int aState)
        {
            switch(aState)
            {
                case 0: button_Cancel.Visible = true;
                        button_Ok.Left = mOKLeft;
                        break;
                case 1: button_Cancel.Visible = false;
                        mOKLeft = button_Ok.Left;
                        button_Ok.Left = Width / 2 - button_Ok.Width / 2;
                        break;
                default: break;
            }
        }

        public void                 setOkOnlyStyle()
        {
            changeView(1);
        }

        public void                 setOkCancelStyle()
        {
            changeView(0);
        }

        public bool                 isOkCancelStyle
        {
            get { return button_Cancel.Visible; }
        }

        private void                button_Ok_Click(object aSender, EventArgs aEventArgs)
        {
            mDialogResult = DialogResult.OK;
            raiseButton_Click(this, EventArgs.Empty);
        }

        private void                button_Cancel_Click(object aSender, EventArgs aEventArgs)
        {
            mDialogResult = DialogResult.Cancel;
            raiseButton_Click(this, EventArgs.Empty);
        }
    }
}
