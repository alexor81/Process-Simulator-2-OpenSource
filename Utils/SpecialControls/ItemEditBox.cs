// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;

namespace Utils.SpecialControls
{
    [DefaultEvent("ButtonClick")]
    public partial class ItemEditBox : UserControl
    {
        public                      ItemEditBox()
        {
            InitializeComponent();

            buttonEdit_Item.ToolTipController               = new DevExpress.Utils.ToolTipController();
            buttonEdit_Item.ToolTipController.AutoPopDelay  = 60000;
        }

        public string               ItemRequirements
        {
            get { return buttonEdit_Item.Properties.NullValuePrompt; }
            set { buttonEdit_Item.Properties.NullValuePrompt = value; }
        }

        public string               ItemName
        {
            get { return buttonEdit_Item.Text; }
            set { buttonEdit_Item.Text = value; }
        }

        public string               ItemToolTip
        {
            get { return buttonEdit_Item.ToolTip; }
            set { buttonEdit_Item.ToolTip = value; }
        }

        [Browsable(true)]
        public event EventHandler   ButtonClick;
        private void                raiseButton_Click(object aSender, EventArgs aEventArgs)
        {
            ButtonClick?.Invoke(this, aEventArgs);
        }

        private void                buttonEdit_Item_ButtonClick(object aSender, ButtonPressedEventArgs aEventArgs)
        {
            raiseButton_Click(this, EventArgs.Empty);
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if (buttonEdit_Item.ToolTipController != null)
                {
                    buttonEdit_Item.ToolTipController.Dispose();
                    buttonEdit_Item.ToolTipController = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
