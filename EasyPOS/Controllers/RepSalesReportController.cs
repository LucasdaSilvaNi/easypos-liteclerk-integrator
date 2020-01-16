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

        // ====================
        // Sales Summary Report
        // ====================
        public List<Entities.RepSalesReportTrnSalesEntity> SalesSummaryReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var sales = from d in db.TrnSales.OrderByDescending(d => d.Id)
                        where d.SalesDate >= startDate
                        && d.SalesDate <= endDate
                        && d.TerminalId == terminalId
                        && d.IsLocked == true
                        && d.IsCancelled == false
                        select new Entities.RepSalesReportTrnSalesEntity
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
        public List<Entities.RepSalesReportTrnCollectionEntity> CollectionSummaryReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var collections = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                              where d.CollectionDate >= startDate
                              && d.CollectionDate <= endDate
                              && d.TerminalId == terminalId
                              && d.IsLocked == true
                              select new Entities.RepSalesReportTrnCollectionEntity
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
                                  Amount = d.Amount
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
                                      PayType = d.MstPayType.PayType,
                                      Amount = d.MstPayType.PayType.Equals("Cash") ? d.Amount - d.TrnCollection.ChangeAmount : d.Amount,
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
        public List<Entities.RepSalesReportTrnCollectionEntity> CancelledSalesSummaryReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var cancelledCollections = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                                       where d.CollectionDate >= startDate
                                       && d.CollectionDate <= endDate
                                       && d.TerminalId == terminalId
                                       && d.IsLocked == true
                                       && d.IsCancelled == true
                                       select new Entities.RepSalesReportTrnCollectionEntity
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
                                           Amount = d.Amount
                                       };

            return cancelledCollections.ToList();
        }
    }
}
