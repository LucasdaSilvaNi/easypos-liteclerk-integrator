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
    public partial class RepSalesReturnDetailReportForm : Form
    {
        public List<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity> salesDetailList;
        public BindingSource dataSalesDatailListSource = new BindingSource();
        public PagedList<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateStart;
        public DateTime dateEnd;
        public Int32 filterTerminalId;

        public RepSalesReturnDetailReportForm(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            InitializeComponent();

            dateStart = startDate;
            dateEnd = endDate;
            filterTerminalId = terminalId;

            GetSalesReturnDetailListDataSource();
            GetSalesReturnDetailListDataGridSource();
        }

        public List<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity> GetSalesReturnDetailListData(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            List<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity> rowList = new List<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity>();

            Controllers.RepSalesReportController repSalesReturnDetailReportController = new Controllers.RepSalesReportController();

            var salesDetailList = repSalesReturnDetailReportController.SalesReturnDetailReport(startDate, endDate, terminalId);
            if (salesDetailList.OrderByDescending(d => d.Id).Any())
            {
                Decimal totalAmount = 0;

                var row = from d in salesDetailList
                          select new Entities.DgvRepSalesReportSalesReturnDetailReportListEntity
                          {
                              ColumnTerminal = d.Terminal,
                              ColumnDate = d.Date,
                              ColumnSalesNumber = d.SalesReturnNumber,
                              ColumnCustomerCode = d.CustomerCode,
                              ColumnCustomer = d.Customer,
                              ColumnItemCode = d.ItemCode,
                              ColumnItemDescription = d.ItemDescription,
                              ColumnItemCategory = d.ItemCategory,
                              ColumnUnit = d.Unit,
                              ColumnPrice = d.Price.ToString("#,##0.00"),
                              ColumnDiscountAmount = d.DiscountAmount.ToString("#,##0.00"),
                              ColumnNetPrice = d.NetPrice.ToString("#,##0.00"),
                              ColumnQuantity = d.Quantity.ToString("#,##0.00"),
                              ColumnAmount = d.Amount.ToString("#,##0.00"),
                              ColumnTax = d.Tax,
                              ColumnTaxRate = d.TaxRate.ToString("#,##0.00"),
                              ColumnTaxAmount = d.TaxAmount.ToString("#,##0.00")
                          };

                totalAmount = salesDetailList.Sum(d => d.Amount);

                textBoxTotalAmount.Text = totalAmount.ToString("#,##0.00");

                rowList = row.ToList();

            }
            return rowList;
        }

        public void GetSalesReturnDetailListDataSource()
        {
            salesDetailList = GetSalesReturnDetailListData(dateStart, dateEnd, filterTerminalId);
            if (salesDetailList.Any())
            {

                pageList = new PagedList<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity>(salesDetailList, pageNumber, pageSize);

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

        public void GetSalesReturnDetailListDataGridSource()
        {
            dataGridViewSalesReturnDetailReport.DataSource = dataSalesDatailListSource;
        }

        private void buttonSalesListPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity>(salesDetailList, 1, pageSize);
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
                pageList = new PagedList<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity>(salesDetailList, --pageNumber, pageSize);
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
                pageList = new PagedList<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity>(salesDetailList, ++pageNumber, pageSize);
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
            pageList = new PagedList<Entities.DgvRepSalesReportSalesReturnDetailReportListEntity>(salesDetailList, pageList.PageCount, pageSize);
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
                    String[] header = { "Terminal", "Date", "Sales Return Number", "Customer Code", "Customer", "Item Code", "Item Description", "Item Category", "Unit", "Price", "Discount", "Net Price", "Quantity", "Amount", "Tax", "Tax Rate", "Tax Amount" };
                    csv.AppendLine(String.Join(",", header));

                    if (salesDetailList.Any())
                    {
                        foreach (var salesDetail in salesDetailList)
                        {
                            String customerCode = "";
                            if (salesDetail.ColumnCustomerCode != null)
                            {
                                customerCode = salesDetail.ColumnCustomerCode.Replace(",", "");
                            }

                            String[] data = {
                                salesDetail.ColumnTerminal,
                                salesDetail.ColumnDate,
                                salesDetail.ColumnSalesNumber,
                                customerCode,
                                salesDetail.ColumnCustomer.Replace("," , ""),
                                salesDetail.ColumnItemCode.Replace("," , ""),
                                salesDetail.ColumnItemDescription.Replace("," , ""),
                                salesDetail.ColumnItemCategory.Replace("," , ""),
                                salesDetail.ColumnUnit.Replace("," , ""),
                                salesDetail.ColumnPrice.Replace("," , ""),
                                salesDetail.ColumnDiscountAmount.Replace("," , ""),
                                salesDetail.ColumnNetPrice.Replace("," , ""),
                                salesDetail.ColumnQuantity.Replace("," , ""),
                                salesDetail.ColumnAmount.Replace("," , ""),
                                salesDetail.ColumnTax.Replace("," , ""),
                                salesDetail.ColumnTaxRate.Replace("," , ""),
                                salesDetail.ColumnTaxAmount.Replace("," , "")
                            };
                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\SalesReturnDetailReport_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

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
