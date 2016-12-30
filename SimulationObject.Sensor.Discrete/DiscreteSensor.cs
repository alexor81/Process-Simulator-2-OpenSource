// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.Logger;
using Utils.Panels.BooleanButton;
using Utils.Panels.BooleanCheckBox;
using Utils.Panels.BooleanIndicator;
using Utils.Panels.BooleanToggle;
using Utils.Panels.BooleanTrend;
using Utils.Panels.ObjectDropDownList;
using Utils.Panels.ObjectRadioButtonGroup;
using Utils.Panels.ObjectTextLabel;

namespace SimulationObject.Sensor.Discrete
{
    public class DiscreteSensor : ISimulationObject, IBooleanValueReadWrite, IObjectValueReadWrite
    {
        #region Properties

            private SpeechSynthesizer                           mSpeechSynthesizer;
            private void                                        initSpeechSynthesizer()
            {
                if (mSpeechSynthesizer == null && (String.IsNullOrWhiteSpace(mTrueSpeech) == false || String.IsNullOrWhiteSpace(mFalseSpeech) == false))
                {
                    mSpeechSynthesizer = new SpeechSynthesizer();
                    mSpeechSynthesizer.SelectVoiceByHints(VoiceGender.Female);
                }
            }

            private string                                      mTrueSpeech     = "";
            public string                                       TrueSpeech
            {
                get { return mTrueSpeech; }
                set { mTrueSpeech = value; }
            }

            private string                                      mFalseSpeech    = "";
            public string                                       FalseSpeech
            {
                get { return mFalseSpeech; }
                set { mFalseSpeech = value; }
            }

            private bool                                        mTellTrue       = false;
            public bool                                         TellTrue
            {
                get { return mTellTrue; }
                set
                {
                    if (mTellTrue != value)
                    {
                        mTellTrue = value;
                        if (mTellTrue)
                        {
                            initSpeechSynthesizer();
                        }
                    }
                }
            }

            private bool                                        mTellFalse      = false;
            public bool                                         TellFalse
            {
                get { return mTellFalse; }
                set
                {
                    if (mTellFalse != value)
                    {
                        mTellFalse = value;
                        if (mTellFalse)
                        {
                            initSpeechSynthesizer();
                        }
                    }
                }
            }

            private bool                                        mLogTrue        = false;
            public bool                                         LogTrue
            {
                get { return mLogTrue; }
                set { mLogTrue = value; }
            }

            private bool                                        mLogFalse       = false;
            public bool                                         LogFalse
            {
                get { return mLogFalse; }
                set { mLogFalse = value; }
            }

        #endregion

        #region IItemUser, IBooleanValueReadWrite, IObjectValueReadWrite

            public int                                          mValueItemHandle = -1;
            private bool                                        mValue;
            public bool                                         ValueBoolean
            {
                get
                {
                    return mValue;
                }
                set
                {
                    if (mValue != value)
                    {
                        mValue          = value;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
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

            private IItemBrowser                                mItemBrowser;
            public IItemBrowser                                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                                        ItemReadHandles
            {
                get
                {
                    return new int[] { mValueItemHandle };
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
                if (aItemHandle == mValueItemHandle)
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

                    if (mValue != lValue)
                    {
                        mValue = lValue;
                        raiseValuesChanged();
                    }
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Indicator", "Button", "CheckBox", "Trend", "RadioButton", "DropDownList", "TextLabel", "Toggle" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
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
                    if (mSpeechSynthesizer != null)
                    {
                        mSpeechSynthesizer.SpeakAsyncCancelAll();
                    }
                    lResult = lSetupForm.ShowDialog(aOwner);
                }

                return lResult;
            }

            public void                                         loadFromXML(XmlTextReader aXMLTextReader)
            {
                var lReader         = new XMLAttributeReader(aXMLTextReader);

                mValueItemHandle    = mItemBrowser.getItemHandleByName(lReader.getAttribute<String>("Item"));
                TrueSpeech          = lReader.getAttribute<String>("TrueSpeech", "");
                FalseSpeech         = lReader.getAttribute<String>("FalseSpeech", "");
                TellTrue            = lReader.getAttribute<Boolean>("TellTrue", TellTrue);
                LogTrue             = lReader.getAttribute<Boolean>("LogTrue", LogTrue);
                TellFalse           = lReader.getAttribute<Boolean>("TellFalse", TellFalse);
                LogFalse            = lReader.getAttribute<Boolean>("LogFalse", LogFalse);
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Item", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteAttributeString("TrueSpeech", mTrueSpeech);
                aXMLTextWriter.WriteAttributeString("FalseSpeech", mFalseSpeech);
                aXMLTextWriter.WriteAttributeString("TellTrue", StringUtils.ObjectToString(TellTrue));
                aXMLTextWriter.WriteAttributeString("LogTrue", StringUtils.ObjectToString(LogTrue));
                aXMLTextWriter.WriteAttributeString("TellFalse", StringUtils.ObjectToString(TellFalse));
                aXMLTextWriter.WriteAttributeString("LogFalse", StringUtils.ObjectToString(LogFalse));
            }

            private bool                                        mPrevValue;
            public void                                         execute()
            {
                if (mPrevValue != mValue)
                {
                    if (mValue == true)
                    {
                        if (String.IsNullOrWhiteSpace(mTrueSpeech) == false)
                        {
                            if (mTellTrue)
                            {
                                mSpeechSynthesizer.SpeakAsync(mTrueSpeech);
                            }

                            if (mLogTrue)
                            {
                                Log.Info(mTrueSpeech);
                            }
                        }
                    }
                    else 
                    {
                        if (String.IsNullOrWhiteSpace(mFalseSpeech) == false)
                        {
                            if (mTellFalse)
                            {
                                mSpeechSynthesizer.SpeakAsync(mFalseSpeech);
                            }

                            if (mLogFalse)
                            {
                                Log.Info(mFalseSpeech);
                            }
                        }
                    }
                }
                mPrevValue = mValue;
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
                mLastError = aMessage;
                var lEvent = SimulationObjectError;
                if (lEvent != null) lEvent(this, new MessageStringEventArgs(aMessage));
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
                    if (aDisposing)
                    {
                        if (mSpeechSynthesizer != null)
                        {
                            mSpeechSynthesizer.Dispose();
                            mSpeechSynthesizer = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
