using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnStockInLineListEntity
    {
        public String ColumnStockInLineListButtonEdit { get; set; }
        public String ColumnStockInLineListButtonDelete { get; set; }
        public Int32 ColumnStockInLineListStockInId { get; set; }
        public Int32 ColumnStockInLineListItemId { get; set; }
        public Int32 ColumnStockInLineListId { get; set; }
        public String ColumnStockInLineListItemBarcode { get; set; }
        public String ColumnStockInLineListItemDescription { get; set; }
        public Int32 ColumnStockInLineListUnitId { get; set; }
        public String ColumnStockInLineListUnit { get; set; }
        public String ColumnStockInLineListQuantity { get; set; }
        public String ColumnStockInLineListCost { get; set; }
        public String ColumnStockInLineListAmount { get; set; }
        public String ColumnStockInLineListExpiryDate { get; set; }
        public String ColumnStockInLineListLotNumber { get; set; }
        public Int32 ColumnStockInLineListAssetAccountId { get; set; }
        public String ColumnStockInLineListAssetAccount { get; set; }
        public String ColumnStockInLineListPrice { get; set; }
    }
}