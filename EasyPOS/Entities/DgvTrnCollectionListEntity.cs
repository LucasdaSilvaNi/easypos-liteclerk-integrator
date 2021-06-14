using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnCollectionListEntity
    {
        public String ColumnCollectionListButtonEdit { get; set; }
        public String ColumnCollectionListButtonDelete { get; set; }
        public Int32 ColumnCollectionListId { get; set; }
        public Int32 ColumnCollectionListPeriodId { get; set; }
        public String ColumnCollectionListCollectionDate { get; set; }
        public String ColumnCollectionListCollectionNumber { get; set; }
        public Int32 ColumnCollectionListTerminalId { get; set; }
        public String ColumnCollectionListTerminal { get; set; }
        public String ColumnCollectionListCancelledCollectionNumber { get; set; }
        public String ColumnCollectionListManualORNumber { get; set; }
        public Int32 ColumnCollectionListCustomerId { get; set; }
        public String ColumnCollectionListCustomer { get; set; }
        public String ColumnCollectionListRemarks { get; set; }
        public Int32? ColumnCollectionListSalesId { get; set; }
        public Decimal ColumnCollectionListSalesBalanceAmount { get; set; }
        public String ColumnCollectionListAmount { get; set; }
        public String ColumnCollectionListTenderAmount { get; set; }
        public String ColumnCollectionListChangeAmount { get; set; }
        public String ColumnCollectionListPreparedBy { get; set; }
        public String ColumnCollectionListCheckedBy { get; set; }
        public String ColumnCollectionListApprovedBy { get; set; }
        public Boolean ColumnCollectionListIsCancelled { get; set; }
        public Boolean ColumnCollectionListIsLocked { get; set; }
        public Int32 ColumnCollectionListEntryUserId { get; set; }
        public String ColumnCollectionListEntryDateTime { get; set; }
        public Int32 ColumnCollectionListUpdateUserId { get; set; }
        public String ColumnCollectionListUpdateDateTime { get; set; }
    }
}
