using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepSalesReportController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ======================
        // Dropdown List Terminal
        // ======================
        public List<Entities.MstTerminalEntity> DropdownListTerminal()
        {
            var terminals = from d in db.MstTerminals
                            select new Entities.MstTerminalEntity
                            {
                                Id = d.Id,
                                Terminal = "Terminal: " + d.Terminal
                            };

            return terminals.ToList();
        }

        // ======================
        // Dropdown List Customer
        // ======================
        public List<Entities.MstCustomerEntity> DropdownListCustomer()
        {
            var customers = from d in db.MstCustomers
                            select new Entities.MstCustomerEntity
                            {
                                Id = d.Id,
                                Customer = d.Customer
                            };

            return customers.ToList();
        }

        // ====================
        // Sales Summary Report
        // ====================
        public List<Entities.RepSalesReportSalesSummaryReportEntity> SalesSummaryReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var sales = from d in db.TrnSales.OrderByDescending(d => d.Id)
                        where d.SalesDate >= startDate
                        && d.SalesDate <= endDate
                        && d.TerminalId == terminalId
                        && d.IsLocked == true
                        && d.IsCancelled == false
                        && d.IsReturned == false
                        select new Entities.RepSalesReportSalesSummaryReportEntity
                        {
                            Id = d.Id,
                            Terminal = d.MstTerminal.Terminal,
                            SalesDate = d.SalesDate.ToShortDateString(),
                            SalesNumber = d.SalesNumber,
                            CustomerCode = d.MstCustomer.CustomerCode,
                            Customer = d.MstCustomer.Customer,
                            Term = d.MstTerm.Term,
                            Remarks = d.Remarks,
                            PreparedByUserName = d.MstUser.FullName,
                            Amount = d.Amount
                        };

            return sales.OrderByDescending(d => d.Id).ToList();
        }

        // ===================
        // Sales Detail Report
        // ===================
        public List<Entities.RepSalesReportSalesDetailReportEntity> SalesDetailReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var salesLines = from d in db.TrnSalesLines
                             where d.TrnSale.SalesDate >= startDate
                             && d.TrnSale.SalesDate <= endDate
                             && d.TrnSale.TerminalId == terminalId
                             && d.TrnSale.IsLocked == true
                             && d.TrnSale.IsCancelled == false
                             && d.TrnSale.IsReturned == false
                             select new Entities.RepSalesReportSalesDetailReportEntity
                             {
                                 Id = d.Id,
                                 Terminal = d.TrnSale.MstTerminal.Terminal,
                                 Date = d.TrnSale.SalesDate.ToShortDateString(),
                                 SalesNumber = d.TrnSale.SalesNumber,
                                 CustomerCode = d.TrnSale.MstCustomer.CustomerCode,
                                 Customer = d.TrnSale.MstCustomer.Customer,
                                 ItemCode = d.MstItem.ItemCode,
                                 ItemDescription = d.MstItem.ItemDescription,
                                 ItemCategory = d.MstItem.Category,
                                 Quantity = d.Quantity,
                                 Unit = d.MstUnit.Unit,
                                 Price = d.Price,
                                 Discount = d.MstDiscount.Discount,
                                 NetPrice = d.NetPrice,
                                 Amount = d.Amount,
                                 Tax = d.MstTax.Tax,
                                 TaxRate = d.TaxRate,
                                 TaxAmount = d.TaxAmount
                             };

            return salesLines.ToList();
        }

        // =========================
        // Collection Summary Report
        // =========================
        public List<Entities.RepSalesReportCollectionSummaryReportEntity> CollectionSummaryReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var collections = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                              where d.CollectionDate >= startDate
                              && d.CollectionDate <= endDate
                              && d.TerminalId == terminalId
                              && d.IsLocked == true
                              select new Entities.RepSalesReportCollectionSummaryReportEntity
                              {
                                  Id = d.Id,
                                  Terminal = d.MstTerminal.Terminal,
                                  CollectionDate = d.CollectionDate.ToShortDateString(),
                                  CollectionNumber = d.CollectionNumber,
                                  CustomerCode = d.MstCustomer.CustomerCode,
                                  Customer = d.MstCustomer.Customer,
                                  SalesNumber = d.TrnSale.SalesNumber,
                                  Remarks = d.Remarks,
                                  PreparedByUserName = d.MstUser.UserName,
                                  IsCancelled = d.IsCancelled,
                                  Amount = d.IsCancelled == true ? 0 : d.Amount
                              };

            return collections.ToList();
        }

        // ========================
        // Collection Detail Report
        // ========================
        public List<Entities.RepSalesReportCollectionDetailReportEntity> CollectionDetailReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var collectionLines = from d in db.TrnCollectionLines
                                  where d.TrnCollection.CollectionDate >= startDate
                                  && d.TrnCollection.CollectionDate <= endDate
                                  && d.TrnCollection.TerminalId == terminalId
                                  && d.TrnCollection.IsLocked == true
                                  select new Entities.RepSalesReportCollectionDetailReportEntity
                                  {
                                      Id = d.Id,
                                      Terminal = d.TrnCollection.MstTerminal.Terminal,
                                      CollectionDate = d.TrnCollection.CollectionDate.ToShortDateString(),
                                      CollectionNumber = d.TrnCollection.CollectionNumber,
                                      CustomerCode = d.TrnCollection.MstCustomer.CustomerCode,
                                      Customer = d.TrnCollection.MstCustomer.Customer,
                                      SalesNumber = d.TrnCollection.TrnSale.SalesNumber,
                                      PayType = d.MstPayType.PayType,
                                      Amount = d.TrnCollection.IsCancelled == true ? 0 : d.MstPayType.PayType.Equals("Cash") ? d.Amount - d.TrnCollection.ChangeAmount : d.Amount,
                                      CheckNumber = d.CheckNumber,
                                      CheckDate = d.CheckDate.ToString(),
                                      CheckBank = d.CheckBank,
                                      OtherInformation = d.OtherInformation
                                  };

            return collectionLines.ToList();
        }

        // ==============================
        // Cancelled Sales Summary Report
        // ==============================
        public List<Entities.RepSalesReportCollectionSummaryReportEntity> CancelledSalesSummaryReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var cancelledCollections = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                                       where d.CollectionDate >= startDate
                                       && d.CollectionDate <= endDate
                                       && d.TerminalId == terminalId
                                       && d.IsLocked == true
                                       && d.IsCancelled == true
                                       select new Entities.RepSalesReportCollectionSummaryReportEntity
                                       {
                                           Id = d.Id,
                                           Terminal = d.MstTerminal.Terminal,
                                           CollectionDate = d.CollectionDate.ToShortDateString(),
                                           CancelledCollectionNumber = d.CancelledCollectionNumber,
                                           CollectionNumber = d.CollectionNumber,
                                           CustomerCode = d.MstCustomer.CustomerCode,
                                           Customer = d.MstCustomer.Customer,
                                           SalesNumber = d.TrnSale.SalesNumber,
                                           Remarks = d.Remarks,
                                           PreparedByUserName = d.MstUser.UserName,
                                           Amount = d.Amount
                                       };

            return cancelledCollections.ToList();
        }

        // =======================
        // Stock Withdrawal Report
        // =======================
        public List<Entities.RepSalesReportCollectionSummaryReportEntity> StockWithdrawalReport(DateTime startDate, DateTime endDate, Int32 terminalId, Int32 customerId)
        {
            var stockWithdrawalReports = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                                         where d.CollectionDate >= startDate
                                         && d.CollectionDate <= endDate
                                         && d.TerminalId == terminalId
                                         && d.CustomerId == customerId
                                         && d.IsLocked == true
                                         && d.IsCancelled == false
                                         && d.SalesId != null
                                         select new Entities.RepSalesReportCollectionSummaryReportEntity
                                         {
                                             Id = d.Id,
                                             SalesId = d.SalesId,
                                             CollectionNumber = d.CollectionNumber
                                         };

            return stockWithdrawalReports.ToList();
        }

        // ========================
        // Top Selling Item Reports
        // ========================
        public List<Entities.RepSalesReportTopSellingItemsReportEntity> TopSellingItemsReport(DateTime startDate, DateTime endDate)
        {
            var topSellingItems = from d in db.TrnSalesLines
                                  where d.TrnSale.SalesDate >= startDate
                                  && d.TrnSale.SalesDate <= endDate
                                  && d.TrnSale.IsLocked == true
                                  && d.TrnSale.IsCancelled == false
                                  && d.TrnSale.IsReturned == false
                                  group d by new
                                  {
                                      d.MstItem.ItemCode,
                                      d.MstItem.ItemDescription,
                                      d.MstItem.Category,
                                      d.MstUnit.Unit,
                                      d.Price
                                  } into g
                                  select new Entities.RepSalesReportTopSellingItemsReportEntity
                                  {
                                      ItemCode = g.Key.ItemCode,
                                      ItemDescription = g.Key.ItemDescription,
                                      ItemCategory = g.Key.Category,
                                      Quantity = g.Sum(d => d.Quantity),
                                      Unit = g.Key.Unit,
                                      Price = g.Key.Price,
                                      Amount = g.Sum(d => d.Amount)
                                  };

            return topSellingItems.OrderByDescending(d => d.Quantity).ToList();
        }
    }
}