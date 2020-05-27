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
            List<Entities.SysKitchenEntity> kitchens = new List<Entities.SysKitchenEntity>();
            for (Int32 i = 1; i <= 10; i++)
            {
                kitchens.Add(new Entities.SysKitchenEntity { Kitchen = "Kitchen " + i });
            }

            return kitchens;
        }

        public List<Entities.SysKitchenItemEntity> ListKitchenItems(String kitchen)
        {
            var salesLines = from d in db.TrnSalesLines
                             where d.MstItem.DefaultKitchenReport == kitchen
                             group d by d.MstItem.ItemDescription into g
                             select new Entities.SysKitchenItemEntity
                             {
                                 ItemDescription = g.Key
                             };

            return salesLines.OrderBy(d => d.ItemDescription).ToList();
        }
    }
}
