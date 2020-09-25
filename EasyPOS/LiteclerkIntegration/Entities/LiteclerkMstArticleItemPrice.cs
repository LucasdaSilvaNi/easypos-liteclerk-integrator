using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkMstArticleItemPrice
    {
        public Int32 Id { get; set; }
        public Int32 ArticleId { get; set; }
        public LiteclerkMstArticleItem ArticleItem { get; set; }
        public String PriceDescription { get; set; }
        public Decimal Price { get; set; }
    }
}
