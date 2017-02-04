// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace SimulationObject.Item.BitSplitter
{
    public class Splitter : ISimulationObject
    {
        #region Properties

            public EDataFlow                    mDataFlow               = EDataFlow.BOTH;

        #endregion

        #region IItemUser

            public int                          mBitsValueItemHandle    = -1;
            public bool[]                       mBitsValue              = new bool[0];
            private bool                        mBitsValueChanged;
            public int[]                        mBitItemHandles         = new int[0];
            public bool[]                       mBitValueChanged        = new bool[0];

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

                    lResult.Add(mBitsValueItemHandle);
                    for (int i = 0; i < mBitItemHandles.Length; i++)
                    {
                        if (mBitItemHandles[i] != -1) lResult.Add(mBitItemHandles[i]);
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                        ItemWriteHandles
            {
                get
                {
                    return ItemReadHandles;
                }
            }

            private volatile bool               mValueChanged = false;
            public bool                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            private void                        setBitValue(ref ulong aDest, int aIndex, bool aValue)
            {
                ulong lMask = 1UL << aIndex;
                if (aValue)
                {
                    aDest = aDest | lMask;
                }
                else
                {
                    aDest = aDest & ~lMask;
                }
            }

            private bool                        getBitValue(object aSrc, int aIndex)
            {
                return (BinaryConverters.ToUInt64(aSrc) & 1UL << aIndex) > 0;
            }

            private void                        checkType(Type aType)
            {
                if( aType != typeof(Byte) && 
                    aType != typeof(SByte) &&
                    aType != typeof(Int16) &&
                    aType != typeof(UInt16) &&
                    aType != typeof(Int32) &&
                    aType != typeof(UInt32) &&
                    aType != typeof(Int64) &&
                    aType != typeof(UInt64) &&
                    aType != typeof(Single) &&
                    aType != typeof(Double)
                  )
                {
                    throw new ArgumentException("Type is not supported. ");
                }
            }

            public void                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                if (mDataFlow.HasFlag(EDataFlow.TO) && mBitsValueChanged)
                {
                    mBitsValueChanged   = false;
                    object lValueObject = mItemBrowser.readItemOrInitValue(mBitsValueItemHandle);
                    Type lValueType     = lValueObject.GetType();
                    checkType(lValueType);

                    ulong lValueUInt64  = BinaryConverters.ToUInt64(lValueObject);
                    for (int i = 0; i < mBitsValue.Length; i++)
                    {
                        setBitValue(ref lValueUInt64, i, mBitsValue[i]);
                    }
                    
                    lHandles.Add(mBitsValueItemHandle);
                    lValues.Add(BinaryConverters.FromUInt64(lValueType, lValueUInt64));
                }

                if (mDataFlow.HasFlag(EDataFlow.FROM))
                {
                    for (int i = 0; i < mBitItemHandles.Length; i++)
                    {
                        if (mBitValueChanged[i] && mBitItemHandles[i] != -1)
                        {
                            mBitValueChanged[i] = false;
                            lHandles.Add(mBitItemHandles[i]);
                            lValues.Add(mBitsValue[i]);
                        }
                    }
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                bool lNewValue;

                if (mDataFlow.HasFlag(EDataFlow.FROM))
                {
                    if (aItemHandle == mBitsValueItemHandle)
                    {
                        checkType(aItemValue.GetType());

                        for (int i = 0; i < mBitItemHandles.Length; i++)
                        {
                            lNewValue = getBitValue(aItemValue, i);
                            if (lNewValue != mBitsValue[i])
                            {
                                mBitsValue[i] = lNewValue;
                                if (mBitItemHandles[i] != -1)
                                {
                                    mBitValueChanged[i] = true;
                                    mValueChanged       = true;
                                }
                            }
                        }
                        return;
                    }

                    if(mDataFlow.HasFlag(EDataFlow.TO) == false)
                    {
                        for (int i = 0; i < mBitItemHandles.Length; i++)
                        {
                            if (aItemHandle == mBitItemHandles[i])
                            {
                                mBitValueChanged[i] = true;
                                mValueChanged       = true;
                                return;
                            }
                        }
                        
                    }
                }

                if (mDataFlow.HasFlag(EDataFlow.TO))
                {
                    if(mDataFlow.HasFlag(EDataFlow.FROM) == false && aItemHandle == mBitsValueItemHandle)
                    {
                        mBitsValueChanged   = true;
                        mValueChanged       = true;
                        return;
                    }

                    for (int i = 0; i < mBitItemHandles.Length; i++)
                    {
                        if (aItemHandle == mBitItemHandles[i])
                        {
                            lNewValue = Convert.ToBoolean(aItemValue);
                            if (lNewValue != mBitsValue[i])
                            {
                                mBitsValue[i]       = lNewValue;
                                mBitsValueChanged   = true;
                                mValueChanged       = true;
                            }
                            return;
                        }
                    }
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
                }

                return lResult;
            }

            public void                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mBitsValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mDataFlow = (EDataFlow)Enum.Parse(typeof(EDataFlow), lReader.getAttribute<String>("DataFlow", mDataFlow.ToString()));

                #region Bits

                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        aXMLTextReader.Read();
                        if (aXMLTextReader.Name.Equals("Bits", StringComparison.Ordinal))
                        {
                            if (aXMLTextReader.IsEmptyElement == false)
                            {
                                List<int> lIndexes  = new List<int>();
                                List<int> lItems    = new List<int>();
                                var lIndexSet       = new HashSet<int>();
                                int lMaxIndex       = -1;
                                int lIndex;

                                aXMLTextReader.Read();
                                while (aXMLTextReader.Name.Equals("Bit", StringComparison.Ordinal))
                                {
                                    lIndex = (int)lReader.getAttribute<UInt32>("Index");
                                    if (lIndexSet.Add(lIndex) == false)
                                    {
                                        throw new ArgumentException("Bit '" + lIndex.ToString() + "' already exists. ");
                                    }
                                    if (lIndex > 63)
                                    {
                                        throw new ArgumentException("Bit index is too big (max 63). ");
                                    }

                                    lIndexes.Add(lIndex);
                                    if (lIndex > lMaxIndex)
                                    {
                                        lMaxIndex = lIndex;
                                    }

                                    lItem = lReader.getAttribute<String>("Item");
                                    lChecker.addItemName(lItem);
                                    lItems.Add(mItemBrowser.getItemHandleByName(lItem));

                                    aXMLTextReader.Read();
                                }

                                if (lIndexes.Count != 0)
                                {
                                    mBitItemHandles = new int[lMaxIndex + 1];
                                    for (int i = 0; i < mBitItemHandles.Length; i++)
                                    {
                                        mBitItemHandles[i] = -1;
                                    }
                                    mBitValueChanged    = new bool[mBitItemHandles.Length];
                                    mBitsValue          = new bool[mBitItemHandles.Length];

                                    int lCount = lIndexes.Count;
                                    for (int i = 0; i < lCount; i++)
                                    {
                                        lIndex                  = lIndexes[i];
                                        mBitItemHandles[lIndex] = lItems[i];
                                    }
                                }
                            }

                            aXMLTextReader.Read();
                        }
                    }

                #endregion
            }

            public void                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mBitsValueItemHandle));
                aXMLTextWriter.WriteAttributeString("DataFlow", mDataFlow.ToString());

                if (mBitItemHandles.Length > 0)
                {
                    aXMLTextWriter.WriteStartElement("Bits");
                    for (int i = 0; i < mBitItemHandles.Length; i++)
                    {
                        if (mBitItemHandles[i] != -1)
                        {
                            aXMLTextWriter.WriteStartElement("Bit");
                            aXMLTextWriter.WriteAttributeString("Index", StringUtils.ObjectToString(i));
                            aXMLTextWriter.WriteAttributeString("Item", mItemBrowser.getItemNameByHandle(mBitItemHandles[i]));
                            aXMLTextWriter.WriteEndElement();
                        }
                    }
                    aXMLTextWriter.WriteEndElement();
                }
            }

            public void                         execute()
            {
            }

            public void                         beforeActivate()
            {
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
                    mDisposed = true;
                }
            }

        #endregion
    }
}
