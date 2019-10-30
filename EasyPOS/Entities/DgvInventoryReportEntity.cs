using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvInventoryReportEntity
    {
        public String ItemDescription { get; set; }
        public String Unit { get; set; }
        public String BegQuantity { get; set; }
        public String InQuantity { get; set; }
        public String OutQuantity { get; set; }
        public String EndingQuantity { get; set; }
        public String ColumnStockCount { get; set; }
        public String ColumnVariance { get; set; }
        public String ColumnCost { get; set; }
        public String ColumnAmount { get; set; }
    }
}
