using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class RepRemitanceReportEntity
    {
        public String RemittanceNumber { get; set; }
        public String RemittanceDate { get; set; }
        public String Terminal { get; set; }
        public String PreparedBy { get; set; }
        public String Remarks { get; set; }
        public Decimal? Amount1000 { get; set; }
        public Decimal? Amount500 { get; set; }
        public Decimal? Amount200 { get; set; }
        public Decimal? Amount100 { get; set; }
        public Decimal? Amount50 { get; set; }
        public Decimal? Amount20 { get; set; }
        public Decimal? Amount10 { get; set; }
        public Decimal? Amount5 { get; set; }
        public Decimal? Amount1 { get; set; }
        public Decimal? Amount025 { get; set; }
        public Decimal? Amount010 { get; set; }
        public Decimal? Amount005 { get; set; }
        public Decimal? Amount001 { get; set; }
        public Decimal? Total { get; set; }
        public List<TrnCollectionLineEntity> CollectionLines { get; set; }
        public Decimal TotalCollection { get; set; }
    }
}
