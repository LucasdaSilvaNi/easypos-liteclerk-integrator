using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepSalesReport
{
    public partial class RepHourlyTopSellingSalesReportForm : Form
    {
        public List<Entities.DGVRepHourlyTopSellingSalesReportEntities> topHourlySalesSummaryList;
        public BindingSource dataTopSalesSummaryListSource = new BindingSource();
        public PagedList<Entities.DGVRepHourlyTopSellingSalesReportEntities> pageList;

        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateStart;
        public DateTime dateEnd;

        public RepHourlyTopSellingSalesReportForm(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            dateStart = startDate;
            dateEnd = endDate;
            GetSalesDetailListDataSource();
            GetSalesDetailListDataGridSource();
        }
        public String get12HourFormat(Int32 hour)
        {
            String returnText = hour + " AM";

            if (hour > 12)
            {
                switch (hour)
                {
                    case 13:
                        {
                            returnText = "1 PM";
                            break;
                        }
                    case 14:
                        {
                            returnText = "2 PM";
                            break;
                        }
                    case 15:
                        {
                            returnText = "3 PM";
                            break;
                        }
                    case 16:
                        {
                            returnText = "4 PM";
                            break;
                        }
                    case 17:
                        {
                            returnText = "5 PM";
                            break;
                        }
                    case 18:
                        {
                            returnText = "6 PM";
                            break;
                        }
                    case 19:
                        {
                            returnText = "7 PM";
                            break;
                        }
                    case 20:
                        {
                            returnText = "8 PM";
                            break;
                        }
                    case 21:
                        {
                            returnText = "9 PM";
                            break;
                        }
                    case 22:
                        {
                            returnText = "10 PM";
                            break;
                        }
                    case 23:
                        {
                            returnText = "11 PM";
                            break;
                        }
                    case 24:
                        {
                            returnText = "12 PM";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }

            return returnText;
        }
        public List<Entities.DGVRepHourlyTopSellingSalesReportEntities> GetHourlyTopSalesDetailListData(DateTime startDate, DateTime endDate)
        {
            List<Entities.DGVRepHourlyTopSellingSalesReportEntities> rowList = new List<Entities.DGVRepHourlyTopSellingSalesReportEntities>();

            Controllers.RepSalesReportController repTopSellingSalesReportController = new Controllers.RepSalesReportController();

            var salesDetailList = repTopSellingSalesReportController.GetTopHourlySalesSummaryReport(startDate, endDate);

            if (salesDetailList.Any())
            {
                Decimal totalAmount = 0;
                Int32 number = 0;

                List<Entities.DGVRepHourlyTopSellingSalesReportEntities> newTopSellingItemsReportList = new List<Entities.DGVRepHourlyTopSellingSalesReportEntities>();
                foreach (var topSellingItemsReport in salesDetailList)
                {
                    number += 1;

                    newTopSellingItemsReportList.Add(new Entities.DGVRepHourlyTopSellingSalesReportEntities()
                    {
                        ColumnHour = get12HourFormat(topSellingItemsReport.Hour).ToString(),
                        ColumnNo = number.ToString(),
                        ColumnCategory = topSellingItemsReport.ItemCategory,
                        ColumnItemDescription = topSellingItemsReport.ItemDescription,
                        ColumnUnit = topSellingItemsReport.Unit,
                        ColumnPrice = topSellingItemsReport.Price.ToString("#,##0.00"),
                        ColumnQuantity = topSellingItemsReport.Quantity.ToString("#,##0.00"),
                        ColumnAmount = topSellingItemsReport.Amount.ToString("#,##0.00")
                    });
                }
                rowList = newTopSellingItemsReportList.ToList();
            }

            return rowList;
        }
        public void GetSalesDetailListDataSource()
        {
            topHourlySalesSummaryList = GetHourlyTopSalesDetailListData(dateStart, dateEnd);
            if (topHourlySalesSummaryList.Any())
            {
                pageList = new PagedList<Entities.DGVRepHourlyTopSellingSalesReportEntities>(topHourlySalesSummaryList, pageNumber, pageSize);

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
                dataTopSalesSummaryListSource.DataSource = pageList;
            }
            else
            {
                buttonPageListFirst.Enabled = false;
                buttonPageListPrevious.Enabled = false;
                buttonPageListNext.Enabled = false;
                buttonPageListLast.Enabled = false;

                dataTopSalesSummaryListSource.Clear();
                textBoxPageNumber.Text = "0 / 0";
            }
        }
        public void GetSalesDetailListDataGridSource()
        {
            dataGridViewHourlyTopSellingSalesReport.DataSource = dataTopSalesSummaryListSource;
        }

        private void buttonSalesListPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DGVRepHourlyTopSellingSalesReportEntities>(topHourlySalesSummaryList, 1, pageSize);
            dataTopSalesSummaryListSource.DataSource = pageList;

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
                pageList = new PagedList<Entities.DGVRepHourlyTopSellingSalesReportEntities>(topHourlySalesSummaryList, --pageNumber, pageSize);
                dataTopSalesSummaryListSource.DataSource = pageList;
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
                pageList = new PagedList<Entities.DGVRepHourlyTopSellingSalesReportEntities>(topHourlySalesSummaryList, ++pageNumber, pageSize);
                dataTopSalesSummaryListSource.DataSource = pageList;
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
            pageList = new PagedList<Entities.DGVRepHourlyTopSellingSalesReportEntities>(topHourlySalesSummaryList, pageList.PageCount, pageSize);
            dataTopSalesSummaryListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = true;
            buttonPageListPrevious.Enabled = true;
            buttonPageListNext.Enabled = false;
            buttonPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
