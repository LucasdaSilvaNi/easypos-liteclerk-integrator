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
    public partial class TrnSalesListReprintForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public Int32 trnSalesId = 0;
        public Int32 trnCollectionId = 0;

        public TrnSalesListReprintForm(SysSoftwareForm softwareForm, Int32 salesId, Int32 collectionId)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;

            trnSalesId = salesId;
            trnCollectionId = collectionId;
        }

        private void buttonOfficialReceipt_Click(object sender, EventArgs e)
        {
            DialogResult cancelDialogResult = MessageBox.Show("Reprint Sales?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cancelDialogResult == DialogResult.Yes)
            {
                new Reports.RepOfficialReceiptReportForm(trnSalesId, trnCollectionId, true);
                Close();
            }
        }

        private void buttonDeliveryReceipt_Click(object sender, EventArgs e)
        {
            DialogResult cancelDialogResult = MessageBox.Show("Reprint Sales?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cancelDialogResult == DialogResult.Yes)
            {
                new Reports.RepDeliveryReceiptReportForm(trnSalesId, trnCollectionId, false, "", "", false);
                Close();
            }
        }

        private void buttonWithdrawalSlip_Click(object sender, EventArgs e)
        {
            DialogResult cancelDialogResult = MessageBox.Show("Reprint Sales?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cancelDialogResult == DialogResult.Yes)
            {
                new Reports.RepDeliveryReceiptReportForm(trnSalesId, trnCollectionId, false, "", "", false);
                Close();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
