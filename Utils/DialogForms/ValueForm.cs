// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Windows.Forms;
using Utils.Logger;
using Utils.SpecialControls;

namespace Utils.DialogForms
{
    public partial class ValueForm : Form
    {
        private static ValueForm    mValueForm;

        public static object        getValue(object aValue, IWin32Window aOwner)
        {
            if (mValueForm == null)
            {
                mValueForm = new ValueForm();
            }
            mValueForm.Value = aValue;

            do
            {
                if (mValueForm.ShowDialog(aOwner) == DialogResult.OK)
                {
                    try
                    {
                        return mValueForm.Value;
                    }
                    catch (Exception lExc)
                    {
                        Log.Error("User value input error. " + lExc.Message, lExc.ToString());
                        MessageForm.showMessage(lExc.Message, aOwner);
                    }
                }
                else
                {
                    return null;
                }
            } while (true);
        }

        private                     ValueForm()
        {
            InitializeComponent();
            comboBox_Type.Items.AddRange(StringUtils.TypesNames);
            comboBox_Type.Items.Add("Not supported");
            comboBox_Type.SelectedIndex = 0;
        }

        private object              Value
        {
            set
            {
                if (value == null)
                {
                    checkBox_Array.Checked  = false;
                    spinEdit_Length.Enabled = false;
                    spinEdit_Length.Value   = 1;
                    spinEdit_Length_EditValueChanged(this, EventArgs.Empty);
                    Type                    = null;
                    return;
                }

                bool lisArray   = false;
                int lLength     = 1;
                if (value is Array)
                {
                    if (((Array)value).Rank == 1)
                    {
                        lisArray    = true;
                        lLength     = ((Array)value).Length;
                    }
                }

                if (lisArray)
                {
                    checkBox_Array.Checked  = true;
                    spinEdit_Length.Enabled = true;   
                }
                else
                {
                    checkBox_Array.Checked  = false;
                    spinEdit_Length.Enabled = false;
                }

                spinEdit_Length.Value = lLength;
                spinEdit_Length_EditValueChanged(this, EventArgs.Empty);

                if (lisArray)
                {
                    Type = value.GetType().GetElementType();
                    Array lArray = value as Array;
                    for (int i = 0; i < lLength; i++)
                    {
                        if (lArray.GetValue(i) != null)
                        {
                            ((ValueControl)tabControl_Value.TabPages[i].Controls[0]).setValue(lArray.GetValue(i));
                        }
                    }
                }
                else
                {
                    Type = value.GetType();
                    ((ValueControl)tabControl_Value.TabPages[0].Controls[0]).setValue(value);
                }
            }
            get
            {
                Type lType = Type;
                if (lType == null)
                {
                    throw new InvalidOperationException("Type is not supported. ");
                }

                string lValueString;
                object lValue;

                if (checkBox_Array.Checked)
                {
                    int lCount = (int)spinEdit_Length.Value;
                    Array lArray = Array.CreateInstance(lType, lCount);

                    for (int i = 0; i < lCount; i++)
                    {
                        lValueString = ((ValueControl)tabControl_Value.TabPages[i].Controls[0]).getValueString();
                        try
                        {                           
                            lValue = StringUtils.StringToObject(lType, lValueString);
                        }
                        catch (Exception lExc)
                        {
                            throw new InvalidOperationException("Type conversion error for array element [" + StringUtils.ObjectToString(i) + "]. " + lExc.Message, lExc);
                        }

                        lArray.SetValue(lValue, i);
                    }

                    return lArray;
                }
                else
                {
                    return StringUtils.StringToObject(lType, ((ValueControl)tabControl_Value.TabPages[0].Controls[0]).getValueString());
                }
            }
        }

        private Type                Type
        {
            set
            {
                if(StringUtils.isTypeSupported(value))
                {
                    comboBox_Type.SelectedIndex = StringUtils.getIndexByType(value);
                }
                else
                {
                    comboBox_Type.SelectedIndex = comboBox_Type.Items.Count - 1;
                }
            }
            get
            {
                if (comboBox_Type.SelectedIndex == comboBox_Type.Items.Count - 1)
                {
                    return null;
                }

                return StringUtils.getTypeByIndex(comboBox_Type.SelectedIndex);
            }
        }

        private void                checkBox_Array_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (checkBox_Array.Checked)
            {
                spinEdit_Length.Enabled = true;
            }
            else
            {
                spinEdit_Length.Enabled = false;
                spinEdit_Length.Value = 1;
                spinEdit_Length_EditValueChanged(this, EventArgs.Empty);
            }
        }

        private void                spinEdit_Length_EditValueChanged(object aSender, EventArgs aEventArgs)
        {
            int lNewLength = (int)spinEdit_Length.Value;
            int lCurrLength = tabControl_Value.TabCount;

            if (lNewLength != lCurrLength)
            {
                TabPage lTabPage;
                if (lNewLength > lCurrLength)
                {
                    ValueControl lValueControl;
                    Type lType = Type;
                    int lAdd = lNewLength - lCurrLength;
                    for (int i = 0; i < lAdd; i++)
                    {
                        lValueControl = new ValueControl();
                        lValueControl.setType(lType);
                        lValueControl.Left  = tabControl_Value.Width / 2 - lValueControl.Width / 2;
                        lTabPage            = new TabPage(StringUtils.ObjectToString(lCurrLength + i));
                        lTabPage.Controls.Add(lValueControl);
                        tabControl_Value.TabPages.Add(lTabPage);
                    }
                }
                else
                {
                    while (tabControl_Value.TabCount != lNewLength)
                    {
                        lTabPage = tabControl_Value.TabPages[tabControl_Value.TabCount - 1];
                        tabControl_Value.TabPages.Remove(lTabPage);
                        lTabPage.Controls[0].Dispose();
                        lTabPage.Dispose();
                    }
                }
            }
        }

        private void                comboBox_Type_SelectedIndexChanged(object aSender, EventArgs aEventArgs)
        {
            Type lType = Type;
            int lCount = tabControl_Value.TabPages.Count;
            for (int i = 0; i < lCount; i++)
            {
                ((ValueControl)tabControl_Value.TabPages[i].Controls[0]).setType(lType);
            }
        }

        private void                okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void                ValueForm_KeyDown(object aSender, KeyEventArgs aEventArgs)
        {
            if (aEventArgs.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void                ValueForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }

        protected override void     Dispose(bool disposing)
        {
            if (disposing)
            {
                TabPage lTabPage;

                while (tabControl_Value.TabPages.Count != 0)
                {
                    lTabPage = tabControl_Value.TabPages[0];
                    tabControl_Value.TabPages.Remove(lTabPage);
                    lTabPage.Controls[0].Dispose();
                    lTabPage.Dispose();
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
