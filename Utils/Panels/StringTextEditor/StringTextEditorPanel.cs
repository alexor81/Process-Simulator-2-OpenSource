// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Utils.Panels.StringTextEditor
{
    public partial class StringTextEditorPanel :  UserControl, IPanel
    {
        private IObjectValueReadWrite   mObjectValue;
        public string                   TextType
        {
            get { return fastColoredTextBox_Text.Language.ToString(); }
            set
            {
                fastColoredTextBox_Text.Language = (FastColoredTextBoxNS.Language)Enum.Parse(typeof(FastColoredTextBoxNS.Language), value);

                var lText = fastColoredTextBox_Text.Text;
                fastColoredTextBox_Text.Text = "";
                fastColoredTextBox_Text.Text = lText;
            }
        }

        public                          StringTextEditorPanel(IObjectValueReadWrite aObjectValue)
        {
            mObjectValue = aObjectValue;
            InitializeComponent();

            BackColor                           = SystemColors.Control;
            mValue                              = StringUtils.ObjectToString(mObjectValue.ValueObject);
            fastColoredTextBox_Text.Text        = mValue;
        }

        public void                     fillForDemo()
        {
            fastColoredTextBox_Text.Text = "Hello World!";
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader = new XMLAttributeReader(aXMLTextReader);
            LabelText   = lReader.getAttribute<String>("ToolTip", "");
            TextType    = lReader.getAttribute<String>("Type", TextType);
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("ToolTip", LabelText);
            aXMLTextWriter.WriteAttributeString("Type", TextType);
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return true; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new SetupForm(this))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                   LabelText
        {
            get { return toolTip.GetToolTip(fastColoredTextBox_Text); }
            set
            {
                toolTip.SetToolTip(fastColoredTextBox_Text, value);
                toolTip.SetToolTip(toolStrip, value);
            }
        }

        private string                  mValue;
        public void                     updateValues()
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
        private void                    updateV()
        {
            string lValue = StringUtils.ObjectToString(mObjectValue.ValueObject);
            if (mValue.Equals(lValue, StringComparison.Ordinal) == false)
            {
                mValue                      = lValue;
                tsButton_Refresh.BackColor  = Color.Yellow;
            }
        }

        public void                     updateProperties()
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
        private void                    updateP()
        {
        }

        private void                    tsButton_Refresh_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.Text    = mValue;
            tsButton_Refresh.BackColor      = SystemColors.Control;
        }

        private void                    tsButton_Write_Click(object aSender, EventArgs aEventArgs)
        {
            mValue                      = fastColoredTextBox_Text.Text;
            mObjectValue.ValueObject    = fastColoredTextBox_Text.Text;
            tsButton_Refresh.BackColor  = SystemColors.Control;
        }

        private void                    tsButton_Cut_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.Cut();
        }

        private void                    tsButton_Copy_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.Copy();
        }

        private void                    tsButton_Paste_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.Paste();
        }

        private void                    tsButton_SelectAll_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.SelectAll();
        }

        private void                    fastColoredTextBox_Text_UndoRedoStateChanged(object aSender, EventArgs aEventArgs)
        {
            tsButton_Undo.Enabled = fastColoredTextBox_Text.UndoEnabled;
            tsButton_Redo.Enabled = fastColoredTextBox_Text.RedoEnabled;
        }

        private void                    tsButton_Undo_Click(object aSender, EventArgs aEventArgs)
        {
            if (fastColoredTextBox_Text.UndoEnabled)
                    fastColoredTextBox_Text.Undo();
        }

        private void                    tsButton_Redo_Click(object aSender, EventArgs aEventArgs)
        {
            if (fastColoredTextBox_Text.RedoEnabled)
                    fastColoredTextBox_Text.Redo();
        }

        private void                    tsButton_Find_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.ShowFindDialog();
        }

        private void                    tsButton_Replace_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.ShowReplaceDialog();
        }

        private void                    tsButton_CollapseAll_Click(object aSender, EventArgs aEventArgs)
        {
            FCTBUtils.fold(fastColoredTextBox_Text);
        }

        private void                    tsButton_ExpandAll_Click(object aSender, EventArgs aEventArgs)
        {
            fastColoredTextBox_Text.ExpandAllFoldingBlocks();
        }

        private void                    tsButton_PrettyXML_Click(object aSender, EventArgs aEventArgs)
        {
            if (fastColoredTextBox_Text.Language != FastColoredTextBoxNS.Language.XML) return;

            try
            {
                fastColoredTextBox_Text.Text = FCTBUtils.xmlPretty(fastColoredTextBox_Text.Text);
            }
            catch(Exception lExc)
            {
                Logger.Log.Error("Error while using pretty XML function. " + lExc.Message, lExc.ToString());
            }
        }
    }
}
