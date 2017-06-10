// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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

            mVisibleItemHandle      = mMove.mVisibleItemHandle;
            mMovingByUserItemHandle = mMove.mMovingByUserItemHandle;
            mUserMove               = mMove.mUserCanMove;
            mWidthItemHandle        = mMove.mWidthItemHandle;
            mHeightItemHandle       = mMove.mHeightItemHandle;
            mLabelItemHandle        = mMove.mLabelItemHandle;
            mLabelFont              = mMove.mLabelFont;
            mLabelColor             = mMove.mLabelColor;

            if (mMove.mBmp != null)
            {
                mImgMemStrm         = mMove.mImgMemStrm;
                mBmp                = mMove.mBmp;
            }

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

        #region Options

            public int              mVisibleItemHandle      = -1;
            public int              mMovingByUserItemHandle = -1;
            public bool             mUserMove;
            public int              mWidthItemHandle        = -1;
            public int              mHeightItemHandle       = -1;
            public int              mLabelItemHandle        = -1;
            public Font             mLabelFont;
            public Color            mLabelColor; 

            private void            tsButton_Options_Click(object aSender, EventArgs aEventArgs)
            {
                using (var lOptions = new OptionsForm(this, mBrowser))
                {
                    lOptions.ShowDialog(this);
                }

                updateForm();
            }

        #endregion

        private Bitmap              mPBoxBmp;
        private void                updateForm()
        {
            if (mPBoxBmp != null)
            {
                pictureBox.Image = null;
                mPBoxBmp.Dispose();
                mPBoxBmp = null;
            }

            if (mBmp != null)
            {
                var lWidth = mBmp.Width;
                if (mWidthItemHandle != -1)
                {
                    try
                    {
                        lWidth = (int)mBrowser.readItemValue(mWidthItemHandle);
                    }
                    catch {}

                    if (lWidth > ImageMove.Move.MaxWidth) lWidth = ImageMove.Move.MaxWidth;
                }

                var lHeight = mBmp.Height;
                if (mHeightItemHandle != -1)
                {
                    try
                    {
                        lHeight = (int)mBrowser.readItemValue(mHeightItemHandle);
                    }
                    catch {}

                    if (lHeight > ImageMove.Move.MaxHeight) lHeight = ImageMove.Move.MaxHeight;
                }

                var lLabel = "";
                if (mLabelItemHandle != -1)
                {
                    try
                    {
                        lLabel = StringUtils.ObjectToString(mBrowser.readItemValue(mLabelItemHandle));
                    }
                    catch {}
                }

                var mPBoxBmp = new Bitmap(lWidth, lHeight);
                mPBoxBmp.SetResolution(mBmp.HorizontalResolution, mBmp.VerticalResolution);

                using (var lGraphics = Graphics.FromImage(mPBoxBmp))
                {
                    lGraphics.Clear(Color.Transparent);
                    lGraphics.InterpolationMode = InterpolationMode.High;
                    lGraphics.DrawImage(mBmp, 0, 0, lWidth, lHeight);
                    if (String.IsNullOrWhiteSpace(lLabel) == false)
                    {
                        lGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        using (var lBrush = new SolidBrush(mLabelColor))
                        {
                            lGraphics.DrawString(lLabel, mLabelFont, lBrush, 0, 0);
                        }
                    }
                }

                pictureBox.Image        = mPBoxBmp;
                labelControl_HW.Text    = StringUtils.ObjectToString(lWidth) + ", " + StringUtils.ObjectToString(lHeight);
            }
            else
            {
                labelControl_HW.Text = "0, 0";
            }
        }

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
                        }

                        if (mImgMemStrm != null && ReferenceEquals(mMove.mImgMemStrm, mImgMemStrm) == false)
                        {
                            mImgMemStrm.Close();
                            mImgMemStrm = null;
                        }

                        mImgMemStrm         = lMemStrm;
                        mBmp                = lBmp;

                        updateForm();

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

        private void                Cancel()
        {
            if (mBmp != null && ReferenceEquals(mMove.mBmp, mBmp) == false)
            {
                mBmp.Dispose();
                mBmp                = null;        
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
                    lChecker.addItemName(mBrowser.getItemNameByHandle(mVisibleItemHandle));
                    lChecker.addItemName(mBrowser.getItemNameByHandle(mMovingByUserItemHandle));
                    lChecker.addItemName(mBrowser.getItemNameByHandle(mWidthItemHandle));
                    lChecker.addItemName(mBrowser.getItemNameByHandle(mHeightItemHandle));
                    lChecker.addItemName(mBrowser.getItemNameByHandle(mLabelItemHandle));

                    mMove.mXValueItemHandle         = mBrowser.getItemHandleByName(itemEditBox_X.ItemName);
                    mMove.mYValueItemHandle         = mBrowser.getItemHandleByName(itemEditBox_Y.ItemName);

                    mMove.mVisibleItemHandle        = mVisibleItemHandle;
                    if(mMove.mVisibleItemHandle == -1)
                    {
                        mMove.mVisible = true;
                    }

                    mMove.mUserCanMove              = mUserMove;
                    mMove.mMovingByUserItemHandle   = mMovingByUserItemHandle;

                    mMove.mWidthItemHandle          = mWidthItemHandle;
                    if (mWidthItemHandle == -1)
                    {
                        mMove.mWidth = mBmp.Width;
                    }

                    mMove.mHeightItemHandle         = mHeightItemHandle;
                    if (mHeightItemHandle == -1)
                    {
                        mMove.mHeight = mBmp.Height;
                    }

                    mMove.mLabelItemHandle          = mLabelItemHandle;
                    if (mLabelItemHandle == -1)
                    {
                        mMove.mLabel = "";
                    }

                    mMove.mLabelFont                = mLabelFont;
                    mMove.mLabelColor               = mLabelColor;

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

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Cancel();
            }
        }
    
        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mPBoxBmp != null)
                {
                    pictureBox.Image = null;
                    mPBoxBmp.Dispose();
                    mPBoxBmp = null;
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
