// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utils;
using Utils.Logger;

namespace Connection.OPCUA
{
    public partial class OPCNodesBrowserForm : Form
    {
        private Connection          mConnection;
        private Browser             mBrowser;

        public                      OPCNodesBrowserForm(Connection aConnection)
        {
            mConnection = aConnection;
            InitializeComponent();

            updateForm();
        }

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
                        Size        = mNormalSize;
                        Location    = mNormalLocation;
                        mMaximized  = false;
                    }
                    else
                    {
                        mNormalSize     = Size;
                        mNormalLocation = Location;
                        Screen lScreen  = Screen.FromControl(this);
                        Size            = lScreen.WorkingArea.Size;
                        Location        = lScreen.WorkingArea.Location;
                        mMaximized      = true;
                    }
                }

                base.WndProc(ref aMessage);
            }

        #endregion

        private void                updateForm()
        {
            treeView_Browser.Nodes.Clear();

            mBrowser = null;
            try
            {
                mBrowser = new Browser(mConnection.mSession);
            }
            catch (Exception lExc)
            {
                Log.Error("Error getting OPC Nodes browser from server '" 
                    + mConnection.mServerName + "' at host '" + mConnection.mHost + "'. " + lExc.Message, lExc.ToString());
            }

            if (mBrowser != null)
            {
                mBrowser.ReferenceTypeId = ReferenceTypes.HierarchicalReferences;

                TreeNode lNode;
                treeView_Browser.BeginUpdate();
                Cursor = Cursors.WaitCursor;
                //================================
                try
                { 
                    var lResult = mBrowser.Browse(new NodeId(Objects.RootFolder, 0));
                    foreach(var lBranch in lResult)
                    {
                        lNode = new TreeNode(lBranch.BrowseName.Name);
                        if(lBranch.NodeClass.Equals(NodeClass.Variable))
                        {
                            lNode.ImageIndex            = 1;
                            lNode.SelectedImageIndex    = 1;
                        }
                        lNode.Tag   = lBranch;
                        lNode.Nodes.Add("");

                        treeView_Browser.Nodes.Add(lNode);
                    }
                }
                catch (Exception lExc)
                {
                    Log.Error("Error getting OPC Node list from server '" 
                        + mConnection.mServerName + "' at host '" + mConnection.mHost + "'. " + lExc.Message, lExc.ToString());
                    treeView_Browser.Nodes.Clear();
                    treeView_Browser.Nodes.Add("Error getting OPC Node list", "Error getting OPC Node list", 2, 2);
                }
                finally
                {
                    //================================
                    treeView_Browser.EndUpdate();
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                treeView_Browser.Nodes.Clear();
                treeView_Browser.Nodes.Add("Error getting OPC Node list", "Error getting OPC Node list", 2, 2);
            }

            toolStripLabel_NodeId.Text = NodeId;
        }

        private void                treeView_Browser_DoubleClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = DialogResult.OK;
        }

        private void                treeView_Browser_BeforeExpand(object aSender, TreeViewCancelEventArgs aEventArgs)
        {
            if(aEventArgs.Node.Nodes.Count == 1 && String.IsNullOrWhiteSpace(aEventArgs.Node.Nodes[0].Name.ToString()))
            {
                aEventArgs.Node.Nodes.Clear();

                TreeNode lNode;
                treeView_Browser.BeginUpdate();
                Cursor = Cursors.WaitCursor;
                //================================
                try
                {
                    var lResult = mBrowser.Browse((NodeId)((ReferenceDescription)aEventArgs.Node.Tag).NodeId);
                    foreach (var lBranch in lResult)
                    {
                        lNode = new TreeNode(lBranch.BrowseName.Name);
                        if (lBranch.NodeClass.Equals(NodeClass.Variable))
                        {
                            lNode.ImageIndex            = 1;
                            lNode.SelectedImageIndex    = 1;
                        }
                        lNode.Tag = lBranch;
                        lNode.Nodes.Add("");

                        aEventArgs.Node.Nodes.Add(lNode);
                    }
                }
                catch (Exception lExc)
                {
                    Log.Error("Error getting OPC Node list from server '"
                        + mConnection.mServerName + "' at host '" + mConnection.mHost + "'. " + lExc.Message, lExc.ToString());
                    aEventArgs.Node.Nodes.Add("Error getting OPC Node list", "Error getting OPC Node list", 2, 2);
                }
                finally
                {
                    //================================
                    treeView_Browser.EndUpdate();
                    Cursor = Cursors.Default;
                }
            }
        }

        private void                tsButton_Refresh_Click(object aSender, EventArgs aEventArgs)
        {
            updateForm();
        }

        private void                treeView_Browser_AfterSelect(object aSender, TreeViewEventArgs aEventArgs)
        {
            string lNodeId = NodeId;

            if (String.IsNullOrWhiteSpace(lNodeId) == false)
            {
                try
                {
                    if (mConnection.Connected && String.IsNullOrWhiteSpace(aEventArgs.Node.ToolTipText))
                    {
                        var lResult = mConnection.readAttribute(new NodeId(lNodeId), Attributes.Description);
                        if (lResult != null)
                        {
                            aEventArgs.Node.ToolTipText = lResult[0].Value.ToString();
                        }
                    }
                }
                catch (Exception lExc)
                {
                    toolStripLabel_NodeId.Text = "";
                    Log.Error(lExc.Message, lExc.ToString());
                    return;
                }
            }

            toolStripLabel_NodeId.Text = lNodeId;
        }

        private void                OPCNodesBrowserForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        public string               NodeId
        {
            get
            {
                if (treeView_Browser.SelectedNode == null || treeView_Browser.SelectedNode.Tag == null)
                {
                    return "";
                }

                try
                {
                    return ((NodeId)(((ReferenceDescription)treeView_Browser.SelectedNode.Tag).NodeId)).ToString();
                }
                catch (Exception lExc)
                {
                    Log.Error(lExc.Message, lExc.ToString());
                    return "";
                }
            }
        }
    }
}
