using API;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Utils;
using Utils.DialogForms;
using Utils.Logger;
using Utils.SpecialControls;

namespace SimulationObject.Animation.ImageMove
{
    public partial class SetupForm : Form
    {
        private Move                mMove;
        private IItemBrowser        mBrowser;
        private MemoryStream        mImgMemStrm;
        private Bitmap              mBmp;
        private string              mPath;

        public                      SetupForm(Move aMove, IItemBrowser aBrowser)
        {
            mMove       = aMove;
            mBrowser    = aBrowser;
            InitializeComponent();

            if (mMove.mXValueItemHandle != -1)
            {
                itemEditBox_X.ItemName      = mBrowser.getItemNameByHandle(mMove.mXValueItemHandle);
                itemEditBox_X.ItemToolTip   = mBrowser.getItemToolTipByHandle(mMove.mXValueItemHandle);
            }

            if (mMove.mYValueItemHandle != -1)
            {
                itemEditBox_Y.ItemName      = mBrowser.getItemNameByHandle(mMove.mYValueItemHandle);
                itemEditBox_Y.ItemToolTip   = mBrowser.getItemToolTipByHandle(mMove.mYValueItemHandle);
            }

            if (mMove.mVisibleItemHandle != -1)
            {
                itemEditBox_Visible.ItemName    = mBrowser.getItemNameByHandle(mMove.mVisibleItemHandle);
                itemEditBox_Visible.ItemToolTip = mBrowser.getItemToolTipByHandle(mMove.mVisibleItemHandle);
            }

            if (mMove.mBmp != null)
            {
                mImgMemStrm         = mMove.mImgMemStrm;
                mBmp                = mMove.mBmp;
                pictureBox.Image    = mMove.mBmp;
            }
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

        private void                ItemButtonClick(object aSender, EventArgs aEventArgs)
        {
            var lItemEditBox            = (ItemEditBox)aSender;
            int lHandle                 = mBrowser.getItemHandleByForm(mBrowser.getItemHandleByName(lItemEditBox.ItemName), this);
            lItemEditBox.ItemName       = mBrowser.getItemNameByHandle(lHandle);
            lItemEditBox.ItemToolTip    = mBrowser.getItemToolTipByHandle(lHandle);
        }

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

                        if (mBmp != null && ReferenceEquals(mMove.mBmp, mBmp) == false)
                        {
                            mBmp.Dispose();
                            mBmp                = null;
                            pictureBox.Image    = null;
                        }

                        if (mImgMemStrm != null && ReferenceEquals(mMove.mImgMemStrm, mImgMemStrm) == false)
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
                        return;
                    }
                }
            }
        }

        private void                Cancel()
        {
            if (mBmp != null && ReferenceEquals(mMove.mBmp, mBmp) == false)
            {
                mBmp.Dispose();
                mBmp = null;
                pictureBox.Image = null;
            }

            if (mImgMemStrm != null && ReferenceEquals(mMove.mImgMemStrm, mImgMemStrm) == false)
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
                try
                {
                    if (String.IsNullOrWhiteSpace(itemEditBox_X.ItemName))
                    {
                        throw new ArgumentException("X position Item is missing. ");
                    }

                    if (String.IsNullOrWhiteSpace(itemEditBox_Y.ItemName))
                    {
                        throw new ArgumentException("Y position Item is missing. ");
                    }

                    if(mImgMemStrm == null || mBmp == null)
                    {
                        throw new ArgumentException("Image is empty. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_X.ItemName);
                    lChecker.addItemName(itemEditBox_Y.ItemName);
                    lChecker.addItemName(itemEditBox_Visible.ItemName);

                    mMove.mXValueItemHandle     = mBrowser.getItemHandleByName(itemEditBox_X.ItemName);
                    mMove.mYValueItemHandle     = mBrowser.getItemHandleByName(itemEditBox_Y.ItemName);
                    mMove.mVisibleItemHandle    = mBrowser.getItemHandleByName(itemEditBox_Visible.ItemName);

                    if(mMove.mVisibleItemHandle == -1)
                    {
                        mMove.mVisible = true;
                    }

                    if (mMove.mBmp != null && ReferenceEquals(mMove.mBmp, mBmp) == false)
                    {
                        mMove.mBmp.Dispose();
                    }

                    if (mMove.mImgMemStrm != null && ReferenceEquals(mMove.mImgMemStrm, mImgMemStrm) == false)
                    {
                        mMove.mImgMemStrm.Close();   
                    }

                    mMove.mImgMemStrm   = mImgMemStrm;
                    mMove.mBmp          = mBmp;
                    mMove.raiseValuesChanged();
                    mMove.raisePropertiesChanged();
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Cancel();
            }
        }
    }
}
