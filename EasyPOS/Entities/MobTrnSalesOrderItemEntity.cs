using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class MobTrnSalesOrderItemEntity
    {
        public String ItemCode { get; set; }
        public String ItemDescription { get; set; }
        public String Particulars { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal Price { get; set; }
        public String Discount { get; set; }
        public Decimal DiscountRate { get; set; }
        public Decimal DiscountAmount { get; set; }
        public Decimal NetPrice { get; set; }
        public Decimal Amount { get; set; }
    }
}
