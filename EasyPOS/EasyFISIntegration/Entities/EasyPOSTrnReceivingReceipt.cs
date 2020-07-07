using System;
using System.Collections.Generic;

namespace EasyPOS.EasyFISIntegration.Entities
{
    public class EasyPOSTrnReceivingReceipt
    {
        public String BranchCode { get; set; }
        public String Branch { get; set; }
        public String RRNumber { get; set; }
        public String RRDate { get; set; }
        public List<EasyPOSTrnReceivingReceiptItem> ListPOSIntegrationTrnReceivingReceiptItem { get; set; }
    }
}
