using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnCollectionLineListEntity
    {
        public String ColumnCollectionLineListButtonEdit { get; set; }
        public String ColumnCollectionLineListButtonDelete { get; set; }
        public Int32 ColumnCollectionLineListId { get; set; }
        public Int32 ColumnCollectionLineListCollectionId { get; set; }
        public String ColumnCollectionLineListAmount { get; set; }
        public String ColumnCollectionLineListPayType { get; set; }
        public Int32 ColumnCollectionLineListPayTypeId { get; set; }
        public String ColumnCollectionLineListCheckNumber { get; set; }
        public String ColumnCollectionLineListCheckDate { get; set; }
        public String ColumnCollectionLineListCheckBank { get; set; }
        public String ColumnCollectionLineListCreditCardVerificationCode { get; set; }
        public String ColumnCollectionLineListCreditCardNumber { get; set; }
        public String ColumnCollectionLineListCreditCardType { get; set; }
        public String ColumnCollectionLineListCreditCardBank { get; set; }
        public String ColumnCollectionLineListGiftCertificateNumber { get; set; }
        public String ColumnCollectionLineListOtherInformation { get; set; }
        public String ColumnCollectionLineListSalesReturnSalesId { get; set; }
        public String ColumnCollectionLineListStockInId { get; set; }

        public String ColumnCollectionLineListAccountId { get; set; }
        public String ColumnCollectionLineListCreditCardReferenceNumber { get; set; }
        public String ColumnCollectionLineListCreditCardHolderName { get; set; }
        public String ColumnCollectionLineListCreditCardExpiry { get; set; }
    }
}
