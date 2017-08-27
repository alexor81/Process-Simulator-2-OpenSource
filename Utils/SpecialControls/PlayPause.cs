// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Utils.SpecialControls
{
    [DefaultEvent("CheckedChanged")]
    public partial class PlayPause : UserControl
    {
        [Browsable(true)]
        public event EventHandler   CheckedChanged;
        private void                raiseCheckedChanged(object aSender, EventArgs aEventArgs)
        {
            CheckedChanged?.Invoke(this, aEventArgs);
        }

        private bool                mChecked;
        public bool                 Checked
        {
            get { return mChecked; }
            set
            {
                if (mChecked != value)
                {
                    mChecked                    = value;
                    checkBox_PlayPause.Checked  = value;

                    if (mChecked)
                    {
                        checkBox_PlayPause.ImageIndex = 1;
                    }
                    else
                    {
                        checkBox_PlayPause.ImageIndex = 0;
                    }
                }
            }
        }

        public                      PlayPause()
        {
            InitializeComponent();
        }

        private void                checkBox_PlayPause_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mChecked != checkBox_PlayPause.Checked)
            {
                Checked = checkBox_PlayPause.Checked;
                raiseCheckedChanged(this, EventArgs.Empty);
            }
        }
    }
}
