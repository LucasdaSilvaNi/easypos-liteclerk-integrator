﻿using System;
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
    public partial class TrnSalesListForm : Form
    {
        SoftwareForm softwareForm;
        public TrnSalesListForm(SoftwareForm form)
        {
            InitializeComponent();
            softwareForm = form;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            softwareForm.RemoveTabPage();
        }

        private void buttonSales_Click(object sender, EventArgs e)
        {
            softwareForm.AddTabPagePOSSalesDetail();
        }
    }
}
