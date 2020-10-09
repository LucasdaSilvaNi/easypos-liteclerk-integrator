using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvMstUserListEntity
    {
        public String ColumnUserListButtonEdit { get; set; }
        public String ColumnUserListButtonDelete { get; set; }
        public Int32 ColumnUserListId { get; set; }
        public String ColumnUserListUserName { get; set; }
        public String ColumnUserListFullName { get; set; }
        public Boolean ColumnUserListIsLocked { get; set; }
    }
}
