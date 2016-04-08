using System;
using System.Windows.Forms;
using API;
using Utils;
using Utils.DialogForms;

namespace Connection.Internal
{
    public partial class ItemSetupForm : Form
    {
        private DataItem    mItemInternal;
        private Connection  mConnectionInternal;

        public              ItemSetupForm(Connection aConnectioInternaln, DataItem aItemInternal, bool aNew)
        {
            mConnectionInternal = aConnectioInternaln;
            mItemInternal       = aItemInternal;
            InitializeComponent();

            if (aNew == false)
            {
                okCancelButton.setOkOnlyStyle();
            }

            mItemInternal.ValueChanged          += new EventHandler(onChange);
            mItemInternal.PropertiesChanged     += new EventHandler(onChange);
            mConnectionInternal.ConnectionState += new EventHandler(onChange);
            updateForm();
        }

        private void        onChange(object aSender, EventArgs aEventArgs)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => { updateForm(); }));
            }
            else
            {
                updateForm();
            }
        }

        private void        updateForm()
        {
            if (mConnectionInternal.Connected)
            {
                Text = "Internal Item";
            }
            else
            {
                Text = "Internal Item (Disconnected)";
            }

            if (mConnectionInternal.Connected && mItemInternal.Access.HasFlag(EAccess.READ))
            {
                if (mItemInternal.Value != null)
                {
                    label_ValueValue.Text   = StringUtils.ObjectToString(mItemInternal.Value);
                    label_TypeValue.Text    = mItemInternal.Value.GetType().Name;
                }
                else
                {
                    label_ValueValue.Text   = "null";
                    label_TypeValue.Text    = "N/A";
                }
            }
            else
            {
                label_ValueValue.Text   = "N/A";
                label_TypeValue.Text    = "N/A";
            }

            button_Write.Enabled = mConnectionInternal.Connected && mItemInternal.Access.HasFlag(EAccess.WRITE);

            if (mConnectionInternal.Connected)
            {
                switch (mItemInternal.Access)
                {
                    case EAccess.READ:          radioButton_R.Checked   = true; break;
                    case EAccess.WRITE:         radioButton_W.Checked   = true; break;
                    case EAccess.READ_WRITE:    radioButton_RW.Checked  = true; break;
                    case EAccess.NO_ACCESS:     radioButton_NA.Checked  = true; break;
                }
            }
            else
            {
                radioButton_NA.Checked = true;
            }

            radioButton_R.Enabled   = mConnectionInternal.Connected;
            radioButton_W.Enabled   = mConnectionInternal.Connected;
            radioButton_RW.Enabled  = mConnectionInternal.Connected;
            radioButton_NA.Enabled  = mConnectionInternal.Connected;
        }

        private void        button_Write_Click(object aSender, EventArgs aEventArgs)
        {
            object lValue;
            if (mItemInternal.Access.HasFlag(EAccess.READ))
            {
                lValue = mItemInternal.Value;
            }
            else
            {
                lValue = mItemInternal.InitValue;
            }

            lValue = ValueForm.getValue(lValue, this);
            if (lValue != null)
            {
                mItemInternal.Value = lValue;
            }
        }

        private void        radioButton_CheckedChanged(object aSender, EventArgs aEventArgs)
        {
            if (radioButton_R.Checked)
            {
                mItemInternal.Access = EAccess.READ;
            }

            if (radioButton_W.Checked)
            {
                mItemInternal.Access = EAccess.WRITE;
            }

            if (radioButton_RW.Checked)
            {
                mItemInternal.Access = EAccess.READ_WRITE;
            }

            if (radioButton_NA.Checked)
            {
                mItemInternal.Access = EAccess.NO_ACCESS;
            }
        }

        private void        okCancelButton_ButtonClick(object aSender, EventArgs aEventArgs)
        {
            DialogResult = okCancelButton.DialogResult;
        }

        private void        ItemSetupForm_FormClosed(object aSender, FormClosedEventArgs aEventArgs)
        {
            mItemInternal.ValueChanged          -= onChange;
            mItemInternal.PropertiesChanged     -= onChange;
            mConnectionInternal.ConnectionState -= onChange;
        }

        private void        ItemSetupForm_Load(object aSender, EventArgs aEventArgs)
        {
            ClientSize = FormUtils.calcClientSize(ClientSize, Controls);
        }
    }
}
