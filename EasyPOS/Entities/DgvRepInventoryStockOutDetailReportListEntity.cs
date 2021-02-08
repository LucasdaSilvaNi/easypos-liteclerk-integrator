using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvRepInventoryStockOutDetailReportListEntity
    {
        public String ColumnItemListCode { get; set; }
        public String ColumnItemListBarcode { get; set; }
        public String ColumnStockOutDate { get; set; }
        public String ColumnStockOutNumber { get; set; }
        public String ColumnManualStockOutNumber { get; set; }
        public String ColumnRemarks { get; set; }
        public String ColumnItem { get; set; }
        public String ColumnUnit { get; set; }
        public String ColumnQuantity { get; set; }
        public String ColumnCost { get; set; }
        public String ColumnAmount { get; set; }
    }
}
