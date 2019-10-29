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
    public partial class RepSalesReportCancelSalesSummaryReportForm : Form
    {
        public List<Entities.DgvSalesReportCancelSalesSummaryReportEntity> canCelSalesList;
        public BindingSource dataCancelSalesListSource = new BindingSource();
        public PagedList<Entities.DgvSalesReportCancelSalesSummaryReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateStart;
        public DateTime dateEnd;

        public RepSalesReportCancelSalesSummaryReportForm(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            dateStart = startDate;
            dateEnd = endDate;

            GetCancelSalesListDataSource();
            GetCancelSalesSummaryReportSource();
        }

        public List<Entities.DgvSalesReportCancelSalesSummaryReportEntity> GetCancelSalesSummaryListData(DateTime startDate, DateTime endDate)
        {
            List<Entities.DgvSalesReportCancelSalesSummaryReportEntity> rowList = new List<Entities.DgvSalesReportCancelSalesSummaryReportEntity>();

            Controllers.RepSalesReportController repSalesReportController = new Controllers.RepSalesReportController();

            var cancelSalesList = repSalesReportController.CancelSalesSummaryList(startDate, endDate);
            if (cancelSalesList.Any())
            {
                Decimal totalAmount = 0;
                var row = from d in cancelSalesList
                          select new Entities.DgvSalesReportCancelSalesSummaryReportEntity
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

                totalAmount = cancelSalesList.Sum(d => d.Amount);

                textBoxTotalAmount.Text = totalAmount.ToString("#,##0.00");

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetCancelSalesListDataSource()
        {
            canCelSalesList = GetCancelSalesSummaryListData(dateStart, dateEnd);
            if (canCelSalesList.Any())
            {

                pageList = new PagedList<Entities.DgvSalesReportCancelSalesSummaryReportEntity>(canCelSalesList, pageNumber, pageSize);

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
                dataCancelSalesListSource.DataSource = pageList;
            }
            else
            {
                buttonPageListFirst.Enabled = false;
                buttonPageListPrevious.Enabled = false;
                buttonPageListNext.Enabled = false;
                buttonPageListLast.Enabled = false;

                dataCancelSalesListSource.Clear();
                textBoxPageNumber.Text = "0 / 0";
            }
        }

        public void GetCancelSalesSummaryReportSource() {
            dataGridCancelSalesSummaryReport.DataSource = dataCancelSalesListSource;
        }
      

        private void buttonSalesListPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvSalesReportCancelSalesSummaryReportEntity>(canCelSalesList, 1, pageSize);
            dataCancelSalesListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = false;
            buttonPageListPrevious.Enabled = false;
            buttonPageListNext.Enabled = true;
            buttonPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonSalesListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvSalesReportCancelSalesSummaryReportEntity>(canCelSalesList, --pageNumber, pageSize);
                dataCancelSalesListSource.DataSource = pageList;
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

        private void buttonSalesListPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvSalesReportCancelSalesSummaryReportEntity>(canCelSalesList, ++pageNumber, pageSize);
                dataCancelSalesListSource.DataSource = pageList;
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

        private void buttonSalesListPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvSalesReportCancelSalesSummaryReportEntity>(canCelSalesList, pageList.PageCount, pageSize);
            dataCancelSalesListSource.DataSource = pageList;

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
