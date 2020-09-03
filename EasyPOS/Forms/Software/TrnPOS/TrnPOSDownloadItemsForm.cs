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
    public partial class TrnPOSDownloadItemsForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public TrnPOSBarcodeDetailForm trnBarcodeDetailForm;
        public TrnPOSTouchDetailForm trnPOSTouchDetailForm;

        public Int32 salesId;

        public TrnPOSDownloadItemsForm(SysSoftwareForm softwareForm, TrnPOSBarcodeDetailForm barcodeDetailForm, TrnPOSTouchDetailForm POSTouchDetailForm, Int32 currentSalesId)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnBarcodeDetailForm = barcodeDetailForm;
            trnPOSTouchDetailForm = POSTouchDetailForm;

            salesId = currentSalesId;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DownloadOrder();
        }

        public void DownloadOrder()
        {
            String salesOrderNumber = textBoxSalesOrderNumber.Text;

            DialogResult downloadItemsDialogResult = MessageBox.Show("Download Items? ", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (downloadItemsDialogResult == DialogResult.Yes)
            {
                Controllers.TrnSalesLineController trnSalesLineController = new Controllers.TrnSalesLineController();

                String[] downloadSalesLine = trnSalesLineController.DownloadItems(salesId, salesOrderNumber);
                if (downloadSalesLine[1].Equals("0") == false)
                {
                    MessageBox.Show("Download Successful.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (trnBarcodeDetailForm != null)
                    {
                        trnBarcodeDetailForm.GetSalesLineList();
                        Close();
                    }

                    if (trnPOSTouchDetailForm != null)
                    {
                        trnPOSTouchDetailForm.GetSalesLineList();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show(downloadSalesLine[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxSalesOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DownloadOrder();
            }
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
                            Focus();
                        }

                        break;
                    }
                case Keys.Escape:
                    {
                        if (buttonClose.Enabled == true)
                        {
                            buttonClose.PerformClick();
                            Focus();
                        }

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
