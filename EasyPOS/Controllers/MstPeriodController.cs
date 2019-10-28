using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstPeriodController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===========
        // List Period
        // ===========
        public List<Entities.MstPeriodEntity> ListPeriod(String filter)
        {
            var periods = from d in db.MstPeriods
                          where d.Period.Contains(filter)
                          select new Entities.MstPeriodEntity
                          {
                              Id = d.Id,
                              Period = d.Period,
                          };

            return periods.OrderByDescending(d => d.Id).ToList();
        }
    }
}
