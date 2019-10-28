using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstTaxController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========
        // List Tax
        // ========
        public List<Entities.MstTaxEntity> ListTax(String filter)
        {
            var taxes = from d in db.MstTaxes
                        where d.Code.Contains(filter)
                        || d.Tax.Contains(filter)
                        || d.MstAccount.Account.Contains(filter)
                        select new Entities.MstTaxEntity
                        {
                            Id = d.Id,
                            Code = d.Code,
                            Tax = d.Tax,
                            Rate = d.Rate,
                            AccountId = d.AccountId,
                            Account = d.MstAccount.Account
                        };

            return taxes.OrderByDescending(d => d.Id).ToList();
        }
    }
}
