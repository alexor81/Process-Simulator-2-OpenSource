// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Item.Delay.Panel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Item.Delay
{
    public class Delay : ISimulationObject, IObjectValueRead
    {
        public                                  Delay()
        {
            mTimer              = new System.Timers.Timer();
            mTimer.Elapsed      += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            mTimer.AutoReset    = true;
        }

        #region Properties

            private uint                        mDelayMS            = 0;
            public uint                         DelayMS
            {
                get { return mDelayMS; }
                set
                {
                    mDelayMS = value;
                    raisePropertiesChanged();
                }
            }

        #endregion

        #region IItemUser, IObjectValueRead

            public int                          mOnItemHandle       = -1;
            private bool                        mOnChanged;
            private bool                        mOn = true;
            public bool                         On
            {
                get { return mOn; }
                set
                {
                    if (mOn != value)
                    {
                        mOn             = value;
                        mOnChanged      = true;
                        mValueChanged   = true;
                        raiseValuesChanged();
                        push();
                        correctInterval();
                    }
                }
            }

            public int                          mOutValueItemHandle = -1;
            private object                      mOutValue;
            public object                       ValueObject
            {
                get { return mOutValue; }
                set
                {
                    mOutValue = value;
                    raiseValuesChanged();
                }
            }

            public int                          mInValueItemHandle  = -1;
            public object                       mInValue;
            public object                       InValue
            {
                get { return mInValue; }
            }

            private IItemBrowser                mItemBrowser;
            public IItemBrowser                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                        ItemReadHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    lResult.Add(mInValueItemHandle);

                    if (mOnItemHandle != -1)
                    {
                        lResult.Add(mOnItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    lResult.Add(mOutValueItemHandle);

                    if (mOnItemHandle != -1)
                    {
                        lResult.Add(mOnItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            private volatile bool               mValueChanged       = false;
            public bool                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                bool lValueChanged  = mValueChanged;
                mValueChanged       = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                if (mOutValue != null)
                {
                    lHandles.Add(mOutValueItemHandle);
                    lValues.Add(mOutValue);
                }

                if (mOnItemHandle != -1)
                {
                    if (!lValueChanged || mOnChanged)
                    {
                        mOnChanged = false;
                        lHandles.Add(mOnItemHandle);
                        lValues.Add(mOn);
                    }
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mOnItemHandle)
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

                    if (mOn != lValue)
                    {
                        mOn = lValue;
                        raiseValuesChanged();
                        push();
                        correctInterval();
                    }

                    return;
                }

                if (aItemHandle == mInValueItemHandle)
                {
                    if (ValuesCompare.isNotEqual(aItemValue, mInValue))
                    {
                        mInValue = aItemValue;
                        raiseValuesChanged();
                        push();
                        correctInterval();
                    }
                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]    mPanelList = new string[] { "Delay", "TextLabel" };
            public string[]                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Delay":       return new DelayPanel(this);
                    case "TextLabel":   return new ObjectTextLabelPanel(this);
                    default:            throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler           ChangedValues;
            public void                         raiseValuesChanged()
            {
                ChangedValues?.Invoke(this, EventArgs.Empty);
            }

            public event EventHandler           ChangedProperties;
            public void                         raisePropertiesChanged()
            {
                ChangedProperties?.Invoke(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult                 setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

            public void                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("On", "");
                lChecker.addItemName(lItem);
                mOnItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("InputItem");
                lChecker.addItemName(lItem);
                mInValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("OutputItem");
                lChecker.addItemName(lItem);
                mOutValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                DelayMS = lReader.getAttribute<UInt32>("DelayMS", DelayMS);
            }

            public void                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("On", mItemBrowser.getItemNameByHandle(mOnItemHandle));
                aXMLTextWriter.WriteAttributeString("InputItem", mItemBrowser.getItemNameByHandle(mInValueItemHandle));
                aXMLTextWriter.WriteAttributeString("OutputItem", mItemBrowser.getItemNameByHandle(mOutValueItemHandle));
                aXMLTextWriter.WriteAttributeString("DelayMS", StringUtils.ObjectToString(DelayMS));
            }

            private Queue<long>                 mTimeMS = new Queue<long>();
            private Queue<object>               mValues = new Queue<object>();

            private void                        push()
            {
                if (mOn)
                {
                    lock (mTimeMS)
                    {
                        mTimeMS.Enqueue(MiscUtils.TimerMS);
                        mValues.Enqueue(mInValue);
                    }
                }
            }

            private void                        clearBuff()
            {
                lock (mTimeMS)
                {
                    mTimeMS.Clear();
                    mValues.Clear();  
                }
            }

            private object                      pop()
            {
                object lValue = null;

                lock (mTimeMS)
                {
                    if (mTimeMS.Count != 0)
                    {
                        while (mTimeMS.Count > 0)
                        {
                            if (mTimeMS.Peek() + mDelayMS <= MiscUtils.TimerMS)
                            {
                                mTimeMS.Dequeue();
                                lValue = mValues.Dequeue();
                                continue;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                return lValue;
            }

            private System.Timers.Timer         mTimer;
            private void                        correctInterval()
            {
                long lInterval = MiscUtils.TimeSlice;

                lock (mTimeMS)
                {
                    if (mTimeMS.Count != 0)
                    {
                        lInterval = mTimeMS.Peek() + mDelayMS - MiscUtils.TimerMS;
                        if (lInterval < MiscUtils.TimeSlice) lInterval = MiscUtils.TimeSlice;
                    }
                }

                mTimer.Interval = lInterval;
            }

            private void                        Timer_Elapsed(object aSender, System.Timers.ElapsedEventArgs aEventArgs)
            {
                object lValue = pop();

                if (lValue != null)
                {
                    ValueObject = lValue;

                    try
                    {
                        mItemBrowser.writeItemValue(mOutValueItemHandle, lValue);
                    }
                    catch
                    {
                        mValueChanged = true;
                    }
                }

                correctInterval();
            }

            public void                         execute()
            {
            }

            public void                         beforeActivate()
            {
                if (DelayMS < MiscUtils.TimeSlice)
                {
                    mTimer.Interval = MiscUtils.TimeSlice;
                }
                else
                {
                    mTimer.Interval = DelayMS;
                }
                mTimer.Start();
            }

            public void                         afterDeactivate()
            {
                mTimer.Stop();
            }

            public event EventHandler<MessageStringEventArgs> SimulationObjectError;
            private void                        raiseSimulationObjectError(string aMessage)
            {
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            public string                       LastError
            {
                get { return ""; }
            }

            public string[]                     ContextMenuItemList
            {
                get { return new string[0]; }
            }

            public void                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
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
                        clearBuff();

                        if (mTimer != null)
                        {
                            mTimer.Dispose();
                            mTimer = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
