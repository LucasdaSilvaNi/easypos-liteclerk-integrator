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

namespace EasyPOS.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnStockInListForm trnStockInListForm;
        public Entities.TrnStockInEntity trnStockInEntity;

        public static List<Entities.DgvStockInDetailStockInLineEntity> stockInLineData = new List<Entities.DgvStockInDetailStockInLineEntity>();
        public static Int32 stockInLinePageNumber = 1;
        public static Int32 stockInLinePageSize = 50;
        public PagedList<Entities.DgvStockInDetailStockInLineEntity> stockInLinePageList = new PagedList<Entities.DgvStockInDetailStockInLineEntity>(stockInLineData, stockInLinePageNumber, stockInLinePageSize);
        public BindingSource stockInLineDataSource = new BindingSource();

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

            CreateStockInLineListDataGridView();
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

            buttonBarcode.Enabled = !isLocked;
            buttonSearchItem.Enabled = !isLocked;
            textBoxBarcode.Enabled = !isLocked;

            dataGridViewStockInLineList.Columns[0].Visible = !isLocked;
            dataGridViewStockInLineList.Columns[1].Visible = !isLocked;
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


        public void UpdateStockInLineListDataSource()
        {
            SetStockInLineListDataSourceAsync();
        }

        public async void SetStockInLineListDataSourceAsync()
        {
            List<Entities.DgvStockInDetailStockInLineEntity> getStockInLineListData = await GetStockInLineListDataTask();
            if (getStockInLineListData.Any())
            {
                stockInLineData = getStockInLineListData;
                stockInLinePageList = new PagedList<Entities.DgvStockInDetailStockInLineEntity>(stockInLineData, stockInLinePageNumber, stockInLinePageSize);

                if (stockInLinePageList.PageCount == 1)
                {
                    buttonStockInLineListPageListFirst.Enabled = false;
                    buttonStockInLineListPageListPrevious.Enabled = false;
                    buttonStockInLineListPageListNext.Enabled = false;
                    buttonStockInLineListPageListLast.Enabled = false;
                }
                else if (stockInLinePageNumber == 1)
                {
                    buttonStockInLineListPageListFirst.Enabled = false;
                    buttonStockInLineListPageListPrevious.Enabled = false;
                    buttonStockInLineListPageListNext.Enabled = true;
                    buttonStockInLineListPageListLast.Enabled = true;
                }
                else if (stockInLinePageNumber == stockInLinePageList.PageCount)
                {
                    buttonStockInLineListPageListFirst.Enabled = true;
                    buttonStockInLineListPageListPrevious.Enabled = true;
                    buttonStockInLineListPageListNext.Enabled = false;
                    buttonStockInLineListPageListLast.Enabled = false;
                }
                else
                {
                    buttonStockInLineListPageListFirst.Enabled = true;
                    buttonStockInLineListPageListPrevious.Enabled = true;
                    buttonStockInLineListPageListNext.Enabled = true;
                    buttonStockInLineListPageListLast.Enabled = true;
                }

                textBoxStockInLineListPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
                stockInLineDataSource.DataSource = stockInLinePageList;
            }
            else
            {
                buttonStockInLineListPageListFirst.Enabled = false;
                buttonStockInLineListPageListPrevious.Enabled = false;
                buttonStockInLineListPageListNext.Enabled = false;
                buttonStockInLineListPageListLast.Enabled = false;

                stockInLinePageNumber = 1;

                stockInLineData = new List<Entities.DgvStockInDetailStockInLineEntity>();
                stockInLineDataSource.Clear();
                textBoxStockInLineListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvStockInDetailStockInLineEntity>> GetStockInLineListDataTask()
        {
            Controllers.TrnStockInLineController trnStockInLineController = new Controllers.TrnStockInLineController();

            List<Entities.TrnStockInLineEntity> listStockInLine = trnStockInLineController.ListStockInLine(trnStockInEntity.Id);
            if (listStockInLine.Any())
            {
                var items = from d in listStockInLine
                            select new Entities.DgvStockInDetailStockInLineEntity
                            {
                                ColumnStockInLineListButtonEdit = "Edit",
                                ColumnStockInLineListButtonDelete = "Delete",
                                ColumnStockInLineListId = d.Id,
                                ColumnStockInLineListStockInId = d.StockInId,
                                ColumnStockInLineListItemId = d.ItemId,
                                ColumnStockInLineListItemDescription = d.ItemDescription,
                                ColumnStockInLineListUnitId = d.UnitId,
                                ColumnStockInLineListUnit = d.Unit,
                                ColumnStockInLineListQuantity = d.Quantity.ToString("#,##0.00"),
                                ColumnStockInLineListCost = d.Cost.ToString("#,##0.00"),
                                ColumnStockInLineListAmount = d.Amount.ToString("#,##0.00"),
                                ColumnStockInLineListExpiryDate = d.ExpiryDate,
                                ColumnStockInLineListLotNumber = d.LotNumber,
                                ColumnStockInLineListAssetAccountId = d.AssetAccountId,
                                ColumnStockInLineListAssetAccount = d.AssetAccount,
                                ColumnStockInLineListPrice = d.Price != null ? Convert.ToDecimal(d.Price).ToString("#,##0.00") : Convert.ToDecimal("0").ToString("#,##0.00"),
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvStockInDetailStockInLineEntity>());
            }
        }

        public void CreateStockInLineListDataGridView()
        {
            UpdateStockInLineListDataSource();

            dataGridViewStockInLineList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockInLineList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewStockInLineList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockInLineList.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockInLineList.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#F34F1C");
            dataGridViewStockInLineList.Columns[1].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewStockInLineList.DataSource = stockInLineDataSource;
        }

        public void GetStockInLineListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void dataGridViewStockInLineList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetStockInLineListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewStockInLineList.CurrentCell.ColumnIndex == dataGridViewStockInLineList.Columns["ColumnStockInLineListButtonEdit"].Index)
            {
                var id = Convert.ToInt32(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListId"].Index].Value);
                var stockInId = Convert.ToInt32(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListStockInId"].Index].Value);
                var itemId = Convert.ToInt32(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListItemId"].Index].Value);
                var itemDescription = dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListItemDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListUnitId"].Index].Value);
                var unit = dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListUnit"].Index].Value.ToString();
                var quantity = Convert.ToDecimal(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListQuantity"].Index].Value);
                var cost = Convert.ToDecimal(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListCost"].Index].Value);
                var amount = Convert.ToDecimal(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListAmount"].Index].Value);
                var expiryDate = dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListExpiryDate"].Index].Value.ToString();
                var lotNumber = dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListLotNumber"].Index].Value.ToString();
                var assetAccountId = Convert.ToInt32(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListAssetAccountId"].Index].Value);
                var assetAccount = dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListAssetAccount"].Index].Value.ToString();
                var price = Convert.ToDecimal(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListPrice"].Index].Value);

                Entities.TrnStockInLineEntity trnStockInLineEntity = new Entities.TrnStockInLineEntity()
                {
                    Id = id,
                    StockInId = stockInId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Unit = unit,
                    Quantity = quantity,
                    Cost = cost,
                    Amount = amount,
                    ExpiryDate = expiryDate,
                    LotNumber = lotNumber,
                    AssetAccountId = assetAccountId,
                    AssetAccount = assetAccount,
                    Price = price
                };

                TrnStockInDetailStockInLineItemDetailForm trnStockInDetailStockInLineItemDetailForm = new TrnStockInDetailStockInLineItemDetailForm(this, trnStockInLineEntity);
                trnStockInDetailStockInLineItemDetailForm.ShowDialog();
            }

            if (e.RowIndex > -1 && dataGridViewStockInLineList.CurrentCell.ColumnIndex == dataGridViewStockInLineList.Columns["ColumnStockInLineListButtonDelete"].Index)
            {
                DialogResult deleteDialogResult = MessageBox.Show("Delete Stock-In?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deleteDialogResult == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dataGridViewStockInLineList.Rows[e.RowIndex].Cells[dataGridViewStockInLineList.Columns["ColumnStockInLineListId"].Index].Value);

                    Controllers.TrnStockInLineController trnStockInLineController = new Controllers.TrnStockInLineController();
                    String[] deleteStockInLine = trnStockInLineController.DeleteStockInLine(id);
                    if (deleteStockInLine[1].Equals("0") == false)
                    {
                        stockInLinePageNumber = 1;
                        UpdateStockInLineListDataSource();
                    }
                    else
                    {
                        MessageBox.Show(deleteStockInLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonStockInLineListPageListFirst_Click(object sender, EventArgs e)
        {
            stockInLinePageList = new PagedList<Entities.DgvStockInDetailStockInLineEntity>(stockInLineData, 1, stockInLinePageSize);
            stockInLineDataSource.DataSource = stockInLinePageList;

            buttonStockInLineListPageListFirst.Enabled = false;
            buttonStockInLineListPageListPrevious.Enabled = false;
            buttonStockInLineListPageListNext.Enabled = true;
            buttonStockInLineListPageListLast.Enabled = true;

            stockInLinePageNumber = 1;
            textBoxStockInLineListPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonStockInLineListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (stockInLinePageList.HasPreviousPage == true)
            {
                stockInLinePageList = new PagedList<Entities.DgvStockInDetailStockInLineEntity>(stockInLineData, --stockInLinePageNumber, stockInLinePageSize);
                stockInLineDataSource.DataSource = stockInLinePageList;
            }

            buttonStockInLineListPageListNext.Enabled = true;
            buttonStockInLineListPageListLast.Enabled = true;

            if (stockInLinePageNumber == 1)
            {
                buttonStockInLineListPageListFirst.Enabled = false;
                buttonStockInLineListPageListPrevious.Enabled = false;
            }

            textBoxStockInLineListPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonStockInLineListPageListNext_Click(object sender, EventArgs e)
        {
            if (stockInLinePageList.HasNextPage == true)
            {
                stockInLinePageList = new PagedList<Entities.DgvStockInDetailStockInLineEntity>(stockInLineData, ++stockInLinePageNumber, stockInLinePageSize);
                stockInLineDataSource.DataSource = stockInLinePageList;
            }

            buttonStockInLineListPageListFirst.Enabled = true;
            buttonStockInLineListPageListPrevious.Enabled = true;

            if (stockInLinePageNumber == stockInLinePageList.PageCount)
            {
                buttonStockInLineListPageListNext.Enabled = false;
                buttonStockInLineListPageListLast.Enabled = false;
            }

            textBoxStockInLineListPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonStockInLineListPageListLast_Click(object sender, EventArgs e)
        {
            stockInLinePageList = new PagedList<Entities.DgvStockInDetailStockInLineEntity>(stockInLineData, stockInLinePageList.PageCount, stockInLinePageSize);
            stockInLineDataSource.DataSource = stockInLinePageList;

            buttonStockInLineListPageListFirst.Enabled = true;
            buttonStockInLineListPageListPrevious.Enabled = true;
            buttonStockInLineListPageListNext.Enabled = false;
            buttonStockInLineListPageListLast.Enabled = false;

            stockInLinePageNumber = stockInLinePageList.PageCount;
            textBoxStockInLineListPageNumber.Text = stockInLinePageNumber + " / " + stockInLinePageList.PageCount;
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnStockInDetailSearchItemForm trnStockInDetailSearchItemForm = new TrnStockInDetailSearchItemForm(this, trnStockInEntity);
            trnStockInDetailSearchItemForm.ShowDialog();
        }

        private void buttonBarcode_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBarcode_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
