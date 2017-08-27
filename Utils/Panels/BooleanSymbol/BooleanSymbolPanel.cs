// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.BooleanSymbol
{
	public partial class BooleanSymbolPanel : UserControl, IPanel, IPanelExt
	{
		public static readonly Dictionary<string, Type> mSymbolTypeByName = new Dictionary<string, Type>(StringComparer.Ordinal)
		{
			{ "None",       typeof(SymbolNone)},
            { "Ellipse",    typeof(SymbolEllipse.SymbolEllipse)},
            { "Image",      typeof(SymbolImage.SymbolImage)},
            { "Line",       typeof(SymbolLine.SymbolLine)},
			{ "Rectangle",  typeof(SymbolRectangle.SymbolRectangle)}
		};

		private IBooleanValueRead   mBooleanValue;

		public ISymbol              mTrueSymbol     = new SymbolRectangle.SymbolRectangle() { FillColor = Color.LimeGreen };
		public ISymbol              mFalseSymbol    = new SymbolRectangle.SymbolRectangle() { FillColor = Color.LightGray };

		private Bitmap              mTrueBitmap;
		private Bitmap              mFalseBitmap;

		public                      BooleanSymbolPanel(IBooleanValueRead aBooleanValue)
		{
			mBooleanValue = aBooleanValue;
			InitializeComponent();
		}

		public void                 fillForDemo()
		{
		}

		public void                 loadFromXML(XmlTextReader aXMLTextReader)
		{
			var lReader     = new XMLAttributeReader(aXMLTextReader);
			LabelText = lReader.getAttribute<String>("ToolTip", "");

            string lSymbolName;
            aXMLTextReader.Read();
            if (aXMLTextReader.Name.Equals("True", StringComparison.Ordinal))
            {
                lSymbolName = lReader.getAttribute<String>("Name");
                mTrueSymbol = (ISymbol)Activator.CreateInstance(BooleanSymbolPanel.mSymbolTypeByName[lSymbolName]);
                aXMLTextReader.Read();
                mTrueSymbol.loadFromXML(aXMLTextReader);
                aXMLTextReader.Read();
            }

            aXMLTextReader.Read();
            while (aXMLTextReader.IsStartElement() == false && aXMLTextReader.EOF == false)
            {
                aXMLTextReader.Read();
            }

            if (aXMLTextReader.Name.Equals("False", StringComparison.Ordinal))
            {
                lSymbolName = lReader.getAttribute<String>("Name");
                mFalseSymbol = (ISymbol)Activator.CreateInstance(BooleanSymbolPanel.mSymbolTypeByName[lSymbolName]);
                aXMLTextReader.Read();
                mFalseSymbol.loadFromXML(aXMLTextReader);
                aXMLTextReader.Read();
            }

            aXMLTextReader.Read();
		}

		public void                 saveToXML(XmlTextWriter aXMLTextWriter)
		{
			aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);

			aXMLTextWriter.WriteStartElement("True");
				aXMLTextWriter.WriteAttributeString("Name", mTrueSymbol.Name);
                aXMLTextWriter.WriteStartElement("Properties");
                    mTrueSymbol.saveToXML(aXMLTextWriter);
                aXMLTextWriter.WriteEndElement();
			aXMLTextWriter.WriteEndElement();

			aXMLTextWriter.WriteStartElement("False");
				aXMLTextWriter.WriteAttributeString("Name", mFalseSymbol.Name);
                aXMLTextWriter.WriteStartElement("Properties");
                    mFalseSymbol.saveToXML(aXMLTextWriter);
                aXMLTextWriter.WriteEndElement();
			aXMLTextWriter.WriteEndElement();
		}

		public UserControl          UserControl { get { return this; } }

		public bool                 IsScalable { get { return true; } }

		public bool                 IsTransparent { get { return true; } }

		public bool                 IsConfigurable { get { return true; } }

		public bool                 IsContainer { get { return false; } }

		public bool                 IsSetupOnDblClick { get { return true; } }

		public void                 setupByForm(IWin32Window aOwner)
		{
			using (var lSetupForm = new SetupForm(this))
			{
				lSetupForm.ShowDialog(aOwner);
			}
		}

		public string               LabelText
		{
			get { return toolTip.GetToolTip(pictureBox_State); }
			set
			{
				toolTip.SetToolTip(pictureBox_State, value);
			}
		}

		public void                 updateValues()
		{
			if (InvokeRequired)
			{
				BeginInvoke((Action)(() => { updateV(); }));
			}
			else
			{
				updateV();
			}
		}
		private void                updateV()
		{
			if (mBooleanValue.ValueBoolean)
			{
				pictureBox_State.Image = mTrueBitmap;
			}
			else
			{
				pictureBox_State.Image = mFalseBitmap;
			}
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
			pictureBox_State.Image = null;

			if (mTrueBitmap != null)
			{                 
				mTrueBitmap.Dispose();
				mTrueBitmap = null;
			}
			if (mTrueSymbol != null)
			{
				mTrueBitmap = mTrueSymbol.draw(pictureBox_State.Width, pictureBox_State.Height);
			}

			if (mFalseBitmap != null)
			{                 
				mFalseBitmap.Dispose();
				mFalseBitmap = null;
			}
			if (mFalseSymbol != null)
			{
				mFalseBitmap = mFalseSymbol.draw(pictureBox_State.Width, pictureBox_State.Height);
			}

			updateV();
		}

		private void                BooleanSymbolPanel_SizeChanged(object aSender, EventArgs aEventArgs)
		{
			updateP();
		}

		protected override void     Dispose(bool disposing)
		{
			if (disposing)
			{
				mBooleanValue = null;
				toolTip.RemoveAll();

				pictureBox_State.Image = null;

				if (mTrueBitmap != null)
				{                 
					mTrueBitmap.Dispose();
					mTrueBitmap = null;
				}

				if (mFalseBitmap != null)
				{                 
					mFalseBitmap.Dispose();
					mFalseBitmap = null;
				}

				if (mTrueSymbol != null)
				{
					mTrueSymbol.Dispose();
					mTrueSymbol = null;
				}

				if (mFalseSymbol != null)
				{
					mFalseSymbol.Dispose();
					mFalseSymbol = null;
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
