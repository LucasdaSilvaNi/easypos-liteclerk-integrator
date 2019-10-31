using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    class RepInventoryReportUnionEntity
    {
        public String ItemDescription { get; set; }
        public String Unit { get; set; }
        public Decimal BegQuantity { get; set; }
        public Decimal InQuantity { get; set; }
        public Decimal OutQuantity { get; set; }
        public Decimal EndingQuantity { get; set; }
        public Decimal CountQuantity { get; set; }
        public Decimal Variance { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Amount { get; set; }
    }
}
