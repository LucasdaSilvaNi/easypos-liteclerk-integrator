using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class SysCurrentEntity
    {
        public String CompanyName { get; set; }
        public String Address { get; set; }
        public String ContactNo { get; set; }
        public String TIN { get; set; }
        public String AccreditationNo { get; set; }
        public String SerialNo { get; set; }
        public String PermitNo { get; set; }
        public String MachineNo { get; set; }
        public String DeclareRate { get; set; }
        public String ReceiptFooter { get; set; }
        public String InvoiceFooter { get; set; }
        public String LicenseCode { get; set; }
        public String TenantOf { get; set; }
        public String CurrentUserId { get; set; }
        public String CurrentUserName { get; set; }
        public String CurrentVersion { get; set; }
        public String CurrentDeveloper { get; set; }
        public String CurrentSupport { get; set; }
        public String CurrentPeriodId { get; set; }
        public String CurrentDate { get; set; }
        public String TerminalId { get; set; }
        public String WalkinCustomerId { get; set; }
        public String DefaultDiscountId { get; set; }
        public String ReturnSupplierId { get; set; }
        public String ORPrintTitle { get; set; }
        public String IsTenderPrint { get; set; }
        public String IsBarcodeQuantityAlwaysOne { get; set; }
        public String WithCustomerDisplay { get; set; }
        public String CustomerDisplayPort { get; set; }
        public String CustomerDisplayBaudRate { get; set; }
        public String CustomerDisplayFirstLineMessage { get; set; }
        public String CustomerDisplayIfCounterClosedMessage { get; set; }
    }
}