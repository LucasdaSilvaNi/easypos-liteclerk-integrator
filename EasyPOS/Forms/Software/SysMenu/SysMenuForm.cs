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
        SoftwareForm softwareForm;
        public SysMenuForm(SoftwareForm form)
        {
            InitializeComponent();
            softwareForm = form;
        }

        private void buttonItem_Click(object sender, EventArgs e)
        {
            softwareForm.AddTabPageItemList();
        }

        private void buttonPOS_Click(object sender, EventArgs e)
        {
            softwareForm.AddTabPagePOSSalesList();
        }

        private void buttonDiscounting_Click(object sender, EventArgs e)
        {
            softwareForm.AddTabPageDiscountingList();
        }

        private void buttonPOSReport_Click(object sender, EventArgs e)
        {
            softwareForm.AddTabPagePOSReport();
        }
    }
}
