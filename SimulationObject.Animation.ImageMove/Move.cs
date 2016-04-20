using API;
using SimulationObject.Animation.ImageMove.Panel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Utils;

namespace SimulationObject.Animation.ImageMove
{
    public class Move : ISimulationObject
    {
        #region Properties

            public MemoryStream                                 mImgMemStrm;
            public Bitmap                                       mBmp;

        #endregion

        #region IItemUser

            public int                                          mXValueItemHandle   = -1;
            public int                                          mXValue;

            public int                                          mYValueItemHandle   = -1;
            public int                                          mYValue;

            public int                                          mVisibleItemHandle  = -1;
            public bool                                         mVisible            = true;

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

                    lResult.Add(mXValueItemHandle);
                    lResult.Add(mYValueItemHandle);


                    if (mVisibleItemHandle != -1)
                    {
                        lResult.Add(mVisibleItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    return new int[] { };
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
                aItemHandles    = new int[] { };
                aItemValues     = new object[] { };
            }

            public void                                         onItemValueChange(int aItemHandle, object aItemValue)
            {
                if (aItemHandle == mXValueItemHandle)
                {
                    int lValue;
                    try
                    {
                        lValue = Convert.ToInt32(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("X value conversion error. ", lExc);
                    }

                    if (mXValue != lValue)
                    {
                        mXValue = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mYValueItemHandle)
                {
                    int lValue;
                    try
                    {
                        lValue = Convert.ToInt32(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Y value conversion error. ", lExc);
                    }

                    if (mYValue != lValue)
                    {
                        mYValue = lValue;
                        raiseValuesChanged();
                    }

                    return;
                }

                if (aItemHandle == mVisibleItemHandle)
                {
                    bool lValue;
                    try
                    {
                        lValue = Convert.ToBoolean(aItemValue);
                    }
                    catch (Exception lExc)
                    {
                        throw new ArgumentException("Value conversion error for image to change visibile state. ", lExc);
                    }

                    if (mVisible != lValue)
                    {
                        mVisible = lValue;
                        raiseValuesChanged();     
                    }    

                    return;
                }
            }

        #endregion

        #region IPanelOwner

            private static readonly string[]                    mPanelList = new string[] { "Move" };
            public string[]                                     PanelTypeList
            {
                get { return mPanelList; }
            }

            public IPanel                                       getPanel(string aPanelType)
            {
                switch (aPanelType)
                {
                    case "Move":    return new MovePanel(this);
                    default:        throw new ArgumentException("Panel of type '" + aPanelType + "' does not exist. ");
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
                var lReader     = new XMLAttributeReader(aXMLTextReader);
                var lChecker    = new RepeatItemNameChecker();

                string lItem = lReader.getAttribute<String>("X");
                lChecker.addItemName(lItem);
                mXValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Y");
                lChecker.addItemName(lItem);
                mYValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Visible", "");
                lChecker.addItemName(lItem);
                mVisibleItemHandle = mItemBrowser.getItemHandleByName(lItem);

                if (aXMLTextReader.IsEmptyElement == false)
                {
                    aXMLTextReader.Read();
                    if (aXMLTextReader.Name.Equals("Image", StringComparison.Ordinal))
                    {
                        if (aXMLTextReader.IsEmptyElement == false)
                        {
                            aXMLTextReader.Read();
                            mImgMemStrm = new MemoryStream(Convert.FromBase64String(aXMLTextReader.ReadString()));
                        }
                    }
                }

                if(mImgMemStrm == null)
                {
                    throw new ArgumentException("Image does not exist. ");
                }

                try
                {
                    mBmp = new Bitmap(mImgMemStrm);
                }
                catch(Exception lExc)
                {
                    mImgMemStrm.Close();
                    mImgMemStrm = null;
                    throw new ArgumentException("Image is wrong. " + lExc.Message, lExc);
                }
            }

            public void                                         saveToXML(XmlTextWriter aXMLTextWriter)
            {
                aXMLTextWriter.WriteAttributeString("X", mItemBrowser.getItemNameByHandle(mXValueItemHandle));
                aXMLTextWriter.WriteAttributeString("Y", mItemBrowser.getItemNameByHandle(mYValueItemHandle));
                aXMLTextWriter.WriteAttributeString("Visible", mItemBrowser.getItemNameByHandle(mVisibleItemHandle));
                aXMLTextWriter.WriteStartElement("Image");
                    aXMLTextWriter.WriteString(Convert.ToBase64String(mImgMemStrm.ToArray()));
                aXMLTextWriter.WriteEndElement();
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
                get { return new string[] { }; }
            }

            public void                                         onContextMenuItemClick(string aMenuItemName, IWin32Window aOwner)
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
                        if (mBmp != null)
                        {
                            mBmp.Dispose();
                            mBmp = null;
                        }

                        if (mImgMemStrm != null)
                        {
                            mImgMemStrm.Close();
                            mImgMemStrm = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
