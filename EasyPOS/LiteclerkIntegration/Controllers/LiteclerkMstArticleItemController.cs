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
    class LiteclerkMstArticleItemController
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
        public LiteclerkMstArticleItemController(Forms.Software.SysSettings.SysSettingsForm form, String actDate)
        {
            sysSettingsForm = form;
            activityDate = actDate;
        }

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

        // =========
        // Sync Item
        // =========
        public async void SyncItem(String apiUrlHost)
        {
            await GetItem(apiUrlHost);
        }

        // ========
        // Get Item
        // ========
        public Task GetItem(String apiUrlHost)
        {
            try
            {
                ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                DateTime dateTimeToday = DateTime.Now;
                String currentDate = Convert.ToDateTime(activityDate).ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);

                // ============
                // Http Request
                // ============
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://" + apiUrlHost + "/api/EasyPOSMstArticleItemAPI/list/locked/byUpdatedDateTime/" + currentDate);
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
                    List<Entities.LiteclerkMstArticleItem> itemLists = (List<Entities.LiteclerkMstArticleItem>)js.Deserialize(result, typeof(List<Entities.LiteclerkMstArticleItem>));

                    if (itemLists.Any())
                    {
                        foreach (var item in itemLists)
                        {
                            var units = from d in posdb.MstUnits where d.Unit.Equals(item.Unit.ManualCode) select d;
                            if (units.Any())
                            {
                                var taxes = from d in posdb.MstTaxes where d.Tax.Equals(item.SIVAT.ManualCode) select d;
                                if (taxes.Any())
                                {
                                    var supplier = from d in posdb.MstSuppliers select d;
                                    if (supplier.Any())
                                    {
                                        var defaultSettings = from d in posdb.IntCloudSettings select d;

                                        var currentItem = from d in posdb.MstItems where d.BarCode.Equals(item.BarCode) && d.MstUnit.Unit.Equals(item.Unit.ManualCode) && d.IsLocked == true select d;
                                        if (currentItem.Any())
                                        {
                                            Boolean foundChanges = false;

                                            if (!foundChanges)
                                            {
                                                if (!currentItem.FirstOrDefault().BarCode.Equals(item.BarCode))
                                                {
                                                    foundChanges = true;
                                                }
                                            }

                                            if (!foundChanges)
                                            {
                                                if (!currentItem.FirstOrDefault().ItemDescription.Equals(item.Description))
                                                {
                                                    foundChanges = true;
                                                }
                                            }

                                            if (!foundChanges)
                                            {
                                                if (!currentItem.FirstOrDefault().Category.Equals(item.Category))
                                                {
                                                    foundChanges = true;
                                                }
                                            }

                                            if (!foundChanges)
                                            {
                                                if (!currentItem.FirstOrDefault().MstUnit.Unit.Equals(item.Unit.ManualCode))
                                                {
                                                    foundChanges = true;
                                                }
                                            }

                                            if (!defaultSettings.FirstOrDefault().UseItemPrice)
                                            {
                                                if (!foundChanges)
                                                {
                                                    if (currentItem.FirstOrDefault().Price != item.Price)
                                                    {
                                                        foundChanges = true;
                                                    }
                                                }
                                            }

                                            //if (!foundChanges)
                                            //{
                                            //    if (currentItem.FirstOrDefault().Cost != item.Cost)
                                            //    {
                                            //        foundChanges = true;
                                            //    }
                                            //}

                                            if (!foundChanges)
                                            {
                                                if (currentItem.FirstOrDefault().IsInventory != item.IsInventory)
                                                {
                                                    foundChanges = true;
                                                }
                                            }

                                            //if (!foundChanges)
                                            //{
                                            //    if (currentItem.FirstOrDefault().Remarks != null)
                                            //    {
                                            //        if (!currentItem.FirstOrDefault().Remarks.Equals(item.Particulars))
                                            //        {
                                            //            foundChanges = true;
                                            //        }
                                            //    }
                                            //}

                                            if (!foundChanges)
                                            {
                                                if (currentItem.FirstOrDefault().OutTaxId != taxes.FirstOrDefault().Id)
                                                {
                                                    foundChanges = true;
                                                }
                                            }

                                            if (!defaultSettings.FirstOrDefault().UseItemPrice)
                                            {
                                                if (!foundChanges)
                                                {
                                                    if (item.ArticleItemPrices.Any())
                                                    {
                                                        var posItemPrices = from d in posdb.MstItemPrices where d.MstItem.BarCode.Equals(item.ArticleManualCode) select d;
                                                        if (posItemPrices.Any())
                                                        {
                                                            if (item.ArticleItemPrices.Count() == posItemPrices.Count())
                                                            {
                                                                foreach (var itemPrice in item.ArticleItemPrices)
                                                                {
                                                                    if (!foundChanges)
                                                                    {
                                                                        var currentPOSItemPrices = from d in posItemPrices where d.PriceDescription.Equals(itemPrice.PriceDescription) && d.Price == itemPrice.Price select d;
                                                                        if (!currentPOSItemPrices.Any())
                                                                        {
                                                                            foundChanges = true;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                foundChanges = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            if (foundChanges)
                                            {
                                                sysSettingsForm.logMessages("Updating Item...\r\n\n");
                                                sysSettingsForm.logMessages("Barcode: " + currentItem.FirstOrDefault().BarCode + "\r\n\n");
                                                sysSettingsForm.logMessages("Item Description: " + currentItem.FirstOrDefault().ItemDescription + "\r\n\n");

                                                var updateItem = currentItem.FirstOrDefault();
                                                updateItem.BarCode = item.ArticleManualCode;
                                                updateItem.ItemDescription = item.Description;
                                                updateItem.Alias = item.Description;
                                                updateItem.GenericName = item.Description;
                                                updateItem.Category = item.Category;
                                                updateItem.UnitId = units.FirstOrDefault().Id;
                                                updateItem.Price = item.Price;
                                                //updateItem.Cost = item.Cost;
                                                updateItem.IsInventory = item.IsInventory;
                                                //updateItem.Remarks = item.Particulars;
                                                updateItem.OutTaxId = taxes.FirstOrDefault().Id;
                                                updateItem.UpdateUserId = defaultSettings.FirstOrDefault().PostUserId;
                                                updateItem.UpdateDateTime = DateTime.Now;
                                                posdb.SubmitChanges();

                                                if (!defaultSettings.FirstOrDefault().UseItemPrice)
                                                {
                                                    if (item.ArticleItemPrices.Any())
                                                    {
                                                        var posItemPrices = from d in posdb.MstItemPrices where d.ItemId == currentItem.FirstOrDefault().Id select d;
                                                        if (posItemPrices.Any())
                                                        {
                                                            posdb.MstItemPrices.DeleteAllOnSubmit(posItemPrices);
                                                            posdb.SubmitChanges();
                                                        }

                                                        List<Data.MstItemPrice> newItemPrice = new List<Data.MstItemPrice>();
                                                        foreach (var itemPrice in item.ArticleItemPrices)
                                                        {
                                                            newItemPrice.Add(new Data.MstItemPrice
                                                            {
                                                                ItemId = currentItem.FirstOrDefault().Id,
                                                                PriceDescription = itemPrice.PriceDescription,
                                                                Price = itemPrice.Price,
                                                                TriggerQuantity = 0
                                                            });
                                                        }

                                                        posdb.MstItemPrices.InsertAllOnSubmit(newItemPrice);
                                                        posdb.SubmitChanges();
                                                    }
                                                }

                                                sysSettingsForm.logMessages("Update Successful!\r\n\n");
                                                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                                sysSettingsForm.logMessages("\r\n\n");
                                            }
                                        }
                                        else
                                        {
                                            sysSettingsForm.logMessages("Saving Item...\r\n\n");
                                            sysSettingsForm.logMessages("Barcode: " + item.ArticleManualCode + "\r\n\n");
                                            sysSettingsForm.logMessages("Item Description: " + item.Description + "\r\n\n");

                                            var itemCode = "0000000001";
                                            var lastItem = from d in posdb.MstItems.OrderByDescending(d => d.Id) select d;
                                            if (lastItem.Any())
                                            {
                                                var newItemCode = Convert.ToInt32(lastItem.FirstOrDefault().ItemCode) + 0000000001;
                                                itemCode = FillLeadingZeroes(newItemCode, 10);
                                            }

                                            Data.MstItem newItem = new Data.MstItem
                                            {
                                                ItemCode = itemCode,
                                                BarCode = item.ArticleManualCode,
                                                ItemDescription = item.Description,
                                                Alias = item.Description,
                                                GenericName = item.Description,
                                                Category = item.Category,
                                                SalesAccountId = 159,
                                                AssetAccountId = 74,
                                                CostAccountId = 238,
                                                InTaxId = 4,
                                                OutTaxId = taxes.FirstOrDefault().Id,
                                                UnitId = units.FirstOrDefault().Id,
                                                DefaultSupplierId = supplier.FirstOrDefault().Id,
                                                Cost = 0,
                                                MarkUp = 0,
                                                Price = item.Price,
                                                ImagePath = "NA",
                                                ReorderQuantity = 0,
                                                OnhandQuantity = 0,
                                                IsInventory = item.IsInventory,
                                                ExpiryDate = null,
                                                LotNumber = " ",
                                                Remarks = "Liteclerk",
                                                EntryUserId = defaultSettings.FirstOrDefault().PostUserId,
                                                EntryDateTime = DateTime.Now,
                                                UpdateUserId = defaultSettings.FirstOrDefault().PostUserId,
                                                UpdateDateTime = DateTime.Now,
                                                IsLocked = true,
                                                DefaultKitchenReport = " ",
                                                IsPackage = false
                                            };

                                            posdb.MstItems.InsertOnSubmit(newItem);
                                            posdb.SubmitChanges();

                                            if (item.ArticleItemPrices.Any())
                                            {
                                                List<Data.MstItemPrice> newItemPrice = new List<Data.MstItemPrice>();
                                                foreach (var itemPrice in item.ArticleItemPrices)
                                                {
                                                    newItemPrice.Add(new Data.MstItemPrice
                                                    {
                                                        ItemId = newItem.Id,
                                                        PriceDescription = itemPrice.PriceDescription,
                                                        Price = itemPrice.Price,
                                                        TriggerQuantity = 0
                                                    });
                                                }

                                                posdb.MstItemPrices.InsertAllOnSubmit(newItemPrice);
                                                posdb.SubmitChanges();
                                            }

                                            sysSettingsForm.logMessages("Save Successful!\r\n\n");
                                            sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                            sysSettingsForm.logMessages("\r\n\n");
                                        }
                                    }
                                    else
                                    {
                                        sysSettingsForm.logMessages("Item Integration Failed!\r\n\n");
                                        sysSettingsForm.logMessages("Barcode: " + item.ArticleManualCode + "\r\n\n");
                                        sysSettingsForm.logMessages("Item Description: " + item.Description + "\r\n\n");
                                        sysSettingsForm.logMessages("Error: Default Supplier is Empty.\r\n\n");
                                        sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                        sysSettingsForm.logMessages("\r\n\n");
                                    }
                                }
                                else
                                {
                                    sysSettingsForm.logMessages("Item Integration Failed!\r\n\n");
                                    sysSettingsForm.logMessages("Barcode: " + item.ArticleManualCode + "\r\n\n");
                                    sysSettingsForm.logMessages("Item Description: " + item.Description + "\r\n\n");
                                    sysSettingsForm.logMessages("Error: Output Tax Mismatch.\r\n\n");
                                    sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                                    sysSettingsForm.logMessages("\r\n\n");
                                }
                            }
                            else
                            {
                                sysSettingsForm.logMessages("Item Integration Failed!\r\n\n");
                                sysSettingsForm.logMessages("Barcode: " + item.ArticleManualCode + "\r\n\n");
                                sysSettingsForm.logMessages("Item Description: " + item.Description + "\r\n\n");
                                sysSettingsForm.logMessages("Error: Unit Mismatch.\r\n\n");
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
                sysSettingsForm.logMessages("Item Integration Failed!\r\n\n");
                sysSettingsForm.logMessages("Error: " + e.Message + "\r\n\n");
                sysSettingsForm.logMessages("Time Stamp: " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + "\r\n\n");
                sysSettingsForm.logMessages("\r\n\n");

                return Task.FromResult("");
            }
        }
    }
}
