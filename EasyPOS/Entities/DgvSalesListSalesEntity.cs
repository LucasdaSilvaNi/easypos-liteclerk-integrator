using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvSalesListSalesEntity
    {
        public String ColumnEdit { get; set; }
        public String ColumnDelete { get; set; }
        public Int32 ColumnId { get; set; }
        public String ColumnTerminal { get; set; }
        public String ColumnSalesDate { get; set; }
        public String ColumnSalesNumber { get; set; }
        public String ColumnCustomer { get; set; }
        public String ColumnSalesAgent { get; set; }
        public String ColumnAmount { get; set; }
        public String ColumnSpace { get; set; }
        public Boolean ColumnIsLocked { get; set; }
        public Boolean ColumnIsTendered { get; set; }
        public Boolean ColumnIsCancelled { get; set; }
    }
}
