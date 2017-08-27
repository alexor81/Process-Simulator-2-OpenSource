// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using FastColoredTextBoxNS;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils.DialogForms;
using Utils.NameValueList;

namespace Utils.CSharpScript
{
    public partial class SetupForm : Form
    {
        private CSScript            mCSharp;
        private NameValueHolder     mLocalVars;
        private IItemBrowser        mBrowser;
        private AutocompleteMenu    mAutocompleteMenu;

        private CompilerResults     mCompilerResults;
        private string              mAliasCode;
        private string[]            mVarItems;
        private string[]            mConnectedStates;

        public                      SetupForm(CSScript aCSharp, IItemBrowser aBrowser, string aName)
        {
            mCSharp     = aCSharp;
            mBrowser    = aBrowser;
            InitializeComponent();

            if(String.IsNullOrWhiteSpace(aName) == false)
            {
                Text = aName;
            }

            fastColoredTextBox_Code.Text                = mCSharp.Code;
            mLocalVars                                  = mCSharp.mLocalVars.clone();

            Size                                        = mCSharp.mEditorSize;
            mNormalSize                                 = mCSharp.mEditorSize;
            splitContainerControl_Code.SplitterPosition = mCSharp.mEditorSplitterPos;

            mAutocompleteMenu                           = new AutocompleteMenu(fastColoredTextBox_Code);
            mAutocompleteMenu.SelectedColor             = Color.Green;

            List<string> lItems = new List<string>(mBrowser.TotalItemNames);

            lItems.Add("MSFromLastCall");
            lItems.Add("FirstCycle");
            lItems.Add("LogMessage(\"Message\");");
            lItems.Add("ReportError(\"Error\");");
            lItems.Add("SwitchTo(\"StateName\");");

            lItems.AddRange(CSScript.CSTypes);
            lItems.AddRange(CSScript.CSWords);
            lItems.AddRange(mCSharp.mLocalVars.Names);

            string lMaxName     = "";
            for (int i = 0; i < lItems.Count; i++)
            {
                if (lMaxName.Length < lItems[i].Length) lMaxName = lItems[i];
            }
            var lWidth                                  = TextRenderer.MeasureText(lMaxName, mAutocompleteMenu.Font).Width;
            lWidth                                      = lWidth + lWidth / 5;
            mAutocompleteMenu.Items.MaximumSize         = new Size(lWidth, 300);
            mAutocompleteMenu.Items.Width               = lWidth;

            mAutocompleteMenu.Items.SetAutocompleteItems(lItems);

            TriggerTimeMS   = mCSharp.mTriggerTimeMS;
            WatchdogMS      = mCSharp.mWatchdogMS;
            OnItemHandle    = mCSharp.mOnItemHandle;

            fastColoredTextBox_Code.Select();
        }

        #region Errors

            private HashSet<int>    mErrorsLineId = new HashSet<int>();

            private void            clearLinesColoring()
            {
                int lLinesCount = fastColoredTextBox_Code.LinesCount;
                for (int i = 0; i < lLinesCount; i++)
                {
                    if (mErrorsLineId.Contains(fastColoredTextBox_Code[i].UniqueId))
                    {
                        fastColoredTextBox_Code[i].BackgroundBrush = null;
                    }
                }
                mErrorsLineId.Clear();
                fastColoredTextBox_Code.Invalidate();
            }

            private void            colorLine(int aLine)
            {
                int lLine   = aLine - 1;
                int lId     = fastColoredTextBox_Code[lLine].UniqueId;
                if (mErrorsLineId.Contains(lId))
                {
                    return;
                }
                mErrorsLineId.Add(lId);
                fastColoredTextBox_Code[lLine].BackgroundBrush = Brushes.LightPink;
                fastColoredTextBox_Code.Invalidate();
            }

            private void            fastColoredTextBox_Code_LineRemoved(object aSender, FastColoredTextBoxNS.LineRemovedEventArgs aEventArgs)
            {
                foreach (int lId in aEventArgs.RemovedLineUniqueIds)
                {
                    mErrorsLineId.Remove(lId);
                }
            }

        #endregion

        #region Menu

