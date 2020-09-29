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
    class LiteclerkMstArticleSupplierController
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
        public LiteclerkMstArticleSupplierController(Forms.Software.SysSettings.SysSettingsForm form, String actDate)
        {
            sysSettingsForm = form;
            activityDate = actDate;
        }

        // =============
        // Sync Supplier
        // =============
        public async void SyncSupplier(String apiUrlHost)
        {
            await GetSupplier(apiUrlHost);
        }

        // ============
        // Get Supplier
        // ============
        public Task GetSupplier(String apiUrlHost)
        {
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                DateTime dateTimeToday = DateTime.Now;
                String currentDate = Convert.ToDateTime(activityDate).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);

                // ============
                // Http Request
                // ============
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://" + apiUrlHost + "/api/EasyPOSMstArticleSupplierAPI/list/locked/byUpdatedDateTime/" + currentDate);
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
                    List<Entities.LiteclerkMstArticleSupplier> supplierLists = (List<Entities.LiteclerkMstArticleSupplier>)js.Deserialize(result, typeof(List<Entities.LiteclerkMstArticleSupplier>));

                    if (supplierLists.Any())
                    {
                        foreach (var supplier in supplierLists)
                        {
                            var terms = from d in posdb.MstTerms where d.Term.Equals(supplier.Term.ManualCode) select d;
                            if (terms.Any())
                            {
                                var defaultSettings = from d in posdb.IntCloudSettings select d;

                                var currentSupplier = from d in posdb.MstSuppliers where d.Supplier.Equals(supplier.Supplier) && d.IsLocked == true select d;
                                if (currentSupplier.Any())
                                {
                                    Boolean foundChanges = false;

                                    if (!foundChanges)
                                    {
                                        if (!currentSupplier.FirstOrDefault().Supplier.Equals(supplier.Supplier))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (!foundChanges)
                                    {
                                        if (!currentSupplier.FirstOrDefault().Address.Equals(supplier.Address))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (!foundChanges)
                                    {
                                        if (!currentSupplier.FirstOrDefault().CellphoneNumber.Equals(supplier.ContactNumber))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    if (!foundChanges)
                                    {
                                        if (!currentSupplier.FirstOrDefault().MstTerm.Term.Equals(supplier.Term.ManualCode))
                                        {
                                            foundChanges = true;
                                        }
                                    }

                                    //if (!foundChanges)
                                    //{
                                    //    if (!currentSupplier.FirstOrDefault().TIN.Equals(supplier.TaxNumber))
                                    //    {
                                    //        foundChanges = true;
                                    //    }
                                    //}

                                    if (foundChanges)
                                    {
                                        sysSettingsForm.logMessages("Updating Supplier...\r\n\n");
                                        sysSettingsForm.logMessages("Supplier: " + currentSupplier.FirstOrDefault().Supplier + "\r\n\n");
                                        sysSettingsForm.logMessages("Contact No.: " + currentSupplier.FirstOrDefault().CellphoneNumber + "\r\n\n");

                                        var updateSupplier = currentSupplier.FirstOrDefault();
                                        updateSupplier.Supplier = supplier.Supplier;
                                        updateSupplier.Address = supplier.Address;
                                        updateSupplier.CellphoneNumber = supplier.ContactNumber;
                                        updateSupplier.TermId = terms.FirstOrDefault().Id;
                                        //updateSupplier.TIN = supplier.TaxNumber;
                                        updateSupplier.UpdateUserId = defaultSettings.FirstOrDefault().PostUserId;
                                        updateSupplier.UpdateDateTime = DateTime.Now;
                                        posdb.SubmitChanges();

                                        sysSettingsForm.logMessages("Update Successful!\r\n\n");
                                        sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                        sysSettingsForm.logMessages("\r\n\n");
                                    }
                                }
                                else
                                {
                                    sysSettingsForm.logMessages("Saving Supplier...\r\n\n");
                                    sysSettingsForm.logMessages("Supplier: " + supplier.Supplier + "\r\n\n");
                                    sysSettingsForm.logMessages("Contact No.: " + supplier.ContactNumber + "\r\n\n");

                                    Data.MstSupplier newSupplier = new Data.MstSupplier
                                    {
                                        Supplier = supplier.Supplier,
                                        Address = supplier.Address,
                                        TelephoneNumber = "NA",
                                        CellphoneNumber = supplier.ContactNumber,
                                        FaxNumber = "NA",
                                        TermId = terms.FirstOrDefault().Id,
                                        TIN = "NA",
                                        AccountId = 254,
                                        EntryUserId = defaultSettings.FirstOrDefault().PostUserId,
                                        EntryDateTime = DateTime.Now,
                                        UpdateUserId = defaultSettings.FirstOrDefault().PostUserId,
                                        UpdateDateTime = DateTime.Now,
                                        IsLocked = true,
                                    };

                                    posdb.MstSuppliers.InsertOnSubmit(newSupplier);
                                    posdb.SubmitChanges();

                                    sysSettingsForm.logMessages("Save Successful!\r\n\n");
                                    sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                    sysSettingsForm.logMessages("\r\n\n");
                                }
                            }
                            else
                            {
                                sysSettingsForm.logMessages("Supplier Integration Failed!\r\n\n");
                                sysSettingsForm.logMessages("Supplier: " + supplier.Supplier + "\r\n\n");
                                sysSettingsForm.logMessages("Contact No.: " + supplier.ContactNumber + "\r\n\n");
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
                sysSettingsForm.logMessages("Supplier Integration Failed!\r\n\n");
                sysSettingsForm.logMessages("Error: " + e.Message + "\r\n\n");
                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                sysSettingsForm.logMessages("\r\n\n");

                return Task.FromResult("");
            }
        }
    }
}
