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

        // ============
        // Add Terminal
        // ============
        public String[] AddTerminal(Entities.MstTerminalEntity objTerminal)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstTerminal addTerminal = new Data.MstTerminal()
                {
                    Terminal = objTerminal.Terminal
                };

                db.MstTerminals.InsertOnSubmit(addTerminal);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(addTerminal);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstTerminal",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddTerminal"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Update Terminal
        // ===============
        public String[] UpdateTerminal(Entities.MstTerminalEntity objTerminal)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var terminal = from d in db.MstTerminals
                               where d.Id == objTerminal.Id
                               select d;

                if (terminal.Any())
                {
                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(terminal.FirstOrDefault());

                    var updateTerminal = terminal.FirstOrDefault();
                    updateTerminal.Terminal = objTerminal.Terminal;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(terminal.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstTerminal",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdateTerminal"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Terminal not found!", "0" };
                }

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete Terminal
        // ===============
        public String[] DeleteTerminal(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var terminal = from d in db.MstTerminals
                               where d.Id == id
                               select d;

                if (terminal.Any())
                {
                    var deleteTerminal = terminal.FirstOrDefault();
                    db.MstTerminals.DeleteOnSubmit(deleteTerminal);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(terminal.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstTerminal",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteTerminal"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Terminal not found!", "0" };
                }

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
