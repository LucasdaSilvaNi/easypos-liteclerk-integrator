using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvStockCountDetailStockCountLineEntity
    {
        public String ColumnStockCountLineListButtonEdit { get; set; }
        public String ColumnStockCountLineListButtonDelete { get; set; }
        public Int32 ColumnStockCountLineListId { get; set; }
        public Int32 ColumnStockCountLineListStockCountId { get; set; }
        public Int32 ColumnStockCountLineListItemId { get; set; }
        public String ColumnStockCountLineListItemDescription { get; set; }
        public Int32 ColumnStockCountLineListUnitId { get; set; }
        public String ColumnStockCountLineListUnit { get; set; }
        public String ColumnStockCountLineListQuantity { get; set; }
        public String ColumnStockCountLineListCost { get; set; }
        public String ColumnStockCountLineListAmount { get; set; }
    }
}