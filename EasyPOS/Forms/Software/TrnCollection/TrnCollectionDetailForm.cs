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

namespace EasyPOS.Forms.Software.TrnCollection
{
    public partial class TrnCollectionDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;
        public TrnCollectionListForm trnCollectionListForm;
        public Entities.TrnCollectionEntity trnCollectionEntity;

        public static List<Entities.DgvTrnCollectionLineListEntity> collectionLineData = new List<Entities.DgvTrnCollectionLineListEntity>();
        public static Int32 CollectionLinePageNumber = 1;
        public static Int32 CollectionLinePageSize = 50;
        public PagedList<Entities.DgvTrnCollectionLineListEntity> collectionLinePageList = new PagedList<Entities.DgvTrnCollectionLineListEntity>(collectionLineData, CollectionLinePageNumber, CollectionLinePageSize);
        public BindingSource collectionLineDataSource = new BindingSource();
        public TrnCollectionDetailForm(SysSoftwareForm softwareForm, TrnCollectionListForm CollectionListForm, Entities.TrnCollectionEntity CollectionEntity)
        {
            InitializeComponent();
            sysUserRights = new Modules.SysUserRightsModule("TrnCollectionDetail");
            if (sysUserRights.GetUserRights() == null)
            {
                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                trnCollectionListForm = CollectionListForm;
                trnCollectionEntity = CollectionEntity;

                GetCollectionNumber();
            }
        }
        public void GetCollectionNumber()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionNumber().Any())
            {
                comboBoxCollectionNumber.DataSource = trnCollectionController.DropdownListCollectionNumber();
                comboBoxCollectionNumber.DisplayMember = "CollectionNumber";

                GetPeriodId();
            }
        }
        public void GetPeriodId()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionPeriodId().Any())
            {
                comboBoxPeriodId.DataSource = trnCollectionController.DropdownListCollectionPeriodId();
                comboBoxPeriodId.ValueMember = "Id";
                comboBoxPeriodId.DisplayMember = "Period";

                GetManualORNumber();
            }
        }
        public void GetManualORNumber()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionManualORNumber().Any())
            {
                comboBoxManualORNumber.DataSource = trnCollectionController.DropdownListCollectionManualORNumber();
                comboBoxManualORNumber.DisplayMember = "ManualORNumber";

                GetTerminalId();
            }
        }
        public void GetTerminalId()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionTerminalId().Any())
            {
                comboBoxTerminal.DataSource = trnCollectionController.DropdownListCollectionTerminalId();
                comboBoxTerminal.ValueMember = "Id";
                comboBoxTerminal.DisplayMember = "Terminal";

                GetCustomer();
            }
        }
        public void GetCustomer()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionCustomer().Any())
            {
                comboBoxCustomer.DataSource = trnCollectionController.DropdownListCollectionCustomer();
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DisplayMember = "Customer";

                GetSalesNumber();
            }
        }
        public void GetSalesNumber()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionSalesNumber().Any())
            {
                comboBoxSalesNumber.DataSource = trnCollectionController.DropdownListCollectionSalesNumber();
                comboBoxSalesNumber.DisplayMember = "SalesNumber";
                
                GetSalesBalanceAmount();
            }
        }
        public void GetSalesBalanceAmount()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionSalesBalanceAmount().Any())
            {
                comboBoxSalesBalance.DataSource = trnCollectionController.DropdownListCollectionSalesBalanceAmount();
                comboBoxSalesBalance.DisplayMember = "BalanceAmount";

                GetSalesAmount();
            }
        }
        public void GetSalesAmount()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionSalesAmount().Any())
            {
                comboBoxAmount.DataSource = trnCollectionController.DropdownListCollectionSalesAmount();
                comboBoxAmount.DisplayMember = "Amount";

                GetUserList();
            }
        }
        public void GetUserList()
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();
            if (trnCollectionController.DropdownListCollectionUser().Any())
            {
                comboBoxPreparedBy.DataSource = trnCollectionController.DropdownListCollectionUser();
                comboBoxPreparedBy.ValueMember = "Id";
                comboBoxPreparedBy.DisplayMember = "FullName";

                comboBoxCheckedBy.DataSource = trnCollectionController.DropdownListCollectionUser();
                comboBoxCheckedBy.ValueMember = "Id";
                comboBoxCheckedBy.DisplayMember = "FullName";

                comboBoxApprovedBy.DataSource = trnCollectionController.DropdownListCollectionUser();
                comboBoxApprovedBy.ValueMember = "Id";
                comboBoxApprovedBy.DisplayMember = "FullName";

                GetCollectionDetail();
            }
        }
        public void GetCollectionDetail()
        {
            UpdateComponents(trnCollectionEntity.IsLocked);

            comboBoxCollectionNumber.SelectedText = trnCollectionEntity.CollectionNumber;
            comboBoxPeriodId.SelectedValue = trnCollectionEntity.PeriodId;
            dateTimePickerCollectionDate.Value = Convert.ToDateTime(trnCollectionEntity.CollectionDate);
            comboBoxManualORNumber.SelectedText = trnCollectionEntity.ManualORNumber;
            comboBoxTerminal.SelectedValue = trnCollectionEntity.TerminalId;
            comboBoxCustomer.SelectedValue = trnCollectionEntity.CustomerId;
            comboBoxSalesNumber.SelectedText = trnCollectionEntity.SalesNumber;
            comboBoxSalesBalance.SelectedText = trnCollectionEntity.SalesBalanceAmount.ToString();
            comboBoxAmount.SelectedText = trnCollectionEntity.Amount.ToString();
            textBoxRemarks.Text = trnCollectionEntity.Remarks;
            comboBoxPreparedBy.SelectedValue = trnCollectionEntity.PreparedBy;
            comboBoxCheckedBy.SelectedValue = trnCollectionEntity.CheckedBy;
            comboBoxApprovedBy.SelectedValue = trnCollectionEntity.ApprovedBy;

            CreateCollectionLineListDataGridView();
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

            if (sysUserRights.GetUserRights().CanPrint == false)
            {
                buttonPrint.Enabled = false;
            }
            else
            {
                buttonPrint.Enabled = isLocked;
            }

            dateTimePickerCollectionDate.Enabled = !isLocked;
            comboBoxPeriodId.Enabled = !isLocked;
            comboBoxManualORNumber.Enabled = !isLocked;
            comboBoxTerminal.Enabled = !isLocked;
            comboBoxCustomer.Enabled = !isLocked;
            comboBoxSalesNumber.Enabled = !isLocked;
            comboBoxSalesBalance.Enabled = !isLocked;
            comboBoxAmount.Enabled = !isLocked;
            textBoxRemarks.Enabled = !isLocked;
            comboBoxPreparedBy.Enabled = !isLocked;
            comboBoxCheckedBy.Enabled = !isLocked;
            comboBoxApprovedBy.Enabled = !isLocked;

            dataGridViewCollectionLineList.Columns[0].Visible = !isLocked;
            dataGridViewCollectionLineList.Columns[1].Visible = !isLocked;
            dateTimePickerCollectionDate.Focus();
        }

        private void buttonLock_Click(object sender, EventArgs e)
        {
            try
            {
                Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();

                Entities.TrnCollectionEntity newCollectionEntity = new Entities.TrnCollectionEntity()
                {

                    PeriodId = Convert.ToInt32(comboBoxPeriodId.SelectedValue),
                    CollectionDate = dateTimePickerCollectionDate.Value.Date.ToShortDateString(),
                    ManualORNumber = comboBoxManualORNumber.Text,
                    TerminalId = Convert.ToInt32(comboBoxTerminal.SelectedValue),
                    CustomerId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    SalesNumber = comboBoxSalesNumber.Text,
                    SalesBalanceAmount = Convert.ToDecimal(comboBoxSalesBalance.Text),
                    Amount = Convert.ToDecimal(comboBoxAmount.Text),
                    Remarks = textBoxRemarks.Text,
                    PreparedBy = Convert.ToInt32(comboBoxPreparedBy.SelectedValue),
                    CheckedBy = Convert.ToInt32(comboBoxCheckedBy.SelectedValue),
                    ApprovedBy = Convert.ToInt32(comboBoxApprovedBy.SelectedValue),
                };

                String[] lockCollection = trnCollectionController.LockCollection(trnCollectionEntity.Id, newCollectionEntity);
                if (lockCollection[1].Equals("0") == false)
                {
                    UpdateComponents(true);
                    trnCollectionListForm.UpdateCollectionListDataSource();
                }
                else
                {
                    MessageBox.Show(lockCollection[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {
            Controllers.TrnCollectionController trnCollectionController = new Controllers.TrnCollectionController();

            String[] unlockCollection = trnCollectionController.UnlockCollection(trnCollectionEntity.Id);
            if (unlockCollection[1].Equals("0") == false)
            {
                UpdateComponents(false);
                trnCollectionListForm.UpdateCollectionListDataSource();
            }
            else
            {
                MessageBox.Show(unlockCollection[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateCollectionListDataSource()
        {
            SetCollectionLineListDataSourceAsync();
        }
        public async void SetCollectionLineListDataSourceAsync()
        {
            List<Entities.DgvTrnCollectionLineListEntity> getCollectionLineListData = await GetCollectionLineListDataTask();
            if (getCollectionLineListData.Any())
            {
                collectionLineData = getCollectionLineListData;
                collectionLinePageList = new PagedList<Entities.DgvTrnCollectionLineListEntity>(collectionLineData, CollectionLinePageNumber, CollectionLinePageSize);

                if (collectionLinePageList.PageCount == 1)
                {
                    buttonCollectionLineListPageListFirst.Enabled = false;
                    buttonCollectionLineListPageListPrevious.Enabled = false;
                    buttonCollectionLineListPageListNext.Enabled = false;
                    buttonCollectionLineListPageListLast.Enabled = false;
                }
                else if (CollectionLinePageNumber == 1)
                {
                    buttonCollectionLineListPageListFirst.Enabled = false;
                    buttonCollectionLineListPageListPrevious.Enabled = false;
                    buttonCollectionLineListPageListNext.Enabled = true;
                    buttonCollectionLineListPageListLast.Enabled = true;
                }
                else if (CollectionLinePageNumber == collectionLinePageList.PageCount)
                {
                    buttonCollectionLineListPageListFirst.Enabled = true;
                    buttonCollectionLineListPageListPrevious.Enabled = true;
                    buttonCollectionLineListPageListNext.Enabled = false;
                    buttonCollectionLineListPageListLast.Enabled = false;
                }
                else
                {
                    buttonCollectionLineListPageListFirst.Enabled = true;
                    buttonCollectionLineListPageListPrevious.Enabled = true;
                    buttonCollectionLineListPageListNext.Enabled = true;
                    buttonCollectionLineListPageListLast.Enabled = true;
                }

                textBoxCollectionLineListPageNumber.Text = CollectionLinePageNumber + " / " + collectionLinePageList.PageCount;
                collectionLineDataSource.DataSource = collectionLinePageList;
            }
            else
            {
                buttonCollectionLineListPageListFirst.Enabled = false;
                buttonCollectionLineListPageListPrevious.Enabled = false;
                buttonCollectionLineListPageListNext.Enabled = false;
                buttonCollectionLineListPageListLast.Enabled = false;

                CollectionLinePageNumber = 1;

                collectionLineData = new List<Entities.DgvTrnCollectionLineListEntity>();
                collectionLineDataSource.Clear();
                textBoxCollectionLineListPageNumber.Text = "1 / 1";
            }
        }
        public Task<List<Entities.DgvTrnCollectionLineListEntity>> GetCollectionLineListDataTask()
        {
            Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();

            List<Entities.TrnCollectionLineEntity> listCollectionLine = trnCollectionLineController.ListCollectionLine(trnCollectionEntity.Id);
            if (listCollectionLine.Any())
            {
                var items = from d in listCollectionLine
                            select new Entities.DgvTrnCollectionLineListEntity
                            {
                                ColumnCollectionLineListButtonEdit = "Edit",
                                ColumnCollectionLineListButtonDelete = "Delete",
                                ColumnCollectionLineListId = d.Id,
                                ColumnCollectionLineListCollectionId = d.CollectionId,
                                ColumnCollectionLineListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnCollectionLineListPayType = d.PayType,
                                ColumnCollectionLineListCheckNumber = d.CheckNumber,
                                ColumnCollectionLineListCheckDate = d.CheckDate,
                                ColumnCollectionLineListCheckBank = d.CheckBank,
                                ColumnCollectionLineListCreditCardVerificationCode = d.CreditCardVerificationCode,
                                ColumnCollectionLineListCreditCardNumber = d.CreditCardNumber,
                                ColumnCollectionLineListCreditCardType = d.CreditCardType,
                                ColumnCollectionLineListCreditCardBank = d.CreditCardBank,
                                ColumnCollectionLineListGiftCertificateNumber = d.GiftCertificateNumber,
                                ColumnCollectionLineListOtherInformation = d.OtherInformation,
                                ColumnCollectionLineListSalesReturnSalesId = d.SalesReturnSalesId.ToString(),
                                ColumnCollectionLineListStockInId = d.StockInId.ToString(),
                                ColumnCollectionLineListAccountId = d.AccountId.ToString(),
                                ColumnCollectionLineListCreditCardReferenceNumber = d.CreditCardReferenceNumber,
                                ColumnCollectionLineListCreditCardHolderName = d.CreditCardHolderName,
                                ColumnCollectionLineListCreditCardExpiry = d.CreditCardExpiry,

                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnCollectionLineListEntity>());
            }
        }
        public void CreateCollectionLineListDataGridView()
        {
            UpdateCollectionListDataSource();

            dataGridViewCollectionLineList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCollectionLineList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewCollectionLineList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCollectionLineList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCollectionLineList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewCollectionLineList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewCollectionLineList.DataSource = collectionLineDataSource;
        }
        public void GetCollectionLineListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewCollectionLineList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetCollectionLineListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewCollectionLineList.CurrentCell.ColumnIndex == dataGridViewCollectionLineList.Columns["ColumnCollectionLineListButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListId"].Index].Value);
                var collectionId = Convert.ToInt32(dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCollectionId"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListAmount"].Index].Value);
                var paytype = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListPayType"].Index].Value.ToString();
                var checkNumber = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCheckNumber"].Index].Value.ToString();
                var checkDate = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCheckDate"].Index].Value.ToString();
                var checkBank = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCheckBank"].Index].Value.ToString();
                var verificationCode = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCreditCardVerificationCode"].Index].Value.ToString();
                var creditCardNumber = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCreditCardNumber"].Index].Value.ToString();
                var creditCardType = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCreditCardType"].Index].Value.ToString();
                var creditCardBank = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListCreditCardBank"].Index].Value.ToString();
                var giftCertificateNumber = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListGiftCertificateNumber"].Index].Value.ToString();
                var otherInformation = dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListOtherInformation"].Index].Value.ToString();
                var stockInId = Convert.ToInt32(dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListStockInId"].Index].Value);
                var accountId = Convert.ToInt32(dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListAccountId"].Index].Value);
                Entities.TrnCollectionLineEntity trnCollectionLineEntity = new Entities.TrnCollectionLineEntity()
                {
                    Id = id,
                    CollectionId = collectionId,
                    Amount = amount,
                    PayType = paytype,
                    CheckNumber = checkNumber,
                    CheckDate = checkDate,
                    CheckBank = checkBank,
                    CreditCardVerificationCode = verificationCode,
                    CreditCardNumber = creditCardNumber,
                    CreditCardType = creditCardType,
                    CreditCardBank = creditCardBank,
                    GiftCertificateNumber = giftCertificateNumber,
                    OtherInformation = otherInformation,
                    StockInId = stockInId,
                    AccountId = accountId
                };

                //TrnCollectionLineDetailForm trnPurchaseOrderDetailPurchaseOrderLineItemDetailForm = new TrnCollectionLineDetailForm(this, trnCollectionLineEntity);
                //trnPurchaseOrderDetailPurchaseOrderLineItemDetailForm.ShowDialog();
            }
            if (e.RowIndex > -1 && dataGridViewCollectionLineList.CurrentCell.ColumnIndex == dataGridViewCollectionLineList.Columns["ColumnCollectionLineListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Collection?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewCollectionLineList.Rows[e.RowIndex].Cells[dataGridViewCollectionLineList.Columns["ColumnCollectionLineListId"].Index].Value);

                    Controllers.TrnCollectionLineController trnCollectionLineController = new Controllers.TrnCollectionLineController();
                    String[] deleteCollectionLine = trnCollectionLineController.DeleteCollectionLine(id);
                    if (deleteCollectionLine[1].Equals("0") == false)
                    {
                        CollectionLinePageNumber = 1;
                        UpdateCollectionListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteCollectionLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonCollectionLineListPageListFirst_Click(object sender, EventArgs e)
        {
            collectionLinePageList = new PagedList<Entities.DgvTrnCollectionLineListEntity>(collectionLineData, 1, CollectionLinePageSize);
            collectionLineDataSource.DataSource = collectionLinePageList;

            buttonCollectionLineListPageListFirst.Enabled = false;
            buttonCollectionLineListPageListPrevious.Enabled = false;
            buttonCollectionLineListPageListNext.Enabled = true;
            buttonCollectionLineListPageListLast.Enabled = true;

            CollectionLinePageNumber = 1;
            textBoxCollectionLineListPageNumber.Text = CollectionLinePageNumber + " / " + collectionLinePageList.PageCount;
        }

        private void buttonCollectionLineListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (collectionLinePageList.HasPreviousPage == true)
            {
                collectionLinePageList = new PagedList<Entities.DgvTrnCollectionLineListEntity>(collectionLineData, --CollectionLinePageNumber, CollectionLinePageSize);
                collectionLineDataSource.DataSource = collectionLinePageList;
            }

            buttonCollectionLineListPageListNext.Enabled = true;
            buttonCollectionLineListPageListLast.Enabled = true;

            if (CollectionLinePageNumber == 1)
            {
                buttonCollectionLineListPageListFirst.Enabled = false;
                buttonCollectionLineListPageListPrevious.Enabled = false;
            }

            textBoxCollectionLineListPageNumber.Text = CollectionLinePageNumber + " / " + collectionLinePageList.PageCount;
        }

        private void buttonCollectionLineListPageListNext_Click(object sender, EventArgs e)
        {
            if (collectionLinePageList.HasNextPage == true)
            {
                collectionLinePageList = new PagedList<Entities.DgvTrnCollectionLineListEntity>(collectionLineData, CollectionLinePageNumber, CollectionLinePageSize);
                collectionLineDataSource.DataSource = collectionLinePageList;
            }

            buttonCollectionLineListPageListFirst.Enabled = true;
            buttonCollectionLineListPageListPrevious.Enabled = true;

            if (CollectionLinePageNumber == collectionLinePageList.PageCount)
            {
                buttonCollectionLineListPageListNext.Enabled = false;
                buttonCollectionLineListPageListLast.Enabled = false;
            }

            textBoxCollectionLineListPageNumber.Text = CollectionLinePageNumber + " / " + collectionLinePageList.PageCount;
        }

        private void buttonCollectionLineListPageListLast_Click(object sender, EventArgs e)
        {
            collectionLinePageList = new PagedList<Entities.DgvTrnCollectionLineListEntity>(collectionLineData, collectionLinePageList.PageCount, CollectionLinePageSize);
            collectionLineDataSource.DataSource = collectionLinePageList;

            buttonCollectionLineListPageListFirst.Enabled = true;
            buttonCollectionLineListPageListPrevious.Enabled = true;
            buttonCollectionLineListPageListNext.Enabled = false;
            buttonCollectionLineListPageListLast.Enabled = false;

            CollectionLinePageNumber = collectionLinePageList.PageCount;
            textBoxCollectionLineListPageNumber.Text = CollectionLinePageNumber + " / " + collectionLinePageList.PageCount;
        }

        
    }
}
