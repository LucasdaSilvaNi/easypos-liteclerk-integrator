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
    public partial class RepSalesReportSalesDetailReportForm : Form
    {
        public List<Entities.DgvSalesDetailReportEntity> salesDetailList;
        public BindingSource dataSalesDatailListSource = new BindingSource();
        public PagedList<Entities.DgvSalesDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;


        public DateTime dateStart;
        public DateTime dateEnd;

        public RepSalesReportSalesDetailReportForm(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            dateStart = startDate;
            dateEnd = endDate;

            CreateDgvSalesDetailReport();
        }

        public List<Entities.DgvSalesDetailReportEntity> GetSalesDetailListData(DateTime startDate, DateTime endDate)
        {
            List<Entities.DgvSalesDetailReportEntity> rowList = new List<Entities.DgvSalesDetailReportEntity>();

            Controllers.RepSalesReportController repSalesDetailReportController = new Controllers.RepSalesReportController();

            var salesDetailList = repSalesDetailReportController.SalesDetailList(startDate, endDate);
            if (salesDetailList.Any())
            {
                Decimal totalAmount = 0;

                var row = from d in salesDetailList
                          select new Entities.DgvSalesDetailReportEntity
                          {
                              ColumnTerminal = d.Terminal,
                              ColumnDate = d.Date,
                              ColumnSalesNumber = d.SalesNumber,
                              ColumnCustomer = d.Customer,
                              ColumnItemDescription = d.ItemDescription,
                              ColumnItemCode = d.ItemCode,
                              ColumnItemCategory = d.ItemCategory,
                              ColumnUnit = d.Unit,
                              ColumnPrice = d.Price.ToString("#,##0.00"),
                              ColumnDiscount = d.Discount,
                              ColumnDiscountRate = d.DiscountRate.ToString("#,##0.00"),
                              ColumnDiscountAmount = d.DiscountAmount.ToString("#,##0.00"),
                              ColumnNetPrice = d.NetPrice.ToString("#,##0.00"),
                              ColumnQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnAmount = d.Amount.ToString("#,##0.00"),
                              ColumnTax = d.Tax,
                              ColumnTaxRate = d.TaxRate.ToString("#,##0.00"),
                              ColumnTaxAmount = d.TaxAmount.ToString("#,##0.00"),
                              ColumnUser = d.User,
                              ColumnTimeStamp = d.SalesLineTimeStamp,
                          };

                totalAmount = salesDetailList.Sum(d => d.Amount);

                textBoxTotalAmount.Text = totalAmount.ToString("#,##0.00");

                rowList = row.ToList();

            }
            return rowList;
        }

        public void CreateDgvSalesDetailReport()
        {
            GetSalesListDataSource();
            GetSalesDetailListDataGridSource();
        }

        public void GetSalesListDataSource()
        {
            salesDetailList = GetSalesDetailListData(dateStart, dateEnd);
            if (salesDetailList.Any())
            {

                pageList = new PagedList<Entities.DgvSalesDetailReportEntity>(salesDetailList, pageNumber, pageSize);

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
                dataSalesDatailListSource.DataSource = pageList;
            }
            else
            {
                buttonPageListFirst.Enabled = false;
                buttonPageListPrevious.Enabled = false;
                buttonPageListNext.Enabled = false;
                buttonPageListLast.Enabled = false;

                dataSalesDatailListSource.Clear();
                textBoxPageNumber.Text = "0 / 0";
            }
        }

        public void GetSalesDetailListDataGridSource()
        {
            dataGridViewSalesDetailReport.DataSource = dataSalesDatailListSource;

        }

        private void buttonSalesListPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvSalesDetailReportEntity>(salesDetailList, 1, pageSize);
            dataSalesDatailListSource.DataSource = pageList;

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
                pageList = new PagedList<Entities.DgvSalesDetailReportEntity>(salesDetailList, --pageNumber, pageSize);
                dataSalesDatailListSource.DataSource = pageList;
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
                pageList = new PagedList<Entities.DgvSalesDetailReportEntity>(salesDetailList, ++pageNumber, pageSize);
                dataSalesDatailListSource.DataSource = pageList;
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
            pageList = new PagedList<Entities.DgvSalesDetailReportEntity>(salesDetailList, pageList.PageCount, pageSize);
            dataSalesDatailListSource.DataSource = pageList;

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
