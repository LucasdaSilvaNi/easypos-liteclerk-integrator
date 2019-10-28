using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepSalesReportController
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ====================
        // Sales Summary Report
        // ====================
        public List<Entities.TrnSalesEntity> SalesSummaryList(DateTime startDate, DateTime endDate)
        {
            var sales = from d in db.TrnSales
                        where d.SalesDate >= startDate 
                        && d.SalesDate <= endDate 
                        && d.IsLocked == true 
                        && d.IsCancelled == false
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

        // ====================
        // Sales Summary Report
        // ====================
        public List<Entities.TrnSalesEntity> CancelSalesSummaryList(DateTime startDate, DateTime endDate)
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

        // ===================
        // Sales Detail Report
        // ===================
        public List<Entities.RepSalesDetailReportEntity> SalesDetailList(DateTime startDate, DateTime endDate)
        {
            var salesDetails = from d in db.TrnSalesLines
                               where d.TrnSale.SalesDate >= startDate
                               && d.TrnSale.SalesDate <= endDate
                               && d.TrnSale.IsLocked == true
                               && d.TrnSale.IsCancelled == false
                               select new Entities.RepSalesDetailReportEntity
                               {
                                   Id = d.Id,
                                   SalesId = d.SalesId,
                                   Terminal = d.TrnSale.MstTerminal.Terminal,
                                   Date = d.TrnSale.SalesDate.ToShortDateString(),
                                   SalesNumber = d.TrnSale.SalesNumber,
                                   Customer = d.TrnSale.MstCustomer.Customer,
                                   ItemId = d.ItemId,
                                   ItemDescription = d.MstItem.ItemDescription,
                                   ItemCode = d.MstItem.ItemCode,
                                   ItemCategory = d.MstItem.Category,
                                   UnitId = d.UnitId,
                                   Unit = d.MstUnit.Unit,
                                   Price = d.Price,
                                   DiscountId = d.DiscountId,
                                   Discount = d.MstDiscount.Discount,
                                   DiscountRate = d.DiscountRate,
                                   DiscountAmount = d.DiscountAmount,
                                   NetPrice = d.NetPrice,
                                   Quantity = d.Quantity,
                                   Amount = d.Amount,
                                   TaxId = d.TaxId,
                                   Tax = d.MstTax.Tax,
                                   TaxRate = d.TaxRate,
                                   TaxAmount = d.TaxAmount,
                                   SalesLineTimeStamp = d.SalesLineTimeStamp.ToShortDateString(),
                                   UserId = d.UserId,
                                   User = d.MstUser.FullName
                               };

            return salesDetails.OrderByDescending(d => d.Id).ToList();
        }
    }
}
