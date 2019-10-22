using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnStockOutController
    {
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===================
        // Fill Leading Zeroes
        // ===================
        public String FillLeadingZeroes(Int32 number, Int32 length)
        {
            var result = number.ToString();
            var pad = length - result.Length;
            while (pad > 0)
            {
                result = '0' + result;
                pad--;
            }

            return result;
        }

        public List<Entities.TrnStockOutEntity> ListStockOut(string filter)
        {
            var stockOuts = from d in db.TrnStockOuts
                            where d.StockOutNumber.Contains(filter)
                            select new Entities.TrnStockOutEntity
                            {
                                Id = d.Id,
                                PeriodId = d.PeriodId,
                                StockOutDate = d.StockOutDate.ToShortDateString(),
                                StockOutNumber = d.StockOutNumber,
                                AccountId = d.AccountId,
                                Remarks = d.Remarks,
                                PreparedBy = d.PreparedBy,
                                CheckedBy = d.CheckedBy,
                                ApprovedBy = d.ApprovedBy,
                                IsLocked = d.IsLocked,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = d.UpdateDateTime.ToShortDateString()
                            };

            return stockOuts.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // StockOut Detail
        // ==============
        public Entities.TrnStockOutEntity DetailStockOut(Int32 id)
        {
            var stockOut = from d in db.TrnStockOuts
                           where d.Id == id
                           where d.Id == id
                           select new Entities.TrnStockOutEntity
                           {
                               Id = d.Id,
                               PeriodId = d.PeriodId,
                               StockOutDate = d.StockOutDate.ToShortDateString(),
                               StockOutNumber = d.StockOutNumber,
                               AccountId = d.AccountId,
                               Remarks = d.Remarks,
                               PreparedBy = d.PreparedBy,
                               CheckedBy = d.CheckedBy,
                               ApprovedBy = d.ApprovedBy,
                               IsLocked = d.IsLocked,
                               EntryUserId = d.EntryUserId,
                               EntryDateTime = d.EntryDateTime.ToShortDateString(),
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = d.UpdateDateTime.ToShortDateString()
                           };

            return stockOut.FirstOrDefault();
        }
    }
}
