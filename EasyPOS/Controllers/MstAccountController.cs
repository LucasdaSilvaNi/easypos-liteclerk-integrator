using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstAccountController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List Account
        // ============
        public List<Entities.MstAccountEntity> ListAccount(String filter)
        {
            var accounts = from d in db.MstAccounts
                           where d.Code.Contains(filter)
                           || d.Account.Contains(filter)
                           || d.AccountType.Contains(filter)
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               Code = d.Code,
                               Account = d.Account,
                               IsLocked = d.IsLocked,
                               AccountType = d.AccountType
                           };

            return accounts.OrderByDescending(d => d.Id).ToList();
        }

        // =================
        // List Account Type
        // =================
        public List<String> ListType()
        {
            return new List<String>
            {
                "ASSET", "LIABILITY", "SALES", "EXPENSES"
            };
        }

        // ===========
        // Add Account
        // ===========
        public String[] AddAccount(Entities.MstAccountEntity objAccount)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current user not found.", "0" };
                }

                Data.MstAccount addAccount = new Data.MstAccount()
                {
                    Code = objAccount.Code,
                    Account = objAccount.Account,
                    IsLocked = true,
                    AccountType = objAccount.AccountType
                };

                db.MstAccounts.InsertOnSubmit(addAccount);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(addAccount);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstAccount",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddAccount"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Update Account
        // ==============
        public String[] UpdateAccount(Entities.MstAccountEntity objAccount)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current user not found.", "0" };
                }

                var account = from d in db.MstAccounts
                              where d.Id == objAccount.Id
                              select d;

                if (account.Any())
                {
                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(account.FirstOrDefault());

                    var updateAccount = account.FirstOrDefault();
                    updateAccount.Code = objAccount.Code;
                    updateAccount.Account = objAccount.Account;
                    updateAccount.AccountType = objAccount.AccountType;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(account.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstAccount",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdateAccount"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Account not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==============
        // Delete Account
        // ==============
        public String[] DeleteAccount(int id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current user not found.", "0" };
                }

                var account = from d in db.MstAccounts
                              where d.Id == id
                              select d;

                if (account.Any())
                {
                    var deleteAccount = account.FirstOrDefault();
                    db.MstAccounts.DeleteOnSubmit(deleteAccount);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(account.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstAccount",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteAccount"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else
                {
                    return new String[] { "Account not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
