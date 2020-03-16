using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstItemComponentController
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

        // ===================
        // Item Component List
        // ===================
        public List<Entities.MstItemComponentEntity> ItemComponentList(Int32 itemId)
        {
            var itemComponent = from d in db.MstItemComponents
                                where d.ItemId == itemId
                                && d.MstItem1.IsInventory == true
                                select new Entities.MstItemComponentEntity
                                {
                                    Id = d.Id,
                                    ItemId = d.ItemId,
                                    ItemDescription = d.MstItem.ItemDescription,
                                    ComponentItemId = d.ComponentItemId,
                                    ComponentItemDescription = d.MstItem1.ItemDescription,
                                    UnitId = d.UnitId,
                                    Unit = d.MstUnit.Unit,
                                    Quantity = d.Quantity,
                                    Cost = d.Cost,
                                    Amount = d.Amount,
                                    OnHandQuantity = d.MstItem1.OnhandQuantity,
                                    IsPrinted = d.IsPrinted
                                };

            return itemComponent.OrderByDescending(d => d.Id).ToList();
        }

        // ====================
        // Dropdown - Item List
        // ====================
        public List<Entities.MstItemEntity> DropdownListItem(Int32 itemId)
        {
            var items = from d in db.MstItems
                        where d.IsInventory == true
                        && d.Id != itemId
                        select new Entities.MstItemEntity
                        {
                            Id = d.Id,
                            ItemDescription = d.ItemDescription,
                            Unit = d.MstUnit.Unit,
                            Cost = d.Cost,
                            OnhandQuantity = d.OnhandQuantity,
                        };

            return items.OrderBy(d => d.ItemDescription).ToList();
        }

        // ==================
        // Add Item Component
        // ==================
        public String[] AddItemComponent(Entities.MstItemComponentEntity objItemComponent)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var componentItem = from d in db.MstItems
                                    where d.Id == objItemComponent.ComponentItemId
                                    select d;

                if (componentItem.Any() == false)
                {
                    return new String[] { "Item component not found.", "0" };
                }

                Data.MstItemComponent addComponent = new Data.MstItemComponent()
                {
                    ItemId = objItemComponent.ItemId,
                    ComponentItemId = objItemComponent.ComponentItemId,
                    UnitId = componentItem.First().UnitId,
                    Quantity = objItemComponent.Quantity,
                    Cost = objItemComponent.Cost,
                    Amount = objItemComponent.Amount,
                    IsPrinted = false
                };

                db.MstItemComponents.InsertOnSubmit(addComponent);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(addComponent);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstItemComponent",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddItemComponent"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Update Item Component
        // =====================
        public String[] UpdateItemComponent(Entities.MstItemComponentEntity objItemComponent)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var itemComponent = from d in db.MstItemComponents
                                    where d.Id == objItemComponent.Id
                                    select d;

                if (itemComponent.Any())
                {
                    var componentItem = from d in db.MstItems
                                        where d.Id == objItemComponent.ComponentItemId
                                        select d;

                    if (componentItem.Any() == false)
                    {
                        return new String[] { "Component item not found.", "0" };
                    }

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(itemComponent.FirstOrDefault());

                    var updateItemComponent = itemComponent.FirstOrDefault();
                    updateItemComponent.ComponentItemId = objItemComponent.ComponentItemId;
                    updateItemComponent.UnitId = componentItem.FirstOrDefault().UnitId;
                    updateItemComponent.Quantity = objItemComponent.Quantity;
                    updateItemComponent.Cost = objItemComponent.Cost;
                    updateItemComponent.Amount = objItemComponent.Amount;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(itemComponent.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstItemComponent",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UpdateItemComponent"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item Component not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =====================
        // Delete Item Component
        // =====================
        public String[] DeleteItemComponent(int id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var itemComponent = from d in db.MstItemComponents
                                    where d.Id == id
                                    select d;

                if (itemComponent.Any())
                {
                    var deleteItemComponent = itemComponent.FirstOrDefault();
                    db.MstItemComponents.DeleteOnSubmit(deleteItemComponent);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(itemComponent.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstItemComponent",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteItemComponent"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "" };
                }
                else
                {
                    return new String[] { "Item Component not found!", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
