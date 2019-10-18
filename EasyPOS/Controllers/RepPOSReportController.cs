using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepPOSReportController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========================
        // Dropdown List - Terminal
        // ========================
        public List<Entities.MstTerminal> DropdownListTerminal()
        {
            var terminals = from d in db.MstTerminals
                            select new Entities.MstTerminal
                            {
                                Id = d.Id,
                                Terminal = d.Terminal
                            };

            return terminals.ToList();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUser> DropdownListUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUser
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }
    }
}
