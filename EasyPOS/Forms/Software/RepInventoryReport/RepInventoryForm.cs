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
    public partial class RepInventoryForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public RepInventoryForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetItemList();
        }

        public void GetItemList()
        {
            Controllers.RepInventoryReportController repInventoryReportController = new Controllers.RepInventoryReportController();
            if (repInventoryReportController.DropdownListItem().Any())
            {
                comboBoxItem.DataSource = repInventoryReportController.DropdownListItem();
                comboBoxItem.ValueMember = "Id";
                comboBoxItem.DisplayMember = "ItemDescription";
            }
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
                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;
                        dateTimePickerStartDate.Focus();
                        break;
                    case "Item List Report":
                        break;
                    case "Stock Card":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        labelItem.Visible = true;
                        comboBoxItem.Visible = true;
                        dateTimePickerStartDate.Focus();
                        break;
                    case "Stock In Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;
                        dateTimePickerStartDate.Focus();
                        break;
                    case "Stock Out Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;
                        dateTimePickerStartDate.Focus();
                        break;
                    case "Stock Count Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;
                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;
                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;
                        dateTimePickerStartDate.Focus();
                        break;
                    default:
                        labelStartDate.Visible = false;
                        dateTimePickerStartDate.Visible = false;
                        labelEndDate.Visible = false;
                        dateTimePickerEndDate.Visible = false;
                        labelItem.Visible = false;
                        comboBoxItem.Visible = false;
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
                                RepInventoryReportForm repInventoryReportInventoryReport = new RepInventoryReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
                                repInventoryReportInventoryReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case "Item List Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepInventoryItemList");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepInventoryItemListReportForm repInventoryListReportInventoryReport = new RepInventoryItemListReportForm();
                                repInventoryListReportInventoryReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case "Stock Card":
                        sysUserRights = new Modules.SysUserRightsModule("RepInventoryStockCard");
                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepStockCardForm repStockCardForm = new RepStockCardForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxItem.SelectedValue));
                                repStockCardForm.ShowDialog();
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
                                RepStockInDetailReportForm reportStockInDetailReport = new RepStockInDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
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
                                RepStockOutDetailReportForm repInventoryReportStockOut = new RepStockOutDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
                                repInventoryReportStockOut.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        break;
                    case "Stock Count Detail Report":
                        RepStockCountDetailReportForm repInventoryReportStockCount = new RepStockCountDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date);
                        repInventoryReportStockCount.ShowDialog();
                        break;
                    default:
                        MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
