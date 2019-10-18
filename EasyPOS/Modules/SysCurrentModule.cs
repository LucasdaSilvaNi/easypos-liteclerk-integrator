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
            Entities.SysCurrentEntity newEntities = new Entities.SysCurrentEntity()
            {
                CompanyName = "ACME Corporation",
                Address = "Cebu City",
                ContactNo = "",
                TIN = "",
                AccreditationNo = "",
                SerialNo = "",
                PermitNo = "",
                MachineNo = "",
                DeclareRate = "",
                ReceiptFooter = "EASYFIS CORPORATION\nUnit 1023 City Soho Bldg. B. Rodriguez St. Guadalupe Cebu City Phil, 6000\nTIN= 010-045-930-000\n\nTHIS INVOICE/RECEIPT SHALL BE VALID FOR FIVE(5) YEARS FROM THE DATE OF PERMIT TO USE.",
                InvoiceFooter = "",
                LicenseCode = "",
                TenantOf = "",
                CurrentUserId = currentUserId,
                CurrentUserName = userName,
                CurrentVersion = "",
                CurrentDeveloper = "",
                CurrentSupport = "",
                CurrentPeriodId = "1",
                CurrentDate = loginDate,
                TerminalId = "1",
                WalkinCustomerId = "5579",
                DefaultDiscountId = "2",
                ReturnSupplierId = "",
                ORPrintTitle = "O F F I C I A L  R E C E I P T"
            };

            String newJson = new JavaScriptSerializer().Serialize(newEntities);
            File.WriteAllText(path, newJson);
        }
    }
}
