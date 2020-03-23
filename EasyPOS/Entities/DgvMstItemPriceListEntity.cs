using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvMstItemPriceListEntity
    {
        public String ColumnItemPriceListButtonEdit { get; set; }
        public String ColumnItemPriceListButtonDelete { get; set; }
        public Int32 ColumnItemPriceListId { get; set; }
        public String ColumnItemPriceListPriceDescription { get; set; }
        public String ColumnItemPriceListPrice { get; set; }
        public String ColumnItemPriceListTriggerQuantity { get; set; }
    }
}