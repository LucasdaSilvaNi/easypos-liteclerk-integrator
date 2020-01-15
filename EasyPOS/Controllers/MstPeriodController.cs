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

        // ==========
        // Add Period
        // ==========
        public String[] AddPeriod(Entities.MstPeriodEntity objPeriod)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstPeriod addPeriod = new Data.MstPeriod()
                {
                    Period = objPeriod.Period
                };

                db.MstPeriods.InsertOnSubmit(addPeriod);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(addPeriod);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstPeriod",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddPeriod"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============
        // Update Period
        // =============
        public String[] UpdatePeriod(Entities.MstPeriodEntity objPeriod)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var period = from d in db.MstPeriods
                             where d.Id == objPeriod.Id
                             select d;

                if (period.Any())
                {
                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(period.FirstOrDefault());

                    var updatePeriod = period.FirstOrDefault();
                    updatePeriod.Period = objPeriod.Period;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(period.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstPeriod",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdatePeriod"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Period not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============
        // Delete Period
        // =============
        public String[] DeletePeriod(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var period = from d in db.MstPeriods
                             where d.Id == id
                             select d;

                if (period.Any())
                {
                    var deletePeriod = period.FirstOrDefault();
                    db.MstPeriods.DeleteOnSubmit(deletePeriod);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(period.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstPeriod",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeletePeriod"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Period not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
