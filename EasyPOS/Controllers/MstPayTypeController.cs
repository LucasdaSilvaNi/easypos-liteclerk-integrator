using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstPayTypeController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // List Pay Type
        // =============
        public List<Entities.MstPayTypeEntity> ListPayType(String filter)
        {
            var payTypes = from d in db.MstPayTypes
                           where d.PayType.Contains(filter)
                           select new Entities.MstPayTypeEntity
                           {
                               Id = d.Id,
                               PayType = d.PayType,
                               AccountId = d.AccountId,
                               Account = d.AccountId != null ? d.MstAccount.Account : "",
                               SortNumber = d.SortNumber
                           };

            return payTypes.OrderBy(d => d.Id).ToList();
        }
    }
}
