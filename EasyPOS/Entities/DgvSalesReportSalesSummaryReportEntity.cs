using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvSalesReportSalesSummaryReportEntity
    {
        public Int32 ColumnId { get; set; }
        public Int32 ColumnPeriodId { get; set; }
        public String ColumnPeriod { get; set; }
        public String ColumnSalesDate { get; set; }
        public String ColumnSalesNumber { get; set; }
        public String ColumnManualInvoiceNumber { get; set; }
        public Decimal ColumnAmount { get; set; }
        public Int32? ColumnTableId { get; set; }
        public Int32 ColumnCustomerId { get; set; }
        public String ColumnCustomer { get; set; }
        public Int32 ColumnAccountId { get; set; }
        public Int32 ColumnTermId { get; set; }
        public String ColumnTerm { get; set; }
        public Int32? ColumnDiscountId { get; set; }
        public String ColumnSeniorCitizenId { get; set; }
        public String ColumnSeniorCitizenName { get; set; }
        public Int32? ColumnSeniorCitizenAge { get; set; }
        public String ColumnRemarks { get; set; }
        public Int32? ColumnSalesAgent { get; set; }
        public String ColumnSalesAgentUserName { get; set; }
        public Int32 ColumnTerminalId { get; set; }
        public String ColumnTerminal { get; set; }
        public Int32 ColumnPreparedBy { get; set; }
        public String ColumnPreparedByUserName { get; set; }
        public Int32 ColumnCheckedBy { get; set; }
        public String ColumnCheckedByUserName { get; set; }
        public Int32 ColumnApprovedBy { get; set; }
        public String ColumnApprovedByUserName { get; set; }
        public Boolean ColumnIsLocked { get; set; }
        public Boolean ColumnIsTendered { get; set; }
        public Boolean ColumnIsCancelled { get; set; }
        public Decimal ColumnPaidAmount { get; set; }
        public Decimal ColumnCreditAmount { get; set; }
        public Decimal ColumnDebitAmount { get; set; }
        public Decimal ColumnBalanceAmount { get; set; }
        public Int32 ColumnEntryUserId { get; set; }
        public String ColumnEntryUserName { get; set; }
        public String ColumnEntryDateTime { get; set; }
        public Int32 ColumnUpdateUserId { get; set; }
        public String ColumnUpdatedUserName { get; set; }
        public String ColumnUpdateDateTime { get; set; }
        public Int32? ColumnPax { get; set; }
        public Int32 ColumnTableStatus { get; set; }
    }
}
