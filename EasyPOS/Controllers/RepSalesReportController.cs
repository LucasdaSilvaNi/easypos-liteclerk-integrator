using System;
using System.Collections.Generic;
using System.Globalization;
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
                            Amount = d.Amount,
                            EntryDateTime = d.EntryDateTime.ToShortTimeString()

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
                                 DiscountAmount = d.DiscountAmount,
                                 NetPrice = d.NetPrice,
                                 Amount = d.Amount,
                                 Tax = d.MstTax.Tax,
                                 TaxRate = d.TaxRate,
                                 TaxAmount = d.TaxAmount
                             };

            return salesLines.ToList();
        }
        // ================================
        // Net Sales Summary Report - Daily
        // ================================
        public List<Entities.RepNetSalesSummaryReportDailyEntity> GetNetSalesSummaryReportDaily(DateTime startDate, DateTime endDate)
        {
            var netSalesDaily = from d in db.TrnSalesLines
                                where d.TrnSale.SalesDate >= startDate
                                && d.TrnSale.SalesDate <= endDate
                                && d.TrnSale.IsLocked == true
                                && d.TrnSale.IsCancelled == false
                                group d by new
                                {
                                    d.TrnSale.SalesDate
                                } into g
                                select new Entities.RepNetSalesSummaryReportDailyEntity
                                {
                                    Date = g.Key.SalesDate,
                                    CustomerCount = g.GroupBy(x => x.TrnSale.Id).Count(),
                                    Quantity = g.Sum(x => x.Quantity),
                                    CostAmount = g.Sum(x => x.MstItem.Cost) * g.Sum(x => x.Quantity),
                                    SalesAmount = g.Sum(x => x.Amount),
                                    MarginAmount = g.Sum(x => x.Amount) - (g.Sum(x => x.MstItem.Cost) * g.Sum(x => x.Quantity)),
                                    Percentage = ((g.Sum(x => x.Amount) - (g.Sum(x => x.MstItem.Cost) * g.Sum(x => x.Quantity))) / g.Sum(x => x.Amount)) * 100
                                };

            return netSalesDaily.OrderBy(d => d.Date).ToList();
        }

        // ==================================
        // Net Sales Summary Report - Monthly
        // ==================================
        public List<Entities.RepNetSalesSummaryReportMonthlyEntity> GetNetSalesSummaryReportMonthly(DateTime startDate, DateTime endDate)
        {
            var netSalesDaily = from d in db.TrnSalesLines
                                where d.TrnSale.SalesDate >= startDate
                                && d.TrnSale.SalesDate <= endDate
                                && d.TrnSale.IsLocked == true
                                && d.TrnSale.IsCancelled == false
                                group d by new
                                {
                                    d.TrnSale.SalesDate.Month,
                                    d.TrnSale.SalesDate.Year
                                } into g
                                select new Entities.RepNetSalesSummaryReportMonthlyEntity
                                {
                                    Month = g.Key.Month,
                                    Year = g.Key.Year,
                                    CustomerCount = g.GroupBy(x => x.TrnSale.Id).Count(),
                                    Quantity = g.Sum(x => x.Quantity),
                                    CostAmount = g.Sum(x => x.MstItem.Cost) * g.Sum(x => x.Quantity),
                                    SalesAmount = g.Sum(x => x.Amount),
                                    MarginAmount = g.Sum(x => x.Amount) - (g.Sum(x => x.MstItem.Cost) * g.Sum(x => x.Quantity)),
                                    Percentage = ((g.Sum(x => x.Amount) - (g.Sum(x => x.MstItem.Cost) * g.Sum(x => x.Quantity))) / g.Sum(x => x.Amount)) * 100
                                };

            return netSalesDaily.OrderBy(d => d.Month).ToList();
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
                                  Amount = d.Amount,
                                  EntryDateTime = d.EntryDateTime.ToShortTimeString()
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
                                      ChangeAmount = d.TrnCollection.ChangeAmount,
                                      IsCancelled = d.TrnCollection.IsCancelled,
                                      SalesNumber = d.TrnCollection.TrnSale.SalesNumber,
                                      PayTypeCode = d.MstPayType.PayTypeCode,
                                      PayType = d.MstPayType.PayType,
                                      Amount = d.Amount,
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

        // ==========================
        // Sales Return Detail Report
        // ==========================
        public List<Entities.RepSalesReportSalesReturnDetailReportEntity> SalesReturnDetailReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var salesLines = from d in db.TrnSalesLines
                             where d.TrnSale.SalesDate >= startDate
                             && d.TrnSale.SalesDate <= endDate
                             && d.TrnSale.TerminalId == terminalId
                             && d.TrnSale.IsLocked == true
                             && d.TrnSale.IsCancelled == false
                             && d.TrnSale.IsReturned == true
                             && d.TrnSale.IsTendered == false
                             select new Entities.RepSalesReportSalesReturnDetailReportEntity
                             {
                                 Id = d.Id,
                                 Terminal = d.TrnSale.MstTerminal.Terminal,
                                 Date = d.TrnSale.SalesDate.ToShortDateString(),
                                 SalesReturnNumber = d.TrnSale.SalesNumber,
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
        // ====================
        // Customer List Report
        // ====================
        public List<Entities.RepSalesReportCustomerListReportEntity> GetCustomerListReport()
        {
            var customer = from d in db.MstCustomers
                           select new Entities.RepSalesReportCustomerListReportEntity
                           {
                               Id = d.Id,
                               CustomerCode = d.CustomerCode,
                               Customer = d.Customer,
                               ContactNumber = d.ContactNumber,
                               Address = d.Address
                           };

            return customer.ToList();
        }



        // ===============================
        // Hourly Top Selling Sales Report
        // ===============================
        public List<Entities.RepSalesReportTopSellingItemsReportEntity> GetTopHourlySalesSummaryReport(DateTime startDate, DateTime endDate)
        {
            var listSalesInvoices = from d in db.TrnSalesLines
                                    where d.TrnSale.SalesDate >= startDate
                                    && d.TrnSale.SalesDate <= endDate
                                    && d.TrnSale.IsLocked == true
                                    && d.TrnSale.IsCancelled == false
                                    select new
                                    {
                                        Hour = d.TrnSale.UpdateDateTime.Hour,
                                        ItemDescription = d.MstItem.ItemDescription,
                                        ItemCategory = d.MstItem.Category,
                                        Unit = d.MstUnit.Unit,
                                        Price = d.Price,
                                        Quantity = d.Quantity,
                                        Amount = d.Amount
                                    };

            if (listSalesInvoices.Any())
            {
                var topSellingItems = from d in listSalesInvoices
                                      group d by new
                                      {
                                          d.Hour,
                                          d.ItemDescription,
                                          d.ItemCategory,
                                          d.Unit,
                                          d.Price
                                      } into g
                                      select new Entities.RepSalesReportTopSellingItemsReportEntity
                                      {
                                          Hour = g.Key.Hour,
                                          ItemDescription = g.Key.ItemDescription,
                                          ItemCategory = g.Key.ItemCategory,
                                          Quantity = g.Sum(d => d.Quantity),
                                          Unit = g.Key.Unit,
                                          Price = g.Key.Price,
                                          Amount = g.Sum(d => d.Amount)
                                      };

                return topSellingItems.OrderBy(d => d.Hour).ThenByDescending(d => d.Quantity).ToList();
            }
            else
            {
                return new List<Entities.RepSalesReportTopSellingItemsReportEntity>();
            }
        }
        // ===================
        // Unsold Items Report
        // ===================
        public List<Entities.RepUnsoldItemEntity> UnsoldItemsReport(DateTime startDate, DateTime endDate)
        {
            List<Entities.RepUnsoldItemEntity> data = new List<Entities.RepUnsoldItemEntity>();

            var items = from d in db.MstItems select d;
            if (items.Any())
            {
                foreach (var item in items)
                {
                    var salesLines = from d in db.TrnSalesLines
                                     where d.ItemId == item.Id
                                     && d.TrnSale.SalesDate >= startDate
                                     && d.TrnSale.SalesDate <= endDate
                                     select d;

                    if (salesLines.Any() == false)
                    {
                        data.Add(new Entities.RepUnsoldItemEntity()
                        {
                            BarCode = item.BarCode,
                            ItemDescription = item.ItemDescription,
                            ItemCategory = item.Category,
                            Unit = item.MstUnit.Unit,
                            Price = item.Price,
                            Cost = item.Cost
                        });
                    }
                }
            }

            return data;
        }
    }
}