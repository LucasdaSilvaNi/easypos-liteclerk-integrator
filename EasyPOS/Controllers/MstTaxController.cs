using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstTaxController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ========
        // List Tax
        // ========
        public List<Entities.MstTaxEntity> ListTax(String filter)
        {
            var taxes = from d in db.MstTaxes
                        where d.Code.Contains(filter)
                        || d.Tax.Contains(filter)
                        || d.MstAccount.Account.Contains(filter)
                        select new Entities.MstTaxEntity
                        {
                            Id = d.Id,
                            Code = d.Code,
                            Tax = d.Tax,
                            Rate = d.Rate,
                            AccountId = d.AccountId,
                            Account = d.MstAccount.Account
                        };

            return taxes.OrderByDescending(d => d.Id).ToList();
        }

        // =============
        // List Tax Code
        // =============
        public String[] DropDownListCode()
        {
            return new String[] { "INCLUSIVE", "EXCLUSIVE" };
        }

        // =======================
        // Dropdown List - Account
        // =======================
        public List<Entities.MstAccountEntity> DropDownListAccount()
        {
            var accounts = from d in db.MstAccounts
                           where d.AccountType.Equals("LIABILITY")
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               Account = d.Account
                           };

            return accounts.ToList();
        }

        // =======
        // Add Tax
        // =======
        public String[] AddTax(Entities.MstTaxEntity objTax)
        {
            try
            {
                Data.MstTax addTax = new Data.MstTax()
                {
                    Code = objTax.Code,
                    Tax = objTax.Tax,
                    Rate = objTax.Rate,
                    AccountId = objTax.AccountId
                };

                db.MstTaxes.InsertOnSubmit(addTax);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==========
        // Update Tax
        // ==========
        public String[] UpdateTax(Entities.MstTaxEntity objTax)
        {
            try
            {
                var tax = from d in db.MstTaxes
                          where d.Id == objTax.Id
                          select d;

                if (tax.Any())
                {
                    var updateTax = tax.FirstOrDefault();
                    updateTax.Code = objTax.Code;
                    updateTax.Tax = objTax.Tax;
                    updateTax.Rate = objTax.Rate;
                    updateTax.AccountId = objTax.AccountId;
                    db.SubmitChanges();

                    return new string[] { "", "" };
                }
                else
                {
                    return new String[] { "Tax not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==========
        // Delete Tax
        // ==========
        public String[] DeleteTax(Int32 id)
        {
            try
            {
                var tax = from d in db.MstTaxes
                          where d.Id == id
                          select d;

                if (tax.Any())
                {
                    var deleteTax = tax.FirstOrDefault();
                    db.MstTaxes.DeleteOnSubmit(deleteTax);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Tax not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
