using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkMstArticleCustomer
    {
        public Int32 Id { get; set; }
        public Int32 ArticleId { get; set; }
        public LiteclerkMstArticle Article { get; set; }
        public String ArticleManualCode { get; set; }
        public String Customer { get; set; }
        public String Address { get; set; }
        public String ContactPerson { get; set; }
        public String ContactNumber { get; set; }
        public Int32 TermId { get; set; }
        public LiteclerkMstTerm Term { get; set; }
        public Decimal CreditLimit { get; set; }
    }
}
