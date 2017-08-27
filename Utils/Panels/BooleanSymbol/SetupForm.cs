// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Utils.Panels.BooleanSymbol
{
    public partial class SetupForm : Form, IRedraw
    {
        private BooleanSymbolPanel  mSymbolPanel;

        public                      SetupForm(BooleanSymbolPanel aSymbolPanel)
        {
            mSymbolPanel = aSymbolPanel;
            InitializeComponent();

            comboBox_True.Items.AddRange(BooleanSymbolPanel.mSymbolTypeByName.Keys.ToArray());
            comboBox_True.SelectedItem = mSymbolPanel.mTrueSymbol.Name;

            comboBox_False.Items.AddRange(BooleanSymbolPanel.mSymbolTypeByName.Keys.ToArray());
            comboBox_False.SelectedItem = mSymbolPanel.mFalseSymbol.Name;

            textBox_ToolTip.Text = mSymbolPanel.LabelText;
            Redraw();
        }

        public Bitmap               mTrue;
        public Bitmap               mFalse;
        public void                 Redraw()
        {
            if (mTrue != null)
            {
                pictureBox_True.Image = null;
                mTrue.Dispose();
                mTrue = null;
            }

            if (mFalse != null)
            {
                pictureBox_False.Image = null;
                mFalse.Dispose();
                mFalse = null;
            }

            if (mSymbolPanel.mTrueSymbol != null)
            {
                mTrue = mSymbolPanel.mTrueSymbol.draw(pictureBox_True.Width, pictureBox_True.Height);
                pictureBox_True.Image = mTrue;
            }

            if (mSymbolPanel.mFalseSymbol != null)
            {
                mFalse = mSymbolPanel.mFalseSymbol.draw(pictureBox_False.Width, pictureBox_False.Height);
                pictureBox_False.Image = mFalse;
            }
        }

        private void                textBox_ToolTip_TextChanged(object aSender, EventArgs aEventArgs)
        {
            if (mSymbolPanel.LabelText.Equals(textBox_ToolTip.Text, StringComparison.Ordinal) == false)
            {
                mSymbolPanel.LabelText = textBox_ToolTip.Text;
            }
        }

        private void                comboBox_True_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            var lNew = comboBox_True.SelectedItem.ToString();
            if (mSymbolPanel.mTrueSymbol.Name.Equals(lNew, StringComparison.Ordinal) == false)
            {
                var lOld                    = mSymbolPanel.mTrueSymbol;
                mSymbolPanel.mTrueSymbol    = (ISymbol)Activator.CreateInstance(BooleanSymbolPanel.mSymbolTypeByName[lNew]);
                lOld.Dispose();
                Redraw();
            } 
        }

        private void                comboBox_False_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            var lNew = comboBox_False.SelectedItem.ToString();
            if (mSymbolPanel.mFalseSymbol.Name.Equals(lNew, StringComparison.Ordinal) == false)
            {
                var lOld                    = mSymbolPanel.mFalseSymbol;
                mSymbolPanel.mFalseSymbol   = (ISymbol)Activator.CreateInstance(BooleanSymbolPanel.mSymbolTypeByName[lNew]);
                lOld.Dispose();
                Redraw();
            } 
        }

        private void                button_TrueSetup_Click(object aSender, EventArgs aEventArgs)
        {
            if (mSymbolPanel.mTrueSymbol != null)
            {
                mSymbolPanel.mTrueSymbol.setupByForm(this, this);
            }
        }

        private void                button_FalseSetup_Click(object aSender, EventArgs aEventArgs)
        {
            if (mSymbolPanel.mFalseSymbol != null)
            {
                mSymbolPanel.mFalseSymbol.setupByForm(this, this);
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
    
        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mTrue != null)
                {
                    pictureBox_True.Image = null;
                    mTrue.Dispose();
                    mTrue = null;
                }

                if (mFalse != null)
                {
                    pictureBox_False.Image = null;
                    mFalse.Dispose();
                    mFalse = null;
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
