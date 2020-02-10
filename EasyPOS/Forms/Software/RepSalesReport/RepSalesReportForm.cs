using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepSalesReport
{
    public partial class RepSalesReportForm : Form
    {
        SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public RepSalesReportForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetTerminalList();
        }

        public void GetTerminalList()
        {
            Controllers.RepSalesReportController repSalesReportController = new Controllers.RepSalesReportController();
            if (repSalesReportController.DropdownListTerminal().Any())
            {
                comboBoxTerminal.DataSource = repSalesReportController.DropdownListTerminal();
                comboBoxTerminal.ValueMember = "Id";
                comboBoxTerminal.DisplayMember = "Terminal";
            }

            GetCustomerList();
        }

        public void GetCustomerList()
        {
            Controllers.RepSalesReportController repSalesReportController = new Controllers.RepSalesReportController();
            if (repSalesReportController.DropdownListCustomer().Any())
            {
                comboBoxCustomer.DataSource = repSalesReportController.DropdownListCustomer();
                comboBoxCustomer.ValueMember = "Id";
                comboBoxCustomer.DisplayMember = "Customer";
            }
        }

        private void listBoxSalesReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSalesReport.SelectedItem != null)
            {
                String selectedItem = listBoxSalesReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Sales Summary Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        dateTimePickerStartDate.Focus();
                        break;
                    case "Sales Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        dateTimePickerStartDate.Focus();
                        break;
                    case "Collection Summary Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        dateTimePickerStartDate.Focus();
                        break;
                    case "Collection Detail Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        dateTimePickerStartDate.Focus();
                        break;
                    case "Cancelled Summary Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        dateTimePickerStartDate.Focus();
                        break;
                    case "Stock Withdrawal Report":
                        labelStartDate.Visible = true;
                        dateTimePickerStartDate.Visible = true;

                        labelEndDate.Visible = true;
                        dateTimePickerEndDate.Visible = true;

                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        labelCustomer.Visible = true;
                        comboBoxCustomer.Visible = true;

                        dateTimePickerStartDate.Focus();

                        break;
                    default:
                        labelStartDate.Visible = false;
                        dateTimePickerStartDate.Visible = false;

                        labelEndDate.Visible = false;
                        dateTimePickerEndDate.Visible = false;

                        labelTerminal.Visible = false;
                        comboBoxTerminal.Visible = false;

                        labelCustomer.Visible = false;
                        comboBoxCustomer.Visible = false;

                        dateTimePickerStartDate.Focus();
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

        private void buttonView_OnClick(object sender, EventArgs e)
        {
            if (listBoxSalesReport.SelectedItem != null)
            {
                String selectedItem = listBoxSalesReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Sales Summary Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepSalesSummary");

                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepSalesReportSalesSummaryReportForm repSalesSummaryReport = new RepSalesReportSalesSummaryReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue));
                                repSalesSummaryReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        break;
                    case "Sales Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepSalesDetail");

                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepSalesReportSalesDetailReportForm repSalesReportSalesDetail = new RepSalesReportSalesDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue));
                                repSalesReportSalesDetail.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        break;
                    case "Collection Summary Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepCollectionSummary");

                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepSalesReportCollectionSummaryReport reportCollectionReport = new RepSalesReportCollectionSummaryReport(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue));
                                reportCollectionReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        break;
                    case "Collection Detail Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepCollectionDetail");

                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepSalesReportCollectionDetailReportForm reportCollectionDetailReportForm = new RepSalesReportCollectionDetailReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue));
                                reportCollectionDetailReportForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        break;
                    case "Cancelled Summary Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepSalesCancelledSummary");

                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                RepSalesReportCancelSalesSummaryReportForm repCancelSalesSummaryReport = new RepSalesReportCancelSalesSummaryReportForm(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue));
                                repCancelSalesSummaryReport.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        break;
                    case "Stock Withdrawal Report":
                        DialogResult printDialogResult = printDialogStockWithdrawalReport.ShowDialog();
                        if (printDialogResult == DialogResult.OK)
                        {
                            String printerName = printDialogStockWithdrawalReport.PrinterSettings.PrinterName;
                            String printFilePath = "";

                            if (printerName == "Microsoft XPS Document Writer")
                            {
                                DialogResult folderBrowserDialoResult = folderBrowserDialogStockWithdrawalReport.ShowDialog();
                                if (folderBrowserDialoResult == DialogResult.OK)
                                {
                                    printFilePath = folderBrowserDialogStockWithdrawalReport.SelectedPath;
                                }
                            }

                            Controllers.RepSalesReportController repSalesReportController = new Controllers.RepSalesReportController();
                            if (repSalesReportController.StockWithdrawalReport(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue), Convert.ToInt32(comboBoxCustomer.SelectedValue)).Any())
                            {
                                foreach (var objStockWithdrawalReport in repSalesReportController.StockWithdrawalReport(dateTimePickerStartDate.Value.Date, dateTimePickerEndDate.Value.Date, Convert.ToInt32(comboBoxTerminal.SelectedValue), Convert.ToInt32(comboBoxCustomer.SelectedValue)))
                                {
                                    String printFileName = printFilePath + "\\" + objStockWithdrawalReport.CollectionNumber + ".oxps";
                                    new Reports.RepDeliveryReceiptReportForm(Convert.ToInt32(objStockWithdrawalReport.SalesId), objStockWithdrawalReport.Id, false, printerName, printFileName, true);
                                }
                            }
                        }

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
    }
}
