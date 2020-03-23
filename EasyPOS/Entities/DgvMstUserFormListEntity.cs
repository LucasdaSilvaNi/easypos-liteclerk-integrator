using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvMstUserFormListEntity
    {
        public String ColumnUserFormListButtonEdit { get; set; }
        public String ColumnUserFormListButtonDelete { get; set; }
        public Int32 ColumnUserFormListId { get; set; }
        public Int32 ColumnUserFormListFormId { get; set; }
        public String ColumnUserFormListForm { get; set; }
        public Int32 ColumnUserFormListUserId { get; set; }
        public Boolean ColumnUserFormListCanDelete { get; set; }
        public Boolean ColumnUserFormListCanAdd { get; set; }
        public Boolean ColumnUserFormListCanLock { get; set; }
        public Boolean ColumnUserFormListCanUnlock { get; set; }
        public Boolean ColumnUserFormListCanPrint { get; set; }
        public Boolean ColumnUserFormListCanPreview { get; set; }
        public Boolean ColumnUserFormListCanEdit { get; set; }
        public Boolean ColumnUserFormListCanTender { get; set; }
        public Boolean ColumnUserFormListCanDiscount { get; set; }
        public Boolean ColumnUserFormListCanView { get; set; }
        public Boolean ColumnUserFormListCanSplit { get; set; }
        public Boolean ColumnUserFormListCanCancel { get; set; }
        public Boolean ColumnUserFormListCanReturn { get; set; }
    }
}