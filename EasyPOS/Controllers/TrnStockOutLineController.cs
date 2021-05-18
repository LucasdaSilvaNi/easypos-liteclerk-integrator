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
                                    ItemBarcode = d.MstItem.BarCode,
                                    ItemDescription = d.MstItem.ItemDescription,
                                    UnitId = d.UnitId,
                                    Unit = d.MstUnit.Unit,
                                    Quantity = d.Quantity,
                                    Cost = d.MstItem.Cost,
                                    Price = d.MstItem.Price,
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
                        where d.IsInventory == true
                        && (d.BarCode.Contains(filter)
                        || d.ItemDescription.Contains(filter)
                        || d.GenericName.Contains(filter))
                        select new Entities.MstItemEntity
                        {
                            Id = d.Id,
                            BarCode = d.BarCode,
                            ItemDescription = d.ItemDescription,
                            GenericName = d.GenericName,
                            Cost = d.Cost,
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
                       && d.IsInventory == true
                       select new Entities.MstItemEntity
                       {
                           Id = d.Id,
                           BarCode = d.BarCode,
                           ItemDescription = d.ItemDescription,
                           GenericName = d.GenericName,
                           Cost = d.Cost,
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

        // ==================
        // Add Stock-Out Line
        // ==================
        public String[] AddStockOutLine(Entities.TrnStockOutLineEntity objStockOutLine)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                               where d.Id == objStockOutLine.StockOutId
                               select d;

                if (stockOut.Any() == false)
                {
                    return new String[] { "Stock-Out transaction not found.", "0" };
                }

                var item = from d in db.MstItems
                           where d.Id == objStockOutLine.ItemId
                           && d.IsInventory == true
                           && d.IsLocked == true
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                if (Modules.SysCurrentModule.GetCurrentSettings().AllowNegativeInventory == false)
                {
                    if (item.FirstOrDefault().IsInventory == true)
                    {
                        if (item.FirstOrDefault().OnhandQuantity <= 0)
                        {
                            return new String[] { "Item " + item.FirstOrDefault().ItemDescription + " has negative inventory", "0" };
                        }
                        else
                        {
                            if (item.FirstOrDefault().OnhandQuantity < objStockOutLine.Quantity)
                            {
                                return new String[] { "Item " + item.FirstOrDefault().ItemDescription + " has negative inventory", "0" };
                            }
                        }
                    }
                }

                Data.TrnStockOutLine newStockOutLine = new Data.TrnStockOutLine
                {
                    StockOutId = objStockOutLine.StockOutId,
                    ItemId = objStockOutLine.ItemId,
                    UnitId = item.FirstOrDefault().UnitId,
                    Quantity = objStockOutLine.Quantity,
                    Cost = objStockOutLine.Cost,
                    Amount = objStockOutLine.Amount,
                    AssetAccountId = item.FirstOrDefault().AssetAccountId,
                   
                };

                db.TrnStockOutLines.InsertOnSubmit(newStockOutLine);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(newStockOutLine);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "TrnStockOutLine",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddStockOutLine"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Update Stock-Out Line
        // =====================
        public String[] UpdateStockOutLine(Int32 id, Entities.TrnStockOutLineEntity objStockOutLine)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

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

                    if (Modules.SysCurrentModule.GetCurrentSettings().AllowNegativeInventory == false)
                    {
                        if (stockOutLine.FirstOrDefault().MstItem.IsInventory == true)
                        {
                            if (stockOutLine.FirstOrDefault().MstItem.OnhandQuantity <= 0)
                            {
                                return new String[] { "Item " + stockOutLine.FirstOrDefault().MstItem.ItemDescription + " has negative inventory", "0" };
                            }
                            else
                            {
                                if (stockOutLine.FirstOrDefault().MstItem.OnhandQuantity < objStockOutLine.Quantity)
                                {
                                    return new String[] { "Item " + stockOutLine.FirstOrDefault().MstItem.ItemDescription + " has negative inventory", "0" };
                                }
                            }
                        }
                    }

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(stockOutLine.FirstOrDefault());

                    var updateStockOutLine = stockOutLine.FirstOrDefault();
                    updateStockOutLine.Quantity = objStockOutLine.Quantity;
                    updateStockOutLine.Cost = objStockOutLine.Cost;
                    updateStockOutLine.Amount = objStockOutLine.Amount;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(stockOutLine.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "TrnStockOutLine",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdateStockOutLine"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

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
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockOutLine = from d in db.TrnStockOutLines
                                   where d.Id == id
                                   select d;

                if (stockOutLine.Any())
                {
                    var deleteStockOutLine = stockOutLine.FirstOrDefault();
                    db.TrnStockOutLines.DeleteOnSubmit(deleteStockOutLine);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(stockOutLine.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "TrnStockOutLine",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteStockOutLine"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

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

        // ======================
        // Barcode Stock-Out Line
        // ======================
        public String[] BarcodeStockOutLine(Int32 stockOutId, String barcode)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                               where d.Id == stockOutId
                               select d;

                if (stockOut.Any() == false)
                {
                    return new String[] { "Stock-Out transaction not found.", "0" };
                }

                var item = from d in db.MstItems
                           where d.BarCode.Equals(barcode)
                           && d.IsInventory == true
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

                String newObject = Modules.SysAuditTrailModule.GetObjectString(newStockOutLine);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "TrnStockOutLine",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddStockOutLine"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==================
        // Import Stock-Out Line
        // ==================
        public String[] ImportStockOutLine (List<Entities.TrnStockOutLineEntity> objStockOutLines)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                if(objStockOutLines.Any())
                {
                    foreach(var objStockOutLine in objStockOutLines)
                    {
                        var stockOut = from d in db.TrnStockOuts
                                       where d.Id == objStockOutLine.StockOutId
                                       select d;

                        if (stockOut.Any() == false)
                        {
                            return new String[] { "Stock-Out transaction not found.", "0" };
                        }

                        var item = from d in db.MstItems
                                   where d.BarCode == objStockOutLine.ItemBarcode
                                   && d.IsInventory == true
                                   && d.IsLocked == true
                                   select d;

                        if (item.Any() == false)
                        {
                            return new String[] { "Item not found.", "0" };
                        }

                        if (Modules.SysCurrentModule.GetCurrentSettings().AllowNegativeInventory == false)
                        {
                            if (item.FirstOrDefault().IsInventory == true)
                            {
                                if (item.FirstOrDefault().OnhandQuantity <= 0)
                                {
                                    return new String[] { "Item " + item.FirstOrDefault().ItemDescription + " has negative inventory", "0" };
                                }
                                else
                                {
                                    if (item.FirstOrDefault().OnhandQuantity < objStockOutLine.Quantity)
                                    {
                                        return new String[] { "Item " + item.FirstOrDefault().ItemDescription + " has negative inventory", "0" };
                                    }
                                }
                            }
                        }

                        Data.TrnStockOutLine newStockOutLine = new Data.TrnStockOutLine
                        {
                            StockOutId = objStockOutLine.StockOutId,
                            ItemId = item.FirstOrDefault().Id,
                            UnitId = item.FirstOrDefault().UnitId,
                            Quantity = objStockOutLine.Quantity,
                            Cost = objStockOutLine.Cost,
                            Amount = objStockOutLine.Amount,
                            AssetAccountId = item.FirstOrDefault().AssetAccountId
                        };

                        db.TrnStockOutLines.InsertOnSubmit(newStockOutLine);
                        db.SubmitChanges();

                        String newObject = Modules.SysAuditTrailModule.GetObjectString(newStockOutLine);

                        Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                        {
                            UserId = currentUserLogin.FirstOrDefault().Id,
                            AuditDate = DateTime.Now,
                            TableInformation = "TrnStockOutLine",
                            RecordInformation = "",
                            FormInformation = newObject,
                            ActionInformation = "AddStockOutLine"
                        };
                        Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);
                    }
                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Data source is empty.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
