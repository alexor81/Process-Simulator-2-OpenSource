// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using Utils.CSharpScript;
using Utils.DialogForms;

namespace SimulationObject.Script.CSharpFSM
{
    public partial class SetupForm : Form
    {
        private CSharpFSM           mCSharpFSM;
        private CSharpFSM           mCSharpFSMClone;
        private IItemBrowser        mBrowser;
        private GViewer             mGViewer;

        public                      SetupForm(CSharpFSM aCSharpFSM, IItemBrowser aBrowser)
        {
            mCSharpFSM                  = aCSharpFSM;
            mBrowser                    = aBrowser;

            mCSharpFSMClone             = new CSharpFSM();
            mCSharpFSMClone.ItemBrowser = mBrowser;
            mCSharpFSMClone.clone(mCSharpFSM);
 
            InitializeComponent();

            mGViewer                                = new GViewer();
            mGViewer.Dock                           = DockStyle.Fill;
            mGViewer.ToolBarIsVisible               = false;
            mGViewer.ObjectUnderMouseCursorChanged  += MGViewer_ObjectUnderMouseCursorChanged;
            mGViewer.MouseClick                     += MGViewer_MouseClick;
            panel_Graph.Controls.Add(mGViewer);

            updateForm();
            updateButtons();
        }

        #region Node Selection

            private Node            mSelectedNode;
            private Node            mNodeUnderCursor;

            private void            MGViewer_MouseClick(object aSender, MouseEventArgs aEventArgs)
            {
                mSelectedNode = mNodeUnderCursor;
                updateButtons();

                if(aEventArgs.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    tsButton_Setup_Click(this, EventArgs.Empty);
                }
            }

            private void            MGViewer_ObjectUnderMouseCursorChanged(object aSender, ObjectUnderMouseCursorChangedEventArgs aEventArgs)
            {
                DNode lDNode = aEventArgs.NewObject as DNode;
                if (lDNode != null)
                {
                    mNodeUnderCursor = lDNode.Node;
                }
                else
                {
                    mNodeUnderCursor = null;
                }
            }

        #endregion

        #region Size

