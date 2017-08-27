// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.VectorImage.ElementEllipse
{
    public partial class SetupForm : Form
    {
        private IRedraw         mRedraw;
        private ElementEllipse  mEllipse;

        public                  SetupForm(ElementEllipse aEllipse, IRedraw aRedraw)
        {
            mEllipse    = aEllipse;
            mRedraw     = aRedraw;
            InitializeComponent();

            spinEdit_X.Value            = mEllipse.mX;
            spinEdit_Y.Value            = mEllipse.mY;
            spinEdit_Width.Value        = mEllipse.mWidth;
            spinEdit_Height.Value       = mEllipse.mHeight;
            spinEdit_BorderWidth.Value  = mEllipse.BorderWidth;
            colorEdit_BorderColor.Color = mEllipse.BorderColor;
            colorEdit_FillColor.Color   = mEllipse.FillColor;
        }

        private void            spinEdit_X_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEllipse.mX != spinEdit_X.Value)
            {
                mEllipse.mX = (int)spinEdit_X.Value;
                mRedraw.Redraw();
            }
        }

        private void            spinEdit_Y_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEllipse.mY != spinEdit_Y.Value)
            {
                mEllipse.mY = (int)spinEdit_Y.Value;
                mRedraw.Redraw();
            }
        }

        private void            spinEdit_Width_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEllipse.mWidth != spinEdit_Width.Value)
            {
                mEllipse.mWidth = (int)spinEdit_Width.Value;
                mRedraw.Redraw();
            }
        }

        private void            spinEdit_Height_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEllipse.mHeight != spinEdit_Height.Value)
            {
                mEllipse.mHeight = (int)spinEdit_Height.Value;
                mRedraw.Redraw();
            }
        }

        private void            colorEdit_BorderColor_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEllipse.BorderColor != colorEdit_BorderColor.Color)
            {
                mEllipse.BorderColor = colorEdit_BorderColor.Color;
                mRedraw.Redraw();
            }
        }

        private void            spinEdit_BorderWidth_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEllipse.BorderWidth != spinEdit_BorderWidth.Value)
            {
                mEllipse.BorderWidth = (uint)spinEdit_BorderWidth.Value;
                mRedraw.Redraw();
            }
        }

        private void            colorEdit_FillColor_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mEllipse.FillColor != colorEdit_FillColor.Color)
            {
                mEllipse.FillColor = colorEdit_FillColor.Color;
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
