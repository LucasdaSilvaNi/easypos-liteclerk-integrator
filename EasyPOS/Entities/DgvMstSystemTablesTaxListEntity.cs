using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvMstSystemTablesTaxListEntity
    {
        public String ColumnTaxListButtonEdit { get; set; }
        public String ColumnTaxListButtonDelete { get; set; }
        public Int32 ColumnTaxListId { get; set; }
        public String ColumnTaxListCode { get; set; }
        public String ColumnTaxListTax { get; set; }
        public String ColumnTaxListRate { get; set; }
        public Int32 ColumnTaxListAccountId { get; set; }
        public String ColumnTaxListAccount { get; set; }
    }
}
