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

            if(mMove.mImgMemStrm != null)
            {
                mImgMemStrm         = mMove.mImgMemStrm;
                pictureBox.Image    = new Bitmap(mImgMemStrm);
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
            if (open_file.ShowDialog() == DialogResult.OK)
            {
                MemoryStream lMemStrm = new MemoryStream();

                try
                {
                    using (FileStream lFileStrm = new FileStream(open_file.FileName, FileMode.Open))
                    {
                        lFileStrm.CopyTo(lMemStrm);
                    }

                    Bitmap lBmp = new Bitmap(lMemStrm);

                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                        pictureBox.Image = null;
                    }

                    if (ReferenceEquals(mMove.mImgMemStrm, mImgMemStrm) == false)
                    {
                        mImgMemStrm.Close();
                        mImgMemStrm = null;
                    }

                    mImgMemStrm         = lMemStrm;
                    pictureBox.Image    = lBmp;
                }
                catch (Exception lExc)
                {
                    lMemStrm.Close();
                    Log.Error("Unable to load image from '" + open_file.FileName + "'. " + lExc.Message, lExc.ToString());
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                if (ReferenceEquals(mMove.mImgMemStrm, mImgMemStrm) == false)
                {
                    mImgMemStrm.Close();
                    mImgMemStrm = null;
                }

                DialogResult = DialogResult.Cancel;
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

                    if(mImgMemStrm == null)
                    {
                        throw new ArgumentException("Image is empty. ");
                    }

                    var lChecker = new RepeatItemNameChecker();
                    lChecker.addItemName(itemEditBox_X.ItemName);
                    lChecker.addItemName(itemEditBox_Y.ItemName);

                    mMove.mXValueItemHandle = mBrowser.getItemHandleByName(itemEditBox_X.ItemName);
                    mMove.mYValueItemHandle = mBrowser.getItemHandleByName(itemEditBox_Y.ItemName);

                    if(ReferenceEquals(mMove.mImgMemStrm, mImgMemStrm) == false)
                    {
                        mMove.mImgMemStrm.Close();
                        mMove.mImgMemStrm = mImgMemStrm;
                        mMove.raisePropertiesChanged();
                    }
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
