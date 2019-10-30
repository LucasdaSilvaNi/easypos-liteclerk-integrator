using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvSalesReportCancelSalesReportEntity
    {
        public Int32 ColumnId { get; set; }
        public Int32 ColumnPeriodId { get; set; }
        public String ColumnPeriod { get; set; }
        public String ColumnTerminal { get; set; }
        public String ColumnSalesDate { get; set; }
        public String ColumnSalesNumber { get; set; }
        public String ColumnManualInvoiceNumber { get; set; }
        public Int32? ColumnTableId { get; set; }
        public Int32 ColumnCustomerId { get; set; }
        public String ColumnCustomer { get; set; }
        public Int32 ColumnAccountId { get; set; }
        public Int32 ColumnTermId { get; set; }
        public String ColumnTerm { get; set; }
        public Int32? ColumnDiscountId { get; set; }
        public String ColumnRemarks { get; set; }
        public String ColumnAmount { get; set; }
        public Int32 ColumnTerminalId { get; set; }
        public Int32 ColumnPreparedBy { get; set; }
        public String ColumnPreparedByUserName { get; set; }
        public Int32? ColumnPax { get; set; }
        public String ColumnTable { get; set; }
    }
}
