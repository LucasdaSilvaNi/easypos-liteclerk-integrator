using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Controllers
{
    class SysLoginController
    {
        // ============
        // Data Context
        // ============
        public Data.easyposdbDataContext db = new Data.easyposdbDataContext(Modules.SysConnectionStringModule.GetConnectionString());

        // =====
        // Login
        // =====
        public String[] Login(String username, String password)
        {
            try
            {
                var currentUser = from d in db.MstUsers
                                  where d.UserName.Equals(username)
                                  && d.Password.Equals(password)
                                  select d;

                if (currentUser.Any())
                {
                    return new String[] { "", currentUser.FirstOrDefault().Id.ToString() };
                }
                else
                {
                    return new String[] { "Username or password is incorrect.", "0" };
                }
            }
            catch (Exception e)
            {
                return new String[] { e.Message, "0" };
            }
        }
    }
}
