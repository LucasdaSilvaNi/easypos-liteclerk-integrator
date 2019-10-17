using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnSalesDetailTenderForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnSalesDetailForm trnSalesDetailForm;
        public Entities.TrnSalesEntity trnSalesEntity;

        public TrnSalesDetailTenderForm(SysSoftwareForm softwareForm, TrnSalesDetailForm salesDetailForm, Entities.TrnSalesEntity salesEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnSalesDetailForm = salesDetailForm;
            trnSalesEntity = salesEntity;

            GetSalesDetail();
        }

        public void GetSalesDetail()
        {
            textBoxTotalSalesAmount.Text = trnSalesEntity.Amount.ToString("#,##0.00");
            labelInvoiceNumber.Text = trnSalesEntity.SalesNumber;
            labelInvoiceDate.Text = trnSalesEntity.SalesDate;
            labelCustomer.Text = trnSalesEntity.Customer;

            GetPayTypeList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonTender_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBoxTenderAmount.Text) < Convert.ToDecimal(textBoxTotalSalesAmount.Text))
            {
                MessageBox.Show("Cannot tender below sales amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult tenderPrinterReadyDialogResult = MessageBox.Show("Is printer ready?", "Tender", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (tenderPrinterReadyDialogResult == DialogResult.Yes)
                {
                    CreateCollection();
                }
            }
        }

        public void GetPayTypeList()
        {
            dataGridViewTenderPayType.Rows.Clear();
            dataGridViewTenderPayType.Refresh();

            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();

            var payTypeList = trnPOSSalesController.TenderListPayType();
            if (payTypeList.Any())
            {
                dataGridViewTenderPayType.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#742274");
                dataGridViewTenderPayType.Columns[1].DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#742274");
                dataGridViewTenderPayType.Columns[1].DefaultCellStyle.ForeColor = Color.White;

                foreach (var objPayTypeList in payTypeList)
                {
                    dataGridViewTenderPayType.Rows.Add(
                        objPayTypeList.Id,
                        objPayTypeList.PayType,
                        "0.00"
                    );
                }
            }

            ComputeAmount();
        }

        private void dataGridViewTenderPayType_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && dataGridViewTenderPayType.CurrentCell.ColumnIndex == dataGridViewTenderPayType.Columns["ColumnTenderListPayTypeAmount"].Index)
                {
                    dataGridViewTenderPayType.CurrentCell.Value = Convert.ToDecimal(dataGridViewTenderPayType.CurrentCell.Value).ToString("#,##0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewTenderPayType.CurrentCell.Value = Convert.ToDecimal(0).ToString("#,##0.00");
            }

            ComputeAmount();
        }

        public Decimal GetTotalTenderAmount()
        {
            Decimal totalTenderAmount = 0;

            if (dataGridViewTenderPayType.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewTenderPayType.Rows)
                {
                    totalTenderAmount += Convert.ToDecimal(row.Cells[2].Value);
                }
            }

            return totalTenderAmount;
        }

        public void ComputeAmount()
        {
            textBoxTenderAmount.Text = GetTotalTenderAmount().ToString("#,##0.00");

            Decimal changeAmount = GetTotalTenderAmount() - Convert.ToDecimal(textBoxTotalSalesAmount.Text);
            textBoxChangeAmount.Text = changeAmount.ToString("#,##0.00");
        }

        public void CreateCollection()
        {
            List<Entities.TrnCollectionLineEntity> listCollectionLine = new List<Entities.TrnCollectionLineEntity>();
            if (dataGridViewTenderPayType.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewTenderPayType.Rows)
                {
                    if (Convert.ToDecimal(row.Cells[2].Value) > 0)
                    {
                        listCollectionLine.Add(new Entities.TrnCollectionLineEntity()
                        {
                            Amount = Convert.ToDecimal(row.Cells[2].Value),
                            PayTypeId = Convert.ToInt32(row.Cells[0].Value),
                            CheckNumber = "NA",
                            CheckDate = null,
                            CheckBank = "NA",
                            CreditCardVerificationCode = "NA",
                            CreditCardNumber = "NA",
                            CreditCardType = "NA",
                            CreditCardBank = "NA",
                            GiftCertificateNumber = "NA",
                            OtherInformation = "NA",
                            CreditCardReferenceNumber = "NA",
                            CreditCardHolderName = "NA",
                            CreditCardExpiry = "NA"
                        });
                    }
                }
            }

            if (listCollectionLine.Any())
            {
                Entities.TrnCollectionEntity newCollection = new Entities.TrnCollectionEntity()
                {
                    TenderAmount = Convert.ToDecimal(textBoxTenderAmount.Text),
                    ChangeAmount = Convert.ToDecimal(textBoxChangeAmount.Text),
                    CollectionLines = listCollectionLine
                };

                Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
                String[] tenderSales = trnPOSSalesController.TenderSales(trnSalesEntity.Id, newCollection);
                if (tenderSales[1].Equals("0") == false)
                {
                    Close();

                    trnSalesDetailForm.Close();
                    trnSalesDetailForm.trnSalesListForm.newSales();
                }
                else
                {
                    MessageBox.Show(tenderSales[0], "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cannot tender zero amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
