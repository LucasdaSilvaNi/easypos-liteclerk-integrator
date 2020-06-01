using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnStockInListEntity
    {
        public String ColumnStockInListButtonEdit { get; set; }
        public String ColumnStockInListButtonDelete { get; set; }
        public Int32 ColumnStockInListId { get; set; }
        public String ColumnStockInListStockInDate { get; set; }
        public String ColumnStockInListStockInNumber { get; set; }
        public String ColumnStockInListManualStockInNumber { get; set; }
        public String ColumnStockInListSupplier { get; set; }
        public String ColumnStockInListRemarks { get; set; }
        public Boolean ColumnStockInListIsLocked { get; set; }
    }
}