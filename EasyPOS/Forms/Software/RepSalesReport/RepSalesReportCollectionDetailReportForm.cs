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
    }
}
