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

        // ========
        // Add Unit
        // ========
        public String[] AddUnit(Entities.MstUnitEntity objUnit)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstUnit addUnit = new Data.MstUnit()
                {
                    Unit = objUnit.Unit
                };

                db.MstUnits.InsertOnSubmit(addUnit);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(addUnit);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstUnit",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddUnit"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Update Unit
        // ===========
        public String[] UpdateUnit(Entities.MstUnitEntity objUnit)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var unit = from d in db.MstUnits
                           where d.Id == objUnit.Id
                           select d;

                if (unit.Any())
                {
                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(unit.FirstOrDefault());

                    var updateUnit = unit.FirstOrDefault();
                    updateUnit.Unit = objUnit.Unit;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(unit.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstUnit",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdateUnit"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Unit not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete Unit
        // ===========
        public String[] DeleteUnit(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var unit = from d in db.MstUnits
                           where d.Id == id
                           select d;

                if (unit.Any())
                {
                    var deleteUnit = unit.FirstOrDefault();
                    db.MstUnits.DeleteOnSubmit(deleteUnit);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(unit.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstUnit",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteUnit"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Unit not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
