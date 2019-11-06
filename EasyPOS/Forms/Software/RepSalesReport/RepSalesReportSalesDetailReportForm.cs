using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepSalesReport
{
    public partial class RepSalesReportSalesDetailReportForm : Form
    {
        public List<Entities.DgvSalesReportSalesDetailReportEntity> salesDetailList;
        public BindingSource dataSalesDatailListSource = new BindingSource();
        public PagedList<Entities.DgvSalesReportSalesDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;


        public DateTime dateStart;
        public DateTime dateEnd;

        public RepSalesReportSalesDetailReportForm(DateTime startDate, DateTime endDate)
        {
            InitializeComponent();

            dateStart = startDate;
            dateEnd = endDate;

            GetSalesDetailListDataSource();
            GetSalesDetailListDataGridSource();
        }

        public List<Entities.DgvSalesReportSalesDetailReportEntity> GetSalesDetailListData(DateTime startDate, DateTime endDate)
        {
            List<Entities.DgvSalesReportSalesDetailReportEntity> rowList = new List<Entities.DgvSalesReportSalesDetailReportEntity>();

            Controllers.RepSalesReportController repSalesDetailReportController = new Controllers.RepSalesReportController();

            var salesDetailList = repSalesDetailReportController.SalesDetailList(startDate, endDate);
            if (salesDetailList.OrderByDescending(d => d.Id).Any())
            {
                Decimal totalAmount = 0;

                var row = from d in salesDetailList
                          select new Entities.DgvSalesReportSalesDetailReportEntity
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

        public void GetSalesDetailListDataSource()
        {
            salesDetailList = GetSalesDetailListData(dateStart, dateEnd);
            if (salesDetailList.Any())
            {

                pageList = new PagedList<Entities.DgvSalesReportSalesDetailReportEntity>(salesDetailList, pageNumber, pageSize);

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
            pageList = new PagedList<Entities.DgvSalesReportSalesDetailReportEntity>(salesDetailList, 1, pageSize);
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
                pageList = new PagedList<Entities.DgvSalesReportSalesDetailReportEntity>(salesDetailList, --pageNumber, pageSize);
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
                pageList = new PagedList<Entities.DgvSalesReportSalesDetailReportEntity>(salesDetailList, ++pageNumber, pageSize);
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
            pageList = new PagedList<Entities.DgvSalesReportSalesDetailReportEntity>(salesDetailList, pageList.PageCount, pageSize);
            dataSalesDatailListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = true;
            buttonPageListPrevious.Enabled = true;
            buttonPageListNext.Enabled = false;
            buttonPageListLast.Enabled = false;

            pageNumber = pageList.PageCount;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonGenerateCSV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = folderBrowserDialogGenerateCSV.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    DateTime startDate = dateStart;
                    DateTime endDate = dateEnd;

                    StringBuilder csv = new StringBuilder();
                    String[] header = { "Terminal", "Date", "Sales Number", "Manual Invoice No.", "Item Description", "Item Code", "Item Category", "Unit","Price", "Discount", "Discount Rate", "Discount Amount", "Net Price", "Quantity", "Amount", "Tax", "Tax Amount", "User", "Time Stamp" };
                    csv.AppendLine(String.Join(",", header));

                    if (salesDetailList.Any())
                    {
                        foreach (var salesDetail in salesDetailList)
                        {
                            String[] data = {salesDetail.ColumnTerminal,
                                            salesDetail.ColumnDate,
                                            salesDetail.ColumnSalesNumber,
                                            salesDetail.ColumnCustomer.Replace("," , " "),
                                            salesDetail.ColumnItemDescription.Replace("," , " "),
                                            salesDetail.ColumnItemCode,
                                            salesDetail.ColumnItemCategory.Replace("," , " "),
                                            salesDetail.ColumnUnit,
                                            salesDetail.ColumnPrice,
                                            salesDetail.ColumnDiscount,
                                            salesDetail.ColumnDiscountRate,
                                            salesDetail.ColumnDiscountAmount.Replace("," , ""),
                                            salesDetail.ColumnNetPrice.Replace("," , ""),
                                            salesDetail.ColumnQuantity.Replace("," , ""),
                                            salesDetail.ColumnAmount.Replace("," , ""),
                                            salesDetail.ColumnTax,
                                            salesDetail.ColumnTaxRate.Replace("," , ""),
                                            salesDetail.ColumnTaxAmount.Replace("," , ""),
                                            salesDetail.ColumnUser,
                                            salesDetail.ColumnTimeStamp
                            };
                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\SalesDetailReport_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                    MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
