using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EasyPOS.Modules
{
    class SysCurrentModule
    {
        public static String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Settings/SysCurrent.json");

        // ====================
        // Get Current Settings 
        // ====================
        public static Entities.SysCurrentEntity GetCurrentSettings()
        {
            String json;
            using (StreamReader trmRead = new StreamReader(path)) { json = trmRead.ReadToEnd(); }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Entities.SysCurrentEntity sysCurrentEntity = javaScriptSerializer.Deserialize<Entities.SysCurrentEntity>(json);

            return sysCurrentEntity;
        }

        // ===============================
        // Update Current Settings - Login
        // ===============================
        public static void UpdateCurrentSettingsLogin(String currentUserId, String userName, String loginDate)
        {
            var currentSettings = GetCurrentSettings();

            Entities.SysCurrentEntity newEntities = new Entities.SysCurrentEntity()
            {
                CompanyName = currentSettings.CompanyName,
                Address = currentSettings.Address,
                ContactNo = currentSettings.ContactNo,
                TIN = currentSettings.TIN,
                AccreditationNo = currentSettings.AccreditationNo,
                SerialNo = currentSettings.SerialNo,
                PermitNo = currentSettings.PermitNo,
                MachineNo = currentSettings.MachineNo,
                DeclareRate = currentSettings.DeclareRate,
                ReceiptFooter = currentSettings.ReceiptFooter,
                InvoiceFooter = currentSettings.InvoiceFooter,
                LicenseCode = currentSettings.LicenseCode,
                TenantOf = currentSettings.TenantOf,
                CurrentUserId = currentUserId,
                CurrentUserName = userName,
                CurrentVersion = currentSettings.CurrentDate,
                CurrentDeveloper = currentSettings.CurrentDeveloper,
                CurrentSupport = currentSettings.CurrentSupport,
                CurrentPeriodId = currentSettings.CurrentPeriodId,
                CurrentDate = loginDate,
                TerminalId = currentSettings.TerminalId,
                WalkinCustomerId = currentSettings.WalkinCustomerId,
                DefaultDiscountId = currentSettings.DefaultDiscountId,
                ReturnSupplierId = currentSettings.ReturnSupplierId,
                ORPrintTitle = currentSettings.ORPrintTitle,
                IsTenderPrint = currentSettings.IsTenderPrint,
                IsBarcodeQuantityAlwaysOne = currentSettings.IsBarcodeQuantityAlwaysOne,
                WithCustomerDisplay = currentSettings.WithCustomerDisplay,
                CustomerDisplayPort = currentSettings.CustomerDisplayPort,
                CustomerDisplayBaudRate = currentSettings.CustomerDisplayBaudRate,
                CustomerDisplayFirstLineMessage = currentSettings.CustomerDisplayFirstLineMessage,
                CustomerDisplayIfCounterClosedMessage = currentSettings.CustomerDisplayIfCounterClosedMessage,
                CollectionReport = currentSettings.CollectionReport
            };

            String newJson = new JavaScriptSerializer().Serialize(newEntities);
            File.WriteAllText(path, newJson);
        }
    }
}
