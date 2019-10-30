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
    public partial class RepSalesReportCollectionDetailReportForm : Form
    {
        public List<Entities.DgvCollectionDetailReportEntity> collectionDetailList;
        public BindingSource dataCollectionDetailListSource = new BindingSource();
        public PagedList<Entities.DgvCollectionDetailReportEntity> pageList;
        public Int32 pageNumber = 1;
        public Int32 pageSize = 50;

        public DateTime dateStart;
        public DateTime dateEnd;
        public Int32 idTerminal;

        public RepSalesReportCollectionDetailReportForm(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            InitializeComponent();

            dateStart = startDate;
            dateEnd = endDate;
            idTerminal = terminalId;

            GetCollectionDetailListDataSource();
            GetDataGridViewCollectionDetailReportSource();
        }

        public List<Entities.DgvCollectionDetailReportEntity> GetCollectionDetailListData(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            List<Entities.DgvCollectionDetailReportEntity> rowList = new List<Entities.DgvCollectionDetailReportEntity>();

            Controllers.RepSalesReportController repSalesReportController = new Controllers.RepSalesReportController();

            var collectionDetailList = repSalesReportController.CollectionDetailList(startDate, endDate, terminalId);
            if (collectionDetailList.Any())
            {
                Decimal totalAmount = 0;
                var row = from d in collectionDetailList
                          select new Entities.DgvCollectionDetailReportEntity
                          {
                              ColumnCollectionDate = d.CollectionDate,
                              ColumnCollectionNumber = d.CollectionNumber,
                              ColumnTerminal = d.Terminal,
                              ColumnManualORNumber = d.ManualORNumber,
                              ColumnCustomer = d.Customer,
                              ColumnSalesNumber = d.SalesNumber,
                              ColumnAmount = d.Amount.ToString("#,##0.00"),
                              ColumnPayType = d.PayType,
                              ColumnCheckNumber = d.CheckNumber,
                              ColumnCheckDate = d.CheckDate,
                              ColumnCheckBank = d.CheckBank,
                              ColumnCreditCardVerificationCode = d.CreditCardVerificationCode,
                              ColumnCreditCardNumber = d.CreditCardNumber,
                              ColumnCreditCardType = d.CreditCardType,
                              ColumnCreditCardBank = d.CreditCardBank,
                              ColumnCreditCardReferenceNumber = d.CreditCardReferenceNumber,
                              ColumnCreditCardHolderName = d.CreditCardHolderName,
                              ColumnCreditCardExpiry = d.CreditCardExpiry,
                              ColumnGiftCertificateNumber = d.GiftCertificateNumber,
                              ColumnOtherInformation = d.OtherInformation
                          };

                totalAmount = collectionDetailList.Sum(d => d.Amount);

                textBoxTotalAmount.Text = totalAmount.ToString("#,##0.00");

                rowList = row.ToList();
            }
            return rowList;
        }

        public void GetCollectionDetailListDataSource()
        {
            collectionDetailList = GetCollectionDetailListData(dateStart, dateEnd, idTerminal);
            if (collectionDetailList.Any())
            {

                pageList = new PagedList<Entities.DgvCollectionDetailReportEntity>(collectionDetailList, pageNumber, pageSize);

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
                dataCollectionDetailListSource.DataSource = pageList;
            }
            else
            {
                buttonPageListFirst.Enabled = false;
                buttonPageListPrevious.Enabled = false;
                buttonPageListNext.Enabled = false;
                buttonPageListLast.Enabled = false;

                dataCollectionDetailListSource.Clear();
                textBoxPageNumber.Text = "0 / 0";
            }
        }

        public void GetDataGridViewCollectionDetailReportSource()
        {
            dataGridViewCollectionDetailReport.DataSource = dataCollectionDetailListSource;
        }


        private void buttonCollectionListPageListFirst_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvCollectionDetailReportEntity>(collectionDetailList, 1, pageSize);
            dataCollectionDetailListSource.DataSource = pageList;

            buttonPageListFirst.Enabled = false;
            buttonPageListPrevious.Enabled = false;
            buttonPageListNext.Enabled = true;
            buttonPageListLast.Enabled = true;

            pageNumber = 1;
            textBoxPageNumber.Text = pageNumber + " / " + pageList.PageCount;
        }

        private void buttonCollectionListPageListPrevious_Click(object sender, EventArgs e)
        {
            if (pageList.HasPreviousPage == true)
            {
                pageList = new PagedList<Entities.DgvCollectionDetailReportEntity>(collectionDetailList, --pageNumber, pageSize);
                dataCollectionDetailListSource.DataSource = pageList;
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

        private void buttonCollectionListPageListNext_Click(object sender, EventArgs e)
        {
            if (pageList.HasNextPage == true)
            {
                pageList = new PagedList<Entities.DgvCollectionDetailReportEntity>(collectionDetailList, ++pageNumber, pageSize);
                dataCollectionDetailListSource.DataSource = pageList;
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

        private void buttonCollectionListPageListLast_Click(object sender, EventArgs e)
        {
            pageList = new PagedList<Entities.DgvCollectionDetailReportEntity>(collectionDetailList, pageList.PageCount, pageSize);
            dataCollectionDetailListSource.DataSource = pageList;

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
                    String[] header = { "Collection Date", "Collection Number", "Terminal", "Manual OR Number", "Customer",
                        "Sales Number", "Amount", "PayType", "CheckNumber", "CheckDate", "CheckBank", "CreditCardVerificationCode",
                        "CreditCardNumber", "CreditCardType", "CreditCardBank", "CreditCardReferenceNumber", "CreditCardHolderName",
                        "CreditCardExpiry", "GiftCertificateNumber", "OtherInformation"
                    };
                    csv.AppendLine(String.Join(",", header));

                    if (collectionDetailList.Any())
                    {
                        foreach (var collectionDetail in collectionDetailList)
                        {
                            String[] data = {collectionDetail.ColumnCollectionDate,
                                        collectionDetail.ColumnCollectionNumber,
                                        collectionDetail.ColumnTerminal,
                                        collectionDetail.ColumnManualORNumber,
                                        collectionDetail.ColumnCustomer.Replace("," , " "),
                                        collectionDetail.ColumnSalesNumber,
                                        collectionDetail.ColumnAmount.Replace("," , " "),
                                        collectionDetail.ColumnPayType,
                                        collectionDetail.ColumnCheckNumber,
                                        collectionDetail.ColumnCheckDate,
                                        collectionDetail.ColumnCheckBank,
                                        collectionDetail.ColumnCreditCardVerificationCode,
                                        collectionDetail.ColumnCreditCardNumber,
                                        collectionDetail.ColumnCreditCardType,
                                        collectionDetail.ColumnCreditCardBank,
                                        collectionDetail.ColumnCreditCardReferenceNumber,
                                        collectionDetail.ColumnCreditCardHolderName,
                                        collectionDetail.ColumnCreditCardExpiry,
                                        collectionDetail.ColumnGiftCertificateNumber,
                                        collectionDetail.ColumnOtherInformation,
                            };

                            csv.AppendLine(String.Join(",", data));
                        }
                    }

                    String executingUser = WindowsIdentity.GetCurrent().Name;

                    DirectorySecurity securityRules = new DirectorySecurity();
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                    securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                    DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogGenerateCSV.SelectedPath, securityRules);
                    File.WriteAllText(createDirectorySTCSV.FullName + "\\CollectionDetailReport_" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                    MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
