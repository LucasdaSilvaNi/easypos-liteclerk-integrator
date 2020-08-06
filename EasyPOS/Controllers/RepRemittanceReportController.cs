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
        public List<Entities.TrnDisbursementEntity> DropdownListRemittanceNumber(Int32 terminalId, Int32 userId, DateTime startDate, DateTime endDate)
        {
            var disbursements = from d in db.TrnDisbursements
                                where d.TerminalId == terminalId
                                && d.DisbursementDate >= startDate.Date
                                && d.DisbursementDate <= endDate.Date
                                && d.PreparedBy == userId
                                && d.DisbursementType == "CREDIT"
                                && d.MstPayType.PayTypeCode == "CASH"
                                && d.IsLocked == true
                                select new Entities.TrnDisbursementEntity
                                {
                                    Id = d.Id,
                                    DisbursementNumber = d.DisbursementNumber + " - " + d.Remarks
                                };

            return disbursements.ToList();
        }

        // =========================
        // Remittance Summary Report
        // =========================
        public List<Entities.RepRemitanceReportCashInOutSummaryReportEntity> DisbursementSummaryReport(DateTime startDate, DateTime endDate, Int32 terminalId)
        {
            var cashInOuts = from d in db.TrnDisbursements.OrderByDescending(d => d.Id)
                             where d.DisbursementDate >= startDate.Date
                             && d.DisbursementDate <= endDate.Date
                             && d.TerminalId == terminalId
                             && d.IsLocked == true
                             select new Entities.RepRemitanceReportCashInOutSummaryReportEntity
                             {
                                 Id = d.Id,
                                 DisbursementDate = d.DisbursementDate.ToShortDateString(),
                                 DisbursementNumber = d.DisbursementNumber,
                                 DisbursementType = d.DisbursementType,
                                 Remarks = d.Remarks,
                                 PayType = d.MstPayType.PayType,
                                 User = d.MstUser.UserName,
                                 Amount = d.Amount
                             };

            return cashInOuts.OrderByDescending(d => d.Id).ToList();
        }
    }
}