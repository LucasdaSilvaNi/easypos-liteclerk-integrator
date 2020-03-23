using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvRepSalesReportCancelledSalesSummaryReportListEntity
    {
        public Int32 ColumnId { get; set; }
        public String ColumnTerminal { get; set; }
        public String ColumnCollectionDate { get; set; }
        public String ColumnCancelledCollectionNumber { get; set; }
        public String ColumnCollectionNumber { get; set; }
        public String ColumnCustomerCode { get; set; }
        public String ColumnCustomer { get; set; }
        public String ColumnSalesNumber { get; set; }
        public String ColumnRemarks { get; set; }
        public String ColumnPreparedByUserName { get; set; }
        public String ColumnAmount { get; set; }
    }
}
