// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils.Panels.VectorImage
{
    public partial class SetupForm : Form, IRedraw
    {
        private VectorImagePanel            mPanel;
        private List<IVectorElement>        mElements = new List<IVectorElement>();
        private int                         mPanelWidth;
        private int                         mPanelHeight;

        public                              SetupForm(VectorImagePanel aPanel)
        {
            mPanel          = aPanel;
            mPanelWidth     = mPanel.Width;
            mPanelHeight    = mPanel.Height;
            InitializeComponent();

            Size                                    = mPanel.mEditorSize;
            mNormalSize                             = mPanel.mEditorSize;
            splitContainerControl.SplitterPosition  = mPanel.mSplitterPos;
            KeyPreview                              = true;

            int lCount = mPanel.Elements.Count;
            for (int i = 0; i < lCount; i++)
            {
                listBox_Elements.Items.Add(mPanel.Elements[i].Name);
                mElements.Add(mPanel.Elements[i].Clone);
            }

            if (SystemInformation.TerminalServerSession == false)
            {
                System.Reflection.PropertyInfo aProp =
                      typeof(Control).GetProperty(
                            "DoubleBuffered",
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Instance);

                aProp.SetValue(panel_Draw, true, null);
            }

            IsContainer     = mPanel.IsContainer;
            BackgroundColor = mPanel.BackgroundColor;

            updateMenu();
        }

        #region Size

            private bool                    mMaximized = false;
            private Size                    mNormalSize;
            private Point                   mNormalLocation;
            protected override void         WndProc(ref Message aMessage)
            {
                if (aMessage.Msg == (int)WM.NCLBUTTONDBLCLK)
                {
                    if (mMaximized)
                    {
                        Size        = mNormalSize;
                        Location    = mNormalLocation;

                        mMaximized  = false;
                    }
                    else
                    {
                        Size lSize      = Size;     
                        mNormalLocation = Location;
                        Screen lScreen  = Screen.FromControl(this);           
                        Size            = lScreen.WorkingArea.Size;
                        mNormalSize     = lSize;
                        Location        = lScreen.WorkingArea.Location;
                        
                        mMaximized      = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

            private void                    SetupForm_SizeChanged(object aSender, EventArgs aEventArgs)
            {
                mNormalSize = Size;
            }

        #endregion

        #region Menu

            private void                    updateMenu()
            {
                bool lNotEmpty      = listBox_Elements.Items.Count > 0;
                bool lSelected      = listBox_Elements.SelectedItems.Count > 0;

                tsButton_Setup.Enabled          = (listBox_Elements.SelectedItems.Count == 1);
                tsButton_SendToBack.Enabled     = lSelected;
                tsButton_BringToFront.Enabled   = lSelected;
                tsButton_SelectAll.Enabled      = lNotEmpty;
                tsButton_SelectNone.Enabled     = lNotEmpty;
                tsButton_Copy.Enabled           = lSelected;
                tsButton_Paste.Enabled          = (mCopyBuffer.Count > 0);
                tsButton_Delete.Enabled         = lSelected;
                tsButton_CenterV.Enabled        = lSelected;
                tsButton_CenterH.Enabled        = lSelected;
                tsButton_AlignL.Enabled         = lSelected;
                tsButton_AlignR.Enabled         = lSelected;
                tsButton_AlignT.Enabled         = lSelected;
                tsButton_AlignB.Enabled         = lSelected;
                tsButton_Fit.Enabled            = lNotEmpty;
            }

            private void                    tsButton_Setup_Click(object aSender, EventArgs aEventArgs)
            {
                int lSelectedIndex = listBox_Elements.SelectedIndex;
                listBox_Elements.SetSelected(lSelectedIndex, false);
                using (Form lSetupForm = mElements[lSelectedIndex].getSetupForm(this))
                {
                    lSetupForm.ShowDialog(this);
                }
                listBox_Elements.SetSelected(lSelectedIndex, true);
            }

            private void                    tsButton_SendToBack_Click(object aSender, EventArgs aEventArgs)
            {
                sendToBackElements();
            }

            private void                    tsButton_BringToFront_Click(object aSender, EventArgs aEventArgs)
            {
                bringToFrontElements();
            }

            private void                    tsButton_SelectAll_Click(object aSender, EventArgs aEventArgs)
            {
                for (int i = 0; i < listBox_Elements.Items.Count; i++)
                {
                    listBox_Elements.SetSelected(i, true);
                }
            }
            
            private void                    tsButton_SelectNone_Click(object aSender, EventArgs aEventArgs)
            {
                listBox_Elements.ClearSelected();
            }

            private void                    tsButton_Copy_Click(object aSender, EventArgs aEventArgs)
            {
                copy();
            }

            private void                    tsButton_Paste_Click(object aSender, EventArgs aEventArgs)
            {
                paste();
            }

            private void                    tsButton_Delete_Click(object aSender, EventArgs aEventArgs)
            {
                delete();
            }

            private void                    tsButton_UserTool_Click(object aSender, EventArgs aEventArgs)
            {
                tsButton_Pointer.Checked    = (aSender == tsButton_Pointer);
                tsButton_Line.Checked       = (aSender == tsButton_Line);
                tsButton_Rectangle.Checked  = (aSender == tsButton_Rectangle);
                tsButton_Ellipse.Checked    = (aSender == tsButton_Ellipse);
                tsButton_Text.Checked       = (aSender == tsButton_Text);

                if (tsButton_Pointer.Checked == false)
                {
                    listBox_Elements.ClearSelected();
                    panel_Draw.Cursor = Cursors.Cross;
                }
                else
                {
                    panel_Draw.Cursor = Cursors.Arrow;
                }

                updateMenu();
            }

        #endregion

        #region Paint

            private Rectangle               mSelectedRect;
            private void                    updateXYWH(int aX = 0, int aY = 0)
            {
                if ((listBox_Elements.SelectedIndices.Count > 0) || (mNewElement != null))
                {
                    labelControl_XY.Text    = StringUtils.ObjectToString(mSelectedRect.X) + ", " + StringUtils.ObjectToString(mSelectedRect.Y);
                    labelControl_HW.Visible = true;      
                    labelControl_HW.Text    = StringUtils.ObjectToString(mSelectedRect.Width) + ", " + StringUtils.ObjectToString(mSelectedRect.Height);
                }
                else
                {
                    labelControl_XY.Text    = StringUtils.ObjectToString(aX) + ", " + StringUtils.ObjectToString(aY);
                    labelControl_HW.Visible = false;
                }

                labelControl_HW.Left    = labelControl_XY.Right + 1;              
            }

            public void                     Redraw()
            {
                if (InvokeRequired)
                {
                    BeginInvoke((Action)(() => { redraw(); }));
                }
                else
                {
                    redraw();
                }
            }
            private void                    redraw()
            {
                if (mBitmap != null)
                {
                    mBitmap.Dispose();
                    mBitmap = null;
                }
                panel_Draw.Invalidate();
            }

            private Bitmap                  mBitmap;
            private void                    panel_Draw_Paint(object aSender, PaintEventArgs aEventArgs)
            {
                int lCount;

                if (mBitmap == null) // not selected elements
                {
                    mBitmap = new Bitmap(panel_Draw.Width, panel_Draw.Height);
                    using (Graphics lGraphics = Graphics.FromImage(mBitmap))
                    {
                        lGraphics.SmoothingMode     = SmoothingMode.AntiAlias;
                        lGraphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

                        lCount = mElements.Count;
                        for (int i = 0; i < lCount; i++)
                        {
                            if (listBox_Elements.SelectedIndices.Contains(i) == false)
                            {
                                mElements[i].draw(lGraphics);
                            }
                        }

                        lGraphics.DrawLine(Pens.Gray, mPanelWidth, 0, mPanelWidth, mPanelHeight);
                        lGraphics.DrawLine(Pens.Gray, 0, mPanelHeight, mPanelWidth, mPanelHeight);
                    }
                }

                aEventArgs.Graphics.SmoothingMode       = SmoothingMode.AntiAlias;
                aEventArgs.Graphics.TextRenderingHint   = TextRenderingHint.AntiAliasGridFit;
                aEventArgs.Graphics.DrawImage(mBitmap, 0, 0);

                lCount = listBox_Elements.SelectedIndices.Count;
                if (lCount > 0) // selected elements
                {
                    int lMinX = Int32.MaxValue;
                    int lMinY = Int32.MaxValue;
                    int lMaxX = 0;
                    int lMaxY = 0;
                    IVectorElement lElement;
                    Rectangle lRect;
                    
                    for (int i = 0; i < lCount; i++) 
                    {
                        lElement = mElements[listBox_Elements.SelectedIndices[i]];
                        lElement.drawSelected(aEventArgs.Graphics);
                        lRect = lElement.coverRect;

                        if (lMinX > lRect.Left)     lMinX = lRect.Left;
                        if (lMinY > lRect.Top)      lMinY = lRect.Top;
                        if (lMaxX < lRect.Right)    lMaxX = lRect.Right;
                        if (lMaxY < lRect.Bottom)   lMaxY = lRect.Bottom;
                    }

                    mSelectedRect = new Rectangle(lMinX, lMinY, lMaxX - lMinX, lMaxY - lMinY);
                }

                if (mNewElement != null) // new element
                {
                    mNewElement.drawSelected(aEventArgs.Graphics);
                    mSelectedRect = mNewElement.coverRect;
                }
            }

            private void                    panel_Draw_Resize(object aSender, EventArgs aEventArgs)
            {
                redraw();
            }

        #endregion

        #region Create, Select, Move

            private void                    listBox_Elements_MouseDown(object aSender, MouseEventArgs aEventArgs)
            {
                if (!tsButton_Pointer.Checked)
                {
                    tsButton_Pointer.Checked    = true;
                    tsButton_Line.Checked       = false;
                    tsButton_Rectangle.Checked  = false;
                    tsButton_Ellipse.Checked    = false;
                    tsButton_Text.Checked       = false;
                    panel_Draw.Cursor           = Cursors.Arrow;
                }
            }

            private int                     mFirstSelected = -1;
            private void                    listBox_Elements_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
            {
                if (listBox_Elements.SelectedIndices.Count == 0)
                {
                    mFirstSelected = -1;
                }
                else if (listBox_Elements.SelectedIndices.Count == 1)
                {
                    mFirstSelected = listBox_Elements.SelectedIndices[0];
                }

                updateMenu();
                redraw();
            }

            private int                     testHit(Point aPoint)
            {
                for (int i = mElements.Count - 1; i >= 0; i--)
                {
                    if (mElements[i].testHit(aPoint))
                    {
                        return i;
                    }
                }
                return -1;
            }

            private void                    selectElementInsideRectangle(Rectangle aRect)
            {
                int lCount          = mElements.Count;
                bool[] lSelect      = new bool[lCount];

                Parallel.For(0, lCount, i => lSelect[i] = aRect.Contains(mElementRect[i]));

                for (int i = 0; i < lCount; i++)
                {
                    listBox_Elements.SetSelected(i, lSelect[i]);
                }
            }

            private bool                    mMove   = false;
            private bool                    mCreate = false;
            private Point                   mMousePosition;
            private IVectorElement          mNewElement;
            private Form                    mSelectionForm;
            private volatile bool           mSelectionWork;
            private Rectangle               mSelectionRect;
            private Rectangle[]             mElementRect;
            private void                    SelectionWork()
            {
                var lLastRect = Rectangle.Empty;

                while(mSelectionWork)
                {
                    if (lLastRect.Equals(mSelectionRect) == false)
                    {
                        if (InvokeRequired)
                        {
                            Invoke((Action)(() => { selectElementInsideRectangle(mSelectionRect); }));
                        }
                        else
                        {
                            selectElementInsideRectangle(mSelectionRect);
                        }

                        lLastRect = mSelectionRect;
                    }

                    Thread.Sleep(MiscUtils.TimeSlice);
                }
            }

            private void                    moveSelected(int aDx, int aDy)
            {
                int lCount = listBox_Elements.SelectedIndices.Count;
                for (int i = 0; i < lCount; i++)
                {
                    mElements[listBox_Elements.SelectedIndices[i]].move(aDx, aDy);
                }

                panel_Draw.Invalidate();
            }

            private void                    panel_Draw_MouseEnter(object aSender, EventArgs aEventArgs)
            {
                updateXYWH();
                labelControl_XY.Visible = true;          
            }

            private void                    panel_Draw_MouseDown(object aSender, MouseEventArgs aEventArgs)
            {
                #region Selecting, Moving

                    if (tsButton_Pointer.Checked)
                    {
                        int lIndex = testHit(aEventArgs.Location);
                        bool lCtrl = (Form.ModifierKeys == Keys.Control);

                        if (aEventArgs.Button == MouseButtons.Left)
                        {
                            if (lIndex > -1)
                            {
                                bool lSelected = listBox_Elements.GetSelected(lIndex);
                                if (lSelected && lCtrl)
                                {
                                    listBox_Elements.SetSelected(lIndex, false);
                                }
                                else
                                {
                                    if (lSelected == false)
                                    {
                                        if (lCtrl == false)
                                        {
                                            listBox_Elements.ClearSelected();
                                        }

                                        listBox_Elements.SetSelected(lIndex, true);
                                    }

                                    mMove           = true;
                                    mMousePosition  = aEventArgs.Location;
                                }
                            }
                            else
                            {
                                listBox_Elements.ClearSelected();

                                mMousePosition                  = Cursor.Position;

                                mSelectionForm                  = new Form();
                                mSelectionForm.FormBorderStyle  = FormBorderStyle.None;
                                mSelectionForm.ShowInTaskbar    = false;
                                mSelectionForm.ShowIcon         = false;
                                mSelectionForm.BackColor        = Color.Gray;
                                mSelectionForm.Opacity          = 0.15;
                                mSelectionForm.TopMost          = true;

                                int lCount     = mElements.Count;
                                mElementRect   = new Rectangle[lCount];
                                for(int i = 0; i < lCount; i++)
                                {
                                    mElementRect[i] = panel_Draw.RectangleToScreen(mElements[i].coverRect);
                                }

                                mSelectionWork  = true;
                                mSelectionRect  = new Rectangle(0, 0, 1, 1);
                                ThreadPool.QueueUserWorkItem((o) => { SelectionWork();});
                            }
                        }

                        if (aEventArgs.Button == MouseButtons.Right)
                        {
                            listBox_Elements.ClearSelected();
                            if (lIndex > -1)
                            {
                                listBox_Elements.SetSelected(lIndex, true);
                                tsButton_Setup_Click(this, EventArgs.Empty);
                            }
                        }

                        return;
                    }

                #endregion

                #region Creating

                    if (aEventArgs.Button == MouseButtons.Left)
                    {
                        mCreate = true;

                        if (tsButton_Line.Checked)
                        {
                            mNewElement = new ElementLine.ElementLine();
                        }
                        else if (tsButton_Rectangle.Checked)
                        {
                            mNewElement = new ElementRectangle.ElementRectangle();
                        }
                        else if (tsButton_Ellipse.Checked)
                        {
                            mNewElement = new ElementEllipse.ElementEllipse();
                        }
                        else if (tsButton_Text.Checked)
                        {
                            mNewElement = new ElementText.ElementText();
                        }
                    
                        mNewElement.move(aEventArgs.X, aEventArgs.Y);
                        mMousePosition = aEventArgs.Location;

                        return;
                    }

                #endregion
            }

            private void                    panel_Draw_MouseMove(object aSender, MouseEventArgs aEventArgs)
            {
                if (mMove)
                {
                    int ldX         = aEventArgs.X - mMousePosition.X;
                    int ldY         = aEventArgs.Y - mMousePosition.Y;
                    mMousePosition  = aEventArgs.Location;
                    moveSelected(ldX, ldY);
                }

                if (mCreate)
                {                 
                    int lW = aEventArgs.X - mMousePosition.X;
                    int lH = aEventArgs.Y - mMousePosition.Y;
                    mNewElement.resize(lW, lH, (Control.ModifierKeys & Keys.Shift) != 0);
                    panel_Draw.Invalidate();
                }

                if (mSelectionWork)
                {
                    int lX;
                    int lW;
                    if (mMousePosition.X < Cursor.Position.X)
                    {
                        lX = mMousePosition.X;
                        lW = Cursor.Position.X - lX;
                    }
                    else
                    {
                        lX = Cursor.Position.X;
                        lW = mMousePosition.X - lX;
                    }

                    int lY;
                    int lH;
                    if (mMousePosition.Y < Cursor.Position.Y)
                    {
                        lY = mMousePosition.Y;
                        lH = Cursor.Position.Y - lY;
                    }
                    else
                    {
                        lY = Cursor.Position.Y;
                        lH = mMousePosition.Y - lY;
                    }

                    mSelectionForm.Location = new Point(lX, lY);
                    mSelectionForm.Width    = lW;
                    mSelectionForm.Height   = lH;
                    mSelectionForm.Show();

                    mSelectionRect = mSelectionForm.RectangleToScreen(mSelectionForm.ClientRectangle);
                }

                updateXYWH(aEventArgs.X, aEventArgs.Y);
            }

            private void                    panel_Draw_MouseUp(object aSender, MouseEventArgs aEventArgs)
            {
                if (aEventArgs.Button == MouseButtons.Left)
                {
                    mMove = false;

                    if (mCreate)
                    {
                        mCreate = false;

                        mElements.Add(mNewElement);
                        listBox_Elements.Items.Add(mNewElement.Name);
                        mNewElement = null;      
                    }

                    if (mSelectionWork)
                    {
                        mSelectionWork = false;

                        mSelectionForm.Hide();
                        mSelectionForm.Dispose();
                        mSelectionForm  = null;
                    }

                    updateMenu();
                    redraw();

                    return;
                }
            }

            private void                    panel_Draw_MouseLeave(object aSender, EventArgs aEventArgs)
            {
                labelControl_XY.Visible = false;
                labelControl_HW.Visible = false;
            }

        #endregion

        #region Bring To Front, Send To Back

            private void                    addToElementIndex(int aIndex, int aAdd)
            {
                var lElement = mElements[aIndex];

                mElements.RemoveAt(aIndex);
                listBox_Elements.Items.RemoveAt(aIndex);

                aIndex = aIndex + aAdd;

                mElements.Insert(aIndex, lElement);
                listBox_Elements.Items.Insert(aIndex, mElements[aIndex].Name);

                listBox_Elements.SetSelected(aIndex, true);
            }

            private void                    sendToBackElements()
            {
                int lCount  = listBox_Elements.SelectedIndices.Count;

                if (listBox_Elements.SelectedIndices[0] > 0)
                {
                    addToElementIndex(listBox_Elements.SelectedIndices[0], -1);
                }
                int lLast = listBox_Elements.SelectedIndices[0] + 1;
             
                for(int i = 1; i < lCount; i++)
                {
                    if (listBox_Elements.SelectedIndices[i] > lLast)
                    {
                        addToElementIndex(listBox_Elements.SelectedIndices[i], lLast - listBox_Elements.SelectedIndices[i]);                       
                    }
                    lLast = lLast + 1;
                }

                panel_Draw.Invalidate();
            }

            private void                    bringToFrontElements()
            {
                int lCount  = listBox_Elements.SelectedIndices.Count;
                if (listBox_Elements.SelectedIndices[lCount - 1] < (listBox_Elements.Items.Count - 1))
                {
                    addToElementIndex(listBox_Elements.SelectedIndices[lCount - 1], 1);
                }

                int lLast = listBox_Elements.SelectedIndices[lCount - 1] - 1;

                for(int i = lCount - 2; i >= 0; i--)
                {
                    if (listBox_Elements.SelectedIndices[i] < lLast)
                    {
                        addToElementIndex(listBox_Elements.SelectedIndices[i], lLast - listBox_Elements.SelectedIndices[i]);                       
                    }
                    lLast = lLast - 1;
                }

                panel_Draw.Invalidate();
            }

        #endregion

        #region Copy, Paste, Delete

            private List<IVectorElement>    mCopyBuffer = new List<IVectorElement>();

            private void                    copy()
            {
                int lCount = mCopyBuffer.Count;
                if (lCount != 0)
                {
                    for (int i = 0; i < lCount; i++)
                    {
                        mCopyBuffer[i].Dispose();
                    }
                    mCopyBuffer.Clear();
                }

                if (listBox_Elements.SelectedItems.Count > 0)
                {
                    
                    lCount = listBox_Elements.SelectedIndices.Count;
                    for (int i = 0; i < lCount; i++)
                    {
                        mCopyBuffer.Add(mElements[listBox_Elements.SelectedIndices[i]].Clone);
                    }
                }

                updateMenu();
            }

            private void                    paste()
            {
                int lCount = mCopyBuffer.Count;
                if (lCount != 0)
                {
                    listBox_Elements.ClearSelected();
                    for (int i = 0; i < lCount; i++)
                    {
                        mElements.Add(mCopyBuffer[i].Clone);
                        listBox_Elements.Items.Add(mCopyBuffer[i].Name);
                        listBox_Elements.SetSelected(listBox_Elements.Items.Count - 1, true);
                    }
                }
            }

            private void                    delete()
            {
                int lIndex;
                for (int i = listBox_Elements.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    lIndex = listBox_Elements.SelectedIndices[i];
                    listBox_Elements.Items.RemoveAt(lIndex);
                    mElements[lIndex].Dispose();
                    mElements.RemoveAt(lIndex);
                }
            }

        #endregion

        #region Center, Align, Fit

            private void                    tsButton_CenterV_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = listBox_Elements.SelectedIndices.Count;
                if (lCount > 0)
                {
                    int lX;
                    if (mFirstSelected > -1 && lCount != 1)
                    {
                        lX = mElements[mFirstSelected].coverRect.X + mElements[mFirstSelected].coverRect.Width / 2;
                    }
                    else
                    {
                        lX = mPanelWidth / 2;
                    }
                        
                    for (int i = 0; i < lCount; i++)
                    {
                        mElements[listBox_Elements.SelectedIndices[i]].centerVertically(lX);
                    }

                    redraw();
                }
            }

            private void                    tsButton_CenterH_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = listBox_Elements.SelectedIndices.Count;
                if (lCount > 0)
                {
                    int lY;
                    if (mFirstSelected > -1 && lCount != 1)
                    {
                        lY = mElements[mFirstSelected].coverRect.Y + mElements[mFirstSelected].coverRect.Height / 2;
                    }
                    else
                    {
                        lY = mPanelHeight / 2;
                    }
     
                    for (int i = 0; i < lCount; i++)
                    {
                        mElements[listBox_Elements.SelectedIndices[i]].centerHorizantally(lY);
                    }

                    redraw();
                }
            }

            private void                    tsButton_AlignL_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = listBox_Elements.SelectedIndices.Count;
                if (lCount > 0)
                {           
                    int lX;  
                    if (mFirstSelected > -1 && lCount != 1)
                    {
                        lX = mElements[mFirstSelected].coverRect.Left;
                    }
                    else
                    {
                        lX = 0;
                    }
                         
                    for (int i = 0; i < lCount; i++)
                    {
                        mElements[listBox_Elements.SelectedIndices[i]].alignLeft(lX);
                    }

                    redraw();
                }
            }

            private void                    tsButton_AlignR_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = listBox_Elements.SelectedIndices.Count;
                if (lCount > 0)
                {
                    int lX;
                    if (mFirstSelected > -1 && lCount != 1)
                    {
                        lX = mElements[mFirstSelected].coverRect.Right + 1;
                    }
                    else
                    {
                        lX = mPanelWidth - 1;
                    }

                    for (int i = 0; i < lCount; i++)
                    {
                        mElements[listBox_Elements.SelectedIndices[i]].alignRight(lX);
                    }

                    redraw();
                }
            }

            private void                    tsButton_AlignT_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = listBox_Elements.SelectedIndices.Count;
                if (lCount > 0)
                {    
                    int lY;
                    if (mFirstSelected > -1 && lCount != 1)
                    {
                        lY = mElements[mFirstSelected].coverRect.Top;
                    }
                    else
                    {
                        lY = 0;
                    }
                              
                    for (int i = 0; i < lCount; i++)
                    {
                        mElements[listBox_Elements.SelectedIndices[i]].alignTop(lY);
                    }

                    redraw();
                }
            }

            private void                    tsButton_AlignB_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = listBox_Elements.SelectedIndices.Count;
                if (lCount > 0)
                {
                    int lY;
                    if (mFirstSelected > -1 && lCount != 1)
                    {
                        lY = mElements[mFirstSelected].coverRect.Bottom + 1;
                    }
                    else
                    {
                        lY = mPanelHeight - 1;
                    }

                    for (int i = 0; i < lCount; i++)
                    {
                        mElements[listBox_Elements.SelectedIndices[i]].alignBottom(lY);
                    }

                    redraw();
                }
            }

            private void                    tsButton_Fit_Click(object aSender, EventArgs aEventArgs)
            {
                int lCount = mElements.Count;
                if (lCount > 0)
                {
                    Rectangle lRect;

                    int lXShift         = 0;
                    int lYShift         = 0;

                    for(int i = 0; i < lCount; i++)
                    {
                        lRect = mElements[i].coverRect;

                        if (lRect.X < 0 && Math.Abs(lRect.X) > lXShift)
                        {
                            lXShift = Math.Abs(lRect.X);
                        }

                        if (lRect.Y < 0 && Math.Abs(lRect.Y) > lYShift)
                        {
                            lYShift = Math.Abs(lRect.Y);
                        }
                    }

                    for (int i = 0; i < lCount; i++)
                    {
                        if(lXShift != 0 || lYShift != 0)
                        {
                            mElements[i].move(lXShift, lYShift);
                        }
                    }

                    int lWidth  = 0;
                    int lHeight = 0;

                    for (int i = 0; i < lCount; i++)
                    {
                        lRect = mElements[i].coverRect;

                        if(lRect.X + lRect.Width > lWidth)
                        {
                            lWidth = lRect.X + lRect.Width;
                        }

                        if(lRect.Y + lRect.Height > lHeight)
                        {
                            lHeight = lRect.Y + lRect.Height;
                        }
                    }

                    if (lWidth != 0) { mPanelWidth = lWidth + 1; }
                    if (lHeight != 0) { mPanelHeight = lHeight + 1; }
                    
                    redraw();
                }
            }

        #endregion

        #region Options

            private bool                    mIsContainer;
            public bool                     IsContainer
            {
                get { return mIsContainer; }
                set { mIsContainer = value; }
            }

            public Color                    BackgroundColor
            {
                get { return panel_Draw.BackColor; }
                set { panel_Draw.BackColor = value; }
            }
            
            private void                    tsButton_Options_Click(object aSender, EventArgs aEventArgs)
            {
                using (Form lOptionsForm = new OptionsForm(this))
                {
                    lOptionsForm.ShowDialog(this);
                }
            }

        #endregion

        private void                        SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }

            if (listBox_Elements.SelectedItems.Count > 0)
            {
                int lDx = 0;
                int lDy = 0;

                if (aEventArgs.KeyCode == Keys.Up)
                {
                    lDy = -1;
                }
                else if (aEventArgs.KeyCode == Keys.Down)
                {
                    lDy = 1;
                }
                else if (aEventArgs.KeyCode == Keys.Left)
                {
                    lDx = -1;
                }
                else if (aEventArgs.KeyCode == Keys.Right)
                {
                    lDx = 1;
                }

                if (lDx != 0 || lDy != 0)
                {
                    moveSelected(lDx, lDy);
                    updateXYWH();
                    return;
                }

                if (aEventArgs.KeyCode == Keys.Delete)
                {
                    delete();
                }

                if (aEventArgs.Control && aEventArgs.KeyCode == Keys.C)
                {
                    copy();
                }

                if (aEventArgs.Control && aEventArgs.KeyCode == Keys.V)
                {
                    paste();
                }
            }
        }

        private void                        Ok()
        {
            mPanel.Elements         = mElements;
            mElements               = null;
            mPanel.IsContainer      = IsContainer;
            mPanel.BackgroundColor  = BackgroundColor;
            mPanel.Size             = new Size(mPanelWidth, mPanelHeight);
            mPanel.updateProperties();

            DialogResult = DialogResult.OK;
        }

        private void                        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            mPanel.mEditorSize   = mNormalSize;
            mPanel.mSplitterPos  = splitContainerControl.SplitterPosition;

            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                Ok();
            }
        }

        private void                        SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void             Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mBitmap != null)
                {
                    mBitmap.Dispose();
                    mBitmap = null;
                }

                if (mElements != null)
                {
                    int lCount = mElements.Count;
                    if (lCount > 0)
                    {
                        for (int i = 0; i < lCount; i++)
                        {
                            mElements[i].Dispose();
                        }
                        mElements.Clear();
                    }
                    mElements = null;
                }

                if (mCopyBuffer != null)
                {
                    int lCount = mCopyBuffer.Count;
                    if (lCount > 0)
                    {
                        for (int i = 0; i < lCount; i++)
                        {
                            mCopyBuffer[i].Dispose();
                        }
                        mCopyBuffer.Clear();
                    }
                    mCopyBuffer = null;
                }

                if (mNewElement != null)
                {
                    mNewElement.Dispose();
                    mNewElement = null;
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
