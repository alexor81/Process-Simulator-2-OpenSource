// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;
using API;

namespace Utils
{
    public partial class PanelForm : Form
    {
        private ISimulationObject   mSimObject;
        private string              mPanelName;
        private IPanel              mPanel;

        public                      PanelForm(ISimulationObject aSimObject, string aPanleName, string aText)
        {
            mSimObject = aSimObject;
            mPanelName = aPanleName;

            InitializeComponent();

            Text            = aText;
            Point lPoint    = Cursor.Position;
            SetDesktopLocation(lPoint.X - Width / 2, lPoint.Y - Height / 2);
        }

        private void                PanelForm_VisibleChanged(object aSender, EventArgs aEventArgs)
        {
            if (Visible)
            {
                mPanel          = mSimObject.getPanel(mPanelName);

                var lControl = mPanel.UserControl;
                Controls.Add(lControl);
                ClientSize = new Size(lControl.Width, lControl.Height);

                mSimObject.ChangedValues        += new EventHandler(onValueChanged);
                mSimObject.ChangedProperties    += new EventHandler(onPropertiesChanged);

                mPanel.updateValues();
                mPanel.updateProperties();

                var lPoint  = Cursor.Position;
                int lX      = lPoint.X - Width / 2;
                int lY      = lPoint.Y - Height / 2;

                int lMax = SystemInformation.VirtualScreen.Width - Width;
                if (lX > lMax)
                {
                    lX = lMax;
                }
                else if (lX < 0)
                {
                    lX = 0;
                }

                lMax = SystemInformation.VirtualScreen.Height - Height;
                if (lY > lMax)
                {
                    lY = lMax;
                }
                else if (lY < 0)
                {
                    lY = 0;
                }
                SetDesktopLocation(lX, lY);
            }
            else
            {
                mSimObject.ChangedValues        -= onValueChanged;
                mSimObject.ChangedProperties    -= onPropertiesChanged;

                Controls.Remove(mPanel.UserControl);
                mPanel.Dispose();
            }
        }

        private void                onValueChanged(object aSender, EventArgs aEventArgs)
        {
            mPanel.updateValues();
        }

        private void                onPropertiesChanged(object aSender, EventArgs aEventArgs)
        {
            mPanel.updateProperties();
        }

        private void                PanelForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
