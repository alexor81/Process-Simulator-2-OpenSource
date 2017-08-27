// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Drawing;
using System.Windows.Forms;

namespace Utils
{
    public static class FormUtils
    {
        public const int    AddSize = 5;

        public static Size  calcClientSize(Size aClientSize, Control.ControlCollection aControls)
        {
            Control lControl;
            int lNewHeight  = aClientSize.Height;
            int lNewWidth   = aClientSize.Width;

            int lCount = aControls.Count;
            for (int i = 0; i < lCount; i++)
            {
                lControl = aControls[i];
                if (lControl.Top + lControl.Height > lNewHeight)
                {
                    lNewHeight = lControl.Top + lControl.Height + AddSize;
                }

                if (lControl.Left + lControl.Width > lNewWidth)
                {
                    lNewWidth = lControl.Left + lControl.Width + AddSize;
                }
            }

            return new Size(lNewWidth, lNewHeight);
        }

        public static void  CursorJerk() /// Для обновления tooltip для toolStripButton
        {
            Point lCurrentPos = Cursor.Position;
            Cursor.Position   = new Point(0, 0);
            Cursor.Position   = new Point(100, 100);
            Cursor.Position   = lCurrentPos;
        }
    }
}
