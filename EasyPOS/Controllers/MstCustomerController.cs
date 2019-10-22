using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstCustomerController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // Customer List
        // =============
        public List<Entities.MstCustomerEntity> ListCustomer(String filter)
        {
            var customers = from d in db.MstCustomers
                            where d.Customer.Contains(filter)
                            || d.CustomerCode.Contains(filter)
                            select new Entities.MstCustomerEntity
                            {
                                Id = d.Id,
                                Customer = d.Customer,
                                Address = d.Address,
                                ContactPerson = d.ContactPerson,
                                ContactNumber = d.ContactNumber,
                                CreditLimit = d.CreditLimit.ToString(),
                                TermId = d.TermId,
                                TIN = d.TIN,
                                WithReward = d.WithReward,
                                RewardNumber = d.RewardNumber,
                                RewardConversion = d.RewardConversion,
                                AvailableReward = d.AvailableReward,
                                AccountId = d.AccountId,
                                EntryUserId = d.EntryUserId,
                                EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                UpdateUserId = d.UpdateUserId,
                                UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                                IsLocked = d.IsLocked,
                                DefaultPriceDescription = d.DefaultPriceDescription,
                                CustomerCode = d.CustomerCode
                            };

            return customers.OrderByDescending(d => d.Id).ToList();
        }

        // ===============
        // Customer Detail
        // ===============
        public Entities.MstCustomerEntity DetailCustomer(Int32 id)
        {
            var customer = from d in db.MstCustomers
                           where d.Id == id
                           select new Entities.MstCustomerEntity
                           {
                               Id = d.Id,
                               Customer = d.Customer,
                               Address = d.Address,
                               ContactPerson = d.ContactPerson,
                               ContactNumber = d.ContactNumber,
                               CreditLimit = d.CreditLimit.ToString(),
                               TermId = d.TermId,
                               TIN = d.TIN,
                               WithReward = d.WithReward,
                               RewardNumber = d.RewardNumber,
                               RewardConversion = d.RewardConversion,
                               AvailableReward = d.AvailableReward,
                               AccountId = d.AccountId,
                               EntryUserId = d.EntryUserId,
                               EntryDateTime = d.EntryDateTime.ToShortDateString(),
                               UpdateUserId = d.UpdateUserId,
                               UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                               IsLocked = d.IsLocked,
                               DefaultPriceDescription = d.DefaultPriceDescription,
                               CustomerCode = d.CustomerCode
                           };

            return customer.FirstOrDefault();
        }

        // ============
        // Add Customer
        // ============
        public String[] AddCustomer()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var term = from d in db.MstTerms select d;
                if (term.Any() == false)
                {
                    return new String[] { "Term not found.", "0" };
                }

                var account = from d in db.MstAccounts where d.Account == "Accounts Receivable - Sales" select d;
                if (account.Any() == false)
                {
                    return new String[] { "Account not found.", "0" };
                }

                Data.MstCustomer newCustomer = new Data.MstCustomer()
                {
                    Customer = "",
                    Address = "NA",
                    ContactPerson = "NA",
                    ContactNumber = "NA",
                    CreditLimit = 0,
                    TermId = term.FirstOrDefault().Id,
                    TIN = "NA",
                    WithReward = false,
                    RewardNumber = null,
                    RewardConversion = 0,
                    AvailableReward = 0,
                    AccountId = account.FirstOrDefault().Id,
                    EntryUserId = currentUserLogin.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Today,
                    UpdateUserId = currentUserLogin.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Today,
                    IsLocked = false,
                    DefaultPriceDescription = null,
                    CustomerCode = null
                };

                db.MstCustomers.InsertOnSubmit(newCustomer);
                db.SubmitChanges();

                return new String[] { "", newCustomer.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============
        // Lock Customer
        // =============
        public String[] LockCustomer(Int32 id, Entities.MstCustomerEntity objCustomer)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var customer = from d in db.MstCustomers
                               where d.Id == id
                               select d;

                if (customer.Any())
                {
                    var lockCustomer = customer.FirstOrDefault();
                    lockCustomer.Customer = objCustomer.Customer;
                    lockCustomer.Address = objCustomer.Address;
                    lockCustomer.ContactPerson = objCustomer.ContactPerson;
                    lockCustomer.ContactNumber = objCustomer.ContactNumber;
                    lockCustomer.CreditLimit = Convert.ToDecimal(objCustomer.CreditLimit);
                    lockCustomer.TermId = objCustomer.TermId;
                    lockCustomer.TIN = objCustomer.TIN;
                    lockCustomer.WithReward = objCustomer.WithReward;
                    lockCustomer.RewardNumber = objCustomer.RewardNumber;
                    lockCustomer.RewardConversion = objCustomer.RewardConversion;
                    lockCustomer.AvailableReward = objCustomer.AvailableReward;
                    lockCustomer.AccountId = objCustomer.AccountId;
                    lockCustomer.UpdateUserId = objCustomer.UpdateUserId;
                    lockCustomer.UpdateDateTime = DateTime.Today;
                    lockCustomer.IsLocked = true;
                    lockCustomer.DefaultPriceDescription = objCustomer.DefaultPriceDescription;
                    lockCustomer.CustomerCode = objCustomer.CustomerCode;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Customer not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Unlock Customer
        // ===============
        public String[] UnlockCustomer(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var customer = from d in db.MstCustomers
                               where d.Id == id
                               select d;

                if (customer.Any())
                {
                    var unLockCustomer = customer.FirstOrDefault();
                    unLockCustomer.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unLockCustomer.UpdateDateTime = DateTime.Today;
                    unLockCustomer.IsLocked = false;
                    db.SubmitChanges();
                }

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete Customer
        // ===============
        public String[] DeleteCustomer(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var customer = from d in db.MstCustomers
                               where d.Id == id
                               select d;

                if (customer.Any())
                {
                    if (customer.FirstOrDefault().IsLocked == false)
                    {
                        var deleteCustomer = customer.FirstOrDefault();
                        db.MstCustomers.DeleteOnSubmit(deleteCustomer);
                        db.SubmitChanges();

                        return new String[] { "", "" };
                    }
                    else
                    {
                        return new String[] { "Customer is Locked", "0" };
                    }
                }
                else
                {
                    return new String[] { "Customer not found", "0" };
                }


            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

    }
}
