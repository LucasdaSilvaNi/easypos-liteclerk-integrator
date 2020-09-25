using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkTrnStockIn
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public LiteclerkMstCompanyBranch Branch { get; set; }
        public String INNumber { get; set; }
        public String INDate { get; set; }
        public String ManualNumber { get; set; }
        public String DocumentReference { get; set; }
        public String Remarks { get; set; }
        public List<LiteclerkTrnStockInItem> StockInItems { get; set; }
    }
}
