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

namespace EasyPOS.Forms.Software.TrnPurchaseOrder
{
    public partial class TrnPurchaseOrderSearchItemForm : Form
    {
        public TrnPurchaseOrderDetailForm trnPurchaseOrderDetailForm;
        public Entities.TrnPurchaseOrderEntity trnPurchaseOrderEntity;

        public static List<Entities.DgvTrnPurchaseOrderSearchItemListEntity> searchItemListData = new List<Entities.DgvTrnPurchaseOrderSearchItemListEntity>();
        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;
        public PagedList<Entities.DgvTrnPurchaseOrderSearchItemListEntity> searchItemListPageList = new PagedList<Entities.DgvTrnPurchaseOrderSearchItemListEntity>(searchItemListData, pageNumber, pageSize);
        public BindingSource searchItemListDataSource = new BindingSource();

        public TrnPurchaseOrderSearchItemForm(TrnPurchaseOrderDetailForm purchaseOrderDetailForm, Entities.TrnPurchaseOrderEntity purchaseOrderEntity)
        {
            InitializeComponent();

            trnPurchaseOrderDetailForm = purchaseOrderDetailForm;
            trnPurchaseOrderEntity = purchaseOrderEntity;
            if (Modules.SysCurrentModule.GetCurrentSettings().HideItemListBarcode == true)
            {
                ColumnSearchItemListBarCode.Visible = false;
            }
            else
            {
                ColumnSearchItemListBarCode.Visible = true;
            }
            CreateSearchItemListDataGridView();
            textBoxSearchItemListFilter.Focus();
            
            
        }

        public void UpdateSearchItemListDataSource()
        {
            SetSearchItemListDataSourceAsync();
        }

        public async void SetSearchItemListDataSourceAsync()
        {
            List<Entities.DgvTrnPurchaseOrderSearchItemListEntity> getSearchItemListData = await GetSearchItemListDataTask();
            if (getSearchItemListData.Any())
            {
                searchItemListData = getSearchItemListData;
                searchItemListPageList = new PagedList<Entities.DgvTrnPurchaseOrderSearchItemListEntity>(searchItemListData, pageNumber, pageSize);

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

                searchItemListData = new List<Entities.DgvTrnPurchaseOrderSearchItemListEntity>();
                searchItemListDataSource.Clear();
                textBoxSearchItemListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvTrnPurchaseOrderSearchItemListEntity>> GetSearchItemListDataTask()
        {
            String filter = textBoxSearchItemListFilter.Text;
            Controllers.TrnPurchaseOrderLineController trnPurchaseOrderLineController = new Controllers.TrnPurchaseOrderLineController();

            List<Entities.MstItemEntity> listSearchItem = trnPurchaseOrderLineController.ListSearchItem(filter);
            if (listSearchItem.Any())
            {
                var items = from d in listSearchItem
                            select new Entities.DgvTrnPurchaseOrderSearchItemListEntity
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
                                ColumnSearchItemListCost = d.Cost.ToString("#,##0.00"),
                                ColumnSearchItemListOnhandQuantity = d.OnhandQuantity.ToString("#,##0.00"),
                                ColumnSearchItemListButtonPick = "Pick"
                            };

                return Task.FromResult(items.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvTrnPurchaseOrderSearchItemListEntity>());
            }
        }

        public void CreateSearchItemListDataGridView()
        {
            UpdateSearchItemListDataSource();

            dataGridViewSearchItemList.Columns[12].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItemList.Columns[12].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewSearchItemList.Columns[12].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewSearchItemList.DataSource = searchItemListDataSource;
        }

        public void GetSearchItemListCurrentSelectedCell(Int32 rowIndex)
        {

        }


        private void dataGridViewSearchItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSearchItemList.CurrentCell.ColumnIndex == dataGridViewSearchItemList.Columns["ColumnSearchItemListButtonPick"].Index)
            {
                var PurchaseOrderId = trnPurchaseOrderEntity.Id;
                var itemId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListId"].Index].Value);
                var itemDescription = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListDescription"].Index].Value.ToString();
                var unitId = Convert.ToInt32(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListUnitId"].Index].Value);
                var unit = dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListUnit"].Index].Value.ToString();
                var cost = Convert.ToDecimal(dataGridViewSearchItemList.Rows[e.RowIndex].Cells[dataGridViewSearchItemList.Columns["ColumnSearchItemListCost"].Index].Value);

                Entities.TrnPurchaseOrderLineEntity trnPurchaseOrderLineEntity = new Entities.TrnPurchaseOrderLineEntity()
                {
                    Id = 0,
                    PurchaseOrderId = PurchaseOrderId,
                    ItemId = itemId,
                    ItemDescription = itemDescription,
                    UnitId = unitId,
                    Unit = unit,
                    Quantity = 1,
                    Cost = cost,
                    Amount = 0,
                };

                TrnPurchaseOrderLineItemDetailForm trnPurchaseOrderDetailPurchaseOrderLineItemDetailForm = new TrnPurchaseOrderLineItemDetailForm(trnPurchaseOrderDetailForm, trnPurchaseOrderLineEntity);
                trnPurchaseOrderDetailPurchaseOrderLineItemDetailForm.ShowDialog();
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
            searchItemListPageList = new PagedList<Entities.DgvTrnPurchaseOrderSearchItemListEntity>(searchItemListData, 1, pageSize);
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
                searchItemListPageList = new PagedList<Entities.DgvTrnPurchaseOrderSearchItemListEntity>(searchItemListData, --pageNumber, pageSize);
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
                searchItemListPageList = new PagedList<Entities.DgvTrnPurchaseOrderSearchItemListEntity>(searchItemListData, ++pageNumber, pageSize);
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
            searchItemListPageList = new PagedList<Entities.DgvTrnPurchaseOrderSearchItemListEntity>(searchItemListData, searchItemListPageList.PageCount, pageSize);
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
