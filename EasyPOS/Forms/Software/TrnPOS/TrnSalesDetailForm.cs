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
        SoftwareForm softwareForm;
        public TrnSalesDetailForm(SoftwareForm form)
        {
            InitializeComponent();
            softwareForm = form;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            softwareForm.RemoveTabPage();
        }

        private void buttonTender_Click(object sender, EventArgs e)
        {
            TrnSalesDetailTenderForm trnSalesDetailTenderForm = new TrnSalesDetailTenderForm();
            trnSalesDetailTenderForm.ShowDialog();
        }

        private void buttonSearchItem_Click(object sender, EventArgs e)
        {
            TrnSalesDetailSearchItemForm trnSalesDetailSearchItemForm = new TrnSalesDetailSearchItemForm();
            trnSalesDetailSearchItemForm.ShowDialog();
        }
    }
}
