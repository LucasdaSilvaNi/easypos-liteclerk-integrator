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
    }
}
