using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockOutController
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

        // ==============
        // Stock-Out List
        // ==============
        public List<Entities.TrnStockOutEntity> ListStockOut(DateTime dateFilter, String filter)
        {
            var stockOuts = from d in db.TrnStockOuts
                            where d.StockOutDate == dateFilter
                            && d.StockOutNumber.Contains(filter)
                            select new Entities.TrnStockOutEntity
                            {
                                Id = d.Id,
                                PeriodId = d.PeriodId,
                                StockOutDate = d.StockOutDate.ToShortDateString(),
                                StockOutNumber = d.StockOutNumber,
                                AccountId = d.AccountId,
                                Account = d.MstAccount.Account,
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

        // ================
        // Stock-Out Detail
        // ================
        public Entities.TrnStockOutEntity DetailStockOut(Int32 id)
        {
            var stockOut = from d in db.TrnStockOuts
                           where d.Id == id
                           select new Entities.TrnStockOutEntity
                           {
                               Id = d.Id,
                               PeriodId = d.PeriodId,
                               StockOutDate = d.StockOutDate.ToShortDateString(),
                               StockOutNumber = d.StockOutNumber,
                               AccountId = d.AccountId,
                               Account = d.MstAccount.Account,
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

        // ========================
        // Dropdown List - Account
        // ========================
        public List<Entities.MstAccountEntity> DropdownListStockOutAccount()
        {
            var accounts = from d in db.MstAccounts
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               Account = d.Account
                           };

            return accounts.ToList();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListStockOutUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // =============
        // Add Stock-Out
        // =============
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
                    return new String[] { "Periods not found.", "0" };
                }

                var account = from d in db.MstAccounts select d;
                if (account.Any() == false)
                {
                    return new String[] { "Account not found.", "0" };
                }

                String stockOutNumber = "0000000001";
                var lastStockOut = from d in db.TrnStockOuts.OrderByDescending(d => d.Id) select d;
                if (lastStockOut.Any())
                {
                    Int32 newStockOutNumber = Convert.ToInt32(lastStockOut.FirstOrDefault().StockOutNumber) + 1;
                    stockOutNumber = FillLeadingZeroes(newStockOutNumber, 10);
                }

                Data.TrnStockOut newStockOut = new Data.TrnStockOut()
                {
                    PeriodId = period.FirstOrDefault().Id,
                    StockOutDate = DateTime.Today,
                    StockOutNumber = stockOutNumber,
                    AccountId = account.FirstOrDefault().Id,
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

                db.TrnStockOuts.InsertOnSubmit(newStockOut);
                db.SubmitChanges();

                return new String[] { "", newStockOut.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Lock Stock-Out
        // ==============
        public String[] LockStockOut(Int32 id, Entities.TrnStockOutEntity objStockOut)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var account = from d in db.MstAccounts
                              where d.Id == objStockOut.AccountId
                              && d.IsLocked == true
                              select d;

                if (account.Any() == false)
                {
                    return new String[] { "Account not found.", "0" };
                }

                var checkedByUser = from d in db.MstUsers
                                    where d.Id == objStockOut.CheckedBy
                                    && d.IsLocked == true
                                    select d;

                if (checkedByUser.Any() == false)
                {
                    return new String[] { "Checked by user not found.", "0" };
                }

                var approvedByUser = from d in db.MstUsers
                                     where d.Id == objStockOut.ApprovedBy
                                     && d.IsLocked == true
                                     select d;

                if (approvedByUser.Any() == false)
                {
                    return new String[] { "Approved by user not found.", "0" };
                }

                var stockOut = from d in db.TrnStockOuts
                               where d.Id == id
                               select d;

                if (stockOut.Any())
                {
                    if (stockOut.FirstOrDefault().IsLocked == true)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    var lockStockOut = stockOut.FirstOrDefault();
                    lockStockOut.AccountId = objStockOut.AccountId;
                    lockStockOut.Remarks = objStockOut.Remarks;
                    lockStockOut.CheckedBy = objStockOut.CheckedBy;
                    lockStockOut.ApprovedBy = objStockOut.ApprovedBy;
                    lockStockOut.IsLocked = true;
                    lockStockOut.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    lockStockOut.UpdateDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Unlock Stock-Out
        // ================
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
                    if (stockOut.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    var unLockStockOut = stockOut.FirstOrDefault();
                    unLockStockOut.IsLocked = false;
                    unLockStockOut.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unLockStockOut.UpdateDateTime = DateTime.Today;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Stock-Out not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Delete Stock-Out
        // ================
        public String[] DeleteStockOut(Int32 id)
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
                    if (stockOut.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Stock-Out is locked", "0" };
                    }

                    var deleteStockOut = stockOut.FirstOrDefault();
                    db.TrnStockOuts.DeleteOnSubmit(deleteStockOut);
                    db.SubmitChanges();

                    return new String[] { "", "" };
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
