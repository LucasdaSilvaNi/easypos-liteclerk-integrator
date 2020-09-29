using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EasyPOS.LiteclerkIntegration.Controllers
{
    class LiteclerkMstArticleCustomerController
    {
        // ====
        // Data
        // ====
        private Data.easyposdbDataContext posdb = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        public Forms.Software.SysSettings.SysSettingsForm sysSettingsForm;
        public String activityDate;

        // ===========
        // Constructor
        // ===========
        public LiteclerkMstArticleCustomerController(Forms.Software.SysSettings.SysSettingsForm form, String actDate)
        {
            sysSettingsForm = form;
            activityDate = actDate;
        }

        // =============
        // Sync Customer
        // =============
        public async void SyncCustomer(String apiUrlHost)
        {
            await GetCustomer(apiUrlHost);
        }

        // ============
        // Get Customer
        // ============
        public Task GetCustomer(String apiUrlHost)
        {
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                DateTime dateTimeToday = DateTime.Now;
                String currentDate = Convert.ToDateTime(activityDate).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);

                // ============
                // Http Request
                // ============
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://" + apiUrlHost + "/api/EasyPOSMstArticleCustomerAPI/list/locked/byUpdatedDateTime/" + currentDate);
                httpWebRequest.Method = "GET";
                httpWebRequest.Accept = "application/json";

                // ================
                // Process Response
                // ================
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();

                    List<Entities.LiteclerkMstArticleCustomer> customerLists = (List<Entities.LiteclerkMstArticleCustomer>)js.Deserialize(result, typeof(List<Entities.LiteclerkMstArticleCustomer>));

                    if (customerLists.Any())
                    {
                        foreach (var customer in customerLists)
                        {
                            var terms = from d in posdb.MstTerms where d.Term.Equals(customer.Term.ManualCode) select d;
                            if (terms.Any())
                            {
                                var defaultSettings = from d in posdb.IntCloudSettings select d;

                                var currentCustomer = from d in posdb.MstCustomers where d.CustomerCode.Equals(customer.ArticleManualCode) && d.CustomerCode != null && d.IsLocked == true select d;
                                if (currentCustomer.Any())
                                {
                                    Boolean foundChanges = false;

                                    if (!foundChanges)
                                    {
                                        if (!currentCustomer.FirstOrDefault().Customer.Equals(customer.Customer))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (!foundChanges)
                                    {
                                        if (!currentCustomer.FirstOrDefault().Address.Equals(customer.Address))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (!foundChanges)
                                    {
                                        if (!currentCustomer.FirstOrDefault().ContactPerson.Equals(customer.ContactPerson))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (!foundChanges)
                                    {
                                        if (!currentCustomer.FirstOrDefault().ContactNumber.Equals(customer.ContactNumber))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (!foundChanges)
                                    {
                                        if (!currentCustomer.FirstOrDefault().MstTerm.Term.Equals(customer.Term.ManualCode))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    //if (!foundChanges)
                                    //{
                                    //    if (!currentCustomer.FirstOrDefault().TIN.Equals(customer.TIN))
                                    //    {
                                    //        foundChanges = true;
                                    //    }
                                    //}

                                    if (!foundChanges)
                                    {
                                        if (Convert.ToDecimal(currentCustomer.FirstOrDefault().CreditLimit) != Convert.ToDecimal(customer.CreditLimit))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (foundChanges)
                                    {
                                        sysSettingsForm.logMessages("Updating Customer...\r\n\n");
                                        sysSettingsForm.logMessages("Customer Code: " + currentCustomer.FirstOrDefault().CustomerCode + "\r\n\n");
                                        sysSettingsForm.logMessages("Customer: " + currentCustomer.FirstOrDefault().Customer + "\r\n\n");

                                        var updateCustomer = currentCustomer.FirstOrDefault();
                                        updateCustomer.Customer = customer.Customer;
                                        updateCustomer.Address = customer.Address;
                                        updateCustomer.ContactPerson = customer.ContactPerson;
                                        updateCustomer.ContactNumber = customer.ContactNumber;
                                        updateCustomer.CreditLimit = customer.CreditLimit;
                                        updateCustomer.TermId = terms.FirstOrDefault().Id;
                                        //updateCustomer.TIN = customer.TaxNumber;
                                        updateCustomer.UpdateUserId = defaultSettings.FirstOrDefault().PostUserId;
                                        updateCustomer.UpdateDateTime = DateTime.Now;
                                        updateCustomer.CustomerCode = customer.ArticleManualCode;
                                        posdb.SubmitChanges();

                                        sysSettingsForm.logMessages("Update Successful!\r\n\n");
                                        sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                        sysSettingsForm.logMessages("\r\n\n");
                                    }
                                }
                                else
                                {
                                    sysSettingsForm.logMessages("Saving Customer...\r\n\n");
                                    sysSettingsForm.logMessages("Customer Code: " + customer.ArticleManualCode + "\r\n\n");
                                    sysSettingsForm.logMessages("Customer: " + customer.Customer + "\r\n\n");

                                    Data.MstCustomer newCustomer = new Data.MstCustomer
                                    {
                                        Customer = customer.Customer,
                                        Address = customer.Address,
                                        ContactPerson = customer.ContactPerson,
                                        ContactNumber = customer.ContactNumber,
                                        CreditLimit = customer.CreditLimit,
                                        TermId = terms.FirstOrDefault().Id,
                                        TIN = "", /*customer.TaxNumber,*/
                                        WithReward = false,
                                        RewardNumber = null,
                                        RewardConversion = 4,
                                        AccountId = 64,
                                        EntryUserId = defaultSettings.FirstOrDefault().PostUserId,
                                        EntryDateTime = DateTime.Now,
                                        UpdateUserId = defaultSettings.FirstOrDefault().PostUserId,
                                        UpdateDateTime = DateTime.Now,
                                        IsLocked = true,
                                        DefaultPriceDescription = null,
                                        CustomerCode = customer.ArticleManualCode,
                                    };

                                    posdb.MstCustomers.InsertOnSubmit(newCustomer);
                                    posdb.SubmitChanges();

                                    sysSettingsForm.logMessages("Save Successful!\r\n\n");
                                    sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                    sysSettingsForm.logMessages("\r\n\n");
                                }
                            }
                            else
                            {
                                sysSettingsForm.logMessages("Customer Integration Failed!\r\n\n");
                                sysSettingsForm.logMessages("Customer Code: " + customer.ArticleManualCode + "\r\n\n");
                                sysSettingsForm.logMessages("Customer: " + customer.Customer + "\r\n\n");
                                sysSettingsForm.logMessages("Error: Term Mismatch.\r\n\n");
                                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                sysSettingsForm.logMessages("\r\n\n");
                            }
                        }
                    }
                }

                return Task.FromResult("");
            }
            catch (Exception e)
            {
                sysSettingsForm.logMessages("Customer Integration Failed!\r\n\n");
                sysSettingsForm.logMessages("Error: " + e.Message + "\r\n\n");
                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                sysSettingsForm.logMessages("\r\n\n");

                return Task.FromResult("");
            }
        }
    }
}
