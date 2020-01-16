using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.RepPOSReport
{
    public partial class RepPOSReportForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public RepPOSReportForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            GetTerminalList();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        public void GetTerminalList()
        {
            Controllers.RepPOSReportController repPOSReportController = new Controllers.RepPOSReportController();
            if (repPOSReportController.DropdownListTerminal().Any())
            {
                comboBoxTerminal.DataSource = repPOSReportController.DropdownListTerminal();
                comboBoxTerminal.ValueMember = "Id";
                comboBoxTerminal.DisplayMember = "Terminal";

                GetUserList();
            }
        }

        public void GetUserList()
        {
            Controllers.RepPOSReportController repPOSReportController = new Controllers.RepPOSReportController();
            if (repPOSReportController.DropdownListUser().Any())
            {
                comboBoxUser.DataSource = repPOSReportController.DropdownListUser();
                comboBoxUser.ValueMember = "Id";
                comboBoxUser.DisplayMember = "FullName";
            }
        }

        private void listBoxPOSReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPOSReport.SelectedItem != null)
            {
                String selectedItem = listBoxPOSReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Z Reading Report":
                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        dateTimePickerDate.Visible = true;
                        labelDate.Visible = true;

                        comboBoxUser.Visible = false;
                        labelUser.Visible = false;

                        dateTimePickerStartDate.Visible = false;
                        labelStartDate.Visible = false;

                        dateTimePickerEndDate.Visible = false;
                        labelEndDate.Visible = false;
                        break;
                    case "X Reading Report":
                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        dateTimePickerDate.Visible = true;
                        labelDate.Visible = true;

                        comboBoxUser.Visible = true;
                        labelUser.Visible = true;

                        dateTimePickerStartDate.Visible = false;
                        labelStartDate.Visible = false;

                        dateTimePickerEndDate.Visible = false;
                        labelEndDate.Visible = false;
                        break;
                    case "E-Journal Report":
                        labelTerminal.Visible = true;
                        comboBoxTerminal.Visible = true;

                        dateTimePickerDate.Visible = false;
                        labelDate.Visible = false;

                        comboBoxUser.Visible = false;
                        labelUser.Visible = false;

                        dateTimePickerStartDate.Visible = true;
                        labelStartDate.Visible = true;

                        dateTimePickerEndDate.Visible = true;
                        labelEndDate.Visible = true;
                        break;
                    default:
                        labelTerminal.Visible = false;
                        comboBoxTerminal.Visible = false;

                        dateTimePickerDate.Visible = false;
                        labelDate.Visible = false;

                        comboBoxUser.Visible = false;
                        labelUser.Visible = false;

                        dateTimePickerStartDate.Visible = false;
                        labelStartDate.Visible = false;

                        dateTimePickerEndDate.Visible = false;
                        labelEndDate.Visible = false;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please select a report.", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            if (listBoxPOSReport.SelectedItem != null)
            {
                String selectedItem = listBoxPOSReport.SelectedItem.ToString();
                switch (selectedItem)
                {
                    case "Z Reading Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepPOS (Z Reading)");

                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                Reports.RepPOSReportZReadingReportForm repZReadingReportForm = new Reports.RepPOSReportZReadingReportForm(this, Convert.ToInt32(comboBoxTerminal.SelectedValue), Convert.ToDateTime(dateTimePickerDate.Value.ToShortDateString()));
                                repZReadingReportForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        break;
                    case "X Reading Report":
                        sysUserRights = new Modules.SysUserRightsModule("RepPOS (X Reading)");

                        if (sysUserRights.GetUserRights() == null)
                        {
                            MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (sysUserRights.GetUserRights().CanView == true)
                            {
                                Reports.RepPOSReportXReadingReportForm repXReadingReportForm = new Reports.RepPOSReportXReadingReportForm(this, Convert.ToInt32(comboBoxTerminal.SelectedValue), Convert.ToDateTime(dateTimePickerDate.Value.ToShortDateString()), Convert.ToInt32(comboBoxUser.SelectedValue));
                                repXReadingReportForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("No rights!", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        break;
                    case "E-Journal Report":
                        DialogResult dialogResult = folderBrowserDialogSaveEJournal.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            String folderPath = folderBrowserDialogSaveEJournal.SelectedPath;

                            FileStream fs1 = new FileStream(folderPath + "\\EJournalReport.txt", FileMode.OpenOrCreate, FileAccess.Write);
                            StreamWriter writer = new StreamWriter(fs1);

                            Controllers.RepPOSReportController repPOSReportController = new Controllers.RepPOSReportController();
                            if (repPOSReportController.ListCollections(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, Convert.ToInt32(comboBoxTerminal.SelectedValue)).Any())
                            {
                                var systemCurrent = Modules.SysCurrentModule.GetCurrentSettings();
                                foreach (var collection in repPOSReportController.ListCollections(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, Convert.ToInt32(comboBoxTerminal.SelectedValue)))
                                {
                                    writer.Write(systemCurrent.CompanyName + "\n");
                                    writer.Write(systemCurrent.Address + "\n");

                                    writer.Write("TIN: " + systemCurrent.TIN + "\n");
                                    writer.Write("S/N: " + systemCurrent.SerialNo + "\n");
                                    writer.Write("MIN: " + systemCurrent.MachineNo + "\n");
                                    writer.Write(systemCurrent.ORPrintTitle + "\n");
                                    writer.Write(collection.CollectionNumber + "\n");
                                    writer.Write("---------------------------------------------\n");

                                    if (collection.SalesId != null)
                                    {
                                        if (repPOSReportController.ListSalesLines(Convert.ToInt32(collection.SalesId)).Any())
                                        {
                                            Decimal totalSales = 0;
                                            Decimal totalNumberOfItems = 0;
                                            Decimal totalDiscount = 0;

                                            foreach (var salesLine in repPOSReportController.ListSalesLines(Convert.ToInt32(collection.SalesId)))
                                            {
                                                writer.Write(salesLine.ItemDescription + " " + salesLine.Quantity.ToString("#,##0.00") + " " + salesLine.Unit + " @ " + salesLine.Price.ToString("#,#00.00"));
                                                writer.Write("\n");

                                                totalSales += salesLine.Amount;
                                                totalNumberOfItems += 1;
                                                totalDiscount += salesLine.DiscountAmount;
                                            }

                                            writer.Write("---------------------------------------------\n");

                                            writer.Write("Total Sales: " + totalSales.ToString("#,#00.00"));
                                            writer.Write("Total No. of Item(s): " + totalNumberOfItems.ToString("#,#00.00"));
                                            writer.Write("Total Discount: " + totalDiscount.ToString("#,#00.00"));
                                        }
                                    }

                                    writer.Write("\n\n\n");
                                }
                            }

                            writer.Close();
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
