// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Panels.BitmapImage
{
    public partial class SetupForm : Form
    {
        private BitmapImagePanel    mPanel;
        private MemoryStream        mImgMemStrm;
        private Bitmap              mBmp;
        private string              mPath;

        public                      SetupForm(BitmapImagePanel aPanel)
        {
            mPanel = aPanel;
            InitializeComponent();

            if (mPanel.mBmp != null)
            {
                mImgMemStrm         = mPanel.mImgMemStrm;
                mBmp                = mPanel.mBmp;
                pictureBox.Image    = mPanel.mBmp;
            }

            IsContainer = mPanel.IsContainer;
        }

        #region Size

            private bool            mMaximized;
            private Size            mNormalSize;
            private Point           mNormalLocation;
            protected override void WndProc(ref Message aMessage)
            {
                if (aMessage.Msg == (int)WM.NCLBUTTONDBLCLK)
                {
                    if (mMaximized)
                    {
                        Size = mNormalSize;
                        Location = mNormalLocation;
                        mMaximized = false;
                    }
                    else
                    {
                        mNormalSize     = Size;
                        mNormalLocation = Location;
                        Screen lScreen  = Screen.FromControl(this);
                        Size            = lScreen.WorkingArea.Size;
                        Location        = lScreen.WorkingArea.Location;
                        mMaximized      = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

        #endregion

        private void                tsButton_Import_Click(object aSender, EventArgs aEventArgs)
        {
            using (var lOpenDlg = new OpenFileDialog())
            {
                lOpenDlg.CheckFileExists    = true;
                lOpenDlg.AddExtension       = true;
                lOpenDlg.Filter             = "Images|*.bmp;*.png;*.gif;*.exif;*.jpg;*.tif";
                lOpenDlg.Multiselect        = false;

                if (String.IsNullOrWhiteSpace(mPath))
                {
                    if (String.IsNullOrWhiteSpace(MiscUtils.ProjectPath) == false)
                    {
                        lOpenDlg.InitialDirectory = MiscUtils.ProjectPath;
                    }
                }

                if (lOpenDlg.ShowDialog() == DialogResult.OK)
                {
                    MemoryStream lMemStrm = new MemoryStream();

                    try
                    {
                        using (FileStream lFileStrm = new FileStream(lOpenDlg.FileName, FileMode.Open))
                        {
                            lFileStrm.CopyTo(lMemStrm);
                        }

                        Bitmap lBmp = new Bitmap(lMemStrm);

                        if (mBmp != null && ReferenceEquals(mPanel.mBmp, mBmp) == false)
                        {
                            mBmp.Dispose();
                            mBmp                = null;
                            pictureBox.Image    = null;
                        }

                        if (mImgMemStrm != null && ReferenceEquals(mPanel.mImgMemStrm, mImgMemStrm) == false)
                        {
                            mImgMemStrm.Close();
                            mImgMemStrm = null;
                        }

                        mImgMemStrm         = lMemStrm;
                        mBmp                = lBmp;
                        pictureBox.Image    = lBmp;

                        mPath               = Path.GetDirectoryName(lOpenDlg.FileName);
                    }
                    catch (Exception lExc)
                    {
                        lMemStrm.Close();
                        Log.Error("Unable to load image from '" + lOpenDlg.FileName + "'. " + lExc.Message, lExc.ToString());
                        MessageForm.showMessage(lExc.Message, this);
                    }
                }
            }
        }

        private void                tsButton_Fit_Click(object aSender, EventArgs aEventArgs)
        {
            mPanel.fitSize();
        }

        #region Options

            private bool            mIsContainer;
            public bool             IsContainer
            {
                get { return mIsContainer; }
                set { mIsContainer = value; }
            }

            private void            tsButton_Options_Click(object aSender, EventArgs aEventArgs)
            {
                using (Form lOptionsForm = new OptionsForm(this))
                {
                    lOptionsForm.ShowDialog(this);
                }
            }

        #endregion

        private void                Ok()
        {
            try
            {
                if (mPanel.mBmp != null && ReferenceEquals(mPanel.mBmp, mBmp) == false)
                {
                    mPanel.mBmp.Dispose();
                }

                if (mPanel.mImgMemStrm != null && ReferenceEquals(mPanel.mImgMemStrm, mImgMemStrm) == false)
                {
                    mPanel.mImgMemStrm.Close();
                }

                mPanel.mImgMemStrm = mImgMemStrm;
                mPanel.mBmp = mBmp;
                mPanel.IsContainer = IsContainer;

                if (mPanel.Width != mBmp.Width || mPanel.Height != mBmp.Height)
                {
                    if (QuestionForm.askQuestion("Fit panel to image size?", this) == DialogResult.Yes)
                    {
                        mPanel.fitSize();
                    }
                }

                mPanel.updateProperties();

                DialogResult = DialogResult.OK;
            }
            catch (Exception lExc)
            {
                MessageForm.showMessage(lExc.Message, this);
            }   
        }

        private void                Cancel()
        {
            if (mBmp != null && ReferenceEquals(mPanel.mBmp, mBmp) == false)
            {
                mBmp.Dispose();
                pictureBox.Image    = null;
                mBmp                = null;        
            }

            if (mImgMemStrm != null && ReferenceEquals(mPanel.mImgMemStrm, mImgMemStrm) == false)
            {
                mImgMemStrm.Close();
                mImgMemStrm = null;
            }

            DialogResult = DialogResult.Cancel;
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                Cancel();
            }
            else
            {
                Ok();
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Cancel();
            }
        }

        private void                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
