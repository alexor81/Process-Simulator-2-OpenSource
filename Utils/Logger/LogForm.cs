// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Utils.Logger
{
    public partial class LogForm : Form
    {
        private StringFormat    mStringFormat   = new StringFormat(StringFormatFlags.NoWrap);

        private Brush           mEvenBrush      = new SolidBrush(Color.LightGray);

        private Brush           mBlackBrush     = new SolidBrush(Color.Black);

        private Brush           mWhiteBrush     = new SolidBrush(Color.White);

        public                  LogForm()
        {
            InitializeComponent();
            mStringFormat.SetTabStops(0.0f, new float[1] { 80.0f });

            if (System.Windows.Forms.SystemInformation.TerminalServerSession == false)
            {
                System.Reflection.PropertyInfo aProp =
                      typeof(System.Windows.Forms.Control).GetProperty(
                            "DoubleBuffered",
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Instance);

                aProp.SetValue(listBox_Log, true, null);
            }
        }

        public void             LogMessage(string aMessage)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { addMessage(aMessage); }));
            }
            else
            {
                addMessage(aMessage);
            }
        }
        private void            addMessage(string aMessage)
        {
            lock (mAddMessageLock)
            {
                listBox_Log.BeginUpdate();
                try
                {
                    listBox_Log.Items.Add(aMessage);
                    if (listBox_Log.Items.Count > MaxMessageNum)
                    {
                        listBox_Log.Items.RemoveAt(0);
                    }
                }
                finally
                {
                    listBox_Log.EndUpdate();
                }

                track();
                tsStatusLabel_Total.Text = "Total: " + StringUtils.ObjectToString(Log.ErrorCount + Log.InfoCount);
                tsStatusLabel_Info.Text = "Info: " + StringUtils.ObjectToString(Log.InfoCount);
                tsStatusLabel_Error.Text = "Error: " + StringUtils.ObjectToString(Log.ErrorCount);
            }
        }

        public void             ClearAllMessages()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { clear(); }));
            }
            else
            {
                clear();
            }
        }
        private void            clear()
        {
            lock (mAddMessageLock)
            {
                listBox_Log.BeginUpdate();
                try
                {
                    listBox_Log.Items.Clear();
                }
                finally
                {
                    listBox_Log.EndUpdate();
                }
            }
        }

        public void             ShowForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { showFormFront(); }));
            }
            else
            {
                showFormFront();
            }
        }
        private void            showFormFront()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        public void             DisposeForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { Dispose(); }));
            }
            else
            {
                Dispose();
            }
        }

        private void            listBox_Log_DrawItem(object aSender, DrawItemEventArgs aEventArgs)
        {
            if (aEventArgs.Index >= 0)
            {
                if (aEventArgs.Index % 2 == 0 && aEventArgs.State == DrawItemState.None)
                {
                    aEventArgs.Graphics.FillRectangle(mEvenBrush, aEventArgs.Bounds);
                }
                else
                {
                    aEventArgs.DrawBackground();
                }

                if (
                    aEventArgs.State == DrawItemState.Selected ||
                    aEventArgs.State == (DrawItemState.Selected | DrawItemState.Focus)
                    )
                {
                    aEventArgs.Graphics.DrawString((string)listBox_Log.Items[aEventArgs.Index], aEventArgs.Font, mWhiteBrush, aEventArgs.Bounds, mStringFormat);
                }
                else
                {
                    aEventArgs.Graphics.DrawString((string)listBox_Log.Items[aEventArgs.Index], aEventArgs.Font, mBlackBrush, aEventArgs.Bounds, mStringFormat);
                }
            }
        }

        private void            listBox_Log_MeasureItem(object aSender, MeasureItemEventArgs aEventArgs)
        {
            aEventArgs.ItemHeight = aEventArgs.ItemHeight * StringUtils.getLineCount((string)listBox_Log.Items[aEventArgs.Index]);
        }

        private void            LogForm_VisibleChanged(object aSender, EventArgs aEventArgs)
        {
            if (Visible) track();
        }

        private void            tsButton_Track_Click(object aSender, EventArgs aEventArgs)
        {
            track();
        }

        private void            tsButton_StayOnTop_Click(object aSender, EventArgs aEventArgs)
        {
            TopMost = tsButton_StayOnTop.Checked;
        }

        private void            tsButton_Clear_Click(object aSender, EventArgs aEventArgs)
        {
            clear();
        }

        private readonly object mAddMessageLock = new object();

        private const int       MaxMessageNum = 10000;

        private void            track()
        {
            if (tsButton_Track.Checked)
            {
                listBox_Log.SelectedIndex = listBox_Log.Items.Count - 1;
                listBox_Log.SelectedIndex = -1;
            }
        }

        private void            LoggerForm_FormClosing(object aSender, FormClosingEventArgs aEventArgs)
        {
            if (aEventArgs.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                aEventArgs.Cancel = true;
            }
        }

        private void            LogForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (aEventArgs.Control && aEventArgs.KeyCode == Keys.C)
            {
                if(listBox_Log.SelectedIndex != -1)
                {
                    Clipboard.SetText(listBox_Log.SelectedItem.ToString());
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mStringFormat != null)
                {
                    mStringFormat.Dispose();
                    mStringFormat = null;
                }

                if (mEvenBrush != null)
                {
                    mEvenBrush.Dispose();
                    mEvenBrush = null;
                }

                if (mWhiteBrush != null)
                {
                    mWhiteBrush.Dispose();
                    mWhiteBrush = null;
                }

                if (mBlackBrush != null)
                {
                    mBlackBrush.Dispose();
                    mBlackBrush = null;
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
