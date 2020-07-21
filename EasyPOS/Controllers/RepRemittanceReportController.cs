using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class RepRemittanceReportController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========================
        // Dropdown List - Terminal
        // ========================
        public List<Entities.MstTerminalEntity> DropdownListTerminal()
        {
            var terminals = from d in db.MstTerminals
                            select new Entities.MstTerminalEntity
                            {
                                Id = d.Id,
                                Terminal = d.Terminal
                            };

            return terminals.ToList();
        }

        // ====================
        // Dropdown List - User
        // ====================
        public List<Entities.MstUserEntity> DropdownListUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.ToList();
        }

        // =================================
        // Dropdown List - Remittance Number
        // =================================
        public List<Entities.TrnDisbursementEntity> DropdownListRemittanceNumber(Int32 terminalId,  Int32 userId)
        {
            var disbursements = from d in db.TrnDisbursements
                                where d.TerminalId == terminalId
                                && d.PreparedBy == userId
                                && d.DisbursementType == "DEBIT"
                                && d.IsLocked == true
                                select new Entities.TrnDisbursementEntity
                                {
                                    Id = d.Id,
                                    DisbursementNumber = d.DisbursementNumber
                                };

            return disbursements.ToList();
        }
    }
}
