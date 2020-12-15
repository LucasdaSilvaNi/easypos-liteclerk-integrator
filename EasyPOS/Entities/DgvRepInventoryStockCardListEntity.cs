using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvRepInventoryStockCardListEntity
    {
        public DateTime ColumnInventoryDate { get; set; }
        public String ColumnDocument { get; set; }
        public String ColumnBegQuantity { get; set; }
        public String ColumnInQuantity { get; set; }
        public String ColumnOutQuantity { get; set; }
        public String ColumnEndingQuantity { get; set; }
        public String ColumnRunningQuantity { get; set; }
    }
}