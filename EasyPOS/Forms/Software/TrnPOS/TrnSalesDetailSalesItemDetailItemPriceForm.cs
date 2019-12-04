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

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnSalesDetailSalesItemDetailItemPriceForm : Form
    {
        TrnSalesDetailSalesItemDetailForm trnSalesDetailSalesItemDetailForm;
        Entities.TrnSalesLineEntity trnSalesLineEntity;

        public static Int32 pageNumber = 1;
        public static Int32 pageSize = 50;

        public static List<Entities.DgvSalesDetailItemPriceListEntity> itemPriceListData = new List<Entities.DgvSalesDetailItemPriceListEntity>();
        public PagedList<Entities.DgvSalesDetailItemPriceListEntity> itemPriceListPageList = new PagedList<Entities.DgvSalesDetailItemPriceListEntity>(itemPriceListData, pageNumber, pageSize);
        public BindingSource itemPriceListDataSource = new BindingSource();

        public TrnSalesDetailSalesItemDetailItemPriceForm(TrnSalesDetailSalesItemDetailForm salesDetailSalesItemDetailForm, Entities.TrnSalesLineEntity salesLineEntity)
        {
            InitializeComponent();

            trnSalesDetailSalesItemDetailForm = salesDetailSalesItemDetailForm;
            trnSalesLineEntity = salesLineEntity;

            LoadItemPrice();
        }

        public void LoadItemPrice()
        {
            textBoxItemDescription.Text = trnSalesLineEntity.ItemDescription;
            CreateItemPriceListDataGridView();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void UpdateItemPriceListDataSource()
        {
            SetItemPriceListDataSourceAsync();
        }

        public async void SetItemPriceListDataSourceAsync()
        {
            List<Entities.DgvSalesDetailItemPriceListEntity> getItemPriceListData = await GetItemPriceListDataTask();
            if (getItemPriceListData.Any())
            {
                itemPriceListData = getItemPriceListData;
                itemPriceListPageList = new PagedList<Entities.DgvSalesDetailItemPriceListEntity>(itemPriceListData, pageNumber, pageSize);

                if (itemPriceListPageList.PageCount == 1)
                {
                    buttonItemPriceListPageListFirst.Enabled = false;
                    buttonItemPriceListPageListPrevious.Enabled = false;
                    buttonItemPriceListPageListNext.Enabled = false;
                    buttonItemPriceListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonItemPriceListPageListFirst.Enabled = false;
                    buttonItemPriceListPageListPrevious.Enabled = false;
                    buttonItemPriceListPageListNext.Enabled = true;
                    buttonItemPriceListPageListLast.Enabled = true;
                }
                else if (pageNumber == itemPriceListPageList.PageCount)
                {
                    buttonItemPriceListPageListFirst.Enabled = true;
                    buttonItemPriceListPageListPrevious.Enabled = true;
                    buttonItemPriceListPageListNext.Enabled = false;
                    buttonItemPriceListPageListLast.Enabled = false;
                }
                else
                {
                    buttonItemPriceListPageListFirst.Enabled = true;
                    buttonItemPriceListPageListPrevious.Enabled = true;
                    buttonItemPriceListPageListNext.Enabled = true;
                    buttonItemPriceListPageListLast.Enabled = true;
                }

                textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }
            else
            {
                buttonItemPriceListPageListFirst.Enabled = false;
                buttonItemPriceListPageListPrevious.Enabled = false;
                buttonItemPriceListPageListNext.Enabled = false;
                buttonItemPriceListPageListLast.Enabled = false;

                pageNumber = 1;

                itemPriceListData = new List<Entities.DgvSalesDetailItemPriceListEntity>();
                itemPriceListDataSource.Clear();
                textBoxItemPriceListPageNumber.Text = "1 / 1";
            }
        }

        public Task<List<Entities.DgvSalesDetailItemPriceListEntity>> GetItemPriceListDataTask()
        {
            Controllers.MstItemPriceController mstItemPriceController = new Controllers.MstItemPriceController();
            List<Entities.MstItemPriceEntity> listItemPrice = mstItemPriceController.ListItemPrice(trnSalesLineEntity.ItemId);

            if (listItemPrice.Any())
            {
                var itemPrices = from d in listItemPrice
                                 select new Entities.DgvSalesDetailItemPriceListEntity
                                 {
                                     ColumnItemPriceListButtonPick = "Pick",
                                     ColumnItemPriceListPriceDescription = d.PriceDescription,
                                     ColumnItemPriceListPrice = d.Price.ToString("#,##0.00")
                                 };

                return Task.FromResult(itemPrices.ToList());
            }
            else
            {
                return Task.FromResult(new List<Entities.DgvSalesDetailItemPriceListEntity>());
            }
        }

        public void CreateItemPriceListDataGridView()
        {
            UpdateItemPriceListDataSource();

            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#01A6F0");
            dataGridViewItemPriceList.Columns[0].DefaultCellStyle.ForeColor = Color.White;

            dataGridViewItemPriceList.DataSource = itemPriceListDataSource;
        }

        public void GetItemPriceListCurrentSelectedCell(Int32 rowIndex)
        {

        }

        private void buttonItemPriceListPageListFirst_Click(object sender, EventArgs e)
        {
            itemPriceListPageList = new PagedList<Entities.DgvSalesDetailItemPriceListEntity>(itemPriceListData, 1, pageSize);
            itemPriceListDataSource.DataSource = itemPriceListPageList;

            buttonItemPriceListPageListFirst.Enabled = false;
            buttonItemPriceListPageListPrevious.Enabled = false;
            buttonItemPriceListPageListNext.Enabled = true;
            buttonItemPriceListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (itemPriceListPageList.HasPreviousPage == true)
            {
                itemPriceListPageList = new PagedList<Entities.DgvSalesDetailItemPriceListEntity>(itemPriceListData, --pageNumber, pageSize);
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }

            buttonItemPriceListPageListNext.Enabled = true;
            buttonItemPriceListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonItemPriceListPageListFirst.Enabled = false;
                buttonItemPriceListPageListPrevious.Enabled = false;
            }

            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListNext_Click(object sender, EventArgs e)
        {
            if (itemPriceListPageList.HasNextPage == true)
            {
                itemPriceListPageList = new PagedList<Entities.DgvSalesDetailItemPriceListEntity>(itemPriceListData, ++pageNumber, pageSize);
                itemPriceListDataSource.DataSource = itemPriceListPageList;
            }

            buttonItemPriceListPageListFirst.Enabled = true;
            buttonItemPriceListPageListPrevious.Enabled = true;

            if (pageNumber == itemPriceListPageList.PageCount)
            {
                buttonItemPriceListPageListNext.Enabled = false;
                buttonItemPriceListPageListLast.Enabled = false;
            }

            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void buttonItemPriceListPageListLast_Click(object sender, EventArgs e)
        {
            itemPriceListPageList = new PagedList<Entities.DgvSalesDetailItemPriceListEntity>(itemPriceListData, itemPriceListPageList.PageCount, pageSize);
            itemPriceListDataSource.DataSource = itemPriceListPageList;

            buttonItemPriceListPageListFirst.Enabled = true;
            buttonItemPriceListPageListPrevious.Enabled = true;
            buttonItemPriceListPageListNext.Enabled = false;
            buttonItemPriceListPageListLast.Enabled = false;

            pageNumber = itemPriceListPageList.PageCount;
            textBoxItemPriceListPageNumber.Text = pageNumber + " / " + itemPriceListPageList.PageCount;
        }

        private void dataGridViewItemPriceList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                GetItemPriceListCurrentSelectedCell(e.RowIndex);
            }

            if (e.RowIndex > -1 && dataGridViewItemPriceList.CurrentCell.ColumnIndex == dataGridViewItemPriceList.Columns["ColumnItemPriceListButtonPick"].Index)
            {
                Decimal price = Convert.ToDecimal(dataGridViewItemPriceList.Rows[dataGridViewItemPriceList.CurrentCell.RowIndex].Cells[dataGridViewItemPriceList.Columns["ColumnItemPriceListPrice"].Index].Value);
                trnSalesDetailSalesItemDetailForm.UpdatePrice(price);

                Close();
            }
        }
    }
}
