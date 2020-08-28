using EasyPOS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Entities
{
    public class RepRemitanceReportEntity
    {
        public String Terminal { get; set; }
        public String PreparedBy { get; set; }
        public String RemittanceDate { get; set; }
        public List<TrnCollectionLineEntity> CollectionLines { get; set; }
        public List<TrnDisbursementEntity> Disbursements { get; set; }
        public String DisbursementNumber { get; set; }
        public String DisbursementType { get; set; }
        public String PayType { get; set; }
        public Decimal TotalCollection { get; set; }
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
        public Decimal RemittedAmount { get; set; }
        public Decimal CashCollectedAmount { get; set; }
        public Decimal CashInAmount { get; set; }
        public Decimal CashOutAmount { get; set; }
        public Decimal OverShortAmount { get; set; }
    }
}
