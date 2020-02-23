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
    public partial class TrnSalesListCancelRemarksForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public TrnSalesListForm trnSalesListForm;
        public TrnPOSTouchForm trnPOSTouchForm;

        public Int32 salesId;

        public TrnSalesListCancelRemarksForm(SysSoftwareForm softwareForm, TrnSalesListForm salesListForm, TrnPOSTouchForm POSTouchForm, Int32 currentSalesId)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnSalesListForm = salesListForm;
            trnPOSTouchForm = POSTouchForm;

            salesId = currentSalesId;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (trnSalesListForm != null)
            {
                trnSalesListForm.SetContinueCancel(false);
            }

            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            String remarks = textBoxCancelRemarks.Text;

            if (trnSalesListForm != null)
            {
                trnSalesListForm.SetCancelRemarks(remarks);
                trnSalesListForm.SetContinueCancel(true);
            }

            if (trnPOSTouchForm != null)
            {
                DialogResult cancelDialogResult = MessageBox.Show("Cancel Transaction? ", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cancelDialogResult == DialogResult.Yes)
                {
                    Controllers.TrnSalesController trnPOSSalesController = new Controllers.TrnSalesController();

                    if (trnPOSSalesController.CanCancelCollection(salesId))
                    {
                        String[] cancelSales = trnPOSSalesController.CancelSales(salesId, textBoxCancelRemarks.Text);
                        if (cancelSales[1].Equals("0") == false)
                        {
                            MessageBox.Show("Cancel Successful.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            trnPOSTouchForm.UpdateSalesListGridDataSource();
                            trnPOSTouchForm.ClosePOSTouchActivity();
                        }
                        else
                        {
                            MessageBox.Show(cancelSales[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not allowed.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Close();
        }
    }
}
