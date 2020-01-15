using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class SysAuditTrailController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ============
        // List Account
        // ============
        public List<Entities.SysAuditTrailEntity> ListAuditTrail(DateTime startDate, DateTime endDate, Int32 userId)
        {
            var auditTrail = from d in db.SysAuditTrails
                             where d.AuditDate >= startDate
                             && d.AuditDate >= endDate
                             select new Entities.SysAuditTrailEntity
                             {
                                 Id = d.Id,
                                 UserId = d.UserId,
                                 User = d.MstUser.FullName,
                                 AuditDate = d.AuditDate,
                                 TableInformation = d.TableInformation,
                                 RecordInformation = d.RecordInformation,
                                 FormInformation = d.FormInformation,
                                 ActionInformation = d.ActionInformation

                             };

            return auditTrail.OrderByDescending(d => d.Id).ToList();
        }

        public List<Entities.MstUserEntity> DropDownUserList()
        {
            var users = from d in db.MstUsers
                        where d.IsLocked == true
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.OrderByDescending(d => d.Id).ToList();
        }
    }
}
