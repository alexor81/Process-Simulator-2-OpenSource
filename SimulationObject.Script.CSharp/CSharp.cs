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
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;

namespace SimulationObject.Script.CSharp
{
    public class CSharp : ISimulationObject
    {
        #region Properties

            public uint                                         mWatchdogMS         = 1000;

            public uint                                         mTriggerTimeMS      = 500;

            public Size                                         mEditorSize         =  new Size(618, 517);

            public int                                          mEditorSplitterPos  = 53;

            public int                                          mEditorFontIndex    = 0;

        #endregion

        #region Script

            private string                                      mAliasCode    = "";
            private object                                      mScriptClassInst;
            private Type                                        mScriptClassType;
            private Delegate                                    mOnEventDelegate;

            public string                                       Code
            {
                get
                {
                    var lCode   = new StringBuilder(mAliasCode);
                    for (int i = mVarItemHandles.Length - 1; i >= 0; i--)
                    {
                        lCode.Replace("this.var" + StringUtils.ObjectToString(i), "'" + mItemBrowser.getItemNameByHandle(mVarItemHandles[i]) + "'");
                    }

                    return lCode.ToString();
                }
            }

            private string[]                                    mReservedWords = new string[] { "ScriptClass",
                                                                                                "ScriptMethod",
                                                                                                "mVarValues",
                                                                                                "mVarValuesChanged",
                                                                                                "ScriptEvent",
                                                                                                "raiseScriptEvent",
                                                                                                "mEventArgs" };
            public Tuple<string, int>[]                         check(string aCode)
            {
                List<Tuple<string, int>> lErrors = new List<Tuple<string,int>>();
                int lIndex;
                bool lError;
                char lChar;

                for (int i = 0; i < mReservedWords.Length; i++)
                {
                    lIndex = 0;
                    do
                    {
                       lIndex = aCode.IndexOf(mReservedWords[i], lIndex);
                       if (lIndex != -1)
                       {
                           // Если a-zA-Z_ в начале, или a-zA-Z0-9_ в конце то не считается
                           lError = true;
                           if (lIndex >= 1)
                           {
                               lChar = aCode[lIndex - 1];
                               if (Char.IsLetter(lChar) || lChar == '_')
                               {
                                   lError = false;
                               }
                           }

                           if (lIndex + mReservedWords[i].Length < aCode.Length)
                           {
                               lChar = aCode[lIndex + mReservedWords[i].Length];
                               if (Char.IsLetter(lChar) || lChar == '_' || Char.IsDigit(lChar))
                               {
                                   lError = false;
                               }
                           }

                           if (lError)
                           {
                               lErrors.Add(new Tuple<string, int>("String '" + mReservedWords[i] + "' usage is prohibited", StringUtils.getLineNumber(aCode, lIndex)));
                           }

                           lIndex = lIndex + mReservedWords[i].Length;
                           if (lIndex >= aCode.Length)
                           {
                               break;
                           }
                       }
                    }
                    while (lIndex != -1);
                }
                
                return lErrors.ToArray();
            }

