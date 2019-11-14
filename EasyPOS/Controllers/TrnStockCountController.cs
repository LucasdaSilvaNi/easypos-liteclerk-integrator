using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockCountController
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

        // ================
        // List Stock-Count 
        // ================
        public List<Entities.TrnStockCountEntity> ListStockCount(DateTime dateFilter, String filter)
        {
            var stockCounts = from d in db.TrnStockCounts
                              where d.StockCountDate == dateFilter
                              && d.StockCountNumber.Contains(filter)
                              select new Entities.TrnStockCountEntity
                              {
                                  Id = d.Id,
                                  PeriodId = d.PeriodId,
                                  StockCountDate = d.StockCountDate.ToShortDateString(),
                                  StockCountNumber = d.StockCountNumber,
                                  Remarks = d.Remarks,
                                  PreparedBy = d.PreparedBy,
                                  CheckedBy = d.CheckedBy,
                                  ApprovedBy = d.ApprovedBy,
                                  IsLocked = d.IsLocked,
                                  EntryUserId = d.EntryUserId,
                                  EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                  UpdateUserId = d.UpdateUserId,
                                  UpdateDateTime = d.UpdateDateTime.ToShortDateString()
                              };

            return stockCounts.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // Detail Stock-Count
        // ==================
        public Entities.TrnStockCountEntity DetailStockCount(Int32 id)
        {
            var stockCount = from d in db.TrnStockCounts
                             where d.Id == id
                             select new Entities.TrnStockCountEntity
                             {
                                 Id = d.Id,
                                 PeriodId = d.PeriodId,
                                 StockCountDate = d.StockCountDate.ToShortDateString(),
                                 StockCountNumber = d.StockCountNumber,
                                 Remarks = d.Remarks,
                                 PreparedBy = d.PreparedBy,
                                 CheckedBy = d.CheckedBy,
                                 ApprovedBy = d.ApprovedBy,
                                 IsLocked = d.IsLocked,
                                 EntryUserId = d.EntryUserId,
                                 EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                 UpdateUserId = d.UpdateUserId,
                                 UpdateDateTime = d.UpdateDateTime.ToShortDateString()
                             };

            return stockCount.FirstOrDefault();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListStockCountUser()
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
        // Add Stock-Count
        // ===============
        public String[] AddStockCount()
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

                String stockCountNumber = "0000000001";
                var lastStockCount = from d in db.TrnStockCounts.OrderByDescending(d => d.Id) select d;
                if (lastStockCount.Any())
                {
                    Int32 newStockCountNumber = Convert.ToInt32(lastStockCount.FirstOrDefault().StockCountNumber) + 1;
                    stockCountNumber = FillLeadingZeroes(newStockCountNumber, 10);
                }

                Data.TrnStockCount newStockCount = new Data.TrnStockCount()
                {
                    PeriodId = period.FirstOrDefault().Id,
                    StockCountDate = DateTime.Today,
                    StockCountNumber = stockCountNumber,
                    Remarks = "",
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    EntryUserId = currentUserLogin.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Now,
                    UpdateUserId = currentUserLogin.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Now
                };

                db.TrnStockCounts.InsertOnSubmit(newStockCount);
                db.SubmitChanges();

                return new String[] { "", newStockCount.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Lock Stock-Count
        // ================
        public String[] LockStockCount(Int32 id, Entities.TrnStockCountEntity objStockCount)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objStockCount.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objStockCount.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var stockCount = from d in db.TrnStockCounts
                                 where d.Id == id
                                 select d;

                if (stockCount.Any())
                {
                    if (stockCount.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockStockCount = stockCount.FirstOrDefault();
                    lockStockCount.StockCountDate = Convert.ToDateTime(objStockCount.StockCountDate);
                    lockStockCount.Remarks = objStockCount.Remarks;
                    lockStockCount.CheckedBy = objStockCount.CheckedBy;
                    lockStockCount.ApprovedBy = objStockCount.ApprovedBy;
                    lockStockCount.IsLocked = true;
                    lockStockCount.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    lockStockCount.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Count not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==================
        // Unlock Stock-Count
        // ==================
        public String[] UnlockStockCount(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockCount = from d in db.TrnStockCounts
                                 where d.Id == id
                                 select d;

                if (stockCount.Any())
                {
                    if (stockCount.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unlockStockCount = stockCount.FirstOrDefault();
                    unlockStockCount.IsLocked = false;
                    unlockStockCount.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unlockStockCount.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Count not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==================
        // Delete Stock-Count
        // ==================
        public String[] DeleteStockCount(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockCount = from d in db.TrnStockCounts
                                 where d.Id == id
                                 select d;

                if (stockCount.Any())
                {
                    if (stockCount.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Stock-Count is locked", "0" };
                    }

                    var deleteStockCount = stockCount.FirstOrDefault();
                    db.TrnStockCounts.DeleteOnSubmit(deleteStockCount);
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Count not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
