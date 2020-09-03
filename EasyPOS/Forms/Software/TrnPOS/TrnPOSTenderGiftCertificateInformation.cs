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
    public partial class TrnPOSTenderGiftCertificateInformation : Form
    {
        public TrnPOSTenderForm trnPOSTenderForm;
        public DataGridView mstDataGridViewTenderPayType;

        public TrnPOSTenderGiftCertificateInformation(TrnPOSTenderForm POSTenderForm, DataGridView dataGridViewTenderPayType, Decimal totalSalesAmount)
        {
            InitializeComponent();

            trnPOSTenderForm = POSTenderForm;
            mstDataGridViewTenderPayType = dataGridViewTenderPayType;

            textBoxAmount.Text = totalSalesAmount.ToString("#,##0.00");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            GiftCertificatePay();
        }

        public void GiftCertificatePay()
        {
            try
            {
                Decimal currentAmount = Convert.ToDecimal(textBoxAmount.Text);
                if (currentAmount >= 0)
                {
                    if (mstDataGridViewTenderPayType.Rows.Contains(mstDataGridViewTenderPayType.CurrentRow))
                    {
                        Int32 id = Convert.ToInt32(mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value);
                        String payTypeCode = mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value.ToString();
                        String payType = mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value.ToString();
                        Decimal amount = Convert.ToDecimal(textBoxAmount.Text);
                        String otherInformation = "Gift Certificate Payment " + DateTime.Now.ToLongDateString();
                        String giftCertificateNumber = textBoxGiftCertificateNumber.Text;

                        mstDataGridViewTenderPayType.CurrentRow.Cells[0].Value = id;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[1].Value = payTypeCode;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[2].Value = payType;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[4].Value = amount.ToString("#,##0.00");
                        mstDataGridViewTenderPayType.CurrentRow.Cells[5].Value = otherInformation;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[6].Value = null;
                        mstDataGridViewTenderPayType.CurrentRow.Cells[7].Value = "";
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
                        mstDataGridViewTenderPayType.CurrentRow.Cells[18].Value = giftCertificateNumber;
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

        private void textBoxAmount_Leave(object sender, EventArgs e)
        {
            textBoxAmount.Text = Convert.ToDecimal(textBoxAmount.Text).ToString("#,##0.00");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
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
