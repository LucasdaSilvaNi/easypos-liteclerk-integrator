using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Modules
{
    class SysAuditTrailModule
    {
        // ============
        // Data Context
        // ============
        public static Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==================
        // Insert Audit Trail
        // ==================
        public static void InsertAuditTrail(Entities.SysAuditTrailEntity objAuditTrail)
        {
            try
            {
                var currentUser = from d in db.MstUsers where d.Id == objAuditTrail.UserId select d;
                if (currentUser.Any())
                {
                    if (SysCurrentModule.GetCurrentSettings().ActivateAuditTrail == true)
                    {
                        Data.SysAuditTrail newAuditTrail = new Data.SysAuditTrail
                        {
                            AuditDate = objAuditTrail.AuditDate,
                            UserId = objAuditTrail.UserId,
                            TableInformation = objAuditTrail.TableInformation,
                            RecordInformation = objAuditTrail.RecordInformation,
                            FormInformation = objAuditTrail.FormInformation,
                            ActionInformation = objAuditTrail.ActionInformation
                        };

                        db.SysAuditTrails.InsertOnSubmit(newAuditTrail);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // =================
        // Get Object String
        // =================
        public static String GetObjectString<T>(T obj)
        {
            String json = "";

            var properties = obj.GetType().GetProperties().Where(p => p.PropertyType.IsSerializable == true);
            if (properties.Any())
            {
                dynamic flexible = new ExpandoObject();
                var dictionary = (IDictionary<string, object>)flexible;

                foreach (PropertyInfo property in properties)
                {
                    dictionary.Add(property.Name, property.GetValue(obj));
                }

                var serialized = JsonConvert.SerializeObject(dictionary);

                json = serialized;
            }

            return json;
        }
    }
}
