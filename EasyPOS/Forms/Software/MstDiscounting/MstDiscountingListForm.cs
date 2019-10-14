using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPOS.Forms.Software.MstDiscounting
{
    public partial class MstDiscountingListForm : Form
    {
        SoftwareForm softwareForm;
        public MstDiscountingListForm(SoftwareForm form)
        {
            InitializeComponent();
            softwareForm = form;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            softwareForm.RemoveTabPage();
        }
    }
}
