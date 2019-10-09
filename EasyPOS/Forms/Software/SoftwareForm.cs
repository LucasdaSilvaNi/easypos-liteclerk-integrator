using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software
{
    public partial class SoftwareForm : Form
    {
        public SoftwareForm()
        {
            InitializeComponent();
            InitializeDefaultForm();
        }

        private TabPage tabPageItem;

        public void InitializeDefaultForm()
        {
            SysMenu.SysMenuForm sysMenuForm = new SysMenu.SysMenuForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageSysMenu.Controls.Add(sysMenuForm);
        }

        public void AddTabPageItem()
        {
            if (tabPageItem != null)
            {
                tabControlSoftware.SelectTab(tabPageItem);
            }
            else
            {
                tabPageItem = new TabPage
                {
                    Name = "tabPageItem",
                    Text = "Item List"
                };

                MstItem.MstItemListForm mstItemListForm = new MstItem.MstItemListForm(this)
                {
                    TopLevel = false,
                    Visible = true,
                    Dock = DockStyle.Fill
                };

                tabPageItem.Controls.Add(mstItemListForm);

                tabControlSoftware.TabPages.Add(tabPageItem);
                tabControlSoftware.SelectTab(tabPageItem);
            }
        }
    }
}
