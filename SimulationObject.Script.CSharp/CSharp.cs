using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils.CSharpScript;

namespace SimulationObject.Script.CSharp
{
    public class CSharp : ISimulationObject
    {
        private CSScipt                                         mCSScript;

        #region IItemUser

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set
                {
                    mItemBrowser = value;

                    if(mCSScript == null)
                    {
                        mCSScript                   = new CSScipt(mItemBrowser);
                        mCSScript.ScriptException   += MCSScript_ScriptException;
                    }
                }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    return mCSScript.ItemHandles;
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return mCSScript.ItemHandles;
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged = false;
                mCSScript.getItemValues(out aItemHandles, out aItemValues);
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                mCSScript.setItemValue(aItemHandle, aItemValue);
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
                return mCSScript.setupByForm("Script.CSharp", aOwner);
            }

            public void                                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                mCSScript.loadFromXML(aXMLTextReader);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                mCSScript.saveToXML(aXMLTextWriter);
            }

            public void                                         execute()
            {
                mCSScript.execute();
                mValueChanged = mCSScript.ValueChanged;
            }

            public void                                         beforeActivate()
            {
                mCSScript.reset();
                mCSScript.setFirstCycle();
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

            private void                                        MCSScript_ScriptException(object aSender, MessageStringEventArgs aEventArgs)
            {
                raiseSimulationObjectError(aEventArgs.Message);
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
                        if(mCSScript != null)
                        {
                            mCSScript.ScriptException -= MCSScript_ScriptException;
                            mCSScript.Dispose();
                            mCSScript = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
