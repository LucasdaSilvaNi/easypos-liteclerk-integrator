using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnStockIn
{
    public partial class TrnStockInDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnStockInListForm trnStockInListForm;
        public Entities.TrnStockInEntity trnStockInEntity;

        public TrnStockInDetailForm(SysSoftwareForm softwareForm, TrnStockInListForm stockInListForm, Entities.TrnStockInEntity stockInEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnStockInListForm = stockInListForm;
            trnStockInEntity = stockInEntity;
        }
    }
}
