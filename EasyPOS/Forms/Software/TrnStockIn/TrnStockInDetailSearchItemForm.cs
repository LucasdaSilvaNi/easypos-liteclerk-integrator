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
    public partial class TrnStockInDetailSearchItemForm : Form
    {
        public TrnStockInDetailForm trnStockInDetailForm;
        public Entities.TrnStockInEntity trnStockInEntity;

        public TrnStockInDetailSearchItemForm(TrnStockInDetailForm stockInDetailForm, Entities.TrnStockInEntity stockInEntity)
        {
            InitializeComponent();

            trnStockInDetailForm = stockInDetailForm;
            trnStockInEntity = stockInEntity;
        }
    }
}
