// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils.NameValueList;

namespace Utils.Panels.ObjectDropDownList
{
    public partial class DropDownListPanel : UserControl, IPanel
    {
        private IObjectValueReadWrite   mObjectValue;
        private NameValueHolder         mHolder = new NameValueHolder(false, false);
         
        public                          DropDownListPanel(IObjectValueReadWrite aObjectValue)
        {
            mObjectValue = aObjectValue;
            InitializeComponent();

            BackColor           = SystemColors.Control;
            mHolder.ListChanged += MHolder_ListChanged;
            mHolder.add("Current value", mObjectValue.ValueObject, false);     
        }

        private void                    MHolder_ListChanged(object aSender, EventArgs aEventArgs)
        {
            comboBox.Items.Clear();

            if (mHolder.Count > 0)
            {
                var Names   = mHolder.Names;
                int lWidth  = 0;
                int lTextW;
                foreach (string lName in Names)
                {
                    lTextW = TextRenderer.MeasureText(lName, comboBox.Font).Width;
                    if (lTextW > lWidth)
                    {
                        lWidth = lTextW;
                    }
                }
                Width = lWidth + SystemInformation.VerticalScrollBarWidth;

                comboBox.Items.AddRange(Names);
            }
        }

        public void                     fillForDemo()
        {
        }

        public void                     loadFromXML(XmlTextReader aXMLTextReader)
        {
            mHolder.clear();

            if (aXMLTextReader.IsEmptyElement == false)
            {
                aXMLTextReader.Read();
                if (aXMLTextReader.Name.Equals("ItemList", StringComparison.Ordinal))
                {
                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        mHolder.loadFromXML(aXMLTextReader, "Item");
                    }

                    aXMLTextReader.Read();
                }          
            }

            if (mHolder.Count == 0)
            {
                mHolder.add("Current value", mObjectValue.ValueObject, false);
            }
        }

        public void                     saveToXML(XmlTextWriter aXMLTextWriter)
        {
            aXMLTextWriter.WriteStartElement("ItemList");
                mHolder.saveToXML(aXMLTextWriter, "Item");
            aXMLTextWriter.WriteEndElement();
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return false; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new NameValueForm(mHolder, "Drop Down List"))
            {
                lSetupForm.ShowDialog(aOwner);
            }
        }

        public string                   LabelText
        {
            set { }
            get { return ""; }
        }

        public void                     updateValues()
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateV(); }));
            }
            else
            {
                updateV();
            }
        }
        private void                    updateV()
        {
            if (mHolder.Count > 0)
            {
                var lNames = mHolder.Names;
                for (int i = 0; i < lNames.Length; i++)
                {
                    if (ValuesCompare.isEqual(mHolder.getValue(lNames[i]), mObjectValue.ValueObject))
                    {
                        mNoUpdate = true;
                        try
                        {
                            comboBox.SelectedIndex = i;
                        }
                        finally
                        {
                            mNoUpdate = false;
                        }
                        return;
                    }
                }
            }

            comboBox.SelectedIndex = -1;
        }

        public void                     updateProperties()
        {
        }

        private volatile bool           mNoUpdate;
        private void                    comboBox_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            if (mNoUpdate || comboBox.SelectedIndex == -1) return;

            mObjectValue.ValueObject = mHolder.getValue(comboBox.SelectedItem.ToString());
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing)
            {
                mObjectValue = null;

                if(mHolder != null)
                {
                    mHolder.ListChanged -= MHolder_ListChanged;
                    mHolder.clear();
                    mHolder = null;
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
