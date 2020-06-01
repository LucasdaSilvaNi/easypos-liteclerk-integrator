using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvStockOutListStockOutEntity
    {
        public String ColumnStockOutListButtonEdit { get; set; }
        public String ColumnStockOutListButtonDelete { get; set; }
        public Int32 ColumnStockOutListId { get; set; }
        public String ColumnStockOutListStockOutDate { get; set; }
        public String ColumnStockOutListStockOutNumber { get; set; }
        public String ColumnStockOutListManualStockOutNumber { get; set; }
        public String ColumnStockOutListRemarks { get; set; }
        public Boolean ColumnStockOutListIsLocked { get; set; }
    }
}