            private string[]                                    findItems(string aCode, string aConnectionName)
            {
                var lResult         = new HashSet<string>();
                string[] lItems     = null;
                int lIndex          = 0;
                string lFindString  = "'" + aConnectionName + ".";
                do
                {
                    lIndex = aCode.IndexOf(lFindString, lIndex);
                    if (lIndex != -1)
                    {
                        lIndex = lIndex + lFindString.Length;
                        if (lIndex < aCode.Length - 1)
                        {
                            if (lItems == null)
                            {
                                lItems = mItemBrowser.getItemNames(aConnectionName);
                            }

                            for (int i = 0; i < lItems.Length; i++)
                            {
                                if (lIndex + lItems[i].Length < aCode.Length)
                                {
                                    if (aCode.IndexOf(lItems[i] + "'", lIndex) == lIndex)
                                    {
                                        lResult.Add(aConnectionName + "." + lItems[i]);
                                        lIndex = lIndex + lItems[i].Length + 1;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                while (lIndex != -1);

                return lResult.ToArray();
            }

            private static readonly int                         UserLineStart = 11;

            public CompilerResults                              compile(string aCode, out string aAliasCode, out string[] aVarItems)
            {
                var lConnections    = mItemBrowser.ConnectionNames;
                var lVarItem        = new List<string>();
                for (int i = 0; i < lConnections.Length; i++)
                {
                    lVarItem.AddRange(findItems(aCode, lConnections[i]));
                }

                aVarItems           = lVarItem.ToArray();
                var lCode           = new StringBuilder(aCode);

                for (int i = 0; i < aVarItems.Length; i++)
                {
                    lCode.Replace("'" + aVarItems[i] + "'", "this.var" + StringUtils.ObjectToString(i));
                }

                var lAssembly       = Assembly.GetExecutingAssembly();
                var lStreamReader   = new StreamReader(lAssembly.GetManifestResourceStream("SimulationObject.Script.CSharp.Resources.ScriptTemplate.txt"));
                var lScriptTemplate = new StringBuilder(lStreamReader.ReadToEnd());
                lStreamReader.Close();

                StringBuilder lFields = new StringBuilder("");
                if (aVarItems.Length != 0)
                {
                    lStreamReader = new StreamReader(lAssembly.GetManifestResourceStream("SimulationObject.Script.CSharp.Resources.VarTemplate.txt"));
                    var lVarTemplate = lStreamReader.ReadToEnd();
                    lStreamReader.Close();

                    for (int i = 0; i < aVarItems.Length; i++)
                    {
                        lFields.Append(lVarTemplate.Replace("#R#", StringUtils.ObjectToString(i)));
                    }
                }

                lScriptTemplate.Replace("#R1#", lFields.ToString());
                lScriptTemplate.Replace("#R2#", lCode.ToString());

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

                aAliasCode = lCode.ToString();
                return lCompilerResults;
            }

            public static string                                getErrorMessage(string aErrorText, int aLine)
            {
                return aErrorText + " (Line " + StringUtils.ObjectToString(aLine) + ").";
            }

            private void                                        clear()
            {
                if (mScriptClassInst != null)
                {
                    mScriptClassType.GetEvent("ScriptEvent").RemoveEventHandler(mScriptClassInst, mOnEventDelegate);
                }
            }
            
            public void                                         init(CompilerResults aCompilerResults, string aAliasCode, string[] aVarItems)
            {
                clear();

                mScriptClassInst    = aCompilerResults.CompiledAssembly.CreateInstance("SciptNamespace.ScriptClass");
                mScriptClassType    = mScriptClassInst.GetType();
                mAliasCode          = aAliasCode;

                mOnEventDelegate    = new EventHandler(onEvent);
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
            }

        #endregion

        #region IItemUser

            private Dictionary<int, int>                        mVarItemIndex   = new Dictionary<int, int>();
            private int[]                                       mVarItemHandles = new int[0];
            private object[]                                    mVarItemValues  = new object[0];
            private bool[]                                      mVarItemChanged = new bool[0];
  
            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    return mVarItemHandles;
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return mVarItemHandles;
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged           = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                for (int i = 0; i < mVarItemHandles.Length; i++)
                {
                    if (mVarItemChanged[i] == true)
                    {
                        mVarItemChanged[i] = false;
                        lHandles.Add(mVarItemHandles[i]);
                        lValues.Add(mVarItemValues[i]);                 
                    }
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if(mVarItemIndex.ContainsKey(aItemHandle))
                {
                    int lIndex = mVarItemIndex[aItemHandle];
                    if (mVarItemChanged[lIndex] == false)
                    {
                        mVarItemValues[lIndex] = aItemValue;
                    }
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    default: throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler                           ChangedValues;
            public void                                         raiseValuesChanged()
            {
                EventHandler lEvent = ChangedValues;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

            public event EventHandler                           ChangedProperties;
            public void                                         raisePropertiesChanged()
            {
                EventHandler lEvent = ChangedProperties;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult                                 setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

            public void                                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                
                mWatchdogMS     = lReader.getAttribute<UInt32>("Watchdog", mWatchdogMS);
                mTriggerTimeMS  = lReader.getAttribute<UInt32>("TriggerTime", mTriggerTimeMS);

                string lCode    = "";
                if (aXMLTextReader.IsEmptyElement == false)
                {
                    aXMLTextReader.Read();
                    if (aXMLTextReader.Name.Equals("Script", StringComparison.Ordinal))
                    {
                        if (aXMLTextReader.IsEmptyElement == false)
                        {
                            aXMLTextReader.Read();
                            lCode = aXMLTextReader.ReadString();
                        }
                    }
                }

                var lErrors = check(lCode);
                if (lErrors.Length != 0)
                {
                    throw new ArgumentException(getErrorMessage(lErrors[0].Item1, lErrors[0].Item2));
                }

                string lAliasCode;
                string[] lVarItems;

                var lCompilerResult = compile(lCode, out lAliasCode, out lVarItems);

                if (lCompilerResult.Errors.Count != 0)
                {
                    foreach (CompilerError lError in lCompilerResult.Errors)
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

                init(lCompilerResult, lAliasCode, lVarItems);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Watchdog", StringUtils.ObjectToString(mWatchdogMS));
                aXMLTextWriter.WriteAttributeString("TriggerTime", StringUtils.ObjectToString(mTriggerTimeMS));

                aXMLTextWriter.WriteStartElement("Script");
                aXMLTextWriter.WriteCData(Code);
                aXMLTextWriter.WriteEndElement();
            }

            private long                                        mLastMS;
            public void                                         execute()
            {
                long lMSFromLastCall = MiscUtils.TimerMS - mLastMS;
                if (lMSFromLastCall < mTriggerTimeMS)
                {
                    return;
                }

                Thread lThread = new Thread(delegate() { mScriptClassType.GetMethod("ScriptMethod").Invoke(mScriptClassInst, new object[] { lMSFromLastCall }); });
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
                        break;
                    }
                }

                mLastMS = MiscUtils.TimerMS;
            }

            public void                                         beforeActivate()
            {
                mLastMS = MiscUtils.TimerMS;
                for (int i = 0; i < mVarItemChanged.Length; i++)
                {
                    mVarItemChanged[i] = false;
                }
            }

            public void                                         afterDeactivate()
            {
            }

            private string                                      mLastError;
            public string                                       LastError
            {
                get { return mLastError; }
            }

            public event EventHandler<MessageStringEventArgs>   SimulationObjectError;
            public void                                         raiseSimulationObjectError(string aMessage)
            {
                mLastError = aMessage;
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
            }

            private void                                        onEvent(Object aSender, EventArgs aEventArgs)
            {
                var lEventArgs = (object[])mScriptClassType.GetField("mEventArgs").GetValue(mScriptClassInst);

                switch((int)lEventArgs[0])
                {
                    case 1: raiseSimulationObjectError((string)lEventArgs[1]); break;   //ReportError
                    case 2: Log.Info((string)lEventArgs[1]); break;                     //LogMessage
                    case 3: Exception lExc = lEventArgs[1] as Exception;                //ReportException
                            if (lExc != null)
                            {
                                int lLine = new StackTrace(lExc, true).GetFrame(0).GetFileLineNumber() - UserLineStart;
                                if(lLine > 0)
                                { 
                                    raiseSimulationObjectError(lExc.Message + " (Line " + lLine.ToString() + ")");
                                }
                                else
                                {
                                    raiseSimulationObjectError(lExc.Message);
                                }
                            }
                            break;
                }

                mScriptClassType.GetField("mEventArgs").SetValue(mScriptClassInst, null);
            }

            public string[]                                     ContextMenuItemList
            {
                get { return new string[0]; }
            }

            public void                                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
            }

        #endregion

        #region IDisposable

            private bool                                        mDisposed = false;

            public void                                         Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void                              Dispose(bool aDisposing)
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
