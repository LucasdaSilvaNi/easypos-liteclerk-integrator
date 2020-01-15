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

        // ===============
        // Detail Supplier
        // ===============
        public Entities.MstSupplierEntity DetailSupplier(Int32 id)
        {
            var supplier = from d in db.MstSuppliers
                           where d.Id == id
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

            return supplier.FirstOrDefault();
        }

        // =====================
        // Dropdown List Account
        // =====================
        public List<Entities.MstAccountEntity> DropDownListAccount()
        {
            var accounts = from d in db.MstAccounts
                           where d.AccountType == "LIABILITY"
                           select new Entities.MstAccountEntity
                           {
                               Id = d.Id,
                               Code = d.Code,
                               Account = d.Account,
                               IsLocked = d.IsLocked,
                               AccountType = d.AccountType
                           };

            return accounts.ToList();
        }

        // ===================
        // Dropdown List Terms
        // ===================
        public List<Entities.MstTermEntity> DropDownListTerms()
        {
            var terms = from d in db.MstTerms
                        select new Entities.MstTermEntity
                        {
                            Id = d.Id,
                            Term = d.Term
                        };

            return terms.ToList();
        }

        // ============
        // Add Supplier
        // ============
        public String[] AddSupplier()
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

                var account = from d in db.MstAccounts where d.AccountType == "LIABILITY" select d;
                if (account.Any() == false)
                {
                    return new String[] { "Account not found.", "0" };
                }

                Data.MstSupplier addSupplier = new Data.MstSupplier()
                {
                    Supplier = "NA",
                    Address = "NA",
                    TelephoneNumber = "NA",
                    CellphoneNumber = "NA",
                    FaxNumber = "NA",
                    TermId = term.FirstOrDefault().Id,
                    TIN = "NA",
                    AccountId = account.FirstOrDefault().Id,
                    EntryUserId = currentUserLogin.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Today,
                    UpdateUserId = currentUserLogin.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Today,
                    IsLocked = false
                };

                db.MstSuppliers.InsertOnSubmit(addSupplier);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(addSupplier);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstSupplier",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddSupplier"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { addSupplier.Id.ToString(), "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =============
        // Lock Supplier
        // =============
        public String[] LockSupplier(Entities.MstSupplierEntity objSupplier)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var supplier = from d in db.MstSuppliers
                               where d.Id == objSupplier.Id
                               select d;

                if (supplier.Any())
                {
                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(supplier.FirstOrDefault());

                    var lockSupplier = supplier.FirstOrDefault();
                    lockSupplier.Supplier = objSupplier.Supplier;
                    lockSupplier.Address = objSupplier.Address;
                    lockSupplier.TelephoneNumber = objSupplier.TelephoneNumber;
                    lockSupplier.CellphoneNumber = objSupplier.CellphoneNumber;
                    lockSupplier.FaxNumber = objSupplier.FaxNumber;
                    lockSupplier.TermId = objSupplier.TermId;
                    lockSupplier.TIN = objSupplier.TIN;
                    lockSupplier.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    lockSupplier.UpdateDateTime = DateTime.Today;
                    lockSupplier.IsLocked = true;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(supplier.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstSupplier",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "LockSupplier"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Supplier not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Unlock Supplier
        // ===============
        public String[] UnlockSupplier(Entities.MstSupplierEntity objSupplier)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var supplier = from d in db.MstSuppliers
                               where d.Id == objSupplier.Id
                               select d;

                if (supplier.Any())
                {
                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(supplier.FirstOrDefault());

                    var unlockSupplier = supplier.FirstOrDefault();
                    unlockSupplier.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unlockSupplier.UpdateDateTime = DateTime.Today;
                    unlockSupplier.IsLocked = false;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(supplier.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstSupplier",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UnlockSupplier"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Supplier not found!", "0" };
                }

            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Delete Supplier
        // ===============
        public String[] DeleteSupplier(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var supplier = from d in db.MstSuppliers
                               where d.Id == id
                               select d;

                if (supplier.Any())
                {
                    if (supplier.FirstOrDefault().IsLocked == false)
                    {
                        var deleteSupplier = supplier.FirstOrDefault();
                        db.MstSuppliers.DeleteOnSubmit(deleteSupplier);

                        String oldObject = Modules.SysAuditTrailModule.GetObjectString(supplier.FirstOrDefault());

                        Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                        {
                            UserId = currentUserLogin.FirstOrDefault().Id,
                            AuditDate = DateTime.Now,
                            TableInformation = "MstSupplier",
                            RecordInformation = oldObject,
                            FormInformation = "",
                            ActionInformation = "DeleteSupplier"
                        };
                        Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                        db.SubmitChanges();

                        return new String[] { "", "" };
                    }
                    else
                    {
                        return new String[] { "Supplier is locked!", "0" };
                    }
                }
                else
                {
                    return new String[] { "Supplier not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
