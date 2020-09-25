using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.LiteclerkIntegration.Entities
{
    class LiteclerkMstCompanyBranch
    {
        public Int32 Id { get; set; }
        public String ManualCode { get; set; }
        public Int32 CompanyId { get; set; }
        public LiteclerkMstCompany Company { get; set; }
        public String Branch { get; set; }
    }
}
