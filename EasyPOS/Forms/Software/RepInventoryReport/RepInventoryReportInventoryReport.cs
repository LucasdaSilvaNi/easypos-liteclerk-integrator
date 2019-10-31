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
    public partial class RepInventoryReportInventoryReport : Form
    {
        public List<Entities.DgvInventoryReportEntity> inventoryReportList;
        public BindingSource dataInventoryReportListSource = new BindingSource();
        public PagedList<Entities.DgvInventoryReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime startDate;
        public DateTime endDate;

        public RepInventoryReportInventoryReport(DateTime dateStart, DateTime dateEnd)
        {
            InitializeComponent();

            startDate = dateStart;
            endDate = dateEnd;

            GetCancelSalesListDataSource();
            GetDataGridViewCollectionDetailReportSource();
        }

        public List<Entities.DgvInventoryReportEntity> GetInventoryReportListData(DateTime startDate, DateTime endDate)
        {
            List<Entities.DgvInventoryReportEntity> rowList = new List<Entities.DgvInventoryReportEntity>();

            Controllers.RepInventoryReportController repInvetoryReportController = new Controllers.RepInventoryReportController();

            var inventoryReportList = repInvetoryReportController.GetInventoryReport(startDate, endDate);
            if (inventoryReportList.Any())
            {
                Decimal totalAmount = 0;
                var row = from d in inventoryReportList
                          select new Entities.DgvInventoryReportEntity
                          {
                              ColumnItemDescription = d.ItemDescription,
                              ColumnUnit = d.Unit,
                              ColumnBegQuantity = d.BegQuantity.ToString("#,##0.00"),
                              ColumnInQuantity = d.InQuantity.ToString("#,##0.00"),
                              ColumnOutQuantity = d.OutQuantity.ToString("#,##0.00"),
                              ColumnEndingQuantity = d.EndingQuantity.ToString("#,##0.00"),
                              ColumnStockCount = d.CountQuantity.ToString("#,##0.00"),
                              ColumnVariance = d.Variance.ToString("#,##0.00"),
                              ColumnCost = d.Cost.ToString("#,##0.00"),
                              ColumnAmount = d.Amount.ToString("#,##0.00")

                          };

                totalAmount = inventoryReportList.Sum(d => d.Amount);

                textBoxTotalAmount.Text = totalAmount.ToString("#,##0.00");

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetCancelSalesListDataSource()
        {
            inventoryReportList = GetInventoryReportListData(startDate, endDate);
            if (inventoryReportList.Any())
            {

                pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, pageNumber, pageSize);

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
            pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, 1, pageSize);
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
                pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, --pageNumber, pageSize);
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
                pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, ++pageNumber, pageSize);
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
            pageList = new PagedList<Entities.DgvInventoryReportEntity>(inventoryReportList, pageList.PageCount, pageSize);
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
    }
}
