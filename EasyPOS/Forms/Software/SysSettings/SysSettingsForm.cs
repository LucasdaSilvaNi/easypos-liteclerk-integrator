using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysSettings
{
    public partial class SysSettingsForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;

        public Boolean isIntegrationStarted = false;
        public Int32 logMessageCount = 0;

        public String logLocation = "";

        public SysSettingsForm(SysSoftwareForm softwareForm)
        {
            InitializeComponent();
            sysSoftwareForm = softwareForm;

            getSettings();
            GetComboBoxDropDownList();
        }

        public void getSettings()
        {
            txtLogs.Text = "Press start button to integrate. \r\n\n\r\n\n";

            isIntegrationStarted = false;

            btnStartIntegration.Enabled = true;
            btnStopIntegration.Enabled = false;

            dtpIntegrationDate.Enabled = true;

            Controllers.IntCloudSettingsController intCloudSettingsController = new Controllers.IntCloudSettingsController();
            var cloudSettings = intCloudSettingsController.DetailCloudSettings();
            if (cloudSettings != null)
            {
                txtDomain.Text = cloudSettings.Domain;
                txtBranchCode.Text = cloudSettings.BranchCode;
                txtUserCode.Text = cloudSettings.UserCode;
                cbxUseItemPrice.Checked = cloudSettings.UseItemPrice;
                logLocation = cloudSettings.LogFileLocation;
            }
        }

        private void backgroundWorkerEasyfisIntegration_DoWork(object sender, DoWorkEventArgs e)
        {
            Controllers.IntCloudSettingsController intCloudSettingsController = new Controllers.IntCloudSettingsController();

            while (isIntegrationStarted)
            {
                String apiUrlHost = txtDomain.Text;

                var cloudSettings = intCloudSettingsController.DetailCloudSettings();
                if (cloudSettings != null)
                {
                    var branchCode = cloudSettings.BranchCode;
                    var userCode = cloudSettings.UserCode;
                    var useItemPrice = cloudSettings.UseItemPrice;

                    Task taskCustomer = Task.Run(() =>
                    {
                        EasyFISIntegration.Controllers.ISPOSMstCustomerController objMstCustomer = new EasyFISIntegration.Controllers.ISPOSMstCustomerController(this, dtpIntegrationDate.Text);
                        objMstCustomer.SyncCustomer(apiUrlHost);
                    });
                    taskCustomer.Wait();

                    if (taskCustomer.IsCompleted)
                    {
                        Task taskSupplier = Task.Run(() =>
                        {
                            EasyFISIntegration.Controllers.ISPOSMstSupplierController objMstSupplier = new EasyFISIntegration.Controllers.ISPOSMstSupplierController(this, dtpIntegrationDate.Text);
                            objMstSupplier.SyncSupplier(apiUrlHost);
                        });
                        taskSupplier.Wait();

                        if (taskSupplier.IsCompleted)
                        {
                            Task taskItem = Task.Run(() =>
                            {
                                EasyFISIntegration.Controllers.ISPOSMstItemController objMstItem = new EasyFISIntegration.Controllers.ISPOSMstItemController(this, dtpIntegrationDate.Text);
                                objMstItem.SyncItem(apiUrlHost);
                            });
                            taskItem.Wait();

                            if (taskItem.IsCompleted)
                            {
                                Task taskReceivingReceipt = Task.Run(() =>
                                {
                                    EasyFISIntegration.Controllers.ISPOSTrnReceivingReceiptController objTrnReceivingReceipt = new EasyFISIntegration.Controllers.ISPOSTrnReceivingReceiptController(this, dtpIntegrationDate.Text);
                                    objTrnReceivingReceipt.SyncReceivingReceipt(apiUrlHost, branchCode);
                                });
                                taskReceivingReceipt.Wait();

                                if (taskReceivingReceipt.IsCompleted)
                                {
                                    Task taskStockIn = Task.Run(() =>
                                    {
                                        EasyFISIntegration.Controllers.ISPOSTrnStockInController objTrnStockIn = new EasyFISIntegration.Controllers.ISPOSTrnStockInController(this, dtpIntegrationDate.Text);
                                        objTrnStockIn.SyncStockIn(apiUrlHost, branchCode);
                                    });
                                    taskStockIn.Wait();

                                    if (taskStockIn.IsCompleted)
                                    {
                                        Task taskStockOut = Task.Run(() =>
                                        {
                                            EasyFISIntegration.Controllers.ISPOSTrnStockOutController objTrnStockOut = new EasyFISIntegration.Controllers.ISPOSTrnStockOutController(this, dtpIntegrationDate.Text);
                                            objTrnStockOut.SyncStockOut(apiUrlHost, branchCode);

                                        });
                                        taskStockOut.Wait();

                                        if (taskStockOut.IsCompleted)
                                        {
                                            Task taskStockTransferIn = Task.Run(() =>
                                            {
                                                EasyFISIntegration.Controllers.ISPOSTrnStockTransferInController objTrnStockTransferIn = new EasyFISIntegration.Controllers.ISPOSTrnStockTransferInController(this, dtpIntegrationDate.Text);
                                                objTrnStockTransferIn.SyncStockTransferIN(apiUrlHost, branchCode);

                                            });
                                            taskStockTransferIn.Wait();

                                            if (taskStockTransferIn.IsCompleted)
                                            {
                                                Task taskStockTransferOut = Task.Run(() =>
                                                {
                                                    EasyFISIntegration.Controllers.ISPOSTrnStockTransferOutController objTrnStockTransferOut = new EasyFISIntegration.Controllers.ISPOSTrnStockTransferOutController(this, dtpIntegrationDate.Text);
                                                    objTrnStockTransferOut.SyncStockTransferOT(apiUrlHost, branchCode);
                                                });
                                                taskStockTransferOut.Wait();

                                                if (taskStockTransferOut.IsCompleted)
                                                {
                                                    Task taskCollection = Task.Run(() =>
                                                    {
                                                        EasyFISIntegration.Controllers.ISPOSTrnCollectionController objTrnCollection = new EasyFISIntegration.Controllers.ISPOSTrnCollectionController(this);
                                                        objTrnCollection.SyncCollection(apiUrlHost, branchCode, userCode);
                                                    });
                                                    taskCollection.Wait();

                                                    if (taskCollection.IsCompleted)
                                                    {
                                                        Task taskSalesReturn = Task.Run(() =>
                                                        {
                                                            EasyFISIntegration.Controllers.ISPOSTrnSalesReturnController objTrnSalesReturn = new EasyFISIntegration.Controllers.ISPOSTrnSalesReturnController(this);
                                                            objTrnSalesReturn.SyncSalesReturn(apiUrlHost, branchCode, userCode);
                                                        });
                                                        taskSalesReturn.Wait();

                                                        if (useItemPrice)
                                                        {
                                                            if (taskSalesReturn.IsCompleted)
                                                            {
                                                                Task taskItemPrice = Task.Run(() =>
                                                                {
                                                                    EasyFISIntegration.Controllers.ISPOSTrnItemPriceController objTrnItemPrice = new EasyFISIntegration.Controllers.ISPOSTrnItemPriceController(this, dtpIntegrationDate.Text);
                                                                    objTrnItemPrice.SyncItemPrice(apiUrlHost, branchCode);

                                                                });
                                                                taskItemPrice.Wait();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                System.Threading.Thread.Sleep(5000);
            }
        }

        private void btnStartIntegration_Click(object sender, EventArgs e)
        {
            isIntegrationStarted = true;

            btnStartIntegration.Enabled = false;
            btnStopIntegration.Enabled = true;

            dtpIntegrationDate.Enabled = false;

            logMessages("Started! \r\n\nTime Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n\r\n\n");

            if (backgroundWorkerEasyfisIntegration.IsBusy != true)
            {
                backgroundWorkerEasyfisIntegration.RunWorkerAsync();
            }
        }

        private void btnStopIntegration_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to stop integration?", "Easy POS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                isIntegrationStarted = false;

                btnStartIntegration.Enabled = true;
                btnStopIntegration.Enabled = false;

                dtpIntegrationDate.Enabled = true;

                logMessages("Stopped! \r\n\nTime Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n\r\n\n");
            }
        }

        public void logMessages(String message)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                String displayMessage = message;

                logMessageCount++;
                if (logMessageCount >= 1000)
                {
                    logMessageCount = 0;

                    if (!txtLogs.Text.Equals(""))
                    {
                        File.WriteAllText(logLocation + "\\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".txt", txtLogs.Text);
                        txtLogs.Text = "";
                    }
                }

                txtLogs.Text += displayMessage;

                txtLogs.Focus();
                txtLogs.SelectionStart = txtLogs.Text.Length;
                txtLogs.ScrollToCaret();
            });
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            sysSoftwareForm.RemoveTabPage();
        }

        // ==========
        // SysCurrent 
        // ==========

        public void GetComboBoxDropDownList()
        {
            Controllers.SysCurrentController sysSettingsController = new Controllers.SysCurrentController();

            var terminals = sysSettingsController.DropDownTerminalList();
            if (terminals.Any())
            {

                comboBoxTerminal.DataSource = terminals;
                comboBoxTerminal.ValueMember = "Id";
                comboBoxTerminal.DisplayMember = "Terminal";
            }

            var periods = sysSettingsController.DropDownPeriodList();
            if (periods.Any())
            {
                comboBoxCurrentPeriod.DataSource = periods;
                comboBoxCurrentPeriod.ValueMember = "Id";
                comboBoxCurrentPeriod.DisplayMember = "Period";
            }

            var customers = sysSettingsController.DropDownCustomerList();
            if (customers.Any())
            {
                comboBoxWalkinCustomer.DataSource = customers;
                comboBoxWalkinCustomer.ValueMember = "Id";
                comboBoxWalkinCustomer.DisplayMember = "Customer";
            }

            var discounts = sysSettingsController.DropDownDiscountList();
            if (discounts.Any())
            {
                comboBoxDefaultDiscount.DataSource = discounts;
                comboBoxDefaultDiscount.ValueMember = "Id";
                comboBoxDefaultDiscount.DisplayMember = "Discount";
            }

            var supplier = sysSettingsController.DropDownSupplierList();
            if (supplier.Any())
            {
                comboBoxReturnSupplier.DataSource = supplier;
                comboBoxReturnSupplier.ValueMember = "Id";
                comboBoxReturnSupplier.DisplayMember = "Supplier";
            }
            getSysCurrentDetail();
        }

        public void getSysCurrentDetail()
        {
            Controllers.SysCurrentController sysSettingsController = new Controllers.SysCurrentController();
            var sysCurrent = sysSettingsController.GetSysCurrent();
            if (sysCurrent != null)
            {
                textBoxCompanyName.Text = sysCurrent.CompanyName;
                textBoxAddress.Text = sysCurrent.Address;
                textBoxContactNo.Text = sysCurrent.ContactNo;
                textBoxTIN.Text = sysCurrent.TIN;
                textBoxAccreditationNo.Text = sysCurrent.AccreditationNo;
                textBoxSerialNo.Text = sysCurrent.SerialNo;
                textBoxPermitNo.Text = sysCurrent.PermitNo;
                textBoxMachineNo.Text = sysCurrent.MachineNo;
                textBoxReceiptFooter.Text = sysCurrent.ReceiptFooter;
                textBoxInvoiceFooter.Text = sysCurrent.InvoiceFooter;
                textBoxLicenseCode.Text = sysCurrent.LicenseCode;
                textBoxTenantOf.Text = sysCurrent.TenantOf;
                textBoxCurrentVersion.Text = sysCurrent.CurrentVersion;
                textBoxCurrentDeveloper.Text = sysCurrent.CurrentDeveloper;
                textBoxCurrentSupport.Text = sysCurrent.CurrentSupport;
                comboBoxCurrentPeriod.SelectedValue = Convert.ToInt32(sysCurrent.CurrentPeriodId);
                comboBoxTerminal.SelectedValue = Convert.ToInt32(sysCurrent.TerminalId);
                comboBoxWalkinCustomer.SelectedValue = Convert.ToInt32(sysCurrent.WalkinCustomerId);
                comboBoxDefaultDiscount.SelectedValue = Convert.ToInt32(sysCurrent.DefaultDiscountId);
                comboBoxReturnSupplier.SelectedValue = Convert.ToInt32(sysCurrent.ReturnSupplierId);
                textBoxORPrintTitle.Text = sysCurrent.ORPrintTitle;
                checkBoxIsTenderPrint.Checked = Convert.ToBoolean(sysCurrent.IsTenderPrint);
                checkBoxIsBarcodeQuantityAlwaysOne.Checked = Convert.ToBoolean(sysCurrent.IsBarcodeQuantityAlwaysOne);
                checkBoxWithCustomerDisplay.Checked = Convert.ToBoolean(sysCurrent.WithCustomerDisplay);
                textBoxCustomerDisplayPort.Text = sysCurrent.CustomerDisplayPort;
                textBoxCustomerDisplayBaudRate.Text = sysCurrent.CustomerDisplayBaudRate;
                textBoxCustomerDisplayFirstLineMessage.Text = sysCurrent.CustomerDisplayFirstLineMessage;
                textBoxCustomerDisplayIfCounterClosedMessage.Text = sysCurrent.CustomerDisplayIfCounterClosedMessage;
                textBoxCollectionReport.Text = sysCurrent.CollectionReport;
                textBoxZReadingFooter.Text = sysCurrent.ZReadingFooter;
                textBoxEasypayAPIURL.Text = sysCurrent.EasypayAPIURL;
                textBoxEasypayDefaultUsername.Text = sysCurrent.EasypayDefaultUsername;
                textBoxEasypayDefaultPassword.Text = sysCurrent.EasypayDefaultPassword;
                textBoxEasypayMotherCardNumber.Text = sysCurrent.EasypayMotherCardNumber;
                checkBoxActivateAuditTrail.Checked = Convert.ToBoolean(sysCurrent.ActivateAuditTrail);
            }
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            Controllers.SysCurrentController sysSettingsController = new Controllers.SysCurrentController();

            Entities.SysCurrentEntity sysCurrentEntity = new Entities.SysCurrentEntity()
            {
                CompanyName = textBoxCompanyName.Text,
                Address = textBoxAddress.Text,
                ContactNo = textBoxContactNo.Text,
                TIN = textBoxTIN.Text,
                AccreditationNo = textBoxAccreditationNo.Text,
                SerialNo = textBoxSerialNo.Text,
                PermitNo = textBoxPermitNo.Text,
                MachineNo = textBoxMachineNo.Text,
                DeclareRate = "",
                ReceiptFooter = textBoxInvoiceFooter.Text,
                InvoiceFooter = textBoxInvoiceFooter.Text,
                LicenseCode = textBoxLicenseCode.Text,
                TenantOf = textBoxTenantOf.Text,
                CurrentVersion = textBoxCurrentVersion.Text,
                CurrentDeveloper = textBoxCurrentDeveloper.Text,
                CurrentSupport = textBoxCurrentSupport.Text,
                CurrentPeriodId = comboBoxCurrentPeriod.SelectedValue.ToString(),
                TerminalId = comboBoxTerminal.SelectedValue.ToString(),
                WalkinCustomerId = comboBoxWalkinCustomer.SelectedValue.ToString(),
                DefaultDiscountId = comboBoxDefaultDiscount.SelectedValue.ToString(),
                ReturnSupplierId = comboBoxReturnSupplier.SelectedValue.ToString(),
                ORPrintTitle = textBoxORPrintTitle.Text,
                IsTenderPrint = checkBoxIsTenderPrint.Checked.ToString(),
                IsBarcodeQuantityAlwaysOne = checkBoxIsBarcodeQuantityAlwaysOne.Checked.ToString(),
                WithCustomerDisplay = checkBoxWithCustomerDisplay.Checked.ToString(),
                CustomerDisplayPort = textBoxCustomerDisplayPort.Text,
                CustomerDisplayBaudRate = textBoxCustomerDisplayBaudRate.Text,
                CustomerDisplayFirstLineMessage = textBoxCustomerDisplayFirstLineMessage.Text,
                CustomerDisplayIfCounterClosedMessage = textBoxCustomerDisplayIfCounterClosedMessage.Text,
                CollectionReport = textBoxCollectionReport.Text,
                ZReadingFooter = textBoxZReadingFooter.Text,
                EasypayAPIURL = textBoxEasypayAPIURL.Text,
                EasypayDefaultUsername = textBoxEasypayDefaultUsername.Text,
                EasypayDefaultPassword = textBoxEasypayDefaultPassword.Text,
                EasypayMotherCardNumber = textBoxEasypayMotherCardNumber.Text,
                ActivateAuditTrail = checkBoxActivateAuditTrail.Checked.ToString()
            };

            String[] saveSysCurrent = sysSettingsController.UpdateSysCurrent(sysCurrentEntity);
            if (saveSysCurrent[1].Equals("0") == false)
            {
                MessageBox.Show("SysCurrent Save", "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(saveSysCurrent[0], "Easy POS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab.Name == "System Current") { textBoxCompanyName.Focus(); }
            if (tabControl1.SelectedTab.Name == "Cloud Settings") { dtpIntegrationDate.Focus(); }

        }
    }
}
