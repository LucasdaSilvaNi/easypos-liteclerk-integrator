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
    public partial class TrnSalesListCancelRemarksForm : Form
    {
        public SysSoftwareForm sysSoftwareForm;
        public TrnSalesListForm trnSalesListForm;

        public TrnSalesListCancelRemarksForm(SysSoftwareForm softwareForm, TrnSalesListForm salesListForm)
        {
            InitializeComponent();

            sysSoftwareForm = softwareForm;
            trnSalesListForm = salesListForm;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            String remarks = textBoxCancelRemarks.Text;
            trnSalesListForm.SetCancelRemarks(remarks);
            Close();
        }
    }
}
