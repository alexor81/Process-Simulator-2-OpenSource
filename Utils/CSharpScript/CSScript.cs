// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Utils.Logger;
using Utils.NameValueList;

namespace Utils.CSharpScript
{
    public class CSScript : IDisposable
    {
        private IItemBrowser                mItemBrowser;

        public                              CSScript(IItemBrowser aItemBrowser)
        {
            mItemBrowser = aItemBrowser;

            var lReservedWords = new List<string>();
            lReservedWords.AddRange(CSTypes);
            lReservedWords.AddRange(CSWords);
            lReservedWords.AddRange(ReservedWords);
            lReservedWords.Add("FirstCycle");
            lReservedWords.Add("MSFromLastCall");

            mLocalVars = new NameValueHolder(true, true, lReservedWords.ToArray(), new Action<string>( (a) => { validateName(a); } ));

            var lAliasCode          = "";
            var lVarItems           = new string[] {};
            var lCompilerResults    = compile(lAliasCode, lVarItems, new string[] {}, new object[] {});
            var lConnectedStates    = new string[] {};

            if (lCompilerResults.Errors.Count > 0)
            {
                throw new ArgumentException("Error compailing empty script. ");
            }

            init(lCompilerResults, lAliasCode, lVarItems, lConnectedStates);
        }

        public void                         loadFromXML(XmlTextReader aXMLTextReader)
        {
            var lReader     = new XMLAttributeReader(aXMLTextReader);

            mWatchdogMS     = lReader.getAttribute<UInt32>("Watchdog", mWatchdogMS);
            mTriggerTimeMS  = lReader.getAttribute<UInt32>("TriggerTime", mTriggerTimeMS);
            mOnItemHandle   = mItemBrowser.getItemHandleByName(lReader.getAttribute<String>("On", ""));

            string lCode    = "";
            if (aXMLTextReader.IsEmptyElement == false)
            {
                aXMLTextReader.Read();

                if (aXMLTextReader.Name.Equals("LocalVariables", StringComparison.Ordinal))
                {
                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        mLocalVars.loadFromXML(aXMLTextReader, "LocalVariable");                   
                    }
                    aXMLTextReader.Read();
                }

                while (aXMLTextReader.IsStartElement() == false && aXMLTextReader.EOF == false)
                {
                    aXMLTextReader.Read();
                }

                if (aXMLTextReader.Name.Equals("Script", StringComparison.Ordinal))
                {
                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        aXMLTextReader.Read();
                        lCode = aXMLTextReader.ReadString();
                    }
                }
            }

            var lStrings    = findAllStings(lCode);
            var lComments   = findAllComments(lCode);
            var lComStr     = uniteCommentsAndStrings(lComments, lStrings);

            string[] lConnectedStates;
            var lErrors     = check(lCode, lComStr, out lConnectedStates);
            if (lErrors.Length != 0)
            {
                throw new ArgumentException(getErrorMessage(lErrors[0].Item1, lErrors[0].Item2));
            }
  
            var lVarItems           = findItems(mItemBrowser, lStrings, lComments);
            var lAliasCode          = prepareCode(lCode, lStrings, lComments, lComStr, lVarItems);
            var lCompilerResults    = compile(lAliasCode, lVarItems, mLocalVars.Names, mLocalVars.Values);

            if (lCompilerResults.Errors.Count != 0)
            {
                foreach (CompilerError lError in lCompilerResults.Errors)
                {
                    if (lError.IsWarning == true)
                    {
                        Log.Info(getErrorMessage(lError.ErrorText, lError.Line));
                    }
                    else
                    {
                        throw new ArgumentException(getErrorMessage(lError.ErrorText, lError.Line));
                    }
                }
            }

