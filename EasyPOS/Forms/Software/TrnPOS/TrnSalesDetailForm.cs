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
    public partial class TrnSalesDetailForm : Form
    {
        SysSoftwareForm sysSoftwareForm;
        TrnSalesListForm trnSalesListForm;

        public TrnSalesDetailForm(SysSoftwareForm softwareForm, TrnSalesListForm salesListForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnSalesListForm = salesListForm;

            GetSalesDetail();
        }

        public Entities.TrnSalesEntity trnSalesEntity;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();

            trnSalesListForm.GetSalesList();
            sysSoftwareForm.RemoveTabPage();
        }

        public void GetSalesDetail()
        {
            trnSalesEntity = trnSalesListForm.trnSalesEntity;

            textBoxTotalSalesAmount.Text = trnSalesEntity.Amount.ToString("#,##0.00");
            labelInvoiceNumber.Text = trnSalesEntity.SalesNumber;
            labelInvoiceDate.Text = trnSalesEntity.SalesDate;
            labelCustomer.Text = trnSalesEntity.Customer;
        }

        private void buttonTender_Click(object sender, EventArgs e)
        {
            TrnSalesDetailTenderForm trnSalesDetailTenderForm = new TrnSalesDetailTenderForm();
            trnSalesDetailTenderForm.ShowDialog();
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnSalesDetailSearchItemForm trnSalesDetailSearchItemForm = new TrnSalesDetailSearchItemForm(this);
            trnSalesDetailSearchItemForm.ShowDialog();
        }
    }
}
