using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockOutLineController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===================
        // List Stock-Out Line
        // ===================
        public List<Entities.TrnStockOutLineEntity> ListStockOutLine(Int32 stockOutId)
        {
            var stockOutLines = from d in db.TrnStockOutLines
                                where d.Id == stockOutId
                                select new Entities.TrnStockOutLineEntity
                                {
                                    Id = d.Id,
                                    StockOutId = d.StockOutId,
                                    ItemId = d.ItemId,
                                    ItemDescription = d.MstItem.ItemDescription,
                                    UnitId = d.UnitId,
                                    Unit = d.MstUnit.Unit,
                                    Quantity = d.Quantity,
                                    Cost = d.Cost,
                                    Amount = d.Amount,
                                    AssetAccountId = d.AssetAccountId,
                                    AssetAccount = d.MstAccount.Account
                                };

            return stockOutLines.OrderByDescending(d => d.Id).ToList();
        }

        // =====================
        // Detail Stock-Out Line
        // =====================
        public Entities.TrnStockOutLineEntity DetailStockOutLine(Int32 id)
        {
            var stockOutLine = from d in db.TrnStockOutLines
                               where d.Id == id
                               select new Entities.TrnStockOutLineEntity
                               {
                                   Id = d.Id,
                                   StockOutId = d.StockOutId,
                                   ItemId = d.ItemId,
                                   ItemDescription = d.MstItem.ItemDescription,
                                   UnitId = d.UnitId,
                                   Unit = d.MstUnit.Unit,
                                   Quantity = d.Quantity,
                                   Cost = d.Cost,
                                   Amount = d.Amount,
                                   AssetAccountId = d.AssetAccountId,
                                   AssetAccount = d.MstAccount.Account
                               };

            return stockOutLine.FirstOrDefault();
        }

        // =================
        // Add Stock-In Line
        // =================
        public String[] AddStockOutLine(Entities.TrnStockOutLineEntity objStockOutLine)
        {
            try
            {
                var stockOut = from d in db.TrnStockOuts
                               where d.Id == objStockOutLine.StockOutId
                               select d;

                if (stockOut.Any() == false)
                {
                    return new String[] { "Stock-Out transaction not found.", "0" };
                }

                var item = from d in db.MstItems
                           where d.Id == objStockOutLine.ItemId
                           && d.IsLocked == true
                           select d;

                if (item.Any())
                {
                    return new String[] { "Item not found.", "0" };
                }

                var unit = from d in db.MstUnits
                           where d.Id == objStockOutLine.UnitId
                           select d;

                if (unit.Any())
                {
                    return new String[] { "Unit not found.", "0" };
                }

                var account = from d in db.MstAccounts
                              where d.Id == objStockOutLine.AssetAccountId
                              && d.IsLocked == true
                              select d;

                if (account.Any())
                {
                    return new String[] { "Account not found.", "0" };
                }

                Data.TrnStockOutLine newStockOutLine = new Data.TrnStockOutLine
                {
                    StockOutId = objStockOutLine.StockOutId,
                    ItemId = objStockOutLine.ItemId,
                    UnitId = objStockOutLine.UnitId,
                    Quantity = objStockOutLine.Quantity,
                    Cost = objStockOutLine.Cost,
                    Amount = objStockOutLine.Amount,
                    AssetAccountId = objStockOutLine.AssetAccountId
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
        // Update Stock-In Line
        // ====================
        public String[] UpdateStockOutLine(Int32 id, Entities.TrnStockOutLineEntity objStockOutLine)
        {
            try
            {
                var stockOutLine = from d in db.TrnStockOutLines
                                   where d.Id == id
                                   select d;

                if (stockOutLine.Any())
                {
                    var stockOut = from d in db.TrnStockOuts
                                   where d.Id == objStockOutLine.StockOutId
                                   select d;

                    if (stockOut.Any() == false)
                    {
                        return new String[] { "Stock-Out transaction not found.", "0" };
                    }

                    var item = from d in db.MstItems
                               where d.Id == objStockOutLine.ItemId
                               && d.IsLocked == true
                               select d;

                    if (item.Any())
                    {
                        return new String[] { "Item not found.", "0" };
                    }

                    var unit = from d in db.MstUnits
                               where d.Id == objStockOutLine.UnitId
                               select d;

                    if (unit.Any())
                    {
                        return new String[] { "Unit not found.", "0" };
                    }

                    var account = from d in db.MstAccounts
                                  where d.Id == objStockOutLine.AssetAccountId
                                  && d.IsLocked == true
                                  select d;

                    if (account.Any())
                    {
                        return new String[] { "Account not found.", "0" };
                    }

                    var updateStockOutLine = stockOutLine.FirstOrDefault();
                    updateStockOutLine.ItemId = objStockOutLine.ItemId;
                    updateStockOutLine.UnitId = objStockOutLine.UnitId;
                    updateStockOutLine.Quantity = objStockOutLine.Quantity;
                    updateStockOutLine.Cost = objStockOutLine.Cost;
                    updateStockOutLine.Amount = objStockOutLine.Amount;
                    updateStockOutLine.AssetAccountId = objStockOutLine.AssetAccountId;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out line not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Delete Stock-Out Line
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
                    var deleteStockOutLine = stockOutLine.FirstOrDefault();
                    db.TrnStockOutLines.DeleteOnSubmit(deleteStockOutLine);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out line not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
