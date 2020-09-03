using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvMstItemGroupItemListEntity
    {
        public String ColumnItemGroupItemListButtonEdit { get; set; }
        public String ColumnItemGroupItemListButtonDelete { get; set; }
        public Int32 ColumnItemGroupItemListId { get; set; }
        public Int32 ColumnItemGroupItemListItemId { get; set; }
        public String ColumnItemGroupItemListItemDescription { get; set; }
        public Int32 ColumnItemGroupItemListItemGroupId { get; set; }
        public Boolean ColumnItemGroupItemListShow { get; set; }

    }
}