using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvMstDiscountingListEntity
    {
        public String ColumnDiscountListButtonEdit { get; set; }
        public String ColumnDiscountListButtonDelete { get; set; }
        public Int32 ColumnDiscountListId { get; set; }
        public String ColumnDiscountListDiscount { get; set; }
        public String ColumnDiscountListDiscountRate { get; set; }
        public String ColumnDiscountListDiscountAmount { get; set; }
        public Boolean ColumnDiscountListIsLocked { get; set; }
    }
}