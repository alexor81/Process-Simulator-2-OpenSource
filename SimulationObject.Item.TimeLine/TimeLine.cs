// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Item.TimeLine.Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Snapshot;

namespace SimulationObject.Item.TimeLine
{
    public class TimeLine : ISimulationObject
    {
        public                                  TimeLine()
        {
            mTimer              = new System.Timers.Timer();
            mTimer.Elapsed      += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            mTimer.AutoReset    = true;
        }

        #region Properties

            private bool                        mLoop           = false;
            public bool                         Loop
            {
                get { return mLoop; }
                set
                {
                    if (mLoop != value)
                    {
                        mLoop = value;
                        raisePropertiesChanged();
                    }
                }
            }

        #endregion

        #region IItemUser

            public int                          mOnItemHandle   = -1;
            private bool                        mOnChanged;
            private bool                        mOn             = false;
            public bool                         On
            {
                get { return mOn; }
                set
                {
                    if (mOn != value)
                    {
                        mOn             = value;
                        doOnChange();
                        mOnChanged      = true;
                        mValueChanged   = true;
                        raiseValuesChanged();                      
                    }
                }
            }

            private IItemBrowser                mItemBrowser;
            public IItemBrowser                 ItemBrowser
            {
                get { return mItemBrowser; }
                set { mItemBrowser = value; }
            }

            public int[]                        ItemReadHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    if (mOnItemHandle != -1)
                    {
                        lResult.Add(mOnItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                        UniqueItemHandles
            {
                get
                {
                    HashSet<int> lUniqueItemHandles = new HashSet<int>();

                    int[] lItemHandles;
                    foreach (Tuple<long, Snapshot> lRecord in mSections)
                    {
                        lItemHandles = lRecord.Item2.ItemsHandles;
                        foreach(int lHandle in lItemHandles)
                        {
                            lUniqueItemHandles.Add(lHandle);
                        }
                    }

                    return lUniqueItemHandles.ToArray();
                }
            }

            public int[]                        ItemWriteHandles
            {
                get
                {
                    List<int> lItemHandles = new List<int>();

                    if (mOnItemHandle != -1)
                    {
                        lItemHandles.Add(mOnItemHandle);
                    }

                    lItemHandles.AddRange(UniqueItemHandles);

                    return lItemHandles.ToArray();
                }
            }

            private volatile bool               mValueChanged   = false;
            public bool                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                bool lValueChanged      = mValueChanged;
                mValueChanged           = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                if (mOnItemHandle != -1)
                {
                    if (!lValueChanged || mOnChanged)
                    {
                        mOnChanged = false;
                        lHandles.Add(mOnItemHandle);
                        lValues.Add(mOn);
                    }
                }

                aItemHandles            = lHandles.ToArray();
                aItemValues             = lValues.ToArray();
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
                        doOnChange();
                        raiseValuesChanged();     
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]    mPanelList = new string[] { "TimeLine" };
            public string[]                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "TimeLine":    return new TimeLinePanel(this);
                    default:            throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler           ChangedValues;
            public void                         raiseValuesChanged()
            {
                EventHandler lEvent = ChangedValues;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

            public event EventHandler           ChangedProperties;
            public void                         raisePropertiesChanged()
            {
                EventHandler lEvent = ChangedProperties;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult                 setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                    raisePropertiesChanged();
                }

                return lResult;
            }

            public void                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);

                string lItem = lReader.getAttribute<String>("On", "");
                mOnItemHandle = mItemBrowser.getItemHandleByName(lItem);

                Loop = lReader.getAttribute<Boolean>("Loop", Loop);

                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("Sections", StringComparison.Ordinal))
                {
                    aXMLTextReader.Read();

                    long lInterval;
                    Snapshot lSnapshot;

                    while (aXMLTextReader.Name.Equals("Section", StringComparison.Ordinal) && aXMLTextReader.IsStartElement())
                    {
                        lInterval = lReader.getAttribute<Int64>("DelayMS");
                        lSnapshot = new Snapshot("", mItemBrowser);

                        aXMLTextReader.Read();

                        if (aXMLTextReader.Name.Equals("Record", StringComparison.Ordinal))
                        {
                            lSnapshot.loadFromXML(aXMLTextReader);
                        }

                        mSections.Add(new Tuple<long, Snapshot>(lInterval, lSnapshot));

                        aXMLTextReader.Read();
                    }
                }
            }

            public void                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("On", mItemBrowser.getItemNameByHandle(mOnItemHandle));
                aXMLTextWriter.WriteAttributeString("Loop", StringUtils.ObjectToString(Loop));

                aXMLTextWriter.WriteStartElement("Sections");

                foreach (Tuple<long, Snapshot> lTuple in mSections)
                {
                    aXMLTextWriter.WriteStartElement("Section");
                    aXMLTextWriter.WriteAttributeString("DelayMS", StringUtils.ObjectToString(lTuple.Item1));
                    lTuple.Item2.saveToXML(aXMLTextWriter);
                    aXMLTextWriter.WriteEndElement();
                }

                aXMLTextWriter.WriteEndElement();
            }

            private void                        doOnChange()
            {
                if (mOn == true && mSections.Count > 0)
                {
                    mCurrentStep = 0;
                }
                else
                {
                    mCurrentStep = -1;
                }

                setInterval();
            }

            private System.Timers.Timer         mTimer;
            private void                        setInterval()
            {
                if(mCurrentStep >= mSections.Count)
                {
                    if (mLoop)
                    {
                        mCurrentStep = 0;
                    }
                    else
                    {
                        On = false;
                        return;
                    }
                }

                if (mCurrentStep < 0)
                {
                    mTimer.Stop();
                    return;
                }

                long lInterval = mSections[mCurrentStep].Item1;
                if (lInterval < MiscUtils.TimeSlice)
                {
                    lInterval = MiscUtils.TimeSlice;
                }

                mTimer.Interval = lInterval;

                if (mTimer.Enabled == false)
                {
                    mTimer.Start();
                }
            }

            public List<Tuple<long, Snapshot>>  mSections  = new List<Tuple<long, Snapshot>>();
            
            private volatile int                mCurrentStep    = -1;

            private void                        Timer_Elapsed(object aSender, System.Timers.ElapsedEventArgs aEventArgs)
            {
                if (mCurrentStep >= 0 && mCurrentStep < mSections.Count)
                {
                    mSections[mCurrentStep].Item2.writeSnapshot(false);
                    mCurrentStep = mCurrentStep + 1;
                }
                setInterval();
            }

            public void                         execute()
            {

            }

            public void                         beforeActivate()
            {
                doOnChange();
            }

            public void                         afterDeactivate()
            {
                mCurrentStep = -1;
                setInterval();
            }

            public event EventHandler<MessageStringEventArgs> SimulationObjectError;
            private void                        raiseSimulationObjectError(string aMessage)
            {
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
            }

            public string                       LastError
            {
                get { return ""; }
            }

            public string[]                     ContextMenuItemList
            {
                get
                {
                    return new string[0];
                }
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
