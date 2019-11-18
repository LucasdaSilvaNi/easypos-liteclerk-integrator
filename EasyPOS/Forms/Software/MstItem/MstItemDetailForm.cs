using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstItem
{
    public partial class MstItemDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public MstItemListForm mstItemListForm;
        public Entities.MstItemEntity mstItemEntity;

        public MstItemDetailForm(SysSoftwareForm softwareForm, MstItemListForm itemListForm, Entities.MstItemEntity itemEntity)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            sysUserRights = new Modules.SysUserRightsModule("MstItemDetail");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mstItemListForm = itemListForm;
                mstItemEntity = itemEntity;

                GetUnitList();
            }
        }

        public void GetUnitList()
        {
            Controllers.MstItemController mstItemController = new Controllers.MstItemController();
            if (mstItemController.DropdownListItemUnit().Any())
            {
                comboBoxUnit.DataSource = mstItemController.DropdownListItemUnit();
                comboBoxUnit.ValueMember = "Id";
                comboBoxUnit.DisplayMember = "Unit";

                GetSupplierList();
            }
        }

        public void GetSupplierList()
        {
            Controllers.MstItemController mstItemController = new Controllers.MstItemController();
            if (mstItemController.DropdownListItemSupplier().Any())
            {
                comboBoxDefaultSupplier.DataSource = mstItemController.DropdownListItemSupplier();
                comboBoxDefaultSupplier.ValueMember = "Id";
                comboBoxDefaultSupplier.DisplayMember = "Supplier";

                GetTaxList();
            }
        }

        public void GetTaxList()
        {
            Controllers.MstItemController mstItemController = new Controllers.MstItemController();
            if (mstItemController.DropdownListItemTax().Any())
            {
                comboBoxSalesVAT.DataSource = mstItemController.DropdownListItemTax();
                comboBoxSalesVAT.ValueMember = "Id";
                comboBoxSalesVAT.DisplayMember = "Tax";

                GetItemDetail();
            }
        }

        public void GetItemDetail()
        {
            UpdateComponents(mstItemEntity.IsLocked);

            textBoxItemCode.Text = mstItemEntity.ItemCode;
            textBoxBarcode.Text = mstItemEntity.BarCode;
            textBoxDescription.Text = mstItemEntity.ItemDescription;
            textBoxAlias.Text = mstItemEntity.Alias;
            textBoxCategory.Text = mstItemEntity.Category;
            comboBoxUnit.SelectedValue = mstItemEntity.UnitId;
            comboBoxDefaultSupplier.SelectedValue = mstItemEntity.DefaultSupplierId;
            textBoxCost.Text = mstItemEntity.Cost.ToString("#,##0.00");
            textBoxMarkUp.Text = mstItemEntity.MarkUp.ToString("#,##0.00");
            textBoxPrice.Text = mstItemEntity.Price.ToString("#,##0.00");
            textBoxStockLevelQuantity.Text = mstItemEntity.ReorderQuantity.ToString("#,##0.00");
            textBoxOnHandQuantity.Text = mstItemEntity.OnhandQuantity.ToString("#,##0.00");
            checkBoxIsInventory.Checked = mstItemEntity.IsInventory;
            checkBoxIsPackage.Checked = mstItemEntity.IsPackage;

            DateTime expiryDate = DateTime.Today;
            if (String.IsNullOrEmpty(mstItemEntity.ExpiryDate) == false)
            {
                expiryDate = Convert.ToDateTime(mstItemEntity.ExpiryDate);
            }

            dateTimePickerExpiryDate.Value = expiryDate;
            textBoxLotNumber.Text = mstItemEntity.LotNumber;
            textBoxRemarks.Text = mstItemEntity.Remarks;
            textBoxGenericName.Text = mstItemEntity.GenericName;
            comboBoxSalesVAT.SelectedValue = mstItemEntity.OutTaxId;
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

            textBoxBarcode.Enabled = !isLocked;
            textBoxDescription.Enabled = !isLocked;
            textBoxAlias.Enabled = !isLocked;
            textBoxCategory.Enabled = !isLocked;
            comboBoxUnit.Enabled = !isLocked;
            comboBoxDefaultSupplier.Enabled = !isLocked;
            textBoxCost.Enabled = !isLocked;
            textBoxMarkUp.Enabled = !isLocked;
            textBoxPrice.Enabled = !isLocked;
            textBoxStockLevelQuantity.Enabled = !isLocked;
            checkBoxIsInventory.Enabled = !isLocked;
            checkBoxIsPackage.Enabled = !isLocked;
            dateTimePickerExpiryDate.Enabled = !isLocked;
            textBoxLotNumber.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            textBoxGenericName.Enabled = !isLocked;
            comboBoxSalesVAT.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.MstItemController mstItemController = new Controllers.MstItemController();

            Entities.MstItemEntity newItemEntity = new Entities.MstItemEntity()
            {
                ItemCode = textBoxItemCode.Text,
                BarCode = textBoxBarcode.Text,
                ItemDescription = textBoxDescription.Text,
                Alias = textBoxAlias.Text,
                GenericName = textBoxGenericName.Text,
                Category = textBoxCategory.Text,
                OutTaxId = Convert.ToInt32(comboBoxSalesVAT.SelectedValue),
                UnitId = Convert.ToInt32(comboBoxUnit.SelectedValue),
                DefaultSupplierId = Convert.ToInt32(comboBoxDefaultSupplier.SelectedValue),
                Cost = Convert.ToDecimal(textBoxCost.Text),
                MarkUp = Convert.ToDecimal(textBoxMarkUp.Text),
                Price = Convert.ToDecimal(textBoxPrice.Text),
                ReorderQuantity = Convert.ToDecimal(textBoxStockLevelQuantity.Text),
                OnhandQuantity = Convert.ToDecimal(textBoxOnHandQuantity.Text),
                IsInventory = checkBoxIsInventory.Checked,
                IsPackage = checkBoxIsPackage.Checked,
                ExpiryDate = Convert.ToDateTime(dateTimePickerExpiryDate.Value).ToShortDateString(),
                LotNumber = textBoxLotNumber.Text,
                Remarks = textBoxRemarks.Text
            };

            String[] lockItem = mstItemController.LockItem(mstItemEntity.Id, newItemEntity);
            if (lockItem[1].Equals("0") == false)
            {
                UpdateComponents(true);
                mstItemListForm.UpdateItemListDataSource();
            }
            else
            {
                UpdateComponents(false);
                MessageBox.Show(lockItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.MstItemController mstItemController = new Controllers.MstItemController();

            String[] unlockItem = mstItemController.UnlockItem(mstItemEntity.Id);
            if (unlockItem[1].Equals("0") == false)
            {
                UpdateComponents(false);
                mstItemListForm.UpdateItemListDataSource();
            }
            else
            {
                UpdateComponents(true);
                MessageBox.Show(unlockItem[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
