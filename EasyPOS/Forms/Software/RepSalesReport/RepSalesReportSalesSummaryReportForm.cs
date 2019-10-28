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

            var salesList = repSalesSummaryReportController.ListSales(startDate, endDate);
            if (salesList.Any())
            {
                var row = from d in salesList
                          select new Entities.DgvSalesReportSalesSummaryReportEntity
                          {
                              ColumnId = d.ColumnId,
                              ColumnPeriodId = d.ColumnPeriodId,
                              ColumnPeriod = d.ColumnPeriod,
                              ColumnSalesDate = d.ColumnSalesDate,
                              ColumnSalesNumber = d.ColumnSalesNumber,
                              ColumnManualInvoiceNumber = d.ColumnManualInvoiceNumber,
                              ColumnAmount = d.ColumnAmount,
                              ColumnTableId = d.ColumnTableId,
                              ColumnCustomerId = d.ColumnCustomerId,
                              ColumnCustomer = d.ColumnCustomer,
                              ColumnAccountId = d.ColumnAccountId,
                              ColumnTermId = d.ColumnTermId,
                              ColumnTerm = d.ColumnTerm,
                              ColumnDiscountId = d.ColumnDiscountId,
                              ColumnSeniorCitizenId = d.ColumnSeniorCitizenId,
                              ColumnSeniorCitizenName = d.ColumnSeniorCitizenName,
                              ColumnSeniorCitizenAge = d.ColumnSeniorCitizenAge,
                              ColumnRemarks = d.ColumnRemarks,
                              ColumnSalesAgent = d.ColumnSalesAgent,
                              ColumnSalesAgentUserName = d.ColumnSalesAgentUserName,
                              ColumnTerminalId = d.ColumnTerminalId,
                              ColumnTerminal = d.ColumnTerminal,
                              ColumnPreparedBy = d.ColumnPreparedBy,
                              ColumnPreparedByUserName = d.ColumnPreparedByUserName,
                              ColumnCheckedBy = d.ColumnCheckedBy,
                              ColumnCheckedByUserName = d.ColumnCheckedByUserName,
                              ColumnApprovedBy = d.ColumnApprovedBy,
                              ColumnApprovedByUserName = d.ColumnApprovedByUserName,
                              ColumnIsLocked = d.ColumnIsLocked,
                              ColumnIsTendered = d.ColumnIsTendered,
                              ColumnIsCancelled = d.ColumnIsCancelled,
                              ColumnPaidAmount = d.ColumnPaidAmount,
                              ColumnCreditAmount = d.ColumnCreditAmount,
                              ColumnDebitAmount = d.ColumnDebitAmount,
                              ColumnBalanceAmount = d.ColumnBalanceAmount,
                              ColumnEntryUserId = d.ColumnEntryUserId,
                              ColumnEntryUserName = d.ColumnEntryUserName,
                              ColumnEntryDateTime = d.ColumnEntryDateTime,
                              ColumnUpdateUserId = d.ColumnUpdateUserId,
                              ColumnUpdatedUserName = d.ColumnUpdatedUserName,
                              ColumnUpdateDateTime = d.ColumnUpdateDateTime,
                              ColumnPax = d.ColumnPax,
                              ColumnTableStatus = d.ColumnTableStatus
                          };

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
