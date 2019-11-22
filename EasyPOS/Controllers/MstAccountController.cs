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

        public List<String> ListType()
        {
            return new List<String>
            {
                "ASSET", "LIABILITY", "SALES", "EXPENSES"
            };
        }

        public String[] AddAccount(Entities.MstAccountEntity objAccount)
        {
            try
            {
                Data.MstAccount addAccount = new Data.MstAccount()
                {
                    Code = objAccount.Code,
                    Account = objAccount.Account,
                    IsLocked = true,
                    AccountType = objAccount.AccountType
                };

                db.MstAccounts.InsertOnSubmit(addAccount);
                db.SubmitChanges();
                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        public String[] UpdateAccount(Entities.MstAccountEntity objAccount)
        {
            try
            {
                var currentAccount = from d in db.MstAccounts
                                     where d.Id == objAccount.Id
                                     select d;
                if (currentAccount.Any())
                {
                    var updateAccount = currentAccount.FirstOrDefault();
                    updateAccount.Code = objAccount.Code;
                    updateAccount.Account = objAccount.Account;
                    updateAccount.AccountType = objAccount.AccountType;
                    db.SubmitChanges();

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

        public String[] DeleteAccount(int id)
        {
            try
            {
                var account = from d in db.MstAccounts
                              where d.Id == id
                              select d;
                if (account.Any())
                {
                    var deleteAccount = account.FirstOrDefault();
                    db.MstAccounts.DeleteOnSubmit(deleteAccount);
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