            private void            Check_Click(object aSender, EventArgs aEventArgs)
            {
                try
                {
                    mCompilerResults    = null;
                    mAliasCode          = null;
                    mVarItems           = null;
                    clearLinesColoring();

                    var lResultLog      = new StringBuilder();
                    int lErrorCount     = 0;
                    int lWarningCount   = 0;

                    var lStrings    = CSScript.findAllStings(fastColoredTextBox_Code.Text);
                    var lComments   = CSScript.findAllComments(fastColoredTextBox_Code.Text);
                    var lComStr     = CSScript.uniteCommentsAndStrings(lComments, lStrings);
                    
                    string[] lConnectedStates;
                    var lErrors     = CSScript.check(fastColoredTextBox_Code.Text, lComStr, out lConnectedStates);

                    for (int i = 0; i < lErrors.Length; i++)
                    {
                        colorLine(lErrors[i].Item2);
                        lResultLog.AppendLine("Error: " + CSScript.getErrorMessage(lErrors[i].Item1, lErrors[i].Item2));
                        lErrorCount += 1;
                    }
       
                    var lVarItems       = CSScript.findItems(mBrowser, lStrings, lComments);
                    var lAliasCode      = CSScript.prepareCode(fastColoredTextBox_Code.Text, lStrings, lComments, lComStr, lVarItems);
                    var lCompilerResult = CSScript.compile(lAliasCode, lVarItems, mLocalVars.Names, mLocalVars.Values);

                    if (lCompilerResult.Errors.Count != 0)
                    {
                        foreach (CompilerError lError in lCompilerResult.Errors)
                        {
                            if (lError.IsWarning)
                            {
                                lResultLog.AppendLine("Warning: " + CSScript.getErrorMessage(lError.ErrorText, lError.Line));
                                lWarningCount += 1;
                            }
                            else
                            {
                                colorLine(lError.Line);
                                lResultLog.AppendLine("Error: " + CSScript.getErrorMessage(lError.ErrorText, lError.Line));
                                lErrorCount += 1;
                            }
                        }
                    }

                    if (lErrorCount == 0)
                    {
                        mCompilerResults    = lCompilerResult;
                        mAliasCode          = lAliasCode;
                        mVarItems           = lVarItems;
                        mConnectedStates    = lConnectedStates;
                    }
                    lResultLog.AppendLine("==============================");
                    lResultLog.Append("Errors " + StringUtils.ObjectToString(lErrorCount) + ", Warnings " + StringUtils.ObjectToString(lWarningCount));
                    richTextBox_Result.Text             = lResultLog.ToString();
                    richTextBox_Result.SelectionStart   = richTextBox_Result.Text.Length;
                    richTextBox_Result.ScrollToCaret();
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }

            private void            Items_Click(object aSender, EventArgs aEventArgs)
            {
                int lHandle = mBrowser.getItemHandleByForm(-1, this);
                if (lHandle != -1)
                {
                    fastColoredTextBox_Code.InsertText("'" + mBrowser.getItemNameByHandle(lHandle) + "'");
                }
            }

            private void            LocalVars_Click(object aSender, EventArgs aEventArgs)
            {
                using (var lSetupForm = new NameValueForm(mLocalVars, "Local Variables"))
                {
                    lSetupForm.ShowDialog(this);
                }
            }

            private void            Cut_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.Cut();
            }

            private void            Copy_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.Copy();
            }

