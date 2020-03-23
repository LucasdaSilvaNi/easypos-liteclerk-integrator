using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class DgvSysSysUtilitiesAuditTrailListEntity
    {
        public Int32 ColumnAuditTrailListId { get; set; }
        public Int32 ColumnAuditTrailListUserId { get; set; }
        public String ColumnAuditTrailListUser { get; set; }
        public String ColumnAuditTrailListAuditDate { get; set; }
        public String ColumnAuditTrailListTableInformation { get; set; }
        public String ColumnAuditTrailListRecordInformation { get; set; }
        public String ColumnAuditTrailListFormInformation { get; set; }
        public String ColumnAuditTrailListActionInformation { get; set; }
        public String ColumnAuditTrailListSpace { get; set; }

    }
}
