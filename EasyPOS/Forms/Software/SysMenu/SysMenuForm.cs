using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysMenu
{
    public partial class SysMenuForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public SysMenuForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;
        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageItemList();
        }

        private void buttonPOS_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPagePOSSalesList();
        }

        private void buttonDiscounting_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageDiscountingList();
        }

        private void buttonPOSReport_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPagePOSReport();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageUserList();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageSettings();
        }

        private void buttonSalesReport_OnClick(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageSalesReport();
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageCustomerList();
        }

        private void buttonStockIn_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageStockInList();
        }

        private void buttonStockOut_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageStockOutList();
        }

        private void buttonDisbursement_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.AddTabPageDisbursementList();
        }
    }
}
