using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class EspCardDetailsEntity
    {
        public String FullName { get; set; }
        public Decimal Balance { get; set; }
        public String SourceCardNumber { get; set; }
        public String DestinationCardNumber { get; set; }
        public Decimal Amount { get; set; }
        public String Particulars { get; set; }
    }
}
