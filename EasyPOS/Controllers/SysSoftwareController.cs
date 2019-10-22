using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class SysSoftwareController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // Get Terminal
        // ============
        public String GetCurrentTerminal(Int32 terminalId)
        {
            String currentTerminal = "";

            var terminal = from d in db.MstTerminals
                           where d.Id == terminalId
                           select d;

            if (terminal.Any())
            {
                currentTerminal = terminal.FirstOrDefault().Terminal;
            }

            return currentTerminal;
        }
    }
}
