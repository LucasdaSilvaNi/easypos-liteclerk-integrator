using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstCustomer
{
    public partial class MstCustomerDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public MstCustomerListForm mstCustomerListForm;
        public Entities.MstCustomerEntity mstCustomerEntity;

        public MstCustomerDetailForm(SysSoftwareForm softwareForm, MstCustomerListForm itemListForm, Entities.MstCustomerEntity itemEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            mstCustomerListForm = itemListForm;
            mstCustomerEntity = itemEntity;

            GetTermList();
        }

        public void GetTermList()
        {
            Controllers.MstCustomerController mstCustomerController = new Controllers.MstCustomerController();
            if (mstCustomerController.DropdownListCustomerTerm().Any())
            {
                comboBoxTerm.DataSource = mstCustomerController.DropdownListCustomerTerm();
                comboBoxTerm.ValueMember = "Id";
                comboBoxTerm.DisplayMember = "Term";

                GetCustomerDetail();
            }
        }

        public void GetCustomerDetail()
        {
            UpdateComponents(mstCustomerEntity.IsLocked);

            textBoxCustomerCode.Text = mstCustomerEntity.CustomerCode;
            textBoxCustomer.Text = mstCustomerEntity.Customer;
            textBoxAddress.Text = mstCustomerEntity.Address;
            textBoxContactPerson.Text = mstCustomerEntity.ContactPerson;
            textBoxContactNumber.Text = mstCustomerEntity.ContactNumber;
            textBoxCreditLimit.Text = mstCustomerEntity.CreditLimit.ToString("#,##0.00");
            comboBoxTerm.SelectedValue = mstCustomerEntity.TermId;
            textBoxTIN.Text = mstCustomerEntity.TIN;
            checkBoxWithReward.Checked = mstCustomerEntity.WithReward;
            textBoxRewardNumber.Text = mstCustomerEntity.RewardNumber;
            textBoxRewardConversion.Text = mstCustomerEntity.RewardConversion.ToString("#,##0.00");
            textBoxAvailableReward.Text = mstCustomerEntity.AvailableReward.ToString("#,##0.00");
            textBoxDefaultPrice.Text = mstCustomerEntity.DefaultPriceDescription;
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;

            textBoxCustomerCode.ReadOnly = isLocked;
            textBoxCustomer.ReadOnly = isLocked;
            textBoxAddress.ReadOnly = isLocked;
            textBoxContactPerson.ReadOnly = isLocked;
            textBoxContactNumber.ReadOnly = isLocked;
            textBoxCreditLimit.ReadOnly = isLocked;
            comboBoxTerm.Enabled = !isLocked;
            textBoxTIN.ReadOnly = isLocked;
            checkBoxWithReward.Enabled = !isLocked;
            textBoxRewardNumber.ReadOnly = isLocked;
            textBoxRewardConversion.ReadOnly = isLocked;
            textBoxDefaultPrice.ReadOnly = isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstCustomerController mstCustomerController = new Controllers.MstCustomerController();

            Entities.MstCustomerEntity newCustomerEntity = new Entities.MstCustomerEntity()
            {
                CustomerCode = textBoxCustomerCode.Text,
                Customer = textBoxCustomer.Text,
                Address = textBoxAddress.Text,
                ContactPerson = textBoxContactPerson.Text,
                ContactNumber = textBoxContactNumber.Text,
                CreditLimit = Convert.ToDecimal(textBoxCreditLimit.Text),
                TermId = Convert.ToInt32(comboBoxTerm.SelectedValue),
                TIN = textBoxTIN.Text,
                WithReward = checkBoxWithReward.Checked,
                RewardNumber = textBoxRewardNumber.Text,
                RewardConversion = Convert.ToDecimal(textBoxRewardConversion.Text),
                AvailableReward = Convert.ToDecimal(textBoxAvailableReward.Text),
                DefaultPriceDescription = textBoxDefaultPrice.Text,
            };

            String[] lockCustomer = mstCustomerController.LockCustomer(mstCustomerEntity.Id, newCustomerEntity);
            if (lockCustomer[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstCustomerListForm.UpdateCustomerListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockCustomer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstCustomerController mstCustomerController = new Controllers.MstCustomerController();

            String[] unlockCustomer = mstCustomerController.UnlockCustomer(mstCustomerEntity.Id);
            if (unlockCustomer[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstCustomerListForm.UpdateCustomerListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockCustomer[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void textBoxCreditLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxRewardConversion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxAvailableReward_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
