using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkMstArticleItem
    {
        public Int32 Id { get; set; }
        public Int32 ArticleId { get; set; }
        public LiteclerkMstArticle Article { get; set; }
        public String ArticleManualCode { get; set; }
        public String SKUCode { get; set; }
        public String BarCode { get; set; }
        public String Description { get; set; }
        public Int32 UnitId { get; set; }
        public LiteclerkMstUnit Unit { get; set; }
        public String Category { get; set; }
        public Boolean IsInventory { get; set; }
        public Decimal Price { get; set; }
        public Int32 RRVATId { get; set; }
        public LiteclerkMstTax RRVAT { get; set; }
        public Int32 SIVATId { get; set; }
        public LiteclerkMstTax SIVAT { get; set; }
        public List<LiteclerkMstArticleItemPrice> ArticleItemPrices { get; set; }
    }
}
