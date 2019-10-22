using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepSalesSummaryReportController
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List - Sales 
        // ============
        public List<Entities.DgvSalesSummaryReportEntity> ListSales(DateTime startDate, DateTime endDate)
        {
            var sales = from d in db.TrnSales
                        where d.SalesDate >= startDate && d.SalesDate <= endDate
                        select new Entities.DgvSalesSummaryReportEntity
                        {
                            ColumnId = d.Id,
                            ColumnPeriodId = d.PeriodId,
                            ColumnPeriod = d.MstPeriod.Period,
                            ColumnSalesDate = d.SalesDate.ToShortDateString(),
                            ColumnSalesNumber = d.SalesNumber,
                            ColumnManualInvoiceNumber = d.ManualInvoiceNumber,
                            ColumnAmount = d.Amount,
                            ColumnTableId = d.TableId,
                            ColumnCustomerId = d.CustomerId,
                            ColumnCustomer = d.MstCustomer.Customer,
                            ColumnAccountId = d.AccountId,
                            ColumnTermId = d.TermId,
                            ColumnTerm = d.MstTerm.Term,
                            ColumnDiscountId = d.DiscountId,
                            ColumnSeniorCitizenId = d.SeniorCitizenId,
                            ColumnSeniorCitizenName = d.SeniorCitizenName,
                            ColumnSeniorCitizenAge = d.SeniorCitizenAge,
                            ColumnRemarks = d.Remarks,
                            ColumnSalesAgent = d.SalesAgent,
                            ColumnSalesAgentUserName = d.SalesAgent != null ? d.MstUser5.UserName : "",
                            ColumnTerminalId = d.TerminalId,
                            ColumnTerminal = d.MstTerminal.Terminal,
                            ColumnPreparedBy = d.PreparedBy,
                            ColumnPreparedByUserName = d.MstUser.FullName,
                            ColumnCheckedBy = d.CheckedBy,
                            ColumnCheckedByUserName = d.MstUser1.FullName,
                            ColumnApprovedBy = d.ApprovedBy,
                            ColumnApprovedByUserName = d.MstUser2.FullName,
                            ColumnIsLocked = d.IsLocked,
                            ColumnIsTendered = d.IsTendered,
                            ColumnIsCancelled = d.IsCancelled,
                            ColumnPaidAmount = d.PaidAmount,
                            ColumnCreditAmount = d.CreditAmount,
                            ColumnDebitAmount = d.DebitAmount,
                            ColumnBalanceAmount = d.BalanceAmount,
                            ColumnEntryUserId = d.EntryUserId,
                            ColumnEntryUserName = d.MstUser3.FullName,
                            ColumnEntryDateTime = d.EntryDateTime.ToShortDateString(),
                            ColumnUpdateUserId = d.UpdateUserId,
                            ColumnUpdatedUserName = d.MstUser4.FullName,
                            ColumnUpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                            ColumnPax = d.Pax,
                            ColumnTableStatus = d.TableStatus,
                        };

            return sales.OrderByDescending(d => d.ColumnId).ToList();
        }
    }
}
