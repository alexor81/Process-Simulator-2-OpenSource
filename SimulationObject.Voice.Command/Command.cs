// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Speech.Recognition;
using System.Windows.Forms;
using System.Xml;
using Utils;
using Utils.NameValueList;

namespace SimulationObject.Voice.Command
{
    public class Command : ISimulationObject
    {
        public                                  Command()
        {
            mHolder.add("Ok, Dave.", 0, false);
        }

        #region Properties

            private SpeechRecognitionEngine     mSREngine;
            private void                        clearSREngine()
            {
                if (mSREngine != null)
                {
                    mSREngine.SpeechRecognized -= MSREngine_SpeechRecognized;
                    mSREngine.Dispose();
                    mSREngine = null;
                }
            }

            private RecognizerInfo              mRecInfo;
            public string                       Language
            {
                get 
                { 
                    if(mRecInfo != null)
                    {
                        return mRecInfo.Culture.Name;
                    }
                    else
                    {
                        return ""; 
                    }
                }
                set
                {
                    if(String.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Language is empty. ");
                    }

                    if(mRecInfo != null && mRecInfo.Culture.Name.Equals(value, StringComparison.Ordinal))
                    {
                        return;
                    }

                    RecognizerInfo lNewRecInfo = null;
                    foreach (var lRecInfo in SpeechRecognitionEngine.InstalledRecognizers())
                    {
                        if (lRecInfo.Culture.Name.Equals(value, StringComparison.Ordinal))
                        {
                            lNewRecInfo = lRecInfo;
                            break;
                        }
                    }

                    if(lNewRecInfo == null)
                    {
                        throw new ArgumentException("Language does not exist. ");
                    }

                    mRecInfo = lNewRecInfo;
                }
            }
            public string[]                     Languages
            {
                get
                {
                    var lEngines    = SpeechRecognitionEngine.InstalledRecognizers();
                    string[] lLang  = new string[lEngines.Count];
                    int i           = 0;

                    foreach (var lEngine in lEngines) 
                    {
                        lLang[i] = lEngine.Culture.Name;
                        i = i + 1;
                    }

                    return lLang;
                }
            }

            public NameValueHolder              mHolder = new NameValueHolder(false, true);

        #endregion

        #region IItemUser

            public int                          mValueItemHandle = -1;
            private object                      mValue;

            private IItemBrowser                mItemBrowser;
            public IItemBrowser                 ItemBrowser
            {
                set { mItemBrowser = value; }
            }

            public int[]                        ItemReadHandles
            {
                get
                {
                    return new int[] { };
                }
            }

            public int[]                        ItemWriteHandles
            {
                get
                {
                    return new int[] { mValueItemHandle };
                }
            }

            private volatile bool               mValueChanged = false;
            public bool                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged   = false;

                aItemHandles    = new int[] { mValueItemHandle };
                aItemValues     = new object[] { mValue };
            }

            public void                         onItemValueChange(int aItemHandle, object aItemValue)
            {
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
                var lReader         = new XMLAttributeReader(aXMLTextReader);
                Language            = lReader.getAttribute<String>("Language");
                mValueItemHandle    = mItemBrowser.getItemHandleByName(lReader.getAttribute<String>("Item"));

                mHolder.clear();
                if (aXMLTextReader.IsEmptyElement == false)
                {
                    aXMLTextReader.Read();
                    if (aXMLTextReader.Name.Equals("Commands", StringComparison.Ordinal))
                    {
                        if (aXMLTextReader.IsEmptyElement == false)
                        {
                            mHolder.loadFromXML(aXMLTextReader, "Comand");
                        }

                        aXMLTextReader.Read();
                    }
                }

                if (mHolder.Count == 0)
                {
                    mHolder.add("Ok, Dave.", 0, false);
                }
            }

            public void                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("Language", Language);
                aXMLTextWriter.WriteAttributeString("Item", mItemBrowser.getItemNameByHandle(mValueItemHandle));
                aXMLTextWriter.WriteStartElement("Commands");
                    mHolder.saveToXML(aXMLTextWriter, "Comand");
                aXMLTextWriter.WriteEndElement();
            }

            private void                        MSREngine_SpeechRecognized(object aSender, SpeechRecognizedEventArgs aEventArgs)
            {
                mValue          = mHolder.getValue(aEventArgs.Result.Text);
                mValueChanged   = true;
                raiseValuesChanged();
            } 

            public void                         execute()
            {
            }

            public void                         beforeActivate()
            {
                clearSREngine();

                mSREngine               = new SpeechRecognitionEngine(mRecInfo);             
                var lGrammarBuilder     = new GrammarBuilder();
                lGrammarBuilder.Culture = mRecInfo.Culture;
                lGrammarBuilder.Append(new Choices(mHolder.Names));
                mSREngine.LoadGrammar(new Grammar(lGrammarBuilder));
            
                mSREngine.SetInputToDefaultAudioDevice();
                mSREngine.SpeechRecognized += MSREngine_SpeechRecognized;

                mSREngine.RecognizeAsync(RecognizeMode.Multiple);
            }

            public void                         afterDeactivate()
            {
                mSREngine.RecognizeAsyncCancel();
            }

            public event EventHandler<MessageStringEventArgs> SimulationObjectError;
            private void                        raiseSimulationObjectError(string aMessage)
            {
                mLastError = aMessage;
                SimulationObjectError?.Invoke(this, new MessageStringEventArgs(aMessage));
            }

            private string                      mLastError;
            public string                       LastError
            {
                get { return mLastError; }
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
                        clearSREngine();
                        mHolder.clear();
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
