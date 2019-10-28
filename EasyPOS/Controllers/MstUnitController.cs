using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstUnitController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =========
        // List Unit
        // =========
        public List<Entities.MstUnitEntity> ListUnit(String filter)
        {
            var units = from d in db.MstUnits
                        where d.Unit.Contains(filter)
                        select new Entities.MstUnitEntity
                        {
                            Id = d.Id,
                            Unit = d.Unit,
                        };

            return units.OrderByDescending(d => d.Id).ToList();
        }
    }
}
