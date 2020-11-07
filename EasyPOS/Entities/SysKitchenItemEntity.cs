using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class SysKitchenItemEntity
    {
        public Int32 SalesId { get; set; }
        public String OrderNumber { get; set; }
        public String BarCode { get; set; }
        public String Alias {get; set; }
        public String Unit { get; set; }
        public Decimal Quantity { get; set; }
        public Boolean? IsPrepared { get; set; }
        public String Preparation { get; set; }
        public String UpdateDateTime { get; set; }
    }
}
