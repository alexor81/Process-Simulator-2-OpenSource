// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils.CSharpScript;
using Utils.Panels.BooleanButton;
using Utils.Panels.BooleanCheckBox;
using Utils.Panels.BooleanIndicator;
using Utils.Panels.BooleanToggle;
using Utils.Panels.BooleanTrend;
using Utils.Panels.ObjectDropDownList;
using Utils.Panels.ObjectRadioButtonGroup;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Script.CSharp
{
    public class CSharp : ISimulationObject, IBooleanValueReadWrite, IObjectValueReadWrite
    {
        private CSScript mCSScript;

        #region IItemUser, IBooleanValueReadWrite, IObjectValueReadWrite

            public bool                                         ValueBoolean
            {
                get
                {
                    return mCSScript.On;
                }
                set
                {
                    if (mCSScript.On != value)
                    {
                        mCSScript.On = value;
                    }
                }
            }
            public object                                       ValueObject
            {
                get { return ValueBoolean; }
                set
                {
                    try
                    {
                        ValueBoolean = Convert.ToBoolean(value);
                    }
                    catch (Exception lExc)
                    {
                        raiseSimulationObjectError(lExc.Message);
                    }
                }
            }

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set
                {
                    mItemBrowser = value;

                    if(mCSScript == null)
                    {
                        mCSScript                   = new CSScript(mItemBrowser);
                        mCSScript.ScriptException   += MCSScript_ScriptException;
                        mCSScript.OnChanged         += MCSScript_OnChanged;
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

            private static readonly string[]                    mPanelList = new string[] { "Indicator", "Button", "CheckBox", "Trend", "RadioButton", "DropDownList", "TextLabel", "Toggle" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Indicator":       return new BooleanIndicatorPanel(this);
                    case "Button":          return new BooleanButtonPanel(this);
                    case "CheckBox":        return new BooleanCheckBoxPanel(this);
                    case "Trend":           return new BooleanTrendPanel(this);
                    case "RadioButton":     return new RadioButtonGroupPanel(this);
                    case "DropDownList":    return new DropDownListPanel(this);
                    case "TextLabel":       return new ObjectTextLabelPanel(this);
                    case "Toggle":          return new BooleanTogglePanel(this);
                    default:                throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler                           ChangedValues;
            public void                                         raiseValuesChanged()
            {
                ChangedValues?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler                           ChangedProperties;
            public void                                         raisePropertiesChanged()
            {
                ChangedProperties?.Invoke(this, EventArgs.Empty);
            }

            private void                                        MCSScript_OnChanged(object aSender, EventArgs aEventArgs)
            {
                raiseValuesChanged();
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
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
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
                            mCSScript.OnChanged       -= MCSScript_OnChanged;
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
