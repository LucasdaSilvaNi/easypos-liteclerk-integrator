using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockOutController
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

        public List<Entities.TrnStockOutEntity> ListStockOut(string filter)
        {
            var stockOuts = from d in db.TrnStockOuts
                            where d.StockOutNumber.Contains(filter)
                            select new Entities.TrnStockOutEntity
                            {
                                Id = d.Id,
                                PeriodId = d.PeriodId,
                                StockOutDate = d.StockOutDate.ToShortDateString(),
                                StockOutNumber = d.StockOutNumber,
                                AccountId = d.AccountId,
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

            return stockOuts.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // StockOut Detail
        // ==============
        public Entities.TrnStockOutEntity DetailStockOut(Int32 id)
        {
            var stockOut = from d in db.TrnStockOuts
                           where d.Id == id
                           where d.Id == id
                           select new Entities.TrnStockOutEntity
                           {
                               Id = d.Id,
                               PeriodId = d.PeriodId,
                               StockOutDate = d.StockOutDate.ToShortDateString(),
                               StockOutNumber = d.StockOutNumber,
                               AccountId = d.AccountId,
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

            return stockOut.FirstOrDefault();
        }

        // ============
        // Add StockOut
        // ============
        public String[] AddStockOut()
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
                    return new String[] { "Perios not found.", "0" };
                }

                String stockOutNumber = "0000000001";
                var lastStockOutNumber = from d in db.TrnStockOuts.OrderByDescending(d => d.Id) select d;
                if (lastStockOutNumber.Any())
                {
                    Int32 newStockOutCode = Convert.ToInt32(lastStockOutNumber.FirstOrDefault().StockOutNumber) + 1;
                    stockOutNumber = FillLeadingZeroes(newStockOutCode, 10);
                }

                var account = from d in db.MstAccounts
                              select d;
                if (account.Any() == false)
                {
                    return new String[] { "Account not found.", "0" };
                }

                Data.TrnStockOut newStockOut = new Data.TrnStockOut()
                {
                    PeriodId = period.FirstOrDefault().Id,
                    StockOutDate = DateTime.Today,
                    StockOutNumber = stockOutNumber,
                    AccountId = account.FirstOrDefault().Id,
                    Remarks = "NA",
                    PreparedBy = currentUserLogin.FirstOrDefault().Id,
                    CheckedBy = currentUserLogin.FirstOrDefault().Id,
                    ApprovedBy = currentUserLogin.FirstOrDefault().Id,
                    IsLocked = false,
                    EntryUserId = currentUserLogin.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Today,
                    UpdateUserId = currentUserLogin.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Today
                };

                db.TrnStockOuts.InsertOnSubmit(newStockOut);
                db.SubmitChanges();

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============
        // Lock StockOut
        // =============
        public String[] LockStockOut(Int32 id, Entities.TrnStockOutEntity objStockOut)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                               where d.Id == id
                               select d;

                if (stockOut.Any())
                {
                    var updateStockOut = stockOut.FirstOrDefault();
                    updateStockOut.PeriodId = objStockOut.PeriodId;
                    updateStockOut.Remarks = objStockOut.Remarks;
                    updateStockOut.CheckedBy = currentUserLogin.FirstOrDefault().Id;
                    updateStockOut.ApprovedBy = currentUserLogin.FirstOrDefault().Id;
                    updateStockOut.IsLocked = true;
                    updateStockOut.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    updateStockOut.UpdateDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
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

        // ===============
        // Unlock StockOut
        // ===============
        public String[] UnlockStockOut(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                              where d.Id == id
                              select d;

                if (stockOut.Any())
                {
                    var unLockStockOut = stockOut.FirstOrDefault();
                    unLockStockOut.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unLockStockOut.UpdateDateTime = DateTime.Today;
                    unLockStockOut.IsLocked = false;
                    db.SubmitChanges();
                }

                return new String[] { "", "" };

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete StockOut
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

                var stockOut = from d in db.TrnStockOuts
                              where d.Id == id
                              select d;

                if (stockOut.Any())
                {
                    if (stockOut.FirstOrDefault().IsLocked == false)
                    {
                        var deleteStockOut = stockOut.FirstOrDefault();
                        db.TrnStockOuts.DeleteOnSubmit(deleteStockOut);
                        db.SubmitChanges();

                        return new String[] { "", "" };
                    }
                    else
                    {
                        return new String[] { "StockOut is Locked", "0" };
                    }
                }
                else
                {
                    return new String[] { "StockOut not found", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
