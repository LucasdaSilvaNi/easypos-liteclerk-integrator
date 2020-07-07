using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.EasyFISIntegration.Entities
{
    class EasyPOSMstItem
    {
        public String ManualArticleCode { get; set; }
        public String Article { get; set; }
        public String Category { get; set; }
        public String Unit { get; set; }
        public Decimal Price { get; set; }
        public Decimal Cost { get; set; }
        public Boolean IsInventory { get; set; }
        public String Particulars { get; set; }
        public String OutputTax { get; set; }
        public List<EasyPOSMstItemPrice> ListItemPrice { get; set; }
    }
}
