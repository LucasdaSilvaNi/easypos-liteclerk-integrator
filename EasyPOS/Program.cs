using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Software.SysSoftwareForm());
            //Application.Run(new Forms.Account.SysLogin.SysLoginForm());
            //Application.Run(new Reports.RepDeliveryReceiptReportForm(288431, 1011071, false));
        }
    }
}
