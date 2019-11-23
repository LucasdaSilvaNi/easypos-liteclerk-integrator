using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysSystemTables
{
    public partial class SysSystemTablesForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public static Int32 pageSize = 50;

        public static List<Entities.DgvSystemTablesAccountListEntity> accountListData = new List<Entities.DgvSystemTablesAccountListEntity>();
        public PagedList<Entities.DgvSystemTablesAccountListEntity> accountListPageList = new PagedList<Entities.DgvSystemTablesAccountListEntity>(accountListData, accountListPageNumber, pageSize);
        public BindingSource accountListDataSource = new BindingSource();
        public static Int32 accountListPageNumber = 1;

        public static List<Entities.DgvSystemTablesPayTypeListEntity> payTypeListData = new List<Entities.DgvSystemTablesPayTypeListEntity>();
        public PagedList<Entities.DgvSystemTablesPayTypeListEntity> payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, accountListPageNumber, pageSize);
        public BindingSource payTypeListDataSource = new BindingSource();
        public static Int32 payTypeListPageNumber = 1;

        public static List<Entities.DgvSystemTablesTaxListEntity> taxListData = new List<Entities.DgvSystemTablesTaxListEntity>();
        public PagedList<Entities.DgvSystemTablesTaxListEntity> taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, accountListPageNumber, pageSize);
        public BindingSource taxListDataSource = new BindingSource();
        public static Int32 taxListPageNumber = 1;

        public static List<Entities.DgvSystemTablesUnitListEntity> unitListData = new List<Entities.DgvSystemTablesUnitListEntity>();
        public PagedList<Entities.DgvSystemTablesUnitListEntity> unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, accountListPageNumber, pageSize);
        public BindingSource unitListDataSource = new BindingSource();
        public static Int32 unitListPageNumber = 1;

        public static List<Entities.DgvSystemTablesPeriodListEntity> periodListData = new List<Entities.DgvSystemTablesPeriodListEntity>();
        public PagedList<Entities.DgvSystemTablesPeriodListEntity> periodListPageList = new PagedList<Entities.DgvSystemTablesPeriodListEntity>(periodListData, accountListPageNumber, pageSize);
        public BindingSource periodListDataSource = new BindingSource();
        public static Int32 periodListPageNumber = 1;

        public static List<Entities.DgvSystemTablesTerminalListEntity> terminalListData = new List<Entities.DgvSystemTablesTerminalListEntity>();
        public PagedList<Entities.DgvSystemTablesTerminalListEntity> terminalListPageList = new PagedList<Entities.DgvSystemTablesTerminalListEntity>(terminalListData, accountListPageNumber, pageSize);
        public BindingSource terminalListDataSource = new BindingSource();
        public static Int32 terminalListPageNumber = 1;

        public static List<Entities.DgvSystemTablesSupplierListEntity> supplierListData = new List<Entities.DgvSystemTablesSupplierListEntity>();
        public PagedList<Entities.DgvSystemTablesSupplierListEntity> supplierListPageList = new PagedList<Entities.DgvSystemTablesSupplierListEntity>(supplierListData, accountListPageNumber, pageSize);
        public BindingSource supplierListDataSource = new BindingSource();
        public static Int32 supplierListPageNumber = 1;

        public SysSystemTablesForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            CreateAccountListDataGridView();
            CreatePayTypeListDataGridView();
            CreateTaxListDataGridView();
            CreateUnitListDataGridView();
            CreatePeriodListDataGridView();
            CreateTerminalListDataGridView();
            CreateSupplierListDataGridView();
        }

        // =======
        // Account
        // =======
        public void UpdateAccountListDataSource()
        {
            SetAccountListDataSourceAsync();
        }

        public async void SetAccountListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesAccountListEntity> getAccountListData = await GetAccountListDataTask();
            if (getAccountListData.Any())
            {
                accountListData = getAccountListData;
                accountListPageList = new PagedList<Entities.DgvSystemTablesAccountListEntity>(accountListData, accountListPageNumber, pageSize);

                if (accountListPageList.PageCount == 1)
                {
                    buttonAccountListPageListFirst.Enabled = false;
                    buttonAccountListPageListPrevious.Enabled = false;
                    buttonAccountListPageListNext.Enabled = false;
                    buttonAccountListPageListLast.Enabled = false;
                }
                else if (accountListPageNumber == 1)
                {
                    buttonAccountListPageListFirst.Enabled = false;
                    buttonAccountListPageListPrevious.Enabled = false;
                    buttonAccountListPageListNext.Enabled = true;
                    buttonAccountListPageListLast.Enabled = true;
                }
                else if (accountListPageNumber == accountListPageList.PageCount)
                {
                    buttonAccountListPageListFirst.Enabled = true;
                    buttonAccountListPageListPrevious.Enabled = true;
                    buttonAccountListPageListNext.Enabled = false;
                    buttonAccountListPageListLast.Enabled = false;
                }
                else
                {
                    buttonAccountListPageListFirst.Enabled = true;
                    buttonAccountListPageListPrevious.Enabled = true;
                    buttonAccountListPageListNext.Enabled = true;
                    buttonAccountListPageListLast.Enabled = true;
                }

                textBoxAccountListPageNumber.Text = accountListPageNumber + " / " + accountListPageList.PageCount;
                accountListDataSource.DataSource = accountListPageList;
            }
            else
            {
                buttonAccountListPageListFirst.Enabled = false;
                buttonAccountListPageListPrevious.Enabled = false;
                buttonAccountListPageListNext.Enabled = false;
                buttonAccountListPageListLast.Enabled = false;

                accountListPageNumber = 1;

                accountListData = new List<Entities.DgvSystemTablesAccountListEntity>();
                accountListDataSource.Clear();
                textBoxAccountListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesAccountListEntity>> GetAccountListDataTask()
        {
            String filter = textBoxAccountListFilter.Text;
            Controllers.MstAccountController mstAccountController = new Controllers.MstAccountController();

            List<Entities.MstAccountEntity> listAccount = mstAccountController.ListAccount(filter);
            if (listAccount.Any())
            {
                var accounts = from d in listAccount
                               select new Entities.DgvSystemTablesAccountListEntity
                               {
                                   ColumnAccountListButtonEdit = "Edit",
                                   ColumnAccountListButtonDelete = "Delete",
                                   ColumnAccountListId = d.Id,
                                   ColumnAccountListCode = d.Code,
                                   ColumnAccountListAccount = d.Account,
                                   ColumnAccountListAccountType = d.AccountType
                               };

                return Task.FromResult(accounts.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesAccountListEntity>());
            }
        }

        public void CreateAccountListDataGridView()
        {
            UpdateAccountListDataSource();

            dataGridViewAccountList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewAccountList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewAccountList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewAccountList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewAccountList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewAccountList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewAccountList.DataSource = accountListDataSource;
        }

        public void GetAccountListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonAccountListPageListFirst_Click(object sender, EventArgs e)
        {
            accountListPageList = new PagedList<Entities.DgvSystemTablesAccountListEntity>(accountListData, 1, pageSize);
            accountListDataSource.DataSource = accountListPageList;

            buttonAccountListPageListFirst.Enabled = false;
            buttonAccountListPageListPrevious.Enabled = false;
            buttonAccountListPageListNext.Enabled = true;
            buttonAccountListPageListLast.Enabled = true;

            accountListPageNumber = 1;
            textBoxAccountListPageNumber.Text = accountListPageNumber + " / " + accountListPageList.PageCount;
        }

        private void buttonAccountListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (accountListPageList.HasPreviousPage == true)
            {
                accountListPageList = new PagedList<Entities.DgvSystemTablesAccountListEntity>(accountListData, --accountListPageNumber, pageSize);
                accountListDataSource.DataSource = accountListPageList;
            }

            buttonAccountListPageListNext.Enabled = true;
            buttonAccountListPageListLast.Enabled = true;

            if (accountListPageNumber == 1)
            {
                buttonAccountListPageListFirst.Enabled = false;
                buttonAccountListPageListPrevious.Enabled = false;
            }

            textBoxAccountListPageNumber.Text = accountListPageNumber + " / " + accountListPageList.PageCount;
        }

        private void buttonAccountListPageListNext_Click(object sender, EventArgs e)
        {
            if (accountListPageList.HasNextPage == true)
            {
                accountListPageList = new PagedList<Entities.DgvSystemTablesAccountListEntity>(accountListData, ++accountListPageNumber, pageSize);
                accountListDataSource.DataSource = accountListPageList;
            }

            buttonAccountListPageListFirst.Enabled = true;
            buttonAccountListPageListPrevious.Enabled = true;

            if (accountListPageNumber == accountListPageList.PageCount)
            {
                buttonAccountListPageListNext.Enabled = false;
                buttonAccountListPageListLast.Enabled = false;
            }

            textBoxAccountListPageNumber.Text = accountListPageNumber + " / " + accountListPageList.PageCount;
        }

        private void buttonAccountListPageListLast_Click(object sender, EventArgs e)
        {
            accountListPageList = new PagedList<Entities.DgvSystemTablesAccountListEntity>(accountListData, accountListPageList.PageCount, pageSize);
            accountListDataSource.DataSource = accountListPageList;

            buttonAccountListPageListFirst.Enabled = true;
            buttonAccountListPageListPrevious.Enabled = true;
            buttonAccountListPageListNext.Enabled = false;
            buttonAccountListPageListLast.Enabled = false;

            accountListPageNumber = accountListPageList.PageCount;
            textBoxAccountListPageNumber.Text = accountListPageNumber + " / " + accountListPageList.PageCount;
        }

        private void dataGridViewAccountList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetAccountListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewAccountList.CurrentCell.ColumnIndex == dataGridViewAccountList.Columns["ColumnAccountListButtonEdit"].Index)
            {
                Entities.MstAccountEntity account = new Entities.MstAccountEntity
                {
                    Id = Convert.ToInt32(dataGridViewAccountList.Rows[e.RowIndex].Cells[2].Value),
                    Code = dataGridViewAccountList.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Account = dataGridViewAccountList.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    AccountType = dataGridViewAccountList.Rows[e.RowIndex].Cells[5].Value.ToString()
                };

                SysSystemTablesAccountDetailForm sysSystemTablesAccountDetailForm = new SysSystemTablesAccountDetailForm(this, account);
                sysSystemTablesAccountDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewAccountList.CurrentCell.ColumnIndex == dataGridViewAccountList.Columns["ColumnAccountListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Account?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstAccountController mstAccountController = new Controllers.MstAccountController();

                    String[] deleteAccount = mstAccountController.DeleteAccount(Convert.ToInt32(dataGridViewAccountList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteAccount[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = accountListPageNumber;

                        accountListPageNumber = 1;
                        UpdateAccountListDataSource();

                        if (accountListPageList != null)
                        {
                            if (accountListData.Count() % pageSize == 1)
                            {
                                accountListPageNumber = currentPageNumber - 1;
                            }
                            else if (accountListData.Count() < 1)
                            {
                                accountListPageNumber = 1;
                            }
                            else
                            {
                                accountListPageNumber = currentPageNumber;
                            }

                            accountListDataSource.DataSource = accountListPageList;
                        }
                    }
                    else
                    {
                        MessageBox.Show(deleteAccount[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBoxAccountListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateAccountListDataSource();
            }
        }

        // ========
        // Pay Type
        // ========
        public void UpdatePayTypeListDataSource()
        {
            SetPayTypeListDataSourceAsync();
        }

        public async void SetPayTypeListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesPayTypeListEntity> getPayTypeListData = await GetPayTypeListDataTask();
            if (getPayTypeListData.Any())
            {
                payTypeListData = getPayTypeListData;
                payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, payTypeListPageNumber, pageSize);

                if (payTypeListPageList.PageCount == 1)
                {
                    buttonPayTypeListPageListFirst.Enabled = false;
                    buttonPayTypeListPageListPrevious.Enabled = false;
                    buttonPayTypeListPageListNext.Enabled = false;
                    buttonPayTypeListPageListLast.Enabled = false;
                }
                else if (payTypeListPageNumber == 1)
                {
                    buttonPayTypeListPageListFirst.Enabled = false;
                    buttonPayTypeListPageListPrevious.Enabled = false;
                    buttonPayTypeListPageListNext.Enabled = true;
                    buttonPayTypeListPageListLast.Enabled = true;
                }
                else if (payTypeListPageNumber == payTypeListPageList.PageCount)
                {
                    buttonPayTypeListPageListFirst.Enabled = true;
                    buttonPayTypeListPageListPrevious.Enabled = true;
                    buttonPayTypeListPageListNext.Enabled = false;
                    buttonPayTypeListPageListLast.Enabled = false;
                }
                else
                {
                    buttonPayTypeListPageListFirst.Enabled = true;
                    buttonPayTypeListPageListPrevious.Enabled = true;
                    buttonPayTypeListPageListNext.Enabled = true;
                    buttonPayTypeListPageListLast.Enabled = true;
                }

                textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
                payTypeListDataSource.DataSource = payTypeListPageList;
            }
            else
            {
                buttonPayTypeListPageListFirst.Enabled = false;
                buttonPayTypeListPageListPrevious.Enabled = false;
                buttonPayTypeListPageListNext.Enabled = false;
                buttonPayTypeListPageListLast.Enabled = false;

                payTypeListPageNumber = 1;

                payTypeListData = new List<Entities.DgvSystemTablesPayTypeListEntity>();
                payTypeListDataSource.Clear();
                textBoxPayTypeListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesPayTypeListEntity>> GetPayTypeListDataTask()
        {
            String filter = textBoxPayTypeListFilter.Text;
            Controllers.MstPayTypeController mstPayTypeController = new Controllers.MstPayTypeController();

            List<Entities.MstPayTypeEntity> listPayType = mstPayTypeController.ListPayType(filter);
            if (listPayType.Any())
            {
                var payTypes = from d in listPayType
                               select new Entities.DgvSystemTablesPayTypeListEntity
                               {
                                   ColumnPayTypeListButtonEdit = "Edit",
                                   ColumnPayTypeListButtonDelete = "Delete",
                                   ColumnPayTypeListId = d.Id,
                                   ColumnPayTypeListPayType = d.PayType,
                                   ColumnAccountId = Convert.ToInt32(d.AccountId),
                                   ColumnPayTypeListAccount = d.Account
                               };

                return Task.FromResult(payTypes.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesPayTypeListEntity>());
            }
        }

        public void CreatePayTypeListDataGridView()
        {
            UpdatePayTypeListDataSource();

            dataGridViewPayTypeList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPayTypeList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPayTypeList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPayTypeList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPayTypeList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPayTypeList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPayTypeList.DataSource = payTypeListDataSource;
        }

        private void textBoxPayTypeListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePayTypeListDataSource();
            }
        }

        private void dataGridViewPayTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetPayTypeListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewPayTypeList.CurrentCell.ColumnIndex == dataGridViewPayTypeList.Columns["ColumnPayTypeListButtonEdit"].Index)
            {
                Entities.MstPayTypeEntity selectePaytype = new Entities.MstPayTypeEntity()
                {
                    Id = Convert.ToInt32(dataGridViewPayTypeList.Rows[e.RowIndex].Cells[2].Value),
                    PayType = dataGridViewPayTypeList.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    AccountId = Convert.ToInt32(dataGridViewPayTypeList.Rows[e.RowIndex].Cells[4].Value)
                };
                SysSystemTablesPayTypeDetailForm sysSystemTablesPayTypeDetailForm = new SysSystemTablesPayTypeDetailForm(this, selectePaytype);
                sysSystemTablesPayTypeDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewPayTypeList.CurrentCell.ColumnIndex == dataGridViewPayTypeList.Columns["ColumnPayTypeListButtonDelete"].Index)
            {

                DialogResult deleteDialogResult = MessageBox.Show("Delete PayType?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstPayTypeController mstPayTypeController = new Controllers.MstPayTypeController();

                    String[] deletePayType = mstPayTypeController.DeletePayType(Convert.ToInt32(dataGridViewPayTypeList.Rows[e.RowIndex].Cells[2].Value));
                    if (deletePayType[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = payTypeListPageNumber;

                        payTypeListPageNumber = 1;
                        UpdatePayTypeListDataSource();

                        if (payTypeListPageList != null)
                        {
                            if (payTypeListData.Count() % pageSize == 1)
                            {
                                payTypeListPageNumber = currentPageNumber - 1;
                            }
                            else if (payTypeListData.Count() < 1)
                            {
                                payTypeListPageNumber = 1;
                            }
                            else
                            {
                                payTypeListPageNumber = currentPageNumber;
                            }

                            payTypeListDataSource.DataSource = payTypeListPageList;
                        }
                    }
                    else
                    {
                        MessageBox.Show(deletePayType[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetPayTypeListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonPayTypeListPageListFirst_Click(object sender, EventArgs e)
        {
            payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, 1, pageSize);
            payTypeListDataSource.DataSource = payTypeListPageList;

            buttonPayTypeListPageListFirst.Enabled = false;
            buttonPayTypeListPageListPrevious.Enabled = false;
            buttonPayTypeListPageListNext.Enabled = true;
            buttonPayTypeListPageListLast.Enabled = true;

            payTypeListPageNumber = 1;
            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        private void buttonPayTypeListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (payTypeListPageList.HasPreviousPage == true)
            {
                payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, --payTypeListPageNumber, pageSize);
                payTypeListDataSource.DataSource = payTypeListPageList;
            }

            buttonPayTypeListPageListNext.Enabled = true;
            buttonPayTypeListPageListLast.Enabled = true;

            if (payTypeListPageNumber == 1)
            {
                buttonPayTypeListPageListFirst.Enabled = false;
                buttonPayTypeListPageListPrevious.Enabled = false;
            }

            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        private void buttonPayTypeListPageListNext_Click(object sender, EventArgs e)
        {
            if (payTypeListPageList.HasNextPage == true)
            {
                payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, ++payTypeListPageNumber, pageSize);
                payTypeListDataSource.DataSource = payTypeListPageList;
            }

            buttonPayTypeListPageListFirst.Enabled = true;
            buttonPayTypeListPageListPrevious.Enabled = true;

            if (payTypeListPageNumber == payTypeListPageList.PageCount)
            {
                buttonPayTypeListPageListNext.Enabled = false;
                buttonPayTypeListPageListLast.Enabled = false;
            }

            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        private void buttonPayTypeListPageListLast_Click(object sender, EventArgs e)
        {
            payTypeListPageList = new PagedList<Entities.DgvSystemTablesPayTypeListEntity>(payTypeListData, payTypeListPageList.PageCount, pageSize);
            payTypeListDataSource.DataSource = payTypeListPageList;

            buttonPayTypeListPageListFirst.Enabled = true;
            buttonPayTypeListPageListPrevious.Enabled = true;
            buttonPayTypeListPageListNext.Enabled = false;
            buttonPayTypeListPageListLast.Enabled = false;

            payTypeListPageNumber = payTypeListPageList.PageCount;
            textBoxPayTypeListPageNumber.Text = payTypeListPageNumber + " / " + payTypeListPageList.PageCount;
        }

        // ===
        // Tax
        // ===
        public void UpdateTaxListDataSource()
        {
            SetTaxListDataSourceAsync();
        }

        public async void SetTaxListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesTaxListEntity> getTaxListData = await GetTaxListDataTask();
            if (getTaxListData.Any())
            {
                taxListData = getTaxListData;
                taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, taxListPageNumber, pageSize);

                if (taxListPageList.PageCount == 1)
                {
                    buttonTaxListPageListFirst.Enabled = false;
                    buttonTaxListPageListPrevious.Enabled = false;
                    buttonTaxListPageListNext.Enabled = false;
                    buttonTaxListPageListLast.Enabled = false;
                }
                else if (taxListPageNumber == 1)
                {
                    buttonTaxListPageListFirst.Enabled = false;
                    buttonTaxListPageListPrevious.Enabled = false;
                    buttonTaxListPageListNext.Enabled = true;
                    buttonTaxListPageListLast.Enabled = true;
                }
                else if (taxListPageNumber == taxListPageList.PageCount)
                {
                    buttonTaxListPageListFirst.Enabled = true;
                    buttonTaxListPageListPrevious.Enabled = true;
                    buttonTaxListPageListNext.Enabled = false;
                    buttonTaxListPageListLast.Enabled = false;
                }
                else
                {
                    buttonTaxListPageListFirst.Enabled = true;
                    buttonTaxListPageListPrevious.Enabled = true;
                    buttonTaxListPageListNext.Enabled = true;
                    buttonTaxListPageListLast.Enabled = true;
                }

                textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
                taxListDataSource.DataSource = taxListPageList;
            }
            else
            {
                buttonTaxListPageListFirst.Enabled = false;
                buttonTaxListPageListPrevious.Enabled = false;
                buttonTaxListPageListNext.Enabled = false;
                buttonTaxListPageListLast.Enabled = false;

                taxListPageNumber = 1;

                taxListData = new List<Entities.DgvSystemTablesTaxListEntity>();
                taxListDataSource.Clear();
                textBoxTaxListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesTaxListEntity>> GetTaxListDataTask()
        {
            String filter = textBoxTaxListFilter.Text;
            Controllers.MstTaxController mstTaxController = new Controllers.MstTaxController();

            List<Entities.MstTaxEntity> listTax = mstTaxController.ListTax(filter);
            if (listTax.Any())
            {
                var taxs = from d in listTax
                           select new Entities.DgvSystemTablesTaxListEntity
                           {
                               ColumnTaxListButtonEdit = "Edit",
                               ColumnTaxListButtonDelete = "Delete",
                               ColumnTaxListId = d.Id,
                               ColumnTaxListCode = d.Code,
                               ColumnTaxListTax = d.Tax,
                               ColumnTaxListRate = d.Rate.ToString("#,##0.00"),
                               ColumnTaxListAccountId = d.AccountId,
                               ColumnTaxListAccount = d.Account
                           };

                return Task.FromResult(taxs.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesTaxListEntity>());
            }
        }

        public void CreateTaxListDataGridView()
        {
            UpdateTaxListDataSource();

            dataGridViewTaxList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewTaxList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewTaxList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewTaxList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewTaxList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewTaxList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewTaxList.DataSource = taxListDataSource;
        }

        private void textBoxTaxListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTaxListDataSource();
            }
        }

        private void dataGridViewTaxList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetTaxListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewTaxList.CurrentCell.ColumnIndex == dataGridViewTaxList.Columns["ColumnTaxListButtonEdit"].Index)
            {
                Entities.MstTaxEntity selectedTax = new Entities.MstTaxEntity()
                {
                    Id = Convert.ToInt32(dataGridViewTaxList.Rows[e.RowIndex].Cells[2].Value),
                    Code = dataGridViewTaxList.Rows[e.RowIndex].Cells[3].Value.ToString(),
                    Tax = dataGridViewTaxList.Rows[e.RowIndex].Cells[4].Value.ToString(),
                    Rate = Convert.ToDecimal(dataGridViewTaxList.Rows[e.RowIndex].Cells[5].Value),
                    AccountId = Convert.ToInt32(dataGridViewTaxList.Rows[e.RowIndex].Cells[6].Value)
                };

                SysSystemTablesTaxDetailForm sysSystemTablesTaxDetailForm = new SysSystemTablesTaxDetailForm(this, selectedTax);
                sysSystemTablesTaxDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewTaxList.CurrentCell.ColumnIndex == dataGridViewTaxList.Columns["ColumnTaxListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Tax?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstTaxController mstTaxController = new Controllers.MstTaxController();

                    String[] deleteTax = mstTaxController.DeleteTax(Convert.ToInt32(dataGridViewTaxList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteTax[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = taxListPageNumber;

                        taxListPageNumber = 1;
                        UpdateTaxListDataSource();

                        if (taxListPageList != null)
                        {
                            if (taxListData.Count() % pageSize == 1)
                            {
                                taxListPageNumber = currentPageNumber - 1;
                            }
                            else if (taxListData.Count() < 1)
                            {
                                taxListPageNumber = 1;
                            }
                            else
                            {
                                taxListPageNumber = currentPageNumber;
                            }

                            taxListDataSource.DataSource = taxListPageList;
                        }
                    }
                    else
                    {
                        MessageBox.Show(deleteTax[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetTaxListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonTaxListPageListFirst_Click(object sender, EventArgs e)
        {
            taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, 1, pageSize);
            taxListDataSource.DataSource = taxListPageList;

            buttonTaxListPageListFirst.Enabled = false;
            buttonTaxListPageListPrevious.Enabled = false;
            buttonTaxListPageListNext.Enabled = true;
            buttonTaxListPageListLast.Enabled = true;

            taxListPageNumber = 1;
            textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
        }

        private void buttonTaxListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (taxListPageList.HasPreviousPage == true)
            {
                taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, --taxListPageNumber, pageSize);
                taxListDataSource.DataSource = taxListPageList;
            }

            buttonTaxListPageListNext.Enabled = true;
            buttonTaxListPageListLast.Enabled = true;

            if (taxListPageNumber == 1)
            {
                buttonTaxListPageListFirst.Enabled = false;
                buttonTaxListPageListPrevious.Enabled = false;
            }

            textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
        }

        private void buttonTaxListPageListNext_Click(object sender, EventArgs e)
        {
            if (taxListPageList.HasNextPage == true)
            {
                taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, ++taxListPageNumber, pageSize);
                taxListDataSource.DataSource = taxListPageList;
            }

            buttonTaxListPageListFirst.Enabled = true;
            buttonTaxListPageListPrevious.Enabled = true;

            if (taxListPageNumber == taxListPageList.PageCount)
            {
                buttonTaxListPageListNext.Enabled = false;
                buttonTaxListPageListLast.Enabled = false;
            }

            textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
        }

        private void buttonTaxListPageListLast_Click(object sender, EventArgs e)
        {
            taxListPageList = new PagedList<Entities.DgvSystemTablesTaxListEntity>(taxListData, taxListPageList.PageCount, pageSize);
            taxListDataSource.DataSource = taxListPageList;

            buttonTaxListPageListFirst.Enabled = true;
            buttonTaxListPageListPrevious.Enabled = true;
            buttonTaxListPageListNext.Enabled = false;
            buttonTaxListPageListLast.Enabled = false;

            taxListPageNumber = taxListPageList.PageCount;
            textBoxTaxListPageNumber.Text = taxListPageNumber + " / " + taxListPageList.PageCount;
        }

        // ====
        // Unit
        // ====
        public void UpdateUnitListDataSource()
        {
            SetUnitListDataSourceAsync();
        }

        public async void SetUnitListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesUnitListEntity> getUnitListData = await GetUnitListDataTask();
            if (getUnitListData.Any())
            {
                unitListData = getUnitListData;
                unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, unitListPageNumber, pageSize);

                if (unitListPageList.PageCount == 1)
                {
                    buttonUnitListPageListFirst.Enabled = false;
                    buttonUnitListPageListPrevious.Enabled = false;
                    buttonUnitListPageListNext.Enabled = false;
                    buttonUnitListPageListLast.Enabled = false;
                }
                else if (unitListPageNumber == 1)
                {
                    buttonUnitListPageListFirst.Enabled = false;
                    buttonUnitListPageListPrevious.Enabled = false;
                    buttonUnitListPageListNext.Enabled = true;
                    buttonUnitListPageListLast.Enabled = true;
                }
                else if (unitListPageNumber == unitListPageList.PageCount)
                {
                    buttonUnitListPageListFirst.Enabled = true;
                    buttonUnitListPageListPrevious.Enabled = true;
                    buttonUnitListPageListNext.Enabled = false;
                    buttonUnitListPageListLast.Enabled = false;
                }
                else
                {
                    buttonUnitListPageListFirst.Enabled = true;
                    buttonUnitListPageListPrevious.Enabled = true;
                    buttonUnitListPageListNext.Enabled = true;
                    buttonUnitListPageListLast.Enabled = true;
                }

                textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
                unitListDataSource.DataSource = unitListPageList;
            }
            else
            {
                buttonUnitListPageListFirst.Enabled = false;
                buttonUnitListPageListPrevious.Enabled = false;
                buttonUnitListPageListNext.Enabled = false;
                buttonUnitListPageListLast.Enabled = false;

                unitListPageNumber = 1;

                unitListData = new List<Entities.DgvSystemTablesUnitListEntity>();
                unitListDataSource.Clear();
                textBoxUnitListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesUnitListEntity>> GetUnitListDataTask()
        {
            String filter = textBoxUnitListFilter.Text;
            Controllers.MstUnitController mstUnitController = new Controllers.MstUnitController();

            List<Entities.MstUnitEntity> listUnit = mstUnitController.ListUnit(filter);
            if (listUnit.Any())
            {
                var units = from d in listUnit
                            select new Entities.DgvSystemTablesUnitListEntity
                            {
                                ColumnUnitListButtonEdit = "Edit",
                                ColumnUnitListButtonDelete = "Delete",
                                ColumnUnitListId = d.Id,
                                ColumnUnitListUnit = d.Unit
                            };

                return Task.FromResult(units.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesUnitListEntity>());
            }
        }

        public void CreateUnitListDataGridView()
        {
            UpdateUnitListDataSource();

            dataGridViewUnitList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUnitList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewUnitList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUnitList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUnitList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewUnitList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewUnitList.DataSource = unitListDataSource;
        }

        private void textBoxUnitListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateUnitListDataSource();
            }
        }

        private void dataGridViewUnitList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetUnitListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewUnitList.CurrentCell.ColumnIndex == dataGridViewUnitList.Columns["ColumnUnitListButtonEdit"].Index)
            {
                Entities.MstUnitEntity selectedUnit = new Entities.MstUnitEntity()
                {
                    Id = Convert.ToInt32(dataGridViewUnitList.Rows[e.RowIndex].Cells[2].Value),
                    Unit = dataGridViewUnitList.Rows[e.RowIndex].Cells[3].Value.ToString()
                };
                SysSystemTablesUnitDetailForm sysSystemTablesUnitDetailForm = new SysSystemTablesUnitDetailForm(this, selectedUnit);
                sysSystemTablesUnitDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewUnitList.CurrentCell.ColumnIndex == dataGridViewUnitList.Columns["ColumnUnitListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Unit?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstUnitController mstUnitController = new Controllers.MstUnitController();

                    String[] deleteUnit = mstUnitController.DeleteUnit(Convert.ToInt32(dataGridViewUnitList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteUnit[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = unitListPageNumber;

                        unitListPageNumber = 1;
                        UpdateUnitListDataSource();

                        if (unitListPageList != null)
                        {
                            if (unitListData.Count() % pageSize == 1)
                            {
                                unitListPageNumber = currentPageNumber - 1;
                            }
                            else if (unitListData.Count() < 1)
                            {
                                unitListPageNumber = 1;
                            }
                            else
                            {
                                unitListPageNumber = currentPageNumber;
                            }

                            unitListDataSource.DataSource = unitListPageList;
                        }
                    }
                    else
                    {
                        MessageBox.Show(deleteUnit[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetUnitListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonUnitListPageListFirst_Click(object sender, EventArgs e)
        {
            unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, 1, pageSize);
            unitListDataSource.DataSource = unitListPageList;

            buttonUnitListPageListFirst.Enabled = false;
            buttonUnitListPageListPrevious.Enabled = false;
            buttonUnitListPageListNext.Enabled = true;
            buttonUnitListPageListLast.Enabled = true;

            unitListPageNumber = 1;
            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
        }

        private void buttonUnitListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (unitListPageList.HasPreviousPage == true)
            {
                unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, --unitListPageNumber, pageSize);
                unitListDataSource.DataSource = unitListPageList;
            }

            buttonUnitListPageListNext.Enabled = true;
            buttonUnitListPageListLast.Enabled = true;

            if (unitListPageNumber == 1)
            {
                buttonUnitListPageListFirst.Enabled = false;
                buttonUnitListPageListPrevious.Enabled = false;
            }

            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
        }

        private void buttonUnitListPageListNext_Click(object sender, EventArgs e)
        {
            if (unitListPageList.HasNextPage == true)
            {
                unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, ++unitListPageNumber, pageSize);
                unitListDataSource.DataSource = unitListPageList;
            }

            buttonUnitListPageListFirst.Enabled = true;
            buttonUnitListPageListPrevious.Enabled = true;

            if (unitListPageNumber == unitListPageList.PageCount)
            {
                buttonUnitListPageListNext.Enabled = false;
                buttonUnitListPageListLast.Enabled = false;
            }

            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
        }

        private void buttonUnitListPageListLast_Click(object sender, EventArgs e)
        {
            unitListPageList = new PagedList<Entities.DgvSystemTablesUnitListEntity>(unitListData, unitListPageList.PageCount, pageSize);
            unitListDataSource.DataSource = unitListPageList;

            buttonUnitListPageListFirst.Enabled = true;
            buttonUnitListPageListPrevious.Enabled = true;
            buttonUnitListPageListNext.Enabled = false;
            buttonUnitListPageListLast.Enabled = false;

            unitListPageNumber = unitListPageList.PageCount;
            textBoxUnitListPageNumber.Text = unitListPageNumber + " / " + unitListPageList.PageCount;
        }

        // ======
        // Period
        // ======
        public void UpdatePeriodListDataSource()
        {
            SetPeriodListDataSourceAsync();
        }

        public async void SetPeriodListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesPeriodListEntity> getPeriodListData = await GetPeriodListDataTask();
            if (getPeriodListData.Any())
            {
                periodListData = getPeriodListData;
                periodListPageList = new PagedList<Entities.DgvSystemTablesPeriodListEntity>(periodListData, periodListPageNumber, pageSize);

                if (periodListPageList.PageCount == 1)
                {
                    buttonPeriodListPageListFirst.Enabled = false;
                    buttonPeriodListPageListPrevious.Enabled = false;
                    buttonPeriodListPageListNext.Enabled = false;
                    buttonPeriodListPageListLast.Enabled = false;
                }
                else if (periodListPageNumber == 1)
                {
                    buttonPeriodListPageListFirst.Enabled = false;
                    buttonPeriodListPageListPrevious.Enabled = false;
                    buttonPeriodListPageListNext.Enabled = true;
                    buttonPeriodListPageListLast.Enabled = true;
                }
                else if (periodListPageNumber == periodListPageList.PageCount)
                {
                    buttonPeriodListPageListFirst.Enabled = true;
                    buttonPeriodListPageListPrevious.Enabled = true;
                    buttonPeriodListPageListNext.Enabled = false;
                    buttonPeriodListPageListLast.Enabled = false;
                }
                else
                {
                    buttonPeriodListPageListFirst.Enabled = true;
                    buttonPeriodListPageListPrevious.Enabled = true;
                    buttonPeriodListPageListNext.Enabled = true;
                    buttonPeriodListPageListLast.Enabled = true;
                }

                textBoxPeriodListPageNumber.Text = periodListPageNumber + " / " + periodListPageList.PageCount;
                periodListDataSource.DataSource = periodListPageList;
            }
            else
            {
                buttonPeriodListPageListFirst.Enabled = false;
                buttonPeriodListPageListPrevious.Enabled = false;
                buttonPeriodListPageListNext.Enabled = false;
                buttonPeriodListPageListLast.Enabled = false;

                periodListPageNumber = 1;

                periodListData = new List<Entities.DgvSystemTablesPeriodListEntity>();
                periodListDataSource.Clear();
                textBoxPeriodListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesPeriodListEntity>> GetPeriodListDataTask()
        {
            String filter = textBoxPeriodListFilter.Text;
            Controllers.MstPeriodController mstPeriodController = new Controllers.MstPeriodController();

            List<Entities.MstPeriodEntity> listPeriod = mstPeriodController.ListPeriod(filter);
            if (listPeriod.Any())
            {
                var periods = from d in listPeriod
                              select new Entities.DgvSystemTablesPeriodListEntity
                              {
                                  ColumnPeriodListButtonEdit = "Edit",
                                  ColumnPeriodListButtonDelete = "Delete",
                                  ColumnPeriodListId = d.Id,
                                  ColumnPeriodListPeriod = d.Period
                              };

                return Task.FromResult(periods.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesPeriodListEntity>());
            }
        }

        public void CreatePeriodListDataGridView()
        {
            UpdatePeriodListDataSource();

            dataGridViewPeriodList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPeriodList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewPeriodList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPeriodList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPeriodList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewPeriodList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewPeriodList.DataSource = periodListDataSource;
        }

        private void textBoxPeriodListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdatePeriodListDataSource();
            }
        }

        private void dataGridViewPeriodList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetPeriodListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewPeriodList.CurrentCell.ColumnIndex == dataGridViewPeriodList.Columns["ColumnPeriodListButtonEdit"].Index)
            {
                Entities.MstPeriodEntity selectedPeriod = new Entities.MstPeriodEntity()
                {
                    Id = Convert.ToInt32(dataGridViewPeriodList.Rows[e.RowIndex].Cells[2].Value),
                    Period = dataGridViewPeriodList.Rows[e.RowIndex].Cells[3].Value.ToString()
                };
                SysSystemTablesPeriodDetailForm sysSystemTablesPeriodDetailForm = new SysSystemTablesPeriodDetailForm(this, selectedPeriod);
                sysSystemTablesPeriodDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewPeriodList.CurrentCell.ColumnIndex == dataGridViewPeriodList.Columns["ColumnPeriodListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Period?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstPeriodController mstPeriodController = new Controllers.MstPeriodController();

                    String[] deletePeriod = mstPeriodController.DeletePeriod(Convert.ToInt32(dataGridViewPeriodList.Rows[e.RowIndex].Cells[2].Value));
                    if (deletePeriod[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = periodListPageNumber;

                        periodListPageNumber = 1;
                        UpdatePeriodListDataSource();

                        if (periodListPageList != null)
                        {
                            if (periodListData.Count() % pageSize == 1)
                            {
                                periodListPageNumber = currentPageNumber - 1;
                            }
                            else if (periodListData.Count() < 1)
                            {
                                periodListPageNumber = 1;
                            }
                            else
                            {
                                periodListPageNumber = currentPageNumber;
                            }

                            periodListDataSource.DataSource = periodListPageList;
                        }
                    }
                    else
                    {
                        MessageBox.Show(deletePeriod[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetPeriodListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonPeriodListPageListFirst_Click(object sender, EventArgs e)
        {
            periodListPageList = new PagedList<Entities.DgvSystemTablesPeriodListEntity>(periodListData, 1, pageSize);
            periodListDataSource.DataSource = periodListPageList;

            buttonPeriodListPageListFirst.Enabled = false;
            buttonPeriodListPageListPrevious.Enabled = false;
            buttonPeriodListPageListNext.Enabled = true;
            buttonPeriodListPageListLast.Enabled = true;

            periodListPageNumber = 1;
            textBoxPeriodListPageNumber.Text = periodListPageNumber + " / " + periodListPageList.PageCount;
        }

        private void buttonPeriodListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (periodListPageList.HasPreviousPage == true)
            {
                periodListPageList = new PagedList<Entities.DgvSystemTablesPeriodListEntity>(periodListData, --periodListPageNumber, pageSize);
                periodListDataSource.DataSource = periodListPageList;
            }

            buttonPeriodListPageListNext.Enabled = true;
            buttonPeriodListPageListLast.Enabled = true;

            if (periodListPageNumber == 1)
            {
                buttonPeriodListPageListFirst.Enabled = false;
                buttonPeriodListPageListPrevious.Enabled = false;
            }

            textBoxPeriodListPageNumber.Text = periodListPageNumber + " / " + periodListPageList.PageCount;
        }

        private void buttonPeriodListPageListNext_Click(object sender, EventArgs e)
        {
            if (periodListPageList.HasNextPage == true)
            {
                periodListPageList = new PagedList<Entities.DgvSystemTablesPeriodListEntity>(periodListData, ++periodListPageNumber, pageSize);
                periodListDataSource.DataSource = periodListPageList;
            }

            buttonPeriodListPageListFirst.Enabled = true;
            buttonPeriodListPageListPrevious.Enabled = true;

            if (periodListPageNumber == periodListPageList.PageCount)
            {
                buttonPeriodListPageListNext.Enabled = false;
                buttonPeriodListPageListLast.Enabled = false;
            }

            textBoxPeriodListPageNumber.Text = periodListPageNumber + " / " + periodListPageList.PageCount;
        }

        private void buttonPeriodListPageListLast_Click(object sender, EventArgs e)
        {
            periodListPageList = new PagedList<Entities.DgvSystemTablesPeriodListEntity>(periodListData, periodListPageList.PageCount, pageSize);
            periodListDataSource.DataSource = periodListPageList;

            buttonPeriodListPageListFirst.Enabled = true;
            buttonPeriodListPageListPrevious.Enabled = true;
            buttonPeriodListPageListNext.Enabled = false;
            buttonPeriodListPageListLast.Enabled = false;

            periodListPageNumber = periodListPageList.PageCount;
            textBoxPeriodListPageNumber.Text = periodListPageNumber + " / " + periodListPageList.PageCount;
        }

        // ========
        // Terminal
        // ========
        public void UpdateTerminalListDataSource()
        {
            SetTerminalListDataSourceAsync();
        }

        public async void SetTerminalListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesTerminalListEntity> getTerminalListData = await GetTerminalListDataTask();
            if (getTerminalListData.Any())
            {
                terminalListData = getTerminalListData;
                terminalListPageList = new PagedList<Entities.DgvSystemTablesTerminalListEntity>(terminalListData, terminalListPageNumber, pageSize);

                if (terminalListPageList.PageCount == 1)
                {
                    buttonTerminalListPageListFirst.Enabled = false;
                    buttonTerminalListPageListPrevious.Enabled = false;
                    buttonTerminalListPageListNext.Enabled = false;
                    buttonTerminalListPageListLast.Enabled = false;
                }
                else if (terminalListPageNumber == 1)
                {
                    buttonTerminalListPageListFirst.Enabled = false;
                    buttonTerminalListPageListPrevious.Enabled = false;
                    buttonTerminalListPageListNext.Enabled = true;
                    buttonTerminalListPageListLast.Enabled = true;
                }
                else if (terminalListPageNumber == terminalListPageList.PageCount)
                {
                    buttonTerminalListPageListFirst.Enabled = true;
                    buttonTerminalListPageListPrevious.Enabled = true;
                    buttonTerminalListPageListNext.Enabled = false;
                    buttonTerminalListPageListLast.Enabled = false;
                }
                else
                {
                    buttonTerminalListPageListFirst.Enabled = true;
                    buttonTerminalListPageListPrevious.Enabled = true;
                    buttonTerminalListPageListNext.Enabled = true;
                    buttonTerminalListPageListLast.Enabled = true;
                }

                textBoxTerminalListPageNumber.Text = terminalListPageNumber + " / " + terminalListPageList.PageCount;
                terminalListDataSource.DataSource = terminalListPageList;
            }
            else
            {
                buttonTerminalListPageListFirst.Enabled = false;
                buttonTerminalListPageListPrevious.Enabled = false;
                buttonTerminalListPageListNext.Enabled = false;
                buttonTerminalListPageListLast.Enabled = false;

                terminalListPageNumber = 1;

                terminalListData = new List<Entities.DgvSystemTablesTerminalListEntity>();
                terminalListDataSource.Clear();
                textBoxTerminalListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesTerminalListEntity>> GetTerminalListDataTask()
        {
            String filter = textBoxTerminalListFilter.Text;
            Controllers.MstTerminalController mstTerminalController = new Controllers.MstTerminalController();

            List<Entities.MstTerminalEntity> listTerminal = mstTerminalController.ListTerminal(filter);
            if (listTerminal.Any())
            {
                var terminals = from d in listTerminal
                                select new Entities.DgvSystemTablesTerminalListEntity
                                {
                                    ColumnTerminalListButtonEdit = "Edit",
                                    ColumnTerminalListButtonDelete = "Delete",
                                    ColumnTerminalListId = d.Id,
                                    ColumnTerminalListTerminal = d.Terminal
                                };

                return Task.FromResult(terminals.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesTerminalListEntity>());
            }
        }

        public void CreateTerminalListDataGridView()
        {
            UpdateTerminalListDataSource();

            dataGridViewTerminalList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewTerminalList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewTerminalList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewTerminalList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewTerminalList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewTerminalList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewTerminalList.DataSource = terminalListDataSource;
        }

        private void textBoxTerminalListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTerminalListDataSource();
            }
        }

        private void dataGridViewTerminalList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetTerminalListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewTerminalList.CurrentCell.ColumnIndex == dataGridViewTerminalList.Columns["ColumnTerminalListButtonEdit"].Index)
            {
                Entities.MstTerminalEntity selectedTerminal = new Entities.MstTerminalEntity()
                {
                    Id = Convert.ToInt32(dataGridViewTerminalList.Rows[e.RowIndex].Cells[2].Value),
                    Terminal = dataGridViewTerminalList.Rows[e.RowIndex].Cells[3].Value.ToString()
                };
                SysSystemTablesTerminalDetailForm sysSystemTablesTerminalDetailForm = new SysSystemTablesTerminalDetailForm(this, selectedTerminal);
                sysSystemTablesTerminalDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewTerminalList.CurrentCell.ColumnIndex == dataGridViewTerminalList.Columns["ColumnTerminalListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Terminal?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    Controllers.MstTerminalController mstTerminalController = new Controllers.MstTerminalController();

                    String[] deleteTerminal = mstTerminalController.DeleteTerminal(Convert.ToInt32(dataGridViewTerminalList.Rows[e.RowIndex].Cells[2].Value));
                    if (deleteTerminal[1].Equals("0") == false)
                    {
                        Int32 currentPageNumber = terminalListPageNumber;

                        terminalListPageNumber = 1;
                        UpdateTerminalListDataSource();

                        if (terminalListPageList != null)
                        {
                            if (terminalListData.Count() % pageSize == 1)
                            {
                                terminalListPageNumber = currentPageNumber - 1;
                            }
                            else if (terminalListData.Count() < 1)
                            {
                                terminalListPageNumber = 1;
                            }
                            else
                            {
                                terminalListPageNumber = currentPageNumber;
                            }

                            terminalListDataSource.DataSource = terminalListPageList;
                        }
                    }
                    else
                    {
                        MessageBox.Show(deleteTerminal[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void GetTerminalListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonTerminalListPageListFirst_Click(object sender, EventArgs e)
        {
            terminalListPageList = new PagedList<Entities.DgvSystemTablesTerminalListEntity>(terminalListData, 1, pageSize);
            terminalListDataSource.DataSource = terminalListPageList;

            buttonTerminalListPageListFirst.Enabled = false;
            buttonTerminalListPageListPrevious.Enabled = false;
            buttonTerminalListPageListNext.Enabled = true;
            buttonTerminalListPageListLast.Enabled = true;

            terminalListPageNumber = 1;
            textBoxTerminalListPageNumber.Text = terminalListPageNumber + " / " + terminalListPageList.PageCount;
        }

        private void buttonTerminalListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (terminalListPageList.HasPreviousPage == true)
            {
                terminalListPageList = new PagedList<Entities.DgvSystemTablesTerminalListEntity>(terminalListData, --terminalListPageNumber, pageSize);
                terminalListDataSource.DataSource = terminalListPageList;
            }

            buttonTerminalListPageListNext.Enabled = true;
            buttonTerminalListPageListLast.Enabled = true;

            if (terminalListPageNumber == 1)
            {
                buttonTerminalListPageListFirst.Enabled = false;
                buttonTerminalListPageListPrevious.Enabled = false;
            }

            textBoxTerminalListPageNumber.Text = terminalListPageNumber + " / " + terminalListPageList.PageCount;
        }

        private void buttonTerminalListPageListNext_Click(object sender, EventArgs e)
        {
            if (terminalListPageList.HasNextPage == true)
            {
                terminalListPageList = new PagedList<Entities.DgvSystemTablesTerminalListEntity>(terminalListData, ++terminalListPageNumber, pageSize);
                terminalListDataSource.DataSource = terminalListPageList;
            }

            buttonTerminalListPageListFirst.Enabled = true;
            buttonTerminalListPageListPrevious.Enabled = true;

            if (terminalListPageNumber == terminalListPageList.PageCount)
            {
                buttonTerminalListPageListNext.Enabled = false;
                buttonTerminalListPageListLast.Enabled = false;
            }

            textBoxTerminalListPageNumber.Text = terminalListPageNumber + " / " + terminalListPageList.PageCount;
        }

        private void buttonTerminalListPageListLast_Click(object sender, EventArgs e)
        {
            terminalListPageList = new PagedList<Entities.DgvSystemTablesTerminalListEntity>(terminalListData, terminalListPageList.PageCount, pageSize);
            terminalListDataSource.DataSource = terminalListPageList;

            buttonTerminalListPageListFirst.Enabled = true;
            buttonTerminalListPageListPrevious.Enabled = true;
            buttonTerminalListPageListNext.Enabled = false;
            buttonTerminalListPageListLast.Enabled = false;

            terminalListPageNumber = terminalListPageList.PageCount;
            textBoxTerminalListPageNumber.Text = terminalListPageNumber + " / " + terminalListPageList.PageCount;
        }

        // ========
        // Supplier
        // ========
        public void UpdateSupplierListDataSource()
        {
            SetSupplierListDataSourceAsync();
        }

        public async void SetSupplierListDataSourceAsync()
        {
            List<Entities.DgvSystemTablesSupplierListEntity> getSupplierListData = await GetSupplierListDataTask();
            if (getSupplierListData.Any())
            {
                supplierListData = getSupplierListData;
                supplierListPageList = new PagedList<Entities.DgvSystemTablesSupplierListEntity>(supplierListData, supplierListPageNumber, pageSize);

                if (supplierListPageList.PageCount == 1)
                {
                    buttonSupplierListPageListFirst.Enabled = false;
                    buttonSupplierListPageListPrevious.Enabled = false;
                    buttonSupplierListPageListNext.Enabled = false;
                    buttonSupplierListPageListLast.Enabled = false;
                }
                else if (supplierListPageNumber == 1)
                {
                    buttonSupplierListPageListFirst.Enabled = false;
                    buttonSupplierListPageListPrevious.Enabled = false;
                    buttonSupplierListPageListNext.Enabled = true;
                    buttonSupplierListPageListLast.Enabled = true;
                }
                else if (supplierListPageNumber == supplierListPageList.PageCount)
                {
                    buttonSupplierListPageListFirst.Enabled = true;
                    buttonSupplierListPageListPrevious.Enabled = true;
                    buttonSupplierListPageListNext.Enabled = false;
                    buttonSupplierListPageListLast.Enabled = false;
                }
                else
                {
                    buttonSupplierListPageListFirst.Enabled = true;
                    buttonSupplierListPageListPrevious.Enabled = true;
                    buttonSupplierListPageListNext.Enabled = true;
                    buttonSupplierListPageListLast.Enabled = true;
                }

                textBoxSupplierListPageNumber.Text = supplierListPageNumber + " / " + supplierListPageList.PageCount;
                supplierListDataSource.DataSource = supplierListPageList;
            }
            else
            {
                buttonSupplierListPageListFirst.Enabled = false;
                buttonSupplierListPageListPrevious.Enabled = false;
                buttonSupplierListPageListNext.Enabled = false;
                buttonSupplierListPageListLast.Enabled = false;

                supplierListPageNumber = 1;

                supplierListData = new List<Entities.DgvSystemTablesSupplierListEntity>();
                supplierListDataSource.Clear();
                textBoxSupplierListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSystemTablesSupplierListEntity>> GetSupplierListDataTask()
        {
            String filter = textBoxSupplierListFilter.Text;
            Controllers.MstSupplierController mstSupplierController = new Controllers.MstSupplierController();

            List<Entities.MstSupplierEntity> listSupplier = mstSupplierController.ListSupplier(filter);
            if (listSupplier.Any())
            {
                var suppliers = from d in listSupplier
                                select new Entities.DgvSystemTablesSupplierListEntity
                                {
                                    ColumnSupplierListButtonEdit = "Edit",
                                    ColumnSupplierListButtonDelete = "Delete",
                                    ColumnSupplierListId = d.Id,
                                    ColumnSupplierListSupplier = d.Supplier,
                                    ColumnSupplierListAddress = d.Address,
                                    ColumnSupplierListTelephoneNumber = d.TelephoneNumber,
                                    ColumnSupplierListCellphoneNumber = d.CellphoneNumber,
                                    ColumnSupplierListTIN = d.TIN
                                };

                return Task.FromResult(suppliers.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSystemTablesSupplierListEntity>());
            }
        }

        public void CreateSupplierListDataGridView()
        {
            UpdateSupplierListDataSource();

            dataGridViewSupplierList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSupplierList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSupplierList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSupplierList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSupplierList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewSupplierList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSupplierList.DataSource = supplierListDataSource;
        }

        private void textBoxSupplierListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSupplierListDataSource();
            }
        }

        private void dataGridViewSupplierList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetSupplierListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewSupplierList.CurrentCell.ColumnIndex == dataGridViewSupplierList.Columns["ColumnSupplierListButtonEdit"].Index)
            {
                //Controllers.MstSupplierController mstSupplierController = new Controllers.MstSupplierController();
                //sysSoftwareForm.AddTabPageSupplierDetail(this, mstSupplierController.DetailSupplier(Convert.ToInt32(dataGridViewSupplierList.Rows[e.RowIndex].Cells[2].Value)));
            }

            if (e.RowIndex > -1 && dataGridViewSupplierList.CurrentCell.ColumnIndex == dataGridViewSupplierList.Columns["ColumnSupplierListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Supplier?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    //Controllers.MstSupplierController mstSupplierController = new Controllers.MstSupplierController();

                    //String[] deleteSupplier = mstSupplierController.DeleteSupplier(Convert.ToInt32(dataGridViewSupplierList.Rows[e.RowIndex].Cells[2].Value));
                    //if (deleteSupplier[1].Equals("0") == false)
                    //{
                    //    Int32 currentPageNumber = supplierListPageNumber;

                    //    supplierListPageNumber = 1;
                    //    UpdateSupplierListDataSource();

                    //    if (supplierListPageList != null)
                    //    {
                    //        if (supplierListData.Count() % pageSize == 1)
                    //        {
                    //            supplierListPageNumber = currentPageNumber - 1;
                    //        }
                    //        else if (supplierListData.Count() < 1)
                    //        {
                    //            supplierListPageNumber = 1;
                    //        }
                    //        else
                    //        {
                    //            supplierListPageNumber = currentPageNumber;
                    //        }

                    //        supplierListDataSource.DataSource = supplierListPageList;
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show(deleteSupplier[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }
        }

        public void GetSupplierListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonSupplierListPageListFirst_Click(object sender, EventArgs e)
        {
            supplierListPageList = new PagedList<Entities.DgvSystemTablesSupplierListEntity>(supplierListData, 1, pageSize);
            supplierListDataSource.DataSource = supplierListPageList;

            buttonSupplierListPageListFirst.Enabled = false;
            buttonSupplierListPageListPrevious.Enabled = false;
            buttonSupplierListPageListNext.Enabled = true;
            buttonSupplierListPageListLast.Enabled = true;

            supplierListPageNumber = 1;
            textBoxSupplierListPageNumber.Text = supplierListPageNumber + " / " + supplierListPageList.PageCount;
        }

        private void buttonSupplierListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (supplierListPageList.HasPreviousPage == true)
            {
                supplierListPageList = new PagedList<Entities.DgvSystemTablesSupplierListEntity>(supplierListData, --supplierListPageNumber, pageSize);
                supplierListDataSource.DataSource = supplierListPageList;
            }

            buttonSupplierListPageListNext.Enabled = true;
            buttonSupplierListPageListLast.Enabled = true;

            if (supplierListPageNumber == 1)
            {
                buttonSupplierListPageListFirst.Enabled = false;
                buttonSupplierListPageListPrevious.Enabled = false;
            }

            textBoxSupplierListPageNumber.Text = supplierListPageNumber + " / " + supplierListPageList.PageCount;
        }

        private void buttonSupplierListPageListNext_Click(object sender, EventArgs e)
        {
            if (supplierListPageList.HasNextPage == true)
            {
                supplierListPageList = new PagedList<Entities.DgvSystemTablesSupplierListEntity>(supplierListData, ++supplierListPageNumber, pageSize);
                supplierListDataSource.DataSource = supplierListPageList;
            }

            buttonSupplierListPageListFirst.Enabled = true;
            buttonSupplierListPageListPrevious.Enabled = true;

            if (supplierListPageNumber == supplierListPageList.PageCount)
            {
                buttonSupplierListPageListNext.Enabled = false;
                buttonSupplierListPageListLast.Enabled = false;
            }

            textBoxSupplierListPageNumber.Text = supplierListPageNumber + " / " + supplierListPageList.PageCount;
        }

        private void buttonSupplierListPageListLast_Click(object sender, EventArgs e)
        {
            supplierListPageList = new PagedList<Entities.DgvSystemTablesSupplierListEntity>(supplierListData, supplierListPageList.PageCount, pageSize);
            supplierListDataSource.DataSource = supplierListPageList;

            buttonSupplierListPageListFirst.Enabled = true;
            buttonSupplierListPageListPrevious.Enabled = true;
            buttonSupplierListPageListNext.Enabled = false;
            buttonSupplierListPageListLast.Enabled = false;

            supplierListPageNumber = supplierListPageList.PageCount;
            textBoxSupplierListPageNumber.Text = supplierListPageNumber + " / " + supplierListPageList.PageCount;
        }


        // ===========
        // Add / Close
        // ===========
        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            String selectedTab = tabControlSystemTable.SelectedTab.Text.ToString();
            switch (selectedTab)
            {
                case "Account":
                    SysSystemTablesAccountDetailForm sysSystemTablesAccountDetailForm = new SysSystemTablesAccountDetailForm(this, null);
                    sysSystemTablesAccountDetailForm.ShowDialog();
                    break;
                case "Pay Type":
                    SysSystemTablesPayTypeDetailForm sysSystemTablesPayTypeDetailForm = new SysSystemTablesPayTypeDetailForm(this, null);
                    sysSystemTablesPayTypeDetailForm.ShowDialog();
                    break;
                case "Tax":
                    SysSystemTablesTaxDetailForm sysSystemTablesTaxDetailForm = new SysSystemTablesTaxDetailForm(this, null);
                    sysSystemTablesTaxDetailForm.ShowDialog();
                    break;
                case "Unit":
                    SysSystemTablesUnitDetailForm sysSystemTablesUnitDetailForm = new SysSystemTablesUnitDetailForm(this, null);
                    sysSystemTablesUnitDetailForm.ShowDialog();
                    break;
                case "Period":
                    SysSystemTablesPeriodDetailForm sysSystemTablesPeriodDetailForm = new SysSystemTablesPeriodDetailForm(this, null);
                    sysSystemTablesPeriodDetailForm.ShowDialog();
                    break;
                case "Terminal":
                    SysSystemTablesTerminalDetailForm sysSystemTablesTerminalDetailForm = new SysSystemTablesTerminalDetailForm(this, null);
                    sysSystemTablesTerminalDetailForm.ShowDialog();
                    break;

            }
        }
    }
}
