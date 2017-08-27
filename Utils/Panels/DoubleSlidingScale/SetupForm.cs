// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;

namespace Utils.Panels.DoubleSlidingScale
{
    public partial class SetupForm : Form
    {
        private DoubleSlidingScalePanel mDoubleSlidingScale;

        public                          SetupForm(DoubleSlidingScalePanel aDoubleSlidingScale)
        {
            mDoubleSlidingScale = aDoubleSlidingScale;
            InitializeComponent();

            updateForm();
        }

        private void                    updateForm()
        {
            textBox_ToolTip.Text        = mDoubleSlidingScale.LabelText;
            colorEdit_Body.Color        = mDoubleSlidingScale.BodyColor;
            colorEdit_Needle.Color      = mDoubleSlidingScale.NeedleColor;
            colorEdit_Scale.Color       = mDoubleSlidingScale.ScaleColor;
            checkBox_Shadow.Checked     = mDoubleSlidingScale.Shadow;
            colorEdit_Shadow.Color      = mDoubleSlidingScale.ShadowColor;
            spinEdit_LT_Count.Value     = mDoubleSlidingScale.LargeTickCount;
            spinEdit_LT_Length.Value    = mDoubleSlidingScale.LargeTickLength;
            spinEdit_ST_Count.Value     = mDoubleSlidingScale.SmallTickCount;
            spinEdit_ST_Length.Value    = mDoubleSlidingScale.SmallTickLength;
        }

        private void                    textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (textBox_ToolTip.Text.Equals(mDoubleSlidingScale.LabelText, StringComparison.Ordinal) == false)
            {
                mDoubleSlidingScale.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                    colorEdit_Needle_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Needle.Color != mDoubleSlidingScale.NeedleColor)
            {
                mDoubleSlidingScale.NeedleColor = colorEdit_Needle.Color;
            }
        }

        private void                    colorEdit_Scale_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Scale.Color != mDoubleSlidingScale.ScaleColor)
            {
                mDoubleSlidingScale.ScaleColor = colorEdit_Scale.Color;
            }
        }

        private void                    colorEdit_Body_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Body.Color != mDoubleSlidingScale.BodyColor)
            {
                mDoubleSlidingScale.BodyColor = colorEdit_Body.Color;
            }
        }

        private void                    colorEdit_Shadow_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (colorEdit_Shadow.Color != mDoubleSlidingScale.ShadowColor)
            {
                mDoubleSlidingScale.ShadowColor = colorEdit_Shadow.Color;
            }
        }

        private void                    checkBox_Shadow_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if(checkBox_Shadow.Checked != mDoubleSlidingScale.Shadow)
            {
                mDoubleSlidingScale.Shadow = checkBox_Shadow.Checked;
            }
        }

        private void                    spinEdit_LT_Count_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_LT_Count.Value != mDoubleSlidingScale.LargeTickCount)
            {
                mDoubleSlidingScale.LargeTickCount = (int)spinEdit_LT_Count.Value;
                updateForm();
            }
        }

        private void                    spinEdit_LT_Length_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_LT_Length.Value != mDoubleSlidingScale.LargeTickLength)
            {
                mDoubleSlidingScale.LargeTickLength = (int)spinEdit_LT_Length.Value;
                updateForm();
            }
        }

        private void                    spinEdit_ST_Count_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_ST_Count.Value != mDoubleSlidingScale.SmallTickCount)
            {
                mDoubleSlidingScale.SmallTickCount = (int)spinEdit_ST_Count.Value;
                updateForm();
            }
        }

        private void                    spinEdit_ST_Length_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            if (spinEdit_ST_Length.Value != mDoubleSlidingScale.SmallTickLength)
            {
                mDoubleSlidingScale.SmallTickLength = (int)spinEdit_ST_Length.Value;
                updateForm();
            }
        }

        private void                    SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void                    SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
