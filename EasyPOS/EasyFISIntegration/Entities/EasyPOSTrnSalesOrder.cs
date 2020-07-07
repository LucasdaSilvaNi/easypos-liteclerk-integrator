using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.EasyFISIntegration.Entities
{
    class EasyPOSTrnSalesOrder
    {
        public String BranchCode { get; set; }
        public String SODate { get; set; }
        public String SONumber { get; set; }
        public String ManualSONumber { get; set; }
        public String DocumentReference { get; set; }
        public String CustomerCode { get; set; }
        public String Remarks { get; set; }
        public List<EasyPOSTrnSalesOrderItem> POSIntegrationTrnSalesOrderItems { get; set; }
    }
}
