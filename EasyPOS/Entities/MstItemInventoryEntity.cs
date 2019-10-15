using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class MstItemInventoryEntity
    {
        public Int32 Id { get; set; }
        public String ItemId { get; set; }
        public String InventoryDate { get; set; }
        public Decimal Quantity { get; set; }
    }
}