            init(lCompilerResults, lAliasCode, lVarItems, lConnectedStates);
        }

        public void                         saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteAttributeString("On", mItemBrowser.getItemNameByHandle(mOnItemHandle));
            aXMLTextWriter.WriteAttributeString("Watchdog", StringUtils.ObjectToString(mWatchdogMS));
            aXMLTextWriter.WriteAttributeString("TriggerTime", StringUtils.ObjectToString(mTriggerTimeMS));
            
            aXMLTextWriter.WriteStartElement("LocalVariables");
                mLocalVars.saveToXML(aXMLTextWriter, "LocalVariable");
            aXMLTextWriter.WriteEndElement();

            aXMLTextWriter.WriteStartElement("Script");
                aXMLTextWriter.WriteCData(Code);
            aXMLTextWriter.WriteEndElement();
        }

        #region Setup form

            public Size                     mEditorSize         =  new Size(800, 600);

            public int                      mEditorSplitterPos  = 53;

            public DialogResult             setupByForm(string aName, IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser, aName))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

        #endregion

        #region Items

            private Dictionary<int, int>    mVarItemIndex       = new Dictionary<int, int>();
            private int[]                   mVarItemHandles     = new int[0];
            private object[]                mVarItemValues      = new object[0];
            private bool[]                  mVarItemChanged     = new bool[0];

            public int                      mOnItemHandle       = -1;
            private volatile bool           mOn                 = true;
            private volatile bool           mOnChanged;
            public bool                     On
            {
                get
                {
                    return mOn;
                }
                set
                {
                    if (mOn != value)
                    {
                        mOn             = value;
                        mValueChanged   = true;
                        mOnChanged      = true;
                        raiseOnChanged();
                    }
                }
            }
            public event EventHandler       OnChanged;
            public void                     raiseOnChanged()
            {
                OnChanged?.Invoke(this, EventArgs.Empty);
            }

            public int[]                    ItemHandles
            {
                get 
                {
                    if (mOnItemHandle != -1)
                    {
                        var lHandles = new HashSet<int>();
                        lHandles.Add(mOnItemHandle);
                        for (int i = 0; i < mVarItemHandles.Length; i++)
                        {
                            lHandles.Add(mVarItemHandles[i]);
                        }

                        return lHandles.ToArray();
                    }
                    else
                    { 
                        return mVarItemHandles;
                    }
                }
            }

            public void                     getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                var lHandles    = new List<int>();
                var lValues     = new List<object>();

                if (mValueChanged)
                {
                    mValueChanged = false;
     
                    for (int i = 0; i < mVarItemHandles.Length; i++)
                    {
                        if (mVarItemChanged[i] == true)
                        {
                            mVarItemChanged[i] = false;
                            lHandles.Add(mVarItemHandles[i]);
                            lValues.Add(mVarItemValues[i]);
                        }
                    }

                    if (mOnItemHandle != -1 && lHandles.Contains(mOnItemHandle) == false && mOnChanged)
                    {
                        mOnChanged = false;
                        lHandles.Add(mOnItemHandle);
                        lValues.Add(mOn);
                    }
                }
                else
                {
                    for (int i = 0; i < mVarItemHandles.Length; i++)
                    {
                        mVarItemChanged[i] = false;
                        lHandles.Add(mVarItemHandles[i]);
                        lValues.Add(mVarItemValues[i]);
                    }

                    if (mOnItemHandle != -1 && lHandles.Contains(mOnItemHandle) == false)
                    {
                        mOnChanged = false;
                        lHandles.Add(mOnItemHandle);
                        lValues.Add(mOn);
                    }
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                     setItemValue(int aItemHandle, object aItemValue)
            {
                if (mVarItemIndex.ContainsKey(aItemHandle))
                {
                    int lIndex = mVarItemIndex[aItemHandle];
                    if (mVarItemChanged[lIndex] == false)
                    {
                        mVarItemValues[lIndex] = aItemValue;
                    }
                }

                if (mOnItemHandle == aItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for object to switch on. ", lExc);
                    }

                    mOn = lValue;
                    raiseOnChanged();
                }
            }

        #endregion

        #region Strings, Comments

            private static Regex            mStrRegex = new Regex(
                                            @"
                                                    # Character definitions:
                                                    '
                                                    (?> # disable backtracking
                                                      (?:
                                                        \\[^\r\n]|    # escaped meta char
                                                        [^'\r\n]      # any character except '
                                                      )*
                                                    )
                                                    '?
                                                    |
                                                    # Normal string & verbatim strings definitions:
                                                    (?<verbatimIdentifier>@)?         # this group matches if it is an verbatim string
                                                    ""
                                                    (?> # disable backtracking
                                                      (?:
                                                        # match and consume an escaped character including escaped double quote ("") char
                                                        (?(verbatimIdentifier)        # if it is a verbatim string ...
                                                          """"|                         #   then: only match an escaped double quote ("") char
                                                          \\.                         #   else: match an escaped sequence
                                                        )
                                                        | # OR
            
                                                        # match any char except double quote char ("")
                                                        [^""]
                                                      )*
                                                    )
                                                    ""
                                                ",
                                            RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled );
            
            public static Tuple<int[], string[]>    findAllStings(string aSource)
            {
                var lMatches        = mStrRegex.Matches(aSource);
                int lCount          = lMatches.Count;
                int[] lIndex        = new int[lCount];
                string[] lString    = new string[lCount];

                for(int i = 0; i < lCount; i++)
                {
                    lIndex[i]   = lMatches[i].Index;
                    lString[i]  = lMatches[i].Value;
                }

                return new Tuple<int[], string[]>(lIndex, lString);
            }

            private static Regex                    CommentRegex1 = new Regex(@"//.*$", RegexOptions.Multiline | RegexOptions.Compiled);
            private static Regex                    CommentRegex2 = new Regex(@"(/\*.*?\*/)|(/\*.*)", RegexOptions.Singleline | RegexOptions.Compiled);
            private static Regex                    CommentRegex3 = new Regex(@"(/\*.*?\*/)|(.*\*/)", RegexOptions.Singleline | RegexOptions.RightToLeft | RegexOptions.Compiled);

            public static Tuple<int[], string[]>    findAllComments(string aSource)
            {
                var lIndex      = new List<int>();
                var lComment    = new List<string>();

                var lMatches    = CommentRegex1.Matches(aSource);
                var lCount      = lMatches.Count;

                for(int i = 0; i < lCount; i++)
                {
                    lIndex.Add(lMatches[i].Index);
                    lComment.Add(lMatches[i].Value);
                }

                lMatches    = CommentRegex2.Matches(aSource);
                lCount      = lMatches.Count;

                for(int i = 0; i < lCount; i++)
                {
                    lIndex.Add(lMatches[i].Index);
                    lComment.Add(lMatches[i].Value);
                }

                lMatches    = CommentRegex3.Matches(aSource);
                lCount      = lMatches.Count;

                for(int i = 0; i < lCount; i++)
                {
                    lIndex.Add(lMatches[i].Index);
                    lComment.Add(lMatches[i].Value);
                }

                return new Tuple<int[], string[]>(lIndex.ToArray(), lComment.ToArray());
            }

            private static bool                     isInside(int aIndex, Tuple<int[], string[]> aRange)
            {
                if (aRange.Item1.Length > 0)
                {
                    int lIndex = Array.BinarySearch(aRange.Item1, aIndex);
                    if (lIndex < 0) lIndex = ~lIndex - 1;
                    if (lIndex >= 0 && aIndex < aRange.Item1[lIndex] + aRange.Item2[lIndex].Length)
                    {
                        return true;
                    }
                }

                return false;
            }

            private static bool                     isInside(int aIndex, Tuple<int[], int[]> aRange)
            {
                if (aRange.Item1.Length > 0)
                {
                    int lIndex = Array.BinarySearch(aRange.Item1, aIndex);
                    if (lIndex < 0) lIndex = ~lIndex - 1;
                    if (lIndex >= 0 && aIndex < aRange.Item1[lIndex] + aRange.Item2[lIndex])
                    {
                        return true;
                    }
                }

                return false;
            }

            public static Tuple<int[], int[]>       uniteCommentsAndStrings(Tuple<int[], string[]> aComments, Tuple<int[], string[]> aStrings)
            {
                var lResult = new SortedDictionary<int, int>();

                for (int i = 0; i < aComments.Item1.Length; i++)
                {
                    lResult.Add(aComments.Item1[i], aComments.Item2[i].Length);
                }

                for (int i = 0; i < aStrings.Item1.Length; i++)
                {
                    if (aStrings.Item2[i][0] == '\'') continue;

                    if (isInside(aStrings.Item1[i], aComments) == false)
                    {
                        lResult.Add(aStrings.Item1[i], aStrings.Item2[i].Length);
                    }
                }

                return new Tuple<int[], int[]>(lResult.Keys.ToArray(), lResult.Values.ToArray());
            }

        #endregion

        #region Local variables

            public NameValueHolder          mLocalVars; 

            public void                     setLocalVariables()
            {
                if (mLocalVars.Count > 0)
                {
                    var lLVNames = mLocalVars.Names;
                    for (int i = 0; i < lLVNames.Length; i++)
                    {
                        mScriptClassType.GetField(lLVNames[i]).SetValue(mScriptClassInst, mLocalVars.getValue(lLVNames[i]));
                    }
                }
            }

            public void                     getLocalVariables()
            {
                if (mLocalVars.Count > 0)
                {
                    var lLVNames = mLocalVars.Names;
                    for (int i = 0; i < lLVNames.Length; i++)
                    {
                        mLocalVars.setValue(lLVNames[i], mScriptClassType.GetField(lLVNames[i]).GetValue(mScriptClassInst));
                    }
                }
            }

            public static void              validateName(string aName)
            {
                if (aName.All((c) => {return char.IsLetterOrDigit(c) || c.Equals('_');}) == false)
                {
                    throw new ArgumentException("Local variable name '" + aName + "' not allowed.");
                }

                if (char.IsLetter(aName[0]) == false && aName[0] != '_')
                {
                    throw new ArgumentException("Local variable name '" + aName + "' not allowed.");
                }

                if (aName.StartsWith("var"))
                {
                   var lEnd = aName.Substring(3);
                   if (lEnd.Length > 0)
                   {
                       if (lEnd.All(char.IsDigit))
                       {
                            throw new ArgumentException("Local variable name '" + aName + "' not allowed.");
                       }
                   }
                }
            }

        #endregion

        #region Script

            public static string[]         CSTypes              = new string[] { "bool", "byte", "char", "decimal", "double", 
                                                                                "float", "int", "long", "object", "sbyte",
                                                                                "short", "string", "uint", "ulong", "ushort",
                                                                                "Boolean", "Byte", "SByte", "Int16", "Int32",
                                                                                "Int64", "UInt16", "UInt32", "UInt64", "Single",
                                                                                "Double", "Decimal", "Char", "String", "DateTime" };

            public static string[]         CSWords              = new string[] { "as", "break", "case", "catch", "continue", "do",
                                                                                "else", "false", "finally", "for", "foreach", 
                                                                                "goto", "if", "is", "new", "null", "return", 
                                                                                "switch", "throw", "true", "try", "typeof", "using",
                                                                                "while"};

            public static string[]         ReservedWords        = new string[] { "ScriptClass",
                                                                                 "ScriptMethod",
                                                                                 "mVarValues",
                                                                                 "mVarValuesChanged",
                                                                                 "ScriptEvent",
                                                                                 "raiseScriptEvent",
                                                                                 "mEventArgs" };

            private string                  mAliasCode          = "";
            private object                  mScriptClassInst;
            private Type                    mScriptClassType;
            private Delegate                mOnEventDelegate;

            public string                   Code
            {
                get
                {
                    var lStrings    = findAllStings(mAliasCode);
                    var lComments   = findAllComments(mAliasCode);
                    var lComStr     = uniteCommentsAndStrings(lComments, lStrings);
                    var lCode       = new StringBuilder();

                    if (lComStr.Item1.Length == 0)
                    {  
                        lCode.Append(mAliasCode);
                        for (int i = mVarItemHandles.Length - 1; i >= 0; i--)
                        {
                            lCode.Replace("this.var" + StringUtils.ObjectToString(i), 
                                            "'" + mItemBrowser.getItemNameByHandle(mVarItemHandles[i]) + "'");
                        }
                    }
                    else
                    {
                        var lSubStr = new StringBuilder();

                        if (lComStr.Item1[0] != 0)
                        {
                            lSubStr.Append(mAliasCode.Substring(0, lComStr.Item1[0]));
                            for (int j = mVarItemHandles.Length - 1; j >= 0; j--)
                            {
                                lSubStr.Replace("this.var" + StringUtils.ObjectToString(j),
                                                    "'" + mItemBrowser.getItemNameByHandle(mVarItemHandles[j]) + "'");
                            }
                            lCode.Append(lSubStr);
                        }

                        int lLastIndx = lComStr.Item1.Length - 1;
                        int lStrIndx;

                        for (int i = 0; i < lComStr.Item1.Length; i++)
                        {
                            lCode.Append(mAliasCode.Substring(lComStr.Item1[i], lComStr.Item2[i]));
                        
                            lStrIndx = lComStr.Item1[i] + lComStr.Item2[i];
                            if (lStrIndx < mAliasCode.Length)
                            {
                                lSubStr.Clear();

                                if (i < lLastIndx)
                                {
                                    lSubStr.Append(mAliasCode.Substring(lStrIndx, lComStr.Item1[i + 1] - lStrIndx));
                                }
                                else
                                {
                                    lSubStr.Append(mAliasCode.Substring(lStrIndx, mAliasCode.Length - lStrIndx));
                                }

                                for (int j = mVarItemHandles.Length - 1; j >= 0; j--)
                                {
                                    lSubStr.Replace("this.var" + StringUtils.ObjectToString(j),
                                                        "'" + mItemBrowser.getItemNameByHandle(mVarItemHandles[j]) + "'");
                                }

                                lCode.Append(lSubStr);
                            }
                        }
                     }

                    return lCode.ToString();
                }
            }

            private string[]                mConnectedStates = new string[] { };
            public string[]                 ConnectedStates
            { 
                get { return mConnectedStates; } 
            }

            public void                     replaceConnectedState(string aOldState, string aNewState)
            {
                if (mConnectedStates.Length == 0) return;

                var lStrings = findAllStings(mAliasCode);
                if (lStrings.Item1.Length == 0) return;

                var lComments   = findAllComments(mAliasCode);
                var lComStr     = uniteCommentsAndStrings(lComments, lStrings);

                var lCode       = new StringBuilder();
                if (lStrings.Item1[0] != 0)
                {
                    lCode.Append(mAliasCode.Substring(0, lStrings.Item1[0]));
                }

                int lStateIndex = -1;
                for (int i = 0; i < mConnectedStates.Length; i++)
                {
                    if (mConnectedStates[i].Equals(aOldState, StringComparison.Ordinal))
                    {
                        lStateIndex = i;

                        string lSubStr;
                        bool lIsSwitchTo;
                        int lStrIndx;
                        int lLastIndex = lStrings.Item1.Length - 1;

                        for (int j = 0; j < lStrings.Item1.Length; j++)
                        {
                            lIsSwitchTo = false;
                            lSubStr     = lStrings.Item2[j].Substring(1, lStrings.Item2[j].Length - 2);
                            if (lSubStr.Equals(aOldState, StringComparison.Ordinal) && isInside(lStrings.Item1[j], lComments) == false)
                            {
                                lStrIndx = lStrings.Item1[j] + lStrings.Item2[j].Length;

                                while(lStrIndx < mAliasCode.Length && mAliasCode[lStrIndx] != ')')
                                {
                                    if (mAliasCode[lStrIndx] != ' ' && mAliasCode[lStrIndx] != '\r' && mAliasCode[lStrIndx] != '\n')
                                    {
                                        goto next;
                                    }

                                    lStrIndx = lStrIndx + 1;
                                }

                                lStrIndx = lStrIndx + 1;

                                while(lStrIndx < mAliasCode.Length && mAliasCode[lStrIndx] != ';')
                                {
                                    if (mAliasCode[lStrIndx] != ' ' && mAliasCode[lStrIndx] != '\r' && mAliasCode[lStrIndx] != '\n')
                                    {
                                        goto next;
                                    }

                                    lStrIndx = lStrIndx + 1;
                                }

                                lStrIndx = lStrings.Item1[j] - 1;

                                while(lStrIndx >= 0 && mAliasCode[lStrIndx] != '(')
                                {
                                    if (mAliasCode[lStrIndx] != ' ' && mAliasCode[lStrIndx] != '\r' && mAliasCode[lStrIndx] != '\n')
                                    {
                                        goto next;
                                    }

                                    lStrIndx = lStrIndx - 1;
                                }

                                lStrIndx = lStrIndx - 1;

                                while(lStrIndx >= 0 && mAliasCode[lStrIndx] != 'o')
                                {
                                    if (mAliasCode[lStrIndx] != ' ' && mAliasCode[lStrIndx] != '\r' && mAliasCode[lStrIndx] != '\n')
                                    {
                                        goto next;
                                    }

                                    lStrIndx = lStrIndx - 1;
                                }

                                if (lStrIndx < 7)
                                {
                                    goto next;
                                }

                                if (mAliasCode.Substring(lStrIndx - 7, 8).Equals("SwitchTo", StringComparison.Ordinal) == false)
                                {
                                    goto next;
                                }

                                lIsSwitchTo = true;                         
                            }
                            
                            next:

                            if (lIsSwitchTo)
                            {
                                lCode.Append('"');
                                lCode.Append(aNewState);
                                lCode.Append('"');
                            }
                            else
                            {
                                lCode.Append(lStrings.Item2[j]);
                            }

                            lStrIndx = lStrings.Item1[j] + lStrings.Item2[j].Length;
                            if (j == lLastIndex)
                            {
                                lCode.Append(mAliasCode.Substring(lStrIndx, mAliasCode.Length - lStrIndx));
                            }
                            else
                            {  
                                lCode.Append(mAliasCode.Substring(lStrIndx, lStrings.Item1[j + 1] - lStrIndx));
                            }
                        }

                        break;
                    }
                }
                if (lStateIndex == -1) return;

                var lVarItems = new string[mVarItemHandles.Length];
                for (int i = 0; i < mVarItemHandles.Length; i++)
                {
                    lVarItems[0] = mItemBrowser.getItemNameByHandle(mVarItemHandles[i]);
                }

                var lAliasCode          = lCode.ToString();
                var lCompilerResults    = compile(lAliasCode, lVarItems, mLocalVars.Names, mLocalVars.Values);

                if (lCompilerResults.Errors.Count != 0)
                {
                    foreach (CompilerError lError in lCompilerResults.Errors)
                    {
                        if (lError.IsWarning != true)
                        {
                            throw new InvalidOperationException("Unable to compile script. " + CSScript.getErrorMessage(lError.ErrorText, lError.Line));
                        }
                    }
                }

                mConnectedStates[lStateIndex] = aNewState;
                init(lCompilerResults, lAliasCode, lVarItems, mConnectedStates);
            }

            public static Tuple<string, int>[]  check(string aCode, Tuple<int[], int[]> aComStr, out string[] aConnectedStates)
            {
                var lErrors = new List<Tuple<string, int>>();
                var lStates = new HashSet<string>();
                int lIndex;
                int lIndex1;
                bool lError;
                bool lVerbatim;
                bool lIsSwitchTo;
                char lChar;
                string lString = "";

                #region Reserved words

                    for (int i = 0; i < ReservedWords.Length; i++)
                    {
                        lIndex = 0;
                        do
                        {
                            lIndex = aCode.IndexOf(ReservedWords[i], lIndex);
                            if (lIndex != -1)
                            {
                                lError = true;

                                // Если a-zA-Z_ в начале, или a-zA-Z0-9_ в конце то не считается                    
                                if (lIndex >= 1)
                                {
                                    lChar = aCode[lIndex - 1];
                                    if (Char.IsLetter(lChar) || lChar == '_')
                                    {
                                        lError = false;
                                        goto nextRW;
                                    }
                                }

                                if (lIndex + ReservedWords[i].Length < aCode.Length)
                                {
                                    lChar = aCode[lIndex + ReservedWords[i].Length];
                                    if (Char.IsLetter(lChar) || lChar == '_' || Char.IsDigit(lChar))
                                    {
                                        lError = false;
                                        goto nextRW;
                                    }
                                }

                                //Если строковой литерал или коментарий
                                if (isInside(lIndex, aComStr))
                                {
                                    lError = false;
                                    goto nextRW;
                                }

                                nextRW:

                                if (lError)
                                {
                                    lErrors.Add(new Tuple<string, int>("String '" + ReservedWords[i] + "' usage is prohibited", StringUtils.getLineNumber(aCode, lIndex)));
                                }

                                lIndex = lIndex + ReservedWords[i].Length;
                                if (lIndex >= aCode.Length)
                                {
                                    break;
                                }
                            }
                        }
                        while (lIndex != -1);
                    }

                #endregion
                
                #region SwitchTo

                    lIndex = 0;
                    do
                    {
                        lIndex = aCode.IndexOf("SwitchTo", lIndex);
                        if(lIndex != -1)
                        {
                            lIsSwitchTo = true;

                            // Если a-zA-Z_ в начале, или a-zA-Z0-9_ в конце то не считается                    
                            if (lIndex >= 1)
                            {
                                lChar = aCode[lIndex - 1];
                                if (Char.IsLetter(lChar) || lChar == '_')
                                {
                                    lIsSwitchTo = false;
                                    goto nextST;
                                }
                            }

                            if (lIndex + 8 < aCode.Length)
                            {
                                lChar = aCode[lIndex + 8];
                                if (Char.IsLetter(lChar) || lChar == '_' || Char.IsDigit(lChar))
                                {
                                    lIsSwitchTo = false;
                                    goto nextST;
                                }
                            }

                            //Если строковой литерал или коментарий
                            if (isInside(lIndex, aComStr))
                            {
                                lIsSwitchTo = false;
                                goto nextST;
                            }
                            
                            nextST:

                            lError = false; 
                            if (lIsSwitchTo)
                            {
                                lIndex = lIndex + 8;
                                lIndex1 = aCode.IndexOf(';', lIndex);
                                if (lIndex1 != -1)
                                {
                                    lIndex1 = lIndex1 - lIndex;
                                    lString = aCode.Substring(lIndex, lIndex1).Trim();
                                    if(lString[0].Equals('(') && lString[lString.Length - 1].Equals(')') && lString.Length > 2)
                                    {
                                        lString = lString.Substring(1, lString.Length - 2).Trim();

                                        lVerbatim = lString[0].Equals('@');
                                        if (lVerbatim)
                                        {
                                            lString = lString.Substring(1);
                                        }

                                        if (lString[0].Equals('"') && lString[lString.Length - 1].Equals('"'))
                                        {
                                            lString = lString.Substring(1, lString.Length - 2);

                                            if (lString.Length != 0)
                                            {
                                                if(lVerbatim)
                                                {
                                                    if (lString.Replace(@"""""", "").Contains(@""""))
                                                    {
                                                        lError = true;
                                                    }
                                                    else
                                                    {
                                                        lString = lString.Replace(@"""""", @"""");
                                                    }
                                                }
                                                else
                                                {
                                                    if (lString.Replace(@"\""", "").Contains(@""""))
                                                    {
                                                        lError = true;
                                                    }
                                                    else
                                                    {
                                                        lString = lString.Replace(@"\""", @"""");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                lError = true;
                                            }
                                        }
                                        else { lError = true; }
                                    }
                                    else { lError = true; }
                                }
                                else { lError = true; }
                            }
                            else
                            {
                                lIndex1 = 8;
                            }

                            if(lError)
                            {
                                lErrors.Add(new Tuple<string, int>("'SwitchTo' syntax is invalid. ", StringUtils.getLineNumber(aCode, lIndex)));
                                break;
                            }
                            else if (lIsSwitchTo)
                            {
                                lStates.Add(lString);
                            }

                            lIndex = lIndex + lIndex1;
                            if (lIndex >= aCode.Length)
                            {
                                break;
                            }
                        }                        
                    }
                    while (lIndex != -1);

                    aConnectedStates = lStates.ToArray();

                #endregion

                return lErrors.ToArray();
            }

            public static string[]          findItems(IItemBrowser aItemBrowser, Tuple<int[], string[]> aStrings, Tuple<int[], string[]> aComments)
            {
                var lResult = new HashSet<string>();
                string lString;
                int lLength;

                for (int i = 0; i < aStrings.Item2.Length; i++)
                {
                    lLength = aStrings.Item2[i].Length;
                    if (lLength >= 5)
                    {
                        if (aStrings.Item2[i][0] == '\'')
                        {
                            //Не коментарий
                            if (isInside(aStrings.Item1[i], aComments))
                            {
                                continue;
                            }

                            lString = aStrings.Item2[i].Substring(1, lLength - 2);
                            if (aItemBrowser.isItemExists(lString))
                            {
                                lResult.Add(lString);
                            }
                        }
                    }
                }

                return lResult.ToArray();
            }

            public static readonly int      UserLineStart = 11;

            public static string            prepareCode(string                  aCode, 
                                                        Tuple<int[], string[]>  aStrings, 
                                                        Tuple<int[], string[]>  aComments,
                                                        Tuple<int[], int[]>     aComStr,
                                                        string[]                aVarItems)
            {
                var lCode   = new StringBuilder();

                if (aComStr.Item1.Length == 0)
                {
                    lCode.Append(aCode);
                    for (int i = 0; i < aVarItems.Length; i++)
                    {
                        lCode.Replace("'" + aVarItems[i] + "'", "this.var" + StringUtils.ObjectToString(i));
                    }
                }
                else
                {
                    var lSubStr = new StringBuilder();

                    if (aComStr.Item1[0] != 0)
                    {
                        lSubStr.Append(aCode.Substring(0, aComStr.Item1[0]));
                        for (int j = 0; j < aVarItems.Length; j++)
                        {
                            lSubStr.Replace("'" + aVarItems[j] + "'", "this.var" + StringUtils.ObjectToString(j));
                        }
                        lCode.Append(lSubStr);
                    }

                    int lLastIndx = aComStr.Item1.Length - 1;
                    int lStrIndx;

                    for (int i = 0; i < aComStr.Item1.Length; i++)
                    {
                        lCode.Append(aCode.Substring(aComStr.Item1[i], aComStr.Item2[i]));
                        
                        lStrIndx = aComStr.Item1[i] + aComStr.Item2[i];
                        if (lStrIndx < aCode.Length)
                        {
                            lSubStr.Clear();

                            if (i == lLastIndx)
                            {
                                lSubStr.Append(aCode.Substring(lStrIndx, aCode.Length - lStrIndx));  
                            }
                            else
                            {
                                lSubStr.Append(aCode.Substring(lStrIndx, aComStr.Item1[i + 1] - lStrIndx));
                            }

                            for (int j = 0; j < aVarItems.Length; j++)
                            {
                                lSubStr.Replace("'" + aVarItems[j] + "'", "this.var" + StringUtils.ObjectToString(j));
                            }

                            lCode.Append(lSubStr);
                        }
                    }
                }
            
                return lCode.ToString();
            }

            public static CompilerResults   compile(string aCode, string[] aVarItems, string[] aLocalVarNames, object[] aLocalVarValues)
            {
                string[] names = Assembly.GetExecutingAssembly().GetManifestResourceNames();

                var lAssembly       = Assembly.GetExecutingAssembly();
                var lStreamReader   = new StreamReader(lAssembly.GetManifestResourceStream("Utils.Resources.ScriptTemplate.txt"));
                var lScriptTemplate = new StringBuilder(lStreamReader.ReadToEnd());
                lStreamReader.Close();

                var lLocalVars = new StringBuilder("");
                for (int i = 0; i < aLocalVarNames.Length; i++)
                {
                    lLocalVars.Append("public ");
                    lLocalVars.Append(aLocalVarValues[i].GetType().Name);
                    lLocalVars.Append(" ");
                    lLocalVars.Append(aLocalVarNames[i]);
                    lLocalVars.Append(";");
                    lLocalVars.Append(Environment.NewLine);
                } 

                var lFields = new StringBuilder("");
                if (aVarItems.Length != 0)
                {
                    lStreamReader       = new StreamReader(lAssembly.GetManifestResourceStream("Utils.Resources.VarTemplate.txt"));
                    var lVarTemplate    = lStreamReader.ReadToEnd();
                    lStreamReader.Close();

                    for (int i = 0; i < aVarItems.Length; i++)
                    {
                        lFields.Append(lVarTemplate.Replace("#R#", StringUtils.ObjectToString(i)));
                    }
                }

                lScriptTemplate.Replace("#R0#", lLocalVars.ToString());
                lScriptTemplate.Replace("#R1#", lFields.ToString());
                lScriptTemplate.Replace("#R2#", aCode);

                CompilerParameters lCompilerParam       = new CompilerParameters();
                lCompilerParam.GenerateExecutable       = false;
                lCompilerParam.GenerateInMemory         = false;
                lCompilerParam.TreatWarningsAsErrors    = false;
                lCompilerParam.WarningLevel             = 4;
                lCompilerParam.IncludeDebugInformation  = true;
                lCompilerParam.TempFiles                = new TempFileCollection(MiscUtils.TempPath, true);
                lCompilerParam.ReferencedAssemblies.Add("System.dll");

                CompilerResults lCompilerResults;
                using (CodeDomProvider lCodeProvider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } }))
                {
                    lCompilerResults = lCodeProvider.CompileAssemblyFromSource(lCompilerParam, lScriptTemplate.ToString());
                }

                if (lCompilerResults.Errors.Count != 0)
                {
                    long lLineNum = StringUtils.getLineCount(aCode);
                    foreach (CompilerError lError in lCompilerResults.Errors)
                    {
                        lError.Line = lError.Line - UserLineStart;
                        if (lError.Line <= 0) lError.Line = 1;
                        if (lError.Line > lLineNum) lError.Line = (int)lLineNum;
                    }
                }

                lCompilerResults.TempFiles.KeepFiles = true;

                return lCompilerResults;
            }

            public static string            getErrorMessage(string aErrorText, int aLine)
            {
                return aErrorText + " (Line " + StringUtils.ObjectToString(aLine) + ").";
            }

            private void                    clear()
            {
                if (mScriptClassInst != null)
                {
                    mScriptClassType.GetEvent("ScriptEvent").RemoveEventHandler(mScriptClassInst, mOnEventDelegate);
                }
            }

            public void                     init(CompilerResults aCompilerResults, string aAliasCode, string[] aVarItems, string[] aConnectedStates)
            {
                clear();
                mAliasCode          = aAliasCode;
                mConnectedStates    = aConnectedStates;

                mScriptClassInst    = aCompilerResults.CompiledAssembly.CreateInstance("SciptNamespace.ScriptClass");
                mScriptClassType    = mScriptClassInst.GetType();

                mOnEventDelegate = new EventHandler(onEvent);
                mScriptClassType.GetEvent("ScriptEvent").AddEventHandler(mScriptClassInst, mOnEventDelegate);

                mVarItemIndex.Clear();

                mVarItemHandles     = new int[aVarItems.Length];
                mVarItemValues      = new object[aVarItems.Length];
                mVarItemChanged     = new bool[aVarItems.Length];

                for (int i = 0; i < aVarItems.Length; i++)
                {
                    mVarItemHandles[i]  = mItemBrowser.getItemHandleByName(aVarItems[i]);
                    mVarItemValues[i]   = 0;
                    mVarItemChanged[i]  = false;
                    mVarItemIndex.Add(mVarItemHandles[i], i);
                }

                mScriptClassType.GetField("mVarValues").SetValue(mScriptClassInst, mVarItemValues);
                mScriptClassType.GetField("mVarValuesChanged").SetValue(mScriptClassInst, mVarItemChanged);

                setLocalVariables();
            }

        #endregion

        #region Work

            public uint                     mWatchdogMS         = 1000;

            public uint                     mTriggerTimeMS      = 0;

            private long                    mLastMS;
            
            public void                     reset()
            {
                mValueChanged   = false;
                mLastMS         = MiscUtils.TimerMS;
                for (int i = 0; i < mVarItemChanged.Length; i++)
                {
                    mVarItemChanged[i] = false;
                }
            }

            public void                     setFirstCycle()
            {
                mLastMS = MiscUtils.TimerMS;
                mScriptClassType.GetField("FirstCycle").SetValue(mScriptClassInst, true);
            }

            private volatile bool           mValueChanged;
            public bool                     ValueChanged
            {
                get { return mValueChanged; }
            }

            private bool                    mLastOn = true;
            public void                     execute()
            {
                if (mOn && mLastOn == false)
                {
                    setFirstCycle();
                }
                mLastOn = mOn;

                if (mOn == false) return;

                var lAllArrays = new Dictionary<int, Array>();
                Array lArray;
                for (int i = 0; i < mVarItemValues.Length; i++)
                {
                    lArray = mVarItemValues[i] as Array;
                    if (lArray != null)
                    {
                        lAllArrays.Add(mVarItemHandles[i], (Array)lArray.Clone());
                    }
                }

                long lMSFromLastCall = MiscUtils.TimerMS - mLastMS;
                if (lMSFromLastCall < mTriggerTimeMS)
                {
                    return;
                }

                Thread lThread = new Thread(delegate () { mScriptClassType.GetMethod("ScriptMethod").Invoke(mScriptClassInst, new object[] { lMSFromLastCall }); });
                lThread.Start();
                if (lThread.Join((int)mWatchdogMS) == false)
                {
                    lThread.Abort();
                    throw new InvalidOperationException("Watchdog timeout. ");
                }

                for (int i = 0; i < mVarItemChanged.Length; i++)
                {
                    if (mVarItemChanged[i] == true)
                    {
                        mValueChanged = true;
                    }
                    else
                    {                     
                        lArray = mVarItemValues[i] as Array;
                        if (lArray != null)
                        {
                            if (lAllArrays.ContainsKey(mVarItemHandles[i]))
                            {
                                // if SetValue() is used in script
                                if (ValuesCompare.isNotEqual(lArray, lAllArrays[mVarItemHandles[i]]))
                                {
                                    mVarItemChanged[i]  = true;
                                    mValueChanged       = true;
                                }
                            }
                            else
                            {
                                mVarItemChanged[i]  = true;
                                mValueChanged       = true;
                            }
                        }
                    }
                }

                if (mValueChanged && mVarItemIndex.ContainsKey(mOnItemHandle))
                {
                    int lIndex = mVarItemIndex[mOnItemHandle];
                    if (mVarItemChanged[lIndex])
                    {
                        bool lValue;
                        try
                        {
                            lValue = Convert.ToBoolean(mVarItemValues[lIndex]);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("Value conversion error for object to switch on. ", lExc);
                        }

                        mOn = lValue;
                        raiseOnChanged();
                    }
                }

                getLocalVariables();

                mLastMS = MiscUtils.TimerMS;
            }

            private void                    onEvent(Object aSender, EventArgs aEventArgs)
            {
                var lEventArgs = (object[])mScriptClassType.GetField("mEventArgs").GetValue(mScriptClassInst);

                switch ((int)lEventArgs[0])
                {
                    case 1: var lExc = lEventArgs[1] as Exception;                  // Exception
                            string lMessage;
                            if (lExc == null) { lMessage = "Exception is null. "; }
                            else
                            {
                                lMessage = lExc.Message;
                                int lLine = new StackTrace(lExc, true).GetFrame(0).GetFileLineNumber() - CSScript.UserLineStart;
                                if (lLine > 0)
                                {
                                    lMessage = lMessage + " (Line " + lLine.ToString() + ")";
                                }
                            }
                            raiseScriptException(lMessage); break;
                    case 2: Log.Info((string)lEventArgs[1]); break;                 // LogMessage
                    case 3: Log.Error((string)lEventArgs[1]); break;                // ReportError
                    case 4: raiseSwitchToState((string)lEventArgs[1]); break;       // SwitchTo
                }

                mScriptClassType.GetField("mEventArgs").SetValue(mScriptClassInst, null);
            }

            public event EventHandler<MessageStringEventArgs> ScriptException;
            private void                    raiseScriptException(string aMessage)
            {
                ScriptException?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            public event EventHandler<MessageStringEventArgs> SwitchToState;
            private void                    raiseSwitchToState(string aMessage)
            {
                SwitchToState?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

        #endregion

        #region IDisposable

            private bool                    mDisposed = false;

            public void                     Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void          Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        clear();
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
