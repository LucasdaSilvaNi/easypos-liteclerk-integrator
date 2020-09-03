using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class MstItemGroupItemEntity
    {
        public Int32 Id { get; set; }
        public Int32 ItemId { get; set; }
        public String Barcode { get; set; }
        public String ItemDescription { get; set; }
        public String Alias { get; set; }
        public Int32 ItemGroupId { get; set; }
        public Boolean? Show { get; set; }
    }
}
