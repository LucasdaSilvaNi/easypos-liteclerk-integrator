using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstItemPriceController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ===============
        // List Item Price
        // ===============
        public List<Entities.MstItemPriceEntity> ListItemPrice(Int32 itemId)
        {
            var itemPrices = from d in db.MstItemPrices
                             where d.ItemId == itemId
                             select new Entities.MstItemPriceEntity
                             {
                                 Id = d.Id,
                                 PriceDescription = d.PriceDescription,
                                 Price = d.Price,
                                 TriggerQuantity = d.TriggerQuantity
                             };

            return itemPrices.OrderByDescending(d => d.Id).ToList();
        }

        // ==============
        // Add Item Price
        // ==============
        public String[] AddItemPrice(Entities.MstItemPriceEntity objItemPrice)
        {
            try
            {
                Data.MstItemPrice addItemPrice = new Data.MstItemPrice()
                {
                    ItemId = objItemPrice.ItemId,
                    PriceDescription = objItemPrice.PriceDescription,
                    Price = objItemPrice.Price,
                    TriggerQuantity = objItemPrice.TriggerQuantity
                };

                db.MstItemPrices.InsertOnSubmit(addItemPrice);
                db.SubmitChanges();

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Update Item Price
        // =================
        public String[] UpdateItemPrice(Entities.MstItemPriceEntity objItemPrice)
        {
            try
            {
                var itemPrice = from d in db.MstItemPrices
                                where d.Id == objItemPrice.Id
                                select d;

                if (itemPrice.Any())
                {
                    var updateItemPrice = itemPrice.FirstOrDefault();
                    updateItemPrice.PriceDescription = objItemPrice.PriceDescription;
                    updateItemPrice.Price = objItemPrice.Price;
                    updateItemPrice.TriggerQuantity = objItemPrice.TriggerQuantity;
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item price not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =================
        // Delete Item Price
        // =================
        public String[] DeleteItemPrice(Int32 id)
        {
            try
            {
                var itemPrice = from d in db.MstItemPrices
                                where d.Id == id
                                select d;

                if (itemPrice.Any())
                {
                    var deleteItemPrice = itemPrice.FirstOrDefault();
                    db.MstItemPrices.DeleteOnSubmit(deleteItemPrice);
                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item price not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
