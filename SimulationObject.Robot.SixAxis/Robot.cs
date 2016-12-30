// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;

namespace SimulationObject.Robot.SixAxis
{
    public class Robot : ISimulationObject
    {
        public                                  Robot()
        {
            mJointFSM   = new FiniteStateMachine[6];
            mLastMS     = new long[6];

            for (int i = 0; i < 6; i++)
            {
                int lIndex = i;
                mJointFSM[i] = new FiniteStateMachine("Stable", () => StableState(lIndex));
                mJointFSM[i].addState("Moving", () => MovingState(lIndex));
            }
        }

        #region Properties

            public double[]                     mMaxSpeed = new double[6] { 10.0D, 10.0D, 10.0D, 10.0D, 10.0D, 10.0D, };

            public double[]                     mMaxAngle = new double[6] { 180.0D, 180.0D, 180.0D, 180.0D, 180.0D, 180.0D };

            public double[]                     mMinAngle = new double[6] { -180.0D, -180.0D, -180.0D, -180.0D, -180.0D, -180.0D };

        #endregion

        #region IItemUser

            public int[]                        mAxisAngleItemHandle    = new int[6] { -1, -1, -1, -1, -1, -1 };
            public double[]                     mAxisAngle              = new double[6];
            private bool[]                      mAxisAngleItemChanged   = new bool[6];

            public int[]                        mAxisSPItemHandle       = new int[6] { -1, -1, -1, -1, -1, -1 };
            public double[]                     mAxisSP                 = new double[6];

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

                    for (int i = 0; i < 6; i++)
                    {
                        if (mAxisAngleItemHandle[i] != -1)
                        {
                            lResult.Add(mAxisAngleItemHandle[i]);
                        }

                        if (mAxisSPItemHandle[i] != -1)
                        {
                            lResult.Add(mAxisSPItemHandle[i]);
                        }
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    for (int i = 0; i < 6; i++)
                    {
                        if (mAxisAngleItemHandle[i] != -1)
                        {
                            lResult.Add(mAxisAngleItemHandle[i]);
                        }
                    }

                    return lResult.ToArray();
                }
            }

            private volatile bool               mValueChanged = false;
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

                for (int i = 0; i < 6; i++)
                {
                    if (mAxisAngleItemHandle[i] != -1)
                    {
                        if (mAxisAngleItemChanged[i] == true || lValueChanged == false)
                        {
                            mAxisAngleItemChanged[i] = false;
                            lHandles.Add(mAxisAngleItemHandle[i]);
                            lValues.Add(mAxisAngle[i]);
                        }
                    }
                }

