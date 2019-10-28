using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.TrnDisbursement
{
    public partial class TrnDisbursementDetailForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnDisbursementListForm trnDisbursementListForm;
        public Entities.TrnDisbursementEntity trnDisbursementEntity;

        public TrnDisbursementDetailForm(SysSoftwareForm softwareForm, TrnDisbursementListForm disbursementListForm, Entities.TrnDisbursementEntity disbursementEntity)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnDisbursementListForm = disbursementListForm;
            trnDisbursementEntity = disbursementEntity;
        }
    }
}
