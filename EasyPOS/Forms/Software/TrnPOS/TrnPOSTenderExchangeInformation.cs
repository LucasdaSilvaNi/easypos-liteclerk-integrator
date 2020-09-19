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
    public partial class TrnPOSTenderExchangeInformation : Form
    {
        public TrnPOSTenderForm trnPOSTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public Int32? salesId = null;
        public String salesNumber = "";

        public TrnPOSTenderExchangeInformation(TrnPOSTenderForm POSTenderForm, DataGridView dataGridViewTenderPayType)
        {
            InitializeComponent();

            trnPOSTenderForm = POSTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;

            textBoxOrderReturnNumber.Text = mstDataGridViewTenderPayType.CurrentRow.Cells[7].Value.ToString();
            textBoxAmount.Text = (Convert.ToDecimal(mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value) * -1).ToString("#,##0.00");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ExchangePay();
        }

        public void ExchangePay()
        {
            try
            {
                Decimal currentAmount = Convert.ToDecimal(textBoxAmount.Text) * -1;
                if (currentAmount >= 0)
                {
                    if (mstDataGridViewTenderPayType.Rows.Contains(mstDataGridViewTenderPayType.CurrentRow))
                    {
                        Int32 id = Convert.ToInt32(mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value);
                        String payTypeCode = mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value.ToString();
                        String payType = mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value.ToString();
                        Decimal amount = Convert.ToDecimal(textBoxAmount.Text) * -1;
                        String otherInformation = "Exchange Payment for Order no. " + salesNumber + " " + DateTime.Now.ToLongDateString();

                        mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value = id;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value = payTypeCode;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value = payType;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value = amount.ToString("#,##0.00");
                        mstDataGridViewTenderPayType.CurrentRow.Cells[5].Value = otherInformation;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[6].Value = salesId;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[7].Value = salesNumber;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[8].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[9].Value = null;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[10].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[11].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[12].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[13].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[14].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[15].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[16].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[17].Value = "NA";
                        mstDataGridViewTenderPayType.CurrentRow.Cells[18].Value = "NA";
                    }

                    mstDataGridViewTenderPayType.Refresh();
                    Close();

                    mstDataGridViewTenderPayType.Focus();
                    mstDataGridViewTenderPayType.CurrentRow.Cells[2].Selected = true;

                    trnPOSTenderForm.ComputeAmount();
                }
                else
                {
                    MessageBox.Show("Cannot pay if amount is zero.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetSalesDetail()
        {
            Controllers.TrnSalesController trnSalesController = new Controllers.TrnSalesController();
            if (trnSalesController.GetExchangeSalesDetail(textBoxOrderReturnNumber.Text) != null)
            {
                var currentSales = trnSalesController.GetExchangeSalesDetail(textBoxOrderReturnNumber.Text);

                salesId = currentSales.Id;
                salesNumber = currentSales.SalesNumber;
                textBoxAmount.Text = currentSales.Amount.ToString("#,##0.00");
            }
            else
            {
                salesId = null;
                salesNumber = "";
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F2:
                    {
                        if (buttonOK.Enabled == true)
                        {
                            buttonOK.PerformClick();
                            Close();
                        }

                        break;
                    }
                case Keys.Escape:
                    {
                        Close();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