            private bool            mMaximized;
            private Size            mNormalSize;
            private Point           mNormalLocation;
            protected override void WndProc(ref Message aMessage)
            {
                if (aMessage.Msg == (int)WM.NCLBUTTONDBLCLK)
                {
                    if (mMaximized)
                    {
                        Size = mNormalSize;
                        Location = mNormalLocation;

                        mMaximized = false;
                    }
                    else
                    {
                        Size lSize = Size;
                        mNormalLocation = Location;
                        Screen lScreen = Screen.FromControl(this);
                        Size = lScreen.WorkingArea.Size;
                        mNormalSize = lSize;
                        Location = lScreen.WorkingArea.Location;

                        mMaximized = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

            private void            SetupForm_SizeChanged(object aSender, EventArgs aEventArgs)
            {
                mNormalSize = Size;
            }

        #endregion

        private void                updateForm()
        {
            var lGraph                  = new Graph();
            lGraph.Attr.BackgroundColor = Microsoft.Msagl.Drawing.Color.Transparent;

            Node lNode;
            string[] lStates    = mCSharpFSMClone.StateList;
            for(int i = 0; i < lStates.Length; i++)
            {
                lNode           = new Node(lStates[i]);
                lNode.LabelText = lStates[i];
                if (i == 0)
                {
                    lNode.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Green;
                }

                lGraph.AddNode(lNode);
            }

            string[] lConnections;
            foreach (string lState in lStates)
            {
                lConnections = mCSharpFSMClone.getStateConnections(lState);
                foreach(string lConnection in lConnections)
                {
                    if (mCSharpFSMClone.isStateExists(lConnection))
                    {
                        lGraph.AddEdge(lState, lConnection);
                    }
                }
            }

            mGViewer.Graph  = lGraph;
            mSelectedNode   = null;
        }

        private void                updateButtons()
        {
            bool lSelected          = (mSelectedNode != null);
            tsButton_Delete.Enabled = lSelected;
            tsButton_Setup.Enabled  = lSelected;
            tsButton_Rename.Enabled = lSelected;
            tsButton_First.Enabled  = lSelected && mCSharpFSMClone.isFirstState(mSelectedNode.LabelText);
        }

        private void                tsButton_Add_Click(object aSender, EventArgs aEventArgs)
        {
            bool lExit  = false;
            var lName   = "State" + (mCSharpFSMClone.StateCount + 1).ToString();

            do
            {
                try
                {
                    lName = StringForm.getString(lName, this, "Add State");
                    if (lName != null)
                    {
                        if(mCSharpFSMClone.isStateExists(lName))
                        {
                            throw new ArgumentException("State '" + lName + "' already exists. ");
                        }

                        CSScipt lScript = new CSScipt(mBrowser);
                        if(lScript.setupByForm(lName, this) == DialogResult.OK)
                        {
                            mCSharpFSMClone.addState(lName, lScript);

                            updateForm();
                            updateButtons();
                        }

                        lExit = true;
                    }
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
            while (lName != null && lExit == false);
        }

        private void                tsButton_Delete_Click(object aSender, EventArgs aEventArgs)
        {
            if (mSelectedNode != null)
            {
                try
                {
                    if (QuestionForm.askQuestion("Delete State '" + mSelectedNode.LabelText + "'?", this) == DialogResult.Yes)
                    {
                        mCSharpFSMClone.deleteState(mSelectedNode.LabelText);

                        updateForm();
                        updateButtons();
                    }
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                tsButton_Setup_Click(object aSender, EventArgs aEventArgs)
        {
            if(mSelectedNode != null)
            {
                try
                {
                    mCSharpFSMClone.setupScript(mSelectedNode.LabelText, this);

                    updateForm();
                    updateButtons();
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                tsButton_Rename_Click(object aSender, EventArgs aEventArgs)
        {
            if (mSelectedNode != null)
            {
                string lName = mSelectedNode.LabelText;
                string lNewName;
                bool lExit = false;

                do
                {
                    try
                    {
                        lNewName = StringForm.getString(lName, this, "Rename State");
                        if (lNewName != null)
                        {
                            mCSharpFSMClone.renameState(lName, lNewName);

                            updateForm();
                            updateButtons();
                        }
                        lExit = true;
                    }
                    catch (Exception lExc)
                    {
                        MessageForm.showMessage(lExc.Message, this);
                    }
                }
                while (lExit == false);
            }
        }

        private void                tsButton_First_Click(object aSender, EventArgs aEventArgs)
        {
            if (mSelectedNode != null)
            {
                try
                {
                    mCSharpFSMClone.setFirstState(mSelectedNode.LabelText);

                    updateForm();
                    updateButtons();
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                tsButton_Refresh_Click(object aSender, EventArgs aEventArgs)
        {
            mGViewer.Graph = mGViewer.Graph;
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            if (okCancelButton.DialogResult == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                try
                {
                    mCSharpFSMClone.check();

                    mCSharpFSM.clearAllStates();
                    mCSharpFSM.clone(mCSharpFSMClone);

                    mCSharpFSMClone = null;

                    DialogResult = DialogResult.OK;
                }
                catch (Exception lExc)
                {
                    MessageForm.showMessage(lExc.Message, this);
                }
            }
        }

        private void                SetupForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                SetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mGViewer != null)
                {
                    mGViewer.MouseClick                     -= MGViewer_MouseClick;
                    mGViewer.ObjectUnderMouseCursorChanged  -= MGViewer_ObjectUnderMouseCursorChanged;
                    mGViewer.Dispose();
                    mGViewer = null;
                }

                if(mCSharpFSMClone != null)
                {
                    mCSharpFSMClone.Dispose();
                    mCSharpFSMClone = null;
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
