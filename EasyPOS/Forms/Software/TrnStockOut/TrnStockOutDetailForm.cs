using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnStockOut
{
    public partial class TrnStockOutDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnStockOutListForm trnStockOutListForm;
        public Entities.TrnStockOutEntity trnStockOutEntity;

        public TrnStockOutDetailForm(SysSoftwareForm softwareForm, TrnStockOutListForm stockOutListForm, Entities.TrnStockOutEntity stockOutEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnStockOutListForm = stockOutListForm;
            trnStockOutEntity = stockOutEntity;

            GetAccountList();
        }

        public void GetAccountList()
        {
            Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();
            if (trnStockOutController.DropdownListStockOutAccount().Any())
            {
                comboBoxAccount.DataSource = trnStockOutController.DropdownListStockOutAccount();
                comboBoxAccount.ValueMember = "Id";
                comboBoxAccount.DisplayMember = "Account";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();
            if (trnStockOutController.DropdownListStockOutUser().Any())
            {
                comboBoxPreparedBy.DataSource = trnStockOutController.DropdownListStockOutUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnStockOutController.DropdownListStockOutUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnStockOutController.DropdownListStockOutUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetStockOutDetail();
            }
        }

        public void GetStockOutDetail()
        {
            UpdateComponents(trnStockOutEntity.IsLocked);

            textBoxStockOutNumber.Text = trnStockOutEntity.StockOutNumber;
            dateTimePickerStockOutDate.Value = Convert.ToDateTime(trnStockOutEntity.StockOutDate);
            comboBoxAccount.SelectedValue = trnStockOutEntity.AccountId;
            textBoxRemarks.Text = trnStockOutEntity.Remarks;
            comboBoxPreparedBy.SelectedValue = trnStockOutEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnStockOutEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnStockOutEntity.ApprovedBy;
        }

        public void UpdateComponents(Boolean isLocked)
        {
            buttonLock.Enabled = !isLocked;
            buttonUnlock.Enabled = isLocked;
            buttonPrint.Enabled = isLocked;

            dateTimePickerStockOutDate.Enabled = !isLocked;
            comboBoxAccount.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();

            Entities.TrnStockOutEntity newStockOutEntity = new Entities.TrnStockOutEntity()
            {
                StockOutDate = dateTimePickerStockOutDate.Value.Date.ToShortDateString(),
                AccountId = Convert.ToInt32(comboBoxAccount.SelectedValue),
                Remarks = textBoxRemarks.Text,
                CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue)
            };

            String[] lockStockOut = trnStockOutController.LockStockOut(trnStockOutEntity.Id, newStockOutEntity);
            if (lockStockOut[1].Equals("0") == false)
            {
                UpdateComponents(true);
                trnStockOutListForm.UpdateStockOutListDataSource();
            }
            else
            {
                MessageBox.Show(lockStockOut[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnStockOutController trnStockOutController = new Controllers.TrnStockOutController();

            String[] unlockStockOut = trnStockOutController.UnlockStockOut(trnStockOutEntity.Id);
            if (unlockStockOut[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnStockOutListForm.UpdateStockOutListDataSource();
            }
            else
            {
                MessageBox.Show(unlockStockOut[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
