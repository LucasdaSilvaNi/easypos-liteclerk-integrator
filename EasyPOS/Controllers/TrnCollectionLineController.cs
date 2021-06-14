using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnCollectionLineController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========================
        // List Collection Line
        // ========================
        public List<Entities.TrnCollectionLineEntity> ListCollectionLine(Int32 collectionId)
        {
            var collectionLine = from d in db.TrnCollectionLines
                                 where d.CollectionId == collectionId
                                 select new Entities.TrnCollectionLineEntity
                                     {
                                        Id = d.Id,
                                        CollectionId = d.CollectionId,
                                        Amount = d.Amount,
                                        PayTypeId = d.PayTypeId,
                                        PayType = d.MstPayType.PayType,
                                        CheckNumber = d.CheckNumber,
                                        CheckDate = Convert.ToString(d.CheckDate),
                                        CheckBank = d.CheckBank,
                                        CreditCardVerificationCode = d.CreditCardVerificationCode,
                                        CreditCardNumber = d.CreditCardNumber,
                                        CreditCardType = d.CreditCardType,
                                        CreditCardBank = d.CreditCardBank,
                                        GiftCertificateNumber = d.GiftCertificateNumber,
                                        OtherInformation = d.OtherInformation,
                                        SalesReturnSalesId = d.SalesReturnSalesId,
                                        StockInId = d.StockInId,
                                        AccountId = d.AccountId,
                                        CreditCardReferenceNumber = d.CreditCardReferenceNumber,
                                        CreditCardHolderName = d.CreditCardHolderName,
                                        CreditCardExpiry = d.CreditCardExpiry
                                     };

            return collectionLine.OrderByDescending(d => d.Id).ToList();
        }

        // ==========================
        // Delete Collection Line
        // ==========================
        public String[] DeleteCollectionLine(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var collectionLine = from d in db.TrnCollectionLines
                                        where d.Id == id
                                        select d;

                if (collectionLine.Any())
                {
                    var deleteCollectionLine = collectionLine.FirstOrDefault();
                    db.TrnCollectionLines.DeleteOnSubmit(deleteCollectionLine);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(collectionLine.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "TrnCollectionLine",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteCollectionLine"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Collection line not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

    }
}
