using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.EasyFISIntegration.Entities
{
    class EasyPOSTrnStockIn
    {
        public String BranchCode { get; set; }
        public String Branch { get; set; }
        public String INNumber { get; set; }
        public String INDate { get; set; }
        public List<EasyPOSTrnStockInItem> ListPOSIntegrationTrnStockInItem { get; set; }
    }
}
