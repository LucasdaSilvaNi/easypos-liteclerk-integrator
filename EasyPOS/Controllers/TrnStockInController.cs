using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockInController
    {
        // ============
        // Data Context
        // ============
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

        // =============
        // Stock-In List
        // =============
        public List<Entities.TrnStockInEntity> ListStockIn(DateTime dateFilter, String filter)
        {
            var stockIns = from d in db.TrnStockIns
                           where d.StockInDate == dateFilter
                           && d.StockInNumber.Contains(filter)
                           select new Entities.TrnStockInEntity
                           {
                               Id = d.Id,
                               PeriodId = d.PeriodId,
                               StockInDate = d.StockInDate.ToShortDateString(),
                               StockInNumber = d.StockInNumber,
                               SupplierId = d.SupplierId,
                               Supplier = d.MstSupplier.Supplier,
                               Remarks = d.Remarks,
                               IsReturn = d.IsReturn,
                               CollectionId = d.CollectionId,
                               CollectionNumber = d.CollectionId != null ? d.TrnCollection.CollectionNumber : "",
                               SalesNumber = d.CollectionId != null ? d.TrnCollection.TrnSale.SalesNumber : "",
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

        // ===============
        // Stock-In Detail
        // ===============
        public Entities.TrnStockInEntity DetailStockIn(Int32 id)
        {
            var stockIn = from d in db.TrnStockIns
                          where d.Id == id
                          select new Entities.TrnStockInEntity
                          {
                              Id = d.Id,
                              PeriodId = d.PeriodId,
                              StockInDate = d.StockInDate.ToShortDateString(),
                              StockInNumber = d.StockInNumber,
                              SupplierId = d.SupplierId,
                              Supplier = d.MstSupplier.Supplier,
                              Remarks = d.Remarks,
                              IsReturn = d.IsReturn,
                              CollectionId = d.CollectionId,
                              CollectionNumber = d.CollectionId != null ? d.TrnCollection.CollectionNumber : "",
                              SalesNumber = d.CollectionId != null ? d.TrnCollection.TrnSale.SalesNumber : "",
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

            return stockIn.FirstOrDefault();
        }

        // ========================
        // Dropdown List - Supplier
        // ========================
        public List<Entities.MstSupplierEntity> DropdownListStockInSupplier()
        {
            var suppliers = from d in db.MstSuppliers
                            select new Entities.MstSupplierEntity
                            {
                                Id = d.Id,
                                Supplier = d.Supplier
                            };

            return suppliers.ToList();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListStockInUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // ============ 
        // Add Stock-In
        // ============
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
                if (period.Any() == false)
                {
                    return new String[] { "Periods not found.", "0" };
                }

                var supplier = from d in db.MstSuppliers select d;
                if (supplier.Any() == false)
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                String stockInNumber = "0000000001";
                var lastStockIn = from d in db.TrnStockIns.OrderByDescending(d => d.Id) select d;
                if (lastStockIn.Any())
                {
                    Int32 newStockInNumber = Convert.ToInt32(lastStockIn.FirstOrDefault().StockInNumber) + 1;
                    stockInNumber = FillLeadingZeroes(newStockInNumber, 10);
                }

                Data.TrnStockIn newStockIn = new Data.TrnStockIn()
                {
                    PeriodId = period.FirstOrDefault().Id,
                    StockInDate = DateTime.Today,
                    StockInNumber = stockInNumber,
                    SupplierId = supplier.FirstOrDefault().Id,
                    Remarks = "",
                    IsReturn = false,
                    CollectionId = null,
                    PurchaseOrderId = null,
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    SalesId = null,
                    PostCode = null,
                    IsLocked = false,
                    EntryUserId = currentUserLogin.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Now,
                    UpdateUserId = currentUserLogin.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Now
                };

                db.TrnStockIns.InsertOnSubmit(newStockIn);
                db.SubmitChanges();

                return new String[] { "", newStockIn.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============
        // Lock Stock-In
        // =============
        public String[] LockStockIn(Int32 id, Entities.TrnStockInEntity objStockIn)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var supplier = from d in db.MstSuppliers
                               where d.Id == objStockIn.SupplierId
                               && d.IsLocked == true
                               select d;

                if (supplier.Any() == false)
                {
                    return new String[] { "Supplier not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objStockIn.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objStockIn.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var stockIn = from d in db.TrnStockIns
                              where d.Id == id
                              select d;

                if (stockIn.Any())
                {
                    if (stockIn.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockStockIn = stockIn.FirstOrDefault();
                    lockStockIn.StockInDate = Convert.ToDateTime(objStockIn.StockInDate);
                    lockStockIn.SupplierId = objStockIn.SupplierId;
                    lockStockIn.Remarks = objStockIn.Remarks;
                    lockStockIn.IsReturn = objStockIn.IsReturn;
                    lockStockIn.CheckedBy = objStockIn.CheckedBy;
                    lockStockIn.ApprovedBy = objStockIn.ApprovedBy;
                    lockStockIn.IsLocked = true;
                    lockStockIn.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    lockStockIn.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Unlock Stock-In
        // ===============
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
                    if (stockIn.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockStockIn = stockIn.FirstOrDefault();
                    unlockStockIn.IsLocked = false;
                    unlockStockIn.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unlockStockIn.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete Stock-In
        // ===============
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
                    if (stockIn.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Stock-In is locked", "0" };
                    }

                    var deleteStockIn = stockIn.FirstOrDefault();
                    db.TrnStockIns.DeleteOnSubmit(deleteStockIn);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-In not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
