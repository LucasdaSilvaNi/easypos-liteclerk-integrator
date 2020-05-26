using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class MobTrnSalesOrderEntity
    {
        public String SONumber { get; set; }
        public String SODate { get; set; }
        public String DocumentReference { get; set; }
        public String Remarks { get; set; }
        public List<MobTrnSalesOrderItemEntity> ListSalesOrderItems { get; set; }
    }
}
