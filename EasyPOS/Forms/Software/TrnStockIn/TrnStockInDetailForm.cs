using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnStockInListForm trnStockInListForm;
        public Entities.TrnStockInEntity trnStockInEntity;

        public TrnStockInDetailForm(SysSoftwareForm softwareForm, TrnStockInListForm stockInListForm, Entities.TrnStockInEntity stockInEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnStockInListForm = stockInListForm;
            trnStockInEntity = stockInEntity;

            GetSupplierList();
        }

        public void GetSupplierList()
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();
            if (trnStockInController.DropdownListStockInSupplier().Any())
            {
                comboBoxSupplier.DataSource = trnStockInController.DropdownListStockInSupplier();
                comboBoxSupplier.ValueMember = "Id";
                comboBoxSupplier.DisplayMember = "Supplier";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();
            if (trnStockInController.DropdownListStockInUser().Any())
            {
                comboBoxPreparedBy.DataSource = trnStockInController.DropdownListStockInUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnStockInController.DropdownListStockInUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnStockInController.DropdownListStockInUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetStockInDetail();
            }
        }

        public void GetStockInDetail()
        {
            UpdateComponents(trnStockInEntity.IsLocked);

            textBoxStockInNumber.Text = trnStockInEntity.StockInNumber;
            dateTimePickerStockInDate.Value = Convert.ToDateTime(trnStockInEntity.StockInDate);
            comboBoxSupplier.SelectedValue = trnStockInEntity.SupplierId;
            textBoxRemarks.Text = trnStockInEntity.Remarks;
            checkBoxReturn.Checked = trnStockInEntity.IsReturn;
            textBoxReturnORNumber.Text = trnStockInEntity.CollectionNumber;
            textBoxReturnSalesNumber.Text = trnStockInEntity.SalesNumber;
            comboBoxPreparedBy.SelectedValue = trnStockInEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnStockInEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnStockInEntity.ApprovedBy;
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = isLocked;

            dateTimePickerStockInDate.Enabled = !isLocked;
            comboBoxSupplier.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            checkBoxReturn.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();

            Entities.TrnStockInEntity newStockInEntity = new Entities.TrnStockInEntity()
            {
                StockInDate = dateTimePickerStockInDate.Value.Date.ToShortDateString(),
                SupplierId = Convert.ToInt32(comboBoxSupplier.SelectedValue),
                Remarks = textBoxRemarks.Text,
                IsReturn = checkBoxReturn.Checked,
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            String[] lockStockIn = trnStockInController.LockStockIn(trnStockInEntity.Id, newStockInEntity);
            if (lockStockIn[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnStockInListForm.UpdateStockInListDataSource();
            }
            else
            {
                MessageBox.Show(lockStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockInController trnStockInController = new Controllers.TrnStockInController();

            String[] unlockStockIn = trnStockInController.UnlockStockIn(trnStockInEntity.Id);
            if (unlockStockIn[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnStockInListForm.UpdateStockInListDataSource();
            }
            else
            {
                MessageBox.Show(unlockStockIn[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}
