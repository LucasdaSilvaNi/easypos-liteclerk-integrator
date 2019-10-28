using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstSupplierController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // List Pay Type
        // =============
        public List<Entities.MstSupplierEntity> ListSupplier(String filter)
        {
            var suppliers = from d in db.MstSuppliers
                            where d.Supplier.Contains(filter)
                            || d.Address.Contains(filter)
                            || d.TelephoneNumber.Contains(filter)
                            || d.CellphoneNumber.Contains(filter)
                            || d.TIN.Contains(filter)
                            select new Entities.MstSupplierEntity
                            {
                                Id = d.Id,
                                Supplier = d.Supplier,
                                Address = d.Address,
                                TelephoneNumber = d.TelephoneNumber,
                                CellphoneNumber = d.CellphoneNumber,
                                FaxNumber = d.FaxNumber,
                                TermId = d.TermId,
                                Term = d.MstTerm.Term,
                                TIN = d.TIN,
                                AccountId = d.AccountId,
                                Account = d.MstAccount.Account,
                                EntryUserId = d.EntryUserId,
                                EntryUserName = d.MstUser.UserName,
                                EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                UpdateUserId = d.UpdateUserId,
                                UpdatedUserName = d.MstUser1.UserName,
                                UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                                IsLocked = d.IsLocked
                            };

            return suppliers.OrderBy(d => d.Id).ToList();
        }
    }
}
