// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.VectorImage.ElementLine
{
    public partial class SetupForm : Form
    {
        private IRedraw     mRedraw;
        private ElementLine mLine;

        public              SetupForm(ElementLine aLine, IRedraw aRedraw)
        {
            mLine   = aLine;
            mRedraw = aRedraw;
            InitializeComponent();

            spinEdit_X1.Value       = mLine.mX1;
            spinEdit_Y1.Value       = mLine.mY1;
            spinEdit_X2.Value       = mLine.mX2;
            spinEdit_Y2.Value       = mLine.mY2;
            spinEdit_Width.Value    = mLine.LineWidth;
            colorEdit_Color.Color   = mLine.LineColor;
        }

        private void        spinEdit_X1_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLine.mX1 != spinEdit_X1.Value)
            {
                mLine.mX1 = (int)spinEdit_X1.Value;
                mRedraw.Redraw();
            }
        }

        private void        spinEdit_Y1_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLine.mY1 != spinEdit_Y1.Value)
            {
                mLine.mY1 = (int)spinEdit_Y1.Value;
                mRedraw.Redraw();
            }
        }

        private void        spinEdit_X2_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLine.mX2 != spinEdit_X2.Value)
            {
                mLine.mX2 = (int)spinEdit_X2.Value;
                mRedraw.Redraw();
            }
        }

        private void        spinEdit_Y2_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLine.mY2 != spinEdit_Y2.Value)
            {
                mLine.mY2 = (int)spinEdit_Y2.Value;
                mRedraw.Redraw();
            }
        }

        private void        spinEdit_Width_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLine.LineWidth != spinEdit_Width.Value)
            {
                mLine.LineWidth = (uint)spinEdit_Width.Value;
                mRedraw.Redraw();
            }
        }

        private void        colorEdit_Color_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Color.Color != mLine.LineColor)
            {
                mLine.LineColor = colorEdit_Color.Color;
                mRedraw.Redraw();
            }
        }

        private void        SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
