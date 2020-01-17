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
                              where d.CollectionDate >= startDate
                              && d.CollectionDate <= endDate
                              && d.TerminalId == terminalId
                              && d.IsLocked == true
                              select new Entities.TrnCollectionEntity
                              {
                                  Id = d.Id,
                                  Terminal = d.MstTerminal.Terminal,
                                  CollectionNumber = d.CollectionNumber,
                                  SalesId = d.SalesId,
                                  PreparedByUserName = d.MstUser3.UserName
                              };

            return collections.ToList();
        }

        // ===============
        // Sales Line List
        // ===============
        public List<Entities.TrnSalesLineEntity> ListSalesLines(Int32 salesId)
        {
            var salesLines = from d in db.TrnSalesLines
                             where d.SalesId == salesId
                             select new Entities.TrnSalesLineEntity
                             {
                                 Id = d.Id,
                                 ItemDescription = d.MstItem.ItemDescription,
                                 Quantity = d.Quantity,
                                 Unit = d.MstUnit.Unit,
                                 Price = d.Price,
                                 Amount = d.Amount,
                             };

            return salesLines.ToList();
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
                              where d.CollectionDate >= startDate
                              && d.CollectionDate <= endDate
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
                                  Amount = d.Amount,
                                  VATSales = d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Sum(s => s.Amount) - d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Sum(s => s.TaxAmount) : 0,
                                  VATAmount = d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VAT").Sum(s => s.TaxAmount) : 0,
                                  NonVAT = d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "NONVAT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "NONVAT").Sum(s => s.Amount) : 0,
                                  VATExempt = d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VATEXEMPT").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VATEXEMPT").Sum(s => s.Amount) : 0,
                                  VATZeroRated = d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VATZERORATED").Any() ? d.TrnSale.TrnSalesLines.Where(s => s.MstTax.Code == "VATZERORATED").Sum(s => s.Amount) : 0,
                              };

            return collections.ToList();
        }

    }
}
