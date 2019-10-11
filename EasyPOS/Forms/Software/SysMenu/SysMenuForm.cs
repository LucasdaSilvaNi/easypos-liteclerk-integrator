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

        TabPage tabPageItemList = new TabPage { Name = "tabPageItemList", Text = "Item List" };
        TabPage tabPageSalesList = new TabPage { Name = "tabPageSalesList", Text = "Sales List" };

        private void buttonItem_Click(object sender, EventArgs e)
        {
            MstItem.MstItemListForm mstItemListForm = new MstItem.MstItemListForm(softwareForm)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageItemList.Controls.Add(mstItemListForm);
            softwareForm.AddTabPage(tabPageItemList);
        }

        private void buttonPOS_Click(object sender, EventArgs e)
        {
            TrnPOS.TrnSalesListForm trnSalesListForm = new TrnPOS.TrnSalesListForm(softwareForm)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSalesList.Controls.Add(trnSalesListForm);
            softwareForm.AddTabPage(tabPageSalesList);
        }
    }
}
