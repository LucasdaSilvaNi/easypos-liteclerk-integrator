using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepPOSReportController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========================
        // Dropdown List - Terminal
        // ========================
        public List<Entities.MstTerminalEntity> DropdownListTerminal()
        {
            var terminals = from d in db.MstTerminals
                            select new Entities.MstTerminalEntity
                            {
                                Id = d.Id,
                                Terminal = d.Terminal
                            };

            return terminals.ToList();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // ===============
        // Collection List
        // ===============
        public List<Entities.TrnCollectionEntity> ListCollections(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var collections = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                              where d.CollectionDate >= startDate.Date
                              && d.CollectionDate <= endDate.Date
                              && d.TerminalId == terminalId
                              && d.IsLocked == true
                              select new Entities.TrnCollectionEntity
                              {
                                  Id = d.Id,
                                  Terminal = d.MstTerminal.Terminal,
                                  CollectionNumber = d.CollectionNumber,
                                  SalesId = d.SalesId,
                                  PreparedByUserName = d.MstUser3.UserName,
                                  IsCancelled = d.IsCancelled
                              };

            return collections.ToList();
        }

        // ===============
        // Sales Line List
        // ===============
        public IQueryable<Data.TrnSalesLine> ListSalesLines(Int32 salesId)
        {
            var salesLines = from d in db.TrnSalesLines
                             where d.SalesId == salesId
                             select d;

            return salesLines;
        }

        // =====================
        // Collection Lines List
        // =====================
        public List<Entities.TrnCollectionLineEntity> ListCollectionLines(Int32 collectionId)
        {
            var collectionLines = from d in db.TrnCollectionLines.OrderByDescending(d => d.Id)
                                  where d.CollectionId == collectionId
                                  select new Entities.TrnCollectionLineEntity
                                  {
                                      Id = d.Id,
                                      PayType = d.MstPayType.PayType,
                                      Amount = d.Amount
                                  };

            return collectionLines.ToList();
        }

        // ========================
        // Collection Register List
        // ========================
        public List<Entities.TrnCollectionEntity> ListCollectionRegister(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var collections = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                              where d.CollectionDate >= startDate.Date
                              && d.CollectionDate <= endDate.Date
                              && d.TerminalId == terminalId
                              && d.SalesId != null
                              && d.IsLocked == true
                              select new Entities.TrnCollectionEntity
                              {
                                  Terminal = d.MstTerminal.Terminal,
                                  CollectionDate = d.CollectionDate.ToShortDateString(),
                                  CollectionNumber = d.CollectionNumber,
                                  CustomerCode = d.MstCustomer.CustomerCode,
                                  Customer = d.MstCustomer.Customer,
                                  Amount = d.IsCancelled == true ? 0 : d.Amount,
                                  VATSales = d.IsCancelled == true ? 0 : d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Sum(s => s.Amount) - d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Sum(s => s.TaxAmount) : 0,
                                  VATAmount = d.IsCancelled == true ? 0 : d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Sum(s => s.TaxAmount) : 0,
                                  NonVAT = d.IsCancelled == true ? 0 : d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "NONVAT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "NONVAT").Sum(s => s.Amount) : 0,
                                  VATExempt = d.IsCancelled == true ? 0 : d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "EXEMPTVAT").Any() ?
                                              d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "EXEMPTVAT").Sum(s => s.MstItem.MstTax1.Rate > 0 ? (s.Price * s.Quantity) - ((s.Price * s.Quantity) / (1 + (s.MstItem.MstTax1.Rate / 100)) * (s.MstItem.MstTax1.Rate / 100)) : s.Price * s.Quantity) : 0,
                                  VATZeroRated = d.IsCancelled == true ? 0 : d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "ZEROVAT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "ZEROVAT").Sum(s => s.Amount) : 0,
                              };

            return collections.ToList();
        }

        // =======
        // E Sales
        // =======
        public Entities.RepPOSReportZReadingReportEntity ZReadingESalesDataSource(Int32 terminalId, DateTime date)
        {
            Entities.RepPOSReportZReadingReportEntity zReadingReportEntity;

            Int32 filterTerminalId = terminalId;
            DateTime filterDate = date;

            Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

            Entities.RepPOSReportZReadingReportEntity repZReadingReportEntity = new Entities.RepPOSReportZReadingReportEntity()
            {
                Terminal = "",
                Date = "",
                TotalGrossSales = 0,
                TotalRegularDiscount = 0,
                TotalSeniorDiscount = 0,
                TotalPWDDiscount = 0,
                TotalSalesReturn = 0,
                TotalNetSales = 0,
                CollectionLines = new List<Entities.TrnCollectionLineEntity>(),
                TotalCollection = 0,
                TotalVATSales = 0,
                TotalVATAmount = 0,
                TotalNonVAT = 0,
                TotalVATExclusive = 0,
                TotalVATExempt = 0,
                TotalVATZeroRated = 0,
                CounterIdStart = "0000000000",
                CounterIdEnd = "0000000000",
                TotalCancelledTrnsactionCount = 0,
                TotalCancelledAmount = 0,
                TotalNumberOfTransactions = 0,
                TotalNumberOfSKU = 0,
                TotalQuantity = 0,
                GrossSalesTotalPreviousReading = 0,
                GrossSalesRunningTotal = 0,
                NetSalesTotalPreviousReading = 0,
                NetSalesRunningTotal = 0,
                ZReadingCounter = "0"
            };

            repZReadingReportEntity.Date = filterDate.ToShortDateString();

            var salesLines = from d in db.TrnSalesLines
                             where d.TrnSale.TrnCollections.Where(s => s.TerminalId == filterTerminalId && s.CollectionDate == filterDate && s.IsLocked == true && s.IsCancelled == false).Count() > 0
                             select d;

            var currentCollections = from d in db.TrnCollections
                                     where d.TerminalId == filterTerminalId
                                     && d.CollectionDate == filterDate.Date
                                     && d.IsLocked == true
                                     && d.IsCancelled == false
                                     select d;

            var currentCollectionLines = from d in db.TrnCollectionLines
                                         where d.TrnCollection.TerminalId == filterTerminalId
                                         && d.TrnCollection.CollectionDate == filterDate.Date
                                         && d.TrnCollection.IsLocked == true
                                         && d.TrnCollection.IsCancelled == false
                                         group d by new
                                         {
                                             d.MstPayType.PayTypeCode,
                                             d.MstPayType.PayType,
                                         } into g
                                         select new
                                         {
                                             g.Key.PayTypeCode,
                                             g.Key.PayType,
                                             TotalAmount = g.Sum(s => s.Amount),
                                             TotalChangeAmount = g.Sum(s => s.TrnCollection.ChangeAmount)
                                         };

            if (salesLines.Any() && currentCollectionLines.Any())
            {
                var terminal = from d in db.MstTerminals
                               where d.Id == filterTerminalId
                               select d;

                if (terminal.Any())
                {
                    repZReadingReportEntity.Terminal = terminal.FirstOrDefault().Terminal;
                }

                var grossSales = salesLines.Where(d => d.Quantity > 0);
                if (grossSales.Any())
                {
                    repZReadingReportEntity.TotalGrossSales = grossSales.Sum(d => d.MstTax.Code == "EXEMPTVAT" ? d.MstItem.MstTax1.Rate > 0 ? (d.Price * d.Quantity) - ((d.Price * d.Quantity) / (1 + (d.MstItem.MstTax1.Rate / 100)) * (d.MstItem.MstTax1.Rate / 100)) :
                                                              (d.Quantity * d.Price) - ((d.Price * d.Quantity) / (1 + (d.MstTax.Rate / 100)) * (d.MstTax.Rate / 100)) :
                                                              (d.Quantity * d.Price) - ((d.Price * d.Quantity) / (1 + (d.MstTax.Rate / 100)) * (d.MstTax.Rate / 100)));
                }

                var regularDiscounts = salesLines.Where(d => d.Quantity > 0
                                                             && d.MstDiscount.Discount.Equals("Senior Citizen Discount") == false
                                                             && d.MstDiscount.Discount.Equals("PWD") == false);
                if (regularDiscounts.Any())
                {
                    repZReadingReportEntity.TotalRegularDiscount = regularDiscounts.Sum(d => d.DiscountAmount * d.Quantity);
                }

                var seniorDiscounts = salesLines.Where(d => d.Quantity > 0 && d.MstDiscount.Discount.Equals("Senior Citizen Discount") == true);
                if (seniorDiscounts.Any())
                {
                    repZReadingReportEntity.TotalSeniorDiscount = seniorDiscounts.Sum(d => d.DiscountAmount * d.Quantity);
                }

                var PWDDiscounts = salesLines.Where(d => d.Quantity > 0 && d.MstDiscount.Discount.Equals("PWD") == true);
                if (PWDDiscounts.Any())
                {
                    repZReadingReportEntity.TotalPWDDiscount = PWDDiscounts.Sum(d => d.DiscountAmount * d.Quantity);
                }

                var salesReturns = salesLines.Where(d => d.Quantity < 0);
                if (salesReturns.Any())
                {
                    repZReadingReportEntity.TotalSalesReturn = salesReturns.Sum(d => d.Amount);
                }

                var netSales = salesLines.Where(d => d.Quantity > 0);
                if (netSales.Any())
                {
                    repZReadingReportEntity.TotalNetSales = repZReadingReportEntity.TotalGrossSales - repZReadingReportEntity.TotalRegularDiscount - repZReadingReportEntity.TotalSeniorDiscount - repZReadingReportEntity.TotalPWDDiscount;
                }

                foreach (var collectionLine in currentCollectionLines)
                {
                    Decimal amount = collectionLine.TotalAmount;
                    if (collectionLine.PayTypeCode.Equals("CASH"))
                    {
                        amount = collectionLine.TotalAmount - collectionLine.TotalChangeAmount;
                    }

                    repZReadingReportEntity.CollectionLines.Add(new Entities.TrnCollectionLineEntity()
                    {
                        PayType = collectionLine.PayType,
                        Amount = amount
                    });
                }

                repZReadingReportEntity.TotalCollection = currentCollections.Sum(d => d.Amount);

                var VATSales = salesLines.Where(d => d.MstTax.Code.Equals("VAT") == true);
                if (VATSales.Any())
                {
                    repZReadingReportEntity.TotalVATSales = VATSales.Sum(d => (d.Price * d.Quantity) - ((d.Price * d.Quantity) / (1 + (d.MstItem.MstTax1.Rate / 100)) * (d.MstItem.MstTax1.Rate / 100)));
                }

                repZReadingReportEntity.TotalVATAmount = salesLines.Sum(d => d.TaxAmount);

                var nonVATSales = salesLines.Where(d => d.MstTax.Code.Equals("NONVAT") == true);
                if (nonVATSales.Any())
                {
                    repZReadingReportEntity.TotalNonVAT = nonVATSales.Sum(d => d.Price * d.Quantity);
                }

                var VATExempts = salesLines.Where(d => d.MstTax.Code.Equals("EXEMPTVAT") == true);
                if (VATExempts.Any())
                {
                    repZReadingReportEntity.TotalVATExempt = VATExempts.Sum(d => d.MstItem.MstTax1.Rate > 0 ? (d.Price * d.Quantity) - ((d.Price * d.Quantity) / (1 + (d.MstItem.MstTax1.Rate / 100)) * (d.MstItem.MstTax1.Rate / 100)) : d.Price * d.Quantity);
                }

                var VATZeroRateds = salesLines.Where(d => d.MstTax.Code.Equals("ZEROVAT") == true);
                if (VATZeroRateds.Any())
                {
                    repZReadingReportEntity.TotalVATZeroRated = VATZeroRateds.Sum(d => d.Amount);
                }

                var counterCollections = from d in db.TrnCollections
                                         where d.TerminalId == filterTerminalId
                                         && d.CollectionDate == filterDate.Date
                                         && d.IsLocked == true
                                         select d;

                if (counterCollections.Any())
                {
                    repZReadingReportEntity.CounterIdStart = counterCollections.OrderBy(d => d.Id).FirstOrDefault().CollectionNumber;
                    repZReadingReportEntity.CounterIdEnd = counterCollections.OrderByDescending(d => d.Id).FirstOrDefault().CollectionNumber;
                }

                repZReadingReportEntity.TotalNumberOfTransactions = currentCollections.Count();
                repZReadingReportEntity.TotalNumberOfSKU = salesLines.Count();
                repZReadingReportEntity.TotalQuantity = salesLines.Sum(d => d.Quantity);
            }

            var currentCancelledCollections = from d in db.TrnCollections
                                              where d.TerminalId == filterTerminalId
                                              && d.CollectionDate == filterDate
                                              && d.IsLocked == true
                                              && d.IsCancelled == true
                                              select d;

            if (currentCancelledCollections.Any())
            {
                repZReadingReportEntity.TotalCancelledTrnsactionCount = currentCancelledCollections.Count();
                repZReadingReportEntity.TotalCancelledAmount = currentCancelledCollections.Sum(d => d.Amount);
            }

            var grossSalesPreviousCollections = from d in db.TrnCollections
                                                where d.TerminalId == filterTerminalId
                                                && d.CollectionDate < filterDate.Date
                                                && d.IsLocked == true
                                                && d.IsCancelled == false
                                                && d.SalesId != null
                                                select d;

            if (grossSalesPreviousCollections.Any())
            {
                repZReadingReportEntity.GrossSalesTotalPreviousReading = grossSalesPreviousCollections.Sum(d => d.TrnSale.TrnSalesLines.Any() ?
                                                                         d.TrnSale.TrnSalesLines.Sum(s => s.MstTax.Code == "EXEMPTVAT" ?
                                                                         s.MstItem.MstTax1.Rate > 0 ? (s.Price * s.Quantity) - ((s.Price * s.Quantity) / (1 + (s.MstItem.MstTax1.Rate / 100)) * (s.MstItem.MstTax1.Rate / 100)) :
                                                                         (s.Quantity * s.Price) - ((s.Price * s.Quantity) / (1 + (s.MstTax.Rate / 100)) * (s.MstTax.Rate / 100)) :
                                                                         (s.Quantity * s.Price) - ((s.Price * s.Quantity) / (1 + (s.MstTax.Rate / 100)) * (s.MstTax.Rate / 100))) : 0);

                repZReadingReportEntity.GrossSalesRunningTotal = repZReadingReportEntity.TotalGrossSales + repZReadingReportEntity.GrossSalesTotalPreviousReading;
            }

            var netSalesPreviousCollections = from d in db.TrnCollections
                                              where d.TerminalId == filterTerminalId
                                              && d.CollectionDate < filterDate.Date
                                              && d.IsLocked == true
                                              && d.IsCancelled == false
                                              select d;

            if (netSalesPreviousCollections.Any())
            {
                repZReadingReportEntity.NetSalesTotalPreviousReading = repZReadingReportEntity.GrossSalesTotalPreviousReading - netSalesPreviousCollections.Sum(s => s.TrnSale.TrnSalesLines.Any() ? s.TrnSale.TrnSalesLines.Sum(d => d.DiscountAmount * d.Quantity) : 0);
                repZReadingReportEntity.NetSalesRunningTotal = repZReadingReportEntity.TotalNetSales + repZReadingReportEntity.NetSalesTotalPreviousReading;
            }

            var firstCollection = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                                  where d.IsLocked == true
                                  select d;

            if (firstCollection.Any())
            {
                Double totalDays = (filterDate.Date - firstCollection.FirstOrDefault().CollectionDate).TotalDays + 1;
                repZReadingReportEntity.ZReadingCounter = totalDays.ToString("#,##0");
            }

            zReadingReportEntity = repZReadingReportEntity;
            return zReadingReportEntity;
        }
    }
}
