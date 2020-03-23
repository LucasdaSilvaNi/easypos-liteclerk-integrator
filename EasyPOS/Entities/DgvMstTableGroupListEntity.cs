using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvMstTableGroupListEntity
    {
        public String ColumnTableGroupListButtonEdit { get; set; }
        public String ColumnTableGroupListButtonDelete { get; set; }
        public Int32 ColumnTableGroupListId { get; set; }
        public String ColumnTableGroupListTableGroup { get; set; }
        public Boolean ColumnTableGroupListIsLocked { get; set; }
    }
}
