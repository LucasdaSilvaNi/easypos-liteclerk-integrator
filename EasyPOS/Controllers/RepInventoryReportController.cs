using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepInventoryReportController
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        public List<Entities.RepInventoryReportEntity> GetInventoryReport(DateTime startDate, DateTime endDate)
        {
            List<Entities.RepInventoryReportEntity> newRepInventoryReportEntity = new List<Entities.RepInventoryReportEntity>();

            var stockInLines = from d in db.TrnStockInLines
                               where d.TrnStockIn.IsLocked == true
                               select new Entities.RepInventoryReportEntity
                               {
                                   InventoryDate = d.TrnStockIn.StockInDate,
                                   ItemDescription = d.MstItem.ItemDescription,
                                   Unit = d.MstItem.MstUnit.Unit,
                                   InQuantity = d.Quantity,
                                   OutQuantity = 0,
                                   Quantity = d.Quantity,
                                   Cost = d.MstItem.Cost,
                                   Amount = d.Quantity * d.MstItem.Cost
                               };

            if (stockInLines.Any())
            {
                newRepInventoryReportEntity.AddRange(stockInLines.ToList());
            }

            var saleLines = from d in db.TrnSalesLines
                            where d.TrnSale.IsLocked == true
                            && d.TrnSale.IsCancelled == false
                            select new Entities.RepInventoryReportEntity
                            {
                                InventoryDate = d.TrnSale.SalesDate,
                                ItemDescription = d.MstItem.ItemDescription,
                                Unit = d.MstItem.MstUnit.Unit,
                                InQuantity = 0,
                                OutQuantity = d.Quantity,
                                Quantity = d.Quantity * -1,
                                Cost = d.MstItem.Cost,
                                Amount = (d.Quantity * -1) * d.MstItem.Cost
                            };

            if (saleLines.Any())
            {
                newRepInventoryReportEntity.AddRange(saleLines.ToList());
            }

            var stockOutLines = from d in db.TrnStockOutLines
                                select new Entities.RepInventoryReportEntity
                                {
                                    InventoryDate = d.TrnStockOut.StockOutDate,
                                    ItemDescription = d.MstItem.ItemDescription,
                                    Unit = d.MstItem.MstUnit.Unit,
                                    InQuantity = 0,
                                    OutQuantity = d.Quantity,
                                    Quantity = d.Quantity * -1,
                                    Cost = d.MstItem.Cost,
                                    Amount = (d.Quantity * -1) * d.MstItem.Cost
                                };

            if (stockOutLines.Any())
            {
                newRepInventoryReportEntity.AddRange(stockOutLines.ToList());
            }

            if (newRepInventoryReportEntity.Any())
            {
                var begInventories = from d in newRepInventoryReportEntity
                                     where d.InventoryDate < startDate
                                     select new Entities.RepInventoryReportEntity
                                     {
                                         Document = "Beg",
                                         InventoryDate = d.InventoryDate,
                                         ItemDescription = d.ItemDescription,
                                         Unit = d.Unit,
                                         InQuantity = d.InQuantity,
                                         OutQuantity = d.OutQuantity,
                                         Quantity = d.Quantity,
                                         Cost = d.Cost,
                                         Amount = d.Amount
                                     };

                var curInventories = from d in newRepInventoryReportEntity
                                     where d.InventoryDate >= startDate
                                     && d.InventoryDate <= endDate
                                     select new Entities.RepInventoryReportEntity
                                     {
                                         Document = "Cur",
                                         InventoryDate = d.InventoryDate,
                                         ItemDescription = d.ItemDescription,
                                         Unit = d.Unit,
                                         InQuantity = d.InQuantity,
                                         OutQuantity = d.OutQuantity,
                                         Quantity = d.Quantity,
                                         Cost = d.Cost,
                                         Amount = d.Amount
                                     };

                var unionInventories = begInventories.Union(curInventories);

                if (unionInventories.ToList().Any())
                {
                    var inventories = from d in unionInventories
                                      group d by new
                                      {
                                          d.ItemDescription,
                                          d.Unit,
                                          d.Cost
                                      } into g
                                      select new Entities.RepInventoryReportEntity
                                      {
                                          ItemDescription = g.Key.ItemDescription,
                                          Unit = g.Key.ItemDescription,
                                          BegQuantity = g.Sum(s => s.Document == "Beg" ? s.Quantity : 0),
                                          InQuantity = g.Sum(s => s.Document == "Cur" ? s.InQuantity : 0),
                                          OutQuantity = g.Sum(s => s.Document == "Cur" ? s.OutQuantity : 0),
                                          EndingQuantity = g.Sum(s => s.Quantity),
                                          CountQuantity = 0,
                                          Variance = g.Sum(s => s.Quantity),
                                          Cost = g.Key.Cost,
                                          Amount = g.Sum(s => s.Amount),
                                      };

                    return inventories.OrderBy(d => d.ItemDescription).ToList();
                }
                else
                {
                    return new List<Entities.RepInventoryReportEntity>();
                }
            }
            else
            {
                return new List<Entities.RepInventoryReportEntity>();
            }
        }

        public List<Entities.RepInventoryReportStockInDetailReportEntity> GetListStockInDetail(DateTime startDate, DateTime endDate)
        {
            var stockInDetails = from d in db.TrnStockInLines
                                 where d.TrnStockIn.IsLocked == true
                                       && d.TrnStockIn.StockInDate >= startDate
                                       && d.TrnStockIn.StockInDate <= endDate
                                 select new Entities.RepInventoryReportStockInDetailReportEntity
                                 {
                                     Id = d.Id,
                                     StockInDate = d.TrnStockIn.StockInDate.ToShortDateString(),
                                     StockInNumber = d.TrnStockIn.StockInNumber,
                                     Remarks = d.TrnStockIn.Remarks,
                                     IsReturn = d.TrnStockIn.IsReturn,
                                     Item = d.MstItem.ItemDescription,
                                     Unit = d.MstUnit.Unit,
                                     Quantity = d.Quantity,
                                     Cost = d.Cost,
                                     Amount = d.Amount,
                                     ExpiryDate = d.ExpiryDate.ToString(),
                                     LotNumber = d.LotNumber,
                                     SellingPrice = d.Price != null ? d.Price : 0
                                 };

            return stockInDetails.ToList();
        }

        public List<Entities.RepInventoryReportStockOutDetailEntity> GetListStockOutDetail(DateTime startDate, DateTime endDate)
        {
            var stockOutDetails = from d in db.TrnStockOutLines
                                  where d.TrnStockOut.IsLocked == true
                                        && d.TrnStockOut.StockOutDate >= startDate
                                        && d.TrnStockOut.StockOutDate <= endDate
                                  select new Entities.RepInventoryReportStockOutDetailEntity
                                  {
                                      Id = d.Id,
                                      StockOutDate = d.TrnStockOut.StockOutDate.ToShortDateString(),
                                      StockOutNumber = d.TrnStockOut.StockOutNumber,
                                      Remarks = d.TrnStockOut.Remarks,
                                      Item = d.MstItem.ItemDescription,
                                      Unit = d.MstUnit.Unit,
                                      Quantity = d.Quantity,
                                      Cost = d.Cost,
                                      Amount = d.Amount,
                                  };
            return stockOutDetails.OrderByDescending(d => d.Id).ToList();
        }

        public List<Entities.RepInventoryReportStockCountEntity> GetListStockCountDetail(DateTime startDate, DateTime endDate)
        {
            var stockCountDetails = from d in db.TrnStockCountLines
                                    where d.TrnStockCount.StockCountDate >= startDate
                                          && d.TrnStockCount.StockCountDate <= endDate
                                    select new Entities.RepInventoryReportStockCountEntity
                                    {
                                        Id = d.Id,
                                        StockCountDate = d.TrnStockCount.StockCountDate.ToShortDateString(),
                                        StockCountNumber = d.TrnStockCount.StockCountNumber,
                                        Remarks = d.TrnStockCount.Remarks,
                                        Item = d.MstItem.ItemDescription,
                                        Unit = d.MstUnit.Unit,
                                        Quantity = d.Quantity,
                                        Cost = d.Cost,
                                        Amount = d.Amount
                                    };
            return stockCountDetails.OrderByDescending(d => d.Id).ToList();
        }
    }
}
