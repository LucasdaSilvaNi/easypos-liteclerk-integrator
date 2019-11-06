using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvInventoryReportStockInDetailReportEntity
    {
        public String ColumnStockInDate { get; set; }
        public String ColumnStockInNumber { get; set; }
        public String ColumnRemarks { get; set; }
        public Boolean ColumnIsReturn { get; set; }
        public String ColumnItem { get; set; }
        public String ColumnUnit { get; set; }
        public String ColumnQuantity { get; set; }
        public String ColumnCost { get; set; }
        public String ColumnAmount { get; set; }
        public String ColumnExpiryDate { get; set; }
        public String ColumnLotNumber { get; set; }
        public String ColumnSellingPrice { get; set; }
    }
}
