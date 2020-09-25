using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkTrnSalesOrderItem
    {
        public Int32 Id { get; set; }
        public Int32 SOId { get; set; }
        public Int32 ItemId { get; set; }
        public LiteclerkMstArticleItem Item { get; set; }
        public String ItemBarCode { get; set; }
        public String Particulars { get; set; }
        public Decimal Quantity { get; set; }
        public Int32 UnitId { get; set; }
        public LiteclerkMstUnit Unit { get; set; }
        public Decimal Price { get; set; }
        public Int32 DiscountId { get; set; }
        public LiteclerkMstDiscount Discount { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal Amount { get; set; }
    }
}
