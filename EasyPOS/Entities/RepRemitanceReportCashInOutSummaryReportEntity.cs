using EasyPOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class RepRemitanceReportCashInOutSummaryReportEntity
    {
        public Int32 Id { get; set; }
        public String DisbursementDate { get; set; }
        public String DisbursementNumber { get; set; }
        public String DisbursementType { get; set; }
        public String Remarks { get; set; }
        public String PayType { get; set; }
        public String User { get; set; }
        public Decimal Amount { get; set; }
    }
}
