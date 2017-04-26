// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using SimulationObject.Animation.ImageMove.Panels;
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

            public bool                                         mUserCanMove = false;

        #endregion

        #region IItemUser

            public int                                          mXValueItemHandle   = -1;
            private int                                         mXValue;
            public int                                          XValue
            {
                get { return mXValue; }
                set
                {
                    if (mUserCanMove && mXValue != value)
                    {
                        mXValue         = value;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mYValueItemHandle   = -1;
            private int                                         mYValue;
            public int                                          YValue
            {
                get { return mYValue; }
                set
                {
                    if (mUserCanMove && mYValue != value)
                    {
                        mYValue         = value;
                        mValueChanged   = true;
                        raiseValuesChanged();
                    }
                }
            }

            public int                                          mVisibleItemHandle  = -1;
            public bool                                         mVisible            = true;

            public int                                          mMovingByUserItemHandle  = -1;
            private bool                                        mMovingByUser;
            public bool                                         MovingByUser
            {
                get { return mMovingByUser; }
                set
                {
                    if (mUserCanMove && mMovingByUser != value)
                    {
                        mMovingByUser   = value;
                        mValueChanged   = true;
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
                    if (mVisibleItemHandle != -1)
                    {
                        return new int[] {mXValueItemHandle, mYValueItemHandle, mVisibleItemHandle};
                    }
                    else
                    {
                        return new int[] {mXValueItemHandle, mYValueItemHandle};
                    }
                }
            }

            public int[]                                        ItemWriteHandles
            {
                get
                {
                    List<int> lResult = new List<int>();

                    if (mUserCanMove)
                    {
                        lResult.Add(mXValueItemHandle);
                        lResult.Add(mYValueItemHandle);
                    }

                    if (mMovingByUserItemHandle != -1)
                    {
                        lResult.Add(mMovingByUserItemHandle);
                    }

                    return lResult.ToArray();
                }
            }

            private volatile bool                               mValueChanged = false;
            public bool                                         IsValueChanged
            {
                get { return mValueChanged; }
            }

            public void                                         getItemValues(out int[] aItemHandles, out object[] aItemValues)
            {
                mValueChanged = false;

                if (mUserCanMove)
                {
                    if (mMovingByUserItemHandle != -1)
                    {
                        aItemHandles    = new int[] { mXValueItemHandle, mYValueItemHandle, mMovingByUserItemHandle};
                        aItemValues     = new object[] { mXValue, mYValue, mMovingByUser };
                    }
                    else
                    {
                        aItemHandles    = new int[] { mXValueItemHandle, mYValueItemHandle};
                        aItemValues     = new object[] { mXValue, mYValue };
                    }
                }
                else
                {
                    aItemHandles    = new int[] { };
                    aItemValues     = new object[] { };
                }
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
                        throw new ArgumentException("Value conversion error for visibility state. ", lExc);
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

                string lItem = lReader.getAttribute<String>("X");
                lChecker.addItemName(lItem);
                mXValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Y");
                lChecker.addItemName(lItem);
                mYValueItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("Visible", "");
                lChecker.addItemName(lItem);
                mVisibleItemHandle = mItemBrowser.getItemHandleByName(lItem);

                lItem = lReader.getAttribute<String>("MovingByUser", "");
                lChecker.addItemName(lItem);
                mMovingByUserItemHandle = mItemBrowser.getItemHandleByName(lItem);

                mUserCanMove = lReader.getAttribute<Boolean>("UserCanMove", mUserCanMove);

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
                aXMLTextWriter.WriteAttributeString("UserCanMove", StringUtils.ObjectToString(mUserCanMove));
                aXMLTextWriter.WriteAttributeString("MovingByUser", mItemBrowser.getItemNameByHandle(mMovingByUserItemHandle));
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
