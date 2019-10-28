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

namespace EasyPOS.Forms.Software.RepSalesReport
{
    public partial class RepSalesReportSalesSummaryReportForm : Form
    {
        public List<Entities.DgvSalesReportSalesSummaryReportEntity> salesList;
        public BindingSource dataSalesListSource = new BindingSource();
        public PagedList<Entities.DgvSalesReportSalesSummaryReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateStart;
        public DateTime dateEnd;

        public RepSalesReportSalesSummaryReportForm(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            dateStart = startDate;
            dateEnd = endDate;

            GetSalesListDataSource();
            CreateSalesSummaryListDataGrid();
        }


        public List<Entities.DgvSalesReportSalesSummaryReportEntity> GetSalesSummaryListData(DateTime startDate, DateTime endDate)
        {
            List<Entities.DgvSalesReportSalesSummaryReportEntity> rowList = new List<Entities.DgvSalesReportSalesSummaryReportEntity>();

            Controllers.RepSalesReportController repSalesSummaryReportController = new Controllers.RepSalesReportController();

            var salesList = repSalesSummaryReportController.SalesSummaryList(startDate, endDate);
            if (salesList.Any())
            {
                Decimal totalAmount = 0;
                var row = from d in salesList
                          select new Entities.DgvSalesReportSalesSummaryReportEntity
                          {
                              ColumnId = d.Id,
                              ColumnPeriodId = d.Id,
                              ColumnPeriod = d.Period,
                              ColumnTerminal = d.Terminal,
                              ColumnSalesDate = d.SalesDate,
                              ColumnSalesNumber = d.SalesNumber,
                              ColumnManualInvoiceNumber = d.ManualInvoiceNumber,
                              ColumnAmount = d.Amount.ToString("#,##0.00"),
                              ColumnTableId = d.TableId,
                              ColumnCustomerId = d.CustomerId,
                              ColumnCustomer = d.Customer,
                              ColumnAccountId = d.AccountId,
                              ColumnTermId = d.TermId,
                              ColumnTerm = d.Term,
                              ColumnDiscountId = d.DiscountId,
                              ColumnRemarks = d.Remarks,
                              ColumnTerminalId = d.TerminalId,
                              ColumnPreparedBy = d.PreparedBy,
                              ColumnPreparedByUserName = d.PreparedByUserName,
                              ColumnPax = d.Pax,
                              ColumnTable = d.Table,
                          };

                totalAmount = salesList.Sum(d => d.Amount);

                textBoxTotalAmount.Text = totalAmount.ToString("#,##0.00");

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetSalesListDataSource()
        {
            salesList = GetSalesSummaryListData(dateStart, dateEnd);
            if (salesList.Any())
            {

                pageList = new PagedList<Entities.DgvSalesReportSalesSummaryReportEntity>(salesList, pageNumber, pageSize);

                if (pageList.PageCount == 1)
                {
                    buttonSalesListPageListFirst.Enabled = false;
                    buttonSalesListPageListPrevious.Enabled = false;
                    buttonSalesListPageListNext.Enabled = false;
                    buttonSalesListPageListLast.Enabled = false;
                }
                else if (pageNumber == 1)
                {
                    buttonSalesListPageListFirst.Enabled = false;
                    buttonSalesListPageListPrevious.Enabled = false;
                    buttonSalesListPageListNext.Enabled = true;
                    buttonSalesListPageListLast.Enabled = true;
                }
                else if (pageNumber == pageList.PageCount)
                {
                    buttonSalesListPageListFirst.Enabled = true;
                    buttonSalesListPageListPrevious.Enabled = true;
                    buttonSalesListPageListNext.Enabled = false;
                    buttonSalesListPageListLast.Enabled = false;
                }
                else
                {
                    buttonSalesListPageListFirst.Enabled = true;
                    buttonSalesListPageListPrevious.Enabled = true;
                    buttonSalesListPageListNext.Enabled = true;
                    buttonSalesListPageListLast.Enabled = true;
                }

                textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
                dataSalesListSource.DataSource = pageList;
            }
            else
            {
                buttonSalesListPageListFirst.Enabled = false;
                buttonSalesListPageListPrevious.Enabled = false;
                buttonSalesListPageListNext.Enabled = false;
                buttonSalesListPageListLast.Enabled = false;

                dataSalesListSource.Clear();
                textBoxPageNumber.Text = "0 / 0";
            }
        }

        public void CreateSalesSummaryListDataGrid()
        {
            dataGridViewSalesSummaryReport.DataSource = dataSalesListSource;
        }

        private void buttonSalesListPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvSalesReportSalesSummaryReportEntity>(salesList, 1, pageSize);
            dataSalesListSource.DataSource = pageList;

            buttonSalesListPageListFirst.Enabled = false;
            buttonSalesListPageListPrevious.Enabled = false;
            buttonSalesListPageListNext.Enabled = true;
            buttonSalesListPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvSalesReportSalesSummaryReportEntity>(salesList, --pageNumber, pageSize);
                dataSalesListSource.DataSource = pageList;
            }

            buttonSalesListPageListNext.Enabled = true;
            buttonSalesListPageListLast.Enabled = true;

            if (pageNumber == 1)
            {
                buttonSalesListPageListFirst.Enabled = false;
                buttonSalesListPageListPrevious.Enabled = false;
            }

            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesListPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvSalesReportSalesSummaryReportEntity>(salesList, ++pageNumber, pageSize);
                dataSalesListSource.DataSource = pageList;
            }

            buttonSalesListPageListFirst.Enabled = true;
            buttonSalesListPageListPrevious.Enabled = true;

            if (pageNumber == pageList.PageCount)
            {
                buttonSalesListPageListNext.Enabled = false;
                buttonSalesListPageListLast.Enabled = false;
            }

            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesListPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvSalesReportSalesSummaryReportEntity>(salesList, pageList.PageCount, pageSize);
            dataSalesListSource.DataSource = pageList;

            buttonSalesListPageListFirst.Enabled = true;
            buttonSalesListPageListPrevious.Enabled = true;
            buttonSalesListPageListNext.Enabled = false;
            buttonSalesListPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
