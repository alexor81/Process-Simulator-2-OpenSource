// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.BooleanSymbol.SymbolLine
{
    public partial class SetupForm : Form
    {
        private IRedraw         mRedraw;
        private SymbolLine      mLine;

        public                  SetupForm(SymbolLine aLine, IRedraw aRedraw)
        {
            mLine   = aLine;
            mRedraw = aRedraw;
            InitializeComponent();

            spinEdit_Width.Value  = mLine.LineWidth;
            colorEdit_Color.Color = mLine.LineColor;
            spinEdit_Angle.Value  = mLine.Angle;
        }

        private void            colorEdit_Color_EditValueChanged(object aSender, EventArgs aEventArgse)
        {
            if (mLine.LineColor != colorEdit_Color.Color)
            {
                mLine.LineColor = colorEdit_Color.Color;
                mRedraw.Redraw();
            }
        }

        private void            spinEdit_Width_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLine.LineWidth != spinEdit_Width.Value)
            {
                mLine.LineWidth = (uint)spinEdit_Width.Value;
                mRedraw.Redraw();
            }
        }

        private void            spinEdit_Angle_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (mLine.Angle != spinEdit_Angle.Value)
            {
                mLine.Angle = (int)spinEdit_Angle.Value;
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
