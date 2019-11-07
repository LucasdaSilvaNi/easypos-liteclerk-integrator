using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockInLineController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==================
        // List Stock-In Line
        // ==================
        public List<Entities.TrnStockInLineEntity> ListStockInLine(Int32 stockInId)
        {
            var stockInLines = from d in db.TrnStockInLines
                               where d.StockInId == stockInId
                               select new Entities.TrnStockInLineEntity
                               {
                                   Id = d.Id,
                                   StockInId = d.StockInId,
                                   ItemId = d.ItemId,
                                   ItemDescription = d.MstItem.ItemDescription,
                                   UnitId = d.UnitId,
                                   Unit = d.MstUnit.Unit,
                                   Quantity = d.Quantity,
                                   Cost = d.Cost,
                                   Amount = d.Amount,
                                   ExpiryDate = d.ExpiryDate != null ? Convert.ToDateTime(d.ExpiryDate).ToShortDateString() : "",
                                   LotNumber = d.LotNumber != null ? d.LotNumber : "",
                                   AssetAccountId = d.AssetAccountId,
                                   AssetAccount = d.MstAccount.Account,
                                   Price = d.Price
                               };

            return stockInLines.OrderByDescending(d => d.Id).ToList();
        }

        // ====================
        // Dropdown List - Item
        // ====================
        public List<Entities.MstItemEntity> DropdownListStockInLineItem()
        {
            var items = from d in db.MstItems
                        select new Entities.MstItemEntity
                        {
                            Id = d.Id,
                            ItemDescription = d.ItemDescription,
                            UnitId = d.UnitId,
                            Unit = d.MstUnit.Unit
                        };

            return items.ToList();
        }

        // ====================
        // Dropdown List - Unit
        // ====================
        public List<Entities.MstUnitEntity> DropdownListStockInLineUnit()
        {
            var units = from d in db.MstUnits
                        select new Entities.MstUnitEntity
                        {
                            Id = d.Id,
                            Unit = d.Unit
                        };

            return units.ToList();
        }

        // =======================
        // Dropdown List - Account
        // =======================
        public List<Entities.MstAccountEntity> DropdownListStockInLineAccount()
        {
            var accounts = from d in db.MstAccounts
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               Account = d.Account
                           };

            return accounts.ToList();
        }

        // =================
        // Add Stock-In Line
        // =================
        public String[] AddStockInLine(Entities.TrnStockInLineEntity objStockInLine)
        {
            try
            {
                var stockIn = from d in db.TrnStockIns
                              where d.Id == objStockInLine.StockInId
                              select d;

                if (stockIn.Any() == false)
                {
                    return new String[] { "Stock-In transaction not found.", "0" };
                }

                var item = from d in db.MstItems
                           where d.Id == objStockInLine.ItemId
                           && d.IsLocked == true
                           select d;

                if (item.Any())
                {
                    return new String[] { "Item not found.", "0" };
                }

                var account = from d in db.MstAccounts
                              where d.Account.Equals("Inventory")
                              && d.IsLocked == true
                              select d;

                if (account.Any() == false)
                {
                    return new String[] { "Account not found.", "0" };
                }

                Data.TrnStockInLine newStockInLine = new Data.TrnStockInLine
                {
                    StockInId = objStockInLine.StockInId,
                    ItemId = objStockInLine.ItemId,
                    UnitId = item.FirstOrDefault().UnitId,
                    Quantity = objStockInLine.Quantity,
                    Cost = objStockInLine.Cost,
                    Amount = objStockInLine.Amount,
                    ExpiryDate = Convert.ToDateTime(objStockInLine.ExpiryDate),
                    LotNumber = objStockInLine.LotNumber,
                    AssetAccountId = account.FirstOrDefault().Id,
                    Price = objStockInLine.Price
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

        // ====================
        // Update Stock-In Line
        // ====================
        public String[] UpdateStockInLine(Int32 id, Entities.TrnStockInLineEntity objStockInLine)
        {
            try
            {
                var stockInLine = from d in db.TrnStockInLines
                                  where d.Id == id
                                  select d;

                if (stockInLine.Any())
                {
                    var stockIn = from d in db.TrnStockIns
                                  where d.Id == objStockInLine.StockInId
                                  select d;

                    if (stockIn.Any() == false)
                    {
                        return new String[] { "Stock-In transaction not found.", "0" };
                    }

                    var item = from d in db.MstItems
                               where d.Id == objStockInLine.ItemId
                               && d.IsLocked == true
                               select d;

                    if (item.Any() == false)
                    {
                        return new String[] { "Item not found.", "0" };
                    }

                    var updateStockInLine = stockInLine.FirstOrDefault();
                    updateStockInLine.Quantity = objStockInLine.Quantity;
                    updateStockInLine.Cost = objStockInLine.Cost;
                    updateStockInLine.Amount = objStockInLine.Amount;
                    updateStockInLine.ExpiryDate = Convert.ToDateTime(objStockInLine.ExpiryDate);
                    updateStockInLine.LotNumber = objStockInLine.LotNumber;
                    updateStockInLine.Price = objStockInLine.Price;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In line not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ====================
        // Delete Stock-In Line
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
                    var deleteStockInLine = stockInLine.FirstOrDefault();
                    db.TrnStockInLines.DeleteOnSubmit(deleteStockInLine);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In line not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
