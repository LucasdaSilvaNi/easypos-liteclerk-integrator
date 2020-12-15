using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    class RepInventoryReportStockCardEntity
    {
        public DateTime InventoryDate { get; set; }
        public String Document { get; set; }
        public Decimal BeginningQuantity { get; set; }
        public Decimal InQuantity { get; set; }
        public Decimal OutQuantity { get; set; }
        public Decimal EndingQuantity { get; set; }
        public Decimal RunningQuantity { get; set; }
    }
}
