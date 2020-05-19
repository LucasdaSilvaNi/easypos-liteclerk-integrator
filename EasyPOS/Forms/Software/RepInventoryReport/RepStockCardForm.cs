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

namespace EasyPOS.Forms.Software.RepInventoryReport
{
    public partial class RepStockCardForm : Form
    {
        public List<Entities.DgvRepInventoryStockCardListEntity> inventoryReportList;
        public BindingSource dataInventoryReportListSource = new BindingSource();
        public PagedList<Entities.DgvRepInventoryStockCardListEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime startDate;
        public DateTime endDate;
        public Int32 itemId;

        public RepStockCardForm(DateTime dateStart, DateTime dateEnd, Int32 filterItemId)
        {
            InitializeComponent();

            startDate = dateStart;
            endDate = dateEnd;
            itemId = filterItemId;

            GetInventoryReportDataSource("");
            GetDataGridViewCollectionDetailReportSource();
        }

        public List<Entities.DgvRepInventoryStockCardListEntity> GetInventoryReportListData(DateTime startDate, DateTime endDate, Int32 itemId, String filter)
        {
            List<Entities.DgvRepInventoryStockCardListEntity> rowList = new List<Entities.DgvRepInventoryStockCardListEntity>();

            Controllers.RepInventoryReportController repInvetoryReportController = new Controllers.RepInventoryReportController();

            var inventoryReportList = repInvetoryReportController.StockCardReport(startDate, endDate, itemId, filter);
            if (inventoryReportList.Any())
            {
                var row = from d in inventoryReportList
                          select new Entities.DgvRepInventoryStockCardListEntity
                          {
                              ColumnInventoryDate = d.InventoryDate,
                              ColumnDocument = d.Document,
                              ColumnBegQuantity = d.BeginningQuantity.ToString("#,##0.00"),
                              ColumnInQuantity = d.InQuantity.ToString("#,##0.00"),
                              ColumnOutQuantity = d.OutQuantity.ToString("#,##0.00"),
                              ColumnEndingQuantity = d.EndingQuantity.ToString("#,##0.00"),
                          };

                rowList = row.ToList();
            }

            return rowList;
        }

        public void GetInventoryReportDataSource(String filter)
        {
            inventoryReportList = GetInventoryReportListData(startDate, endDate, itemId, filter);
            if (inventoryReportList.Any())
            {
                pageList = new PagedList<Entities.DgvRepInventoryStockCardListEntity>(inventoryReportList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonPageListFirst.Enabled = false;
                    buttonPageListPrevious.Enabled = false;
                    buttonPageListNext.Enabled = false;
                    buttonPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonPageListFirst.Enabled = false;
                    buttonPageListPrevious.Enabled = false;
                    buttonPageListNext.Enabled = true;
                    buttonPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonPageListFirst.Enabled = true;
                    buttonPageListPrevious.Enabled = true;
                    buttonPageListNext.Enabled = false;
                    buttonPageListLast.Enabled = false;
                }
                else
                {
                    buttonPageListFirst.Enabled = true;
                    buttonPageListPrevious.Enabled = true;
                    buttonPageListNext.Enabled = true;
                    buttonPageListLast.Enabled = true;
                }

                textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataInventoryReportListSource.DataSource = pageList;
            }
            else
            {
                buttonPageListFirst.Enabled = false;
                buttonPageListPrevious.Enabled = false;
                buttonPageListNext.Enabled = false;
                buttonPageListLast.Enabled = false;

                dataInventoryReportListSource.Clear();
                textBoxPageNumber.Text = "0 / 0";
            }
        }

        public void GetDataGridViewCollectionDetailReportSource()
        {
            dataGridViewInventoryReport.DataSource = dataInventoryReportListSource;
        }

        private void buttonPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryStockCardListEntity>(inventoryReportList, 1, pageSize);
            dataInventoryReportListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = false;
            buttonPageListPrevious.Enabled = false;
            buttonPageListNext.Enabled = true;
            buttonPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryStockCardListEntity>(inventoryReportList, --pageNumber, pageSize);
                dataInventoryReportListSource.DataSource = pageList;
            }

            buttonPageListNext.Enabled = true;
            buttonPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonPageListFirst.Enabled = false;
                buttonPageListPrevious.Enabled = false;
            }

            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvRepInventoryStockCardListEntity>(inventoryReportList, ++pageNumber, pageSize);
                dataInventoryReportListSource.DataSource = pageList;
            }

            buttonPageListFirst.Enabled = true;
            buttonPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonPageListNext.Enabled = false;
                buttonPageListLast.Enabled = false;
            }

            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepInventoryStockCardListEntity>(inventoryReportList, pageList.PageCount, pageSize);
            dataInventoryReportListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = true;
            buttonPageListPrevious.Enabled = true;
            buttonPageListNext.Enabled = false;
            buttonPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetInventoryReportDataSource(textBoxFilter.Text);
            }
        }
    }
}
