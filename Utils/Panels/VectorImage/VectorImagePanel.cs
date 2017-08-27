// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.VectorImage
{
    public partial class VectorImagePanel : UserControl, IPanel
    {
        public static readonly Dictionary<string, Type> mElementTypeByName = new Dictionary<string, Type>(StringComparer.Ordinal)
        {
            { "Rectangle",  typeof(ElementRectangle.ElementRectangle)},
            { "Ellipse",    typeof(ElementEllipse.ElementEllipse)},
            { "Line",       typeof(ElementLine.ElementLine)},
            { "Text",       typeof(ElementText.ElementText)}
        };

        public static readonly Pen                      mSelectionPen   = new Pen(Color.Red) { DashPattern = new float[] { 2, 2 } };

        public const uint                               mHitDelta       = 2;

        public Size                                     mEditorSize     = new Size(830, 620);
        public int                                      mSplitterPos    = 85;

        public                                          VectorImagePanel()
        {
            InitializeComponent();

            var lRec        = new ElementRectangle.ElementRectangle();
            lRec.mX         = 0;
            lRec.mY         = 0;
            lRec.mWidth     = Width - 1;
            lRec.mHeight    = Height - 1;
            mElements.Add(lRec);

            var lText       = new ElementText.ElementText();
            lText.TextFont  = new Font("Microsoft Sans Serif", 12);
            lText.mX = 103;
            lText.mY = 79;
            lText.mText     = "Image";
            
            mElements.Add(lText);
        }

        public void                                     fillForDemo()
        {
            clear();

            var lText           = new ElementText.ElementText();
            lText.mX            = 37;
            lText.mY            = 9;
            lText.mText         = "Hello, world!";
            lText.TextFont      = new Font("Microsoft Sans Serif", 20);
            lText.TextColor     = Color.Blue;
            mElements.Add(lText);

            var lEllipse        = new ElementEllipse.ElementEllipse();
            lEllipse.mX         = 73;
            lEllipse.mY         = 64;
            lEllipse.mWidth     = 73;
            lEllipse.mHeight    = 64;
            lEllipse.FillColor  = Color.Red;
            mElements.Add(lEllipse);

            var lRec            = new ElementRectangle.ElementRectangle();
            lRec.mX             = 127;
            lRec.mY             = 89;
            lRec.mWidth         = 60;
            lRec.mHeight        = 60;
            lRec.FillColor      = Color.LimeGreen;
            mElements.Add(lRec);

            lRec                = new ElementRectangle.ElementRectangle();
            lRec.mX             = 0;
            lRec.mY             = 0;
            lRec.mWidth         = Width - 1;
            lRec.mHeight        = Height - 1;
            mElements.Add(lRec);
        }

        public void                                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            clear();

            var lReader     = new XMLAttributeReader(aXMLTextReader);
            BackgroundColor = lReader.getAttribute<Color>("BackgroundColor", BackgroundColor);
            IsContainer     = lReader.getAttribute<Boolean>("Conteiner", IsContainer);

            if (aXMLTextReader.IsEmptyElement == false)
            {
                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("Elements", StringComparison.Ordinal))
                {
                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        aXMLTextReader.Read();
                        IVectorElement lElement;
                        while (mElementTypeByName.ContainsKey(aXMLTextReader.Name))
                        {
                            lElement = (IVectorElement)Activator.CreateInstance(mElementTypeByName[aXMLTextReader.Name]);
                            lElement.loadFromXML(aXMLTextReader);
                            mElements.Add(lElement);

                            aXMLTextReader.Read();
                        }
                    }

                    aXMLTextReader.Read();
                }
            }
        }

        public void                                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("BackgroundColor", StringUtils.ObjectToString(BackgroundColor));
            aXMLTextWriter.WriteAttributeString("Conteiner", StringUtils.ObjectToString(IsContainer));
            int lCount = mElements.Count;
            if (lCount > 0)
            {
                aXMLTextWriter.WriteStartElement("Elements");
                for (int i = 0; i < lCount; i++)
                {
                    aXMLTextWriter.WriteStartElement(mElements[i].Name);
                    mElements[i].saveToXML(aXMLTextWriter);
                    aXMLTextWriter.WriteEndElement();
                }
                aXMLTextWriter.WriteEndElement();
            }
        }

        public UserControl                              UserControl { get { return this; } }

        public bool                                     IsScalable { get { return true; } }

        public bool                                     IsTransparent { get { return true; } }

        public bool                                     IsConfigurable { get { return true; } }

        private bool                                    mIsContainer = false;
        public bool                                     IsContainer
        {
            get { return mIsContainer; }
            set { mIsContainer = value; }
        }

        public void                                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                                   LabelText
        {
            get { return ""; }
            set {  }
        }

        public Color                                    BackgroundColor
        {
            get { return pictureBox.BackColor; }
            set { pictureBox.BackColor = value; }
        }

        public void                                     updateValues()
        {
        }

        public void                                     updateProperties()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { draw(); }));
            }
            else
            {
                draw();
            }
        }

        private void                                    VectorImagePanel_Load(object aSender, EventArgs aEventArgs)
        {
            draw();
        }

        private void                                    VectorImagePanel_Resize(object aSender, EventArgs aEventArgs)
        {
            draw();
        }

        private List<IVectorElement>                    mElements = new List<IVectorElement>();
        public List<IVectorElement>                     Elements
        {
            get { return mElements; }
            set
            {
                clear();
                mElements = value;
            }
        }

        private Bitmap                                  mBitmap;

        private Graphics                                mGraphics;

        private void                                    draw()
        {
            var lBitmap                 = new Bitmap(Width, Height);
            var lGraphics               = Graphics.FromImage(lBitmap);
            lGraphics.SmoothingMode     = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            lGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            
            int lCount = mElements.Count;
            for (int i = 0; i < lCount; i++)
            {
                mElements[i].draw(lGraphics);
            }

            pictureBox.Image = lBitmap;

            if (mBitmap != null)
            {
                mBitmap.Dispose();
            }

            if (mGraphics != null)
            {
                mGraphics.Dispose();
            }

            mBitmap     = lBitmap;
            mGraphics   = lGraphics;
        }

        private void                                    clear()
        {
            int lCount = mElements.Count;
            if (lCount > 0)
            {
                for (int i = 0; i < lCount; i++)
                {
                    mElements[i].Dispose();
                }
                mElements.Clear();
            }
        }

        protected override void                         Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mGraphics != null)
                {
                    mGraphics.Dispose();
                    mGraphics = null;
                }

                if (mBitmap != null)
                {
                    pictureBox.Image = null;
                    mBitmap.Dispose();
                    mBitmap = null;
                }

                if (mElements != null)
                {
                    clear();
                    mElements = null;
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
