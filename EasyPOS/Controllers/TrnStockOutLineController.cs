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
                                where d.StockOutId == stockOutId
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

        // ================
        // List Search Item
        // ================
        public List<Entities.MstItemEntity> ListSearchItem(String filter)
        {
            var items = from d in db.MstItems
                        where d.BarCode.Contains(filter)
                        || d.ItemDescription.Contains(filter)
                        || d.GenericName.Contains(filter)
                        select new Entities.MstItemEntity
                        {
                            Id = d.Id,
                            BarCode = d.BarCode,
                            ItemDescription = d.ItemDescription,
                            GenericName = d.GenericName,
                            OutTaxId = d.OutTaxId,
                            OutTax = d.MstTax1.Tax,
                            OutTaxRate = d.MstTax1.Rate,
                            UnitId = d.UnitId,
                            Unit = d.MstUnit.Unit,
                            Price = d.Price,
                            OnhandQuantity = d.OnhandQuantity
                        };

            return items.OrderBy(d => d.ItemDescription).ToList();
        }

        // ===========
        // Detail Item
        // ===========
        public Entities.MstItemEntity DetailSearchItem(String barcode)
        {
            var item = from d in db.MstItems
                       where d.BarCode.Equals(barcode)
                       select new Entities.MstItemEntity
                       {
                           Id = d.Id,
                           BarCode = d.BarCode,
                           ItemDescription = d.ItemDescription,
                           GenericName = d.GenericName,
                           OutTaxId = d.OutTaxId,
                           OutTax = d.MstTax1.Tax,
                           OutTaxRate = d.MstTax1.Rate,
                           UnitId = d.UnitId,
                           Unit = d.MstUnit.Unit,
                           Price = d.Price,
                           OnhandQuantity = d.OnhandQuantity
                       };

            return item.FirstOrDefault();
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

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                Data.TrnStockOutLine newStockOutLine = new Data.TrnStockOutLine
                {
                    StockOutId = objStockOutLine.StockOutId,
                    ItemId = objStockOutLine.ItemId,
                    UnitId = item.FirstOrDefault().UnitId,
                    Quantity = objStockOutLine.Quantity,
                    Cost = objStockOutLine.Cost,
                    Amount = objStockOutLine.Amount,
                    AssetAccountId = item.FirstOrDefault().AssetAccountId
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

                    var updateStockOutLine = stockOutLine.FirstOrDefault();
                    updateStockOutLine.Quantity = objStockOutLine.Quantity;
                    updateStockOutLine.Cost = objStockOutLine.Cost;
                    updateStockOutLine.Amount = objStockOutLine.Amount;
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

        // =====================
        // Barcode Stock-In Line
        // =====================
        public String[] BarcodeStockOutLine(Int32 stockOutId, String barcode)
        {
            try
            {
                var stockOut = from d in db.TrnStockOuts
                               where d.Id == stockOutId
                               select d;

                if (stockOut.Any() == false)
                {
                    return new String[] { "Stock-Out transaction not found.", "0" };
                }

                var item = from d in db.MstItems
                           where d.BarCode.Equals(barcode)
                           && d.IsLocked == true
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                Data.TrnStockOutLine newStockOutLine = new Data.TrnStockOutLine
                {
                    StockOutId = stockOutId,
                    ItemId = item.FirstOrDefault().Id,
                    UnitId = item.FirstOrDefault().UnitId,
                    Quantity = 1,
                    Cost = 0,
                    Amount = 0,
                    AssetAccountId = item.FirstOrDefault().AssetAccountId
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
    }
}
