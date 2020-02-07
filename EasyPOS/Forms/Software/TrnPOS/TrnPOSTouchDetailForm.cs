using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnPOS
{
    public partial class TrnPOSTouchDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        private Modules.SysUserRightsModule sysUserRights;

        public TrnPOSTouchForm trnPOSTouchForm;
        public Entities.TrnSalesEntity trnSalesEntity;

        public TrnPOSTouchDetailForm(SysSoftwareForm softwareForm, TrnPOSTouchForm POSTouchForm, Entities.TrnSalesEntity salesEntity)
        {
            InitializeComponent();
        }
    }
}
