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

        public String[] AddUnit(Entities.MstUnitEntity objUnit)
        {
            try
            {
                Data.MstUnit addUnit = new Data.MstUnit()
                {
                    Unit = objUnit.Unit
                };

                db.MstUnits.InsertOnSubmit(addUnit);
                db.SubmitChanges();
                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        public String[] UpdateUnit(Entities.MstUnitEntity objUnit)
        {
            try
            {
                var currentUnit = from d in db.MstUnits
                                  where d.Id == objUnit.Id
                                  select d;
                if (currentUnit.Any())
                {
                    var updateUnit = currentUnit.FirstOrDefault();
                    updateUnit.Unit = objUnit.Unit;
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

        public String[] DeleteUnit(Int32 id)
        {
            try
            {
                var currentUnit = from d in db.MstUnits
                                  where d.Id == id
                                  select d;
                if (currentUnit.Any())
                {
                    var deleteUnit = currentUnit.FirstOrDefault();
                    db.MstUnits.DeleteOnSubmit(deleteUnit);
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
