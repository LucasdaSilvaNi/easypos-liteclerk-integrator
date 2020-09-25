using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkTrnSalesOrder
    {
        public Int32 Id { get; set; }
        public Int32 BranchId { get; set; }
        public LiteclerkMstCompanyBranch Branch { get; set; }
        public String SONumber { get; set; }
        public String SODate { get; set; }
        public String ManualNumber { get; set; }
        public String DocumentReference { get; set; }
        public Int32 CustomerId { get; set; }
        public LiteclerkMstArticleCustomer Customer { get; set; }
        public String CustomerManualCode { get; set; }
        public String CustomerName { get; set; }
        public String Remarks { get; set; }
        public List<LiteclerkTrnSalesOrderItem> SalesOrderItems { get; set; }
    }
}
