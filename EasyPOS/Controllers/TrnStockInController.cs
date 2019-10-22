using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockInController
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===================
        // Fill Leading Zeroes
        // ===================
        public String FillLeadingZeroes(Int32 number, Int32 length)
        {
            var result = number.ToString();
            var pad = length - result.Length;
            while (pad > 0)
            {
                result = '0' + result;
                pad--;
            }

            return result;
        }

        // ============
        // StockIn List
        // ============
        public List<Entities.TrnStockInEntity> ListStockIn(String filter)
        {
            var stockIns = from d in db.TrnStockIns
                        where d.StockInNumber.Contains(filter)
                        select new Entities.TrnStockInEntity
                        {
                            Id = d.Id,
                            PeriodId = d.PeriodId,
                            StockInDate = d.StockInDate.ToShortDateString(),
                            StockInNumber = d.StockInNumber,
                            SupplierId = d.SupplierId,
                            Remarks = d.Remarks,
                            IsReturn = d.IsReturn,
                            CollectionId = d.CollectionId,
                            PurchaseOrderId = d.PurchaseOrderId,
                            PreparedBy = d.PreparedBy,
                            CheckedBy = d.CheckedBy,
                            ApprovedBy = d.ApprovedBy,
                            IsLocked = d.IsLocked,
                            EntryUserId = d.EntryUserId,
                            EntryDateTime = d.EntryDateTime.ToShortDateString(),
                            UpdateUserId = d.UpdateUserId,
                            UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                            SalesId = d.SalesId,
                            PostCode = d.PostCode
                        };

            return stockIns.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // Stockin Detail
        // ==============
        public Entities.TrnStockInEntity DetailStockIn(Int32 id)
        {
            var stockIns = from d in db.TrnStockIns
                           where d.Id == id
                           select new Entities.TrnStockInEntity
                           {
                               Id = d.Id,
                               PeriodId = d.PeriodId,
                               StockInDate = d.StockInDate.ToShortDateString(),
                               StockInNumber = d.StockInNumber,
                               SupplierId = d.SupplierId,
                               Remarks = d.Remarks,
                               IsReturn = d.IsReturn,
                               CollectionId = d.CollectionId,
                               PurchaseOrderId = d.PurchaseOrderId,
                               PreparedBy = d.PreparedBy,
                               CheckedBy = d.CheckedBy,
                               ApprovedBy = d.ApprovedBy,
                               IsLocked = d.IsLocked,
                               EntryUserId = d.EntryUserId,
                               EntryDateTime = d.EntryDateTime.ToShortDateString(),
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                               SalesId = d.SalesId,
                               PostCode = d.PostCode
                           };

            return stockIns.FirstOrDefault();
        }

        // ===========
        // Add Stockin
        // ===========
        public String[] AddStockIn()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var period = from d in db.MstPeriods select d;
                if (period.Any())
                {
                    return new String[] { "Perios not found.", "0" };
                }

                String stockInNumber = "0000000001";
                var lastStockInNumber = from d in db.TrnStockIns.OrderByDescending(d => d.Id) select d;
                if (lastStockInNumber.Any())
                {
                    Int32 newItemCode = Convert.ToInt32(lastStockInNumber.FirstOrDefault().StockInNumber) + 1;
                    stockInNumber = FillLeadingZeroes(newItemCode, 10);
                }

                var supplier = from d in db.MstSuppliers select d;
                if (supplier.Any())
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                Data.TrnStockIn newStockIn = new Data.TrnStockIn()
                {
                    PeriodId = period.FirstOrDefault().Id,
                    StockInDate = DateTime.Today,
                    StockInNumber = stockInNumber,
                    SupplierId = supplier.FirstOrDefault().Id,
                    Remarks = "NA",
                    IsReturn = false,
                    CollectionId = null,
                    PurchaseOrderId = null,
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    SalesId = null,
                    IsLocked = false,
                    EntryUserId = currentUserLogin.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Today,
                    UpdateUserId = currentUserLogin.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Today

                };

                db.TrnStockIns.InsertOnSubmit(newStockIn);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        //============
        //Lock Stockin
        //============
        public String[] LockStockIn(Int32 id, Entities.TrnStockInEntity objStockInd)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockIn = from d in db.TrnStockIns
                              where d.Id == id
                              select d;

                if (stockIn.Any())
                {
                    var lockStockIn = stockIn.FirstOrDefault();
                    lockStockIn.Id = objStockInd.Id;
                    lockStockIn.PeriodId = objStockInd.PeriodId;
                    lockStockIn.StockInDate = Convert.ToDateTime(objStockInd.StockInDate);
                    lockStockIn.StockInNumber = objStockInd.StockInNumber;
                    lockStockIn.SupplierId = objStockInd.SupplierId;
                    lockStockIn.Remarks = objStockInd.Remarks;
                    lockStockIn.IsReturn = objStockInd.IsReturn;
                    lockStockIn.CollectionId = objStockInd.CollectionId;
                    lockStockIn.PurchaseOrderId = objStockInd.PurchaseOrderId;
                    lockStockIn.PreparedBy = objStockInd.PreparedBy;
                    lockStockIn.CheckedBy = objStockInd.CheckedBy;
                    lockStockIn.ApprovedBy = objStockInd.ApprovedBy;
                    lockStockIn.IsLocked = objStockInd.IsLocked;
                    lockStockIn.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    lockStockIn.UpdateDateTime = Convert.ToDateTime(objStockInd.UpdateDateTime);
                    lockStockIn.SalesId = objStockInd.SalesId;
                    lockStockIn.PostCode = objStockInd.PostCode;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item not found.", "0" };
                }

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Unlock StockIn
        // ==============
        public String[] UnlockStockIn(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockIn = from d in db.TrnStockIns
                              where d.Id == id
                              select d;

                if (stockIn.Any())
                {
                    var unLockStockIn = stockIn.FirstOrDefault();
                    unLockStockIn.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unLockStockIn.UpdateDateTime = DateTime.Today;
                    unLockStockIn.IsLocked = false;
                    db.SubmitChanges();
                }

                return new String[] { "", "" };

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete Item
        // ===========
        public String[] DeleteStockIn(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockIn = from d in db.TrnStockIns
                              where d.Id == id
                              select d;

                if (stockIn.Any())
                {
                    if (stockIn.FirstOrDefault().IsLocked == false)
                    {
                        var deleteStockIn = stockIn.FirstOrDefault();
                        db.TrnStockIns.DeleteOnSubmit(deleteStockIn);
                        db.SubmitChanges();

                        return new String[] { "", "" };
                    }
                    else
                    {
                        return new String[] { "StockIn is Locked", "0" };
                    }
                }
                else
                {
                    return new String[] { "StockIn not found", "0" };
                }

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
