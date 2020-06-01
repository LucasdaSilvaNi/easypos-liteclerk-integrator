using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class TrnSalesEntity
    {
        public Int32 Id { get; set; }
        public Int32 PeriodId { get; set; }
        public String Period { get; set; }
        public String SalesDate { get; set; }
        public String SalesNumber { get; set; }
        public String ManualInvoiceNumber { get; set; }
        public String CollectionNumber { get; set; }
        public Decimal Amount { get; set; }
        public Int32? TableId { get; set; }
        public Int32 CustomerId { get; set; }
        public String CustomerCode { get; set; }
        public String Customer { get; set; }
        public Int32 AccountId { get; set; }
        public Int32 TermId { get; set; }
        public String Term { get; set; }
        public Int32? DiscountId { get; set; }
        public String SeniorCitizenId { get; set; }
        public String SeniorCitizenName { get; set; }
        public Int32? SeniorCitizenAge { get; set; }
        public String Remarks { get; set; }
        public Int32? SalesAgent { get; set; }
        public String SalesAgentUserName { get; set; }
        public Int32 TerminalId { get; set; }
        public String Terminal { get; set; }
        public Int32 PreparedBy { get; set; }
        public String PreparedByUserName { get; set; }
        public Int32 CheckedBy { get; set; }
        public String CheckedByUserName { get; set; }
        public Int32 ApprovedBy { get; set; }
        public String ApprovedByUserName { get; set; }
        public Boolean IsLocked { get; set; }
        public Boolean IsTendered { get; set; }
        public Boolean IsCancelled { get; set; }
        public Decimal PaidAmount { get; set; }
        public Decimal CreditAmount { get; set; }
        public Decimal DebitAmount { get; set; }
        public Decimal BalanceAmount { get; set; }
        public Int32 EntryUserId { get; set; }
        public String EntryUserName { get; set; }
        public String EntryDateTime { get; set; }
        public Int32 UpdateUserId { get; set; }
        public String UpdatedUserName { get; set; }
        public String UpdateDateTime { get; set; }
        public Int32? Pax { get; set; }
        public Int32 TableStatus { get; set; }
        public String Table { get; set; }
    }
}