            private void            Paste_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.Paste();
            }

            private void            SelectAll_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.SelectAll();
            }

            private void            fastColoredTextBox_Code_UndoRedoStateChanged(object aSender, EventArgs aEventArgs)
            {
                tsButton_Undo.Enabled   = fastColoredTextBox_Code.UndoEnabled;
                tsMenuItem_Undo.Enabled = fastColoredTextBox_Code.UndoEnabled;
                tsButton_Redo.Enabled   = fastColoredTextBox_Code.RedoEnabled;
                tsMenuItem_Redo.Enabled = fastColoredTextBox_Code.RedoEnabled;
            }

            private void            Undo_Click(object aSender, EventArgs aEventArgs)
            {
                if (fastColoredTextBox_Code.UndoEnabled)
                    fastColoredTextBox_Code.Undo();
            }

            private void            Redo_Click(object aSender, EventArgs aEventArgs)
            {
                if (fastColoredTextBox_Code.RedoEnabled)
                    fastColoredTextBox_Code.Redo();
            }

            private void            Find_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.ShowFindDialog();
            }

            private void            Replace_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.ShowReplaceDialog();
            }

            private void            CollapseAll_Click(object aSender, EventArgs aEventArgs)
            {
                FCTBUtils.fold(fastColoredTextBox_Code);
            }

            private void            ExpandAll_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.ExpandAllFoldingBlocks();
            }

            private void            Comment_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.InsertLinePrefix("//");
            }

            private void            Uncomment_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.RemoveLinePrefix("//");
            }

            private void            Indent_Click(object aSender, EventArgs aEventArgs)
            {
                fastColoredTextBox_Code.DoAutoIndent();
            }

            private void            Clone_Click(object aSender, EventArgs aEventArgs)
            {
                //expand selection
                fastColoredTextBox_Code.Selection.Expand();
                //get text of selected lines
                string lText = Environment.NewLine + fastColoredTextBox_Code.Selection.Text;
                //move caret to end of selected lines
                fastColoredTextBox_Code.Selection.Start = fastColoredTextBox_Code.Selection.End;
                //insert text
                fastColoredTextBox_Code.InsertText(lText);
            }

            private void            CloneAndComment_Click(object aSender, EventArgs aEventArgs)
            {
                //start autoUndo block
                fastColoredTextBox_Code.BeginAutoUndo();
                //expand selection
                fastColoredTextBox_Code.Selection.Expand();
                //get text of selected lines
                string lText = Environment.NewLine + fastColoredTextBox_Code.Selection.Text;
                //comment lines
                fastColoredTextBox_Code.InsertLinePrefix("//");
                //move caret to end of selected lines
                fastColoredTextBox_Code.Selection.Start = fastColoredTextBox_Code.Selection.End;
                //insert text
                fastColoredTextBox_Code.InsertText(lText);
                //end of autoUndo block
                fastColoredTextBox_Code.EndAutoUndo();
            }

        #endregion

        #region Options

            private uint            mTriggerTimeMS;
            public uint             TriggerTimeMS
            {
                get { return mTriggerTimeMS; }
                set { mTriggerTimeMS = value; }

            }

            private uint            mWatchdogMS;
            public uint             WatchdogMS
            {
                get { return mWatchdogMS; }
                set { mWatchdogMS = value; }
            }

            private int             mOnItemHandle = -1;
            public int              OnItemHandle
            {
                get { return mOnItemHandle; }
                set { mOnItemHandle = value; }
            } 

            private void            Options_Click(object aSender, EventArgs aEventArgs)
            {
                using (Form lOptionsForm = new OptionsForm(this, mBrowser))
                {
                    lOptionsForm.ShowDialog(this);
                }
            }

        #endregion

        #region Size

            private bool            mMaximized;
            private Size            mNormalSize;
            private Point           mNormalLocation;
            protected override void WndProc(ref Message aMessage)
            {
                if (aMessage.Msg == (int)WM.NCLBUTTONDBLCLK)
                {
                    if (mMaximized)
                    {
                        Size        = mNormalSize;
                        Location    = mNormalLocation;

                        mMaximized  = false;
                    }
                    else
                    {
                        Size lSize      = Size;
                        mNormalLocation = Location;
                        Screen lScreen  = Screen.FromControl(this);
                        Size            = lScreen.WorkingArea.Size;
                        mNormalSize     = lSize;
                        Location        = lScreen.WorkingArea.Location;

                        mMaximized      = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

            private void            SetupForm_SizeChanged(object aSender, EventArgs aEventArgs)
            {
                mNormalSize = Size;
            }

        #endregion

        #region ToolTip

            private void            fastColoredTextBox_Code_ToolTipNeeded(object aSender, ToolTipNeededEventArgs aEventArgs)
            {
                var lRange  = new Range(aSender as FastColoredTextBox, aEventArgs.Place, aEventArgs.Place);
                try
                {
                    int lHandle = mBrowser.getItemHandleByName(lRange.GetFragment("[^\n ']").Text);
                    if (lHandle != -1)
                    {
                        aEventArgs.ToolTipText = mBrowser.getItemToolTipByHandle(lHandle);
                    }
                }
                catch { }
            }

        #endregion

        #region Additional Syntax Highlighting

            protected Style         mTypeStyle = new TextStyle(Brushes.DarkCyan, null, FontStyle.Regular);
            private void            fastColoredTextBox_Code_TextChanged(object aSender, TextChangedEventArgs aEventArgs)
            {           
                aEventArgs.ChangedRange.ClearStyle(mTypeStyle);
                aEventArgs.ChangedRange.SetStyle(mTypeStyle, @"\b(Boolean|Byte|SByte|Int16|Int32|Int64|UInt16|UInt32|UInt64|Single|Double|Decimal|Char|String|DateTime)\b");                  
            }

        #endregion

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            mCSharp.mEditorSize         = mNormalSize;
            mCSharp.mEditorSplitterPos  = splitContainerControl_Code.SplitterPosition;

            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    Check_Click(this, EventArgs.Empty);
                    if (mCompilerResults == null)
                    {
                        MessageForm.showMessage("Compilation error. ", this);
                        return;
                    }

                    mCSharp.mLocalVars = mLocalVars;
                    mCSharp.init(mCompilerResults, mAliasCode, mVarItems, mConnectedStates);

                    mCSharp.mTriggerTimeMS  = TriggerTimeMS;
                    mCSharp.mWatchdogMS     = WatchdogMS;
                    mCSharp.mOnItemHandle   = mOnItemHandle;

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize  = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mAutocompleteMenu != null)
                {
                    mAutocompleteMenu.Dispose();
                    mAutocompleteMenu = null;
                }

                if (mTypeStyle != null)
                {
                    mTypeStyle.Dispose();
                    mTypeStyle = null;
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
