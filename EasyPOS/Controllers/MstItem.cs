using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class MstItem
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // ==========
        // List Items
        // ==========
        public List<Entities.MstItem> ListItem(String filter)
        {
            return new List<Entities.MstItem>();
        }

        // ===========
        // Detail Item
        // ===========
        public Entities.MstItem DetailItem(Int32 id)
        {
            return new Entities.MstItem();
        }

        // ========
        // Add Item
        // ========
        public String[] AddItem()
        {
            try
            {
                return new String[] { "", "1" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // =========
        // Lock Item
        // =========
        public String[] LockItem(Int32 id, Entities.MstItem objItem)
        {
            try
            {
                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Unlock Item
        // ===========
        public String[] UnlockItem(Int32 id)
        {
            try
            {
                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }

        // ===========
        // Delete Item
        // ===========
        public String[] DeleteItem(Int32 id)
        {
            try
            {
                return new String[] { "", "" };
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
