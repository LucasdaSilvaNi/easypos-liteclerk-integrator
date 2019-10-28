using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockInLineController
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        public List<Entities.TrnStockInLineEntity> ListStockInLine(Int32 stockInId)
        {
            var stockInLines = from d in db.TrnStockInLines
                               where d.Id == stockInId
                               select new Entities.TrnStockInLineEntity
                               {
                                   Id = d.Id,
                                   StockInId = d.StockInId,
                                   ItemId = d.ItemId,
                                   UnitId = d.UnitId,
                                   Quantity = d.Quantity,
                                   Cost = d.Cost,
                                   Amount = d.Amount,
                                   ExpiryDate = d.ExpiryDate.ToString(),
                                   LotNumber = d.LotNumber,
                                   AssetAccountId = d.AssetAccountId,
                                   Price = d.Price
                               };
            return stockInLines.OrderByDescending(d => d.Id).ToList();
        }

        // ====================
        // Detail - StockInLine
        // ====================
        public Entities.TrnStockInLineEntity DetailStockInLine(Entities.TrnStockInLineEntity objStockInLine)
        {
            var stockInLine = from d in db.TrnStockInLines
                              where d.Id == objStockInLine.Id
                              select new Entities.TrnStockInLineEntity
                              {
                                  Id = d.Id,
                                  StockInId = d.StockInId,
                                  ItemId = d.ItemId,
                                  ItemItemDescription = d.MstItem.ItemDescription,
                                  UnitId = d.UnitId,
                                  Unit = d.MstUnit.Unit,
                                  Quantity = d.Quantity,
                                  Cost = d.Cost,
                                  Amount = d.Amount,
                                  ExpiryDate = d.ExpiryDate.ToString(),
                                  LotNumber = d.LotNumber,
                                  AssetAccountId = d.AssetAccountId,
                                  AssetAccount = d.MstAccount.Account,
                                  Price = d.Price
                              };

            return stockInLine.FirstOrDefault();
        }

        // =================
        // Add - StockInLine
        // =================
        public String[] AddStockInLine(int stockInId, string barCode)
        {
            try
            {
                var stockIn = from d in db.TrnStockIns
                              where d.Id == stockInId
                              select d;

                if (stockIn.Any() == false)
                {
                    return new String[] { "StockIn transaction not found.", "0" };
                }

                var item = from d in db.MstItems
                           where d.BarCode == barCode
                           select d;

                if (item.Any())
                {
                    return new String[] { "Item not found.", "0" };
                }

                var account = from d in db.MstAccounts
                              where d.Account.Equals("Inventory")
                              select d;

                if (account.Any())
                {
                    return new String[] { "Account not found.", "0" };
                }


                Data.TrnStockInLine newStockInLine = new Data.TrnStockInLine
                {
                    StockInId = stockIn.FirstOrDefault().Id,
                    ItemId = item.FirstOrDefault().Id,
                    UnitId = item.FirstOrDefault().UnitId,
                    Quantity = 1,
                    Cost = item.FirstOrDefault().Cost,
                    Amount = item.FirstOrDefault().Cost,
                    ExpiryDate = null,
                    LotNumber = null,
                    AssetAccountId = account.FirstOrDefault().Id,
                    Price = item.FirstOrDefault().Cost

                };

                db.TrnStockInLines.InsertOnSubmit(newStockInLine);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Update - StockInLine
        // =================
        public String[] UpdateStockInLine(Entities.TrnStockInLineEntity objStockInLine)
        {
            try
            {
                var stockInLine = from d in db.TrnStockInLines
                                  where d.Id == objStockInLine.Id
                                  select d;

                if (stockInLine.Any())
                {
                    var item = from d in db.MstItems
                               where d.Id == objStockInLine.Id
                               select d;

                    if (item.Any())
                    {
                        return new String[] { "Item not found.", "0" };
                    }

                    var account = from d in db.MstAccounts
                                  where d.Id == objStockInLine.AssetAccountId
                                  select d;

                    if (account.Any())
                    {
                        return new String[] { "Account not found.", "0" };
                    }

                    var unit = from d in db.MstUnits
                               where d.Id == objStockInLine.UnitId
                               select d;
                    if (unit.Any())
                    {
                        return new String[] { "Unit not found.", "0" };
                    }

                    var updateStockInLine = stockInLine.FirstOrDefault();
                    updateStockInLine.UnitId = unit.FirstOrDefault().Id;
                    updateStockInLine.Quantity = objStockInLine.Quantity;
                    updateStockInLine.Cost = objStockInLine.Cost;
                    updateStockInLine.Amount = objStockInLine.Amount;
                    updateStockInLine.ExpiryDate = Convert.ToDateTime(objStockInLine.ExpiryDate);
                    updateStockInLine.LotNumber = objStockInLine.LotNumber;
                    updateStockInLine.AssetAccountId = account.FirstOrDefault().Id;
                    updateStockInLine.Price = objStockInLine.Price;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "StockIn transaction not found.", "0" };
                }

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Delete - StockInLine
        // ====================
        public String[] DeleteStockInLine(Int32 id)
        {
            try
            {
                var stockInLine = from d in db.TrnStockInLines
                                where d.Id == id
                                select d;

                if (stockInLine.Any())
                {
                    db.TrnStockInLines.DeleteOnSubmit(stockInLine.FirstOrDefault());
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "StockInLine not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
