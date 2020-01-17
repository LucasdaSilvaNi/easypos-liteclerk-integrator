using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
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
                    case "E-Journal Report (ejournal.txt)":
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
                    case "E-Sales Report (esales.csv)":
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
                    case "Collection Register (collectionregister.csv)":
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
                    case "E-Journal Report (ejournal.txt)":
                        DialogResult dialogResult = folderBrowserDialogSaveEJournal.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            String folderPath = folderBrowserDialogSaveEJournal.SelectedPath;

                            FileStream fs1 = new FileStream(folderPath + "\\ejournal" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
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
                                    writer.Write("---------------------------------------------------------\n");

                                    if (collection.SalesId != null)
                                    {
                                        if (repPOSReportController.ListSalesLines(Convert.ToInt32(collection.SalesId)).Any())
                                        {
                                            Decimal totalSales = 0;
                                            Decimal totalNumberOfItems = 0;
                                            Decimal totalDiscount = 0;

                                            foreach (var salesLine in repPOSReportController.ListSalesLines(Convert.ToInt32(collection.SalesId)))
                                            {
                                                String itemDescription = salesLine.ItemDescription + " " + salesLine.Quantity.ToString("#,##0.00") + " " + salesLine.Unit + " @ " + salesLine.Price.ToString("#,#00.00") + " \t\t" + salesLine.Amount.ToString("#,#00.00");
                                                if (salesLine.ItemDescription.Length >= 20)
                                                {
                                                    itemDescription = salesLine.ItemDescription.Substring(0, 20) + " " + salesLine.Quantity.ToString("#,##0.00") + " " + salesLine.Unit + " @ " + salesLine.Price.ToString("#,#00.00") + " \t" + salesLine.Amount.ToString("#,#00.00");
                                                }
                                                else
                                                {
                                                    if (salesLine.ItemDescription.Length <= 12)
                                                    {
                                                        itemDescription = salesLine.ItemDescription + " " + salesLine.Quantity.ToString("#,##0.00") + " " + salesLine.Unit + " @ " + salesLine.Price.ToString("#,#00.00") + " \t\t\t" + salesLine.Amount.ToString("#,#00.00");
                                                    }
                                                    if (salesLine.ItemDescription.Length <= 4)
                                                    {
                                                        itemDescription = salesLine.ItemDescription + " " + salesLine.Quantity.ToString("#,##0.00") + " " + salesLine.Unit + " @ " + salesLine.Price.ToString("#,#00.00") + " \t\t\t\t" + salesLine.Amount.ToString("#,#00.00");
                                                    }
                                                }

                                                writer.Write(itemDescription);
                                                writer.Write("\n");

                                                totalSales += salesLine.Amount;
                                                totalNumberOfItems += 1;
                                                totalDiscount += salesLine.DiscountAmount;
                                            }

                                            writer.Write("---------------------------------------------------------\n");
                                            writer.Write("Total Sales: \t\t\t\t\t" + totalSales.ToString("#,#00.00"));
                                            writer.Write("\n");
                                            writer.Write("Total No. of Item(s): \t\t\t\t" + totalNumberOfItems.ToString("#,#00.00"));
                                            writer.Write("\n");
                                            writer.Write("Total Discount: \t\t\t\t" + totalDiscount.ToString("#,#00.00"));
                                            writer.Write("\n");
                                            writer.Write("---------------------------------------------------------\n");
                                        }

                                        if (repPOSReportController.ListCollectionLines(Convert.ToInt32(collection.Id)).Any())
                                        {
                                            foreach (var collectionLine in repPOSReportController.ListCollectionLines(Convert.ToInt32(collection.Id)))
                                            {
                                                writer.Write(collectionLine.PayType + ": \t\t\t\t\t\t" + collectionLine.Amount.ToString("#,##0.00"));
                                                writer.Write("\n");
                                            }
                                        }

                                        writer.Write("---------------------------------------------------------\n");
                                        writer.Write("VAT ANALYSIS\n");

                                        Decimal VATSales = 0;
                                        Decimal VATAmount = 0;
                                        Decimal NonVAT = 0;
                                        Decimal VATExempt = 0;
                                        Decimal VATZeroRated = 0;

                                        writer.Write("VAT Sales: \t\t\t\t\t" + VATSales.ToString("#,#00.00"));
                                        writer.Write("\n");
                                        writer.Write("VAT Amount: \t\t\t\t\t" + VATAmount.ToString("#,#00.00"));
                                        writer.Write("\n");
                                        writer.Write("Non-VAT: \t\t\t\t\t" + NonVAT.ToString("#,#00.00"));
                                        writer.Write("\n");
                                        writer.Write("VAT Exempt: \t\t\t\t\t" + VATExempt.ToString("#,#00.00"));
                                        writer.Write("\n");
                                        writer.Write("VAT Zero Rated: \t\t\t\t" + VATZeroRated.ToString("#,#00.00"));
                                        writer.Write("\n");

                                        writer.Write("---------------------------------------------------------\n");
                                        writer.Write("Cashier: " + collection.PreparedByUserName);
                                        writer.Write("\n");
                                        writer.Write("---------------------------------------------------------\n");
                                        writer.Write("Customer Name: \n");
                                        writer.Write("Address: \n");
                                        writer.Write("TIN: \n");
                                        writer.Write("Business Style: \n");
                                        writer.Write("---------------------------------------------------------\n");

                                        writer.Write(systemCurrent.ReceiptFooter);
                                    }

                                    writer.Write("\n\n\n\n\n");
                                }
                            }

                            writer.Close();
                        }

                        break;
                    case "E-Sales Report (esales.csv)":

                        break;
                    case "Collection Register (collectionregister.csv)":
                        DialogResult dialogResultCollectionRegister = folderBrowserDialogCollectionRegister.ShowDialog();
                        if (dialogResultCollectionRegister == DialogResult.OK)
                        {
                            StringBuilder csv = new StringBuilder();
                            String[] header = {
                                "Terminal",
                                "Date",
                                "Collection Number",
                                "Customer Code",
                                "Customer",
                                "Amount",
                                "VAT Sales",
                                "VAT Amount",
                                "Non-VAT",
                                "VAT Exempt",
                                "VAT Zero Rated"
                            };
                            csv.AppendLine(String.Join(",", header));

                            Controllers.RepPOSReportController repPOSReportController = new Controllers.RepPOSReportController();
                            if (repPOSReportController.ListCollectionRegister(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, Convert.ToInt32(comboBoxTerminal.SelectedValue)).Any())
                            {
                                foreach (var collectionRegister in repPOSReportController.ListCollectionRegister(dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, Convert.ToInt32(comboBoxTerminal.SelectedValue)))
                                {
                                    String customerCode = "";
                                    if (collectionRegister.CustomerCode != null)
                                    {
                                        customerCode = collectionRegister.CustomerCode.Replace(",", " ");
                                    }

                                    String[] data = {
                                        collectionRegister.Terminal,
                                        collectionRegister.CollectionDate,
                                        collectionRegister.CollectionNumber,
                                        customerCode,
                                        collectionRegister.Customer.Replace("," , ""),
                                        collectionRegister.Amount.ToString("#,#00.00").Replace("," , ""),
                                        collectionRegister.VATSales.ToString("#,#00.00").Replace("," , ""),
                                        collectionRegister.VATAmount.ToString("#,#00.00").Replace("," , ""),
                                        collectionRegister.NonVAT.ToString("#,#00.00").Replace("," , ""),
                                        collectionRegister.VATExempt.ToString("#,#00.00").Replace("," , ""),
                                        collectionRegister.VATZeroRated.ToString("#,#00.00").Replace("," , ""),
                                    };
                                    csv.AppendLine(String.Join(",", data));
                                }
                            }

                            String executingUser = WindowsIdentity.GetCurrent().Name;

                            DirectorySecurity securityRules = new DirectorySecurity();
                            securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.Read, AccessControlType.Allow));
                            securityRules.AddAccessRule(new FileSystemAccessRule(executingUser, FileSystemRights.FullControl, AccessControlType.Allow));

                            DirectoryInfo createDirectorySTCSV = Directory.CreateDirectory(folderBrowserDialogCollectionRegister.SelectedPath, securityRules);
                            File.WriteAllText(createDirectorySTCSV.FullName + "\\collectionregister" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv", csv.ToString(), Encoding.GetEncoding("iso-8859-1"));

                            MessageBox.Show("Generate CSV Successful!", "Generate CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
