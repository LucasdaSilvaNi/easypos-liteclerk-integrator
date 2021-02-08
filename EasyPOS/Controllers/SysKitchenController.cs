using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class SysKitchenController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =============
        // List Kitchens
        // =============
        public List<Entities.SysKitchenEntity> ListKitchen()
        {
            List<Entities.SysKitchenEntity> kitchens = new List<Entities.SysKitchenEntity>()
            {
                new Entities.SysKitchenEntity { Kitchen = "Main Course Kitchen" },
                new Entities.SysKitchenEntity { Kitchen = "Beverages" },
                new Entities.SysKitchenEntity { Kitchen = "Barbecue Station" }
            };

            return kitchens;
        }
        // ==========================
        // Dropdown List Order Number
        // ==========================
        public List<Entities.SysKitchenItemEntity> DropdownListOrderNumber(String kitchen, DateTime salesDate)
        {
            var OrderedNumber = from d in db.TrnSalesLines
                                where d.IsPrepared == false
                               && d.MstItem.DefaultKitchenReport == kitchen
                               && d.TrnSale.SalesDate == salesDate
                               && d.TrnSale.IsLocked == true
                               && d.TrnSale.IsCancelled == false
                               && d.TrnSale.IsDispatched == false
                                group d by new
                                {
                                    d.SalesId,
                                    d.TrnSale.ManualInvoiceNumber,
                                } into g
                                select new Entities.SysKitchenItemEntity
                                {
                                    SalesId = g.Key.SalesId,
                                    OrderNumber = g.Key.ManualInvoiceNumber,
                                };
            return OrderedNumber.ToList();
        }
        public List<Entities.SysKitchenItemEntity> ListKitchenItems(String kitchen, DateTime salesDate, Int32 salesId)
        {
            if(salesId == 0)
            {
                var salesLines = from d in db.TrnSalesLines
                                 where d.IsPrepared == false
                                 && d.MstItem.DefaultKitchenReport == kitchen
                                 && d.TrnSale.SalesDate == salesDate
                                 && d.TrnSale.IsLocked == true
                                 && d.TrnSale.IsCancelled == false
                                 && d.TrnSale.IsDispatched == false
                                 group d by new
                                 {
                                     d.SalesId,
                                     d.TrnSale.ManualInvoiceNumber,
                                     d.MstItem.BarCode,
                                     d.MstItem.Alias,
                                     d.MstItem.MstUnit.Unit,
                                     d.IsPrepared,
                                     d.Preparation,
                                     d.TrnSale.UpdateDateTime,
                                 } into g
                                 select new Entities.SysKitchenItemEntity
                                 {
                                     SalesId = g.Key.SalesId,
                                     OrderNumber = g.Key.ManualInvoiceNumber,
                                     BarCode = g.Key.BarCode,
                                     Alias = g.Key.Alias,
                                     Unit = g.Key.Unit,
                                     IsPrepared = g.Key.IsPrepared,
                                     Preparation = g.Key.Preparation,
                                     Quantity = g.Sum(d => d.Quantity),
                                     UpdateDateTime = g.Key.UpdateDateTime.ToString()
                                 };

                return salesLines.ToList();
            }
            else
            {
                var salesLines = from d in db.TrnSalesLines
                                 where d.IsPrepared == false
                                 && d.MstItem.DefaultKitchenReport == kitchen
                                 && d.TrnSale.SalesDate == salesDate
                                 && d.TrnSale.IsLocked == true
                                 && d.TrnSale.IsCancelled == false
                                 && d.TrnSale.IsDispatched == false
                                 && d.SalesId == salesId
                                 group d by new
                                 {
                                     d.SalesId,
                                     d.TrnSale.ManualInvoiceNumber,
                                     d.MstItem.BarCode,
                                     d.MstItem.Alias,
                                     d.MstItem.MstUnit.Unit,
                                     d.IsPrepared,
                                     d.Preparation,
                                     d.TrnSale.UpdateDateTime,
                                 } into g
                                 select new Entities.SysKitchenItemEntity
                                 {
                                     SalesId = g.Key.SalesId,
                                     OrderNumber = g.Key.ManualInvoiceNumber,
                                     BarCode = g.Key.BarCode,
                                     Alias = g.Key.Alias,
                                     Unit = g.Key.Unit,
                                     IsPrepared = g.Key.IsPrepared,
                                     Preparation = g.Key.Preparation,
                                     Quantity = g.Sum(d => d.Quantity),
                                     UpdateDateTime = g.Key.UpdateDateTime.ToString()
                                 };

                return salesLines.ToList();
            }
        }

        public String[] DonePrepareItem(Int32 salesId, String itemBarcode)
        {
            try
            {
                var salesLines = from d in db.TrnSalesLines
                                 where d.SalesId == salesId
                                 && d.MstItem.BarCode == itemBarcode
                                 select d;

                if (salesLines.Any())
                {
                    foreach (var salesLine in salesLines)
                    {
                        salesLine.IsPrepared = true;
                        db.SubmitChanges();
                    }

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

        public List<Entities.SysKitchenItemEntity> ListKitchenPreparedItems(String kitchen, DateTime salesDate)
        {
            var salesLines = from d in db.TrnSalesLines
                             where d.IsPrepared == true
                             && d.MstItem.DefaultKitchenReport == kitchen
                             && d.TrnSale.SalesDate == salesDate
                             && d.TrnSale.IsLocked == true
                             && d.TrnSale.IsCancelled == false
                             && d.TrnSale.IsDispatched == false
                             group d by new
                             {
                                 d.SalesId,
                                 d.TrnSale.ManualInvoiceNumber,
                                 d.MstItem.BarCode,
                                 d.MstItem.Alias,
                                 d.MstItem.MstUnit.Unit,
                                 d.IsPrepared,
                                 d.Preparation,
                                 d.TrnSale.UpdateDateTime

                             } into g
                             select new Entities.SysKitchenItemEntity
                             {
                                 SalesId = g.Key.SalesId,
                                 OrderNumber = g.Key.ManualInvoiceNumber,
                                 BarCode = g.Key.BarCode,
                                 Alias = g.Key.Alias,
                                 Unit = g.Key.Unit,
                                 IsPrepared = g.Key.IsPrepared,
                                 Preparation = g.Key.Preparation,
                                 Quantity = g.Sum(d => d.Quantity),
                                 UpdateDateTime = g.Key.UpdateDateTime.ToString()
                             };

            return salesLines.ToList();
        }

    }
}
