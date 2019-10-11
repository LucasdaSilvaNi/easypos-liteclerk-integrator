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

        public void AddTabPage(TabPage tabPage)
        {
            if (tabControlSoftware.TabPages.Contains(tabPage) == true)
            {
                tabControlSoftware.SelectTab(tabPage);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPage);
                tabControlSoftware.SelectTab(tabPage);
            }
        }

        public void RemoveTabPage()
        {
            tabControlSoftware.TabPages.Remove(tabControlSoftware.SelectedTab);
        }
    }
}
