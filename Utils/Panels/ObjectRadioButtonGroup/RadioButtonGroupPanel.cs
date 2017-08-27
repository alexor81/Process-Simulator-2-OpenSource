// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Utils.NameValueList;

namespace Utils.Panels.ObjectRadioButtonGroup
{
    public partial class RadioButtonGroupPanel : UserControl, IPanel
    {
        private IObjectValueReadWrite   mObjectValue;
        private NameValueHolder         mHolder = new NameValueHolder(false, false);

        public                          RadioButtonGroupPanel(IObjectValueReadWrite aObjectValue)
        {
            mObjectValue = aObjectValue;
            InitializeComponent();

            BackColor           = SystemColors.Control;
            mHolder.ListChanged += MHolder_ListChanged;
            mHolder.add("Current value", mObjectValue.ValueObject, false);          
        }

        private void                    MHolder_ListChanged(object aSender, EventArgs aEventArgs)
        {
            clearRB();

            if (mHolder.Count > 0)
            {
                RadioButton lRB;
                Height      = 22;
                Width       = 22;

                int lY      = 0;
                int lW      = 0;
                var lNames  = mHolder.Names;
                for (int i = 0; i < lNames.Length; i++)
                {
                    lRB                 = new RadioButton();
                    lRB.AutoSize        = true;
                    lRB.Text            = lNames[i];
                    lRB.Top             = lY;
                    lRB.CheckedChanged  += new EventHandler(RB_CheckedChanged);
                    mRB.Add(lRB);
                    Controls.Add(lRB);

                    lY = lY + lRB.Height + 1;
                    if (lRB.Width > lW)
                    {
                        lW = lRB.Width + 1;
                    }
                }

                Height  = lY;
                Width   = lW;
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
                if (aXMLTextReader.Name.Equals("RadioButtons", StringComparison.Ordinal))
                {
                    if (aXMLTextReader.IsEmptyElement == false)
                    {
                        mHolder.loadFromXML(aXMLTextReader, "RadioButton");
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
            aXMLTextWriter.WriteStartElement("RadioButtons");
                mHolder.saveToXML(aXMLTextWriter, "RadioButton");
            aXMLTextWriter.WriteEndElement();
        }

        public UserControl              UserControl { get { return this; } }

        public bool                     IsScalable { get { return false; } }

        public bool                     IsTransparent { get { return false; } }

        public bool                     IsConfigurable { get { return true; } }

        public bool                     IsContainer { get { return false; } }

        public void                     setupByForm(IWin32Window aOwner)
        {
            using (var lSetupForm = new NameValueForm(mHolder, "Radio Button"))
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
                var lNames  = mHolder.Names;
                mNoUpdate   = true;
                try
                {
                    for (int i = 0; i < lNames.Length; i++)
                    {
                        mRB[i].Checked = ValuesCompare.isEqual(mHolder.getValue(lNames[i]), mObjectValue.ValueObject);
                    }
                }
                finally
                {
                    mNoUpdate = false;
                }
            }
        }

        public void                     updateProperties()
        {
        }

        private List<RadioButton>       mRB = new List<RadioButton>();
        private void                    clearRB()
        {
            RadioButton lRB;
            while (mRB.Count > 0)
            {
                lRB                 = mRB[0];
                lRB.CheckedChanged  -= RB_CheckedChanged;
                Controls.Remove(lRB);
                mRB.RemoveAt(0);
                lRB.Dispose();    
            }
        }

        private volatile bool           mNoUpdate;
        private void                    RB_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (mNoUpdate) return;

            RadioButton lRB = (RadioButton)aSender;

            if (lRB.Checked)
            {
                mObjectValue.ValueObject = mHolder.getValue(lRB.Text);
            }
        }

        protected override void         Dispose(bool disposing)
        {
            if (disposing)
            {
                mObjectValue = null;

                if (mHolder != null)
                {
                    mHolder.ListChanged -= MHolder_ListChanged;
                    mHolder.clear();
                    mHolder = null;
                }

                if(mRB != null)
                {
                    clearRB();
                    mRB = null;
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
