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

        public List<Entities.MstAccountEntity> DropDownListAccount()
        {
            var accounts = from d in db.MstAccounts
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               Account = d.Account
                           };
            return accounts.ToList();
        }

        public String[] AddPayType(Entities.MstPayTypeEntity objPayType)
        {
            try
            {
                Data.MstPayType addPayType = new Data.MstPayType()
                {
                    PayType = objPayType.PayType,
                    AccountId = objPayType.AccountId
                };
                db.MstPayTypes.InsertOnSubmit(addPayType);
                db.SubmitChanges();

                return new string[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        public String[] UpdatePayType(Entities.MstPayTypeEntity objPayType)
        {
            try
            {
                var currentPaytype = from d in db.MstPayTypes
                                     where d.Id == objPayType.Id
                                     select d;
                if (currentPaytype.Any())
                {
                    var updatePayType = currentPaytype.FirstOrDefault();
                    updatePayType.PayType = objPayType.PayType;
                    updatePayType.AccountId = objPayType.AccountId;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Pay Type not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }

        public String[] DeletePayType(Int32 id)
        {
            try
            {
                var payType = from d in db.MstPayTypes
                              where d.Id == id
                              select d;
                if (payType.Any())
                {
                    var deletePayType = payType.FirstOrDefault();
                    db.MstPayTypes.DeleteOnSubmit(deletePayType);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Pay Type not found", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
