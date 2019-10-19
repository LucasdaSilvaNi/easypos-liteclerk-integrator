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
    public partial class SysSoftwareForm : Form
    {
        public SysSoftwareForm()
        {
            InitializeComponent();
            InitializeDefaultForm();

            Text = "Easy POS - " + Modules.SysCurrentModule.GetCurrentSettings().CurrentDate + " - " + Modules.SysCurrentModule.GetCurrentSettings().CurrentUserName;
        }

        public TabPage tabPageItemList = new TabPage { Name = "tabPageItemList", Text = "Item List" };
        public TabPage tabPageUserList = new TabPage { Name = "tabPageUserList", Text = "User List" };
        public TabPage tabPageUserDetail = new TabPage { Name = "tabPageUserDetail", Text = "User Detail" };
        public TabPage tabPagePOSSalesList = new TabPage { Name = "tabPagePOSSalesList", Text = "Sales List" };
        public TabPage tabPagePOSSalesDetail = new TabPage { Name = "tabPagePOSSalesDetail", Text = "Sales Detail" };
        public TabPage tabPageDiscountingList = new TabPage { Name = "tabPageDiscountingList", Text = "Discounting List" };
        public TabPage tabPagePOSReport = new TabPage { Name = "tabPagePOSReport", Text = "POS Report" };

        public MstItem.MstItemListForm mstItemListForm = null;
        public MstUser.MstUserListForm mstUserListForm = null;
        public MstUser.MstUserDetailForm mstUserDetailForm = null;
        public MstDiscounting.MstDiscountingListForm mstDiscountingListForm = null;
        public TrnPOS.TrnSalesListForm trnSalesListForm = null;
        public TrnPOS.TrnSalesDetailForm trnSalesDetailForm = null;
        public RepPOSReport.RepPOSReportForm repPOSReportForm = null;

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

        public void AddTabPageItemList()
        {
            tabPagePOSSalesDetail.Controls.Remove(mstItemListForm);

            mstItemListForm = new MstItem.MstItemListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageItemList.Controls.Add(mstItemListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageItemList) == true)
            {
                tabControlSoftware.SelectTab(tabPageItemList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageItemList);
                tabControlSoftware.SelectTab(tabPageItemList);
            }
        }


        public void AddTabPageUserList()
        {
            tabPagePOSSalesDetail.Controls.Remove(mstUserListForm);

            mstUserListForm = new MstUser.MstUserListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageUserList.Controls.Add(mstUserListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageUserList) == true)
            {
                tabControlSoftware.SelectTab(tabPageUserList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageUserList);
                tabControlSoftware.SelectTab(tabPageUserList);
            }
        }

        public void AddTabPageUserDetail()
        {
            tabPagePOSSalesDetail.Controls.Remove(mstUserDetailForm);

            mstUserDetailForm = new MstUser.MstUserDetailForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageUserDetail.Controls.Add(mstUserDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPageUserDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPageUserDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageUserDetail);
                tabControlSoftware.SelectTab(tabPageUserDetail);
            }
        }

        public void AddTabPageDiscountingList()
        {
            tabPagePOSSalesDetail.Controls.Remove(mstDiscountingListForm);

            mstDiscountingListForm = new MstDiscounting.MstDiscountingListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPageDiscountingList.Controls.Add(mstDiscountingListForm);

            if (tabControlSoftware.TabPages.Contains(tabPageDiscountingList) == true)
            {
                tabControlSoftware.SelectTab(tabPageDiscountingList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPageDiscountingList);
                tabControlSoftware.SelectTab(tabPageDiscountingList);
            }
        }

        public void AddTabPagePOSSalesList()
        {
            labelLastChange.Visible = true;
            textBoxLastChange.Visible = true;

            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
            textBoxLastChange.Text = trnPOSSalesController.GetLastChange(Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId)).ToString("#,##0.00");

            trnSalesListForm = new TrnPOS.TrnSalesListForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPagePOSSalesList.Controls.Add(trnSalesListForm);

            if (tabControlSoftware.TabPages.Contains(tabPagePOSSalesList) == true)
            {
                tabControlSoftware.SelectTab(tabPagePOSSalesList);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPagePOSSalesList);
                tabControlSoftware.SelectTab(tabPagePOSSalesList);
            }
        }

        public void AddTabPagePOSSalesDetail(TrnPOS.TrnSalesListForm salesListForm, Entities.TrnSalesEntity salesEntity)
        {
            labelLastChange.Visible = true;
            textBoxLastChange.Visible = true;

            Controllers.TrnPOSSalesController trnPOSSalesController = new Controllers.TrnPOSSalesController();
            textBoxLastChange.Text = trnPOSSalesController.GetLastChange(Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId)).ToString("#,##0.00");

            tabPagePOSSalesDetail.Controls.Remove(trnSalesDetailForm);

            trnSalesDetailForm = new TrnPOS.TrnSalesDetailForm(this, salesListForm, salesEntity)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPagePOSSalesDetail.Controls.Add(trnSalesDetailForm);

            if (tabControlSoftware.TabPages.Contains(tabPagePOSSalesDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPagePOSSalesDetail);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPagePOSSalesDetail);
                tabControlSoftware.SelectTab(tabPagePOSSalesDetail);
            }
        }

        public void AddTabPagePOSReport()
        {
            tabPagePOSSalesDetail.Controls.Remove(repPOSReportForm);

            repPOSReportForm = new RepPOSReport.RepPOSReportForm(this)
            {
                TopLevel = false,
                Visible = true,
                Dock = DockStyle.Fill
            };

            tabPagePOSReport.Controls.Add(repPOSReportForm);

            if (tabControlSoftware.TabPages.Contains(tabPagePOSReport) == true)
            {
                tabControlSoftware.SelectTab(tabPagePOSReport);
            }
            else
            {
                tabControlSoftware.TabPages.Add(tabPagePOSReport);
                tabControlSoftware.SelectTab(tabPagePOSReport);
            }
        }

        public void RemoveTabPage()
        {
            tabControlSoftware.TabPages.Remove(tabControlSoftware.SelectedTab);
            tabControlSoftware.SelectTab(tabControlSoftware.TabPages.Count - 1);
        }

        private void SysSoftwareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Account.SysLogin.SysLoginForm sysLogin = new Account.SysLogin.SysLoginForm();
            sysLogin.Show();
        }

        private void tabControlSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlSoftware.SelectedTab == tabPagePOSSalesList || tabControlSoftware.SelectedTab == tabPagePOSSalesDetail)
            {
                labelLastChange.Visible = true;
                textBoxLastChange.Visible = true;
            }
            else
            {
                labelLastChange.Visible = false;
                textBoxLastChange.Visible = false;
            }
        }
    }
}