                aItemHandles            = lHandles.ToArray();
                aItemValues             = lValues.ToArray();
            }

            public void                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (aItemHandle == mAxisAngleItemHandle[i])
                    {
                        double lValue;
                        try
                        {
                            lValue = Convert.ToDouble(aItemValue);
                        }
                        catch (Exception lExc)
                        {
                            Log.Error("Axis angle value conversion error for joint №" + (i + 1).ToString() + ". ", lExc.ToString());
                            mAxisAngleItemChanged[i]    = true;
                            mValueChanged               = true;
                            return;
                        }

                        if (ValuesCompare.NotEqualDelta1.compare(mAxisAngle[i], lValue))
                        {
                            mAxisAngleItemChanged[i]    = true;
                            mValueChanged               = true;
                        }

                        return;
                    }

                    if (aItemHandle == mAxisSPItemHandle[i])
                    {
                        double lValue;
                        try
                        {
                            lValue = Convert.ToDouble(aItemValue);
                        }
                        catch (Exception lExc)
                        {
                            throw new ArgumentException("SetPoint value conversion error for joint №" + (i + 1).ToString() + ". ", lExc);
                        }

                        if (lValue < mMinAngle[i] || lValue > mMaxAngle[i])
                        {
                            throw new ArgumentException("SetPoint for joint №" + (i + 1).ToString() + " is out of range (" + mMinAngle[i].ToString() + ".." + mMaxAngle[i].ToString() + "). ");
                        }

                        if (ValuesCompare.NotEqualDelta1.compare(mAxisSP[i], lValue))
                        {
                            mAxisSP[i] = lValue;
                            raiseValuesChanged();
                        }

                        return;
                    }
                }
            }

        #endregion

        #region RoKiSim

            private IPAddress                   mIP;
            private int                         mPort;
            private byte[]                      mBuffer;

            private volatile bool               mSendData           = false;
            public bool                         SendData
            {
                get { return mSendData; }
                set
                {
                    mSendData = value;

                    if (mSendData)
                    {
                        if (mIP == null)
                        {
                            mIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
                            mPort = 2001;

                            mBuffer = new byte[56];
                            mBuffer[3] = 6;
                            mBuffer[7] = 1;

                            mSendTimer = new System.Timers.Timer(mUpdateRoKiSimMS);
                            mSendTimer.Elapsed += new ElapsedEventHandler(Send);
                            mSendTimer.AutoReset = false;
                        }

                        mSendTimer.Start();
                    }
                    else
                    {
                        mLastSendResult = true;
                    }
                }
            }

            private int                         mUpdateRoKiSimMS    = 50;
            public int                          UpdateRoKiSimMS
            {
                get { return mUpdateRoKiSimMS; }
                set
                {
                    int lValue = value;

                    if (lValue < 15) 
                    {
                        lValue = 15;
                    }
                    else if (lValue > 1000)
                    {
                        lValue = 1000;
                    }

                    if (mUpdateRoKiSimMS != lValue)
                    {
                        mUpdateRoKiSimMS = lValue;
                        if (mSendTimer != null)
                        {
                            mSendTimer.Interval = mUpdateRoKiSimMS;
                        }
                    }
                }
            }

            private bool                        mLastSendResult     = true;

            private System.Timers.Timer         mSendTimer;

            private volatile bool               mNewData            = true;

            private void                        Send(object aSender, ElapsedEventArgs aEventArgs)
            {
                if (mSendData)
                {
                    if (mNewData)
                    {
                        mNewData = false;

                        Socket lSocket = new Socket(mIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            lSocket.Connect(mIP, mPort);
                            byte[] lValue;
                            int lIndex = 8;

                            for (int i = 0; i < 6; i++)
                            {
                                lValue = BitConverter.GetBytes(mAxisAngle[i]);
                                Array.Reverse(lValue);
                                Array.Copy(lValue, 0, mBuffer, lIndex, 8);
                                lIndex = lIndex + 8;
                            }

                            lSocket.Send(mBuffer);
                            lSocket.Disconnect(true);

                            mLastSendResult = true;
                        }
                        catch (Exception lExc)
                        {
                            if (mLastSendResult)
                            {
                                Log.Error("Error sending data to RoKiSim. " + lExc.Message, lExc.ToString());
                                mLastSendResult = false;
                            }
                        }
                        finally
                        {
                            lSocket.Dispose();
                            lSocket = null;
                        }
                    }

                    if (mSendData) mSendTimer.Start();
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]    mPanelList = new string[] { };
            public string[]                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    default: throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
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
                var lChecker    = new RepeatItemNameChecker();

                SendData        = lReader.getAttribute<Boolean>("SendData", SendData);
                UpdateRoKiSimMS = (int)lReader.getAttribute<UInt32>("UpdateRoKiSimMS", (uint)UpdateRoKiSimMS);

                if (aXMLTextReader.IsEmptyElement == false)
                {
                    aXMLTextReader.Read();
                    if (aXMLTextReader.Name.Equals("Joints", StringComparison.Ordinal))
                    {
                        if (aXMLTextReader.IsEmptyElement == false)
                        {
                            var lIndexSet = new HashSet<int>();
                            int lIndex;
                            int lArrayIndex;
                            string lItem;

                            aXMLTextReader.Read();
                            while (aXMLTextReader.Name.Equals("Joint", StringComparison.Ordinal))
                            {
                                lIndex = (int)lReader.getAttribute<UInt32>("Index");

                                if(lIndex == 0 || lIndex > 6)
                                {
                                    throw new ArgumentException("Wrong joint number. ");
                                }

                                if (lIndexSet.Add(lIndex) == false)
                                {
                                    throw new ArgumentException("Joint №" + lIndex.ToString() + " already exists. ");
                                }

                                lArrayIndex = lIndex - 1;

                                lItem = lReader.getAttribute<String>("SetPointItem", "");
                                lChecker.addItemName(lItem);
                                mAxisSPItemHandle[lArrayIndex] = mItemBrowser.getItemHandleByName(lItem);

                                mMaxSpeed[lArrayIndex] = lReader.getAttribute<Double>("MaxSpeed", mMaxSpeed[lArrayIndex]);
                                if (mMaxSpeed[lArrayIndex] <= 0.0D)
                                {
                                    throw new ArgumentException("Maximum speed of joint №" + lIndex.ToString() + " must be greater than zero. ");
                                }

                                lItem = lReader.getAttribute<String>("AngleItem", "");
                                lChecker.addItemName(lItem);
                                mAxisAngleItemHandle[lArrayIndex] = mItemBrowser.getItemHandleByName(lItem);

                                mMaxAngle[lArrayIndex] = lReader.getAttribute<Double>("MaxAngle", mMaxAngle[lArrayIndex]);
                                mMinAngle[lArrayIndex] = lReader.getAttribute<Double>("MinAngle", mMinAngle[lArrayIndex]);
                                if (mMaxAngle[lArrayIndex] <= mMinAngle[lArrayIndex])
                                {
                                    throw new ArgumentException("The maximum angle of joint №" + lIndex.ToString() + " has to be greater than minimum. ");
                                }

                                aXMLTextReader.Read();
                            }
                        }

                        aXMLTextReader.Read();
                    }
                }
            }

            public void                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("SendData", StringUtils.ObjectToString(SendData));
                aXMLTextWriter.WriteAttributeString("UpdateRoKiSimMS", StringUtils.ObjectToString(UpdateRoKiSimMS));

                aXMLTextWriter.WriteStartElement("Joints");
                for (int i = 0; i < 6; i++)
                {
                    aXMLTextWriter.WriteStartElement("Joint");
                    aXMLTextWriter.WriteAttributeString("Index", StringUtils.ObjectToString(i + 1));
                    aXMLTextWriter.WriteAttributeString("SetPointItem", mItemBrowser.getItemNameByHandle(mAxisSPItemHandle[i]));
                    aXMLTextWriter.WriteAttributeString("MaxSpeed", StringUtils.ObjectToString(mMaxSpeed[i]));
                    aXMLTextWriter.WriteAttributeString("AngleItem", mItemBrowser.getItemNameByHandle(mAxisAngleItemHandle[i]));
                    aXMLTextWriter.WriteAttributeString("MaxAngle", StringUtils.ObjectToString(mMaxAngle[i]));
                    aXMLTextWriter.WriteAttributeString("MinAngle", StringUtils.ObjectToString(mMinAngle[i]));
                    aXMLTextWriter.WriteEndElement();
                }
                aXMLTextWriter.WriteEndElement();
            }

            private FiniteStateMachine[]        mJointFSM;
            private long[]                      mLastMS;
            private void                        StableState(int i)
            {
                if (ValuesCompare.NotEqualDelta1.compare(mAxisAngle[i], mAxisSP[i]))
                {
                    mLastMS[i]          = MiscUtils.TimerMS;
                    mJointFSM[i].State  = "Moving";
                }
            }
            private void                        MovingState(int i)
            {
                if (ValuesCompare.EqualDelta1.compare(mAxisAngle[i], mAxisSP[i]))
                {
                    mJointFSM[i].State  = "Stable";
                }

                double lDeltaAngle = mMaxSpeed[i] * (double)(MiscUtils.TimerMS - mLastMS[i]) / 1000D;

                if (mAxisAngle[i] < mAxisSP[i])
                {
                    mAxisAngle[i] = mAxisAngle[i] + lDeltaAngle;
                    if (mAxisAngle[i] > mAxisSP[i])
                    {
                        mAxisAngle[i] = mAxisSP[i];
                    }
                }
                else
                {
                    mAxisAngle[i] = mAxisAngle[i] - lDeltaAngle;
                    if (mAxisAngle[i] < mAxisSP[i])
                    {
                        mAxisAngle[i] = mAxisSP[i];
                    }
                }

                mAxisAngleItemChanged[i]    = true;
                mLastMS[i]                  = MiscUtils.TimerMS;
            }
            
            public void                         execute()
            {
                for (int i = 0; i < 6; i++)
                {
                    mJointFSM[i].executeStateAction();
                }

                for (int i = 0; i < 6; i++)
                {
                    if (mAxisAngleItemChanged[i] == true)
                    {
                        mNewData = true;
                        raiseValuesChanged();
                        break;
                    }
                }

                bool lUpdate = false;
                for (int i = 0; i < 6; i++)
                {
                    if (mAxisAngleItemChanged[i] == true)
                    {
                        if (mAxisAngleItemHandle[i] != -1)
                        {
                            lUpdate = true;
                        }
                        else
                        {
                            mAxisAngleItemChanged[i] = false;
                        }
                    }
                }

                if (lUpdate)
                {
                    mValueChanged = true;         
                }
            }

            public void                         beforeActivate()
            {
                mNewData = true;
                for (int i = 0; i < 6; i++)
                {
                    mJointFSM[i].State = "Stable";
                }
            }

            public void                         afterDeactivate()
            {
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
                    return new string[] { };
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
                        for(int i = 0; i < mJointFSM.Length; i++)
                        {
                            mJointFSM[i].Dispose();
                            mJointFSM[i] = null;
                        }

                        if (mSendTimer != null)
                        {
                            mSendTimer.Dispose();
                            mSendTimer = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
