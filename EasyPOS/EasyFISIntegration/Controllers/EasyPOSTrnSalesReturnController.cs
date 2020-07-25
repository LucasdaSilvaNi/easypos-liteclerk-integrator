using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EasyPOS.EasyFISIntegration.Controllers
{
    class EasyPOSTrnSalesReturnController
    {
        // ====
        // Data
        // ====
        private Data.easyposdbDataContext posdb = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        public Forms.Software.SysSettings.SysSettingsForm sysSettingsForm;

        // ===========
        // Constructor
        // ===========
        public EasyPOSTrnSalesReturnController(Forms.Software.SysSettings.SysSettingsForm form)
        {
            sysSettingsForm = form;
        }

        // =================
        // Sync Sales Return
        // =================
        public async void SyncSalesReturn(String apiUrlHost, String branchCode, String userCode)
        {
            await GetSalesReturn(apiUrlHost, branchCode, userCode);
        }

        // ================
        // Get Sales Return
        // ================
        public Task GetSalesReturn(String apiUrlHost, String branchCode, String userCode)
        {
            try
            {
                var stockIns = from d in posdb.TrnStockIns
                               where d.IsReturn == true
                               && d.CollectionId != null
                               //&& d.PostCode == null
                               && d.IsLocked == true
                               && d.TrnStockInLines.Any() == true
                               select d;

                if (stockIns.Any())
                {
                    var stockIn = stockIns.FirstOrDefault();
                    Int32 stockInId = stockIn.Id;

                    List<Entities.EasyPOSTrnCollectionLines> listCollectionLines = new List<Entities.EasyPOSTrnCollectionLines>();

                    var stockInLines = from d in stockIn.TrnStockInLines select d;
                    foreach (var stockInLine in stockInLines)
                    {
                        listCollectionLines.Add(new Entities.EasyPOSTrnCollectionLines()
                        {
                            ItemManualArticleCode = stockInLine.MstItem.BarCode,
                            Particulars = stockInLine.MstItem.ItemDescription,
                            Unit = stockInLine.MstUnit.Unit,
                            Quantity = stockInLine.Quantity * -1,
                            Price = stockInLine.Cost * -1,
                            Discount = "Zero Discount",
                            DiscountAmount = 0,
                            NetPrice = (stockInLine.Cost * -1),
                            Amount = ((stockInLine.Quantity * -1) * (stockInLine.Cost * -1)) * -1,
                            VAT = stockInLine.MstItem.MstTax.Tax,
                            SalesItemTimeStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
                        });
                    }

                    var collectionData = new Entities.EasyPOSTrnCollection()
                    {
                        SIDate = stockIn.StockInDate.ToShortDateString(),
                        BranchCode = branchCode,
                        CustomerManualArticleCode = stockIn.TrnCollection.TrnSale.MstCustomer.CustomerCode,
                        CreatedBy = userCode,
                        Term = stockIn.TrnCollection.TrnSale.MstTerm.Term,
                        DocumentReference = stockIn.StockInNumber,
                        ManualSINumber = "IN-" + stockIn.StockInNumber,
                        Remarks = "Return from Customer, OR-" + stockIn.TrnCollection.CollectionNumber + ", SI-" + stockIn.TrnCollection.TrnSale.SalesNumber,
                        ListPOSIntegrationTrnSalesInvoiceItem = listCollectionLines.ToList()
                    };

                    String json = new JavaScriptSerializer().Serialize(collectionData);

                    sysSettingsForm.logMessages("Sending Sales Return: " + collectionData.ManualSINumber + "\r\n\n");
                    sysSettingsForm.logMessages("Amount: " + collectionData.ListPOSIntegrationTrnSalesInvoiceItem.Sum(d => d.Amount).ToString("#,##0.00") + "\r\n\n");
                    SendSalesReturn(apiUrlHost, json, stockInId);
                }

                return Task.FromResult("");
            }
            catch (Exception e)
            {
                sysSettingsForm.logMessages("Sales Return Error: " + e.Message + "\r\n\n");
                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                sysSettingsForm.logMessages("\r\n\n");

                return Task.FromResult("");
            }
        }

        // =================
        // Send Sales Return
        // =================
        public void SendSalesReturn(String apiUrlHost, String json, Int32 stockInId)
        {
            try
            {
                // ============
                // Http Request
                // ============
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + apiUrlHost + "/api/add/POSIntegration/salesInvoice");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                // ====
                // Data
                // ====
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    Entities.EasyPOSTrnCollection collection = new JavaScriptSerializer().Deserialize<Entities.EasyPOSTrnCollection>(json);
                    streamWriter.Write(new JavaScriptSerializer().Serialize(collection));
                }

                // ================
                // Process response
                // ================
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result != null)
                    {
                        var stockIns = from d in posdb.TrnStockIns
                                       where d.Id == stockInId
                                       select d;

                        if (stockIns.Any())
                        {
                            var stockIn = stockIns.FirstOrDefault();
                            //stockIn.PostCode = result.Replace("\"", "");
                            posdb.SubmitChanges();
                        }

                        sysSettingsForm.logMessages("Send Succesful!" + "\r\n\n");
                        sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                        sysSettingsForm.logMessages("\r\n\n");
                    }
                }
            }
            catch (WebException we)
            {
                var resp = new StreamReader(we.Response.GetResponseStream()).ReadToEnd();

                sysSettingsForm.logMessages(resp.Replace("\"", "") + "\r\n\n");
                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                sysSettingsForm.logMessages("\r\n\n");
            }
        }
    }
}