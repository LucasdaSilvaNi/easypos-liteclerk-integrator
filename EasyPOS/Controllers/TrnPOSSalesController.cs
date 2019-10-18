using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class TrnPOSSalesController
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

        // ========================
        // Dropdown List - Terminal
        // ========================
        public List<Entities.MstTerminal> DropdownListTerminal()
        {
            var terminals = from d in db.MstTerminals
                            select new Entities.MstTerminal
                            {
                                Id = d.Id,
                                Terminal = "Terminal: " + d.Terminal
                            };

            return terminals.ToList();
        }

        // ============
        // List - Sales 
        // ============
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
                            EntryDateTime = d.EntryDateTime.ToString(),
                            UpdateUserId = d.UpdateUserId,
                            UpdatedUserName = d.MstUser4.FullName,
                            UpdateDateTime = d.UpdateDateTime.ToString(),
                            Pax = d.Pax,
                            TableStatus = d.TableStatus,
                        };

            return sales.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // Detail - Sales 
        // ==============
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
                            EntryDateTime = d.EntryDateTime.ToString(),
                            UpdateUserId = d.UpdateUserId,
                            UpdatedUserName = d.MstUser4.FullName,
                            UpdateDateTime = d.UpdateDateTime.ToString(),
                            Pax = d.Pax,
                            TableStatus = d.TableStatus,
                        };

            return sales.FirstOrDefault();
        }

        // ===========
        // Add - Sales 
        // ===========
        public String[] AddSales()
        {
            try
            {
                var period = from d in db.MstPeriods where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentPeriodId) select d;
                if (period.Any() == false)
                {
                    return new String[] { "Period not found.", "0" };
                }

                var table = from d in db.MstTables select d;
                if (table.Any() == false)
                {
                    return new String[] { "Table not found.", "0" };
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
                    SalesDate = DateTime.Today,
                    SalesNumber = salesNumber,
                    ManualInvoiceNumber = terminal.FirstOrDefault().Terminal + "-" + salesNumber,
                    Amount = 0,
                    TableId = table.FirstOrDefault().Id,
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

                return new String[] { "", newSales.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =======================
        // Tender - List Pay Types 
        // =======================
        public List<Entities.MstPayType> TenderListPayType()
        {
            var payTypes = from d in db.MstPayTypes
                           select new Entities.MstPayType
                           {
                               Id = d.Id,
                               PayType = d.PayType,
                               SortNumber = d.SortNumber,
                               Amount = 0
                           };

            return payTypes.OrderBy(d => d.SortNumber).ToList();
        }

        // ==============
        // Tender - Sales
        // ==============
        public String[] TenderSales(Int32 salesId, Entities.TrnCollectionEntity objCollection)
        {
            try
            {
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
                var lastSales = from d in db.TrnSales.OrderByDescending(d => d.Id) select d;
                if (lastSales.Any())
                {
                    Int32 newSalesNumber = Convert.ToInt32(lastSales.FirstOrDefault().SalesNumber) + 1;
                    collectionNumber = FillLeadingZeroes(newSalesNumber, 10);
                }

                Data.TrnCollection newCollection = new Data.TrnCollection
                {
                    PeriodId = currentSales.FirstOrDefault().PeriodId,
                    CollectionDate = DateTime.Today,
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
                    EntryDateTime = DateTime.Now.Date,
                    UpdateUserId = user.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Now.Date
                };

                db.TrnCollections.InsertOnSubmit(newCollection);
                db.SubmitChanges();

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

                var lockSales = currentSales.FirstOrDefault();
                lockSales.PaidAmount = paidAmount;
                lockSales.BalanceAmount = salesAmount - paidAmount;
                lockSales.IsLocked = true;
                lockSales.IsTendered = true;
                db.SubmitChanges();

                Modules.TrnInventoryModule trnInventoryModule = new Modules.TrnInventoryModule();
                trnInventoryModule.UpdateSalesInventory(currentSales.FirstOrDefault().Id);

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
        public List<Entities.MstCustomer> TenderSalesDropdownListCustomer()
        {
            var customers = from d in db.MstCustomers
                            select new Entities.MstCustomer
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
        public List<Entities.MstTerm> TenderSalesDropdownListTerm()
        {
            var terms = from d in db.MstTerms
                        select new Entities.MstTerm
                        {
                            Id = d.Id,
                            Term = d.Term
                        };

            return terms.OrderBy(d => d.Term).ToList();
        }

        // ==================================
        // Tender Sales - Dropdown List Users
        // ==================================
        public List<Entities.MstUser> TenderSalesDropdownListUser()
        {
            var users = from d in db.MstUsers
                        select new Entities.MstUser
                        {
                            Id = d.Id,
                            FullName = d.FullName
                        };

            return users.OrderBy(d => d.FullName).ToList();
        }

        // =====================
        // Tender - Update Sales
        // =====================
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

        // ==============
        // Delete - Sales 
        // ==============
        public String[] DeleteSales(Int32 salesId)
        {
            try
            {
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

        // ==============
        // Cancel - Sales
        // ==============
        public String[] CancelSales(Int32 salesId)
        {
            try
            {
                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            && d.IsLocked == true
                            && d.IsCancelled == false
                            select d;

                if (sales.Any())
                {
                    var collection = from d in db.TrnCollections
                                     where d.SalesId == salesId
                                     && d.IsLocked == true
                                     && d.IsCancelled == false
                                     select d;

                    if (collection.Any())
                    {
                        var cancelSales = sales.FirstOrDefault();
                        cancelSales.IsCancelled = true;
                        db.SubmitChanges();

                        var cancelCollection = collection.FirstOrDefault();
                        cancelCollection.IsCancelled = true;
                        db.SubmitChanges();

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
    }
}
