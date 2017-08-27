// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.VectorImage.ElementRectangle
{
    public partial class SetupForm : Form
    {
        private IRedraw             mRedraw;
        private ElementRectangle    mRectangle;

        public                      SetupForm(ElementRectangle aRectangle, IRedraw aRedraw)
        {
            mRectangle  = aRectangle;
            mRedraw     = aRedraw;
            InitializeComponent();

            spinEdit_X.Value            = mRectangle.mX;
            spinEdit_Y.Value            = mRectangle.mY;
            spinEdit_Width.Value        = mRectangle.mWidth;
            spinEdit_Height.Value       = mRectangle.mHeight;
            spinEdit_BorderWidth.Value  = mRectangle.BorderWidth;
            colorEdit_BorderColor.Color = mRectangle.BorderColor;
            colorEdit_FillColor.Color   = mRectangle.FillColor;
        }

        private void                spinEdit_X_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.mX != spinEdit_X.Value)
            {
                mRectangle.mX = (int)spinEdit_X.Value;
                mRedraw.Redraw();
            }
        }

        private void                spinEdit_Y_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.mY != spinEdit_Y.Value)
            {
                mRectangle.mY = (int)spinEdit_Y.Value;
                mRedraw.Redraw();
            }
        }

        private void                spinEdit_Width_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.mWidth != spinEdit_Width.Value)
            {
                mRectangle.mWidth = (int)spinEdit_Width.Value;
                mRedraw.Redraw();
            }
        }

        private void                spinEdit_Height_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.mHeight != spinEdit_Height.Value)
            {
                mRectangle.mHeight = (int)spinEdit_Height.Value;
                mRedraw.Redraw();
            }
        }

        private void                colorEdit_BorderColor_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.BorderColor != colorEdit_BorderColor.Color)
            {
                mRectangle.BorderColor = colorEdit_BorderColor.Color;
                mRedraw.Redraw();
            }
        }

        private void                spinEdit_BorderWidth_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.BorderWidth != spinEdit_BorderWidth.Value)
            {
                mRectangle.BorderWidth = (uint)spinEdit_BorderWidth.Value;
                mRedraw.Redraw();
            }
        }

        private void                colorEdit_FillColor_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mRectangle.FillColor != colorEdit_FillColor.Color)
            {
                mRectangle.FillColor = colorEdit_FillColor.Color;
                mRedraw.Redraw();
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
    }
}
