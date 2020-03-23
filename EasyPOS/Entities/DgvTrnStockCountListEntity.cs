using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnStockCountListEntity
    {
        public String ColumnStockCountListButtonEdit { get; set; }
        public String ColumnStockCountListButtonDelete { get; set; }
        public Int32 ColumnStockCountListId { get; set; }
        public String ColumnStockCountListStockCountDate { get; set; }
        public String ColumnStockCountListStockCountNumber { get; set; }
        public String ColumnStockCountListRemarks { get; set; }
        public Boolean ColumnStockCountListIsLocked { get; set; }
    }
}