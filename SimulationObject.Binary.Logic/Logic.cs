// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Binary.Logic.Panels;
using System;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
using Utils.Panels.BooleanIndicator;
using Utils.Panels.BooleanTrend;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Binary.Logic
{
    public class Logic : ISimulationObject, IBooleanValueRead, IObjectValueRead
    {
        #region Properties

            public static readonly string[]                     Operators = new string[] { "AND",
                                                                                           "OR",
                                                                                           "XOR",
                                                                                           "NOT",
                                                                                           "NAND",
                                                                                           "NOR",
                                                                                           "XNOR" };

            private int                                         mOperator = 0;
            public int                                          OperatorIndex
            {
                get { return mOperator; }
                set
                {
                    if (mOperator != value)
                    {
                        if (value < 0 || value >= Operators.Length)
                        {
                            throw new ArgumentException("Unknown logical operator. ");
                        }

                        mOperator = value;
                        raisePropertiesChanged();
                        check();
                    }
                }
            }
            public string                                       OperatorString
            {
                get { return Operators[mOperator]; }
                set
                {
                    for (int i = 0; i < Operators.Length; i++)
                    {
                        if (Operators[i].Equals(value, StringComparison.Ordinal))
                        {
                            if (mOperator != i)
                            {
                                mOperator = i;
                                raisePropertiesChanged();
                                check();
                            }
                            return;
                        }
                    }

                    throw new ArgumentException("Unknown logical operator. ");
                }
            }

            private bool                                        mInput1Inverse = false;
            public bool                                         Input1Inverse
            {
                get { return mInput1Inverse; }
                set
                {
                    mInput1Inverse = value;
                    raisePropertiesChanged();
                    raiseValuesChanged();
                    check();
                }
            }

            private bool                                        mInput2Inverse = false;
            public bool                                         Input2Inverse
            {
                get { return mInput2Inverse; }
                set
                {
                    mInput2Inverse = value;
                    raisePropertiesChanged();
                    raiseValuesChanged();
                    check();
                }
            }

        #endregion

        #region IItemUser, IBooleanValueRead, IObjectValueRead

            public int                                          mValueItemHandle    = -1;
            private bool                                        mValue;
            public bool                                         ValueBoolean
            {
                get { return mValue; }
            }
            public object                                       ValueObject
            {
                get { return ValueBoolean; }
            }

            public int                                          mInput1ItemHandle   = -1;
            private bool                                        mInput1Value;
            public bool                                         Input1Value
            {
                get { return mInput1Value; }
            }          

            public int                                          mInput2ItemHandle   = -1;
            private bool                                        mInput2Value;
            public bool                                         Input2Value
            {
                get { return mInput2Value; }
            } 

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    if (mInput2ItemHandle != -1)
                    {
                        return new int[] { mInput1ItemHandle, mInput2ItemHandle };
                    }
                    else
                    {
                        
                        return new int[] { mInput1ItemHandle };
                    }
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
                if (aItemHandle == mInput1ItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value №1 conversion error. ", lExc);
                    }

                    if (mInput1Value != lValue)
                    {
                        mInput1Value = lValue;
                        raiseValuesChanged();
                        check();
                    }

                    return;
                }

                if (aItemHandle == mInput2ItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value №2 conversion error. ", lExc);
                    }

                    if (mInput2Value != lValue)
                    {
                        mInput2Value = lValue;
                        raiseValuesChanged();
                        check();
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Logic", "Indicator", "Trend", "TextLabel" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Logic":       return new LogicPanel(this);
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

                OperatorString = lReader.getAttribute<String>("Operator");

                string lItem = lReader.getAttribute<String>("Input1");
                lChecker.addItemName(lItem);
                mInput1ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mInput1Inverse = lReader.getAttribute<Boolean>("Input1Inverse", mInput1Inverse);

                lItem = lReader.getAttribute<String>("Input2", "");
                lChecker.addItemName(lItem);
                mInput2ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mInput2Inverse = lReader.getAttribute<Boolean>("Input2Inverse", mInput2Inverse);

                lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Operator", OperatorString);
                aXMLTextWriter.WriteAttributeString("Input1", mItemBrowser.getItemNameByHandle(mInput1ItemHandle));
                aXMLTextWriter.WriteAttributeString("Input1Inverse", StringUtils.ObjectToString(mInput1Inverse));
                aXMLTextWriter.WriteAttributeString("Input2", mItemBrowser.getItemNameByHandle(mInput2ItemHandle));
                aXMLTextWriter.WriteAttributeString("Input2Inverse", StringUtils.ObjectToString(mInput2Inverse));
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mValueItemHandle));
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

                bool lIn1;
                if (mInput1Inverse) { lIn1 = !mInput1Value; }
                else { lIn1 = mInput1Value; }

                bool lIn2;
                if (mInput2Inverse) { lIn2 = !mInput2Value; }
                else { lIn2 = mInput2Value; }

                switch (mOperator)
                {
                    case 0: mValue = lIn1 && lIn2; break;       //AND
                    case 1: mValue = lIn1 || lIn2; break;       //OR
                    case 2: mValue = lIn1 ^ lIn2; break;        //XOR
                    case 3: mValue = !lIn1; break;              //NOT
                    case 4: mValue = !(lIn1 && lIn2); break;    //NAND
                    case 5: mValue = !(lIn1 || lIn2); break;    //NOR
                    case 6: mValue = !(lIn1 ^ lIn2); break;     //XNOR
                }

                if (lPrevValue != mValue)
                {
                    mValueChanged = true;
                    raiseValuesChanged();
                }
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
