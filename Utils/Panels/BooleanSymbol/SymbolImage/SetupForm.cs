// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.Logger;

namespace Utils.Panels.BooleanSymbol.SymbolImage
{
    public partial class SetupForm : Form
    {
        private IRedraw             mRedraw;
        private SymbolImage         mImage;
        private Bitmap              mBmp;

        public                      SetupForm(SymbolImage aImage, IRedraw aRedraw)
        {
            mImage  = aImage;
            mRedraw = aRedraw;
            InitializeComponent();

            updateForm();
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
                        Size        = mNormalSize;
                        Location    = mNormalLocation;
                        mMaximized  = false;
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

        private void                updateForm()
        {
            pictureBox_Image.Image = null;
            var lOldBmp = mBmp;

            if (mImage.mImgMemStrm != null)
            {
                mBmp                    = new Bitmap(mImage.mImgMemStrm);
                pictureBox_Image.Image  = mBmp;
                labelControl_HW.Text    = StringUtils.ObjectToString(mBmp.Width) + ", " + StringUtils.ObjectToString(mBmp.Height);
            }
            else
            {
                labelControl_HW.Text = "0, 0";
            }

            if (lOldBmp != null)
            {
                lOldBmp.Dispose();
                lOldBmp = null;
            }
        }

        private void                tsButton_Import_Click(object aSender, EventArgs aEventArgs)
        {
            using (var lOpenDlg = new OpenFileDialog())
            {
                lOpenDlg.CheckFileExists    = true;
                lOpenDlg.AddExtension       = true;
                lOpenDlg.Filter             = "Images|*.bmp;*.png;*.gif;*.exif;*.jpg;*.tif";
                lOpenDlg.Multiselect        = false;

                if (lOpenDlg.ShowDialog() == DialogResult.OK)
                {
                    var lMemStrm = new MemoryStream();
                    try
                    {
                        using (FileStream lFileStrm = new FileStream(lOpenDlg.FileName, FileMode.Open))
                        {
                            lFileStrm.CopyTo(lMemStrm);
                        }

                        var lOldStrm        = mImage.mImgMemStrm;
                        mImage.mImgMemStrm  = lMemStrm;

                        if (lOldStrm != null)
                        {
                            lOldStrm.Close();
                            lOldStrm = null;
                        }

                        updateForm();
                        mRedraw.Redraw();
                    }
                    catch (Exception lExc)
                    {
                        lMemStrm.Close();
                        Log.Error("Unable to load image from '" + lOpenDlg.FileName + "'. " + lExc.Message, lExc.ToString());
                        MessageForm.showMessage(lExc.Message, this);
                        return;
                    }         
                }
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    
        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mBmp != null)
                {
                    pictureBox_Image.Image = null;
                    mBmp.Dispose();
                    mBmp = null;
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
