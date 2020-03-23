using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvRepSalesReportCollectionDetailReportListEntity
    {
        public String ColumnTerminal { get; set; }
        public String ColumnCollectionDate { get; set; }
        public String ColumnCollectionNumber { get; set; }
        public String ColumnCustomerCode { get; set; }
        public String ColumnCustomer { get; set; }
        public String ColumnSalesNumber { get; set; }
        public String ColumnPayType { get; set; }
        public String ColumnAmount { get; set; }
        public String ColumnCheckNumber { get; set; }
        public String ColumnCheckDate { get; set; }
        public String ColumnCheckBank { get; set; }
        public String ColumnOtherInformation { get; set; }
        public Image ColumnPhoto { get; set; }
    }
}
