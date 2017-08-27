// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.BooleanSymbol.SymbolRectangle
{
    public partial class SetupForm : Form
    {
        private IRedraw         mRedraw;
        private SymbolRectangle mRectangle;
        
        public                  SetupForm(SymbolRectangle aRectangle, IRedraw aRedraw)
        {
            mRectangle  = aRectangle;
            mRedraw     = aRedraw;
            InitializeComponent();

            spinEdit_BorderWidth.Value  = mRectangle.BorderWidth;
            colorEdit_BorderColor.Color = mRectangle.BorderColor;
            colorEdit_FillColor.Color   = mRectangle.FillColor;
        }

        private void            colorEdit_BorderColor_EditValueChanged(object aSender, EventArgs aEventArgse)
        {
            if (mRectangle.BorderColor != colorEdit_BorderColor.Color)
            {
                mRectangle.BorderColor = colorEdit_BorderColor.Color;
                mRedraw.Redraw();
            }
        }

        private void            spinEdit_BorderWidth_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.BorderWidth != spinEdit_BorderWidth.Value)
            {
                mRectangle.BorderWidth = (uint)spinEdit_BorderWidth.Value;
                mRedraw.Redraw();
            }
        }

        private void            colorEdit_FillColor_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.FillColor != colorEdit_FillColor.Color)
            {
                mRectangle.FillColor = colorEdit_FillColor.Color;
                mRedraw.Redraw();
            }
        }

        private void            SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void            SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
