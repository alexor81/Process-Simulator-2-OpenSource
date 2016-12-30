// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Real.Calculator.Panel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
using Utils.Panels.DoubleBar;
using Utils.Panels.DoubleIndicator;
using Utils.Panels.DoubleMeter;
using Utils.Panels.DoubleSlidingScale;
using Utils.Panels.DoubleTrend;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Real.Calculator
{
    public class Calculator : ISimulationObject, IDoubleValueRead, IObjectValueRead
    {
        #region Properties

            public static readonly string[]                     Operations = new string[] { "Add",
                                                                                            "Subtract",
                                                                                            "Multiply",
                                                                                            "Divide",
                                                                                            "Modulo",
                                                                                            "Power",
                                                                                            "Logarithm",
                                                                                            "Logarithm (natural)",
                                                                                            "Logarithm (base 10)",
                                                                                            "Exponent",
                                                                                            "Square root",
                                                                                            "Sine",
                                                                                            "Cosine",
                                                                                            "Tangent",
                                                                                            "Absolute",
                                                                                            "Round",
                                                                                            "Truncate"};

            public const uint                                   OneArgument = 7;

            private int                                         mOperation  = 0;
            public int                                          OperationIndex
            {
                get { return mOperation; }
                set
                {
                    if (mOperation != value)
                    {
                        if (value < 0 || value >= Operations.Length)
                        {
                            throw new ArgumentException("Unknown operation. ");
                        }

                        mOperation = value;
                        raisePropertiesChanged();
                        calc();
                    }
                }
            }
            public string                                       OperationString
            {
                get { return Operations[mOperation]; }
                set
                {
                    for (int i = 0; i < Operations.Length; i++)
                    {
                        if (Operations[i].Equals(value, StringComparison.Ordinal))
                        {
                            if (mOperation != i)
                            {
                                mOperation = i;
                                raisePropertiesChanged();
                                calc();
                            }
                            return;
                        }
                    }

                    throw new ArgumentException("Unknown operation. ");
                }
            }

        #endregion

        #region IItemUser, IDoubleValueRead, IObjectValueRead

            public int                                          mValueItemHandle    = -1;
            private double                                      mValue;
            public double                                       ValueDouble
            {
                get
                {
                    return mValue;
                }
            }
            public object                                       ValueObject
            {
                get { return ValueDouble; }
            }

            public double[]                                     Thresholds { get { return new double[0]; } }
            public string                                       Units { get { return ""; } }

            public int                                          mInput1ItemHandle   = -1;
            private double                                      mInput1;
            public double                                       Input1
            {
                get { return mInput1; }
            }

            public int                                          mInput2ItemHandle   = -1;
            private double                                      mInput2;
            public double                                       Input2
            {
                get { return mInput2; }
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
                    List<int> lResult = new List<int>();

                    lResult.Add(mValueItemHandle);
                    lResult.Add(mInput1ItemHandle);

                    if (mInput2ItemHandle != -1)
                    {
                        lResult.Add(mInput2ItemHandle);
                    }

                    return lResult.ToArray();
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
                    double lValue;
                    try
                    {
                        lValue = Convert.ToDouble(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value №1 conversion error. ", lExc);
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mInput1, lValue))
                    {
                        mInput1 = lValue;
                        calc();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mInput2ItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = Convert.ToDouble(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Input value №2 conversion error. ", lExc);
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mInput2, lValue))
                    {
                        mInput2 = lValue;
                        calc();
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mValueItemHandle)
                {
                    double lValue;
                    try
                    {
                        lValue = Convert.ToDouble(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("Output value conversion error. " + lExc.Message, lExc.ToString());
                        mValueChanged = true;
                        return;
                    }

                    if (ValuesCompare.NotEqualDelta1.compare(mValue, lValue))
                    {
                        mValueChanged = true;
                    }

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Calculator", "Trend", "Indicator", "TextLabel", "Meter", "Bar", "SlidingScale" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Calculator":      return new CalculatorPanel(this);
                    case "Trend":           return new DoubleTrendPanel(this);
                    case "Indicator":       return new DoubleIndicatorPanel(this);
                    case "TextLabel":       return new ObjectTextLabelPanel(this);
                    case "Meter":           return new DoubleMeterPanel(this, 100, 0);
                    case "Bar":             return new DoubleBarPanel(this, 100, 0);
                    case "SlidingScale":    return new DoubleSlidingScalePanel(this);
                    default:                throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
                }
            }

            public event EventHandler                           ChangedValues;
            public void                                         raiseValuesChanged()
            {
                EventHandler lEvent = ChangedValues;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
            }

            public event EventHandler                           ChangedProperties;
            public void                                         raisePropertiesChanged()
            {
                EventHandler lEvent = ChangedProperties;
                if (lEvent != null) lEvent(this, EventArgs.Empty);
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
                var lReader = new XMLAttributeReader(aXMLTextReader);
                var lChecker = new RepeatItemNameChecker();

                OperationString = lReader.getAttribute<String>("Operation");

                string lItem = lReader.getAttribute<String>("Input1");
                lChecker.addItemName(lItem);
                mInput1ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Input2", "");
                lChecker.addItemName(lItem);
                mInput2ItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Value");
                lChecker.addItemName(lItem);
                mValueItemHandle = mItemBrowser.getItemHandleByName(lItem);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Operation", OperationString);
                aXMLTextWriter.WriteAttributeString("Input1", mItemBrowser.getItemNameByHandle(mInput1ItemHandle));
                aXMLTextWriter.WriteAttributeString("Input2", mItemBrowser.getItemNameByHandle(mInput2ItemHandle));
                aXMLTextWriter.WriteAttributeString("Value", mItemBrowser.getItemNameByHandle(mValueItemHandle));
            }

            private void                                        calc()
            {
                double lLastOutValue = mValue;

                switch (mOperation)
                {
                    case 0: mValue = mInput1 + mInput2; break;          //Add
                    case 1: mValue = mInput1 - mInput2; break;          //Subtract
                    case 2: mValue = mInput1 * mInput2; break;          //Multiply
                    case 3: mValue = mInput1 / mInput2; break;          //Divide
                    case 4: mValue = mInput1 % mInput2; break;          //Modulo
                    case 5: mValue = Math.Pow(mInput1, mInput2); break; //Power
                    case 6: mValue = Math.Log(mInput1, mInput2); break; //Logarithm
                    case 7: mValue = Math.Log(mInput1); break;          //Logarithm (natural)
                    case 8: mValue = Math.Log10(mInput1); break;        //Logarithm (base 10)
                    case 9: mValue = Math.Exp(mInput1); break;          //Exponent
                    case 10: mValue = Math.Sqrt(mInput1); break;         //Square root
                    case 11: mValue = Math.Sin(mInput1); break;          //Sine
                    case 12: mValue = Math.Cos(mInput1); break;          //Cosine
                    case 13: mValue = Math.Tan(mInput1); break;          //Tangent
                    case 14: mValue = Math.Abs(mInput1); break;          //Absolute
                    case 15: mValue = Math.Round(mInput1); break;        //Round
                    case 16: mValue = Math.Truncate(mInput1); break;     //Truncate
                }

                if (ValuesCompare.NotEqualDelta1.compare(lLastOutValue, mValue))
                {
                    mValueChanged = true;
                    raiseValuesChanged();
                }
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

            public event EventHandler<MessageStringEventArgs>   SimulationObjectError;
            private void                                        raiseSimulationObjectError(string aMessage)
            {
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
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
