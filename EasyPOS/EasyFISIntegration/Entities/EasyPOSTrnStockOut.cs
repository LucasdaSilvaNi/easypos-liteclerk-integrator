using System;
using System.Collections.Generic;

namespace EasyPOS.EasyFISIntegration.Entities
{
    public class EasyPOSTrnStockOut
    {
        public String BranchCode { get; set; }
        public String Branch { get; set; }
        public String OTNumber { get; set; }
        public String OTDate { get; set; }
        public List<EasyPOSTrnStockOutItem> ListPOSIntegrationTrnStockOutItem { get; set; }
    }
}
