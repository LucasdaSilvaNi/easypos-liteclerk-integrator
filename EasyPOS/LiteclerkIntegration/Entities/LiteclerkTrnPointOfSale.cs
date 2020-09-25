using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkTrnPointOfSale
    {
        public String BranchCode { get; set; }
        public String TerminalCode { get; set; }
        public String POSDate { get; set; }
        public String POSNumber { get; set; }
        public String OrderNumber { get; set; }
        public String CustomerCode { get; set; }
        public String ItemCode { get; set; }
        public String Particulars { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Price { get; set; }
        public Decimal Discount { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal Amount { get; set; }
        public String TaxCode { get; set; }
        public Decimal TaxAmount { get; set; }
        public String CashierUserCode { get; set; }
        public String TimeStamp { get; set; }
        public String PostCode { get; set; }
    }
}
