using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.SysSystemTables
{
    public partial class SysSystemTablesSupplierDetailForm : Form
    {
        SysSystemTablesForm sysSystemTablesForm;
        Entities.MstSupplierEntity mstSupplierEntity;
        public SysSystemTablesSupplierDetailForm(SysSystemTablesForm systemTablesForm, Entities.MstSupplierEntity supplierEntity)
        {
            InitializeComponent();
            sysSystemTablesForm = systemTablesForm;
            mstSupplierEntity = supplierEntity;
        }

    }
}
