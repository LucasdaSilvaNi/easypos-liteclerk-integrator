using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
   public class DgvTrnPurchaseOrderSearchItemListEntity
    {
        public Int32 ColumnSearchItemListId { get; set; }
        public String ColumnSearchItemListBarCode { get; set; }
        public String ColumnSearchItemListDescription { get; set; }
        public String ColumnSearchItemListGenericName { get; set; }
        public Int32 ColumnSearchItemListOutTaxId { get; set; }
        public String ColumnSearchItemListOutTax { get; set; }
        public String ColumnSearchItemListOutTaxRate { get; set; }
        public Int32 ColumnSearchItemListUnitId { get; set; }
        public String ColumnSearchItemListUnit { get; set; }
        public String ColumnSearchItemListPrice { get; set; }
        public String ColumnSearchItemListCost { get; set; }
        public String ColumnSearchItemListOnhandQuantity { get; set; }
        public String ColumnSearchItemListButtonPick { get; set; }

    }
}
