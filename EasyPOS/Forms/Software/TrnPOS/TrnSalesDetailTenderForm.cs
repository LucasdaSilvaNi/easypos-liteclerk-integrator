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
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonTender_Click(object sender, EventArgs e)
        {
            DialogResult tenderPrinterReadyDialogResult = MessageBox.Show("Is printer ready?", "Tender", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tenderPrinterReadyDialogResult == DialogResult.Yes)
            {

            }
        }
    }
}
