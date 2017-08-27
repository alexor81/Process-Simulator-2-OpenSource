// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Windows.Forms;

namespace Utils.SpecialControls
{
    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var lCreateParams   = base.CreateParams;
                lCreateParams.Style |= 0x04;
                return lCreateParams;
            }
        }
    }
}
