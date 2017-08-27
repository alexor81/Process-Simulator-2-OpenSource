// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Utils.Logger;

namespace Utils.Panels.BitmapImage
{
    public partial class BitmapImagePanel : UserControl, IPanel
    {
        public MemoryStream         mImgMemStrm;
        public Bitmap               mBmp;

        public                      BitmapImagePanel()
        {
            InitializeComponent();

            mBmp        = new Bitmap(Width, Height);
            mImgMemStrm = new MemoryStream();

            using (Graphics lGraphics = Graphics.FromImage(mBmp))
            {
                lGraphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

                lGraphics.TextRenderingHint     = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                StringFormat lStringFromat      = new StringFormat();
                lStringFromat.Alignment         = StringAlignment.Center;
                lStringFromat.LineAlignment     = StringAlignment.Center;
                Font lFont                      = new Font("Microsoft Sans Serif", 12);
                lGraphics.DrawString("Image", lFont, Brushes.Black, new Rectangle(0, 0, Width - 1, Height - 1), lStringFromat);
                lFont.Dispose();
            }

            mBmp.Save(mImgMemStrm, ImageFormat.Png);
        }

        public void                 fillForDemo()
        {
            clear();

            mBmp        = new Bitmap(Width, Height);
            mImgMemStrm = new MemoryStream();

            using (Graphics lGraphics = Graphics.FromImage(mBmp))
            {
                lGraphics.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                lGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

                StringFormat lStringFromat  = new StringFormat();
                lStringFromat.Alignment     = StringAlignment.Center;
                lStringFromat.LineAlignment = StringAlignment.Center;
                Font lFont = new Font("Microsoft Sans Serif", 20);
                lGraphics.DrawString("Hello, world!", lFont, Brushes.Blue, new Rectangle(0, 0, Width - 1, 60), lStringFromat);
                lFont.Dispose();

                lGraphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

                lGraphics.FillEllipse(Brushes.Red, 73, 64, 73, 64);
                lGraphics.DrawEllipse(Pens.Black, 73, 64, 73, 64);

                lGraphics.FillRectangle(Brushes.LimeGreen, 127, 89, 60, 60);
                lGraphics.DrawRectangle(Pens.Black, 127, 89, 60, 60);
            }

            mBmp.Save(mImgMemStrm, ImageFormat.Bmp);
        }

        public void                 loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            IsContainer = lReader.getAttribute<Boolean>("Conteiner", IsContainer);

            if (aXMLTextReader.IsEmptyElement == false)
            {
                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("Image", StringComparison.Ordinal))
                {
                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        aXMLTextReader.Read();
                        mImgMemStrm = new MemoryStream(Convert.FromBase64String(aXMLTextReader.ReadString()));
                    }
                }
            }

            if (mImgMemStrm == null)
            {
                throw new ArgumentException("Image does not exist. ");
            }

            try
            {
                mBmp = new Bitmap(mImgMemStrm);
            }
            catch (Exception lExc)
            {
                mImgMemStrm.Close();
                mImgMemStrm = null;
                throw new ArgumentException("Image is wrong. " + lExc.Message, lExc);
            }
        }

        public void                 saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Conteiner", StringUtils.ObjectToString(IsContainer));
            aXMLTextWriter.WriteStartElement("Image");
                aXMLTextWriter.WriteString(Convert.ToBase64String(mImgMemStrm.ToArray()));
            aXMLTextWriter.WriteEndElement();
        }

        public UserControl          UserControl { get { return this; } }

        public bool                 IsScalable { get { return true; } }

        public bool                 IsTransparent { get { return true; } }

        public bool                 IsConfigurable { get { return true; } }

        private bool                mIsContainer = false;
        public bool                 IsContainer
        {
            get { return mIsContainer; }
            set { mIsContainer = value; }
        }

        public void                 setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string               LabelText
        {
            get { return ""; }
            set { }
        }

        public void                 updateValues()
        {
        }

        public void                 updateProperties()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateP(); }));
            }
            else
            {
                updateP();
            }
        }
        private void                updateP()
        {
            if (mBmp != null)
            {
                pictureBox.Image = mBmp;
            }
            else
            {
                Log.Error("Error in BitmapImage panel. Image is empty. ");
            }
        }

        public void                 fitSize()
        {
            Size = mBmp.Size;
        }

        private void                BitmapImagePanel_Load(object aSender, EventArgs aEventArgs)
        {
            updateP();
        }

        private void                clear()
        {
            if (mBmp != null)
            {
                mBmp.Dispose();
                mBmp = null;
            }

            if (mImgMemStrm != null)
            {
                mImgMemStrm.Close();
                mImgMemStrm = null;
            }
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                clear();

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
