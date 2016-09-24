using API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.CSharpScript;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Script.CSharpFSM
{
    public class CSharpFSM : ISimulationObject, IObjectValueRead
    {
        #region Properties

            private volatile string             mCurrentState   = "";
            public object                       ValueObject
            {
                get 
                {
                    if (mCurrentState == null)
                    { 
                        return ""; 
                    }
                    else
                    {
                        return mCurrentState;
                    }
                }
            }

            private List<string>                mStates         = new List<string>();
            private Dictionary<string, CSScipt> mStateAction    = new Dictionary<string, CSScipt>();    

            public void                         addState(string aName, CSScipt aScript)
            {
                if(String.IsNullOrWhiteSpace(aName))
                {
                    throw new ArgumentException("State name is empty. ");
                }

                if(mStateAction.ContainsKey(aName))
                {
                    throw new ArgumentException("State '" + aName + "' already exists. ");
                }

                aScript.ScriptException += MCSScript_ScriptException;
                aScript.SwitchToState   += MCSScript_SwitchToState;
                mStateAction.Add(aName, aScript);
                mStates.Add(aName);

                if(mStates.Count == 1)
                {
                    mCurrentState = aName;
                    raiseValuesChanged();
                }

                mItemHandles = null;
            }

            public void                         deleteState(string aName)
            {
                if (String.IsNullOrWhiteSpace(aName))
                {
                    throw new ArgumentException("State name is empty. ");
                }

                if (mStateAction.ContainsKey(aName) == false)
                {
                    throw new ArgumentException("State '" + aName + "' does not exist. ");
                }

                var lScript = mStateAction[aName];
                mStateAction.Remove(aName);
                mStates.Remove(aName);
                lScript.ScriptException -= MCSScript_ScriptException;
                lScript.SwitchToState   -= MCSScript_SwitchToState;
                lScript.Dispose();

                if (mStates.Count == 0)
                {
                    mCurrentState = null;
                    raiseValuesChanged();
                }
                else
                {
                    if (aName.Equals(mCurrentState, StringComparison.Ordinal))
                    {
                        mCurrentState = mStates[0];
                        raiseValuesChanged();
                    }
                }

                mItemHandles = null;
            }

            public void                         clearAllStates()
            {
                var lKeys = mStates.ToArray();
                foreach (string lKey in lKeys)
                {
                    deleteState(lKey);
                }

                mItemHandles = null;
            }

            private Dictionary<int, HashSet<string>>  mItemHandles = null;
            private int[]                       ItemHandles
            {
                get
                {
                    if (mItemHandles == null)
                    {
                        mItemHandles = new Dictionary<int, HashSet<string>>();

                        int[] lScriptHandles;
                        foreach (string lStateName in mStates)
                        {
                            lScriptHandles = mStateAction[lStateName].ItemHandles;
                            foreach (int lHandle in lScriptHandles)
                            {
                                if (mItemHandles.ContainsKey(lHandle) == false)
                                {
                                    mItemHandles.Add(lHandle, new HashSet<string>(StringComparer.Ordinal));
                                }

                                mItemHandles[lHandle].Add(lStateName);
                            }
                        }
                    }

                    return mItemHandles.Keys.ToArray();
                }
            }

            public string[]                     StateList
            {
                get { return mStates.ToArray(); }
            }

            public int                          StateCount
            {
                get { return mStates.Count; }
            }

            public string[]                     getStateConnections(string aName)
            {
                if(mStateAction.ContainsKey(aName) == false)
                {
                    throw new ArgumentException("State '" + aName + "' does not exist. ");
                }

                return mStateAction[aName].ConnectedStates;
            }

            public void                         check()
            {
                var lStates             = new HashSet<string>(StateList);
                var lConnectedStates    = new HashSet<string>();
                string[] lConnections;

                foreach (string lState in mStates)
                {
                    lConnections = mStateAction[lState].ConnectedStates;

                    if (lConnections.Length == 0 && mStates.Count != 1)
                    {
                        throw new ArgumentException("State '" + lState + " is dead end. ");
                    }

                    foreach (string lConnection in lConnections)
                    {
                        if (lStates.Contains(lConnection) == false)
                        {
                            throw new ArgumentException("Connected state '" + lConnection + "' of '" + lState + "' does not exist. ");
                        }

                        lConnectedStates.Add(lConnection);
                    }
                }

                lStates.ExceptWith(lConnectedStates);
                if (lStates.Count > 0)
                {
                     foreach (string lState in lStates)
                     {
                        if (lState.Equals(mStates[0], StringComparison.Ordinal) == false)
                        {
                            throw new ArgumentException("State '" + lState + "' is unreachable. This is only allowed for the first state. " );
                        }
                     }
                }
            }

            public void                         clone(CSharpFSM aCSharpFSM)
            {
                using (var lStream = new MemoryStream())
                {
                    var lXMLTextWriter = new XmlTextWriter(lStream, Encoding.UTF8);
                    lXMLTextWriter.WriteStartElement("Properties");
                        aCSharpFSM.saveToXML(lXMLTextWriter);
                    lXMLTextWriter.WriteEndElement();
                    lXMLTextWriter.Flush();

                    lStream.Position = 0;
                    var lXMLTextReader = new XmlTextReader(lStream);
                    lXMLTextReader.Read();

                    loadFromXML(lXMLTextReader);
                }
            }

            public DialogResult                 setupScript(string aStateName, IWin32Window aOwner)
            {
                if (mStateAction.ContainsKey(aStateName) == false)
                {
                    throw new ArgumentException("State '" + aStateName + "' does not exist. ");
                }

                return mStateAction[aStateName].setupByForm(aStateName, aOwner);
            }

            public bool                         isFirstState(string aName)
            {
                if (String.IsNullOrWhiteSpace(aName))
                {
                    throw new ArgumentException("State name is empty. ");
                }

                return (aName.Equals(mStates[0], StringComparison.Ordinal) == false);
            }

            public bool                         isStateExists(string aName)
            {
                if (String.IsNullOrWhiteSpace(aName))
                {
                    throw new ArgumentException("State name is empty. ");
                }

                return mStateAction.ContainsKey(aName);
            }

            public void                         setFirstState(string aName)
            {
                if (String.IsNullOrWhiteSpace(aName))
                {
                    throw new ArgumentException("State name is empty. ");
                }

                if (aName.Equals(mStates[0], StringComparison.Ordinal) == false)
                {
                    mStates.Remove(aName);
                    string lOld = mStates[0];
                    mStates[0] = aName;
                    mStates.Add(lOld);
                }
            }

            public void                         renameState(string aOldName, string aNewName)
            {
                if (String.IsNullOrWhiteSpace(aNewName))
                {
                    throw new ArgumentException("State new name is empty. ");
                }

                if (String.IsNullOrWhiteSpace(aOldName))
                {
                    throw new ArgumentException("State old name is empty. ");
                }

                if(aNewName.Equals(aOldName, StringComparison.Ordinal))
                {
                    throw new ArgumentException("New name of State coincides with the old. ");
                }

                if (mStateAction.ContainsKey(aNewName))
                {
                    throw new ArgumentException("State '" + aNewName + "' already exists. ");
                }

                if (mStateAction.ContainsKey(aOldName) == false)
                {
                    throw new ArgumentException("State '" + aOldName + "' does not exist. ");
                }

                var lScript = mStateAction[aOldName];
                mStateAction.Remove(aOldName);
                mStateAction.Add(aNewName, lScript);
                mStates[mStates.IndexOf(aOldName)] = aNewName;
            }

        #endregion

        #region IItemUser

            private IItemBrowser    mItemBrowser;
            public IItemBrowser     ItemBrowser
            {
                set
                {
                    mItemBrowser = value;
                }
            }

            public int[]            ItemReadHandles
            {
                get
                {
                    return ItemHandles;
                }
            }

            public int[]            ItemWriteHandles
            {
                get
                {
                    return ItemHandles;
                }
            }

            private volatile bool   mValueChanged = false;
            public bool             IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void             getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged = false;
            
                foreach(CSScipt lScript in mStateAction.Values)
                {
                    if(lScript.ValueChanged)
                    {
                        lScript.getItemValues(out aItemHandles, out aItemValues);
                        return;
                    }
                }

                aItemHandles    = new int[] { };
                aItemValues     = new object[] { };
            }

            public void             onItemValueChange(int aItemHandle, object aItemValue)
            {
                if(mItemHandles.ContainsKey(aItemHandle))
                {
                    foreach(string lStateName in mItemHandles[aItemHandle])
                    {
                        mStateAction[lStateName].setItemValue(aItemHandle, aItemValue);
                    }
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[] mPanelList = new string[] { "TextLabel" };
            public string[]         PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel           getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "TextLabel":   return new ObjectTextLabelPanel(this);
                    default:            throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler ChangedValues;
            public void             raiseValuesChanged()
            {
                EventHandler lEvent = ChangedValues;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

            public event EventHandler ChangedProperties;
            public void             raisePropertiesChanged()
            {
                EventHandler lEvent = ChangedProperties;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult     setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult         = lSetupForm.ShowDialog(aOwner);
                    mItemHandles    = null;
                    raisePropertiesChanged();
                }

                return lResult;
            }

            public void             loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader = new XMLAttributeReader(aXMLTextReader);

                if (aXMLTextReader.IsEmptyElement == false)
                {
                    aXMLTextReader.Read();

                    string lStateName;
                    CSScipt lScript;
                    while (aXMLTextReader.Name.Equals("State", StringComparison.Ordinal) && aXMLTextReader.IsStartElement())
                    {
                        lStateName  = lReader.getAttribute<string>("Name");
                        lScript     = new CSScipt(mItemBrowser);
                        try
                        {
                            lScript.loadFromXML(aXMLTextReader);
                        }
                        catch(Exception lExc)
                        {
                            throw new ArgumentException("State '" + lStateName + "'. " + lExc.Message, lExc);
                        }

                        addState(lStateName, lScript);

                        aXMLTextReader.Read();
                        aXMLTextReader.Read();
                    }
                }

                check();
            }

            public void             saveToXML(XmlTextWriter aXMLTextWriter)
            {
                foreach (string lName in mStates)
                {
                    aXMLTextWriter.WriteStartElement("State");
                    aXMLTextWriter.WriteAttributeString("Name", lName);
                        mStateAction[lName].saveToXML(aXMLTextWriter);
                    aXMLTextWriter.WriteEndElement();
                }
            }

            public void             execute()
            {
                if (mCurrentState != null)
                {
                    var lScript = mStateAction[mCurrentState];
                    lScript.execute();
                    mValueChanged = lScript.ValueChanged;
                }
            }

            public void             beforeActivate()
            {
                if(mStates.Count == 0)
                {
                    mCurrentState = null;
                    raiseValuesChanged();
                }
                else
                {
                    mCurrentState = mStates[0];
                    raiseValuesChanged();
                    foreach (CSScipt lScript in mStateAction.Values)
                    {
                        lScript.reset();
                    }
                    mStateAction[mCurrentState].setFirstCycle();
                }
                
            }

            public void             afterDeactivate()
            {
            }

            private string          mLastError;
            public string           LastError
            {
                get { return mLastError; }
            }

            public event EventHandler<MessageStringEventArgs> SimulationObjectError;
            public void             raiseSimulationObjectError(string aMessage)
            {
                mLastError = aMessage;
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
            }

            private void            MCSScript_ScriptException(object aSender, MessageStringEventArgs aEventArgs)
            {
                raiseSimulationObjectError(aEventArgs.Message);
            }

            private void            MCSScript_SwitchToState(object aSender, MessageStringEventArgs aEventArgs)
            {
                if(mStateAction.ContainsKey(aEventArgs.Message))
                {
                    mCurrentState = aEventArgs.Message;
                    raiseValuesChanged();
                    mStateAction[mCurrentState].setFirstCycle();
                }
                else
                {
                    throw new ArgumentException("State '" + aEventArgs.Message + "' does not exist. ");
                }
            }

            public string[]         ContextMenuItemList
            {
                get { return new string[0]; }
            }

            public void             onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {
            }

        #endregion

        #region IDisposable

            private bool            mDisposed = false;

            public void             Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void  Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        clearAllStates();
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
