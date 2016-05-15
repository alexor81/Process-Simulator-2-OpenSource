using API;
using SimulationObject.Item.WriteToFile.Panel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace SimulationObject.Item.WriteToFile
{
    public class WriteToFile : ISimulationObject
    {
        public                          WriteToFile()
        {
            mTimer              = new System.Timers.Timer();
            mTimer.Elapsed      += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            mTimer.AutoReset    = false;
            mTimer.Interval     = 1000;
        }

        #region Properties

            public string               mPath               = "";
            public string               mFileName           = "ItemValues";
            public string               mDelimiter          = ",";
            public bool                 mWriteChangesOnly   = true;

            private int                 mRateMS             = 1000;
            public int                  RateMS
            {
                get { return mRateMS; }
                set
                {
                    if(mRateMS != value)
                    {
                        if(value < MiscUtils.TimeSlice)
                        {
                            mRateMS = MiscUtils.TimeSlice;
                        }
                        else
                        { 
                            mRateMS = value;
                        }
                    }
                }
            }

        #endregion

        #region IItemUser

            public int                  mOnItemHandle   = -1;
            private bool                mOnChanged;
            private bool                mOn             = false;
            public bool                 On
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
                        evaluateState();
                    }
                }
            }

            public int[]                mItems          = new int[] { };
            private bool[]              mItemsChanged   = new bool[] { };
            private object[]            mItemsValues    = new object[] { };
            public void                 initItems(int[] aItems)
            {
                mItems          = aItems;
                mItemsChanged   = new bool[aItems.Length];
                mItemsValues    = new object[aItems.Length];
            }

            private IItemBrowser        mItemBrowser;
            public IItemBrowser         ItemBrowser
            {
                get { return mItemBrowser; }
                set { mItemBrowser = value; }
            }

            public int[]                ItemReadHandles
            {
                get
                {
                    List<int> lItemHandles = new List<int>();

                    if (mOnItemHandle != -1)
                    {
                        lItemHandles.Add(mOnItemHandle);
                    }

                    lItemHandles.AddRange(mItems);

                    return lItemHandles.ToArray();
                }
            }

            public int[]                ItemWriteHandles
            {
                get
                {
                    List<int> lItemHandles = new List<int>();

                    if (mOnItemHandle != -1)
                    {
                        lItemHandles.Add(mOnItemHandle);
                    }

                    return lItemHandles.ToArray();
                }
            }

            private volatile bool       mValueChanged = false;
            public bool                 IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                 getItemValues(out int[] aItemHandles, out object[] aItemValues)
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

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                 onItemValueChange(int aItemHandle, object aItemValue)
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
                        evaluateState();
                    }

                    return;
                }

                for(int i = 0; i < mItems.Length; i++)
                {
                    if(aItemHandle == mItems[i])
                    {
                        mItemsChanged[i]    = true;
                        mItemsValues[i]     = aItemValue;
                        return;
                    }
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[] mPanelList = new string[] { "WriteToFile" };
            public string[]             PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel               getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "WriteToFile": return new WriteToFilePanel(this);
                    default:            throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler   ChangedValues;
            public void                 raiseValuesChanged()
            {
                EventHandler lEvent = ChangedValues;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

            public event EventHandler   ChangedProperties;
            public void                 raisePropertiesChanged()
            {
                EventHandler lEvent = ChangedProperties;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

        #endregion

        #region ISimulationObject

            public DialogResult         setupByForm(IWin32Window aOwner)
            {
                DialogResult lResult;

                using (var lSetupForm = new SetupForm(this, mItemBrowser))
                {
                    lResult = lSetupForm.ShowDialog(aOwner);
                    raisePropertiesChanged();
                }

                return lResult;
            }

            public void                 loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);

                string lItem    = lReader.getAttribute<String>("On", "");
                mOnItemHandle   = mItemBrowser.getItemHandleByName(lItem);

                mPath           = lReader.getAttribute<String>("Path", "");
                if(String.IsNullOrWhiteSpace(mPath) == false)
                {
                    if(Directory.Exists(mPath) == false)
                    {
                        throw new ArgumentException("Path does not exist. ");
                    }
                }

                mFileName           = lReader.getAttribute<String>("FileName", mFileName);
                RateMS              = (int)lReader.getAttribute<UInt32>("Rate", (uint)RateMS);
                mWriteChangesOnly   = lReader.getAttribute<Boolean>("WriteChangesOnly", mWriteChangesOnly);
                mDelimiter          = lReader.getAttribute<String>("Delimiter", mDelimiter);

                HashSet<int> lItems = new HashSet<int>();
                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("Items", StringComparison.Ordinal))
                {
                    aXMLTextReader.Read();

                    int lHandle;
                    string lItemName;

                    while (aXMLTextReader.Name.Equals("Item", StringComparison.Ordinal) && aXMLTextReader.IsStartElement())
                    {
                        lItemName   = lReader.getAttribute<String>("Name");
                        lHandle     = mItemBrowser.getItemHandleByName(lItemName);

                        if (lItems.Contains(lHandle))
                        {
                            throw new ArgumentException("Item '" + lItemName + "' already exists. ");
                        }

                        lItems.Add(lHandle);
                        aXMLTextReader.Read();
                    }
                }

                if(lItems.Count != 0)
                {
                    initItems(lItems.ToArray());
                }
            }

            public void                 saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("On", mItemBrowser.getItemNameByHandle(mOnItemHandle));
                aXMLTextWriter.WriteAttributeString("Path", mPath);
                aXMLTextWriter.WriteAttributeString("FileName", mFileName);
                aXMLTextWriter.WriteAttributeString("Rate", StringUtils.ObjectToString(RateMS));
                aXMLTextWriter.WriteAttributeString("WriteChangesOnly", StringUtils.ObjectToString(mWriteChangesOnly));
                aXMLTextWriter.WriteAttributeString("Delimiter", mDelimiter);

                aXMLTextWriter.WriteStartElement("Items");
                foreach(int lHandle in mItems)
                {
                    aXMLTextWriter.WriteStartElement("Item");
                    aXMLTextWriter.WriteAttributeString("Name", mItemBrowser.getItemNameByHandle(lHandle));
                    aXMLTextWriter.WriteEndElement();
                }
                aXMLTextWriter.WriteEndElement();
            }

            public void                 execute()
            {
            }

            private bool                mActive = false;
            public void                 beforeActivate()
            {
                mActive = true;
                evaluateState();
            }
            public void                 afterDeactivate()
            {
                mActive = false;
                evaluateState();
            }

            private volatile bool       mState = false;
            private StreamWriter        mStreamWriter;
            private void                evaluateState()
            {
                bool lPrevState = mState;
                mState          = mActive && mOn;

                if (lPrevState != mState)
                {
                    if (mState)
                    {
                        string lFile;

                        if(String.IsNullOrWhiteSpace(mPath))
                        {
                            lFile = MiscUtils.ProjectPath;
                        }
                        else
                        {
                            lFile = mPath;
                        }

                        lFile = lFile + "\\" + mFileName;

                        if (File.Exists(lFile + ".csv"))
                        {
                            int lNum = 1;
                            while(File.Exists(lFile + "_" + lNum.ToString() + ".csv"))
                            {
                                lNum = lNum + 1;
                            }
                            lFile = lFile + "_" + lNum.ToString();
                        }
                        lFile = lFile + ".csv";

                        try
                        { 
                            mStreamWriter = new StreamWriter(lFile);
                        }
                        catch(Exception lExc)
                        {
                            raiseSimulationObjectError("Unable to create file '" + lFile + "'. " + lExc.Message);
                        }

                        writeValues();

                        mTimer.Interval = MiscUtils.TimeSlice;
                        mTimer.Start();
                    }
                    else
                    {
                        mTimer.Stop();
                        if(mStreamWriter != null)
                        {
                            mStreamWriter.Close();
                            mStreamWriter = null;
                        }
                    }
                }
            }
            
            private System.Timers.Timer mTimer;
            private void                Timer_Elapsed(object aSender, System.Timers.ElapsedEventArgs aEventArgs)
            {
                if (mState == false) return;

                long lStartMS = MiscUtils.TimerMS;

                if(mWriteChangesOnly)
                {
                    writeChangedValues();
                }
                else
                {
                    writeValues();
                }

                if(mState)
                {
                    int lSleepTime = mRateMS - (int)(MiscUtils.TimerMS - lStartMS);
                    if (lSleepTime < 1 | lSleepTime > mRateMS) lSleepTime = 1;
                    mTimer.Interval = lSleepTime;
                    mTimer.Start();
                }
            }

            private void                writeValues()
            {
                try
                {
                    if (mItems.Length > 0)
                    {
                        string lDateTime = StringUtils.ObjectToString(DateTime.Now);

                        if (mItems.Length == 1)
                        {
                            if (mItemsValues[0] != null)
                            {
                                mItemsChanged[0] = false;
                                mStreamWriter.Write(lDateTime);
                                mStreamWriter.Write(mDelimiter);
                                mStreamWriter.WriteLine(StringUtils.ObjectToString(mItemsValues[0]));
                            }
                        }
                        else
                        {
                            for (int i = 0; i < mItems.Length; i++)
                            {
                                if (mItemsValues[i] != null)
                                {
                                    mItemsChanged[i] = false;
                                    mStreamWriter.Write(lDateTime);
                                    mStreamWriter.Write(mDelimiter);
                                    mStreamWriter.Write(mItemBrowser.getItemNameByHandle(mItems[i]));
                                    mStreamWriter.Write(mDelimiter);
                                    mStreamWriter.WriteLine(StringUtils.ObjectToString(mItemsValues[i]));
                                }
                            }
                        }
                    }
                }
                catch(Exception lExc)
                {
                    raiseSimulationObjectError("Unable to write values. " + lExc.Message);
                }
            }
            
            private void                writeChangedValues()
            {
                try
                {
                    if (mItems.Length > 0)
                    {
                        string lDateTime = StringUtils.ObjectToString(DateTime.Now);

                        if (mItems.Length == 1)
                        {
                            if(mItemsChanged[0] && mItemsValues[0] != null)
                            { 
                                mItemsChanged[0] = false;
                                mStreamWriter.Write(lDateTime);
                                mStreamWriter.Write(mDelimiter);
                                mStreamWriter.WriteLine(StringUtils.ObjectToString(mItemsValues[0]));
                            }
                        }
                        else
                        {
                            for (int i = 0; i < mItems.Length; i++)
                            {
                                if (mItemsChanged[i] && mItemsValues[i] != null)
                                {
                                    mItemsChanged[i] = false;
                                    mStreamWriter.Write(lDateTime);
                                    mStreamWriter.Write(mDelimiter);
                                    mStreamWriter.Write(mItemBrowser.getItemNameByHandle(mItems[i]));
                                    mStreamWriter.Write(mDelimiter);
                                    mStreamWriter.WriteLine(StringUtils.ObjectToString(mItemsValues[i]));
                                }
                            }
                        }
                    }
                }
                catch (Exception lExc)
                {
                    raiseSimulationObjectError("Unable to write values. " + lExc.Message);
                }
            }

            public event EventHandler<MessageStringEventArgs> SimulationObjectError;
            private void                raiseSimulationObjectError(string aMessage)
            {
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
            }

            public string               LastError
            {
                get { return ""; }
            }

            public string[]             ContextMenuItemList
            {
                get
                {
                    return new string[] { };
                }
            }

            public void                 onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
            {

            }

        #endregion

        #region IDisposable

            private bool                mDisposed = false;

            public void                 Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void      Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        if(mTimer != null)
                        {
                            mTimer.Dispose();
                            mTimer = null;
                        }

                        if(mStreamWriter != null)
                        {
                            mStreamWriter.Close();
                            mStreamWriter = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}