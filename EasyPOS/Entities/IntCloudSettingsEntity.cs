using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class IntCloudSettingsEntity
    {
        public Int32 Id { get; set; }
        public String BranchCode { get; set; }
        public String UserCode { get; set; }
        public Int32 PostUserId { get; set; }
        public Int32 PostSupplierId { get; set; }
        public Boolean UseItemPrice { get; set; }
        public String Domain { get; set; }
        public String LogFileLocation { get; set; }
        public String Application { get; set; }
    }
}
