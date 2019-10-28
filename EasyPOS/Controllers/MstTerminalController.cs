using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstTerminalController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // List Terminal
        // =============
        public List<Entities.MstTerminalEntity> ListTerminal(String filter)
        {
            var terminals = from d in db.MstTerminals
                            where d.Terminal.Contains(filter)
                            select new Entities.MstTerminalEntity
                            {
                                Id = d.Id,
                                Terminal = d.Terminal,
                            };

            return terminals.OrderByDescending(d => d.Id).ToList();
        }
    }
}
