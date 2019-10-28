using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockOutLineController
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =====================
        // List - StockOutLine
        // =====================
        public List<Entities.TrnStockOutLineEntity> ListStockOutLine(Int32 stockOutId)
        {
            var stockOutLines = from d in db.TrnStockOutLines
                                where d.Id == stockOutId
                                select new Entities.TrnStockOutLineEntity
                                {
                                    Id = d.Id,
                                    StockOutId = d.StockOutId,
                                    ItemId = d.ItemId,
                                    UnitId = d.UnitId,
                                    Quantity = d.Quantity,
                                    Cost = d.Cost,
                                    Amount = d.Amount,
                                    AssetAccountId = d.AssetAccountId

                                };
            return stockOutLines.OrderByDescending(d => d.Id).ToList();
        }

        // =====================
        // Detail - StockOutLine
        // =====================
        public Entities.TrnStockOutLineEntity DetailStockOutLine(Entities.TrnStockOutLineEntity objStockOutLine)
        {
            var stockInLine = from d in db.TrnStockOutLines
                              where d.Id == objStockOutLine.Id
                              select new Entities.TrnStockOutLineEntity
                              {
                                  Id = d.Id,
                                    StockOutId = d.StockOutId,
                                    ItemId = d.ItemId,
                                    ItemItemDescription = d.MstItem.ItemDescription,
                                    UnitId = d.UnitId,
                                    Unit = d.MstUnit.Unit,
                                    Quantity = d.Quantity,
                                    Cost = d.Cost,
                                    Amount = d.Amount,
                                    AssetAccountId = d.AssetAccountId,
                                    AssetAccount = d.MstAccount.Account
                              };

            return stockInLine.FirstOrDefault();
        }

        // =================
        // Add - StockInLine
        // =================
        public String[] AddStockOutLine(int stockOutId, string barCode)
        {
            try
            {
                var stockOut = from d in db.TrnStockOuts
                              where d.Id == stockOutId
                              select d;

                if (stockOut.Any() == false)
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


                Data.TrnStockOutLine newStockOutLine = new Data.TrnStockOutLine
                {
                    StockOutId = stockOut.FirstOrDefault().Id,
                    ItemId = item.FirstOrDefault().Id,
                    UnitId = item.FirstOrDefault().UnitId,
                    Quantity = 1,
                    Cost = item.FirstOrDefault().Cost,
                    Amount = item.FirstOrDefault().Cost,
                    AssetAccountId = account.FirstOrDefault().Id,
                };

                db.TrnStockOutLines.InsertOnSubmit(newStockOutLine);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Update - StockInLine
        // ====================
        public String[] UpdateStockOutLine(Entities.TrnStockOutLineEntity objStockOutLine)
        {
            try
            {
                var stockOutLine = from d in db.TrnStockOutLines
                                  where d.Id == objStockOutLine.Id
                                  select d;

                if (stockOutLine.Any())
                {
                    var item = from d in db.MstItems
                               where d.Id == objStockOutLine.Id
                               select d;

                    if (item.Any())
                    {
                        return new String[] { "Item not found.", "0" };
                    }

                    var account = from d in db.MstAccounts
                                  where d.Id == objStockOutLine.AssetAccountId
                                  select d;

                    if (account.Any())
                    {
                        return new String[] { "Account not found.", "0" };
                    }

                    var unit = from d in db.MstUnits
                               where d.Id == objStockOutLine.UnitId
                               select d;
                    if (unit.Any())
                    {
                        return new String[] { "Unit not found.", "0" };
                    }

                    var updateStockInLine = stockOutLine.FirstOrDefault();
                    updateStockInLine.UnitId = unit.FirstOrDefault().Id;
                    updateStockInLine.Quantity = objStockOutLine.Quantity;
                    updateStockInLine.Cost = objStockOutLine.Cost;
                    updateStockInLine.Amount = objStockOutLine.Amount;
                    updateStockInLine.AssetAccountId = account.FirstOrDefault().Id;
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

        // =====================
        // Delete - StockOutLine
        // =====================
        public String[] DeleteStockOutLine(Int32 id)
        {
            try
            {
                var stockOutLine = from d in db.TrnStockOutLines
                                  where d.Id == id
                                  select d;

                if (stockOutLine.Any())
                {
                    db.TrnStockOutLines.DeleteOnSubmit(stockOutLine.FirstOrDefault());
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
