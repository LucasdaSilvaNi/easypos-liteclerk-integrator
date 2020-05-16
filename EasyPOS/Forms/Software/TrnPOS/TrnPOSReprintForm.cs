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
    public partial class TrnPOSReprintForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public Int32 trnSalesId = 0;
        public Int32 trnCollectionId = 0;

        public TrnPOSReprintForm(SysSoftwareForm softwareForm, Int32 salesId, Int32 collectionId)
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
                DialogResult printDialogResult = printDialogReprint.ShowDialog();
                if (printDialogResult == DialogResult.OK)
                {
                    new TrnPOSOfficialReceiptReportForm(trnSalesId, trnCollectionId, true, printDialogReprint.PrinterSettings.PrinterName);
                    Close();
                }
            }
        }

        private void buttonDeliveryReceipt_Click(object sender, EventArgs e)
        {
            DialogResult cancelDialogResult = MessageBox.Show("Reprint Sales?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cancelDialogResult == DialogResult.Yes)
            {
                new TrnPOSDeliveryReceiptReportForm("", StockWithdrawalReport(trnCollectionId), true, false);
                MessageBox.Show("Generate PDF Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonWithdrawalSlip_Click(object sender, EventArgs e)
        {
            DialogResult cancelDialogResult = MessageBox.Show("Reprint Sales?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cancelDialogResult == DialogResult.Yes)
            {
                new TrnPOSDeliveryReceiptReportForm("", StockWithdrawalReport(trnCollectionId), false, false);
                MessageBox.Show("Generate PDF Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ===============================================
        // Stock Withdrawal Report (Copied) To be modified
        // ===============================================
        public List<Entities.RepSalesReportCollectionSummaryReportEntity> StockWithdrawalReport(Int32 id)
        {
            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            var stockWithdrawalReports = from d in db.TrnCollections
                                         where d.Id == id
                                         select new Entities.RepSalesReportCollectionSummaryReportEntity
                                         {
                                             Id = d.Id,
                                             SalesId = d.SalesId,
                                             CollectionNumber = d.CollectionNumber
                                         };

            return stockWithdrawalReports.ToList();
        }
    }
}
