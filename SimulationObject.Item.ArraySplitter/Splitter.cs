// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace SimulationObject.Item.ArraySplitter
{
    public class Splitter : ISimulationObject
    {
        #region Properties

            public EDataFlow                    mDataFlow               = EDataFlow.BOTH;

        #endregion

        #region IItemUser

            public int                          mArrayValueItemHandle   = -1;
            public object[]                     mArrayValue             = new object[0];
            private bool                        mArrayValueChanged;
            public int[]                        mElementItemHandles     = new int[0];
            public bool[]                       mElementValueChanged    = new bool[0];

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

                    lResult.Add(mArrayValueItemHandle);
                    for (int i = 0; i < mElementItemHandles.Length; i++)
                    {
                        if (mElementItemHandles[i] != -1) lResult.Add(mElementItemHandles[i]);
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

            public void                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged = false;

                List<int> lHandles      = new List<int>();
                List<object> lValues    = new List<object>();

                if (mDataFlow.HasFlag(EDataFlow.TO) && mArrayValueChanged)
                {
                    mArrayValueChanged  = false;
                    object lValue       = mItemBrowser.readItemOrInitValue(mArrayValueItemHandle);
                    Type lType;
                    Array lArray = lValue as Array;
                    if (lArray != null)
                    {
                        lType = lArray.GetType().GetElementType();
                        if (lArray.Length < mArrayValue.Length)
                        {
                            lArray = Array.CreateInstance(lType, mArrayValue.Length);
                        }
                    }
                    else
                    {
                        lType   = lValue.GetType();
                        lArray  = Array.CreateInstance(lType, mArrayValue.Length);
                    }

                    for (int i = 0; i < mArrayValue.Length; i++)
                    {
                        lArray.SetValue(MiscUtils.convertValue(lType, mArrayValue[i]), i);
                    }

                    lHandles.Add(mArrayValueItemHandle);
                    lValues.Add(lArray);
                }

                if (mDataFlow.HasFlag(EDataFlow.FROM))
                {
                    for (int i = 0; i < mElementItemHandles.Length; i++)
                    {
                        if (mElementValueChanged[i] == true && mElementItemHandles[i] != -1 && mArrayValue[i] != null)
                        {
                            mElementValueChanged[i] = false;
                            lHandles.Add(mElementItemHandles[i]);
                            lValues.Add(mArrayValue[i]);
                        }
                    }
                }

                aItemHandles    = lHandles.ToArray();
                aItemValues     = lValues.ToArray();
            }

            public void                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (mArrayValue.Length == 0) return;

                if (mDataFlow.HasFlag(EDataFlow.FROM))
                {
                    if (aItemHandle == mArrayValueItemHandle)
                    {
                        Array lArray = aItemValue as Array;

                        if (lArray != null)
                        {
                            for (int i = 0; i < lArray.Length; i++)
                            {
                                if (i == mArrayValue.Length) return;

                                if (ValuesCompare.isNotEqual(lArray.GetValue(i), mArrayValue[i]))
                                {
                                    mArrayValue[i] = lArray.GetValue(i);
                                    if (mElementItemHandles[i] != -1)
                                    {
                                        mElementValueChanged[i] = true;
                                        mValueChanged           = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (ValuesCompare.isNotEqual(aItemValue, mArrayValue[0]))
                            {
                                mArrayValue[0] = aItemValue;
                                if (mElementItemHandles[0] != -1)
                                {
                                    mElementValueChanged[0] = true;
                                    mValueChanged           = true;
                                }
                            }
                        }

                        return;
                    }

                    if (mDataFlow.HasFlag(EDataFlow.TO) == false)
                    {
                        for (int i = 0; i < mElementItemHandles.Length; i++)
                        {
                            if (aItemHandle == mElementItemHandles[i])
                            {
                                mElementValueChanged[i] = true;
                                mValueChanged           = true;
                                return;
                            }
                        }
                    }
                }

                if (mDataFlow.HasFlag(EDataFlow.TO))
                {
                    if(mDataFlow.HasFlag(EDataFlow.FROM) == false && aItemHandle == mArrayValueItemHandle)
                    {
                        mArrayValueChanged  = true;
                        mValueChanged       = true;
                        return;
                    }

                    for (int i = 0; i < mElementItemHandles.Length; i++)
                    {
                        if (aItemHandle == mElementItemHandles[i])
                        {
                            if (ValuesCompare.isNotEqual(aItemValue, mArrayValue[i]))
                            {
                                mArrayValue[i]      = aItemValue;
                                mArrayValueChanged  = true;
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

                string lItem    = lReader.getAttribute<String>("ArrayItem");
                lChecker.addItemName(lItem);
                mArrayValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mDataFlow = (EDataFlow)Enum.Parse(typeof(EDataFlow), lReader.getAttribute<String>("DataFlow", mDataFlow.ToString()));

                #region Elements

                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        aXMLTextReader.Read();
                        if (aXMLTextReader.Name.Equals("Elements", StringComparison.Ordinal))
                        {
                            if (aXMLTextReader.IsEmptyElement == false)
                            {
                                List<int> lIndexes  = new List<int>();
                                List<int> lItems    = new List<int>();
                                var lIndexSet       = new HashSet<int>();
                                int lMaxIndex       = -1;
                                int lIndex;

                                aXMLTextReader.Read();
                                while (aXMLTextReader.Name.Equals("Element", StringComparison.Ordinal))
                                {
                                    lIndex = (int)lReader.getAttribute<UInt32>("Index");
                                    if (lIndexSet.Add(lIndex) == false)
                                    {
                                        throw new ArgumentException("Index '" + lIndex.ToString() + "' already exists. ");
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
                                    mElementItemHandles = new int[lMaxIndex + 1];
                                    for (int i = 0; i < mElementItemHandles.Length; i++)
                                    {
                                        mElementItemHandles[i] = -1;
                                    }
                                    mElementValueChanged    = new bool[mElementItemHandles.Length];
                                    mArrayValue             = new object[mElementItemHandles.Length];

                                    int lCount = lIndexes.Count;
                                    for (int i = 0; i < lCount; i++)
                                    {
                                        lIndex                      = lIndexes[i];
                                        mElementItemHandles[lIndex] = lItems[i];
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
                aXMLTextWriter.WriteAttributeString("ArrayItem", mItemBrowser.getItemNameByHandle(mArrayValueItemHandle));
                aXMLTextWriter.WriteAttributeString("DataFlow", mDataFlow.ToString());

                if (mElementItemHandles.Length > 0)
                {
                    aXMLTextWriter.WriteStartElement("Elements");
                    for (int i = 0; i < mElementItemHandles.Length; i++)
                    {
                        if (mElementItemHandles[i] != -1)
                        {
                            aXMLTextWriter.WriteStartElement("Element");
                                aXMLTextWriter.WriteAttributeString("Index", StringUtils.ObjectToString(i));
                                aXMLTextWriter.WriteAttributeString("Item", mItemBrowser.getItemNameByHandle(mElementItemHandles[i]));
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
                get { return new string[] { }; }
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
