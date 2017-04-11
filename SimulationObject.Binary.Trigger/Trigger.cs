// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Binary.Trigger.Panel;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Panels.BooleanButton;
using Utils.Panels.BooleanCheckBox;
using Utils.Panels.BooleanIndicator;
using Utils.Panels.BooleanToggle;
using Utils.Panels.BooleanTrend;
using Utils.Panels.ObjectDropDownList;
using Utils.Panels.ObjectRadioButtonGroup;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Binary.Trigger
{
    public class Trigger : ISimulationObject, IBooleanValueReadWrite, IObjectValueReadWrite
    {
        #region Properties

            private bool                                        mSR_RS = true;
            public bool                                         SR_RS
            {
                get { return mSR_RS; }
                set
                {
                    if (mSR_RS != value)
                    {
                        mSR_RS = value;                   
                        raisePropertiesChanged();
                        check();
                    }
                }
            }

        #endregion

        #region IItemUser, IBooleanValueReadWrite, IObjectValueReadWrite

            public int                                          mValueItemHandle    = -1;
            private bool                                        mValue;
            public bool                                         ValueBoolean
            { 
                get { return mValue; }
                set
                {
                    mValue = value;
                    check();
                    raiseValuesChanged();
                    mValueChanged = true;
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

            public int                                          mSetItemHandle      = -1;
            public bool                                         mSetValue;

            public int                                          mResetItemHandle    = -1;
            public bool                                         mResetValue;

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    return new int[] { mSetItemHandle, mResetItemHandle, mValueItemHandle };
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return new int[] { mValueItemHandle };
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged   = false;

                aItemHandles    = new int[] { mValueItemHandle };
                aItemValues     = new object[] { mValue };
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mSetItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for trigger 'Set' command. ", lExc);
                    }

                    if (mSetValue != lValue)
                    {
                        mSetValue = lValue;
                        raiseValuesChanged();
                        check();
                    }

                    return;
                }

                if (aItemHandle == mResetItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for trigger 'Reset' command. ", lExc);
                    }

                    if (mResetValue != lValue)
                    {
                        mResetValue = lValue;
                        raiseValuesChanged();
                        check();
                    }

                    return;
                }

                if (aItemHandle == mValueItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Output value conversion error. ", lExc);
                    }

                    if (mValue != lValue)
                    {
                        mValue = lValue;
                        raiseValuesChanged();
                        check();
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Trigger", "Indicator", "Button", "CheckBox", "Trend", "RadioButton", "DropDownList", "TextLabel", "Toggle" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Trigger":         return new TriggerPanel(this);
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
                var lChecker    = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("Set");
                lChecker.addItemName(lItem);
                mSetItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Reset");
                lChecker.addItemName(lItem);
                mResetItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                SR_RS = lReader.getAttribute<Boolean>("SR_RS");
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {                
                aXMLTextWriter.WriteAttributeString("Set", mItemBrowser.getItemNameByHandle(mSetItemHandle));
                aXMLTextWriter.WriteAttributeString("Reset", mItemBrowser.getItemNameByHandle(mResetItemHandle));
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteAttributeString("SR_RS", StringUtils.ObjectToString(SR_RS));
            }

            public void                                         execute()
            {
            }

            public void                                         beforeActivate()
            {
            }

            public void                                         afterDeactivate()
            {
            }

            public void                                         check()
            {
                bool lPrevValue = mValue;

                if (mSR_RS)
                {
                    if (mResetValue && !mSetValue)
                    {
                        mValue = false;
                    }
                    else if (mSetValue)
                    {
                        mValue = true;
                    }
                }
                else
                {
                    if (mSetValue && !mResetValue)
                    {
                        mValue = true;
                    }
                    else if (mResetValue)
                    {
                        mValue = false;
                    }
                }

                if (lPrevValue != mValue)
                {
                    raiseValuesChanged();
                    mValueChanged = true;
                }
            }

            public event EventHandler<MessageStringEventArgs>   SimulationObjectError;
            private void                                        raiseSimulationObjectError(string aMessage)
            {
                mLastError = aMessage;
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            private string                                      mLastError;
            public string                                       LastError
            {
                get { return mLastError; }
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
                    mDisposed = true;
                }
            }

        #endregion
    }
}