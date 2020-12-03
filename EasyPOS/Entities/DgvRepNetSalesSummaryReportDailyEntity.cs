using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvRepNetSalesSummaryReportDailyEntity
    {
        public String ColumnNetSalesSummaryDate { get; set; }
        public String ColumnNetSalesSummaryCustomerCount { get; set; }
        public String ColumnNetSalesSummaryQuantity { get; set; }
        public String ColumnNetSalesSummaryCostAmount { get; set; }
        public String ColumnNetSalesSummarySalesAmount { get; set; }
        public String ColumnNetSalesSummaryMarginAmount { get; set; }
        public String ColumnNetSalesSummaryPercentage { get; set; }
    }
}
