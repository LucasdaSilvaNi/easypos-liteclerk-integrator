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
    public partial class TrnStockInDetailSearchItemForm : Form
    {
        public TrnStockInDetailForm trnStockInDetailForm;
        public Entities.TrnStockInEntity trnStockInEntity;

        public static List<Entities.DgvStockInSearchItemListEntity> searchItemListData = new List<Entities.DgvStockInSearchItemListEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvStockInSearchItemListEntity> searchItemListPageList = new PagedList<Entities.DgvStockInSearchItemListEntity>(searchItemListData, pageNumber, pageSize);
        public BindingSource searchItemListDataSource = new BindingSource();

        public TrnStockInDetailSearchItemForm(TrnStockInDetailForm stockInDetailForm, Entities.TrnStockInEntity stockInEntity)
        {
            InitializeComponent();

            trnStockInDetailForm = stockInDetailForm;
            trnStockInEntity = stockInEntity;

            CreateSearchItemListDataGridView();
            textBoxSearchItemListFilter.Focus();
        }

        public void UpdateSearchItemListDataSource()
        {
            SetSearchItemListDataSourceAsync();
        }

        public async void SetSearchItemListDataSourceAsync()
        {
            List<Entities.DgvStockInSearchItemListEntity> getSearchItemListData = await GetSearchItemListDataTask();
            if (getSearchItemListData.Any())
            {
                searchItemListData = getSearchItemListData;
                searchItemListPageList = new PagedList<Entities.DgvStockInSearchItemListEntity>(searchItemListData, pageNumber, pageSize);

                if (searchItemListPageList.PageCount == 1)
                {
                    buttonSearchItemListPageListFirst.Enabled = false;
                    buttonSearchItemListPageListPrevious.Enabled = false;
                    buttonSearchItemListPageListNext.Enabled = false;
                    buttonSearchItemListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSearchItemListPageListFirst.Enabled = false;
                    buttonSearchItemListPageListPrevious.Enabled = false;
                    buttonSearchItemListPageListNext.Enabled = true;
                    buttonSearchItemListPageListLast.Enabled = true;
                }
                else if (pageNumber == searchItemListPageList.PageCount)
                {
                    buttonSearchItemListPageListFirst.Enabled = true;
                    buttonSearchItemListPageListPrevious.Enabled = true;
                    buttonSearchItemListPageListNext.Enabled = false;
                    buttonSearchItemListPageListLast.Enabled = false;
                }
                else
                {
                    buttonSearchItemListPageListFirst.Enabled = true;
                    buttonSearchItemListPageListPrevious.Enabled = true;
                    buttonSearchItemListPageListNext.Enabled = true;
                    buttonSearchItemListPageListLast.Enabled = true;
                }

                textBoxSearchItemListPageNumber.Text = pageNumber + " / " + searchItemListPageList.PageCount;
                searchItemListDataSource.DataSource = searchItemListPageList;
            }
            else
            {
                buttonSearchItemListPageListFirst.Enabled = false;
                buttonSearchItemListPageListPrevious.Enabled = false;
                buttonSearchItemListPageListNext.Enabled = false;
                buttonSearchItemListPageListLast.Enabled = false;

                pageNumber = 1;

                searchItemListData = new List<Entities.DgvStockInSearchItemListEntity>();
                searchItemListDataSource.Clear();
                textBoxSearchItemListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvStockInSearchItemListEntity>> GetSearchItemListDataTask()
        {
            String filter = textBoxSearchItemListFilter.Text;
            Controllers.TrnStockInLineController trnStockInLineController = new Controllers.TrnStockInLineController();

            List<Entities.MstItemEntity> listSearchItem = trnStockInLineController.ListSearchItem(filter);
            if (listSearchItem.Any())
            {
                var items = from d in listSearchItem
                            select new Entities.DgvStockInSearchItemListEntity
                            {
                                ColumnSearchItemListId = d.Id,
                                ColumnSearchItemListBarCode = d.BarCode,
                                ColumnSearchItemListDescription = d.ItemDescription,
                                ColumnSearchItemListGenericName = d.GenericName,
                                ColumnSearchItemListOutTaxId = d.OutTaxId,
                                ColumnSearchItemListOutTax = d.OutTax,
                                ColumnSearchItemListOutTaxRate = d.OutTaxRate.ToString("#,##0.00"),
                                ColumnSearchItemListUnitId = d.UnitId,
                                ColumnSearchItemListUnit = d.Unit,
                                ColumnSearchItemListPrice = d.Price.ToString("#,##0.00"),
                                ColumnSearchItemListOnhandQuantity = d.OnhandQuantity.ToString("#,##0.00"),
                                ColumnSearchItemListButtonPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvStockInSearchItemListEntity>());
            }
        }

        public void CreateSearchItemListDataGridView()
        {
            UpdateSearchItemListDataSource();

            dataGridViewSearchItemList.Columns[11].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItemList.Columns[11].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItemList.Columns[11].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchItemList.DataSource = searchItemListDataSource;
        }

        public void GetSearchItemListCurrentSelectedCell(Int32 rowIndex)
        {

        }


        private void dataGridViewSearchItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchItemList.CurrentCell.ColumnIndex == dataGridViewSearchItemList.Columns["ColumnSearchItemListButtonPick"].Index)
            {
                var stockInId = trnStockInEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListId"].Index].Value);
                var itemDescription = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListUnitId"].Index].Value);
                var unit = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListUnit"].Index].Value.ToString();
                var price = Convert.ToDecimal(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListPrice"].Index].Value);

                Entities.TrnStockInLineEntity trnStockInLineEntity = new Entities.TrnStockInLineEntity()
                {
                    Id = 0,
                    StockInId = stockInId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Unit = unit,
                    Quantity = 1,
                    Cost = 0,
                    Amount = 0,
                    ExpiryDate = "",
                    LotNumber = "",
                    AssetAccountId = 0,
                    AssetAccount = "",
                    Price = price
                };

                TrnStockInDetailStockInLineItemDetailForm trnStockInDetailStockInLineItemDetailForm = new TrnStockInDetailStockInLineItemDetailForm(trnStockInDetailForm, trnStockInLineEntity);
                trnStockInDetailStockInLineItemDetailForm.ShowDialog();
            }
        }

        private void textBoxSearchItemListFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateSearchItemListDataSource();
                pageNumber = 1;
                CreateSearchItemListDataGridView();
            }
        }

        private void buttonSearchItemListPageListFirst_Click(object sender, EventArgs e)
        {
            searchItemListPageList = new PagedList<Entities.DgvStockInSearchItemListEntity>(searchItemListData, 1, pageSize);
            searchItemListDataSource.DataSource = searchItemListPageList;

            buttonSearchItemListPageListFirst.Enabled = false;
            buttonSearchItemListPageListPrevious.Enabled = false;
            buttonSearchItemListPageListNext.Enabled = true;
            buttonSearchItemListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxSearchItemListPageNumber.Text = pageNumber + " / " + searchItemListPageList.PageCount;
        }

        private void buttonSearchItemListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (searchItemListPageList.HasPreviousPage == true)
            {
                searchItemListPageList = new PagedList<Entities.DgvStockInSearchItemListEntity>(searchItemListData, --pageNumber, pageSize);
                searchItemListDataSource.DataSource = searchItemListPageList;
            }

            buttonSearchItemListPageListNext.Enabled = true;
            buttonSearchItemListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSearchItemListPageListFirst.Enabled = false;
                buttonSearchItemListPageListPrevious.Enabled = false;
            }

            textBoxSearchItemListPageNumber.Text = pageNumber + " / " + searchItemListPageList.PageCount;
        }

        private void buttonSearchItemListPageListNext_Click(object sender, EventArgs e)
        {
            if (searchItemListPageList.HasNextPage == true)
            {
                searchItemListPageList = new PagedList<Entities.DgvStockInSearchItemListEntity>(searchItemListData, ++pageNumber, pageSize);
                searchItemListDataSource.DataSource = searchItemListPageList;
            }

            buttonSearchItemListPageListFirst.Enabled = true;
            buttonSearchItemListPageListPrevious.Enabled = true;

            if (pageNumber == searchItemListPageList.PageCount)
            {
                buttonSearchItemListPageListNext.Enabled = false;
                buttonSearchItemListPageListLast.Enabled = false;
            }

            textBoxSearchItemListPageNumber.Text = pageNumber + " / " + searchItemListPageList.PageCount;
        }

        private void buttonSearchItemListPageListLast_Click(object sender, EventArgs e)
        {
            searchItemListPageList = new PagedList<Entities.DgvStockInSearchItemListEntity>(searchItemListData, searchItemListPageList.PageCount, pageSize);
            searchItemListDataSource.DataSource = searchItemListPageList;

            buttonSearchItemListPageListFirst.Enabled = true;
            buttonSearchItemListPageListPrevious.Enabled = true;
            buttonSearchItemListPageListNext.Enabled = false;
            buttonSearchItemListPageListLast.Enabled = false;

            pageNumber = searchItemListPageList.PageCount;
            textBoxSearchItemListPageNumber.Text = pageNumber + " / " + searchItemListPageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
