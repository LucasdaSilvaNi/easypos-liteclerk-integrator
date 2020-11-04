using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnStockCountSearchItemListEntity
    {
        public int ColumnSearchItemListId { get; set; }
        public string ColumnSearchItemListBarCode { get; set; }
        public string ColumnSearchItemListDescription { get; set; }
        public string ColumnSearchItemListGenericName { get; set; }
        public string ColumnSearchItemListCost { get; set; }
        public int ColumnSearchItemListOutTaxId { get; set; }
        public string ColumnSearchItemListOutTax { get; set; }
        public string ColumnSearchItemListOutTaxRate { get; set; }
        public int ColumnSearchItemListUnitId { get; set; }
        public string ColumnSearchItemListUnit { get; set; }
        public string ColumnSearchItemListPrice { get; set; }
        public string ColumnSearchItemListOnhandQuantity { get; set; }
        public string ColumnSearchItemListButtonPick { get; set; }
    }
}