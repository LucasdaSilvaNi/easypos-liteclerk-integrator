using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    class RepNetSalesSummaryReportMonthlyEntity
    {
        public Int32 Month { get; set; }
        public Int32 Year { get; set; }
        public Decimal CustomerCount { get; set; }
        public Decimal Quantity { get; set; }
        public Decimal CostAmount { get; set; }
        public Decimal SalesAmount { get; set; }
        public Decimal MarginAmount { get; set; }
        public Decimal Percentage { get; set; }
    }
}
