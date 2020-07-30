using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvTrnDisbursementListEntity
    {
        public String ColumnDisbursementListButtonEdit { get; set; }
        public String ColumnDisbursementListButtonDelete { get; set; }
        public Int32 ColumnDisbursementListId { get; set; }
        public String ColumnDisbursementListDisbursementDate { get; set; }
        public String ColumnDisbursementListDisbursementNumber { get; set; }
        public String ColumnDisbursementListDisbursementType { get; set; }
        public String ColumnDisbursementListPayType { get; set; }
        public String ColumnDisbursementListPayee { get; set; }
        public String ColumnDisbursementListAmount { get; set; }
        public String ColumnDisbursementListRemarks { get; set; }
        public Boolean ColumnDisbursementListIsLocked { get; set; }
    }
}