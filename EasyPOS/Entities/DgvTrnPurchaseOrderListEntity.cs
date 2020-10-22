using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
   public class DgvTrnPurchaseOrderListEntity
    {
        public String ColumnPurchaseOrderListButtonEdit { get; set; }
        public String ColumnPurchaseOrderListButtonDelete { get; set; }
        public Int32 ColumnPurchaseOrderListId { get; set; }
        public Int32 ColumnPurchaseOrderListPeriodId { get; set; }
        public String ColumnPurchaseOrderListPurchaseOrderDate { get; set; }
        public String ColumnPurchaseOrderListPurchaseOrderNumber { get; set; }
        public String ColumnPurchaseOrderListAmount { get; set; }
        public String ColumnPurchaseOrderListSupplier { get; set; }
        public String ColumnPurchaseOrderListRemarks { get; set; }
        public String ColumnPurchaseOrderListPreparedBy { get; set; }
        public String ColumnPurchaseOrderListCheckedBy { get; set; }
        public String ColumnPurchaseOrderListApprovedBy { get; set; }
        public Boolean ColumnPurchaseOrderListIsLocked { get; set; }
        public Int32 ColumnPurchaseOrderListEntryUserId { get; set; }
        public String ColumnPurchaseOrderListEntryDateTime { get; set; }
        public Int32 ColumnPurchaseOrderListUpdateUserId { get; set; }
        public String ColumnPurchaseOrderListUpdateDateTime { get; set; }
        public String ColumnPurchaseOrderListRequestedBy { get; set; }
    }
}
