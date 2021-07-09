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
    class LiteclerkTrnPointOfSaleController
    {
        // ====
        // Data
        // ====
        private Data.easyposdbDataContext posdb = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());
        public Forms.Software.SysSettings.SysSettingsForm sysSettingsForm;

        // ===========
        // Constructor
        // ===========
        public LiteclerkTrnPointOfSaleController(Forms.Software.SysSettings.SysSettingsForm form)
        {
            sysSettingsForm = form;
        }

        // ==========
        // Sync Sales
        // ==========
        public async void SyncSales(String apiUrlHost, String branchCode, String userCode)
        {
            await GetSales(apiUrlHost, branchCode, userCode);
        }

        // =========
        // Get Sales
        // =========
        public Task GetSales(String apiUrlHost, String branchCode, String userCode)
        {
            try
            {
                var unpostedSales = from d in posdb.TrnSales
                                    where d.IsLocked == true
                                    && d.IsCancelled == false
                                    && d.PostCode == null
                                    select d;

                if (unpostedSales.Any())
                {
                    foreach (var unpostedSale in unpostedSales)
                    {
                        if (unpostedSale.TrnCollections.Where(c => c.IsLocked == true && c.IsCancelled == false).Any())
                        {
                            Int32 salesId = unpostedSale.Id;

                            List<Entities.LiteclerkTrnPointOfSale> listPOSSales = new List<Entities.LiteclerkTrnPointOfSale>();
                            foreach (var salesLine in unpostedSale.TrnSalesLines)
                            {
                                listPOSSales.Add(new Entities.LiteclerkTrnPointOfSale()
                                {
                                    BranchCode = branchCode,
                                    TerminalCode = salesLine.TrnSale.MstTerminal.Terminal,
                                    POSDate = salesLine.TrnSale.SalesDate.ToShortDateString(),
                                    POSNumber = salesLine.TrnSale.TrnCollections.FirstOrDefault().CollectionNumber,
                                    OrderNumber = salesLine.TrnSale.SalesNumber,
                                    CustomerCode = salesLine.TrnSale.MstCustomer.CustomerCode,
                                    ItemCode = salesLine.MstItem.BarCode,
                                    Particulars = "OR: " + salesLine.TrnSale.TrnCollections.FirstOrDefault().CollectionNumber + ", Sales Agent: " + salesLine.TrnSale.MstUser5.UserName,
                                    Quantity = salesLine.Quantity,
                                    Price = salesLine.Price,
                                    Discount = salesLine.DiscountAmount,
                                    NetPrice = salesLine.NetPrice,
                                    Amount = salesLine.Amount,
                                    TaxCode = salesLine.MstTax.Code,
                                    TaxAmount = salesLine.TaxAmount,
                                    CashierUserCode = salesLine.TrnSale.MstUser.UserName,
                                    TimeStamp = DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt"),
                                    PostCode = ""
                                });
                            }

                            String json = new JavaScriptSerializer().Serialize(listPOSSales);

                            sysSettingsForm.logMessages("Sending Sales...\r\n\n");
                            sysSettingsForm.logMessages("Sales Number: " + unpostedSale.SalesNumber + "\r\n\n");
                            sysSettingsForm.logMessages("Sales Date: " + unpostedSale.SalesDate.ToShortDateString() + "\r\n\n");
                            sysSettingsForm.logMessages("OR Number: " + unpostedSale.TrnCollections.FirstOrDefault().CollectionNumber + "\r\n\n");
                            sysSettingsForm.logMessages("Amount: " + unpostedSale.Amount.ToString("#,##0.00") + "\r\n\n");

                            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://" + apiUrlHost + "/api/EasyPOSTrnPointOfSaleAPI/add");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";
                            httpWebRequest.Accept = "*/*";

                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                List<Entities.LiteclerkTrnPointOfSale> POSSales = new JavaScriptSerializer().Deserialize<List<Entities.LiteclerkTrnPointOfSale>>(json);
                                streamWriter.Write(new JavaScriptSerializer().Serialize(POSSales));
                            }

                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var result = streamReader.ReadToEnd();
                                if (result != null)
                                {
                                    var sales = from d in posdb.TrnSales
                                                where d.Id == salesId
                                                select d;

                                    if (sales.Any())
                                    {
                                        var updateSales = sales.FirstOrDefault();
                                        updateSales.PostCode = result.Replace("\"", "");
                                        posdb.SubmitChanges();
                                    }

                                    sysSettingsForm.logMessages("Send Succesful!" + "\r\n\n");
                                    sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                    sysSettingsForm.logMessages("\r\n\n");
                                }
                            }

                            break;
                        }
                    }
                }

                return Task.FromResult("");
            }
            catch (WebException we)
            {
                var resp = new StreamReader(we.Response.GetResponseStream()).ReadToEnd();

                sysSettingsForm.logMessages(resp.Replace("\"", "") + "\r\n\n");
                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                sysSettingsForm.logMessages("\r\n\n");

                return Task.FromResult("");
            }
            catch (Exception e)
            {
                sysSettingsForm.logMessages("Sales Error: " + e.Message + "\r\n\n");
                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                sysSettingsForm.logMessages("\r\n\n");

                return Task.FromResult("");
            }
        }
    }
}
