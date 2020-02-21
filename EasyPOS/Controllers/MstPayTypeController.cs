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
                               PayTypeCode = d.PayTypeCode,
                               PayType = d.PayType,
                               AccountId = d.AccountId,
                               Account = d.AccountId != null ? d.MstAccount.Account : "",
                               SortNumber = d.SortNumber
                           };

            return payTypes.OrderBy(d => d.Id).ToList();
        }

        // ============
        // List Account
        // ============
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

        // ============
        // Add Pay Type
        // ============
        public String[] AddPayType(Entities.MstPayTypeEntity objPayType)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstPayType addPayType = new Data.MstPayType()
                {
                    PayTypeCode = objPayType.PayTypeCode,
                    PayType = objPayType.PayType,
                    AccountId = objPayType.AccountId
                };

                db.MstPayTypes.InsertOnSubmit(addPayType);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(addPayType);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstPayType",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddPayType"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new string[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Update Pay Type
        // ===============
        public String[] UpdatePayType(Entities.MstPayTypeEntity objPayType)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var payType = from d in db.MstPayTypes
                              where d.Id == objPayType.Id
                              select d;

                if (payType.Any())
                {
                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(payType.FirstOrDefault());

                    var updatePayType = payType.FirstOrDefault();
                    updatePayType.PayTypeCode = objPayType.PayTypeCode;
                    updatePayType.PayType = objPayType.PayType;
                    updatePayType.AccountId = objPayType.AccountId;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(payType.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstPayType",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdatePayType"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Pay type not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new string[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete Pay Type
        // ===============
        public String[] DeletePayType(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var payType = from d in db.MstPayTypes
                              where d.Id == id
                              select d;

                if (payType.Any())
                {
                    var deletePayType = payType.FirstOrDefault();
                    db.MstPayTypes.DeleteOnSubmit(deletePayType);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(payType.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstPayType",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeletePayType"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Pay type not found", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
