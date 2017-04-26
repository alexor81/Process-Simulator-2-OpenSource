// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Binary.Delay.Panels;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
using Utils.Panels.BooleanIndicator;
using Utils.Panels.BooleanTrend;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Binary.Delay
{
    public class Delay : ISimulationObject, IBooleanValueRead, IObjectValueRead
    {
        public                                                  Delay()
        {
            mFSM = new FiniteStateMachine("Switch", () => DelaySwitch());
            mFSM.addState("On", () => DelayOn());
            mFSM.addState("Off", () => DelayOff());
        }

        #region Properties

            private bool                                        mInverse;
            public bool                                         Inverse
            {
                get { return mInverse; }
                set
                { 
                    mInverse = value;
                    raisePropertiesChanged();
                    raiseValuesChanged();
                    mValueChanged = true;
                }
            }

            private uint                                        mOnDelayMS = 0;
            public uint                                         OnDelayMS
            {
                get { return mOnDelayMS; }
                set
                { 
                    mOnDelayMS = value;
                    raisePropertiesChanged();
                }
            }

            private uint                                        mOffDelayMS = 0;
            public uint                                         OffDelayMS
            {
                get { return mOffDelayMS; }
                set
                { 
                    mOffDelayMS = value;
                    raisePropertiesChanged();
                }
            }

        #endregion

        #region IItemUser, IBooleanValueRead, IObjectValueRead

            public int                                          mOutValueItemHandle = -1;
            private bool                                        mOutValue;
            public bool                                         ValueBoolean
            {
                get
                {
                    if (mInverse)
                    {
                        return !mOutValue;
                    }
                    else
                    {
                        return mOutValue;
                    }
                }
            }
            public object                                       ValueObject
            {
                get { return ValueBoolean; }
            }

            public int                                          mInValueItemHandle = -1;
            public bool                                         mInValue;

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    return new int[] { mInValueItemHandle };
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return new int[] { mOutValueItemHandle };
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
                aItemHandles    = new int[] { mOutValueItemHandle };

                aItemValues     = new object[1];
                if (mInverse)
                {
                    aItemValues[0] = !mOutValue;
                }
                else
                {
                    aItemValues[0] = mOutValue;
                }
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mInValueItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value conversion error. ", lExc);
                    }

                    if (mInValue != lValue)
                    {
                        mInValue = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Delay", "Indicator", "Trend", "TextLabel" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Delay":       return new DelayPanel(this);
                    case "Indicator":   return new BooleanIndicatorPanel(this);
                    case "Trend":       return new BooleanTrendPanel(this);
                    case "TextLabel":   return new ObjectTextLabelPanel(this);
                    default:            throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
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

                string lItem = lReader.getAttribute<String>("InputItem");
                lChecker.addItemName(lItem);
                mInValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("OutputItem");
                lChecker.addItemName(lItem);
                mOutValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                Inverse    = lReader.getAttribute<Boolean>("Inverse", Inverse);
                OnDelayMS  = lReader.getAttribute<UInt32>("OnDelayMS", OnDelayMS);
                OffDelayMS = lReader.getAttribute<UInt32>("OffDelayMS", OffDelayMS);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("InputItem", mItemBrowser.getItemNameByHandle(mInValueItemHandle));
                aXMLTextWriter.WriteAttributeString("OutputItem", mItemBrowser.getItemNameByHandle(mOutValueItemHandle));
                aXMLTextWriter.WriteAttributeString("Inverse", StringUtils.ObjectToString(Inverse));
                aXMLTextWriter.WriteAttributeString("OnDelayMS", StringUtils.ObjectToString(OnDelayMS));
                aXMLTextWriter.WriteAttributeString("OffDelayMS", StringUtils.ObjectToString(OffDelayMS));
            }

            private FiniteStateMachine                          mFSM;
            private long                                        mLastMS;
            private void                                        DelaySwitch()
            {
                if (mOutValue == false && mInValue == true)
                {
                    mLastMS = MiscUtils.TimerMS;
                    mFSM.State = "On";
                    return;
                }

                if (mOutValue == true && mInValue == false)
                {
                    mLastMS = MiscUtils.TimerMS;
                    mFSM.State = "Off";
                    return;
                }
            }

            private void                                        DelayOn()
            {
                if (mInverse)
                {
                    if (MiscUtils.TimerMS - mLastMS >= mOffDelayMS)
                    {
                        mOutValue = true;
                    }
                }
                else
                {
                    if (MiscUtils.TimerMS - mLastMS >= mOnDelayMS)
                    {
                        mOutValue = true;
                    }
                }

                if (mOutValue == true || mInValue == false)
                {
                    mFSM.State = "Switch";
                    return;
                }
            }

            private void                                        DelayOff()
            {
                if (mInverse)
                {
                    if (MiscUtils.TimerMS - mLastMS >= mOnDelayMS)
                    {
                        mOutValue = false;
                    }
                }
                else
                {
                    if (MiscUtils.TimerMS - mLastMS >= mOffDelayMS)
                    {
                        mOutValue = false;
                    }
                }

                if (mOutValue == false || mInValue == true)
                {
                    mFSM.State = "Switch";
                    return;
                }
            }

            public void                                         execute()
            {
                bool lLastOutValue = mOutValue;

                mFSM.executeStateAction();

                if (lLastOutValue != mOutValue)
                {
                    raiseValuesChanged();
                    mValueChanged = true;
                }
            }

            public void                                         beforeActivate()
            {
                mFSM.State = "Switch";
            }

            public void                                         afterDeactivate()
            {
            }

            public event EventHandler<MessageStringEventArgs>   SimulationObjectError;
            private void                                        raiseSimulationObjectError(string aMessage)
            {
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            public string                                       LastError
            {
                get { return ""; }
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

            private bool                        mDisposed = false;

            public void                         Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void              Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        if (mFSM != null)
                        {
                            mFSM.Dispose();
                            mFSM = null;
                        }
                    }
                    mDisposed = true;
                }
            }

        #endregion
    }
}
