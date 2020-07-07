using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvSysDispatchStationSalesListEntity
    {
        public String ColumnButtonDispatch { get; set; }
        public Int32 ColumnId { get; set; }
        public String ColumnTerminal { get; set; }
        public String ColumnSalesDate { get; set; }
        public String ColumnSalesNumber { get; set; }
        public String ColumnManualSalesNumber { get; set; }
        public String ColumnCustomer { get; set; }
        public String ColumnCustomerAddress { get; set; }
        public String ColumnDelivery { get; set; }
        public String ColumnNumberOfItems { get; set; }
        public Boolean ColumnIsLocked { get; set; }
        public Boolean ColumnIsTendered { get; set; }
        public Boolean ColumnIsCancelled { get; set; }
        public Boolean ColumnIsDispatched { get; set; }
        public String ColumnPrepared { get; set; }
        public String ColumnStatus { get; set; }
        public String ColumnSpace { get; set; }
    }
}