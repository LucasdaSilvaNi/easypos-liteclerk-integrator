using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class RepSalesReportCollectionDetailReportEntity
    {
        public Int32 Id { get; set; }
        public Int32 CollectionId { get; set; }
        public String CollectionDate { get; set; }
        public String CollectionNumber { get; set; }
        public Int32 TerminalId { get; set; }
        public String Terminal { get; set; }
        public String ManualORNumber { get; set; }
        public String CustomerCode { get; set; }
        public String Customer { get; set; }
        public Decimal ChangeAmount { get; set; }
        public Boolean IsCancelled { get; set; }
        public String SalesNumber { get; set; }
        public Decimal Amount { get; set; }
        public Int32 PayTypeId { get; set; }
        public String PayTypeCode { get; set; }
        public String PayType { get; set; }
        public String CheckNumber { get; set; }
        public String CheckDate { get; set; }
        public String CheckBank { get; set; }
        public String CreditCardVerificationCode { get; set; }
        public String CreditCardNumber { get; set; }
        public String CreditCardType { get; set; }
        public String CreditCardBank { get; set; }
        public String GiftCertificateNumber { get; set; }
        public String OtherInformation { get; set; }
        public Int32? StockInId { get; set; }
        public Int32 AccountId { get; set; }
        public String CreditCardReferenceNumber { get; set; }
        public String CreditCardHolderName { get; set; }
        public String CreditCardExpiry { get; set; }
    }
}
