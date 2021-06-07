using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnStockOutLineListEntity
    {
        public String ColumnStockOutLineListButtonEdit { get; set; }
        public String ColumnStockOutLineListButtonDelete { get; set; }
        public Int32 ColumnStockOutLineListId { get; set; }
        public Int32 ColumnStockOutLineListStockOutId { get; set; }
        public Int32 ColumnStockOutLineListItemId { get; set; }
        public String ColumnStockOutLineListItemBarcode { get; set; }
        public String ColumnStockOutLineListItemDescription { get; set; }
        public Int32 ColumnStockOutLineListUnitId { get; set; }
        public String ColumnStockOutLineListUnit { get; set; }
        public String ColumnStockOutLineListQuantity { get; set; }
        public String ColumnStockOutLineListCost { get; set; }
        public String ColumnStockOutLineListAmount { get; set; }
        public Int32 ColumnStockOutLineListAssetAccountId { get; set; }
        public String ColumnStockOutLineListAssetAccount { get; set; }
        public String ColumnStockOutLineListPrice { get; set; }
    }
}