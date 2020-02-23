using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstTableGroupController
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

        // ================
        // List Table Group 
        // ================
        public List<Entities.MstTableGroupEntity> ListTableGroup(String filter)
        {
            var tableGroups = from d in db.MstTableGroups
                             where d.TableGroup.Contains(filter)
                             select new Entities.MstTableGroupEntity
                             {
                                 Id = d.Id,
                                 TableGroup = d.TableGroup,
                                 EntryUserId = d.EntryUserId,
                                 EntryUserName = d.MstUser.UserName,
                                 EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                 UpdateUserId = d.UpdateUserId,
                                 UpdatedUserName = d.MstUser1.UserName,
                                 UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                                 IsLocked = d.IsLocked,
                             };

            return tableGroups.OrderByDescending(d => d.Id).ToList();
        }

        // ==================
        // Detail Table Group
        // ==================
        public Entities.MstTableGroupEntity DetailTableGroup(Int32 id)
        {
            var tableGroup = from d in db.MstTableGroups
                            where d.Id == id
                            select new Entities.MstTableGroupEntity
                            {
                                Id = d.Id,
                                TableGroup = d.TableGroup,
                                EntryUserId = d.EntryUserId,
                                EntryUserName = d.MstUser.UserName,
                                EntryDateTime = d.EntryDateTime.ToShortDateString(),
                                UpdateUserId = d.UpdateUserId,
                                UpdatedUserName = d.MstUser1.UserName,
                                UpdateDateTime = d.UpdateDateTime.ToShortDateString(),
                                IsLocked = d.IsLocked,
                            };

            return tableGroup.FirstOrDefault();
        }

        // ===============
        // Add Table Group
        // ===============
        public String[] AddTableGroup()
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                Data.MstTableGroup newTableGroup = new Data.MstTableGroup()
                {
                    TableGroup = "",
                    EntryUserId = currentUserLogin.FirstOrDefault().Id,
                    EntryDateTime = DateTime.Now,
                    UpdateUserId = currentUserLogin.FirstOrDefault().Id,
                    UpdateDateTime = DateTime.Now,
                    IsLocked = false
                };

                db.MstTableGroups.InsertOnSubmit(newTableGroup);
                db.SubmitChanges();

                String newObject = Modules.SysAuditTrailModule.GetObjectString(newTableGroup);

                Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                {
                    UserId = currentUserLogin.FirstOrDefault().Id,
                    AuditDate = DateTime.Now,
                    TableInformation = "MstTableGroup",
                    RecordInformation = "",
                    FormInformation = newObject,
                    ActionInformation = "AddTableGroup"
                };
                Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                return new String[] { "", newTableGroup.Id.ToString() };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ================
        // Lock Table Group
        // ================
        public String[] LockTableGroup(Int32 id, Entities.MstTableGroupEntity objTableGroup)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var tableGroup = from d in db.MstTableGroups
                                where d.Id == id
                                select d;

                if (tableGroup.Any())
                {
                    if (tableGroup.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "Already locked.", "0" };
                    }

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(tableGroup.FirstOrDefault());

                    var lockTableGroup = tableGroup.FirstOrDefault();
                    lockTableGroup.TableGroup = objTableGroup.TableGroup;
                    lockTableGroup.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    lockTableGroup.UpdateDateTime = DateTime.Now;
                    lockTableGroup.IsLocked = true;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(tableGroup.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstTableGroup",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "LockTableGroup"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "TableGroup not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==================
        // Unlock Table Group
        // ==================
        public String[] UnlockTableGroup(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var tableGroup = from d in db.MstTableGroups
                                where d.Id == id
                                select d;

                if (tableGroup.Any())
                {
                    if (tableGroup.FirstOrDefault().IsLocked == false)
                    {
                        return new String[] { "Already unlocked.", "0" };
                    }

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(tableGroup.FirstOrDefault());

                    var unlockTableGroup = tableGroup.FirstOrDefault();
                    unlockTableGroup.IsLocked = false;
                    unlockTableGroup.UpdateUserId = currentUserLogin.FirstOrDefault().Id;
                    unlockTableGroup.UpdateDateTime = DateTime.Now;
                    db.SubmitChanges();

                    String newObject = Modules.SysAuditTrailModule.GetObjectString(tableGroup.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstTableGroup",
                        RecordInformation = oldObject,
                        FormInformation = newObject,
                        ActionInformation = "UnlockTableGroup"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "TableGroup not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ==================
        // Delete Table Group
        // ==================
        public String[] DeleteTableGroup(Int32 id)
        {
            try
            {
                var currentUserLogin = from d in db.MstUsers where d.Id == Convert.ToInt32(Modules.SysCurrentModule.GetCurrentSettings().CurrentUserId) select d;
                if (currentUserLogin.Any() == false)
                {
                    return new String[] { "Current login user not found.", "0" };
                }

                var tableGroup = from d in db.MstTableGroups
                                where d.Id == id
                                select d;

                if (tableGroup.Any())
                {
                    if (tableGroup.FirstOrDefault().IsLocked)
                    {
                        return new String[] { "TableGroup is locked", "0" };
                    }

                    var deleteTableGroup = tableGroup.FirstOrDefault();
                    db.MstTableGroups.DeleteOnSubmit(deleteTableGroup);

                    String oldObject = Modules.SysAuditTrailModule.GetObjectString(tableGroup.FirstOrDefault());

                    Entities.SysAuditTrailEntity newAuditTrail = new Entities.SysAuditTrailEntity()
                    {
                        UserId = currentUserLogin.FirstOrDefault().Id,
                        AuditDate = DateTime.Now,
                        TableInformation = "MstTableGroup",
                        RecordInformation = oldObject,
                        FormInformation = "",
                        ActionInformation = "DeleteTableGroup"
                    };
                    Modules.SysAuditTrailModule.InsertAuditTrail(newAuditTrail);

                    db.SubmitChanges();

                    return new String[] { "", "1" };
                }
                else
                {
                    return new String[] { "TableGroup not found.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
