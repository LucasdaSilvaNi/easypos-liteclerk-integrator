using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepCancelledSalesReport
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ====================
        // Sales Summary Report
        // ====================
        public List<Entities.TrnSalesEntity> ListSales(DateTime startDate, DateTime endDate)
        {
            var sales = from d in db.TrnSales
                        where d.SalesDate >= startDate
                        && d.SalesDate <= endDate
                        && d.IsLocked == true
                        && d.IsCancelled == true
                        select new Entities.TrnSalesEntity
                        {
                            Id = d.Id,
                            PeriodId = d.PeriodId,
                            Period = d.MstPeriod.Period,
                            SalesDate = d.SalesDate.ToShortDateString(),
                            SalesNumber = d.SalesNumber,
                            ManualInvoiceNumber = d.ManualInvoiceNumber,
                            Amount = d.Amount,
                            TableId = d.TableId,
                            CustomerId = d.CustomerId,
                            Customer = d.MstCustomer.Customer,
                            AccountId = d.AccountId,
                            TermId = d.TermId,
                            Term = d.MstTerm.Term,
                            DiscountId = d.DiscountId,
                            SeniorCitizenId = d.SeniorCitizenId,
                            SeniorCitizenName = d.SeniorCitizenName,
                            SeniorCitizenAge = d.SeniorCitizenAge,
                            Remarks = d.Remarks,
                            SalesAgent = d.SalesAgent,
                            SalesAgentUserName = d.SalesAgent != null ? d.MstUser5.UserName : "",
                            TerminalId = d.TerminalId,
                            Terminal = d.MstTerminal.Terminal,
                            PreparedBy = d.PreparedBy,
                            PreparedByUserName = d.MstUser.FullName,
                            CheckedBy = d.CheckedBy,
                            CheckedByUserName = d.MstUser1.FullName,
                            ApprovedBy = d.ApprovedBy,
                            ApprovedByUserName = d.MstUser2.FullName,
                            IsLocked = d.IsLocked,
                            IsTendered = d.IsTendered,
                            IsCancelled = d.IsCancelled,
                            PaidAmount = d.PaidAmount,
                            CreditAmount = d.CreditAmount,
                            DebitAmount = d.DebitAmount,
                            BalanceAmount = d.BalanceAmount,
                            EntryUserId = d.EntryUserId,
                            EntryUserName = d.MstUser3.FullName,
                            EntryDateTime = d.EntryDateTime.ToShortDateString(),
                            UpdateUserId = d.UpdateUserId,
                            UpdatedUserName = d.MstUser4.FullName,
                            UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                            Pax = d.Pax,
                            TableStatus = d.TableStatus,
                            Table = d.MstTable.TableCode
                        };

            return sales.OrderByDescending(d => d.Id).ToList();
        }
    }
}
