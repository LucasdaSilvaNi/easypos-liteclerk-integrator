using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnSalesController
    {
        // ============
        // Data Context
        // ============
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

        // ======================
        // Dropdown List Terminal
        // ======================
        public List<Entities.MstTerminalEntity> DropdownListTerminal()
        {
            var terminals = from d in db.MstTerminals
                            select new Entities.MstTerminalEntity
                            {
                                Id = d.Id,
                                Terminal = "Terminal: " + d.Terminal
                            };

            return terminals.ToList();
        }

        // ==============
        // POS List Sales 
        // ==============
        public List<Entities.TrnSalesEntity> POSTTouchListSales(DateTime dateTime, Int32 terminalId)
        {
            var sales = from d in db.TrnSales
                        where d.SalesDate == dateTime
                        && d.TerminalId == terminalId
                        select new Entities.TrnSalesEntity
                        {
                            Id = d.Id,
                            PeriodId = d.PeriodId,
                            Period = d.MstPeriod.Period,
                            SalesDate = d.SalesDate.ToShortDateString(),
                            SalesNumber = d.SalesNumber,
                            ManualInvoiceNumber = d.ManualInvoiceNumber,
                            CollectionNumber = d.CollectionNumber,
                            Amount = d.Amount,
                            TableId = d.TableId,
                            Table = d.TableId != null ? d.MstTable.TableCode : "",
                            CustomerId = d.CustomerId,
                            Customer = d.MstCustomer.Customer,
                            AccountId = d.AccountId,
                            TermId = d.TermId,
                            Term = d.MstTerm.Term,
                            DiscountId = d.DiscountId,
                            SeniorCitizenId = d.SeniorCitizenId,
                            SeniorCitizenName = d.SeniorCitizenName,
                            SeniorCitizenAge = d.SeniorCitizenAge,
                            Remarks = d.Remarks,
                            SalesAgent = d.SalesAgent,
                            SalesAgentUserName = d.SalesAgent != null ? d.MstUser5.UserName : "",
                            TerminalId = d.TerminalId,
                            Terminal = d.MstTerminal.Terminal,
                            PreparedBy = d.PreparedBy,
                            PreparedByUserName = d.MstUser.FullName,
                            CheckedBy = d.CheckedBy,
                            CheckedByUserName = d.MstUser1.FullName,
                            ApprovedBy = d.ApprovedBy,
                            ApprovedByUserName = d.MstUser2.FullName,
                            IsLocked = d.IsLocked,
                            IsTendered = d.IsTendered,
                            IsCancelled = d.IsCancelled,
                            PaidAmount = d.PaidAmount,
                            CreditAmount = d.CreditAmount,
                            DebitAmount = d.DebitAmount,
                            BalanceAmount = d.BalanceAmount,
                            EntryUserId = d.EntryUserId,
                            EntryUserName = d.MstUser3.FullName,
                            EntryDateTime = d.EntryDateTime.ToShortDateString(),
                            UpdateUserId = d.UpdateUserId,
                            UpdatedUserName = d.MstUser4.FullName,
                            UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                            Pax = d.Pax,
                            TableStatus = d.TableStatus,
                        };

            return sales.OrderByDescending(d => d.Id).ToList();
        }

        // ==========
        // List Sales 
        // ==========
        public List<Entities.TrnSalesEntity> ListSales(DateTime dateTime, Int32 terminalId, String filter)
        {
            var sales = from d in db.TrnSales
                        where d.SalesDate == dateTime
                        && d.TerminalId == terminalId
                        && (d.SalesNumber.Contains(filter)
                        || d.MstCustomer.Customer.Contains(filter)
                        || d.MstUser5.UserName.Contains(filter))
                        select new Entities.TrnSalesEntity
                        {
                            Id = d.Id,
                            PeriodId = d.PeriodId,
                            Period = d.MstPeriod.Period,
                            SalesDate = d.SalesDate.ToShortDateString(),
                            SalesNumber = d.SalesNumber,
                            ManualInvoiceNumber = d.ManualInvoiceNumber,
                            CollectionNumber = d.CollectionNumber,
                            Amount = d.Amount,
                            TableId = d.TableId,
                            CustomerId = d.CustomerId,
                            Customer = d.MstCustomer.Customer,
                            AccountId = d.AccountId,
                            TermId = d.TermId,
                            Term = d.MstTerm.Term,
                            DiscountId = d.DiscountId,
                            SeniorCitizenId = d.SeniorCitizenId,
                            SeniorCitizenName = d.SeniorCitizenName,
                            SeniorCitizenAge = d.SeniorCitizenAge,
                            Remarks = d.Remarks,
                            SalesAgent = d.SalesAgent,
                            SalesAgentUserName = d.SalesAgent != null ? d.MstUser5.UserName : "",
                            TerminalId = d.TerminalId,
                            Terminal = d.MstTerminal.Terminal,
                            PreparedBy = d.PreparedBy,
                            PreparedByUserName = d.MstUser.FullName,
                            CheckedBy = d.CheckedBy,
                            CheckedByUserName = d.MstUser1.FullName,
                            ApprovedBy = d.ApprovedBy,
                            ApprovedByUserName = d.MstUser2.FullName,
                            IsLocked = d.IsLocked,
                            IsTendered = d.IsTendered,
                            IsCancelled = d.IsCancelled,
                            PaidAmount = d.PaidAmount,
                            CreditAmount = d.CreditAmount,
                            DebitAmount = d.DebitAmount,
                            BalanceAmount = d.BalanceAmount,
                            EntryUserId = d.EntryUserId,
                            EntryUserName = d.MstUser3.FullName,
                            EntryDateTime = d.EntryDateTime.ToShortDateString(),
                            UpdateUserId = d.UpdateUserId,
                            UpdatedUserName = d.MstUser4.FullName,
                            UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                            Pax = d.Pax,
                            TableStatus = d.TableStatus,
                        };

            return sales.OrderByDescending(d => d.Id).ToList();
        }

        // ============
        // Detail Sales 
        // ============
        public Entities.TrnSalesEntity DetailSales(Int32 id)
        {
            var sales = from d in db.TrnSales
                        where d.Id == id
                        select new Entities.TrnSalesEntity
                        {
                            Id = d.Id,
                            PeriodId = d.PeriodId,
                            Period = d.MstPeriod.Period,
                            SalesDate = d.SalesDate.ToShortDateString(),
                            SalesNumber = d.SalesNumber,
                            ManualInvoiceNumber = d.ManualInvoiceNumber,
                            CollectionNumber = d.CollectionNumber,
                            Amount = d.Amount,
                            TableId = d.TableId,
                            CustomerId = d.CustomerId,
                            Customer = d.MstCustomer.Customer,
                            AccountId = d.AccountId,
                            TermId = d.TermId,
                            Term = d.MstTerm.Term,
                            DiscountId = d.DiscountId,
                            SeniorCitizenId = d.SeniorCitizenId,
                            SeniorCitizenName = d.SeniorCitizenName,
                            SeniorCitizenAge = d.SeniorCitizenAge,
                            Remarks = d.Remarks,
                            SalesAgent = d.SalesAgent,
                            SalesAgentUserName = d.SalesAgent != null ? d.MstUser5.UserName : "",
                            TerminalId = d.TerminalId,
                            Terminal = d.MstTerminal.Terminal,
                            PreparedBy = d.PreparedBy,
                            PreparedByUserName = d.MstUser.FullName,
                            CheckedBy = d.CheckedBy,
                            CheckedByUserName = d.MstUser1.FullName,
                            ApprovedBy = d.ApprovedBy,
                            ApprovedByUserName = d.MstUser2.FullName,
                            IsLocked = d.IsLocked,
                            IsTendered = d.IsTendered,
                            IsCancelled = d.IsCancelled,
                            PaidAmount = d.PaidAmount,
                            CreditAmount = d.CreditAmount,
                            DebitAmount = d.DebitAmount,
                            BalanceAmount = d.BalanceAmount,
                            EntryUserId = d.EntryUserId,
                            EntryUserName = d.MstUser3.FullName,
                            EntryDateTime = d.EntryDateTime.ToShortDateString(),
                            UpdateUserId = d.UpdateUserId,
                            UpdatedUserName = d.MstUser4.FullName,
                            UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                            Pax = d.Pax,
                            TableStatus = d.TableStatus,
                        };

            return sales.FirstOrDefault();
        }

        // =========
        // Add Sales 
        // =========
        public String[] AddSales(String tableCode)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var period = from d in db.MstPeriods where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentPeriodId) select d;
                if (period.Any() == false)
                {
                    return new String[] { "Period not found.", "0" };
                }

                Int32? tableId = null;
                if (tableCode != "")
                {
                    var table = from d in db.MstTables
                                where d.TableCode == tableCode
                                select d;

                    if (table.Any() == false)
                    {
                        return new String[] { "Table not found.", "0" };
                    }

                    tableId = table.FirstOrDefault().Id;
                }

                var walkinCustomer = from d in db.MstCustomers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().WalkinCustomerId) select d;
                if (walkinCustomer.Any() == false)
                {
                    return new String[] { "Walk-In customer not found.", "0" };
                }

                var terminal = from d in db.MstTerminals where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId) select d;
                if (terminal.Any() == false)
                {
                    return new String[] { "Terminal not found.", "0" };
                }

                var user = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (user.Any() == false)
                {
                    return new String[] { "User not found.", "0" };
                }

                String salesNumber = "0000000001";
                var lastSales = from d in db.TrnSales.OrderByDescending(d => d.Id) select d;
                if (lastSales.Any())
                {
                    Int32 newSalesNumber = Convert.ToInt32(lastSales.FirstOrDefault().SalesNumber) + 1;
                    salesNumber = FillLeadingZeroes(newSalesNumber, 10);
                }

                Data.TrnSale newSales = new Data.TrnSale()
                {
                    PeriodId = period.FirstOrDefault().Id,
                    SalesDate = Convert.ToDateTime(Modules.SysCurrentModule.GetCurrentSettings().CurrentDate),
                    SalesNumber = salesNumber,
                    ManualInvoiceNumber = terminal.FirstOrDefault().Terminal + "-" + salesNumber,
                    CollectionNumber = null,
                    Amount = 0,
                    TableId = tableId,
                    CustomerId = walkinCustomer.FirstOrDefault().Id,
                    AccountId = walkinCustomer.FirstOrDefault().AccountId,
                    TermId = walkinCustomer.FirstOrDefault().TermId,
                    DiscountId = null,
                    SeniorCitizenId = "",
                    SeniorCitizenName = "",
                    SeniorCitizenAge = null,
                    Remarks = "",
                    SalesAgent = user.FirstOrDefault().Id,
                    TerminalId = terminal.FirstOrDefault().Id,
                    PreparedBy = user.FirstOrDefault().Id,
                    CheckedBy = user.FirstOrDefault().Id,
                    ApprovedBy = user.FirstOrDefault().Id,
                    IsLocked = false,
                    IsTendered = false,
                    IsCancelled = false,
                    PaidAmount = 0,
                    CreditAmount = 0,
                    DebitAmount = 0,
                    BalanceAmount = 0,
                    EntryUserId = user.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Now,
                    UpdateUserId = user.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Now,
                    Pax = null,
                    TableStatus = 0,
                };

                db.TrnSales.InsertOnSubmit(newSales);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(newSales);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "TrnSale",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddSales"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", newSales.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Tender List Pay Types 
        // =====================
        public List<Entities.MstPayTypeEntity> TenderListPayType()
        {
            var payTypes = from d in db.MstPayTypes
                           select new Entities.MstPayTypeEntity
                           {
                               Id = d.Id,
                               PayTypeCode = d.PayTypeCode,
                               PayType = d.PayType,
                               SortNumber = d.SortNumber
                           };

            return payTypes.OrderBy(d => d.SortNumber).ToList();
        }

        // ============
        // Tender Sales
        // ============
        public String[] TenderSales(Int32 salesId, Entities.TrnCollectionEntity objCollection)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var currentSales = from d in db.TrnSales
                                   where d.Id == salesId
                                   select d;

                if (currentSales.Any() == false)
                {
                    return new String[] { "Sales not found.", "0" };
                }

                var user = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (user.Any() == false)
                {
                    return new String[] { "User not found.", "0" };
                }

                if (user.Any() == false)
                {
                    return new String[] { "User are not found.", "0" };
                }

                String collectionNumber = "0000000001";
                var lastCollection = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                                     where d.TerminalId == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId)
                                     select d;

                if (lastCollection.Any())
                {
                    Int32 newCollectionNumber = Convert.ToInt32(lastCollection.FirstOrDefault().CollectionNumber) + 1;
                    collectionNumber = FillLeadingZeroes(newCollectionNumber, 10);
                }

                Data.TrnCollection newCollection = new Data.TrnCollection
                {
                    PeriodId = currentSales.FirstOrDefault().PeriodId,
                    CollectionDate = Convert.ToDateTime(Modules.SysCurrentModule.GetCurrentSettings().CurrentDate),
                    CollectionNumber = collectionNumber,
                    TerminalId = currentSales.FirstOrDefault().TerminalId,
                    ManualORNumber = currentSales.FirstOrDefault().MstTerminal.Terminal + "-" + collectionNumber,
                    CustomerId = currentSales.FirstOrDefault().CustomerId,
                    Remarks = currentSales.FirstOrDefault().Remarks,
                    SalesId = currentSales.FirstOrDefault().Id,
                    SalesBalanceAmount = currentSales.FirstOrDefault().BalanceAmount,
                    Amount = 0,
                    TenderAmount = objCollection.TenderAmount,
                    ChangeAmount = objCollection.ChangeAmount,
                    PreparedBy = user.FirstOrDefault().Id,
                    CheckedBy = user.FirstOrDefault().Id,
                    ApprovedBy = user.FirstOrDefault().Id,
                    IsCancelled = false,
                    PostCode = null,
                    IsLocked = false,
                    EntryUserId = user.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Now,
                    UpdateUserId = user.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Now
                };

                db.TrnCollections.InsertOnSubmit(newCollection);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(newCollection);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "TrnCollection",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "TenderSales"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                if (objCollection.CollectionLines.Any())
                {
                    List<Data.TrnCollectionLine> newCollectionLines = new List<Data.TrnCollectionLine>();
                    foreach (var collectionLine in objCollection.CollectionLines)
                    {
                        var payType = from d in db.MstPayTypes
                                      where d.Id == collectionLine.PayTypeId
                                      && d.AccountId != null
                                      select d;

                        if (payType.Any())
                        {
                            DateTime? checkDate = null;
                            if (String.IsNullOrEmpty(collectionLine.CheckDate) == false)
                            {
                                checkDate = Convert.ToDateTime(collectionLine.CheckDate);
                            }

                            newCollectionLines.Add(new Data.TrnCollectionLine()
                            {
                                CollectionId = newCollection.Id,
                                Amount = collectionLine.Amount,
                                PayTypeId = collectionLine.PayTypeId,
                                CheckNumber = collectionLine.CheckNumber,
                                CheckDate = checkDate,
                                CheckBank = collectionLine.CheckBank,
                                CreditCardVerificationCode = collectionLine.CreditCardVerificationCode,
                                CreditCardNumber = collectionLine.CreditCardNumber,
                                CreditCardType = collectionLine.CreditCardType,
                                CreditCardBank = collectionLine.CreditCardBank,
                                GiftCertificateNumber = collectionLine.GiftCertificateNumber,
                                OtherInformation = collectionLine.OtherInformation,
                                StockInId = null,
                                AccountId = Convert.ToInt32(payType.FirstOrDefault().AccountId),
                                CreditCardReferenceNumber = collectionLine.CreditCardReferenceNumber,
                                CreditCardHolderName = collectionLine.CreditCardHolderName,
                                CreditCardExpiry = collectionLine.CreditCardExpiry
                            });
                        }
                    }

                    db.TrnCollectionLines.InsertAllOnSubmit(newCollectionLines);
                    db.SubmitChanges();
                }

                Decimal salesAmount = currentSales.FirstOrDefault().Amount;
                Decimal paidAmount = 0;

                var collection = from d in db.TrnCollections
                                 where d.Id == newCollection.Id
                                 select d;

                if (collection.Any())
                {
                    Decimal totalCollectionLineAmount = 0;
                    var collectionLines = from d in db.TrnCollectionLines
                                          where d.CollectionId == collection.FirstOrDefault().Id
                                          select d;

                    if (collectionLines.Any())
                    {
                        totalCollectionLineAmount = collectionLines.Sum(d => d.Amount);
                    }

                    var lockCollection = collection.FirstOrDefault();
                    lockCollection.Amount = totalCollectionLineAmount - collection.FirstOrDefault().ChangeAmount;
                    lockCollection.IsLocked = true;
                    db.SubmitChanges();

                    paidAmount = totalCollectionLineAmount;
                }

                String oldObject3 = Modules.SysAuditTrailModule.GetObjectString(currentSales.FirstOrDefault());

                var lockSales = currentSales.FirstOrDefault();
                lockSales.CollectionNumber = collection.FirstOrDefault().CollectionNumber;
                lockSales.PaidAmount = paidAmount;
                lockSales.BalanceAmount = salesAmount - paidAmount;
                lockSales.IsLocked = true;
                lockSales.IsTendered = true;
                lockSales.UpdateUserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);
                lockSales.UpdateDateTime = DateTime.Now;
                db.SubmitChanges();

                Modules.TrnInventoryModule trnInventoryModule = new Modules.TrnInventoryModule();
                trnInventoryModule.UpdateSalesInventory(currentSales.FirstOrDefault().Id);

                String newObject3 = Modules.SysAuditTrailModule.GetObjectString(currentSales.FirstOrDefault());

                Entities.SysAuditTrailEntity newAuditTrail3 = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "TrnSales",
                    RecordInformation = oldObject3,
                    FormInformation = newObject3,
                    ActionInformation = "TenderSales"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail3);

                return new String[] { "", newCollection.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ======================================
        // Tender Sales - Dropdown List Customers
        // ======================================
        public List<Entities.MstCustomerEntity> TenderSalesDropdownListCustomer()
        {
            var customers = from d in db.MstCustomers
                            select new Entities.MstCustomerEntity
                            {
                                Id = d.Id,
                                Customer = d.Customer,
                                TermId = d.TermId,
                                CustomerCode = d.CustomerCode
                            };

            return customers.OrderBy(d => d.Customer).ToList();
        }

        // ==================================
        // Tender Sales - Dropdown List Terms
        // ==================================
        public List<Entities.MstTermEntity> TenderSalesDropdownListTerm()
        {
            var terms = from d in db.MstTerms
                        select new Entities.MstTermEntity
                        {
                            Id = d.Id,
                            Term = d.Term
                        };

            return terms.OrderBy(d => d.Term).ToList();
        }

        // ==================================
        // Tender Sales - Dropdown List Users
        // ==================================
        public List<Entities.MstUserEntity> TenderSalesDropdownListUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUserEntity
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.OrderBy(d => d.FullName).ToList();
        }

        // ===========================
        // Tender Sales - Update Sales
        // ===========================
        public String[] TenderUpdateSales(Int32 salesId, Entities.TrnSalesEntity objSalesEntity)
        {
            try
            {
                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            select d;

                if (sales.Any())
                {
                    var updateSales = sales.FirstOrDefault();
                    updateSales.CustomerId = objSalesEntity.CustomerId;
                    updateSales.TermId = objSalesEntity.TermId;
                    updateSales.Remarks = objSalesEntity.Remarks;
                    updateSales.SalesAgent = objSalesEntity.SalesAgent;
                    updateSales.UpdateUserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);
                    updateSales.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ============
        // Delete Sales 
        // ============
        public String[] DeleteSales(Int32 salesId)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            select d;

                if (sales.Any())
                {
                    if (sales.FirstOrDefault().IsTendered)
                    {
                        return new String[] { "Already tendered.", "0" };
                    }

                    if (sales.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    db.TrnSales.DeleteOnSubmit(sales.FirstOrDefault());

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(sales.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "TrnSales",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteSales"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ============
        // Cancel Sales
        // ============
        public String[] CancelSales(Int32 salesId, String cancelRemarks)
        {
            try
            {
                DateTime currentLoginDate = Convert.ToDateTime(Modules.SysCurrentModule.GetCurrentSettings().CurrentDate);

                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            && d.IsLocked == true
                            select d;

                if (sales.Any())
                {
                    if (sales.FirstOrDefault().IsCancelled)
                    {
                        return new String[] { "Already cancelled.", "0" };
                    }

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(sales.FirstOrDefault());

                    var cancelSales = sales.FirstOrDefault();
                    cancelSales.IsCancelled = true;
                    cancelSales.UpdateUserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);
                    cancelSales.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(sales.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "TrnSales",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "CancelSales"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    var collection = from d in db.TrnCollections
                                     where d.SalesId == salesId
                                     && d.IsLocked == true
                                     select d;

                    if (collection.Any())
                    {
                        if (collection.FirstOrDefault().IsCancelled)
                        {
                            return new String[] { "Already cancelled.", "0" };
                        }

                        String cancelledCollectionNumber = "0000000001";
                        var lastCancelledCollection = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                                                      where d.TerminalId == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().TerminalId)
                                                      && d.IsCancelled == true
                                                      select d;

                        if (lastCancelledCollection.Any())
                        {
                            Int32 newCancelledCollectionNumber = Convert.ToInt32(lastCancelledCollection.FirstOrDefault().CancelledCollectionNumber) + 1;
                            cancelledCollectionNumber = FillLeadingZeroes(newCancelledCollectionNumber, 10);
                        }

                        String oldObject2 = Modules.SysAuditTrailModule.GetObjectString(collection.FirstOrDefault());

                        var cancelCollection = collection.FirstOrDefault();
                        cancelCollection.CancelledCollectionNumber = cancelledCollectionNumber;
                        cancelCollection.Remarks = cancelRemarks;
                        cancelCollection.IsCancelled = true;
                        cancelCollection.UpdateUserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);
                        cancelCollection.UpdateDateTime = DateTime.Now;
                        db.SubmitChanges();

                        String newObject2 = Modules.SysAuditTrailModule.GetObjectString(collection.FirstOrDefault());

                        Entities.SysAuditTrailEntity newAuditTrail2 = new Entities.SysAuditTrailEntity()
                        {
                            UserId = currentUserLogin.FirstOrDefault().Id,
                            AuditDate = DateTime.Now,
                            TableInformation = "TrnCollection",
                            RecordInformation = oldObject2,
                            FormInformation = newObject2,
                            ActionInformation = "CancelSales"
                        };
                        Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail2);

                        return new String[] { "", "1" };
                    }
                    else
                    {
                        return new String[] { "Collection not found.", "0" };
                    }
                }
                else
                {
                    return new String[] { "Sales not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===============
        // Get Last Change
        // ===============
        public Decimal GetLastChange(Int32 terminalId)
        {
            Decimal lastChange = 0;

            var lastCollection = from d in db.TrnCollections
                                 where d.TerminalId == terminalId
                                 select d;

            if (lastCollection.Any())
            {
                lastChange = lastCollection.OrderByDescending(d => d.Id).FirstOrDefault().ChangeAmount;
            }

            return lastChange;
        }

        // =================
        // Get Collection Id
        // =================
        public Int32 GetCollectionId(Int32 salesId)
        {
            Int32 collectionId = 0;

            var collection = from d in db.TrnCollections
                             where d.SalesId == salesId
                             select d;

            if (collection.Any())
            {
                collectionId = collection.FirstOrDefault().Id;
            }

            return collectionId;
        }

        // ====================
        // Check Tendered Sales
        // ====================
        public Boolean IsSalesTendered(Int32 salesId)
        {
            Boolean isTendered = false;

            var collection = from d in db.TrnCollections
                             where d.SalesId == salesId
                             && d.IsLocked == true
                             && d.IsCancelled == false
                             select d;

            if (collection.Any())
            {
                isTendered = true;
            }

            return isTendered;
        }

        // ======================
        // Dropdown List Discount
        // ======================
        public List<Entities.MstDiscountEntity> DropdownListDiscount()
        {
            var discounts = from d in db.MstDiscounts
                            where d.Id != 3
                            select new Entities.MstDiscountEntity
                            {
                                Id = d.Id,
                                Discount = d.Discount,
                                DiscountRate = d.DiscountRate
                            };

            return discounts.ToList();
        }

        // ==============
        // Discount Sales
        // ==============
        public String[] DiscountSales(Int32 salesId, Entities.TrnSalesEntity objSalesEntity)
        {
            try
            {
                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            select d;

                if (sales.Any())
                {
                    var updateSales = sales.FirstOrDefault();
                    updateSales.DiscountId = objSalesEntity.DiscountId;
                    updateSales.SeniorCitizenId = objSalesEntity.SeniorCitizenId;
                    updateSales.SeniorCitizenName = objSalesEntity.SeniorCitizenName;
                    updateSales.SeniorCitizenAge = objSalesEntity.SeniorCitizenAge;
                    updateSales.UpdateUserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);
                    updateSales.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    Decimal discountRate = 0;

                    var discount = from d in db.MstDiscounts
                                   where d.Id == objSalesEntity.DiscountId
                                   select d;

                    if (discount.Any())
                    {
                        discountRate = discount.FirstOrDefault().DiscountRate;
                    }

                    var salesLines = from d in db.TrnSalesLines
                                     where d.SalesId == salesId
                                     select d;

                    if (salesLines.Any())
                    {
                        foreach (var salesLine in salesLines)
                        {
                            Decimal quantity = salesLine.Quantity;
                            Decimal price = salesLine.Price;
                            Decimal taxRate = salesLine.TaxRate;
                            Decimal priceVatExempt = 0;
                            Decimal discountAmount = 0;
                            Decimal taxAmount = 0;
                            Decimal netPrice = 0;
                            Decimal amount = 0;

                            if (discount.FirstOrDefault().IsVatExempt == true)
                            {
                                if (taxRate > 0)
                                {
                                    priceVatExempt = price - (price / (1 + (taxRate / 100))) * (taxRate / 100);

                                    discountAmount = priceVatExempt * (discountRate / 100);
                                    netPrice = priceVatExempt - discountAmount;
                                    amount = netPrice * quantity;
                                }
                                else
                                {
                                    discountAmount = price * (discountRate / 100);
                                    netPrice = price - discountAmount;
                                    amount = netPrice * quantity;
                                }

                                salesLine.DiscountId = discount.FirstOrDefault().Id;
                                salesLine.DiscountRate = discountRate;
                                salesLine.DiscountAmount = discountAmount;
                                salesLine.NetPrice = netPrice;
                                salesLine.Amount = amount;
                                salesLine.TaxId = 18;
                                salesLine.TaxRate = 0;
                                salesLine.TaxAmount = 0;
                            }
                            else
                            {
                                if (taxRate > 0)
                                {
                                    discountAmount = price * (discountRate / 100);
                                    netPrice = price - discountAmount;
                                    amount = netPrice * quantity;
                                    taxAmount = (price * quantity) / (1 + (taxRate / 100)) * (taxRate / 100);
                                }
                                else
                                {
                                    discountAmount = price * (discountRate / 100);
                                    netPrice = price - discountAmount;
                                    amount = netPrice * quantity;
                                    taxAmount = 0;
                                }

                                salesLine.DiscountId = discount.FirstOrDefault().Id;
                                salesLine.DiscountRate = discountRate;
                                salesLine.DiscountAmount = discountAmount;
                                salesLine.NetPrice = netPrice;
                                salesLine.Amount = amount;
                                salesLine.TaxAmount = taxAmount;
                            }

                            db.SubmitChanges();
                        }
                    }

                    if (discount.FirstOrDefault().Id == 2)
                    {
                        updateSales.DiscountId = null;
                        updateSales.SeniorCitizenId = "";
                        updateSales.SeniorCitizenName = "";
                        updateSales.SeniorCitizenAge = null;
                    }

                    updateSales.Amount = sales.FirstOrDefault().TrnSalesLines.Any() ? sales.FirstOrDefault().TrnSalesLines.Sum(d => d.Amount) : 0;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Discount Detail Sales 
        // =====================
        public Entities.TrnSalesEntity DiscountDetailSales(Int32 id)
        {
            var sales = from d in db.TrnSales
                        where d.Id == id
                        select new Entities.TrnSalesEntity
                        {
                            DiscountId = d.DiscountId,
                            SeniorCitizenId = d.SeniorCitizenId,
                            SeniorCitizenName = d.SeniorCitizenName,
                            SeniorCitizenAge = d.SeniorCitizenAge
                        };

            return sales.FirstOrDefault();
        }

        // ===================================
        // Can Cancel Collection Previous Date
        // ===================================
        public Boolean CanCancelCollection(Int32 salesId)
        {
            var collection = from d in db.TrnCollections
                             where d.SalesId == salesId
                             select d;

            if (collection.Any())
            {
                var lastCollection = from d in db.TrnCollections.OrderByDescending(d => d.Id)
                                     where d.IsLocked == true
                                     select d;

                if (lastCollection.Any())
                {
                    if (lastCollection.FirstOrDefault().CollectionDate.Date == collection.FirstOrDefault().CollectionDate)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        // ==========
        // Lock Sales
        // ==========
        public String[] LockSales(Int32 salesId)
        {
            try
            {
                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            select d;

                if (sales.Any())
                {
                    var updateSales = sales.FirstOrDefault();
                    updateSales.IsLocked = true;
                    updateSales.UpdateUserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);
                    updateSales.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ============
        // Unlock Sales
        // ============
        public String[] UnlockSales(Int32 salesId)
        {
            try
            {
                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            select d;

                if (sales.Any())
                {
                    var updateSales = sales.FirstOrDefault();
                    updateSales.IsLocked = false;
                    updateSales.UpdateUserId = Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId);
                    updateSales.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Sales not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ============
        // Table Groups
        // ============
        public List<Entities.MstTableGroupEntity> ListTableGroup()
        {
            var tableGroups = from d in db.MstTableGroups
                              where d.TableGroup != "Walk-in" && d.TableGroup != "Delivery"
                              select new Entities.MstTableGroupEntity
                              {
                                  Id = d.Id,
                                  TableGroup = d.TableGroup,
                                  EntryUserId = d.EntryUserId,
                                  EntryUserName = d.MstUser.UserName,
                                  EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                  UpdateUserId = d.UpdateUserId,
                                  UpdatedUserName = d.MstUser1.UserName,
                                  UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                                  IsLocked = d.IsLocked,
                              };

            return tableGroups.OrderBy(d => d.TableGroup).ToList();
        }

        // ======
        // Tables
        // ======
        public List<Entities.MstTableEntity> ListTable(Int32 tableGroupId)
        {
            var tables = from d in db.MstTables
                         where d.TableGroupId == tableGroupId
                         select new Entities.MstTableEntity
                         {
                             Id = d.Id,
                             TableCode = d.TableCode,
                         };

            return tables.OrderBy(d => d.TableCode).ToList();
        }

        // ===============
        // List Item Group 
        // ===============
        public List<Entities.MstItemGroupEntity> ListItemGroup()
        {
            var itemGroups = from d in db.MstItemGroups
                             select new Entities.MstItemGroupEntity
                             {
                                 Id = d.Id,
                                 ItemGroup = d.ItemGroup,
                                 ImagePath = d.ImagePath,
                                 KitchenReport = d.KitchenReport,
                                 EntryUserId = d.EntryUserId,
                                 EntryUserName = d.MstUser.UserName,
                                 EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                 UpdateUserId = d.UpdateUserId,
                                 UpdatedUserName = d.MstUser1.UserName,
                                 UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                                 IsLocked = d.IsLocked,
                             };

            return itemGroups.OrderBy(d => d.ItemGroup).ToList();
        }

        // ====================
        // List Item Group Item
        // ====================
        public List<Entities.MstItemGroupItemEntity> ListItemGroupItem(Int32 itemGroupId)
        {
            var itemGroupItems = from d in db.MstItemGroupItems
                                 where d.ItemGroupId == itemGroupId
                                 select new Entities.MstItemGroupItemEntity
                                 {
                                     Id = d.Id,
                                     ItemId = d.ItemId,
                                     Barcode = d.MstItem.BarCode,
                                     Alias = d.MstItem.Alias
                                 };

            return itemGroupItems.OrderBy(d => d.Alias).ToList();
        }
    }
}
