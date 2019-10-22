using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.EasyFISIntegration.Entities
{
    class ISPOSTrnStockIn
    {
        public String BranchCode { get; set; }
        public String Branch { get; set; }
        public String INNumber { get; set; }
        public String INDate { get; set; }
        public List<ISPOSTrnStockInItem> ListPOSIntegrationTrnStockInItem { get; set; }
    }
}
