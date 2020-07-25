using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnDisbursement
{
    public partial class TrnRefundForm : Form
    {
        public TrnDisbursementListForm trnDisbursementListForm;
        public Int32 salesId = 0;

        public TrnRefundForm(TrnDisbursementListForm disbursementListForm)
        {
            InitializeComponent();
            trnDisbursementListForm = disbursementListForm;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Refund();
        }

        public void Refund()
        {
            DialogResult deleteDialogResult = MessageBox.Show("Refund sales?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteDialogResult == DialogResult.Yes)
            {
                Entities.TrnDisbursementEntity newDisbursement = new Entities.TrnDisbursementEntity()
                {
                    RefundSalesId = salesId,
                    Amount = Convert.ToDecimal(textBoxAmount.Text)
                };

                Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
                String[] refundSales = trnDisbursementController.Refund(newDisbursement);
                if (refundSales[1].Equals("0") == false)
                {
                    MessageBox.Show("Refund successful.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    trnDisbursementListForm.UpdateDisbursementListDataSource();
                    Close();
                }
                else
                {
                    MessageBox.Show(refundSales[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void GetSalesDetail()
        {
            Controllers.TrnDisbursementController trnDisbursementController = new Controllers.TrnDisbursementController();
            if (trnDisbursementController.GetSalesDetail(textBoxOrderReturnNumber.Text) != null)
            {
                var currentDisbursement = trnDisbursementController.GetSalesDetail(textBoxOrderReturnNumber.Text);

                salesId = currentDisbursement.Id;
                textBoxCustomer.Text = currentDisbursement.Customer;
                textBoxAmount.Text = currentDisbursement.Amount.ToString("#,##0.00");
            }
            else
            {
                salesId = 0;
                textBoxCustomer.Text = "";
                textBoxAmount.Text = "0.00";
            }
        }

        private void textBoxOrderReturnNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetSalesDetail();
            }
        }
    }
}
