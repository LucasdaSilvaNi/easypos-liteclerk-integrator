using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepInventoryReport
{
    public partial class RepInventoryReportForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public RepInventoryReportForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;
        }

        private void listBoxSalesReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxInventoryReport.SelectedItem != null)
            {
                String selectedItem = listBoxInventoryReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Inventory Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        dateTimePickerStartDate.Focus();
                        break;
                    case "Stock In Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        dateTimePickerStartDate.Focus();
                        break;
                    case "Stock Out Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        dateTimePickerStartDate.Focus();
                        break;
                    case "Stock Count Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        dateTimePickerStartDate.Focus();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonView_OnClick(object sender, EventArgs e)
        {
            if (listBoxInventoryReport.SelectedItem != null)
            {
                String selectedItem = listBoxInventoryReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Inventory Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepInventory");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepInventoryReportInventoryReportForm repInventoryReportInventoryReport = new RepInventoryReportInventoryReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
                                repInventoryReportInventoryReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case "Stock In Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepInventoryStockInDetail");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepInventoryReportStockInDetailReportForm reportStockInDetailReport = new RepInventoryReportStockInDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
                                reportStockInDetailReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case "Stock Out Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepInventoryStockInDetail");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepInventoryReportStockOutDetailReportForm repInventoryReportStockOut = new RepInventoryReportStockOutDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
                                repInventoryReportStockOut.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case "Stock Count Detail Report":
                        RepInventoryReportStockCountDetailReportForm repInventoryReportStockCount = new RepInventoryReportStockCountDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
                        repInventoryReportStockCount.ShowDialog();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_OnClick(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }
    }
}
