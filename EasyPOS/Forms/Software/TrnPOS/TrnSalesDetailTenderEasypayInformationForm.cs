using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnSalesDetailTenderEasypayInformationForm : Form
    {
        public TrnSalesDetailTenderForm trnSalesDetailTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public TrnSalesDetailTenderEasypayInformationForm(TrnSalesDetailTenderForm salesDetailTenderForm, DataGridView dataGridViewTenderPayType, Decimal totalSalesAmount)
        {
            InitializeComponent();

            trnSalesDetailTenderForm = salesDetailTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;

            textBoxTotalSalesAmount.Text = totalSalesAmount.ToString("#,##0.00");

            textBoxBeginningBalance.Text = Convert.ToDecimal(0).ToString("#,##0.00");
            textBoxAmountCharge.Text = totalSalesAmount.ToString("#,##0.00");
            textBoxEndingBalance.Text = Convert.ToDecimal(totalSalesAmount * -1).ToString("#,##0.00");

            CheckConnection();
        }

        public void CheckConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://localhost:2650"))
                    {
                        labelConnectionStatus.Text = "Connected";
                        labelConnectionStatus.ForeColor = Color.Lime;

                        buttonPay.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                labelConnectionStatus.Text = "Not Connected";
                labelConnectionStatus.ForeColor = Color.OrangeRed;

                buttonPay.Enabled = false;

                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            Pay();
        }

        public void Pay()
        {
            try
            {
                Decimal endingBalance = Convert.ToDecimal(textBoxEndingBalance.Text);
                if (endingBalance >= 0)
                {
                    if (mstDataGridViewTenderPayType.Rows.Contains(mstDataGridViewTenderPayType.CurrentRow))
                    {
                        Int32 id = Convert.ToInt32(mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value);
                        String payType = mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value.ToString();
                        Decimal amount = Convert.ToDecimal(textBoxAmountCharge.Text);
                        String otherInformation = "";

                        mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value = id;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value = payType;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value = amount;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[3].Value = otherInformation;
                    }

                    mstDataGridViewTenderPayType.Refresh();
                    Close();

                    mstDataGridViewTenderPayType.Focus();
                    mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;

                    trnSalesDetailTenderForm.TenderSales();
                }
                else
                {
                    MessageBox.Show("Cannot pay if balance is zero.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxTappedCardAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Pay();
            }
        }
    }
}
