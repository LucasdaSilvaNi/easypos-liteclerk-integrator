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
                Data.MstPeriod addPeriod = new Data.MstPeriod()
                {
                    Period = objPeriod.Period
                };

                db.MstPeriods.InsertOnSubmit(addPeriod);
                db.SubmitChanges();

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
                var period = from d in db.MstPeriods
                             where d.Id == objPeriod.Id
                             select d;

                if (period.Any())
                {
                    var updatePeriod = period.FirstOrDefault();
                    updatePeriod.Period = objPeriod.Period;
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

        // =============
        // Delete Period
        // =============
        public String[] DeletePeriod(Int32 id)
        {
            try
            {
                var period = from d in db.MstPeriods
                             where d.Id == id
                             select d;

                if (period.Any())
                {
                    var deletePeriod = period.FirstOrDefault();
                    db.MstPeriods.DeleteOnSubmit(deletePeriod);
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
