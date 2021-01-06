using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class RepUnsoldItemEntity
    {
        public String BarCode { get; set; }
        public String ItemDescription { get; set; }
        public String ItemCategory { get; set; }
        public String Unit { get; set; }
        public Decimal Price { get; set; }
        public Decimal Cost { get; set; }
    }
}
