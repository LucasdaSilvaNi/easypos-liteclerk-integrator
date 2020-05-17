using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstItemGroupItemController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

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
                                     ItemDescription = d.MstItem.ItemDescription,
                                     Alias = d.MstItem.Alias,
                                     ItemGroupId = d.ItemGroupId,
                                 };

            return itemGroupItems.OrderByDescending(d => d.Id).ToList();
        }

        // ================
        // List Search Item
        // ================
        public List<Entities.MstItemEntity> ListSearchItem(String filter)
        {
            var items = from d in db.MstItems
                        where d.BarCode.Contains(filter)
                        && d.IsInventory == true
                        || d.ItemDescription.Contains(filter)
                        || d.GenericName.Contains(filter)
                        select new Entities.MstItemEntity
                        {
                            Id = d.Id,
                            BarCode = d.BarCode,
                            ItemDescription = d.ItemDescription,
                            GenericName = d.GenericName,
                            Alias = d.Alias,
                            OutTaxId = d.OutTaxId,
                            OutTax = d.MstTax1.Tax,
                            OutTaxRate = d.MstTax1.Rate,
                            UnitId = d.UnitId,
                            Unit = d.MstUnit.Unit,
                            Price = d.Price,
                            OnhandQuantity = d.OnhandQuantity
                        };

            return items.OrderBy(d => d.ItemDescription).ToList();
        }

        // ===================
        // Add Item Group Item
        // ===================
        public String[] AddItemGroupItem(Entities.MstItemGroupItemEntity objItemGroupItem)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var itemGroup = from d in db.MstItemGroups
                                where d.Id == objItemGroupItem.ItemGroupId
                                select d;

                if (itemGroup.Any() == false)
                {
                    return new String[] { "Item group not found.", "0" };
                }

                var item = from d in db.MstItems
                           where d.Id == objItemGroupItem.ItemId
                           select d;

                if (item.Any() == false)
                {
                    return new String[] { "Item not found.", "0" };
                }

                Data.MstItemGroupItem newItemGroupItem = new Data.MstItemGroupItem
                {
                    ItemId = objItemGroupItem.ItemId,
                    ItemGroupId = objItemGroupItem.ItemGroupId
                };

                db.MstItemGroupItems.InsertOnSubmit(newItemGroupItem);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(newItemGroupItem);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstItemGroupItem",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddItemGroupItem"
                };

                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ======================
        // Update Item Group Item
        // ======================
        public String[] UpdateItemGroupItem(Int32 id, Entities.MstItemGroupItemEntity objItemGroupItem)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var itemGroupItem = from d in db.MstItemGroupItems
                                    where d.Id == id
                                    select d;

                if (itemGroupItem.Any())
                {
                    var itemGroup = from d in db.MstItemGroups
                                    where d.Id == objItemGroupItem.ItemGroupId
                                    select d;

                    if (itemGroup.Any() == false)
                    {
                        return new String[] { "Item group not found.", "0" };
                    }

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(itemGroupItem.FirstOrDefault());

                    var updateItemGroupItem = itemGroupItem.FirstOrDefault();
                    updateItemGroupItem.ItemId = objItemGroupItem.ItemId;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(itemGroupItem.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstItemGroupItem",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdateItemGroupItem"
                    };

                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Form not found.  " + id, "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ======================
        // Delete Item Group Item
        // ======================
        public String[] DeleteItemGroupItem(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var itemGroupItem = from d in db.MstItemGroupItems
                                    where d.Id == id
                                    select d;

                if (itemGroupItem.Any())
                {
                    var deleteItemGroupItem = itemGroupItem.FirstOrDefault();
                    db.MstItemGroupItems.DeleteOnSubmit(deleteItemGroupItem);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(itemGroupItem.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstItemGroupItem",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteItemGroupItem"
                    };

                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "Form not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
