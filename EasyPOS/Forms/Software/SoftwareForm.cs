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

        TabPage tabPageItemList = new TabPage { Name = "tabPageItemList", Text = "Item List" };
        TabPage tabPagePOSSalesList = new TabPage { Name = "tabPagePOSSalesList", Text = "Sales List" };
        TabPage tabPagePOSSalesDetail = new TabPage { Name = "tabPagePOSSalesDetail", Text = "Sales Detail" };
        TabPage tabPageDiscountingList = new TabPage { Name = "tabPageDiscountingList", Text = "Discounting List" };
        TabPage tabPagePOSReport = new TabPage { Name = "tabPagePOSReport", Text = "POS Report" };

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
            if (tabControlSoftware.TabPages.Contains(tabPageItemList) == true)
            {
                tabControlSoftware.SelectTab(tabPageItemList);
            }
            else
            {
                MstItem.MstItemListForm mstItemListForm = new MstItem.MstItemListForm(this)
                {
                    TopLevel = false,
                    Visible = true,
                    Dock = DockStyle.Fill
                };

                tabPageItemList.Controls.Add(mstItemListForm);

                tabControlSoftware.TabPages.Add(tabPageItemList);
                tabControlSoftware.SelectTab(tabPageItemList);
            }
        }

        public void AddTabPagePOSSalesList()
        {
            if (tabControlSoftware.TabPages.Contains(tabPagePOSSalesList) == true)
            {
                tabControlSoftware.SelectTab(tabPagePOSSalesList);
            }
            else
            {
                TrnPOS.TrnSalesListForm trnSalesListForm = new TrnPOS.TrnSalesListForm(this)
                {
                    TopLevel = false,
                    Visible = true,
                    Dock = DockStyle.Fill
                };

                tabPagePOSSalesList.Controls.Add(trnSalesListForm);

                tabControlSoftware.TabPages.Add(tabPagePOSSalesList);
                tabControlSoftware.SelectTab(tabPagePOSSalesList);
            }
        }

        public void AddTabPagePOSSalesDetail()
        {
            if (tabControlSoftware.TabPages.Contains(tabPagePOSSalesDetail) == true)
            {
                tabControlSoftware.SelectTab(tabPagePOSSalesDetail);
            }
            else
            {
                TrnPOS.TrnSalesDetailForm trnSalesDetailForm = new TrnPOS.TrnSalesDetailForm(this)
                {
                    TopLevel = false,
                    Visible = true,
                    Dock = DockStyle.Fill
                };

                tabPagePOSSalesDetail.Controls.Add(trnSalesDetailForm);

                tabControlSoftware.TabPages.Add(tabPagePOSSalesDetail);
                tabControlSoftware.SelectTab(tabPagePOSSalesDetail);
            }
        }

        public void AddTabPageDiscountingList()
        {
            if (tabControlSoftware.TabPages.Contains(tabPageDiscountingList) == true)
            {
                tabControlSoftware.SelectTab(tabPageDiscountingList);
            }
            else
            {
                MstDiscounting.MstDiscountingListForm trnDiscountingListForm = new MstDiscounting.MstDiscountingListForm(this)
                {
                    TopLevel = false,
                    Visible = true,
                    Dock = DockStyle.Fill
                };

                tabPageDiscountingList.Controls.Add(trnDiscountingListForm);

                tabControlSoftware.TabPages.Add(tabPageDiscountingList);
                tabControlSoftware.SelectTab(tabPageDiscountingList);
            }
        }

        public void AddTabPagePOSReport()
        {
            if (tabControlSoftware.TabPages.Contains(tabPagePOSReport) == true)
            {
                tabControlSoftware.SelectTab(tabPagePOSReport);
            }
            else
            {
                RepPOSReport.RepPOSReportForm repPOSReportForm = new RepPOSReport.RepPOSReportForm(this)
                {
                    TopLevel = false,
                    Visible = true,
                    Dock = DockStyle.Fill
                };

                tabPagePOSReport.Controls.Add(repPOSReportForm);

                tabControlSoftware.TabPages.Add(tabPagePOSReport);
                tabControlSoftware.SelectTab(tabPagePOSReport);
            }
        }

        public void RemoveTabPage()
        {
            tabControlSoftware.TabPages.Remove(tabControlSoftware.SelectedTab);
            tabControlSoftware.SelectTab(tabControlSoftware.TabPages.Count - 1);
        }
    }
}
