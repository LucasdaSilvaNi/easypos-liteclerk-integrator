using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstDiscounting
{
    public partial class MstDiscountingDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public MstDiscountingListForm mstDiscountListForm;
        public Entities.MstDiscountEntity mstDiscountEntity;

        public MstDiscountingDetailForm(SysSoftwareForm softwareForm, MstDiscountingListForm itemListForm, Entities.MstDiscountEntity itemEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            sysUserRights = new Modules.SysUserRightsModule("MstDiscountDetail");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mstDiscountListForm = itemListForm;
                mstDiscountEntity = itemEntity;

                GetDiscountDetail();
            }
        }

        public void GetDiscountDetail()
        {
            UpdateComponents(mstDiscountEntity.IsLocked);
        }

        public void UpdateComponents(Boolean isLocked)
        {
            if (sysUserRights.GetUserRights().CanLock == false)
            {
                buttonLock.Enabled = false;
            }
            else
            {
                buttonLock.Enabled = !isLocked;
            }

            if (sysUserRights.GetUserRights().CanUnlock == false)
            {
                buttonUnlock.Enabled = false;
            }
            else
            {
                buttonUnlock.Enabled = isLocked;
            }
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstDiscountController mstDiscountController = new Controllers.MstDiscountController();

            Entities.MstDiscountEntity newDiscountEntity = new Entities.MstDiscountEntity()
            {

            };

            String[] lockDiscount = mstDiscountController.LockDiscount(mstDiscountEntity.Id, newDiscountEntity);
            if (lockDiscount[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstDiscountListForm.UpdateDiscountListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockDiscount[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstDiscountController mstDiscountController = new Controllers.MstDiscountController();

            String[] unlockDiscount = mstDiscountController.UnlockDiscount(mstDiscountEntity.Id);
            if (unlockDiscount[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstDiscountListForm.UpdateDiscountListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockDiscount[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void textBoxCost_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxMarkUp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxStockLevelQuantity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxOnHandQuantity_KeyPress(object sender, KeyPressEventArgs e)
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
