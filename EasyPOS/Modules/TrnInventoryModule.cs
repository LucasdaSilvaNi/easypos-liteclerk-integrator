using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Modules
{
    class TrnInventoryModule
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ======================
        // Update Sales Inventory
        // ======================
        public void UpdateSalesInventory(Int32 salesId)
        {
            try
            {
                var sales = from d in db.TrnSales
                            where d.Id == salesId
                            select d;

                if (sales.Any())
                {
                    var salesLines = sales.FirstOrDefault().TrnSalesLines;
                    if (salesLines.Any())
                    {
                        var salesLineItems = from d in salesLines
                                             group d by new
                                             {
                                                 d.ItemId
                                             } into g
                                             select new
                                             {
                                                 g.Key.ItemId,
                                                 TotalQuantity = g.Sum(s => s.Quantity)
                                             };

                        if (salesLineItems.Any())
                        {
                            foreach (var salesLineItem in salesLineItems)
                            {
                                var item = from d in db.MstItems where d.Id == salesLineItem.ItemId select d;
                                if (item.Any())
                                {
                                    Decimal totalSalesLineQuantity = 0;
                                    var allSalesLineItems = from d in db.TrnSalesLines
                                                            where d.ItemId == salesLineItem.ItemId
                                                            && d.TrnSale.IsLocked == true
                                                            && d.TrnSale.IsCancelled == false
                                                            select d;

                                    if (allSalesLineItems.Any())
                                    {
                                        totalSalesLineQuantity = allSalesLineItems.Sum(d => d.Quantity);
                                    }

                                    Decimal totalStockInLineQuantity = 0;
                                    var allStockInLineItems = from d in db.TrnStockInLines
                                                              where d.ItemId == salesLineItem.ItemId
                                                              && d.TrnStockIn.IsLocked == true
                                                              select d;


                                    if (allStockInLineItems.Any())
                                    {
                                        totalStockInLineQuantity = allStockInLineItems.Sum(d => d.Quantity);
                                    }

                                    var updateItem = item.FirstOrDefault();
                                    updateItem.OnhandQuantity = totalSalesLineQuantity - totalStockInLineQuantity;
                                    db.SubmitChanges();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // =====================
        // Update Item Inventory
        // =====================
        public void UpdateItemInventory(Int32 itemId)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
