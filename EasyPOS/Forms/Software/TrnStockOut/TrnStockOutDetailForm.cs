using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnStockOut
{
    public partial class TrnStockOutDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnStockOutListForm trnStockOutListForm;
        public Entities.TrnStockOutEntity trnStockOutEntity;

        public TrnStockOutDetailForm(SysSoftwareForm softwareForm, TrnStockOutListForm stockOutListForm, Entities.TrnStockOutEntity stockOutEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnStockOutListForm = stockOutListForm;
            trnStockOutEntity = stockOutEntity;
        }
    }
}
