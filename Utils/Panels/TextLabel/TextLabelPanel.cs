// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.TextLabel
{
    public enum ERotation
    {
        Rotate0     = 0,
        Rotate90    = 1,
        Rotate180   = 2,
        Rotate270   = 3
    }

    public partial class TextLabelPanel : UserControl, IPanel
    {
        public                  TextLabelPanel()
        {
            InitializeComponent();

            mBmp = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            redraw();
        }

        public void             fillForDemo()
        {
        }

        public void             loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader         = new XMLAttributeReader(aXMLTextReader);
            mLabelText          = lReader.getAttribute<String>("Text", "");
            mTextColor          = lReader.getAttribute<Color>("TextColor", mTextColor);
            mBackgroundColor    = lReader.getAttribute<Color>("BackgroundColor", mBackgroundColor);
            mLabelFont          = lReader.getAttribute<Font>("Font", mLabelFont);
            mRotation           = (ERotation)Enum.Parse(typeof(ERotation), lReader.getAttribute<String>("Rotation", ERotation.Rotate0.ToString()));

            redraw();
        }

        public void             saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("Text", LabelText);
            aXMLTextWriter.WriteAttributeString("TextColor", StringUtils.ObjectToString(mTextColor));
            aXMLTextWriter.WriteAttributeString("BackgroundColor", StringUtils.ObjectToString(mBackgroundColor));
            aXMLTextWriter.WriteAttributeString("Font", StringUtils.ObjectToString(mLabelFont));
            aXMLTextWriter.WriteAttributeString("Rotation", StringUtils.ObjectToString(mRotation));
        }

        public UserControl      UserControl { get { return this; } }

        public bool             IsScalable { get { return true; } }

        public bool             IsTransparent { get { return true; } }

        public bool             IsConfigurable { get { return true; } }

        public bool             IsContainer { get { return false; } }

        public void             setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        private string          mLabelText = "Text";
        public string           LabelText
        {
            get { return mLabelText; }
            set 
            {
                if (mLabelText.Equals(value, StringComparison.Ordinal) == false)
                {
                    mLabelText = value;
                    redraw();
                }
            }
        }

        private Color           mTextColor = Color.Black;
        public Color            TextColor
        {
            get { return mTextColor; }
            set 
            {
                if (mTextColor.ToArgb().Equals(value.ToArgb()) == false)
                {
                    mTextColor = value;
                    redraw();
                }
            }
        }

        private Color           mBackgroundColor = SystemColors.Control;
        public Color            BackgroundColor
        {
            get { return mBackgroundColor; }
            set 
            {
                if (mBackgroundColor.ToArgb().Equals(value.ToArgb()) == false)
                {
                    mBackgroundColor = value;
                    redraw();
                }
            }
        }

        private Font            mLabelFont = SystemFonts.DefaultFont;
        public Font             LabelFont
        {
            get { return mLabelFont; }
            set 
            {
                if (mLabelFont.Equals(value) == false)
                {
                    mLabelFont = value;
                    redraw();
                }
            }
        }

        private ERotation       mRotation = ERotation.Rotate0;
        public ERotation        Rotation
        {
            get { return mRotation; }
            set
            {
                if (mRotation != value)
                {
                    mRotation = value;
                    redraw();
                }
            }
        }

        public void             updateValues()
        {
        }

        public void             updateProperties()
        {
        }

        private Bitmap          mBmp;
        private void            redraw()
        {
            bool lTextExist = (String.IsNullOrWhiteSpace(mLabelText) == false);
            Bitmap lBmp;
            Graphics lGraphics;

            if (lTextExist)
            {
                Size lSize;
                using (lGraphics = Graphics.FromImage(mBmp))
                {
                    lGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    lSize = lGraphics.MeasureString(mLabelText, mLabelFont).ToSize();
                }

                lBmp = new Bitmap(lSize.Width + 2, lSize.Height);
            }
            else
            {
                lBmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            }

            lGraphics = Graphics.FromImage(lBmp);
            lGraphics.Clear(mBackgroundColor);

            if (lTextExist)
            {
                using (var lBrush = new SolidBrush(mTextColor))
                {
                    lGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                    lGraphics.DrawString(mLabelText, mLabelFont, lBrush, 0, 0);
                }

                switch (mRotation)
                {
                    case ERotation.Rotate90:    lBmp.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                    case ERotation.Rotate180:   lBmp.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                    case ERotation.Rotate270:   lBmp.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
                    default:                    break;
                }
            }

            lGraphics.Dispose();
            
            pictureBox.Image = lBmp;
            mBmp.Dispose();
            mBmp = lBmp;

            pictureBox.BackColor = mBackgroundColor;
            pictureBox.Refresh();
        }

        public void             fitToContent()
        {
            Size = new Size(mBmp.Width + 1, mBmp.Height + 1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {


                if (mBmp != null)
                {
                    pictureBox.Image = null;
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
